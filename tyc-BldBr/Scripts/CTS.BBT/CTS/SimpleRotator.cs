using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class SimpleRotator : MonoBehaviour
	{
		[SerializeField]
		private Transform _target;

		[SerializeField]
		private float _duration = 1f;

		private float _startRotation;

		private Coroutine _routine;

		private Button _button;

		private void Awake()
		{
			_startRotation = _target.eulerAngles.y;
			_button = GetComponent<Button>();
			if ((bool)_button)
			{
				_button.onClick.AddListener(Rotate);
			}
		}

		private void OnDestroy()
		{
			if ((bool)_button)
			{
				_button.onClick.RemoveListener(Rotate);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void Rotate()
		{
			if (_routine != null)
			{
				StopCoroutine(_routine);
			}
			_routine = StartCoroutine(Rotation());
		}

		private IEnumerator Rotation()
		{
			for (float time = 0f; time < 1f; time += Time.deltaTime / _duration)
			{
				float y = Mathf.Lerp(_startRotation, _startRotation + 360f, time);
				Vector3 eulerAngles = _target.eulerAngles;
				eulerAngles.y = y;
				_target.eulerAngles = eulerAngles;
				yield return null;
			}
			_routine = null;
		}
	}
}
