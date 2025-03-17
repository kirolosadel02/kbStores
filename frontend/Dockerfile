# Use the official Flutter image
FROM cirrusci/flutter:stable

# Set the working directory
WORKDIR /app

# Copy the Flutter app code
COPY . .

# Install dependencies
RUN flutter pub get

# Build the Flutter app for the web
RUN flutter build web

# Expose port for the web server
EXPOSE 5000

# Run the app
CMD ["flutter", "run", "--release", "-d", "web-server", "--web-port", "5000", "--web-hostname", "0.0.0.0"]