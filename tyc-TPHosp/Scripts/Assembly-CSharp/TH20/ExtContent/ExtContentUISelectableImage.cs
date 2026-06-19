using System;
using TH20.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.ExtContent
{
	[DontSave]
	public class ExtContentUISelectableImage : UIBehaviour
	{
		[SerializeField]
		private GameObject _gameObjectResizeForTarget;

		[SerializeField]
		private DynamicButton _buttonChooseTexture;

		[SerializeField]
		private DynamicButton _buttonChooseTextureImage;

		[SerializeField]
		private DynamicButton _buttonResetTextureImage;

		[SerializeField]
		private DynamicButton _buttonToggleEditMode;

		[SerializeField]
		private DynamicButton _buttonRotateImageCW;

		[SerializeField]
		private DynamicButton _buttonRotateImageCCW;

		[SerializeField]
		private Image _imageTexture;

		[SerializeField]
		private Image _imageTextureBG;

		[SerializeField]
		private Color _imageTextureDefaultBGColour;

		[SerializeField]
		private LocalisedString _locTextSelectTextureTitle;

		[SerializeField]
		private string _devTextSelectTextureTitle;

		private bool _bAreEventsRegistered;

		private bool _bEditModeOn;

		private bool _bCanInteract;

		private bool _bScaleImageToCompletelyFillParent;

		private bool _bFireDelegatePendingTextureChanged;

		private bool _bFireDelegatePendingDisplayChanged;

		private bool _bEditModeAllowedExternal;

		private bool _bUseImageBGColour;

		private string[] _supportedTextureFileExtensions;

		private Action _onTextureChangedCallback;

		private Action _onTextureDisplayedChangedCallback;

		private Action _onEditModeStatusChangedCallback;

		private ExtContentImageSpec _imageSpec;

		private ExtContentImageSpec _imageSpecLoaded;

		private Texture2D _texture2DScaledSource;

		private Texture2D _texture2DSelectedArea;

		private Color _imageBGColour;

		private float _displayAspectRatio;

		private bool _bInitialised;

		private SelectableImageCursor _editModeCursor;

		private string _debugContextString;

		public ExtContentImageSpec ImageSpec => _imageSpec;

		public string ImageFileSpec => _imageSpec.FileSpec;

		public bool HasValidFileSpec => !_imageSpec.FileSpec.IsNullOrEmpty();

		public bool EditModeOn => _bEditModeOn;

		public bool Initialised => _bInitialised;

		public bool UseImageBGColour
		{
			get
			{
				return _bUseImageBGColour;
			}
			set
			{
				SetUseImageBGColour(value);
			}
		}

		public Texture2D Texture2DScaledSource => _texture2DScaledSource;

		public Texture2D Texture2DSelectedArea => _texture2DSelectedArea;

		public ExtContentUISelectableImage()
		{
			_imageSpec = new ExtContentImageSpec();
			_imageSpecLoaded = new ExtContentImageSpec();
		}

		public void Setup(string debugContextString, string[] supportedTextureFileExtensions, bool bScaleImageToCompletelyFillParent, Action onTextureChangedCallback = null, Action onTextureDisplayedChangedCallback = null, Action onEditModeStatusChangedCallback = null)
		{
			_debugContextString = debugContextString;
			_supportedTextureFileExtensions = supportedTextureFileExtensions;
			_bScaleImageToCompletelyFillParent = bScaleImageToCompletelyFillParent;
			_onTextureChangedCallback = onTextureChangedCallback;
			_onTextureDisplayedChangedCallback = onTextureDisplayedChangedCallback;
			_onEditModeStatusChangedCallback = onEditModeStatusChangedCallback;
		}

		public void Initialise(float displayAspectRatio, ExtContentImageSpec imageSpec)
		{
			_bInitialised = false;
			_imageSpecLoaded.Reset();
			_imageSpec.UpdateFrom(imageSpec);
			SetUseImageBGColour(bSet: false);
			SetDisplayAspectRatio(displayAspectRatio, bForce: true);
		}

		public void Show()
		{
			ProcessEventRegistration(bShow: true);
			_bCanInteract = true;
			_bEditModeAllowedExternal = true;
			SetEditMode(bSet: false, bForce: true);
		}

		public void Hide()
		{
			ProcessEventRegistration(bShow: false);
			DestroyEditModeCursor();
			_texture2DScaledSource = null;
			_texture2DSelectedArea = null;
		}

		public void SetEditModeOn()
		{
			SetEditMode(bSet: true);
		}

		public void SetEditModeOff()
		{
			SetEditMode(bSet: false);
		}

		public void ToggleEditMode()
		{
			SetEditMode(!_bEditModeOn);
		}

		public void SetUseImageBGColour(bool bSet)
		{
			_bUseImageBGColour = bSet;
			if (_imageTextureBG != null)
			{
				Color color = (_bUseImageBGColour ? _imageBGColour : _imageTextureDefaultBGColour);
				if (_imageTextureBG.color != color)
				{
					_imageTextureBG.color = color;
				}
			}
		}

		public void SetMainTextureBGColour(Color imageBGColour)
		{
			_imageBGColour = imageBGColour;
		}

		public void SetEditModeAllowedExternal(bool bSet)
		{
			_bEditModeAllowedExternal = bSet;
			UpdateToggleEditModeButtonDisplay();
		}

		public void SetInteractable(bool bCanInteract)
		{
			_bCanInteract = bCanInteract;
			ExtContentUIUtils.SetSelectableInteractable(_buttonChooseTexture, _bCanInteract);
			ExtContentUIUtils.SetSelectableInteractable(_buttonChooseTextureImage, _bCanInteract);
			UpdateToggleEditModeButtonDisplay();
			UpdateResetImageButtonDisplay();
			UpdateRotateImageButtonsDisplay();
		}

		public void UpdateDisplayedImageFrom(ExtContentUISelectableImage otherSelectableImage, int rotateRightAnlgesCount)
		{
			Texture2D texture2D = otherSelectableImage.GetSelectedAreaTexture2D();
			if (rotateRightAnlgesCount != 0)
			{
				texture2D = ExtContentTextureUtils.RotateTexture2D(texture2D, rotateRightAnlgesCount);
			}
			UpdateDisplayImageTexture(texture2D, _bScaleImageToCompletelyFillParent);
		}

		public void UpdateImageSpecFrom(ExtContentImageSpec imageSpec, bool bForce = true)
		{
			if (!_imageSpec.IsEqualTo(imageSpec) || bForce)
			{
				_imageSpec.UpdateFrom(imageSpec);
				OnImageSpecChanged();
			}
		}

		public void Update()
		{
			ProcessFireDelegatesPending();
			_editModeCursor?.Update();
			_bInitialised = true;
		}

		private void ProcessEventRegistration(bool bShow)
		{
			if (bShow)
			{
				if (!_bAreEventsRegistered)
				{
					_bAreEventsRegistered = true;
					if (_buttonChooseTexture != null)
					{
						_buttonChooseTexture.onPrimaryDown.AddListener(OnChooseTextureButton);
					}
					if (_buttonChooseTextureImage != null)
					{
						_buttonChooseTextureImage.onPrimaryDown.AddListener(OnChooseTextureButton);
					}
					if (_buttonResetTextureImage != null)
					{
						_buttonResetTextureImage.onPrimaryDown.AddListener(OnResetTextureButton);
					}
					if (_buttonToggleEditMode != null)
					{
						_buttonToggleEditMode.onPrimaryDown.AddListener(OnToggleEditModeButton);
					}
					if (_buttonRotateImageCW != null)
					{
						_buttonRotateImageCW.onPrimaryDown.AddListener(OnRotateImageCWButton);
					}
					if (_buttonRotateImageCCW != null)
					{
						_buttonRotateImageCCW.onPrimaryDown.AddListener(OnRotateImageCCWButton);
					}
				}
			}
			else if (_bAreEventsRegistered)
			{
				_bAreEventsRegistered = false;
				if (_buttonChooseTexture != null)
				{
					_buttonChooseTexture.onPrimaryDown.RemoveListener(OnChooseTextureButton);
				}
				if (_buttonChooseTextureImage != null)
				{
					_buttonChooseTextureImage.onPrimaryDown.RemoveListener(OnChooseTextureButton);
				}
				if (_buttonResetTextureImage != null)
				{
					_buttonResetTextureImage.onPrimaryDown.RemoveListener(OnResetTextureButton);
				}
				if (_buttonToggleEditMode != null)
				{
					_buttonToggleEditMode.onPrimaryDown.RemoveListener(OnToggleEditModeButton);
				}
				if (_buttonRotateImageCW != null)
				{
					_buttonRotateImageCW.onPrimaryDown.RemoveListener(OnRotateImageCWButton);
				}
				if (_buttonRotateImageCCW != null)
				{
					_buttonRotateImageCCW.onPrimaryDown.RemoveListener(OnRotateImageCCWButton);
				}
			}
		}

		private void SetFireDelegatePendingTextureChanged()
		{
			_bFireDelegatePendingTextureChanged = true;
		}

		private void SetFireDelegatePendingDisplayChanged()
		{
			_bFireDelegatePendingDisplayChanged = true;
		}

		private void ProcessFireDelegatesPending()
		{
			if (_bFireDelegatePendingTextureChanged)
			{
				_bFireDelegatePendingTextureChanged = false;
				if (_onTextureChangedCallback != null)
				{
					_onTextureChangedCallback();
				}
			}
			if (_bFireDelegatePendingDisplayChanged)
			{
				_bFireDelegatePendingDisplayChanged = false;
				if (_onTextureDisplayedChangedCallback != null)
				{
					_onTextureDisplayedChangedCallback();
				}
			}
		}

		private void OnImageSpecChanged(bool bForceReload = false)
		{
			bool flag = !_imageSpec.AreFileSpecsEqual(_imageSpecLoaded);
			bool flag2 = !_imageSpec.AreSelectionAreasEqual(_imageSpecLoaded);
			bool flag3 = !_imageSpec.AreRotationIndexesEqual(_imageSpecLoaded);
			bool flag4 = !_imageSpec.SelectionArea.IsValid();
			if (!(bForceReload || flag || flag2 || flag4 || flag3))
			{
				return;
			}
			SetEditMode(bSet: false);
			DestroyEditModeCursor();
			bool flag5 = flag3;
			bool flag6 = flag4;
			if (bForceReload || flag)
			{
				_texture2DScaledSource = ExtContentTextureUtils.LoadTexture2D(_imageSpec.FileSpec);
				if (_texture2DScaledSource != null)
				{
					ExtContentTextureUtils.ConstrainTexture2D(ref _texture2DScaledSource, ExtContentUtils.TexturesConfig.MaxStagedMainTextureDimension);
					flag5 = true;
					flag6 = true;
					SetUseImageBGColour(bSet: true);
				}
				else if (!_imageSpec.FileSpec.IsNullOrEmpty())
				{
					SetUseImageBGColour(bSet: false);
					ExtContentMessages.ShowErrorMessageBox(ExtContentMessages.GetMessageString(EMessageType.ImageFileFailedToLoadMessageBoxTitle), ExtContentMessages.GetMessageString(EMessageType.ImageFileFailedToLoadMessageBoxBody));
				}
			}
			if (flag5 && _texture2DScaledSource != null)
			{
				int rotationCountTo = _imageSpecLoaded.GetRotationCountTo(_imageSpec.RotationIndex);
				if (rotationCountTo != 0)
				{
					float curParentW = _texture2DScaledSource.width;
					float curParentH = _texture2DScaledSource.height;
					_texture2DScaledSource = ExtContentTextureUtils.RotateTexture2D(_texture2DScaledSource, rotationCountTo);
					_imageSpec.SelectionArea.Renormalise(curParentW, curParentH, _texture2DScaledSource.width, _texture2DScaledSource.height);
					_imageSpec.SelectionArea.RotateWithinParentMaintainingAspectRatio((float)_texture2DScaledSource.width / (float)_texture2DScaledSource.height, rotationCountTo);
					flag6 = true;
				}
			}
			if (flag6 && !IsImageSpecSelectionAreaValidForAspectRatio())
			{
				ResetImageSpecSelectionAreaForAspectRatio();
			}
			_texture2DSelectedArea = ExtContentTextureUtils.CreateTexture2DForSelectionArea(_texture2DScaledSource, _imageSpec.SelectionArea);
			if (bForceReload || flag)
			{
				SetFireDelegatePendingTextureChanged();
			}
			UpdateDisplayImageTexture();
			UpdateToggleEditModeButtonDisplay();
			UpdateResetImageButtonDisplay();
			UpdateRotateImageButtonsDisplay();
			_imageSpecLoaded.UpdateFrom(_imageSpec);
		}

		public void SetDisplayAspectRatio(float displayAspectRatio, bool bForce = false)
		{
			bool flag = _displayAspectRatio != displayAspectRatio;
			if (flag || bForce)
			{
				_displayAspectRatio = displayAspectRatio;
				ResizeGameObjectToFitParentMaintainingAspectRatio();
				if (flag)
				{
					_imageSpec.SelectionArea.Invalidate();
				}
				OnImageSpecChanged(bForce);
			}
		}

		private void ResizeGameObjectToFitParentMaintainingAspectRatio()
		{
			if (_gameObjectResizeForTarget != null)
			{
				float aspectRatio = _displayAspectRatio;
				if (EditModeOn && _texture2DScaledSource != null)
				{
					float num = _texture2DScaledSource.width;
					float num2 = _texture2DScaledSource.height;
					aspectRatio = num / num2;
				}
				ExtContentTextureUtils.ResizeGameObjectToFitParentMaintainingAspectRatio(_gameObjectResizeForTarget, aspectRatio);
			}
		}

		private bool IsImageSpecSelectionAreaValidForAspectRatio()
		{
			bool result = false;
			if (_imageSpec.SelectionArea.IsValid() && _texture2DScaledSource != null)
			{
				float num = _texture2DScaledSource.width;
				float num2 = _texture2DScaledSource.height;
				if (MathUtils.Approximately(_imageSpec.SelectionArea.W * num / (_imageSpec.SelectionArea.H * num2), _displayAspectRatio, 0.0001f))
				{
					float outTargetW = 0f;
					float outTargetH = 0f;
					ExtContentTextureUtils.ScaleDimensionsToFitParentMaintainingAspectRatio(_displayAspectRatio, num, num2, ref outTargetW, ref outTargetH);
					if (_imageSpec.SelectionArea.W <= outTargetW && _imageSpec.SelectionArea.H <= outTargetH && _imageSpec.SelectionArea.IsCentreValidForSize())
					{
						result = true;
					}
				}
			}
			return result;
		}

		private void ResetImageSpecSelectionAreaForAspectRatio()
		{
			if (_texture2DScaledSource != null)
			{
				float num = _texture2DScaledSource.width;
				float num2 = _texture2DScaledSource.height;
				_imageSpec.SelectionArea.ScaleToFitAspectRatios(num / num2, _displayAspectRatio);
				if (_editModeCursor != null)
				{
					_editModeCursor.UpdateSelectionAreaCoordsForAspectRatio(_displayAspectRatio, _imageSpec.SelectionArea);
				}
			}
		}

		private void UpdateDisplayImageTexture()
		{
			Texture2D currentDisplayTexture2D = GetCurrentDisplayTexture2D();
			UpdateDisplayImageTexture(currentDisplayTexture2D, _bScaleImageToCompletelyFillParent && !_bEditModeOn);
		}

		private void UpdateDisplayImageTexture(Texture2D texture2D, bool bScaleToCompletelyFillParent)
		{
			ExtContentTextureUtils.UpdateImageTexture(ref _imageTexture, texture2D, bScaleToCompletelyFillParent);
			SetFireDelegatePendingDisplayChanged();
		}

		public Texture2D GetSelectedAreaTexture2D()
		{
			return _texture2DSelectedArea;
		}

		private Texture2D GetCurrentDisplayTexture2D()
		{
			Texture2D texture2D = null;
			if (_bEditModeOn)
			{
				return _texture2DScaledSource;
			}
			return (_texture2DSelectedArea != null) ? _texture2DSelectedArea : _texture2DScaledSource;
		}

		private void OnChooseTextureButton()
		{
			ExtContentUIUtils.CallOpenFileBrowserFunction(OnChooseTextureButtonImpl);
		}

		private void OnChooseTextureButtonImpl()
		{
			string text = string.Empty;
			bool flag = false;
			if (!ExtContentUIUtils.IsTextureFileResetModifierActive())
			{
				string promptStr = _devTextSelectTextureTitle;
				if (!_locTextSelectTextureTitle.Term.IsNullOrEmpty())
				{
					promptStr = _locTextSelectTextureTitle.Translation;
				}
				text = ExtContentUIUtils.PromptUserForImageFileSpec(promptStr, _imageSpec.FileSpec, _supportedTextureFileExtensions);
				if (!text.IsNullOrEmpty())
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				_imageSpecLoaded.Reset();
				_imageSpec.SetFromFileSpec(text);
				_imageSpec.SelectionArea.Invalidate();
				_imageSpec.RotationIndex = 0;
				OnImageSpecChanged(bForceReload: true);
			}
		}

		private void OnResetTextureButton()
		{
			_imageSpecLoaded.Reset();
			_imageSpec.SetFromFileSpec(string.Empty);
			_imageSpec.SelectionArea.Invalidate();
			_imageSpec.RotationIndex = 0;
			OnImageSpecChanged(bForceReload: true);
		}

		private void OnRotateImageCWButton()
		{
			_imageSpec.IncrementRotationIndex(1);
			OnImageSpecChanged();
		}

		private void OnRotateImageCCWButton()
		{
			_imageSpec.IncrementRotationIndex(-1);
			OnImageSpecChanged();
		}

		private void OnToggleEditModeButton()
		{
			ToggleEditMode();
		}

		private bool IsEditModeAllowed()
		{
			if (IsEditModeAllowedInternal())
			{
				return IsEditModeAllowedExternal();
			}
			return false;
		}

		private bool IsEditModeAllowedInternal()
		{
			bool result = false;
			if (_texture2DScaledSource != null)
			{
				result = true;
			}
			return result;
		}

		private bool IsEditModeAllowedExternal()
		{
			return _bEditModeAllowedExternal;
		}

		private void SetEditMode(bool bSet, bool bForce = false)
		{
			bSet = bSet && IsEditModeAllowed();
			bool flag = _bEditModeOn != bSet;
			if (flag || bForce)
			{
				_bEditModeOn = bSet;
				if (_buttonChooseTexture != null)
				{
					_buttonChooseTexture.gameObject.SetActive(!_bEditModeOn);
				}
				if (_buttonChooseTextureImage != null)
				{
					_buttonChooseTextureImage.gameObject.SetActive(!_bEditModeOn);
				}
				if (_buttonResetTextureImage != null)
				{
					_buttonResetTextureImage.gameObject.SetActive(!_bEditModeOn);
				}
				ResizeGameObjectToFitParentMaintainingAspectRatio();
				SetEditModeCursorActive(_bEditModeOn);
				UpdateToggleEditModeButtonDisplay();
				UpdateResetImageButtonDisplay();
				UpdateRotateImageButtonsDisplay();
				if (flag)
				{
					OnEditModeChanged();
				}
			}
		}

		private void OnEditModeChanged()
		{
			if (!_bEditModeOn && _editModeCursor != null)
			{
				ImageSelectionArea normalisedSelectionArea = _editModeCursor.GetNormalisedSelectionArea();
				_imageSpec.SelectionArea = normalisedSelectionArea;
				_texture2DSelectedArea = ExtContentTextureUtils.CreateTexture2DForSelectionArea(_texture2DScaledSource, _imageSpec.SelectionArea);
			}
			UpdateDisplayImageTexture();
			if (_onEditModeStatusChangedCallback != null)
			{
				_onEditModeStatusChangedCallback();
			}
		}

		public bool IsMouseOverUI()
		{
			Vector2 screenPoint = Input.mousePosition;
			return RectTransformUtility.RectangleContainsScreenPoint(_imageTexture.GetComponent<RectTransform>(), screenPoint);
		}

		private void SetEditModeCursorActive(bool bSet)
		{
			if (bSet && _editModeCursor == null)
			{
				CreateEditModeCursor();
			}
			if (_editModeCursor != null)
			{
				_editModeCursor.CursorActive = bSet;
			}
		}

		private void CreateEditModeCursor()
		{
			if (_editModeCursor == null)
			{
				ExtContentMessages.LogDebug($"Creating edit mode cursor ...");
				_editModeCursor = new SelectableImageCursor();
				_editModeCursor.Init(_imageTexture, _displayAspectRatio, _imageSpec.SelectionArea, _texture2DScaledSource.width, _texture2DScaledSource.height);
			}
		}

		private void DestroyEditModeCursor()
		{
			if (_editModeCursor != null)
			{
				ExtContentMessages.LogDebug($"Destroying edit mode cursor ...");
				_editModeCursor.DeInit();
				_editModeCursor = null;
			}
		}

		private void UpdateToggleEditModeButtonDisplay()
		{
			if (_buttonToggleEditMode != null)
			{
				_buttonToggleEditMode.gameObject.SetActive(IsEditModeAllowedInternal());
				ExtContentUIUtils.SetSelectableSelectability(_buttonToggleEditMode, _bCanInteract && IsEditModeAllowedExternal(), _bEditModeOn);
			}
		}

		private void UpdateResetImageButtonDisplay()
		{
			if (_buttonResetTextureImage != null)
			{
				_buttonResetTextureImage.gameObject.SetActive(!_bEditModeOn);
				ExtContentUIUtils.SetSelectableInteractable(_buttonResetTextureImage, _bCanInteract && !_imageSpec.FileSpec.IsNullOrEmpty());
			}
		}

		private void UpdateRotateImageButtonsDisplay()
		{
			if (_buttonRotateImageCW != null)
			{
				_buttonRotateImageCW.gameObject.SetActive(!_bEditModeOn);
				ExtContentUIUtils.SetSelectableSelectability(_buttonRotateImageCW, _bCanInteract && !_imageSpec.FileSpec.IsNullOrEmpty(), bIsSelected: false);
			}
			if (_buttonRotateImageCCW != null)
			{
				_buttonRotateImageCCW.gameObject.SetActive(!_bEditModeOn);
				ExtContentUIUtils.SetSelectableSelectability(_buttonRotateImageCCW, _bCanInteract && !_imageSpec.FileSpec.IsNullOrEmpty(), bIsSelected: false);
			}
		}
	}
}
