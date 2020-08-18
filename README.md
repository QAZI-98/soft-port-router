# soft-port-router

This project is to understand basics behind router, it is an application
that allows to hide actual port numbers on which application is receiving/sending
data. The application will act between actual application (source) and destination
(target). Source will subscribe port with your application for sending and receiving
where target will connect with you (on predefined ports). The job of application
is to receive packets from source/target and send to source/target by changing ports
such that source and target are unaware about actual ports used for communication.
Such applications can help to exploit original application and provide additional
security layer
