using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERSplatmap
	{
		public int x;

		public int y;

		public int index;

		public int layer;

		public float value;

		public ERModularRoad script;

		public float tValue1;

		public float tValue2;

		public float tValue3;

		public float tValue4;

		public float tValue5;

		public float tValue6;

		public float tValue7;

		public float tValue8;

		public float tValue9;

		public float tValue10;

		public float tValue11;

		public float tValue12;

		public ERSplatmap(int m_x, int m_y, int m_index, int m_layer, float m_value, ERModularRoad scr, float tv1, float tv2, float tv3, float tv4, float tv5, float tv6, float tv7, float tv8, float tv9, float tv10, float tv11, float tv12)
		{
			x = m_x;
			y = m_y;
			index = m_index;
			layer = m_layer;
			value = m_value;
			script = scr;
			tValue1 = tv1;
			tValue2 = tv2;
			tValue3 = tv3;
			tValue4 = tv4;
			tValue5 = tv5;
			tValue6 = tv6;
			tValue7 = tv7;
			tValue8 = tv8;
			tValue9 = tv9;
			tValue10 = tv10;
			tValue11 = tv11;
			tValue12 = tv12;
		}
	}
}
