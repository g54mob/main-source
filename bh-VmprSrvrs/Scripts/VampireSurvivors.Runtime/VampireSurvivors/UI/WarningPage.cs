using UnityEngine;
using Zenject;

namespace VampireSurvivors.UI
{
	public class WarningPage : BaseUIPage
	{
		public static bool Corrupt;

		[SerializeField]
		private float WaitDuration;

		[SerializeField]
		private CanvasGroup Content;

		[SerializeField]
		private float FadeDuration;

		[SerializeField]
		private bool _DebugCorruptPage;

		private bool _isWaiting;

		private float _currentTime;

		private SignalBus _signalBus;

		[Inject]
		private void Construct(SignalBus signalBus)
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		protected override void Update()
		{
		}

		private void Complete()
		{
		}
	}
}
