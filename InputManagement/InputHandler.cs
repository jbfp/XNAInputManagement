using Microsoft.Xna.Framework;

namespace InputManagement
{
    /// <summary>
    ///     Helps update all input handlers.
    /// </summary>
    public class InputHandler : GameComponent
    {
        /// <summary>
        ///     Initializes a new instance of <see cref="InputHandler" />.
        /// </summary>
        /// <param name="game">
        ///     The game to which this <see cref="GameComponent" /> belongs.
        /// </param>
        public InputHandler(Game game)
            : base(game)
        {
        }

        /// <summary>
        ///     Called when the GameComponent needs to be updated. Override this method with component-specific update code.
        /// </summary>
        /// <param name="gameTime">Time elapsed since the last call to Update</param>
        public override void Update(GameTime gameTime)
        {
            Update();
        }

        /// <summary>
        ///     Updates <see cref="KeyboardHandler" />, <see cref="MouseHandler" />, and <see cref="GamePadHandler" /> states.
        /// </summary>
        public static void Update()
        {
            KeyboardHandler.Update();
            MouseHandler.Update();
            GamePadHandler.Update();
        }
    }
}