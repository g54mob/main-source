using System.Collections;
using TMPro;
using UnityEngine;

namespace MateoRyhr
{
	public class FPSMeter : MonoBehaviour
	{
		[SerializeField]
		private GameObject _objectToActiveDesactive;

		[SerializeField]
		private TextMeshProUGUI _fpsText;

		private bool enable;

		public void Enable()
		{
			_objectToActiveDesactive.SetActive(value: true);
			enable = true;
			_fpsText.gameObject.SetActive(value: true);
			StartCoroutine(UpdateFrameMeter());
		}

		public void Disable()
		{
			_objectToActiveDesactive.SetActive(value: false);
			enable = false;
			_fpsText.gameObject.SetActive(value: false);
			StopCoroutine(UpdateFrameMeter());
		}

		public void SwitchStatus()
		{
			if (enable)
			{
				Disable();
			}
			else
			{
				Enable();
			}
		}

		private IEnumerator UpdateFrameMeter()
		{
			yield return new WaitForSecondsRealtime(1f);
			_fpsText.text = ((int)(1f / Time.deltaTime)).ToString();
			if (enable)
			{
				StartCoroutine(UpdateFrameMeter());
			}
		}
	}
}
