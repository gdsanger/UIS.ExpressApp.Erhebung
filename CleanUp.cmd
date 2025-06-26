@echo off
echo This script cleans the solution folder and deletes all bin and obj folders. (Similar to Visual Studio Clean)
echo Delete BIN Folders
for /d /r %%i in (bin) do if exist "%%i" rmdir /s /q "%%i"
echo Delete OBJ Folders
for /d /r %%i in (obj) do if exist "%%i" rmdir /s /q "%%i"
echo Finished