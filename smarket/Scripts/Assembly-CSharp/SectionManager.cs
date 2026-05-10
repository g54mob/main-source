using System;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : NoktaSingleton<SectionManager>
{
	[SerializeField]
	private float m_SectionAnimationInterval;

	[HideInInspector]
	public Section[] sections;

	private Queue<int> m_SectionAnimationQueue;

	public Action<Vector3> onSectionPositionChanged;

	public Action<int> onSectionPurchased;

	public Action<int> onSectionPurchasedAnimated;

	public Action onDisabled;

	public bool IsMaxStoreUpgradeLevel => false;

	public int m_StoreUpgradeLevel
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void OnDisable()
	{
	}

	public void UpgradeStore()
	{
	}

	public void UpgradeStoreOrder(int upgradeStoreLevel)
	{
	}

	private void PlayAnimations()
	{
	}

	public void LoadUpgrade()
	{
	}
}
