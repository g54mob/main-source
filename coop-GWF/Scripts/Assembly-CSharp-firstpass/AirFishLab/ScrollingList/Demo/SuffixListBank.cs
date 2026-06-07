using System;
using System.Collections.Generic;
using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
	public class SuffixListBank : BaseListBank
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
			LoadSuffixNames();
		}

		private void LoadSuffixNames()
		{
			TextAsset textAsset = Resources.Load<TextAsset>("suffix");
			if (textAsset != null)
			{
				_contents.AddRange(JsonUtility.FromJson<JsonStringArray>(textAsset.text).array);
			}
			else
			{
				Debug.LogWarning("JSON file 'Suffix' not found in Resources folder.");
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
