using System.Collections.Generic;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace ManagementScripts
{
	public class TagsManager : MonoBehaviour
	{
		public static TagsManager instance;

		public Dictionary<string, BibiteTag> tags = new Dictionary<string, BibiteTag>();

		private void Awake()
		{
			instance = this;
		}

		public BibiteTag GetBibiteTag(string key)
		{
			tags.TryGetValue(key, out var value);
			return value;
		}

		public void AddToTag(BibiteBody bibite, string tagString)
		{
			if (tags.TryGetValue(tagString, out var value))
			{
				value.AddToTag(bibite);
				return;
			}
			value = new BibiteTag(tagString);
			value.AddToTag(bibite);
			tags.Add(tagString, value);
		}

		public void AddToTag(EggHatching bibite, string tagString)
		{
			if (tags.TryGetValue(tagString, out var value))
			{
				value.AddToTag(bibite);
				return;
			}
			value = new BibiteTag(tagString);
			value.AddToTag(bibite);
			tags.Add(tagString, value);
		}

		public void RemoveFromTag(BibiteBody bibite, string tagString)
		{
			if (tags.TryGetValue(tagString, out var value))
			{
				value.RemoveFromTag(bibite);
				if (value.count < 1)
				{
					tags.Remove(tagString);
				}
			}
		}

		public void RemoveFromTag(EggHatching bibite, string tagString)
		{
			if (tags.TryGetValue(tagString, out var value))
			{
				value.RemoveFromTag(bibite);
				if (value.count < 1)
				{
					tags.Remove(tagString);
				}
			}
		}
	}
}
