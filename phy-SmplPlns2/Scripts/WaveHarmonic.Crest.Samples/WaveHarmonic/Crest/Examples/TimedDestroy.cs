using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("")]
	internal sealed class TimedDestroy : CustomBehaviour
	{
		[SerializeField]
		private float _LifeTime = 2f;

		[SerializeField]
		private float _ScaleToZeroDuration;

		private Vector3 _Scale;

		private float _BirthTime;

		private protected override void OnStart()
		{
			base.OnStart();
			_BirthTime = Time.time;
			_Scale = base.transform.localScale;
		}

		private void Update()
		{
			float num = Time.time - _BirthTime;
			if (num >= _LifeTime)
			{
				Helpers.Destroy(base.gameObject);
			}
			else if (num > _LifeTime - _ScaleToZeroDuration)
			{
				base.transform.localScale = _Scale * (1f - (num - (_LifeTime - _ScaleToZeroDuration)) / _ScaleToZeroDuration);
			}
			else
			{
				base.transform.localScale = _Scale;
			}
		}
	}
}
