# Gameloop-emulator-bypass
A simple easy to use emulator bypass for Gameloop Emulator for absolute beginners to get started on their journey.

Uses Memory.dll : https://github.com/erfg12/memory.dll/

## Aim : 
> My only aim to upload this was to provide a easy way for newbies like me to get started as the entry barrier is very high . Also this source code should be used as a tool to understand how it works , not to copy paste some offsets from telegram channels or discords and make ur own bypass . A great way to start would be to use cheat engine along with this to see how it works and then use memory.dll to to create your own project . Current bypass source codes are either too complicated or are straight up viruses . So newcomers can use this to learn . 

## Features : 
1. ### Patch(long library_header_address, long offset, string bytes)
  **library_header_address** : It is the address of the Library inside aow_exe.exe . For now currently only 2 headers are defined , anogs and ue4 (for libanogs.so and libUE4.so of BGMI 3.4 32bit respectively) . This header is essentially the the first 52 bytes of the library . U can open the library inside a Hex editor like HxD and copy the first 52 bytes , that is ur header . Then we use AobScan function provided by Memory.dll to find the address of the library inside aow_exe.exe . <br>
   **offset** : The offset inside the library . U can use a dissassembler like Ida , Ghidra to find offsets of functions . <br>
   **bytes** : The bytes that will be written in that offset . Writebytes function of Memory.dll is used to write the bytes . 

2. It already has function defination to find aow_exe.exe as it changes everytime the game is launched (Can be changed to adapt for other emulators)
3. This can be used with AndroidEmulatorEx.exe engine of Gameloop or other emulators as long as they are not protected by anticheat and we can write to its memory.


## Usage : 
1. Launch your Game in AndroidEmulatorEx.exe of Gameloop . 
2. On game startup or actually anytime as long as the game is running , run the compiled exe and click bypass . 

# HOPE THIS HELPS AND U CAN HAVE A GREAT TIME LEARNING 
