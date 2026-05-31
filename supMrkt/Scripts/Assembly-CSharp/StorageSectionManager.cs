using System;
using System.Collections.Generic;
using UnityEngine;

public class StorageSectionManager : NoktaSingleton<StorageSectionManager>
{
	[SerializeField]
	private float m_StorageSectionAnimationInterval;

	[SerializeField]
	private Transform m_DoorTransform;

	private StorageSection[] m_StorageSections;

	private Queue<int> m_StorageSectionAnimationQueue;

	public Action onStoragePurchased;

	public Action<int> onStorageSectionPurchased;

	public Action onStorageSectionPurchasedAnimated;

	public Action onDisabled;

	public int m_StorageUpgradeLevel
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool PurcasedStorage
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	public void UpgradeStore()
	{
	}

	public void UpgradeStorageOrder(int storageUpgradeLevel)
	{
	}

	private void PlayAnimations()
	{
	}

	public void LoadUpgrade()
	{
	}

	public void OpenStorage()
	{
	}

	public void OpenStorageOrder()
	{
	}
}
