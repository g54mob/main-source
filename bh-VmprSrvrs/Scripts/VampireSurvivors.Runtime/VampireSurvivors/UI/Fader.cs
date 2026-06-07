using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class Fader : MonoBehaviour
	{
		private Image _image;

		private SignalBus _signalBus;

		[Inject]
		private void Construct(SignalBus signal)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Awake()
		{
		}

		private void Fade(UISignals.FadeScreenSignal sig)
		{
		}
	}
}
