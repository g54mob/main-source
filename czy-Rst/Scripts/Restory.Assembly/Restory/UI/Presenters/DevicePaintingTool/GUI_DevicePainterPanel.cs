using System;
using Restory.Data.Equipment;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_DevicePainterPanel : MonoBehaviour, IConfirmationRequester
	{
		[SerializeField]
		private GUI_DevicePainterPanelView view;

		[SerializeField]
		private GUI_DevicePainterMainParametersPanel mainParametersPanel;

		[SerializeField]
		private GUI_DevicePainterColorSelectionPanel colorSelectionPanel;

		[SerializeField]
		private PaintingGuiValuesConversionSettings valuesConversionSettings;

		[SerializeField]
		private GameObject brushModePanel;

		[SerializeField]
		private GUI_StickerModePanel stickerModePanel;

		[SerializeField]
		private string clearPaintConfirmationLocalizationKey;

		private DevicePainter devicePainter;

		private PaintingBrush paintingBrush;

		private AvailablePaintingPalettesTrackingService availablePalettesTracker;

		private ConfirmationService confirmationService;

		private PaintingPaletteInfo currentlySelectedPalette;

		private ConcentricCirclesBrushMultiRaycasterSettings currentlySelectedMultiBrush;

		private SmallSingleBrushRaycasterSettings currentlySelectedSmallBrush;

		private BrushRaycastingMode currentBrushRaycastingMode;

		public event Action OnSwitchRequested;

		public event Action OnExitRequested;

		[Inject]
		private void Construct(DevicePainter devicePainter, PaintingBrush paintingBrush, AvailablePaintingPalettesTrackingService availablePalettesTracker, ConfirmationService confirmationService)
		{
			this.devicePainter = devicePainter;
			this.paintingBrush = paintingBrush;
			this.availablePalettesTracker = availablePalettesTracker;
			this.confirmationService = confirmationService;
		}

		public void Show()
		{
			mainParametersPanel.AddPalettesToDropDown(availablePalettesTracker.AvailablePalettes);
			availablePalettesTracker.OnNewPalettesMadeAvailable += ResolveNewNewPalettesMadeAvailable;
			SetDefaultValues();
			colorSelectionPanel.OnColorSelectionChangeRequested += ResolveColorSelectionChangeRequested;
			mainParametersPanel.OnPaletteSelectionChanged += ResolvePaletteSelectionChanged;
			mainParametersPanel.OnBrushTypeChanged += ResolveBrushTypeSettingChanged;
			mainParametersPanel.OnBrushSizeChanged += ResolveBrushSizeSettingChanged;
			mainParametersPanel.OnBrushOpacityChanged += ResolveBrushOpacitySettingChanged;
			view.OnPaintClearRequested += ResolvePaintClearRequested;
			view.OnVisibilitySwitchRequested += ResolveVisibilitySwitchRequested;
			view.OnUndoActionRequested += ResolveOnUndoActionRequested;
			view.OnRedoActionRequested += ResolveOnRedoActionRequested;
			view.OnSwitchRequested += ResolveSwitchRequested;
			view.OnExitRequested += ResolveExitRequested;
			devicePainter.OnAnyChange += UpdateButtonsActivity;
			colorSelectionPanel.Show();
			mainParametersPanel.Show();
			view.Show();
			UpdateButtonsActivity();
		}

		public void Hide()
		{
			view.Hide();
			colorSelectionPanel.Hide();
			mainParametersPanel.Hide();
			mainParametersPanel.OnPaletteSelectionChanged -= ResolvePaletteSelectionChanged;
			mainParametersPanel.OnBrushTypeChanged -= ResolveBrushTypeSettingChanged;
			mainParametersPanel.OnBrushSizeChanged -= ResolveBrushSizeSettingChanged;
			mainParametersPanel.OnBrushOpacityChanged -= ResolveBrushOpacitySettingChanged;
			colorSelectionPanel.OnColorSelectionChangeRequested -= ResolveColorSelectionChangeRequested;
			availablePalettesTracker.OnNewPalettesMadeAvailable -= ResolveNewNewPalettesMadeAvailable;
			view.OnPaintClearRequested -= ResolvePaintClearRequested;
			view.OnVisibilitySwitchRequested -= ResolveVisibilitySwitchRequested;
			view.OnUndoActionRequested -= ResolveOnUndoActionRequested;
			view.OnRedoActionRequested -= ResolveOnRedoActionRequested;
			view.OnSwitchRequested -= ResolveSwitchRequested;
			view.OnExitRequested -= ResolveExitRequested;
			devicePainter.OnAnyChange -= UpdateButtonsActivity;
		}

		public void SetBrushMode()
		{
			brushModePanel.SetActive(value: true);
			stickerModePanel.Deactivate();
		}

		public void SetStickerMode()
		{
			brushModePanel.SetActive(value: false);
			stickerModePanel.Activate();
		}

		private void SetDefaultValues()
		{
			SetActivePalette(availablePalettesTracker.AvailablePalettes[0], 0);
			currentlySelectedMultiBrush = valuesConversionSettings.HardEdgeMultiBrush;
			currentlySelectedSmallBrush = valuesConversionSettings.HardEdgeSmallBrush;
			mainParametersPanel.RestoreValues(shouldBrushBeSoftEdged: false, 0.44f, 1f, currentlySelectedPalette);
			float brushSizeFromPanelView = GetBrushSizeFromPanelView(out currentBrushRaycastingMode);
			SetupBrushes(brushSizeFromPanelView);
			paintingBrush.ChangeRayCastingMode(currentBrushRaycastingMode);
			paintingBrush.SetBrushStrength(1f, 1f);
		}

		private void SetupBrushes(float size)
		{
			switch (currentBrushRaycastingMode)
			{
			case BrushRaycastingMode.ConcentricCirclesMultiRaycasts:
				SetSmallBrush(size);
				SetMultiBrush(size);
				break;
			case BrushRaycastingMode.SingleRaycastWithAddedRaycastsLine:
				SetMultiBrush(size);
				SetSmallBrush(size);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void SetActivePalette(PaintingPaletteInfo newPalette, int colorIndexToSelect)
		{
			currentlySelectedPalette = newPalette;
			colorSelectionPanel.ChangeColorsOfButtons(newPalette.Colors);
			colorSelectionPanel.SetColorSelection(colorIndexToSelect);
			UpdateBrushColor(colorIndexToSelect);
		}

		private void UpdateBrushColor(int colorIndex)
		{
			if (colorIndex < 0 || colorIndex >= currentlySelectedPalette.Colors.Length)
			{
				Debug.LogError(string.Format("[{0}] tried to select color with index {1}, ", "GUI_DevicePainterPanel", colorIndex) + "but the currently selected palette '" + currentlySelectedPalette.ID + "' has no color with that index set!");
				return;
			}
			paintingBrush.SetActivePalette(currentlySelectedPalette);
			paintingBrush.SetPaintingColor(currentlySelectedPalette.Colors[colorIndex]);
			colorSelectionPanel.SetColorSelection(colorIndex);
		}

		private void ResolvePaletteSelectionChanged()
		{
			SetActivePalette(mainParametersPanel.CurrentlySelectedPalette, 0);
		}

		private void ResolveBrushTypeSettingChanged()
		{
			currentlySelectedMultiBrush = (mainParametersPanel.IsCurrentlySelectedBrushSoftEdged ? valuesConversionSettings.SoftEdgeMultiBrush : valuesConversionSettings.HardEdgeMultiBrush);
			currentlySelectedSmallBrush = (mainParametersPanel.IsCurrentlySelectedBrushSoftEdged ? valuesConversionSettings.SoftEdgeSmallBrush : valuesConversionSettings.HardEdgeSmallBrush);
			BrushRaycastingMode relevantBrushRaycastingMode;
			float brushSizeFromPanelView = GetBrushSizeFromPanelView(out relevantBrushRaycastingMode);
			SetupBrushes(brushSizeFromPanelView);
		}

		private void ResolveBrushSizeSettingChanged()
		{
			float brushSizeFromPanelView = GetBrushSizeFromPanelView(out currentBrushRaycastingMode);
			switch (currentBrushRaycastingMode)
			{
			case BrushRaycastingMode.ConcentricCirclesMultiRaycasts:
			{
				float x2 = (float)currentlySelectedMultiBrush.BrushSize.x * brushSizeFromPanelView;
				float y2 = (float)currentlySelectedMultiBrush.BrushSize.y * brushSizeFromPanelView;
				float newRaycastRingsSpacing = currentlySelectedMultiBrush.BrushRaycastRingsSpacing * brushSizeFromPanelView;
				float rayMaxRandomDeviation = currentlySelectedMultiBrush.BrushRaycastRayMaxRandomDeviation * brushSizeFromPanelView;
				Vector2 newCursorSize2 = currentlySelectedMultiBrush.CursorSize * brushSizeFromPanelView;
				paintingBrush.SetMultiBrushSizeDependentParameters(new Vector2(x2, y2), newRaycastRingsSpacing, rayMaxRandomDeviation, newCursorSize2);
				break;
			}
			case BrushRaycastingMode.SingleRaycastWithAddedRaycastsLine:
			{
				float x = (float)currentlySelectedSmallBrush.BrushSize.x * brushSizeFromPanelView;
				float y = (float)currentlySelectedSmallBrush.BrushSize.y * brushSizeFromPanelView;
				Vector2 newCursorSize = currentlySelectedSmallBrush.CursorSize * brushSizeFromPanelView;
				paintingBrush.SetSingleCastBrushSize(new Vector2(x, y), newCursorSize);
				break;
			}
			default:
				throw new NotImplementedException();
			}
			paintingBrush.ChangeRayCastingMode(currentBrushRaycastingMode);
		}

		private void ResolveBrushOpacitySettingChanged()
		{
			float multiBrushStrength = valuesConversionSettings.MultiBrushOpacityToAlphaMultiplierCurve.Evaluate(mainParametersPanel.CurrentBrushOpacitySliderNormalizedValue);
			float smallBrushStrength = valuesConversionSettings.SmallBrushOpacityToAlphaMultiplierCurve.Evaluate(mainParametersPanel.CurrentBrushOpacitySliderNormalizedValue);
			paintingBrush.SetBrushStrength(multiBrushStrength, smallBrushStrength);
		}

		private void ResolveColorSelectionChangeRequested(int colorIndex)
		{
			UpdateBrushColor(colorIndex);
		}

		private void ResolveNewNewPalettesMadeAvailable()
		{
			mainParametersPanel.AddPalettesToDropDown(availablePalettesTracker.AvailablePalettes);
		}

		private void SetPaintingBrush(float size)
		{
			switch (currentBrushRaycastingMode)
			{
			case BrushRaycastingMode.ConcentricCirclesMultiRaycasts:
				SetMultiBrush(size);
				break;
			case BrushRaycastingMode.SingleRaycastWithAddedRaycastsLine:
				SetSmallBrush(size);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private float GetBrushSizeFromPanelView(out BrushRaycastingMode relevantBrushRaycastingMode)
		{
			float currentBrushSizeSliderValue = mainParametersPanel.CurrentBrushSizeSliderValue;
			float num = valuesConversionSettings.SwitchBetweenNormalAndSmallBrushSizeSliderThreshold;
			float brushSizeSliderMinValue = mainParametersPanel.BrushSizeSliderMinValue;
			float brushSizeSliderMaxValue = mainParametersPanel.BrushSizeSliderMaxValue;
			if (currentBrushSizeSliderValue > num)
			{
				relevantBrushRaycastingMode = BrushRaycastingMode.ConcentricCirclesMultiRaycasts;
				float t = Mathf.InverseLerp(num, brushSizeSliderMaxValue, currentBrushSizeSliderValue);
				return Mathf.Lerp(valuesConversionSettings.MultiBrushMinMaxSize.Min, valuesConversionSettings.MultiBrushMinMaxSize.Max, t);
			}
			relevantBrushRaycastingMode = BrushRaycastingMode.SingleRaycastWithAddedRaycastsLine;
			float t2 = Mathf.InverseLerp(brushSizeSliderMinValue, num, currentBrushSizeSliderValue);
			return Mathf.Lerp(valuesConversionSettings.SmallBrushMinMaxSize.Min, valuesConversionSettings.SmallBrushMinMaxSize.Max, t2);
		}

		private void SetMultiBrush(float size)
		{
			float x = (float)currentlySelectedMultiBrush.BrushSize.x * size;
			float y = (float)currentlySelectedMultiBrush.BrushSize.y * size;
			float newRaycastRingsSpacing = currentlySelectedMultiBrush.BrushRaycastRingsSpacing * size;
			float rayMaxRandomDeviation = currentlySelectedMultiBrush.BrushRaycastRayMaxRandomDeviation * size;
			Vector2 newCursorSize = currentlySelectedMultiBrush.CursorSize * size;
			paintingBrush.SetMultiBrush(currentlySelectedMultiBrush.BrushTexture, new Vector2(x, y), newRaycastRingsSpacing, rayMaxRandomDeviation, newCursorSize, currentlySelectedMultiBrush.AreBrushRaysCastParallelInWorldSpace);
		}

		private void SetSmallBrush(float size)
		{
			float x = (float)currentlySelectedSmallBrush.BrushSize.x * size;
			float y = (float)currentlySelectedSmallBrush.BrushSize.y * size;
			Vector2 brushCursorSize = currentlySelectedSmallBrush.CursorSize * size;
			paintingBrush.SetSmallBrush(currentlySelectedSmallBrush.BrushTexture, new Vector2(x, y), brushCursorSize);
		}

		private void UpdateButtonsActivity()
		{
			view.SetRedoButtonInteractable(devicePainter.IsAbleToRedo);
			view.SetUndoButtonInteractable(devicePainter.IsAbleToUndo);
		}

		private void ResolveVisibilitySwitchRequested()
		{
			switch (view.CurrentVisibilityState)
			{
			case SlidingPanelState.Peeking:
				view.SwitchVisibility(shouldBeFullyOpen: true);
				break;
			case SlidingPanelState.Open:
				view.SwitchVisibility(shouldBeFullyOpen: false);
				break;
			default:
				throw new NotImplementedException();
			case SlidingPanelState.None:
			case SlidingPanelState.Hidden:
				break;
			}
		}

		private void ResolveSwitchRequested()
		{
			this.OnSwitchRequested?.Invoke();
		}

		private void ResolveExitRequested()
		{
			this.OnExitRequested?.Invoke();
		}

		private void ResolvePaintClearRequested()
		{
			confirmationService.RequestConfirmation(this, clearPaintConfirmationLocalizationKey);
		}

		public void OnConfirmationResponse(bool isPaintClearingConfirmed)
		{
			if (isPaintClearingConfirmed)
			{
				devicePainter.ClearAllPaintInTargetDevice();
			}
		}

		private void ResolveOnRedoActionRequested()
		{
			devicePainter.RedoPaintingStep();
		}

		private void ResolveOnUndoActionRequested()
		{
			devicePainter.UndoPaintingStep();
		}
	}
}
