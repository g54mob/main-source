using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Data;

[Serializable]
public class CustomMerchantData
{
	private CharacterType _003CMerchantCharacter_003Ek__BackingField;

	private string _003CPortraitSprite_003Ek__BackingField;

	private string _003CPortraitSpriteTexture_003Ek__BackingField;

	private string _003CStaticSprite_003Ek__BackingField;

	private string _003CStaticSpriteTexture_003Ek__BackingField;

	private List<DlcType> _003CDLC_003Ek__BackingField;

	private bool _003CIsAnimated_003Ek__BackingField;

	private bool _003CHideBackgroundParticles_003Ek__BackingField;

	private bool _003CHideBackgroundWindows_003Ek__BackingField;

	private bool _003CHideBackgroundMask_003Ek__BackingField;

	private float? _003CCustomCooldown_003Ek__BackingField;

	private string _003CTextLocKey_003Ek__BackingField;

	private float? _003CMerchantXPos_003Ek__BackingField;

	private float? _003CMerchantYPos_003Ek__BackingField;

	private Vector2? _003CBodyOffset_003Ek__BackingField;

	private List<WeaponType> _003CMerchantInventory_003Ek__BackingField;

	private List<ItemType> _003CMerchantInventoryItems_003Ek__BackingField;

	public CharacterType MerchantCharacter
	{
		get
		{
			return _003CMerchantCharacter_003Ek__BackingField;
		}
		set
		{
			_003CMerchantCharacter_003Ek__BackingField = value;
		}
	}

	public string PortraitSprite
	{
		get
		{
			return _003CPortraitSprite_003Ek__BackingField;
		}
		set
		{
			_003CPortraitSprite_003Ek__BackingField = value;
		}
	}

	public string PortraitSpriteTexture
	{
		get
		{
			return _003CPortraitSpriteTexture_003Ek__BackingField;
		}
		set
		{
			_003CPortraitSpriteTexture_003Ek__BackingField = value;
		}
	}

	public string StaticSprite
	{
		get
		{
			return _003CStaticSprite_003Ek__BackingField;
		}
		set
		{
			_003CStaticSprite_003Ek__BackingField = value;
		}
	}

	public string StaticSpriteTexture
	{
		get
		{
			return _003CStaticSpriteTexture_003Ek__BackingField;
		}
		set
		{
			_003CStaticSpriteTexture_003Ek__BackingField = value;
		}
	}

	public List<DlcType> DLC
	{
		get
		{
			return _003CDLC_003Ek__BackingField;
		}
		set
		{
			_003CDLC_003Ek__BackingField = value;
		}
	}

	public bool IsAnimated
	{
		get
		{
			return _003CIsAnimated_003Ek__BackingField;
		}
		set
		{
			_003CIsAnimated_003Ek__BackingField = value;
		}
	}

	public bool HideBackgroundParticles
	{
		get
		{
			return _003CHideBackgroundParticles_003Ek__BackingField;
		}
		set
		{
			_003CHideBackgroundParticles_003Ek__BackingField = value;
		}
	}

	public bool HideBackgroundWindows
	{
		get
		{
			return _003CHideBackgroundWindows_003Ek__BackingField;
		}
		set
		{
			_003CHideBackgroundWindows_003Ek__BackingField = value;
		}
	}

	public bool HideBackgroundMask
	{
		get
		{
			return _003CHideBackgroundMask_003Ek__BackingField;
		}
		set
		{
			_003CHideBackgroundMask_003Ek__BackingField = value;
		}
	}

	public float? CustomCooldown
	{
		get
		{
			return _003CCustomCooldown_003Ek__BackingField;
		}
		set
		{
			_003CCustomCooldown_003Ek__BackingField = value;
		}
	}

	public string TextLocKey
	{
		get
		{
			return _003CTextLocKey_003Ek__BackingField;
		}
		set
		{
			_003CTextLocKey_003Ek__BackingField = value;
		}
	}

	public float? MerchantXPos
	{
		get
		{
			return _003CMerchantXPos_003Ek__BackingField;
		}
		set
		{
			_003CMerchantXPos_003Ek__BackingField = value;
		}
	}

	public float? MerchantYPos
	{
		get
		{
			return _003CMerchantYPos_003Ek__BackingField;
		}
		set
		{
			_003CMerchantYPos_003Ek__BackingField = value;
		}
	}

	public Vector2? BodyOffset
	{
		get
		{
			//IL_0010: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+68]");
			CustomMerchantData customMerchantData = (CustomMerchantData)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+70]");
			_ = 0;
			return (Vector2?)this;
		}
		set
		{
			_003CBodyOffset_003Ek__BackingField = value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Nullable`1<UnityEngine.Vector2>)+8]");
			_ = 0;
		}
	}

	public List<WeaponType> MerchantInventory
	{
		get
		{
			return _003CMerchantInventory_003Ek__BackingField;
		}
		set
		{
			_003CMerchantInventory_003Ek__BackingField = value;
		}
	}

	public List<ItemType> MerchantInventoryItems
	{
		get
		{
			return _003CMerchantInventoryItems_003Ek__BackingField;
		}
		set
		{
			_003CMerchantInventoryItems_003Ek__BackingField = value;
		}
	}
}
