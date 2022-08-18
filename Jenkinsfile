pipeline {
    agent any 1
  stages {
     stage ('Git Checkout') {
      steps {
          git branch: 'main', 
          credentialsId: 'a', 
          url: 'https://github.com/LouhanParitosh/nagp-assignment-jenkins.git'
       }
     }
  }

}
