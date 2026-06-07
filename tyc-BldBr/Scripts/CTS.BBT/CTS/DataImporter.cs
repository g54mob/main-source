using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

namespace CTS
{
	public abstract class DataImporter : DataContainerBase
	{
		[SerializeField]
		private string _sheetPath = "";

		private Dictionary<string, bool> _pagesToggles = new Dictionary<string, bool>();

		private ImportQueue _importQueue;

		protected bool SaveData;

		[field: SerializeField]
		public bool ImportOnStart { get; private set; } = true;

		public string CleanPath
		{
			get
			{
				string text = _sheetPath.Replace("https://docs.google.com/spreadsheets/d/", "");
				if (text.Contains("/edit?usp=drive_link"))
				{
					text = text.Replace("/edit?usp=drive_link", "");
				}
				else if (text.Contains("/edit?usp=sharing"))
				{
					text = text.Replace("/edit?usp=sharing", "");
				}
				return text;
			}
		}

		public event Action DataImported;

		public async Task ImportDataFromGoogleSheet(bool saveData = false)
		{
			SaveData = saveData;
			string cleanPath = CleanPath;
			if (string.IsNullOrEmpty(cleanPath))
			{
				Debug.LogError("Document ID is not specified!");
				return;
			}
			documentID = cleanPath;
			FieldInfo[] fields = GetType().GetFields();
			if (_pagesToggles.Count == 0)
			{
				for (int i = 0; i < fields.Length; i++)
				{
					_pagesToggles.Add(fields[i].Name, Attribute.IsDefined(fields[i], typeof(PageNameAttribute)));
				}
			}
			_importQueue = new ImportQueue(this, fields.Where((FieldInfo fieldInfo) => _pagesToggles[fieldInfo.Name]).ToArray());
			await _importQueue.Run();
			_importQueue = null;
			LoadData();
			this.DataImported?.Invoke();
			await Task.FromResult(result: true);
		}

		private void OnImportQueueComplete(DataContainerBase container)
		{
			ImportQueue importQueue = _importQueue;
			importQueue.onComplete = (Action<DataContainerBase>)Delegate.Remove(importQueue.onComplete, new Action<DataContainerBase>(OnImportQueueComplete));
			_importQueue = null;
			LoadData();
			this.DataImported?.Invoke();
		}

		protected abstract void LoadData();
	}
}
