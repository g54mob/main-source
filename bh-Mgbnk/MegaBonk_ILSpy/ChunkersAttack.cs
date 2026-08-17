using System;
using System.Collections;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class ChunkersAttack : ConstantAttack
{
	public RandomSfx regenSfx;

	public RotatingProjectiles rotatingProjectiles;

	private int currentAmount;

	private float shieldReadyAtTime;

	private float rotationSpeed;

	private float cooldown;

	private float minCooldown;

	private float duration;

	private int amount;

	private float startTime;

	private float stopTime;

	private float nextStartTime;

	private bool isAttacking;

	protected override void Init()
	{
		//IL_0095: Expected I, but got O
		//IL_0120: Expected O, but got I4
		//IL_00cd: Expected O, but got I
		//IL_00d6: Expected O, but got I4
		//IL_0235: Expected O, but got I
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_01b5: Expected I, but got O
		//IL_01bd: Expected I, but got O
		//IL_0208: Expected I4, but got O
		RotatingProjectiles rotatingProjectiles = this.rotatingProjectiles;
		bool flag = (object)this.rotatingProjectiles == null;
		Type type = (Type)(object)this;
		if (!flag)
		{
			rotatingProjectiles.weaponBase = weaponBase;
			this.rotatingProjectiles.TryInit();
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EStat));
			Array values = Enum.GetValues(typeFromHandle);
			bool flag2 = values == null;
			type = typeFromHandle;
			if (!flag2)
			{
				IEnumerator enumerator = values.GetEnumerator();
				type = (Type)(object)values;
				IEnumerator enumerator2 = default(IEnumerator);
				object obj9 = default(object);
				while (enumerator2 != null)
				{
					nint num = (nint)enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r10_v6 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_010d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r10_v6 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj = 0;
					object obj2 = 0;
					while (true)
					{
						object obj3 = obj2 + obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ r8_v6+v361 @ rax_v47*8]");
						if (0 == (nint)typeof(IEnumerator))
						{
							break;
						}
						obj2++;
						object obj4 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r10_v6 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						if ((nint)obj4 < 0)
						{
							continue;
						}
						goto IL_010d;
					}
					object obj5 = obj2 + obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ r8_v6+8+v418 @ rcx_v35*8]");
					object obj6 = (nint)0 << 4;
					object obj7 = obj6 + 312;
					object obj8 = obj7 + num;
					goto IL_0125;
					IL_010d:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
					obj = 0;
					goto IL_0125;
					IL_0125:
					if (enumerator2.MoveNext())
					{
						bool flag3 = enumerator2 == null;
						type = (Type)enumerator2;
						if (!flag3)
						{
							object current = enumerator2.Current;
							bool flag4 = current == null;
							type = (Type)enumerator2;
							if (!flag4)
							{
								nint num2 = (nint)typeof(EStat);
								nint num3 = (nint)current;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v19 (Il2CppClass<System.Object>)+40]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v8 (Il2CppClass<Assets.Scripts.Menu.Shop.EStat>)+40]");
								bool flag5 = num4 != 0;
								type = (Type)current;
								if (!flag5)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
									OnStatUpdate((EStat)obj9);
									type = (Type)(object)this;
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A690");
					nextStartTime = 2f;
					return;
				}
				throw new NullReferenceException();
			}
		}
		throw new NullReferenceException();
	}

	private void FindNewTimes()
	{
		startTime = MyTime.time;
		float num = (stopTime = MyTime.time + duration) + cooldown;
		nextStartTime = num;
	}

	public void StartAttack()
	{
		//IL_0026: Expected O, but got I
		//IL_003c: Expected O, but got I
		isAttacking = true;
		startTime = MyTime.time;
		float num = (stopTime = MyTime.time + duration) + cooldown;
		nextStartTime = num;
		Component component = rotatingProjectiles;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v2 (UnityEngine.Component)+30]");
		((AudioSource)0).Play();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v2 (UnityEngine.Component)+38]");
		((AudioSource)0).Play();
		_ = MyTime.time;
		float num2 = MyTime.time;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v2 (UnityEngine.Component)+9C]");
		float num3 = num2 + 0f;
		GameObject gameObject = component.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = component.gameObject;
		gameObject2.SetActive(value: true);
	}

	public void StopAttack()
	{
		RotatingProjectiles rotatingProjectiles = this.rotatingProjectiles;
		isAttacking = false;
		rotatingProjectiles.fadeTimer = 0f;
		rotatingProjectiles.isActive = false;
	}

	private void FixedUpdate()
	{
		//IL_0030: Expected O, but got I
		//IL_0046: Expected O, but got I
		if (!isAttacking)
		{
			if (!(MyTime.time < nextStartTime))
			{
				isAttacking = true;
				startTime = MyTime.time;
				float num = (stopTime = MyTime.time + duration) + cooldown;
				nextStartTime = num;
				Component component = this.rotatingProjectiles;
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rbx_v5 (UnityEngine.Component)+30]");
				((AudioSource)0).Play();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rbx_v5 (UnityEngine.Component)+38]");
				((AudioSource)0).Play();
				_ = MyTime.time;
				float num2 = MyTime.time;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rbx_v5 (UnityEngine.Component)+9C]");
				float num3 = num2 + 0f;
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: false);
				GameObject gameObject2 = component.gameObject;
				gameObject2.SetActive(value: true);
				return;
			}
			if (!isAttacking)
			{
				return;
			}
		}
		if (!(MyTime.time < stopTime))
		{
			RotatingProjectiles rotatingProjectiles = this.rotatingProjectiles;
			isAttacking = false;
			rotatingProjectiles.fadeTimer = 0f;
			rotatingProjectiles.isActive = false;
		}
	}

	public override float GetAuraRotationSpeed()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	protected override void OnWeaponStatUpdate(EStat stat, EWeapon weapon)
	{
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		if (weaponData.eWeapon == weapon)
		{
			OnStatUpdate(stat);
		}
	}

	protected override void OnStatUpdate(EStat stat)
	{
		//IL_000e: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_0046: Expected O, but got I8
		//IL_0060: Expected O, but got I8
		object obj = stat - 9;
		if ((nint)obj <= 7)
		{
			object obj2 = stat - 9;
			object obj3 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rcx_v1+352890+v19 @ rax_v2*4]");
			object obj4 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v27 @ rax_v4 (should have been resolved before IL gen)");
		}
	}

	private void SetDuration()
	{
		float num = WeaponUtility.GetDuration(weaponBase);
		RotatingProjectiles rotatingProjectiles = this.rotatingProjectiles;
		duration = num;
		rotatingProjectiles.duration = num;
	}

	private void SetProjectiles()
	{
		int num = (amount = WeaponUtility.GetAttackQuantity(weaponBase));
		rotatingProjectiles.SetAmount(num);
	}

	private void SetSize()
	{
		RotatingProjectiles rotatingProjectiles = this.rotatingProjectiles;
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		this.rotatingProjectiles.TryInit();
		rotatingProjectiles.scaleMultiplier = attackSizeMultiplier;
		float num = attackSizeMultiplier;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (RotatingProjectiles)+AC]");
		float num2 = num * 0f;
		Vector3 projectileScale = default(Vector3);
		rotatingProjectiles.projectileScale = projectileScale;
		float num3 = attackSizeMultiplier * rotatingProjectiles.baseProjectileRadius;
		float num4 = attackSizeMultiplier * 0.33f;
		rotatingProjectiles.projectileRadius = num3;
		float num5 = num3 + rotatingProjectiles.baseDistance;
		float distance = num5 + num4;
		rotatingProjectiles.distance = distance;
	}

	private void SetProjectileSpeed()
	{
		//IL_0032: Invalid comparison between I4 and F4
		//IL_0086: Expected F4, but got I4
		RotatingProjectiles rotatingProjectiles = this.rotatingProjectiles;
		float projectileSpeed = WeaponUtility.GetProjectileSpeed(weaponBase);
		float num = projectileSpeed * 50f;
		if (!(0f > num))
		{
			if (num > rotatingProjectiles.maxRotationSpeed)
			{
				rotatingProjectiles.rotationSpeed = rotatingProjectiles.maxRotationSpeed;
				return;
			}
		}
		else
		{
			num = 0f;
		}
		rotatingProjectiles.rotationSpeed = num;
	}

	private void SetCooldown()
	{
		float weaponCooldown = WeaponUtility.GetWeaponCooldown(base.weaponBase);
		WeaponBase weaponBase = base.weaponBase;
		cooldown = weaponCooldown;
		WeaponData weaponData = weaponBase.weaponData;
		float num = (minCooldown = weaponData.endCooldown * 0.1f);
		if (num > weaponCooldown)
		{
			cooldown = num;
		}
	}
}
