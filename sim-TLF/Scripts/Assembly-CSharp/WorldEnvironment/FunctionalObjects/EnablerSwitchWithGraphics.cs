using UnityEngine;

namespace WorldEnvironment.FunctionalObjects
{
	public class EnablerSwitchWithGraphics : EnablerSwitch
	{
		[SerializeField]
		private GameObject _enabledGameObject;

		[SerializeField]
		private GameObject _disabledGameObject;

		private void OnEnable()
		{
			base.StateChanged += ChangeGraphics;
		}

		private void OnDisable()
		{
			base.StateChanged -= ChangeGraphics;
		}

		private void ChangeGraphics(bool enabledState)
		{
			if (enabledState)
			{
				_enabledGameObject.SetActive(value: true);
				_disabledGameObject.SetActive(value: false);
			}
			else
			{
				_enabledGameObject.SetActive(value: false);
				_disabledGameObject.SetActive(value: true);
			}
		}
	}
}
