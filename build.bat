@echo off
.nuget\NuGet.exe install FAKE -Version 4.20.0
packages\FAKE.4.20.0\tools\FAKE.exe build.fsx %1