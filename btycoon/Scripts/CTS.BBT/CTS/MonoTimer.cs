using System.Collections;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class MonoTimer : MonoRoutine, IPoolable
	{
		[SerializeField]
		private float _duration;

		[SerializeField]
		private bool _useUnscaledTime;

		[SerializeField]
		private bool _destroyOnEnd;

		[SerializeField]
		private bool _disableOnEnd;

		[SerializeField]
		private UnityEvent _onPlay;

		PoolGuid IPoolable.PoolGuid { get; set; }

		protected override IEnumerator Routine()
		{
			_onPlay?.Invoke();
			if (_useUnscaledTime)
			{
				yield return Coroutines.WaitForSecondsRealtime(_duration);
			}
			else
			{
				yield return Coroutines.WaitForSeconds(_duration);
			}
			if (_destroyOnEnd)
			{
				Object.Destroy(base.gameObject);
			}
			else if (_disableOnEnd)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
