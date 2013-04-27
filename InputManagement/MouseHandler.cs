using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace InputManagement
{
    /// <summary>
    ///     Represents the current and previous <see cref="MouseState" />.
    /// </summary>
    public static class MouseHandler
    {
        private static MouseState _previousMouseState;
        private static MouseState _currentMouseState;

        /// <summary>
        ///     Gets or sets the mouse location.
        /// </summary>
        public static Point Location
        {
            get { return new Point(_currentMouseState.X, _currentMouseState.Y); }
            set
            {
                Mouse.SetPosition(value.X, value.Y);
                Update();
            }
        }

        /// <summary>
        ///     Gets the changes in the horizontal position of the mouse pointer.
        /// </summary>
        public static int DeltaX
        {
            get { return _currentMouseState.X - _previousMouseState.X; }
        }

        /// <summary>
        ///     Gets the changes in the vertical position of the mouse pointer.
        /// </summary>
        public static int DeltaY
        {
            get { return _currentMouseState.Y - _previousMouseState.Y; }
        }

        /// <summary>
        ///     Gets the current scroll wheel value.
        /// </summary>
        public static int ScrollWheelValue
        {
            get { return _currentMouseState.ScrollWheelValue; }
        }

        /// <summary>
        ///     Gets the change in scroll wheel value from the previous frame to the current frame.
        /// </summary>
        public static int ScrollWheelValueDelta
        {
            get { return _currentMouseState.ScrollWheelValue - _previousMouseState.ScrollWheelValue; }
        }

        /// <summary>
        ///     Gets a value indicating whether the specified button is pressed or not.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <returns>
        ///     A value indicating whether <paramref name="button" /> is pressed or not.
        /// </returns>
        public static bool IsButtonPressed(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return _currentMouseState.LeftButton == ButtonState.Pressed &&
                           _previousMouseState.LeftButton == ButtonState.Released;
                case MouseButtons.Right:
                    return _currentMouseState.RightButton == ButtonState.Pressed &&
                           _previousMouseState.RightButton == ButtonState.Released;
                case MouseButtons.Middle:
                    return _currentMouseState.MiddleButton == ButtonState.Pressed &&
                           _previousMouseState.MiddleButton == ButtonState.Released;
                case MouseButtons.XButton1:
                    return _currentMouseState.XButton1 == ButtonState.Pressed &&
                           _previousMouseState.XButton1 == ButtonState.Released;
                case MouseButtons.XButton2:
                    return _currentMouseState.XButton2 == ButtonState.Pressed &&
                           _previousMouseState.XButton2 == ButtonState.Released;
                default:
                    return false;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the specified button is down or not.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <returns>
        ///     A value indicating whether <paramref name="button" /> is down or not.
        /// </returns>
        public static bool IsButtonDown(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return _currentMouseState.LeftButton == ButtonState.Pressed;
                case MouseButtons.Right:
                    return _currentMouseState.RightButton == ButtonState.Pressed;
                case MouseButtons.Middle:
                    return _currentMouseState.MiddleButton == ButtonState.Pressed;
                case MouseButtons.XButton1:
                    return _currentMouseState.XButton1 == ButtonState.Pressed;
                case MouseButtons.XButton2:
                    return _currentMouseState.XButton2 == ButtonState.Pressed;
                default:
                    return false;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the specified button was down or not.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <returns>
        ///     A value indicating whether <paramref name="button" /> was down or not.
        /// </returns>
        public static bool WasButtonDown(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return _previousMouseState.LeftButton == ButtonState.Pressed;
                case MouseButtons.Right:
                    return _previousMouseState.RightButton == ButtonState.Pressed;
                case MouseButtons.Middle:
                    return _previousMouseState.MiddleButton == ButtonState.Pressed;
                case MouseButtons.XButton1:
                    return _previousMouseState.XButton1 == ButtonState.Pressed;
                case MouseButtons.XButton2:
                    return _previousMouseState.XButton2 == ButtonState.Pressed;
                default:
                    return false;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the specified button is up or not.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <returns>
        ///     A value indicating whether <paramref name="button" /> is up or not.
        /// </returns>
        public static bool IsButtonUp(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return _currentMouseState.LeftButton == ButtonState.Released;
                case MouseButtons.Right:
                    return _currentMouseState.RightButton == ButtonState.Released;
                case MouseButtons.Middle:
                    return _currentMouseState.MiddleButton == ButtonState.Released;
                case MouseButtons.XButton1:
                    return _currentMouseState.XButton1 == ButtonState.Released;
                case MouseButtons.XButton2:
                    return _currentMouseState.XButton2 == ButtonState.Released;
                default:
                    return false;
            }
        }

        /// <summary>
        ///     Updates the mouse states.
        ///     This is necessary to check for changes in mouse button states.
        /// </summary>
        public static void Update()
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
        }
    }
}