using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.SimpleTweeners
{
	public class ToggleTweenerActivator : MonoBehaviour
	{
		[SerializeField]
		private ElementSocket targetSocket;

		private void OnEnable()
		{
			targetSocket.GetComponentInChildren<ToggleTweenerBase>()?.TurnOn();
		}

		private void OnDisable()
		{
			targetSocket.GetComponentInChildren<ToggleTweenerBase>()?.TurnOff();
		}
	}
}
