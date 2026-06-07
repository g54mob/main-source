using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class Level : ChildComponent
	{
		[SerializeField]
		private LabelStyle m_Label = new LabelStyle();

		[SerializeField]
		private LabelStyle m_UpperLabel = new LabelStyle();

		[SerializeField]
		private ItemStyle m_ItemStyle = new ItemStyle();

		public LabelStyle label => m_Label;

		public LabelStyle upperLabel => m_UpperLabel;

		public ItemStyle itemStyle => m_ItemStyle;
	}
}
