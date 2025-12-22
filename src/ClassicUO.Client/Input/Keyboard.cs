#region license
// Copyright (c) 2021, andreakarasho
// All rights reserved.
#endregion

using SDL2;

namespace ClassicUO.Input
{
    internal static class Keyboard
    {
        private static SDL.SDL_Keycode _code;

        public static SDL.SDL_Keymod IgnoreKeyMod { get; } =
            SDL.SDL_Keymod.KMOD_CAPS |
            SDL.SDL_Keymod.KMOD_NUM |
            SDL.SDL_Keymod.KMOD_MODE |
            SDL.SDL_Keymod.KMOD_RESERVED;

        public static bool Alt { get; private set; }
        public static bool Shift { get; private set; }
        public static bool Ctrl { get; private set; }

        // === ADDITION ===
        public static void RefreshModifiers()
        {
            SDL.SDL_Keymod mod = SDL.SDL_GetModState() & ~IgnoreKeyMod;

            if ((mod & (SDL.SDL_Keymod.KMOD_RALT | SDL.SDL_Keymod.KMOD_LCTRL)) ==
                (SDL.SDL_Keymod.KMOD_RALT | SDL.SDL_Keymod.KMOD_LCTRL))
            {
                mod = SDL.SDL_Keymod.KMOD_NONE;
            }

            Shift = (mod & SDL.SDL_Keymod.KMOD_SHIFT) != SDL.SDL_Keymod.KMOD_NONE;
            Alt   = (mod & SDL.SDL_Keymod.KMOD_ALT)   != SDL.SDL_Keymod.KMOD_NONE;
            Ctrl  = (mod & SDL.SDL_Keymod.KMOD_CTRL)  != SDL.SDL_Keymod.KMOD_NONE;
        }
        // === END ADDITION ===

        public static void OnKeyUp(SDL.SDL_KeyboardEvent e)
        {
            SDL.SDL_Keymod mod = e.keysym.mod & ~IgnoreKeyMod;

            if ((mod & (SDL.SDL_Keymod.KMOD_RALT | SDL.SDL_Keymod.KMOD_LCTRL)) ==
                (SDL.SDL_Keymod.KMOD_RALT | SDL.SDL_Keymod.KMOD_LCTRL))
            {
                e.keysym.sym = SDL.SDL_Keycode.SDLK_UNKNOWN;
                e.keysym.mod = SDL.SDL_Keymod.KMOD_NONE;
            }

            Shift = (e.keysym.mod & SDL.SDL_Keymod.KMOD_SHIFT) != SDL.SDL_Keymod.KMOD_NONE;
            Alt   = (e.keysym.mod & SDL.SDL_Keymod.KMOD_ALT)   != SDL.SDL_Keymod.KMOD_NONE;
            Ctrl  = (e.keysym.mod & SDL.SDL_Keymod.KMOD_CTRL)  != SDL.SDL_Keymod.KMOD_NONE;

            _code = SDL.SDL_Keycode.SDLK_UNKNOWN;
        }

        public static void OnKeyDown(SDL.SDL_KeyboardEvent e)
        {
            SDL.SDL_Keymod mod = e.keysym.mod & ~IgnoreKeyMod;

            if ((mod & (SDL.SDL_Keymod.KMOD_RALT | SDL.SDL_Keymod.KMOD_LCTRL)) ==
                (SDL.SDL_Keymod.KMOD_RALT | SDL.SDL_Keymod.KMOD_LCTRL))
            {
                e.keysym.sym = SDL.SDL_Keycode.SDLK_UNKNOWN;
                e.keysym.mod = SDL.SDL_Keymod.KMOD_NONE;
            }

            Shift = (e.keysym.mod & SDL.SDL_Keymod.KMOD_SHIFT) != SDL.SDL_Keymod.KMOD_NONE;
            Alt   = (e.keysym.mod & SDL.SDL_Keymod.KMOD_ALT)   != SDL.SDL_Keymod.KMOD_NONE;
            Ctrl  = (e.keysym.mod & SDL.SDL_Keymod.KMOD_CTRL)  != SDL.SDL_Keymod.KMOD_NONE;

            _code = e.keysym.sym;
        }
    }
}
