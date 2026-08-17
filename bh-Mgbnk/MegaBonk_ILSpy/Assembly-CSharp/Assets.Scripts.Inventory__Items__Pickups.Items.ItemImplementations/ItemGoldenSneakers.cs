using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGoldenSneakers(ItemInventory itemInventoryRef) : ItemBase(itemInventoryRef)
{
	private float goldPerMeter;

	private float goldPerMeterBase = 0.1f;

	private float checkInterval = 0.5f;

	private float nextCheckTime;

	private Vector3 lastPos;

	private float accumulatedGold;

	protected override void OnInitOrAmountChanged()
	{
		//IL_004f: Expected O, but got I4
		//IL_0034: Expected O, but got F4
		object obj = amount - 1;
		float num = goldPerMeterBase * 0.5f;
		float num2 = num * (float)obj;
		float num3 = num2 + goldPerMeterBase;
		goldPerMeter = num3;
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		lastPos = (Vector3)position.x;
		_ = position.z;
	}

	public unsafe override void Tick()
	{
		//IL_0247: Expected I, but got O
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0203: Expected O, but got F4
		//IL_01cf: Expected O, but got Ref
		//IL_01cf: Expected I4, but got F8
		if (!(nextCheckTime > MyTime.time))
		{
			float num = MyTime.time + checkInterval;
			nextCheckTime = num;
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			float num2 = position.x - (float)lastPos;
			float num3 = position.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemGoldenSneakers)+44]");
			float num4 = num3 - 0f;
			float num5 = position.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemGoldenSneakers)+48]");
			float num6 = num5 - 0f;
			nint num7 = (nint)typeof(Math);
			float num8 = num4 * num4;
			float num9 = num2 * num2;
			float num10 = num6 * num6;
			float num11 = num8 + num9;
			float num12 = num11 + num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v11 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num13 = Math.Sqrt(num12);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
			object obj = 0 * goldPerMeter;
			double num14 = (double)obj + (double)accumulatedGold;
			accumulatedGold = (float)num14;
			if (!(num14 < 1.0))
			{
				double num15 = Math.Floor(num14);
				double num16 = (double)accumulatedGold - num15;
				accumulatedGold = (float)num16;
				Transform transform2 = MyPlayer.Instance.transform;
				Vector3 position2 = transform2.position;
				float num17 = default(float);
				MoneyUtility.SpawnMoney((int)num15, (Vector3)(&num17));
			}
			Transform transform3 = MyPlayer.Instance.transform;
			Vector3 position3 = transform3.position;
			lastPos = (Vector3)position3.x;
			_ = position3.z;
		}
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
}
