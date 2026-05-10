using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NorskaLib.GoogleSheetsDatabase.Utils;
using UnityEngine;

namespace NorskaLib.GoogleSheetsDatabase
{
	public class ImportQueue
	{
		public const string URLFormat = "https://docs.google.com/spreadsheets/d/{0}/gviz/tq?tqx=out:csv&sheet={1}";

		private readonly DataContainerBase container;

		private readonly FieldInfo[] listsInfos;

		private readonly string documentID;

		public Action<DataContainerBase> onComplete;

		public bool abort;

		private string output;

		public Action onOutputChanged;

		public float progress;

		public Action onProgressChanged;

		public string Output
		{
			get
			{
				return output;
			}
			private set
			{
				output = value;
				onOutputChanged?.Invoke();
			}
		}

		public float Progress
		{
			get
			{
				return progress;
			}
			private set
			{
				progress = Mathf.Clamp01(value);
				onProgressChanged?.Invoke();
			}
		}

		private float ProgressElementDelta => 1f / (float)listsInfos.Length;

		public ImportQueue(DataContainerBase container, FieldInfo[] listsInfos)
		{
			this.container = container;
			this.listsInfos = listsInfos;
			documentID = container.documentID;
		}

		public async Task Run()
		{
			abort = false;
			WebClient webClient = new WebClient();
			for (int i = 0; i < listsInfos.Length; i++)
			{
				if (abort)
				{
					break;
				}
				await PopulateList(container, listsInfos[i], webClient);
			}
			webClient.Dispose();
			onComplete?.Invoke(container);
			await Task.FromResult(result: true);
		}

		private async Task PopulateList(DataContainerBase container, FieldInfo listInfo, WebClient webClient)
		{
			Type contentType = listInfo.FieldType.GetGenericArguments().SingleOrDefault();
			if ((object)contentType == null)
			{
				Debug.LogError("Could not identify type of defs stored in " + listInfo.Name);
				return;
			}
			string name = ((PageNameAttribute)Attribute.GetCustomAttribute(listInfo, typeof(PageNameAttribute))).name;
			Output = "Downloading page '" + name + "'...";
			string text = $"https://docs.google.com/spreadsheets/d/{documentID}/gviz/tq?tqx=out:csv&sheet={name}";
			Task<string> request;
			try
			{
				request = webClient.DownloadStringTaskAsync(text);
			}
			catch (WebException)
			{
				Debug.LogError("Bad URL '" + text + "'");
				abort = true;
				throw;
			}
			while (!request.IsCompleted)
			{
				await Task.Delay(100);
			}
			string[] array = Regex.Split(request.Result, "\r\n|\r|\n");
			request.Dispose();
			Progress += 1f / 3f * ProgressElementDelta;
			Output = "Analysing headers...";
			string[] array2 = Utilities.Split(array[0]);
			int num = -1;
			List<string> list = new List<string>();
			List<int> emptyHeadersIdxs = new List<int>();
			for (int i = 0; i < array2.Length; i++)
			{
				if (string.IsNullOrEmpty(array2[i]))
				{
					emptyHeadersIdxs.Add(i);
					continue;
				}
				if (num == -1 && array2[i].ToLower() == "id")
				{
					num = i;
				}
				list.Add(array2[i]);
			}
			List<string[]> list2 = new List<string[]>();
			for (int j = 1; j < array.Length; j++)
			{
				string[] array3 = Utilities.Split(array[j]);
				if (num == -1 || !string.IsNullOrEmpty(array3[num]))
				{
					list2.Add(array3.Where((string val, int index) => !emptyHeadersIdxs.Contains(index)).ToArray());
				}
			}
			Progress += 1f / 3f * ProgressElementDelta;
			Output = "Populating list of defs '" + listInfo.Name + "'<" + contentType.Name + ">...";
			Dictionary<string, FieldInfo> dictionary = new Dictionary<string, FieldInfo>();
			foreach (string item in list)
			{
				FieldInfo field = contentType.GetField(item, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if ((object)field == null)
				{
					Debug.LogWarning("Header '" + item + "' match no field in " + contentType.Name + " type");
				}
				else
				{
					dictionary.Add(item, field);
				}
			}
			IList list3 = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(contentType));
			foreach (string[] item2 in list2)
			{
				object obj = Activator.CreateInstance(contentType);
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					if (dictionary.TryGetValue(list[num2], out var value))
					{
						value.SetValue(obj, Utilities.Parse(item2[num2], value.FieldType));
					}
				}
				list3.Add(obj);
			}
			listInfo.SetValue(container, list3);
			Progress += 1f / 3f * ProgressElementDelta;
		}
	}
}
