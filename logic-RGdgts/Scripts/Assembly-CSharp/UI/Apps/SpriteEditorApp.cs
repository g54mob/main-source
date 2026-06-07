using System.Collections;
using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UI.SpriteEditor;
using UI.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Apps
{
	public class SpriteEditorApp : MultiToolEditorApp
	{
		private SpriteSheetAsset selectedAsset;

		private uint[] originalSpriteToEdit;

		[SerializeField]
		private UIButton zoomIncrease;

		[SerializeField]
		private UIButton zoomDecrease;

		[SerializeField]
		private RectTransform filterImage;

		[SerializeField]
		private UIToggle snapFilterToggle;

		private SEFilter filter;

		private SESelectedArea selectedArea;

		private List<SelectionParameters> selectionHistory;

		private List<uint[]> coloredPixelHistory;

		private int maxInHistory;

		[SerializeField]
		private VerticalPalette verticalPalette;

		[SerializeField]
		private UIButton changePaletteButton;

		[SerializeField]
		private UIButton editPaletteButton;

		[SerializeField]
		private UIButton savePaletteButton;

		[SerializeField]
		private UIPaletteButton transparentColorButton;

		private Material imageMaterial;

		private Material transparentBkgMaterial;

		[SerializeField]
		private RectTransform zoomedArea;

		[SerializeField]
		private ImagePixelSelection zoomedImage;

		private int zoomMaskSize;

		private Vector2Int navigationImageSize;

		[SerializeField]
		private ImagePixelSelection navigationImage;

		[SerializeField]
		private SEGrid navigationGrid;

		[SerializeField]
		private ZoomImageGrid zoomGrid;

		[SerializeField]
		private UIGrid navigationGridOnZoom;

		[SerializeField]
		private UIText currentMouseX;

		[SerializeField]
		private UIText currentMouseY;

		private SECoordinatesConverter coordConverter;

		[SerializeField]
		private UIButton showCellCoordButton;

		[SerializeField]
		private UIButton showCoordButton;

		private bool showCellsCoords;

		private List<UIButton> exclusiveShowMouseButtons;

		[SerializeField]
		private Image navigationBackground;

		[SerializeField]
		private Image zoomedTransparentBackground;

		[SerializeField]
		private Image buttonTransparentBackground;

		private Color transparentBKGColor0;

		private Color transparentBKGColor1;

		[SerializeField]
		private UIButton penGroupButton;

		[SerializeField]
		private UIButton fillGroupButton;

		[SerializeField]
		private UIButton drawShapeButton;

		[SerializeField]
		private UIButton pickGroupButton;

		[SerializeField]
		private UIButton selectionGroupButton;

		private SEToolGroups currentGroupTool;

		private UIButton currentSelectedButton;

		private PenTool pen;

		private LineTool line;

		private FillToolBFS fillFilter;

		private FillToolBFS fillImage;

		private DrawShapeTool circle;

		private DrawShapeTool square;

		private DrawShapeTool filledCircle;

		private DrawShapeTool filledSquare;

		private SelectionTool selectionSquare;

		private SelectionTool selectionCircle;

		private SelectionTool selectionFree;

		private ReplaceColorTool replaceFilter;

		private ReplaceColorTool replaceImage;

		private ColorPickerTool pick;

		[SerializeField]
		private SESettingsPanel settingPanelPrefab;

		[SerializeField]
		private SEFontPanel fontPanelPrefab;

		[SerializeField]
		private SESmallPanel smallPanelPrefab;

		private SESmallPanel toolsSmallPanel;

		private Dictionary<SEToolGroups, GroupButtonsAndPanels> groupsAndPanelsDict;

		private Dictionary<SEToolType, ToolAndToolTypes> toolDict;

		[SerializeField]
		private UIButton settingsButton;

		private SESettingsPanel settingsPanel;

		private MultitoolColorPickerService changeColor;

		public UIFont font;

		[SerializeField]
		private UIButton fontButton;

		private SEFontPanel fontPanel;

		[SerializeField]
		private UIButton printStickersButton;

		[SerializeField]
		private GameObject remoteGadgetTransparentPanel;

		private List<UIButton> mutualExclusiveSelectionButtons;

		private Coroutine checkEscapeCo;

		private Coroutine checkCtrlZCo;

		private Coroutine checkSEElementStatusCo;

		private Coroutine checkSelectionActiveCo;

		public override void Init()
		{
		}

		private void InitSelectedArea()
		{
		}

		private void InitToolsGroups()
		{
		}

		private void InitTools()
		{
		}

		private void InitPixelImages()
		{
		}

		private void InitGrids()
		{
		}

		private void ResetShowCellButtons()
		{
		}

		private void InitToolGroupsSmallPanels()
		{
		}

		private void InitFontSmallPanel()
		{
		}

		private void InitSettingsSmallPanel()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		public override void EditAsset(Asset asset)
		{
		}

		private void ResetApp()
		{
		}

		public Asset GetAsset()
		{
			return null;
		}

		private void ImportPalette(Asset palette)
		{
		}

		private void SetImagePalette()
		{
		}

		private void EditPalette()
		{
		}

		private void StopEditPalette()
		{
		}

		public void InstantiateChosePaletteModal()
		{
		}

		private void ConfirmImportPalette(Asset palette)
		{
		}

		private void OnImportPaletteConfirmed(bool confirm, Asset palette)
		{
		}

		private void SetZoomedImageSizeAndPosition()
		{
		}

		private void SetRawImage()
		{
		}

		private void OnNavigationGridChange(Vector2Int gridSize)
		{
		}

		private void CheckGridPower2(bool printErrorBar)
		{
		}

		private void OnIncreaseFilterSize()
		{
		}

		private void OnDecreaseFilterSize()
		{
		}

		private void OnMoveFilter()
		{
		}

		private void MoveFilter(Vector2 tlFilterCoords, int shiftX = 0, int shiftY = 0, Vector2? checkCoords = null)
		{
		}

		private void SnapFilter(Vector2 coords, int shiftX = 0, int shiftY = 0)
		{
		}

		private (Vector2Int, PitagoraD) ReturnSnapPoint(Vector2 coords, int shiftX = 0, int shiftY = 0, bool snapped = false)
		{
			return default((Vector2Int, PitagoraD));
		}

		private (Vector2Int, PitagoraD) GetPitagoraDToSnapPoint(List<Vector2Int> snapCoords, Vector2 coordsTL, int shiftX = 0, int shiftY = 0)
		{
			return default((Vector2Int, PitagoraD));
		}

		private void MoveFilterFree(Vector2 coords, int shiftX, int shiftY, Vector2? checkCoords = null)
		{
		}

		private (Vector2, Vector2) ReturnTLFilterCoordsAndShift()
		{
			return default((Vector2, Vector2));
		}

		private (Vector2, Vector2) ReturnNavigationImageCoords(Vector2 navigationCoords)
		{
			return default((Vector2, Vector2));
		}

		private void UpdateFilterArea()
		{
		}

		private void OnNavigationImageDown()
		{
		}

		private void OnNavigationImageMove()
		{
		}

		private void OnZoomedImagesMove()
		{
		}

		private void OnNavigationImagesMove()
		{
		}

		private void OnPixelImagesEnter()
		{
		}

		private void OnPixelImagesExit()
		{
		}

		private void ChooseGroupTool(SEToolGroups toolGroup)
		{
		}

		private void ChooseTool(SEToolType toolType)
		{
		}

		private ToolAndToolTypes GetCurrentTool()
		{
			return null;
		}

		private void ManagePermanetButtons(bool enablePaste, bool selectionActive)
		{
		}

		private void ResetToNoToolSelected()
		{
		}

		private void SetAreaSelection(DrawingTool tool)
		{
		}

		private void ResetAreaSelectionToToolDefault(DrawingTool tool)
		{
		}

		private void DeleteSelection()
		{
		}

		private void CutSelection()
		{
		}

		private void PasteSelection()
		{
		}

		private void FlipSelection(SEFlip flip)
		{
		}

		private void CopySelection()
		{
		}

		private void IgnoreTransparencyChange(bool ignoreTransparency)
		{
		}

		private void FixedCentreChange(bool fixedCentre)
		{
		}

		private void PrintSticker()
		{
		}

		private void RefreshTitle()
		{
		}

		private void HistoryCountChange()
		{
		}

		private void AddToHistory()
		{
		}

		private bool CheckDifferences(uint[] colorPixels)
		{
			return false;
		}

		private void SaveFirstSpriteInHistory()
		{
		}

		private void GoBackInHistory()
		{
		}

		private void SetDefaultAppValues()
		{
		}

		private void OpenSettingsPanel()
		{
		}

		private void SetFont()
		{
		}

		private void SetFontInAsset(string font)
		{
		}

		private void SetFontTool()
		{
		}

		private void OpenFontPanel()
		{
		}

		private void ResetAllButtonsAndPanels(bool resetCurrentButton = false)
		{
		}

		private void ResetFont()
		{
		}

		private void ResetSettings()
		{
		}

		private void ResetToolSmallPanel()
		{
		}

		private void SetColors()
		{
		}

		private void SetBKGColors()
		{
		}

		private void SetDefaultBkgColors()
		{
		}

		private void ResetDefaultBkgColors()
		{
		}

		private void SetBkgColor0()
		{
		}

		private void SetBkgColor1()
		{
		}

		private void OnSetBkgColor0(Color32 color)
		{
		}

		private void OnSetBkgColor1(Color32 color)
		{
		}

		private void ResetFilterColor()
		{
		}

		private void SetFilterColor()
		{
		}

		private void OnSetFilterColor(Color32 color)
		{
		}

		private void SetFilterAlpha(float alpha)
		{
		}

		private void ResetGridColor()
		{
		}

		private void SetGridColor()
		{
		}

		private void OnSetGridColor(Color32 color)
		{
		}

		private void SetGridAlpha(float alpha)
		{
		}

		private void ResetZoomGridColor()
		{
		}

		private void SetZoomColor()
		{
		}

		private void OnSetZoomColor(Color32 color)
		{
		}

		private void SetZoomAlpha(float alpha)
		{
		}

		private void OnZoomToggleChange(bool value)
		{
		}

		public override void OnSetGadget(Gadget gadget)
		{
		}

		private void CloseAppNoGadget()
		{
		}

		public IEnumerator CheckEscapeCO()
		{
			return null;
		}

		private void StopImagesCoroutines()
		{
		}

		public IEnumerator CheckCtrlZCO()
		{
			return null;
		}

		public IEnumerator CheckSelectionActiveCO()
		{
			return null;
		}

		private IEnumerator CheckSEElementStatusCO()
		{
			return null;
		}

		private void StopCoroutines()
		{
		}
	}
}
