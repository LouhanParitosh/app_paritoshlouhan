pipeline {
    agent any 
      stages {
         
             
           stage('Nuget Restore') {
              steps {
                bat "dotnet restore NAGP-ASSIGNMENT.sln"
              }
           }
          
          stage('Code Build') {
             steps {
                   bat "\"${tool 'MSBuild'}\" NAGP-ASSIGNMENT.sln /p:Configuration=DEBUG /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0"
             }
           }
     }
}
