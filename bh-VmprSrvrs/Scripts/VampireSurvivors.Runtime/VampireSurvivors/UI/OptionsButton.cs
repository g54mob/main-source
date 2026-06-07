using UnityEngine;
using Zenject;

namespace VampireSurvivors.UI
{
	public class OptionsButton : MonoBehaviour
	{
		private SignalBus signalBus;

		[Inject]
		private void Construct(SignalBus _signal)
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Hide()
		{
		}

		private void Show()
		{
		}
	}
}
