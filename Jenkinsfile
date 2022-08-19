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
                      bat 'dotnet D:\\sonar-scanner-msbuild-5.7.2.50892-net5.0\\SonarScanner.MSBuild.dll begin /k:"Test_Sonar"'
                      
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
