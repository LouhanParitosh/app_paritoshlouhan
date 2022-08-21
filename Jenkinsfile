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
			when {
				branch 'master'
			}              
			steps {
				withSonarQubeEnv('Sonar') {
					bat 'dotnet D:\\sonar-scanner-msbuild-5.7.2.50892-net5.0\\SonarScanner.MSBuild.dll begin /k:"Test_Sonar"'
					  
				}
			}
	    }
          
		stage('Code Build') {
		 
			steps {
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
    }
    
}
