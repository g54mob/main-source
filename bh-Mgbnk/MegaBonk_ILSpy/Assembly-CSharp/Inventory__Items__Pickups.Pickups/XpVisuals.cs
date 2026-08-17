using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Inventory__Items__Pickups.Pickups;

public class XpVisuals : MonoBehaviour
{
	private enum XpTier
	{
		Low = 0,
		Medium = 10,
		High = 50
	}

	public ParticleSystem ps;

	private ParticleSystem.MainModule psMain;

	public Pickup pickup;

	public Color c_low;

	public Color c_mid;

	public Color c_high;

	public Color c_echo;

	private XpTier currentXpTier;

	private void Awake()
	{
		//IL_0092: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00a9: Expected I, but got O
		//IL_006b: Expected I, but got O
		//IL_00f3: Expected I, but got O
		//IL_0104: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_011b: Expected I, but got O
		//IL_014b: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		Pickup pickup = this.pickup;
		Delegate obj;
		nint num;
		Delegate obj6;
		object obj2;
		object obj3;
		nint num2;
		if ((object)this.pickup != null)
		{
			Action<int> b = OnValueUpdated;
			obj = Delegate.Combine(pickup.A_ValueUpdated, b);
			if ((object)obj == null)
			{
				pickup.A_ValueUpdated = (Action<int>)obj;
				num = (nint)pickup.A_ValueUpdated;
				goto IL_0129;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action = default(Action<int>);
			bool flag = action == null;
			obj2 = 0;
			obj3 = 0;
			num2 = (nint)typeof(Action<int>);
			Delegate obj4 = obj;
			if (!flag)
			{
				pickup.A_ValueUpdated = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				num = (nint)typeof(Action<int>);
				obj6 = obj;
				obj2 = 0;
				obj3 = 0;
				num2 = (nint)typeof(Action<int>);
				if (!flag2)
				{
					goto IL_0129;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj4 = obj6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			return;
		}
		goto IL_0184;
		IL_0129:
		bool flag3 = (object)ps == null;
		obj6 = obj;
		obj2 = 0;
		obj3 = 0;
		num2 = num;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
			psMain = mainModule;
			return;
		}
		goto IL_0184;
		IL_0184:
		throw new NullReferenceException();
	}

	private void OnDestroy()
	{
		//IL_0085: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009c: Expected I, but got O
		Pickup pickup = this.pickup;
		Action<int> value = OnValueUpdated;
		Delegate obj = Delegate.Remove(pickup.A_ValueUpdated, value);
		if ((object)obj == null)
		{
			pickup.A_ValueUpdated = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		bool flag = action == null;
		object obj2 = 0;
		object obj3 = 0;
		nint num = (nint)typeof(Action<int>);
		Delegate obj4 = obj;
		if (!flag)
		{
			pickup.A_ValueUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			if (obj5 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			object obj6 = default(object);
			obj2 = obj6;
			object obj7 = default(object);
			obj3 = obj7;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			Delegate obj8 = default(Delegate);
			obj4 = obj8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Update()
	{
	}

	public unsafe void SetEchoXp()
	{
		//IL_0009: Expected O, but got Ref
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0025: Expected O, but got Ref
		object obj = default(object);
		ParticleSystem.MinMaxGradient minMaxGradient = (Color)(&obj);
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)(this + 40);
		object obj2 = default(object);
		((ParticleSystem.MainModule*)mainModule)->startColor = (ParticleSystem.MinMaxGradient)(&obj2);
	}

	private unsafe void OnValueUpdated(int newValue)
	{
		//IL_0008: Expected O, but got Ref
		//IL_01e0: Expected O, but got Ref
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0218: Expected O, but got Ref
		//IL_0092: Expected O, but got Ref
		//IL_02d3: Expected I, but got O
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0183: Expected O, but got Ref
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00e7: Expected O, but got Ref
		//IL_02f6: Expected O, but got Ref
		//IL_0334: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		XpTier xpTier;
		if (newValue >= 10)
		{
			bool flag = newValue < 50;
			xpTier = XpTier.Medium;
			if (!flag)
			{
				xpTier = XpTier.High;
			}
		}
		else
		{
			xpTier = XpTier.Low;
		}
		if (currentXpTier == xpTier)
		{
			return;
		}
		Transform transform2;
		if (newValue >= 10)
		{
			Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			float num;
			if (newValue >= 50)
			{
				currentXpTier = XpTier.High;
				_ = c_high;
				ParticleSystem.MinMaxGradient minMaxGradient = color;
				ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)(this + 40);
				ParticleSystem.MinMaxGradient startColor = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				_ = minMaxGradient.m_Mode;
				_ = minMaxGradient.m_GradientMax;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v18 (UnityEngine.ParticleSystem+MinMaxGradient)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v18 (UnityEngine.ParticleSystem+MinMaxGradient)+30]");
				_ = 0;
				((ParticleSystem.MainModule*)mainModule)->startColor = startColor;
				Transform transform = base.transform;
				num = 1.5f;
				transform2 = transform;
			}
			else
			{
				currentXpTier = XpTier.Medium;
				_ = c_mid;
				ParticleSystem.MinMaxGradient minMaxGradient2 = color;
				ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)(this + 40);
				ParticleSystem.MinMaxGradient startColor2 = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				_ = minMaxGradient2.m_Mode;
				_ = minMaxGradient2.m_GradientMax;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v13 (UnityEngine.ParticleSystem+MinMaxGradient)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v13 (UnityEngine.ParticleSystem+MinMaxGradient)+30]");
				_ = 0;
				((ParticleSystem.MainModule*)mainModule2)->startColor = startColor2;
				Transform transform3 = base.transform;
				num = 1.25f;
				transform2 = transform3;
			}
			nint num2 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rcx_v13 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num3 = 0;
			float num4 = (float)Vector3.oneVector * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
			float num5 = 0f * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num6 = 0f * num;
		}
		else
		{
			Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			currentXpTier = XpTier.Low;
			_ = c_low;
			ParticleSystem.MinMaxGradient minMaxGradient3 = color2;
			ParticleSystem.MainModule mainModule3 = (ParticleSystem.MainModule)(this + 40);
			ParticleSystem.MinMaxGradient startColor3 = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = minMaxGradient3.m_Mode;
			_ = minMaxGradient3.m_GradientMax;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v7 (UnityEngine.ParticleSystem+MinMaxGradient)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v7 (UnityEngine.ParticleSystem+MinMaxGradient)+30]");
			_ = 0;
			((ParticleSystem.MainModule*)mainModule3)->startColor = startColor3;
			Transform transform4 = base.transform;
			nint num7 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v10 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num8 = 0;
			_ = Vector3.oneVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdx_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdx_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			_ = 0;
			transform2 = transform4;
		}
		Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		transform2.localScale = localScale;
	}

	private XpTier GetXpTier(int value)
	{
		if (value >= 10)
		{
			bool flag = value < 50;
			XpTier result = XpTier.Medium;
			if (!flag)
			{
				result = XpTier.High;
			}
			return result;
		}
		return XpTier.Low;
	}
}
