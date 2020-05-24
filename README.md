## Simple Core .NET REST API
A very simple project to have some ToDo REST API with a Swagger integration to show the Swagger UI with the documentation on project startup within a Docker container.

#### Prerequisites
Follow the steps detailed [here](https://dotnet.microsoft.com/download) to install everything needed to compile and run the project, if you wish to run the project as a standalone and not in a container (which is not recommended). To run the application as intended within a container Docker is required for this project and it can be download following the steps detailed [here](https://www.docker.com/products/docker-desktop). Once everything is installed you will need to activate the Kubernets cluster from the Docker for Windows/Mac or install something like minikube on Linux.

#### Installation
Run the `docker build` command from within the `dotnet-refresh/` folder which has the Dockerfile in it. It is also recommended that the `-t` flag is used to give a recognizable name to the image it will create of the container. An example of the command would be like this: `docker build -t dotnet-refresh:v1` where `v1` is the tag we are applying to the image.

#### Launch
To run the project use the following commands:

`kubectl apply -f dotnet-refresh/k8s/deployment.yml` this will create a pod using the image of the .NET application we created earlier.

Then use the `kubectl apply -f dotnet-refresh/k8s/service.yml` to create the load balancer which will expose our APIs outside the cluster. 

Once both are up and running (can be checked using the `kubectl get pods` or `kubectl get svc` respectively) the APIs are ready to be used at `localhost:8080`. It is possible to open the browser and go to [https://localhost:8080/swagger](https://localhost:8080/swagger) to check the OpenAPI documentation.
Afterwards use a client like Postman to try out the various endpoints to see their functionality. An export of a Postman collection with all the API calls can be found in the `doc/` folder.

#### Cleanup
Use the following commands to cleanup once all testing is done:

`kubectl delete deployment dotnet-refresh-deployment`

and

`kubectl delete svc dotnet-refresh-service`
