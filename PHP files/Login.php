<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "backstage";
$useName = $_POST["usname"];
$usePassword = $_POST["uspwd"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

echo "Successfully Connected To database";

$sql = "SELECT password FROM student WHERE name= '".$useName."'";

	$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    	if($row["password"]==$usePassword){
	echo "Login succesfull";	
	}
	else{
	echo "Login Failure";
	}
	} 
}
else {
  echo " 0 results";
}
$conn->close();
?>