using System;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal class PositionData
	{
		[SerializeField]
		public Vector3 direction = Vector3.up;

		[SerializeField]
		public float amplitude = 1f;
	}
}
