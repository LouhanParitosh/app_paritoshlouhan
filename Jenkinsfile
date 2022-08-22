pipeline {
  agent any

  environment {
    scannerHome = tool name: 'sonar_scanner_dotnet'
  }

  stages {

    stage('Nuget Restore') {

      steps {
        bat "dotnet restore NAGP-ASSIGNMENT.sln"
      }
    }

    stage('Start SonarQube Analysis') {
      when {
        branch 'master'
      }
      steps {
        withSonarQubeEnv('Sonar') {
          bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"sonar-paritoshlouhan\""

        }
      }
    }

    stage('Code Build') {

      steps {
        bat "kubectl get nodes"
        bat "dotnet build"
      }
    }

    stage('Test Case Execution') {
      when {
        branch 'master'
      }

      steps {
        bat "dotnet test -l:trx;LogFileName=file.xml"
      }
    }

    stage('Release artifact') {
      when {
        branch 'develop'
      }

      steps {
        bat "dotnet publish -c Release -o out"
      }
    }

    stage('Stop SonarQube Analysis') {
      when {
        branch 'master'
      }

      steps {
        withSonarQubeEnv('Sonar') {
          bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
        }
      }
    }

    stage('Kubernetes deployment') {

      steps {
        bat "kubectl get nodes"
        bat "kubectl apply -f deployment.yaml"
        bat "kubectl apply -f lb-service.yaml"
        
      }
    }

  }

}
