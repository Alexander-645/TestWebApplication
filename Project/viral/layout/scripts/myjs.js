
function onChange(){
	
	if (document.getElementById("name").value != "" 
		&& document.getElementById("email").value != ""
		&& (document.getElementById("checkbox1").checked != false
		|| document.getElementById("checkbox2").checked != false
		|| document.getElementById("checkbox3").checked != false)
		&& document.getElementById("Date").value != "")
		
		document.getElementById("Submit").disabled = false
		
	else
		
		document.getElementById("Submit").disabled = true;
		
};

function onResetClick(){
	
	document.getElementById("Submit").disabled = true;
	
};

function onResetClick1(){
	
	document.getElementById("Submit1").disabled = true;
	
};

function onSubmitClick(){
	
	if (document.getElementById("Name").value != "" && document.getElementById("Mail").value != "")
		
		document.getElementById("SubButton").disabled = false
		
	else
		
		document.getElementById("SubButton").disabled = true;
		
};

function onClickSecond(){
	
	if(document.getElementById("name").value != "" 
		&& document.getElementById("email").value != ""
		&& (document.getElementById("r1").checked 
		|| document.getElementById("r2").checked)
		&& document.getElementsByName("theme[]").value != "")
		
		
		document.getElementById("Submit1").disabled = false
		
	else
		
		document.getElementById("Submit1").disabled = true;
		
};



function OnPageLoad(){
	
	var date = new Date();
	var getNormalDate = function(date){ 
		var day = date.getDate();
		if (day<10) day='0'+day; 
		var month = date.getMonth() + 1;
		if (month<10) month='0'+month; 
		var year = date.getFullYear(); 
		return year + '-' + month + '-' + day;
	}
	
	document.getElementById("Date").value = getNormalDate(date);
	document.getElementById("Date").min = getNormalDate(date);
};
	
		