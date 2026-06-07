using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using OneUseScripts;
using ScriptHelpers;
using StandaloneFileBrowser;
using TMPro;
using UIScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace SettingScripts
{
	public class ScenarioSaver : UIPanel
	{
		public const string DefaultSimulationSettingsPath = "Scenarios/";

		private readonly Regex containsABadCharacter = new Regex("[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");

		[SerializeField]
		private TMP_InputField scenarioName;

		[SerializeField]
		private TMP_InputField scenarioDesc;

		[SerializeField]
		private Button saveButton;

		[SerializeField]
		private GameObject existingBasicScenarioIndicator;

		[SerializeField]
		private GameObject existingScenarioIndicator;

		[SerializeField]
		private RawImage previewImage;

		private Texture2D previewTex;

		[SerializeField]
		private Texture2D noPreviewTex;

		[SerializeField]
		private GameObject noPreviewText;

		private string defaultPath;

		[SerializeField]
		public UnityEvent<string> OnSubmit = new UnityEvent<string>();

		[SerializeField]
		public UnityEvent OnCancel = new UnityEvent();

		private bool openFromCall;

		public override void InitPanel()
		{
			if (!openFromCall)
			{
				base.gameObject.SetActive(value: false);
			}
			defaultPath = Path.Combine(Application.persistentDataPath, "Scenarios/");
			if (!Directory.Exists(defaultPath))
			{
				Directory.CreateDirectory(defaultPath);
			}
		}

		public void OpenWithImage(Texture2D tex)
		{
			previewTex = tex;
			previewImage.texture = tex;
			noPreviewText.SetActive(value: false);
			OpenPanel();
		}

		public override void OpenPanel()
		{
			openFromCall = true;
			base.OpenPanel();
			if (previewTex == null)
			{
				previewImage.texture = noPreviewTex;
				noPreviewText.SetActive(value: true);
			}
			UserControl.SetKeyboardBlockFromSource("ScenarioSaver", block: true);
			scenarioName.text = ScenarioSelectorPanel.scenarioTitle;
			scenarioDesc.text = ScenarioSelectorPanel.scenarioDescription;
			AssertForm();
		}

		public void RefreshToScreenshot()
		{
			if (File.Exists(ScreenShotHandler.tempScreenshotPath))
			{
				byte[] data = File.ReadAllBytes(ScreenShotHandler.tempScreenshotPath);
				previewImage.texture = null;
				previewTex = new Texture2D(2, 2, TextureFormat.RGB24, mipChain: false);
				previewTex.LoadImage(data);
				previewImage.texture = previewTex;
				noPreviewText.SetActive(value: false);
			}
		}

		public void SelectImageFromDisk()
		{
			global::StandaloneFileBrowser.StandaloneFileBrowser.OpenFilePanelAsync("Select new preview Image (1MB max)", Application.persistentDataPath, "png", multiselect: false, SetNewPreview);
		}

		public void SetNewPreview(string[] path)
		{
			if (path == null || path.Length < 1)
			{
				return;
			}
			string text = path[0];
			if (!string.IsNullOrEmpty(text))
			{
				FileInfo fileInfo = new FileInfo(text);
				if (fileInfo.Extension != ".png")
				{
					PopupManager.DisplayError("Image Upload", "Only .png files are supported.");
				}
				else if ((double)fileInfo.Length > 1000000.0)
				{
					PopupManager.DisplayError("Image Upload", "The maximum preview image size is 1MB.");
				}
				else if (File.Exists(text))
				{
					byte[] data = File.ReadAllBytes(text);
					previewImage.texture = null;
					previewTex = new Texture2D(2, 2, TextureFormat.RGB24, mipChain: false);
					previewTex.LoadImage(data);
					previewImage.texture = previewTex;
					noPreviewText.SetActive(value: false);
				}
			}
		}

		public void SavedButtonClicked()
		{
			string saveFileName = Path.Combine(defaultPath, scenarioName.text + ".zip");
			if (File.Exists(saveFileName))
			{
				PopupManager.DisplayChoiceDialog("Warning", "A scenario with this name already exists.\n\rContinuing will overwrite the previous scenario with this one.\n\rAre you sure?", "Cancel", "YES", null, delegate
				{
					SaveScenario(saveFileName);
				}, setBlockingScreen: true);
			}
			else
			{
				SaveScenario(saveFileName);
			}
		}

		private void SaveScenario(string path)
		{
			JObject obj = SerializationHelper.SerializeScenario(saveRecommendations: true);
			JObject jObject = new JObject();
			jObject["name"] = scenarioName.text;
			jObject["desc"] = (string.IsNullOrEmpty(scenarioDesc.text) ? "No description was given for this scenario." : scenarioDesc.text);
			jObject["version"] = Version.Present.ToString();
			if (ScenarioSettings.Instance.isChallenge)
			{
				jObject["isChallenge"] = true;
				jObject["star1"] = ScenarioSettings.Instance.challengeParameters.star1Desc;
				jObject["star2"] = ScenarioSettings.Instance.challengeParameters.star2Desc;
				jObject["star3"] = ScenarioSettings.Instance.challengeParameters.star3Desc;
			}
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			using (ZipArchive zip = ZipFile.Open(path, ZipArchiveMode.Create))
			{
				SaveSystem.WriteJObjectToArchive(zip, "settings.bb8settings", obj);
				SaveSystem.WriteJObjectToArchive(zip, "scenario.info", jObject);
				if (previewTex != null)
				{
					byte[] file = previewTex.EncodeToPNG();
					SaveSystem.WriteFileToArchive(zip, "img.png", file);
				}
				SaveSystem.AddTemplatesToArchive(zip);
			}
			base.gameObject.SetActive(value: false);
			UserControl.SetKeyboardBlockFromSource("ScenarioSaver", block: false);
			OnSubmit.Invoke(scenarioName.text);
		}

		public void Cancel()
		{
			UserControl.SetKeyboardBlockFromSource("ScenarioSaver", block: false);
			ClosePanel();
			OnCancel.Invoke();
		}

		public override void Escape()
		{
			Cancel();
		}

		public void AssertForm()
		{
			bool flag = !containsABadCharacter.IsMatch(scenarioName.text) && !string.IsNullOrEmpty(scenarioName.text);
			bool flag2 = !GameManager.defaultScenarios.Contains(scenarioName.text.ToLower());
			if (flag2)
			{
				string item = ChallengesProgress.NameToKey(scenarioName.text);
				flag2 &= !GameManager.defaultScenarioKeys.Contains(item);
			}
			existingBasicScenarioIndicator.SetActive(!flag2);
			existingScenarioIndicator.SetActive(flag2 && File.Exists(Path.Combine(defaultPath, scenarioName.text + ".zip")));
			saveButton.interactable = flag && flag2;
		}
	}
}
