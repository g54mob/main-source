using System;
using Cpp2ILInjected;
using Doozy.Engine.Touchy;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.UI;

public class UIDrawerArrowAnimator : MonoBehaviour
{
	private const float CLOSED_DRAWER_VELOCITY = 0.75f;

	private const float MAX_BAR_ROTATION = 45f;

	private const float ROTATION_SPEED = 10f;

	private UIDrawer _003CDrawer_003Ek__BackingField;

	private float _003CWidth_003Ek__BackingField;

	private float _003CHeight_003Ek__BackingField;

	public RectTransform Rotator;

	public RectTransform LeftBar;

	public RectTransform RightBar;

	private RectTransform m_rectTransform;

	private Image m_leftBarImage;

	private Image m_rightBarImage;

	private float m_velocity;

	private Vector3[] m_rotatorCorners;

	private Vector3[] m_drawerCorners;

	private float m_rotatorDisableThreshold;

	private Vector3[] m_tempCorners;

	private Rect m_rotatorRect;

	public UIDrawer Drawer
	{
		get
		{
			return _003CDrawer_003Ek__BackingField;
		}
		private set
		{
			_003CDrawer_003Ek__BackingField = value;
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
			RectTransform rectTransform2;
			if ((object)m_rectTransform == null || ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0)
			{
				rectTransform2 = GetComponent<RectTransform>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				m_rectTransform = rectTransform2;
				if (flag)
				{
					goto IL_0129;
				}
				object obj = this + 72;
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
			rectTransform2 = m_rectTransform;
			goto IL_0129;
			IL_0129:
			return rectTransform2;
		}
	}

	public float Width
	{
		get
		{
			return _003CWidth_003Ek__BackingField;
		}
		private set
		{
			_003CWidth_003Ek__BackingField = value;
		}
	}

	public float Height
	{
		get
		{
			return _003CHeight_003Ek__BackingField;
		}
		private set
		{
			_003CHeight_003Ek__BackingField = value;
		}
	}

	public Vector2 Size
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	private void Awake()
	{
		RectTransform leftBar = LeftBar;
		if ((object)LeftBar != null && ((UnityEngine.Object)leftBar).m_CachedPtr != (IntPtr)0)
		{
			Image component = LeftBar.GetComponent<Image>();
			m_leftBarImage = component;
		}
		RectTransform rightBar = RightBar;
		if ((object)RightBar != null && ((UnityEngine.Object)rightBar).m_CachedPtr != (IntPtr)0)
		{
			Image component2 = RightBar.GetComponent<Image>();
			m_rightBarImage = component2;
		}
		UpdateSize();
	}

	public Vector3[] AdjustCornersToIdentityRotation(RectTransform target, Vector3[] corners)
	{
		//IL_0025: Invalid comparison between F4 and I4
		//IL_0064: Invalid comparison between F4 and I4
		//IL_0252: Expected O, but got I
		//IL_0460: Expected O, but got I
		//IL_066e: Expected O, but got I
		Vector3 localEulerAngles = target.localEulerAngles;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182BA9F5Fh\"");
		if (localEulerAngles.z == 0f)
		{
			goto IL_003c;
		}
		if (target.localEulerAngles.z > 0f && !(90f < target.localEulerAngles.z))
		{
			Vector3[] tempCorners = m_tempCorners;
			if (corners.Length > 1 && tempCorners.Length > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+2C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+34]");
				_ = 0;
				Vector3[] tempCorners2 = m_tempCorners;
				if (corners.Length > 2 && tempCorners2.Length > 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+40]");
					_ = 0;
					Vector3[] tempCorners3 = m_tempCorners;
					if (corners.Length > 3 && tempCorners3.Length > 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+44]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+4C]");
						_ = 0;
						Vector3[] tempCorners4 = m_tempCorners;
						if (corners.Length > 0 && tempCorners4.Length > 3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+20]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+28]");
							Vector3 vector = (Vector3)0;
							goto IL_0686;
						}
					}
				}
			}
		}
		else if (target.localEulerAngles.z > 90f && !(180f < target.localEulerAngles.z))
		{
			Vector3[] tempCorners5 = m_tempCorners;
			if (corners.Length > 2 && tempCorners5.Length > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+40]");
				_ = 0;
				Vector3[] tempCorners6 = m_tempCorners;
				if (corners.Length > 3 && tempCorners6.Length > 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+44]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+4C]");
					_ = 0;
					Vector3[] tempCorners7 = m_tempCorners;
					if (corners.Length > 0 && tempCorners7.Length > 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+20]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+28]");
						_ = 0;
						Vector3[] tempCorners8 = m_tempCorners;
						if (corners.Length > 1 && tempCorners8.Length > 3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+2C]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+34]");
							Vector3 vector = (Vector3)0;
							goto IL_0686;
						}
					}
				}
			}
		}
		else
		{
			if (!(target.localEulerAngles.z > 180f) || 270f < target.localEulerAngles.z)
			{
				goto IL_003c;
			}
			Vector3[] tempCorners9 = m_tempCorners;
			if (corners.Length > 3 && tempCorners9.Length > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+44]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+4C]");
				_ = 0;
				Vector3[] tempCorners10 = m_tempCorners;
				if (corners.Length > 0 && tempCorners10.Length > 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+28]");
					_ = 0;
					Vector3[] tempCorners11 = m_tempCorners;
					if (corners.Length > 1 && tempCorners11.Length > 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+2C]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+34]");
						_ = 0;
						Vector3[] tempCorners12 = m_tempCorners;
						if (corners.Length > 2 && tempCorners12.Length > 3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+38]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [corners @ r8 (UnityEngine.Vector3[])+40]");
							Vector3 vector = (Vector3)0;
							goto IL_0686;
						}
					}
				}
			}
		}
		return (Vector3[])(object)new IndexOutOfRangeException();
		IL_0686:
		return m_tempCorners;
		IL_003c:
		return corners;
	}

	public void SetTargetDrawer(UIDrawer drawer)
	{
		_003CDrawer_003Ek__BackingField = drawer;
		RotateAndMoveArrowToMatchDrawerDirection(_003CDrawer_003Ek__BackingField);
	}

	public unsafe void UpdateArrow()
	{
		//IL_02a1: Expected F4, but got I
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected F4, but got Unknown
		//IL_02e5: Expected F4, but got I
		//IL_055a: Expected O, but got F4
		//IL_0584: Invalid comparison between F4 and I4
		//IL_04e1: Invalid comparison between I4 and F4
		//IL_0272: Expected F4, but got I
		//IL_0501: Invalid comparison between F4 and I4
		//IL_0521: Invalid comparison between I4 and F4
		//IL_0313: Expected F4, but got I4
		//IL_0341: Expected F4, but got I4
		//IL_05a4: Expected O, but got F4
		//IL_0435: Expected O, but got Ref
		//IL_05dc: Expected O, but got F4
		//IL_04c3: Expected O, but got Ref
		UIDrawer uIDrawer = _003CDrawer_003Ek__BackingField;
		float num = default(float);
		if (!uIDrawer._003CIsDragged_003Ek__BackingField && uIDrawer.m_visibility != VisibilityState.Hiding && uIDrawer.m_visibility != VisibilityState.Showing)
		{
			if (uIDrawer.CloseDirection != SimpleSwipe.Left && uIDrawer.CloseDirection != SimpleSwipe.Up)
			{
				if (uIDrawer.CloseDirection == SimpleSwipe.Right || uIDrawer.CloseDirection == SimpleSwipe.Down)
				{
					if (uIDrawer.m_visibility == VisibilityState.NotVisible)
					{
						m_velocity = 0.75f;
						num = 0.75f;
					}
					else
					{
						m_velocity = -0.75f;
						num = -0.75f;
					}
				}
			}
			else if (uIDrawer.m_visibility == VisibilityState.NotVisible)
			{
				m_velocity = -0.75f;
				num = -0.75f;
			}
			else
			{
				m_velocity = 0.75f;
				num = 0.75f;
			}
			goto IL_03ac;
		}
		float velocity;
		float num3 = default(float);
		if (uIDrawer.CloseDirection != SimpleSwipe.Left && uIDrawer.CloseDirection != SimpleSwipe.Right)
		{
			UIDrawerArrowAnimator uIDrawerArrowAnimator;
			if (uIDrawer.CloseDirection != SimpleSwipe.Up)
			{
				bool flag = uIDrawer.CloseDirection != SimpleSwipe.Down;
				uIDrawerArrowAnimator = this;
				if (flag)
				{
					goto IL_0551;
				}
			}
			uIDrawerArrowAnimator = (UIDrawerArrowAnimator)(object)uIDrawer.Container;
			float num2 = default(float);
			velocity = num2 - num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v22 (Doozy.Engine.UI.UIDrawerArrowAnimator)+9C]");
			num3 = 0f;
			num = num2;
		}
		else
		{
			UIDrawerArrowAnimator uIDrawerArrowAnimator = (UIDrawerArrowAnimator)(object)uIDrawer.Container;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v22 (Doozy.Engine.UI.UIDrawerArrowAnimator)+9C]");
			num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v22 (Doozy.Engine.UI.UIDrawerArrowAnimator)+74]");
			float num4 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v22 (Doozy.Engine.UI.UIDrawerArrowAnimator)+9C]");
			float num5 = num4 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			velocity = num5 ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v22 (Doozy.Engine.UI.UIDrawerArrowAnimator)+9C]");
			num3 = 0f;
		}
		m_velocity = velocity;
		goto IL_0551;
		IL_0551:
		object obj = Time.unscaledDeltaTime;
		float num6 = m_velocity / num;
		float num7 = num6 / 1000f;
		if (num7 > 0f && 0.05f > num7)
		{
			num7 = 0f;
		}
		if (0f > num7 && num7 > -0.05f)
		{
			num7 = 0f;
		}
		if (num7 > 0f)
		{
			bool flag2 = num7 > 1f;
			num = 1f;
			if (flag2)
			{
				goto IL_0518;
			}
		}
		num = num7;
		goto IL_0518;
		IL_0538:
		float velocity2;
		m_velocity = velocity2;
		goto IL_03ac;
		IL_0518:
		if (0f > num)
		{
			bool flag3 = -1f > num;
			velocity2 = -1f;
			if (flag3)
			{
				goto IL_0538;
			}
		}
		velocity2 = num;
		goto IL_0538;
		IL_03ac:
		Vector3 localEulerAngles = LeftBar.localEulerAngles;
		float num8 = m_velocity * 45f;
		if (!(-45f > num8))
		{
			if (num8 > 45f)
			{
				num8 = 45f;
			}
		}
		else
		{
			num8 = -45f;
		}
		object obj2 = Time.unscaledDeltaTime;
		float t = num * 10f;
		float num9 = Mathf.LerpAngle(localEulerAngles.z, num8, t);
		LeftBar.localEulerAngles = (Vector3)(&num3);
		Vector3 localEulerAngles2 = RightBar.localEulerAngles;
		float num10 = m_velocity * -45f;
		if (!(-45f > num10))
		{
			if (num10 > 45f)
			{
				num10 = 45f;
			}
		}
		else
		{
			num10 = -45f;
		}
		object obj3 = Time.unscaledDeltaTime;
		float t2 = num9 * 10f;
		float num11 = Mathf.LerpAngle(localEulerAngles2.z, num10, t2);
		RightBar.localEulerAngles = (Vector3)(&num3);
	}

	public unsafe void UpdateArrowColor(UIDrawer drawer)
	{
		//IL_017b: Invalid comparison between I4 and F4
		//IL_0113: Expected O, but got I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_01d7: Invalid comparison between I4 and F4
		//IL_015f: Expected O, but got I
		//IL_0298: Expected O, but got Ref
		//IL_02e5: Expected O, but got Ref
		UIDrawerArrow arrow = drawer.Arrow;
		if (!arrow.OverrideColor)
		{
			return;
		}
		RectTransform leftBar = LeftBar;
		if ((object)LeftBar == null || ((UnityEngine.Object)leftBar).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		RectTransform rightBar = RightBar;
		if ((object)RightBar == null || ((UnityEngine.Object)rightBar).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (drawer._003CIsDragged_003Ek__BackingField)
		{
			goto IL_016d;
		}
		bool flag = drawer.m_visibility == VisibilityState.Visible;
		Color color;
		if (!flag)
		{
			object obj = drawer.m_visibility - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (flag)
				{
					float num = 1f - drawer.m_visibilityProgress;
					if (!(0f > num) && !(num > 1f))
					{
					}
					goto IL_0342;
				}
				bool flag2 = (nint)obj2 != 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				color = (Color)0;
				if (!flag2)
				{
					goto IL_016d;
				}
			}
			else
			{
				UIDrawerArrow arrow2 = drawer.Arrow;
				color = arrow2.ClosedColor;
			}
		}
		else
		{
			UIDrawerArrow arrow3 = drawer.Arrow;
			color = arrow3.OpenedColor;
		}
		goto IL_0333;
		IL_0333:
		Image leftBarImage = m_leftBarImage;
		Color color2 = default(Color);
		if ((object)m_leftBarImage != null && ((UnityEngine.Object)leftBarImage).m_CachedPtr != (IntPtr)0)
		{
			m_leftBarImage.color = (Color)(&color);
			color = color2;
		}
		Image rightBarImage = m_rightBarImage;
		if ((object)m_rightBarImage != null && ((UnityEngine.Object)rightBarImage).m_CachedPtr != (IntPtr)0)
		{
			m_rightBarImage.color = (Color)(&color);
		}
		return;
		IL_0342:
		color = color2;
		goto IL_0333;
		IL_016d:
		if (!(0f > drawer.m_visibilityProgress) && !(drawer.m_visibilityProgress > 1f))
		{
		}
		goto IL_0342;
	}

	public void UpdateLocalScale(Vector3 scale)
	{
		RectTransform rectTransform = RectTransform;
		bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref value);
		UpdateSize();
	}

	public void UpdateLocalScale(float scale)
	{
		RectTransform rectTransform = RectTransform;
		bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref value);
		UpdateSize();
	}

	public void UpdateRotatorPosition(float visibility)
	{
		//IL_00d6: Expected O, but got I4
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Expected O, but got Unknown
		//IL_0bbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc0: Expected O, but got Unknown
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c18: Expected O, but got Unknown
		//IL_0c28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2d: Expected O, but got Unknown
		//IL_0843: Unknown result type (might be due to invalid IL or missing references)
		//IL_0848: Expected O, but got Unknown
		//IL_086b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0870: Expected O, but got Unknown
		//IL_08c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c8: Expected O, but got Unknown
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Expected O, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Expected O, but got Unknown
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Expected O, but got Unknown
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_0d9f: Invalid comparison between I4 and F4
		//IL_0dea: Expected F4, but got I4
		//IL_11d0: Expected O, but got I
		//IL_11ed: Expected O, but got I
		//IL_0a4f: Invalid comparison between I4 and F4
		//IL_0a9a: Expected F4, but got I4
		//IL_128a: Expected O, but got I
		//IL_10c2: Expected O, but got I
		//IL_10df: Expected O, but got I
		//IL_06ff: Invalid comparison between I4 and F4
		//IL_0e04: Expected O, but got I
		//IL_0e25: Expected O, but got I4
		//IL_074a: Expected F4, but got I4
		//IL_0f83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f88: Expected O, but got Unknown
		//IL_1192: Expected O, but got I
		//IL_0fb4: Expected O, but got I
		//IL_0fd1: Expected O, but got I
		//IL_0ab4: Expected O, but got I
		//IL_0ad5: Expected O, but got I4
		//IL_03e0: Invalid comparison between I4 and F4
		//IL_1084: Expected O, but got I
		//IL_042b: Expected F4, but got I4
		//IL_0764: Expected O, but got I
		//IL_0785: Expected O, but got I4
		//IL_0e89: Expected O, but got I
		//IL_0ea6: Expected O, but got I
		//IL_0f59: Expected O, but got I
		//IL_0445: Expected O, but got I
		//IL_0456: Expected O, but got I4
		//IL_0f97->IL0e6b: Incompatible stack heights: 1 vs 0
		//IL_0e45->IL0e45: Incompatible stack heights: 2 vs 0
		//IL_0ade->IL0f7a: Incompatible stack heights: 2 vs 1
		//IL_078e->IL0f7a: Incompatible stack heights: 2 vs 1
		//IL_0afb->IL0afb: Incompatible stack heights: 3 vs 0
		//IL_07ab->IL07ab: Incompatible stack heights: 3 vs 0
		//IL_045b->IL0f7a: Incompatible stack heights: 2 vs 1
		object obj5 = default(object);
		object obj14 = default(object);
		if ((object)Rotator != null)
		{
			Rotator.GetWorldCorners(m_rotatorCorners);
			Vector3[] rotatorCorners = AdjustCornersToIdentityRotation(Rotator, m_rotatorCorners);
			m_rotatorCorners = rotatorCorners;
			if ((object)_003CDrawer_003Ek__BackingField != null)
			{
				RectTransform rectTransform = _003CDrawer_003Ek__BackingField.RectTransform;
				if ((object)rectTransform != null)
				{
					rectTransform.GetWorldCorners(m_drawerCorners);
					UIDrawer uIDrawer = _003CDrawer_003Ek__BackingField;
					bool flag = (object)_003CDrawer_003Ek__BackingField == null;
					if (!flag)
					{
						object obj = uIDrawer.CloseDirection - 1;
						if (flag)
						{
							goto IL_0afb;
						}
						object obj2 = obj - 1;
						if (flag)
						{
							goto IL_07ab;
						}
						object obj3 = obj2 - 1;
						if (!flag)
						{
							if ((nint)obj3 != 1)
							{
								return;
							}
							if ((object)Rotator != null)
							{
								GameObject gameObject = Rotator.gameObject;
								Vector3[] rotatorCorners2 = m_rotatorCorners;
								if (m_rotatorCorners != null)
								{
									Vector3[] drawerCorners = m_drawerCorners;
									if (m_drawerCorners != null)
									{
										Vector3[] rotatorCorners3 = m_rotatorCorners;
										object obj4 = obj5 - 80;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ rdx_v51 (UnityEngine.Vector3[])+20]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ rdx_v51 (UnityEngine.Vector3[])+28]");
										_ = 0;
										object obj6 = obj5 - 96;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ rdx_v51 (UnityEngine.Vector3[])+2C]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ rdx_v51 (UnityEngine.Vector3[])+34]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2DA0");
										if ((object)gameObject != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ rdx_v51 (UnityEngine.Vector3[])+2C]");
											object obj7 = 0 * m_rotatorDisableThreshold;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v74 (UnityEngine.Vector3[])+24]");
											object obj8 = obj7 + 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v73 (UnityEngine.Vector3[])+30]");
											bool active = (nint)obj8 < 0;
											gameObject.SetActive(active);
											UIDrawer uIDrawer2 = _003CDrawer_003Ek__BackingField;
											object rotator = Rotator;
											if ((object)_003CDrawer_003Ek__BackingField != null)
											{
												UIDrawerArrow arrow = uIDrawer2.Arrow;
												if (uIDrawer2.Arrow != null && arrow.Down != null)
												{
													Vector3 closedLocalPosition = arrow.Down.ClosedLocalPosition;
													UIDrawer uIDrawer3 = _003CDrawer_003Ek__BackingField;
													_ = closedLocalPosition.x;
													if ((object)_003CDrawer_003Ek__BackingField != null)
													{
														UIDrawerArrow arrow2 = uIDrawer3.Arrow;
														if (uIDrawer3.Arrow != null && arrow2.Down != null)
														{
															Vector3 openedLocalPosition = arrow2.Down.OpenedLocalPosition;
															_ = openedLocalPosition.x;
															float num = 1f - visibility;
															if (!(0f > num))
															{
																if (num > 1f)
																{
																	num = 1f;
																}
															}
															else
															{
																num = 0f;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-50]");
															nint num2 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-60]");
															object obj9 = num2 - 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-4C]");
															nint num3 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-5C]");
															object obj10 = num3 - 0;
															float num4 = openedLocalPosition.z - closedLocalPosition.z;
															float num5 = (float)obj9 * num;
															float num6 = (float)obj10 * num;
															float num7 = num5;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-60]");
															float num8 = num7 + 0f;
															float num9 = num4 * num;
															float num10 = num6;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-5C]");
															float num11 = num10 + 0f;
															float num12 = num9 + closedLocalPosition.z;
															bool flag2 = (object)Rotator == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v26 (System.Object)+10]");
															object obj11 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v26 (System.Object)+10]");
															bool flag3 = (nint)0 == 0;
															object obj12 = 0;
															object obj13 = obj14;
															object obj15 = 0;
															goto IL_0f7a;
														}
													}
												}
											}
										}
									}
								}
							}
						}
						else if ((object)Rotator != null)
						{
							GameObject gameObject2 = Rotator.gameObject;
							Vector3[] rotatorCorners4 = m_rotatorCorners;
							if (m_rotatorCorners != null)
							{
								Vector3[] drawerCorners2 = m_drawerCorners;
								if (m_drawerCorners != null)
								{
									Vector3[] rotatorCorners5 = m_rotatorCorners;
									object obj16 = obj5 - 96;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ rdx_v45 (UnityEngine.Vector3[])+2C]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ rdx_v45 (UnityEngine.Vector3[])+34]");
									_ = 0;
									object obj17 = obj5 - 80;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ rdx_v45 (UnityEngine.Vector3[])+20]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ rdx_v45 (UnityEngine.Vector3[])+28]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2DA0");
									if ((object)gameObject2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ rdx_v45 (UnityEngine.Vector3[])+20]");
										object obj18 = 0 * m_rotatorDisableThreshold;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rcx_v64 (UnityEngine.Vector3[])+30]");
										object obj19 = 0 - obj18;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rcx_v63 (UnityEngine.Vector3[])+24]");
										bool active2 = 0 < (nint)obj19;
										gameObject2.SetActive(active2);
										UIDrawer uIDrawer4 = _003CDrawer_003Ek__BackingField;
										object rotator2 = Rotator;
										if ((object)_003CDrawer_003Ek__BackingField != null)
										{
											UIDrawerArrow arrow3 = uIDrawer4.Arrow;
											if (uIDrawer4.Arrow != null && arrow3.Up != null)
											{
												Vector3 closedLocalPosition2 = arrow3.Up.ClosedLocalPosition;
												UIDrawer uIDrawer5 = _003CDrawer_003Ek__BackingField;
												_ = closedLocalPosition2.x;
												if ((object)_003CDrawer_003Ek__BackingField != null)
												{
													UIDrawerArrow arrow4 = uIDrawer5.Arrow;
													if (uIDrawer5.Arrow != null && arrow4.Up != null)
													{
														Vector3 openedLocalPosition2 = arrow4.Up.OpenedLocalPosition;
														_ = openedLocalPosition2.x;
														float num = 1f - visibility;
														if (!(0f > num))
														{
															if (num > 1f)
															{
																num = 1f;
															}
														}
														else
														{
															num = 0f;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-50]");
														nint num13 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-60]");
														object obj20 = num13 - 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-4C]");
														nint num14 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-5C]");
														object obj21 = num14 - 0;
														float num15 = openedLocalPosition2.z - closedLocalPosition2.z;
														float num16 = (float)obj20 * num;
														float num17 = (float)obj21 * num;
														float num18 = num16;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-60]");
														float num8 = num18 + 0f;
														float num19 = num15 * num;
														float num20 = num17;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-5C]");
														float num11 = num20 + 0f;
														float num21 = num19 + closedLocalPosition2.z;
														bool flag4 = (object)Rotator == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v24 (System.Object)+10]");
														object obj11 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v24 (System.Object)+10]");
														bool flag5 = (nint)0 == 0;
														object obj12 = 0;
														bool flag6 = (nint)0 != 0;
														object obj13 = obj14;
														object obj15 = 0;
														if (!flag6)
														{
															bool flag7 = (nint)0 == 0;
															goto IL_07ab;
														}
														goto IL_0f7a;
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
			}
		}
		goto IL_0e45;
		IL_0e45:
		throw new NullReferenceException();
		IL_07ab:
		if ((object)Rotator != null)
		{
			GameObject gameObject3 = Rotator.gameObject;
			Vector3[] rotatorCorners6 = m_rotatorCorners;
			if (m_rotatorCorners != null)
			{
				Vector3[] drawerCorners3 = m_drawerCorners;
				if (m_drawerCorners != null)
				{
					Vector3[] rotatorCorners7 = m_rotatorCorners;
					object obj22 = obj5 - 96;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ rdx_v39 (UnityEngine.Vector3[])+38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ rdx_v39 (UnityEngine.Vector3[])+40]");
					_ = 0;
					object obj23 = obj5 - 80;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ rdx_v39 (UnityEngine.Vector3[])+2C]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ rdx_v39 (UnityEngine.Vector3[])+34]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2DA0");
					if ((object)gameObject3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ rdx_v39 (UnityEngine.Vector3[])+2C]");
						object obj24 = 0 * m_rotatorDisableThreshold;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v53 (UnityEngine.Vector3[])+38]");
						object obj25 = 0 - obj24;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rcx_v52 (UnityEngine.Vector3[])+2C]");
						bool active3 = 0 < (nint)obj25;
						gameObject3.SetActive(active3);
						UIDrawer uIDrawer6 = _003CDrawer_003Ek__BackingField;
						object rotator3 = Rotator;
						if ((object)_003CDrawer_003Ek__BackingField != null)
						{
							UIDrawerArrow arrow5 = uIDrawer6.Arrow;
							if (uIDrawer6.Arrow != null && arrow5.Right != null)
							{
								Vector3 closedLocalPosition3 = arrow5.Right.ClosedLocalPosition;
								UIDrawer uIDrawer7 = _003CDrawer_003Ek__BackingField;
								_ = closedLocalPosition3.x;
								if ((object)_003CDrawer_003Ek__BackingField != null)
								{
									UIDrawerArrow arrow6 = uIDrawer7.Arrow;
									if (uIDrawer7.Arrow != null && arrow6.Right != null)
									{
										Vector3 openedLocalPosition3 = arrow6.Right.OpenedLocalPosition;
										_ = openedLocalPosition3.x;
										float num = 1f - visibility;
										if (!(0f > num))
										{
											if (num > 1f)
											{
												num = 1f;
											}
										}
										else
										{
											num = 0f;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-50]");
										nint num22 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-60]");
										object obj26 = num22 - 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-4C]");
										nint num23 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-5C]");
										object obj27 = num23 - 0;
										float num24 = openedLocalPosition3.z - closedLocalPosition3.z;
										float num25 = (float)obj26 * num;
										float num26 = (float)obj27 * num;
										float num27 = num25;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-60]");
										float num8 = num27 + 0f;
										float num28 = num24 * num;
										float num29 = num26;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-5C]");
										float num11 = num29 + 0f;
										float num30 = num28 + closedLocalPosition3.z;
										bool flag8 = (object)Rotator == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdi_v22 (System.Object)+10]");
										object obj11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdi_v22 (System.Object)+10]");
										bool flag9 = (nint)0 == 0;
										object obj12 = 0;
										bool flag10 = (nint)0 != 0;
										object obj13 = obj14;
										object obj15 = 0;
										if (!flag10)
										{
											bool flag11 = (nint)0 == 0;
											goto IL_0afb;
										}
										goto IL_0f7a;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0e45;
		IL_0afb:
		if ((object)Rotator != null)
		{
			GameObject gameObject4 = Rotator.gameObject;
			Vector3[] rotatorCorners8 = m_rotatorCorners;
			if (m_rotatorCorners != null)
			{
				Vector3[] drawerCorners4 = m_drawerCorners;
				if (m_drawerCorners != null)
				{
					Vector3[] rotatorCorners9 = m_rotatorCorners;
					object obj28 = obj5 - 96;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ rdx_v33 (UnityEngine.Vector3[])+2C]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ rdx_v33 (UnityEngine.Vector3[])+34]");
					_ = 0;
					object obj29 = obj5 - 80;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ rdx_v33 (UnityEngine.Vector3[])+38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ rdx_v33 (UnityEngine.Vector3[])+40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2DA0");
					if ((object)gameObject4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ rdx_v33 (UnityEngine.Vector3[])+38]");
						object obj30 = 0 * m_rotatorDisableThreshold;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v42 (UnityEngine.Vector3[])+2C]");
						object obj31 = obj30 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v41 (UnityEngine.Vector3[])+38]");
						bool active4 = (nint)obj31 < 0;
						gameObject4.SetActive(active4);
						UIDrawer uIDrawer8 = _003CDrawer_003Ek__BackingField;
						object rotator4 = Rotator;
						if ((object)_003CDrawer_003Ek__BackingField != null)
						{
							UIDrawerArrow arrow7 = uIDrawer8.Arrow;
							if (uIDrawer8.Arrow != null && arrow7.Left != null)
							{
								Vector3 closedLocalPosition4 = arrow7.Left.ClosedLocalPosition;
								UIDrawer uIDrawer9 = _003CDrawer_003Ek__BackingField;
								_ = closedLocalPosition4.x;
								if ((object)_003CDrawer_003Ek__BackingField != null)
								{
									UIDrawerArrow arrow8 = uIDrawer9.Arrow;
									if (uIDrawer9.Arrow != null && arrow8.Left != null)
									{
										Vector3 openedLocalPosition4 = arrow8.Left.OpenedLocalPosition;
										_ = openedLocalPosition4.x;
										float num = 1f - visibility;
										if (!(0f > num))
										{
											if (num > 1f)
											{
												num = 1f;
											}
										}
										else
										{
											num = 0f;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-50]");
										nint num31 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-60]");
										object obj32 = num31 - 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-4C]");
										nint num32 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-5C]");
										object obj33 = num32 - 0;
										float num33 = openedLocalPosition4.z - closedLocalPosition4.z;
										float num34 = (float)obj32 * num;
										float num35 = (float)obj33 * num;
										float num36 = num34;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-60]");
										float num8 = num36 + 0f;
										float num37 = num33 * num;
										float num38 = num35;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-5C]");
										float num11 = num38 + 0f;
										float num39 = num37 + closedLocalPosition4.z;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v20 (System.Object)+10]");
										object obj11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v20 (System.Object)+10]");
										bool flag12 = (nint)0 == 0;
										object obj12 = 0;
										bool flag13 = (nint)0 != 0;
										object obj13 = obj14;
										object obj15 = 0;
										if (flag13)
										{
											goto IL_0f7a;
										}
										bool flag14 = (nint)0 == 0;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0e45;
		IL_0f7a:
		object obj34 = obj5 - 80;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2042 @ rax_v39 (should have been resolved before IL gen)");
	}

	private unsafe void RotateAndMoveArrowToMatchDrawerDirection(UIDrawer drawer)
	{
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Expected O, but got Unknown
		//IL_0032: Expected O, but got I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0753: Expected O, but got Unknown
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Expected O, but got Unknown
		//IL_04ab: Expected O, but got I
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected O, but got Unknown
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Expected O, but got Unknown
		//IL_04c3: Expected O, but got I
		//IL_04e5: Expected O, but got I4
		//IL_04f7: Expected O, but got I4
		//IL_0379: Expected O, but got I
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Expected O, but got Unknown
		//IL_0670: Unknown result type (might be due to invalid IL or missing references)
		//IL_0675: Expected O, but got Unknown
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Expected O, but got Unknown
		//IL_0391: Expected O, but got I
		//IL_03b3: Expected O, but got I4
		//IL_03c5: Expected O, but got I4
		//IL_0250: Expected O, but got I
		//IL_0268: Expected O, but got I
		//IL_0281: Expected O, but got I4
		//IL_0293: Expected O, but got I4
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Expected O, but got Unknown
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f7: Expected O, but got Unknown
		//IL_0158: Expected O, but got I
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Expected O, but got Unknown
		//IL_0170: Expected O, but got I
		//IL_0179: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		//IL_0667->IL05cc: Incompatible stack heights: 6 vs 1
		//IL_0517->IL0517: Incompatible stack heights: 7 vs 2
		//IL_03eb->IL03eb: Incompatible stack heights: 7 vs 1
		//IL_02b9->IL02b9: Incompatible stack heights: 7 vs 1
		RectTransform rotator = Rotator;
		_ = Quaternion.identityQuaternion;
		bool flag = ((UnityEngine.Object)rotator).m_CachedPtr == (IntPtr)0;
		object obj2 = default(object);
		object obj = obj2 - 48;
		Transform.set_localRotation_Injected(((UnityEngine.Object)rotator).m_CachedPtr, ref *(Quaternion*)obj);
		bool flag2 = (object)drawer == null;
		object obj3 = drawer.CloseDirection - 1;
		if (flag2)
		{
			goto IL_03eb;
		}
		object obj4 = obj3 - 1;
		if (flag2)
		{
			goto IL_02b9;
		}
		object obj5 = obj4 - 1;
		bool num;
		bool num2;
		bool num3;
		bool num4;
		bool num5;
		object obj8;
		IntPtr cachedPtr;
		object obj9;
		object obj10;
		bool flag8;
		object obj11;
		if (!flag2)
		{
			if ((nint)obj5 != 1)
			{
				goto IL_05cc;
			}
			RectTransform rectTransform = RectTransform;
			UIDrawerArrow arrow = drawer.Arrow;
			bool flag3 = drawer.Arrow == null;
			num = flag3;
			UIDrawerArrow.Holder down = arrow.Down;
			bool flag4 = arrow.Down == null;
			num2 = flag4;
			bool flag5 = (object)rectTransform == null;
			num3 = flag5;
			rectTransform.SetParent(down.Root, worldPositionStays: true);
			RectTransform rotator2 = Rotator;
			_ = 0;
			_ = 0;
			object obj6 = obj2 - 48;
			object obj7 = obj2 - 64;
			Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj7, out *(Quaternion*)obj6);
			bool flag6 = (object)Rotator == null;
			num4 = flag6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-30]");
			obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-30]");
			_ = 0;
			cachedPtr = ((UnityEngine.Object)rotator2).m_CachedPtr;
			bool flag7 = ((UnityEngine.Object)rotator2).m_CachedPtr == (IntPtr)0;
			num5 = flag7;
			obj9 = 0;
			obj10 = 0;
			flag8 = true;
			obj11 = 0;
		}
		else
		{
			RectTransform rectTransform2 = RectTransform;
			UIDrawerArrow arrow2 = drawer.Arrow;
			bool flag9 = drawer.Arrow == null;
			num = flag9;
			UIDrawerArrow.Holder up = arrow2.Up;
			bool flag10 = arrow2.Up == null;
			num2 = flag10;
			bool flag11 = (object)rectTransform2 == null;
			num3 = flag11;
			rectTransform2.SetParent(up.Root, worldPositionStays: true);
			RectTransform rotator3 = Rotator;
			_ = 0;
			_ = 0;
			object obj12 = obj2 - 48;
			object obj13 = obj2 - 64;
			Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj13, out *(Quaternion*)obj12);
			bool flag12 = (object)Rotator == null;
			num4 = flag12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-30]");
			obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-30]");
			_ = 0;
			cachedPtr = ((UnityEngine.Object)rotator3).m_CachedPtr;
			bool flag13 = ((UnityEngine.Object)rotator3).m_CachedPtr == (IntPtr)0;
			num5 = flag13;
			obj9 = 0;
			bool flag14 = (nint)0 != 0;
			obj10 = 0;
			flag8 = true;
			obj11 = 0;
			if (!flag14)
			{
				bool flag15 = (nint)0 == 0;
				goto IL_02b9;
			}
		}
		goto IL_064a;
		IL_05cc:
		RectTransform rectTransform3 = RectTransform;
		bool flag16 = (object)rectTransform3 == null;
		goto IL_0517;
		IL_03eb:
		RectTransform rectTransform4 = RectTransform;
		UIDrawerArrow arrow3 = drawer.Arrow;
		bool flag17 = drawer.Arrow == null;
		num = flag17;
		UIDrawerArrow.Holder left = arrow3.Left;
		bool flag18 = arrow3.Left == null;
		num2 = flag18;
		bool flag19 = (object)rectTransform4 == null;
		num3 = flag19;
		rectTransform4.SetParent(left.Root, worldPositionStays: true);
		RectTransform rotator4 = Rotator;
		_ = (float)Math.PI / 2f;
		_ = 0;
		object obj14 = obj2 - 48;
		object obj15 = obj2 - 64;
		Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj15, out *(Quaternion*)obj14);
		bool flag20 = (object)Rotator == null;
		num4 = flag20;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-30]");
		obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-30]");
		_ = 0;
		cachedPtr = ((UnityEngine.Object)rotator4).m_CachedPtr;
		bool flag21 = ((UnityEngine.Object)rotator4).m_CachedPtr == (IntPtr)0;
		num5 = flag21;
		obj9 = 0;
		bool flag22 = (nint)0 != 0;
		float num6 = (float)Math.PI / 2f;
		obj10 = 0;
		flag8 = true;
		obj11 = 0;
		if (!flag22)
		{
			bool flag23 = (nint)0 == 0;
			goto IL_0517;
		}
		goto IL_064a;
		IL_0517:
		Vector2 anchoredPosition = default(Vector2);
		rectTransform3.anchoredPosition = anchoredPosition;
		bool flag24 = drawer.Arrow == null;
		RectTransform rectTransform5 = RectTransform;
		bool flag25 = (object)rectTransform5 == null;
		_ = 1f;
		bool flag26 = ((UnityEngine.Object)rectTransform5).m_CachedPtr == (IntPtr)0;
		object obj16 = obj2 - 64;
		Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform5).m_CachedPtr, ref *(Vector3*)obj16);
		UpdateSize();
		UpdateArrowColor(drawer);
		return;
		IL_064a:
		object obj17 = obj2 - 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1466 @ rax_v63 (should have been resolved before IL gen)");
		goto IL_05cc;
		IL_02b9:
		RectTransform rectTransform6 = RectTransform;
		UIDrawerArrow arrow4 = drawer.Arrow;
		bool flag27 = drawer.Arrow == null;
		num = flag27;
		UIDrawerArrow.Holder right = arrow4.Right;
		bool flag28 = arrow4.Right == null;
		num2 = flag28;
		bool flag29 = (object)rectTransform6 == null;
		num3 = flag29;
		rectTransform6.SetParent(right.Root, worldPositionStays: true);
		RectTransform rotator5 = Rotator;
		_ = (float)Math.PI / 2f;
		_ = 0;
		object obj18 = obj2 - 48;
		object obj19 = obj2 - 64;
		Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj19, out *(Quaternion*)obj18);
		bool flag30 = (object)Rotator == null;
		num4 = flag30;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-30]");
		obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-30]");
		_ = 0;
		cachedPtr = ((UnityEngine.Object)rotator5).m_CachedPtr;
		bool flag31 = ((UnityEngine.Object)rotator5).m_CachedPtr == (IntPtr)0;
		num5 = flag31;
		obj9 = 0;
		bool flag32 = (nint)0 != 0;
		num6 = (float)Math.PI / 2f;
		obj10 = 0;
		flag8 = true;
		obj11 = 0;
		if (!flag32)
		{
			bool flag33 = (nint)0 == 0;
			goto IL_03eb;
		}
		goto IL_064a;
	}

	private void UpdateSize()
	{
		//IL_0065: Expected F4, but got I
		//IL_0077: Expected F4, but got I
		RectTransform rotator = Rotator;
		bool flag = ((UnityEngine.Object)rotator).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rotator).m_CachedPtr, out Rect ret);
		m_rotatorRect = ret;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawerArrowAnimator)+90]");
		_003CWidth_003Ek__BackingField = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawerArrowAnimator)+94]");
		_003CHeight_003Ek__BackingField = 0f;
	}

	public UIDrawerArrowAnimator()
	{
		Vector3[] rotatorCorners = new Vector3[4];
		m_rotatorCorners = rotatorCorners;
		Vector3[] drawerCorners = new Vector3[4];
		m_drawerCorners = drawerCorners;
		m_rotatorDisableThreshold = 0.6f;
		Vector3[] tempCorners = new Vector3[4];
		m_tempCorners = tempCorners;
	}
}
