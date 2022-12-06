The table was created via aws cli using the below script.

Pre-requisit 
dynamodb running via docker.

aws dynamodb create-table --table-name Buses --key-schema AttributeName=LicensePlate,KeyType=HASH --attribute-definitions AttributeName=LicensePlate,AttributeType=S --provisioned-throughput ReadCapacityUnits=3,WriteCapacityUnits=3  --endpoint-url http://localhost:8000