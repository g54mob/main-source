using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class PolygonAndID
	{
		[SerializeField]
		private ulong polygonID_;

		[NonSerialized]
		private SimplePolygon polygon_;

		public ulong polygonID
		{
			set
			{
				polygonID_ = value;
				Invalidate();
			}
		}

		public ulong id => polygonID_;

		public SimplePolygon polygon
		{
			get
			{
				if (polygon_ == null)
				{
					Refresh();
				}
				return polygon_;
			}
			set
			{
				if (value != null)
				{
					polygonID_ = value.instanceID;
				}
				else
				{
					polygonID_ = 0uL;
				}
				polygon_ = value;
			}
		}

		public PolygonAndID()
		{
		}

		public PolygonAndID(SimplePolygon _polygon)
		{
			polygon = _polygon;
		}

		public PolygonAndID Clone(Dictionary<SimplePolygon, SimplePolygon> originalToClone = null)
		{
			if (originalToClone != null && originalToClone.TryGetValue(polygon, out var value))
			{
				return new PolygonAndID(value);
			}
			return new PolygonAndID(polygon);
		}

		public void Invalidate()
		{
			polygon_ = null;
		}

		public void Refresh()
		{
			polygon_ = Util.FindPolygonInEdMesh(polygonID_);
		}
	}
}
