

#include <iostream>
#include <Windows.h>
#include "AutoClick.h"

BOOL WINAPI DllMain(
    HINSTANCE hinstDLL,  // handle to DLL module
    DWORD fdwReason,     // reason for calling function
    LPVOID lpvReserved)  // reserved
{
    // Perform actions based on the reason for calling.
    switch (fdwReason)
    {
    case DLL_PROCESS_ATTACH:
        // Initialize once for each new process.
        // Return FALSE to fail DLL load.
        break;

    case DLL_THREAD_ATTACH:
        // Do thread-specific initialization.
        break;

    case DLL_THREAD_DETACH:
        // Do thread-specific cleanup.
        break;

    case DLL_PROCESS_DETACH:

        if (lpvReserved != nullptr)
        {
            break; // do not do cleanup if process termination scenario
        }

        // Perform any necessary cleanup.
        break;
    }
    return TRUE;  // Successful DLL_PROCESS_ATTACH.
}

static bool on = false;
extern "C"
{
	DllExport void Click(int keyenable,int keydisable)
	{

		if (GetAsyncKeyState(keyenable) & 0x1)
		{
			on = true;
		}
		if (GetAsyncKeyState(keydisable) & 0x1)
		{
			on = false;
		}


		if (on)
		{
			INPUT events[2];

			events[0].type = INPUT_MOUSE;
			events[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;


			events[1].type = INPUT_MOUSE;
			events[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;

			SendInput(sizeof(events) / sizeof(INPUT), events, sizeof(INPUT));
		}
	}
}
