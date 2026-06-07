using System;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class ParticleSystemData
	{
		public ParticleSystem ps;

		[NonSerialized]
		public readonly ParticleSystem.MinMaxCurve initialStartLifetime;

		[NonSerialized]
		public readonly ParticleSystem.MinMaxCurve initialStartSpeed;

		[NonSerialized]
		public readonly ParticleSystem.MinMaxCurve initialStartSize;

		[NonSerialized]
		public readonly ParticleSystem.MinMaxCurve initialRateOverTime;

		[NonSerialized]
		public readonly int initialMaxParticles;

		[NonSerialized]
		public readonly float initialVelMult;

		public bool IsActiveGO => ps.gameObject.activeInHierarchy;

		public ParticleSystemData(ParticleSystem ps)
		{
			this.ps = ps;
			ParticleSystem.MainModule main = ps.main;
			initialStartLifetime = main.startLifetime;
			initialStartSpeed = main.startSpeed;
			initialStartSize = main.startSize;
			initialMaxParticles = main.maxParticles;
			initialRateOverTime = ps.emission.rateOverTime;
			initialVelMult = ps.inheritVelocity.curveMultiplier;
		}
	}
}
