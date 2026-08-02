using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Michsky.UI.Heat
{
	public class SelectorInputHandler : MonoBehaviour
	{
		[Header("Resources")]
		[SerializeField]
		private HorizontalSelector selectorObject;

		[SerializeField]
		private GameObject indicator;

		[Header("Settings")]
		public float selectorCooldown = 0.4f;

		[SerializeField]
		private bool optimizeUpdates = true;

		public bool requireSelecting = true;

		private bool isInCooldown;

		private void OnEnable()
		{
			if (ControllerManager.instance == null || selectorObject == null)
			{
				Object.Destroy(this);
			}
			if (indicator == null)
			{
				indicator = new GameObject();
				indicator.name = "[Generated Indicator]";
				indicator.transform.SetParent(base.transform);
			}
			indicator.SetActive(value: false);
		}

		private void Update()
		{
			if (Gamepad.current == null || ControllerManager.instance == null)
			{
				indicator.SetActive(value: false);
			}
			else if (requireSelecting && EventSystem.current.currentSelectedGameObject != base.gameObject)
			{
				indicator.SetActive(value: false);
			}
			else if (optimizeUpdates && ControllerManager.instance != null && !ControllerManager.instance.gamepadEnabled)
			{
				indicator.SetActive(value: false);
			}
			else if (!isInCooldown)
			{
				indicator.SetActive(value: true);
				if ((double)ControllerManager.instance.hAxis >= 0.75)
				{
					selectorObject.NextItem();
					isInCooldown = true;
					StopCoroutine("CooldownTimer");
					StartCoroutine("CooldownTimer");
				}
				else if ((double)ControllerManager.instance.hAxis <= -0.75)
				{
					selectorObject.PreviousItem();
					isInCooldown = true;
					StopCoroutine("CooldownTimer");
					StartCoroutine("CooldownTimer");
				}
			}
		}

		private IEnumerator CooldownTimer()
		{
			yield return new WaitForSecondsRealtime(selectorCooldown);
			isInCooldown = false;
		}
	}
}
