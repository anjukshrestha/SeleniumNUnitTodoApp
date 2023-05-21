pipeline {
    agent any
    stages {
        stage ('Git Checkout') {
              steps {
                  git branch: 'main',  url: 'https://github.com/anjukshrestha/SeleniumNUnitTodoApp'
                }
        }
         
        stage('Build') {
            steps {
                sh '/var/lib/jenkins/.dotnet/dotnet build SeleniumNUnitTodoApp.sln'
            }
        }
        
        stage('setup') {
            steps {
                browserstack('3bcba4c1-b268-409b-8b1b-111753592a00') {
                    // For Linux-based systems, add the following commands in the given console to download the binary, run it, and stop its execution after the test has been executed.
                    sh 'wget "https://www.browserstack.com/browserstack-local/BrowserStackLocal-linux-x64.zip"'
                    sh 'unzip -o BrowserStackLocal-linux-x64.zip'
                    sh './BrowserStackLocal --key $BROWSERSTACK_ACCESS_KEY --daemon start'
                     
 
                }
                // Enable reporting in Jenkins
                browserStackReportPublisher 'automate'
            }
        }
        
    }
}
