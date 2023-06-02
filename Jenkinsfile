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
                sh 'dotnet build SeleniumNUnitTodoApp.sln'
            }
        }
        
        stage('run') {
            steps {
                browserstack('3bcba4c1-b268-409b-8b1b-111753592a00') {
                     
                     sh 'dotnet test --interactive SeleniumNUnitTodoApp.sln'
 
                }
                // Enable reporting in Jenkins
                browserStackReportPublisher 'automate'
            }
        } 
        
    }
}
