using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Heraldry;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class VillageWorldView : GameStartView
	{
		[Header("Region Label")]
		[SerializeField]
		private TMP_Text regionLabel;

		[Header("Village Specific")]
		[SerializeField]
		private TMP_InputField villageName;

		[SerializeField]
		private SoundButton villageNameRandomizeButton;

		[SerializeField]
		private Image mapPreview;

		[SerializeField]
		private Image mapGroundData;

		[Header("Heraldry")]
		[SerializeField]
		private HeraldryEditorView heraldryEditorView;

		[SerializeField]
		private Image heraldryCrest;

		[SerializeField]
		private Image heraldryPattern;

		[SerializeField]
		private SoundButton heraldryEditButton;

		[SerializeField]
		private SoundButton heraldryRandomizeButton;

		[SerializeField]
		private TMP_Text heraldryAuthorSignature;

		[Header("Map Settings")]
		[SerializeField]
		private TMP_Dropdown mapTypeDropDown;

		[SerializeField]
		private TMP_Dropdown mapSizeDropDown;

		[SerializeField]
		private TMP_InputField mapSeedInput;

		[SerializeField]
		private SoundButton mapSeedRandomizeButton;

		[SerializeField]
		private WorldMapViewHomeScene worldMapView;

		[SerializeField]
		private TMP_Text mapTypeDescription;

		[SerializeField]
		private TMP_Text mapSizeDescription;

		[SerializeField]
		private GameObject regionGameObject;

		[SerializeField]
		private List<GameObject> mapGameObjects;

		[SerializeField]
		private SoundButton regionToggleButton;

		[NonSerialized]
		private readonly Dictionary<string, int> indexOfMapType = new Dictionary<string, int>();

		private string creator = string.Empty;

		private string mapSeed = string.Empty;

		[NonSerialized]
		private HeraldryCamera patternCam;

		[NonSerialized]
		private HeraldryCamera crestCam;

		[NonSerialized]
		private bool isVillageNameValid;

		private bool isRegionShowing;

		private void RefreshMapPreviewSprite()
		{
			if (MonoSingleton<MapGenerationController>.IsInstantiated() && MonoSingleton<MapGenerationController>.Instance.MapGenerator != null && !(MonoSingleton<MapGenerationController>.Instance.MapGenerator.PreviewTexture == null))
			{
				Texture2D previewTexture = MonoSingleton<MapGenerationController>.Instance.MapGenerator.PreviewTexture;
				Sprite sprite = Sprite.Create(previewTexture, new Rect(0f, 0f, previewTexture.width, previewTexture.height), new Vector2(0.5f, 0.5f));
				mapPreview.sprite = sprite;
				mapGroundData.sprite = sprite;
			}
		}

		public override void Show()
		{
			if (villageName.text == string.Empty || villageName == null)
			{
				GetRandomVillageName();
			}
			OnWorldMapGeneratedFromHomeScene();
			worldMapView.OnShow();
			base.Show();
			base.MoreInfoPanel.Show();
		}

		protected override void OnClickNext()
		{
			if (MonoSingleton<MapGenerationController>.IsInstantiated() && MonoSingleton<MapGenerationController>.Instance.MapGenerator != null && MonoSingleton<MapGenerationController>.Instance.MapGenerator.MapGenerationParameters != null)
			{
				base.StartController.SelectedVillageName = villageName.text;
				base.StartController.SelectedMapSize = MonoSingleton<MapGenerationController>.Instance.MapGenerator.MapGenerationParameters.MapSize;
				base.StartController.SelectedMapType = MonoSingleton<MapGenerationController>.Instance.MapGenerator.MapGenerationParameters.MapType.GetID();
				base.StartController.SelectedMapSeed = MonoSingleton<MapGenerationController>.Instance.MapGenerator.MapGenerationParameters.MapSeed;
				base.OnClickNext();
			}
		}

		private void Start()
		{
			SetMapPreviewVisible(visible: false);
			mapSeed = new System.Random().Next().ToString();
			MonoSingleton<WorldMapController>.Instance.PlaceSelectedEvent += OnVillagePlaceSelected;
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.RegenerateFromHomeScene(mapSeed.GetHashCode());
			villageNameRandomizeButton.onClick.AddListener(GetRandomVillageName);
			villageName.onDeselect.AddListener(OnVillageNameDeselect);
			villageName.onValueChanged.AddListener(OnVillageNameChanged);
			heraldryEditButton.onClick.AddListener(OnHeraldryEdit);
			heraldryRandomizeButton.onClick.AddListener(OnHeraldryRandomize);
			heraldryEditorView.LoadLastUserHeraldry();
			crestCam = MonoSingleton<HeraldryManager>.Instance.CrestCam;
			patternCam = MonoSingleton<HeraldryManager>.Instance.PatternCam;
			StopCoroutine(InitHeraldry());
			StartCoroutine(InitHeraldry());
			mapSeedRandomizeButton.onClick.AddListener(RandomizeSeed);
			mapSeedInput.onValueChanged.AddListener(OnSeedEdit);
			MonoSingleton<WorldMapController>.Instance.WorldMapGeneratedFromHomeSceneEvent += OnWorldMapGeneratedFromHomeScene;
			mapSeedInput.SetTextWithoutNotify(mapSeed);
			RefreshIsRegionShowing();
		}

		private void OnMapSizeChanged(int index)
		{
			MapSize mapSize = GetMapSizes().ElementAt(mapSizeDropDown.value);
			mapSizeDescription.text = LocKeyUtils.GetInfo(mapSize.LocKeys).ToLocalized();
			base.StartController.SelectedMapSize = mapSize;
			MonoSingleton<MapGenerationController>.Instance.StartMapGeneration(mapSeed);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.PlaceSelectedEvent -= OnVillagePlaceSelected;
			}
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.WorldMapGeneratedFromHomeSceneEvent -= OnWorldMapGeneratedFromHomeScene;
			}
		}

		private void SetMapTypeDescription(string mapType)
		{
			NSMedieval.Model.MapNew.Map byID = Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(mapType);
			if (byID == null)
			{
				return;
			}
			Sb.Clear();
			Sb.AppendLine(base.Localize.GetText(LocKeyUtils.GetInfo(byID.LocKeys)));
			if (LocKeyUtils.GetTooltipLines(byID.LocKeys, out var lines))
			{
				string[] array = lines;
				foreach (string key in array)
				{
					Sb.AppendLine(base.Localize.GetText(key));
				}
			}
			if (!base.StartController.SelectedScenario.IsAllowedMapType(mapType))
			{
				Sb.AppendLine("not_allowed_map_selected".ToLocalized().ToStyled(TooltipStyles.DefaultRed));
			}
			mapTypeDescription.SetText(Sb.ToString());
		}

		private void SetMapSizeDropdownValue(MapSize mapSize, bool notifyUI = false)
		{
			int indexOfMapSize = GetIndexOfMapSize(mapSize);
			if (mapSize.LocKeys != null)
			{
				mapSizeDescription.text = LocKeyUtils.GetInfo(mapSize.LocKeys)?.ToLocalized();
			}
			if (notifyUI)
			{
				mapSizeDropDown.value = indexOfMapSize;
			}
			else
			{
				mapSizeDropDown.SetValueWithoutNotify(indexOfMapSize);
			}
		}

		private void OnWorldMapGeneratedFromHomeScene()
		{
			if (base.StartController.SelectedScenario.GetAllowedMapTypes(out var allowedMapTypes))
			{
				mapTypeDropDown.onValueChanged.RemoveAllListeners();
				mapTypeDropDown.ClearOptions();
				mapTypeDropDown.AddOptions(GetMapTypesDropdown(allowedMapTypes));
				mapTypeDropDown.onValueChanged.AddListener(OnMapTypeDropdownChanged);
				if (base.StartController.SelectedMapSize == null)
				{
					base.StartController.SelectedMapSize = GetMapSizes().ElementAt(mapSizeDropDown.value);
				}
				string selectedMapType = base.StartController.SelectedMapType;
				if (selectedMapType != null && indexOfMapType != null && indexOfMapType.ContainsKey(selectedMapType))
				{
					mapTypeDropDown.value = indexOfMapType[selectedMapType];
					SetMapTypeDescription(selectedMapType);
				}
			}
		}

		private void OnMapTypeDropdownChanged(int selectedIndex)
		{
			if (selectedIndex != -1)
			{
				string key = indexOfMapType.FirstOrDefault((KeyValuePair<string, int> item) => item.Value == selectedIndex).Key;
				SetMapTypeDescription(key);
				base.StartController.SelectedMapType = key;
				MonoSingleton<WorldMapController>.Instance.MapTypeDropdownChanged(key, selectedIndex);
				MonoSingleton<MapGenerationController>.Instance.StartMapGeneration(mapSeed);
			}
		}

		private void OnVillagePlaceSelected(Vector2Int villagePlace)
		{
			string mapTypeName = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.GetMapTypeName(in villagePlace);
			if (mapTypeName != null)
			{
				base.StartController.SelectedMapType = mapTypeName;
				if (indexOfMapType.TryGetValue(mapTypeName, out var value))
				{
					mapTypeDropDown.SetValueWithoutNotify(value);
				}
			}
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.VillagePosition = villagePlace;
			SetMapTypeDescription(mapTypeName);
			MonoSingleton<MapGenerationController>.Instance.StartMapGeneration(mapSeed);
		}

		private void OnApplicationQuit()
		{
			StopAllCoroutines();
			MonoSingleton<MapGenerationController>.Instance.MapGenerator.ForceStopMapGenerationThread();
		}

		private void OnEnable()
		{
			MonoSingleton<HeraldryManager>.Instance.HeraldryChangedEvent += OnHeraldryChanged;
			MonoSingleton<MapGenerationController>.Instance.MapGenerationStartedEvent += OnMapGenerationStarted;
			mapSizeDropDown.ClearOptions();
			mapSizeDropDown.AddOptions((from item in GetMapSizes()
				select new TMP_Dropdown.OptionData(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(item.LocKeys)))).ToList());
			mapSizeDropDown.onValueChanged.AddListener(OnMapSizeChanged);
			regionToggleButton.onClick.RemoveAllListeners();
			regionToggleButton.onClick.AddListener(OnRegionToggleButtonClick);
			MapSize mapSize = base.StartController?.SelectedMapSize;
			if (mapSize != null)
			{
				SetMapSizeDropdownValue(mapSize);
			}
			bool flag = MonoSingleton<MapGenerationController>.IsInstantiated() && MonoSingleton<MapGenerationController>.Instance.IsMapGenerationSuccessful;
			SetMapPreviewVisible(flag);
			if (flag)
			{
				RefreshMapPreviewSprite();
			}
			OnVillageNameDeselect(villageName.text);
			StopCoroutine(UpdateHeraldry());
			StartCoroutine(UpdateHeraldry());
		}

		private void OnDisable()
		{
			if (MonoSingleton<HeraldryManager>.IsInstantiated())
			{
				MonoSingleton<HeraldryManager>.Instance.HeraldryChangedEvent -= OnHeraldryChanged;
			}
			if (MonoSingleton<MapGenerationController>.IsInstantiated())
			{
				MonoSingleton<MapGenerationController>.Instance.MapGenerationStartedEvent -= OnMapGenerationStarted;
				MonoSingleton<MapGenerationController>.Instance.MapGenerationFinishedEvent -= OnMapGenerationFinished;
			}
			StopAllCoroutines();
		}

		private void SetMapPreviewVisible(bool visible)
		{
			mapPreview.enabled = visible;
			mapGroundData.enabled = visible;
		}

		private void OnMapGenerationFinished(bool success)
		{
			if (MonoSingleton<MapGenerationController>.IsInstantiated())
			{
				MonoSingleton<MapGenerationController>.Instance.MapGenerationFinishedEvent -= OnMapGenerationFinished;
			}
			if (base.gameObject.activeInHierarchy)
			{
				RefreshMapPreviewSprite();
				SetMapPreviewVisible(success);
				RefreshNextButtonInteractable();
			}
		}

		private void OnMapGenerationStarted()
		{
			SetMapPreviewVisible(visible: false);
			RefreshNextButtonInteractable();
			MonoSingleton<MapGenerationController>.Instance.MapGenerationFinishedEvent += OnMapGenerationFinished;
		}

		private void RefreshNextButtonInteractable()
		{
			base.NextButton.interactable = isVillageNameValid;
		}

		private void OnRegionToggleButtonClick()
		{
			isRegionShowing = !isRegionShowing;
			RefreshIsRegionShowing();
		}

		private void RefreshIsRegionShowing()
		{
			string key = (isRegionShowing ? "hud_lb_map" : "hud_lb_world");
			regionToggleButton.GetComponentInChildren<TMP_Text>().SetText(MonoSingleton<LocalizationController>.Instance.GetText(key));
			regionGameObject.SetActive(isRegionShowing);
			worldMapView.SetInputEnabled(isRegionShowing);
			string key2 = (isRegionShowing ? "hud_lb_world" : "hud_lb_map");
			regionLabel.SetText(MonoSingleton<LocalizationController>.Instance.GetText(key2));
			foreach (GameObject mapGameObject in mapGameObjects)
			{
				mapGameObject.SetActive(!isRegionShowing);
			}
		}

		private List<string> GetMapTypesDropdown(List<string> allowedMapTypes)
		{
			indexOfMapType.Clear();
			List<string> list = new List<string>();
			int num = 0;
			bool isEnabled;
			foreach (string allowedMapType in allowedMapTypes)
			{
				NSMedieval.Model.MapNew.Map byID = Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(allowedMapType);
				if (byID == null)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\VillageWorldView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find map type ");
						messageBuilder.AppendFormatted(allowedMapType);
						messageBuilder.AppendLiteral(" in MapRepository.");
					}
					Log.Error(messageBuilder);
					continue;
				}
				FVLogTraceInterpolationHandler messageBuilder2;
				if (!worldMapView.SelectableVillagePlaces.Any((WorldMapItemVillagePlace place) => allowedMapType.Equals(place.GetMapTypeName())))
				{
					messageBuilder2 = new FVLogTraceInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\VillageWorldView.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Couldn't find map type ");
						messageBuilder2.AppendFormatted(allowedMapType);
						messageBuilder2.AppendLiteral(" on world map");
					}
					Log.Trace(messageBuilder2);
					continue;
				}
				messageBuilder2 = new FVLogTraceInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\VillageWorldView.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Generating world map from home scene ");
					messageBuilder2.AppendFormatted(byID.GetID());
				}
				Log.Trace(messageBuilder2);
				indexOfMapType.Add(byID.GetID(), num++);
				list.Add(LocKeyUtils.GetName(byID.LocKeys).ToLocalized().ToStyled(TooltipStyles.TooltipDefault));
			}
			List<NSMedieval.Model.MapNew.Map> list2 = new List<NSMedieval.Model.MapNew.Map>();
			foreach (NSMedieval.Model.MapNew.Map allItem in Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetAllItems())
			{
				if (!allowedMapTypes.Contains(allItem.GetID()) && !allItem.IsDevOnly)
				{
					list2.Add(allItem);
				}
			}
			if (list2.Count > 0)
			{
				foreach (NSMedieval.Model.MapNew.Map item in list2)
				{
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\VillageWorldView.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Non Allowed Map: ");
						messageBuilder2.AppendFormatted(item.GetID());
					}
					Log.Trace(messageBuilder2);
					indexOfMapType.Add(item.GetID(), num++);
					list.Add(LocKeyUtils.GetName(item.LocKeys).ToLocalized().ToStyled(TooltipStyles.DefaultRed));
				}
			}
			return list;
		}

		private IEnumerable<MapSize> GetMapSizes()
		{
			foreach (MapSize allItem in Repository<MapSizeRepository, MapSize>.Instance.GetAllItems())
			{
				if (allItem.ShownInRelease)
				{
					yield return allItem;
				}
			}
		}

		private int GetIndexOfMapSize(MapSize mapSize)
		{
			int num = 0;
			foreach (MapSize mapSize2 in GetMapSizes())
			{
				if (mapSize2 == mapSize)
				{
					return num;
				}
				num++;
			}
			return -1;
		}

		private void OnSeedEdit(string newSeed)
		{
			mapSeed = newSeed;
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetSeedFromHomeScene(mapSeed.GetHashCode(), 0.35f);
		}

		private void RandomizeSeed()
		{
			System.Random random = new System.Random();
			mapSeed = random.Next().ToString();
			mapSeedInput.SetTextWithoutNotify(mapSeed);
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetSeedFromHomeScene(mapSeed.GetHashCode(), 0.2f);
		}

		private void OnVillageNameChanged(string textFieldInput)
		{
			CheckVillageName(textFieldInput, showBlackBarMessage: false);
			MonoSingleton<GameStartController>.Instance.VillageNameChanged(villageName.text);
		}

		private void OnVillageNameDeselect(string textFieldInput)
		{
			CheckVillageName(textFieldInput, showBlackBarMessage: true);
		}

		private void CheckVillageName(string textFieldInput, bool showBlackBarMessage)
		{
			string text = textFieldInput.TrimStart();
			if (string.Compare(text, textFieldInput, StringComparison.Ordinal) != 0)
			{
				villageName.text = text;
			}
			text = text.TrimEnd();
			if (showBlackBarMessage && string.Compare(text, textFieldInput, StringComparison.Ordinal) != 0)
			{
				villageName.text = text;
			}
			if (text.Equals(string.Empty))
			{
				if (showBlackBarMessage)
				{
					base.NextButton.AddCleanNonInteractableListener(delegate
					{
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(base.Localize.GetText("warning_choose_village_name"));
					});
				}
				isVillageNameValid = false;
			}
			else if (MonoSingleton<GlobalSaveController>.Instance.AnyVillageInfoByName(text))
			{
				if (showBlackBarMessage)
				{
					base.NextButton.AddCleanNonInteractableListener(delegate
					{
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(base.Localize.GetText("warning_village_name_exists"));
					});
				}
				isVillageNameValid = false;
			}
			else
			{
				isVillageNameValid = true;
			}
			RefreshNextButtonInteractable();
		}

		private void GetRandomVillageName()
		{
			string randomName = Repository<VillageNameRepository, VillageNames>.Instance.GetRandomName();
			if (randomName == null)
			{
				OnVillageNameDeselect(string.Empty);
				return;
			}
			villageName.text = randomName;
			OnVillageNameChanged(randomName);
		}

		private void OnHeraldryEdit()
		{
			heraldryEditorView.ShowHeraldry(this);
			Hide();
		}

		private IEnumerator UpdateHeraldry()
		{
			yield return new WaitForEndOfFrame();
			MonoSingleton<HeraldryManager>.Instance.UpdateHeraldry();
		}

		private void OnHeraldryChanged()
		{
			heraldryCrest.sprite = MonoSingleton<HeraldryManager>.Instance.Crest.sprite;
			heraldryPattern.sprite = MonoSingleton<HeraldryManager>.Instance.Pattern.sprite;
			creator = heraldryEditorView.Creator;
			ShowHeraldryAuthor();
		}

		private void OnHeraldryRandomize()
		{
			heraldryEditorView.LoadRandomPreset();
			StopCoroutine(InitHeraldry());
			StartCoroutine(InitHeraldry());
		}

		private IEnumerator InitHeraldry()
		{
			yield return new WaitForEndOfFrame();
			crestCam.TakeSs();
			patternCam.TakeSs();
			creator = heraldryEditorView.Creator;
			StopCoroutine(UpdateHeraldry());
			StartCoroutine(UpdateHeraldry());
		}

		private void ShowHeraldryAuthor()
		{
			if (!string.IsNullOrEmpty(creator) && !heraldryEditorView.Changed)
			{
				heraldryAuthorSignature.text = base.Localize.GetText("made_by") + " " + creator;
			}
			else
			{
				heraldryAuthorSignature.text = string.Empty;
			}
		}
	}
}
