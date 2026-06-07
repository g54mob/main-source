using System;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class ExtendedEdge : Edge
	{
		private Vector2 uv0_;

		private Vector2 uv1_;

		public override Vector2 uv0
		{
			get
			{
				return uv0_;
			}
			set
			{
				uv0_ = value;
			}
		}

		public override Vector2 uv1
		{
			get
			{
				return uv1_;
			}
			set
			{
				uv1_ = value;
			}
		}

		public ExtendedEdge()
		{
		}

		public ExtendedEdge(Vertex v0, Vertex v1)
		{
			p0 = v0.pos;
			p1 = v1.pos;
			uv0 = v0.uv;
			uv1 = v1.uv;
		}

		public ExtendedEdge(Vector3 _p0, Vector3 _p1, Vector2 _uv0, Vector2 _uv1)
		{
			p0 = _p0;
			p1 = _p1;
			uv0 = _uv0;
			uv1 = _uv1;
		}

		public override bool ContainsUVs()
		{
			return true;
		}

		public override Edge Clone()
		{
			return new ExtendedEdge(p0, p1, uv0, uv1);
		}

		public override Edge Invert()
		{
			base.Invert();
			MathUtil.Swap(ref uv0_, ref uv1_);
			return this;
		}
	}
}
