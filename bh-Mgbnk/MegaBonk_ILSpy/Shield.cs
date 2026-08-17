using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Shield : MonoBehaviour
{
	private Vector3 defaultScale;

	private float destroyTimer;

	private Renderer renderer;

	private Material shieldMaterial;

	public AudioSource sfx;

	private float defaultVolume;

	private float scaleTime = 0.3f;

	private unsafe void Awake()
	{
		//IL_0093: Expected O, but got F4
		//IL_02aa: Expected O, but got I4
		//IL_00ba: Expected F4, but got O
		//IL_00c7: Expected O, but got Ref
		//IL_00e9: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_019b: Expected I, but got O
		//IL_01ac: Expected O, but got I4
		//IL_01e5: Expected O, but got I4
		//IL_01f3: Expected I, but got O
		//IL_0204: Expected O, but got I4
		//IL_0225: Expected O, but got I4
		//IL_0236: Expected O, but got I4
		Renderer component = GetComponent<Renderer>();
		renderer = component;
		bool flag = (object)renderer == null;
		Transform transform2 = default(Transform);
		Transform transform = transform2;
		object obj4;
		object obj;
		if (!flag)
		{
			Material sharedMaterial = renderer.GetSharedMaterial();
			shieldMaterial = sharedMaterial;
			float rageTime = PowerupConstants.GetRageTime();
			destroyTimer = rageTime;
			Transform transform3 = base.transform;
			bool flag2 = (object)transform3 == null;
			transform = transform2;
			if (!flag2)
			{
				Vector3 localScale = transform3.localScale;
				rageTime = localScale.x;
				defaultScale = (Vector3)localScale.x;
				_ = localScale.z;
				Transform transform4 = base.transform;
				bool flag3 = (object)transform4 == null;
				transform = transform4;
				obj = 0;
				if (!flag3)
				{
					rageTime = (float)Vector3.zeroVector;
					object obj2 = default(object);
					transform4.localScale = (Vector3)(&obj2);
					bool flag4 = (object)sfx == null;
					transform = transform4;
					obj = 0;
					if (!flag4)
					{
						rageTime = sfx.volume;
						defaultVolume = rageTime;
						Action<Pickup> b = OnPickup;
						Delegate obj3 = Delegate.Combine(Pickup.A_PickupTriggered, b);
						if ((object)obj3 == null)
						{
							Pickup.A_PickupTriggered = (Action<Pickup>)obj3;
							goto IL_0212;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
						Action<Pickup> action = default(Action<Pickup>);
						bool flag5 = action == null;
						obj4 = 0;
						nint num = (nint)typeof(Action<Pickup>);
						transform = (Transform)(object)obj3;
						obj = 0;
						if (!flag5)
						{
							Pickup.A_PickupTriggered = action;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							object obj5 = default(object);
							bool flag6 = obj5 == null;
							obj4 = 0;
							num = (nint)typeof(Action<Pickup>);
							transform = (Transform)(object)obj3;
							obj = 0;
							if (!flag6)
							{
								goto IL_0212;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						return;
					}
				}
			}
		}
		goto IL_0276;
		IL_0276:
		throw new NullReferenceException();
		IL_0212:
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 210 Invalid \"Jump target not found in method: 0x1804F4E10\"");
		obj4 = 0;
		transform = transform2;
		obj = 0;
		goto IL_0276;
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Pickup> value = OnPickup;
		Delegate obj = Delegate.Remove(Pickup.A_PickupTriggered, value);
		if ((object)obj == null)
		{
			Pickup.A_PickupTriggered = (Action<Pickup>)obj;
			return;
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
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Pickup>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnPickup(Pickup pickup)
	{
		if (pickup.ePickup == EPickup.Shield)
		{
			float rageTime = PowerupConstants.GetRageTime();
			destroyTimer = rageTime;
		}
	}

	private unsafe void Update()
	{
		//IL_02f8: Invalid comparison between I4 and F4
		//IL_0116: Expected F4, but got I4
		//IL_0020: Invalid comparison between I4 and F4
		//IL_0128: Expected O, but got Ref
		//IL_006b: Expected F4, but got I4
		//IL_0179: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_018a: Expected O, but got Ref
		//IL_007d: Expected O, but got Ref
		//IL_008f: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_00a0: Expected O, but got Ref
		//IL_0338: Invalid comparison between O and F4
		//IL_03b0: Invalid comparison between O and F4
		//IL_01eb: Expected F4, but got I4
		float num4 = default(float);
		float num6;
		object obj;
		if (!(scaleTime < destroyTimer))
		{
			float num = destroyTimer / scaleTime;
			float num2 = 1f - num;
			Transform transform = base.transform;
			float num3 = Easing.InOutCirc(num2);
			if (!(0f > num3))
			{
				if (num3 > 1f)
				{
					num3 = 1f;
				}
			}
			else
			{
				num3 = 0f;
			}
			transform.localScale = (Vector3)(&num4);
			AudioSource audioSource = sfx;
			float num5 = 1f - num2;
			float volume = num5 * defaultVolume;
			sfx.volume = volume;
			num6 = 1f;
			obj = 0;
			object obj2 = 0;
			Vector3 vector = (Vector3)(&num4);
		}
		else
		{
			float num7 = MyTime.deltaTime / scaleTime;
			Transform transform2 = base.transform;
			Transform transform3 = base.transform;
			Vector3 localScale = transform3.localScale;
			if (!(0f > num7))
			{
				if (num7 > 1f)
				{
					num7 = 1f;
				}
			}
			else
			{
				num7 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Shield)+24]");
			float num8 = 0f - localScale.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Shield)+28]");
			float num9 = 0f - localScale.z;
			float num10 = num8 * num7;
			float num11 = num9 * num7;
			float volume = num10 + localScale.y;
			float num12 = num11 + localScale.z;
			transform2.localScale = (Vector3)(&num4);
			num6 = 1f;
			obj = 0;
			object obj2 = 0;
			Vector3 vector = (Vector3)(&num4);
			AudioSource audioSource = (AudioSource)(object)transform2;
		}
		float num13 = (destroyTimer -= MyTime.deltaTime);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num13))
		{
			if (3f < num13)
			{
				return;
			}
			float num14 = MyTime.time * 3f;
			float num15 = num14 * (float)Math.PI;
			float num16 = num15 + num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
			float num17 = num16 + num6;
			float num18 = num17 * 0.5f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num18))
			{
				if (num18 > num6)
				{
					num18 = num6;
				}
			}
			else
			{
				num18 = 0f;
			}
			float num19 = num18 * 0.9f;
			float alpha = num19 + 0.1f;
			UpdateAlpha(alpha);
		}
		else
		{
			GameObject obj3 = base.gameObject;
			UnityEngine.Object.Destroy(obj3);
		}
	}

	private unsafe void UpdateAlpha(float alpha)
	{
		//IL_0060: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172CE4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Color color = shieldMaterial.GetColor("_MainColor");
		object obj = default(object);
		shieldMaterial.SetColor("_MainColor", (Color)(&obj));
	}
}
