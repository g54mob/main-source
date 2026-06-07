using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct CustomColor
	{
		[Flags]
		public enum Kind
		{
			Basic = 1,
			Cheap = 2,
			Goths = 4,
			Vampire = 8
		}

		[SerializeField]
		[MinMaxSlider(0f, 2f)]
		private Vector2 _colorClarity;

		[field: SerializeField]
		public Color _color { get; private set; }

		[field: SerializeField]
		public Kind _kind { get; private set; }

		public float GetRandomClarity => UnityEngine.Random.Range(_colorClarity.x, _colorClarity.y);
	}
}
