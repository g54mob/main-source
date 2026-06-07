using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class LevelStyle : ChildComponent
	{
		[SerializeField]
		private bool m_Show;

		[SerializeField]
		private List<Level> m_Levels = new List<Level>
		{
			new Level()
		};

		public bool show
		{
			get
			{
				return m_Show;
			}
			set
			{
				m_Show = value;
			}
		}

		public List<Level> levels => m_Levels;
	}
}
