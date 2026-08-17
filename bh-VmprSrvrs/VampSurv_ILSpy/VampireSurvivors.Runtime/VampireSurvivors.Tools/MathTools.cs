using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace VampireSurvivors.Tools;

public static class MathTools
{
	private sealed class _003C_003Ec__DisplayClass9_0<T> where T : Component
	{
		public Vector2 source;

		internal float _003CListNearestToFarthest_003Eb__0(T x)
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			if ((object)x != null)
			{
				Transform transform = x.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Tools.MathTools+<>c__DisplayClass9_0`1<T>)+10]");
					object obj = 0 - ret;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Tools.MathTools+<>c__DisplayClass9_0`1<T>)+14]");
					object obj3 = default(object);
					object obj2 = 0 - obj3;
					object obj4 = obj * obj;
					object obj5 = obj2 * obj2;
					return (float)obj4 + (float)obj5;
				}
			}
			throw new NullReferenceException();
		}
	}

	public static Vector2 SetToPolar(Vector2 v2, float azimuth, float radius)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}

	public static float Remap(float value, float from1, float to1, float from2, float to2)
	{
		float num = value - from1;
		float num2 = to1 - from1;
		object obj = default(object);
		float num3 = (float)obj - from2;
		float num4 = num / num2;
		float num5 = num4 * num3;
		return num5 + from2;
	}

	public static bool ContainsRect(Rect rectA, Rect rectB)
	{
		//IL_0062: Invalid comparison between F4 and I4
		//IL_008b: Expected O, but got I4
		//IL_00bb: Invalid comparison between F4 and I4
		//IL_00e4: Expected O, but got I4
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02c9: Expected O, but got I4
		//IL_01c0: Invalid comparison between F4 and I4
		//IL_01e9: Expected O, but got I4
		//IL_020f: Invalid comparison between F4 and I4
		//IL_0238: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected I4, but got Unknown
		//IL_027a: Expected O, but got I4
		float num = rectA.m_Height + rectA.m_YMin;
		float num2 = rectA.m_Width + rectA.m_XMin;
		bool flag = num < rectB.m_YMin;
		float num3 = num - rectB.m_YMin;
		bool flag2 = num3 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj = flag4 & flag3;
		bool flag5 = num2 < rectB.m_XMin;
		float num4 = num2 - rectB.m_XMin;
		bool flag6 = num4 == 0f;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		object obj2 = flag8 & flag7;
		object obj3 = obj & obj2;
		bool flag9 = !(rectB.m_YMin < rectA.m_YMin);
		object obj4 = obj3;
		if (!flag9)
		{
			obj4 = 0;
		}
		bool flag10 = rectB.m_XMin < rectA.m_XMin;
		bool flag11 = !flag10;
		object obj5 = flag11 & obj4;
		bool flag12 = obj5 == null;
		object obj6 = !flag12;
		if (obj6 == null)
		{
			return false;
		}
		float num5 = rectB.m_Width + rectB.m_XMin;
		float num6 = rectB.m_Height + rectB.m_YMin;
		float num7 = rectA.m_Height + rectA.m_YMin;
		float num8 = rectA.m_Width + rectA.m_XMin;
		bool flag13 = num7 < num6;
		float num9 = num7 - num6;
		bool flag14 = num9 == 0f;
		bool flag15 = !flag13;
		bool flag16 = !flag14;
		object obj7 = flag16 & flag15;
		bool flag17 = num8 < num5;
		float num10 = num8 - num5;
		bool flag18 = num10 == 0f;
		bool flag19 = !flag17;
		bool flag20 = !flag18;
		object obj8 = flag20 & flag19;
		object obj9 = obj7 & obj8;
		bool flag21 = !(num6 < rectA.m_YMin);
		object obj10 = obj9;
		if (!flag21)
		{
			obj10 = 0;
		}
		bool flag22 = num5 < rectA.m_XMin;
		bool flag23 = !flag22;
		return (byte)((obj10 & flag23) ? 1 : 0) != 0;
	}

	public static Vector2 RandomOutside(Rect outer, Rect inner)
	{
		//IL_006e: Expected O, but got I4
		//IL_009e: Invalid comparison between F4 and I4
		//IL_00c7: Expected O, but got I4
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_00fc: Expected O, but got I4
		//IL_0190: Expected O, but got I4
		//IL_01b6: Invalid comparison between F4 and I4
		//IL_01df: Expected O, but got I4
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_021c: Expected O, but got I4
		//IL_03b6: Expected O, but got I4
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		Vector2 vector = default(Vector2);
		object obj = vector + vector;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
		object obj2 = obj - (object)vector;
		bool flag2 = obj2 == null;
		float num = (float)vector + outer.m_XMin;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj3 = flag4 & flag3;
		bool flag5 = num < inner.m_XMin;
		float num2 = num - inner.m_XMin;
		bool flag6 = num2 == 0f;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		object obj4 = flag8 & flag7;
		object obj5 = obj3 & obj4;
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector))
		{
			obj5 = 0;
		}
		bool flag9 = inner.m_XMin < outer.m_XMin;
		bool flag10 = !flag9;
		object obj6 = flag10 & obj5;
		if (obj6 != null)
		{
			float num3 = (float)vector + inner.m_XMin;
			object obj7 = vector + vector;
			object obj8 = vector + vector;
			float num4 = (float)vector + outer.m_XMin;
			bool flag11 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7);
			object obj9 = obj8 - obj7;
			bool flag12 = obj9 == null;
			bool flag13 = !flag11;
			bool flag14 = !flag12;
			object obj10 = flag14 & flag13;
			bool flag15 = num4 < num3;
			float num5 = num4 - num3;
			bool flag16 = num5 == 0f;
			bool flag17 = !flag15;
			bool flag18 = !flag16;
			object obj11 = flag18 & flag17;
			object obj12 = obj10 & obj11;
			bool flag19 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) >= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
			object obj13 = obj12;
			if (!flag19)
			{
				obj13 = 0;
			}
			bool flag20 = num3 < outer.m_XMin;
			bool flag21 = !flag20;
			object obj14 = flag21 & obj13;
			if (obj14 != null)
			{
				object obj15 = UnityEngine.Random.RandomRangeInt(0, 4);
				bool flag22 = obj15 == null;
				if (!flag22)
				{
					object obj16 = obj15 - 1;
					if (flag22)
					{
						float value = UnityEngine.Random.value;
						float value2 = UnityEngine.Random.value;
						return vector;
					}
					object obj17 = obj16 - 1;
					if (flag22)
					{
						float value3 = UnityEngine.Random.value;
						float value4 = UnityEngine.Random.value;
						return vector;
					}
					if ((nint)obj17 == 1)
					{
						float value5 = UnityEngine.Random.value;
						float value6 = UnityEngine.Random.value;
						return vector;
					}
				}
				else
				{
					float value7 = UnityEngine.Random.value;
					float value8 = UnityEngine.Random.value;
				}
				return vector;
			}
		}
		return vector;
	}

	public static List<Vector2> GetPointsOnCircle(int count, float radius = 1f)
	{
		//IL_0016: Expected O, but got I4
		//IL_004c: Expected O, but got I
		//IL_00cb: Expected O, but got I
		//IL_009a: Expected O, but got I
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		List<Vector2> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		if (count > 0)
		{
			float num = radius;
			object obj = 0;
			nint num2 = 0;
			List<Vector2> list2 = list;
			IntPtr intPtr = default(IntPtr);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,edi\"");
				int num3 = 0 / count;
				float num4 = (float)num3 * (float)Math.PI;
				float num5 = num4 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num6 = (float)num3 * (float)Math.PI;
				float num7 = num5 * radius;
				float num8 = num6 + num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				num = num8 * radius;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				list2 = (List<Vector2>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if (num9 >= 0)
				{
					list.AddWithResize((Vector2)(nint)intPtr);
					nint num10 = 0;
					num2 = intPtr;
					list2 = list;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					object obj2 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if (num11 >= 0)
					{
						return (List<Vector2>)(object)new IndexOutOfRangeException();
					}
					nint num10 = 0;
				}
				obj++;
			}
			while ((nint)obj < count);
		}
		return list;
	}

	public static List<Vector2> GetPoints(int count, float spawnAngle, float radius = 1f)
	{
		//IL_0013: Expected O, but got I4
		//IL_002b: Expected F4, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0062: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_00b0: Expected O, but got I
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		List<Vector2> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		if (count > 0)
		{
			List<Vector2> list2 = (List<Vector2>)(count - 1);
			float num2 = default(float);
			float num = num2 / (float)list2;
			float num3 = 0f;
			object obj = 0;
			nint num4 = 0;
			IntPtr intPtr = default(IntPtr);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num5 = num3 * radius;
				num2 = num3 * radius;
				num3 += num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				list2 = (List<Vector2>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if (num6 >= 0)
				{
					list.AddWithResize((Vector2)(nint)intPtr);
					nint num7 = 0;
					num4 = intPtr;
					list2 = list;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					object obj2 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if (num8 >= 0)
					{
						return (List<Vector2>)(object)new IndexOutOfRangeException();
					}
					nint num7 = 0;
				}
				obj++;
			}
			while ((nint)obj < count);
		}
		return list;
	}

	public static float DistanceSq(Vector2 v1, Vector2 v2)
	{
		object obj = v1 - v2;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		object obj5 = obj * obj;
		object obj6 = obj2 * obj2;
		return (float)obj5 + (float)obj6;
	}

	public static T FurthestObject<T>(Vector2 source, List<T> targets) where T : Component
	{
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		//IL_00ed->IL0156: Incompatible stack heights: 1 vs 0
		//IL_01b8->IL0156: Incompatible stack heights: 2 vs 0
		//IL_0284->IL0146: Incompatible stack heights: 3 vs 0
		//IL_0146->IL0289: Incompatible stack heights: 3 vs 0
		T val;
		if (targets != null)
		{
			bool flag = targets._size <= 0;
			val = null;
			if (flag)
			{
				goto IL_0146;
			}
			T val2 = null;
			T val3 = null;
			T val4 = null;
			float num = -1f / 0f;
			T val5 = null;
			object obj4 = default(object);
			object obj5 = default(object);
			while (true)
			{
				if ((nint)val5 < targets._size)
				{
					T[] items = targets._items;
					if (targets._items == null)
					{
						break;
					}
					bool flag2 = (nint)val4 >= items.Length;
					object obj = items[(object)val5];
					if ((object)items[(object)val5] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v11 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v11 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					object obj2 = (object)source - (object)ret;
					object obj3 = obj4 - obj5;
					object obj6 = obj2 * obj2;
					object obj7 = obj3 * obj3;
					float num2 = (float)obj6 + (float)obj7;
					bool flag5 = !(num2 > num);
					float num3 = num;
					if (!flag5)
					{
						num3 = num2;
					}
					bool flag6 = num2 > num;
					val = items[(object)val5];
					if (!flag6)
					{
						val = val2;
					}
					val3 = (T)(val3 + 1);
					if ((nint)val3 < targets._size)
					{
						val2 = val;
						val4 = val3;
						num = num3;
						val5 = val3;
						continue;
					}
					goto IL_0146;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				break;
			}
		}
		throw new NullReferenceException();
		IL_0146:
		return val;
	}

	public unsafe static T FurthestObject<T>(Vector2 source, HashSet<T> targets) where T : Component
	{
		//IL_0027: Expected F4, but got I4
		//IL_002f: Expected O, but got Ref
		//IL_015c->IL0161: Incompatible stack heights: 3 vs 0
		//IL_006e->IL0161: Incompatible stack heights: 3 vs 0
		float num = 0f;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		object obj = (object)(&enumerator);
		T result = null;
		float num2 = -1f / 0f;
		object obj4 = default(object);
		object obj5 = default(object);
		while (enumerator.MoveNext())
		{
			object obj2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rsi_v9 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rsi_v9 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			object obj3 = obj4 - obj5;
			object obj6 = (object)source - (object)ret;
			object obj7 = obj6 * obj6;
			obj = obj3 * obj3;
			num = (float)obj7 + (float)obj;
			if (num > num2)
			{
				result = null;
				num2 = num;
			}
		}
		return result;
	}

	public static List<T> ListNearestToFarthest<T>(Vector2 source, HashSet<T> targets) where T : Component
	{
		object CS_0024_003C_003E8__locals0 = null;
		Func<object, float> keySelector = delegate(T x)
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			if ((object)x != null)
			{
				Transform transform = x.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Tools.MathTools+<>c__DisplayClass9_0`1<T>)+10]");
					object obj = 0 - ret;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Tools.MathTools+<>c__DisplayClass9_0`1<T>)+14]");
					object obj3 = default(object);
					object obj2 = 0 - obj3;
					object obj4 = obj * obj;
					object obj5 = obj2 * obj2;
					return (float)obj4 + (float)obj5;
				}
			}
			throw new NullReferenceException();
		};
		IOrderedEnumerable<object> orderedEnumerable = Enumerable.OrderBy(targets, keySelector);
		if (orderedEnumerable != null)
		{
			return (List<T>)(object)new List<object>(orderedEnumerable);
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public static GameObject FurthestGameObject(Vector2 source, List<GameObject> targets)
	{
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		//IL_00d0->IL0156: Incompatible stack heights: 1 vs 0
		//IL_01b8->IL0156: Incompatible stack heights: 2 vs 0
		//IL_0284->IL0129: Incompatible stack heights: 3 vs 0
		//IL_0129->IL0289: Incompatible stack heights: 3 vs 0
		GameObject gameObject;
		if (targets != null)
		{
			bool flag = targets._size <= 0;
			gameObject = null;
			if (flag)
			{
				goto IL_0129;
			}
			float num = -1f / 0f;
			GameObject gameObject2 = null;
			GameObject gameObject3 = null;
			GameObject gameObject4 = null;
			GameObject gameObject5 = null;
			object obj4 = default(object);
			object obj5 = default(object);
			while (true)
			{
				if ((nint)gameObject5 < targets._size)
				{
					GameObject[] items = targets._items;
					if (targets._items == null)
					{
						break;
					}
					bool flag2 = (nint)gameObject2 >= items.Length;
					object obj = items[(object)gameObject5];
					if ((object)items[(object)gameObject5] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbx_v11 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbx_v11 (System.Object)+10]");
					IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					object obj2 = (object)source - (object)ret;
					object obj3 = obj4 - obj5;
					object obj6 = obj2 * obj2;
					object obj7 = obj3 * obj3;
					float num2 = (float)obj6 + (float)obj7;
					bool flag5 = !(num2 > num);
					float num3 = num;
					if (!flag5)
					{
						num3 = num2;
					}
					bool flag6 = num2 > num;
					gameObject = items[(object)gameObject5];
					if (!flag6)
					{
						gameObject = gameObject3;
					}
					gameObject4 = (GameObject)(gameObject4 + 1);
					if ((nint)gameObject4 < targets._size)
					{
						num = num3;
						gameObject2 = gameObject4;
						gameObject3 = gameObject;
						gameObject5 = gameObject4;
						continue;
					}
					goto IL_0129;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				break;
			}
		}
		throw new NullReferenceException();
		IL_0129:
		return gameObject;
	}

	public unsafe static GameObject FurthestGameObject(Vector2 source, Dictionary<int, GameObject> targets, out float max)
	{
		//IL_0022: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0163: Invalid comparison between O and F4
		//IL_0175->IL017a: Incompatible stack heights: 4 vs 0
		//IL_0072->IL017a: Incompatible stack heights: 4 vs 0
		ref float reference = ref *(float*)4286578688L;
		GameObject result = null;
		object obj = 0;
		object obj2 = 2;
		Dictionary<int, GameObject>.Enumerator enumerator = default(Dictionary<int, GameObject>.Enumerator);
		object obj3 = default(object);
		object obj5 = default(object);
		object obj6 = default(object);
		while (enumerator.MoveNext())
		{
			bool flag = obj3 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ stack_-60 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ stack_-60 (System.Object)+10]");
			IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag3 = (object)transform == null;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			object obj4 = obj5 - obj6;
			object obj7 = (object)source - (object)ret;
			object obj8 = obj7 * obj7;
			obj2 = obj4 * obj4;
			obj = obj8 + obj2;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)reference))
			{
				reference = ref *(float*)obj;
				result = (GameObject)obj3;
			}
		}
		return result;
	}

	public static GameObject FurthestGameObject(List<Vector2> sources, Dictionary<int, GameObject> targets)
	{
		List<Tuple<GameObject, float>> list = new List<Tuple<GameObject, float>>();
		if (sources != null)
		{
			List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
			Vector2 source = default(Vector2);
			while (enumerator.MoveNext())
			{
				GameObject gameObject = FurthestGameObject(source, targets, out var max);
				if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
				{
					Tuple<GameObject, float> item = new Tuple<GameObject, float>(gameObject, max);
					if (list == null)
					{
						throw new NullReferenceException();
					}
					((List<object>)(object)list).Add((object)item);
				}
			}
			if (list != null)
			{
				float num = -1f / 0f;
				GameObject result = null;
				List<Tuple<GameObject, float>>.Enumerator enumerator2 = default(List<Tuple<GameObject, float>>.Enumerator);
				if (enumerator2.MoveNext())
				{
					Tuple<GameObject, float> tuple = null;
					Tuple<GameObject, float> tuple2 = null;
					throw new NullReferenceException();
				}
				return result;
			}
		}
		throw new NullReferenceException();
	}
}
