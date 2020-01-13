﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Yukidango.BarrageShooting.DataBase;
 
 
 namespace Yukidango.BarrageShooting.DataBase{


	 public class DataControll : MonoBehaviour
	 {
		 public static SqliteDatabase sqlDB;

		 public void insertDb(int score)
		 {

			 try
			 {
				 sqlDB = new SqliteDatabase(Application.dataPath + "/StreamingAssets/score.db");

				 List<DataFormat> dataList = new List<DataFormat>();
				 string query = "select * from score order by score desc";
				 DataTable dataTable = sqlDB.ExecuteQuery(query);
				 Debug.Log("select finish");

				 if (dataTable.Rows.Count >= 10)
				 {
					 Debug.Log("before if");
					 
					 if ((int) dataTable[9]["score"] < score)
					 {
						 
						 Debug.Log("before delete");

						 query = "update or replace score set score = " +score+ " , date = datetime('now') where id=" + (int)dataTable[9]["id"];
						 sqlDB.ExecuteQuery(query);
						 
						 Debug.Log("insert finish");
					 }
				 }
				 else
				 {
					 query = "insert into score(score,date) values (" + score + ",datetime('now'))";
					 sqlDB.ExecuteQuery(query);
				 }
			 }
			 catch (Exception e)
			 {
				 Debug.Log(e);
			 }
		 }
		 
		 
		 public static DataFormat[] getDb() {
			 sqlDB = new SqliteDatabase(Application.dataPath + "/StreamingAssets/score.db");
			 
			 DataFormat[] data = new DataFormat[10];
			 string selectQuery = "select * from score order by score desc";
			 DataTable dataTable = sqlDB.ExecuteQuery(selectQuery);

			 int i = 0;
			 foreach(DataRow dr in dataTable.Rows){
				 data[i] = new DataFormat((int)dr["score"],(string)dr["date"]);
				 Debug.Log(i.ToString()+"\t" + ((int)dr["score"]).ToString()+"\t" + dr["date"]);
				 i++;
			 }

			 return data;
		 }
	 } 
 }