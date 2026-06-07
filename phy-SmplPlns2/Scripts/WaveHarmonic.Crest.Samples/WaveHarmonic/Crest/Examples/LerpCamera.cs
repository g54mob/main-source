using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("")]
	internal sealed class LerpCamera : ManagedBehaviour<WaterRenderer>
	{
		[SerializeField]
		private float _LerpAlpha = 0.1f;

		[SerializeField]
		private Transform _Target;

		[SerializeField]
		private Transform _LookAt;

		[SerializeField]
		private float _LookAtOffset = 5f;

		[SerializeField]
		private float _MinimumHeightAboveWater = 0.5f;

		private readonly SampleCollisionHelper _SampleHeightHelper = new SampleCollisionHelper();

		public Transform Target
		{
			get
			{
				return _Target;
			}
			set
			{
				_Target = value;
			}
		}

		public Transform LookAt
		{
			get
			{
				return _LookAt;
			}
			set
			{
				_LookAt = value;
			}
		}

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private void OnUpdate(WaterRenderer water)
		{
			if (!(_Target == null))
			{
				_SampleHeightHelper.SampleHeight(base.transform.position, out var height);
				Vector3 position = _Target.position;
				position.y = Mathf.Max(position.y, height + _MinimumHeightAboveWater);
				base.transform.position = Vector3.Lerp(base.transform.position, position, _LerpAlpha * water.DeltaTime * 60f);
				base.transform.LookAt(_LookAt.position + _LookAtOffset * Vector3.up);
			}
		}
	}
}
