# netcore-ssl-by-proxy
A demo of .net core MVC with SSL using reverse proxy

1. Create self certificate using opensll
    a - Execute command to pull & build openssl image
    ```
    docker build -t my-openssl:latest .
    ```

    b - Execute command to run OpenSSL
    ```
    docker run -it --rm -v "C:/Projects/demo/openssl:/openssl-certs:/openssl-certs" my-openssl
    ```

    c - Execute follow commands to create certificate

    ```
    genrsa -out server.key 2048
    ```
    ```
    req -new -out server.csr -key server.key -config openssl.cnf
    ```
    ```
    x509 -req -days 3650 -in server.csr -signkey server.key -out server.crt -extensions v3_req -extfile openssl.cnf
    ```

2. Copy the certificate to `nginx-reverse-proxy/cert` directory

3. Install certificate that was generated above to `Trusted Root Certification Authorities` & `Personal`

4. Run `docker-compose up --build` to start