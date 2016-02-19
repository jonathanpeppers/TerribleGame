#!/bin/bash

nuget install FAKE -Version 4.20.0
mono --runtime=v4.0 packages/FAKE.4.20.0/tools/FAKE.exe build.fsx $@
