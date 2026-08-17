using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Gem : Pickup
{
	public static List<string> GEMFRAMES;

	private int _prevDepth;

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		Time = 1f;
	}

	public void SetDataAndValue(ItemType itemType, float value)
	{
		base.SetData(itemType);
		Time = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 16 Invalid \"Jump target not found in method: 0x1873284C0\"");
	}

	public void SetValue(float value)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_012e: Invalid comparison between F4 and I4
		//IL_00d5: Invalid comparison between F4 and I4
		BaseBody baseBody = body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		base._003CValue_003Ek__BackingField = value;
		bool flag3;
		string text;
		if (4f < value)
		{
			if (6f < value)
			{
				bool flag = value == 7f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873285B1h\"");
				if (!flag)
				{
					bool flag2 = value == 8f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873285BCh\"");
					if (!flag2)
					{
						float num = value - 9f;
						flag3 = num == 0f;
						goto IL_0217;
					}
				}
			}
			else
			{
				bool flag4 = value == 5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873285EEh\"");
				if (!flag4)
				{
					float num2 = value - 6f;
					flag3 = num2 == 0f;
					goto IL_0217;
				}
			}
		}
		else
		{
			if (!(2f < value))
			{
				bool flag5 = value == 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187328626h\"");
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873285C7h\"");
					if (value != 2f)
					{
						goto IL_00e0;
					}
				}
				text = "gemblue";
				goto IL_022f;
			}
			bool flag6 = value == 3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018732860Bh\"");
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873285C7h\"");
				if (value != 4f)
				{
					goto IL_00e0;
				}
			}
		}
		goto IL_01aa;
		IL_01aa:
		text = "gemgreen";
		goto IL_022f;
		IL_0217:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873285C7h\"");
		if (!flag3)
		{
			goto IL_00e0;
		}
		goto IL_01aa;
		IL_022f:
		SetFrame(text);
		return;
		IL_00e0:
		text = "gemred";
		goto IL_022f;
	}

	public override void UpdateDepth()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = -renderer.pixelHeight;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num2 = default(int);
		if (num2 != _prevDepth)
		{
			_prevDepth = num2;
			_itemRenderer.sortingOrder = num2;
		}
	}

	public override void Despawn()
	{
		//IL_002d: Expected O, but got I4
		//IL_00d3: Expected I4, but got I8
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
		ObjectPool gemPool = _gameManager.GemPool;
		GameObject obj = base.gameObject;
		gemPool.Release(obj);
		bool flag = ((HashSet<object>)(object)gameManager._gems).Remove((object)this);
		_prevDepth = -1;
	}

	public override void GetTaken()
	{
		//IL_00f7: Expected F4, but got I4
		//IL_00b0: Expected F4, but got I4
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			GameManager gameManager = _gameManager;
			ArcanaManager arcanaManager = gameManager._arcanaManager;
			object obj = default(object);
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			if (!arcanaManager._003CPewPew_003Ek__BackingField)
			{
				float num = _targetPlayer.PGrowth();
				float xp = (float)obj * base._003CValue_003Ek__BackingField;
				gameManager.AddPlayerXp(xp);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Gem, 1f, 1, 0f, volume, rate, detune, loop, 1f);
			}
			else
			{
				PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Gem, 1f, 1, 0f, volume, rate, detune, loop, 1f);
				Sprite sprite = _itemRenderer.sprite;
				string frameName = ((UnityEngine.Object)sprite).GetName();
				GameManager gameManager2 = _gameManager;
				float num2 = _targetPlayer.PGrowth();
				float damage = (float)obj * base._003CValue_003Ek__BackingField;
				gameManager2._arcanaManager.TriggerGemCannon(damage, frameName, _targetPlayer);
			}
			base.GetTaken();
		}
	}

	public void BlessColor(float value, float index)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		base.Bless(value);
		List<string> gEMFRAMES = GEMFRAMES;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj2 = default(object);
		object obj = obj2 >> 1;
		object obj3 = obj >> 31;
		object obj4 = obj + obj3;
		object obj5 = obj4 * 11;
		object obj6 = (object)this - obj5;
		if ((nint)obj6 < gEMFRAMES._size)
		{
			string[] items = gEMFRAMES._items;
			SetFrame(items[obj6]);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public Gem()
	{
		//IL_001b: Expected I4, but got I8
		_prevDepth = -1;
		base._002Ector();
	}

	static Gem()
	{
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem1");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem2");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem3");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem4");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem5");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem6");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem7");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem8");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem9");
		}
		else
		{
			int num9 = list._size + 1;
			list._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list._version + 1;
		list._version = version10;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem10");
		}
		else
		{
			int num10 = list._size + 1;
			list._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list._version + 1;
		list._version = version11;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Gem11");
		}
		else
		{
			int num11 = list._size + 1;
			list._size = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		GEMFRAMES = list;
	}
}
