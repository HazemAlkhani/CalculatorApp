@echo off
SonarScanner.MSBuild.exe begin /k:"easv-devops_CalculatorApp_AY4IVCA9EVvRW2O60ES7" /d:sonar.host.url="http://sonar.setgo.dk:9000" /d:sonar.token="sqp_e3f74eb9afbc43b08266f8489417813c52bbda82"
MsBuild.exe /t:Rebuild
SonarScanner.MSBuild.exe end /d:sonar.token="sqp_e3f74eb9afbc43b08266f8489417813c52bbda82"






