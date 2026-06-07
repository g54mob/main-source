using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using DevConsole;
using SINetworking;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveGameManager : MonoBehaviour
{
	public static Versioning.Version MinimumSupportedSaveAlpha = new Versioning.Version(Versioning.VersionType.Alpha, 11, 0, 0, false, false);

	public static List<SaveGame> SaveGames;

	public static HashSet<SaveGame> WorkshoppableGames = new HashSet<SaveGame>();

	public static SaveGameManager Instance;

	public GameObject SavePanel;

	public SaveFileItem SaveItemPrefab;

	public List<SaveFileItem> SaveItems = new List<SaveFileItem>();

	public static HashSet<Texture2D> ThumbPics = new HashSet<Texture2D>();

	public static List<Texture2D> LogoPics = new List<Texture2D>();

	public Text ButtonText;

	public Text NewPlotCost;

	public GameObject NameLabel;

	public GameObject WaitPanel;

	public GameObject PlotTogglePanel;

	public GameObject PlotGenPanel;

	public GUICombobox EnvironmentDrop;

	public GUICombobox ClimateDrop;

	public GUIWindow SaveGameWindow;

	public InputField CurrentName;

	public InputField GenerationField;

	public GameObject BackupButton;

	public RectTransform SaveListPanel;

	public VerticalLayoutGroup SaveLayout;

	public ToggleGroup TGroup;

	public Toggle PlotToggle;

	public Toggle BuildingToggle;

	public RawImage CustomMapThumb;

	private bool isSaving;

	public bool isLoading;

	public Text SaveTabLabel;

	public Texture2D MapTex;

	public Toggle BiggerPlotToggle;

	public Scrollbar Scrollbar;

	public VarValueSheet EnvSheet;

	[NonSerialized]
	private SaveGame _selected;

	private List<SaveGame> _saveCache = new List<SaveGame>();

	private Dictionary<SaveGame, Texture2D> _thumbs = new Dictionary<SaveGame, Texture2D>();

	private List<SaveFileItem> _needsThumb = new List<SaveFileItem>();

	[NonSerialized]
	private Action<SaveGame> CustomAction;

	private bool EditMode;

	private bool BuildingMode;

	private bool MultiPlayerMode;

	public static HashSet<string> _localUUIDs = null;

	public static string SaveFolder
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "Saves");
		}
	}

	public static string BuildingFolder
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "Buildings");
		}
	}

	public bool Visible
	{
		get
		{
			return SaveGameWindow.Shown;
		}
	}

	public static GameReader.NewLoadMode CurrentMode
	{
		get
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				if (!GameSettings.Instance.EditMode)
				{
					return GameReader.NewLoadMode.Full;
				}
				return GameReader.NewLoadMode.Building;
			}
			return GameReader.NewLoadMode.Full;
		}
	}

	public void QuickSave(string saveName)
	{
		SaveGame associatedAutoSave = GameSettings.Instance.AssociatedAutoSave;
		SaveMyGame(AutosaveName(saveName, false, GameSettings.Instance.EditMode), null, true, false);
		GameSettings.Instance.AssociatedAutoSave = associatedAutoSave;
	}

	public void AutoSave(bool forceNew = false, GameReader.NewLoadMode? forceMode = null, bool wasManual = false)
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			SaveGame saveGame = (wasManual ? (GameSettings.Instance.AssociatedSave ?? GameSettings.Instance.AssociatedAutoSave) : GameSettings.Instance.AssociatedAutoSave);
			if (!forceNew && saveGame != null)
			{
				saveGame.SaveNow(false, false, false, forceMode ?? CurrentMode);
			}
			else
			{
				SaveMyGame(AutosaveName(GameSettings.Instance.EditMode ? "Building" : "Autosave", true, GameSettings.Instance.EditMode), null, true, wasManual, forceMode);
			}
		}
	}

	private string AutosaveName(string baseName, bool alwaysIncludeNumber, bool building)
	{
		baseName = Utilities.CleanFileName(baseName);
		if (!alwaysIncludeNumber && !CheckExists(baseName, building))
		{
			return baseName;
		}
		baseName += " ";
		int i;
		for (i = 1; CheckExists(baseName + i, building); i++)
		{
		}
		return baseName + i;
	}

	public static bool CheckExists(string name, bool building)
	{
		if (!building)
		{
			return File.Exists(Path.Combine(SaveFolder, name + ".sav"));
		}
		return Directory.Exists(Path.Combine(BuildingFolder, name));
	}

	public SaveGame BuildingSave()
	{
		string text = "Building";
		if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.AssociatedSave != null)
		{
			text = GameSettings.Instance.AssociatedSave.ActualName + " building";
		}
		if (CheckExists(text, true))
		{
			int i;
			for (i = 1; CheckExists(text + " " + i, true); i++)
			{
			}
			text = text + " " + i;
		}
		SaveGame saveGame = SaveGame.CreateSave(text, GameReader.NewLoadMode.Building, false);
		if (saveGame.SaveNow(false, true, false, GameReader.NewLoadMode.Building))
		{
			AddSaveItem(saveGame);
			return saveGame;
		}
		return null;
	}

	public void DeleteSave(SaveGame game, bool message)
	{
		if (game == null || game.Readonly)
		{
			return;
		}
		if (File.Exists(game.FileName))
		{
			NetworkStartWindow.Dirty = true;
			try
			{
				if (game.BuildingOnly)
				{
					Directory.Delete(game.Root, true);
				}
				else
				{
					File.Delete(game.FileName);
				}
				if (!GameSettings.Instance.IsReferenceNull())
				{
					if (GameSettings.Instance.AssociatedAutoSave == game)
					{
						GameSettings.Instance.AssociatedAutoSave = null;
					}
					if (GameSettings.Instance.AssociatedSave == game)
					{
						GameSettings.Instance.AssociatedSave = null;
					}
				}
				RemoveSaveItem(game);
				return;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				if (message)
				{
					WindowManager.SpawnDialog("DeleteFail".Loc(), true, DialogWindow.DialogType.Error);
				}
				return;
			}
		}
		RemoveSaveItem(game);
	}

	private List<SaveGame> GetActiveSavesGames()
	{
		_saveCache.Clear();
		bool flag = !isSaving && !string.IsNullOrEmpty(CurrentName.text);
		string value = CurrentName.text.ToLower();
		for (int i = 0; i < SaveGames.Count; i++)
		{
			SaveGame saveGame = SaveGames[i];
			bool flag2 = ((!isSaving && !EditMode) || !saveGame.Readonly) && (isSaving || MultiPlayerMode == (saveGame.NetworkData != null)) && saveGame.BuildingOnly == BuildingMode && (!EditMode || (saveGame.BuildingOnly && saveGame.IsRentMap()));
			if (flag)
			{
				flag2 &= (saveGame.ActualName + saveGame.CompanyName).ToLower().Contains(value);
			}
			if (flag2)
			{
				_saveCache.Add(saveGame);
			}
		}
		return _saveCache;
	}

	public void Select(SaveFileItem item)
	{
		SaveItems.ForEach(delegate(SaveFileItem x)
		{
			x.Highlight(false);
		});
		if (item != null)
		{
			_selected = item.Save;
			item.Highlight(true);
			SelectChange(item);
		}
		else
		{
			_selected = null;
		}
	}

	public void RefreshScroll()
	{
		int maxItems = GetMaxItems();
		List<SaveGame> activeSavesGames = GetActiveSavesGames();
		int num = Mathf.FloorToInt(Scrollbar.value * (float)Mathf.Max(0, activeSavesGames.Count - maxItems + 1));
		_thumbs.Clear();
		_needsThumb.Clear();
		for (int i = 0; i < SaveItems.Count; i++)
		{
			SaveFileItem saveFileItem = SaveItems[i];
			Texture2D texture2D;
			if (saveFileItem.Save != null && (object)(texture2D = saveFileItem.Thumbnail.texture as Texture2D) != null && texture2D.name.Equals("SaveGameThumb"))
			{
				_thumbs[saveFileItem.Save] = texture2D;
			}
		}
		if (activeSavesGames.Count >= maxItems && num + maxItems > activeSavesGames.Count)
		{
			num = Mathf.Max(0, activeSavesGames.Count - maxItems);
			RectOffset padding = SaveLayout.padding;
			padding.top = -200;
			SaveLayout.padding = padding;
			SaveLayout.childAlignment = TextAnchor.LowerLeft;
		}
		else
		{
			RectOffset padding2 = SaveLayout.padding;
			padding2.top = 4;
			SaveLayout.padding = padding2;
			SaveLayout.childAlignment = TextAnchor.UpperLeft;
		}
		for (int j = 0; j < maxItems; j++)
		{
			int num2 = num + j;
			if (num2 < activeSavesGames.Count)
			{
				SaveGame saveGame = activeSavesGames[num2];
				Texture2D value;
				if (_thumbs.TryGetValue(saveGame, out value))
				{
					_thumbs.Remove(saveGame);
					SaveItems[j].Init(saveGame, value, LogoPics);
				}
				else
				{
					SaveItems[j].Init(saveGame, null, LogoPics);
					_needsThumb.Add(SaveItems[j]);
				}
				SaveItems[j].Highlight(_selected == saveGame);
				SaveItems[j].gameObject.SetActive(true);
			}
			else
			{
				if (SaveItems[j].Save != null)
				{
					_thumbs.Remove(SaveItems[j].Save);
				}
				SaveItems[j].gameObject.SetActive(false);
			}
		}
		foreach (KeyValuePair<SaveGame, Texture2D> thumb in _thumbs)
		{
			ThumbPics.Add(thumb.Value);
		}
		for (int k = 0; k < _needsThumb.Count; k++)
		{
			SaveFileItem saveFileItem2 = _needsThumb[k];
			Texture2D texture = GetTexture();
			if (!saveFileItem2.InitTexture(texture))
			{
				ThumbPics.Add(texture);
			}
		}
		_thumbs.Clear();
		_needsThumb.Clear();
	}

	public void ScrollMe(BaseEventData d)
	{
		PointerEventData pointerEventData = (PointerEventData)d;
		Scrollbar.value -= pointerEventData.scrollDelta.y / (float)Mathf.Max(1, GetActiveSavesGames().Count - GetMaxItems());
	}

	public int GetMaxItems()
	{
		return Mathf.CeilToInt((SaveListPanel.rect.height - 8f) / 132f);
	}

	public void OnSizeChanged()
	{
		PopulateUISaves();
	}

	private void PopulateUISaves()
	{
		int maxItems = GetMaxItems();
		for (int i = SaveItems.Count; i < maxItems; i++)
		{
			SaveFileItem c = UnityEngine.Object.Instantiate(SaveItemPrefab);
			c.transform.SetParent(SaveListPanel, false);
			c.GetComponent<EventTrigger>().AddTrigger(EventTriggerType.Scroll, ScrollMe);
			c.GetComponent<Button>().onClick.AddListener(delegate
			{
				Select(c);
			});
			SaveItems.Add(c);
		}
		int count = SaveItems.Count;
		for (int num = maxItems; num < count; num++)
		{
			SaveFileItem saveFileItem = SaveItems[SaveItems.Count - 1];
			Texture2D texture2D = saveFileItem.DeInitTex();
			if (texture2D != null)
			{
				ThumbPics.Add(texture2D);
			}
			texture2D = saveFileItem.DeInitLogo();
			if (texture2D != null)
			{
				LogoPics.Add(texture2D);
			}
			UnityEngine.Object.Destroy(saveFileItem.gameObject);
			SaveItems.RemoveAt(SaveItems.Count - 1);
		}
		List<SaveGame> activeSavesGames = GetActiveSavesGames();
		Scrollbar.numberOfSteps = Mathf.Max(0, activeSavesGames.Count - maxItems + 2);
		Scrollbar.size = Mathf.Clamp01((float)maxItems / ((float)activeSavesGames.Count + 1f));
		RefreshScroll();
	}

	public static void ReorderList()
	{
		SaveGames.Sort();
		if (Instance != null && Instance.SaveGameWindow.Shown)
		{
			Instance.PopulateUISaves();
		}
	}

	public void UpdateThumbs()
	{
	}

	private static Texture2D GetTexture()
	{
		if (ThumbPics.Count == 0)
		{
			return new Texture2D(128, 128, TextureFormat.ARGB32, false)
			{
				name = "SaveGameThumb"
			};
		}
		Texture2D texture2D = ThumbPics.First();
		ThumbPics.Remove(texture2D);
		return texture2D;
	}

	public void RefreshRents()
	{
		for (int i = 0; i < SaveItems.Count; i++)
		{
			SaveItems[i].RefreshRentCost();
		}
	}

	public void AddSaveItem(SaveGame save)
	{
		if (save != null)
		{
			if (SaveGames.Contains(save))
			{
				ReorderList();
				return;
			}
			AddSave(save);
			ReorderList();
		}
	}

	public void RemoveSaveItem(SaveGame save)
	{
		if (save != null)
		{
			RemoveSave(save);
			PopulateUISaves();
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		for (int i = 0; i < SaveItems.Count; i++)
		{
			SaveFileItem saveFileItem = SaveItems[i];
			Texture2D texture2D = saveFileItem.DeInitTex();
			if (texture2D != null)
			{
				ThumbPics.Add(texture2D);
			}
			texture2D = saveFileItem.DeInitLogo();
			if (texture2D != null)
			{
				LogoPics.Add(texture2D);
			}
		}
		if (MapTex != null)
		{
			UnityEngine.Object.Destroy(MapTex);
		}
	}

	private static void InitializeDefaultBuilding(string name)
	{
		SaveGame saveGame = LoadGameMeta("Default Buildings/" + name, true, true, true) as SaveGame;
		if (saveGame != null)
		{
			AddSave(saveGame);
		}
		string path = Path.Combine(BuildingFolder, name);
		if (Directory.Exists(path))
		{
			try
			{
				Directory.Delete(path, true);
			}
			catch (Exception)
			{
			}
		}
	}

	public static void InitializeSaves()
	{
		if (SaveGames != null)
		{
			return;
		}
		SaveGames = new List<SaveGame>();
		if (!Directory.Exists(SaveFolder))
		{
			Directory.CreateDirectory(SaveFolder);
		}
		if (!Directory.Exists(BuildingFolder))
		{
			try
			{
				Directory.CreateDirectory(BuildingFolder);
			}
			catch (Exception ex)
			{
				Debug.LogException(new Exception("Failed initializing building folder:\n" + ex.ToString()));
			}
		}
		try
		{
			InitializeDefaultBuilding("Garage Inc");
			InitializeDefaultBuilding("Apartment Inc");
			InitializeDefaultBuilding("Skyscraper Inc");
			InitializeDefaultBuilding("Hardware Inc");
		}
		catch (Exception ex2)
		{
			Debug.LogException(new Exception("Failed creating default buildings:\n" + ex2.ToString()));
		}
		DateTime now = DateTime.Now;
		string[] files = Directory.GetFiles(SaveFolder, "*.sav");
		for (int i = 0; i < files.Length; i++)
		{
			SaveGame saveGame = LoadGameMeta(files[i], false, true) as SaveGame;
			if (saveGame != null)
			{
				AddSave(saveGame);
			}
		}
		string[] directories = Directory.GetDirectories(BuildingFolder);
		for (int j = 0; j < directories.Length; j++)
		{
			string text = Directory.GetFiles(directories[j], "*.build").FirstOrDefault();
			if (text != null)
			{
				SaveGame saveGame2 = LoadGameMeta(text, true, true) as SaveGame;
				if (saveGame2 != null)
				{
					AddSave(saveGame2);
				}
			}
		}
		ReorderList();
		Debug.Log("Initializing save games: " + (DateTime.Now - now).TotalSeconds.SecondsToTime());
	}

	public static void RefreshSaves()
	{
		bool flag = false;
		string[] files = Directory.GetFiles(SaveFolder, "*.sav");
		foreach (string text in files)
		{
			string file = text.ToLower();
			if (!SaveGames.Any((SaveGame x) => x.FileName.ToLower().Equals(file)))
			{
				SaveGame saveGame = LoadGameMeta(text, false, true) as SaveGame;
				if (saveGame != null)
				{
					AddSave(saveGame);
					flag = true;
				}
			}
		}
		if (flag)
		{
			ReorderList();
		}
	}

	public static void RemoveSave(SaveGame game)
	{
		SaveGames.Remove(game);
		_localUUIDs = null;
		if (game.BuildingOnly)
		{
			WorkshoppableGames.Remove(game);
		}
	}

	public static void AddSave(SaveGame game)
	{
		InitializeSaves();
		SaveGames.Add(game);
		_localUUIDs = null;
		if (game.BuildingOnly)
		{
			WorkshoppableGames.Add(game);
		}
	}

	public static IWorkshopItem LoadGameMeta(string path, bool build, bool canWrite, bool resource = false)
	{
		try
		{
			return SaveGame.LoadGame(path, build, canWrite, resource);
		}
		catch (Exception ex)
		{
			string text = "Error loading save: " + Path.GetFileName(path) + "\n" + ex;
			Debug.LogError(text);
			return build ? new FailMod("Building", path, text) : null;
		}
	}

	public void UpdateEnvText()
	{
		EnvironmentPreset environmentPreset = ObjectDatabase.Instance.EnvironmentPresets[EnvironmentDrop.Selected];
		EnvSheet.UpdateValues(new string[10]
		{
			EditMode ? "NotApplicableAbbr".Loc() : PlotArea.StartPlotPrice.Currency(),
			GetStat(environmentPreset.EmployeePool, 0.75f, 1f),
			GetStat(environmentPreset.PlotPriceFactor, 1f, 1.2f),
			(environmentPreset.AddedTax - 1f).ToPercent(),
			GetStat(environmentPreset.ISPCostFactor, 0.95f, 1f),
			GetStat(environmentPreset.UtilitiesCostFactor, 1f, 1.1f),
			GetStat(environmentPreset.BackgroundNoise, 0f, 4f),
			GetStat(environmentPreset.BackgroundBeauty, 0.5f, 1f),
			GetStat(environmentPreset.AirQuality, 0.5f, 1f),
			GetStat(environmentPreset.DensityDesc, 0f, 2f)
		});
	}

	private string GetStat(float value, float min, float max)
	{
		switch (Mathf.RoundToInt(value.MapRange(min, max, 0f, 2f, true)))
		{
		case 0:
			return "Low".Loc();
		case 1:
			return "Medium".Loc();
		case 2:
			return "High".Loc();
		default:
			return "NotApplicableAbbr".Loc();
		}
	}

	private void Start()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		InitializeSaves();
		MapTex = new Texture2D(256, 256, TextureFormat.ARGB32, false);
		CustomMapThumb.texture = MapTex;
		EnvironmentDrop.UpdateContent(from x in Enum.GetNames(typeof(GameData.EnvironmentType))
			select x.Loc());
		ClimateDrop.UpdateContent(from x in Enum.GetNames(typeof(GameData.ClimateType))
			select x.Loc());
		EnvironmentDrop.OnSelectedChanged.AddListener(RenderMiniMap);
		ClimateDrop.OnSelectedChanged.AddListener(RenderMiniMap);
		EnvSheet.SetData(new string[10]
		{
			"Cost".Loc(),
			"TalentPool".Loc(),
			"PlotCost".Loc(),
			"AddedTax".Loc(),
			"ISPCost".Loc(),
			"UtilitiesCost".Loc(),
			"BackgroundNoise".Loc(),
			"Beauty".Loc(),
			"AirQuality".Loc(),
			"TrafficDensity".Loc()
		}, new string[0]);
		UpdateEnvText();
	}

	public void RenderMiniMap()
	{
		GameData.EnvironmentType selected = (GameData.EnvironmentType)EnvironmentDrop.Selected;
		MinimapThumbnailMaker.Instance.RenderMap((GameData.ClimateType)ClimateDrop.Selected, selected, MapTex);
		BiggerPlotToggle.gameObject.SetActive(selected == GameData.EnvironmentType.Rural && !EditMode);
	}

	private void SelectChange(SaveFileItem save)
	{
		if (isSaving)
		{
			CurrentName.text = save.Save.ActualName;
		}
		BackupButton.SetActive(CustomAction == null && !isSaving && File.Exists(save.Save.FileName + ".bak"));
	}

	public SaveFileItem FindSave(SaveGame game)
	{
		return SaveItems.FirstOrDefault((SaveFileItem x) => x.gameObject.activeSelf && x.Save == game);
	}

	public static SaveGame FindSave(string name)
	{
		List<SaveGame> saveGames = SaveGames;
		if (saveGames == null)
		{
			return null;
		}
		return saveGames.FirstOrDefault((SaveGame x) => name.Equals(x.ActualName));
	}

	public void UpdateInput()
	{
		if (!isSaving)
		{
			UpdateActive();
		}
	}

	public void TogglePlot(bool on)
	{
		if (on)
		{
			if (BuildingToggle.isOn)
			{
				SavePanel.SetActive(true);
				PlotGenPanel.SetActive(false);
				UpdateThumbs();
			}
			else if (PlotToggle.isOn)
			{
				SavePanel.SetActive(false);
				PlotGenPanel.SetActive(true);
			}
		}
	}

	private void Update()
	{
		if (SaveGameWindow.IsActiveWindow)
		{
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				SaveGameWindow.Close();
			}
			if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
			{
				ButtonClick(false);
			}
		}
		if (!BuildingToggle.isOn)
		{
			return;
		}
		int num = (Input.GetKeyDown(KeyCode.UpArrow) ? (-1) : (Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0));
		if (num != 0 && _selected != null)
		{
			List<SaveGame> activeSavesGames = GetActiveSavesGames();
			int num2 = activeSavesGames.IndexOf(_selected);
			if (num2 >= 0)
			{
				int index = Mathf.Clamp(num2 + num, 0, activeSavesGames.Count - 1);
				SelectSave(activeSavesGames[index]);
			}
		}
	}

	private void UpdateActive()
	{
		SelectSave(GetActiveSavesGames().FirstOrDefault());
		PopulateUISaves();
	}

	public void ChangeBiggerPlotMode()
	{
		GameData.RuralBigPlots = BiggerPlotToggle.isOn;
	}

	public void Show(bool save, bool editMode, bool buildingMode = false, bool plotMode = false, Action<SaveGame> customAction = null, bool multiplayerMode = false)
	{
		SaveGameWindow.Title = ((buildingMode && !save) ? "Pick map" : "Save games");
		CustomAction = customAction;
		isSaving = save;
		TGroup.allowSwitchOff = isSaving;
		EditMode = editMode;
		BuildingMode = buildingMode;
		MultiPlayerMode = multiplayerMode;
		SaveTabLabel.text = (buildingMode ? "Buildings" : "Savegames").Loc();
		NewPlotCost.text = "Cost".Loc() + ": " + PlotArea.StartPlotPrice.Currency();
		NewPlotCost.gameObject.SetActive(!editMode);
		BiggerPlotToggle.isOn = false;
		BiggerPlotToggle.gameObject.SetActive(false);
		UpdateActive();
		PlotTogglePanel.SetActive(plotMode);
		if (plotMode)
		{
			PlotToggle.isOn = true;
			BuildingToggle.isOn = false;
			GenerationField.text = GenerateGenString();
			EnvironmentDrop.Selected = 2;
			ClimateDrop.Selected = 1;
		}
		else
		{
			BuildingToggle.isOn = true;
			PlotToggle.isOn = false;
		}
		TogglePlot(true);
		UpdateThumbs();
		bool flag = save || !plotMode;
		NameLabel.SetActive(flag);
		CurrentName.gameObject.SetActive(flag);
		ButtonText.text = (isSaving ? "Save".Loc() : "Load".Loc());
		if (CustomAction != null || plotMode)
		{
			ButtonText.text = "OK".Loc();
		}
		SaveGameWindow.Show();
		_selected = null;
		PopulateUISaves();
		if (isSaving)
		{
			CurrentName.text = AutosaveName(buildingMode ? "Building" : GameSettings.Instance.MyCompany.Name, false, buildingMode);
			CurrentName.Select();
			if (GameSettings.Instance.AssociatedSave != null)
			{
				CurrentName.text = GameSettings.Instance.AssociatedSave.ActualName;
				SelectSave(GameSettings.Instance.AssociatedSave);
			}
			else
			{
				SelectSave(GetActiveSavesGames().FirstOrDefault());
			}
		}
		else
		{
			SelectSave(GetActiveSavesGames().FirstOrDefault());
			CurrentName.text = "";
			if (flag)
			{
				CurrentName.Select();
			}
		}
		UpdateThumbs();
	}

	private void SelectSave(SaveGame item)
	{
		List<SaveGame> activeSavesGames = GetActiveSavesGames();
		int num = activeSavesGames.IndexOf(item);
		if (num >= 0)
		{
			int num2 = activeSavesGames.Count + 1 - GetMaxItems();
			if (num2 == 0)
			{
				Scrollbar.value = 0f;
			}
			else
			{
				Scrollbar.value = Mathf.Clamp01((float)num / (float)num2);
			}
		}
		PopulateUISaves();
		Select(FindSave(item));
	}

	public static string GenerateGenString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 10; i++)
		{
			if (Utilities.RandomValue > 0.5f)
			{
				stringBuilder.Append((char)Utilities.RandomRange(65, 91));
			}
			else
			{
				stringBuilder.Append(Utilities.RandomRange(0, 10).ToString());
			}
		}
		return stringBuilder.ToString();
	}

	public bool SaveMyGame(string name, SaveGame exists, bool auto = false, bool associate = true, GameReader.NewLoadMode? mode = null)
	{
		GameReader.NewLoadMode finalMode = mode ?? CurrentMode;
		if (exists != null)
		{
			if (exists.BuildingOnly != finalMode.Is(GameReader.NewLoadMode.Building))
			{
				WindowManager.Instance.ShowMessageBox("OverwriteError".Loc(), false, DialogWindow.DialogType.Error);
				return false;
			}
			if (exists.Readonly)
			{
				WindowManager.Instance.ShowMessageBox("OverwriteError".Loc(), false, DialogWindow.DialogType.Error);
				return false;
			}
			if (!auto)
			{
				WindowManager.Instance.ShowMessageBox("OverwriteConfirmMsg".Loc(), false, DialogWindow.DialogType.Warning, delegate
				{
					if (exists.SaveNow(true, true, false, finalMode) && associate)
					{
						GameSettings.Instance.AssociatedSave = exists;
					}
				}, "Overwrite save file");
				return true;
			}
			if (exists.SaveNow(false, false, false, finalMode))
			{
				if (associate)
				{
					GameSettings.Instance.AssociatedSave = exists;
				}
				else
				{
					GameSettings.Instance.AssociatedAutoSave = exists;
				}
				return true;
			}
			return false;
		}
		SaveGame saveGame = SaveGame.SaveCurrentGame(name, auto, finalMode);
		if (saveGame != null)
		{
			AddSaveItem(saveGame);
			if (associate)
			{
				GameSettings.Instance.AssociatedSave = saveGame;
			}
			else if (auto)
			{
				GameSettings.Instance.AssociatedAutoSave = saveGame;
			}
			return true;
		}
		return false;
	}

	public static bool LoadGame(SaveGame game, byte[] companyData, SDateTime companyDate, bool backup, bool company, bool building, bool editMode)
	{
		bool flag = (game == null && !building) || (game != null && game.Resource);
		string path = (flag ? null : ((backup && !building) ? (game.FileName + ".bak") : game.FileName));
		if (!flag && backup && !File.Exists(path))
		{
			return false;
		}
		if (!flag && game.Broken && !backup)
		{
			WindowManager.SpawnDialog("CorruptSaveFile".Loc(), true, DialogWindow.DialogType.Error);
			return false;
		}
		if (game != null && !game.BuildingOnly)
		{
			Versioning.Version version = Versioning.DisectVersionString(game.GameVersion);
			if (version < MinimumSupportedSaveAlpha)
			{
				WindowManager.SpawnDialog(string.Format("OldSaveGameError".Loc(), version.SimpleVersion(), Versioning.SimpleVersionString), true, DialogWindow.DialogType.Error);
				return false;
			}
		}
		if (flag || File.Exists(path))
		{
			if (GameSettings.Instance != null && NetworkManager.IsConnected)
			{
				NetworkMessaging.DisconnectMyself();
				NetworkMessaging.SendAllNow();
				NetworkManager.Instance.CleanUpEverything(true);
			}
			Instance.ShowWaitPanel();
			GameSettings.UnloadNow();
			GameData.LoadGame(game, companyData, companyDate, backup, company, building, editMode);
			ErrorLogging.FirstOfScene = true;
			SiteNewsFeeder.AbortIfActive();
			ErrorLogging.SceneChanging = true;
			DevConsole.Console.SaveConsole();
			SceneManager.LoadSceneAsync("MainScene");
			return true;
		}
		WindowManager.SpawnDialog("SaveDeletedError".Loc(), true, DialogWindow.DialogType.Error);
		RemoveSave(game);
		if (Instance != null)
		{
			Instance.RemoveSaveItem(game);
		}
		return false;
	}

	public void ButtonClick(bool text)
	{
		if (text && !Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.KeypadEnter))
		{
			return;
		}
		if (CustomAction != null)
		{
			if (PlotGenPanel.activeSelf)
			{
				GameData.Climate = (GameData.ClimateType)ClimateDrop.Selected;
				GameData.Environment = (GameData.EnvironmentType)EnvironmentDrop.Selected;
				GameData.RandomString = GenerationField.text;
				CustomAction(null);
				CustomAction = null;
			}
			else if (_selected != null)
			{
				CustomAction(_selected);
				CustomAction = null;
			}
			SaveGameWindow.Close();
		}
		else if (isSaving)
		{
			string text2 = Utilities.CleanFileName(CurrentName.text);
			SaveGame saveGame = null;
			if (_selected != null && _selected.ActualName.Equals(text2))
			{
				saveGame = _selected;
			}
			else if (CurrentMode.Is(GameReader.NewLoadMode.Building))
			{
				string file = Path.Combine(BuildingFolder, text2 + ".build").ToLower();
				saveGame = SaveGames.FirstOrDefault((SaveGame x) => x.BuildingOnly && Path.GetDirectoryName(x.FileName).ToLower().Equals(file));
			}
			else
			{
				string file2 = Path.Combine(SaveFolder, text2 + ".sav").ToLower();
				saveGame = SaveGames.FirstOrDefault((SaveGame x) => !x.BuildingOnly && Path.GetDirectoryName(x.FileName).ToLower().Equals(file2));
			}
			CurrentName.text = text2;
			SaveMyGame(text2, saveGame);
			SaveGameWindow.Close();
		}
		else if (PlotGenPanel.activeSelf)
		{
			if (GameSettings.Instance != null && NetworkManager.IsConnected)
			{
				NetworkMessaging.SendDisconnectPlayer(false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				NetworkMessaging.SendAllNow();
				NetworkManager.Instance.CleanUpEverything(true);
			}
			ShowWaitPanel();
			GameData.EditMode = EditMode;
			GameData.Climate = (GameData.ClimateType)ClimateDrop.Selected;
			GameData.Environment = (GameData.EnvironmentType)EnvironmentDrop.Selected;
			GameData.RandomString = GenerationField.text;
			GameData.LoadAnyOnLoad = false;
			GameSettings.UnloadNow();
			ErrorLogging.FirstOfScene = true;
			SiteNewsFeeder.AbortIfActive();
			ErrorLogging.SceneChanging = true;
			DevConsole.Console.SaveConsole();
			SceneManager.LoadSceneAsync("MainScene");
		}
		else if (_selected != null && !isLoading)
		{
			isLoading = LoadGame(_selected, null, default(SDateTime), false, !EditMode, true, EditMode);
			if (isLoading)
			{
				FrameTransition.StartTransition(true);
			}
		}
		if (text)
		{
			InputController.InputEnabled = true;
		}
	}

	public void ShowWaitPanel()
	{
		if (WaitPanel != null)
		{
			WaitPanel.gameObject.SetActive(true);
		}
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.LoadingText.text = "LoadDestroyScene".Loc();
			GameSettings.Instance.LoadingImage.gameObject.SetActive(false);
			GameSettings.Instance.LoadingCamera.gameObject.SetActive(true);
		}
	}

	public void HideWaitPanel()
	{
		if (WaitPanel != null)
		{
			WaitPanel.gameObject.SetActive(false);
		}
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.LoadingCamera.gameObject.SetActive(false);
		}
	}

	public void LoadBackup()
	{
		DialogWindow diag = WindowManager.SpawnDialog();
		diag.Show("LoadBackupMsg".Loc(), false, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Yes", delegate
		{
			if (_selected != null && !isLoading)
			{
				isLoading = LoadGame(_selected, null, default(SDateTime), true, !_selected.BuildingOnly, true, EditMode);
			}
			diag.Window.Close();
		}), new KeyValuePair<string, Action>("No", delegate
		{
			diag.Window.Close();
		}));
	}

	public static bool HasPlayed(string uuid)
	{
		if (_localUUIDs == null)
		{
			_localUUIDs = new HashSet<string>();
			for (int i = 0; i < SaveGames.Count; i++)
			{
				SaveGame saveGame = SaveGames[i];
				if (!saveGame.Broken && saveGame.NetworkData != null)
				{
					_localUUIDs.Add(saveGame.NetworkData.CurrentUUID);
				}
			}
			string[] files = Directory.GetFiles(SaveFolder, "*.bak");
			foreach (string filename in files)
			{
				try
				{
					SaveGame saveGame2 = SaveGame.LoadGame(filename, false, true);
					if (!saveGame2.Broken && saveGame2.NetworkData != null)
					{
						_localUUIDs.Add(saveGame2.NetworkData.CurrentUUID);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		return _localUUIDs.Contains(uuid);
	}
}
