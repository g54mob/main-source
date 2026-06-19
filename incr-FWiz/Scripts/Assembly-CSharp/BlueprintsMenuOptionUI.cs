using System;
using System.Runtime.CompilerServices;
using OUSystems.Basics.UI;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintsMenuOptionUI : MonoBehaviour
{
	[SerializeField]
	private Image _blueprintImage;

	[SerializeField]
	private Image _slotImage;

	[SerializeField]
	private Sprite _defaultSlotSprite;

	[SerializeField]
	private Sprite _selectedSlotSprite;

	[SerializeField]
	private ClickListener _clickListener;

	public BuildingAsset BuildingAsset { get; private set; }

	public int Index { get; private set; }

	public bool IsSelected { get; private set; }

	public event Action<BlueprintsMenuOptionUI> AnnounceClick
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

	public event Action<BlueprintsMenuOptionUI> AnnounceOnHover
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

	public event Action<BlueprintsMenuOptionUI> AnnounceEndHover
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

	public void Initiate(BuildingAsset buildingAsset, int index)
	{
	}

	private void OnDestroy()
	{
	}

	public void Select()
	{
	}

	public void Unselect()
	{
	}

	public void OnHover()
	{
	}

	public void OnHoverEnd()
	{
	}

	public void OnClick()
	{
	}
}
