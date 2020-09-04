<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "backstage";





// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
$username = $_POST['phpUsername'];
$userpassword = $_POST['phpUserpassword'];
$userEmail = $_POST['phpUserEmail'];

$sql = "INSERT INTO student (name, password, email)
VALUES ('".$username."', '".$userpassword."', '".$userEmail."')";

if ($conn->query($sql) === TRUE) {
  echo "New record created successfully";
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();


?>