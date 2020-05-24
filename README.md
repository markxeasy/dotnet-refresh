## Simple Core .NET REST API
A very simple project to have some ToDo REST API with a Swagger integration to show the Swagger UI with the documentation on project startup within a Docker container.

#### Prerequisites
Follow the steps detailed [here](https://dotnet.microsoft.com/download) to install everything needed to compile and run the project, if you wish to run the project as a standalone and not in a container (which is not recommended). To run the application as intended within a container Docker is required for this project and it can be download following the steps detailed [here](https://www.docker.com/products/docker-desktop).

#### Installation
Run the `docker build` command from within the `dotnet-refresh/` folder, it is recommended that the `-t` flag is used to give a recognizable name to the image it will create of the container. An example of the command would be like this: `docker build -t dotnet-refresh:v1` where `v1` is the tag we are applying to the image.
Once the image has been fully built run the following commands:
`dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p {PASSWORD}`
and 
`dotnet dev-certs https --trust`
to create an HTTPS certificate for development to use the HTTPS protocol, this will be needed to later call the endpoint correctly.

#### Launch
To run the project first copy the `docker/run.dist` file (keeping the copy in the `docker/` folder and rename it to `run`, afterwards within the copy change the value of `[cert_password]` to the same password you've used to generate the HTTPS certificate. 
To launch the application simply use the `docker/run` command and go to [https://localhost:8001/swagger](https://localhost:8001/swagger) to see the API documentation. Afterwards use a client like Postman to try out the various endpoints to see their functionality. An export of a postman collection with all the API calls can be found in the `doc/` folder.
