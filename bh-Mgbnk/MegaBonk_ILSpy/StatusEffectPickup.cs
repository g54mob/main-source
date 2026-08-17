using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class StatusEffectPickup : MonoBehaviour
{
	public EPickup ePickup;

	public EStatusEffect statusEffect;

	public GameObject sparksEffect;

	public GameObject pickupImpactEffect;

	public bool rotateToPlayerVelocity;

	public bool useFeetPosition = true;

	private float timeLeft;

	public unsafe void Set()
	{
		//IL_08d6: Invalid comparison between I and F4
		//IL_07a5: Expected I4, but got O
		//IL_07c6: Expected I, but got O
		//IL_07f9: Expected I4, but got O
		//IL_081a: Expected I, but got O
		//IL_03f2: Expected O, but got Ref
		//IL_0737: Expected O, but got Ref
		//IL_05f4: Expected O, but got Ref
		//IL_05fd: Expected F4, but got O
		UnityEngine.Object instance = GameManager.Instance;
		if (!(GameManager.Instance != null))
		{
			goto IL_0850;
		}
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			if (playerInventory != null && playerInventory.statusEffects != null)
			{
				if (!playerInventory.statusEffects.HasStatusEffect(this.statusEffect))
				{
					goto IL_019c;
				}
				if ((object)GameManager.Instance != null)
				{
					PlayerInventory playerInventory2 = GameManager.Instance.GetPlayerInventory();
					if (playerInventory2 != null)
					{
						PlayerStatusEffects statusEffects = playerInventory2.statusEffects;
						if (playerInventory2.statusEffects != null && statusEffects.statusEffects != null)
						{
							object obj = ((Dictionary<System.Int32Enum, object>)(object)statusEffects.statusEffects).get_Item((System.Int32Enum)this.statusEffect);
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v84 (System.Object)+24]");
								if (0f < MyTime.time)
								{
									goto IL_019c;
								}
								goto IL_022f;
							}
						}
					}
				}
			}
		}
		goto IL_08b4;
		IL_0831:
		float time = PowerupConstants.GetTime(this.statusEffect);
		timeLeft = time;
		return;
		IL_03c0:
		Transform transform;
		bool flag = (object)transform == null;
		instance = transform;
		float num = default(float);
		Vector3 vector;
		if (!flag)
		{
			transform.position = (Vector3)(&num);
			Transform transform2 = base.transform;
			bool flag2 = (object)GameManager.Instance == null;
			instance = transform2;
			if (!flag2)
			{
				MyPlayer player = GameManager.Instance.GetPlayer();
				bool flag3 = (object)player == null;
				instance = transform2;
				if (!flag3)
				{
					Transform parentInternal = player.transform;
					bool flag4 = (object)transform2 == null;
					instance = transform2;
					if (!flag4)
					{
						transform2.parentInternal = parentInternal;
						instance = sparksEffect;
						bool flag5 = sparksEffect != null;
						bool flag6 = !flag5;
						num = vector.x;
						if (flag6)
						{
							goto IL_0602;
						}
						if ((object)sparksEffect != null)
						{
							Transform transform3 = sparksEffect.transform;
							bool flag7 = (object)GameManager.Instance == null;
							instance = transform3;
							if (!flag7)
							{
								MyPlayer player2 = GameManager.Instance.GetPlayer();
								bool flag8 = (object)player2 == null;
								instance = transform3;
								if (!flag8)
								{
									Transform parentInternal2 = player2.transform;
									bool flag9 = (object)transform3 == null;
									instance = transform3;
									if (!flag9)
									{
										transform3.parentInternal = parentInternal2;
										bool flag10 = (object)sparksEffect == null;
										instance = transform3;
										if (!flag10)
										{
											Transform transform4 = sparksEffect.transform;
											bool flag11 = (object)transform4 == null;
											instance = transform4;
											if (!flag11)
											{
												transform4.localPosition = (Vector3)(&num);
												num = (float)Vector3.zeroVector;
												goto IL_0602;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_08b4;
		IL_019c:
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory3 = GameManager.Instance.GetPlayerInventory();
			if (playerInventory3 != null && playerInventory3.statusEffects != null)
			{
				if (!playerInventory3.statusEffects.HasStatusEffect(this.statusEffect))
				{
					goto IL_022f;
				}
				goto IL_0850;
			}
		}
		goto IL_08b4;
		IL_0850:
		if ((object)pickupImpactEffect != null)
		{
			Transform transform5 = pickupImpactEffect.transform;
			if ((object)transform5 != null)
			{
				transform5.parentInternal = null;
				GameObject obj2 = base.gameObject;
				UnityEngine.Object.Destroy(obj2);
				return;
			}
		}
		goto IL_08b4;
		IL_08b4:
		throw new NullReferenceException();
		IL_073c:
		Action<Pickup> b = OnPickupTriggered;
		Delegate obj3 = Delegate.Combine(Pickup.A_PickupTriggered, b);
		if ((object)obj3 == null)
		{
			Pickup.A_PickupTriggered = (Action<Pickup>)obj3;
			goto IL_0831;
		}
		StatusEffect statusEffect = ((Dictionary<EStatusEffect, StatusEffect>)(object)obj3).get_Item((EStatusEffect)typeof(Action<Pickup>));
		bool flag12 = statusEffect == null;
		nint num2 = (nint)typeof(Action<Pickup>);
		instance = (UnityEngine.Object)(object)obj3;
		if (!flag12)
		{
			Pickup.A_PickupTriggered = (Action<Pickup>)(object)statusEffect;
			StatusEffect statusEffect2 = ((Dictionary<EStatusEffect, StatusEffect>)(object)obj3).get_Item((EStatusEffect)typeof(Action<Pickup>));
			bool flag13 = statusEffect2 == null;
			num2 = (nint)typeof(Action<Pickup>);
			instance = (UnityEngine.Object)(object)obj3;
			if (!flag13)
			{
				goto IL_0831;
			}
			StatusEffect statusEffect3 = ((Dictionary<EStatusEffect, StatusEffect>)(object)instance).get_Item((EStatusEffect)num2);
		}
		StatusEffect statusEffect4 = ((Dictionary<EStatusEffect, StatusEffect>)(object)instance).get_Item((EStatusEffect)num2);
		return;
		IL_022f:
		if ((object)GameManager.Instance != null)
		{
			MyPlayer player3 = GameManager.Instance.GetPlayer();
			if (!(player3 != null))
			{
				goto IL_073c;
			}
			transform = base.transform;
			if (useFeetPosition)
			{
				bool flag14 = (object)GameManager.Instance == null;
				instance = transform;
				if (!flag14)
				{
					PlayerMovement playerMovement = GameManager.Instance.GetPlayerMovement();
					bool flag15 = (object)playerMovement == null;
					instance = transform;
					if (!flag15)
					{
						vector = playerMovement.GetRbFeetPosition();
						goto IL_03c0;
					}
				}
			}
			else
			{
				bool flag16 = (object)GameManager.Instance == null;
				instance = transform;
				if (!flag16)
				{
					PlayerMovement playerMovement2 = GameManager.Instance.GetPlayerMovement();
					bool flag17 = (object)playerMovement2 == null;
					instance = transform;
					if (!flag17)
					{
						Transform transform6 = playerMovement2.transform;
						bool flag18 = (object)transform6 == null;
						instance = transform;
						if (!flag18)
						{
							vector = transform6.position;
							goto IL_03c0;
						}
					}
				}
			}
		}
		goto IL_08b4;
		IL_0602:
		instance = pickupImpactEffect;
		if (!(pickupImpactEffect != null))
		{
			goto IL_073c;
		}
		if ((object)pickupImpactEffect != null)
		{
			Transform transform7 = pickupImpactEffect.transform;
			bool flag19 = (object)GameManager.Instance == null;
			instance = transform7;
			if (!flag19)
			{
				MyPlayer player4 = GameManager.Instance.GetPlayer();
				bool flag20 = (object)player4 == null;
				instance = transform7;
				if (!flag20)
				{
					Transform transform8 = player4.transform;
					bool flag21 = (object)transform8 == null;
					instance = transform7;
					if (!flag21)
					{
						Vector3 position = transform8.position;
						bool flag22 = (object)transform7 == null;
						instance = transform7;
						if (!flag22)
						{
							transform7.position = (Vector3)(&num);
							goto IL_073c;
						}
					}
				}
			}
		}
		goto IL_08b4;
	}

	private void OnPickupTriggered(Pickup pickup)
	{
		if (pickup.ePickup == ePickup)
		{
			float time = PowerupConstants.GetTime(statusEffect);
			timeLeft = time;
		}
	}

	private unsafe void Update()
	{
		//IL_0216: Invalid comparison between I4 and F4
		//IL_007b: Expected O, but got Ref
		//IL_00da: Expected I, but got O
		//IL_0199: Invalid comparison between F4 and I4
		//IL_01c2: Expected O, but got I4
		//IL_009c: Expected O, but got Ref
		//IL_00b2: Expected O, but got Ref
		if (0f < (timeLeft -= MyTime.deltaTime))
		{
			MyPlayer player = GameManager.Instance.GetPlayer();
			bool flag = player == null;
			if (!flag && rotateToPlayerVelocity != flag)
			{
				PlayerMovement playerMovement = GameManager.Instance.GetPlayerMovement();
				Vector3 velocity = playerMovement.GetVelocity();
				float num = default(float);
				Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
				nint num2 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v24 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num3 = 0;
				float num4 = vector.x - (float)Vector3.zeroVector;
				object obj2 = default(object);
				object obj3 = default(object);
				object obj = obj2 - obj3;
				float num5 = vector.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				float num6 = num5 - 0f;
				object obj4 = obj * obj;
				float num7 = num4 * num4;
				float num8 = num6 * num6;
				float num9 = (float)obj4 + num7;
				float num10 = num9 + num8;
				bool flag2 = 9.9999994E-11f < num10;
				float num11 = 9.9999994E-11f - num10;
				bool flag3 = num11 == 0f;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				object obj5 = flag5 & flag4;
				if (obj5 == null)
				{
					Transform transform = base.transform;
					Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num));
					Vector3 vector2 = default(Vector3);
					transform.rotation = (Quaternion)(&vector2);
				}
			}
		}
		else
		{
			GameObject obj6 = base.gameObject;
			UnityEngine.Object.Destroy(obj6);
		}
	}

	private bool HasStatusEffect()
	{
		//IL_0234: Expected I4, but got O
		//IL_024a: Invalid comparison between I and F4
		if (GameManager.Instance != null)
		{
			if ((object)GameManager.Instance != null)
			{
				PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
				if (playerInventory != null && playerInventory.statusEffects != null)
				{
					if (!playerInventory.statusEffects.HasStatusEffect(statusEffect))
					{
						goto IL_0198;
					}
					if ((object)GameManager.Instance != null)
					{
						PlayerInventory playerInventory2 = GameManager.Instance.GetPlayerInventory();
						if (playerInventory2 != null)
						{
							PlayerStatusEffects statusEffects = playerInventory2.statusEffects;
							if (playerInventory2.statusEffects != null && statusEffects.statusEffects != null)
							{
								object obj = ((Dictionary<System.Int32Enum, object>)(object)statusEffects.statusEffects).get_Item((System.Int32Enum)statusEffect);
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v18 (System.Object)+24]");
									if (!(0f < MyTime.time))
									{
										return false;
									}
									goto IL_0198;
								}
							}
						}
					}
				}
			}
			goto IL_0226;
		}
		return true;
		IL_0226:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0198:
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory3 = GameManager.Instance.GetPlayerInventory();
			if (playerInventory3 != null && playerInventory3.statusEffects != null)
			{
				return playerInventory3.statusEffects.HasStatusEffect(statusEffect);
			}
		}
		goto IL_0226;
	}

	private void DestroySelf()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
	}

	private void OnDestroy()
	{
		//IL_00f5: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Pickup> value = OnPickupTriggered;
		Delegate obj = Delegate.Remove(Pickup.A_PickupTriggered, value);
		if ((object)obj == null)
		{
			Pickup.A_PickupTriggered = (Action<Pickup>)obj;
			goto IL_009d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Pickup> action = default(Action<Pickup>);
		if (action != null)
		{
			Pickup.A_PickupTriggered = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Pickup>);
			if (!flag)
			{
				goto IL_009d;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Pickup>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_009d:
		if (sparksEffect != null)
		{
			UnityEngine.Object.Destroy(sparksEffect);
		}
	}
}
