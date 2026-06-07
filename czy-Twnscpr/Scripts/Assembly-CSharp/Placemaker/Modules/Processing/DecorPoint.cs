using System;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Modules.Processing
{
	[Serializable]
	public struct DecorPoint
	{
		public int3 v;

		public Vector3 pos;

		public Vector3 normal;
	}
}
