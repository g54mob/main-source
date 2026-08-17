using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerBatsBatsBats : CharacterController
{
	private Battilia2Weapon Battilia2Weapon;

	private float _baseWeaponPower = 0.35f;

	private SpriteRenderer _back2Sprite;

	private SpriteRenderer _front2Sprite;

	private SpriteRenderer _back3Sprite;

	private SpriteRenderer _front3Sprite;

	private SpriteAnimation _back2Anim;

	private SpriteAnimation _front2Anim;

	private SpriteAnimation _back3Anim;

	private SpriteAnimation _front3Anim;

	private int _followers;

	public override bool NeedsCart => false;

	public override float PAmount()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		float num = base.PAmount();
		EggDouble eggDouble = base.PRevivals();
		double num2 = eggDouble._eggVal;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,qword ptr [rax+10h]\"");
		object obj = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj != 9218868437227405312L)
		{
			object obj2 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj2 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018759DE7Ah\"");
				if ((long)obj2 == 9218868437227405312L)
				{
					return -1f / 0f + num;
				}
				goto IL_0103;
			}
		}
		num2 = 1.7976931348623157E+308;
		goto IL_0103;
		IL_0103:
		return (float)num2 + num;
	}

	protected override void OnStop()
	{
	}

	public unsafe override void AfterFullInitialization()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00ce: Expected I, but got O
		//IL_00dc: Expected I, but got O
		//IL_00ec: Expected O, but got I
		//IL_016c: Expected O, but got I4
		//IL_0128: Expected O, but got I
		//IL_0a4f: Expected O, but got I4
		//IL_017a: Expected I4, but got O
		//IL_015e: Expected O, but got I4
		//IL_0b1e: Expected O, but got Ref
		//IL_0b67: Expected O, but got Ref
		//IL_0bb0: Expected O, but got Ref
		//IL_0bf9: Expected O, but got Ref
		//IL_05d9: Expected I4, but got O
		//IL_05fa: Expected I4, but got O
		//IL_0620: Expected I4, but got O
		//IL_0641: Expected I4, but got O
		//IL_06c5: Expected O, but got I
		//IL_0714: Expected I4, but got O
		//IL_0794: Expected O, but got I
		//IL_07e3: Expected I4, but got O
		//IL_0863: Expected O, but got I
		//IL_08b2: Expected I4, but got O
		//IL_096a: Expected O, but got I
		//IL_09b9: Expected I4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.AfterFullInitialization();
		_followers = 0;
		Weapon weaponByType;
		int num;
		object obj5;
		if ((object)base._spriteTrail != null)
		{
			base._spriteTrail.Reset();
			SpriteTrail spriteTrail = base._spriteTrail;
			if ((object)base._spriteTrail != null)
			{
				spriteTrail._MaxHistory = 0;
				base._spriteTrail.InitialiseGhosts(expandExisting: true);
				if ((object)base._weaponsManager != null)
				{
					weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.BATTILIA2);
					if ((object)weaponByType == null)
					{
						num = 0;
						goto IL_0a45;
					}
					nint num2 = (nint)weaponByType;
					nint num3 = (nint)typeof(Battilia2Weapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rdx_v121 (Il2CppClass<VampireSurvivors.Objects.Weapons.Battilia2Weapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ r9_v35 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rdx_v121 (Il2CppClass<VampireSurvivors.Objects.Weapons.Battilia2Weapon>)+130]");
					if (num4 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ r9_v35 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v230+FFFFFFF8+v453 @ rax_v225*8]");
						if (0 == (nint)typeof(Battilia2Weapon))
						{
							obj5 = 1;
							goto IL_0a54;
						}
					}
					obj5 = 0;
					goto IL_0a54;
				}
			}
		}
		goto IL_0a0e;
		IL_0a45:
		Battilia2Weapon = (Battilia2Weapon)num;
		SpriteRenderer battilia2Weapon = (SpriteRenderer)(object)Battilia2Weapon;
		if ((object)Battilia2Weapon != null && ((UnityEngine.Object)battilia2Weapon).m_CachedPtr != (IntPtr)0)
		{
			Battilia2Weapon battilia2Weapon2 = Battilia2Weapon;
			if ((object)Battilia2Weapon != null)
			{
				WeaponData currentWeaponData = ((Weapon)battilia2Weapon2)._currentWeaponData;
				if (((Weapon)battilia2Weapon2)._currentWeaponData != null)
				{
					currentWeaponData._003Cpower_003Ek__BackingField = _baseWeaponPower;
					goto IL_0a9f;
				}
			}
			goto IL_0a0e;
		}
		goto IL_0a9f;
		IL_0a54:
		bool flag = obj5 == null;
		num = 0;
		if (!flag)
		{
			num = (int)weaponByType;
		}
		goto IL_0a45;
		IL_0a9f:
		float2 float5 = base.cachedPosition;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		string text = default(string);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, vector, "character_batsbatsbats", text);
		if ((object)spriteRenderer != null)
		{
			spriteRenderer.enabled = false;
			_back2Sprite = spriteRenderer;
			float2 float6 = base.cachedPosition;
			GameObject gameObject2 = base.gameObject;
			SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(gameObject2, vector, vector, "character_batsbatsbats", text);
			if ((object)spriteRenderer2 != null)
			{
				spriteRenderer2.enabled = false;
				_front2Sprite = spriteRenderer2;
				float2 float7 = base.cachedPosition;
				GameObject gameObject3 = base.gameObject;
				SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject3, vector, vector, "character_batsbatsbats", text);
				if ((object)spriteRenderer3 != null)
				{
					spriteRenderer3.enabled = false;
					_back3Sprite = spriteRenderer3;
					float2 float8 = base.cachedPosition;
					GameObject gameObject4 = base.gameObject;
					SpriteRenderer spriteRenderer4 = RenderingExtensions.AddSprite(gameObject4, vector, vector, "character_batsbatsbats", text);
					if ((object)spriteRenderer4 != null)
					{
						spriteRenderer4.enabled = false;
						_front3Sprite = spriteRenderer4;
						CheckRenderer();
						if ((object)((ArcadeSprite)this)._spriteRenderer != null)
						{
							Vector2 vector2 = ((ArcadeSprite)this)._spriteRenderer.size;
							Transform transform = _back2Sprite.transform;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1609 @ rax_v76 (UnityEngine.Transform)+10]");
							bool flag2 = (nint)0 == 0;
							object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1609 @ rax_v76 (UnityEngine.Transform)+10]");
							Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj6);
							Transform transform2 = _front2Sprite.transform;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1610 @ rax_v81 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1610 @ rax_v81 (UnityEngine.Transform)+10]");
							Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj7);
							Transform transform3 = _back3Sprite.transform;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1611 @ rax_v86 (UnityEngine.Transform)+10]");
							bool flag4 = (nint)0 == 0;
							object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1611 @ rax_v86 (UnityEngine.Transform)+10]");
							Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj8);
							Transform transform4 = _front3Sprite.transform;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1612 @ rax_v91 (UnityEngine.Transform)+10]");
							bool flag5 = (nint)0 == 0;
							object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1612 @ rax_v91 (UnityEngine.Transform)+10]");
							Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj9);
							CheckRenderer();
							Transform parent = ((ArcadeSprite)this)._spriteRenderer.transform;
							Transform transform5 = _back2Sprite.transform;
							transform5.SetParent(parent, worldPositionStays: true);
							CheckRenderer();
							Transform parent2 = ((ArcadeSprite)this)._spriteRenderer.transform;
							Transform transform6 = _front2Sprite.transform;
							transform6.SetParent(parent2, worldPositionStays: true);
							CheckRenderer();
							Transform parent3 = ((ArcadeSprite)this)._spriteRenderer.transform;
							Transform transform7 = _back3Sprite.transform;
							transform7.SetParent(parent3, worldPositionStays: true);
							CheckRenderer();
							Transform parent4 = ((ArcadeSprite)this)._spriteRenderer.transform;
							Transform transform8 = _front3Sprite.transform;
							transform8.SetParent(parent4, worldPositionStays: true);
							List<Sprite> animation = SpriteManager.GetAnimation("bbbats_2_Back_0", 1, 4, "character_batsbatsbats", (byte)(int)text != 0);
							List<Sprite> animation2 = SpriteManager.GetAnimation("bbbats_2_Front_0", 1, 4, "character_batsbatsbats", (byte)(int)text != 0);
							List<Sprite> animation3 = SpriteManager.GetAnimation("bbbats_3_Back_0", 1, 4, "character_batsbatsbats", (byte)(int)text != 0);
							List<Sprite> animation4 = SpriteManager.GetAnimation("bbbats_3_Front_0", 1, 4, "character_batsbatsbats", (byte)(int)text != 0);
							GameObject gameObject5 = _back2Sprite.gameObject;
							_ = 0;
							bool flag6 = (object)gameObject5 == null;
							SpriteAnimation back2Anim;
							if (gameObject5.TryGetComponent<SpriteAnimation>(out System.Runtime.CompilerServices.Unsafe.As<object, SpriteAnimation>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103))))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
								back2Anim = (SpriteAnimation)0;
							}
							else
							{
								back2Anim = gameObject5.AddComponent<SpriteAnimation>();
							}
							_back2Anim = back2Anim;
							bool startRandomFrame = default(bool);
							Action onComplete = default(Action);
							bool autoSetAnimation = default(bool);
							_back2Anim.AddAnimation("idle", animation, 8, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
							GameObject gameObject6 = _front2Sprite.gameObject;
							_ = 0;
							bool flag7 = (object)gameObject6 == null;
							SpriteAnimation front2Anim;
							if (gameObject6.TryGetComponent<SpriteAnimation>(out System.Runtime.CompilerServices.Unsafe.As<object, SpriteAnimation>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103))))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
								front2Anim = (SpriteAnimation)0;
							}
							else
							{
								front2Anim = gameObject6.AddComponent<SpriteAnimation>();
							}
							_front2Anim = front2Anim;
							_front2Anim.AddAnimation("idle", animation2, 8, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
							GameObject gameObject7 = _back3Sprite.gameObject;
							_ = 0;
							bool flag8 = (object)gameObject7 == null;
							SpriteAnimation back3Anim;
							if (gameObject7.TryGetComponent<SpriteAnimation>(out System.Runtime.CompilerServices.Unsafe.As<object, SpriteAnimation>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103))))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
								back3Anim = (SpriteAnimation)0;
							}
							else
							{
								back3Anim = gameObject7.AddComponent<SpriteAnimation>();
							}
							_back3Anim = back3Anim;
							_back3Anim.AddAnimation("idle", animation3, 8, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
							GameObject gameObject8 = _front3Sprite.gameObject;
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v885 @ rdi_v35 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							_ = 0;
							bool flag9 = (object)gameObject8 == null;
							SpriteAnimation front3Anim;
							if (gameObject8.TryGetComponent<SpriteAnimation>(out System.Runtime.CompilerServices.Unsafe.As<object, SpriteAnimation>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103))))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
								front3Anim = (SpriteAnimation)0;
							}
							else
							{
								front3Anim = gameObject8.AddComponent<SpriteAnimation>();
							}
							_front3Anim = front3Anim;
							_front3Anim.AddAnimation("idle", animation4, 8, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
							_back2Anim.SetAnimation("idle");
							_front2Anim.SetAnimation("idle");
							_back3Anim.SetAnimation("idle");
							_front3Anim.SetAnimation("idle");
							return;
						}
					}
				}
			}
		}
		goto IL_0a0e;
		IL_0a0e:
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		//IL_0204: Invalid comparison between O and F4
		//IL_023b: Invalid comparison between O and F4
		//IL_0272: Invalid comparison between O and F4
		//IL_02a9: Invalid comparison between O and F4
		base.OnUpdate();
		int num = base.Depth;
		bool flag = base.flipX;
		SpriteRenderer back2Sprite = _back2Sprite;
		if ((object)_back2Sprite != null && ((UnityEngine.Object)back2Sprite).m_CachedPtr != (IntPtr)0)
		{
			int sortingOrder = num - 1;
			_back2Sprite.sortingOrder = sortingOrder;
			_back2Sprite.flipX = flag;
		}
		SpriteRenderer front2Sprite = _front2Sprite;
		if ((object)_front2Sprite != null && ((UnityEngine.Object)front2Sprite).m_CachedPtr != (IntPtr)0)
		{
			int sortingOrder2 = num + 1;
			_front2Sprite.sortingOrder = sortingOrder2;
			_front2Sprite.flipX = flag;
		}
		SpriteRenderer back3Sprite = _back3Sprite;
		if ((object)_back3Sprite != null && ((UnityEngine.Object)back3Sprite).m_CachedPtr != (IntPtr)0)
		{
			int sortingOrder3 = num - 2;
			_back3Sprite.sortingOrder = sortingOrder3;
			_back3Sprite.flipX = flag;
		}
		SpriteRenderer front3Sprite = _front3Sprite;
		if ((object)_front3Sprite != null && ((UnityEngine.Object)front3Sprite).m_CachedPtr != (IntPtr)0)
		{
			int sortingOrder4 = num + 2;
			_front3Sprite.sortingOrder = sortingOrder4;
			_front3Sprite.flipX = flag;
		}
		float num2 = PAmount();
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)4f))
		{
			_back2Sprite.enabled = true;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f))
		{
			_front2Sprite.enabled = true;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)6f))
		{
			_back3Sprite.enabled = true;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)7f))
		{
			_front3Sprite.enabled = true;
		}
	}

	public override void LevelUp()
	{
		base.LevelUp();
		Battilia2Weapon battilia2Weapon = Battilia2Weapon;
		if ((object)Battilia2Weapon == null || ((UnityEngine.Object)battilia2Weapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Battilia2Weapon battilia2Weapon2 = Battilia2Weapon;
		float num = (float)base._level * 0.1f;
		float num2 = num + _baseWeaponPower;
		LimitBreakData accumulatedLimitBreaks = battilia2Weapon2.accumulatedLimitBreaks;
		if ((object)accumulatedLimitBreaks._003Cpower_003Ek__BackingField != null)
		{
			Battilia2Weapon battilia2Weapon3 = Battilia2Weapon;
			LimitBreakData accumulatedLimitBreaks2 = battilia2Weapon3.accumulatedLimitBreaks;
			if ((object)accumulatedLimitBreaks2._003Cpower_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			object obj = default(object);
			num2 += (float)obj;
		}
		Battilia2Weapon battilia2Weapon4 = Battilia2Weapon;
		WeaponData currentWeaponData = ((Weapon)battilia2Weapon4)._currentWeaponData;
		currentWeaponData._003Cpower_003Ek__BackingField = num2;
	}

	public override void Revive(float percentage = 1f, bool instantRevival = false)
	{
		//IL_006b: Expected O, but got I4
		//IL_00b6: Expected I4, but got F4
		base.Revive(percentage, instantRevival);
		if (_followers <= 20 && instantRevival && _coherenceSync.HasStateAuthority)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.5f;
			soundConfig.Volume = (float?)(object)1;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
			int everyXLevels = default(int);
			bool spawnWithoutAuthority = default(bool);
			CharacterController characterController = GM.Core.AddFollower(CharacterType.FOLLOWER_BATSBATSBATS, this, AIType.ChaoticAF, (byte)(int)num != 0, everyXLevels, spawnWithoutAuthority);
			if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
			{
				characterController._permanentInvulnerability = false;
				characterController.IsInvul = false;
				characterController._invincibilityTimer = 0f;
				characterController._003CTrackedByCamera_003Ek__BackingField = false;
				int followers = _followers + 1;
				_followers = followers;
			}
		}
	}

	public override void DoPostRevivalActions(CharacterController revived, bool instantRevival = false)
	{
	}
}
