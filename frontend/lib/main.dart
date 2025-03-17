import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

void main() {
  runApp(MyApp());
}

// Use 'backend' instead of 'localhost' inside Docker
const String baseUrl = 'http://backend:8081';

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Docker API Test',
      home: Scaffold(
        appBar: AppBar(title: Text('Flutter + Docker')),
        body: Center(
          child: ElevatedButton(
            onPressed: fetchData,
            child: Text('Fetch Data from Backend'),
          ),
        ),
      ),
    );
  }

  void fetchData() async {
    final response = await http.get(Uri.parse('$baseUrl/api/some-endpoint'));
    
    if (response.statusCode == 200) {
      print('Success: ${response.body}');
    } else {
      print('Failed to fetch data');
    }
  }
}
