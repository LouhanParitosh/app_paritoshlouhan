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
                bat "dotnet restore HelloWorldCore.sln"
              }
           }
          
          stage('Code Build') {
             steps {
                   bat "\"${tool 'MSBuild'}\" HelloWorldCore.sln /p:Configuration=DEBUG /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0"
             }
           }
     }
}
