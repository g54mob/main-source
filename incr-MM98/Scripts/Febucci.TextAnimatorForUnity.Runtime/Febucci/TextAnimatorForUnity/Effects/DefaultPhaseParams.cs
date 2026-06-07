using System;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	public class DefaultPhaseParams
	{
		[Range(0f, 1f)]
		public float charOffset;

		[Range(0f, 1f)]
		public float wordOffset;

		public float speed = 1f;
	}
}
