using UnityEngine;
using Zenject;

namespace VampireSurvivors.App.Scripts.UI
{
	public class AccountButtonController : MonoBehaviour
	{
		public static bool CanShow;

		private SignalBus _signalBus;

		[Inject]
		private void Construct(SignalBus signal)
		{
		}

		public void OnClick()
		{
		}
	}
}
