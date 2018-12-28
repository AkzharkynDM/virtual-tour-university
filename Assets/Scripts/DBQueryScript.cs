using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;


 public class DBQueryScript : MonoBehaviour {
    
    // Use this for initialization
    void Start () {       
        
    }

    // Update is called once per frame
    void Update () {
		
	}
  
	public Text TextBox;
	
    public string selectall()
    { 
		string one_row_result="";	
		
		string dbname= "/AllBooks.s3db";
        string conn = "URI=file:" + Application.dataPath + dbname;
        string bookname;
        string author;
        int year;
        string publisher;
		string category;
		
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();		
       	string sqlQuery = "SELECT name, author, year, publisher, category FROM Books";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();          
		
        while (reader.Read())
        {	if (!reader.IsDBNull(0))
			Debug.Log("Error: Null values in the table");
            bookname = reader.GetString(0);
            author = reader.GetString(1);
            year = reader.GetInt32(2);
            publisher = reader.GetString(3);
			category = reader.GetString(4);
			
            Debug.Log("name = " + bookname + "  author = " + author + "  year = " + year + " publisher = " + publisher+" category = "+category+"\n");
            one_row_result+="name = " + bookname + "  author = " + author + "  year = " + year + " publisher = " + publisher+" category = "+category+"\n";            
        }
		
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
		
		return one_row_result; 
    }
	
	public string selectwhere(string neededcategory)
    { 
		string one_row_result="";	
		
		string dbname= "/AllBooks.s3db";
        string conn = "URI=file:" + Application.dataPath + dbname;
        string bookname;
        string author;
        int year;
        string publisher;
		string category;
		
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();	
		//Debug.Log("until here it's fine");		
        string sqlQuery = "SELECT name, author, year, publisher, category FROM Books where category = '"+neededcategory+"'"; 
		dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();          
		//Debug.Log(sqlQuery);
		
        while (reader.Read())
        {	if (!reader.IsDBNull(0))
			Debug.Log("Error: Null values in the table");
            bookname = reader.GetString(0);
            author = reader.GetString(1);
            year = reader.GetInt32(2);
            publisher = reader.GetString(3);
			category = reader.GetString(4);
			
            Debug.Log("name = " + bookname + "  author = " + author + "  year = " + year + " publisher = " + publisher+" category = "+category+"\n");
            one_row_result+="name = " + bookname + "  author = " + author + "  year = " + year + " publisher = " + publisher+" category = "+category+"\n";            
        }
		
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
		
		return one_row_result; 
    }
	
	public void showAllwhenclicked(){
		string one_row="";
		one_row=selectall();       
	
		TextBox.text = one_row;
	}
	
	public void showBynamewhenclicked(string neededcategory){
		string one_row=""; 
		one_row=selectwhere(neededcategory);		
		TextBox.text = one_row;
		
	}
	public int getSize(){
		string one_row_result="";	
		int counter=0;
		string dbname= "/AllBooks.s3db";
        string conn = "URI=file:" + Application.dataPath + dbname;
        string bookname;
        string author;
        int year;
        string publisher;
		string category;
		
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();	
		//Debug.Log("until here it's fine");		
        string sqlQuery = "SELECT name, author, year, publisher, category FROM Books";
		dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();          
		//Debug.Log(sqlQuery);
		
        while (reader.Read())
        {	if (!reader.IsDBNull(0))
			Debug.Log("Error: Null values in the table");
            bookname = reader.GetString(0);
            author = reader.GetString(1);
            year = reader.GetInt32(2);
            publisher = reader.GetString(3);
			category = reader.GetString(4);
			
            //Debug.Log("name= " + bookname + "  author =" + author + "  year =" + year + " publisher= " + publisher+" category= "+category+"\n");
            //one_row_result+="name= " + bookname + "  author =" + author + "  year =" + year + " publisher= " + publisher+" category= "+category+"\n";     
			counter++;			
        }
		
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
		
		return counter; 
	}
}

