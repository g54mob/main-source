using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	[Serializable]
	public struct CircularRegion
	{
		[SerializeField]
		private LocationCoordinate m_center;

		[SerializeField]
		private float m_radius;

		[SerializeField]
		private string m_regionId;

		public LocationCoordinate Center
		{
			get
			{
				return default(LocationCoordinate);
			}
			set
			{
			}
		}

		public float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string RegionId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
