using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSpin : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	private float totalSpin;

	private Vector2 lastPosition;

	private bool mouseSpinning;

	public Transform playerRenderer;

	private float maxSpin = 600f;

	private float controllerSpin = 4f;

	private void OnEnable()
	{
		mouseSpinning = false;
	}

	private unsafe void Update()
	{
		//IL_0032: Expected O, but got F4
		//IL_026c: Expected O, but got F4
		//IL_007b: Expected O, but got F4
		//IL_0083: Invalid comparison between O and F4
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_0103: Expected O, but got F4
		//IL_010b: Invalid comparison between O and F4
		//IL_016d: Invalid comparison between F4 and I4
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected F4, but got Unknown
		//IL_01e7: Expected O, but got Ref
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_0207: Invalid comparison between F4 and O
		if (mouseSpinning)
		{
			float num = Input.mousePosition.x - (float)lastPosition;
			object obj = num ^ -0f;
			float num2 = (totalSpin = (float)obj + totalSpin);
			if (!(num2 > maxSpin))
			{
				object obj2 = maxSpin ^ -0f;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
				{
					float num3 = maxSpin ^ -0f;
					totalSpin = num3;
				}
			}
			else
			{
				totalSpin = maxSpin;
			}
			Vector3 mousePosition = Input.mousePosition;
			_ = mousePosition.y;
			lastPosition = (Vector2)mousePosition.x;
		}
		float num4;
		if (MyInputManager.GetButton(MyInputManager.UIShoulderLeft))
		{
			num4 = controllerSpin;
		}
		else
		{
			if (!MyInputManager.GetButton(MyInputManager.UIShoulderRight))
			{
				goto IL_02b4;
			}
			num4 = controllerSpin ^ -0f;
		}
		float num5 = (totalSpin = num4 + totalSpin);
		if (!(num5 > maxSpin))
		{
			object obj3 = maxSpin ^ -0f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5))
			{
				float num6 = maxSpin ^ -0f;
				totalSpin = num6;
			}
		}
		else
		{
			totalSpin = maxSpin;
		}
		goto IL_02b4;
		IL_035f:
		float deltaTime = Time.deltaTime;
		float num8;
		float num9;
		float num7 = num8 * num9;
		float num10 = deltaTime * num7;
		float num11 = totalSpin - num10;
		totalSpin = num11;
		float num12 = default(float);
		playerRenderer.Rotate((Vector3)(&num12), Space.World);
		float num13 = totalSpin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj4 = num13 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			totalSpin = 0f;
		}
		return;
		IL_02b4:
		float num14 = totalSpin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj5 = num14 & 0;
		if (0 >= (nint)obj5)
		{
			return;
		}
		float num15 = totalSpin * 4f;
		num9 = ((num15 < 0f) ? (-1f) : 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		num8 = num15 & 0;
		bool flag = 40f > num8;
		float num16 = 40f;
		if (!flag)
		{
			bool flag2 = !(num8 > 1500f);
			num16 = 1500f;
			if (flag2)
			{
				goto IL_035f;
			}
		}
		num8 = num16;
		goto IL_035f;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		mouseSpinning = true;
		lastPosition = eventData._003Cposition_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [eventData @ rdx (UnityEngine.EventSystems.PointerEventData)+108]");
		_ = 0;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		mouseSpinning = false;
	}

	private void AddSpin(float spin)
	{
		//IL_0053: Expected O, but got F4
		//IL_005d: Invalid comparison between O and F4
		float num = spin + totalSpin;
		float num2 = maxSpin;
		totalSpin = num;
		if (!(num > maxSpin))
		{
			object obj = maxSpin ^ -0f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)totalSpin))
			{
				return;
			}
			num2 = maxSpin ^ -0f;
		}
		totalSpin = num2;
	}
}
