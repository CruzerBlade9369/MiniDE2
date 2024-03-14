$DVInstallDir = "D:\Steam\steamapps\common\Derail Valley"

Set-Location "$PSScriptRoot"
$FilesToInclude = "info.json","LICENSE","README.md","items/*"

$modInfo = Get-Content -Raw -Path "info.json" | ConvertFrom-Json
$modId = $modInfo.Id
$modVersion = $modInfo.Version

$OutputDirectory = "$DVInstallDir/Mods/$modId"

New-Item "$OutputDirectory" -ItemType Directory -Force
Copy-Item -Force -Recurse -Path $FilesToInclude -Destination "$OutputDirectory"