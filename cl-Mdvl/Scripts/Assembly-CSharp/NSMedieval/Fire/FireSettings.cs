using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.GameEventSystem;
using UnityEngine;

namespace NSMedieval.Fire
{
	[Serializable]
	public class FireSettings : NSEipix.Base.Model
	{
		[Serializable]
		public class FireParticleSettings
		{
			[SerializeField]
			private int flameType;

			[SerializeField]
			private List<string> particlePrefabs;

			public int FlameType => flameType;

			public List<string> ParticlePrefabs => particlePrefabs;
		}

		[SerializeField]
		private float grassDamageMultiplier;

		[SerializeField]
		private float fireDamageThresholdStartRain;

		[SerializeField]
		private float fireTimeThresholdStartRain;

		[SerializeField]
		private float fireCountThresholdRain;

		[SerializeField]
		private InterpolatedValueList fireSlowdownByTotalDamage;

		[SerializeField]
		private float fireTemperatureBoost;

		[SerializeField]
		private float greekFireTemperatureBoost;

		[SerializeField]
		private List<FireParticleSettings> particleSettings;

		public float GrassDamageMultiplier => grassDamageMultiplier;

		public float FireDamageThresholdStartRain => fireDamageThresholdStartRain;

		public float FireTimeThresholdStartRain => fireTimeThresholdStartRain;

		public float FireCountThresholdRain => fireCountThresholdRain;

		public InterpolatedValueList FireSlowdownByTotalDamage => fireSlowdownByTotalDamage;

		public float FireTemperatureBoost => fireTemperatureBoost;

		public float GreekFireTemperatureBoost => greekFireTemperatureBoost;

		public List<FireParticleSettings> ParticleSettings => particleSettings;

		public override string GetID()
		{
			return "FireSettings";
		}
	}
}
