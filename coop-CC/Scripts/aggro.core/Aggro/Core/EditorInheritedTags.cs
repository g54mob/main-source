using System.Collections.Generic;
using UnityEngine;

namespace Aggro.Core
{
	public class EditorInheritedTags
	{
		internal struct EditorInheritedTag
		{
			public Object from;

			public string tagListPath;
		}

		internal List<EditorInheritedTag> tags = new List<EditorInheritedTag>();

		public void AddTag(Object from, string tagListPath)
		{
			EditorInheritedTag item = new EditorInheritedTag
			{
				from = from,
				tagListPath = tagListPath
			};
			tags.Add(item);
		}
	}
}
