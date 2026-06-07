using System;
using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class VectorExtensions
	{
		public static string XAttributeValue(this Vector2d v)
		{
			return DataIO.ToString(v.x) + "," + DataIO.ToString(v.y);
		}

		public static string XAttributeValue(this Vector2i v)
		{
			return DataIO.ToString(v.x) + "," + DataIO.ToString(v.y);
		}

		public static string XAttributeValue(this Vector2 v)
		{
			return DataIO.ToString(v.x) + "," + DataIO.ToString(v.y);
		}

		public static string XAttributeValue(this Vector3d v)
		{
			return DataIO.ToString(v.x) + "," + DataIO.ToString(v.y) + "," + DataIO.ToString(v.z);
		}

		public static string XAttributeValue(this Vector3i v)
		{
			return DataIO.ToString(v.x) + "," + DataIO.ToString(v.y) + "," + DataIO.ToString(v.z);
		}

		public static string XAttributeValue(this Vector3 v)
		{
			return DataIO.ToString(v.x) + "," + DataIO.ToString(v.y) + "," + DataIO.ToString(v.z);
		}

		public static string XAttributeValue(this Vector4d v)
		{
			return DataIO.ToString(v.x) + "," + DataIO.ToString(v.y) + "," + DataIO.ToString(v.z) + "," + DataIO.ToString(v.w);
		}

		public static string XAttributeValue(this Vector4 v)
		{
			return DataIO.ToString(v.x) + "," + DataIO.ToString(v.y) + "," + DataIO.ToString(v.z) + "," + DataIO.ToString(v.w);
		}
	}
}
