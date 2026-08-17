using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Malphas_Character : TP_Character
{
	private Vector2 _whipOffset;

	private float _spriteWhipOffset;

	private SpriteRenderer _back2Sprite;

	private SpriteAnimation _back2Anim;

	private Weapon StartingWeapon;

	private Weapon HiddenWeapon;

	private float _baseWeaponPower = 0.45f;

	private WeaponType WeaponT1 = WeaponType.TP_ELEC2;

	private WeaponType WeaponT2 = WeaponType.THOUSAND;

	public override bool NeedsCart => false;

	public override float2 GetVectorWhipOffset
	{
		get
		{
			CheckRenderer();
			if ((object)((ArcadeSprite)this)._spriteRenderer != null)
			{
				Vector2 vector = ((ArcadeSprite)this)._spriteRenderer.size;
				bool flag = base.flipX;
				CheckRenderer();
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					Vector2 vector2 = ((ArcadeSprite)this)._spriteRenderer.size;
					float2 result = default(float2);
					return result;
				}
			}
			return (float2)new NullReferenceException();
		}
	}

	public override float GetSpriteWhipOffset => _spriteWhipOffset;

	public override bool ShouldCollideWithWalls()
	{
		return false;
	}

	protected override void OnStop()
	{
	}

	public unsafe override void AfterFullInitialization()
	{
		//IL_032f: Expected I4, but got O
		//IL_041e: Expected I4, but got O
		base.AfterFullInitialization();
		if ((object)((CharacterController)this)._spriteTrail != null)
		{
			((CharacterController)this)._spriteTrail.Reset();
			SpriteTrail spriteTrail = ((CharacterController)this)._spriteTrail;
			if ((object)((CharacterController)this)._spriteTrail != null)
			{
				spriteTrail._MaxHistory = 0;
				((CharacterController)this)._spriteTrail.InitialiseGhosts(expandExisting: true);
				base.SetBloodColor(2228224u);
				CheckRenderer();
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					((ArcadeSprite)this)._spriteRenderer.enabled = false;
					if ((object)((CharacterController)this)._weaponsManager != null)
					{
						Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponT1, searchHidden: true);
						StartingWeapon = weaponByType;
						Renderer startingWeapon = (Renderer)(object)StartingWeapon;
						if ((object)StartingWeapon == null || ((UnityEngine.Object)startingWeapon).m_CachedPtr == (IntPtr)0)
						{
							goto IL_04a6;
						}
						Weapon startingWeapon2 = StartingWeapon;
						if ((object)StartingWeapon != null)
						{
							WeaponData currentWeaponData = startingWeapon2._currentWeaponData;
							if (startingWeapon2._currentWeaponData != null)
							{
								currentWeaponData._003Cpower_003Ek__BackingField = _baseWeaponPower;
								goto IL_04a6;
							}
						}
					}
				}
			}
		}
		goto IL_0456;
		IL_0456:
		throw new NullReferenceException();
		IL_04e9:
		float2 float5 = base.cachedPosition;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		string text = default(string);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, vector, "character_tp_malphas", text);
		((UnityEngine.Object)spriteRenderer).SetName("MalphasAnim");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v45 (UnityEngine.SpriteRenderer)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v45 (UnityEngine.SpriteRenderer)+10]");
		Renderer.set_sortingOrder_Injected((IntPtr)0, 1);
		_back2Sprite = spriteRenderer;
		CheckRenderer();
		Transform parent = ((ArcadeSprite)this)._spriteRenderer.transform;
		Transform transform = _back2Sprite.transform;
		transform.SetParent(parent, worldPositionStays: true);
		Transform transform2 = _back2Sprite.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ rax_v56 (UnityEngine.Transform)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ rax_v56 (UnityEngine.Transform)+10]");
		Vector2 value = default(Vector2);
		Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
		List<Sprite> animation = SpriteManager.GetAnimation("TP_Malphas_w0", 1, 7, "character_tp_malphas", (byte)(int)text != 0);
		GameObject gameObject2 = _back2Sprite.gameObject;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rdi_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		bool flag3 = (object)gameObject2 == null;
		SpriteAnimation back2Anim = ((!gameObject2.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject2.AddComponent<SpriteAnimation>() : component);
		_back2Anim = back2Anim;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_back2Anim.AddAnimation("idle", animation, 12, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
		_back2Anim.SetAnimation("idle");
		SetCustomOutlineReferenceRenderer(_back2Sprite);
		_customDamageOverlayRenderer = _back2Sprite;
		return;
		IL_04a6:
		if ((object)((CharacterController)this)._weaponsManager != null)
		{
			Weapon weaponByType2 = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponT2, searchHidden: true);
			HiddenWeapon = weaponByType2;
			Renderer hiddenWeapon = (Renderer)(object)HiddenWeapon;
			if ((object)HiddenWeapon == null || ((UnityEngine.Object)hiddenWeapon).m_CachedPtr == (IntPtr)0)
			{
				goto IL_04e9;
			}
			Weapon hiddenWeapon2 = HiddenWeapon;
			if ((object)HiddenWeapon != null)
			{
				WeaponData currentWeaponData2 = hiddenWeapon2._currentWeaponData;
				if (hiddenWeapon2._currentWeaponData != null)
				{
					currentWeaponData2._003Cpower_003Ek__BackingField = _baseWeaponPower;
					goto IL_04e9;
				}
			}
		}
		goto IL_0456;
	}

	public override void LevelUp()
	{
		base.LevelUp();
		Weapon startingWeapon = StartingWeapon;
		if ((object)StartingWeapon == null || ((UnityEngine.Object)startingWeapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Weapon startingWeapon2 = StartingWeapon;
		float num = (float)((CharacterController)this)._level * 0.1f;
		float num2 = num + _baseWeaponPower;
		LimitBreakData accumulatedLimitBreaks = startingWeapon2.accumulatedLimitBreaks;
		if ((object)accumulatedLimitBreaks._003Cpower_003Ek__BackingField != null)
		{
			Weapon startingWeapon3 = StartingWeapon;
			LimitBreakData accumulatedLimitBreaks2 = startingWeapon3.accumulatedLimitBreaks;
			if ((object)accumulatedLimitBreaks2._003Cpower_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			object obj = default(object);
			num2 += (float)obj;
		}
		Weapon startingWeapon4 = StartingWeapon;
		WeaponData currentWeaponData = startingWeapon4._currentWeaponData;
		currentWeaponData._003Cpower_003Ek__BackingField = num2;
		Weapon hiddenWeapon = HiddenWeapon;
		if ((object)HiddenWeapon != null && ((UnityEngine.Object)hiddenWeapon).m_CachedPtr != (IntPtr)0)
		{
			Weapon hiddenWeapon2 = HiddenWeapon;
			WeaponData currentWeaponData2 = hiddenWeapon2._currentWeaponData;
			float num3 = num2 * 0.5f;
			currentWeaponData2._003Cpower_003Ek__BackingField = num3;
		}
	}
}
