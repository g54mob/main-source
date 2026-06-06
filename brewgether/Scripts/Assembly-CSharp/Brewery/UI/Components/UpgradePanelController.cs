using System;
using UnityEngine.UIElements;

namespace Brewery.UI.Components
{
	public sealed class UpgradePanelController
	{
		private Label tier1StatusLabel;

		private VisualElement tier1Indicator;

		private Button tier1InstallButton;

		private string tier1InstallDefaultText;

		private Label tier2StatusLabel;

		private VisualElement tier2Indicator;

		private Button tier2InstallButton;

		private string tier2InstallDefaultText;

		public void Initialize(VisualElement root, string tier1StatusLabelId, string tier1IndicatorId, string tier1ButtonId, string tier2StatusLabelId, string tier2IndicatorId, string tier2ButtonId)
		{
		}

		public void BindTier1Install(Action onInstall)
		{
		}

		public void BindTier2Install(Action onInstall)
		{
		}

		public void Update(bool tier1Active, bool tier2Active)
		{
		}
	}
}
