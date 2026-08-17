using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Coin : Pickup, ICountedPickup
{
	private GoldFeverController _goldFever;

	private bool _isJewel;

	private List<string> jewelFrames;

	private int _003CAmountOnCollection_003Ek__BackingField;

	public int AmountOnCollection
	{
		get
		{
			return _003CAmountOnCollection_003Ek__BackingField;
		}
		set
		{
			_003CAmountOnCollection_003Ek__BackingField = value;
		}
	}

	private void InjectGoldFever(GoldFeverController gold)
	{
		_goldFever = gold;
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		_isJewel = false;
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		_003CAmountOnCollection_003Ek__BackingField = 1;
	}

	public override void Despawn()
	{
		//IL_002d: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = false;
		setVelocity(0f, (float?)(object)0);
		PhysicsManager sInstance = PhysicsManager._sInstance;
		sInstance._pickupGroup.remove(this);
		PhysicsManager sInstance2 = PhysicsManager._sInstance;
		sInstance2._goToPlayerPickupGroup.remove(this);
		if (body != null)
		{
			body.destroy();
			body = null;
		}
		GameManager gameManager = _gameManager;
		ObjectPool coinPool = _gameManager.CoinPool;
		GameObject obj = base.gameObject;
		coinPool.Release(obj);
		bool flag = ((HashSet<object>)(object)gameManager._coins).Remove((object)this);
	}

	public override void GetTaken()
	{
		//IL_010b: Expected F4, but got I4
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			if (_isJewel)
			{
				GameManager core = GM.Core;
				float2 float5 = _targetPlayer.position;
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt(core._jewelPickupVfx, pos, 10);
			}
			_goldFever.OnCoinPickup(this);
			GM.Core.CoinPickedup(this);
			float num = _playerOptions.AddCoins(base._003CValue_003Ek__BackingField, _targetPlayer);
			PlayerOptionsData config = _playerOptions.Config;
			int num2 = config._003CRunPickups_Coins_003Ek__BackingField + _003CAmountOnCollection_003Ek__BackingField;
			config._003CRunPickups_Coins_003Ek__BackingField = num2;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Coin, 1f, 1, 0f, volume, rate, detune, loop, 1f);
			base.GetTaken();
		}
	}

	public override void Bless(float value, HitVfxType hitVFXType = HitVfxType.Prism)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4E38]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Bless(value, hitVFXType);
		string text;
		if (base._003CValue_003Ek__BackingField < 100f)
		{
			if (base._003CValue_003Ek__BackingField < 25f)
			{
				if (!(base._003CValue_003Ek__BackingField > 10f))
				{
					return;
				}
				text = "MoneyBagRed";
			}
			else
			{
				text = "MoneyBagGreen";
			}
		}
		else
		{
			text = "MoneyBagColor";
		}
		SetFrame(text);
	}

	public void Bejewel()
	{
		//IL_003f: Expected O, but got I4
		_isJewel = true;
		string spriteName = Extensions.PickRnd(jewelFrames);
		Sprite sprite = SpriteManager.GetSprite(spriteName, "TP_items");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setScale(1.5f, (float?)(object)0);
	}

	public void PublicSetSprite(string frameName, string textureName)
	{
		_isJewel = true;
		Sprite sprite = SpriteManager.GetSprite(frameName, textureName);
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public Coin()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Jewel01");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Jewel02");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Jewel03");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Jewel04");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Jewel05");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Jewel06");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Jewel07");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Jewel08");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		jewelFrames = list;
		_003CAmountOnCollection_003Ek__BackingField = 1;
		base._002Ector();
	}
}
