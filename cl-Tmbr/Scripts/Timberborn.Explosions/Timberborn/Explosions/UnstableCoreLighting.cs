using Timberborn.ActivatorSystem;
using Timberborn.BaseComponentSystem;
using Timberborn.EntitySystem;
using Timberborn.Rendering;
using Timberborn.TemplateAttachmentSystem;
using Timberborn.TimeSystem;
using UnityEngine;

namespace Timberborn.Explosions
{
	internal class UnstableCoreLighting : BaseComponent, IAwakableComponent, IInitializableEntity, IUpdatableComponent
	{
		private readonly MaterialColorer _materialColorer;

		private readonly NonlinearAnimationManager _nonlinearAnimationManager;

		private TimedComponentActivator _timedComponentActivator;

		private UnstableCoreLightingSpec _spec;

		private Light _light;

		private float _lastStateChange;

		public UnstableCoreLighting(MaterialColorer materialColorer, NonlinearAnimationManager nonlinearAnimationManager)
		{
			_materialColorer = materialColorer;
			_nonlinearAnimationManager = nonlinearAnimationManager;
		}

		public void Awake()
		{
			_timedComponentActivator = GetComponent<TimedComponentActivator>();
			_spec = GetComponent<UnstableCoreLightingSpec>();
		}

		public void InitializeEntity()
		{
			_light = GetComponent<TemplateAttachments>().GetOrCreateAttachment(_spec.AttachmentId).Transform.GetComponentInChildren<Light>();
			_light.intensity = _spec.LightStrength;
			if (_timedComponentActivator.CountdownIsActive)
			{
				_lastStateChange = Time.time;
			}
			else
			{
				_timedComponentActivator.CountdownActivated += delegate
				{
					_lastStateChange = Time.time;
				};
			}
			DisableLight();
		}

		public void Update()
		{
			if (!_timedComponentActivator.CountdownIsActive || !(Time.timeScale > 0f))
			{
				return;
			}
			float time = Time.time;
			float num = Mathf.Lerp(_spec.MaxInterval, _spec.MinInterval, _timedComponentActivator.ActivationProgress) / _nonlinearAnimationManager.SpeedMultiplier;
			if (time >= _lastStateChange + num)
			{
				if (_light.intensity > 0f)
				{
					DisableLight();
				}
				else
				{
					EnableLight();
				}
				_lastStateChange = time;
			}
		}

		private void DisableLight()
		{
			_materialColorer.DisableLighting(this);
			_light.intensity = 0f;
		}

		private void EnableLight()
		{
			_materialColorer.EnableLighting(this);
			_light.intensity = _spec.LightStrength;
		}
	}
}
