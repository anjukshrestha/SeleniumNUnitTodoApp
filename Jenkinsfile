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
        
    }
}
