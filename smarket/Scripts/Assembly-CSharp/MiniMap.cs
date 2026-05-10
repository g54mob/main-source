using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding;
using UnityEngine;
using __Project__.Scripts.Computer;
using __Project__.Scripts.ControllerInputModule;
using __Project__.Scripts.MiniMap;
using __Project__.Scripts.Vending_Machine;

public class MiniMap : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCreatePathLoop_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MiniMap _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCreatePathLoop_003Ed__52(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private Transform target;

	[SerializeField]
	private float PathDrawInterval;

	[SerializeField]
	private GameObject MiniMapPlane;

	[SerializeField]
	private Transform m_MiniMapArrow;

	[SerializeField]
	private List<Transform> m_CustomTargets;

	[SerializeField]
	private List<Transform> m_CustomTargetsOnlineOrderCustomers;

	[SerializeField]
	private List<OnlineOrderCustomerMapItem> m_GlobalMapUIOnlineOrderCustomers;

	[SerializeField]
	private LineRenderer m_Lr;

	[SerializeField]
	private LineRenderer m_ShortLine;

	[SerializeField]
	private GameObject m_MiniMapObject;

	[SerializeField]
	private GameObject GlobalCamera;

	[SerializeField]
	private GameObject GlobalMapUI;

	[SerializeField]
	private RectTransform m_MapGamepadCursorTransform;

	[SerializeField]
	private GamePadUIPanel m_GamepadUIPanel;

	[SerializeField]
	private float m_CursorMoveSpeed;

	[SerializeField]
	private float m_MinMarkerDistance;

	[SerializeField]
	private VendingGlobalMapUIMarker m_VendingGlobalMapUIMarkerPrefab;

	[SerializeField]
	private RectTransform m_VendingMarkerParent;

	private List<VendingGlobalMapUIMarker> m_VendingGlobalMapUIMarkers;

	[SerializeField]
	private VendingMachineMiniMapObject m_VendingMachineMiniMapObjectPrefab;

	[SerializeField]
	private Transform m_VendingMiniMarkerParent;

	private List<VendingMachineMiniMapObject> m_VendingMachineMiniMapObjects;

	private Seeker seeker;

	private Computer m_Computer;

	private ScaleInteraction m_ScaleInteraction;

	private WaitForSeconds m_CreatePointIntervalWaiter;

	private bool m_IsDrawingPath;

	private Vector3 m_FirstPathPoint;

	private int m_CurrentTargetIndex;

	private float m_RemainingDist;

	private List<GlobalMapMarker> m_GlobalMapMarkers;

	private GlobalMapMarker m_CurrentGlobalMapMarker;

	private PlayerController m_PlayerController;

	private Transform m_PlayerTransform;

	private bool m_IsMiniMapActive;

	private bool m_IsUIActive;

	private MapTooltip m_MapTooltip;

	public static bool AllowMapButton;

	public bool WillBlockGlobalMap => false;

	public event Action<Transform> CustomTargetSelected
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLocalPlayerUpdated(PlayerInstance _instance)
	{
	}

	public void AddMarker(GlobalMapMarker marker)
	{
	}

	public void RemoveMarker(GlobalMapMarker marker)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreatePath(Transform target)
	{
	}

	[IteratorStateMachine(typeof(_003CCreatePathLoop_003Ed__52))]
	private IEnumerator CreatePathLoop()
	{
		return null;
	}

	private void CloseMap()
	{
	}

	private void CloseMiniMap()
	{
	}

	private void OpenMiniMap()
	{
	}

	private void ForceClose()
	{
	}

	private void OnComputerInteract()
	{
	}

	private void OnMapButtonPressed()
	{
	}

	public void OnOnlineOrderCustomerGenerated(int index, string name)
	{
	}

	public void OnOnlineOrderCustomerDespawned(int index)
	{
	}

	public float GetTargetDistance()
	{
		return 0f;
	}

	public void ShowGlobalMap(bool _isOpen, bool fromComputer = false)
	{
	}

	public void CreateDestination(Vector3 _destination)
	{
	}

	public void DestroyDestination()
	{
	}

	public void DrawSpline(Path _path)
	{
	}

	public void SetCustomTargetButton(int _targetIndex)
	{
	}

	public void SwitchTooltip(bool isOpen, string entry, RectTransform marker)
	{
	}

	public void AddVendingMarker(VendingMachine vendingMachine)
	{
	}

	public void RemoveVendingMarker(VendingMachine vendingMachine)
	{
	}

	public void SelectVendingMachineTarget(int uid, bool willSelect)
	{
	}

	public void HighlightVendingMachine(int uid)
	{
	}

	public void MoveGamepadFunction(Vector2 moveDelta)
	{
	}

	public void CheckCursorTarget()
	{
	}

	public void OnMarkerSelected()
	{
	}

	private GlobalMapMarker GetClosestMarker()
	{
		return null;
	}

	private void OnControllerConnected(bool isConnected)
	{
	}
}
