using Unity.Mathematics;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public struct LightweightVertex
	{
		public float3 pos;

		public Color32 color;

		public sbyte normX;

		public sbyte normY;

		public sbyte normZ;

		public sbyte normW;

		public sbyte tanX;

		public sbyte tanY;

		public sbyte tanZ;

		public sbyte tanW;

		public half2 uv;

		public half2 uv2;

		public Vector3 Position
		{
			get
			{
				return pos;
			}
			set
			{
				pos = value;
			}
		}

		public Color32 Color
		{
			get
			{
				return color;
			}
			set
			{
				color = value;
			}
		}

		public Vector3 Normal
		{
			get
			{
				return new Vector3((float)normX / 127f, (float)normY / 127f, (float)normZ / 127f);
			}
			set
			{
				normX = (sbyte)(value.x * 127f);
				normY = (sbyte)(value.y * 127f);
				normZ = (sbyte)(value.z * 127f);
				normW = 1;
			}
		}

		public Vector4 Tangent
		{
			get
			{
				return new Vector4((float)tanX / 127f, (float)tanY / 127f, (float)tanZ / 127f, (float)tanW / 127f);
			}
			set
			{
				tanX = (sbyte)(value.x * 127f);
				tanY = (sbyte)(value.y * 127f);
				tanZ = (sbyte)(value.z * 127f);
				tanW = (sbyte)(value.w * 127f);
			}
		}

		public Vector2 UV
		{
			get
			{
				return new Vector2(uv.x, uv.y);
			}
			set
			{
				uv = new half2((half)value.x, (half)value.y);
			}
		}

		public Vector2 UV2
		{
			get
			{
				return new Vector2(uv2.x, uv2.y);
			}
			set
			{
				uv2 = new half2((half)value.x, (half)value.y);
			}
		}
	}
}
