using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using Rewired.UI;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rewired.Integration.UnityUI;

public abstract class RewiredPointerInputModule : BaseInputModule
{
	protected class MouseState
	{
		private List<ButtonState> m_TrackedButtons;

		public bool AnyPressesThisFrame()
		{
			//IL_0149: Expected I4, but got O
			List<ButtonState> trackedButtons = m_TrackedButtons;
			bool flag = m_TrackedButtons == null;
			int num = 0;
			int num2 = 0;
			if (!flag)
			{
				while (true)
				{
					if (num2 < trackedButtons._size)
					{
						if (m_TrackedButtons == null)
						{
							break;
						}
						ButtonState buttonState = m_TrackedButtons.get_Item(num);
						if (buttonState == null)
						{
							break;
						}
						MouseButtonEventData eventData = buttonState.m_EventData;
						if (buttonState.m_EventData == null)
						{
							break;
						}
						if (eventData.buttonState != PointerEventData.FramePressState.Pressed && eventData.buttonState != PointerEventData.FramePressState.PressedAndReleased)
						{
							trackedButtons = m_TrackedButtons;
							if (m_TrackedButtons == null)
							{
								break;
							}
							num++;
							num2 = num;
							continue;
						}
						return true;
					}
					return false;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		public bool AnyReleasesThisFrame()
		{
			//IL_0149: Expected I4, but got O
			List<ButtonState> trackedButtons = m_TrackedButtons;
			bool flag = m_TrackedButtons == null;
			int num = 0;
			int num2 = 0;
			if (!flag)
			{
				while (true)
				{
					if (num2 < trackedButtons._size)
					{
						if (m_TrackedButtons == null)
						{
							break;
						}
						ButtonState buttonState = m_TrackedButtons.get_Item(num);
						if (buttonState == null)
						{
							break;
						}
						MouseButtonEventData eventData = buttonState.m_EventData;
						if (buttonState.m_EventData == null)
						{
							break;
						}
						if (eventData.buttonState != PointerEventData.FramePressState.Released && eventData.buttonState != PointerEventData.FramePressState.PressedAndReleased)
						{
							trackedButtons = m_TrackedButtons;
							if (m_TrackedButtons == null)
							{
								break;
							}
							num++;
							num2 = num;
							continue;
						}
						return true;
					}
					return false;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		public ButtonState GetButtonState(int button)
		{
			List<ButtonState> trackedButtons = m_TrackedButtons;
			int num = 0;
			int num2 = 0;
			int num3 = default(int);
			while (true)
			{
				ButtonState buttonState3;
				if (num2 < trackedButtons._size)
				{
					ButtonState buttonState = m_TrackedButtons.get_Item(num);
					trackedButtons = m_TrackedButtons;
					if (buttonState.m_Button != button)
					{
						num++;
						num2 = num;
						continue;
					}
					ButtonState buttonState2 = m_TrackedButtons.get_Item(num);
					bool flag = buttonState2 != null;
					buttonState3 = buttonState2;
					if (flag)
					{
						goto IL_01db;
					}
				}
				ButtonState buttonState4 = new ButtonState();
				buttonState4.m_Button = button;
				MouseButtonEventData eventData = new MouseButtonEventData();
				buttonState4.m_EventData = eventData;
				List<object> trackedButtons2 = (List<object>)(object)m_TrackedButtons;
				int version = trackedButtons2._version + 1;
				trackedButtons2._version = version;
				object[] items = trackedButtons2._items;
				if (trackedButtons2._size >= items.Length)
				{
					trackedButtons2.AddWithResize((object)buttonState4);
					goto IL_0209;
				}
				int size = trackedButtons2._size + 1;
				trackedButtons2._size = size;
				if (trackedButtons2._size >= items.Length)
				{
					break;
				}
				items[num3] = buttonState4;
				buttonState3 = buttonState4;
				goto IL_01db;
				IL_01db:
				buttonState4 = buttonState3;
				goto IL_0209;
				IL_0209:
				return buttonState4;
			}
			return (ButtonState)(object)new IndexOutOfRangeException();
		}

		public void SetButtonState(int button, PointerEventData.FramePressState stateForMouseButton, PlayerPointerEventData data)
		{
			ButtonState buttonState = GetButtonState(button);
			MouseButtonEventData eventData = buttonState.m_EventData;
			eventData.buttonState = stateForMouseButton;
			MouseButtonEventData eventData2 = buttonState.m_EventData;
			eventData2.buttonData = data;
		}

		public MouseState()
		{
			List<ButtonState> trackedButtons = new List<ButtonState>();
			m_TrackedButtons = trackedButtons;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}

	public class MouseButtonEventData
	{
		public PointerEventData.FramePressState buttonState;

		public PlayerPointerEventData buttonData;

		public bool PressedThisFrame()
		{
			//IL_0038: Expected O, but got I4
			if (buttonState == PointerEventData.FramePressState.Pressed)
			{
				return true;
			}
			object obj = buttonState - 2;
			return obj == null;
		}

		public bool ReleasedThisFrame()
		{
			//IL_0038: Expected O, but got I4
			if (buttonState == PointerEventData.FramePressState.Released)
			{
				return true;
			}
			object obj = buttonState - 2;
			return obj == null;
		}
	}

	protected class ButtonState
	{
		private int m_Button;

		private MouseButtonEventData m_EventData;

		public MouseButtonEventData eventData
		{
			get
			{
				return m_EventData;
			}
			set
			{
				m_EventData = value;
			}
		}

		public int button
		{
			get
			{
				return m_Button;
			}
			set
			{
				m_Button = value;
			}
		}
	}

	private sealed class UnityInputSource : IMouseInputSource, ITouchInputSource
	{
		private Vector2 m_MousePosition;

		private Vector2 m_MousePositionPrev;

		private int m_LastUpdatedFrame;

		int IMouseInputSource.playerId
		{
			get
			{
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				return 0;
			}
		}

		int ITouchInputSource.playerId
		{
			get
			{
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				return 0;
			}
		}

		bool IMouseInputSource.enabled
		{
			get
			{
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				return Input.mousePresent;
			}
		}

		bool IMouseInputSource.locked
		{
			get
			{
				//IL_0096: Expected O, but got I4
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				CursorLockMode lockState = Cursor.lockState;
				object obj = lockState - 1;
				return obj == null;
			}
		}

		int IMouseInputSource.buttonCount
		{
			get
			{
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				return 3;
			}
		}

		Vector2 IMouseInputSource.screenPosition
		{
			get
			{
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				Vector3 mousePosition2 = Input.mousePosition;
				Vector2 result = default(Vector2);
				return result;
			}
		}

		Vector2 IMouseInputSource.screenPositionDelta
		{
			get
			{
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				Vector2 result = default(Vector2);
				return result;
			}
		}

		Vector2 IMouseInputSource.wheelDelta
		{
			get
			{
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				return Input.mouseScrollDelta;
			}
		}

		bool ITouchInputSource.touchSupported
		{
			get
			{
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				return Input.touchSupported;
			}
		}

		int ITouchInputSource.touchCount
		{
			get
			{
				//IL_007a: Expected O, but got F4
				int frameCount = Time.frameCount;
				if (frameCount != m_LastUpdatedFrame)
				{
					int frameCount2 = Time.frameCount;
					m_LastUpdatedFrame = frameCount2;
					m_MousePositionPrev = m_MousePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
					_ = 0;
					Vector3 mousePosition = Input.mousePosition;
					_ = mousePosition.y;
					m_MousePosition = (Vector2)mousePosition.x;
				}
				return Input.touchCount;
			}
		}

		bool IMouseInputSource.GetButtonDown(int button)
		{
			//IL_007a: Expected O, but got F4
			int frameCount = Time.frameCount;
			if (frameCount != m_LastUpdatedFrame)
			{
				int frameCount2 = Time.frameCount;
				m_LastUpdatedFrame = frameCount2;
				m_MousePositionPrev = m_MousePosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
				_ = 0;
				Vector3 mousePosition = Input.mousePosition;
				_ = mousePosition.y;
				m_MousePosition = (Vector2)mousePosition.x;
			}
			return Input.GetMouseButtonDown(button);
		}

		bool IMouseInputSource.GetButtonUp(int button)
		{
			//IL_007a: Expected O, but got F4
			int frameCount = Time.frameCount;
			if (frameCount != m_LastUpdatedFrame)
			{
				int frameCount2 = Time.frameCount;
				m_LastUpdatedFrame = frameCount2;
				m_MousePositionPrev = m_MousePosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
				_ = 0;
				Vector3 mousePosition = Input.mousePosition;
				_ = mousePosition.y;
				m_MousePosition = (Vector2)mousePosition.x;
			}
			return Input.GetMouseButtonUp(button);
		}

		bool IMouseInputSource.GetButton(int button)
		{
			//IL_007a: Expected O, but got F4
			int frameCount = Time.frameCount;
			if (frameCount != m_LastUpdatedFrame)
			{
				int frameCount2 = Time.frameCount;
				m_LastUpdatedFrame = frameCount2;
				m_MousePositionPrev = m_MousePosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
				_ = 0;
				Vector3 mousePosition = Input.mousePosition;
				_ = mousePosition.y;
				m_MousePosition = (Vector2)mousePosition.x;
			}
			return Input.GetMouseButton(button);
		}

		unsafe Touch ITouchInputSource.GetTouch(int index)
		{
			//IL_0099: Expected native int or pointer, but got O
			//IL_00b8: Expected native int or pointer, but got O
			//IL_00ca: Expected native int or pointer, but got O
			//IL_00dc: Expected native int or pointer, but got O
			//IL_007a: Expected O, but got F4
			int frameCount = Time.frameCount;
			if (frameCount != m_LastUpdatedFrame)
			{
				int frameCount2 = Time.frameCount;
				m_LastUpdatedFrame = frameCount2;
				m_MousePositionPrev = m_MousePosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
				_ = 0;
				Vector3 mousePosition = Input.mousePosition;
				_ = mousePosition.y;
				m_MousePosition = (Vector2)mousePosition.x;
			}
			Touch touch = Input.GetTouch(index);
			Touch touch2 = default(Touch);
			((Touch*)(nint)touch2)->m_FingerId = touch.m_FingerId;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v3 (UnityEngine.Touch)+10]");
			_ = 0;
			((Touch*)(nint)touch2)->m_TapCount = touch.m_TapCount;
			((Touch*)(nint)touch2)->m_maximumPossiblePressure = touch.m_maximumPossiblePressure;
			((Touch*)(nint)touch2)->m_AzimuthAngle = touch.m_AzimuthAngle;
			return touch2;
		}

		private void TryUpdate()
		{
			//IL_007a: Expected O, but got F4
			int frameCount = Time.frameCount;
			if (frameCount != m_LastUpdatedFrame)
			{
				int frameCount2 = Time.frameCount;
				m_LastUpdatedFrame = frameCount2;
				m_MousePositionPrev = m_MousePosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredPointerInputModule+UnityInputSource)+14]");
				_ = 0;
				Vector3 mousePosition = Input.mousePosition;
				_ = mousePosition.y;
				m_MousePosition = (Vector2)mousePosition.x;
			}
		}

		public UnityInputSource()
		{
			//IL_000f: Expected I4, but got I8
			m_LastUpdatedFrame = -1;
			base._002Ector();
		}
	}

	public const int kMouseLeftId = -1;

	public const int kMouseRightId = -2;

	public const int kMouseMiddleId = -3;

	public const int kFakeTouchesId = -4;

	private const int customButtonsStartingId = -2147483520;

	private const int customButtonsMaxCount = 128;

	private const int customButtonsLastId = -2147483392;

	private readonly List<IMouseInputSource> m_MouseInputSourcesList;

	private Dictionary<int, Dictionary<int, PlayerPointerEventData>[]> m_PlayerPointerData;

	private ITouchInputSource m_UserDefaultTouchInputSource;

	private UnityInputSource __m_DefaultInputSource;

	private readonly MouseState m_MouseState;

	private UnityInputSource defaultInputSource
	{
		get
		{
			//IL_0027: Expected I4, but got I8
			if (__m_DefaultInputSource != null)
			{
				return __m_DefaultInputSource;
			}
			UnityInputSource unityInputSource = new UnityInputSource();
			unityInputSource.m_LastUpdatedFrame = -1;
			__m_DefaultInputSource = unityInputSource;
			return unityInputSource;
		}
	}

	private IMouseInputSource defaultMouseInputSource => defaultInputSource;

	protected ITouchInputSource defaultTouchInputSource => defaultInputSource;

	protected virtual bool isMouseSupported
	{
		get
		{
			//IL_014d: Expected I4, but got O
			List<IMouseInputSource> mouseInputSourcesList = m_MouseInputSourcesList;
			if (m_MouseInputSourcesList != null)
			{
				if (mouseInputSourcesList._size != 0)
				{
					bool flag = mouseInputSourcesList._size <= 0;
					int num = 0;
					if (flag)
					{
						goto IL_00fd;
					}
					object obj = default(object);
					while (m_MouseInputSourcesList != null)
					{
						IMouseInputSource mouseInputSource = m_MouseInputSourcesList.get_Item(num);
						if (mouseInputSource == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						if (obj == null)
						{
							num++;
							if (num < mouseInputSourcesList._size)
							{
								continue;
							}
							goto IL_00fd;
						}
						return true;
					}
				}
				else
				{
					UnityInputSource unityInputSource = defaultInputSource;
					if (unityInputSource != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						bool result = default(bool);
						return result;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_00fd:
			return false;
		}
	}

	protected bool IsDefaultMouse(IMouseInputSource mouse)
	{
		UnityInputSource unityInputSource = defaultInputSource;
		object obj = (object)unityInputSource - (object)mouse;
		return obj == null;
	}

	public IMouseInputSource GetMouseInputSource(int playerId, int mouseIndex)
	{
		//IL_00e8: Expected O, but got I4
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		IMouseInputSource mouseInputSource;
		if (mouseIndex >= 0)
		{
			List<IMouseInputSource> mouseInputSourcesList = m_MouseInputSourcesList;
			if (m_MouseInputSourcesList != null)
			{
				if (mouseInputSourcesList._size == 0 && IsDefaultPlayer(playerId))
				{
					UnityInputSource unityInputSource = defaultInputSource;
					mouseInputSource = unityInputSource;
					goto IL_0091;
				}
				List<IMouseInputSource> mouseInputSourcesList2 = m_MouseInputSourcesList;
				if (m_MouseInputSourcesList != null)
				{
					bool flag = mouseInputSourcesList2._size <= 0;
					int num = 0;
					object obj = 0;
					if (flag)
					{
						goto IL_019e;
					}
					object obj2 = default(object);
					while (m_MouseInputSourcesList != null)
					{
						mouseInputSource = m_MouseInputSourcesList.get_Item(num);
						if (!UnityTools.IsNullOrDestroyed(mouseInputSource))
						{
							if (mouseInputSource == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							if ((nint)obj2 == playerId)
							{
								if (mouseIndex == (nint)obj)
								{
									goto IL_0091;
								}
								obj++;
							}
						}
						num++;
						if (num < mouseInputSourcesList2._size)
						{
							continue;
						}
						goto IL_019e;
					}
				}
			}
			return (IMouseInputSource)new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("mouseIndex");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
		IL_0091:
		return mouseInputSource;
		IL_019e:
		mouseInputSource = null;
		goto IL_0091;
	}

	public void RemoveMouseInputSource(IMouseInputSource source)
	{
		if (source != null)
		{
			bool flag = ((List<object>)(object)m_MouseInputSourcesList).Remove((object)source);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentNullException ex = new ArgumentNullException("source");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	public void AddMouseInputSource(IMouseInputSource source)
	{
		if (!UnityTools.IsNullOrDestroyed(source))
		{
			List<object> mouseInputSourcesList = (List<object>)(object)m_MouseInputSourcesList;
			int version = mouseInputSourcesList._version + 1;
			mouseInputSourcesList._version = version;
			object[] items = mouseInputSourcesList._items;
			if (mouseInputSourcesList._size >= items.Length)
			{
				mouseInputSourcesList.AddWithResize((object)source);
				return;
			}
			int size = mouseInputSourcesList._size + 1;
			mouseInputSourcesList._size = size;
			int num = default(int);
			items[num] = source;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentNullException ex = new ArgumentNullException("source");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	public int GetMouseInputSourceCount(int playerId)
	{
		//IL_018e: Expected I4, but got O
		List<IMouseInputSource> mouseInputSourcesList = m_MouseInputSourcesList;
		int result;
		if (m_MouseInputSourcesList != null)
		{
			if (mouseInputSourcesList._size == 0 && IsDefaultPlayer(playerId))
			{
				return 1;
			}
			List<IMouseInputSource> mouseInputSourcesList2 = m_MouseInputSourcesList;
			if (m_MouseInputSourcesList != null)
			{
				bool flag = mouseInputSourcesList2._size <= 0;
				int num = 0;
				int num2 = 0;
				result = 0;
				if (flag)
				{
					goto IL_0173;
				}
				object obj = default(object);
				while (m_MouseInputSourcesList != null)
				{
					IMouseInputSource mouseInputSource = m_MouseInputSourcesList.get_Item(num);
					if (!UnityTools.IsNullOrDestroyed(mouseInputSource))
					{
						if (mouseInputSource == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						if ((nint)obj == playerId)
						{
							num2++;
						}
					}
					num++;
					bool flag2 = num < mouseInputSourcesList2._size;
					result = num2;
					if (flag2)
					{
						continue;
					}
					goto IL_0173;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_0173:
		return result;
	}

	public ITouchInputSource GetTouchInputSource(int playerId, int sourceIndex)
	{
		if (UnityTools.IsNullOrDestroyed(m_UserDefaultTouchInputSource))
		{
			return defaultInputSource;
		}
		return m_UserDefaultTouchInputSource;
	}

	public void RemoveTouchInputSource(ITouchInputSource source)
	{
		if (source != null)
		{
			if (m_UserDefaultTouchInputSource == source)
			{
				m_UserDefaultTouchInputSource = null;
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentNullException ex = new ArgumentNullException("source");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	public void AddTouchInputSource(ITouchInputSource source)
	{
		if (!UnityTools.IsNullOrDestroyed(source))
		{
			m_UserDefaultTouchInputSource = source;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentNullException ex = new ArgumentNullException("source");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	public int GetTouchInputSourceCount(int playerId)
	{
		bool flag = IsDefaultPlayer(playerId);
		bool flag2 = !flag;
		return (!flag2) ? 1 : 0;
	}

	protected void ClearMouseInputSources()
	{
		List<IMouseInputSource> mouseInputSourcesList = m_MouseInputSourcesList;
		int version = mouseInputSourcesList._version + 1;
		mouseInputSourcesList._version = version;
		mouseInputSourcesList._size = 0;
		if (mouseInputSourcesList._size > 0)
		{
			Array.Clear(mouseInputSourcesList._items, 0, mouseInputSourcesList._size);
		}
	}

	protected abstract bool IsDefaultPlayer(int playerId);

	protected unsafe bool GetPointerData(int playerId, int pointerIndex, int pointerTypeId, out PlayerPointerEventData data, bool create, PointerEventType pointerEventType)
	{
		//IL_0980: Expected I4, but got O
		//IL_02fb: Expected I, but got O
		//IL_0300: Expected I, but got O
		//IL_0265: Expected I4, but got O
		//IL_063c: Expected O, but got I
		//IL_0124: Expected I, but got O
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_01cc: Expected I, but got O
		//IL_06c5: Expected O, but got I
		//IL_0a88: Expected I4, but got I8
		//IL_04f5: Expected I, but got O
		//IL_01fb: Expected I, but got O
		//IL_058e: Expected I, but got O
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Expected O, but got Unknown
		//IL_0774: Expected I, but got O
		//IL_05c9: Expected I4, but got O
		//IL_0afb: Expected O, but got I
		//IL_03a3: Expected I, but got O
		//IL_03d4: Expected O, but got I
		//IL_03f3: Expected O, but got I
		//IL_043b: Expected O, but got I
		//IL_0885: Expected O, but got I4
		//IL_0743: Expected I, but got O
		bool flag = m_PlayerPointerData == null;
		nint num = playerId;
		int num3 = default(int);
		int num2 = num3;
		Dictionary<int, PlayerPointerEventData> playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)m_PlayerPointerData;
		Dictionary<int, PlayerPointerEventData>[] array = default(Dictionary<int, PlayerPointerEventData>[]);
		if (!flag)
		{
			bool flag2 = ((Dictionary<int, object>)(object)m_PlayerPointerData).TryGetValue(playerId, out object value);
			num = playerId;
			num2 = (int)(&value);
			if (flag2)
			{
				goto IL_026b;
			}
			nint num4 = num3 + 1;
			array = new Dictionary<int, PlayerPointerEventData>[num4];
			bool flag3 = array == null;
			object obj = array;
			Dictionary<int, PlayerPointerEventData> dictionary = null;
			Dictionary<int, PlayerPointerEventData> dictionary2 = null;
			num = num4;
			num2 = (int)(&value);
			playerPointerData = null;
			if (!flag3)
			{
				while ((nint)dictionary2 < array.Length)
				{
					Dictionary<int, PlayerPointerEventData> dictionary3 = new Dictionary<int, PlayerPointerEventData>();
					bool flag4 = obj == null;
					num = 0;
					num2 = (int)(&value);
					playerPointerData = dictionary3;
					if (!flag4)
					{
						if (dictionary3 != null)
						{
							nint num5 = (nint)obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rdx_v50 (Il2CppClass<System.Object>)+40]");
							bool flag5 = ((Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>)(object)dictionary3).TryGetValue(0, out *(Dictionary<int, PlayerPointerEventData>[]*)(&value));
							bool flag6 = !flag5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rdx_v50 (Il2CppClass<System.Object>)+40]");
							num = 0;
							num2 = (int)(&value);
							playerPointerData = dictionary3;
							if (flag6)
							{
								bool flag7 = ((Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>)(object)playerPointerData).TryGetValue((int)num, out *(Dictionary<int, PlayerPointerEventData>[]*)num2);
								throw flag7;
							}
						}
						Dictionary<int, PlayerPointerEventData> dictionary4 = dictionary;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v16 (System.Object)+18]");
						if ((nint)dictionary4 >= 0)
						{
							goto IL_0972;
						}
						dictionary = (Dictionary<int, PlayerPointerEventData>)(dictionary + 1);
						bool flag8 = array == null;
						num = (nint)dictionary3;
						num2 = (int)(&value);
						playerPointerData = dictionary;
						if (!flag8)
						{
							obj = array;
							num4 = (nint)dictionary3;
							dictionary2 = dictionary;
							continue;
						}
					}
					goto IL_08fb;
				}
				bool flag9 = m_PlayerPointerData == null;
				num = num4;
				num2 = (int)(&value);
				playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)m_PlayerPointerData;
				if (!flag9)
				{
					((Dictionary<int, object>)(object)m_PlayerPointerData).Add(playerId, obj);
					num = playerId;
					num2 = (int)obj;
					goto IL_026b;
				}
			}
		}
		goto IL_08fb;
		IL_026b:
		bool flag10 = array == null;
		playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)array;
		if (!flag10)
		{
			bool flag11 = num3 < array.Length;
			playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)array;
			if (flag11)
			{
				goto IL_0980;
			}
			num = num3 + 1;
			Dictionary<int, PlayerPointerEventData>[] array2 = new Dictionary<int, PlayerPointerEventData>[num];
			bool flag12 = array == null;
			playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)array;
			if (!flag12)
			{
				nint num6 = unchecked((nint)null);
				num = unchecked((nint)null);
				Dictionary<int, PlayerPointerEventData> dictionary5 = (Dictionary<int, PlayerPointerEventData>)(object)array;
				playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)array;
				while (true)
				{
					nint num7 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v55 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+18]");
					if (num7 >= 0)
					{
						break;
					}
					if (playerPointerData != null)
					{
						nint num8 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+18]");
						if (num8 >= 0)
						{
							goto IL_0972;
						}
						if (array2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+20+v71 @ rdi_v16 (Il2CppMethodInfo)*8]");
							if ((nint)0 != 0)
							{
								nint num9 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rdx_v42 (Il2CppClass<System.Object>)+40]");
								int key = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+20+v71 @ rdi_v16 (Il2CppMethodInfo)*8]");
								nint num10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rdx_v42 (Il2CppClass<System.Object>)+40]");
								bool flag13 = ((Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>)num10).TryGetValue(0, out *(Dictionary<int, PlayerPointerEventData>[]*)num2);
								bool flag14 = !flag13;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+20+v71 @ rdi_v16 (Il2CppMethodInfo)*8]");
								Dictionary<int, Dictionary<int, PlayerPointerEventData>[]> dictionary6 = (Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>)0;
								if (flag14)
								{
									bool flag15 = dictionary6.TryGetValue(key, out *(Dictionary<int, PlayerPointerEventData>[]*)num2);
									throw flag15;
								}
							}
							if (num6 >= array2.Length)
							{
								goto IL_0972;
							}
							nint num11 = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+20+v71 @ rdi_v16 (Il2CppMethodInfo)*8]");
							array2[num11] = (Dictionary<int, PlayerPointerEventData>)0;
							num6++;
							bool flag16 = array != null;
							num = num6;
							dictionary5 = (Dictionary<int, PlayerPointerEventData>)(object)array;
							playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)array;
							if (flag16)
							{
								continue;
							}
							num = num6;
							playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)array;
						}
					}
					goto IL_08fb;
				}
				Dictionary<int, PlayerPointerEventData> dictionary7 = new Dictionary<int, PlayerPointerEventData>();
				bool flag17 = array2 == null;
				num = 0;
				playerPointerData = dictionary7;
				if (!flag17)
				{
					if (dictionary7 != null)
					{
						nint num12 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ rdx_v37 (Il2CppClass<System.Object>)+40]");
						int key2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ rdx_v37 (Il2CppClass<System.Object>)+40]");
						bool flag18 = ((Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>)(object)dictionary7).TryGetValue(0, out *(Dictionary<int, PlayerPointerEventData>[]*)num2);
						bool flag19 = !flag18;
						Dictionary<int, Dictionary<int, PlayerPointerEventData>[]> dictionary8 = (Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>)(object)dictionary7;
						if (flag19)
						{
							bool flag20 = dictionary8.TryGetValue(key2, out *(Dictionary<int, PlayerPointerEventData>[]*)num2);
							throw flag20;
						}
					}
					if (num3 >= array2.Length)
					{
						goto IL_0972;
					}
					array2[num3] = dictionary7;
					bool flag21 = m_PlayerPointerData == null;
					num = (nint)dictionary7;
					playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)m_PlayerPointerData;
					if (!flag21)
					{
						((Dictionary<int, object>)(object)m_PlayerPointerData).set_Item(playerId, (object)array2);
						num = playerId;
						num2 = (int)array2;
						playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)array2;
						goto IL_0980;
					}
				}
			}
		}
		goto IL_08fb;
		IL_08fb:
		throw new NullReferenceException();
		IL_0788:
		return false;
		IL_0980:
		if (playerPointerData != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+18]");
			if ((nint)num3 >= (nint)0)
			{
				goto IL_0972;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+20+v117 @ r8_v18 (System.Int32)*8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+20+v117 @ r8_v18 (System.Int32)*8]");
				PointerEventType pointerEventType2 = default(PointerEventType);
				ref object reference = default(ref object);
				if (!((Dictionary<int, object>)0).TryGetValue(pointerTypeId, out reference))
				{
					object obj2 = default(object);
					if (obj2 != null)
					{
						PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)new PointerEventData(base.m_EventSystem);
						playerPointerEventData._003CbuttonIndex_003Ek__BackingField = -1;
						playerPointerEventData._003CplayerId_003Ek__BackingField = playerId;
						playerPointerEventData._003CinputSourceIndex_003Ek__BackingField = num3;
						((PointerEventData)playerPointerEventData)._003CpointerId_003Ek__BackingField = pointerTypeId;
						playerPointerEventData._003CsourceType_003Ek__BackingField = pointerEventType2;
						switch (pointerEventType2)
						{
						case PointerEventType.Touch:
						{
							ITouchInputSource touchInputSource = GetTouchInputSource(playerId, num3);
							playerPointerEventData._003CtouchSource_003Ek__BackingField = touchInputSource;
							break;
						}
						case PointerEventType.Mouse:
						{
							IMouseInputSource mouseInputSource = GetMouseInputSource(playerId, num3);
							playerPointerEventData._003CmouseSource_003Ek__BackingField = mouseInputSource;
							break;
						}
						}
						switch (pointerTypeId)
						{
						default:
						{
							object obj3 = pointerTypeId + 2147483520;
							if ((nint)obj3 <= 128)
							{
								int num13 = pointerTypeId + 2147483520;
								playerPointerEventData._003CbuttonIndex_003Ek__BackingField = num13;
							}
							break;
						}
						case -3:
							playerPointerEventData._003CbuttonIndex_003Ek__BackingField = 2;
							break;
						case -2:
							playerPointerEventData._003CbuttonIndex_003Ek__BackingField = 1;
							break;
						case -1:
							playerPointerEventData._003CbuttonIndex_003Ek__BackingField = 0;
							break;
						}
						reference = ref *(object*)playerPointerEventData;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+20+v117 @ r8_v18 (System.Int32)*8]");
						((Dictionary<int, object>)0).Add(pointerTypeId, reference);
						return true;
					}
					goto IL_0788;
				}
				object obj4 = reference;
				IMouseInputSource mouseInputSource2;
				if (pointerEventType2 == PointerEventType.Mouse)
				{
					mouseInputSource2 = GetMouseInputSource(playerId, num3);
					num = playerId;
					playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)this;
				}
				else
				{
					num = pointerTypeId;
					mouseInputSource2 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.Int32, Rewired.Integration.UnityUI.PlayerPointerEventData>)+20+v117 @ r8_v18 (System.Int32)*8]");
					playerPointerData = (Dictionary<int, PlayerPointerEventData>)0;
				}
				bool flag22 = reference == null;
				num2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
				if (!flag22)
				{
					playerPointerData = (Dictionary<int, PlayerPointerEventData>)(reference + 392);
					object obj5 = reference;
					if (pointerEventType2 == PointerEventType.Touch)
					{
						if (UnityTools.IsNullOrDestroyed(m_UserDefaultTouchInputSource))
						{
							UnityInputSource unityInputSource = defaultInputSource;
							num = unchecked((nint)null);
							playerPointerData = (Dictionary<int, PlayerPointerEventData>)(object)this;
						}
						else
						{
							UnityInputSource unityInputSource = (UnityInputSource)m_UserDefaultTouchInputSource;
							num = 0;
							playerPointerData = (Dictionary<int, PlayerPointerEventData>)m_UserDefaultTouchInputSource;
						}
					}
					else
					{
						num = (nint)mouseInputSource2;
						UnityInputSource unityInputSource = null;
					}
					bool flag23 = reference == null;
					num2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
					if (!flag23)
					{
						goto IL_0788;
					}
				}
			}
		}
		goto IL_08fb;
		IL_0972:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private PlayerPointerEventData CreatePointerEventData(int playerId, int pointerIndex, int pointerTypeId, PointerEventType pointerEventType)
	{
		//IL_016a: Expected I4, but got I8
		//IL_00d2: Expected O, but got I4
		PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)new PointerEventData(base.m_EventSystem);
		playerPointerEventData._003CbuttonIndex_003Ek__BackingField = -1;
		playerPointerEventData._003CplayerId_003Ek__BackingField = playerId;
		playerPointerEventData._003CinputSourceIndex_003Ek__BackingField = pointerIndex;
		((PointerEventData)playerPointerEventData)._003CpointerId_003Ek__BackingField = pointerTypeId;
		PointerEventType pointerEventType2 = default(PointerEventType);
		playerPointerEventData._003CsourceType_003Ek__BackingField = pointerEventType2;
		switch (pointerEventType2)
		{
		case PointerEventType.Touch:
		{
			ITouchInputSource touchInputSource = GetTouchInputSource(playerId, pointerIndex);
			playerPointerEventData._003CtouchSource_003Ek__BackingField = touchInputSource;
			break;
		}
		case PointerEventType.Mouse:
		{
			IMouseInputSource mouseInputSource = GetMouseInputSource(playerId, pointerIndex);
			playerPointerEventData._003CmouseSource_003Ek__BackingField = mouseInputSource;
			break;
		}
		}
		switch (pointerTypeId)
		{
		default:
		{
			object obj = pointerTypeId + 2147483520;
			if ((nint)obj <= 128)
			{
				int num = pointerTypeId + 2147483520;
				playerPointerEventData._003CbuttonIndex_003Ek__BackingField = num;
				return playerPointerEventData;
			}
			break;
		}
		case -3:
			playerPointerEventData._003CbuttonIndex_003Ek__BackingField = 2;
			return playerPointerEventData;
		case -2:
			playerPointerEventData._003CbuttonIndex_003Ek__BackingField = 1;
			return playerPointerEventData;
		case -1:
			playerPointerEventData._003CbuttonIndex_003Ek__BackingField = 0;
			break;
		}
		return playerPointerEventData;
	}

	protected void RemovePointerData(PlayerPointerEventData data)
	{
		//IL_0092: Expected O, but got I
		if (((Dictionary<int, object>)(object)m_PlayerPointerData).TryGetValue(data._003CplayerId_003Ek__BackingField, out object _))
		{
			int num = data._003CinputSourceIndex_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ stack_8_v3 (System.Object)+18]");
			if ((nint)num < (nint)0)
			{
				int num2 = data._003CinputSourceIndex_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ stack_8_v3 (System.Object)+20+v64 @ rax_v7 (System.Int32)*8]");
				bool flag = ((Dictionary<int, object>)0).Remove(((PointerEventData)data)._003CpointerId_003Ek__BackingField);
			}
		}
	}

	protected unsafe PlayerPointerEventData GetTouchPointerEventData(int playerId, int touchDeviceIndex, Touch input, out bool pressed, out bool released)
	{
		//IL_0378: Expected O, but got I4
		//IL_03b3: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_016e: Expected I, but got O
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_030c: Expected O, but got I
		int fingerId = ((Touch*)input)->fingerId;
		ref PlayerPointerEventData data = default(ref PlayerPointerEventData);
		bool create = default(bool);
		PointerEventType pointerEventType = default(PointerEventType);
		bool pointerData = GetPointerData(playerId, touchDeviceIndex, fingerId, out data, create, pointerEventType);
		PointerEventData pointerEventData = default(PointerEventData);
		if (pointerEventData != null)
		{
			pointerEventData.Reset();
			bool flag;
			if (pointerData)
			{
				flag = true;
			}
			else
			{
				TouchPhase phase = ((Touch*)input)->phase;
				bool flag2 = phase == TouchPhase.Began;
				flag = flag2;
			}
			object obj = flag;
			TouchPhase phase2 = ((Touch*)input)->phase;
			bool flag3 = phase2 == TouchPhase.Canceled;
			bool flag4 = true;
			if (!flag3)
			{
				TouchPhase phase3 = ((Touch*)input)->phase;
				object obj2 = phase3 - 3;
				bool flag5 = obj2 == null;
				flag4 = flag5;
			}
			object obj3 = flag4;
			if (pointerData)
			{
				Vector2 position = ((Touch*)input)->position;
				if (pointerEventData == null)
				{
					goto IL_0316;
				}
				pointerEventData._003Cposition_003Ek__BackingField = position;
			}
			if (obj == null)
			{
				Vector2 position2 = ((Touch*)input)->position;
				if (pointerEventData != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ stack_-98_v2 (UnityEngine.EventSystems.PointerEventData)+108]");
					object obj5 = default(object);
					object obj4 = obj5 - 0;
					Vector2 vector = position2 - pointerEventData._003Cposition_003Ek__BackingField;
					if (pointerEventData != null)
					{
						pointerEventData._003Cdelta_003Ek__BackingField = vector;
						goto IL_03cc;
					}
				}
			}
			else if (pointerEventData != null)
			{
				nint num = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v22 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v23 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				_ = 0;
				pointerEventData._003Cdelta_003Ek__BackingField = Vector2.zeroVector;
				goto IL_03cc;
			}
		}
		goto IL_0316;
		IL_0316:
		return (PlayerPointerEventData)(object)new NullReferenceException();
		IL_03cc:
		Vector2 position3 = ((Touch*)input)->position;
		if (pointerEventData != null)
		{
			pointerEventData._003Cposition_003Ek__BackingField = position3;
			if (pointerEventData != null)
			{
				pointerEventData._003Cbutton_003Ek__BackingField = PointerEventData.InputButton.Left;
				if ((object)base.m_EventSystem != null)
				{
					base.m_EventSystem.RaycastAll(pointerEventData, m_RaycastResultCache);
					RaycastResult raycastResult = BaseInputModule.FindFirstRaycast(m_RaycastResultCache);
					if (pointerEventData != null)
					{
						pointerEventData._003CpointerCurrentRaycast_003Ek__BackingField = (RaycastResult)raycastResult.m_GameObject;
						_ = raycastResult.distance;
						_ = raycastResult.sortingGroupOrder;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v16 (UnityEngine.EventSystems.RaycastResult)+30]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v16 (UnityEngine.EventSystems.RaycastResult)+40]");
						_ = 0;
						List<RaycastResult> raycastResultCache = m_RaycastResultCache;
						if (m_RaycastResultCache != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v17 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+1C]");
							_ = (nint)0 + (nint)1;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v17 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v17 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+10]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v17 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+18]");
								Array.Clear((Array)num3, 0, 0);
							}
							return (PlayerPointerEventData)pointerEventData;
						}
					}
				}
			}
		}
		goto IL_0316;
	}

	protected unsafe virtual MouseState GetMousePointerEventData(int playerId, int mouseIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0030: Expected I4, but got I8
		//IL_0044: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_020f: Expected I, but got O
		//IL_022f: Expected O, but got I
		//IL_0158: Expected O, but got I
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0187: Expected O, but got I
		//IL_02c0: Expected O, but got I
		//IL_03e5: Expected I4, but got I8
		//IL_03f9: Expected O, but got I
		//IL_03bd: Expected O, but got I
		//IL_0532: Expected I4, but got I8
		//IL_0546: Expected O, but got I
		//IL_0665: Expected O, but got I4
		//IL_066e: Expected O, but got I4
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Expected I4, but got Unknown
		//IL_06df: Expected O, but got I
		//IL_08fb: Expected O, but got I
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fd: Expected O, but got Unknown
		//IL_09e7: Expected O, but got I
		//IL_0ad3: Expected O, but got I
		//IL_0c34: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		IMouseInputSource mouseInputSource = GetMouseInputSource(playerId, mouseIndex);
		ref PlayerPointerEventData data = default(ref PlayerPointerEventData);
		bool create = default(bool);
		PointerEventType pointerEventType = default(PointerEventType);
		if (mouseInputSource != null)
		{
			bool pointerData = GetPointerData(playerId, mouseIndex, -1, out data, create, pointerEventType);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
			if ((nint)0 != 0)
			{
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v170 @ r8_v5+178] (should have been resolved before IL gen)");
				if (pointerData)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
					if ((nint)0 == 0)
					{
						goto IL_0c63;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-4D]");
					_ = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				object obj5 = default(object);
				if (obj5 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					object obj6 = default(object);
					if (obj6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-4D]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v95+108]");
							object obj8 = num - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v95+104]");
							object obj10 = default(object);
							object obj9 = obj10 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-4D]");
								_ = 0;
								goto IL_0cf7;
							}
						}
						goto IL_0c63;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
				if ((nint)0 != 0)
				{
					_ = 3212836864L;
					_ = 3212836864L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
					if ((nint)0 != 0)
					{
						nint num2 = (nint)typeof(Vector2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v848 @ rax_v90 (Il2CppClass<UnityEngine.Vector2>)+B8]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ rax_v91 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ rax_v91 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
						_ = 0;
						_ = Vector2.zeroVector;
						goto IL_0cf7;
					}
				}
			}
			goto IL_0c63;
		}
		return (MouseState)mouseInputSource;
		IL_0c63:
		return (MouseState)(object)new NullReferenceException();
		IL_0cf7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-4D]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
			if ((nint)0 != 0)
			{
				_ = 0;
				if ((object)base.m_EventSystem != null)
				{
					EventSystem obj12 = base.m_EventSystem;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
					obj12.RaycastAll((PointerEventData)0, m_RaycastResultCache);
					RaycastResult raycastResult = BaseInputModule.FindFirstRaycast(m_RaycastResultCache);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
					if ((nint)0 != 0)
					{
						_ = raycastResult.m_GameObject;
						_ = raycastResult.distance;
						_ = raycastResult.sortingGroupOrder;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v16 (UnityEngine.EventSystems.RaycastResult)+30]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v16 (UnityEngine.EventSystems.RaycastResult)+40]");
						_ = 0;
						List<RaycastResult> raycastResultCache = m_RaycastResultCache;
						if (m_RaycastResultCache != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+1C]");
							_ = (nint)0 + (nint)1;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+10]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>)+18]");
								Array.Clear((Array)num4, 0, 0);
							}
							bool pointerData2 = GetPointerData(playerId, mouseIndex, -2, out data, create, pointerEventType);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+108]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+104]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+110]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+10C]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+140]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+13C]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+60]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+70]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+80]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+90]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ r14_v3+20]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
									if ((nint)0 != 0)
									{
										_ = 1;
										bool pointerData3 = GetPointerData(playerId, mouseIndex, -3, out data, create, pointerEventType);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
										object obj14 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+108]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+104]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+110]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+10C]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+140]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+13C]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+50]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+60]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+70]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+80]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+90]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r14_v4+20]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
												if ((nint)0 != 0)
												{
													_ = 2;
													object obj15 = 3;
													object obj16 = 3;
													while (true)
													{
														int buttonCount = mouseInputSource.buttonCount;
														if ((nint)obj16 < buttonCount)
														{
															int pointerTypeId = obj15 - 2147483520;
															bool pointerData4 = GetPointerData(playerId, mouseIndex, pointerTypeId, out data, create, pointerEventType);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
															object obj17 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
															if ((nint)0 == 0)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
															if ((nint)0 == 0)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+108]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+104]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+110]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+10C]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+140]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+13C]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+50]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+60]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+70]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+80]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+90]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r15_v12+20]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
															if ((nint)0 == 0)
															{
																break;
															}
															obj15++;
															_ = 4294967295L;
															obj16 = obj15;
															continue;
														}
														PointerEventData.FramePressState buttonState = StateForMouseButton(playerId, mouseIndex, 0);
														if (m_MouseState == null)
														{
															break;
														}
														ButtonState buttonState2 = m_MouseState.GetButtonState(0);
														if (buttonState2 == null)
														{
															break;
														}
														MouseButtonEventData eventData = buttonState2.m_EventData;
														if (buttonState2.m_EventData == null)
														{
															break;
														}
														eventData.buttonState = buttonState;
														MouseButtonEventData eventData2 = buttonState2.m_EventData;
														if (buttonState2.m_EventData == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
														eventData2.buttonData = (PlayerPointerEventData)0;
														PointerEventData.FramePressState buttonState3 = StateForMouseButton(playerId, mouseIndex, 1);
														if (m_MouseState == null)
														{
															break;
														}
														ButtonState buttonState4 = m_MouseState.GetButtonState(1);
														if (buttonState4 == null)
														{
															break;
														}
														MouseButtonEventData eventData3 = buttonState4.m_EventData;
														if (buttonState4.m_EventData == null)
														{
															break;
														}
														eventData3.buttonState = buttonState3;
														MouseButtonEventData eventData4 = buttonState4.m_EventData;
														if (buttonState4.m_EventData == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
														eventData4.buttonData = (PlayerPointerEventData)0;
														PointerEventData.FramePressState buttonState5 = StateForMouseButton(playerId, mouseIndex, 2);
														if (m_MouseState == null)
														{
															break;
														}
														ButtonState buttonState6 = m_MouseState.GetButtonState(2);
														if (buttonState6 == null)
														{
															break;
														}
														MouseButtonEventData eventData5 = buttonState6.m_EventData;
														if (buttonState6.m_EventData == null)
														{
															break;
														}
														eventData5.buttonState = buttonState5;
														MouseButtonEventData eventData6 = buttonState6.m_EventData;
														if (buttonState6.m_EventData == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
														eventData6.buttonData = (PlayerPointerEventData)0;
														int num5 = 3;
														while (true)
														{
															int buttonCount2 = mouseInputSource.buttonCount;
															if (num5 < buttonCount2)
															{
																int pointerTypeId2 = num5 - 2147483520;
																bool pointerData5 = GetPointerData(playerId, mouseIndex, pointerTypeId2, out data, create, pointerEventType);
																PointerEventData.FramePressState framePressState = StateForMouseButton(playerId, mouseIndex, num5);
																if (m_MouseState == null)
																{
																	break;
																}
																ButtonState buttonState7 = m_MouseState.GetButtonState(num5);
																if (buttonState7 == null)
																{
																	break;
																}
																MouseButtonEventData eventData7 = buttonState7.m_EventData;
																if (buttonState7.m_EventData == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
																eventData7.buttonState = PointerEventData.FramePressState.Pressed;
																MouseButtonEventData eventData8 = buttonState7.m_EventData;
																if (buttonState7.m_EventData == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
																eventData8.buttonData = (PlayerPointerEventData)0;
																num5++;
																continue;
															}
															return m_MouseState;
														}
														break;
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
		goto IL_0c63;
	}

	protected PlayerPointerEventData GetLastPointerEventData(int playerId, int pointerIndex, int pointerTypeId, bool ignorePointerTypeId, PointerEventType pointerEventType)
	{
		object obj = default(object);
		if (obj != null)
		{
			if (m_PlayerPointerData != null)
			{
				if (((Dictionary<int, object>)(object)m_PlayerPointerData).TryGetValue(playerId, out object value))
				{
					if (value == null)
					{
						goto IL_0156;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-A8_v3 (System.Object)+18]");
					if ((nint)pointerIndex < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-A8_v3 (System.Object)+20+pointerIndex @ r8 (System.Int32)*8]");
						if ((nint)0 == 0)
						{
							goto IL_0156;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
						Dictionary<int, PlayerPointerEventData>.Enumerator enumerator = default(Dictionary<int, PlayerPointerEventData>.Enumerator);
						if (enumerator.MoveNext())
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
							PlayerPointerEventData result = default(PlayerPointerEventData);
							return result;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					}
				}
				return null;
			}
			goto IL_0156;
		}
		ref PlayerPointerEventData data = default(ref PlayerPointerEventData);
		bool create = default(bool);
		PointerEventType pointerEventType2 = default(PointerEventType);
		bool pointerData = GetPointerData(playerId, pointerIndex, pointerTypeId, out data, create, pointerEventType2);
		PlayerPointerEventData result2 = default(PlayerPointerEventData);
		return result2;
		IL_0156:
		return (PlayerPointerEventData)(object)new NullReferenceException();
	}

	private static bool ShouldStartDrag(Vector2 pressPos, Vector2 currentPos, float threshold, bool useDragThreshold)
	{
		//IL_0071: Invalid comparison between O and F4
		if (useDragThreshold)
		{
			object obj = pressPos - currentPos;
			object obj3 = default(object);
			object obj4 = default(object);
			object obj2 = obj3 - obj4;
			object obj5 = obj2 * obj2;
			object obj6 = obj * obj;
			float num = threshold * threshold;
			object obj7 = obj5 + obj6;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num);
			return !flag;
		}
		return true;
	}

	protected virtual void ProcessMove(PlayerPointerEventData pointerEvent)
	{
		GameObject newEnterTarget;
		if (pointerEvent._003CsourceType_003Ek__BackingField != PointerEventType.Mouse)
		{
			if (pointerEvent._003CsourceType_003Ek__BackingField != PointerEventType.Touch)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				NotImplementedException ex = new NotImplementedException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}
			newEnterTarget = (GameObject)((PointerEventData)pointerEvent)._003CpointerCurrentRaycast_003Ek__BackingField;
		}
		else
		{
			IMouseInputSource mouseInputSource = GetMouseInputSource(pointerEvent._003CplayerId_003Ek__BackingField, pointerEvent._003CinputSourceIndex_003Ek__BackingField);
			if (mouseInputSource != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				object obj = default(object);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					object obj2 = default(object);
					if (obj2 == null)
					{
						newEnterTarget = (GameObject)((PointerEventData)pointerEvent)._003CpointerCurrentRaycast_003Ek__BackingField;
						goto IL_0132;
					}
				}
			}
			newEnterTarget = null;
		}
		goto IL_0132;
		IL_0132:
		HandlePointerExitAndEnter(pointerEvent, newEnterTarget);
	}

	protected virtual void ProcessDrag(PlayerPointerEventData pointerEvent)
	{
		//IL_00c7: Expected O, but got I4
		//IL_027e: Expected O, but got I4
		//IL_0199: Expected O, but got I
		//IL_00f1: Expected O, but got I4
		if (!pointerEvent.IsPointerMoving() || !(((PointerEventData)pointerEvent)._003CpointerDrag_003Ek__BackingField != null))
		{
			return;
		}
		if (pointerEvent._003CsourceType_003Ek__BackingField == PointerEventType.Mouse)
		{
			IMouseInputSource mouseInputSource = GetMouseInputSource(pointerEvent._003CplayerId_003Ek__BackingField, pointerEvent._003CinputSourceIndex_003Ek__BackingField);
			if (mouseInputSource == null || ExecuteEvents.Execute((GameObject)2, (BaseEventData)(object)typeof(IMouseInputSource), (ExecuteEvents.EventFunction<IBeginDragHandler>)(object)mouseInputSource) || !ExecuteEvents.Execute((GameObject)1, (BaseEventData)(object)typeof(IMouseInputSource), (ExecuteEvents.EventFunction<IBeginDragHandler>)(object)mouseInputSource))
			{
				return;
			}
		}
		if (!((PointerEventData)pointerEvent)._003Cdragging_003Ek__BackingField)
		{
			EventSystem eventSystem = base.m_EventSystem;
			if (((PointerEventData)pointerEvent)._003CuseDragThreshold_003Ek__BackingField)
			{
				object obj = ((PointerEventData)pointerEvent)._003CpressPosition_003Ek__BackingField - ((PointerEventData)pointerEvent)._003Cposition_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pointerEvent @ rdx (Rewired.Integration.UnityUI.PlayerPointerEventData)+118]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pointerEvent @ rdx (Rewired.Integration.UnityUI.PlayerPointerEventData)+108]");
				object obj2 = num - 0;
				object obj3 = obj2 * obj2;
				object obj4 = obj * obj;
				int num2 = eventSystem.m_DragThreshold * eventSystem.m_DragThreshold;
				object obj5 = obj3 + obj4;
				if ((nint)obj5 < num2)
				{
					goto IL_02ef;
				}
			}
			bool flag = ExecuteEvents.Execute(((PointerEventData)pointerEvent)._003CpointerDrag_003Ek__BackingField, pointerEvent, ExecuteEvents.s_BeginDragHandler);
			((PointerEventData)pointerEvent)._003Cdragging_003Ek__BackingField = true;
			goto IL_02ef;
		}
		goto IL_0231;
		IL_0231:
		if (((PointerEventData)pointerEvent).m_PointerPress != ((PointerEventData)pointerEvent)._003CpointerDrag_003Ek__BackingField)
		{
			ExecuteEvents.EventFunction<IPointerUpHandler> functor = (ExecuteEvents.EventFunction<IPointerUpHandler>)ExecuteEvents.Execute<IBeginDragHandler>(null, (BaseEventData)(object)((PointerEventData)pointerEvent)._003CpointerDrag_003Ek__BackingField, null);
			bool flag2 = ExecuteEvents.Execute(((PointerEventData)pointerEvent).m_PointerPress, pointerEvent, functor);
			((PointerEventData)pointerEvent)._003CeligibleForClick_003Ek__BackingField = false;
			pointerEvent.pointerPress = null;
			((PointerEventData)pointerEvent)._003CrawPointerPress_003Ek__BackingField = null;
		}
		bool flag3 = ExecuteEvents.Execute(((PointerEventData)pointerEvent)._003CpointerDrag_003Ek__BackingField, pointerEvent, ExecuteEvents.s_DragHandler);
		return;
		IL_02ef:
		if (((PointerEventData)pointerEvent)._003Cdragging_003Ek__BackingField)
		{
			goto IL_0231;
		}
	}

	public unsafe override bool IsPointerOverGameObject(int pointerTypeId)
	{
		//IL_0032: Expected O, but got I4
		//IL_003b: Expected O, but got Ref
		//IL_00d5: Expected O, but got I
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0128: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
		object value = null;
		Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator enumerator = default(Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				object obj2 = 0;
				Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator enumerator2 = (Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				while (true)
				{
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ stack_-58+18]");
					if ((nint)obj3 >= 0)
					{
						break;
					}
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ stack_-58+18]");
					if ((nint)obj4 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ stack_-58+20+v79 @ rdi_v9*8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ stack_-58+20+v79 @ rdi_v9*8]");
							if (((Dictionary<int, object>)0).TryGetValue(pointerTypeId, out value))
							{
								if (value == null)
								{
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ stack_8_v6 (System.Object)+20]");
								if ((UnityEngine.Object)0 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
									return true;
								}
							}
							obj2++;
							continue;
						}
						throw new NullReferenceException();
					}
					throw new IndexOutOfRangeException();
				}
				continue;
			}
			enumerator.Dispose();
			return false;
		}
		throw new NullReferenceException();
	}

	protected unsafe void ClearSelection()
	{
		//IL_001a: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_0040: Expected O, but got Ref
		//IL_0048: Expected O, but got Ref
		//IL_0278: Expected O, but got Ref
		//IL_011f: Expected O, but got I
		//IL_013e: Expected O, but got I
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_0167: Expected O, but got I
		BaseEventData baseEventData = base.GetBaseEventData();
		RewiredPointerInputModule rewiredPointerInputModule;
		if (m_PlayerPointerData != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
			Dictionary<int, PlayerPointerEventData>.Enumerator enumerator = (Dictionary<int, PlayerPointerEventData>.Enumerator)0;
			Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator enumerator2 = default(Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator);
			object obj = default(object);
			PointerEventData currentPointerData = default(PointerEventData);
			Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator enumerator4 = default(Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator);
			while (enumerator2.MoveNext())
			{
				bool flag = obj == null;
				object obj2 = 0;
				rewiredPointerInputModule = (RewiredPointerInputModule)(&enumerator2);
				Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator enumerator3 = (Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator)(&enumerator2);
				if (!flag)
				{
					while (true)
					{
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ stack_-48+18]");
						if ((nint)obj3 >= 0)
						{
							break;
						}
						object obj4 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ stack_-48+18]");
						if ((nint)obj4 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ stack_-48+20+v173 @ rdi_v10*8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
								while (enumerator.MoveNext())
								{
									HandlePointerExitAndEnter(currentPointerData, null);
								}
								enumerator.Dispose();
								object obj5 = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ stack_-48+18]");
								bool flag2 = (nint)obj5 >= 0;
								rewiredPointerInputModule = (RewiredPointerInputModule)(&enumerator);
								if (!flag2)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ stack_-48+20+v173 @ rdi_v10*8]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ stack_-48+20+v173 @ rdi_v10*8]");
									rewiredPointerInputModule = (RewiredPointerInputModule)0;
									if (!flag3)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ stack_-48+20+v173 @ rdi_v10*8]");
										((Dictionary<int, PlayerPointerEventData>)0).Clear();
										obj2++;
										enumerator = (Dictionary<int, PlayerPointerEventData>.Enumerator)enumerator4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ stack_-48+20+v173 @ rdi_v10*8]");
										rewiredPointerInputModule = (RewiredPointerInputModule)0;
										continue;
									}
									throw new NullReferenceException();
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						throw new IndexOutOfRangeException();
					}
					continue;
				}
				throw new NullReferenceException();
			}
			enumerator2.Dispose();
			if ((object)base.m_EventSystem != null)
			{
				base.m_EventSystem.SetSelectedGameObject(null, baseEventData);
				return;
			}
		}
		rewiredPointerInputModule = (RewiredPointerInputModule)(object)base.m_EventSystem;
		throw new NullReferenceException();
	}

	public override string ToString()
	{
		//IL_0084: Expected O, but got I4
		//IL_0237: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
		object obj = default(object);
		string text = default(string);
		if (obj != null)
		{
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v63 @ r8_v22+168] (should have been resolved before IL gen)");
		}
		else
		{
			text = null;
		}
		string value = "<b>Pointer Input Module of type: </b>" + text;
		StringBuilder stringBuilder = new StringBuilder(value);
		if (stringBuilder != null)
		{
			StringBuilder stringBuilder2 = stringBuilder.AppendLine();
			if (m_PlayerPointerData != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
				Dictionary<int, PlayerPointerEventData>.Enumerator enumerator = (Dictionary<int, PlayerPointerEventData>.Enumerator)0;
				Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator enumerator2 = default(Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator);
				int num = default(int);
				object obj3 = default(object);
				int num2 = default(int);
				int num3 = default(int);
				RewiredPointerInputModule rewiredPointerInputModule = default(RewiredPointerInputModule);
				Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator enumerator3 = default(Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>.Enumerator);
				while (true)
				{
					if (enumerator2.MoveNext())
					{
						string text2 = num.ToString();
						string value2 = "<B>Player Id:</b> " + text2;
						StringBuilder stringBuilder3 = stringBuilder.AppendLine(value2);
						bool flag = obj3 == null;
						num = num2;
						string text3 = null;
						if (flag)
						{
							break;
						}
						while (true)
						{
							string text4 = text3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ stack_-38+18]");
							if ((nint)text4 >= 0)
							{
								break;
							}
							string text5 = num3.ToString();
							string value3 = "<B>Pointer Index:</b> " + text5;
							StringBuilder stringBuilder4 = stringBuilder.AppendLine(value3);
							int num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ stack_-38+18]");
							if ((nint)num4 < (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ stack_-38+20+v149 @ stack_18_v9 (System.Int32)*8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
									while (enumerator.MoveNext())
									{
										string text6 = num.ToString();
										string value4 = "<B>Button Id:</b> " + text6;
										StringBuilder stringBuilder5 = stringBuilder.AppendLine(value4);
										if ((object)rewiredPointerInputModule != null)
										{
											string value5 = rewiredPointerInputModule.ToString();
											StringBuilder stringBuilder6 = stringBuilder.AppendLine(value5);
											num = num2;
											continue;
										}
										throw new NullReferenceException();
									}
									enumerator.Dispose();
									text3 = (string)(num3 + 1);
									enumerator = (Dictionary<int, PlayerPointerEventData>.Enumerator)enumerator3;
									continue;
								}
								throw new NullReferenceException();
							}
							throw new IndexOutOfRangeException();
						}
						continue;
					}
					enumerator2.Dispose();
					return stringBuilder.ToString();
				}
				throw new NullReferenceException();
			}
		}
		throw new NullReferenceException();
	}

	protected void DeselectIfSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent)
	{
		GameObject eventHandler = ExecuteEvents.GetEventHandler<ISelectHandler>(currentOverGo);
		EventSystem eventSystem = base.m_EventSystem;
		if (eventHandler != eventSystem.m_CurrentSelected)
		{
			base.m_EventSystem.SetSelectedGameObject(null, pointerEvent);
		}
	}

	protected void CopyFromTo(PointerEventData from, PointerEventData to)
	{
		to._003Cposition_003Ek__BackingField = from._003Cposition_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [from @ rdx (UnityEngine.EventSystems.PointerEventData)+108]");
		_ = 0;
		to._003Cdelta_003Ek__BackingField = from._003Cdelta_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [from @ rdx (UnityEngine.EventSystems.PointerEventData)+110]");
		_ = 0;
		to._003CscrollDelta_003Ek__BackingField = from._003CscrollDelta_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [from @ rdx (UnityEngine.EventSystems.PointerEventData)+140]");
		_ = 0;
		to._003CpointerCurrentRaycast_003Ek__BackingField = from._003CpointerCurrentRaycast_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [from @ rdx (UnityEngine.EventSystems.PointerEventData)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [from @ rdx (UnityEngine.EventSystems.PointerEventData)+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [from @ rdx (UnityEngine.EventSystems.PointerEventData)+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [from @ rdx (UnityEngine.EventSystems.PointerEventData)+90]");
		_ = 0;
		to._003CpointerEnter_003Ek__BackingField = from._003CpointerEnter_003Ek__BackingField;
	}

	protected PointerEventData.FramePressState StateForMouseButton(int playerId, int mouseIndex, int buttonId)
	{
		//IL_0045: Expected O, but got I4
		IMouseInputSource mouseInputSource = GetMouseInputSource(playerId, mouseIndex);
		if (mouseInputSource != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
			object obj2 = default(object);
			object obj3 = default(object);
			object obj = obj2 & obj3;
			bool flag = obj == null;
			object obj4 = !flag;
			if (obj4 == null)
			{
				if (obj3 == null)
				{
					bool flag2 = obj2 != null;
					PointerEventData.FramePressState result = PointerEventData.FramePressState.Released;
					if (!flag2)
					{
						result = PointerEventData.FramePressState.NotChanged;
					}
					return result;
				}
				return PointerEventData.FramePressState.Pressed;
			}
			return PointerEventData.FramePressState.PressedAndReleased;
		}
		return PointerEventData.FramePressState.NotChanged;
	}

	protected RewiredPointerInputModule()
	{
		List<IMouseInputSource> mouseInputSourcesList = new List<IMouseInputSource>();
		m_MouseInputSourcesList = mouseInputSourcesList;
		m_PlayerPointerData = new Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>();
		MouseState mouseState = new MouseState();
		List<ButtonState> trackedButtons = new List<ButtonState>();
		mouseState.m_TrackedButtons = trackedButtons;
		m_MouseState = mouseState;
		base._002Ector();
	}
}
