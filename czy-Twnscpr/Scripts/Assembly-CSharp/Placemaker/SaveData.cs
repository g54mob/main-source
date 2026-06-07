using System;
using System.Collections.Generic;
using UnityEngine;

namespace Placemaker
{
	[Serializable]
	public class SaveData
	{
		[Serializable]
		public struct C
		{
			public int x;

			public int y;

			public int count;

			public override string ToString()
			{
				return null;
			}
		}

		[Serializable]
		public struct V
		{
			public byte t;

			public byte h;
		}

		[Serializable]
		public struct Cam
		{
			public byte x;

			public byte y;

			public byte z;
		}

		[Serializable]
		public struct Sun
		{
			public byte h;

			public byte r;
		}

		public string saveString;

		public long lastWriteTime;

		public Cam cam;

		public Sun sun;

		public List<C> corners;

		public List<V> voxels;

		[HideInInspector]
		public byte[] bigJpg;

		public void Clear()
		{
		}

		public void ReadNonImageDataFrom(SaveData other)
		{
		}

		public void CopyFrom(SaveData other)
		{
		}
	}
}
