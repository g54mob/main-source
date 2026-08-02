using System;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[CreateAssetMenu(fileName = "New Localization Table", menuName = "Heat UI/Localization/New Localization Table")]
	public class LocalizationTable : ScriptableObject
	{
		[Serializable]
		public class TableContent
		{
			public string key;
		}

		public string tableID;

		public LocalizationSettings localizationSettings;

		public List<TableContent> tableContent = new List<TableContent>();
	}
}
