using System;
using System.Collections.Generic;
using System.IO;
using Mono.Csv;
using UnityEngine;

public class PlotData
{
	private class DataColumn
	{
		public string name;

		public Queue<string> data = new Queue<string>();

		public List<string> GetColumn()
		{
			List<string> list = new List<string>();
			list.Add(name);
			list.AddRange(data);
			return list;
		}
	}

	public int sampleCount = 10000;

	private List<DataColumn> columns = new List<DataColumn>();

	private string filePath;

	private static string folderName;

	public PlotData(string _fileName, int _sampleCount = 10000)
	{
		if (string.IsNullOrEmpty(folderName))
		{
			DateTime now = DateTime.Now;
			folderName = $"PlotData/plotdata_{now.Year}-{now.Month:D2}-{now.Day:D2}_{now.Hour:D2}-{now.Minute:D2}-{now.Second:D2}/";
		}
		filePath = folderName + _fileName;
		sampleCount = _sampleCount;
	}

	public void Init(params string[] columnNames)
	{
		for (int i = 0; i < columnNames.Length; i++)
		{
			DataColumn dataColumn = new DataColumn();
			dataColumn.name = columnNames[i];
			columns.Add(dataColumn);
		}
	}

	public void Log(params object[] columnDatas)
	{
		if (columnDatas.Length != columns.Count)
		{
			Debug.LogWarning("Wrong column count, plot data won't be saved");
			return;
		}
		for (int i = 0; i < columns.Count; i++)
		{
			columns[i].data.Enqueue(columnDatas[i].ToString());
			if (sampleCount > 0 && columns[i].data.Count > sampleCount)
			{
				columns[i].data.Dequeue();
			}
		}
	}

	public List<List<string>> GetData()
	{
		List<List<string>> list = new List<List<string>>();
		List<string> list2 = new List<string>();
		for (int i = 0; i < columns.Count; i++)
		{
			list2.Add(columns[i].name);
		}
		list.Add(list2);
		while (columns[0].data.Count > 0)
		{
			List<string> list3 = new List<string>();
			for (int j = 0; j < columns.Count; j++)
			{
				list3.Add(columns[j].data.Dequeue());
			}
			list.Add(list3);
		}
		return list;
	}

	public void Serialize()
	{
		string directoryName = Path.GetDirectoryName(filePath);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		List<List<string>> data = GetData();
		using (CsvFileWriter csvFileWriter = new CsvFileWriter(filePath))
		{
			csvFileWriter.WriteAll(data);
		}
	}
}
