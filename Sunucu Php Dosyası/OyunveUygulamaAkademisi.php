<?php
$databaseName = "akademi8_wp309";
$databaseUser = "akademi8_wp309";
$databasePassword = "asdFDS12!";
$databaseHost = "localhost";
$method = $_REQUEST;
$conn = new mysqli($databaseHost,$databaseUser,$databasePassword,$databaseName);
$conn->set_charset("utf8");
error_reporting(E_ERROR | E_PARSE);
$NewGame = $method['NewGame'];
$GameID = $method['GameID'];
$GamePassword = $method['GamePassword'];
$UserNames = $method['UserNames'];
$UserScore = $method['UserScore'];
$User2Score = $method['User2Score'];
$User3Score = $method['User3Score'];
$User4Score = $method['User4Score'];
$UserStatus = $method['UserStatus'];
$Score1 = $method['Score1'];
$Score2 = $method['Score2'];
$Score3 = $method['Score3'];
$Score4 = $method['Score4'];
$ScoreAll = $method['ScoreAll'];
$Users = $method['Users'];
$Login = $method['Login'];
$UserStatusChange = $method['UserStatusChange'];
$Game = $method['Game'];
$isStarted = $method['isStarted'];

$conn = new mysqli($databaseHost,$databaseUser,$databasePassword,$databaseName);
$conn->set_charset("utf8");
if($conn->connect_error){die("error: " . $conn->connect_error);}


if($NewGame == "write"){
	$sql = "INSERT INTO OyunveUygulamaAkademisi (GameID,GamePassword) VALUES ('$_POST[GameID]','$_POST[GamePassword]')";
	$conn->query($sql);
	echo $conn->error;
}


if($Login == "read"){
	$sql = "SELECT GamePassword FROM OyunveUygulamaAkademisi WHERE GameID = '".$GameID."'";
	$result = $conn->query($sql);
	echo $conn->error;
	while($rows = mysqli_fetch_assoc($result)){
        echo $rows['GamePassword'];	
	}
}

if($Users == "read"){
	$sql = "SELECT UserNames FROM OyunveUygulamaAkademisi WHERE GameID = '".$GameID."'";
	$result = $conn->query($sql);
	echo $conn->error;
	while($rows = mysqli_fetch_assoc($result)){
        echo $rows['UserNames'];	
	}
}

if($Users == "write"){
	$sql = "UPDATE `OyunveUygulamaAkademisi` SET `UserNames`='$UserNames' WHERE GameID = '$GameID'";
	$conn->query($sql);
	echo $conn->error;
}

if($UserStatusChange == "read"){
	$sql = "SELECT UserStatus FROM OyunveUygulamaAkademisi WHERE GameID = '".$GameID."'";
	$result = $conn->query($sql);
	echo $conn->error;
	while($rows = mysqli_fetch_assoc($result)){
        echo $rows['UserStatus'];	
	}
}

if($UserStatusChange == "write"){
	$sql = "UPDATE `OyunveUygulamaAkademisi` SET `UserStatus`='$UserStatus' WHERE GameID = '$GameID'";
	$conn->query($sql);
	echo $conn->error;
}

if($Game == "write"){
	$sql = "UPDATE `OyunveUygulamaAkademisi` SET `isStarted`='$isStarted' WHERE GameID = '$GameID'";
	$conn->query($sql);
	echo $conn->error;
}

if($Game == "read"){
	$sql = "SELECT isStarted FROM OyunveUygulamaAkademisi WHERE GameID = '".$GameID."'";
	$result = $conn->query($sql);
	echo $conn->error;
	while($rows = mysqli_fetch_assoc($result)){
        echo $rows['isStarted'];	
	}
}

if($Score1 == "write"){
	$sql = "UPDATE `OyunveUygulamaAkademisi` SET `UserScore`='$UserScore' WHERE GameID = '$GameID'";
	$conn->query($sql);
	echo $conn->error;
}

if($Score2 == "write"){
	$sql = "UPDATE `OyunveUygulamaAkademisi` SET `User2Score`='$User2Score' WHERE GameID = '$GameID'";
	$conn->query($sql);
	echo $conn->error;
}
if($Score3 == "write"){
	$sql = "UPDATE `OyunveUygulamaAkademisi` SET `User3Score`='$User3Score' WHERE GameID = '$GameID'";
	$conn->query($sql);
	echo $conn->error;
}
if($Score4 == "write"){
	$sql = "UPDATE `OyunveUygulamaAkademisi` SET `User4Score`='$User4Score' WHERE GameID = '$GameID'";
	$conn->query($sql);
	echo $conn->error;
}

if($Score1 == "read"){
	$sql = "SELECT UserScore FROM OyunveUygulamaAkademisi WHERE GameID = '".$GameID."'";
	$result = $conn->query($sql);
	echo $conn->error;
	while($rows = mysqli_fetch_assoc($result)){
        echo $rows['UserScore'];	
	}
}

if($Score2 == "read"){
	$sql = "SELECT User2Score FROM OyunveUygulamaAkademisi WHERE GameID = '".$GameID."'";
	$result = $conn->query($sql);
	echo $conn->error;
	while($rows = mysqli_fetch_assoc($result)){
        echo $rows['User2Score'];	
	}
}
if($Score3 == "read"){
	$sql = "SELECT User3Score FROM OyunveUygulamaAkademisi WHERE GameID = '".$GameID."'";
	$result = $conn->query($sql);
	echo $conn->error;
	while($rows = mysqli_fetch_assoc($result)){
        echo $rows['User3Score'];	
	}
}

if($Score4 == "read"){
	$sql = "SELECT User4Score FROM OyunveUygulamaAkademisi WHERE GameID = '".$GameID."'";
	$result = $conn->query($sql);
	echo $conn->error;
	while($rows = mysqli_fetch_assoc($result)){
        echo $rows['User4Score'];	
	}
}

if ($ScoreAll == "read") {
    $sql = "SELECT CONCAT_WS(',', UserScore, User2Score, User3Score, User4Score) as UserScores FROM OyunveUygulamaAkademisi WHERE GameID = '".$GameID."'";
	$result = $conn->query($sql);
	echo $conn->error;
	while($rows = mysqli_fetch_assoc($result)){
        echo $rows['UserScores'];	
	}
}
