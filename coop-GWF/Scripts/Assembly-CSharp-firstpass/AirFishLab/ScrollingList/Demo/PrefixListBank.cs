using System;
using System.Collections.Generic;
using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
	public class PrefixListBank : BaseListBank
	{
		[Serializable]
		private class JsonStringArray
		{
			public List<string> array;
		}

		private List<string> _contents = new List<string>();

		private readonly StringListContent _contentWrapper = new StringListContent();

		private void Awake()
		{
			LoadPrefixNames();
		}

		private void LoadPrefixNames()
		{
			TextAsset textAsset = Resources.Load<TextAsset>("prefix");
			if (textAsset != null)
			{
				_contents.AddRange(JsonUtility.FromJson<JsonStringArray>(textAsset.text).array);
			}
			else
			{
				Debug.LogWarning("JSON file 'prefix' not found in Resources folder.");
			}
		}

		public override IListContent GetListContent(int index)
		{
			_contentWrapper.Value = _contents[index];
			return _contentWrapper;
		}

		public override int GetContentCount()
		{
			return _contents.Count;
		}
	}
}
