using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class RoomAssignationVisualMode : CTSBehaviour
	{
		public enum EMode
		{
			Navigation = 0,
			ObjectAssignation = 1
		}

		private static EMode _currentMode;

		[SerializeField]
		private LayerMask _layerMask;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private UIWallMenu _wallMenu;

		[SerializeField]
		[Inject(false)]
		private AgentPanelRoomAssignation _roomAssignationPanel;

		[SerializeField]
		[Inject(false)]
		private RoomAssignationsTool _assignationsTool;

		public static EMode CurrentMode
		{
			get
			{
				return _currentMode;
			}
			set
			{
				if (_currentMode != value)
				{
					_currentMode = value;
					RoomAssignationVisualMode.ModeChanged?.Invoke(_currentMode);
				}
			}
		}

		public static event Action<EMode> ModeChanged;

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
			_currentMode = EMode.Navigation;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
		}

		private void Start()
		{
			UIWallMenu.OnMenuOpen += OnRoomAssignationMenuOpened;
			AgentPanelRoomAssignation.PanelOpened += OnRoomAssignationMenuOpened;
			UI_MachineMgr_FeatureRoomAssignation.PanelOpened += OnRoomAssignationMenuOpened;
			_assignationsTool.CurrentModeChanged += OnAssignationModeChanged;
		}

		private void OnDestroy()
		{
			UIWallMenu.OnMenuOpen -= OnRoomAssignationMenuOpened;
			AgentPanelRoomAssignation.PanelOpened -= OnRoomAssignationMenuOpened;
			UI_MachineMgr_FeatureRoomAssignation.PanelOpened -= OnRoomAssignationMenuOpened;
			_assignationsTool.CurrentModeChanged -= OnAssignationModeChanged;
			if ((bool)MainCamera.CameraReference)
			{
				MainCamera.CameraReference.cullingMask &= ~(int)_layerMask;
			}
		}

		private void OnAssignationModeChanged(EventChange<RoomAssignationsTool.EMode> obj)
		{
			RecalculateMode();
		}

		private void OnRoomAssignationMenuOpened(bool isOpen)
		{
			RecalculateMode();
		}

		public void RecalculateMode()
		{
			if ((bool)MainCamera.CameraReference)
			{
				if (_wallMenu.IsOpen)
				{
					CurrentMode = EMode.Navigation;
					MainCamera.CameraReference.cullingMask |= _layerMask;
				}
				else if (_roomAssignationPanel.IsOpen)
				{
					CurrentMode = EMode.ObjectAssignation;
					MainCamera.CameraReference.cullingMask |= _layerMask;
				}
				else if (UI_MachineMgr_FeatureRoomAssignation.IsOpen)
				{
					CurrentMode = EMode.ObjectAssignation;
					MainCamera.CameraReference.cullingMask |= _layerMask;
				}
				else
				{
					CurrentMode = EMode.Navigation;
					MainCamera.CameraReference.cullingMask &= ~(int)_layerMask;
				}
			}
		}
	}
}
