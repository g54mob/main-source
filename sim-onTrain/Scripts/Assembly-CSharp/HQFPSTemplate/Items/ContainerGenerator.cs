using System;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[Serializable]
	public class ContainerGenerator
	{
		[SerializeField]
		private string m_Name;

		[SerializeField]
		private ItemContainerFlags m_Flag;

		[SerializeField]
		[Range(1f, 100f)]
		private int m_Size = 1;

		[BHeader("Item Filtering")]
		[SerializeField]
		private bool m_OneStackPerItem;

		[SerializeField]
		[DatabaseCategory]
		private string[] m_ValidCategories;

		[SerializeField]
		[DatabaseProperty]
		private string[] m_RequiredProperties;

		public string Name => m_Name;

		public int Size => m_Size;

		public ItemContainer GenerateContainer(Transform parent)
		{
			return new ItemContainer(m_Name, m_Size, parent, m_Flag, m_OneStackPerItem, m_ValidCategories, m_RequiredProperties);
		}
	}
}
