using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuControllerScript : MonoBehaviour
{
	private MenuMusicScript Music;

	public GameObject MusicPrefab;

	public AudioMixer Mixer;

	public GameObject PersistPrefab;

	public FadeInCanvasGroup Fade;

	private string SettingsPath;

	private PersistScript Persist;

	public CanvasGroup SettingsCanvas;

	public TextMeshProUGUI VsyncButton;

	public TextMeshProUGUI FullscreenButton;

	public TextMeshProUGUI ResolutionText;

	public Slider SensitivitySlider;

	public TextMeshProUGUI SensitivityText;

	public Slider VolumeSlider;

	public TextMeshProUGUI VolumeText;

	public TextMeshProUGUI InvertButton;

	public Slider FovSlider;

	public TextMeshProUGUI FovText;

	private Dictionary<int, Resolution> Resolutions;

	private Dictionary<string, int> ResolutionLookup;

	private int CurrentResolution;

	private int MaxResolutions;

	public AudioSource SettingsSound;

	public AudioSource ClickSound;

	public GameObject SteamObject;

	public GameObject BaseMenuDefaultSelection;

	public GameObject SettingsMenuDefaultSelection;

	private void Awake()
	{
		SettingsPath = Application.dataPath + "/../settings.ini";
		Resolutions = new Dictionary<int, Resolution>();
		ResolutionLookup = new Dictionary<string, int>();
		GetResolutions();
	}

	private void Start()
	{
		if (!GameObject.Find("PERSIST"))
		{
			Object.Instantiate(PersistPrefab).name = "PERSIST";
		}
		if (!GameObject.Find("SteamObject"))
		{
			Object.Instantiate(SteamObject).name = "SteamObject";
		}
		Persist = GameObject.Find("PERSIST").GetComponent<PersistScript>();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Mixer.SetFloat("EnvironmentVolume", 2f);
		Mixer.SetFloat("MusicVolume", -11f);
		GameObject gameObject = GameObject.Find("Music");
		if ((bool)gameObject)
		{
			Music = gameObject.GetComponent<MenuMusicScript>();
		}
		else
		{
			Music = Object.Instantiate(MusicPrefab).GetComponent<MenuMusicScript>();
		}
		LoadSettings();
		Persist.ApplySettings();
		Music.PlayMusic();
	}

	private void Update()
	{
	}

	public void LoadSettings()
	{
		if (!File.Exists(SettingsPath))
		{
			MonoBehaviour.print("WARNING: Settings file not found");
			return;
		}
		INIParser iNIParser = new INIParser();
		iNIParser.Open(SettingsPath);
		Persist.vsync = IntToBool(iNIParser.ReadValue("Game", "vsync", 0));
		Persist.invert = IntToBool(iNIParser.ReadValue("Game", "mouse_invert", 0));
		Persist.vol = (float)iNIParser.ReadValue("Game", "volume", 1.0);
		Persist.resx = iNIParser.ReadValue("Game", "resolution_x", 640);
		Persist.resy = iNIParser.ReadValue("Game", "resolution_y", 480);
		Persist.sensitivity = (float)iNIParser.ReadValue("Game", "sensitivity", 1.0);
		Persist.fov = iNIParser.ReadValue("Game", "fov", 65);
		Persist.fullscreen = iNIParser.ReadValue("Game", "fullscreen", 0);
		Persist.cap = iNIParser.ReadValue("Game", "cap", 144);
		Persist.ApplySettings();
		iNIParser.Close();
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void StartGame()
	{
		Music.FadeOut();
		Application.LoadLevel("IntroScene");
	}

	public void LoadGame()
	{
		if (File.Exists(Application.dataPath + "/../save/progress"))
		{
			Music.FadeOut();
			PersistScript component = GameObject.Find("PERSIST").GetComponent<PersistScript>();
			component.LoadName = "progress";
			component.DoLoad = true;
			Fade.ResetThis();
			Application.LoadLevel("MainScene");
		}
	}

	public void LoadTwitter()
	{
		Application.OpenURL("https://linktr.ee/duskdev");
	}

	public void LoadSteam()
	{
		Application.OpenURL("https://store.steampowered.com/developer/davidszymanski");
	}

	public void PressSettings()
	{
		if (SettingsCanvas.alpha == 0f)
		{
			LoadSettings();
			VsyncButton.text = BoolToText(Persist.vsync);
			FullscreenButton.text = IntToText(Persist.fullscreen);
			InvertButton.text = BoolToText(Persist.invert);
			SensitivitySlider.value = Persist.sensitivity;
			SensitivityText.text = Persist.sensitivity.ToString("00.00");
			FovSlider.value = Persist.fov;
			FovText.text = Persist.fov.ToString("000");
			VolumeSlider.value = Persist.vol;
			VolumeText.text = Persist.vol.ToString("0.00");
			CurrentResolution = ResolutionLookup[Persist.resx + "x" + Persist.resy];
			SetResText();
			SettingsCanvas.alpha = 1f;
			SettingsCanvas.blocksRaycasts = true;
			SettingsCanvas.interactable = true;
			SettingsSound.Play();
			EventSystem.current.SetSelectedGameObject(SettingsMenuDefaultSelection);
		}
	}

	public void ApplySettings()
	{
		INIParser iNIParser = new INIParser();
		iNIParser.Open(SettingsPath);
		iNIParser.WriteValue("Game", "vsync", TextToBool(VsyncButton.text));
		iNIParser.WriteValue("Game", "mouse_invert", TextToBool(InvertButton.text));
		if (FullscreenButton.text == "on")
		{
			iNIParser.WriteValue("Game", "fullscreen", 2);
		}
		else
		{
			iNIParser.WriteValue("Game", "fullscreen", 0);
		}
		iNIParser.WriteValue("Game", "volume", VolumeSlider.value);
		iNIParser.WriteValue("Game", "sensitivity", SensitivitySlider.value);
		iNIParser.WriteValue("Game", "fov", FovSlider.value);
		int width = Resolutions[CurrentResolution].width;
		int height = Resolutions[CurrentResolution].height;
		iNIParser.WriteValue("Game", "resolution_x", width);
		iNIParser.WriteValue("Game", "resolution_y", height);
		iNIParser.Close();
		LoadSettings();
		SettingsCanvas.alpha = 0f;
		SettingsCanvas.blocksRaycasts = false;
		SettingsCanvas.interactable = false;
		SettingsSound.Play();
		EventSystem.current.SetSelectedGameObject(BaseMenuDefaultSelection);
	}

	public void CancelSettings()
	{
		SettingsCanvas.alpha = 0f;
		SettingsCanvas.blocksRaycasts = false;
		SettingsCanvas.interactable = false;
		SettingsSound.Play();
		EventSystem.current.SetSelectedGameObject(BaseMenuDefaultSelection);
	}

	public void FovChange()
	{
		FovText.text = FovSlider.value.ToString("000");
	}

	public void VolumeChange()
	{
		VolumeText.text = VolumeSlider.value.ToString("0.00");
	}

	public void SensitivityChange()
	{
		SensitivityText.text = SensitivitySlider.value.ToString("00.00");
	}

	public void VsyncChange()
	{
		if (VsyncButton.text == "on")
		{
			VsyncButton.text = "off";
		}
		else
		{
			VsyncButton.text = "on";
		}
		ClickSound.Play();
	}

	public void FullscreenChange()
	{
		if (FullscreenButton.text == "on")
		{
			FullscreenButton.text = "off";
		}
		else
		{
			FullscreenButton.text = "on";
		}
		ClickSound.Play();
	}

	public void InvertChange()
	{
		if (InvertButton.text == "on")
		{
			InvertButton.text = "off";
		}
		else
		{
			InvertButton.text = "on";
		}
		ClickSound.Play();
	}

	private void SetResText()
	{
		Resolution resolution = Resolutions[CurrentResolution];
		ResolutionText.text = resolution.width + "x" + resolution.height;
	}

	public void ResUp()
	{
		CurrentResolution++;
		if (CurrentResolution > MaxResolutions)
		{
			CurrentResolution = 0;
		}
		SetResText();
		ClickSound.Play();
	}

	public void ResDown()
	{
		CurrentResolution--;
		if (CurrentResolution < 0)
		{
			CurrentResolution = MaxResolutions;
		}
		SetResText();
		ClickSound.Play();
	}

	public void GetResolutions()
	{
		Resolution[] resolutions = Screen.resolutions;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			if (resolutions[i].width > num2 || resolutions[i].height > num3)
			{
				num2 = resolutions[i].width;
				num3 = resolutions[i].height;
				Resolutions.Add(num, resolutions[i]);
				ResolutionLookup.Add(resolutions[i].width + "x" + resolutions[i].height, num);
				MaxResolutions = num;
				num++;
			}
		}
	}

	public string BoolToText(bool b)
	{
		if (!b)
		{
			return "off";
		}
		return "on";
	}

	public bool TextToBool(string s)
	{
		if (s == "off")
		{
			return false;
		}
		return true;
	}

	public string IntToText(int i)
	{
		if (i == 0)
		{
			return "off";
		}
		return "on";
	}

	public int TextToInt(string s)
	{
		if (s == "off")
		{
			return 0;
		}
		return 1;
	}

	public bool IntToBool(int i)
	{
		if (i == 0)
		{
			return false;
		}
		return true;
	}

	public int BoolToInt(bool b)
	{
		if (!b)
		{
			return 0;
		}
		return 1;
	}
}
