using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Heraldry;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class HeraldryEditorView : ClosableUIView
	{
		[SerializeField]
		private GameObject heraldryPanel;

		[SerializeField]
		private Sprite selectionFrame;

		[SerializeField]
		private List<Sprite> heraldrySymbols;

		[SerializeField]
		private List<Sprite> heraldryCustomSymbols;

		[SerializeField]
		private Sprite[] heraldryShapes;

		[SerializeField]
		private Sprite[] heraldryPatterns;

		[SerializeField]
		private GameObject patternContentHolder;

		[SerializeField]
		private GameObject symbolContentHolder;

		[SerializeField]
		private GameObject customSymbolContentHolder;

		private RectTransform heraldryPreview;

		[SerializeField]
		private Image[] smallIcons;

		[SerializeField]
		private Canvas[] layers;

		[SerializeField]
		private CustomGrouppedToggle[] editTabs;

		[SerializeField]
		private SoundButton[] loadsaveBtns;

		[SerializeField]
		private SoundButton doneButton;

		[SerializeField]
		private GameObject[] editPannels;

		[SerializeField]
		private CustomGrouppedToggle[] layersButtons;

		[SerializeField]
		private GameObject swatchesParent;

		[SerializeField]
		private string heraldryLayer;

		[SerializeField]
		private TextMeshProUGUI creatorTooltip;

		[SerializeField]
		private Slider[] transformSliders;

		[SerializeField]
		private Toggle[] transformToggles;

		[SerializeField]
		private TMP_InputField[] inputFields;

		private Image background;

		private Image pattern;

		[SerializeField]
		private Color currentColor;

		[SerializeField]
		private Scrollbar scrollbar;

		[SerializeField]
		private LayoutGroupItemView shapePrefab;

		[SerializeField]
		private GameObject customHeraldryInfo;

		[SerializeField]
		private GameObject refreshCustomHeraldry;

		[SerializeField]
		private SoundButton copyButton;

		[SerializeField]
		private SoundButton pasteButton;

		[SerializeField]
		private HeraldryData copyLayerData = new HeraldryData();

		private HeraldryColors loadedColorData;

		private Sprite mask;

		private int currentLayer = 1;

		private int currentSymbol;

		private List<string> customSymbolsFilePaths = new List<string>();

		private List<int> selectedLayerImageIndex = new List<int>();

		private List<int> selectedLayerColorIndex = new List<int>();

		private List<HeraldryTransforms> selectedLayerTransformIndex = new List<HeraldryTransforms>(7);

		private string colorsPath = "HeraldryColors/Colors.json";

		private float scaleOffset = 0.1f;

		private UIView callbackScreen;

		private string creator;

		private bool presetChanged;

		private HeraldryPresets currentPreset;

		private TextureCreationFlags flags;

		private bool symbolsLoaded;

		private bool customSymbolsLoaded;

		private bool patternsLoaded;

		private bool colorsLoaded;

		public GameObject ContentHolder => heraldryPanel;

		public string Creator => creator;

		public bool Changed => presetChanged;

		public SoundButton DoneButton => doneButton;

		public void ShowHeraldry(UIView callbackScreen)
		{
			MonoSingleton<HeraldryManager>.Instance.CaptureCameraEnabled = true;
			this.callbackScreen = callbackScreen;
			heraldryPanel.SetActive(value: true);
		}

		private void HideHeraldry()
		{
			MonoSingleton<HeraldryManager>.Instance.CaptureCameraEnabled = false;
			callbackScreen.Show();
			heraldryPanel.SetActive(value: false);
		}

		public void OnLayerSelected(int layer)
		{
			if (loadedColorData.Colors.Count > 0)
			{
				scrollbar.value = 1f;
				currentLayer = layer;
				if (selectedLayerColorIndex[currentLayer - 1] == -1)
				{
					RandomColor();
				}
				LoadTransforms();
				PresetChanged();
			}
		}

		public void OnLayerButtonClicked(int val)
		{
			CustomGrouppedToggle[] array = editTabs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].isOn = false;
			}
			customHeraldryInfo.SetActive(value: false);
			refreshCustomHeraldry.SetActive(value: false);
			copyButton.gameObject.SetActive(value: false);
			pasteButton.gameObject.SetActive(value: false);
			editTabs[0].isOn = true;
			PresetChanged();
		}

		private bool CheckLayer()
		{
			if (layers != null && layers.Length != 0 && currentLayer >= 1)
			{
				return currentLayer <= layers.Length;
			}
			return false;
		}

		private void OnShapeSelected(PointerEventData data)
		{
			int index = -1;
			mask = heraldryShapes[1];
			Canvas[] array = layers;
			foreach (Canvas canvas in array)
			{
				canvas.GetComponent<Image>().sprite = mask;
				canvas.GetComponent<Image>().color = currentColor;
				if (canvas.GetComponent<Canvas>().sortingOrder == 1)
				{
					canvas.GetComponent<Mask>().showMaskGraphic = true;
				}
			}
			background.color = currentColor;
			for (int j = 0; j < heraldryShapes.Length; j++)
			{
				if (data != null && heraldryShapes[j].GetInstanceID() == data.pointerPress.GetComponent<Image>().sprite.GetInstanceID())
				{
					index = j;
					data.pointerPress.GetComponent<LayoutGroupItemView>().GroupItems[1].GetComponent<Image>().color = Color.white;
				}
			}
			Selection(index);
			SetSmallIcons(index);
			PresetChanged();
		}

		private void OnSymbolSelected(PointerEventData data)
		{
			ClearLayer();
			if (currentLayer <= 2)
			{
				return;
			}
			for (int i = 0; i < heraldrySymbols.Count; i++)
			{
				ClearSelection(symbolContentHolder.transform);
				if (heraldrySymbols[i].GetInstanceID() == data.pointerPress.GetComponent<LayoutGroupItemView>().GroupItems[0].GetComponent<Image>().sprite.GetInstanceID())
				{
					data.pointerPress.GetComponent<LayoutGroupItemView>().GroupItems[1].GetComponent<Image>().color = Color.white;
					int num = i;
					SetSymbol(num);
					Selection(num);
					SetSmallIcons(num);
					PresetChanged();
					break;
				}
			}
		}

		private void OnCustomSymbolSelected(PointerEventData data)
		{
			ClearLayer();
			if (currentLayer <= 2)
			{
				return;
			}
			for (int i = 0; i < heraldryCustomSymbols.Count; i++)
			{
				ClearSelection(customSymbolContentHolder.transform);
				if (heraldryCustomSymbols[i].GetInstanceID() == data.pointerPress.GetComponent<LayoutGroupItemView>().GroupItems[0].GetComponent<Image>().sprite.GetInstanceID())
				{
					data.pointerPress.GetComponent<LayoutGroupItemView>().GroupItems[1].GetComponent<Image>().color = Color.white;
					int num = i;
					SetCustomSymbol(num);
					Selection(num);
					SetSmallIcons(num);
					PresetChanged();
					break;
				}
			}
		}

		private void OnPatternSelected(PointerEventData data)
		{
			ClearLayer();
			if (currentLayer != 2)
			{
				return;
			}
			ClearSelection(patternContentHolder.transform);
			for (int i = 0; i < heraldryPatterns.Length; i++)
			{
				if (heraldryPatterns[i].GetInstanceID() == data.pointerPress.GetComponent<LayoutGroupItemView>().GroupItems[0].GetComponent<Image>().sprite.GetInstanceID())
				{
					data.pointerPress.GetComponent<LayoutGroupItemView>().GroupItems[1].GetComponent<Image>().color = Color.white;
					SetPattern(i);
					Selection(i);
					SetSmallIcons(i);
					PresetChanged();
					break;
				}
			}
		}

		public void OnColorSelected(PointerEventData data)
		{
			ClearSelection(swatchesParent.transform);
			int sortingOrder = layers[currentLayer - 1].gameObject.GetComponent<Canvas>().sortingOrder;
			Color color = data.pointerPress.GetComponent<LayoutGroupItemView>().GroupItems[0].GetComponent<Image>().color;
			if (sortingOrder == 1)
			{
				layers[currentLayer - 1].gameObject.GetComponent<Image>().color = color;
				background.color = color;
				currentColor = background.color;
			}
			if (sortingOrder == 2)
			{
				if (layers[currentLayer - 1].transform.childCount > 0)
				{
					layers[currentLayer - 1].transform.GetChild(0).GetComponent<Image>().color = color;
				}
				for (int i = 0; i < heraldryPatterns.Length; i++)
				{
					if (pattern.sprite == heraldryPatterns[i])
					{
						pattern.color = color;
						currentColor = pattern.color;
					}
				}
			}
			if (sortingOrder >= 3 && sortingOrder <= 7)
			{
				if (layers[currentLayer - 1].transform.childCount > 0)
				{
					layers[currentLayer - 1].transform.GetChild(0).GetComponent<Image>().color = color;
				}
				currentColor = color;
			}
			for (int j = 0; j < swatchesParent.transform.childCount; j++)
			{
				if (color == GetColor(j))
				{
					selectedLayerColorIndex[currentLayer - 1] = j;
				}
			}
			data.pointerPress.GetComponent<LayoutGroupItemView>().GroupItems[1].GetComponent<Image>().color = Color.white;
			PresetChanged();
		}

		public void OnTranslateX(Slider slider)
		{
			TranslateX(slider.value);
			PresetChanged();
		}

		public void OnTranslateY(Slider slider)
		{
			TranslateY(slider.value);
			PresetChanged();
		}

		public void OnRotate(Slider slider)
		{
			Rotate(slider.value);
			PresetChanged();
		}

		public void OnScale(Slider slider)
		{
			Scale(slider.value);
			PresetChanged();
		}

		public void OnFlipX(Toggle val)
		{
			FlipX(val.isOn);
			PresetChanged();
		}

		public void OnFlipY(Toggle val)
		{
			if (CheckLayer())
			{
				FlipY(val.isOn);
				PresetChanged();
			}
		}

		private void Scale(float val)
		{
			if (!CheckLayer())
			{
				return;
			}
			Transform transform = layers[currentLayer - 1].gameObject.transform;
			if (transform.childCount > 0 && currentLayer > 2)
			{
				Transform child = transform.GetChild(0);
				child.GetComponent<Image>();
				float num = val / 20f;
				num += scaleOffset;
				int num2 = 1;
				int num3 = 1;
				if (selectedLayerTransformIndex[currentLayer - 1].FlipX)
				{
					num2 = -1;
				}
				if (selectedLayerTransformIndex[currentLayer - 1].FlipY)
				{
					num3 = -1;
				}
				child.localScale = new Vector3((float)num2 * num, (float)num3 * num, 1f);
				selectedLayerTransformIndex[currentLayer - 1].Scale = val;
				UpdateInputFields();
			}
		}

		public void ClearLayer()
		{
			if (layers[currentLayer - 1].gameObject.transform.childCount > 0)
			{
				foreach (Transform item in layers[currentLayer - 1].gameObject.transform)
				{
					UnityEngine.Object.DestroyImmediate(item.gameObject);
				}
			}
			if (currentLayer > 1)
			{
				smallIcons[currentLayer - 1].color = Color.clear;
				selectedLayerColorIndex[currentLayer - 1] = -1;
			}
			if (currentLayer == 2)
			{
				pattern.sprite = null;
				pattern.color = Color.clear;
			}
			selectedLayerImageIndex[currentLayer - 1] = -1;
			StartCoroutine(LoadSelection(patternContentHolder.transform));
			StartCoroutine(LoadSelection(symbolContentHolder.transform));
			StartCoroutine(LoadSelection(customSymbolContentHolder.transform));
			StartCoroutine(LoadSelection(swatchesParent.transform));
			ZeroLayerTransforms();
			LoadTransforms();
			PresetChanged();
		}

		public void ClearAll()
		{
			int num = currentLayer;
			for (int i = 1; i < layers.Length; i++)
			{
				currentLayer = i + 1;
				ClearLayer();
			}
			ClearSmallIcons();
			currentLayer = num;
		}

		public void ShowEditors(GameObject editPanel)
		{
			GameObject[] array = editPannels;
			foreach (GameObject obj in array)
			{
				obj.SetActive(obj == editPanel);
			}
			UpdateInputFields();
		}

		public void SelectingBackground()
		{
			DisableEditBtns();
			editTabs[2].gameObject.SetActive(value: true);
			editTabs[2].isOn = true;
			ShowEditors(editPannels[1]);
			currentColor = GetColor(selectedLayerColorIndex[currentLayer - 1]);
		}

		public void SelectingPattern()
		{
			DisableEditBtns();
			editTabs[1].gameObject.SetActive(value: true);
			ShowEditors(editPannels[3]);
			editTabs[2].gameObject.SetActive(value: true);
			editTabs[1].isOn = true;
			currentColor = GetColor(selectedLayerColorIndex[currentLayer - 1]);
		}

		public void SelectingSymbols()
		{
			DisableEditBtns();
			editTabs[0].gameObject.SetActive(value: true);
			ShowEditors(editPannels[0]);
			editTabs[2].gameObject.SetActive(value: true);
			editTabs[3].gameObject.SetActive(value: true);
			editTabs[0].isOn = true;
			currentColor = GetColor(selectedLayerColorIndex[currentLayer - 1]);
			copyButton.gameObject.SetActive(value: true);
			pasteButton.gameObject.SetActive(value: true);
		}

		public void SelectingCustomSymbols()
		{
			DisableEditBtns();
			editTabs[4].gameObject.SetActive(value: true);
			ShowEditors(editPannels[4]);
			editTabs[3].gameObject.SetActive(value: true);
			currentColor = GetColor(selectedLayerColorIndex[currentLayer - 1]);
			editTabs[4].isOn = true;
			customHeraldryInfo.SetActive(value: true);
			refreshCustomHeraldry.SetActive(value: true);
		}

		public void LoadSymbols()
		{
			if (!symbolsLoaded)
			{
				LoadImages("HeraldryBasicSymbols", symbolContentHolder.transform, ref heraldrySymbols, OnSymbolSelected);
				symbolsLoaded = true;
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryEditorView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Loaded ");
					messageBuilder.AppendFormatted(heraldrySymbols?.Count);
					messageBuilder.AppendLiteral(" symbols");
				}
				Log.Info(messageBuilder);
			}
			StartCoroutine(LoadSelection(symbolContentHolder.transform));
			StartCoroutine(LoadSelection(swatchesParent.transform));
		}

		public void RefreshCustomSymbols()
		{
			customSymbolsLoaded = false;
			LoadCustomSymbols();
			customSymbolsFilePaths = GetCustomHeraldryPaths();
			if (customSymbolsFilePaths.Count != currentPreset.CustomHeraldryImages.Count || !customSymbolsFilePaths.SequenceEqual(currentPreset.CustomHeraldryImages))
			{
				ClearSelection(customSymbolContentHolder.transform);
				ClearLayer();
				currentPreset = GetEditedHeraldry();
				MonoSingleton<HeraldryManager>.Instance.SaveTempHeraldry(currentPreset);
			}
		}

		public void LoadCustomSymbols()
		{
			if (!customSymbolsLoaded)
			{
				LoadCustomImages("heraldryCustomSymbols", customSymbolContentHolder.transform, ref heraldryCustomSymbols, OnCustomSymbolSelected);
				customSymbolsLoaded = true;
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryEditorView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Loaded ");
					messageBuilder.AppendFormatted(heraldryCustomSymbols?.Count);
					messageBuilder.AppendLiteral(" custom symbols");
				}
				Log.Info(messageBuilder);
			}
			StartCoroutine(LoadSelection(customSymbolContentHolder.transform));
			StartCoroutine(LoadSelection(swatchesParent.transform));
		}

		public void LoadShapes()
		{
			StartCoroutine(LoadSelection(swatchesParent.transform));
		}

		public void LoadPatterns()
		{
			if (!patternsLoaded)
			{
				LoadImages("HeraldryBasicPatterns", patternContentHolder.transform, ref heraldryPatterns, OnPatternSelected);
				patternsLoaded = true;
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryEditorView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Loaded ");
					messageBuilder.AppendFormatted(heraldryPatterns?.Length);
					messageBuilder.AppendLiteral(" patterns");
				}
				Log.Info(messageBuilder);
			}
			StartCoroutine(LoadSelection(patternContentHolder.transform));
			StartCoroutine(LoadSelection(swatchesParent.transform));
		}

		public void SetInputFields()
		{
			for (int i = 0; i < 4; i++)
			{
				if (string.IsNullOrEmpty(inputFields[i].text))
				{
					transformSliders[i].value = 0f;
					continue;
				}
				try
				{
					transformSliders[i].value = float.Parse(inputFields[i].text, CultureInfo.InvariantCulture);
					inputFields[i].text = transformSliders[i].value.ToString();
				}
				catch (Exception)
				{
					transformSliders[i].value = 0f;
				}
			}
		}

		private void CopyLayerParameters()
		{
			copyLayerData.Layer = currentLayer;
			copyLayerData.Symbol = selectedLayerImageIndex[currentLayer - 1];
			copyLayerData.Color = selectedLayerColorIndex[currentLayer - 1];
			copyLayerData.LayerTransforms.X = selectedLayerTransformIndex[currentLayer - 1].X;
			copyLayerData.LayerTransforms.Y = selectedLayerTransformIndex[currentLayer - 1].Y;
			copyLayerData.LayerTransforms.Angle = selectedLayerTransformIndex[currentLayer - 1].Angle;
			copyLayerData.LayerTransforms.Scale = selectedLayerTransformIndex[currentLayer - 1].Scale;
			copyLayerData.LayerTransforms.FlipX = selectedLayerTransformIndex[currentLayer - 1].FlipX;
			copyLayerData.LayerTransforms.FlipY = selectedLayerTransformIndex[currentLayer - 1].FlipY;
		}

		private void PasteLayerParameters()
		{
			ClearLayer();
			currentColor = GetColor(copyLayerData.Color);
			SetSymbol(copyLayerData.Symbol);
			Selection(copyLayerData.Symbol);
			SetSmallIcons(copyLayerData.Symbol);
			TranslateX(copyLayerData.LayerTransforms.X);
			TranslateY(copyLayerData.LayerTransforms.Y);
			Rotate(copyLayerData.LayerTransforms.Angle);
			Scale(copyLayerData.LayerTransforms.Scale);
			FlipX(copyLayerData.LayerTransforms.FlipX);
			FlipY(copyLayerData.LayerTransforms.FlipY);
			selectedLayerTransformIndex[currentLayer - 1].X = copyLayerData.LayerTransforms.X;
			selectedLayerTransformIndex[currentLayer - 1].Y = copyLayerData.LayerTransforms.Y;
			selectedLayerTransformIndex[currentLayer - 1].Angle = copyLayerData.LayerTransforms.Angle;
			selectedLayerTransformIndex[currentLayer - 1].Scale = copyLayerData.LayerTransforms.Scale;
			selectedLayerTransformIndex[currentLayer - 1].FlipX = copyLayerData.LayerTransforms.FlipX;
			selectedLayerTransformIndex[currentLayer - 1].FlipY = copyLayerData.LayerTransforms.FlipY;
			LoadTransforms();
		}

		private void LoadPreset(HeraldryPresets preset)
		{
			currentPreset = preset;
			creator = preset.Creator;
			LoadShapes();
			currentLayer = 1;
			currentColor = GetColor(preset.Heraldry[0].Color);
			layers[0].GetComponent<Image>().color = currentColor;
			background.color = currentColor;
			selectedLayerColorIndex[currentLayer - 1] = preset.Heraldry[0].Color;
			SetSmallIcons(preset.Heraldry[0].Symbol);
			Selection(preset.Heraldry[0].Symbol);
			LoadPatterns();
			currentLayer = 2;
			currentColor = GetColor(preset.Heraldry[1].Color);
			SetPattern(preset.Heraldry[1].Symbol);
			SetSmallIcons(preset.Heraldry[1].Symbol);
			Selection(preset.Heraldry[1].Symbol);
			LoadSymbols();
			for (int i = 2; i < 6; i++)
			{
				currentLayer = preset.Heraldry[i].Layer + 1;
				currentColor = GetColor(preset.Heraldry[i].Color);
				SetSymbol(preset.Heraldry[i].Symbol);
				Selection(preset.Heraldry[i].Symbol);
				SetSmallIcons(preset.Heraldry[i].Symbol);
				TranslateX(preset.Heraldry[i].LayerTransforms.X);
				TranslateY(preset.Heraldry[i].LayerTransforms.Y);
				Rotate(preset.Heraldry[i].LayerTransforms.Angle);
				Scale(preset.Heraldry[i].LayerTransforms.Scale);
				FlipX(preset.Heraldry[i].LayerTransforms.FlipX);
				FlipY(preset.Heraldry[i].LayerTransforms.FlipY);
			}
			LoadCustomSymbols();
			if (preset.Heraldry.Count == 7)
			{
				if (preset.Heraldry[6].Symbol + 1 <= heraldryCustomSymbols.Count)
				{
					currentLayer = 7;
					currentColor = Color.clear;
					SetCustomSymbol(preset.Heraldry[6].Symbol);
					SetSmallIcons(preset.Heraldry[6].Symbol);
					TranslateX(preset.Heraldry[6].LayerTransforms.X);
					TranslateY(preset.Heraldry[6].LayerTransforms.Y);
					Rotate(preset.Heraldry[6].LayerTransforms.Angle);
					Scale(preset.Heraldry[6].LayerTransforms.Scale);
					FlipX(preset.Heraldry[6].LayerTransforms.FlipX);
					FlipY(preset.Heraldry[6].LayerTransforms.FlipY);
					Selection(preset.Heraldry[6].Symbol);
				}
				if (customSymbolsFilePaths.Count != preset.CustomHeraldryImages.Count || !customSymbolsFilePaths.SequenceEqual(preset.CustomHeraldryImages))
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("heraldry_missing_custom_symbol"));
					MonoSingleton<HeraldryManager>.Instance.SaveTempHeraldry(GetEditedHeraldry());
				}
			}
		}

		private List<string> GetCustomHeraldryPaths()
		{
			string text = "heraldryCustomSymbols";
			text = $"{Application.streamingAssetsPath}{MonoRepository<StringRepository, KeyStringPair>.Instance.GetString(text)}";
			string[] files = Directory.GetFiles(text, "*.png");
			for (int i = 0; i < files.Length; i++)
			{
				files[i] = files[i].Replace("\\", "/");
			}
			return customSymbolsFilePaths = files.ToList();
		}

		public void LoadRandomPreset(bool saveAsUserPreset = true)
		{
			bool captureCameraEnabled = MonoSingleton<HeraldryManager>.Instance.CaptureCameraEnabled;
			MonoSingleton<HeraldryManager>.Instance.CaptureCameraEnabled = true;
			ClearAll();
			HeraldryPresets heraldryPresets = MonoSingleton<HeraldryManager>.Instance.AllPresets.Presets.PickRandom();
			heraldryPresets.CustomHeraldryImages = GetCustomHeraldryPaths();
			try
			{
				LoadPreset(heraldryPresets);
			}
			catch (Exception t)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryEditorView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Exception happened while loading random heraldry preset: ");
					messageBuilder.AppendFormatted(t);
				}
				Log.Error(messageBuilder);
				return;
			}
			if (saveAsUserPreset)
			{
				MonoSingleton<HeraldryManager>.Instance.SaveTempHeraldry(heraldryPresets);
			}
			OnLayerSelected(1);
			OnLayerButtonClicked(0);
			SelectingBackground();
			layersButtons[0].isOn = true;
			presetChanged = false;
			ShowCreator();
			MonoSingleton<HeraldryManager>.Instance.CaptureCameraEnabled = captureCameraEnabled;
		}

		public void LoadLastUserHeraldry()
		{
			ClearAll();
			HeraldryPresets lastHeraldry = MonoSingleton<HeraldryManager>.Instance.GetLastHeraldry();
			if (lastHeraldry != null)
			{
				try
				{
					LoadPreset(lastHeraldry);
				}
				catch (Exception t)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryEditorView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Exception occurred while loading heraldry preset: ");
						messageBuilder.AppendFormatted(t);
					}
					Log.Error(messageBuilder);
					return;
				}
			}
			OnLayerSelected(1);
			OnLayerButtonClicked(0);
			SelectingBackground();
			layersButtons[0].isOn = true;
			presetChanged = false;
			ShowCreator();
		}

		private HeraldryPresets GetEditedHeraldry()
		{
			HeraldryPresets heraldryPresets = new HeraldryPresets();
			if (presetChanged)
			{
				heraldryPresets.Creator = string.Empty;
			}
			else
			{
				heraldryPresets.Creator = Creator;
			}
			for (int i = 0; i < layers.Length; i++)
			{
				HeraldryData heraldryData = new HeraldryData();
				heraldryData.Layer = i;
				heraldryData.Symbol = selectedLayerImageIndex[i];
				heraldryData.Color = selectedLayerColorIndex[i];
				heraldryData.LayerTransforms = selectedLayerTransformIndex[i];
				heraldryPresets.Heraldry.Add(heraldryData);
			}
			heraldryPresets.CustomHeraldryImages = customSymbolsFilePaths;
			return heraldryPresets;
		}

		private IEnumerator LoadSelection(Transform parent)
		{
			yield return new WaitForEndOfFrame();
			ClearSelection(parent);
			int num = ((!(parent == symbolContentHolder.transform) && !(parent == customSymbolContentHolder.transform) && !(parent == patternContentHolder.transform)) ? selectedLayerColorIndex[currentLayer - 1] : selectedLayerImageIndex[currentLayer - 1]);
			if (num > -1 && parent.transform.childCount > num)
			{
				parent.GetChild(num).GetChild(1).GetComponent<Image>()
					.color = Color.white;
			}
		}

		private void ShowCreator()
		{
			if (creator != null && creator != string.Empty && !presetChanged)
			{
				creatorTooltip.text = string.Format("{0} {1}", base.Localize.GetText("made_by"), creator);
			}
			else
			{
				creatorTooltip.text = string.Empty;
			}
		}

		public void PresetChanged()
		{
			presetChanged = true;
			ShowCreator();
		}

		private void FlipX(bool val)
		{
			if (CheckLayer())
			{
				Transform transform = layers[currentLayer - 1].gameObject.transform;
				if (transform.childCount > 0 && currentLayer > 2)
				{
					Transform child = transform.GetChild(0);
					child.GetComponent<Image>();
					float x = ((!val) ? Mathf.Abs(child.localScale.x) : (-1f * Mathf.Abs(child.localScale.x)));
					child.localScale = new Vector3(x, child.localScale.y, 1f);
					selectedLayerTransformIndex[currentLayer - 1].FlipX = val;
					UpdateInputFields();
				}
			}
		}

		private void FlipY(bool val)
		{
			if (CheckLayer())
			{
				Transform transform = layers[currentLayer - 1].gameObject.transform;
				if (transform.childCount > 0 && currentLayer > 2)
				{
					Transform child = transform.GetChild(0);
					child.GetComponent<Image>();
					child.localScale = new Vector3(y: (!val) ? Mathf.Abs(child.localScale.y) : (-1f * Mathf.Abs(child.localScale.y)), x: child.localScale.x, z: 1f);
					selectedLayerTransformIndex[currentLayer - 1].FlipY = val;
					UpdateInputFields();
				}
			}
		}

		private void TranslateY(float val)
		{
			if (CheckLayer())
			{
				Transform transform = layers[currentLayer - 1].gameObject.transform;
				if (transform.childCount > 0 && currentLayer > 2)
				{
					Transform child = transform.GetChild(0);
					Vector3 localPosition = child.localPosition;
					localPosition = new Vector3(localPosition.x, val / 20f * (heraldryPreview.sizeDelta.y / 2f), localPosition.z);
					child.localPosition = localPosition;
					selectedLayerTransformIndex[currentLayer - 1].Y = val;
					UpdateInputFields();
				}
			}
		}

		private void TranslateX(float val)
		{
			if (CheckLayer())
			{
				Transform transform = layers[currentLayer - 1].gameObject.transform;
				if (transform.childCount > 0 && currentLayer > 2)
				{
					Transform child = transform.GetChild(0);
					Vector3 localPosition = child.localPosition;
					localPosition = new Vector3(val / 20f * (heraldryPreview.sizeDelta.x / 2f), localPosition.y, localPosition.z);
					child.localPosition = localPosition;
					selectedLayerTransformIndex[currentLayer - 1].X = val;
					UpdateInputFields();
				}
			}
		}

		private void Rotate(float val)
		{
			if (CheckLayer())
			{
				Transform transform = layers[currentLayer - 1].gameObject.transform;
				if (transform.childCount > 0 && currentLayer > 2)
				{
					Transform child = transform.GetChild(0);
					child.Rotate(Vector3.forward, val * 10f - child.localEulerAngles.z);
					selectedLayerTransformIndex[currentLayer - 1].Angle = val;
					UpdateInputFields();
				}
			}
		}

		private void Selection(int index)
		{
			if (index == -1)
			{
				return;
			}
			selectedLayerImageIndex[currentLayer - 1] = index;
			for (int i = 0; i < loadedColorData.Colors.Count; i++)
			{
				if (GetColor(i) == currentColor)
				{
					selectedLayerColorIndex[currentLayer - 1] = i;
				}
			}
		}

		private void SetSymbol(int index)
		{
			if (CheckLayer() && index != -1 && index < heraldrySymbols.Count)
			{
				GameObject obj = new GameObject();
				Image image = obj.AddComponent<Image>();
				image.sprite = heraldrySymbols[index];
				currentSymbol = index;
				image.color = currentColor;
				Transform parent = layers[currentLayer - 1].gameObject.transform;
				obj.transform.SetParent(parent);
				obj.layer = LayerMask.NameToLayer(heraldryLayer);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localScale = new Vector3(selectedLayerTransformIndex[currentLayer - 1].Scale / 20f + scaleOffset, selectedLayerTransformIndex[currentLayer - 1].Scale / 20f + scaleOffset, 1f);
				Vector2 sizeDelta = heraldryPreview.sizeDelta;
				obj.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDelta.x - 30f, sizeDelta.y - 30f);
			}
		}

		private void SetCustomSymbol(int index)
		{
			if (CheckLayer() && index != -1)
			{
				GameObject obj = new GameObject();
				obj.AddComponent<Image>().sprite = heraldryCustomSymbols[index];
				currentSymbol = index;
				Transform parent = layers[currentLayer - 1].gameObject.transform;
				obj.transform.SetParent(parent);
				obj.layer = LayerMask.NameToLayer(heraldryLayer);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localScale = new Vector3(selectedLayerTransformIndex[currentLayer - 1].Scale / 20f + scaleOffset, selectedLayerTransformIndex[currentLayer - 1].Scale / 20f + scaleOffset, 1f);
				Vector2 sizeDelta = heraldryPreview.sizeDelta;
				obj.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDelta.x - 30f, sizeDelta.y - 30f);
			}
		}

		private void SetPattern(int index)
		{
			if (index >= 0 && index < heraldryPatterns.Length)
			{
				GameObject obj = new GameObject();
				Image image = obj.AddComponent<Image>();
				if (heraldryPatterns[index].texture.wrapMode == TextureWrapMode.Clamp)
				{
					image.type = Image.Type.Simple;
				}
				else
				{
					image.type = Image.Type.Tiled;
				}
				image.sprite = heraldryPatterns[index];
				pattern.sprite = heraldryPatterns[index];
				pattern.mainTexture.wrapMode = heraldryPatterns[index].texture.wrapMode;
				image.color = currentColor;
				pattern.color = currentColor;
				Transform parent = layers[currentLayer - 1].gameObject.transform;
				obj.transform.SetParent(parent);
				obj.layer = LayerMask.NameToLayer(heraldryLayer);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localScale = Vector3.one;
				image.pixelsPerUnitMultiplier = 0.5f;
				image.SetVerticesDirty();
				Vector2 sizeDelta = heraldryPreview.sizeDelta;
				obj.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDelta.x, sizeDelta.y);
			}
		}

		private void DisableEditBtns()
		{
			CustomGrouppedToggle[] array = editTabs;
			foreach (CustomGrouppedToggle obj in array)
			{
				obj.isOn = false;
				obj.gameObject.SetActive(value: false);
			}
		}

		public void SubFromMainSceneHeraldry()
		{
			doneButton.onClick.AddListener(OnDoneClick);
		}

		private void Awake()
		{
			for (int i = 0; i < selectedLayerTransformIndex.Capacity; i++)
			{
				selectedLayerTransformIndex.Add(new HeraldryTransforms
				{
					X = 0f,
					Y = 0f,
					Angle = 0f,
					Scale = 10f,
					FlipX = false,
					FlipY = false
				});
			}
			layers = MonoSingleton<HeraldryManager>.Instance.Layers;
			background = MonoSingleton<HeraldryManager>.Instance.CrestLive;
			pattern = MonoSingleton<HeraldryManager>.Instance.PatternLive;
			heraldryPreview = MonoSingleton<HeraldryManager>.Instance.ReferenceSize;
			doneButton.onClick.AddListener(OnDoneClick);
			for (int j = 0; j < layers.Length; j++)
			{
				selectedLayerImageIndex.Add(-1);
				selectedLayerColorIndex.Add(-1);
			}
			editTabs[0].GetComponentInChildren<TMP_Text>().SetText(base.Localize.GetText("menu_shapes"));
			editTabs[1].GetComponentInChildren<TMP_Text>().SetText(base.Localize.GetText("menu_patterns"));
			editTabs[2].GetComponentInChildren<TMP_Text>().SetText(base.Localize.GetText("menu_color"));
			editTabs[3].GetComponentInChildren<TMP_Text>().SetText(base.Localize.GetText("menu_transform"));
			editTabs[4].GetComponentInChildren<TMP_Text>().SetText(base.Localize.GetText("menu_shapes"));
			editTabs[0].onValueChanged.AddListener(delegate
			{
				if (editTabs[0].isOn)
				{
					ShowEditors(editPannels[0]);
				}
			});
			editTabs[1].onValueChanged.AddListener(delegate
			{
				if (editTabs[1].isOn)
				{
					ShowEditors(editPannels[3]);
				}
			});
			editTabs[2].onValueChanged.AddListener(delegate
			{
				if (editTabs[2].isOn)
				{
					ShowEditors(editPannels[1]);
				}
			});
			editTabs[3].onValueChanged.AddListener(delegate
			{
				if (editTabs[3].isOn)
				{
					ShowEditors(editPannels[2]);
				}
			});
			editTabs[4].onValueChanged.AddListener(delegate
			{
				if (editTabs[4].isOn)
				{
					ShowEditors(editPannels[4]);
				}
			});
		}

		private void OnDoneClick()
		{
			MonoSingleton<HeraldryManager>.Instance.PatternCam.TakeSs();
			MonoSingleton<HeraldryManager>.Instance.CrestCam.TakeSs();
			MonoSingleton<HeraldryManager>.Instance.UpdateShaders(setWrapModeFromHeraldryEditor: true);
			MonoSingleton<HeraldryManager>.Instance.SaveTempHeraldry(GetEditedHeraldry());
			CloseSelf();
		}

		private void Start()
		{
			Init();
			StartCoroutine(GetScene());
			ShowCreator();
			copyButton.onClick.AddListener(CopyLayerParameters);
			pasteButton.onClick.AddListener(PasteLayerParameters);
		}

		private IEnumerator GetScene()
		{
			yield return new WaitUntil(() => SceneManager.GetActiveScene().name.Equals("HomeScene"));
			if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HomeScene"))
			{
				doneButton.onClick.AddListener(delegate
				{
					HideHeraldry();
				});
			}
		}

		public void Init()
		{
			LoadShapes();
			LoadCustomSymbols();
			LoadColors();
			RandomColor();
			SelectingBackground();
			OnLayerButtonClicked(0);
			ClearSmallIcons();
			ZeroTransforms();
			LoadTransforms();
			OnLayerSelected(1);
			OnShapeSelected(null);
		}

		private void ZeroTransforms(int layer)
		{
			selectedLayerTransformIndex[layer].X = 0f;
			selectedLayerTransformIndex[layer].Y = 0f;
			selectedLayerTransformIndex[layer].Angle = 0f;
			selectedLayerTransformIndex[layer].Scale = 10f;
			selectedLayerTransformIndex[layer].FlipX = false;
			selectedLayerTransformIndex[layer].FlipY = false;
		}

		private void ZeroTransforms()
		{
			for (int i = 0; i < selectedLayerTransformIndex.Capacity; i++)
			{
				ZeroTransforms(i);
			}
		}

		private void ZeroLayerTransforms()
		{
			ZeroTransforms(currentLayer - 1);
		}

		private void LoadTransforms()
		{
			if (currentLayer > 1)
			{
				transformSliders[0].value = selectedLayerTransformIndex[currentLayer - 1].X;
				transformSliders[1].value = selectedLayerTransformIndex[currentLayer - 1].Y;
				transformSliders[2].value = selectedLayerTransformIndex[currentLayer - 1].Angle;
				transformSliders[3].value = selectedLayerTransformIndex[currentLayer - 1].Scale;
				transformToggles[0].isOn = selectedLayerTransformIndex[currentLayer - 1].FlipX;
				transformToggles[1].isOn = selectedLayerTransformIndex[currentLayer - 1].FlipY;
			}
			UpdateInputFields();
		}

		private void UpdateInputFields()
		{
			if (editPannels[2].activeSelf)
			{
				inputFields[0].text = selectedLayerTransformIndex[currentLayer - 1].X.ToString(CultureInfo.InvariantCulture);
				inputFields[1].text = selectedLayerTransformIndex[currentLayer - 1].Y.ToString(CultureInfo.InvariantCulture);
				inputFields[2].text = selectedLayerTransformIndex[currentLayer - 1].Angle.ToString(CultureInfo.InvariantCulture);
				inputFields[3].text = selectedLayerTransformIndex[currentLayer - 1].Scale.ToString(CultureInfo.InvariantCulture);
			}
		}

		private void RandomColor()
		{
			int num = UnityEngine.Random.Range(0, loadedColorData.Colors.Capacity);
			if (GetColor(num) == currentColor)
			{
				RandomColor();
				return;
			}
			selectedLayerColorIndex[currentLayer - 1] = num;
			currentColor = GetColor(num);
		}

		private void SetSmallIcons(int val)
		{
			if (val != -1)
			{
				smallIcons[currentLayer - 1].color = Color.white;
				if (currentLayer == 1)
				{
					smallIcons[currentLayer - 1].sprite = mask;
				}
				if (currentLayer == 2)
				{
					smallIcons[currentLayer - 1].sprite = heraldryPatterns[val];
				}
				if (currentLayer >= 3 && currentLayer < 7)
				{
					smallIcons[currentLayer - 1].sprite = heraldrySymbols[val];
				}
				if (currentLayer == 7)
				{
					smallIcons[currentLayer - 1].sprite = heraldryCustomSymbols[val];
				}
			}
			else
			{
				smallIcons[currentLayer - 1].sprite = null;
				smallIcons[currentLayer - 1].color = Color.clear;
			}
		}

		private void ClearSmallIcons()
		{
			for (int i = 1; i < smallIcons.Length; i++)
			{
				smallIcons[i].color = Color.clear;
			}
		}

		private void ClearSelection(Transform parent)
		{
			for (int i = 0; i < parent.childCount; i++)
			{
				parent.GetChild(i).GetChild(1).GetComponent<Image>()
					.color = Color.clear;
			}
		}

		private Color GetColor(int val)
		{
			if (val != -1 && loadedColorData.Colors.Count > 0)
			{
				ColorUtility.TryParseHtmlString(loadedColorData.Colors[val], out var color);
				return color;
			}
			return Color.clear;
		}

		private void LoadImages(string addressableLabel, Transform parent, ref Sprite[] sprites, Action<PointerEventData> action)
		{
			foreach (Transform item in parent)
			{
				if (item != null)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			long num = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			while (!MonoRepository<SpriteRepository, KeySpritePair>.Instance.HasItemsInLabel(addressableLabel) && DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - num < 1000)
			{
				Thread.Sleep(10);
			}
			if (!MonoRepository<SpriteRepository, KeySpritePair>.Instance.HasItemsInLabel(addressableLabel))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(70, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryEditorView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("There are no sprites of label ");
					messageBuilder.AppendFormatted(addressableLabel);
					messageBuilder.AppendLiteral(" in SpriteRepository, something is wrong");
				}
				Log.Error(messageBuilder);
				return;
			}
			sprites = MonoRepository<SpriteRepository, KeySpritePair>.Instance.GetAllByLabel(addressableLabel).ToArray();
			for (int i = 0; i < sprites.Length; i++)
			{
				LayoutGroupItemView layoutGroupItemView = UnityEngine.Object.Instantiate(shapePrefab, Vector3.zero, Quaternion.identity, parent);
				layoutGroupItemView.transform.localScale = Vector3.one;
				layoutGroupItemView.gameObject.name = i.ToString();
				layoutGroupItemView.GroupItems[0].GetComponent<Image>().sprite = sprites[i];
				layoutGroupItemView.GroupItems[1].GetComponent<Image>().color = Color.clear;
				layoutGroupItemView.gameObject.AddComponent<HeraldryIconClick>().Action = action;
			}
		}

		private void LoadImages(string addressableLabel, Transform parent, ref List<Sprite> sprites, Action<PointerEventData> action)
		{
			foreach (Transform item in parent)
			{
				if (item != null)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			sprites = (from s in MonoRepository<SpriteRepository, KeySpritePair>.Instance.GetAllByLabel(addressableLabel)
				orderby s.name
				select s).ToList();
			for (int num = 0; num < sprites.Count; num++)
			{
				LayoutGroupItemView layoutGroupItemView = UnityEngine.Object.Instantiate(shapePrefab, Vector3.zero, Quaternion.identity, parent);
				layoutGroupItemView.transform.localScale = Vector3.one;
				layoutGroupItemView.gameObject.name = num.ToString();
				layoutGroupItemView.GroupItems[0].GetComponent<Image>().sprite = sprites[num];
				layoutGroupItemView.GroupItems[1].GetComponent<Image>().color = Color.clear;
				layoutGroupItemView.gameObject.AddComponent<HeraldryIconClick>().Action = action;
			}
		}

		private void LoadCustomImages(string path, Transform parent, ref List<Sprite> sprites, Action<PointerEventData> action)
		{
			foreach (Transform item2 in parent)
			{
				if (item2 != null)
				{
					UnityEngine.Object.Destroy(item2.gameObject);
				}
			}
			path = Application.streamingAssetsPath + MonoRepository<StringRepository, KeyStringPair>.Instance.GetString(path);
			string[] files = Directory.GetFiles(path, "*.png");
			for (int i = 0; i < files.Length; i++)
			{
				files[i] = files[i].Replace("\\", "/");
			}
			customSymbolsFilePaths = files.ToList();
			sprites.Clear();
			for (int j = 0; j < files.Length; j++)
			{
				byte[] data;
				try
				{
					data = FileUtils.SafeReadAllBytes(files[j]);
				}
				catch (Exception ex)
				{
					customSymbolsFilePaths.Remove(files[j]);
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(27, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryEditorView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Error reading ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(files[j]));
						messageBuilder.AppendLiteral(". Exception: ");
						messageBuilder.AppendFormatted(ex.Message);
					}
					Log.Info(messageBuilder);
					continue;
				}
				Texture2D texture2D = new Texture2D(512, 512, GraphicsFormat.R8G8B8A8_SRGB, flags);
				texture2D.LoadImage(data);
				Sprite item = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
				LayoutGroupItemView layoutGroupItemView = UnityEngine.Object.Instantiate(shapePrefab, Vector3.zero, Quaternion.identity, parent);
				layoutGroupItemView.transform.localScale = Vector3.one;
				layoutGroupItemView.gameObject.name = j.ToString();
				sprites.Add(item);
				if (j >= 0 && j < sprites.Count && layoutGroupItemView.GroupItems != null && layoutGroupItemView.GroupItems.Count >= 2 && !(layoutGroupItemView.GroupItems[0] == null) && !(layoutGroupItemView.GroupItems[1] == null))
				{
					Image component = layoutGroupItemView.GroupItems[0].GetComponent<Image>();
					Image component2 = layoutGroupItemView.GroupItems[1].GetComponent<Image>();
					if (!(component == null) && !(component2 == null))
					{
						component.sprite = sprites[j];
						component2.color = Color.clear;
						layoutGroupItemView.gameObject.AddComponent<HeraldryIconClick>().Action = action;
					}
				}
			}
		}

		private void LoadColors()
		{
			if (!colorsLoaded)
			{
				string json = FileUtils.SafeReadAllText(Path.Combine(Application.streamingAssetsPath, colorsPath));
				loadedColorData = JsonUtility.FromJson<HeraldryColors>(json);
				for (int i = 0; i < loadedColorData.Colors.Count; i++)
				{
					LayoutGroupItemView layoutGroupItemView = UnityEngine.Object.Instantiate(shapePrefab, Vector3.zero, Quaternion.identity, swatchesParent.transform);
					layoutGroupItemView.transform.localScale = Vector3.one;
					layoutGroupItemView.gameObject.name = i.ToString();
					layoutGroupItemView.GroupItems[0].GetComponent<Image>().color = GetColor(i);
					layoutGroupItemView.GroupItems[1].GetComponent<Image>().color = Color.clear;
					layoutGroupItemView.gameObject.AddComponent<HeraldryIconClick>().Action = OnColorSelected;
				}
				colorsLoaded = true;
			}
		}
	}
}
