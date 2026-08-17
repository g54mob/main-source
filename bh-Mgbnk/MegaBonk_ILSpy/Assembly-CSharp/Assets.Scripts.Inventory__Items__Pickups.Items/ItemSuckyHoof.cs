using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public class ItemSuckyHoof : ItemBase
{
	private float range = 100f;

	private float interval;

	private float nextSuckTime;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * 50f;
		float num2 = 15f / (float)amount;
		float num3 = num + 100f;
		interval = num2;
		range = num3;
	}

	public unsafe override void Tick()
	{
		//IL_0061: Expected O, but got Ref
		//IL_0073: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		if (nextSuckTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + interval;
		nextSuckTime = num;
		EffectManager.Instance.MagnetEffect();
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		PickupManager instance = PickupManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num2 = default(float);
		int layerMask = default(int);
		Collider[] array = Physics.OverlapSphere((Vector3)(&num2), range, layerMask);
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			if (array[obj2] != null)
			{
				Pickup component = array[obj2].GetComponent<Pickup>();
				if (component != null && component.ePickup == EPickup.Xp)
				{
					Transform transform2 = MyPlayer.Instance.transform;
					component.StartFollowingPlayer(transform2);
				}
			}
			obj2++;
			obj = obj2;
		}
	}

	public ItemSuckyHoof(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
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

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}
}
