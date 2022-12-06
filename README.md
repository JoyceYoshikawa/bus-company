# bus-company

#Pre-requisit

Has docker desktop installed. 

#Start Application 

Open a prompt command in application folder and run "docker compose up" to start up the database.

I couldn't figure out how to use docker compose to expose the API, but is possible to check the swagger via IIS Express in visual studio. 
For run the front-end you will need to use the command "ng serve" at folder "bus-company-app-ui". PS: I used the angular cli 15.

To view the interactiong between the fron-end and api , maybe you will need to change the baseUrl address in the file 
bus-company-app-ui\src\app\services\bus.service.ts 


