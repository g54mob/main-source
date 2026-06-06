using System;
using System.Collections.Generic;
using System.Text;
using Unity.Collections;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class WindManager : IManager, IDisposable, IValid
	{
		public struct WindData
		{
			public BitField32 flag;

			public MagicaWindZone.Mode mode;

			public float3 size;

			public float main;

			public float turbulence;

			public float zoneVolume;

			public float3 worldWindDirection;

			public float3 worldPositin;

			public quaternion worldRotation;

			public float3 worldScale;

			public float4x4 worldToLocalMatrix;

			public float4x4 attenuation;

			public bool IsValid()
			{
				return false;
			}

			public bool IsEnable()
			{
				return false;
			}

			public bool IsAddition()
			{
				return false;
			}
		}

		public const int Flag_Valid = 0;

		public const int Flag_Enable = 1;

		public const int Flag_Addition = 2;

		public ExNativeArray<WindData> windDataArray;

		private bool isValid;

		private Dictionary<int, MagicaWindZone> windZoneDict;

		public int WindCount => 0;

		public void Dispose()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Initialize()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public int AddWind(MagicaWindZone windZone)
		{
			return 0;
		}

		public void RemoveWind(int windId)
		{
		}

		public void SetEnable(int windId, bool sw)
		{
		}

		internal void AlwaysWindUpdate()
		{
		}

		public void InformationLog(StringBuilder allsb)
		{
		}
	}
}
