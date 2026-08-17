using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBobDead : ItemBase
{
	private string damageSource;

	public const int maxGhosts = 80;

	private float unitsPerProjectile;

	private float minSpawnTime;

	private float nextCheckTime;

	private float accumulatedDistance;

	private Vector3 lastPos;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0034: Expected O, but got F4
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		lastPos = (Vector3)position.x;
		_ = position.z;
	}

	public override void Tick()
	{
		//IL_0295: Expected I, but got O
		//IL_010a: Expected F8, but got I4
		//IL_0251: Expected O, but got F4
		//IL_019a: Expected F4, but got I4
		//IL_0209: Invalid comparison between F4 and I4
		if (nextCheckTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + minSpawnTime;
		nextCheckTime = num;
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		float num2 = position.x - (float)lastPos;
		float num3 = position.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBobDead)+4C]");
		float num4 = num3 - 0f;
		float num5 = position.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBobDead)+50]");
		float num6 = num5 - 0f;
		nint num7 = (nint)typeof(Math);
		float num8 = num4 * num4;
		float num9 = num2 * num2;
		float num10 = num6 * num6;
		float num11 = num8 + num9;
		float num12 = num11 + num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rcx_v11 (Il2CppClass<System.Math>)+E4]");
		double num13;
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			num13 = 0.0;
		}
		else
		{
			num13 = Math.Sqrt(num12);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		double num14 = num13 + (double)accumulatedDistance;
		accumulatedDistance = (float)num14;
		if (!(num14 < (double)unitsPerProjectile))
		{
			accumulatedDistance = 0f;
			if (amount > 0)
			{
				float num15 = 0f;
				do
				{
					MyPlayer instance = MyPlayer.Instance;
					float damage = instance.baseDamage * 1.5f;
					float stat = PlayerStats.GetStat(EStat.DurationMultiplier);
					float duration = stat * 10f;
					EffectManager.Instance.SpawnGhostProjectile(damage, duration, damageSource);
					num15++;
				}
				while (num15 < (float)amount);
			}
		}
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position2 = transform2.position;
		lastPos = (Vector3)position2.x;
		_ = position2.z;
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		return instance.baseDamage * 1.5f;
	}

	private void SpawnGhost()
	{
		MyPlayer instance = MyPlayer.Instance;
		float damage = instance.baseDamage * 1.5f;
		float stat = PlayerStats.GetStat(EStat.DurationMultiplier);
		float duration = stat * 10f;
		EffectManager.Instance.SpawnGhostProjectile(damage, duration, damageSource);
	}

	private float GetDuration()
	{
		float stat = PlayerStats.GetStat(EStat.DurationMultiplier);
		return stat * 10f;
	}

	public unsafe ItemBobDead(ItemInventory itemInventoryRef)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		damageSource = ((Enum)(&obj)).ToString();
		unitsPerProjectile = 14f;
		minSpawnTime = 0.05f;
		base._002Ector(itemInventoryRef);
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
