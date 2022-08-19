pipeline {
    agent any
    
    environment {
        scannerHome = tool name: 'sonarscanner'
        username = 'admin'
        appName = 'SampleApp'
    }
    
   
    stages {   
          stage('Nuget Restore') {
              steps {
                bat "dotnet restore NAGP-ASSIGNMENT.sln"
              }
           }
        
        
          stage('Start SonarQube Analysis') {
              steps {
               echo "starting sonarqube"
                  withSonarQubeEnv('Sonar') {
                      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"Test_Sonar\" /d:sonar.verbose=true -d:sonar.cs.xunit.reportsPath='file.xml'"
                  }
              }
           }
          
          stage('Code Build') {
             steps {
                   bat "\"${tool 'MSBuild'}\" NAGP-ASSIGNMENT.sln /p:Configuration=DEBUG /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0"
             }
           }
        
         stage('Stop SonarQube Analysis') {
              steps {
               echo "stopping sonarqube"
                  withSonarQubeEnv('Sonar') {
                      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
                  }
              }
           }
     }
}
