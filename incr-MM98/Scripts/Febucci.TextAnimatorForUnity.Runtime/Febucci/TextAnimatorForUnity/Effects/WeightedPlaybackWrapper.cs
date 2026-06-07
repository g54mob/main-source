using System;
using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	public class WeightedPlaybackWrapper : WeightedPlayback
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float intensity01;

		protected override float Intensity01 => intensity01;
	}
}
