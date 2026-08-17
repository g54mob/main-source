using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class TabGridNavigation : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Button, float> _003C_003E9__2_0;

		public static Func<float, float> _003C_003E9__2_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CComputeRowLengthByPosition_003Eb__2_0(Button b)
		{
			Transform transform = b.transform;
			float num = transform.localPosition.y * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
			return num / 100f;
		}

		internal float _003CComputeRowLengthByPosition_003Eb__2_1(float y)
		{
			return y;
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public float topRowY;

		internal bool _003CComputeRowLengthByPosition_003Eb__2(Button b)
		{
			//IL_00b5: Expected I4, but got O
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Expected O, but got Unknown
			//IL_0119: Invalid comparison between F4 and O
			//IL_0137: Invalid comparison between F4 and I4
			if ((object)b != null)
			{
				Transform transform = b.transform;
				if ((object)transform != null)
				{
					float num = transform.localPosition.y * 100f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
					float num2 = num / 100f;
					float num3 = topRowY - num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
					object obj = num2 & 0;
					float num4 = topRowY;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
					object obj2 = num4 & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						obj = obj2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
					object obj3 = num3 & 0;
					float num5 = (float)obj * 1E-06f;
					float num6 = Mathf.Epsilon * 8f;
					if (num5 < num6)
					{
						num5 = num6;
					}
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
					float num7 = num5 - (float)obj3;
					bool flag2 = num7 == 0f;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					return flag4 & flag3;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public GameObject buttonsParent;

	public unsafe void Set(Button tabButton)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0267: Expected O, but got I4
		//IL_0254: Expected O, but got Ref
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_0345: Expected O, but got I4
		//IL_0372: Expected O, but got I4
		//IL_040d: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		List<Button> list = new List<Button>();
		GameObject gameObject = buttonsParent;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			Transform transform = gameObject.transform;
			int childCount = transform.childCount;
			if (num >= childCount)
			{
				break;
			}
			Transform transform2 = buttonsParent.transform;
			Transform child = transform2.GetChild(num2);
			Button component = child.GetComponent<Button>();
			if (component != null)
			{
				GameObject gameObject2 = component.gameObject;
				if (gameObject2.activeSelf)
				{
					list.Add(component);
				}
			}
			gameObject = buttonsParent;
			num2++;
			num = num2;
		}
		GridLayoutGroup component2 = buttonsParent.GetComponent<GridLayoutGroup>();
		int num3;
		if (component2 != null && component2.m_Constraint == GridLayoutGroup.Constraint.FixedColumnCount)
		{
			num3 = component2.m_ConstraintCount;
			TabGridNavigation tabGridNavigation = (TabGridNavigation)(object)component2;
		}
		else
		{
			int num4 = ComputeRowLengthByPosition(list);
			num3 = num4;
		}
		int num5 = 0;
		int num6 = 0;
		while (num6 < list._size)
		{
			_ = 0;
			int num7 = num5 / num3;
			int num8 = num5 % num3;
			bool flag = num5 < num3;
			_ = 0;
			_ = 4;
			_ = 0;
			TabGridNavigation tabGridNavigation;
			if (!flag)
			{
				int index = num5 - num3;
				Button button = list.get_Item(index);
				tabGridNavigation = (TabGridNavigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
			}
			object obj3 = num5 + num3;
			int index2;
			if ((nint)obj3 >= list._size)
			{
				Button button2 = ((List<Button>)(object)this).get_Item(0);
				object obj4 = button2 - 2;
				if (num7 != (nint)obj4)
				{
					goto IL_02ee;
				}
				index2 = list._size - 1;
			}
			else
			{
				index2 = num5 + num3;
			}
			Button button3 = list.get_Item(index2);
			goto IL_02ee;
			IL_02ee:
			if (num8 > 0)
			{
				int index3 = num5 - 1;
				Button button4 = list.get_Item(index3);
			}
			object obj5 = num3 - 1;
			if (num8 < (nint)obj5)
			{
				object obj6 = num5 + 1;
				if ((nint)obj6 < list._size)
				{
					int index4 = num5 + 1;
					Button button5 = list.get_Item(index4);
				}
			}
			if (num7 == 0)
			{
			}
			Button button6 = list.get_Item(num5);
			Navigation navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
			_ = 0;
			button6.navigation = navigation;
			num5++;
			num6 = num5;
			tabGridNavigation = (TabGridNavigation)(object)button6;
		}
	}

	private int ComputeRowLengthByPosition(List<Button> buttons)
	{
		//IL_013d: Expected I4, but got O
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass2_0();
		if ((object)buttonsParent != null)
		{
			RectTransform component = buttonsParent.GetComponent<RectTransform>();
			LayoutRebuilder.ForceRebuildLayoutImmediate(component);
			Func<Button, float> selector = _003C_003Ec._003C_003E9__2_0;
			if (_003C_003Ec._003C_003E9__2_0 == null)
			{
				selector = (_003C_003Ec._003C_003E9__2_0 = (Func<object, float>)delegate(Button b)
				{
					Transform transform = b.transform;
					float num = transform.localPosition.y * 100f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
					return num / 100f;
				});
			}
			IEnumerable<float> source = Enumerable.Select(buttons, selector);
			IEnumerable<float> source2 = Enumerable.Distinct(source);
			Func<float, float> keySelector = _003C_003Ec._003C_003E9__2_1;
			if (_003C_003Ec._003C_003E9__2_1 == null)
			{
				keySelector = (_003C_003Ec._003C_003E9__2_1 = (float y) => y);
			}
			IOrderedEnumerable<float> source3 = Enumerable.OrderByDescending(source2, keySelector);
			List<float> list = Enumerable.ToList(source3);
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v18 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)0 == 0)
				{
					return 0;
				}
				float topRowY = list.get_Item(0);
				if (CS_0024_003C_003E8__locals4 != null)
				{
					CS_0024_003C_003E8__locals4.topRowY = topRowY;
					Func<Button, bool> predicate = delegate(Button b)
					{
						//IL_00b5: Expected I4, but got O
						//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
						//IL_00db: Expected O, but got Unknown
						//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
						//IL_00f2: Expected O, but got Unknown
						//IL_0175: Unknown result type (might be due to invalid IL or missing references)
						//IL_017a: Expected O, but got Unknown
						//IL_0119: Invalid comparison between F4 and O
						//IL_0137: Invalid comparison between F4 and I4
						if ((object)b != null)
						{
							Transform transform = b.transform;
							if ((object)transform != null)
							{
								float num = transform.localPosition.y * 100f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
								float num2 = num / 100f;
								float num3 = CS_0024_003C_003E8__locals4.topRowY - num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
								object obj = num2 & 0;
								float topRowY2 = CS_0024_003C_003E8__locals4.topRowY;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
								object obj2 = topRowY2 & 0;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
								{
									obj = obj2;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
								object obj3 = num3 & 0;
								float num4 = (float)obj * 1E-06f;
								float num5 = Mathf.Epsilon * 8f;
								if (num4 < num5)
								{
									num4 = num5;
								}
								bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
								float num6 = num4 - (float)obj3;
								bool flag2 = num6 == 0f;
								bool flag3 = !flag;
								bool flag4 = !flag2;
								return flag4 & flag3;
							}
						}
						NullReferenceException ex2 = new NullReferenceException();
						return (byte)(int)ex2 != 0;
					};
					return Enumerable.Count(buttons, (Func<object, bool>)predicate);
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}
}
