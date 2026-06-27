using System;
using System.Collections;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Popups
{
	public class GUI_HackingDelayPopup : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float appearanceDelayInSeconds = 0.5f;

		private HackingDelayEvent delayEvent;

		private Coroutine hackingDelayCoroutine;

		private bool isAppearanced;

		private bool isFailed;

		public bool IsFailed => isFailed;

		public float Bonus => delayEvent.Bonus;

		public float Penalty => delayEvent.Penalty;

		public event Action<GUI_HackingDelayPopup> OnDelayComplete;

		private void OnDisable()
		{
			isAppearanced = false;
			isFailed = false;
		}

		public void Activate(HackingDelayEvent delayEvent)
		{
			base.gameObject.SetActive(value: true);
			this.delayEvent = delayEvent;
			if (hackingDelayCoroutine != null)
			{
				StopCoroutine(hackingDelayCoroutine);
			}
			hackingDelayCoroutine = StartCoroutine(HackingDelayCoroutine());
		}

		public bool HackingShouldBeRegressedDueUnwarilyTyping()
		{
			if (!isAppearanced || isFailed)
			{
				return false;
			}
			isFailed = true;
			return true;
		}

		private IEnumerator HackingDelayCoroutine()
		{
			yield return new WaitForSeconds(appearanceDelayInSeconds);
			isAppearanced = true;
			yield return new WaitForSeconds(delayEvent.Delay);
			hackingDelayCoroutine = null;
			this.OnDelayComplete?.Invoke(this);
			base.gameObject.SetActive(value: false);
		}
	}
}
