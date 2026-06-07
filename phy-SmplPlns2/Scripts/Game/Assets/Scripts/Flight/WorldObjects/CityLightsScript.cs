using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class CityLightsScript : MonoBehaviour
	{
		[Serializable]
		public class MaterialEmission
		{
			[SerializeField]
			private float _emissionIntensity = 2.5f;

			[SerializeField]
			private Material _material;

			[SerializeField]
			private Color _targetEmission;

			public float EmissionIntensity => _emissionIntensity;

			public Material Material => _material;

			public Color TargetEmission => _targetEmission;
		}

		private List<Tweener> _animations = new List<Tweener>();

		private bool _emissionEnabled;

		[SerializeField]
		private MaterialEmission[] _materialEmissions;

		protected virtual void OnDestroy()
		{
			EnableEmission(enable: false, animate: false);
		}

		protected virtual void Update()
		{
			EnableEmission(FlightSceneScript.Instance.Environment.IsNight);
		}

		private void EnableEmission(bool enable, bool animate = true)
		{
			if (_emissionEnabled == enable)
			{
				return;
			}
			foreach (Tweener animation in _animations)
			{
				animation.Kill();
			}
			_animations.Clear();
			_emissionEnabled = enable;
			float num = 0f;
			MaterialEmission[] materialEmissions = _materialEmissions;
			foreach (MaterialEmission m in materialEmissions)
			{
				Color color = (enable ? (m.TargetEmission * m.EmissionIntensity) : Color.black);
				if (animate)
				{
					TweenerCore<Color, Color, ColorOptions> item = DOTween.To(() => m.Material.GetColor("_EmissionColor"), delegate(Color c)
					{
						m.Material.SetColor("_EmissionColor", c);
					}, color, 0.5f).SetDelay(num).SetUpdate(isIndependentUpdate: true);
					_animations.Add(item);
					num += 0.25f;
				}
				else
				{
					m.Material.SetColor("_EmissionColor", color);
				}
			}
		}
	}
}
