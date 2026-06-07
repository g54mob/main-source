using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Examples
{
	public class MVVMExampleOptionsMenuController : XmlLayoutController<MVVMExampleOptionsMenuViewModel>
	{
		public XmlLayout_Example_MessageDialog MessageDialog;

		private XmlElementReference<Button> applyButton;

		private void Awake()
		{
			applyButton = XmlElementReference<Button>("applyButton");
		}

		protected override void PrepopulateViewModelData()
		{
			base.viewModel = new MVVMExampleOptionsMenuViewModel
			{
				resolutionOptions = new ObservableList<string> { "960x600", "1024x768", "1920x1080" },
				resolution = "1920x1080",
				qualityOptions = QualitySettings.names.ToObservableList(),
				quality = QualitySettings.names[QualitySettings.GetQualityLevel()],
				masterVolume = 0.8f,
				musicVolume = 0.45f,
				sfxVolume = 0.55f,
				enableHints = true
			};
		}

		private void FormChanged()
		{
			applyButton.element.interactable = true;
		}

		private void ResetForm()
		{
			PrepopulateViewModelData();
			applyButton.element.interactable = false;
		}

		private void Apply()
		{
			MessageDialog.Show("Updated ViewModel Values", $"\r\nResolution    : {base.viewModel.resolution}\r\nQuality       : {base.viewModel.quality}\r\nMaster Volume : {base.viewModel.masterVolume}\r\nMusic Volume  : {base.viewModel.musicVolume}\r\nSfx Volume    : {base.viewModel.sfxVolume}\r\nEnable Hints  : {base.viewModel.enableHints}\r\n");
			applyButton.element.interactable = false;
		}
	}
}
