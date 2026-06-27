using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Restory.Scripts.Restory.Data.Dialogue
{
	[CreateAssetMenu(menuName = "Restory/Dialogue/AdditionalImages", fileName = "DialogueAdditionalImagesSettings")]
	public class DialogueAdditionalImagesSettings : ScriptableObject
	{
		[Serializable]
		private class Entry
		{
			public string ID;

			public Sprite Sprite;
		}

		[SerializeField]
		private Entry[] entries = new Entry[0];

		private readonly Dictionary<string, Sprite> images = new Dictionary<string, Sprite>();

		public bool TryGetImage(string id, out Sprite image)
		{
			if (images.Count == 0)
			{
				FillDictionary();
			}
			return images.TryGetValue(id, out image);
		}

		private void FillDictionary()
		{
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry != null && !string.IsNullOrEmpty(entry.ID))
				{
					images.Add(entry.ID, entry.Sprite);
				}
			}
		}

		[UsedImplicitly]
		private bool ValidateEntries()
		{
			return (from entry in entries
				select entry.ID into id
				where !string.IsNullOrEmpty(id)
				select id).Distinct().Count() == entries.Length;
		}
	}
}
