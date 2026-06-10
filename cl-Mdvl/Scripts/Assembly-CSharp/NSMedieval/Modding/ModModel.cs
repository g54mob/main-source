using System;
using System.Globalization;
using UnityEngine;

namespace NSMedieval.Modding
{
	[Serializable]
	public class ModModel
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string name;

		[SerializeField]
		private string description;

		[SerializeField]
		private string author;

		[SerializeField]
		private string modVersion;

		[SerializeField]
		private string gameVersion;

		[SerializeField]
		private string[] tags;

		[NonSerialized]
		private ModTag tagCache;

		public string Name => name;

		public string Description => description;

		public string Author => author;

		public string GameVersion => gameVersion;

		public string Id => id.ToLower(CultureInfo.InvariantCulture);

		public string[] Tags => tags;

		public string ModVersion => modVersion;

		public bool IdIsNullOrEmpty => string.IsNullOrEmpty(id);

		public ModModel(string id, string name, string description, string author, string modVersion, string gameVersion, string[] tags)
		{
			this.id = id;
			this.name = name;
			this.description = description;
			this.author = author;
			this.modVersion = modVersion;
			this.gameVersion = gameVersion;
			this.tags = tags;
		}

		public ModTag GetTags()
		{
			if (tagCache != ModTag.None)
			{
				return tagCache;
			}
			if (tags == null)
			{
				return tagCache;
			}
			string[] array = tags;
			for (int i = 0; i < array.Length; i++)
			{
				if (Enum.TryParse<ModTag>(array[i], out var result))
				{
					tagCache |= result;
				}
			}
			return tagCache;
		}
	}
}
