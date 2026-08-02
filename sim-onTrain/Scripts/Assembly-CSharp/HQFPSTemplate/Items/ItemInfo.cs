using System;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[Serializable]
	public class ItemInfo
	{
		[SerializeField]
		private string m_Name;

		[Space]
		[SerializeField]
		[ReadOnly]
		private int m_Id;

		[SerializeField]
		[ReadOnly]
		private string m_Category;

		[Space]
		[SerializeField]
		[PreviewSprite]
		private Sprite m_Icon;

		[Space]
		[SerializeField]
		[MultilineCustom(5)]
		private string m_Description;

		[SerializeField]
		private GameObject m_Pickup;

		[SerializeField]
		[Clamp(1f, 1000f)]
		private int m_StackSize = 1;

		[Space]
		[SerializeField]
		[Reorderable]
		private ItemPropertyInfoList m_Properties;

		public int Id => m_Id;

		public string Name => m_Name;

		public string Category
		{
			get
			{
				return m_Category;
			}
			set
			{
				m_Category = value;
			}
		}

		public Sprite Icon => m_Icon;

		public string Description => m_Description;

		public GameObject Pickup => m_Pickup;

		public int StackSize => m_StackSize;

		public ItemPropertyInfoList Properties => m_Properties;
	}
}
