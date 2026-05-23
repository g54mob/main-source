using System;
using System.Collections.Generic;
using UnityEngine;

public class CreditList : ScriptableObject
{
	[Serializable]
	public class Entry
	{
		public string headingId;

		public string titles;

		public string names;

		public string[] faceIds;

		public bool hasTitles
		{
			get
			{
				return titles.HasValue();
			}
		}
	}

	public List<Entry> entries;
}
