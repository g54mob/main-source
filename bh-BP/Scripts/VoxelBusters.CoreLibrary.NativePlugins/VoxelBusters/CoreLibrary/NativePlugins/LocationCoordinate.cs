using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	[Serializable]
	public struct LocationCoordinate
	{
		[SerializeField]
		private double m_latitude;

		[SerializeField]
		private double m_longitude;

		public double Latitude
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Longitude
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}
	}
}
