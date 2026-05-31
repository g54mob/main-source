using System;
using UnityEngine;

namespace PG
{
	[Serializable]
	public class GroundConfig
	{
		public string Caption;

		public GroundType GroundType;

		public ParticleSystem IdleParticles;

		public ParticleSystem SlipParticles;

		public bool TemperatureDependent;

		public bool SpeedDependent;

		public float WheelStiffness;
	}
}
