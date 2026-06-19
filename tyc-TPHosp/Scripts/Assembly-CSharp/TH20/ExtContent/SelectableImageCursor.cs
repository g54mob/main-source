using System;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.ExtContent
{
	[DontSave]
	public class SelectableImageCursor
	{
		private enum CursorEditMode
		{
			Unititialised = 0,
			None = 1,
			Moving = 2,
			Resizing = 3
		}

		private enum Corner
		{
			TL = 0,
			BL = 1,
			TR = 2,
			BR = 3,
			NumCorners = 4,
			None = 5
		}

		private enum ResizeControl
		{
			TL = 0,
			BL = 1,
			TR = 2,
			BR = 3,
			NumControls = 4,
			None = 5
		}

		private enum LineJustification
		{
			CentreV = 0,
			CentreH = 1,
			T = 2,
			B = 3,
			L = 4,
			R = 5
		}

		private const float cDefaultCursorTextureSize = 256f;

		private const float cDebugIncrAmt = 1f;

		private const float cMinSelectionAreaSize = 40f;

		private const int cDottedLineRepeatCount = 20;

		private const int cDottedLineSolidCount = 15;

		private const int cCursorEditBoxControlSizeDraw = 20;

		private const int cCursorEditBoxControlSizeInputDetect = 30;

		private const int cCursorEditBoxControlDetectMargin = 10;

		private const int cCursorEditCornerControlSizeDraw = 20;

		private const int cCursorEditCornerControlSizeInputDetect = 40;

		private const int cSelectionAreaLineThickness = 5;

		private const int cBoxControlLineThicknessDefault = 5;

		private const int cBoxControlLineThicknessMouseOver = 6;

		private const int cCornerControlLineThicknessDefault = 8;

		private const int cCornerControlLineThicknessMouseOver = 9;

		private const float cClrAplhaSelectionArea = 0.4f;

		private const float cClrAplhaSelectionGrabbed = 0.65f;

		private const float cClrAplhaControl = 0.75f;

		private Color cClrSelectionAreaDefault = new Color(0.9f, 0.9f, 0.9f, 0.4f);

		private Color cClrSelectionAreaGrabbed = new Color(1f, 1f, 1f, 0.65f);

		private Color cClrControlDefault = new Color(0f, 0.8f, 0f, 0.75f);

		private Color cClrControlMouseOver = new Color(0f, 1f, 0f, 1f);

		private Color cClrControlGrabbed = new Color(0f, 1f, 0f, 1f);

		private bool _bCursorActive;

		private float _cursorSelX;

		private float _cursorSelY;

		private float _cursorSelW;

		private float _cursorSelH;

		private float _parentTextureW;

		private float _parentTextureH;

		private float _cursorImageW;

		private float _cursorImageH;

		private int _iCursorImageW;

		private int _iCursorImageH;

		private float _cursorSelXSaved;

		private float _cursorSelYSaved;

		private float _cursorSelWSaved;

		private float _cursorSelHSaved;

		private GameObject _gameObjectEditModeCursor;

		private Image _imageBaseTexture;

		private Image _imageEditModeCursor;

		private Texture2D _texture2DEditModeCursor;

		private Sprite _spriteEditModeCursor;

		private RectTransform _imageRectTransform;

		private Rect _imageScreenSpaceRect;

		private bool _bSetFitEditModeCursorToParentPending;

		private bool _bMouseWithinMoveControl;

		private bool _bMouseWithinAnyResizeControl;

		private bool[] _bMouseWithinResizeControl;

		private bool _bSelectionAreaGrabbed;

		private Vector2 _grabbedControlOffset;

		private ResizeControl _resizeControlGrabbed;

		private float _targetAspectRatio;

		private float _screenToImageSpaceFactor;

		private CursorEditMode _cursorEditMode;

		private ImageSelectionArea _normalisedSelectionArea;

		public bool CursorActive
		{
			get
			{
				return _bCursorActive;
			}
			set
			{
				_bCursorActive = value;
				OnSetCursorActive();
			}
		}

		public SelectableImageCursor()
		{
			_normalisedSelectionArea = new ImageSelectionArea();
			_bMouseWithinResizeControl = new bool[4];
			_grabbedControlOffset = default(Vector2);
		}

		public void Init(Image imageBaseTexture, float targetAspectRatio, ImageSelectionArea initialNormalisedSelectionArea, float parentTextureW, float parentTextureH)
		{
			_bCursorActive = false;
			_imageBaseTexture = imageBaseTexture;
			_parentTextureW = parentTextureW;
			_parentTextureH = parentTextureH;
			float num = _parentTextureW / _parentTextureH;
			if (_parentTextureW < _parentTextureH)
			{
				_cursorImageW = 256f;
				_cursorImageH = _cursorImageW / num;
			}
			else
			{
				_cursorImageH = 256f;
				_cursorImageW = _cursorImageH * num;
			}
			_iCursorImageW = (int)_cursorImageW;
			_iCursorImageH = (int)_cursorImageH;
			_gameObjectEditModeCursor = UnityEngine.Object.Instantiate(_imageBaseTexture.gameObject, _imageBaseTexture.gameObject.transform, worldPositionStays: true);
			_gameObjectEditModeCursor.transform.SetAsLastSibling();
			_imageEditModeCursor = _gameObjectEditModeCursor.GetComponent<Image>();
			_imageEditModeCursor.raycastTarget = true;
			UpdateEditModeCursorTransformData();
			SetFitEditModeCursorToParentPending();
			UpdateSelectionAreaCoordsForAspectRatio(targetAspectRatio, initialNormalisedSelectionArea);
			ClearCursorTexture();
		}

		public void DeInit()
		{
			UnityEngine.Object.Destroy(_gameObjectEditModeCursor);
			_gameObjectEditModeCursor = null;
			_imageEditModeCursor = null;
			_spriteEditModeCursor = null;
			_texture2DEditModeCursor = null;
		}

		public ImageSelectionArea GetNormalisedSelectionArea()
		{
			ImageSelectionArea imageSelectionArea = new ImageSelectionArea();
			imageSelectionArea.UpdateFrom(_normalisedSelectionArea);
			return imageSelectionArea;
		}

		public void UpdateSelectionAreaCoordsForAspectRatio(float targetAspectRatio, ImageSelectionArea normalisedSelectionArea)
		{
			UpdateCursorTexture2D();
			UpdateCursorSprite();
			SetTargetAspectRatio(targetAspectRatio);
			_normalisedSelectionArea.UpdateFrom(normalisedSelectionArea);
			_cursorSelX = _normalisedSelectionArea.CentreX * _cursorImageW;
			_cursorSelW = _normalisedSelectionArea.W * _cursorImageW;
			_cursorSelY = _normalisedSelectionArea.CentreY * _cursorImageH;
			_cursorSelH = _normalisedSelectionArea.H * _cursorImageH;
			OnSelectionAreaChanged();
			SaveCurrentSelectionArea();
			CheckResetInvalidSelectionArea();
		}

		private void SetTargetAspectRatio(float targetAspectRatio)
		{
			_targetAspectRatio = targetAspectRatio;
		}

		public void Update()
		{
			if (_bCursorActive && !ExtContentMessages.MessageBox.IsVisibleOrClosing)
			{
				ProcessCursorEditModeInputs();
				ProcessCursorEditMode();
				ProcessFitEditModeCursorToParentPending();
				DrawSelectionArea();
			}
		}

		private void CheckResetInvalidSelectionArea()
		{
			if (!IsSelectionAreaValid())
			{
				ResetSelectionArea();
			}
		}

		private void ResetSelectionArea()
		{
			ExtContentTextureUtils.ScaleDimensionsToFitParentMaintainingAspectRatio(_targetAspectRatio, _cursorImageW, _cursorImageH, ref _cursorSelW, ref _cursorSelH);
			_cursorSelX = _cursorImageW * 0.5f;
			_cursorSelY = _cursorImageH * 0.5f;
			OnSelectionAreaChanged();
		}

		private void SaveCurrentSelectionArea()
		{
			_cursorSelXSaved = _cursorSelX;
			_cursorSelYSaved = _cursorSelY;
			_cursorSelWSaved = _cursorSelW;
			_cursorSelHSaved = _cursorSelH;
		}

		private void CheckSelectionAreaChanged()
		{
			if (_cursorSelX != _cursorSelXSaved || _cursorSelY != _cursorSelYSaved || _cursorSelW != _cursorSelWSaved || _cursorSelH != _cursorSelHSaved)
			{
				OnSelectionAreaChanged();
				SaveCurrentSelectionArea();
			}
		}

		private void OnSelectionAreaChanged()
		{
			_normalisedSelectionArea.Set(Mathf.Clamp(_cursorSelX / _cursorImageW, 0f, 1f), Mathf.Clamp(_cursorSelY / _cursorImageH, 0f, 1f), Mathf.Clamp(_cursorSelW / _cursorImageW, 0f, 1f), Mathf.Clamp(_cursorSelH / _cursorImageH, 0f, 1f));
		}

		private void ClipOffsetsToImageSize(float centreX, float centreY, ref float offsetX, ref float offsetY)
		{
			float num = ((offsetX >= 0f) ? 1f : (-1f));
			float num2 = ((offsetY >= 0f) ? 1f : (-1f));
			int num3 = 0;
			bool flag = false;
			while (!flag)
			{
				int num4 = (int)offsetX;
				int num5 = (int)offsetY;
				if (centreX + offsetX > _cursorImageW)
				{
					offsetX = _cursorImageW - centreX;
					offsetY = Mathf.Abs(offsetX) / _targetAspectRatio * num2;
				}
				else if (centreX + offsetX < 0f)
				{
					offsetX = 0f - centreX;
					offsetY = Mathf.Abs(offsetX) / _targetAspectRatio * num2;
				}
				if (centreY + offsetY > _cursorImageH)
				{
					offsetY = _cursorImageH - centreY;
					offsetX = Mathf.Abs(offsetY) * _targetAspectRatio * num;
				}
				else if (centreY + offsetY < 0f)
				{
					offsetY = 0f - centreY;
					offsetX = Mathf.Abs(offsetY) * _targetAspectRatio * num;
				}
				if ((int)offsetX != num4 || (int)offsetY != num5)
				{
					num3++;
					if (num3 >= 4)
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
			}
		}

		private void SetSelectionAreaWForResizeControl(float inControlPointX, float inControlPointY, ResizeControl resizeControl)
		{
			float num = inControlPointX - _cursorSelX;
			float num2 = inControlPointY - _cursorSelY;
			float num3 = ((num >= 0f) ? 1f : (-1f));
			float num4 = ((num2 >= 0f) ? 1f : (-1f));
			float offsetX = num;
			float offsetY = num2;
			if (Mathf.Abs(num / num2) > _targetAspectRatio)
			{
				offsetY = Mathf.Abs(offsetX) / _targetAspectRatio * num4;
			}
			else
			{
				offsetX = Mathf.Abs(offsetY) * _targetAspectRatio * num3;
			}
			ClipOffsetsToImageSize(_cursorSelX, _cursorSelY, ref offsetX, ref offsetY);
			float cursorSelX = _cursorSelX;
			float cursorSelY = _cursorSelY;
			float num5 = offsetX * 2f;
			float f = num5 / _targetAspectRatio;
			float num6 = Mathf.Abs(num5);
			float num7 = Mathf.Abs(f);
			float num8 = 0f;
			float num9 = 0f;
			switch (resizeControl)
			{
			case ResizeControl.TL:
				num8 = -1f;
				num9 = 1f;
				break;
			case ResizeControl.BL:
				num8 = -1f;
				num9 = -1f;
				break;
			case ResizeControl.TR:
				num8 = 1f;
				num9 = 1f;
				break;
			case ResizeControl.BR:
				num8 = 1f;
				num9 = -1f;
				break;
			}
			bool flag = num3 == num8 && num4 == num9 && Mathf.Abs(offsetX) * 2f >= 40f && Mathf.Abs(offsetY) * 2f >= 40f;
			bool num10 = Mathf.Abs(offsetX) * 2f >= 40f && Mathf.Abs(offsetY) * 2f >= 40f;
			bool flag2 = IsSelectionAreaValid(_cursorSelX, _cursorSelY, num6, num7);
			if (num10)
			{
				if (!flag2)
				{
					if (flag)
					{
						float offsetX2 = 0f - offsetX;
						float offsetY2 = 0f - offsetY;
						ClipOffsetsToImageSize(_cursorSelX, _cursorSelY, ref offsetX2, ref offsetY2);
						float num11 = _cursorSelX + offsetX;
						float num12 = _cursorSelY + offsetY;
						float num13 = _cursorSelX + offsetX2;
						float num14 = _cursorSelY + offsetY2;
						num5 = num11 - num13;
						f = num12 - num14;
						cursorSelX = num13 + num5 * 0.5f;
						cursorSelY = num14 + f * 0.5f;
						num6 = Mathf.Abs(num5);
						num7 = Mathf.Abs(f);
						if (IsSelectionAreaValid(cursorSelX, cursorSelY, num6, num7))
						{
							_cursorSelW = num6;
							_cursorSelH = num7;
							_cursorSelX = cursorSelX;
							_cursorSelY = cursorSelY;
						}
					}
				}
				else if (IsSelectionAreaValid(_cursorSelX, _cursorSelY, num6, num7))
				{
					_cursorSelW = num6;
					_cursorSelH = num7;
				}
			}
			else
			{
				SetCursorSelWHToMinSizeForAspectRatio();
			}
			CheckSelectionAreaChanged();
		}

		private void SetCursorSelWHToMinSizeForAspectRatio()
		{
			if (_targetAspectRatio > 1f)
			{
				_cursorSelH = 40f;
				_cursorSelW = _cursorSelH * _targetAspectRatio;
			}
			else
			{
				_cursorSelW = 40f;
				_cursorSelH = _cursorSelW / _targetAspectRatio;
			}
		}

		private void GetWHForNewW(ref float newW, ref float newH)
		{
			newH = _cursorSelH;
			newH = newW / _targetAspectRatio;
		}

		private void GetWHForNewH(ref float newW, ref float newH)
		{
			newW = _cursorSelW;
			newW = newH * _targetAspectRatio;
		}

		private bool SetSelectionAreaW(float newW)
		{
			bool result = false;
			float newH = 0f;
			GetWHForNewW(ref newW, ref newH);
			if (IsSelectionAreaValid(_cursorSelX, _cursorSelY, newW, newH))
			{
				_cursorSelW = newW;
				_cursorSelH = newH;
				CheckSelectionAreaChanged();
				result = true;
			}
			return result;
		}

		private bool SetSelectionAreaH(float newH)
		{
			bool result = false;
			float newW = 0f;
			GetWHForNewH(ref newW, ref newH);
			if (IsSelectionAreaValid(_cursorSelX, _cursorSelY, newW, newH))
			{
				_cursorSelW = newW;
				_cursorSelH = newH;
				CheckSelectionAreaChanged();
				result = true;
			}
			return result;
		}

		private void SetSelectionAreaXY(float newX, float newY)
		{
			_cursorSelX = newX;
			_cursorSelY = newY;
			ValidateSelectionAreaPositionChange();
			CheckSelectionAreaChanged();
		}

		private bool IsSelectionAreaValid()
		{
			return IsSelectionAreaValid(_cursorSelX, _cursorSelY, _cursorSelW, _cursorSelH);
		}

		private bool IsSelectionAreaValid(float selX, float selY, float selW, float selH)
		{
			bool flag = true;
			if (flag)
			{
				if (selW < 40f)
				{
					flag = false;
				}
				else if (selW > _cursorImageW)
				{
					flag = false;
				}
				if (selH < 40f)
				{
					flag = false;
				}
				else if (selH > _cursorImageH)
				{
					flag = false;
				}
			}
			if (flag)
			{
				float num = selW * 0.5f;
				float num2 = selH * 0.5f;
				if (selX - num < 0f)
				{
					flag = false;
				}
				else if (selX + num > _cursorImageW)
				{
					flag = false;
				}
				if (selY - num2 < 0f)
				{
					flag = false;
				}
				else if (selY + num2 > _cursorImageH)
				{
					flag = false;
				}
			}
			if (flag && !MathUtils.Approximately(selW / selH, _targetAspectRatio, 0.0001f))
			{
				flag = false;
			}
			return flag;
		}

		private bool ValidateSelectionAreaPositionChange()
		{
			float cursorSelX = _cursorSelX;
			float cursorSelY = _cursorSelY;
			float num = _cursorSelW * 0.5f;
			float num2 = _cursorSelH * 0.5f;
			if (_cursorSelX - num < 0f)
			{
				_cursorSelX = num;
			}
			else if (_cursorSelX + num > _cursorImageW)
			{
				_cursorSelX = _cursorImageW - num;
			}
			if (_cursorSelY - num2 < 0f)
			{
				_cursorSelY = num2;
			}
			else if (_cursorSelY + num2 > _cursorImageH)
			{
				_cursorSelY = _cursorImageH - num2;
			}
			if (_cursorSelX == cursorSelX)
			{
				return _cursorSelY != cursorSelY;
			}
			return true;
		}

		private bool ValidateSelectionArea()
		{
			float cursorSelW = _cursorSelW;
			float cursorSelH = _cursorSelH;
			bool bAmendedW = false;
			bool bAmendedH = false;
			if (_cursorSelW < 40f)
			{
				_cursorSelW = 40f;
				bAmendedW = true;
			}
			else if (_cursorSelW > _cursorImageW)
			{
				_cursorSelW = _cursorImageW;
				bAmendedW = true;
			}
			if (_cursorSelH < 40f)
			{
				_cursorSelH = 40f;
				bAmendedH = true;
			}
			else if (_cursorSelH > _cursorImageH)
			{
				_cursorSelH = _cursorImageH;
				bAmendedH = true;
			}
			CheckSelectionMaintainAspectRatio(bAmendedW, bAmendedH);
			bAmendedW = false;
			bAmendedH = false;
			float num = _cursorSelW * 0.5f;
			if (_cursorSelX - num < 0f)
			{
				_cursorSelW = _cursorSelX * 2f;
				bAmendedW = true;
			}
			else if (_cursorSelX + num > _cursorImageW)
			{
				_cursorSelW = (_cursorImageW - _cursorSelX) * 2f;
				bAmendedW = true;
			}
			float num2 = _cursorSelH * 0.5f;
			if (_cursorSelY - num2 < 0f)
			{
				_cursorSelH = _cursorSelY * 2f;
				bAmendedH = true;
			}
			else if (_cursorSelY + num2 > _cursorImageH)
			{
				_cursorSelH = (_cursorImageH - _cursorSelY) * 2f;
				bAmendedH = true;
			}
			CheckSelectionMaintainAspectRatio(bAmendedW, bAmendedH);
			if (_cursorSelW == cursorSelW)
			{
				return _cursorSelH != cursorSelH;
			}
			return true;
		}

		private void CheckSelectionMaintainAspectRatio(bool bAmendedW, bool bAmendedH)
		{
			if (bAmendedW)
			{
				_cursorSelH = _cursorSelW / _targetAspectRatio;
			}
			else if (bAmendedH)
			{
				_cursorSelW = _cursorSelH * _targetAspectRatio;
			}
		}

		private void SetFitEditModeCursorToParentPending(bool bSet = true)
		{
			_bSetFitEditModeCursorToParentPending = bSet;
		}

		private void ProcessFitEditModeCursorToParentPending()
		{
			if (_bSetFitEditModeCursorToParentPending)
			{
				ExtContentTextureUtils.FitGameObjectToParent(_gameObjectEditModeCursor);
				UpdateEditModeCursorTransformData();
				_bSetFitEditModeCursorToParentPending = false;
			}
		}

		private void UpdateEditModeCursorTransformData()
		{
			if (_gameObjectEditModeCursor != null)
			{
				_imageRectTransform = _gameObjectEditModeCursor.GetComponent<RectTransform>();
				if (_imageRectTransform != null)
				{
					_imageScreenSpaceRect = _imageRectTransform.GetScreenSpaceRect();
					_screenToImageSpaceFactor = _cursorImageW / _imageScreenSpaceRect.width;
				}
			}
		}

		private void UpdateCursorTexture2D()
		{
			_texture2DEditModeCursor = new Texture2D(_iCursorImageW, _iCursorImageH, TextureFormat.ARGB32, mipChain: false);
		}

		private void UpdateCursorSprite()
		{
			_spriteEditModeCursor = ExtContentTextureUtils.CreateTextureSprite(_texture2DEditModeCursor);
			if (_spriteEditModeCursor != null)
			{
				_imageEditModeCursor.overrideSprite = _spriteEditModeCursor;
			}
		}

		private void OnSetCursorActive()
		{
			_gameObjectEditModeCursor.SetActive(_bCursorActive);
			if (_bCursorActive)
			{
				_cursorEditMode = CursorEditMode.Unititialised;
				SetCursorEditMode(CursorEditMode.None);
			}
		}

		private void ClearCursorTexture()
		{
			Color color = new Color(0f, 0f, 0f, 0f);
			for (int i = 0; i < _iCursorImageW; i++)
			{
				for (int j = 0; j < _iCursorImageH; j++)
				{
					_texture2DEditModeCursor.SetPixel(i, j, color);
				}
			}
			_texture2DEditModeCursor.Apply();
		}

		private bool IsPointWithinImage(int x, int y)
		{
			bool result = false;
			if (x >= 0 && x < _iCursorImageW && y >= 0 && y < _iCursorImageH)
			{
				result = true;
			}
			return result;
		}

		private Vector2 GetMousePos()
		{
			Vector2 result = Input.mousePosition;
			result.y = (float)Screen.height - result.y;
			return result;
		}

		private Vector2 GetImageSpaceMousePos()
		{
			Vector2 vector = Input.mousePosition;
			vector.y = (float)Screen.height - vector.y;
			float x = (vector.x - _imageScreenSpaceRect.x) * _screenToImageSpaceFactor;
			float num = (vector.y - _imageScreenSpaceRect.y) * _screenToImageSpaceFactor;
			num = _cursorImageH - num;
			return new Vector2(x, num);
		}

		private bool IsMouseWithinImageArea()
		{
			return _imageScreenSpaceRect.Contains(GetMousePos());
		}

		private void ProcessTestInputs()
		{
			if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
			{
				return;
			}
			bool flag = false;
			if (IsMouseWithinImageArea())
			{
				if (Input.GetMouseButton(1))
				{
					SetSelectionAreaW(_cursorSelW - 1f);
					flag = true;
				}
				else if (Input.GetMouseButton(0))
				{
					SetSelectionAreaW(_cursorSelW + 1f);
					flag = true;
				}
				if (flag)
				{
					ValidateSelectionArea();
					CheckSelectionAreaChanged();
				}
			}
		}

		private void ProcessCursorEditModeInputs()
		{
			UpdateMouseWithinControlsFlags();
			switch (_cursorEditMode)
			{
			case CursorEditMode.None:
				if (Input.GetMouseButtonDown(0))
				{
					if (_bMouseWithinMoveControl)
					{
						SetCursorEditMode(CursorEditMode.Moving);
					}
					else if (_bMouseWithinAnyResizeControl)
					{
						SetCursorEditMode(CursorEditMode.Resizing);
					}
				}
				break;
			case CursorEditMode.Moving:
			case CursorEditMode.Resizing:
				if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0))
				{
					SetCursorEditMode(CursorEditMode.None);
				}
				break;
			}
		}

		private void SetCursorEditMode(CursorEditMode newCursorEditMode)
		{
			if (_cursorEditMode == newCursorEditMode)
			{
				return;
			}
			switch (_cursorEditMode)
			{
			}
			_cursorEditMode = newCursorEditMode;
			_bSelectionAreaGrabbed = false;
			_resizeControlGrabbed = ResizeControl.None;
			_grabbedControlOffset.x = 0f;
			_grabbedControlOffset.y = 0f;
			switch (_cursorEditMode)
			{
			case CursorEditMode.Moving:
				_bSelectionAreaGrabbed = true;
				UpdateGrabbedMoveControlOffset();
				break;
			case CursorEditMode.Resizing:
			{
				_bSelectionAreaGrabbed = true;
				int i = 0;
				for (int num = 4; i < num; i++)
				{
					if (_bMouseWithinResizeControl[i])
					{
						_resizeControlGrabbed = (ResizeControl)i;
						break;
					}
				}
				UpdateGrabbedResizeControlOffset();
				break;
			}
			case CursorEditMode.None:
				break;
			}
		}

		private void ProcessCursorEditMode()
		{
			CursorEditMode cursorEditMode = _cursorEditMode;
			if (cursorEditMode != CursorEditMode.None && (uint)(cursorEditMode - 2) <= 1u)
			{
				Vector2 imageSpaceMousePos = GetImageSpaceMousePos();
				imageSpaceMousePos -= _grabbedControlOffset;
				switch (_cursorEditMode)
				{
				case CursorEditMode.Moving:
					SetSelectionAreaXY(imageSpaceMousePos.x, imageSpaceMousePos.y);
					break;
				case CursorEditMode.Resizing:
					SetSelectionAreaWForResizeControl(imageSpaceMousePos.x, imageSpaceMousePos.y, _resizeControlGrabbed);
					break;
				}
			}
		}

		private void UpdateGrabbedResizeControlOffset()
		{
			float retX = 0f;
			float retY = 0f;
			GetSelectionResizeControlXY(_resizeControlGrabbed, ref retX, ref retY);
			Vector2 imageSpaceMousePos = GetImageSpaceMousePos();
			_grabbedControlOffset.x = imageSpaceMousePos.x - retX;
			_grabbedControlOffset.y = imageSpaceMousePos.y - retY;
		}

		private void UpdateGrabbedMoveControlOffset()
		{
			Vector2 imageSpaceMousePos = GetImageSpaceMousePos();
			_grabbedControlOffset.x = imageSpaceMousePos.x - _cursorSelX;
			_grabbedControlOffset.y = imageSpaceMousePos.y - _cursorSelY;
		}

		private void UpdateMouseWithinControlsFlags()
		{
			_bMouseWithinAnyResizeControl = false;
			int i = 0;
			for (int num = 4; i < num; i++)
			{
				bool flag = IsMouseWithinResizeControl((ResizeControl)i);
				_bMouseWithinResizeControl[i] = flag;
				if (flag)
				{
					_bMouseWithinAnyResizeControl = true;
				}
			}
			_bMouseWithinMoveControl = false;
			if (!_bMouseWithinAnyResizeControl)
			{
				_bMouseWithinMoveControl = IsMouseWithinSelectionArea(10f);
			}
		}

		private bool IsMouseWithinSelectionArea(float margin = 0f)
		{
			Rect imageSpaceControlRect = new Rect(_cursorSelX - (_cursorSelW * 0.5f - margin), _cursorSelY - (_cursorSelH * 0.5f - margin), _cursorSelW - margin * 2f, _cursorSelH - margin * 2f);
			return IsMouseWithinImageSpaceControlRect(imageSpaceControlRect);
		}

		private bool IsMouseWithinMoveControl()
		{
			float num = 30f;
			float num2 = num * 0.5f;
			Rect imageSpaceControlRect = new Rect(_cursorSelX - num2, _cursorSelY - num2, num, num);
			return IsMouseWithinImageSpaceControlRect(imageSpaceControlRect);
		}

		private bool IsMouseWithinResizeControl(ResizeControl resizeControl)
		{
			bool result = false;
			if (resizeControl != ResizeControl.None)
			{
				float retX = 0f;
				float retY = 0f;
				GetSelectionResizeControlXY(resizeControl, ref retX, ref retY);
				float num = 40f;
				float num2 = num * 0.5f;
				Rect imageSpaceControlRect = new Rect(retX - num2, retY - num2, num, num);
				result = IsMouseWithinImageSpaceControlRect(imageSpaceControlRect);
			}
			return result;
		}

		private Corner ResizeControlToCornerType(ResizeControl resizeControl)
		{
			Corner result = Corner.None;
			switch (resizeControl)
			{
			case ResizeControl.TL:
				result = Corner.TL;
				break;
			case ResizeControl.BL:
				result = Corner.BL;
				break;
			case ResizeControl.TR:
				result = Corner.TR;
				break;
			case ResizeControl.BR:
				result = Corner.BR;
				break;
			}
			return result;
		}

		private ResizeControl CornerTypeToResizeControl(Corner cornerType)
		{
			ResizeControl result = ResizeControl.None;
			switch (cornerType)
			{
			case Corner.TL:
				result = ResizeControl.TL;
				break;
			case Corner.BL:
				result = ResizeControl.BL;
				break;
			case Corner.TR:
				result = ResizeControl.TR;
				break;
			case Corner.BR:
				result = ResizeControl.BR;
				break;
			}
			return result;
		}

		private void GetSelectionResizeControlXY(ResizeControl resizeControl, ref float retX, ref float retY)
		{
			retX = 0f;
			retY = 0f;
			float num = _cursorSelW * 0.5f;
			float num2 = _cursorSelH * 0.5f;
			switch (resizeControl)
			{
			case ResizeControl.TL:
				retX = _cursorSelX - num;
				retY = _cursorSelY + num2;
				break;
			case ResizeControl.BL:
				retX = _cursorSelX - num;
				retY = _cursorSelY - num2;
				break;
			case ResizeControl.TR:
				retX = _cursorSelX + num;
				retY = _cursorSelY + num2;
				break;
			case ResizeControl.BR:
				retX = _cursorSelX + num;
				retY = _cursorSelY - num2;
				break;
			}
		}

		private void GetSelectionCornerXY(Corner cornerType, ref float retX, ref float retY)
		{
			GetSelectionResizeControlXY(CornerTypeToResizeControl(cornerType), ref retX, ref retY);
		}

		private bool IsMouseWithinImageSpaceControlRect(Rect imageSpaceControlRect)
		{
			bool result = false;
			Vector2 imageSpaceMousePos = GetImageSpaceMousePos();
			if (imageSpaceControlRect.Contains(imageSpaceMousePos))
			{
				result = true;
			}
			return result;
		}

		private void DrawSelectionArea()
		{
			Color[] pixels = _texture2DEditModeCursor.GetPixels(0);
			ClearSelectionArea(pixels);
			DrawCross(pixels, (int)_cursorSelX, (int)_cursorSelY, (int)_cursorSelW, (int)_cursorSelH, 1, (!_bSelectionAreaGrabbed) ? cClrSelectionAreaDefault : cClrSelectionAreaGrabbed, bDotted: false);
			DrawSelectionArea(pixels, (int)_cursorSelX, (int)_cursorSelY, (int)_cursorSelW, (int)_cursorSelH, _bSelectionAreaGrabbed);
			DrawBoxControl(pixels, (int)_cursorSelX, (int)_cursorSelY, _bMouseWithinMoveControl, _bSelectionAreaGrabbed && _resizeControlGrabbed == ResizeControl.None, _bSelectionAreaGrabbed);
			int i = 0;
			for (int num = 4; i < num; i++)
			{
				Corner corner = ResizeControlToCornerType((ResizeControl)i);
				if (corner != Corner.None)
				{
					float retX = 0f;
					float retY = 0f;
					GetSelectionCornerXY(corner, ref retX, ref retY);
					DrawCornerControl(pixels, (int)retX, (int)retY, corner, _bMouseWithinResizeControl[i], _resizeControlGrabbed == (ResizeControl)i, _bSelectionAreaGrabbed);
				}
			}
			_texture2DEditModeCursor.SetPixels(pixels, 0);
			_texture2DEditModeCursor.Apply();
		}

		private void ClearSelectionArea(Color[] targetPixels)
		{
			Color color = new Color(0f, 0f, 0f, 0f);
			for (int i = 0; i < _iCursorImageW; i++)
			{
				for (int j = 0; j < _iCursorImageH; j++)
				{
					int num = j * _iCursorImageW + i;
					targetPixels[num] = color;
				}
			}
		}

		private void DrawSelectionArea(Color[] targetPixels, int selX, int selY, int selW, int selH, bool bIsGrabbed)
		{
			DrawBoxOutline(targetPixels, selX, selY, selW, selH, 5, (!bIsGrabbed) ? cClrSelectionAreaDefault : cClrSelectionAreaGrabbed, bDotted: true);
		}

		private void DrawBoxOutline(Color[] targetPixels, int boxX, int boxY, int boxW, int boxH, int lineThickness, Color clr, bool bDotted)
		{
			int num = boxX - boxW / 2;
			int num2 = boxY - boxH / 2;
			DrawLine(targetPixels, num, num2, num + boxW, num2, lineThickness, clr, bDotted, LineJustification.B);
			DrawLine(targetPixels, num, num2 + boxH, num + boxW, num2 + boxH, lineThickness, clr, bDotted, LineJustification.T);
			DrawLine(targetPixels, num, num2, num, num2 + boxH, lineThickness, clr, bDotted, LineJustification.L);
			DrawLine(targetPixels, num + boxW, num2, num + boxW, num2 + boxH, lineThickness, clr, bDotted, LineJustification.R);
		}

		private void DrawCross(Color[] targetPixels, int crossX, int crossY, int crossW, int crossH, int lineThickness, Color clr, bool bDotted)
		{
			int x = crossX - crossW / 2;
			int x2 = crossX + crossW / 2;
			int y = crossY - crossH / 2;
			int y2 = crossY + crossH / 2;
			DrawLine(targetPixels, x, crossY, x2, crossY, lineThickness, clr, bDotted, LineJustification.CentreH);
			DrawLine(targetPixels, crossX, y, crossX, y2, lineThickness, clr, bDotted, LineJustification.CentreV);
		}

		private Color GetControlColour(bool bMouseOver, bool bControlGrabbed, bool bSelAreaGrabbed)
		{
			Color result = cClrControlDefault;
			if (bControlGrabbed)
			{
				result = cClrControlGrabbed;
			}
			else if (bSelAreaGrabbed)
			{
				result = cClrSelectionAreaGrabbed;
			}
			else if (bMouseOver)
			{
				result = cClrControlMouseOver;
			}
			return result;
		}

		private void DrawBoxControl(Color[] targetPixels, int controlX, int controlY, bool bMouseOver, bool bControlGrabbed, bool bSelAreaGrabbed)
		{
			DrawBoxOutline(targetPixels, controlX, controlY, 20, 20, (!bMouseOver || bControlGrabbed) ? 5 : 6, GetControlColour(bMouseOver, bControlGrabbed, bSelAreaGrabbed), bDotted: false);
		}

		private void DrawCornerControl(Color[] targetPixels, int controlX, int controlY, Corner cornerType, bool bMouseOver, bool bControlGrabbed, bool bSelAreaGrabbed)
		{
			int x = 0;
			int y = 0;
			int x2 = 0;
			int y2 = 0;
			LineJustification lineJustification = LineJustification.CentreV;
			LineJustification lineJustification2 = LineJustification.CentreV;
			switch (cornerType)
			{
			case Corner.TL:
				x = controlX;
				y = controlY - 20;
				x2 = controlX + 20;
				y2 = controlY;
				lineJustification = LineJustification.L;
				lineJustification2 = LineJustification.T;
				break;
			case Corner.TR:
				x = controlX - 20;
				y = controlY;
				x2 = controlX;
				y2 = controlY - 20;
				lineJustification = LineJustification.T;
				lineJustification2 = LineJustification.R;
				break;
			case Corner.BR:
				x = controlX;
				y = controlY + 20;
				x2 = controlX - 20;
				y2 = controlY;
				lineJustification = LineJustification.R;
				lineJustification2 = LineJustification.B;
				break;
			case Corner.BL:
				x = controlX + 20;
				y = controlY;
				x2 = controlX;
				y2 = controlY + 20;
				lineJustification = LineJustification.B;
				lineJustification2 = LineJustification.L;
				break;
			}
			int lineThickness = 8;
			if (bControlGrabbed || bMouseOver)
			{
				lineThickness = 9;
			}
			Color controlColour = GetControlColour(bMouseOver, bControlGrabbed, bSelAreaGrabbed);
			DrawLine(targetPixels, controlX, controlY, x, y, lineThickness, controlColour, bDotted: false, lineJustification);
			DrawLine(targetPixels, controlX, controlY, x2, y2, lineThickness, controlColour, bDotted: false, lineJustification2);
		}

		private bool ShouldDrawDottedPixel(int pixelIndex)
		{
			return pixelIndex % 20 < 15;
		}

		private void DrawLine(Color[] targetPixels, int x1, int y1, int x2, int y2, int lineThickness, Color clr, bool bDotted, LineJustification lineJustification)
		{
			int num = lineThickness / 2;
			clr = GetAnimatedColor(clr);
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			bool flag = false;
			switch (lineJustification)
			{
			case LineJustification.CentreH:
				num2 = -num;
				num3 = -num;
				num4 = num;
				num5 = 0;
				flag = true;
				break;
			case LineJustification.CentreV:
				num2 = -num;
				num3 = -num;
				num4 = 0;
				num5 = num;
				flag = false;
				break;
			case LineJustification.T:
				num2 = 0;
				num3 = -lineThickness;
				num4 = 0;
				num5 = 0;
				flag = true;
				break;
			case LineJustification.B:
				num2 = 0;
				num3 = 0;
				num4 = 0;
				num5 = lineThickness;
				flag = true;
				break;
			case LineJustification.L:
				num2 = 0;
				num3 = 0;
				num4 = 0;
				num5 = 0;
				flag = false;
				break;
			case LineJustification.R:
				num2 = -lineThickness;
				num3 = 0;
				num4 = 0;
				num5 = 0;
				flag = false;
				break;
			}
			if (flag)
			{
				if (x2 < x1)
				{
					int num6 = x2;
					x2 = x1;
					x1 = num6;
				}
				int num7 = 0;
				int num8 = num3;
				while (num7 < lineThickness)
				{
					int num9 = x1 + num2;
					int num10 = y1 + num8;
					int num11 = 0;
					while (num9 < x2 + num4)
					{
						bool flag2 = true;
						if (bDotted)
						{
							flag2 = ShouldDrawDottedPixel(num11);
						}
						if (flag2 && IsPointWithinImage(num9, num10))
						{
							int num12 = num10 * _iCursorImageW + num9;
							targetPixels[num12] = clr;
						}
						num9++;
						num11++;
					}
					num7++;
					num8++;
				}
				return;
			}
			if (y2 < y1)
			{
				int num13 = y2;
				y2 = y1;
				y1 = num13;
			}
			int num14 = 0;
			int num15 = num2;
			while (num14 < lineThickness)
			{
				int num16 = y1 + num3;
				int num17 = x1 + num15;
				int num18 = 0;
				while (num16 < y2 + num5)
				{
					bool flag3 = true;
					if (bDotted)
					{
						flag3 = ShouldDrawDottedPixel(num18);
					}
					if (flag3 && IsPointWithinImage(num17, num16))
					{
						int num19 = num16 * _iCursorImageW + num17;
						targetPixels[num19] = clr;
					}
					num16++;
					num18++;
				}
				num14++;
				num15++;
			}
		}

		private Color GetAnimatedColor(Color inClr)
		{
			float num = Mathf.Clamp(Mathf.Sin(Time.unscaledTime % 1.75f / 1.75f * 360f * ((float)Math.PI / 180f)), -0.3f, 0.3f) / 0.3f;
			float[] array = new float[3] { inClr.r, inClr.g, inClr.b };
			for (int i = 0; i < 3; i++)
			{
				if (array[i] < 0.1f)
				{
					array[i] = 0.1f;
				}
				else if (array[i] > 0.9f)
				{
					array[i] = 0.9f;
				}
				array[i] += num * 0.1f;
			}
			Color result = default(Color);
			result.r = Mathf.Clamp(array[0], 0f, 1f);
			result.g = Mathf.Clamp(array[1], 0f, 1f);
			result.b = Mathf.Clamp(array[2], 0f, 1f);
			result.a = inClr.a;
			return result;
		}
	}
}
