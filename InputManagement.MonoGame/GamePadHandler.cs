using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace InputManagement.MonoGame
{
    /// <summary>
    ///     Represents the current and previous <see cref="GamePadState" />.
    /// </summary>
    public static class GamePadHandler
    {
        private static readonly IDictionary<PlayerIndex, GamePadStates> PlayerGamePadStates =
            new ConcurrentDictionary<PlayerIndex, GamePadStates>(4, 4);

        static GamePadHandler()
        {
            PlayerGamePadStates.Add(new KeyValuePair<PlayerIndex, GamePadStates>(PlayerIndex.One, new GamePadStates()));
            PlayerGamePadStates.Add(new KeyValuePair<PlayerIndex, GamePadStates>(PlayerIndex.Two, new GamePadStates()));
            PlayerGamePadStates.Add(new KeyValuePair<PlayerIndex, GamePadStates>(PlayerIndex.Three, new GamePadStates()));
            PlayerGamePadStates.Add(new KeyValuePair<PlayerIndex, GamePadStates>(PlayerIndex.Four, new GamePadStates()));
        }

        /// <summary>
        ///     Gets a value indicating whether the specified button for the specified player is down or not.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="playerIndex">The player.</param>
        /// <returns>
        ///     A value indicating whether <paramref name="button" /> is down for <paramref name="playerIndex" />.
        /// </returns>
        public static bool IsButtonDown(Buttons button, PlayerIndex playerIndex)
        {
            return PlayerGamePadStates[playerIndex].CurrentGamePadState.IsButtonDown(button);
        }

        /// <summary>
        ///     Gets a value indicating whether the specified button for the specified player is up or not.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="playerIndex">The player.</param>
        /// <returns>
        ///     A value indicating whether <paramref name="button" /> is up for <paramref name="playerIndex" />.
        /// </returns>
        public static bool IsButtonUp(Buttons button, PlayerIndex playerIndex)
        {
            return PlayerGamePadStates[playerIndex].CurrentGamePadState.IsButtonUp(button);
        }

        /// <summary>
        ///     Gets a value indicating whether the specified button for the specified player was down or not.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="playerIndex">The player.</param>
        /// <returns>
        ///     A value indicating whether <paramref name="button" /> was down for <paramref name="playerIndex" />.
        /// </returns>
        public static bool WasButtonDown(Buttons button, PlayerIndex playerIndex)
        {
            return PlayerGamePadStates[playerIndex].PreviousGamePadState.IsButtonDown(button);
        }

        /// <summary>
        ///     Gets a value indicating whether the specified button for the specified player was up or not.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="playerIndex">The player.</param>
        /// <returns>
        ///     A value indicating whether <paramref name="button" /> was up for <paramref name="playerIndex" />.
        /// </returns>
        public static bool WasButtonUp(Buttons button, PlayerIndex playerIndex)
        {
            return PlayerGamePadStates[playerIndex].PreviousGamePadState.IsButtonUp(button);
        }

        /// <summary>
        ///     Gets a value indicating whether the specified button for the specified player is pressed or not.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="playerIndex">The player.</param>
        /// <returns>
        ///     A value indicating whether <paramref name="button" /> is pressed for <paramref name="playerIndex" />.
        /// </returns>
        public static bool IsButtonPressed(Buttons button, PlayerIndex playerIndex)
        {
            GamePadStates gamePadState = PlayerGamePadStates[playerIndex];
            return gamePadState.CurrentGamePadState.IsButtonDown(button) &&
                   gamePadState.PreviousGamePadState.IsButtonUp(button);
        }

        /// <summary>
        ///     Gets the left stick value of the game pad for the specified player.
        /// </summary>
        /// <param name="playerIndex">The player.</param>
        /// <returns>The left stick value.</returns>
        public static Vector2 GetLeftStick(PlayerIndex playerIndex)
        {
            return PlayerGamePadStates[playerIndex].CurrentGamePadState.ThumbSticks.Left;
        }

        /// <summary>
        ///     Gets the right stick value of the game pad for the specified player.
        /// </summary>
        /// <param name="playerIndex">The player.</param>
        /// <returns>The right stick value.</returns>
        public static Vector2 GetRightStick(PlayerIndex playerIndex)
        {
            return PlayerGamePadStates[playerIndex].CurrentGamePadState.ThumbSticks.Right;
        }

        /// <summary>
        ///     Updates the game pad states.
        ///     This is necessary to check for changes in game pad button states.
        /// </summary>
        public static void Update()
        {
            foreach (var gamePadStates in PlayerGamePadStates)
            {
                gamePadStates.Value.PreviousGamePadState = gamePadStates.Value.CurrentGamePadState;
                gamePadStates.Value.CurrentGamePadState = GamePad.GetState(gamePadStates.Key);
            }
        }

        private class GamePadStates
        {
            public GamePadState PreviousGamePadState { get; set; }
            public GamePadState CurrentGamePadState { get; set; }
        }
    }
}