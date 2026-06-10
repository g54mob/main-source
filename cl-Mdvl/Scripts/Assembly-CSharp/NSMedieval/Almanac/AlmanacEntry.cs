using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Dictionary;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.Almanac
{
	[Serializable]
	public class AlmanacEntry : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string name;

		[SerializeField]
		private string groupId;

		[SerializeField]
		private string path;

		[FormerlySerializedAs("iconPath")]
		[SerializeField]
		private string iconId;

		[SerializeField]
		private StringStringDictionary entries;

		[SerializeField]
		private List<string> tags;

		[NonSerialized]
		private StringStringDictionary materialQualityEntries;

		[NonSerialized]
		private string iconColorOverlay;

		[NonSerialized]
		private string selectedMaterial;

		public string Name => name;

		public string GroupId => groupId;

		public StringStringDictionary Entries => entries;

		public StringStringDictionary MaterialQualityEntries => materialQualityEntries;

		public string Path => path;

		public List<string> Tags => tags;

		public string IconId => iconId;

		public string SelectedMaterial
		{
			get
			{
				if (string.IsNullOrEmpty(selectedMaterial) && MaterialQualityEntries.Dictionary.Count > 0)
				{
					selectedMaterial = MaterialQualityEntries.Dictionary.First().Key;
				}
				return selectedMaterial;
			}
		}

		public string IconColorOverlay => iconColorOverlay;

		public AlmanacEntry(string entryId, string name, string groupId, string path, string iconId, StringStringDictionary entries, StringStringDictionary materialQualityEntries, List<string> tags)
		{
			id = entryId;
			this.name = name;
			this.groupId = groupId;
			this.path = path;
			this.iconId = iconId;
			this.entries = entries;
			this.materialQualityEntries = materialQualityEntries;
			this.tags = tags;
		}

		public bool TryGetMaterialQualityEntry(out string entry)
		{
			if (string.IsNullOrEmpty(selectedMaterial))
			{
				StringStringDictionary stringStringDictionary = MaterialQualityEntries;
				if (stringStringDictionary == null || !(stringStringDictionary.Dictionary?.Count > 0))
				{
					entry = null;
					return false;
				}
				selectedMaterial = MaterialQualityEntries.Dictionary.First().Key;
			}
			entry = MaterialQualityEntries.Dictionary[selectedMaterial];
			return true;
		}

		public void SelectMaterial(string material)
		{
			selectedMaterial = material;
		}

		public void AddTags(List<string> newTags)
		{
			tags.AddRange(newTags);
		}

		public void SetIconId(string path)
		{
			iconId = path;
		}

		public void SetIconColorOverlayId(string iconColorOverlay)
		{
			this.iconColorOverlay = iconColorOverlay;
		}

		public override string GetID()
		{
			return id;
		}
	}
}
