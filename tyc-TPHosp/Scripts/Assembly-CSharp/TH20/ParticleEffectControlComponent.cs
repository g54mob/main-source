using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20
{
	[fiInspectorOnly]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ParticleEffectControlComponent : MonoBehaviour
	{
		[SerializeField]
		[FormerlySerializedAs("_effectsUnitySerialised")]
		private List<NamedListOfParticleSystems> _effects = new List<NamedListOfParticleSystems>();

		[SerializeField]
		private string[] _enableOnSpawn;

		private readonly List<string> _enabledEffects = new List<string>();

		private bool _hideForDataView;

		public bool HideForDataView
		{
			set
			{
				if (_hideForDataView == value)
				{
					return;
				}
				_hideForDataView = value;
				foreach (NamedListOfParticleSystems effect in _effects)
				{
					if (!_enabledEffects.Contains(effect.Name))
					{
						continue;
					}
					foreach (ParticleSystem particleSystem in effect.ParticleSystems)
					{
						particleSystem.gameObject.SetActive(!_hideForDataView);
					}
				}
			}
		}

		public bool ContainsSpecificParticleSystem(ParticleSystem particleSystem)
		{
			foreach (NamedListOfParticleSystems effect in _effects)
			{
				foreach (ParticleSystem particleSystem2 in effect.ParticleSystems)
				{
					if (particleSystem2 == particleSystem)
					{
						return true;
					}
				}
			}
			return false;
		}

		protected void Awake()
		{
			StopAllParticles();
		}

		private void OnEnable()
		{
			foreach (NamedListOfParticleSystems effect in _effects)
			{
				EnableEffect(effect.Name, _enabledEffects.Contains(effect.Name));
			}
		}

		private void OnDisabled()
		{
			StopAllParticles();
		}

		public void StopAllParticles()
		{
			foreach (NamedListOfParticleSystems effect in _effects)
			{
				foreach (ParticleSystem particleSystem in effect.ParticleSystems)
				{
					if (particleSystem != null)
					{
						particleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
					}
				}
			}
		}

		public void EnableAllEffects(bool enable)
		{
			foreach (NamedListOfParticleSystems effect in _effects)
			{
				EnableEffect(effect.Name, enable);
			}
		}

		public void EnableEffect(int effectIndex, bool enable)
		{
			NamedListOfParticleSystems effect = _effects[effectIndex];
			EnableEffect(effect, enable);
		}

		public void EnableEffect(string effectName, bool enable)
		{
			foreach (NamedListOfParticleSystems effect in _effects)
			{
				if (effect.Name == effectName)
				{
					EnableEffect(effect, enable);
					break;
				}
			}
		}

		private void EnableEffect(NamedListOfParticleSystems effect, bool enable)
		{
			foreach (ParticleSystem particleSystem in effect.ParticleSystems)
			{
				if (particleSystem != null)
				{
					if (enable)
					{
						particleSystem.Play();
					}
					else
					{
						particleSystem.Stop();
					}
				}
			}
			if (enable)
			{
				_enabledEffects.AddUnique(effect.Name);
			}
			else
			{
				_enabledEffects.Remove(effect.Name);
			}
		}

		public void EnableSpawnedEffects(bool enable)
		{
			if (_enableOnSpawn != null)
			{
				string[] enableOnSpawn = _enableOnSpawn;
				foreach (string effectName in enableOnSpawn)
				{
					EnableEffect(effectName, enable);
				}
			}
		}
	}
}
