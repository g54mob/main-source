using System;
using System.Collections.Generic;
using InputControl;
using Libs;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
	public class GameChangeCtrl : SingletonMonoBehaviour<GameChangeCtrl>
	{
		[Serializable]
		public struct SpeedData
		{
			public double speedGear;

			public Sprite speedSprite;
		}

		[Header("UI Elements")]
		[FormerlySerializedAs("camera")]
		public Button cameraButton;

		[FormerlySerializedAs("speed")]
		public Button speedButton;

		public Button speedButton2;

		public Image speedImage;

		public Image speedImage2;

		public SpellAutoSwitchButton autoSpellButton;

		public Button pauseButton;

		public Button pauseButton2;

		public Button mapExtendButton;

		public Button mapExtendViwerButton;

		public RectTransform treeButtonRect;

		[Space(10f)]
		[SerializeField]
		private Sprite pausingSprite;

		[SerializeField]
		private NoticeBadge treeNoticeBadge;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private GameObject padUIGroup;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		[SerializeField]
		private Transform hpBerParent;

		[SerializeField]
		private Transform relicParent;

		[SerializeField]
		private Transform padUIShopParent;

		[SerializeField]
		private Transform padUISceneFocusParent;

		[Header("UI Groups")]
		[SerializeField]
		private CursorUIGroup _gameChangeGroup;

		[SerializeField]
		private CursorUIGroup _dialogGroup;

		[SerializeField]
		private CursorUIGroup _footerGroup;

		[SerializeField]
		private CursorUIGroup _relicGroup;

		[SerializeField]
		private CursorUIGroup _initGroup;

		[SerializeField]
		private List<GameObject> _guidObjects;

		[SerializeField]
		private List<RectTransform> _raycastTarget;

		[SerializeField]
		private RectTransform _optionRaycastTarget;

		[Header("Speed Settings")]
		public SpeedData[] speedData;

		private bool _isOrthographicCamera;

		private bool _useCameraButton;

		private int _speedIndex;

		private Sprite _originalPauseSprite;

		private Sprite _originalPauseSprite2;

		private bool _isRTriggerPushed;

		private bool _isUIOpen;

		private bool _cacheSystemPause;

		private Vector2 _shopDefaultPosition;

		private Vector2 _sceneChangeDefaultPosition;

		private Vector2 _hpBerDefaultPosition;

		private Vector2 _relicDefaultPosition;

		private CursorUIGroup _shopGroup;

		private CursorUIGroup _sceneChangeGroup;

		private CursorUIGroup _lastSelectedCursorUIGroup;

		public bool IsUIOpen => false;

		public bool PauseButtonOk => false;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void Init()
		{
		}

		private void InitializeCameraButton()
		{
		}

		private void InitializePadUI()
		{
		}

		public void OnSelectGameChangeGroup()
		{
		}

		public void OnSelectDialogGroup()
		{
		}

		public void OnDownSelect()
		{
		}

		public void OnSelectShopGroup()
		{
		}

		public void OnSelectSceneChangeGroup()
		{
		}

		public void OnSelectRelicGroup()
		{
		}

		public void ChangeCamera()
		{
		}

		public void ChangeFactorySpeedGear()
		{
		}

		public void OnPause()
		{
		}

		public void OnPauseShortCut()
		{
		}

		private void ActivatePause()
		{
		}

		private void ReleasePause()
		{
		}

		public bool CanPause()
		{
			return false;
		}

		public void ChangeSpeedIndex()
		{
		}

		public void ChangeSpeedIndex(int setIndex)
		{
		}

		public double GetCurrentSpeedGear()
		{
			return 0.0;
		}

		public void UpdateSpeedImage()
		{
		}

		public void OnSwitchChoiceRouteDialog()
		{
		}

		public void OnSwitchMapExtendDialog()
		{
		}

		public void UpdateUI()
		{
		}

		public void SwitchInteractive(bool interactive)
		{
		}

		public void UpdateButtonBadge()
		{
		}

		public void ToggleGroupInteractive(bool value)
		{
		}

		public void CheckDisplayAutoSpell()
		{
		}

		private void OpenPadUI()
		{
		}

		private bool IsActuallyClickable(List<RectTransform> targets)
		{
			return false;
		}

		private bool IsAnyPointClickable(RectTransform target, Canvas canvas, GraphicRaycaster raycaster)
		{
			return false;
		}

		private void SaveUIPositions()
		{
		}

		private void ReparentUIElements()
		{
		}

		private void ClosePadUI(bool isSelect)
		{
		}

		private void HandleClosingInteraction(bool isSelect)
		{
		}

		private void RestoreUIElements()
		{
		}

		public void CancelPadUI()
		{
		}

		public void OpenSetting()
		{
		}

		private void SetGuideObject(bool isOn)
		{
		}

		private List<RectTransform> GetRayCastList()
		{
			return null;
		}

		private void Update()
		{
		}

		private void HandleTriggerInput()
		{
		}

		private void UpdateUIVisibility()
		{
		}

		private bool CheckTutorial()
		{
			return false;
		}
	}
}
