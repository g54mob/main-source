using TMPro;
using UnityEngine;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class OnlineErrorPage : BaseUIPage
	{
		[SerializeField]
		private TextMeshProUGUI _errorTitle;

		[SerializeField]
		private TextMeshProUGUI _errorText;

		[SerializeField]
		private GameObject _okBtn;

		private SignalBus _signalBus;

		[Inject]
		public void Construct(SignalBus signalBus)
		{
		}

		public void GoBack()
		{
		}

		private void OnShowError(UISignals.ShowOnlineErrorScreenSignal sig)
		{
		}

		private void OnDestroy()
		{
		}

		protected override void Update()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}
	}
}
