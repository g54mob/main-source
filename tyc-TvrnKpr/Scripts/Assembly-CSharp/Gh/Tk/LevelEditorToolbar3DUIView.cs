using Gh.Tk.UI;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class LevelEditorToolbar3DUIView : ShowHideAnimation3DUIView
	{
		private LevelEditor _le;

		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private Button3DUIView _generalButton;

		[SerializeField]
		private Button3DUIView _zoneButton;

		[SerializeField]
		private Button3DUIView _atmosphereButton;

		[SerializeField]
		private GameObject _generalPage;

		[SerializeField]
		private GameObject _zonePage;

		[SerializeField]
		private GameObject _atmospherePage;

		[SerializeField]
		private Button3DUIView _insideButton;

		[SerializeField]
		private Button3DUIView _outsideButton;

		[SerializeField]
		private Button3DUIView _clearButton;

		[SerializeField]
		private CheckBox3DUIView _includeRng;

		[SerializeField]
		private CheckBox3DUIView _includeTavern;

		[SerializeField]
		private CheckBox3DUIView _includeTavernMenu;

		[SerializeField]
		private CheckBox3DUIView _includeTime;

		[SerializeField]
		private CheckBox3DUIView _includePatrons;

		[SerializeField]
		private CheckBox3DUIView _includeSpecialUseActors;

		[SerializeField]
		private CheckBox3DUIView _includeAlerts;

		[SerializeField]
		private CheckBox3DUIView _includeEvents;

		[SerializeField]
		private CheckBox3DUIView _includeStory;

		[SerializeField]
		private CheckBox3DUIView _includeGazette;

		[SerializeField]
		private CheckBox3DUIView _includeResearch;

		[SerializeField]
		private CheckBox3DUIView _includeStaff;

		[SerializeField]
		private CheckBox3DUIView _includeNotHiredStaff;

		[SerializeField]
		private CheckBox3DUIView _includeEntertainmentController;

		[SerializeField]
		private CheckBox3DUIView _includeMerchant;

		[SerializeField]
		private CheckBox3DUIView _setBuildCostsToZero;

		[SerializeField]
		private CheckBox3DUIView _showOutsideWalls;

		[SerializeField]
		private Slider3DUIView _atmosphereValueSlider;

		[SerializeField]
		private TextMeshPro _atmosphereValueText;

		private void Start()
		{
		}

		private void UpdateAtmosphereValues()
		{
		}

		private void Refresh()
		{
		}

		private void RefreshSettings()
		{
		}
	}
}
