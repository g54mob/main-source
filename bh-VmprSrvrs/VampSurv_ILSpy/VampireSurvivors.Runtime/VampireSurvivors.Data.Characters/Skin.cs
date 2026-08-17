using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Data.Characters;

[Serializable]
public class Skin
{
	private string _003Cname_003Ek__BackingField;

	public SkinType skinType;

	private string _003Cprefix_003Ek__BackingField;

	private string _003Csuffix_003Ek__BackingField;

	private string _003Cdescription_003Ek__BackingField;

	private string _003CtextureName_003Ek__BackingField;

	private string _003CspriteName_003Ek__BackingField;

	private string _003CcharSelTexture_003Ek__BackingField;

	private string _003CcharSelFrame_003Ek__BackingField;

	private int _003CwalkingFrames_003Ek__BackingField;

	private int? _003CwalkFrameRate_003Ek__BackingField;

	private bool _003Cunlocked_003Ek__BackingField;

	private bool _003Chidden_003Ek__BackingField;

	private bool _003CalwaysHidden_003Ek__BackingField;

	private bool _003Csecret_003Ek__BackingField;

	private List<Vector2> _003CheadOffsets_003Ek__BackingField;

	private WeaponType? _003CstartingWeapon_003Ek__BackingField;

	private SpriteAnims _003CspriteAnims_003Ek__BackingField;

	private Vector2? _003CbodyOffset_003Ek__BackingField;

	private float _003Cprice_003Ek__BackingField;

	private float _003Ccooldown_003Ek__BackingField;

	private float _003CmaxHp_003Ek__BackingField;

	private float _003Carmor_003Ek__BackingField;

	private float _003Cregen_003Ek__BackingField;

	private float _003CmoveSpeed_003Ek__BackingField;

	private double _003Cpower_003Ek__BackingField;

	private float _003Carea_003Ek__BackingField;

	private float _003Cspeed_003Ek__BackingField;

	private float _003Cduration_003Ek__BackingField;

	private float _003Camount_003Ek__BackingField;

	private float _003Cluck_003Ek__BackingField;

	private float _003Cgrowth_003Ek__BackingField;

	private float _003Cgreed_003Ek__BackingField;

	private float _003Cmagnet_003Ek__BackingField;

	private float _003Crevivals_003Ek__BackingField;

	private float _003Ccurse_003Ek__BackingField;

	private float _003Cshields_003Ek__BackingField;

	private float _003CreRolls_003Ek__BackingField;

	private float _003Cskips_003Ek__BackingField;

	private float _003Cbanish_003Ek__BackingField;

	private List<string> _003CexWeapons_003Ek__BackingField;

	private List<string> _003CexAccessories_003Ek__BackingField;

	private List<string> _003ChiddenWeapons_003Ek__BackingField;

	private ModifierStats _003ConEveryLevelUp_003Ek__BackingField;

	public string name
	{
		get
		{
			return _003Cname_003Ek__BackingField;
		}
		set
		{
			_003Cname_003Ek__BackingField = value;
		}
	}

	public string prefix
	{
		get
		{
			return _003Cprefix_003Ek__BackingField;
		}
		set
		{
			_003Cprefix_003Ek__BackingField = value;
		}
	}

	public string suffix
	{
		get
		{
			return _003Csuffix_003Ek__BackingField;
		}
		set
		{
			_003Csuffix_003Ek__BackingField = value;
		}
	}

	public string description
	{
		get
		{
			return _003Cdescription_003Ek__BackingField;
		}
		set
		{
			_003Cdescription_003Ek__BackingField = value;
		}
	}

	public string textureName
	{
		get
		{
			return _003CtextureName_003Ek__BackingField;
		}
		set
		{
			_003CtextureName_003Ek__BackingField = value;
		}
	}

	public string spriteName
	{
		get
		{
			return _003CspriteName_003Ek__BackingField;
		}
		set
		{
			_003CspriteName_003Ek__BackingField = value;
		}
	}

	public string charSelTexture
	{
		get
		{
			return _003CcharSelTexture_003Ek__BackingField;
		}
		set
		{
			_003CcharSelTexture_003Ek__BackingField = value;
		}
	}

	public string charSelFrame
	{
		get
		{
			return _003CcharSelFrame_003Ek__BackingField;
		}
		set
		{
			_003CcharSelFrame_003Ek__BackingField = value;
		}
	}

	public int walkingFrames
	{
		get
		{
			return _003CwalkingFrames_003Ek__BackingField;
		}
		set
		{
			_003CwalkingFrames_003Ek__BackingField = value;
		}
	}

	public int? walkFrameRate
	{
		get
		{
			return _003CwalkFrameRate_003Ek__BackingField;
		}
		set
		{
			_003CwalkFrameRate_003Ek__BackingField = value;
		}
	}

	public bool unlocked
	{
		get
		{
			return _003Cunlocked_003Ek__BackingField;
		}
		set
		{
			_003Cunlocked_003Ek__BackingField = value;
		}
	}

	public bool hidden
	{
		get
		{
			return _003Chidden_003Ek__BackingField;
		}
		set
		{
			_003Chidden_003Ek__BackingField = value;
		}
	}

	public bool alwaysHidden
	{
		get
		{
			return _003CalwaysHidden_003Ek__BackingField;
		}
		set
		{
			_003CalwaysHidden_003Ek__BackingField = value;
		}
	}

	public bool secret
	{
		get
		{
			return _003Csecret_003Ek__BackingField;
		}
		set
		{
			_003Csecret_003Ek__BackingField = value;
		}
	}

	public List<Vector2> headOffsets
	{
		get
		{
			return _003CheadOffsets_003Ek__BackingField;
		}
		set
		{
			_003CheadOffsets_003Ek__BackingField = value;
		}
	}

	public WeaponType? startingWeapon
	{
		get
		{
			return _003CstartingWeapon_003Ek__BackingField;
		}
		set
		{
			_003CstartingWeapon_003Ek__BackingField = value;
		}
	}

	public SpriteAnims spriteAnims
	{
		get
		{
			return _003CspriteAnims_003Ek__BackingField;
		}
		set
		{
			_003CspriteAnims_003Ek__BackingField = value;
		}
	}

	public Vector2? bodyOffset
	{
		get
		{
			//IL_0010: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+80]");
			Skin skin = (Skin)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+88]");
			_ = 0;
			return (Vector2?)this;
		}
		set
		{
			_003CbodyOffset_003Ek__BackingField = value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Nullable`1<UnityEngine.Vector2>)+8]");
			_ = 0;
		}
	}

	public float price
	{
		get
		{
			return _003Cprice_003Ek__BackingField;
		}
		set
		{
			_003Cprice_003Ek__BackingField = value;
		}
	}

	public float cooldown
	{
		get
		{
			return _003Ccooldown_003Ek__BackingField;
		}
		set
		{
			_003Ccooldown_003Ek__BackingField = value;
		}
	}

	public float maxHp
	{
		get
		{
			return _003CmaxHp_003Ek__BackingField;
		}
		set
		{
			_003CmaxHp_003Ek__BackingField = value;
		}
	}

	public float armor
	{
		get
		{
			return _003Carmor_003Ek__BackingField;
		}
		set
		{
			_003Carmor_003Ek__BackingField = value;
		}
	}

	public float regen
	{
		get
		{
			return _003Cregen_003Ek__BackingField;
		}
		set
		{
			_003Cregen_003Ek__BackingField = value;
		}
	}

	public float moveSpeed
	{
		get
		{
			return _003CmoveSpeed_003Ek__BackingField;
		}
		set
		{
			_003CmoveSpeed_003Ek__BackingField = value;
		}
	}

	public double power
	{
		get
		{
			return _003Cpower_003Ek__BackingField;
		}
		set
		{
			_003Cpower_003Ek__BackingField = value;
		}
	}

	public float area
	{
		get
		{
			return _003Carea_003Ek__BackingField;
		}
		set
		{
			_003Carea_003Ek__BackingField = value;
		}
	}

	public float speed
	{
		get
		{
			return _003Cspeed_003Ek__BackingField;
		}
		set
		{
			_003Cspeed_003Ek__BackingField = value;
		}
	}

	public float duration
	{
		get
		{
			return _003Cduration_003Ek__BackingField;
		}
		set
		{
			_003Cduration_003Ek__BackingField = value;
		}
	}

	public float amount
	{
		get
		{
			return _003Camount_003Ek__BackingField;
		}
		set
		{
			_003Camount_003Ek__BackingField = value;
		}
	}

	public float luck
	{
		get
		{
			return _003Cluck_003Ek__BackingField;
		}
		set
		{
			_003Cluck_003Ek__BackingField = value;
		}
	}

	public float growth
	{
		get
		{
			return _003Cgrowth_003Ek__BackingField;
		}
		set
		{
			_003Cgrowth_003Ek__BackingField = value;
		}
	}

	public float greed
	{
		get
		{
			return _003Cgreed_003Ek__BackingField;
		}
		set
		{
			_003Cgreed_003Ek__BackingField = value;
		}
	}

	public float magnet
	{
		get
		{
			return _003Cmagnet_003Ek__BackingField;
		}
		set
		{
			_003Cmagnet_003Ek__BackingField = value;
		}
	}

	public float revivals
	{
		get
		{
			return _003Crevivals_003Ek__BackingField;
		}
		set
		{
			_003Crevivals_003Ek__BackingField = value;
		}
	}

	public float curse
	{
		get
		{
			return _003Ccurse_003Ek__BackingField;
		}
		set
		{
			_003Ccurse_003Ek__BackingField = value;
		}
	}

	public float shields
	{
		get
		{
			return _003Cshields_003Ek__BackingField;
		}
		set
		{
			_003Cshields_003Ek__BackingField = value;
		}
	}

	public float reRolls
	{
		get
		{
			return _003CreRolls_003Ek__BackingField;
		}
		set
		{
			_003CreRolls_003Ek__BackingField = value;
		}
	}

	public float skips
	{
		get
		{
			return _003Cskips_003Ek__BackingField;
		}
		set
		{
			_003Cskips_003Ek__BackingField = value;
		}
	}

	public float banish
	{
		get
		{
			return _003Cbanish_003Ek__BackingField;
		}
		set
		{
			_003Cbanish_003Ek__BackingField = value;
		}
	}

	public List<string> exWeapons
	{
		get
		{
			return _003CexWeapons_003Ek__BackingField;
		}
		set
		{
			_003CexWeapons_003Ek__BackingField = value;
		}
	}

	public List<string> exAccessories
	{
		get
		{
			return _003CexAccessories_003Ek__BackingField;
		}
		set
		{
			_003CexAccessories_003Ek__BackingField = value;
		}
	}

	public List<string> hiddenWeapons
	{
		get
		{
			return _003ChiddenWeapons_003Ek__BackingField;
		}
		set
		{
			_003ChiddenWeapons_003Ek__BackingField = value;
		}
	}

	public ModifierStats onEveryLevelUp
	{
		get
		{
			return _003ConEveryLevelUp_003Ek__BackingField;
		}
		set
		{
			_003ConEveryLevelUp_003Ek__BackingField = value;
		}
	}

	public Skin()
	{
		List<string> list = new List<string>();
		_003CexWeapons_003Ek__BackingField = list;
		List<string> list2 = new List<string>();
		_003CexAccessories_003Ek__BackingField = list2;
		List<string> list3 = new List<string>();
		_003ChiddenWeapons_003Ek__BackingField = list3;
	}
}
