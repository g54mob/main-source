using System;
using Cpp2ILInjected;
using Doozy.Engine.Touchy;
using UnityEngine;

namespace Doozy.Engine.UI;

[Serializable]
public class UIDrawerArrow
{
	[Serializable]
	public class Holder
	{
		public RectTransform Closed;

		public RectTransform Opened;

		public RectTransform Root;

		public unsafe Vector3 ClosedLocalPosition
		{
			get
			{
				//IL_0051: Expected native int or pointer, but got O
				//IL_005f: Expected native int or pointer, but got O
				RectTransform closed = Closed;
				bool flag = ((UnityEngine.Object)closed).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_localPosition_Injected(((UnityEngine.Object)closed).m_CachedPtr, out *(Vector3*)(&ret));
				Vector3 vector = default(Vector3);
				((Vector3*)(nint)vector)->x = ret;
				((Vector3*)(nint)vector)->z = 0f;
				return vector;
			}
		}

		public unsafe Vector3 OpenedLocalPosition
		{
			get
			{
				//IL_0051: Expected native int or pointer, but got O
				//IL_005f: Expected native int or pointer, but got O
				RectTransform opened = Opened;
				bool flag = ((UnityEngine.Object)opened).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_localPosition_Injected(((UnityEngine.Object)opened).m_CachedPtr, out *(Vector3*)(&ret));
				Vector3 vector = default(Vector3);
				((Vector3*)(nint)vector)->x = ret;
				((Vector3*)(nint)vector)->z = 0f;
				return vector;
			}
		}

		public Holder(RectTransform parent)
		{
			Reset(parent);
		}

		public void Reset(RectTransform parent)
		{
			RectTransform root = Root;
			if ((object)Root != null && ((UnityEngine.Object)root).m_CachedPtr != (IntPtr)0)
			{
				if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
				{
					Root.SetParent(parent, worldPositionStays: true);
				}
				RectTransform opened = Opened;
				if ((object)Opened != null && ((UnityEngine.Object)opened).m_CachedPtr != (IntPtr)0)
				{
					Opened.SetParent(Root, worldPositionStays: true);
				}
				RectTransform closed = Closed;
				if ((object)Closed != null && ((UnityEngine.Object)closed).m_CachedPtr != (IntPtr)0)
				{
					Closed.SetParent(Root, worldPositionStays: true);
				}
			}
		}
	}

	private const bool DEFAULT_ENABLED = true;

	private const bool DEFAULT_OVERRIDE_COLOR = false;

	private const float DEFAULT_SCALE = 1f;

	private static readonly Color DefaultOpenedColor;

	private static readonly Color DefaultClosedColor;

	public UIDrawerArrowAnimator Animator;

	public Color ClosedColor;

	public RectTransform Container;

	public Holder Down;

	public bool Enabled;

	public Holder Left;

	public Color OpenedColor;

	public bool OverrideColor;

	public Holder Right;

	public float Scale;

	public Holder Up;

	public UIDrawerArrow()
	{
		Reset();
	}

	public Holder GetHolder(SimpleSwipe closeDirection)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		object obj = closeDirection - 1;
		object obj2 = default(object);
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				object obj4 = obj3 - 1;
				if (obj2 == null)
				{
					if ((nint)obj4 != 1)
					{
						return null;
					}
					return Down;
				}
				return Up;
			}
			return Right;
		}
		return Left;
	}

	private void Reset()
	{
		Enabled = true;
		Scale = 1f;
		OverrideColor = false;
		OpenedColor = DefaultOpenedColor;
		ClosedColor = DefaultClosedColor;
		Holder holder = null;
		holder.Reset(Container);
		Left = holder;
		Holder holder2 = null;
		holder2.Reset(Container);
		Right = holder2;
		Holder holder3 = null;
		holder3.Reset(Container);
		Up = holder3;
		Holder holder4 = null;
		holder4.Reset(Container);
		Down = holder4;
	}

	public void ResetArrowClosedPosition(SimpleSwipe closeDirection)
	{
		//IL_00c4: Expected O, but got I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		object obj = closeDirection - 1;
		bool flag = closeDirection == SimpleSwipe.Left;
		Holder holder;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						return;
					}
					holder = Down;
				}
				else
				{
					holder = Up;
				}
			}
			else
			{
				holder = Right;
			}
		}
		else
		{
			holder = Left;
		}
		ResetArrowClosedPosition(holder.Closed, closeDirection);
	}

	public static void ResetArrowClosedPosition(RectTransform closed, SimpleSwipe closeDirection)
	{
		//IL_00d7: Expected O, but got I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		Vector2 vector = default(Vector2);
		closed.anchorMin = vector;
		closed.anchorMax = vector;
		closed.pivot = vector;
		closed.sizeDelta = vector;
		bool flag = ((UnityEngine.Object)closed).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)closed).m_CachedPtr, ref value);
		object obj = closeDirection - 1;
		bool flag2 = closeDirection == SimpleSwipe.Left;
		if (!flag2)
		{
			object obj2 = obj - 1;
			if (!flag2)
			{
				object obj3 = obj2 - 1;
				if (!flag2 && (nint)obj3 != 1)
				{
					return;
				}
			}
		}
		closed.anchoredPosition = vector;
	}

	public void ResetArrowOpenedPosition(SimpleSwipe closeDirection)
	{
		//IL_00c4: Expected O, but got I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		object obj = closeDirection - 1;
		bool flag = closeDirection == SimpleSwipe.Left;
		Holder holder;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						return;
					}
					holder = Down;
				}
				else
				{
					holder = Up;
				}
			}
			else
			{
				holder = Right;
			}
		}
		else
		{
			holder = Left;
		}
		ResetArrowOpenedPosition(holder.Opened, closeDirection);
	}

	public static void ResetArrowOpenedPosition(RectTransform opened, SimpleSwipe closeDirection)
	{
		//IL_00d7: Expected O, but got I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		Vector2 vector = default(Vector2);
		opened.anchorMin = vector;
		opened.anchorMax = vector;
		opened.pivot = vector;
		opened.sizeDelta = vector;
		bool flag = ((UnityEngine.Object)opened).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)opened).m_CachedPtr, ref value);
		object obj = closeDirection - 1;
		bool flag2 = closeDirection == SimpleSwipe.Left;
		if (!flag2)
		{
			object obj2 = obj - 1;
			if (!flag2)
			{
				object obj3 = obj2 - 1;
				if (!flag2 && (nint)obj3 != 1)
				{
					return;
				}
			}
		}
		opened.anchoredPosition = vector;
	}

	public void ResetArrowRootPosition(SimpleSwipe closeDirection)
	{
		//IL_00c4: Expected O, but got I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		object obj = closeDirection - 1;
		bool flag = closeDirection == SimpleSwipe.Left;
		Holder holder;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						return;
					}
					holder = Down;
				}
				else
				{
					holder = Up;
				}
			}
			else
			{
				holder = Right;
			}
		}
		else
		{
			holder = Left;
		}
		ResetArrowRootPosition(holder.Root, closeDirection);
	}

	public static void ResetArrowRootPosition(RectTransform root, SimpleSwipe closeDirection)
	{
		//IL_012c: Expected O, but got I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		bool flag = ((UnityEngine.Object)root).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)root).m_CachedPtr, ref value);
		Transform transform = root.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		object obj = closeDirection - 1;
		bool flag3 = closeDirection == SimpleSwipe.Left;
		Vector2 vector = default(Vector2);
		Vector2 anchorMax;
		if (!flag3)
		{
			object obj2 = obj - 1;
			if (!flag3)
			{
				object obj3 = obj2 - 1;
				if (!flag3 && (nint)obj3 != 1)
				{
					goto IL_009a;
				}
				root.anchorMin = vector;
				anchorMax = vector;
				goto IL_0149;
			}
			root.anchorMin = vector;
		}
		else
		{
			root.anchorMin = vector;
		}
		anchorMax = vector;
		goto IL_0149;
		IL_009a:
		root.pivot = vector;
		root.sizeDelta = vector;
		root.anchoredPosition = vector;
		return;
		IL_0149:
		root.anchorMax = anchorMax;
		goto IL_009a;
	}

	static UIDrawerArrow()
	{
		//IL_0016: Expected O, but got I
		//IL_0027: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		DefaultOpenedColor = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		DefaultClosedColor = (Color)0;
	}
}
