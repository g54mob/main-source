using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Extensions;
using Doozy.Engine.Orientation;
using Doozy.Engine.Progress;
using Doozy.Engine.Settings;
using Doozy.Engine.Soundy;
using Doozy.Engine.Touchy;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Settings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Doozy.Engine.UI;

public class UIDrawer : UIComponentBase<UIDrawer>, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003C_002Ecctor_003Eb__134_0(UIDrawer _003Cp0_003E, UIDrawerBehaviorType _003Cp1_003E)
		{
		}
	}

	private const float AUTO_OPEN_IF_DRAGGED_OVER_VISIBILITY_PERCENT = 0.5f;

	private const float AUTO_CLOSE_IF_DRAGGED_UNDER_VISIBILITY_PERCENT = 0.5f;

	private const float AUTO_OPEN_OR_CLOSE_TERMINAL_SWIPE_VELOCITY = 800f;

	private static UIDrawer _003CDraggedDrawer_003Ek__BackingField;

	private static UIDrawer _003COpenedDrawer_003Ek__BackingField;

	public static Action<UIDrawer, UIDrawerBehaviorType> OnUIDrawerBehavior;

	private bool _003CIsDragged_003Ek__BackingField;

	public UIDrawerArrow Arrow;

	public bool BlockBackButton = true;

	public UIDrawerBehavior CloseBehavior;

	public SimpleSwipe CloseDirection;

	public float CloseSpeed;

	public UIDrawerContainer Container;

	public Vector3 CustomStartAnchoredPosition;

	public bool CustomDrawerName;

	public string DrawerName;

	public bool DetectGestures;

	public UIDrawerBehavior DragBehavior;

	public bool HideOnBackButton = true;

	public ProgressEvent OnProgressChanged;

	public ProgressEvent OnInverseProgressChanged;

	public UIDrawerBehavior OpenBehavior;

	public float OpenSpeed;

	public UIContainer Overlay;

	public Progressor Progressor;

	public bool UseCustomStartAnchoredPosition;

	private Canvas m_canvas;

	private VisibilityState m_visibility;

	private float m_visibilityProgress;

	private Vector2 m_scaledCanvas;

	private bool m_availableForDrag;

	private Vector2 m_dragStartPosition;

	private const string GIZMOS_TEXTURE_PATH = "Doozy/UI/UIDrawer/";

	private const bool GIZMOS_ALLOW_SCALING = true;

	private const string ARROW_ROOT = "ArrowRoot";

	private const string ARROW_LEFT = "ArrowLeft";

	private const string ARROW_RIGHT = "ArrowRight";

	private const string ARROW_UP = "ArrowUp";

	private const string ARROW_DOWN = "ArrowDown";

	public static bool AnyDrawerOpened
	{
		get
		{
			UIDrawer uIDrawer = _003COpenedDrawer_003Ek__BackingField;
			if ((object)_003COpenedDrawer_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v1 (Doozy.Engine.UI.UIDrawer)+10]");
				bool flag = (nint)0 == 0;
				return !flag;
			}
			return false;
		}
	}

	public static string DefaultDrawerCategory
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998069A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "General";
		}
	}

	public static string DefaultDrawerName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998069B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Unnamed";
		}
	}

	public static UIDrawer DraggedDrawer
	{
		get
		{
			return _003CDraggedDrawer_003Ek__BackingField;
		}
		private set
		{
			_003CDraggedDrawer_003Ek__BackingField = value;
		}
	}

	public static UIDrawer OpenedDrawer
	{
		get
		{
			return _003COpenedDrawer_003Ek__BackingField;
		}
		private set
		{
			_003COpenedDrawer_003Ek__BackingField = value;
		}
	}

	private static TouchDetector Detector => TouchDetector.Instance;

	public bool ArrowEnabled
	{
		get
		{
			//IL_0105: Expected I4, but got O
			if (Arrow != null)
			{
				UIDrawerArrow arrow = Arrow;
				UIDrawerArrowAnimator animator = arrow.Animator;
				if ((object)arrow.Animator != null && ((UnityEngine.Object)animator).m_CachedPtr != (IntPtr)0)
				{
					UIDrawerArrow arrow2 = Arrow;
					if (Arrow != null)
					{
						RectTransform container = arrow2.Container;
						if ((object)arrow2.Container == null || ((UnityEngine.Object)container).m_CachedPtr == (IntPtr)0)
						{
							goto IL_00f1;
						}
						UIDrawerArrow arrow3 = Arrow;
						if (Arrow != null)
						{
							return arrow3.Enabled;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
			}
			goto IL_00f1;
			IL_00f1:
			return false;
		}
	}

	public Canvas Canvas
	{
		get
		{
			Canvas canvas = m_canvas;
			if ((object)m_canvas == null || ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0)
			{
				Canvas canvas2 = GetComponent<Canvas>();
				if ((object)canvas2 == null)
				{
					GameObject gameObject = base.gameObject;
					if ((object)gameObject == null)
					{
						return (Canvas)(object)new NullReferenceException();
					}
					canvas2 = gameObject.AddComponent<Canvas>();
				}
				m_canvas = canvas2;
			}
			return m_canvas;
		}
	}

	public bool Closed
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_visibility - 1;
			return obj == null;
		}
	}

	public bool HasArrow
	{
		get
		{
			//IL_00d4: Expected I4, but got O
			if (Arrow != null)
			{
				UIDrawerArrow arrow = Arrow;
				UIDrawerArrowAnimator animator = arrow.Animator;
				if ((object)arrow.Animator != null && ((UnityEngine.Object)animator).m_CachedPtr != (IntPtr)0)
				{
					UIDrawerArrow arrow2 = Arrow;
					if (Arrow == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					RectTransform container = arrow2.Container;
					if ((object)arrow2.Container != null)
					{
						bool flag = ((UnityEngine.Object)container).m_CachedPtr == (IntPtr)0;
						return !flag;
					}
				}
			}
			return false;
		}
	}

	public bool HasContainer
	{
		get
		{
			if (Container != null)
			{
				UIDrawerContainer container = Container;
				RectTransform rectTransform = container.RectTransform;
				if ((object)container.RectTransform != null)
				{
					bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
			}
			return false;
		}
	}

	public bool HasOverlay
	{
		get
		{
			if (Overlay != null)
			{
				UIContainer overlay = Overlay;
				RectTransform rectTransform = overlay.RectTransform;
				if ((object)overlay.RectTransform != null)
				{
					bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
			}
			return false;
		}
	}

	public float InverseVisibility => 1f - m_visibilityProgress;

	public bool IsClosing
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_visibility - 2;
			return obj == null;
		}
	}

	public bool IsDragged
	{
		get
		{
			return _003CIsDragged_003Ek__BackingField;
		}
		private set
		{
			_003CIsDragged_003Ek__BackingField = value;
		}
	}

	public bool IsOpening
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_visibility - 3;
			return obj == null;
		}
	}

	public bool Opened => m_visibility == VisibilityState.Visible;

	public VisibilityState Visibility => m_visibility;

	public float VisibilityProgress
	{
		get
		{
			return m_visibilityProgress;
		}
		private set
		{
			//IL_02b4: Invalid comparison between I4 and F4
			//IL_0044: Expected F4, but got I4
			//IL_0223: Invalid comparison between I4 and F4
			//IL_026e: Expected F4, but got I4
			float num;
			if (!(0f > value))
			{
				bool flag = !(value > 1f);
				num = value;
				if (!flag)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			m_visibilityProgress = num;
			if (HasOverlay)
			{
				UIContainer overlay = Overlay;
				overlay.CanvasGroup.alpha = num;
			}
			if (HasContainer)
			{
				UIDrawerContainer container = Container;
				if (container.FadeOut)
				{
					container.CanvasGroup.alpha = m_visibilityProgress;
				}
			}
			UIDrawerArrow arrow = Arrow;
			GameObject gameObject = arrow.Container.gameObject;
			bool arrowEnabled = ArrowEnabled;
			gameObject.SetActive(arrowEnabled);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806B8]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+20]");
			if ((nint)0 == 0)
			{
				DoozySettings instance = DoozySettings.Instance;
				if (!instance.DebugUIDrawer)
				{
					goto IL_031d;
				}
			}
			string text = GetName();
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			string text2 = System.Number.FormatSingle(m_visibilityProgress, null, currentInfo);
			string message = "[" + text + "] OpenProgress: " + text2;
			DDebug.Log(message, this);
			goto IL_031d;
			IL_031d:
			Progressor progressor = Progressor;
			if ((object)Progressor != null && ((UnityEngine.Object)progressor).m_CachedPtr != (IntPtr)0)
			{
				Progressor progressor2 = Progressor;
				float num2 = m_visibilityProgress;
				if (!(0f > m_visibilityProgress))
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
				float num3 = progressor2.m_maxValue - progressor2.m_minValue;
				float num4 = num3 * num2;
				float value2 = num4 + progressor2.m_minValue;
				progressor2.SetValue(value2, instantUpdate: false);
			}
			OnProgressChanged.Invoke(m_visibilityProgress);
			float arg = 1f - m_visibilityProgress;
			OnInverseProgressChanged.Invoke(arg);
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0069: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+20]");
			if ((nint)0 != 0)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugUIDrawer;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private void OnDrawGizmosSelected()
	{
		//IL_0062: Expected O, but got I4
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_066b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Expected O, but got Unknown
		//IL_0679: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Expected O, but got Unknown
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Expected O, but got Unknown
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Expected O, but got Unknown
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Expected O, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected O, but got Unknown
		//IL_0811: Unknown result type (might be due to invalid IL or missing references)
		//IL_0816: Expected O, but got Unknown
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806A5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!ArrowEnabled)
		{
			return;
		}
		bool flag = CloseDirection == SimpleSwipe.None;
		if (flag)
		{
			return;
		}
		object obj = CloseDirection - 1;
		object obj4 = default(object);
		Color tint3;
		bool allowScaling;
		string text;
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
					UIDrawerArrow arrow = Arrow;
					UIDrawerArrow.Holder down = arrow.Down;
					Transform transform = down.Root.transform;
					Vector3 position = transform.position;
					Color tint = (Color)(obj4 - 32);
					Vector3 center = (Vector3)(obj4 - 64);
					_ = position.x;
					_ = position.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					_ = 0;
					Gizmos.DrawIcon(center, "Doozy/UI/UIDrawer/ArrowRoot", allowScaling: true, tint);
					UIDrawerArrow arrow2 = Arrow;
					UIDrawerArrow.Holder down2 = arrow2.Down;
					Transform transform2 = down2.Closed.transform;
					Vector3 position2 = transform2.position;
					Color tint2 = (Color)(obj4 - 32);
					Vector3 center2 = (Vector3)(obj4 - 64);
					_ = position2.x;
					_ = position2.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					_ = 0;
					Gizmos.DrawIcon(center2, "Doozy/UI/UIDrawer/ArrowUp", allowScaling: true, tint2);
					UIDrawerArrow arrow3 = Arrow;
					UIDrawerArrow.Holder down3 = arrow3.Down;
					Transform transform3 = down3.Opened.transform;
					Vector3 position3 = transform3.position;
					tint3 = (Color)(obj4 - 32);
					_ = position3.x;
					_ = position3.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					_ = 0;
					allowScaling = true;
					text = "Doozy/UI/UIDrawer/ArrowDown";
				}
				else
				{
					UIDrawerArrow arrow4 = Arrow;
					UIDrawerArrow.Holder up = arrow4.Up;
					Transform transform4 = up.Root.transform;
					Vector3 position4 = transform4.position;
					Color tint4 = (Color)(obj4 - 32);
					Vector3 center3 = (Vector3)(obj4 - 64);
					_ = position4.x;
					_ = position4.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					_ = 0;
					Gizmos.DrawIcon(center3, "Doozy/UI/UIDrawer/ArrowRoot", allowScaling: true, tint4);
					UIDrawerArrow arrow5 = Arrow;
					UIDrawerArrow.Holder up2 = arrow5.Up;
					Transform transform5 = up2.Closed.transform;
					Vector3 position5 = transform5.position;
					Color tint5 = (Color)(obj4 - 32);
					Vector3 center4 = (Vector3)(obj4 - 64);
					_ = position5.x;
					_ = position5.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					_ = 0;
					Gizmos.DrawIcon(center4, "Doozy/UI/UIDrawer/ArrowDown", allowScaling: true, tint5);
					UIDrawerArrow arrow6 = Arrow;
					UIDrawerArrow.Holder up3 = arrow6.Up;
					Transform transform6 = up3.Opened.transform;
					Vector3 position6 = transform6.position;
					tint3 = (Color)(obj4 - 32);
					_ = position6.x;
					_ = position6.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					_ = 0;
					allowScaling = true;
					text = "Doozy/UI/UIDrawer/ArrowUp";
				}
			}
			else
			{
				UIDrawerArrow arrow7 = Arrow;
				UIDrawerArrow.Holder right = arrow7.Right;
				Transform transform7 = right.Root.transform;
				Vector3 position7 = transform7.position;
				Color tint6 = (Color)(obj4 - 32);
				Vector3 center5 = (Vector3)(obj4 - 64);
				_ = position7.x;
				_ = position7.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				_ = 0;
				Gizmos.DrawIcon(center5, "Doozy/UI/UIDrawer/ArrowRoot", allowScaling: true, tint6);
				UIDrawerArrow arrow8 = Arrow;
				UIDrawerArrow.Holder right2 = arrow8.Right;
				Transform transform8 = right2.Closed.transform;
				Vector3 position8 = transform8.position;
				Color tint7 = (Color)(obj4 - 32);
				Vector3 center6 = (Vector3)(obj4 - 64);
				_ = position8.x;
				_ = position8.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				_ = 0;
				Gizmos.DrawIcon(center6, "Doozy/UI/UIDrawer/ArrowLeft", allowScaling: true, tint7);
				UIDrawerArrow arrow9 = Arrow;
				UIDrawerArrow.Holder right3 = arrow9.Right;
				Transform transform9 = right3.Opened.transform;
				Vector3 position9 = transform9.position;
				tint3 = (Color)(obj4 - 32);
				_ = position9.x;
				_ = position9.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				_ = 0;
				allowScaling = true;
				text = "Doozy/UI/UIDrawer/ArrowRight";
			}
		}
		else
		{
			UIDrawerArrow arrow10 = Arrow;
			UIDrawerArrow.Holder left = arrow10.Left;
			Transform transform10 = left.Root.transform;
			Vector3 position10 = transform10.position;
			Color tint8 = (Color)(obj4 - 32);
			Vector3 center7 = (Vector3)(obj4 - 64);
			_ = position10.x;
			_ = position10.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			Gizmos.DrawIcon(center7, "Doozy/UI/UIDrawer/ArrowRoot", allowScaling: true, tint8);
			UIDrawerArrow arrow11 = Arrow;
			UIDrawerArrow.Holder left2 = arrow11.Left;
			Transform transform11 = left2.Closed.transform;
			Vector3 position11 = transform11.position;
			Color tint9 = (Color)(obj4 - 32);
			Vector3 center8 = (Vector3)(obj4 - 64);
			_ = position11.x;
			_ = position11.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			Gizmos.DrawIcon(center8, "Doozy/UI/UIDrawer/ArrowRight", allowScaling: true, tint9);
			UIDrawerArrow arrow12 = Arrow;
			UIDrawerArrow.Holder left3 = arrow12.Left;
			Transform transform12 = left3.Opened.transform;
			Vector3 position12 = transform12.position;
			tint3 = (Color)(obj4 - 32);
			_ = position12.x;
			_ = position12.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			allowScaling = true;
			text = "Doozy/UI/UIDrawer/ArrowLeft";
		}
		Vector3 center9 = (Vector3)(obj4 - 64);
		Gizmos.DrawIcon(center9, text, allowScaling, tint3);
	}

	protected override void Reset()
	{
		UIDrawerSettings instance = UIDrawerSettings.Instance;
		CloseDirection = instance.CloseDirection;
		CloseSpeed = instance.CloseSpeed;
		CustomStartAnchoredPosition = instance.CustomStartAnchoredPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v3 (Doozy.Engine.UI.Settings.UIDrawerSettings)+2C]");
		_ = 0;
		BlockBackButton = instance.BlockBackButton;
		HideOnBackButton = instance.HideOnBackButton;
		DetectGestures = instance.DetectGestures;
		OpenSpeed = instance.OpenSpeed;
		UseCustomStartAnchoredPosition = instance.UseCustomStartAnchoredPosition;
		UIDrawerBehavior openBehavior = new UIDrawerBehavior(UIDrawerBehaviorType.Open);
		OpenBehavior = openBehavior;
		UIDrawerBehavior closeBehavior = new UIDrawerBehavior(UIDrawerBehaviorType.Close);
		CloseBehavior = closeBehavior;
		UIDrawerBehavior dragBehavior = new UIDrawerBehavior(UIDrawerBehaviorType.Drag);
		DragBehavior = dragBehavior;
		if (Container == null)
		{
			UIDrawerContainer uIDrawerContainer = (UIDrawerContainer)new UIContainer();
			uIDrawerContainer.Reset();
			Container = uIDrawerContainer;
		}
		if (Overlay == null)
		{
			UIContainer overlay = new UIContainer();
			Overlay = overlay;
		}
		if (Arrow == null)
		{
			UIDrawerArrow uIDrawerArrow = new UIDrawerArrow();
			uIDrawerArrow.Reset();
			Arrow = uIDrawerArrow;
		}
		UIDrawerArrow arrow = Arrow;
		RectTransform container = arrow.Container;
		if ((object)arrow.Container != null && ((UnityEngine.Object)container).m_CachedPtr != (IntPtr)0)
		{
			UIDrawerArrow arrow2 = Arrow;
			GameObject gameObject = arrow2.Container.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	public unsafe override void Awake()
	{
		//IL_0057: Expected F4, but got I
		//IL_0061: Expected F4, but got O
		//IL_00ae: Expected O, but got Ref
		//IL_023f: Expected I4, but got O
		//IL_0256: Expected I4, but got O
		base.Awake();
		Canvas canvas = Canvas;
		m_canvas = canvas;
		if (HasContainer)
		{
			if (UseCustomStartAnchoredPosition)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+90]");
				float num = 0f;
				float num2 = (float)CustomStartAnchoredPosition;
			}
			else
			{
				RectTransform rectTransform = base.RectTransform;
				Vector3 anchoredPosition3D = rectTransform.anchoredPosition3D;
				float num2 = anchoredPosition3D.x;
				float num = anchoredPosition3D.z;
			}
			RectTransform rectTransform2 = base.RectTransform;
			object obj = default(object);
			rectTransform2.anchoredPosition3D = (Vector3)(&obj);
			UIDrawerContainer container = Container;
			container.DisableGraphicRaycaster = container.DisableCanvas;
			Container.Init();
			Overlay.Init();
			UIDrawerContainer container2 = Container;
			if (!container2.DisableCanvas)
			{
				container2.Canvas.enabled = true;
			}
			UIDrawerContainer container3 = Container;
			if (!container3.DisableGraphicRaycaster)
			{
				container3.GraphicRaycaster.enabled = true;
			}
			UIDrawerContainer container4 = Container;
			float fixedSize = default(float);
			UpdateContainerSize(container4.Size, container4.PercentageOfScreen, container4.MinimumSize, fixedSize);
			InitContainerPositions();
			InitArrow();
			Close(instantAction: true);
			m_availableForDrag = true;
			_003CIsDragged_003Ek__BackingField = false;
			DoozySettings instance = DoozySettings.Instance;
			if (instance.UseOrientationDetector)
			{
				OrientationDetector instance2 = OrientationDetector.Instance;
				UnityAction<DetectedOrientation> unityAction = null;
				((UIDrawer)(object)unityAction).OnOrientationChanged((DetectedOrientation)this);
				((UIDrawer)(object)instance2.OnOrientationEvent).OnOrientationChanged((DetectedOrientation)unityAction);
			}
		}
		else
		{
			string message = "The '" + DrawerName + "' drawer does not have a container referenced. This is the main drawer component and should not be missing. Either reference it or delete this gameObject. For this session, this gameObject has been disabled. (HINT: You can create a new UIDrawer to see how the container should be referenced)";
			GameObject context = base.gameObject;
			DDebug.Log(message, context);
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	public override void OnEnable()
	{
		//IL_0064: Expected I4, but got O
		//IL_007b: Expected I4, but got O
		UIDrawerContainer container = Container;
		container.DisableGraphicRaycaster = container.DisableCanvas;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.UseOrientationDetector)
		{
			OrientationDetector instance2 = OrientationDetector.Instance;
			UnityAction<DetectedOrientation> unityAction = null;
			((UIDrawer)(object)unityAction).OnOrientationChanged((DetectedOrientation)this);
			((UIDrawer)(object)instance2.OnOrientationEvent).OnOrientationChanged((DetectedOrientation)unityAction);
		}
	}

	public override void OnDisable()
	{
		//IL_0056: Expected I4, but got O
		//IL_008e: Expected O, but got I
		//IL_008e: Expected O, but got I
		DoozySettings instance = DoozySettings.Instance;
		if (instance.UseOrientationDetector && !OrientationDetector._003CApplicationIsQuitting_003Ek__BackingField)
		{
			OrientationDetector instance2 = OrientationDetector.Instance;
			OrientationEvent onOrientationEvent = instance2.OnOrientationEvent;
			UnityAction<DetectedOrientation> unityAction = null;
			((UIDrawer)(object)unityAction).OnOrientationChanged((DetectedOrientation)this);
			MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rsi_v4 (Doozy.Engine.Orientation.OrientationEvent)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v9 (UnityEngine.Events.UnityAction`1<Doozy.Engine.Orientation.DetectedOrientation>)+20]");
			((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
		}
	}

	private unsafe void Update()
	{
		//IL_0398: Expected O, but got I
		//IL_03ef: Invalid comparison between F4 and O
		//IL_00e4: Expected O, but got F4
		//IL_0145: Expected O, but got Ref
		//IL_0291: Expected O, but got Ref
		if (m_visibility == VisibilityState.Showing || m_visibility == VisibilityState.Hiding)
		{
			UpdateShowProgress();
		}
		if (m_visibility == VisibilityState.NotVisible)
		{
			m_availableForDrag = true;
		}
		UpdateArrow();
		UIDrawerContainer container = Container;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 86 Invalid \"Jump target not found in method: 0x182BA4736\"");
		object obj = container.PreviousPosition - container.CurrentPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v4 (Doozy.Engine.UI.UIDrawerContainer)+A4]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v4 (Doozy.Engine.UI.UIDrawerContainer)+7C]");
		object obj2 = num - 0;
		object obj4 = default(object);
		object obj3 = obj4 - obj4;
		object obj5 = obj3 * obj3;
		object obj6 = obj * obj;
		object obj7 = obj2 * obj2;
		object obj8 = obj5 + obj6;
		object obj9 = obj8 + obj7;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
		{
			UpdateShowProgress();
		}
		UIDrawerContainer container2 = Container;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 142 Invalid \"Jump target not found in method: 0x182BA4736\"");
		container2.PreviousPosition = container2.CurrentPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v4 (Doozy.Engine.UI.UIDrawerContainer)+7C]");
		_ = 0;
		UIDrawerContainer container3 = Container;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 158 Invalid \"Jump target not found in method: 0x182BA4736\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 170 Invalid \"Jump target not found in method: 0x182BA4736\"");
		Vector3 anchoredPosition3D = container3.RectTransform.anchoredPosition3D;
		container3.CurrentPosition = (Vector3)anchoredPosition3D.x;
		_ = anchoredPosition3D.z;
		UpdateContainerAnimation();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 191 Invalid \"Jump target not found in method: 0x182BA3DFD\"");
		TouchDetector instance = TouchDetector.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 218 Invalid \"Jump target not found in method: 0x182BA4736\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 229 Invalid \"Jump target not found in method: 0x182BA3DFD\"");
		TouchDetector instance2 = TouchDetector.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 256 Invalid \"Jump target not found in method: 0x182BA4736\"");
		TouchInfo touchInfo = default(TouchInfo);
		object obj10 = (object)(&touchInfo);
		obj10 = instance2.m_currentTouchInfo;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+90]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+D0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+F0]");
		_ = 0;
		bool isDragging = touchInfo.IsDragging;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 294 Invalid \"Jump target not found in method: 0x182BA412B\"");
		EventSystem unityEventSystem = UIComponentBase<UIDrawer>.UnityEventSystem;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 321 Invalid \"Jump target not found in method: 0x182BA4736\"");
		if ((object)unityEventSystem.m_CurrentSelected != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 419 Invalid \"Jump target not found in method: 0x182BA3DFD\"");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 430 Invalid \"Jump target not found in method: 0x182BA3DFD\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 538 Invalid \"Jump target not found in method: 0x182BA3E1E\"");
		object obj11 = default(object);
		if (obj11 != null)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 597 Invalid \"Jump target not found in method: 0x182BA3E1E\"");
		bool anyDrawerOpened = AnyDrawerOpened;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 625 Invalid \"Jump target not found in method: 0x182BA3DFD\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 637 Invalid \"Jump target not found in method: 0x182BA3DFD\"");
		TouchDetector instance3 = TouchDetector.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 664 Invalid \"Jump target not found in method: 0x182BA4736\"");
		object obj13 = default(object);
		object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj13, 32));
		obj12 = instance3.m_currentTouchInfo;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+90]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+D0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v32 (Doozy.Engine.Touchy.TouchDetector)+F0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 702 Invalid \"Jump target not found in method: 0x182BA3B99\"");
	}

	public void OnDrag(PointerEventData eventData)
	{
		m_availableForDrag = true;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		m_availableForDrag = true;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		m_availableForDrag = false;
	}

	private unsafe void OnRectTransformDimensionsChange()
	{
		//IL_0035: Expected O, but got Ref
		//IL_0156: Expected O, but got Ref
		if (!HasContainer)
		{
			return;
		}
		RectTransform rectTransform = base.RectTransform;
		Vector3 vector = default(Vector3);
		rectTransform.anchoredPosition3D = (Vector3)(&vector);
		UIDrawerContainer container = Container;
		float fixedSize = default(float);
		UpdateContainerSize(container.Size, container.PercentageOfScreen, container.MinimumSize, fixedSize);
		InitContainerPositions();
		RectTransform rectTransform2;
		if (m_visibility != VisibilityState.Visible)
		{
			if (m_visibility != VisibilityState.NotVisible)
			{
				goto IL_0103;
			}
			UIDrawerContainer container2 = Container;
			rectTransform2 = container2.RectTransform;
		}
		else
		{
			UIDrawerContainer container3 = Container;
			rectTransform2 = container3.RectTransform;
		}
		rectTransform2.anchoredPosition3D = (Vector3)(&vector);
		goto IL_0103;
		IL_0103:
		UIDrawerArrow arrow = Arrow;
		UIDrawerContainer container4 = Container;
		RectTransformExtensions.Copy(arrow.Container, container4.RectTransform);
	}

	public void Close(bool instantAction = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806AB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (m_visibility == VisibilityState.NotVisible && !_003CIsDragged_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIDrawer)
			{
				goto IL_00cf;
			}
		}
		string text = "in zero seconds!";
		if (!instantAction)
		{
			text = "with animation.";
		}
		string message = "'" + DrawerName + "' - Closed " + text;
		GameObject context = base.gameObject;
		DDebug.Log(message, context);
		goto IL_00cf;
		IL_00cf:
		UIDrawer uIDrawer = this;
		if (!instantAction)
		{
			UIDrawerBehavior closeBehavior = CloseBehavior;
			m_visibility = VisibilityState.Hiding;
			GameObject source = base.gameObject;
			bool playAnimatorEvents = default(bool);
			bool sendGameEvents = default(bool);
			bool invokeUnityEvent = default(bool);
			bool invokeAction = default(bool);
			closeBehavior.OnStart.Invoke(source, playSound: true, playEffect: true, playAnimatorEvents, sendGameEvents, invokeUnityEvent, invokeAction);
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 176 Invalid \"Jump target not found in method: 0x182BA4AD0\"");
			UIDrawer uIDrawer2 = default(UIDrawer);
			uIDrawer = uIDrawer2;
		}
		uIDrawer.FinalizeClose();
	}

	public void DisableGestureDetection()
	{
		DetectGestures = false;
	}

	public void EnableGestureDetection()
	{
		DetectGestures = true;
	}

	public void NotifySystemOfTriggeredBehavior(UIDrawerBehaviorType behaviorType)
	{
		if (OnUIDrawerBehavior != null)
		{
			Action<UIDrawer, UIDrawerBehaviorType> onUIDrawerBehavior = OnUIDrawerBehavior;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v80 @ r10_v2 (System.Action`2<Doozy.Engine.UI.UIDrawer, Doozy.Engine.UI.UIDrawerBehaviorType>)+18] (should have been resolved before IL gen)");
		}
		UIDrawerMessage uIDrawerMessage = null;
		uIDrawerMessage.Drawer = this;
		uIDrawerMessage.Type = behaviorType;
		Message.Send(uIDrawerMessage);
	}

	public void Open(bool instantAction = false)
	{
		//IL_03a1: Expected I, but got O
		//IL_0076: Expected O, but got I4
		//IL_00ca: Expected I4, but got O
		//IL_00f1: Expected I4, but got O
		//IL_012f: Expected I, but got O
		//IL_0266: Expected O, but got I4
		//IL_0299: Expected O, but got I4
		//IL_02be: Expected O, but got I4
		if (m_visibility == VisibilityState.Visible && !_003CIsDragged_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+20]");
		UnityEngine.Object obj;
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			bool flag = !instance.DebugUIDrawer;
			obj = (UnityEngine.Object)instantAction;
			if (flag)
			{
				goto IL_00ae;
			}
		}
		string text = "in zero seconds!";
		if (!instantAction)
		{
			text = "with animation.";
		}
		string message = "'" + DrawerName + "' - Opened " + text;
		GameObject gameObject = base.gameObject;
		DDebug.Log(message, gameObject);
		obj = gameObject;
		nint num = unchecked((nint)null);
		goto IL_00ae;
		IL_00ae:
		bool anyDrawerOpened = AnyDrawerOpened;
		bool flag2 = !anyDrawerOpened;
		bool flag3 = (byte)(int)obj != 0;
		if (!flag2)
		{
			bool flag4 = m_visibility == VisibilityState.Visible;
			flag3 = (byte)(int)obj != 0;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
				UIDrawer uIDrawer = default(UIDrawer);
				uIDrawer.Close(instantAction: true);
				flag3 = true;
				num = unchecked((nint)null);
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB340");
		m_availableForDrag = false;
		Container.Enable();
		if (HasOverlay)
		{
			Overlay.Enable();
		}
		if (!instantAction)
		{
			UIDrawerBehavior openBehavior = OpenBehavior;
			m_visibility = VisibilityState.Showing;
			UIAction onStart = openBehavior.OnStart;
			GameObject source = base.gameObject;
			if (openBehavior.OnStart.HasSound)
			{
				SoundyController soundyController = SoundyManager.Play(onStart.SoundData);
			}
			Canvas canvas = openBehavior.OnStart.GetCanvas(source);
			openBehavior.OnStart.ExecuteEffect(canvas);
			openBehavior.OnStart.InvokeAnimatorEvents();
			bool flag5 = onStart.GameEvents == null;
			object obj2 = 0;
			if (!flag5)
			{
				List<string> gameEvents = onStart.GameEvents;
				bool flag6 = gameEvents._size <= 0;
				obj2 = 0;
				if (!flag6)
				{
					GameEventMessage.SendEvents(gameEvents, source);
					obj2 = 0;
				}
			}
			if (onStart.Event != null)
			{
				onStart.Event.Invoke();
			}
			if (onStart.Action != null)
			{
				Action<GameObject> action = onStart.Action;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v590 @ rax_v27 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			NotifySystemOfTriggeredBehavior(UIDrawerBehaviorType.Open);
		}
		else
		{
			FinalizeOpen();
		}
	}

	public void Toggle(bool instantAction = false)
	{
		//IL_002f: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		bool flag = m_visibility == VisibilityState.Visible;
		if (!flag)
		{
			object obj = m_visibility - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						goto IL_0079;
					}
					return;
				}
			}
			Open(instantAction);
			return;
		}
		goto IL_0079;
		IL_0079:
		Close(instantAction);
	}

	public void ToggleGestureDetection()
	{
		bool detectGestures = !DetectGestures;
		DetectGestures = detectGestures;
	}

	public void UpdateArrowContainer()
	{
		UIDrawerArrow arrow = Arrow;
		UIDrawerContainer container = Container;
		RectTransformExtensions.Copy(arrow.Container, container.RectTransform);
	}

	public unsafe void UpdateContainer()
	{
		//IL_0012: Expected O, but got Ref
		RectTransform rectTransform = base.RectTransform;
		object obj = default(object);
		rectTransform.anchoredPosition3D = (Vector3)(&obj);
		UIDrawerContainer container = Container;
		float fixedSize = default(float);
		UpdateContainerSize(container.Size, container.PercentageOfScreen, container.MinimumSize, fixedSize);
	}

	public void UpdateContainerSize()
	{
		UIDrawerContainer container = Container;
		float fixedSize = default(float);
		UpdateContainerSize(container.Size, container.PercentageOfScreen, container.MinimumSize, fixedSize);
	}

	public void UpdateContainerSize(float fixedSize)
	{
		UIDrawerContainer container = Container;
		float fixedSize2 = default(float);
		UpdateContainerSize(UIDrawerContainerSize.FixedSize, container.PercentageOfScreen, container.MinimumSize, fixedSize2);
	}

	public void UpdateContainerSize(float percentageOfScreen, float minimumSize)
	{
		float fixedSize = default(float);
		UpdateContainerSize(UIDrawerContainerSize.PercentageOfScreen, percentageOfScreen, minimumSize, fixedSize);
	}

	public void UpdateDrawerCloseDirection(SimpleSwipe hideDirection)
	{
		if (!AnyDrawerOpened)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
			UIDrawer uIDrawer = default(UIDrawer);
			uIDrawer.Close(instantAction: true);
		}
		Open(instantAction: true);
		CloseDirection = hideDirection;
		InitContainerPositions();
		InitArrow();
		Close(instantAction: true);
	}

	private void InitiateOpen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB340");
		m_availableForDrag = false;
		Container.Enable();
		if (HasOverlay)
		{
			Overlay.Enable();
		}
	}

	private unsafe void FinalizeOpen()
	{
		//IL_0021: Expected O, but got Ref
		//IL_0164: Expected O, but got I4
		//IL_0197: Expected O, but got I4
		//IL_01bc: Expected O, but got I4
		UIDrawerContainer container = Container;
		object obj = default(object);
		container.RectTransform.anchoredPosition3D = (Vector3)(&obj);
		m_visibility = VisibilityState.Visible;
		VisibilityProgress = 1f;
		bool hasOverlay = HasOverlay;
		bool flag = !hasOverlay;
		float num = 1f;
		if (!flag)
		{
			UIContainer overlay = Overlay;
			num = m_visibilityProgress;
			overlay.CanvasGroup.alpha = m_visibilityProgress;
		}
		UIDrawerBehavior openBehavior = OpenBehavior;
		UIAction onFinished = openBehavior.OnFinished;
		GameObject source = base.gameObject;
		if (openBehavior.OnFinished.HasSound)
		{
			SoundyController soundyController = SoundyManager.Play(onFinished.SoundData);
		}
		Canvas canvas = openBehavior.OnFinished.GetCanvas(source);
		openBehavior.OnFinished.ExecuteEffect(canvas);
		openBehavior.OnFinished.InvokeAnimatorEvents();
		bool flag2 = onFinished.GameEvents == null;
		object obj2 = 0;
		if (!flag2)
		{
			List<string> gameEvents = onFinished.GameEvents;
			bool flag3 = gameEvents._size <= 0;
			obj2 = 0;
			if (!flag3)
			{
				GameEventMessage.SendEvents(gameEvents, source);
				obj2 = 0;
			}
		}
		if (onFinished.Event != null)
		{
			onFinished.Event.Invoke();
		}
		if (onFinished.Action != null)
		{
			Action<GameObject> action = onFinished.Action;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v318 @ rax_v18 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
	}

	private void InitiateClose()
	{
	}

	private unsafe void FinalizeClose()
	{
		//IL_003b: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB340");
		UIDrawerContainer container = Container;
		m_availableForDrag = true;
		object obj = default(object);
		container.RectTransform.anchoredPosition3D = (Vector3)(&obj);
		m_visibility = VisibilityState.NotVisible;
		VisibilityProgress = 0f;
		Container.Disable();
		if (HasOverlay)
		{
			UIContainer overlay = Overlay;
			overlay.CanvasGroup.alpha = m_visibilityProgress;
			Overlay.Disable();
		}
		UIDrawerBehavior closeBehavior = CloseBehavior;
		GameObject source = base.gameObject;
		bool playAnimatorEvents = default(bool);
		bool sendGameEvents = default(bool);
		bool invokeUnityEvent = default(bool);
		bool invokeAction = default(bool);
		closeBehavior.OnFinished.Invoke(source, playSound: true, playEffect: true, playAnimatorEvents, sendGameEvents, invokeUnityEvent, invokeAction);
	}

	private unsafe void MoveToCustomStartPosition()
	{
		//IL_0012: Expected O, but got Ref
		RectTransform rectTransform = base.RectTransform;
		object obj = default(object);
		rectTransform.anchoredPosition3D = (Vector3)(&obj);
	}

	private unsafe void OnOrientationChanged(DetectedOrientation detectedOrientation)
	{
		//IL_0035: Expected O, but got Ref
		//IL_0156: Expected O, but got Ref
		if (!HasContainer)
		{
			return;
		}
		RectTransform rectTransform = base.RectTransform;
		Vector3 vector = default(Vector3);
		rectTransform.anchoredPosition3D = (Vector3)(&vector);
		UIDrawerContainer container = Container;
		float fixedSize = default(float);
		UpdateContainerSize(container.Size, container.PercentageOfScreen, container.MinimumSize, fixedSize);
		InitContainerPositions();
		RectTransform rectTransform2;
		if (m_visibility != VisibilityState.Visible)
		{
			if (m_visibility != VisibilityState.NotVisible)
			{
				goto IL_0103;
			}
			UIDrawerContainer container2 = Container;
			rectTransform2 = container2.RectTransform;
		}
		else
		{
			UIDrawerContainer container3 = Container;
			rectTransform2 = container3.RectTransform;
		}
		rectTransform2.anchoredPosition3D = (Vector3)(&vector);
		goto IL_0103;
		IL_0103:
		UIDrawerArrow arrow = Arrow;
		UIDrawerContainer container4 = Container;
		RectTransformExtensions.Copy(arrow.Container, container4.RectTransform);
	}

	private void InitContainerPositions()
	{
		//IL_0024: Expected O, but got I
		//IL_005c: Expected O, but got F4
		//IL_0099: Expected O, but got F4
		UIDrawerContainer container = Container;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+24]");
		container.OpenedPosition = (Vector3)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+2C]");
		_ = 0;
		UIDrawerContainer container2 = Container;
		Vector3 containerClosedPosition = GetContainerClosedPosition();
		container2.ClosedPosition = (Vector3)containerClosedPosition.x;
		_ = containerClosedPosition.z;
		UIDrawerContainer container3 = Container;
		Vector3 anchoredPosition3D = container3.RectTransform.anchoredPosition3D;
		container3.CurrentPosition = (Vector3)anchoredPosition3D.x;
		_ = anchoredPosition3D.z;
		UIDrawerContainer container4 = Container;
		container4.PreviousPosition = container4.CurrentPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v4 (Doozy.Engine.UI.UIDrawerContainer)+7C]");
		_ = 0;
	}

	private unsafe void UpdateContainerSize(UIDrawerContainerSize size, float percentageOfScreen, float minimumSize, float fixedSize)
	{
		//IL_001c: Expected I4, but got O
		//IL_00c6: Expected O, but got I
		//IL_00d5: Expected I4, but got O
		//IL_1312: Expected I, but got O
		//IL_0150: Invalid comparison between I4 and F4
		//IL_019b: Expected F4, but got I4
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected F4, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected F4, but got Unknown
		//IL_13f4: Expected O, but got I
		//IL_025d: Expected O, but got I
		//IL_0272: Expected O, but got I4
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_0e90: Expected O, but got F4
		//IL_0e9e: Invalid comparison between I4 and F4
		//IL_0eeb: Expected O, but got I4
		//IL_0e03: Invalid comparison between I4 and F4
		//IL_1611: Expected F4, but got O
		//IL_0e55: Expected F4, but got I4
		//IL_0b5e: Expected O, but got F4
		//IL_0b6c: Invalid comparison between I4 and F4
		//IL_15ff: Expected O, but got F4
		//IL_0e21: Invalid comparison between F4 and O
		//IL_0bb9: Expected O, but got I4
		//IL_0ad1: Invalid comparison between I4 and F4
		//IL_0f16: Expected O, but got F4
		//IL_1558: Expected F4, but got O
		//IL_0b23: Expected F4, but got I4
		//IL_07b9: Invalid comparison between I4 and F4
		//IL_1546: Expected O, but got F4
		//IL_0aef: Invalid comparison between F4 and O
		//IL_0812: Expected F4, but got I4
		//IL_071a: Invalid comparison between I4 and F4
		//IL_0f4c: Expected O, but got F4
		//IL_0f6b: Invalid comparison between F4 and O
		//IL_0be4: Expected O, but got F4
		//IL_07dd: Invalid comparison between F4 and I
		//IL_0770: Expected F4, but got I4
		//IL_1121: Expected O, but got Ref
		//IL_073e: Invalid comparison between F4 and I
		//IL_0402: Invalid comparison between I4 and F4
		//IL_0c1a: Expected O, but got F4
		//IL_0c39: Invalid comparison between F4 and O
		//IL_0804: Expected F4, but got I
		//IL_045b: Expected F4, but got I4
		//IL_0363: Invalid comparison between I4 and F4
		//IL_0426: Invalid comparison between F4 and I
		//IL_03b9: Expected F4, but got I4
		//IL_087e: Expected F4, but got I
		//IL_0893: Invalid comparison between F4 and I
		//IL_0387: Invalid comparison between F4 and I
		//IL_044d: Expected F4, but got I
		//IL_08b7: Expected F4, but got I
		//IL_04c7: Expected F4, but got I
		//IL_04dc: Invalid comparison between F4 and I
		//IL_0500: Expected F4, but got I
		//IL_1144->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_117f->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_139d->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_11a1->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_01eb->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_11dc->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_0239->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_11fe->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_1239->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_125b->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_1413->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1296->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_0d9c->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_12b8->IL12d4: Incompatible stack heights: 1 vs 0
		//IL_0a6a->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0e7e->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_06b3->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_15ed->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0b4c->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1105->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1635->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0fd9->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1534->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0799->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_02fc->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0f3a->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1014->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_157c->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0ca7->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_14c1->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1669->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_03e2->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1036->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0c08->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0ce2->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1501->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0910->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1126->IL1126: Incompatible stack heights: 2 vs 1
		//IL_143c->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_1071->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0d04->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_085c->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_094b->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_147c->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0559->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_10a0->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0d3f->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_096d->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_04a5->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0594->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_15c4->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0d6e->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_09a8->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_05b6->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_10cf->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_09ca->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_05f1->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0a05->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0613->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_0a34->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_064e->IL12d4: Incompatible stack heights: 2 vs 0
		//IL_067d->IL12d4: Incompatible stack heights: 2 vs 0
		UIDrawerContainer container = Container;
		Vector3 ret = default(Vector3);
		UIDrawerContainer container17;
		Vector2 calculatedSize;
		UIDrawerContainer container21;
		Vector2 calculatedSize4;
		Vector2 vector7 = default(Vector2);
		if (Container != null)
		{
			container.Size = size;
			UIDrawerContainerSize uIDrawerContainerSize = (UIDrawerContainerSize)Container;
			if (Container != null && Container != null && Container != null && Container != null)
			{
				RectTransform rectTransform = base.RectTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v17 (Doozy.Engine.UI.UIDrawerContainerSize)+30]");
				RectTransformExtensions.Copy((RectTransform)0, rectTransform);
				UIDrawerContainerSize uIDrawerContainerSize2 = (UIDrawerContainerSize)Container;
				if (Container != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rbx_v10 (Doozy.Engine.UI.UIDrawerContainerSize)+30]");
					UIDrawerContainerSize uIDrawerContainerSize3 = UIDrawerContainerSize.FullScreen;
					nint num = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1150 @ rax_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rbx_v11 (Doozy.Engine.UI.UIDrawerContainerSize)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rbx_v11 (Doozy.Engine.UI.UIDrawerContainerSize)+10]");
					Transform.set_localScale_Injected((IntPtr)0, ref ret);
					UIDrawerContainer container2 = Container;
					if (container2.Size != UIDrawerContainerSize.FullScreen)
					{
						float num3 = container2.PercentageOfScreen;
						if (!(0f > container2.PercentageOfScreen))
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
						container2.PercentageOfScreen = num3;
						UIDrawerContainer container3 = Container;
						if (Container != null)
						{
							float minimumSize2 = container3.MinimumSize;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							float minimumSize3 = minimumSize2 & 0;
							container3.MinimumSize = minimumSize3;
							UIDrawerContainer container4 = Container;
							if (Container != null)
							{
								float fixedSize2 = container4.FixedSize;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
								float fixedSize3 = fixedSize2 & 0;
								container4.FixedSize = fixedSize3;
								RectTransform rectTransform2 = base.RectTransform;
								if ((object)rectTransform2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v37 (UnityEngine.RectTransform)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v37 (UnityEngine.RectTransform)+10]");
									RectTransform.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
									UIDrawerContainer container5 = Container;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1151 @ rax_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
									m_scaledCanvas = (Vector2)0;
									bool flag3 = Container == null;
									if (!flag3)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1151 @ rax_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
										container5.CalculatedSize = (Vector2)0;
										object obj = CloseDirection - 1;
										if (!flag3)
										{
											object obj2 = obj - 1;
											if (!flag3)
											{
												object obj3 = obj2 - 1;
												if (!flag3)
												{
													if ((nint)obj3 != 1)
													{
														goto IL_10e1;
													}
													UIDrawerContainer container6 = Container;
													if (Container != null)
													{
														if (container6.Size != UIDrawerContainerSize.PercentageOfScreen)
														{
															if (container6.Size == UIDrawerContainerSize.FixedSize)
															{
																float fixedSize4 = container6.FixedSize;
																if (!(0f > container6.FixedSize))
																{
																	float num4 = fixedSize4;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																	if (num4 > 0f)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																		_ = 0;
																	}
																}
																else
																{
																	fixedSize4 = 0f;
																}
															}
															goto IL_1418;
														}
														UIDrawerContainer container7 = Container;
														if (Container != null)
														{
															float num5 = container7.MinimumSize;
															if (!(0f > container7.MinimumSize))
															{
																float num6 = num5;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																if (num6 > 0f)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																	num5 = 0f;
																}
															}
															else
															{
																num5 = 0f;
															}
															container6.MinimumSize = num5;
															UIDrawerContainer container8 = Container;
															if (Container != null)
															{
																float num7 = container8.PercentageOfScreen;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rcx_v87 (Doozy.Engine.UI.UIDrawerContainer)+64]");
																float num8 = num7 * 0f;
																UIDrawerContainer container9 = Container;
																if (Container != null)
																{
																	float num9 = container9.MinimumSize;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v45 (Doozy.Engine.UI.UIDrawerContainer)+64]");
																	float num10 = 0f;
																	float minimumSize4 = container9.MinimumSize;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v45 (Doozy.Engine.UI.UIDrawerContainer)+64]");
																	if (!(minimumSize4 > 0f))
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																		num9 = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v45 (Doozy.Engine.UI.UIDrawerContainer)+64]");
																		nint num11 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																		if (num11 <= 0)
																		{
																			goto IL_1418;
																		}
																	}
																	num10 = num9;
																	goto IL_1418;
																}
															}
														}
													}
												}
												else
												{
													UIDrawerContainer container10 = Container;
													if (Container != null)
													{
														if (container10.Size != UIDrawerContainerSize.PercentageOfScreen)
														{
															if (container10.Size == UIDrawerContainerSize.FixedSize)
															{
																float fixedSize5 = container10.FixedSize;
																if (!(0f > container10.FixedSize))
																{
																	float num12 = fixedSize5;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																	if (num12 > 0f)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																		_ = 0;
																	}
																}
																else
																{
																	fixedSize5 = 0f;
																}
															}
															goto IL_149d;
														}
														UIDrawerContainer container11 = Container;
														if (Container != null)
														{
															float num13 = container11.MinimumSize;
															if (!(0f > container11.MinimumSize))
															{
																float num14 = num13;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																if (num14 > 0f)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																	num13 = 0f;
																}
															}
															else
															{
																num13 = 0f;
															}
															container10.MinimumSize = num13;
															UIDrawerContainer container12 = Container;
															if (Container != null)
															{
																float num15 = container12.PercentageOfScreen;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rcx_v76 (Doozy.Engine.UI.UIDrawerContainer)+64]");
																float num16 = num15 * 0f;
																UIDrawerContainer container13 = Container;
																if (Container != null)
																{
																	float num17 = container13.MinimumSize;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdx_v40 (Doozy.Engine.UI.UIDrawerContainer)+64]");
																	float num18 = 0f;
																	float minimumSize5 = container13.MinimumSize;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdx_v40 (Doozy.Engine.UI.UIDrawerContainer)+64]");
																	if (!(minimumSize5 > 0f))
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																		num17 = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdx_v40 (Doozy.Engine.UI.UIDrawerContainer)+64]");
																		nint num19 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+104]");
																		if (num19 <= 0)
																		{
																			goto IL_149d;
																		}
																	}
																	num18 = num17;
																	goto IL_149d;
																}
															}
														}
													}
												}
											}
											else
											{
												UIDrawerContainer container14 = Container;
												if (Container != null)
												{
													if (container14.Size != UIDrawerContainerSize.PercentageOfScreen)
													{
														if (container14.Size == UIDrawerContainerSize.FixedSize)
														{
															float num20 = container14.FixedSize;
															if (!(0f > container14.FixedSize))
															{
																float num21 = num20;
																Vector2 scaledCanvas = m_scaledCanvas;
																if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num21) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref scaledCanvas))
																{
																	container14.CalculatedSize = m_scaledCanvas;
																	goto IL_1510;
																}
															}
															else
															{
																num20 = 0f;
															}
															container14.CalculatedSize = (Vector2)num20;
														}
														goto IL_1510;
													}
													UIDrawerContainer container15 = Container;
													if (Container != null)
													{
														Vector2 vector = (Vector2)container15.MinimumSize;
														if (!(0f > container15.MinimumSize))
														{
															Vector2 vector2 = vector;
															Vector2 scaledCanvas2 = m_scaledCanvas;
															if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref scaledCanvas2))
															{
																vector = m_scaledCanvas;
															}
														}
														else
														{
															vector = (Vector2)0;
														}
														container14.MinimumSize = (float)vector;
														UIDrawerContainer container16 = Container;
														if (Container != null)
														{
															float num22 = container16.PercentageOfScreen * (float)container16.CalculatedSize;
															container16.CalculatedSize = (Vector2)num22;
															container17 = Container;
															if (Container != null)
															{
																Vector2 vector3 = (Vector2)container17.MinimumSize;
																calculatedSize = container17.CalculatedSize;
																float minimumSize6 = container17.MinimumSize;
																Vector2 calculatedSize2 = container17.CalculatedSize;
																if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)minimumSize6) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref calculatedSize2))
																{
																	vector3 = m_scaledCanvas;
																	Vector2 calculatedSize3 = container17.CalculatedSize;
																	Vector2 scaledCanvas3 = m_scaledCanvas;
																	if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref calculatedSize3) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref scaledCanvas3))
																	{
																		goto IL_1581;
																	}
																}
																calculatedSize = vector3;
																goto IL_1581;
															}
														}
													}
												}
											}
										}
										else
										{
											UIDrawerContainer container18 = Container;
											if (Container != null)
											{
												if (container18.Size != UIDrawerContainerSize.PercentageOfScreen)
												{
													if (container18.Size == UIDrawerContainerSize.FixedSize)
													{
														float num23 = container18.FixedSize;
														if (!(0f > container18.FixedSize))
														{
															float num24 = num23;
															Vector2 scaledCanvas4 = m_scaledCanvas;
															if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num24) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref scaledCanvas4))
															{
																container18.CalculatedSize = m_scaledCanvas;
																goto IL_15c9;
															}
														}
														else
														{
															num23 = 0f;
														}
														container18.CalculatedSize = (Vector2)num23;
													}
													goto IL_15c9;
												}
												UIDrawerContainer container19 = Container;
												if (Container != null)
												{
													Vector2 vector4 = (Vector2)container19.MinimumSize;
													if (!(0f > container19.MinimumSize))
													{
														Vector2 vector5 = vector4;
														Vector2 scaledCanvas5 = m_scaledCanvas;
														if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector5) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref scaledCanvas5))
														{
															vector4 = m_scaledCanvas;
														}
													}
													else
													{
														vector4 = (Vector2)0;
													}
													container18.MinimumSize = (float)vector4;
													UIDrawerContainer container20 = Container;
													if (Container != null)
													{
														float num25 = container20.PercentageOfScreen * (float)container20.CalculatedSize;
														container20.CalculatedSize = (Vector2)num25;
														container21 = Container;
														if (Container != null)
														{
															Vector2 vector6 = (Vector2)container21.MinimumSize;
															calculatedSize4 = container21.CalculatedSize;
															float minimumSize7 = container21.MinimumSize;
															Vector2 calculatedSize5 = container21.CalculatedSize;
															if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)minimumSize7) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref calculatedSize5))
															{
																vector6 = m_scaledCanvas;
																Vector2 calculatedSize6 = container21.CalculatedSize;
																Vector2 scaledCanvas6 = m_scaledCanvas;
																if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref calculatedSize6) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref scaledCanvas6))
																{
																	goto IL_163a;
																}
															}
															calculatedSize4 = vector6;
															goto IL_163a;
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
					else if ((object)container2.RectTransform != null)
					{
						container2.RectTransform.anchorMin = vector7;
						UIDrawerContainer container22 = Container;
						if (Container != null && (object)container22.RectTransform != null)
						{
							container22.RectTransform.anchorMax = vector7;
							UIDrawerContainer container23 = Container;
							if (Container != null && (object)container23.RectTransform != null)
							{
								container23.RectTransform.pivot = vector7;
								UIDrawerContainer container24 = Container;
								if (Container != null && (object)container24.RectTransform != null)
								{
									container24.RectTransform.sizeDelta = vector7;
									UIDrawerContainer container25 = Container;
									if (Container != null && (object)container25.RectTransform != null)
									{
										container25.RectTransform.anchoredPosition = vector7;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_12d4;
		IL_1418:
		UIDrawerContainer container26 = Container;
		RectTransform rectTransform3;
		Vector2 sizeDelta;
		if (Container != null && (object)container26.RectTransform != null)
		{
			container26.RectTransform.anchorMin = vector7;
			UIDrawerContainer container27 = Container;
			if (Container != null && (object)container27.RectTransform != null)
			{
				container27.RectTransform.anchorMax = vector7;
				UIDrawerContainer container28 = Container;
				if (Container != null && (object)container28.RectTransform != null)
				{
					container28.RectTransform.pivot = vector7;
					UIDrawerContainer container29 = Container;
					if (Container != null)
					{
						rectTransform3 = container29.RectTransform;
						if ((object)container29.RectTransform != null)
						{
							sizeDelta = vector7;
							goto IL_148b;
						}
					}
				}
			}
		}
		goto IL_12d4;
		IL_148b:
		rectTransform3.sizeDelta = sizeDelta;
		goto IL_10e1;
		IL_10e1:
		UIDrawerContainer container30 = Container;
		if (Container != null && (object)container30.RectTransform != null)
		{
			container30.RectTransform.anchoredPosition3D = (Vector3)(&ret);
			return;
		}
		goto IL_12d4;
		IL_15c9:
		UIDrawerContainer container31 = Container;
		RectTransform rectTransform4;
		if (Container != null && (object)container31.RectTransform != null)
		{
			container31.RectTransform.anchorMin = vector7;
			UIDrawerContainer container32 = Container;
			if (Container != null && (object)container32.RectTransform != null)
			{
				container32.RectTransform.anchorMax = vector7;
				UIDrawerContainer container33 = Container;
				if (Container != null)
				{
					rectTransform4 = container33.RectTransform;
					if ((object)container33.RectTransform != null)
					{
						goto IL_1593;
					}
				}
			}
		}
		goto IL_12d4;
		IL_12d4:
		throw new NullReferenceException();
		IL_149d:
		UIDrawerContainer container34 = Container;
		if (Container != null && (object)container34.RectTransform != null)
		{
			container34.RectTransform.anchorMin = vector7;
			UIDrawerContainer container35 = Container;
			if (Container != null && (object)container35.RectTransform != null)
			{
				container35.RectTransform.anchorMax = vector7;
				UIDrawerContainer container36 = Container;
				if (Container != null && (object)container36.RectTransform != null)
				{
					container36.RectTransform.pivot = vector7;
					UIDrawerContainer container37 = Container;
					if (Container != null)
					{
						rectTransform3 = container37.RectTransform;
						if ((object)container37.RectTransform != null)
						{
							sizeDelta = vector7;
							goto IL_148b;
						}
					}
				}
			}
		}
		goto IL_12d4;
		IL_163a:
		container21.CalculatedSize = calculatedSize4;
		goto IL_15c9;
		IL_1581:
		container17.CalculatedSize = calculatedSize;
		goto IL_1510;
		IL_1510:
		UIDrawerContainer container38 = Container;
		if (Container != null && (object)container38.RectTransform != null)
		{
			container38.RectTransform.anchorMin = vector7;
			UIDrawerContainer container39 = Container;
			if (Container != null && (object)container39.RectTransform != null)
			{
				container39.RectTransform.anchorMax = vector7;
				UIDrawerContainer container40 = Container;
				if (Container != null)
				{
					rectTransform4 = container40.RectTransform;
					if ((object)container40.RectTransform != null)
					{
						goto IL_1593;
					}
				}
			}
		}
		goto IL_12d4;
		IL_1593:
		rectTransform4.pivot = vector7;
		UIDrawerContainer container41 = Container;
		if (Container != null)
		{
			rectTransform3 = container41.RectTransform;
			if ((object)container41.RectTransform != null)
			{
				sizeDelta = vector7;
				goto IL_148b;
			}
		}
		goto IL_12d4;
	}

	private unsafe Vector3 GetContainerClosedPosition()
	{
		//IL_026c: Expected I, but got O
		//IL_027c: Expected O, but got I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_02f2: Expected F4, but got I
		//IL_02ed: Expected native int or pointer, but got O
		//IL_0302: Expected F4, but got I
		//IL_030a: Expected native int or pointer, but got O
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_02d3: Expected native int or pointer, but got O
		//IL_0178: Expected F4, but got O
		//IL_0173: Expected native int or pointer, but got O
		//IL_019f: Expected F4, but got I
		//IL_01a7: Expected native int or pointer, but got O
		//IL_0104: Expected F4, but got O
		//IL_00ff: Expected native int or pointer, but got O
		//IL_012b: Expected F4, but got I
		//IL_0133: Expected native int or pointer, but got O
		//IL_0298: Expected I, but got O
		//IL_02b8: Expected F4, but got I
		//IL_02c6: Expected F4, but got O
		//IL_02c1: Expected native int or pointer, but got O
		//IL_0217->IL0235: Incompatible stack heights: 1 vs 0
		//IL_01d5->IL0235: Incompatible stack heights: 1 vs 0
		//IL_0161->IL0235: Incompatible stack heights: 1 vs 0
		//IL_00ed->IL0235: Incompatible stack heights: 1 vs 0
		UIDrawerContainer container = Container;
		Vector3 vector = default(Vector3);
		float z;
		if (Container != null)
		{
			UIDrawerContainer rectTransform = (UIDrawerContainer)(object)container.RectTransform;
			if ((object)container.RectTransform != null)
			{
				bool flag = (object)rectTransform.Canvas == null;
				bool flag2 = (nint)0 == 0;
				RectTransform.get_rect_Injected((IntPtr)rectTransform.Canvas, out Rect _);
				object obj = CloseDirection - 1;
				float x;
				object obj5 = default(object);
				if (!flag2)
				{
					object obj2 = obj - 1;
					if (!flag2)
					{
						object obj3 = obj2 - 1;
						object obj4 = default(object);
						if (!flag2)
						{
							if ((nint)obj3 == 1)
							{
								UIDrawerContainer container2 = Container;
								if (Container == null)
								{
									goto IL_0235;
								}
								((Vector3*)(nint)vector)->x = (float)container2.OpenedPosition;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v19 (Doozy.Engine.UI.UIDrawerContainer)+90]");
								float y = 0f - (float)obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v19 (Doozy.Engine.UI.UIDrawerContainer)+94]");
								z = 0f;
								((Vector3*)(nint)vector)->y = y;
							}
							else
							{
								nint num = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v23 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v24 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
								z = 0f;
								((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
							}
						}
						else
						{
							UIDrawerContainer container3 = Container;
							if (Container == null)
							{
								goto IL_0235;
							}
							((Vector3*)(nint)vector)->x = (float)container3.OpenedPosition;
							float num3 = (float)obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v16 (Doozy.Engine.UI.UIDrawerContainer)+90]");
							float y2 = num3 + 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v16 (Doozy.Engine.UI.UIDrawerContainer)+94]");
							z = 0f;
							((Vector3*)(nint)vector)->y = y2;
						}
						goto IL_02cb;
					}
					UIDrawerContainer container4 = Container;
					if (Container == null)
					{
						goto IL_0235;
					}
					x = (float)obj5 + (float)container4.OpenedPosition;
				}
				else
				{
					UIDrawerContainer container4 = Container;
					if (Container == null)
					{
						goto IL_0235;
					}
					x = (float)container4.OpenedPosition - (float)obj5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v7 (Doozy.Engine.UI.UIDrawerContainer)+90]");
				((Vector3*)(nint)vector)->y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v7 (Doozy.Engine.UI.UIDrawerContainer)+94]");
				z = 0f;
				((Vector3*)(nint)vector)->x = x;
				goto IL_02cb;
			}
		}
		goto IL_0235;
		IL_0235:
		throw new NullReferenceException();
		IL_02cb:
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	private unsafe void UpdateContainerAnimation()
	{
		//IL_00d9: Expected O, but got I
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_016b: Expected O, but got F4
		//IL_017d: Expected O, but got Ref
		//IL_01a6: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0119: Expected O, but got F4
		//IL_012b: Expected O, but got Ref
		//IL_0154: Expected O, but got I4
		if (m_visibility != VisibilityState.Showing)
		{
			if (m_visibility == VisibilityState.Hiding)
			{
				UIDrawerContainer container = Container;
				Vector3 anchoredPosition3D = container.RectTransform.anchoredPosition3D;
				object obj = (nint)0 ^ (nint)0;
				object obj2 = 0 & obj;
				bool flag = (nint)obj2 < 0;
				bool flag2 = (nint)0 < (nint)0;
				object obj3 = Time.unscaledDeltaTime;
				float num = default(float);
				container.RectTransform.anchoredPosition3D = (Vector3)(&num);
				UpdateShowProgress();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
				bool flag3 = flag2 == flag;
				object obj4 = !flag3;
				if (obj4 == null)
				{
					FinalizeClose();
				}
			}
		}
		else
		{
			UIDrawerContainer container2 = Container;
			Vector3 anchoredPosition3D2 = container2.RectTransform.anchoredPosition3D;
			object obj5 = (nint)0 ^ (nint)0;
			object obj6 = 0 & obj5;
			bool flag4 = (nint)obj6 < 0;
			bool flag5 = (nint)0 < (nint)0;
			object obj7 = Time.unscaledDeltaTime;
			Vector3 vector = default(Vector3);
			container2.RectTransform.anchoredPosition3D = (Vector3)(&vector);
			UpdateShowProgress();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [188A10738h]\"");
			bool flag6 = flag5 == flag4;
			object obj8 = !flag6;
			if (obj8 == null)
			{
				FinalizeOpen();
			}
		}
	}

	private void UpdateContainerVelocity()
	{
		//IL_0043: Expected O, but got I
		//IL_009a: Invalid comparison between F4 and O
		//IL_011a: Expected O, but got F4
		UIDrawerContainer container = Container;
		object obj = container.PreviousPosition - container.CurrentPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rcx_v1 (Doozy.Engine.UI.UIDrawerContainer)+A4]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rcx_v1 (Doozy.Engine.UI.UIDrawerContainer)+7C]");
		object obj2 = num - 0;
		object obj4 = default(object);
		object obj3 = obj4 - obj4;
		object obj5 = obj3 * obj3;
		object obj6 = obj * obj;
		object obj7 = obj2 * obj2;
		object obj8 = obj5 + obj6;
		object obj9 = obj8 + obj7;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
		{
			UpdateShowProgress();
		}
		UIDrawerContainer container2 = Container;
		container2.PreviousPosition = container2.CurrentPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v3 (Doozy.Engine.UI.UIDrawerContainer)+7C]");
		_ = 0;
		UIDrawerContainer container3 = Container;
		Vector3 anchoredPosition3D = container3.RectTransform.anchoredPosition3D;
		container3.CurrentPosition = (Vector3)anchoredPosition3D.x;
		_ = anchoredPosition3D.z;
	}

	private unsafe void UpdateContainerDraggedPosition()
	{
		//IL_05ba: Expected O, but got I4
		//IL_028e: Expected O, but got I4
		//IL_0061: Expected O, but got Ref
		//IL_0141: Expected O, but got Ref
		//IL_0215: Invalid comparison between O and F4
		//IL_01af: Invalid comparison between O and F4
		//IL_0377: Expected O, but got Ref
		//IL_0513: Expected O, but got Ref
		//IL_0442: Expected O, but got Ref
		//IL_0590: Expected O, but got I
		//IL_0277: Expected O, but got Ref
		//IL_05e4: Invalid comparison between F4 and O
		//IL_04df: Expected O, but got I
		object obj = CloseDirection - 1;
		object obj3 = default(object);
		float x2 = default(float);
		UIDrawerContainer container4;
		RectTransform rectTransform = default(RectTransform);
		if ((nint)obj <= 1)
		{
			if (m_visibility == VisibilityState.Visible || m_visibility == VisibilityState.NotVisible)
			{
				TouchDetector instance = TouchDetector.Instance;
				object obj2 = (object)(&obj3);
				obj2 = instance.m_currentTouchInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+80]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+90]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+A0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+B0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+C0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+D0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+E0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+F0]");
				_ = 0;
				float x = default(float);
				float num = ScaledPositionX(x);
				UIDrawerContainer container = Container;
				Vector3 anchoredPosition3D = container.RectTransform.anchoredPosition3D;
				UIDrawerContainer container2 = Container;
				container2.RectTransform.anchoredPosition3D = (Vector3)(&x2);
			}
			bool flag = CloseDirection == SimpleSwipe.Left;
			UIDrawerContainer container3 = Container;
			float x3;
			Vector3 vector;
			if (!flag)
			{
				Vector3 anchoredPosition3D2 = container3.RectTransform.anchoredPosition3D;
				x3 = anchoredPosition3D2.x;
				container4 = Container;
				if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref container4.OpenedPosition) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)anchoredPosition3D2.x))
				{
					goto IL_023b;
				}
				vector = container4.ClosedPosition;
			}
			else
			{
				Vector3 anchoredPosition3D3 = container3.RectTransform.anchoredPosition3D;
				x3 = anchoredPosition3D3.x;
				container4 = Container;
				if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref container4.ClosedPosition) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)anchoredPosition3D3.x))
				{
					goto IL_023b;
				}
				vector = container4.OpenedPosition;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x3) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector))
			{
				goto IL_023b;
			}
		}
		else
		{
			object obj4 = CloseDirection - 3;
			if ((nint)obj4 > 1)
			{
				return;
			}
			if (m_visibility != VisibilityState.Visible)
			{
				if (m_visibility != VisibilityState.NotVisible)
				{
					goto IL_0447;
				}
				UIDrawerContainer container5 = Container;
				rectTransform = container5.RectTransform;
				Vector3 anchoredPosition3D4 = container5.RectTransform.anchoredPosition3D;
			}
			else
			{
				UIDrawerContainer container6 = Container;
				rectTransform = container6.RectTransform;
				Vector3 anchoredPosition3D5 = container6.RectTransform.anchoredPosition3D;
			}
		}
		TouchDetector instance2 = TouchDetector.Instance;
		object obj5 = (object)(&obj3);
		obj5 = instance2.m_currentTouchInfo;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+90]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+D0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v10 (Doozy.Engine.Touchy.TouchDetector)+F0]");
		_ = 0;
		float y = default(float);
		float num2 = ScaledPositionY(y);
		UIDrawerContainer container7 = Container;
		Vector3 anchoredPosition3D6 = container7.RectTransform.anchoredPosition3D;
		rectTransform.anchoredPosition3D = (Vector3)(&x2);
		goto IL_0447;
		IL_023b:
		Vector3 anchoredPosition3D7 = container4.RectTransform.anchoredPosition3D;
		UIDrawerContainer container8 = Container;
		RectTransform rectTransform2 = container8.RectTransform;
		Vector3 anchoredPosition3D8 = (Vector3)(&x2);
		goto IL_05f8;
		IL_05f8:
		rectTransform2.anchoredPosition3D = anchoredPosition3D8;
		return;
		IL_04f9:
		UIDrawerContainer container9;
		Vector3 anchoredPosition3D9 = container9.RectTransform.anchoredPosition3D;
		anchoredPosition3D8 = (Vector3)(&x2);
		RectTransform rectTransform3;
		rectTransform2 = rectTransform3;
		goto IL_05f8;
		IL_0447:
		bool flag2 = CloseDirection == SimpleSwipe.Up;
		UIDrawerContainer container10 = Container;
		object obj6 = default(object);
		object obj7;
		object obj8;
		if (!flag2)
		{
			Vector3 anchoredPosition3D10 = container10.RectTransform.anchoredPosition3D;
			container9 = Container;
			rectTransform3 = container9.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v17 (Doozy.Engine.UI.UIDrawerContainer)+6C]");
			bool flag3 = 0 > (nint)obj6;
			x2 = anchoredPosition3D10.x;
			if (flag3)
			{
				goto IL_04f9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v17 (Doozy.Engine.UI.UIDrawerContainer)+90]");
			obj7 = 0;
			x2 = anchoredPosition3D10.x;
			obj8 = obj6;
		}
		else
		{
			Vector3 anchoredPosition3D11 = container10.RectTransform.anchoredPosition3D;
			container9 = Container;
			rectTransform3 = container9.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v17 (Doozy.Engine.UI.UIDrawerContainer)+90]");
			bool flag4 = 0 > (nint)obj6;
			x2 = anchoredPosition3D11.x;
			if (flag4)
			{
				goto IL_04f9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v17 (Doozy.Engine.UI.UIDrawerContainer)+6C]");
			obj7 = 0;
			x2 = anchoredPosition3D11.x;
			obj8 = obj6;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-128), the output could be wrong!");
			/*Error: End of method reached without returning.*/;
		}
		goto IL_04f9;
	}

	private void UpdateShowProgress()
	{
		//IL_0010: Expected O, but got I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_00c3: Expected O, but got I
		object obj = CloseDirection - 1;
		object obj2 = default(object);
		object obj5;
		float num3;
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				object obj4 = obj3 - 1;
				if (obj2 != null || (nint)obj4 == 1)
				{
					UIDrawerContainer container = Container;
					Vector3 anchoredPosition3D = container.RectTransform.anchoredPosition3D;
					UIDrawerContainer container2 = Container;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v6 (Doozy.Engine.UI.UIDrawerContainer)+90]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v6 (Doozy.Engine.UI.UIDrawerContainer)+6C]");
					obj5 = num - 0;
					float num2 = anchoredPosition3D.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v6 (Doozy.Engine.UI.UIDrawerContainer)+6C]");
					num3 = num2 - 0f;
					goto IL_014a;
				}
				return;
			}
		}
		UIDrawerContainer container3 = Container;
		Vector3 anchoredPosition3D2 = container3.RectTransform.anchoredPosition3D;
		UIDrawerContainer container4 = Container;
		obj5 = container4.OpenedPosition - container4.ClosedPosition;
		num3 = anchoredPosition3D2.x - (float)container4.ClosedPosition;
		goto IL_014a;
		IL_014a:
		float visibilityProgress = num3 / (float)obj5;
		VisibilityProgress = visibilityProgress;
	}

	private void InitArrow()
	{
		if (Arrow != null)
		{
			UIDrawerArrow arrow = Arrow;
			if (arrow.Enabled)
			{
				UIDrawerContainer container = Container;
				RectTransformExtensions.Copy(arrow.Container, container.RectTransform);
				UIDrawerArrow arrow2 = Arrow;
				GameObject gameObject = arrow2.Animator.gameObject;
				gameObject.SetActive(value: true);
				UIDrawerArrow arrow3 = Arrow;
				UIDrawerArrowAnimator animator = arrow3.Animator;
				animator._003CDrawer_003Ek__BackingField = this;
				animator.RotateAndMoveArrowToMatchDrawerDirection(animator._003CDrawer_003Ek__BackingField);
			}
		}
	}

	private void UpdateArrow()
	{
		//IL_0405: Expected O, but got I4
		//IL_041f: Expected O, but got I4
		//IL_0494: Expected O, but got I4
		//IL_04ae: Expected O, but got I4
		UIDrawerArrow arrow = Arrow;
		if (!arrow.Enabled)
		{
			return;
		}
		UIDrawerContainer container = Container;
		RectTransformExtensions.Copy(arrow.Container, container.RectTransform);
		UIDrawerArrow arrow2 = Arrow;
		arrow2.Animator.UpdateArrowColor(this);
		UIDrawerArrow arrow3 = Arrow;
		arrow3.Animator.UpdateArrow();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB400");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v10+10]");
			if ((nint)0 != 0)
			{
				goto IL_0120;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rax_v89+10]");
			if ((nint)0 != 0)
			{
				goto IL_0120;
			}
		}
		UIDrawerArrow arrow4 = Arrow;
		arrow4.Animator.UpdateRotatorPosition(1f);
		return;
		IL_030c:
		UIDrawerArrow arrow5 = Arrow;
		goto IL_031b;
		IL_01fe:
		float num = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v59+FC]");
		float visibility = num - 0f;
		UIDrawerArrowAnimator animator;
		animator.UpdateRotatorPosition(visibility);
		return;
		IL_0120:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB400");
		object obj3 = default(object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v17+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB400");
				object obj4 = default(object);
				bool flag = obj4 == null;
				bool flag2 = (object)this == null;
				object obj5 = flag2 & flag;
				bool flag3 = obj5 == null;
				object obj6 = !flag3;
				if (obj6 != null)
				{
					goto IL_030c;
				}
				bool flag4;
				if (obj4 != null)
				{
					object obj7 = obj4 - (object)this;
					flag4 = obj7 == null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+10]");
					flag4 = (nint)0 == 0;
				}
				arrow5 = Arrow;
				if (!flag4)
				{
					animator = arrow5.Animator;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB400");
					goto IL_01fe;
				}
				goto IL_031b;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
		object obj8 = default(object);
		if (obj8 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rax_v28+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		bool flag6 = (object)this == null;
		object obj10 = flag6 & flag5;
		bool flag7 = obj10 == null;
		object obj11 = !flag7;
		if (obj11 != null)
		{
			goto IL_030c;
		}
		bool flag8;
		if (obj9 != null)
		{
			object obj12 = obj9 - (object)this;
			flag8 = obj12 == null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+10]");
			flag8 = (nint)0 == 0;
		}
		arrow5 = Arrow;
		if (!flag8)
		{
			animator = arrow5.Animator;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
			goto IL_01fe;
		}
		goto IL_031b;
		IL_031b:
		float visibility2 = 1f - m_visibilityProgress;
		arrow5.Animator.UpdateRotatorPosition(visibility2);
	}

	private void UpdateOverlayAlpha(float value)
	{
		if (HasOverlay)
		{
			UIContainer overlay = Overlay;
			overlay.CanvasGroup.alpha = value;
		}
	}

	private void UpdateContainerAlpha(float value)
	{
		if (HasContainer)
		{
			UIDrawerContainer container = Container;
			if (container.FadeOut)
			{
				container.CanvasGroup.alpha = value;
			}
		}
	}

	private void UpdateArrowActiveState()
	{
		UIDrawerArrow arrow = Arrow;
		GameObject gameObject = arrow.Container.gameObject;
		bool arrowEnabled = ArrowEnabled;
		gameObject.SetActive(arrowEnabled);
	}

	private unsafe float ScaledPositionX(float x)
	{
		//IL_0099->IL0019: Incompatible stack heights: 1 vs 0
		Canvas canvas = Canvas;
		if ((object)canvas != null)
		{
			bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
			float ret;
			Canvas.get_pixelRect_Injected(((UnityEngine.Object)canvas).m_CachedPtr, out *(Rect*)(&ret));
			RectTransform rectTransform = base.RectTransform;
			if ((object)rectTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
				float ret2;
				RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Rect*)(&ret2));
				object obj = default(object);
				float num = x / (float)obj;
				object obj2 = default(object);
				return num * (float)obj2;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe float ScaledPositionY(float y)
	{
		//IL_0099->IL0019: Incompatible stack heights: 1 vs 0
		Canvas canvas = Canvas;
		if ((object)canvas != null)
		{
			bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
			float ret;
			Canvas.get_pixelRect_Injected(((UnityEngine.Object)canvas).m_CachedPtr, out *(Rect*)(&ret));
			RectTransform rectTransform = base.RectTransform;
			if ((object)rectTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
				float ret2;
				RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Rect*)(&ret2));
				object obj = default(object);
				float num = y / (float)obj;
				object obj2 = default(object);
				return num * (float)obj2;
			}
		}
		throw new NullReferenceException();
	}

	private Vector2 ScaledTouchPosition(Vector2 touchPosition)
	{
		//IL_000a: Expected F4, but got O
		float num = ScaledPositionX((float)touchPosition);
		float y = default(float);
		float num2 = ScaledPositionY(y);
		Vector2 result = default(Vector2);
		return result;
	}

	private void DebugOpenProgress()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806B8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIDrawer)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIDrawer)
			{
				return;
			}
		}
		string text = GetName();
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text2 = System.Number.FormatSingle(m_visibilityProgress, null, currentInfo);
		string message = "[" + text + "] OpenProgress: " + text2;
		DDebug.Log(message, this);
	}

	public static void Close(string drawerName, bool debug = false)
	{
		UIDrawer uIDrawer = Get(drawerName);
		if ((object)uIDrawer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (Doozy.Engine.UI.UIDrawer)+10]");
			if ((nint)0 != 0)
			{
				if (AnyDrawerOpened)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
					object obj = default(object);
					bool flag;
					if (obj != null)
					{
						object obj2 = obj - (object)uIDrawer;
						flag = obj2 == null;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (Doozy.Engine.UI.UIDrawer)+10]");
						flag = (nint)0 == 0;
					}
					if (flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB340");
					}
				}
				uIDrawer.Close();
				return;
			}
		}
		if (debug)
		{
			string message = "Unable to close the '" + drawerName + "' drawer because no such UIDrawer was found in the Database.";
			DDebug.LogError(message);
		}
	}

	public unsafe static bool Contains(string drawerName)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<UIDrawer>.Enumerator enumerator = default(List<UIDrawer>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<UIDrawer>.Enumerator enumerator2 = (List<UIDrawer>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public unsafe static UIDrawer Get(string drawerName)
	{
		//IL_0017: Expected O, but got Ref
		List<UIDrawer>.Enumerator enumerator = default(List<UIDrawer>.Enumerator);
		if (enumerator.MoveNext())
		{
			UIDrawer uIDrawer = null;
			List<UIDrawer>.Enumerator enumerator2 = (List<UIDrawer>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public static void Open(string drawerName, bool debug = false)
	{
		UIDrawer uIDrawer = Get(drawerName);
		if ((object)uIDrawer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (Doozy.Engine.UI.UIDrawer)+10]");
			if ((nint)0 != 0)
			{
				if (AnyDrawerOpened)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
					object obj = default(object);
					bool flag;
					if (obj != null)
					{
						object obj2 = obj - (object)uIDrawer;
						flag = obj2 == null;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (Doozy.Engine.UI.UIDrawer)+10]");
						flag = (nint)0 == 0;
					}
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BBB230");
						UIDrawer uIDrawer2 = default(UIDrawer);
						uIDrawer2.Close(instantAction: true);
					}
				}
				uIDrawer.Open();
				return;
			}
		}
		if (debug)
		{
			string message = "Unable to open the '" + drawerName + "' drawer because no such UIDrawer was found in the Database.";
			DDebug.LogError(message);
		}
	}

	public static void Toggle(string drawerName, bool debug = false)
	{
		//IL_0080: Expected O, but got I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		UIDrawer uIDrawer = Get(drawerName);
		if ((object)uIDrawer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (Doozy.Engine.UI.UIDrawer)+10]");
			if ((nint)0 != 0)
			{
				bool flag = uIDrawer.m_visibility == VisibilityState.Visible;
				if (!flag)
				{
					object obj = uIDrawer.m_visibility - 1;
					if (!flag)
					{
						object obj2 = obj - 1;
						if (!flag)
						{
							if ((nint)obj2 == 1)
							{
								goto IL_00ca;
							}
							return;
						}
					}
					uIDrawer.Open();
					return;
				}
				goto IL_00ca;
			}
		}
		if (debug)
		{
			string message = "Unable to toggle the '" + drawerName + "' drawer because no such UIDrawer was found in the Database.";
			DDebug.LogError(message);
		}
		return;
		IL_00ca:
		uIDrawer.Close();
	}

	public UIDrawer()
	{
		ProgressEvent onProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnProgressChanged = onProgressChanged;
		ProgressEvent onInverseProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnInverseProgressChanged = onInverseProgressChanged;
		UseCustomStartAnchoredPosition = true;
		m_visibilityProgress = 1f;
		base._002Ector();
	}

	static UIDrawer()
	{
		Action<UIDrawer, UIDrawerBehaviorType> onUIDrawerBehavior = delegate
		{
		};
		OnUIDrawerBehavior = onUIDrawerBehavior;
	}
}
