namespace UI.Xml.Examples
{
	public class MVVMExampleOptionsMenuViewModel : XmlLayoutViewModel
	{
		public ObservableList<string> resolutionOptions { get; set; }

		public string resolution { get; set; }

		public ObservableList<string> qualityOptions { get; set; }

		public string quality { get; set; }

		public float masterVolume { get; set; }

		public float musicVolume { get; set; }

		public float sfxVolume { get; set; }

		public bool enableHints { get; set; }
	}
}
