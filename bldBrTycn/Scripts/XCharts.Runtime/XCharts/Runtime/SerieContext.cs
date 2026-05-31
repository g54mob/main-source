using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	public class SerieContext
	{
		public bool pointerEnter;

		public int pointerItemDataIndex = -1;

		public int pointerItemDataDimension = 1;

		public List<int> pointerAxisDataIndexs = new List<int>();

		public bool isTriggerByAxis;

		public int dataZoomStartIndex;

		public int dataZoomStartIndexOffset;

		public Vector3 center;

		public Vector3 lineEndPostion;

		public double lineEndValue;

		public float insideRadius;

		public float outsideRadius;

		public float startAngle;

		public double dataMax;

		public double dataMin;

		public double checkValue;

		public float x;

		public float y;

		public float width;

		public float height;

		public Rect rect;

		public int vertCount;

		public int colorIndex;

		public List<Vector3> dataPoints = new List<Vector3>();

		public List<bool> dataIgnores = new List<bool>();

		public List<int> dataIndexs = new List<int>();

		public List<SerieData> sortedData = new List<SerieData>();

		public List<SerieData> rootData = new List<SerieData>();

		public List<PointInfo> drawPoints = new List<PointInfo>();

		public SerieParams param = new SerieParams();

		public Tooltip.Type tooltipType;

		public Tooltip.Trigger tooltipTrigger;

		public int totalDataIndex;

		public ChartLabel titleObject { get; set; }
	}
}
