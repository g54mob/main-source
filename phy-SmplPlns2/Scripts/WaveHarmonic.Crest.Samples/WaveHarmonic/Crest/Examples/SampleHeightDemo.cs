using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("Crest/Sample/Crest Sample Height Demo")]
	internal sealed class SampleHeightDemo : ManagedBehaviour<WaterRenderer>
	{
		[Tooltip("Which water collision layer to target.")]
		[SerializeField]
		private CollisionLayer _Layer;

		private readonly SampleCollisionHelper _SampleHeightHelper = new SampleCollisionHelper();

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private void OnUpdate(WaterRenderer water)
		{
			float magnitude = base.transform.lossyScale.magnitude;
			if (_SampleHeightHelper.SampleHeight(base.transform.position, out var height, 2f * magnitude, _Layer))
			{
				Vector3 position = base.transform.position;
				position.y = height;
				base.transform.position = position;
			}
		}
	}
}
