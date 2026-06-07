using System.Collections.Generic;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class VariableNozzleAnimationScript : MonoBehaviour
	{
		public class Blade
		{
			public Quaternion OriginalRotation { get; set; }

			public Transform Transform { get; set; }

			public Blade(Transform blade)
			{
				Transform = blade;
				OriginalRotation = Transform.localRotation;
			}

			public void SetRotation(float rotation)
			{
				Quaternion originalRotation = OriginalRotation;
				originalRotation *= Quaternion.Euler(0f, 0f, rotation);
				Transform.localRotation = originalRotation;
			}
		}

		private List<Blade> _blades = new List<Blade>();

		private float _expansion;

		private bool _initialized;

		[SerializeField]
		private float _maxAngle = 15f;

		[SerializeField]
		private Transform _measure1;

		[SerializeField]
		private Transform _measure2;

		public float NozzleRadius => (_measure1.position - _measure2.position).magnitude / 2f;

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

		public void SetLengthScale(float scale)
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				base.transform.GetChild(i).localScale = new Vector3(scale, 1f, 1f);
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
