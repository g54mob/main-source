using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class StatusBar3DUIView : ShowHideAnimation3DUIView
	{
		public Button3DUIView worldMapButton;

		public Button3DUIView staffOverviewButton;

		public Button3DUIView larderOverviewButton;

		public Button3DUIView tavernMenuButton;

		public Button3DUIView tavernOverviewFinanceButton;

		public Button3DUIView houseRulesButton;

		public AtmosphereMenu3DUIView atmosphereMenu;

		[SerializeField]
		public TextMeshProI18n _tavernNameField;

		[field: SerializeField]
		public Date3DUIView Date { get; private set; }

		private void Start()
		{
		}

		protected override void OnEnable()
		{
		}

		public void SetTavernName(string name)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
