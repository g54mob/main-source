using UnityEngine;
using Zenject;

namespace VampireSurvivors.UI
{
	public class LandingScreenPage : MonoBehaviour
	{
		public string AudioClip;

		private SignalBus _signalBus;

		[Inject]
		private void Construct(SignalBus signal)
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void MoveToNextView()
		{
		}
	}
}
