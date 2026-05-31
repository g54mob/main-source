using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	public class SerieDataContext
	{
		public Vector3 labelPosition;

		public Vector3 labelLinePosition;

		public Vector3 labelLinePosition2;

		public float startAngle;

		public float toAngle;

		public float halfAngle;

		public float currentAngle;

		public float insideRadius;

		public float offsetRadius;

		public float outsideRadius;

		public Vector3 position;

		public List<Vector3> dataPoints = new List<Vector3>();

		public List<ChartLabel> dataLabels = new List<ChartLabel>();

		public List<SerieData> children = new List<SerieData>();

		public Rect rect;

		public Rect backgroundRect;

		public Rect subRect;

		public int level;

		public SerieData parent;

		public Color32 color;

		public double area;

		public float angle;

		public Vector3 offsetCenter;

		public Vector3 areaCenter;

		public float stackHeight;

		public bool isClip;

		public bool canShowLabel = true;

		public Image symbol;

		private bool m_Highligth;

		public bool selected;

		public bool highlight
		{
			get
			{
				return m_Highligth;
			}
			set
			{
				m_Highligth = value;
			}
		}

		public void Reset()
		{
			canShowLabel = true;
			highlight = false;
			parent = null;
			symbol = null;
			rect = Rect.zero;
			subRect = Rect.zero;
			children.Clear();
			dataPoints.Clear();
			dataLabels.Clear();
		}
	}
}
