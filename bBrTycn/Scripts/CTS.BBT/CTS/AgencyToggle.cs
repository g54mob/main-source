using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class AgencyToggle : CTSBehaviour
	{
		[SerializeField]
		private bool _goToAgency;

		[SerializeField]
		[Inject(false)]
		private Toggle _toggle;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnValueChanged);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.onValueChanged.RemoveListener(OnValueChanged);
		}

		private void OnValueChanged(bool isOn)
		{
			if (isOn)
			{
				if (_goToAgency)
				{
					GoToAgency();
				}
				else
				{
					QuitAgency();
				}
			}
		}

		public void GoToAgency()
		{
			MonoSingleton<InterimAgency>.Instance.GoToAgency();
		}

		public void QuitAgency()
		{
			MonoSingleton<InterimAgency>.Instance.QuitAgency();
		}
	}
}
