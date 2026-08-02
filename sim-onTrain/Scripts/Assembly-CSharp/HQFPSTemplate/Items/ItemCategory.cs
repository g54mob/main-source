using System;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[Serializable]
	public class ItemCategory
	{
		[SerializeField]
		private string m_Name;

		[SerializeField]
		private ItemInfo[] m_Items;

		public string Name => m_Name;

		public ItemInfo[] Items => m_Items;
	}
}
