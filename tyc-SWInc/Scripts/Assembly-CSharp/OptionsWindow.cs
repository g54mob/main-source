using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Achievements;
using SINetworking;
using Steamworks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GameObject InputButtonPrefab;

	public GameObject[] Panels;

	public List<InputButton> InputButtons;

	public Slider aMusic;

	public Slider aSFX;

	public Slider aUI;

	public GameObject KeyPanel;

	public GameObject TutorialPanel;

	public GameObject TutorialButton;

	public GameObject AudioPanel;

	[NonSerialized]
	public bool Initialized;

	public Transform ModPanel;

	public Transform GameplayPanel;

	public Transform GraphicsPanel;

	public Transform AchievementPanel;

	public GameObject ModContentPrefab;

	public GameObject ModHeaderPrefab;

	public Toggle TogglePrefab;

	public InputField TextboxPrefab;

	public InputField KeySearch;

	public Slider SliderPrefab;

	public Text[] ImpactLabels;

	public Text LabelPrefab;

	public Button ButtonPrefab;

	public GUICombobox ComboPrefab;

	[NonSerialized]
	public Dictionary<string, MonoBehaviour> AllControls = new Dictionary<string, MonoBehaviour>();

	[NonSerialized]
	private List<ValueTuple<string, GameObject[]>> _keys = new List<ValueTuple<string, GameObject[]>>();

	public static OptionsWindow Instance;

	private Dictionary<Options.VariableInfo, object> _GFXSettings = new Dictionary<Options.VariableInfo, object>();

	[NonSerialized]
	public Dictionary<ModController.DLLMod, GameObject[]> ModOptions = new Dictionary<ModController.DLLMod, GameObject[]>();

	public bool InGame
	{
		get
		{
			return SceneManager.GetActiveScene().name.Equals("MainScene");
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		InitKeys();
		InitTutorials();
		InitMods();
		InitAudio();
		InitDynamic();
		Initialized = true;
	}

	public void KeySearchChange()
	{
		if (!string.IsNullOrWhiteSpace(KeySearch.text))
		{
			string query = GlobalSearchPanel.Normalize(KeySearch.text);
			{
				foreach (var key in _keys)
				{
					bool match = GlobalSearchPanel.GetSimilarityNormalized(query, key.Item1) > 0.5;
					key.Item2.ForEachEnum(delegate(GameObject x)
					{
						x.SetActive(match);
					});
				}
				return;
			}
		}
		_keys.ForEach(delegate(ValueTuple<string, GameObject[]> x)
		{
			x.Item2.ForEachEnum(delegate(GameObject z)
			{
				z.SetActive(true);
			});
		});
	}

	public void RefreshAchievements()
	{
		int num = 0;
		foreach (var achievement in AchievementController.GetAchievements())
		{
			InitAchievement(achievement.Item3, achievement.Item1, achievement.Item2, achievement.Item4, num);
			num++;
		}
	}

	private void InitAchievement(Texture2D icon, string name, string desc, bool achieved, int i)
	{
		GameObject gameObject;
		if (i < AchievementPanel.childCount)
		{
			gameObject = AchievementPanel.GetChild(i).gameObject;
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate(AchievementPanel.GetChild(0).gameObject);
			gameObject.transform.SetParent(AchievementPanel, false);
		}
		WindowManager.InitAchievementUI(gameObject, icon, name, desc, achieved);
	}

	public void ResetKeys()
	{
		InputController.Reset();
		InputButtons.ForEach(delegate(InputButton x)
		{
			x.UpdateText();
		});
		Options.SaveToFile();
	}

	public void RefreshGFXSettings()
	{
		Options.DisableSaving = true;
		foreach (KeyValuePair<Options.VariableInfo, object> pair in _GFXSettings)
		{
			Options.SettingAttribute setting = pair.Key.Setting;
			Options.ComboSettingAttribute comboSettingAttribute;
			if (setting is Options.ToggleSettingAttribute)
			{
				((Toggle)pair.Value).isOn = (bool)pair.Key.GetValue();
			}
			else if (setting is Options.SliderSettingAttribute)
			{
				((Slider)pair.Value).value = (float)Convert.ToDouble(pair.Key.GetValue());
			}
			else if ((comboSettingAttribute = setting as Options.ComboSettingAttribute) != null)
			{
				GUICombobox gUICombobox = pair.Value as GUICombobox;
				int num = Options.ComboContentFunctions[comboSettingAttribute.ComboContent]().ToList().FindIndex((KeyValuePair<string, object> x) => pair.Key.Comp(x.Value));
				if (num >= 0 && num < gUICombobox.Items.Count)
				{
					gUICombobox.Selected = num;
				}
			}
			else if (setting is Options.TextBoxSettingAttribute)
			{
				((InputField)pair.Value).text = pair.Key.GetValue().ToString();
			}
		}
		Options.DisableSaving = false;
	}

	private void InitDynamic()
	{
		bool inGame = InGame;
		Dictionary<string, GUICombobox> dictionary = new Dictionary<string, GUICombobox>();
		foreach (IGrouping<KeyValuePair<Options.SettingType, string>, KeyValuePair<string, Options.VariableInfo>> item in from x in Options.SettingFields
			where x.Value.Setting.Type != Options.SettingType.Ignore
			orderby x.Value.Setting.Order
			group x by new KeyValuePair<Options.SettingType, string>(x.Value.Setting.Type, x.Value.Setting.Group))
		{
			Text text = MakeLabel(item.Key.Value, null, item.Key.Key);
			text.fontSize = 18;
			text.color = new Color32(75, 172, 76, 170);
			text.fontStyle = FontStyle.Bold;
			RectTransform rectTransform = new GameObject("Null").AddComponent<RectTransform>();
			bool flag = false;
			AddToPanel(rectTransform, item.Key.Key, false);
			if (item.Key.Key == Options.SettingType.Graphics)
			{
				AddToPanel(new GameObject("Null").AddComponent<RectTransform>(), item.Key.Key, false);
			}
			foreach (KeyValuePair<string, Options.VariableInfo> item2 in item)
			{
				Options.VariableInfo field = item2.Value;
				if (!(field.Setting.Global || inGame) || (!field.Setting.InCampaign && !GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.CampaignMode) || (!field.Setting.Online && !GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.IsNetworkMode) || (field.Setting.OnlyHost && !NetworkManager.IsHost))
				{
					continue;
				}
				flag = true;
				string key = item2.Key;
				Options.SettingAttribute setting = field.Setting;
				if (!setting.HideLabel)
				{
					MakeLabel(setting.UIName, setting.Tooltip, setting.Type);
				}
				Options.ButtonSettingAttribute buttonSettingAttribute;
				Options.SliderSettingAttribute ss;
				Options.ComboSettingAttribute sc;
				Options.TextBoxSettingAttribute textBoxSettingAttribute;
				if ((buttonSettingAttribute = setting as Options.ButtonSettingAttribute) != null)
				{
					Button button = UnityEngine.Object.Instantiate(ButtonPrefab);
					button.GetComponentInChildren<Text>().text = buttonSettingAttribute.ButtonLabel.Loc();
					button.onClick.AddListener(delegate
					{
						if (field.Property.PropertyType == typeof(bool))
						{
							field.SetValue(true);
						}
						else
						{
							field.SetValue(null);
						}
					});
					AllControls[setting.Name] = button;
					AddToPanel(button.transform, setting.Type, setting.HideLabel);
				}
				else if (setting is Options.ToggleSettingAttribute)
				{
					Toggle t = UnityEngine.Object.Instantiate(TogglePrefab);
					if (setting.Type == Options.SettingType.Graphics)
					{
						_GFXSettings[field] = t;
					}
					t.isOn = (bool)field.GetValue();
					t.onValueChanged.AddListener(delegate
					{
						Options.SetAndSave(key, t.isOn);
					});
					AllControls[setting.Name] = t;
					AddToPanel(t.transform, setting.Type, setting.HideLabel);
				}
				else if ((ss = setting as Options.SliderSettingAttribute) != null)
				{
					Slider slider = UnityEngine.Object.Instantiate(SliderPrefab);
					if (setting.Type == Options.SettingType.Graphics)
					{
						_GFXSettings[field] = slider;
					}
					slider.minValue = ss.Min;
					slider.maxValue = ss.Max;
					slider.wholeNumbers = ss.WholeNumber;
					slider.value = (float)Convert.ToDouble(field.GetValue());
					Text label = slider.GetComponentInChildren<Text>();
					bool useLabel = !string.IsNullOrEmpty(ss.NumberFormat) || !string.IsNullOrEmpty(ss.PluralLoc);
					label.text = (useLabel ? FormatSliderValue(ss, slider.value.MapRange(ss.Min, ss.Max, ss.MapMin, ss.MapMax)) : "");
					if (ss.Optimal >= 0f)
					{
						slider.onValueChanged.AddListener(delegate(float x)
						{
							if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Mathf.Approximately(x, ss.Optimal) && Mathf.Abs(x - ss.Optimal) < (ss.Max - ss.Min) * 0.05f)
							{
								slider.value = ss.Optimal;
								Options.SetAndSave(key, ss.Optimal);
							}
							else
							{
								Options.SetAndSave(key, x);
							}
							if (useLabel)
							{
								label.text = FormatSliderValue(ss, slider.value.MapRange(ss.Min, ss.Max, ss.MapMin, ss.MapMax));
							}
						});
					}
					else
					{
						slider.onValueChanged.AddListener(delegate
						{
							Options.SetAndSave(key, slider.value);
							if (useLabel)
							{
								label.text = FormatSliderValue(ss, slider.value.MapRange(ss.Min, ss.Max, ss.MapMin, ss.MapMax));
							}
						});
					}
					AllControls[setting.Name] = slider;
					AddToPanel(slider.transform, setting.Type, setting.HideLabel);
				}
				else if ((sc = setting as Options.ComboSettingAttribute) != null)
				{
					GUICombobox combo = UnityEngine.Object.Instantiate(ComboPrefab);
					dictionary[sc.Name] = combo;
					if (setting.Type == Options.SettingType.Graphics)
					{
						_GFXSettings[field] = combo;
					}
					combo.LocalizeContent = sc.Localize;
					List<KeyValuePair<string, object>> content = Options.ComboContentFunctions[sc.ComboContent]().ToList();
					combo.UpdateContent(content.Select((KeyValuePair<string, object> x) => x.Key));
					int num = content.FindIndex((KeyValuePair<string, object> x) => field.Comp(x.Value));
					if (num >= 0)
					{
						combo.Selected = num;
					}
					else
					{
						combo.SelectedItem = null;
					}
					if (sc.ComboDepend != null)
					{
						dictionary[sc.ComboDepend].OnSelectedChanged.AddListener(delegate
						{
							List<KeyValuePair<string, object>> l = Options.ComboContentFunctions[sc.ComboContent]().ToList();
							combo.UpdateContent(l.Select((KeyValuePair<string, object> x) => x.Key));
						});
					}
					combo.OnSelectedChanged.AddListener(delegate
					{
						if (combo.Selected >= 0)
						{
							Options.SetAndSave(key, content[combo.Selected].Value);
						}
					});
					AllControls[setting.Name] = combo;
					AddToPanel(combo.transform, setting.Type, setting.HideLabel);
				}
				else if ((textBoxSettingAttribute = setting as Options.TextBoxSettingAttribute) != null)
				{
					InputField text2 = UnityEngine.Object.Instantiate(TextboxPrefab);
					if (textBoxSettingAttribute.Password)
					{
						text2.contentType = InputField.ContentType.Password;
					}
					if (setting.Type == Options.SettingType.Graphics)
					{
						_GFXSettings[field] = text2;
					}
					text2.text = field.GetValue().ToString();
					text2.onEndEdit.AddListener(delegate(string x)
					{
						object result;
						if (x.TryConvertToType(field.Property.PropertyType, out result))
						{
							Options.SetAndSave(key, result);
						}
						text2.text = field.GetValue().ToString();
					});
					AllControls[setting.Name] = text2;
					AddToPanel(text2.transform, setting.Type, setting.HideLabel);
				}
				if (setting.Type == Options.SettingType.Graphics)
				{
					AddToPanel((setting.Impact == Options.GraphicsImpact.None) ? new GameObject("Null").AddComponent<RectTransform>() : UnityEngine.Object.Instantiate(ImpactLabels[(int)(setting.Impact - 1)]).transform, setting.Type, setting.HideLabel);
				}
			}
			if (!flag)
			{
				text.gameObject.SetActive(false);
				rectTransform.gameObject.SetActive(false);
			}
		}
	}

	public string FormatSliderValue(Options.SliderSettingAttribute att, float value)
	{
		if (value == 0f && att.SpecialZero != null)
		{
			return att.SpecialZero.Loc();
		}
		if (att.PluralLoc == null)
		{
			return string.Format(att.NumberFormat, value);
		}
		return att.PluralLoc.LocPlural(Mathf.RoundToInt(value));
	}

	private Text MakeLabel(string value, string tip, Options.SettingType type)
	{
		if (string.IsNullOrEmpty(value))
		{
			AddToPanel(new GameObject("Null").AddComponent<RectTransform>(), type, false);
			return null;
		}
		Text text = UnityEngine.Object.Instantiate(LabelPrefab);
		text.text = value.Loc();
		if (tip != null)
		{
			text.GetComponent<GUIToolTipper>().TooltipDescription = tip;
		}
		AddToPanel(text.transform, type, false);
		return text;
	}

	private void AddToPanel(Transform obj, Options.SettingType type, bool labelHidden)
	{
		switch (type)
		{
		case Options.SettingType.Gameplay:
			obj.SetParent(GameplayPanel, false);
			break;
		case Options.SettingType.Graphics:
			obj.SetParent(GraphicsPanel, false);
			break;
		}
		if (labelHidden)
		{
			obj.name = "-F" + obj.name;
		}
	}

	private void InitAudio()
	{
		foreach (KeyValuePair<string, AudioMixerGroup> item in AudioManager.MixerMap)
		{
			Text text = UnityEngine.Object.Instantiate(LabelPrefab);
			text.text = item.Key.Loc();
			text.alignment = TextAnchor.MiddleLeft;
			text.transform.SetParent(AudioPanel.transform, false);
			Slider sl = UnityEngine.Object.Instantiate(SliderPrefab);
			sl.maxValue = 0f;
			sl.minValue = -1f;
			sl.onValueChanged.RemoveAllListeners();
			sl.value = MapVolume(AudioManager.GetVolume(item.Key), true);
			Text lab = sl.GetComponentInChildren<Text>();
			lab.text = string.Format("{0:F0}%", sl.value.MapRange(-1f, 0f, 0f, 200f));
			KeyValuePair<string, AudioMixerGroup> map1 = item;
			sl.onValueChanged.AddListener(delegate(float x)
			{
				lab.text = string.Format("{0:F0}%", x.MapRange(-1f, 0f, 0f, 200f));
				float num = MapVolume(-5f, true);
				if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Mathf.Approximately(x, num) && Mathf.Abs(x - num) < 0.02f)
				{
					sl.value = num;
					AudioManager.SetVolume(map1.Key, -5f);
				}
				else
				{
					AudioManager.SetVolume(map1.Key, MapVolume(x, false));
				}
			});
			sl.transform.SetParent(AudioPanel.transform, false);
		}
	}

	private float MapVolume(float input, bool reverse)
	{
		float num = Mathf.Abs(input);
		if (reverse)
		{
			return 0f - Mathf.Pow(num / 80f, 0.25f);
		}
		return (0f - Mathf.Pow(num, 4f)) * 80f;
	}

	private void InitKeys()
	{
		InputController.Keys[] array = (from x in typeof(InputController.Keys).GetFields(BindingFlags.Static | BindingFlags.Public)
			select x.Name.ToEnum<InputController.Keys>()).ToArray();
		foreach (InputController.Keys key in array)
		{
			string locKey = InputController.GetLocKey((int)key);
			string item = GlobalSearchPanel.Normalize(locKey);
			Text text = UnityEngine.Object.Instantiate(LabelPrefab);
			text.text = locKey;
			text.transform.SetParent(KeyPanel.transform, false);
			GameObject gameObject = UnityEngine.Object.Instantiate(InputButtonPrefab);
			GameObject gameObject2 = gameObject;
			InputButton component = gameObject.GetComponent<InputButton>();
			component.Key = key;
			InputButtons.Add(component);
			gameObject.transform.SetParent(KeyPanel.transform, false);
			gameObject = UnityEngine.Object.Instantiate(InputButtonPrefab);
			component = gameObject.GetComponent<InputButton>();
			component.Key = key;
			component.Alt = true;
			InputButtons.Add(component);
			gameObject.transform.SetParent(KeyPanel.transform, false);
			_keys.Add(new ValueTuple<string, GameObject[]>(item, new GameObject[3] { text.gameObject, gameObject.gameObject, gameObject2.gameObject }));
		}
	}

	private void InitTutorials()
	{
		if (InGame)
		{
			foreach (string key in TutorialSystem.Tutorials.Keys)
			{
				if (!key.Equals("Customization") && !key.Equals("Shared"))
				{
					Button button = UnityEngine.Object.Instantiate(ButtonPrefab);
					button.GetComponentInChildren<Text>().text = key.Loc();
					string ttut = key;
					button.onClick.AddListener(delegate
					{
						Window.Close();
						HUD.Instance.pauseWindow.ToggleShow();
						TutorialSystem.Instance.StartTutorial(ttut, true);
					});
					button.transform.SetParent(TutorialPanel.transform, false);
				}
			}
			return;
		}
		TutorialButton.SetActive(false);
	}

	public void AddModOption(ModController.DLLMod mod)
	{
		GameObject content = UnityEngine.Object.Instantiate(ModContentPrefab);
		RectTransform component = content.GetComponentInChildren<ContentSizeFitter>().GetComponent<RectTransform>();
		try
		{
			mod.Meta.ConstructOptionsScreen(component, InGame);
		}
		catch (Exception exception)
		{
			bool modded = ErrorLogging.Modded;
			ErrorLogging.Modded = true;
			Debug.LogException(exception);
			ErrorLogging.Modded = modded;
			UnityEngine.Object.Destroy(content);
			return;
		}
		float num = component.sizeDelta.x;
		float num2 = component.sizeDelta.y;
		for (int i = 0; i < component.childCount; i++)
		{
			Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(component, component.GetChild(i));
			num = Mathf.Max(num, bounds.max.x);
			num2 = Mathf.Max(num2, 0f - bounds.min.y);
		}
		component.sizeDelta = new Vector2(num + 20f, num2 + 20f);
		content.SetActive(false);
		GameObject gameObject = UnityEngine.Object.Instantiate(ModHeaderPrefab);
		gameObject.GetComponentInChildren<Text>().text = mod.Meta.Name;
		Toggle componentInChildren = gameObject.GetComponentInChildren<Toggle>();
		componentInChildren.isOn = mod.Active;
		componentInChildren.onValueChanged.AddListener(delegate(bool x)
		{
			try
			{
				mod.Activate(x);
			}
			catch (Exception ex)
			{
				Debug.Log("Error activating/deactivating dll mod " + mod.FileName + ":\n" + ex.ToString());
				WindowManager.SpawnDialog("ModActivateError".Loc(), true, DialogWindow.DialogType.Error);
			}
		});
		gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
		{
			content.SetActive(!content.activeSelf);
		});
		gameObject.transform.SetParent(ModPanel, false);
		content.transform.SetParent(ModPanel, false);
		ModOptions[mod] = new GameObject[2] { gameObject, content };
	}

	private void InitMods()
	{
		for (int i = 0; i < ModController.Instance.Mods.Count; i++)
		{
			AddModOption(ModController.Instance.Mods[i]);
		}
	}

	public void ActivatePanel(int j)
	{
		for (int i = 0; i < Panels.Length; i++)
		{
			Panels[i].SetActive(i == j);
		}
	}

	public void Show()
	{
		Window.Show();
		RefreshAchievements();
	}

	public void GetSoundtrack()
	{
		string text = "https://chrissinnott.bandcamp.com/album/software-inc-ost";
		if (SteamManager.Initialized && SteamUtils.IsOverlayEnabled())
		{
			SteamFriends.ActivateGameOverlayToWebPage(text);
		}
		else
		{
			Application.OpenURL(text);
		}
	}
}
