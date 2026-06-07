using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	[AllowDynamicRestore]
	public class SparksGenerator : AttachedBehaviour
	{
		private AnimationCurve _damageCurve;

		private DamageStat _damageStat;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isActive;

		[PersistenceOptIn]
		private float _currentInterval;

		[PersistenceOptIn]
		private float _timeLeftUntilNextSpark;

		public List<SphereCollider> InfluenceAreaColliders;

		private List<ParticleSystem> _sparkParticleSystems;

		private List<ParticleSystem> _fakeSparkParticleSystems;

		private static Dictionary<SparkChance, (float baseSparkInterval, float minSparkInterval)> _sparkIntervals;

		public static List<SparksGenerator> AllGenerators { get; private set; }

		public float SparkInterval => 0f;

		public float TimeLeftUntilNextSpark => 0f;

		public event EventHandler OnEnabledChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public static void Init()
		{
		}

		public static void FakeSparkAllGenerators()
		{
		}

		public void SetActive(bool active)
		{
		}

		public override void Start()
		{
		}

		private void OnPostBuilt(object sender, EventArgs e)
		{
		}

		public override void OnDestroy()
		{
		}

		private void OnValueChanged(object sender, ValueChangedEventArgs<float> e)
		{
		}

		public static (float, float) GetSparkIntervals(SparkChance sparkChance)
		{
			return default((float, float));
		}

		public (float, float) GetSparkIntervals()
		{
			return default((float, float));
		}

		public SparkChance GetCurrentSparkChance()
		{
			return default(SparkChance);
		}

		private void UpdateInterval()
		{
		}

		public float GetDamageIntervalAddition()
		{
			return 0f;
		}

		protected override void UpdateInternal()
		{
		}

		private void SparkRandomly()
		{
		}

		private void Spark()
		{
		}

		private void FakeSpark()
		{
		}

		private void FakeSparkConfig(ParticleSystem ps)
		{
		}

		public void EnableFakeSparks(bool enable)
		{
		}

		private void EnableSparks(bool enable)
		{
		}
	}
}
