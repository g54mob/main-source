using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemCampfire : ItemBase
{
	private float healthRegenPerMinutePerAmount = 1100f;

	private float healthRegen;

	public Campfire campfire;

	private Vector3 campfirePos;

	private float setupTime = 0.6f;

	private float distThreshold = 1.75f;

	private float startCampfireTime;

	private bool isCampActive;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * healthRegenPerMinutePerAmount;
		healthRegen = num;
	}

	public ItemCampfire(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
		RemoveCamp();
	}

	public override void Tick()
	{
		//IL_018d: Expected I, but got O
		//IL_00b7: Expected F8, but got I4
		//IL_012d: Expected O, but got F4
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		nint num = (nint)typeof(Math);
		float num2 = (float)campfirePos - position.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemCampfire)+44]");
		float num3 = 0f - position.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemCampfire)+48]");
		float num4 = 0f - position.z;
		float num5 = num3 * num3;
		float num6 = num2 * num2;
		float num7 = num4 * num4;
		float num8 = num5 + num6;
		float num9 = num8 + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v7 (Il2CppClass<System.Math>)+E4]");
		double num10;
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			num10 = 0.0;
		}
		else
		{
			num10 = Math.Sqrt(num9);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		if (num10 > (double)distThreshold)
		{
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position2 = transform2.position;
			campfirePos = (Vector3)position2.x;
			_ = position2.z;
			bool flag = !isCampActive;
			float num11 = MyTime.time + setupTime;
			startCampfireTime = num11;
			if (flag)
			{
				goto IL_021b;
			}
			RemoveCamp();
		}
		if (!isCampActive)
		{
			goto IL_021b;
		}
		return;
		IL_021b:
		if (MyTime.time > startCampfireTime)
		{
			CreateCamp();
		}
	}

	private unsafe void CreateCamp()
	{
		//IL_003c: Expected O, but got Ref
		//IL_004e: Expected I, but got O
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_015b: Expected O, but got F4
		//IL_00d8: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		Transform transform = instance.playerRenderer.transform;
		Vector3 forward = transform.forward;
		float num = default(float);
		Vector3 vector = RaycastUtility.RayToGround((Vector3)(&num), 5f);
		nint num2 = (nint)typeof(SpawnPositions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v12 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
		nint num3 = 0;
		float num4 = vector.x - (float)SpawnPositions.INVALID_POS;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rax_v13 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
		object obj2 = default(object);
		object obj = obj2 - 0;
		float num5 = vector.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rax_v13 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
		float num6 = num5 - 0f;
		object obj3 = obj * obj;
		float num7 = num4 * num4;
		float num8 = num6 * num6;
		float num9 = (float)obj3 + num7;
		float num10 = num9 + num8;
		if (!(9.9999994E-11f > num10))
		{
			isCampActive = true;
			if (campfire == null)
			{
				EffectManager instance2 = EffectManager.Instance;
				GameObject gameObject = UnityEngine.Object.Instantiate(instance2.campfire);
				Campfire component = gameObject.GetComponent<Campfire>();
				campfire = component;
			}
			campfire.StartFire((Vector3)(&num));
			StatModifier statModifier = new StatModifier();
			statModifier.modification = healthRegen;
			statModifier.modifyType = EStatModifyType.Flat;
			statModifier.stat = EStat.HealthRegen;
			SetStat(statModifier);
		}
		else
		{
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position = transform2.position;
			campfirePos = (Vector3)position.x;
			_ = position.z;
			float num11 = MyTime.time + setupTime;
			startCampfireTime = num11;
		}
	}

	private void RemoveCamp()
	{
		if (isCampActive)
		{
			isCampActive = false;
			campfire.EndFire();
			StatModifier statModifier = new StatModifier();
			statModifier.modifyType = EStatModifyType.Flat;
			statModifier.stat = EStat.HealthRegen;
			SetStat(statModifier);
		}
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}
}
