pipeline {
    agent any 
      stages {
         stage ('Git Checkout') {
          steps {
              git branch: 'main', 
              credentialsId: 'a', 
              url: 'https://github.com/LouhanParitosh/nagp-assignment-jenkins.git'
           }
         }
             
           stage('Nuget Restore') {
              steps {
                bat "dotnet restore NAGP-ASSIGNMENT.sln"
              }
           }
          
          stage('Code Build') {
             steps {
              bat "msbuild.exe NAGP-ASSIGNMENT.sln /nologo /nr:false  /p:platform=\"x64\" /p:configuration=\"release\" /t:clean;restore;rebuild"
             }
           }
     }
}
