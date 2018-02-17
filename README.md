# UnityUtil

Example of how to use this repo as a submodule in a Unity project

Open up the root folder of our Unity project  
` cd /d/UnityProjects/ProjectName/`  

Make a folder to organize our shared code submodules  
`mkdir Submodules`  

Move into the subfolder  
`cd Submodules`  

Clone the shared code as a submodule  
`git submodule add https://github.com/Bennett-Lynch/UnityUtil.git`  

Move into the Assets folder  
`cd ../Assets`  

Create a symbolic link in the Assets folder pointing to our submodule...  
Mac:  
`ln -s ../Submodules/UnityUtil UnityUtil`  
Windows (in a separate command prompt run as admin):  
`mklink /D "D:\UnityProjects\ProjectName\Assets\UnityUtil" "D:\UnityProjects\ProjectName\Submodules\UnityUtil"`