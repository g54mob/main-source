using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class TP_Sara_Character : TP_Character
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__2_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CRevive_003Eb__2_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1405;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		((CharacterController)this)._isLastBreathEnabled = true;
		Action onLastBreath = LastBreath;
		((CharacterController)this)._onLastBreath = onLastBreath;
	}

	public void LastBreath()
	{
		//IL_008d->IL0155: Incompatible stack heights: 4 vs 0
		//IL_0065->IL0155: Incompatible stack heights: 4 vs 0
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		List<CharacterController>.Enumerator pos = default(List<CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			Transform transform = null;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)transform).m_CachedPtr);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = (object)transform2 == null;
			bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
			bool flag4 = (object)GM.Core == null;
			if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.NFT))
			{
				Pickup pickup = PickupManager.CreatePickup((Vector2)pos, ItemType.NFT);
			}
		}
	}

	public unsafe override void Revive(float percentage = 1f, bool instantRevival = false)
	{
		//IL_003b: Expected O, but got Ref
		base.Revive(percentage, instantRevival);
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			CharacterController characterController = null;
			List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}
}
