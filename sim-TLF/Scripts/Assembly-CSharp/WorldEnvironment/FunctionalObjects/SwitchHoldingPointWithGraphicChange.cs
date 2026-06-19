using System;
using UnityEngine;

namespace WorldEnvironment.FunctionalObjects
{
	public class SwitchHoldingPointWithGraphicChange : SwitchHoldingPoint
	{
		[SerializeField]
		private GameObject _pressedGameObject;

		[SerializeField]
		private GameObject _releasedGameObject;

		private void OnEnable()
		{
			StateChanged = (Action<bool>)Delegate.Combine(StateChanged, new Action<bool>(ChangeGraphics));
		}

		private void OnDisable()
		{
			StateChanged = (Action<bool>)Delegate.Remove(StateChanged, new Action<bool>(ChangeGraphics));
		}

		private void ChangeGraphics(bool holding)
		{
			_pressedGameObject.SetActive(holding);
			_releasedGameObject.SetActive(!holding);
		}
	}
}
