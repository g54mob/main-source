using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Props;

public class TP_PropDoor : Destructible
{
	private bool _hasFired;

	private MultiTargetTween _alphaTween;

	private TPBiomeType BiomeType;

	private ItemType linkedRelicType;

	private int doorType;

	public int LinkedRelicType
	{
		get
		{
			return (int)linkedRelicType;
		}
		set
		{
			linkedRelicType = (ItemType)value;
		}
	}

	public int DoorType
	{
		get
		{
			return doorType;
		}
		set
		{
			doorType = value;
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
	}

	protected virtual void OnRecycle()
	{
	}

	public void SetRelicFromBiomeType(TPBiomeType biomeType)
	{
		//IL_0018: Expected O, but got I4
		//IL_0042: Expected O, but got I8
		//IL_005c: Expected O, but got I8
		BiomeType = biomeType;
		object obj = biomeType - 1;
		if ((nint)obj <= 9)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8_v1+6FEC778+v2 @ rdx_v1*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ rdx_v3 (should have been resolved before IL gen)");
		}
	}

	public void SetType(int type)
	{
		//IL_01d2: Expected O, but got I4
		BaseBody baseBody = body;
		float2 float5 = default(float2);
		baseBody._transform.setOrigin(float5);
		int end;
		string text;
		string text2;
		float oX;
		if (type == 2)
		{
			end = 20;
			text = "TP_Item_ClosedA2_";
			text2 = "TP_Item_DoorA2_";
			oX = 1f;
		}
		else
		{
			bool flag = type != 3;
			end = 20;
			text = "TP_Item_ClosedA_";
			text2 = "TP_Item_DoorA_";
			if (flag)
			{
				goto IL_00c9;
			}
			end = 13;
			text = "TP_Item_ClosedC_";
			text2 = "TP_Item_DoorC_";
			oX = 0.5f;
		}
		ArcadeSprite arcadeSprite = setOrigin(oX, (float?)(object)1);
		goto IL_00c9;
		IL_00c9:
		_spriteAnimation.CleanAnimations();
		string text3 = text2 + "01";
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(text2, 1, end, "TP_items", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Open", animationFrames, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		string text4 = text + "01";
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(text, 1, 5, "TP_items", num);
		_spriteAnimation.AddAnimation("idle", animationFrames2, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	protected override void SetupAnimations()
	{
		_spriteAnimation.CleanAnimations();
	}

	public override void Init(PropType destructibleType)
	{
		base.Init(destructibleType);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		BaseBody baseBody = body;
		float2 float5 = default(float2);
		baseBody._transform.setOrigin(float5);
		ArcadeSprite arcadeSprite2 = setAlpha(1f);
		base._003CIsStationary_003Ek__BackingField = true;
		_hasFired = false;
	}

	public override void Despawn()
	{
		base.Despawn();
	}

	public void ManualUpdate()
	{
		//IL_01c7: Invalid comparison between F4 and O
		//IL_01fd: Invalid comparison between O and F4
		//IL_0233: Invalid comparison between F4 and O
		//IL_0269: Invalid comparison between O and F4
		//IL_03cf->IL0377: Incompatible stack heights: 1 vs 0
		//IL_033e->IL0343: Incompatible stack heights: 4 vs 0
		//IL_0339->IL0343: Incompatible stack heights: 4 vs 0
		SpriteRenderer destructibleRenderer = _destructibleRenderer;
		if ((object)_destructibleRenderer != null && ((UnityEngine.Object)destructibleRenderer).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer destructibleRenderer2 = _destructibleRenderer;
			bool flag = ((UnityEngine.Object)destructibleRenderer2).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)destructibleRenderer2).m_CachedPtr, 2);
		}
		if (_hasFired)
		{
			return;
		}
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if ((object)core._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset = stage2._tilingTileset;
		if ((object)stage2._tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		object fancyBg = stage3._fancyBg;
		if ((object)stage3._fancyBg == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdi_v11 (System.Object)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		GameManager core4 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		while (enumerator.MoveNext())
		{
			float2 float5 = ((ArcadeSprite)null).position;
			float2 float6 = base.position;
			float num = (float)float6 - 0.4f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5))
			{
				continue;
			}
			float2 float7 = base.position;
			float num2 = (float)float7 + 0.4f;
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
			{
				continue;
			}
			float2 float8 = base.position;
			float num3 = (float)obj - 0.8f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				continue;
			}
			float2 float9 = base.position;
			float num4 = (float)obj2 + 0.8f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4))
			{
				GameManager core5 = GM.Core;
				bool flag2 = (object)GM.Core == null;
				bool flag3 = core5._playerOptions == null;
				PlayerOptionsData config = core5._playerOptions.Config;
				bool flag4 = config == null;
				bool flag5 = config._003CCollectedItems_003Ek__BackingField == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				if (obj3 != null)
				{
					OnTriggeredByPlayer();
				}
				break;
			}
		}
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		ManualUpdate();
	}

	protected void OnTriggeredByPlayer()
	{
		//IL_0041: Expected O, but got I4
		//IL_00cd: Expected I, but got O
		//IL_013f: Expected O, but got I4
		//IL_015a: Expected I, but got O
		if (!_hasFired)
		{
			_hasFired = true;
			_spriteAnimation.SetAnimation("Open");
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 2f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, time);
			if (_alphaTween != null)
			{
				_alphaTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 1000f;
			tweenConfig.delay = 5000f;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Props.TP_PropDoor>)+330]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
		}
	}

	public override bool DoesAllowVenting()
	{
		return false;
	}

	private void OnDoorTypeChanged(int old, int newDoor)
	{
		SetType(newDoor);
	}

	public TP_PropDoor()
	{
		//IL_0036: Expected I, but got O
		_hp = 1f;
		base._maxHp = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
