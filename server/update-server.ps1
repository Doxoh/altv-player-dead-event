Param(
    [string]$Branch = "release"
)

$flickrImages = "https://cdn.altv.mp/server/$BRANCH/x64_win32/altv-server.exe",
"https://cdn.altv.mp/data/$BRANCH/data/vehmodels.bin",
"https://cdn.altv.mp/data/$BRANCH/data/vehmods.bin",
"https://cdn.altv.mp/data/$BRANCH/data/clothes.bin",
"https://cdn.altv.mp/coreclr-module/$BRANCH/x64_win32/AltV.Net.Host.dll",
"https://cdn.altv.mp/coreclr-module/$BRANCH/x64_win32/modules/csharp-module.dll",
"https://cdn.altv.mp/js-module/$BRANCH/x64_win32/modules/js-module/libnode.dll",
"https://cdn.altv.mp/js-module/$BRANCH/x64_win32/modules/js-module/js-module.dll"         
                        
            
            
function DownloadFile([Object[]] $sourceFiles,[string]$targetDirectory) {            
 $wc = New-Object System.Net.WebClient            
             
 foreach ($sourceFile in $sourceFiles){            
  $sourceFileName = $sourceFile.SubString($sourceFile.LastIndexOf('/')+1)            
  $targetFileName = $targetDirectory + '/' + $sourceFileName
  Write-Host $sourceFile
  Write-Host $targetFileName
  $wc.DownloadFile($sourceFile, $targetFileName)            
  Write-Host "Downloaded $sourceFile to file location $targetFileName"             
 }            
            
}            
            
DownloadFile $flickrImages $PWD  

Move-Item -Path $PWD/csharp-module.dll -Destination $PWD\modules -Force
Move-Item -Path $PWD/js-module.dll -Destination $PWD\modules -Force

Move-Item -Path $PWD/vehmodels.bin -Destination $PWD\data -Force
Move-Item -Path $PWD/vehmods.bin -Destination $PWD\data -Force
Move-Item -Path $PWD/clothes.bin -Destination $PWD\data -Force