using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour, PageTemplateHost
{
	public enum Mode
	{
		Title = 0,
		Pause = 1
	}

	private enum State
	{
		Normal = 0,
		InList = 1,
		InControls = 2
	}

	private class Output
	{
		public Settings.OutputMode outputMode;

		public string name;

		public Output(Settings.OutputMode outputMode_, string name_)
		{
			outputMode = outputMode_;
			name = name_;
		}
	}

	private delegate void OnListItemSelected(ListPanel.Item selectedItem);

	public Mode mode;

	public Image blackoutPanel;

	public AudioClip changeMonitorAudioClip;

	public GameObject autoSavedGo;

	private static SettingsMenu it_;

	[HideInInspector]
	public static UnityEvent onDone = new UnityEvent();

	[HideInInspector]
	public static UnityEvent onQuit = new UnityEvent();

	private float blackoutFlashStartTime;

	private PageTemplate pageTemplate;

	private ListPanel listPanel;

	private RectTransform controlsPanel;

	private AudioKit audioKit;

	private List<Output> outputs = new List<Output>();

	private Version version;

	private float autoSavedGoHideTime;

	private const float kSpeedMin = 0.2f;

	private const float kSpeedMax = 3f;

	public static SettingsMenu it
	{
		get
		{
			return it_;
		}
	}

	private State state
	{
		get
		{
			if (listPanel.gameObject.activeSelf)
			{
				return State.InList;
			}
			if (controlsPanel.gameObject.activeSelf)
			{
				return State.InControls;
			}
			return State.Normal;
		}
		set
		{
			listPanel.gameObject.SetActive(value == State.InList);
			controlsPanel.gameObject.SetActive(value == State.InControls);
			pageTemplate.interactable = value == State.Normal;
		}
	}

	private void Init()
	{
		if (listPanel == null && base.transform.parent != null)
		{
			listPanel = GetComponentInChildren<ListPanel>(true);
			if (listPanel == null)
			{
				return;
			}
			pageTemplate = GetComponent<PageTemplate>();
			controlsPanel = base.transform.Find("Controls") as RectTransform;
			Transform parent = base.transform.parent;
			while (audioKit == null && parent != null)
			{
				audioKit = parent.GetComponentInChildren<AudioKit>(true);
				parent = parent.parent;
			}
			listPanel.audioKit = audioKit;
			CreateOutputSettings();
			blackoutFlashStartTime = 0f;
			blackoutPanel.gameObject.SetActive(false);
			version = new Version();
		}
		if (listPanel != null)
		{
			state = State.Normal;
			Refresh();
		}
	}

	private void CreateOutputSettings()
	{
		outputs = new List<Output>();
		outputs.Add(new Output(Settings.OutputMode.Analog, Lang.Get("settings_output_analog")));
		outputs.Add(new Output(Settings.OutputMode.Digital0, Lang.Get("settings_output_digital_0")));
		outputs.Add(new Output(Settings.OutputMode.Digital1, Lang.Get("settings_output_digital_1")));
		outputs.Add(new Output(Settings.OutputMode.Digital2, Lang.Get("settings_output_digital_2")));
		outputs.Add(new Output(Settings.OutputMode.Digital3, Lang.Get("settings_output_digital_3")));
		outputs.Add(new Output(Settings.OutputMode.Digital4, Lang.Get("settings_output_digital_4")));
		outputs.Add(new Output(Settings.OutputMode.Digital5, Lang.Get("settings_output_digital_5")));
	}

	private void Start()
	{
		Init();
	}

	private void OnEnable()
	{
		it_ = this;
		Init();
		bool flag = mode == Mode.Pause && (DateTime.Now - SaveData.it.diskDate.systemDateTime).TotalSeconds < 2.0;
		autoSavedGo.gameObject.SetActive(flag);
		autoSavedGoHideTime = ((!flag) ? 0f : (Clock.menu.time + 3f));
	}

	private void OnDisable()
	{
		if (it_ == this)
		{
			it_ = null;
		}
		if (listPanel != null && listPanel.isOpen)
		{
			listPanel.gameObject.SetActive(false);
		}
	}

	public void MoveOffPage(int dir, PageItem sourcePageItem)
	{
	}

	private void Update()
	{
		if (RInput.GetButtonDown(10))
		{
			audioKit.Play("popup-close");
			if (state == State.Normal)
			{
				onDone.Invoke();
				return;
			}
			state = State.Normal;
		}
		else if (RInput.GetButtonDown(27))
		{
			onDone.Invoke();
			return;
		}
		if (blackoutFlashStartTime > 0f)
		{
			float num = Util.LerpScale(Clock.active.time - blackoutFlashStartTime, 0f, 0.5f, 1f, 0f);
			if ((double)num > 0.001)
			{
				blackoutPanel.color = new Color(0f, 0f, 0f, num);
			}
			else
			{
				blackoutPanel.gameObject.SetActive(false);
				blackoutFlashStartTime = 0f;
			}
		}
		if (autoSavedGoHideTime > 0f && Clock.menu.time > autoSavedGoHideTime)
		{
			autoSavedGoHideTime = 0f;
			autoSavedGo.gameObject.SetActive(false);
		}
	}

	private void Refresh()
	{
		pageTemplate.BeginRefresh();
		Dictionary<string, PageItem> pageItemDict = pageTemplate.pageItemDict;
		if (mode == Mode.Pause)
		{
			pageItemDict["title"].text = Lang.Get("menu_paused");
			pageItemDict["holder-quit"].visible = true;
			pageItemDict["holder-done"].visible = true;
			pageItemDict["holder-done"].position = new Vector2(150f, 0f);
			pageItemDict["quit"].text = Lang.Get("settings_quit");
		}
		else
		{
			pageItemDict["title"].text = Lang.Get("menu_settings");
			pageItemDict["holder-done"].visible = true;
			pageItemDict["holder-done"].position = Vector2.zero;
			pageItemDict["language-option"].visible = true;
			pageItemDict["language"].text = Lang.loadedLanguage.name;
			pageItemDict["version"].text = version.ToString();
			pageItemDict["awards"].text = Awards.GetEarnedCode();
		}
		pageItemDict["volume"].text = Lang.Get("settings_volume_" + VolumeSettingToIndex(Settings.volume));
		pageItemDict["sens"].text = Lang.Get("settings_sens_" + SpeedSettingToIndex(Settings.lookSpeedX));
		pageItemDict["inverty"].text = Lang.Get((!Settings.lookInvertY) ? "settings_inverty_no" : "settings_inverty_yes");
		int num = Mathf.Max(0, FindMonitorIndex(Settings.colorId));
		pageItemDict["monitor"].text = Settings.monitors[num].name;
		pageItemDict["controls"].text = Lang.Get("settings_controls_view");
		int index = Mathf.Max(0, FindOutputIndex(Settings.outputMode));
		pageItemDict["output"].text = outputs[index].name;
		pageTemplate.EndRefresh();
	}

	private void FlashBlackout()
	{
		blackoutFlashStartTime = Clock.active.time;
		blackoutPanel.color = Color.black;
		blackoutPanel.gameObject.SetActive(true);
		AudioOneShot.Play(changeMonitorAudioClip);
	}

	public void OnPageButtonClick(PageItem pageItem)
	{
		Debug.LogFormat("CLICK {0} {1}", pageItem.id, pageItem.buttonSettings.actionId);
		switch (pageItem.buttonSettings.actionId)
		{
		case "button-volume":
			OpenList(MakeListPanelSpec("settings_volume", VolumeSettingToIndex(Settings.volume)), delegate(ListPanel.Item selectedItem)
			{
				Settings.volume = IndexToVolumeSetting((int)selectedItem.data);
				Settings.Save();
				Refresh();
			});
			break;
		case "button-sens":
			OpenList(MakeListPanelSpec("settings_sens", SpeedSettingToIndex(Settings.lookSpeedX)), delegate(ListPanel.Item selectedItem)
			{
				Settings.lookSpeedX = (Settings.lookSpeedY = IndexToSpeedSetting((int)selectedItem.data));
				Settings.Save();
				Refresh();
			});
			break;
		case "button-inverty":
			Settings.lookInvertY = !Settings.lookInvertY;
			audioKit.Play("tap");
			Settings.Save();
			Refresh();
			break;
		case "button-output":
		{
			ListPanel.Spec spec2 = new ListPanel.Spec(null, string.Empty);
			spec2.title = Lang.Get("settings_output");
			Settings.OutputMode outputMode = Settings.CalcOutputModeMax();
			foreach (Output output in outputs)
			{
				if (output.outputMode <= outputMode)
				{
					spec2.items.Add(new ListPanel.Item(output.name, output));
				}
			}
			spec2.selectedIndex = FindOutputIndex(Settings.outputMode);
			OpenList(spec2, delegate(ListPanel.Item selectedItem)
			{
				Settings.outputMode = (selectedItem.data as Output).outputMode;
				Settings.Save();
				ScreenHelper.ApplyScreenResolution();
				FlashBlackout();
				Refresh();
			});
			break;
		}
		case "button-monitor":
		{
			int num2 = (Mathf.Max(0, FindMonitorIndex(Settings.colorId)) + 1) % Settings.monitors.Length;
			Settings.Monitor monitor = Settings.monitors[num2];
			Settings.colorId = monitor.id;
			Settings.colorBlack = monitor.blackColor;
			Settings.colorWhite = monitor.whiteColor;
			FlashBlackout();
			Settings.Save();
			Refresh();
			break;
		}
		case "button-language":
		{
			ListPanel.Spec spec = new ListPanel.Spec(null, string.Empty);
			spec.title = Lang.Get("settings_language");
			int num = 0;
			foreach (Lang.Language item in Lang.IterateAvailableLanguages())
			{
				if (item.present)
				{
					spec.items.Add(new ListPanel.Item(item.name, item.langId));
					if (item == Lang.loadedLanguage)
					{
						spec.selectedIndex = num;
					}
					num++;
				}
			}
			OpenList(spec, delegate(ListPanel.Item selectedItem)
			{
				string text = selectedItem.data as string;
				if (text != Lang.loadedLanguage.langId)
				{
					Lang.Load(text);
					Settings.Save();
					CreateOutputSettings();
					Refresh();
				}
			});
			break;
		}
		case "button-controls":
			audioKit.Play("popup-open");
			state = State.InControls;
			break;
		case "button-done":
			audioKit.Play("popup-close");
			onDone.Invoke();
			break;
		case "button-quit":
			audioKit.Play("popup-close");
			onQuit.Invoke();
			break;
		case "button-close-controls":
			audioKit.Play("popup-close");
			state = State.Normal;
			break;
		}
	}

	private void OpenList(ListPanel.Spec spec, OnListItemSelected onListItemSelected)
	{
		spec.onItemSelected = delegate(ListPanel.Spec s, ListPanel.Item selectedItem)
		{
			pageTemplate.interactable = true;
			if (selectedItem != null)
			{
				audioKit.Play("tap");
				onListItemSelected(selectedItem);
			}
			else
			{
				audioKit.Play("popup-close");
			}
		};
		audioKit.Play("popup-open");
		state = State.InList;
		spec.outsideAlpha = 1f;
		listPanel.Open(spec);
	}

	private int FindMonitorIndex(string id)
	{
		for (int i = 0; i < Settings.monitors.Length; i++)
		{
			if (id == Settings.monitors[i].id)
			{
				return i;
			}
		}
		return 0;
	}

	private int FindOutputIndex(Settings.OutputMode outputMode)
	{
		for (int i = 0; i < outputs.Count; i++)
		{
			if (outputMode == outputs[i].outputMode)
			{
				return i;
			}
		}
		return 0;
	}

	private int SpeedSettingToIndex(float speed)
	{
		if (speed < 1f)
		{
			return Mathf.FloorToInt(Util.LerpScale(speed, 0.2f, 1f, 0f, 4f) + 0.5f);
		}
		return Mathf.FloorToInt(Util.LerpScale(speed, 1f, 3f, 4f, 8f) + 0.5f);
	}

	private float IndexToSpeedSetting(int index)
	{
		if (index < 4)
		{
			return Util.LerpScale(index, 0f, 4f, 0.2f, 1f);
		}
		return Util.LerpScale(index, 4f, 8f, 1f, 3f);
	}

	private int VolumeSettingToIndex(float volume)
	{
		return (int)Util.LerpScale(volume, 0f, 1f, 0f, 8f);
	}

	private float IndexToVolumeSetting(int index)
	{
		return Util.LerpScale(index, 0f, 8f, 0f, 1f);
	}

	private static ListPanel.Spec MakeListPanelSpec(string textIdPrefix, int selectedIndex)
	{
		ListPanel.Spec spec = new ListPanel.Spec(null, string.Empty);
		spec.title = Lang.Get(textIdPrefix);
		for (int num = 8; num >= 0; num--)
		{
			spec.items.Add(new ListPanel.Item(Lang.Get(textIdPrefix + "_" + num), num));
		}
		spec.selectedIndex = 8 - selectedIndex;
		return spec;
	}
}
