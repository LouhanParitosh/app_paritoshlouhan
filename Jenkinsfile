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
                  withSonarQubeEnv('Sonar') {
                      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:"Test_Sonar" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="sqp_9214c7cb2b9ca70558833050b9cc1c303ca9f867"
                      
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
                  withSonarQubeEnv('Sonar') {
                      bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
                  }
              }
           }
        
        
         stage('Release Artifacts') {
              steps {
                  bat "dotnet publish -c Release -o ${appName}/app/${userName}"
              }
           }
     }
}
