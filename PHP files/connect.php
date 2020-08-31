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

echo "Connected Successfully into Database";
$sql = "SELECT id, name, address, date, password FROM student";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo " id: " . $row["id"]. " - Name: " . $row["name"]. " - Adress " . $row["address"]. " - Date: " . $row["date"]." - Password:" . $row["password"]."/";
  }
} else {
  echo "0 results";
}
$conn->close();
?>