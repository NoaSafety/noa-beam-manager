@echo off

set /p Build=<version.txt

docker build . -t noa-beam-manager:%Build%
docker save noa-beam-manager:%Build% > .\noa-beam-manager-%Build%.tar
