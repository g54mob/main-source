using Timberborn.BaseComponentSystem;
using Timberborn.CoreSound;
using Timberborn.EntitySystem;
using Timberborn.Particles;
using Timberborn.SoundSystem;
using Timberborn.TemplateAttachmentSystem;
using UnityEngine;

namespace Timberborn.Buildings
{
	public class Fire : BaseComponent, IInitializableEntity, IParticlesSpeedMultiplier
	{
		private static readonly string SoundEventKey = "Environment.Buildings.Fire";

		private readonly ISoundSystem _soundSystem;

		private GameObject _fireRoot;

		private ParticlesRunner _particlesRunner;

		private bool _fireStarted;

		public ParticleSystem.MainModule SingleFlame { get; private set; }

		public Light Light { get; private set; }

		public float SpeedMultiplier { get; private set; } = 1f;

		public Fire(ISoundSystem soundSystem)
		{
			_soundSystem = soundSystem;
		}

		public void InitializeEntity()
		{
			string attachmentId = GetComponent<FireSpec>().AttachmentId;
			_fireRoot = GetComponent<TemplateAttachments>().GetOrCreateAttachment(attachmentId).GameObject;
			Light = _fireRoot.GetComponentInChildren<Light>();
			ParticleSystem[] componentsInChildren = _fireRoot.GetComponentsInChildren<ParticleSystem>();
			if (componentsInChildren.Length == 1)
			{
				SingleFlame = componentsInChildren[0].main;
			}
			_fireRoot.SetActive(value: false);
			_particlesRunner = GetComponent<ParticlesCache>().GetParticlesRunner(attachmentId);
			_particlesRunner.AddParticleSpeedMultiplier(this);
		}

		public void Enable()
		{
			if (!_fireStarted)
			{
				_fireRoot.SetActive(value: true);
				_soundSystem.LoopSingle3DSound(_fireRoot, SoundEventKey, 128);
				_soundSystem.SetCustomMixer(_fireRoot, SoundEventKey, MixerNames.BuildingMixerNameKey);
				_fireStarted = true;
			}
		}

		public void Disable()
		{
			_fireRoot.SetActive(value: false);
			if (_fireStarted)
			{
				_soundSystem.StopSound(_fireRoot, SoundEventKey);
			}
			_fireStarted = false;
		}

		public void SetSpeedMultiplier(float speedMultiplier)
		{
			SpeedMultiplier = speedMultiplier;
			_particlesRunner.UpdateSimulationSpeed();
		}
	}
}
