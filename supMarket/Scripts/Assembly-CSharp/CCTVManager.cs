using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CCTVManager : NoktaSingleton<CCTVManager>
{
	[SerializeField]
	private ShoplifterIndicator m_ShoplifterIndicatorPrefab;

	[SerializeField]
	private Camera m_SecurityRenderCamera;

	public Action<Shoplifter, bool> OnShoplifterDeteched;

	public Action<int> OnSecurityGuardFired;

	public Camera TempCamera;

	public List<SecurityCamera> SecurityCameras;

	public List<SecurityGuard> SecurityGuards;

	public List<Transform> CustomPatrolingPoints;

	private Vector3 storeEntrancePosition;

	private List<Shoplifter> m_UnoccupiedShoplifters;

	public bool IsSecurityShowed;

	private CinemachineVirtualCamera m_CVC;

	private float m_DefaultFarDistance;

	private SecurityCamera m_LastActivatedCamera;

	private Coroutine m_EnableDelayedCoroutine;

	private PlayerInstance m_PlayerInstance;

	public Camera SecurityRenderCamera
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Vector3 StoreEntrancePosition
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public List<Shoplifter> UnoccupiedShoplifters => null;

	private PlayerInstance PlayerInstance => null;

	public void Occupy(Shoplifter shoplifter)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void ResetUnoccupiedShoplifters()
	{
	}

	private void OnSectionPositionChanged(Vector3 vector)
	{
	}

	private void Start()
	{
	}

	private void Initialize(PlayerInstance localPlayer)
	{
	}

	private void Update()
	{
	}

	public void AddSecurityGuards(SecurityGuard securityGuard)
	{
	}

	public void RemoveSecurityGuards(SecurityGuard securityGuard)
	{
	}

	public ShoplifterIndicator SpawnIndicator(Shoplifter shoplifter, bool OnAlert)
	{
		return null;
	}

	public void EnableCameraMode(SecurityCamera _CameraObject)
	{
	}

	public void DisableCameraMode()
	{
	}

	public void SaveCameraData(SecurityCamera _cam)
	{
	}

	public void RemoveFromSaveData(SecurityCamera _cam)
	{
	}

	public void RemoveFromSaveData(int camId)
	{
	}

	public SecurityCameraSaveData GetSaveData(SecurityCamera _cam)
	{
		return null;
	}

	public bool IsCustomerVisible(Bounds _Bounds)
	{
		return false;
	}
}
