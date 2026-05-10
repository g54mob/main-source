using System.Collections;
using UnityEngine;

namespace CTS
{
	public class ExteriorFurnitureDestroyer : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve _curve;

		[SerializeField]
		private float _time = 0.5f;

		private float _currentTimer;

		private Coroutine _depop;

		private void Awake()
		{
			ConstructionSystem.OnConstructionGenerated += ConstructionSystem_OnConstructionGenerated;
		}

		private void OnDestroy()
		{
			ConstructionSystem.OnConstructionGenerated -= ConstructionSystem_OnConstructionGenerated;
		}

		private void ConstructionSystem_OnConstructionGenerated(int arg1, int arg2, int arg3)
		{
			if (arg2 != 0 && _depop == null)
			{
				_depop = StartCoroutine(DepopRoutine());
			}
		}

		private IEnumerator DepopRoutine()
		{
			_currentTimer = 0f;
			while (_currentTimer < _time)
			{
				base.transform.localScale = Vector3.one * _curve.Evaluate(Mathf.InverseLerp(0f, _time, _currentTimer));
				_currentTimer += Time.unscaledDeltaTime;
				yield return null;
			}
			base.transform.localScale = Vector3.one * _curve.Evaluate(Mathf.Lerp(0f, _time, _time));
			_depop = null;
			Object.Destroy(base.gameObject);
		}
	}
}
