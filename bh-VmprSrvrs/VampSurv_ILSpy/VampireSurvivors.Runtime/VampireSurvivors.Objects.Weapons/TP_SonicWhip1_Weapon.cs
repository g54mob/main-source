using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_SonicWhip1_Weapon : TP_WhipCore1_Weapon
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public int localIndex;

		public TP_SonicWhip1_Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_012f: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00e9: Expected I, but got O
			//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
							float2 position = ((ArcadeSprite)0).position;
							TP_SonicWhip1_Weapon tP_SonicWhip1_Weapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)gameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		_weaponNodeType = WeaponType.TP_SONICWHIP1_NODE;
	}

	public override float PDuration()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num2 = default(float);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._sineDuration != null)
			{
				float num = characterController2.PDuration();
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
				float value = characterController3._sineDuration.Value;
				num2 = value * num2;
				goto IL_011b;
			}
		}
		float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		goto IL_011b;
		IL_011b:
		bool flag = !(3f > num2);
		float num4 = 3f;
		if (!flag)
		{
			num4 = num2;
		}
		float duration = base.Duration;
		return duration * num4;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0041: Invalid comparison between O and F4
		//IL_0052: Expected F4, but got O
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0218: Invalid comparison between O and F4
		//IL_0073: Invalid comparison between O and F4
		//IL_0084: Expected F4, but got O
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00f0: Expected F4, but got O
		//IL_01cb: Invalid comparison between F4 and I4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num = base.PAmount();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		float num2 = (float)vector;
		if (!flag)
		{
			float num3 = base.PAmount();
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			num2 = (float)vector;
			if (!flag2)
			{
				bool flag3 = true;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj = flag3 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj <= 0)
					{
						Vector2 playerPos = base.PlayerPos;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						num2 = (float)playerPos;
					}
					else
					{
						_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass2_0();
						CS_0024_003C_003E8__locals8._003C_003E4__this = this;
						CS_0024_003C_003E8__locals8.localIndex = (flag3 ? 1 : 0);
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_012f: Expected O, but got I4
							//IL_00b4: Expected O, but got I
							//IL_00e9: Expected I, but got O
							//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
							//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
							//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals8._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj3 == null)
									{
										return;
									}
									GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals8._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
											float2 position2 = ((ArcadeSprite)0).position;
											TP_SonicWhip1_Weapon tP_SonicWhip1_Weapon = CS_0024_003C_003E8__locals8._003C_003E4__this;
											if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
											{
												nint num9 = (nint)gameObject2;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
												return;
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num4 = (float)(flag3 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num2 = num4 * 0.001f;
						Timer lastShotTimer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
					float num5 = base.PAmount();
				}
				while (num2 > (float)(flag3 ? 1 : 0));
			}
		}
		float num6 = base.PInterval();
		float num7 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num7 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num8 = base.PInterval();
			_lastFiringInterval = num2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		if (++_fireCounter % _specialCounter == 0)
		{
			base.OnSpecialCounter(skipTriggers);
		}
		if (_fireCounter % _subWeaponCounter == 0)
		{
			base.OnSubWeaponCounter(skipTriggers);
		}
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_0274: Expected O, but got I4
		//IL_0248: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if (!component._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject2 = default(GameObject);
			Projectile component2 = gameObject2.GetComponent<Projectile>();
			if (!component2.HasAlreadyHitObject(component))
			{
				float chanceFromArray = base.GetChanceFromArray();
				float chance = base.Chance;
				float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				float num2 = characterController.PCurse();
				object obj2 = default(object);
				object obj = obj2 * obj2;
				object obj3 = obj2 * obj;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					object obj4 = default(object);
					bool flag = obj4 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018746AA38h\"");
					HitVfxType hitVfxType = HitVfxType.Default;
					if (!flag)
					{
						hitVfxType = HitVfxType.None;
					}
					object obj5 = hitVfxType & (_003F?)component._003CResRosary_003Ek__BackingField;
					if (obj5 != null)
					{
						float2 position = component.position;
						PlayerOptionsData config = _playerOptions.Config;
						if (config._003CDamageNumbersEnabled_003Ek__BackingField)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
							object obj6 = UnityEngine.Random.RandomRangeInt(128, 256);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE780");
						}
						WeaponData currentWeaponData = _currentWeaponData;
						bool flag2 = _currentWeaponData == null;
						HitVfxType showHitVfx = HitVfxType.Default;
						if (!flag2)
						{
							showHitVfx = currentWeaponData._003ChitVFX_003Ek__BackingField;
						}
						float knockback = base.Knockback;
						component.GetDamagedSpecial(component._hp, showHitVfx, knockback, WeaponType.VOID, hasKb: false, (Vector3?)(object)0);
						float num3 = component._hp + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
						((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num3;
						goto IL_0200;
					}
				}
				base.DealDamage(component);
			}
		}
		goto IL_0200;
		IL_0200:
		return false;
	}

	protected bool IsInstaKill()
	{
		//IL_00ea: Expected I4, but got O
		float chanceFromArray = base.GetChanceFromArray();
		float chance = base.Chance;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PCurse();
				object obj2 = default(object);
				object obj = obj2 * obj2;
				object obj3 = obj2 * obj;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
				object obj4 = obj3 - obj2;
				bool flag2 = obj4 == null;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				return flag4 & flag3;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected void ShowBigDamage(float value, Vector3 position)
	{
		//IL_006d: Expected O, but got I4
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CDamageNumbersEnabled_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
			object obj = UnityEngine.Random.RandomRangeInt(128, 256);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE780");
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}
}
