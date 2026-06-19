using System;
using UnityEngine;

namespace TH20
{
	public static class HospitalMapTile
	{
		public enum Type
		{
			Floor = 0,
			ArrivalPoint = 1,
			Driveway = 2,
			Path = 3,
			Pillar = 4,
			Window = 5,
			Adjoining = 6,
			Max = 7
		}

		private static readonly Color FloorColor = Color.white;

		private static readonly Color ArrivalPoint = Color.cyan;

		private static readonly Color DrivewayColor = Color.green;

		private static readonly Color PathColor = Color.yellow;

		private static readonly Color PillarColor = new Color(0.5f, 0f, 0.5f);

		private static readonly Color WindowColor = new Color(0f, 0.5f, 0.5f);

		private static readonly Color AdjoiningColor = new Color(0.75f, 0.25f, 0f);

		public static Color GetColor(Type type)
		{
			return type switch
			{
				Type.Floor => FloorColor, 
				Type.ArrivalPoint => ArrivalPoint, 
				Type.Path => PathColor, 
				Type.Driveway => DrivewayColor, 
				Type.Pillar => PillarColor, 
				Type.Window => WindowColor, 
				Type.Adjoining => AdjoiningColor, 
				_ => throw new ArgumentOutOfRangeException("type", type, null), 
			};
		}

		public static bool IsType(Color col, Type type, float threshold = 0.1f)
		{
			Color color = GetColor(type);
			if (Mathf.Abs(col.r - color.r) <= threshold && Mathf.Abs(col.g - color.g) <= threshold)
			{
				return Mathf.Abs(col.b - color.b) <= threshold;
			}
			return false;
		}

		public static bool IsHospitalFloor(Color pix)
		{
			if (!IsType(pix, Type.Floor) && !IsType(pix, Type.Window))
			{
				return IsType(pix, Type.Pillar);
			}
			return true;
		}
	}
}
