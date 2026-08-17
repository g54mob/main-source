using System;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class GoldFilterUI : MonoBehaviour
{
	public CanvasGroup canvas;

	public RawImage goldenUi;

	public Transform lines1;

	public Transform lines2;

	private float timeLeft;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Pickup> b = OnPickup;
		Delegate obj = Delegate.Combine(Pickup.A_PickupTriggered, b);
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
		if (pickup.ePickup == EPickup.Stonks)
		{
			float rageTime = PowerupConstants.GetRageTime();
			timeLeft = rageTime;
		}
	}

	private unsafe void Update()
	{
		//IL_02be: Invalid comparison between I4 and F4
		//IL_02f0: Invalid comparison between F4 and I4
		//IL_0013: Expected F4, but got I4
		//IL_033c: Invalid comparison between I4 and F4
		//IL_0031: Invalid comparison between I4 and F4
		//IL_00f1: Expected F4, but got I4
		//IL_007c: Expected F4, but got I4
		//IL_00fe: Expected I, but got O
		//IL_03d6: Invalid comparison between I4 and F4
		//IL_013e: Expected I, but got O
		//IL_014b: Expected O, but got Ref
		//IL_0159: Expected I, but got O
		//IL_01cd: Expected O, but got Ref
		//IL_0208: Expected O, but got Ref
		//IL_024b: Invalid comparison between I4 and F4
		//IL_02ae: Expected O, but got Ref
		if (!(0f < timeLeft))
		{
			return;
		}
		float num = timeLeft - MyTime.deltaTime;
		if (!(num > 0f))
		{
			num = 0f;
		}
		timeLeft = num;
		float alpha;
		if (!(num > 1f))
		{
			float num2 = 1f - num;
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			float num3 = num2 * -1f;
			alpha = num3 + 1f;
		}
		else
		{
			float alpha2 = canvas.alpha;
			float num4 = MyTime.deltaTime * 5f;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			float num5 = 1f - alpha2;
			float num6 = num5 * num4;
			alpha = num6 + alpha2;
		}
		canvas.alpha = alpha;
		RawImage rawImage = goldenUi;
		nint num7 = (nint)rawImage;
		Color color = rawImage.color;
		float num8 = MyTime.time * 0.25f;
		float num9 = num8 / 0.2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float num10 = num9 * 0.2f;
		float num11 = num8 - num10;
		if (0f > num11 || num11 > 0.2f)
		{
		}
		RawImage rawImage2 = goldenUi;
		nint num12 = (nint)rawImage2;
		float num13 = default(float);
		rawImage2.color = (Color)(&num13);
		nint num14 = (nint)typeof(MyTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v16 (Il2CppClass<Assets.Scripts.Utility.MyTime>)+B8]");
		nint num15 = 0;
		float t = MyTime.time * 0.1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FFEE0");
		float num16 = Easing.InOutQuad(t);
		Transform transform = lines1.transform;
		float angle = MyTime.deltaTime * 20f;
		transform.Rotate((Vector3)(&num13), angle);
		Transform transform2 = lines2.transform;
		float angle2 = MyTime.deltaTime * -20f;
		Vector3 vector = default(Vector3);
		transform2.Rotate((Vector3)(&vector), angle2);
		float num17 = Mathf.PingPong(MyTime.time, 0.5f);
		Transform transform3 = lines1.transform;
		Vector3 localScale = transform3.localScale;
		if (0f > num16 || num16 > 1f)
		{
		}
		Transform transform4 = lines1.transform;
		transform4.localScale = (Vector3)(&num13);
	}
}
