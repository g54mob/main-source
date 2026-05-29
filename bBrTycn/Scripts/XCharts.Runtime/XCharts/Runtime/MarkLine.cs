using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[ComponentHandler(typeof(MarkLineHandler), true)]
	public class MarkLine : MainComponent
	{
		[SerializeField]
		private bool m_Show = true;

		[SerializeField]
		private int m_SerieIndex;

		[SerializeField]
		private AnimationStyle m_Animation = new AnimationStyle();

		[SerializeField]
		private List<MarkLineData> m_Data = new List<MarkLineData>();

		public bool show
		{
			get
			{
				return m_Show;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Show, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int serieIndex
		{
			get
			{
				return m_SerieIndex;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_SerieIndex, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public AnimationStyle animation
		{
			get
			{
				return m_Animation;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Animation, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public List<MarkLineData> data
		{
			get
			{
				return m_Data;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Data, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public override void SetDefaultValue()
		{
			data.Clear();
			MarkLineData markLineData = new MarkLineData();
			markLineData.name = "average";
			markLineData.type = MarkLineType.Average;
			markLineData.lineStyle.type = LineStyle.Type.Dashed;
			markLineData.lineStyle.color = Color.clear;
			markLineData.startSymbol.show = true;
			markLineData.startSymbol.type = SymbolType.Circle;
			markLineData.startSymbol.size = 4f;
			markLineData.endSymbol.show = true;
			markLineData.endSymbol.type = SymbolType.Arrow;
			markLineData.endSymbol.size = 5f;
			markLineData.label.show = true;
			markLineData.label.numericFormatter = "f1";
			markLineData.label.formatter = "{c}";
			data.Add(markLineData);
		}
	}
}
