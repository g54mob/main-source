using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.UI;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;

namespace Doozy.Engine.Layouts;

public class RadialLayout : LayoutGroup
{
	public const bool AUTO_REBUILD_DEFAULT_VALUE = true;

	public const bool CLOCKWISE_DEFAULT_VALUE = false;

	public const bool CONTROL_CHILD_HEIGHT_DEFAULT_VALUE = false;

	public const bool CONTROL_CHILD_WIDTH_DEFAULT_VALUE = false;

	public const bool RADIUS_CONTROLS_HEIGHT_DEFAULT_VALUE = false;

	public const bool RADIUS_CONTROLS_WIDTH_DEFAULT_VALUE = false;

	public const bool ROTATE_CHILDREN_DEFAULT_VALUE = false;

	public const float CHILD_HEIGHT_DEFAULT_VALUE = 100f;

	public const float CHILD_ROTATION_DEFAULT_VALUE = 0f;

	public const float CHILD_WIDTH_DEFAULT_VALUE = 100f;

	public const float MAX_ANGLE = 360f;

	public const float MAX_ANGLE_DEFAULT_VALUE = 360f;

	public const float MAX_RADIUS_DEFAULT_VALUE = 1000f;

	public const float MIN_ANGLE = 0f;

	public const float MIN_ANGLE_DEFAULT_VALUE = 0f;

	public const float RADIUS_DEFAULT_VALUE = 100f;

	public const float RADIUS_HEIGHT_FACTOR_DEFAULT_VALUE = 1f;

	public const float RADIUS_WIDTH_FACTOR_DEFAULT_VALUE = 1f;

	public const float SPACING_DEFAULT_VALUE = 0f;

	public const float START_ANGLE_DEFAULT_VALUE = 0f;

	protected bool m_AutoRebuild = true;

	protected float m_ChildHeight = 100f;

	protected float m_ChildRotation;

	protected float m_ChildWidth = 100f;

	protected bool m_Clockwise;

	protected bool m_ControlChildHeight;

	protected bool m_ControlChildWidth;

	protected float m_MaxAngle = 360f;

	protected float m_MaxRadius = 1000f;

	protected float m_MinAngle;

	protected float m_Radius = 100f;

	protected bool m_RadiusControlsHeight;

	protected bool m_RadiusControlsWidth;

	protected float m_RadiusHeightFactor = 1f;

	protected float m_RadiusWidthFactor = 1f;

	protected bool m_RotateChildren;

	protected float m_Spacing;

	protected float m_StartAngle;

	private List<RectTransform> m_childList;

	private RectTransform m_rectTransform;

	public bool AutoRebuild
	{
		get
		{
			return m_AutoRebuild;
		}
		set
		{
			if (m_AutoRebuild != value)
			{
				m_AutoRebuild = value;
				if (value)
				{
					CalculateRadial();
				}
			}
		}
	}

	public float ChildHeight
	{
		get
		{
			return m_ChildHeight;
		}
		set
		{
			bool flag = m_ChildHeight == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C4537Ch\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_ChildHeight = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	public float ChildRotation
	{
		get
		{
			return m_ChildRotation;
		}
		set
		{
			bool flag = m_ChildRotation == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C4539Ch\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_ChildRotation = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	public float ChildWidth
	{
		get
		{
			return m_ChildWidth;
		}
		set
		{
			bool flag = m_ChildWidth == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C453BCh\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_ChildWidth = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	public bool Clockwise
	{
		get
		{
			return m_Clockwise;
		}
		set
		{
			if (m_Clockwise != value)
			{
				bool flag = !m_AutoRebuild;
				m_Clockwise = value;
				if (!flag)
				{
					CalculateRadial();
				}
			}
		}
	}

	public bool ControlChildHeight
	{
		get
		{
			return m_ControlChildHeight;
		}
		set
		{
			bool flag = !m_AutoRebuild;
			m_ControlChildHeight = value;
			if (!flag)
			{
				CalculateRadial();
			}
		}
	}

	public bool ControlChildWidth
	{
		get
		{
			return m_ControlChildWidth;
		}
		set
		{
			bool flag = !m_AutoRebuild;
			m_ControlChildWidth = value;
			if (!flag)
			{
				CalculateRadial();
			}
		}
	}

	public float MaxAngle
	{
		get
		{
			return m_MaxAngle;
		}
		set
		{
			bool flag = m_MaxAngle == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C4544Ch\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_MaxAngle = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	public float MinAngle
	{
		get
		{
			return m_MinAngle;
		}
		set
		{
			bool flag = m_MinAngle == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C4547Ch\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_MinAngle = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	public float Radius
	{
		get
		{
			return m_Radius;
		}
		set
		{
			bool flag = m_Radius == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C454AFh\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_Radius = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	public bool RadiusControlsHeight
	{
		get
		{
			return m_RadiusControlsHeight;
		}
		set
		{
			bool flag = !m_AutoRebuild;
			m_RadiusControlsHeight = value;
			if (!flag)
			{
				CalculateRadial();
			}
		}
	}

	public bool RadiusControlsWidth
	{
		get
		{
			return m_RadiusControlsWidth;
		}
		set
		{
			bool flag = !m_AutoRebuild;
			m_RadiusControlsWidth = value;
			if (!flag)
			{
				CalculateRadial();
			}
		}
	}

	public float RadiusHeightFactor
	{
		get
		{
			return m_RadiusHeightFactor;
		}
		set
		{
			bool flag = m_RadiusHeightFactor == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C4553Fh\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_RadiusHeightFactor = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	public float RadiusWidthFactor
	{
		get
		{
			return m_RadiusWidthFactor;
		}
		set
		{
			bool flag = m_RadiusWidthFactor == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C4557Fh\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_RadiusWidthFactor = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	public RectTransform RectTransform
	{
		get
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_015b: Expected O, but got I4
			RectTransform rectTransform = m_rectTransform;
			RectTransform component;
			if ((object)m_rectTransform == null || ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0)
			{
				component = GetComponent<RectTransform>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				m_rectTransform = component;
				if (flag)
				{
					goto IL_0129;
				}
				object obj = this + 168;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			component = m_rectTransform;
			goto IL_0129;
			IL_0129:
			return component;
		}
	}

	public bool RotateChildren
	{
		get
		{
			return m_RotateChildren;
		}
		set
		{
			bool flag = !m_AutoRebuild;
			m_RotateChildren = value;
			if (!flag)
			{
				CalculateRadial();
			}
		}
	}

	public float Spacing
	{
		get
		{
			return m_Spacing;
		}
		set
		{
			bool flag = m_Spacing == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C4572Fh\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_Spacing = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	public float StartAngle
	{
		get
		{
			return m_StartAngle;
		}
		set
		{
			bool flag = m_StartAngle == value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C4576Fh\"");
			if (!flag)
			{
				bool flag2 = !m_AutoRebuild;
				m_StartAngle = value;
				if (!flag2)
				{
					CalculateRadial();
				}
			}
		}
	}

	protected override void OnEnable()
	{
		SetDirty();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x182C457C0\"");
	}

	public override void SetLayoutHorizontal()
	{
	}

	public override void SetLayoutVertical()
	{
	}

	public override void CalculateLayoutInputVertical()
	{
		CalculateRadial();
	}

	public override void CalculateLayoutInputHorizontal()
	{
		CalculateRadial();
	}

	public unsafe void CalculateRadial()
	{
		//IL_0189: Expected O, but got I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00b2: Expected O, but got I8
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0b16: Expected O, but got I4
		//IL_0b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2b: Expected O, but got Unknown
		//IL_07c7: Expected I, but got O
		//IL_07cb: Expected O, but got I4
		//IL_0991: Expected I, but got O
		//IL_0bfb: Expected O, but got I4
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_0839->IL071a: Incompatible stack heights: 2 vs 0
		//IL_04a6->IL071a: Incompatible stack heights: 1 vs 0
		//IL_0895->IL071a: Incompatible stack heights: 2 vs 0
		//IL_0412->IL01a0: Incompatible stack heights: 2 vs 0
		//IL_0a24->IL071a: Incompatible stack heights: 2 vs 0
		//IL_0719->IL0719: Incompatible stack heights: 2 vs 1
		//IL_033b->IL071a: Incompatible stack heights: 2 vs 0
		//IL_03d1->IL071a: Incompatible stack heights: 2 vs 0
		if (m_childList == null)
		{
			List<RectTransform> childList = new List<RectTransform>();
			m_childList = childList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			if ((nint)0 != 0)
			{
				object obj = this + 160;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = 6603577472L;
				object obj6 = obj3 & 0x3F;
				nint num2;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r14_v5+462E0+v107 @ rdx_v66*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r14_v5+462E0+v107 @ rdx_v66*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r14_v5+462E0+v107 @ rdx_v66*8]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r14_v5+462E0+v107 @ rdx_v66*8]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r14_v5+462E0+v107 @ rdx_v66*8]");
				}
				while (num2 != 0);
			}
		}
		List<RectTransform> childList2 = m_childList;
		if (m_childList != null)
		{
			int version = childList2._version + 1;
			childList2._version = version;
			int size = childList2._size;
			childList2._size = 0;
			if (childList2._size > 0)
			{
				Array.Clear(childList2._items, 0, childList2._size);
			}
			Transform transform = base.transform;
			bool flag = (object)transform == null;
			int num3 = 0;
			int num4 = 0;
			object obj9 = 0;
			List<RectTransform> list = (List<RectTransform>)(object)transform;
			if (!flag)
			{
				float value = default(float);
				List<RectTransform>.Enumerator enumerator = default(List<RectTransform>.Enumerator);
				while (true)
				{
					bool flag2 = list._items == null;
					object obj10 = Transform.get_childCount_Injected((IntPtr)list._items);
					if (num3 >= (nint)obj10)
					{
						if (obj9 != null)
						{
							RectTransform rectTransform = m_rectTransform;
							if ((object)m_rectTransform == null || ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0)
							{
								RectTransform component = GetComponent<RectTransform>();
								m_rectTransform = component;
							}
							List<RectTransform> list2 = (List<RectTransform>)(object)m_rectTransform;
							if ((object)m_rectTransform == null)
							{
								break;
							}
							bool flag3 = list2._items == null;
							RectTransform.set_sizeDelta_Injected((IntPtr)list2._items, ref *(Vector2*)(&value));
							float num5 = (float)obj9 - 1f;
							float num6 = 360f / (float)obj9;
							float num7 = num6 * num5;
							float num8 = m_MinAngle;
							if (m_MinAngle > num7)
							{
								num8 = num7;
							}
							float num9 = 360f - m_MaxAngle;
							if (num9 > num7)
							{
								num9 = num7;
							}
							if (num8 > num7)
							{
								num8 = num7;
							}
							float num10 = num7 - num8;
							float num11 = num10 - num9;
							float num12 = (float)obj9 - 1f;
							float num13 = num11 / num12;
							float num14 = num13 + m_Spacing;
							float num15 = m_StartAngle + num8;
							object obj11 = m_ControlChildHeight | m_ControlChildWidth;
							if (m_Clockwise)
							{
								num14 *= -1f;
							}
							if (m_childList == null)
							{
								break;
							}
							List<RectTransform> list3 = null;
							while (enumerator.MoveNext())
							{
								List<RectTransform> list4 = null;
							}
						}
						return;
					}
					bool flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform2 == null)
					{
						break;
					}
					Transform child = transform2.GetChild(num4);
					bool flag5 = (object)child == null;
					List<RectTransform> list5 = null;
					if (!flag5)
					{
						bool flag6 = (object)child.GetType() != typeof(RectTransform);
						list5 = null;
						if (!flag6)
						{
							list5 = (List<RectTransform>)(object)child;
						}
					}
					if (list5 != null && list5._items != null)
					{
						UIButton component2 = ((Component)(object)list5).GetComponent<UIButton>();
						if ((object)component2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1700 @ rax_v115 (Doozy.Engine.UI.UIButton)+10]");
							if ((nint)0 != 0)
							{
								component2.UpdateStartValues();
							}
						}
						UIToggle component3 = ((Component)(object)list5).GetComponent<UIToggle>();
						if ((object)component3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1921 @ rax_v121 (Doozy.Engine.UI.UIToggle)+10]");
							if ((nint)0 != 0)
							{
								component3.UpdateStartValues();
							}
						}
						LayoutElement component4 = ((Component)(object)list5).GetComponent<LayoutElement>();
						if (list5._items != null)
						{
							GameObject gameObject = ((Component)(object)list5).gameObject;
							if ((object)gameObject == null)
							{
								break;
							}
							if (gameObject.activeSelf && ((object)component4 == null || ((UnityEngine.Object)component4).m_CachedPtr == (IntPtr)0 || !component4.ignoreLayout))
							{
								if (m_childList == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D750");
								obj9++;
							}
						}
					}
					num4++;
					Transform transform3 = base.transform;
					if ((object)transform3 == null)
					{
						break;
					}
					num3 = num4;
					size = 0;
					list = (List<RectTransform>)(object)transform3;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnValueChanged()
	{
		if (m_AutoRebuild)
		{
			CalculateRadial();
		}
	}

	public RadialLayout()
	{
		List<RectTransform> childList = new List<RectTransform>();
		m_childList = childList;
		base._002Ector();
	}
}
