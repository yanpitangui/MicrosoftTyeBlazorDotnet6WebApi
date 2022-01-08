# Microsoft Tye + Blazor + Dotnet6 WebApi
Example application of microsoft tye for microservices

Microsoft tye makes it so easy to connect your microservices.
It supports project (.csproj, etc) and docker images.

Look at how easily the frontend project connect to backend's ip address:
```csharp
builder.Services.AddHttpClient("weatherapi", client =>
{
    client.BaseAddress = builder.Configuration.GetServiceUri("backend");
});
```
Tye takes care of that for you. You just have to give this method the same name as defined in tye.yaml.

This definition can be found on frontend's ```Program.cs```.

## Requirements
1. Install microsoft tye: 
```ps
  dotnet tool update -g Microsoft.Tye --version "0.-*" --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json
```
2. For the kubernetes deploy method, you should have docker installed and kubernetes enabled.

## How to run

2. Run ```tye run``` in the solution's root. In the console, you will see the tye dashboard's IP ([http://127.0.0.1:8000/](http://127.0.0.1:8000/)).
3. You should see 2 services: backend and frontend. Feel free to click on frontend's binding [http://localhost:9000/](http://localhost:9000/) and play around.
4. You can easily attach a debugger with visual studio, just go on Debug -> Attach to Process and select the desired process. Tye console logs show each application process Id, making it easy for you. 

### Kubernetes deploy
1. Run ```tye deploy```. This should make tye generate (!) the necessary dockerfiles and deploy your application for you.
2. After this, your application should be deployed. To check on this, run ```kubectl get pods``` and ```kubectl get svc```.
3. To make your application avaiable outside the cluster, port forward the frontend application using the following command: ```kubectl port-forward svc/frontend 5001:9000```. That should make the frontend accessible via [127.0.0.1:5001](127.0.0.1:5001).
4. To undeploy, just run ```tye undeploy```.

## Want more?
Please visit https://github.com/dotnet/tye, and see the samples. Also, please support it giving a star!
