# MassTransit-Deserialize-Error
There is an issue when deserializing the Ping message at the service. Ping implements IMessage. IMessage has a method of PrintMethod that Ping must implement. Our service has a consumer that implements Consumes\<IMessage\>.All.
