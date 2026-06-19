using System;
using System.Runtime.CompilerServices;
using OUSystems.Basics.UI;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTreeUIUpgrade : MonoBehaviour
{
	[Serializable]
	public class UpgradeUICoreStateSettings
	{
		public Sprite Sprite;

		public Color IconColour;
	}

	private UpgradeTreeUI _parentTree;

	[SerializeField]
	private Image _upgradeImage;

	[SerializeField]
	private Image _slotImage;

	[SerializeField]
	private GameObject _newNotificationPrefab;

	private GameObject _newNotification;

	[SerializeField]
	private GameObject _contentLockSymbol;

	[SerializeField]
	private ContentLockHoverHandler _contentLockHoverHandler;

	[SerializeField]
	private Transform _upgradeTooltipTransform;

	public bool Root;

	[SerializeField]
	private UpgradeUICoreStateSettings UnknownGraphic;

	[SerializeField]
	private UpgradeUICoreStateSettings SelectedGraphic;

	[SerializeField]
	private UpgradeUICoreStateSettings LockedGraphic;

	[SerializeField]
	private UpgradeUICoreStateSettings AvailableGraphic;

	[SerializeField]
	private UpgradeUICoreStateSettings UnavailableGraphic;

	[SerializeField]
	private UpgradeUICoreStateSettings MaxedGraphic;

	[SerializeField]
	private UpgradeUICoreStateSettings DisabledGraphic;

	[SerializeField]
	private PressListenerAnimator _pressListenAnimator;

	[SerializeField]
	private ClickListener _clickListener;

	public int RequiredItemsUndiscovered;

	public UpgradeInstance UpgradeInstance { get; private set; }

	public bool Selected { get; private set; }

	public bool Selectable { get; private set; }

	public bool Visible { get; private set; }

	public bool RequirementLocked { get; private set; }

	public bool Unlocked => false;

	public static event Action<UpgradeTreeUIUpgrade> AnnounceSelect
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

	public static event Action<UpgradeTreeUIUpgrade> AnnounceHover
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

	public void Initiate(UpgradeTreeUI tree, UpgradeInstance upgradeInstance)
	{
	}

	private void OnDestroy()
	{
	}

	public void InitiateRequiredItemsTracking()
	{
	}

	public void OnUnlockItem()
	{
	}

	public void OnParentUpgradeUnlock(int level)
	{
	}

	public void OnParentUpgradeUnlock()
	{
	}

	public void OnRequirementUnlocked()
	{
	}

	public void EvaluateIfAvailable()
	{
	}

	public void OnUpgradeUnlock(int level)
	{
	}

	public void OnUpgradeUnlock()
	{
	}

	public void EvaluateStyle()
	{
	}

	public void SetSelected(bool selected)
	{
	}

	public void OnHover()
	{
	}

	public void OnHoverEnd()
	{
	}

	public void Select()
	{
	}
}
