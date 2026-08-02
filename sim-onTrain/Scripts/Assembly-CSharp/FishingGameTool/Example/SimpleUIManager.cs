using System;
using FishingGameTool.CustomAttribute;
using FishingGameTool.Fishing;
using FishingGameTool.Fishing.Line;
using FishingGameTool.Fishing.LootData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FishingGameTool.Example
{
	public class SimpleUIManager : MonoBehaviour
	{
		[Serializable]
		public class FishingLineLoadBar
		{
			[InfoBox("A reference to a user interface object that will be enabled or disabled.")]
			public GameObject _UIObject;

			public Transform _loadBar;

			public FillDirection _fillDirection;

			[Space]
			[AddButton("Enable Color Gradient", "_fishingLineLoadBar._enableColorGradient")]
			public bool _enableColorGradient;

			[Space]
			[ShowVariable("_enableColorGradient")]
			[InfoBox("The image in which the color will be changed.")]
			public Image _loadBarImage;

			[ShowVariable("_enableColorGradient")]
			public Color _minLineLoadColor = new Color
			{
				r = 255f,
				g = 255f,
				b = 255f,
				a = 255f
			};

			[ShowVariable("_enableColorGradient")]
			public Color _maxLineLoadColor = new Color
			{
				r = 255f,
				g = 255f,
				b = 255f,
				a = 255f
			};

			[ShowVariable("_enableColorGradient")]
			public Color _overloadLineColor = new Color
			{
				r = 255f,
				g = 255f,
				b = 255f,
				a = 255f
			};
		}

		[Serializable]
		public class CastForceBar
		{
			[InfoBox("A reference to a user interface object that will be enabled or disabled.")]
			public GameObject _UIObject;

			public Transform _castBar;

			public FillDirection _fillDirection;

			[Space]
			[AddButton("Enable Color Gradient", "_castForceBar._enableColorGradient")]
			public bool _enableColorGradient;

			[Space]
			[ShowVariable("_enableColorGradient")]
			[InfoBox("The image in which the color will be changed.")]
			public Image _castBarImage;

			[ShowVariable("_enableColorGradient")]
			public Color _minCastForceColor = new Color
			{
				r = 255f,
				g = 255f,
				b = 255f,
				a = 255f
			};

			[ShowVariable("_enableColorGradient")]
			public Color _maxCastForceColor = new Color
			{
				r = 255f,
				g = 255f,
				b = 255f,
				a = 255f
			};
		}

		[BetterHeader("UI Settings", 20)]
		public FishingSystem _fishingSystem;

		public TMP_Text _lootInfoText;

		public GameObject _FGTMenu;

		[Space]
		public FishingLineLoadBar _fishingLineLoadBar;

		[Space]
		public CastForceBar _castForceBar;

		private FishingLineStatus _lineStatus;

		private bool _showMenu = true;

		private void Awake()
		{
			_lineStatus = _fishingSystem._fishingRod._lineStatus;
		}

		private void Update()
		{
			ControlFishingLineLoadBar();
			ControlCastBar();
			ControlMenu();
		}

		private void ControlMenu()
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				_showMenu = !_showMenu;
			}
			if (_showMenu)
			{
				_FGTMenu.SetActive(value: true);
				Cursor.lockState = CursorLockMode.Confined;
			}
			else
			{
				_FGTMenu.SetActive(value: false);
				Cursor.lockState = CursorLockMode.Locked;
			}
		}

		private void ControlCastBar()
		{
			if (_fishingSystem._advanced._caughtLoot || !_fishingSystem._castInput)
			{
				_castForceBar._UIObject.SetActive(value: false);
				return;
			}
			_castForceBar._UIObject.SetActive(value: true);
			float num = CalculateProgess(_fishingSystem._currentCastForce, _fishingSystem._maxCastForce);
			if (_castForceBar._enableColorGradient)
			{
				Color color = Color32.Lerp(_castForceBar._minCastForceColor, _castForceBar._maxCastForceColor, num);
				_castForceBar._castBarImage.color = color;
			}
			SetBarScale(_castForceBar._fillDirection, _castForceBar._castBar, num);
		}

		private void ControlFishingLineLoadBar()
		{
			if (!_fishingSystem._advanced._caughtLoot)
			{
				_fishingLineLoadBar._UIObject.SetActive(value: false);
				_lootInfoText.gameObject.SetActive(value: false);
				return;
			}
			_lootInfoText.gameObject.SetActive(value: true);
			_fishingLineLoadBar._UIObject.SetActive(value: true);
			ShowLootInfo(_fishingSystem._advanced._caughtLootData, _lootInfoText);
			float num = CalculateProgess(_lineStatus._currentLineLoad, _lineStatus._maxLineLoad);
			if (_fishingLineLoadBar._enableColorGradient)
			{
				Color color = Color32.Lerp(_fishingLineLoadBar._minLineLoadColor, _fishingLineLoadBar._maxLineLoadColor, num);
				if (_lineStatus._currentOverLoad != 0f)
				{
					float t = CalculateProgess(_lineStatus._currentOverLoad, _lineStatus._overLoadDuration);
					color = Color32.Lerp(_fishingLineLoadBar._maxLineLoadColor, _fishingLineLoadBar._overloadLineColor, t);
				}
				_fishingLineLoadBar._loadBarImage.color = color;
			}
			SetBarScale(_fishingLineLoadBar._fillDirection, _fishingLineLoadBar._loadBar, num);
		}

		private void ShowLootInfo(FishingLootData lootData, TMP_Text infoGameObject)
		{
			infoGameObject.text = lootData._lootName + " | " + lootData._lootTier.ToString() + " | " + lootData._lootDescription;
		}

		private void SetBarScale(FillDirection fillDirection, Transform barTransform, float progress)
		{
			Vector3 localScale = Vector3.zero;
			switch (fillDirection)
			{
			case FillDirection.Vertical:
				localScale = new Vector3(barTransform.localScale.x, progress, barTransform.localScale.z);
				break;
			case FillDirection.Horizontal:
				localScale = new Vector3(progress, barTransform.localScale.y, barTransform.localScale.z);
				break;
			}
			barTransform.localScale = localScale;
		}

		private static float CalculateProgess(float input, float max)
		{
			float t = Mathf.InverseLerp(0f, max, input);
			return Mathf.Lerp(0f, 1f, t);
		}
	}
}
