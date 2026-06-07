using UnityEngine;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class GameUIHider : MonoBehaviour
	{
		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		[Inject]
		private void Construct(SignalBus signal, PlayerOptions playerOptions)
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void HandleHideGameUISignal(UISignals.ToggleHideGameUISignal signal)
		{
		}
	}
}
