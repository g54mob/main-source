using System;
using DV.Utils;
using Unity.Mathematics;

namespace DV.DopplerEffects
{
	public abstract class ADopplerListener : SingletonBehaviour<ADopplerListener>
	{
		[NonSerialized]
		public float3 oldPosition;

		[NonSerialized]
		public float3 velocity;

		public abstract Doppler.UpdateMode UpdateMode { get; }

		public abstract float3 GetPosition();
	}
}
