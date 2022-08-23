pipeline {
  agent any

  environment {
    scannerHome = tool name: 'sonar_scanner_dotnet'
  }

  stages {

    stage('Nuget Restore') {

      steps {
        bat "dotnet restore NAGP-ASSIGNMENT.sln"
        echo "**************Nuget Restore started**************"
      }
    }

    stage('Start SonarQube Analysis') {
      when {
        branch 'master'
      }
      steps {
        withSonarQubeEnv('Test_Sonar') {
          bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"sonar-paritoshlouhan\""
          echo "**************SonarQube Analysis started**************"

        }
      }
    }

    stage('Code Build') {

      steps {
        bat "dotnet build"
        echo "**************Code build completed**************"
      }
    }

    stage('Test Case Execution') {
      when {
        branch 'master'
      }

      steps {
        bat "dotnet test -l:trx;LogFileName=file.xml"
        echo "**************Test Execution completed**************"
      }
    }

    stage('Release artifact') {
      when {
        branch 'develop'
      }

      steps {
        bat "dotnet publish -c Release -o out"
        echo "**************Code Published**************"
      }
    }

    stage('Stop SonarQube Analysis') {
      when {
        branch 'master'
      }

      steps {
        withSonarQubeEnv('Test_Sonar') {
          bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
          echo "**************Sonar Analysis stopped. Please visit localhost:9000 to see results**************"
        }
      }
    }

    stage('Kubernetes deployment') {

      steps {
        echo "**************Available nodes before deployment**************"
        bat "kubectl get nodes"

        bat "kubectl apply -f 'k8 Yaml files\configMap.yaml'"
        echo "**************ConfigMap deployed**************"

        bat "kubectl apply -f 'k8 Yaml files\deployment.yaml'"
        echo "**************Deployment completed!**************"

        bat "kubectl apply -f 'k8 Yaml files\lb-service.yaml'"
        echo "**************Load balancer Service Initiated**************"
        
      }
    }

  }

}
