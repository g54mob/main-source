using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DemolishLandscapeItemEffect : MonoBehaviour
	{
		public class Config
		{
			[InspectorTooltip("Random time before effect starts")]
			public float MaxStartTime = 1f;

			[InspectorTooltip("Demolish time in metres per second")]
			public float DemolishTimeMS = 0.5f;

			[InspectorTooltip("Demolish particle effect to play")]
			public ParticleSystem DemolishParticleSystem;
		}

		private class RendererInstance
		{
			public Renderer Renderer;

			public Material[] OriginalMaterials;

			public Material[] FadeMaterials;
		}

		private float _time;

		private float _demolishTime;

		private float _originalScale;

		private List<RendererInstance> _rendererInstances;

		private ParticleSystem[] _particles;

		private const string _colorPropName = "_Color";

		private bool _playSound;

		public void Initialise(Config config, float demolishTime)
		{
			_time = demolishTime;
			_demolishTime = config.DemolishTimeMS;
			_originalScale = base.transform.localScale.y;
			_rendererInstances = new List<RendererInstance>();
			Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				RendererInstance rendererInstance = new RendererInstance
				{
					Renderer = renderer,
					OriginalMaterials = renderer.sharedMaterials
				};
				rendererInstance.FadeMaterials = new Material[rendererInstance.OriginalMaterials.Length];
				for (int j = 0; j < rendererInstance.OriginalMaterials.Length; j++)
				{
					Material material = rendererInstance.OriginalMaterials[j];
					if (material != null)
					{
						Material material2 = new Material(material);
						TH20Standard.SetBlendMode(material2, TH20Standard.BlendMode.Dithered);
						rendererInstance.FadeMaterials[j] = material2;
					}
				}
				_playSound = renderer.bounds.max.y > 2f;
				renderer.materials = rendererInstance.FadeMaterials;
				_rendererInstances.Add(rendererInstance);
			}
		}

		private void OnDestroy()
		{
			foreach (RendererInstance rendererInstance in _rendererInstances)
			{
				rendererInstance.Renderer.materials = rendererInstance.OriginalMaterials;
				for (int i = 0; i < rendererInstance.OriginalMaterials.Length; i++)
				{
					Object.Destroy(rendererInstance.FadeMaterials[i]);
				}
				rendererInstance.FadeMaterials = null;
			}
		}

		private void LateUpdate()
		{
			float deltaTime = GameTime.deltaTime;
			if (!(deltaTime > 0f))
			{
				return;
			}
			if (_time >= 0f)
			{
				_time -= deltaTime;
				if (_time <= 0f)
				{
					ParticleEffectControlComponent componentInChildren = base.gameObject.GetComponentInChildren<ParticleEffectControlComponent>();
					if (componentInChildren != null)
					{
						componentInChildren.EnableAllEffects(enable: true);
						_particles = base.gameObject.GetComponentsInChildren<ParticleSystem>();
					}
					if (_playSound)
					{
						AudioManager.Instance.Play("LandPlotItemDestroy", base.gameObject);
					}
				}
			}
			if (!(_time <= 0f))
			{
				return;
			}
			float num = 0f - _time;
			if (num >= _demolishTime)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			num /= _demolishTime;
			float num2 = 1f - EasingsUtils.BounceEaseOut(num);
			base.transform.localScale = new Vector3(1f, _originalScale * num2, 1f);
			if (_particles != null)
			{
				Vector3 localScale = new Vector3(1f, 1f + num2, 1f);
				ParticleSystem[] particles = _particles;
				for (int i = 0; i < particles.Length; i++)
				{
					particles[i].gameObject.transform.localScale = localScale;
				}
			}
			FadeMeshNearCameraComponent component = GetComponent<FadeMeshNearCameraComponent>();
			if (component != null)
			{
				component.enabled = false;
			}
			float num3 = 1f - num;
			float num4 = ((component != null) ? component.Alpha : 1f);
			float a = num3 * num3 * num4;
			foreach (RendererInstance rendererInstance in _rendererInstances)
			{
				Material[] fadeMaterials = rendererInstance.FadeMaterials;
				foreach (Material material in fadeMaterials)
				{
					if (material != null && material.HasProperty("_Color"))
					{
						Color color = material.color;
						color.a = a;
						material.color = color;
					}
				}
			}
			_time -= deltaTime;
		}
	}
}
