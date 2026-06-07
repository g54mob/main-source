using System.Collections.Generic;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class VariableNozzleAnimationScript : MonoBehaviour
	{
		public class Blade
		{
			public Vector3 OriginalRotation { get; set; }

			public Transform Transform { get; set; }

			public Blade(Transform blade)
			{
				Transform = blade;
				OriginalRotation = Transform.localEulerAngles;
			}

			public void SetRotation(float rotation)
			{
				Vector3 originalRotation = OriginalRotation;
				originalRotation.z += rotation;
				Transform.localEulerAngles = originalRotation;
			}
		}

		private List<Blade> _blades = new List<Blade>();

		private float _expansion;

		private bool _initialized;

		[SerializeField]
		private float _maxAngle = 15f;

		public void SetExpansion(float expansion, bool animate = true)
		{
			if (!_initialized)
			{
				Initialize();
			}
			if (animate)
			{
				_expansion = Utilities.StepTowards(_expansion, 1f * Time.deltaTime, expansion);
			}
			else
			{
				_expansion = expansion;
			}
			float rotation = _expansion * _maxAngle;
			foreach (Blade blade in _blades)
			{
				blade.SetRotation(rotation);
			}
		}

		private void Initialize()
		{
			_initialized = true;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Blade item = new Blade(base.transform.GetChild(i));
				_blades.Add(item);
			}
		}
	}
}
