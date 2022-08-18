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
             
           stage('Restore packages') {
              steps {
                bat "dotnet restore NAGP-ASSIGNMENT.sln"
              }
           }
     }
}
