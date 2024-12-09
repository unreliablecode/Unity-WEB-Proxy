
# Unity Web Proxy

A simple Unity web proxy that intercepts requests to specific URLs and provides custom responses. This proxy is designed for testing and development purposes.

## Features

- Intercepts HTTP requests made to specified URLs (e.g., `google.com`).
- Provides custom HTML responses instead of the real responses.
- Easy to integrate into Unity projects.

## Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/unreliablecode/Unity-Web-Proxy.git
   ```

2. **Open the project in Unity.**

3. **Add the WebProxy Script:**
   - Create a new C# script named `WebProxy.cs` and copy the provided code into it.
   - Create an empty GameObject in your scene and attach the `WebProxy` script to it.

4. **Add the Test Proxy Script:**
   - Create another C# script named `TestProxy.cs` and copy the provided code into it.
   - Attach the `TestProxy` script to another GameObject in your scene.

## Usage

- The proxy listens for HTTP requests on `http://localhost:8080/`.
- When a request is made to `google.com`, the proxy responds with a custom HTML message.
- You can test the proxy by making requests to `http://localhost:8080/` from your Unity game.

## Example Request

To test the proxy, you can use the `TestProxy` script, which sends a request to the proxy and logs the response.

## Important Notes

- Ensure that your firewall allows traffic on port 8080.
- This implementation is primarily for desktop platforms and may have limitations on others (e.g., WebGL).
- This proxy should not be used in production without proper security measures.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Author

[unreliablecode](https://github.com/unreliablecode)
