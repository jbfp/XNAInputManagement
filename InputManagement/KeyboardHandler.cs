using Microsoft.Xna.Framework.Input;

namespace InputManagement
{
    /// <summary>
    ///     Represents the current and previous <see cref="KeyboardState" />.
    /// </summary>
    public static class KeyboardHandler
    {
        private static KeyboardState _previousKeyboardState;
        private static KeyboardState _currentKeyboardState;

        /// <summary>
        ///     Gets a value indicating whether the specified key is down this frame.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     A value indiciating whether <paramref name="key" /> is down or not.
        /// </returns>
        public static bool IsKeyDown(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        ///     Gets a value indicating whether the specified key is up this frame.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     A value indiciating whether <paramref name="key" /> is up or not.
        /// </returns>
        public static bool IsKeyUp(Keys key)
        {
            return _currentKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        ///     Gets a value indicating whether the specified key is down this frame
        ///     and that the specified key was down last frame.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     A value indiciating whether <paramref name="key" /> is pressed or not.
        /// </returns>
        public static bool IsKeyPressed(Keys key)
        {
            return IsKeyDown(key) && WasKeyUp(key);
        }

        /// <summary>
        ///     Gets a value indicating whether the specified key was down last frame.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     A value indiciating whether <paramref name="key" /> was down or not.
        /// </returns>
        public static bool WasKeyDown(Keys key)
        {
            return _previousKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        ///     Gets a value indicating whether the specified key was up last frame.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     A value indiciating whether <paramref name="key" /> was up or not.
        /// </returns>
        public static bool WasKeyUp(Keys key)
        {
            return _previousKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        ///     Updates the keyboard states.
        ///     This is necessary to check for changes in key states.
        /// </summary>
        public static void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }
    }
}