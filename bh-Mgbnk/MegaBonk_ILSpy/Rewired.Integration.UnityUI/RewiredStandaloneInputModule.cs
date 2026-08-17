using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Rewired.Components;
using Rewired.UI;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rewired.Integration.UnityUI;

public sealed class RewiredStandaloneInputModule : RewiredPointerInputModule
{
	[Serializable]
	public class PlayerSetting
	{
		public int playerId;

		public List<Rewired.Components.PlayerMouse> playerMice;

		public PlayerSetting()
		{
			List<Rewired.Components.PlayerMouse> list = new List<Rewired.Components.PlayerMouse>();
			playerMice = list;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}

		private unsafe PlayerSetting(PlayerSetting other)
		{
			//IL_00b9: Expected O, but got I
			//IL_022e: Expected I, but got O
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Expected I, but got Unknown
			List<Rewired.Components.PlayerMouse> list = new List<Rewired.Components.PlayerMouse>();
			playerMice = list;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			bool flag = other == null;
			object obj = null;
			if (!flag)
			{
				playerId = other.playerId;
				playerMice = new List<Rewired.Components.PlayerMouse>();
				if (other.playerMice == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				nint num = 0;
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				List<object> list2;
				object obj2 = default(object);
				int num3 = default(int);
				nint num2;
				while (true)
				{
					if (enumerator.MoveNext())
					{
						list2 = (List<object>)(object)playerMice;
						bool flag2 = playerMice == null;
						num2 = num;
						obj = 0;
						if (!flag2)
						{
							int version = list2._version + 1;
							list2._version = version;
							object[] items = list2._items;
							if (list2._items == null)
							{
								break;
							}
							if (list2._size >= items.Length)
							{
								((List<object>)(object)playerMice).AddWithResize(obj2);
								num = 0;
								continue;
							}
							int size = list2._size + 1;
							list2._size = size;
							items[num3] = obj2;
							num = (nint)(list2._items + 32);
							continue;
						}
						throw new NullReferenceException();
					}
					((List<Rewired.Components.PlayerMouse>.Enumerator*)(&enumerator))->Dispose();
					return;
				}
				num2 = (nint)list2._items;
				obj = obj2;
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			ArgumentNullException ex = new ArgumentNullException("other");
			ex._002Ector("other");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}

		public PlayerSetting Clone()
		{
			return new PlayerSetting(this);
		}
	}

	private const string DEFAULT_ACTION_MOVE_HORIZONTAL = "UIHorizontal";

	private const string DEFAULT_ACTION_MOVE_VERTICAL = "UIVertical";

	private const string DEFAULT_ACTION_SUBMIT = "UISubmit";

	private const string DEFAULT_ACTION_CANCEL = "UICancel";

	private InputManager_Base rewiredInputManager;

	private bool useAllRewiredGamePlayers;

	private bool useRewiredSystemPlayer;

	private int[] rewiredPlayerIds;

	private bool usePlayingPlayersOnly;

	private List<Rewired.Components.PlayerMouse> playerMice;

	private bool moveOneElementPerAxisPress;

	private bool setActionsById;

	private int horizontalActionId;

	private int verticalActionId;

	private int submitActionId;

	private int cancelActionId;

	private string m_HorizontalAxis;

	private string m_VerticalAxis;

	private string m_SubmitButton;

	private string m_CancelButton;

	private float m_InputActionsPerSecond;

	private float m_RepeatDelay;

	private bool m_allowMouseInput;

	private bool m_allowMouseInputIfTouchSupported;

	private bool m_allowTouchInput;

	private bool m_deselectIfBackgroundClicked;

	private bool m_deselectBeforeSelecting;

	private bool m_ForceModuleActive;

	[NonSerialized]
	private int[] playerIds;

	private bool recompiling;

	[NonSerialized]
	private bool isTouchSupported;

	[NonSerialized]
	private double m_PrevActionTime;

	[NonSerialized]
	private Vector2 m_LastMoveVector;

	[NonSerialized]
	private int m_ConsecutiveMoveCount;

	[NonSerialized]
	private bool m_HasFocus;

	public InputManager_Base RewiredInputManager
	{
		get
		{
			return rewiredInputManager;
		}
		set
		{
			rewiredInputManager = value;
		}
	}

	public bool UseAllRewiredGamePlayers
	{
		get
		{
			return useAllRewiredGamePlayers;
		}
		set
		{
			useAllRewiredGamePlayers = value;
			if (value != useAllRewiredGamePlayers)
			{
				SetupRewiredVars();
			}
		}
	}

	public bool UseRewiredSystemPlayer
	{
		get
		{
			return useRewiredSystemPlayer;
		}
		set
		{
			useRewiredSystemPlayer = value;
			if (value != useRewiredSystemPlayer)
			{
				SetupRewiredVars();
			}
		}
	}

	public int[] RewiredPlayerIds
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181445580");
			int[] array = default(int[]);
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				if (array == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					int[] result = default(int[]);
					return result;
				}
			}
			return array;
		}
		set
		{
			//IL_0069: Expected I, but got O
			int[] array2;
			if (value != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181445580");
				int[] array = default(int[]);
				bool flag = array == null;
				array2 = array;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					if (array2 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						return;
					}
					nint num = (nint)typeof(int[]);
				}
			}
			else
			{
				array2 = new int[0];
			}
			rewiredPlayerIds = array2;
			SetupRewiredVars();
		}
	}

	public bool UsePlayingPlayersOnly
	{
		get
		{
			return usePlayingPlayersOnly;
		}
		set
		{
			usePlayingPlayersOnly = value;
		}
	}

	public List<Rewired.Components.PlayerMouse> PlayerMice
	{
		get
		{
			return (List<Rewired.Components.PlayerMouse>)(object)new List<object>(playerMice);
		}
		set
		{
			List<Rewired.Components.PlayerMouse> list = (List<Rewired.Components.PlayerMouse>)(object)new List<object>(value);
			if (value != null)
			{
				((List<object>)(object)list)._002Ector((IEnumerable<object>)value);
			}
			else
			{
				list._002Ector();
			}
			playerMice = list;
			SetupRewiredVars();
		}
	}

	public bool MoveOneElementPerAxisPress
	{
		get
		{
			return moveOneElementPerAxisPress;
		}
		set
		{
			moveOneElementPerAxisPress = value;
		}
	}

	public bool allowMouseInput
	{
		get
		{
			return m_allowMouseInput;
		}
		set
		{
			m_allowMouseInput = value;
		}
	}

	public bool allowMouseInputIfTouchSupported
	{
		get
		{
			return m_allowMouseInputIfTouchSupported;
		}
		set
		{
			m_allowMouseInputIfTouchSupported = value;
		}
	}

	public bool allowTouchInput
	{
		get
		{
			return m_allowTouchInput;
		}
		set
		{
			m_allowTouchInput = value;
		}
	}

	public bool deselectIfBackgroundClicked
	{
		get
		{
			return m_deselectIfBackgroundClicked;
		}
		set
		{
			m_deselectIfBackgroundClicked = value;
		}
	}

	private bool deselectBeforeSelecting
	{
		get
		{
			return m_deselectBeforeSelecting;
		}
		set
		{
			m_deselectBeforeSelecting = value;
		}
	}

	public bool SetActionsById
	{
		get
		{
			return setActionsById;
		}
		set
		{
			if (setActionsById != value)
			{
				setActionsById = value;
				SetupRewiredVars();
			}
		}
	}

	public int HorizontalActionId
	{
		get
		{
			return horizontalActionId;
		}
		set
		{
			//IL_00a1: Expected O, but got I
			//IL_00b1: Expected O, but got I
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			if (value == horizontalActionId)
			{
				return;
			}
			horizontalActionId = value;
			if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				InputAction action = mapping.GetAction(value);
				object obj;
				if (action != null)
				{
					ReInput.MappingHelper mapping2 = ReInput.mapping;
					InputAction action2 = mapping2.GetAction(value);
					obj = action2 + 24;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rax_v14+B8]");
					obj = 0;
				}
				m_HorizontalAxis = (string)obj;
			}
		}
	}

	public int VerticalActionId
	{
		get
		{
			return verticalActionId;
		}
		set
		{
			//IL_00a1: Expected O, but got I
			//IL_00b1: Expected O, but got I
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			if (value == verticalActionId)
			{
				return;
			}
			verticalActionId = value;
			if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				InputAction action = mapping.GetAction(value);
				object obj;
				if (action != null)
				{
					ReInput.MappingHelper mapping2 = ReInput.mapping;
					InputAction action2 = mapping2.GetAction(value);
					obj = action2 + 24;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rax_v14+B8]");
					obj = 0;
				}
				m_VerticalAxis = (string)obj;
			}
		}
	}

	public int SubmitActionId
	{
		get
		{
			return submitActionId;
		}
		set
		{
			//IL_00a1: Expected O, but got I
			//IL_00b1: Expected O, but got I
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			if (value == submitActionId)
			{
				return;
			}
			submitActionId = value;
			if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				InputAction action = mapping.GetAction(value);
				object obj;
				if (action != null)
				{
					ReInput.MappingHelper mapping2 = ReInput.mapping;
					InputAction action2 = mapping2.GetAction(value);
					obj = action2 + 24;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rax_v14+B8]");
					obj = 0;
				}
				m_SubmitButton = (string)obj;
			}
		}
	}

	public int CancelActionId
	{
		get
		{
			return cancelActionId;
		}
		set
		{
			//IL_00a1: Expected O, but got I
			//IL_00b1: Expected O, but got I
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			if (value == cancelActionId)
			{
				return;
			}
			cancelActionId = value;
			if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				InputAction action = mapping.GetAction(value);
				object obj;
				if (action != null)
				{
					ReInput.MappingHelper mapping2 = ReInput.mapping;
					InputAction action2 = mapping2.GetAction(value);
					obj = action2 + 24;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rax_v14+B8]");
					obj = 0;
				}
				m_CancelButton = (string)obj;
			}
		}
	}

	protected override bool isMouseSupported
	{
		get
		{
			//IL_01aa: Expected I4, but got O
			List<IMouseInputSource> mouseInputSourcesList = base.m_MouseInputSourcesList;
			if (base.m_MouseInputSourcesList != null)
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
					while (base.m_MouseInputSourcesList != null)
					{
						IMouseInputSource mouseInputSource = base.m_MouseInputSourcesList.get_Item(num);
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
						goto IL_0151;
					}
				}
				else
				{
					RewiredPointerInputModule.UnityInputSource unityInputSource = base.defaultInputSource;
					if (unityInputSource != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						object obj2 = default(object);
						if (obj2 == null)
						{
							goto IL_00fd;
						}
						goto IL_0151;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0151:
			if (m_allowMouseInput)
			{
				if (isTouchSupported)
				{
					return m_allowMouseInputIfTouchSupported;
				}
				return true;
			}
			goto IL_00fd;
			IL_00fd:
			return false;
		}
	}

	private bool isTouchAllowed => m_allowTouchInput;

	public bool allowActivationOnMobileDevice
	{
		get
		{
			return m_ForceModuleActive;
		}
		set
		{
			m_ForceModuleActive = value;
		}
	}

	public bool forceModuleActive
	{
		get
		{
			return m_ForceModuleActive;
		}
		set
		{
			m_ForceModuleActive = value;
		}
	}

	public float inputActionsPerSecond
	{
		get
		{
			return m_InputActionsPerSecond;
		}
		set
		{
			m_InputActionsPerSecond = value;
		}
	}

	public float repeatDelay
	{
		get
		{
			return m_RepeatDelay;
		}
		set
		{
			m_RepeatDelay = value;
		}
	}

	public string horizontalAxis
	{
		get
		{
			return m_HorizontalAxis;
		}
		set
		{
			if (m_HorizontalAxis != value)
			{
				m_HorizontalAxis = value;
				if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
				{
					ReInput.MappingHelper mapping = ReInput.mapping;
					int actionId = mapping.GetActionId(value);
					horizontalActionId = actionId;
				}
			}
		}
	}

	public string verticalAxis
	{
		get
		{
			return m_VerticalAxis;
		}
		set
		{
			if (m_VerticalAxis != value)
			{
				m_VerticalAxis = value;
				if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
				{
					ReInput.MappingHelper mapping = ReInput.mapping;
					int actionId = mapping.GetActionId(value);
					verticalActionId = actionId;
				}
			}
		}
	}

	public string submitButton
	{
		get
		{
			return m_SubmitButton;
		}
		set
		{
			if (m_SubmitButton != value)
			{
				m_SubmitButton = value;
				if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
				{
					ReInput.MappingHelper mapping = ReInput.mapping;
					int actionId = mapping.GetActionId(value);
					submitActionId = actionId;
				}
			}
		}
	}

	public string cancelButton
	{
		get
		{
			return m_CancelButton;
		}
		set
		{
			if (m_CancelButton != value)
			{
				m_CancelButton = value;
				if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
				{
					ReInput.MappingHelper mapping = ReInput.mapping;
					int actionId = mapping.GetActionId(value);
					cancelActionId = actionId;
				}
			}
		}
	}

	private RewiredStandaloneInputModule()
	{
		int[] array = new int[1];
		rewiredPlayerIds = array;
		List<Rewired.Components.PlayerMouse> list = new List<Rewired.Components.PlayerMouse>();
		list._002Ector();
		playerMice = list;
		horizontalActionId = -1;
		submitActionId = -1;
		m_HorizontalAxis = "UIHorizontal";
		m_VerticalAxis = "UIVertical";
		m_SubmitButton = "UISubmit";
		m_CancelButton = "UICancel";
		m_InputActionsPerSecond = 10f;
		m_allowMouseInput = true;
		m_deselectBeforeSelecting = true;
		m_HasFocus = true;
		List<IMouseInputSource> mouseInputSourcesList = new List<IMouseInputSource>();
		base.m_MouseInputSourcesList = mouseInputSourcesList;
		Dictionary<int, Dictionary<int, PlayerPointerEventData>[]> playerPointerData = new Dictionary<int, Dictionary<int, PlayerPointerEventData>[]>();
		base.m_PlayerPointerData = playerPointerData;
		MouseState mouseState = new MouseState();
		List<ButtonState> trackedButtons = new List<ButtonState>();
		mouseState.m_TrackedButtons = trackedButtons;
		base.m_MouseState = mouseState;
		((BaseInputModule)this)._002Ector();
	}

	protected override void Awake()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		RewiredPointerInputModule.UnityInputSource unityInputSource = base.defaultInputSource;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		bool flag = default(bool);
		isTouchSupported = flag;
		Action value = OnRewiredInitialized;
		ReInput.InitializedEvent += value;
		InitializeRewired();
	}

	public override void UpdateModule()
	{
		if (recompiling)
		{
			if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				recompiling = false;
				InitializeRewired();
			}
			if (recompiling)
			{
				return;
			}
		}
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF && !m_HasFocus)
		{
			bool flag = ShouldIgnoreEventsOnNoFocus();
		}
	}

	public override bool IsModuleSupported()
	{
		return true;
	}

	public override bool ShouldActivateModule()
	{
		//IL_0071: Expected F4, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_0852: Expected O, but got I4
		//IL_0b03: Expected O, but got I4
		//IL_0b0c: Expected O, but got I4
		//IL_0b1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b20: Expected O, but got Unknown
		//IL_099c: Expected I4, but got O
		//IL_0bf5: Expected O, but got I4
		//IL_0bfe: Expected O, but got I4
		//IL_09af: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Expected O, but got Unknown
		//IL_0ba2: Expected O, but got I4
		//IL_09c6: Expected O, but got I4
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_0936: Expected O, but got I4
		//IL_07fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Expected O, but got Unknown
		//IL_022b: Expected F4, but got I4
		//IL_0575: Expected O, but got I4
		//IL_058b: Expected I4, but got O
		//IL_059c: Expected O, but got I4
		//IL_0544: Invalid comparison between F4 and I4
		//IL_0553: Invalid comparison between F4 and I4
		//IL_0259: Expected F4, but got I4
		//IL_0777: Expected O, but got I4
		//IL_060a: Expected O, but got I4
		//IL_061a: Expected O, but got I4
		//IL_0a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4b: Expected O, but got Unknown
		//IL_0a54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Expected O, but got Unknown
		//IL_0a66: Expected I4, but got O
		//IL_0a6f: Expected F4, but got I4
		//IL_07c6: Expected O, but got I4
		//IL_07dc: Expected I4, but got O
		//IL_07aa: Expected O, but got I4
		if (base.ShouldActivateModule() && !recompiling && ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			int[] array = playerIds;
			bool flag = m_ForceModuleActive;
			float num = 0f;
			object obj = 0;
			object obj2 = 0;
			object obj4 = default(object);
			object obj6 = default(object);
			object obj11 = default(object);
			object obj12 = default(object);
			float num2 = default(float);
			object obj17 = default(object);
			while (true)
			{
				Player player;
				bool flag7;
				bool flag8;
				bool flag9;
				if ((nint)obj2 < array.Length)
				{
					ReInput.PlayerHelper players = ReInput.players;
					int[] array2 = playerIds;
					if ((nint)obj >= array2.Length)
					{
						break;
					}
					player = players.GetPlayer(array2[obj]);
					if (player == null)
					{
						goto IL_099c;
					}
					bool flag2 = !usePlayingPlayersOnly;
					Player player2 = (Player)(object)players;
					if (!flag2)
					{
						bool isPlaying = player.isPlaying;
						bool flag3 = !isPlaying;
						player2 = player;
						if (flag3)
						{
							goto IL_099c;
						}
					}
					bool flag4;
					if (submitActionId >= 0)
					{
						bool buttonDown = player.GetButtonDown(submitActionId);
						flag4 = buttonDown;
						player2 = player;
					}
					else
					{
						flag4 = false;
					}
					object obj3 = flag4 | flag;
					bool flag5;
					if (cancelActionId >= 0)
					{
						flag5 = player.GetButtonDown(cancelActionId);
						player2 = player;
					}
					else
					{
						flag5 = false;
					}
					bool flag6 = obj3 == null;
					flag7 = flag5;
					if (!flag6)
					{
						flag7 = true;
					}
					if (!moveOneElementPerAxisPress)
					{
						if (horizontalActionId >= 0)
						{
							float axis = player.GetAxis(horizontalActionId);
							player2 = player;
						}
						else
						{
							float axis = 0f;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180363600");
						if (verticalActionId >= 0)
						{
							num = player.GetAxis(verticalActionId);
							player2 = player;
						}
						else
						{
							num = 0f;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180363600");
						obj3 = obj4 ^ 1;
						object obj5 = obj6 ^ 1;
						flag8 = (byte)(obj5 | obj3) != 0;
						num2 = 0f;
						goto IL_0a74;
					}
					if (horizontalActionId >= 0)
					{
						bool buttonDown2 = player.GetButtonDown(horizontalActionId);
						flag9 = !buttonDown2;
						if (!flag9)
						{
							goto IL_0a86;
						}
					}
					bool flag10 = horizontalActionId < 0;
					flag9 = horizontalActionId == 0;
					if (!flag10)
					{
						bool negativeButtonDown = player.GetNegativeButtonDown(horizontalActionId);
					}
					goto IL_0a86;
				}
				int[] array5;
				object obj14;
				object obj15;
				Player player4;
				if (isMouseSupported)
				{
					int[] array3 = playerIds;
					object obj7 = 0;
					object obj8 = 0;
					while (true)
					{
						object obj9 = obj8 - array3.Length;
						bool flag11 = obj9 == null;
						if ((nint)obj8 < array3.Length)
						{
							int[] array4 = playerIds;
							if ((nint)obj7 >= array4.Length)
							{
								break;
							}
							ReInput.PlayerHelper players2 = ReInput.players;
							Player player3 = players2.GetPlayer(array4[obj7]);
							if (player3 != null && (!usePlayingPlayersOnly || player3.isPlaying))
							{
								int mouseInputSourceCount = GetMouseInputSourceCount(array4[obj7]);
								bool flag12 = mouseInputSourceCount <= 0;
								float num3 = num2;
								float num4 = num;
								int num5 = 0;
								player4 = null;
								if (!flag12)
								{
									object obj13;
									while (true)
									{
										IMouseInputSource mouseInputSource = GetMouseInputSource(array4[obj7], num5);
										if (mouseInputSource != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
											object obj10 = obj11 * obj11;
											num3 = (float)obj12 * (float)obj12;
											num4 = (float)obj10 + num3;
											flag11 = num4 == 0f;
											if (num4 > 0f)
											{
												break;
											}
										}
										player4 = (Player)(num5 + 1);
										bool flag13 = (nint)player4 < mouseInputSourceCount;
										num5 = (int)player4;
										num2 = num3;
										obj13 = 0;
										num = num4;
										if (flag13)
										{
											continue;
										}
										goto IL_05b2;
									}
									num2 = num3;
									obj13 = 0;
									num = num4;
									player4 = (Player)num5;
									goto IL_0b50;
								}
							}
							goto IL_05b2;
						}
						goto IL_0b50;
						IL_05b2:
						array3 = playerIds;
						obj7++;
						bool flag14 = playerIds != null;
						obj8 = obj7;
						if (flag14)
						{
							continue;
						}
						goto IL_095a;
						IL_0b50:
						flag = !flag11;
						array5 = playerIds;
						obj14 = 0;
						obj15 = 0;
						goto IL_061f;
					}
					break;
				}
				goto IL_0ad1;
				IL_0a74:
				flag = flag8 | flag7;
				goto IL_099c;
				IL_095a:
				throw new NullReferenceException();
				IL_0ad1:
				if (m_allowTouchInput)
				{
					RewiredPointerInputModule.UnityInputSource unityInputSource = base.defaultInputSource;
					Touch touch = (Touch)0;
					int num6 = 0;
					int num7 = 0;
					RewiredPointerInputModule.UnityInputSource unityInputSource2 = unityInputSource;
					while (true)
					{
						int touchCount = ((ITouchInputSource)unityInputSource2).touchCount;
						if (num6 >= touchCount)
						{
							break;
						}
						RewiredPointerInputModule.UnityInputSource unityInputSource3 = base.defaultInputSource;
						Touch touch2 = ((ITouchInputSource)unityInputSource3).GetTouch(num7);
						TouchPhase phase = touch.phase;
						bool flag15 = phase == TouchPhase.Began;
						if (!flag15)
						{
							TouchPhase phase2 = touch.phase;
							flag15 = phase2 == TouchPhase.Moved;
							if (!flag15)
							{
								TouchPhase phase3 = touch.phase;
								object obj16 = phase3 - 2;
								flag15 = obj16 == null;
							}
						}
						flag = !flag15;
						num7++;
						RewiredPointerInputModule.UnityInputSource unityInputSource4 = base.defaultInputSource;
						bool flag16 = unityInputSource4 != null;
						touch = (Touch)touch2.m_FingerId;
						num6 = num7;
						unityInputSource2 = unityInputSource4;
						if (flag16)
						{
							continue;
						}
						goto IL_095a;
					}
				}
				return flag;
				IL_099c:
				array = playerIds;
				obj++;
				player4 = player;
				obj2 = obj;
				continue;
				IL_0a86:
				flag7 = !flag9;
				if (verticalActionId >= 0 && player.GetButtonDown(verticalActionId))
				{
					flag8 = true;
				}
				else if (verticalActionId >= 0)
				{
					bool negativeButtonDown2 = player.GetNegativeButtonDown(verticalActionId);
					flag8 = negativeButtonDown2;
				}
				else
				{
					flag8 = false;
				}
				goto IL_0a74;
				IL_061f:
				while ((nint)obj15 < array5.Length)
				{
					int[] array6 = playerIds;
					if ((nint)obj14 >= array6.Length)
					{
						goto end_IL_0ab0;
					}
					ReInput.PlayerHelper players3 = ReInput.players;
					Player player5 = players3.GetPlayer(array6[obj14]);
					if (player5 != null && (!usePlayingPlayersOnly || player5.isPlaying))
					{
						int mouseInputSourceCount2 = GetMouseInputSourceCount(array6[obj14]);
						bool flag17 = mouseInputSourceCount2 <= 0;
						int num8 = 0;
						player4 = null;
						if (!flag17)
						{
							while (true)
							{
								IMouseInputSource mouseInputSource2 = GetMouseInputSource(array6[obj14], num8);
								bool flag18 = mouseInputSource2 == null;
								object obj13 = 0;
								if (!flag18)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
									bool flag19 = obj17 != null;
									obj13 = 0;
									if (flag19)
									{
										break;
									}
								}
								player4 = (Player)(num8 + 1);
								bool flag20 = (nint)player4 < mouseInputSourceCount2;
								num8 = (int)player4;
								if (flag20)
								{
									continue;
								}
								goto IL_07ea;
							}
							flag = true;
							break;
						}
					}
					goto IL_07ea;
					IL_07ea:
					array5 = playerIds;
					obj14++;
					bool flag21 = playerIds != null;
					obj15 = obj14;
					if (flag21)
					{
						continue;
					}
					goto IL_095a;
				}
				goto IL_0ad1;
				continue;
				end_IL_0ab0:
				break;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public override void ActivateModule()
	{
		if (m_HasFocus || !ShouldIgnoreEventsOnNoFocus())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			EventSystem eventSystem = ((BaseInputModule)this).m_EventSystem;
			UnityEngine.Object selected = eventSystem.m_CurrentSelected;
			if (eventSystem.m_CurrentSelected == null)
			{
				EventSystem eventSystem2 = ((BaseInputModule)this).m_EventSystem;
				selected = eventSystem2.m_FirstSelected;
			}
			BaseEventData baseEventData = base.GetBaseEventData();
			((BaseInputModule)this).m_EventSystem.SetSelectedGameObject((GameObject)selected, baseEventData);
		}
	}

	public override void DeactivateModule()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		ClearSelection();
	}

	public override void Process()
	{
		//IL_03b8: Expected O, but got I4
		//IL_03c1: Expected O, but got I4
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_0330: Expected O, but got I4
		if (!ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF || (!m_HasFocus && ShouldIgnoreEventsOnNoFocus()) || !base.enabled)
		{
			return;
		}
		GameObject gameObject = base.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			return;
		}
		EventSystem eventSystem = ((BaseInputModule)this).m_EventSystem;
		bool flag2;
		if (eventSystem.m_CurrentSelected != null)
		{
			BaseEventData baseEventData = base.GetBaseEventData();
			EventSystem eventSystem2 = ((BaseInputModule)this).m_EventSystem;
			GameObject currentSelected = eventSystem2.m_CurrentSelected;
			bool flag = ExecuteEvents.Execute(eventSystem2.m_CurrentSelected, baseEventData, ExecuteEvents.s_UpdateSelectedHandler);
			bool used = baseEventData.used;
			flag2 = used;
		}
		else
		{
			flag2 = false;
		}
		EventSystem eventSystem3 = ((BaseInputModule)this).m_EventSystem;
		if (eventSystem3.m_sendNavigationEvents && !flag2 && !SendMoveEventToSelectedObject())
		{
			bool flag3 = SendSubmitEventToSelectedObject();
		}
		if (ProcessTouchEvents() || !isMouseSupported)
		{
			return;
		}
		int[] array = playerIds;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			ReInput.PlayerHelper players = ReInput.players;
			int[] array2 = playerIds;
			Player player = players.GetPlayer(array2[obj]);
			if (player != null && (!usePlayingPlayersOnly || player.isPlaying))
			{
				int[] array3 = playerIds;
				int mouseInputSourceCount = GetMouseInputSourceCount(array3[obj]);
				bool flag4 = mouseInputSourceCount <= 0;
				GameObject currentSelected = null;
				if (!flag4)
				{
					do
					{
						int[] array4 = playerIds;
						ProcessMouseEvent(array4[obj], 0);
						currentSelected = (GameObject)(0 + 1);
					}
					while ((nint)currentSelected < mouseInputSourceCount);
				}
			}
			array = playerIds;
			obj++;
			obj2 = obj;
		}
	}

	private unsafe bool ProcessTouchEvents()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00f7: Expected O, but got Ref
		//IL_0974: Expected I4, but got O
		//IL_0211: Expected F4, but got I
		//IL_054c: Expected O, but got I4
		//IL_0291: Expected O, but got I4
		//IL_02df: Expected O, but got I4
		//IL_05fe: Expected O, but got I4
		//IL_068b: Expected O, but got I4
		//IL_07e8: Expected O, but got I4
		//IL_07a2: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag = !m_allowTouchInput;
		bool result = false;
		if (!flag)
		{
			RewiredPointerInputModule.UnityInputSource unityInputSource = base.defaultInputSource;
			int num = 0;
			int num2 = 0;
			RewiredPointerInputModule.UnityInputSource unityInputSource2 = unityInputSource;
			bool flag2 = false;
			int num3 = 0;
			object obj3 = default(object);
			ref bool pressed = default(ref bool);
			ref bool released = default(ref bool);
			ExecuteEvents.EventFunction<IPointerDownHandler> callbackFunction = default(ExecuteEvents.EventFunction<IPointerDownHandler>);
			while (true)
			{
				int touchCount = ((ITouchInputSource)unityInputSource2).touchCount;
				if ((flag2 ? 1 : 0) >= touchCount)
				{
					break;
				}
				RewiredPointerInputModule.UnityInputSource unityInputSource3 = base.defaultInputSource;
				Touch touch = ((ITouchInputSource)unityInputSource3).GetTouch(num3);
				num2 = touch.m_TapCount;
				float maximumPossiblePressure = touch.m_maximumPossiblePressure;
				_ = touch.m_AzimuthAngle;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A513E0");
				if ((nint)obj3 == 1)
				{
					goto IL_0927;
				}
				Touch touch2 = (Touch)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
				_ = 0;
				_ = touch.m_FingerId;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rax_v18 (UnityEngine.Touch)+10]");
				_ = 0;
				_ = touch.m_TapCount;
				_ = touch.m_maximumPossiblePressure;
				PlayerPointerEventData touchPointerEventData = GetTouchPointerEventData(0, 0, touch2, out pressed, out released);
				if (touchPointerEventData != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
					bool flag3 = (nint)0 == 0;
					ExecuteEvents.EventFunction<IInitializePotentialDragHandler> functor = null;
					BaseEventData eventData = null;
					if (!flag3)
					{
						((PointerEventData)touchPointerEventData)._003CeligibleForClick_003Ek__BackingField = true;
						Vector2 vector = ((global::EDMLXIVQZTAQYUVDbcrQxMhxfKoB)null).ntPWJSIIqsBvZerDgPOJvuYstPhjA(0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+AC]");
						_ = 0;
						((PointerEventData)touchPointerEventData)._003Cdelta_003Ek__BackingField = vector;
						((PointerEventData)touchPointerEventData)._003CpointerPressRaycast_003Ek__BackingField = ((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField;
						((PointerEventData)touchPointerEventData)._003CpressPosition_003Ek__BackingField = ((PointerEventData)touchPointerEventData)._003Cposition_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v26 (Rewired.Integration.UnityUI.PlayerPointerEventData)+60]");
						_ = 0;
						((PointerEventData)touchPointerEventData)._003CuseDragThreshold_003Ek__BackingField = true;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v26 (Rewired.Integration.UnityUI.PlayerPointerEventData)+80]");
						maximumPossiblePressure = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v26 (Rewired.Integration.UnityUI.PlayerPointerEventData)+108]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v26 (Rewired.Integration.UnityUI.PlayerPointerEventData)+70]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v26 (Rewired.Integration.UnityUI.PlayerPointerEventData)+80]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v26 (Rewired.Integration.UnityUI.PlayerPointerEventData)+90]");
						_ = 0;
						HandleMouseTouchDeselectionOnSelectionChanged((GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField, touchPointerEventData);
						bool flag4 = ((PointerEventData)touchPointerEventData)._003CpointerEnter_003Ek__BackingField != (UnityEngine.Object)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField;
						bool flag5 = !flag4;
						object obj4 = 0;
						GameObject gameObject = null;
						GameObject gameObject2 = (GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField;
						if (!flag5)
						{
							HandlePointerExitAndEnter(touchPointerEventData, (GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField);
							((PointerEventData)touchPointerEventData)._003CpointerEnter_003Ek__BackingField = (GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField;
							obj4 = 0;
							gameObject = (GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField;
							gameObject2 = (GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039F1E0");
						GameObject gameObject3 = ExecuteEvents.ExecuteHierarchy((GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField, touchPointerEventData, callbackFunction);
						bool flag6 = gameObject3 == null;
						bool flag7 = !flag6;
						GameObject gameObject4 = gameObject3;
						if (!flag7)
						{
							GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>((GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField);
							gameObject4 = eventHandler;
						}
						ReInput.TimeHelper time = ReInput.time;
						if (time == null)
						{
							goto IL_0966;
						}
						double unscaledTime = time.unscaledTime;
						bool flag8 = gameObject4 == ((PointerEventData)touchPointerEventData)._003ClastPress_003Ek__BackingField;
						if (!flag8)
						{
							((PointerEventData)touchPointerEventData)._003CclickCount_003Ek__BackingField = 1;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,xmm0\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm7,xmm1\"");
							if ((flag8 ? 1 : 0) <= (false ? 1 : 0))
							{
								((PointerEventData)touchPointerEventData)._003CclickCount_003Ek__BackingField = 1;
							}
							else
							{
								int num4 = ((PointerEventData)touchPointerEventData)._003CclickCount_003Ek__BackingField + 1;
								((PointerEventData)touchPointerEventData)._003CclickCount_003Ek__BackingField = num4;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm6\"");
							((PointerEventData)touchPointerEventData)._003CclickTime_003Ek__BackingField = 0f;
							maximumPossiblePressure = (float)unscaledTime;
						}
						touchPointerEventData.pointerPress = gameObject4;
						((PointerEventData)touchPointerEventData)._003CrawPointerPress_003Ek__BackingField = (GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm6\"");
						((PointerEventData)touchPointerEventData)._003CclickTime_003Ek__BackingField = 0f;
						GameObject eventHandler2 = ExecuteEvents.GetEventHandler<IDragHandler>((GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField);
						((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField = eventHandler2;
						bool flag9 = ((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField != null;
						bool flag10 = !flag9;
						num2 = 0;
						functor = null;
						eventData = null;
						if (!flag10)
						{
							GameObject gameObject5 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(null, null, null);
							bool flag11 = ExecuteEvents.Execute(((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField, touchPointerEventData, (ExecuteEvents.EventFunction<IInitializePotentialDragHandler>)(object)gameObject5);
							num2 = 0;
							functor = (ExecuteEvents.EventFunction<IInitializePotentialDragHandler>)(object)gameObject5;
							eventData = touchPointerEventData;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
					if ((nint)0 != 0)
					{
						ExecuteEvents.EventFunction<IPointerUpHandler> functor2 = (ExecuteEvents.EventFunction<IPointerUpHandler>)ExecuteEvents.Execute(null, eventData, functor);
						bool flag12 = ExecuteEvents.Execute(((PointerEventData)touchPointerEventData).m_PointerPress, touchPointerEventData, functor2);
						GameObject eventHandler3 = ExecuteEvents.GetEventHandler<IPointerClickHandler>((GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField);
						if (((PointerEventData)touchPointerEventData).m_PointerPress == eventHandler3 && ((PointerEventData)touchPointerEventData)._003CeligibleForClick_003Ek__BackingField)
						{
							bool flag13 = ExecuteEvents.Execute<IPointerUpHandler>(null, (BaseEventData)(object)eventHandler3, null);
							bool flag14 = ExecuteEvents.Execute(((PointerEventData)touchPointerEventData).m_PointerPress, touchPointerEventData, (ExecuteEvents.EventFunction<IPointerClickHandler>)flag13);
						}
						else if (((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField != null && ((PointerEventData)touchPointerEventData)._003Cdragging_003Ek__BackingField)
						{
							bool flag15 = ExecuteEvents.Execute<IPointerUpHandler>(null, null, null);
							GameObject gameObject6 = ExecuteEvents.ExecuteHierarchy((GameObject)((PointerEventData)touchPointerEventData)._003CpointerCurrentRaycast_003Ek__BackingField, touchPointerEventData, (ExecuteEvents.EventFunction<IDropHandler>)flag15);
						}
						((PointerEventData)touchPointerEventData)._003CeligibleForClick_003Ek__BackingField = false;
						touchPointerEventData.pointerPress = null;
						((PointerEventData)touchPointerEventData)._003CrawPointerPress_003Ek__BackingField = null;
						if (((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField != null && ((PointerEventData)touchPointerEventData)._003Cdragging_003Ek__BackingField)
						{
							ExecuteEvents.EventFunction<IEndDragHandler> functor3 = (ExecuteEvents.EventFunction<IEndDragHandler>)(object)ExecuteEvents.ExecuteHierarchy<IDropHandler>(null, null, null);
							bool flag16 = ExecuteEvents.Execute(((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField, touchPointerEventData, functor3);
						}
						((PointerEventData)touchPointerEventData)._003Cdragging_003Ek__BackingField = false;
						((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField = null;
						bool flag17 = ((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField != null;
						bool flag18 = !flag17;
						ExecuteEvents.EventFunction<IEndDragHandler> functor4 = null;
						if (!flag18)
						{
							ExecuteEvents.EventFunction<IEndDragHandler> eventFunction = (ExecuteEvents.EventFunction<IEndDragHandler>)ExecuteEvents.Execute<IEndDragHandler>(null, null, null);
							bool flag19 = ExecuteEvents.Execute(((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField, touchPointerEventData, eventFunction);
							functor4 = eventFunction;
						}
						((PointerEventData)touchPointerEventData)._003CpointerDrag_003Ek__BackingField = null;
						ExecuteEvents.EventFunction<IPointerExitHandler> callbackFunction2 = (ExecuteEvents.EventFunction<IPointerExitHandler>)ExecuteEvents.Execute(null, null, functor4);
						GameObject gameObject7 = ExecuteEvents.ExecuteHierarchy(((PointerEventData)touchPointerEventData)._003CpointerEnter_003Ek__BackingField, touchPointerEventData, callbackFunction2);
						((PointerEventData)touchPointerEventData)._003CpointerEnter_003Ek__BackingField = null;
						RemovePointerData(touchPointerEventData);
					}
					else
					{
						base.ProcessMove(touchPointerEventData);
						base.ProcessDrag(touchPointerEventData);
					}
					goto IL_0927;
				}
				goto IL_0966;
				IL_0927:
				num3++;
				RewiredPointerInputModule.UnityInputSource unityInputSource4 = base.defaultInputSource;
				num = touch.m_FingerId;
				unityInputSource2 = unityInputSource4;
				flag2 = (byte)num3 != 0;
				continue;
				IL_0966:
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			RewiredPointerInputModule.UnityInputSource unityInputSource5 = base.defaultInputSource;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			object obj6 = default(object);
			object obj5 = obj6 ^ obj6;
			object obj7 = obj6 & obj5;
			bool flag20 = (nint)obj7 < 0;
			bool flag21 = (nint)obj6 < 0;
			bool flag22 = obj6 == null;
			bool flag23 = flag21 == flag20;
			bool flag24 = !flag22;
			result = flag24 & flag23;
		}
		return result;
	}

	private void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
	{
		//IL_051f: Expected I, but got O
		//IL_0320: Expected O, but got I4
		//IL_03ab: Expected O, but got I4
		if (pressed)
		{
			pointerEvent._003CeligibleForClick_003Ek__BackingField = true;
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v64 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v65 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			_ = 0;
			pointerEvent._003Cdelta_003Ek__BackingField = Vector2.zeroVector;
			pointerEvent._003CpointerPressRaycast_003Ek__BackingField = pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField;
			pointerEvent._003CpressPosition_003Ek__BackingField = pointerEvent._003Cposition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pointerEvent @ rdx (UnityEngine.EventSystems.PointerEventData)+60]");
			_ = 0;
			pointerEvent._003CuseDragThreshold_003Ek__BackingField = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pointerEvent @ rdx (UnityEngine.EventSystems.PointerEventData)+108]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pointerEvent @ rdx (UnityEngine.EventSystems.PointerEventData)+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pointerEvent @ rdx (UnityEngine.EventSystems.PointerEventData)+80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pointerEvent @ rdx (UnityEngine.EventSystems.PointerEventData)+90]");
			_ = 0;
			HandleMouseTouchDeselectionOnSelectionChanged((GameObject)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField, pointerEvent);
			if (pointerEvent._003CpointerEnter_003Ek__BackingField != (UnityEngine.Object)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField)
			{
				HandlePointerExitAndEnter(pointerEvent, (GameObject)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField);
				pointerEvent._003CpointerEnter_003Ek__BackingField = (GameObject)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField;
			}
			GameObject gameObject = ExecuteEvents.ExecuteHierarchy((GameObject)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField, pointerEvent, ExecuteEvents.s_PointerDownHandler);
			bool flag = gameObject == null;
			bool flag2 = !flag;
			GameObject gameObject2 = gameObject;
			if (!flag2)
			{
				GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>((GameObject)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField);
				gameObject2 = eventHandler;
			}
			ReInput.TimeHelper time = ReInput.time;
			double unscaledTime = time.unscaledTime;
			bool flag3 = gameObject2 == pointerEvent._003ClastPress_003Ek__BackingField;
			if (!flag3)
			{
				pointerEvent._003CclickCount_003Ek__BackingField = 1;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm2,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm2\"");
				if ((flag3 ? 1 : 0) <= (false ? 1 : 0))
				{
					pointerEvent._003CclickCount_003Ek__BackingField = 1;
				}
				else
				{
					int num3 = pointerEvent._003CclickCount_003Ek__BackingField + 1;
					pointerEvent._003CclickCount_003Ek__BackingField = num3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm6\"");
				pointerEvent._003CclickTime_003Ek__BackingField = 0f;
			}
			pointerEvent.pointerPress = gameObject2;
			pointerEvent._003CrawPointerPress_003Ek__BackingField = (GameObject)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm6\"");
			pointerEvent._003CclickTime_003Ek__BackingField = 0f;
			GameObject eventHandler2 = ExecuteEvents.GetEventHandler<IDragHandler>((GameObject)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField);
			pointerEvent._003CpointerDrag_003Ek__BackingField = eventHandler2;
			if (pointerEvent._003CpointerDrag_003Ek__BackingField != null)
			{
				bool flag4 = ExecuteEvents.Execute(pointerEvent._003CpointerDrag_003Ek__BackingField, pointerEvent, ExecuteEvents.s_InitializePotentialDragHandler);
			}
		}
		if (released)
		{
			bool flag5 = ExecuteEvents.Execute(pointerEvent.m_PointerPress, pointerEvent, ExecuteEvents.s_PointerUpHandler);
			GameObject eventHandler3 = ExecuteEvents.GetEventHandler<IPointerClickHandler>((GameObject)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField);
			if (pointerEvent.m_PointerPress == eventHandler3 && pointerEvent._003CeligibleForClick_003Ek__BackingField)
			{
				bool flag6 = ExecuteEvents.Execute<IPointerUpHandler>(null, (BaseEventData)(object)eventHandler3, null);
				bool flag7 = ExecuteEvents.Execute(pointerEvent.m_PointerPress, pointerEvent, (ExecuteEvents.EventFunction<IPointerClickHandler>)flag6);
			}
			else if (pointerEvent._003CpointerDrag_003Ek__BackingField != null && pointerEvent._003Cdragging_003Ek__BackingField)
			{
				bool flag8 = ExecuteEvents.Execute<IPointerUpHandler>(null, null, null);
				GameObject gameObject3 = ExecuteEvents.ExecuteHierarchy((GameObject)pointerEvent._003CpointerCurrentRaycast_003Ek__BackingField, pointerEvent, (ExecuteEvents.EventFunction<IDropHandler>)flag8);
			}
			pointerEvent._003CeligibleForClick_003Ek__BackingField = false;
			pointerEvent.pointerPress = null;
			pointerEvent._003CrawPointerPress_003Ek__BackingField = null;
			if (pointerEvent._003CpointerDrag_003Ek__BackingField != null && pointerEvent._003Cdragging_003Ek__BackingField)
			{
				ExecuteEvents.EventFunction<IEndDragHandler> functor = (ExecuteEvents.EventFunction<IEndDragHandler>)(object)ExecuteEvents.ExecuteHierarchy<IDropHandler>(null, null, null);
				bool flag9 = ExecuteEvents.Execute(pointerEvent._003CpointerDrag_003Ek__BackingField, pointerEvent, functor);
			}
			pointerEvent._003Cdragging_003Ek__BackingField = false;
			pointerEvent._003CpointerDrag_003Ek__BackingField = null;
			if (pointerEvent._003CpointerDrag_003Ek__BackingField != null)
			{
				bool flag10 = ExecuteEvents.Execute(pointerEvent._003CpointerDrag_003Ek__BackingField, pointerEvent, ExecuteEvents.s_EndDragHandler);
			}
			pointerEvent._003CpointerDrag_003Ek__BackingField = null;
			GameObject gameObject4 = ExecuteEvents.ExecuteHierarchy(pointerEvent._003CpointerEnter_003Ek__BackingField, pointerEvent, ExecuteEvents.s_PointerExitHandler);
			pointerEvent._003CpointerEnter_003Ek__BackingField = null;
		}
	}

	private bool SendSubmitEventToSelectedObject()
	{
		//IL_0069: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_02b9: Expected I4, but got O
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_022a: Expected O, but got I4
		//IL_0237: Expected O, but got I4
		//IL_027c: Expected O, but got I4
		//IL_0289: Expected O, but got I4
		EventSystem eventSystem = ((BaseInputModule)this).m_EventSystem;
		bool flag = eventSystem.m_CurrentSelected == null;
		if (!flag && recompiling == flag)
		{
			BaseEventData baseEventData = base.GetBaseEventData();
			int[] array = playerIds;
			object obj = 0;
			object obj2 = 0;
			while (true)
			{
				if ((nint)obj2 < array.Length)
				{
					ReInput.PlayerHelper players = ReInput.players;
					int[] array2 = playerIds;
					if ((nint)obj >= array2.Length)
					{
						break;
					}
					Player player = players.GetPlayer(array2[obj]);
					if (player == null || (usePlayingPlayersOnly && !player.isPlaying))
					{
						goto IL_01d2;
					}
					GameObject currentSelected;
					ExecuteEvents.EventFunction<ISubmitHandler> functor;
					if (submitActionId < 0 || !player.GetButtonDown(submitActionId))
					{
						if (cancelActionId < 0 || !player.GetButtonDown(cancelActionId))
						{
							goto IL_01d2;
						}
						EventSystem eventSystem2 = ((BaseInputModule)this).m_EventSystem;
						currentSelected = eventSystem2.m_CurrentSelected;
						bool flag2 = ExecuteEvents.Execute<ISubmitHandler>(null, (BaseEventData)cancelActionId, null);
						functor = (ExecuteEvents.EventFunction<ISubmitHandler>)flag2;
					}
					else
					{
						EventSystem eventSystem3 = ((BaseInputModule)this).m_EventSystem;
						currentSelected = eventSystem3.m_CurrentSelected;
						bool flag3 = ExecuteEvents.Execute<ISubmitHandler>(null, (BaseEventData)submitActionId, null);
						functor = (ExecuteEvents.EventFunction<ISubmitHandler>)flag3;
					}
					bool flag4 = ExecuteEvents.Execute(currentSelected, baseEventData, functor);
				}
				return baseEventData.used;
				IL_01d2:
				array = playerIds;
				obj++;
				obj2 = obj;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private Vector2 GetRawMoveVector()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Expected O, but got Unknown
		//IL_013b: Expected F4, but got I4
		//IL_0171: Expected F4, but got I4
		//IL_017f: Expected F4, but got I4
		//IL_0326: Expected F4, but got O
		//IL_018d: Expected F4, but got I4
		//IL_065f: Expected O, but got F4
		//IL_01ab: Expected F4, but got O
		//IL_035a: Expected F4, but got O
		//IL_05f9: Expected O, but got F4
		//IL_03cb: Expected O, but got F4
		//IL_01df: Expected F4, but got O
		//IL_0371: Invalid comparison between F4 and I4
		//IL_0382: Expected F4, but got O
		//IL_0250: Expected O, but got F4
		//IL_03e2: Invalid comparison between I4 and F4
		//IL_03f3: Expected O, but got F4
		//IL_01f6: Invalid comparison between F4 and I4
		//IL_0207: Expected F4, but got O
		//IL_0453: Invalid comparison between F4 and I4
		//IL_0267: Invalid comparison between I4 and F4
		//IL_0278: Expected O, but got F4
		//IL_0419: Expected O, but got F4
		//IL_02d8: Invalid comparison between F4 and I4
		//IL_04ab: Invalid comparison between I4 and F4
		//IL_029e: Expected O, but got F4
		Vector2 result = default(Vector2);
		if (!recompiling)
		{
			Vector2 vector = Vector2.zeroVector;
			int[] array = playerIds;
			object obj = 0;
			object obj2 = 0;
			object obj3 = default(object);
			object obj4 = default(object);
			while (true)
			{
				if ((nint)obj2 < array.Length)
				{
					ReInput.PlayerHelper players = ReInput.players;
					int[] array2 = playerIds;
					if ((nint)obj >= array2.Length)
					{
						break;
					}
					Player player = players.GetPlayer(array2[obj]);
					if (player != null)
					{
						bool flag = !usePlayingPlayersOnly;
						Player player2 = (Player)(object)players;
						if (!flag)
						{
							bool isPlaying = player.isPlaying;
							bool flag2 = !isPlaying;
							player2 = player;
							if (flag2)
							{
								goto IL_052c;
							}
						}
						float num;
						if (horizontalActionId >= 0)
						{
							float axis = player.GetAxis(horizontalActionId);
							num = axis;
							player2 = player;
						}
						else
						{
							num = 0f;
						}
						float num2;
						if (verticalActionId >= 0)
						{
							float axis2 = player.GetAxis(verticalActionId);
							num2 = axis2;
							player2 = player;
						}
						else
						{
							num2 = 0f;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180363600");
						if (obj3 != null)
						{
							num = 0f;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180363600");
						bool flag3 = obj4 == null;
						float num3 = num2;
						if (!flag3)
						{
							num3 = 0f;
						}
						bool flag10;
						if (!moveOneElementPerAxisPress)
						{
							bool flag4 = horizontalActionId < 0;
							float num4 = (float)vector;
							if (!flag4)
							{
								bool button = player.GetButton(horizontalActionId);
								bool flag5 = !button;
								num4 = (float)vector;
								if (!flag5)
								{
									bool flag6 = !(num > 0f);
									num4 = (float)vector;
									if (!flag6)
									{
										num4 = (float)vector + 1f;
									}
								}
							}
							bool flag7 = horizontalActionId < 0;
							vector = (Vector2)num4;
							if (!flag7)
							{
								bool negativeButton = player.GetNegativeButton(horizontalActionId);
								bool flag8 = !negativeButton;
								vector = (Vector2)num4;
								if (!flag8)
								{
									bool flag9 = !(0f > num);
									vector = (Vector2)num4;
									if (!flag9)
									{
										float num5 = num4 - 1f;
										vector = (Vector2)num5;
									}
								}
							}
							if (verticalActionId < 0 || !player.GetButton(verticalActionId) || num3 > 0f)
							{
							}
							if (verticalActionId < 0)
							{
								goto IL_052c;
							}
							flag10 = player.GetNegativeButton(verticalActionId);
						}
						else
						{
							bool flag11 = horizontalActionId < 0;
							float num6 = (float)vector;
							if (!flag11)
							{
								bool buttonDown = player.GetButtonDown(horizontalActionId);
								bool flag12 = !buttonDown;
								num6 = (float)vector;
								if (!flag12)
								{
									bool flag13 = !(num > 0f);
									num6 = (float)vector;
									if (!flag13)
									{
										num6 = (float)vector + 1f;
									}
								}
							}
							bool flag14 = horizontalActionId < 0;
							vector = (Vector2)num6;
							if (!flag14)
							{
								bool negativeButtonDown = player.GetNegativeButtonDown(horizontalActionId);
								bool flag15 = !negativeButtonDown;
								vector = (Vector2)num6;
								if (!flag15)
								{
									bool flag16 = !(0f > num);
									vector = (Vector2)num6;
									if (!flag16)
									{
										float num7 = num6 - 1f;
										vector = (Vector2)num7;
									}
								}
							}
							if (verticalActionId < 0 || !player.GetButtonDown(verticalActionId) || num3 > 0f)
							{
							}
							if (verticalActionId < 0)
							{
								goto IL_052c;
							}
							flag10 = player.GetNegativeButtonDown(verticalActionId);
						}
						if (flag10 && !(0f > num3))
						{
						}
					}
					goto IL_052c;
				}
				return result;
				IL_052c:
				array = playerIds;
				obj++;
				obj2 = obj;
			}
			return (Vector2)new IndexOutOfRangeException();
		}
		return result;
	}

	private bool SendMoveEventToSelectedObject()
	{
		//IL_04a9: Expected I4, but got O
		//IL_00df: Expected O, but got F4
		//IL_0120: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		//IL_0176: Expected F4, but got O
		//IL_0284: Invalid comparison between F4 and I4
		//IL_0295: Invalid comparison between F4 and I4
		//IL_02a6: Invalid comparison between F4 and I4
		//IL_037b: Expected F4, but got O
		//IL_0556: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		//IL_04d8: Expected O, but got I4
		//IL_04f2: Expected O, but got I4
		//IL_030a: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		if (!recompiling)
		{
			ReInput.TimeHelper time = ReInput.time;
			if (time != null)
			{
				double unscaledTime = time.unscaledTime;
				Vector2 rawMoveVector = GetRawMoveVector();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180363600");
				object obj = default(object);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180363600");
					object obj2 = default(object);
					if (obj2 != null)
					{
						m_ConsecutiveMoveCount = 0;
						goto IL_05c7;
					}
				}
				float num2 = default(float);
				float num = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredStandaloneInputModule)+10C]");
				float num3 = num * 0f;
				float num4 = (float)rawMoveVector * (float)m_LastMoveVector;
				Vector2 vector = (Vector2)(num3 + num4);
				bool flag = (nint)vector < 0;
				bool flag2 = (object)vector == null;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				object obj3 = flag4 & flag3;
				CheckButtonOrKeyMovement(out var downHorizontal, out var downVertical);
				object obj4 = downVertical | downHorizontal;
				bool flag5 = !flag2;
				AxisEventData axisEventData2;
				if (obj4 != null)
				{
					AxisEventData axisEventData = base.GetAxisEventData((float)rawMoveVector, num2, 0f);
					if (axisEventData == null)
					{
						goto IL_049b;
					}
					bool flag6;
					if (axisEventData._003CmoveDir_003Ek__BackingField == MoveDirection.Up)
					{
						flag6 = true;
					}
					else
					{
						object obj5 = axisEventData._003CmoveDir_003Ek__BackingField - 3;
						bool flag7 = obj5 == null;
						flag6 = flag7;
					}
					object obj6 = flag6 & downVertical;
					bool flag8 = obj6 == null;
					object obj7 = !flag8;
					axisEventData2 = axisEventData;
					flag5 = true;
					if (obj7 == null)
					{
						if (axisEventData._003CmoveDir_003Ek__BackingField == MoveDirection.Left)
						{
							axisEventData2 = axisEventData;
							flag5 = downHorizontal;
						}
						else
						{
							object obj8 = axisEventData._003CmoveDir_003Ek__BackingField - 2;
							bool flag9 = obj8 == null;
							flag5 = downHorizontal & flag9;
							axisEventData2 = axisEventData;
						}
					}
				}
				else
				{
					axisEventData2 = null;
				}
				if (!flag5)
				{
					bool flag10 = m_RepeatDelay < 0f;
					bool flag11 = m_RepeatDelay == 0f;
					if (m_RepeatDelay > 0f)
					{
						flag10 = (nint)obj3 < 0;
						flag11 = obj3 == null;
						if (!flag11)
						{
							flag10 = m_ConsecutiveMoveCount < 1;
							object obj9 = m_ConsecutiveMoveCount - 1;
							flag11 = obj9 == null;
							if (m_ConsecutiveMoveCount != 1)
							{
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rbx+100h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm8,xmm0\"");
					bool flag12 = !flag10;
					bool flag13 = !flag11;
					object obj10 = flag13 & flag12;
					if (obj10 == null)
					{
						goto IL_05c7;
					}
				}
				bool flag14 = axisEventData2 != null;
				BaseEventData baseEventData = axisEventData2;
				if (!flag14)
				{
					AxisEventData axisEventData3 = base.GetAxisEventData((float)rawMoveVector, num2, 0f);
					bool flag15 = axisEventData3 == null;
					baseEventData = axisEventData3;
					if (flag15)
					{
						goto IL_049b;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v6 (UnityEngine.EventSystems.BaseEventData)+28]");
				if ((nint)0 == 4)
				{
					m_ConsecutiveMoveCount = 0;
				}
				else
				{
					EventSystem eventSystem = ((BaseInputModule)this).m_EventSystem;
					if ((object)((BaseInputModule)this).m_EventSystem == null)
					{
						goto IL_049b;
					}
					bool flag16 = ExecuteEvents.Execute(eventSystem.m_CurrentSelected, baseEventData, ExecuteEvents.s_MoveHandler);
					if (obj3 == null)
					{
						m_ConsecutiveMoveCount = 0;
					}
					if (m_ConsecutiveMoveCount == 0 || m_ConsecutiveMoveCount == 0)
					{
						int consecutiveMoveCount = m_ConsecutiveMoveCount + 1;
						m_ConsecutiveMoveCount = consecutiveMoveCount;
					}
					m_PrevActionTime = unscaledTime;
					m_LastMoveVector = rawMoveVector;
				}
				return baseEventData.used;
			}
			goto IL_049b;
		}
		goto IL_05c7;
		IL_049b:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_05c7:
		return false;
	}

	private unsafe void CheckButtonOrKeyMovement(out bool downHorizontal, out bool downVertical)
	{
		//IL_01ee: Expected O, but got I4
		//IL_01f7: Expected O, but got I4
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_022b: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		ref bool reference = ref *(bool*)null;
		ref bool reference2 = ref *(bool*)null;
		int[] array = playerIds;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			ReInput.PlayerHelper players = ReInput.players;
			int[] array2 = playerIds;
			Player player = players.GetPlayer(array2[obj]);
			if (player != null && (!usePlayingPlayersOnly || player.isPlaying))
			{
				bool flag = (horizontalActionId >= 0 && player.GetButtonDown(horizontalActionId)) || (horizontalActionId >= 0 && player.GetNegativeButtonDown(horizontalActionId));
				object obj3 = downHorizontal | flag;
				reference = ref *(bool*)obj3;
				bool flag2 = (verticalActionId >= 0 && player.GetButtonDown(verticalActionId)) || (verticalActionId >= 0 && player.GetNegativeButtonDown(verticalActionId));
				object obj4 = downVertical | flag2;
				reference2 = ref *(bool*)obj4;
			}
			array = playerIds;
			obj++;
			obj2 = obj;
		}
	}

	private void ProcessMouseEvents()
	{
		//IL_0190: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		int[] array = playerIds;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			ReInput.PlayerHelper players = ReInput.players;
			int[] array2 = playerIds;
			Player player = players.GetPlayer(array2[obj]);
			if (player != null && (!usePlayingPlayersOnly || player.isPlaying))
			{
				int[] array3 = playerIds;
				int mouseInputSourceCount = GetMouseInputSourceCount(array3[obj]);
				bool flag = mouseInputSourceCount <= 0;
				int num = 0;
				if (!flag)
				{
					do
					{
						int[] array4 = playerIds;
						ProcessMouseEvent(array4[obj], 0);
						num = 0 + 1;
					}
					while (num < mouseInputSourceCount);
				}
			}
			array = playerIds;
			obj++;
			obj2 = obj;
		}
	}

	private void ProcessMouseEvent(int playerId, int pointerIndex)
	{
		//IL_03b8: Expected I, but got O
		//IL_0164: Expected O, but got I
		//IL_016d: Expected O, but got I4
		//IL_02e5: Expected O, but got I
		//IL_0271: Expected O, but got I
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		MouseState mousePointerEventData = base.GetMousePointerEventData(playerId, pointerIndex);
		if (mousePointerEventData == null)
		{
			return;
		}
		ButtonState buttonState = mousePointerEventData.GetButtonState(0);
		MouseButtonEventData eventData = buttonState.m_EventData;
		ProcessMousePress(buttonState.m_EventData);
		base.ProcessMove(eventData.buttonData);
		base.ProcessDrag(eventData.buttonData);
		ButtonState buttonState2 = mousePointerEventData.GetButtonState(1);
		ProcessMousePress(buttonState2.m_EventData);
		ButtonState buttonState3 = mousePointerEventData.GetButtonState(1);
		MouseButtonEventData eventData2 = buttonState3.m_EventData;
		base.ProcessDrag(eventData2.buttonData);
		ButtonState buttonState4 = mousePointerEventData.GetButtonState(2);
		ProcessMousePress(buttonState4.m_EventData);
		ButtonState buttonState5 = mousePointerEventData.GetButtonState(2);
		MouseButtonEventData eventData3 = buttonState5.m_EventData;
		base.ProcessDrag(eventData3.buttonData);
		IMouseInputSource mouseInputSource = GetMouseInputSource(playerId, pointerIndex);
		if (mouseInputSource == null)
		{
			return;
		}
		int num = 3;
		while (true)
		{
			nint num2 = (nint)mouseInputSource;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r10_v5 (Il2CppClass<Rewired.UI.IMouseInputSource>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_01a4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r10_v5 (Il2CppClass<Rewired.UI.IMouseInputSource>)+B0]");
			object obj = 0;
			object obj2 = 0;
			while (true)
			{
				object obj3 = obj2 + obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r8_v32+v462 @ rax_v49*8]");
				if (0 == (nint)typeof(IMouseInputSource))
				{
					break;
				}
				obj2++;
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r10_v5 (Il2CppClass<Rewired.UI.IMouseInputSource>)+12E]");
				if ((nint)obj4 < 0)
				{
					continue;
				}
				goto IL_01a4;
			}
			object obj5 = obj2 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r8_v32+8+v519 @ rcx_v38*8]");
			object obj6 = (nint)0 + (nint)3;
			object obj7 = obj6 << 4;
			object obj8 = obj7 + 312;
			object obj9 = obj8 + num2;
			goto IL_01b3;
			IL_01b3:
			int buttonCount = mouseInputSource.buttonCount;
			if (num >= buttonCount)
			{
				break;
			}
			ButtonState buttonState6 = mousePointerEventData.GetButtonState(num);
			ProcessMousePress(buttonState6.m_EventData);
			ButtonState buttonState7 = mousePointerEventData.GetButtonState(num);
			MouseButtonEventData eventData4 = buttonState7.m_EventData;
			base.ProcessDrag(eventData4.buttonData);
			num++;
			continue;
			IL_01a4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
			goto IL_01b3;
		}
		PlayerPointerEventData buttonData = eventData.buttonData;
		object obj10 = ((PointerEventData)buttonData)._003CscrollDelta_003Ek__BackingField * ((PointerEventData)buttonData)._003CscrollDelta_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v29 (Rewired.Integration.UnityUI.PlayerPointerEventData)+140]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v29 (Rewired.Integration.UnityUI.PlayerPointerEventData)+140]");
		object obj11 = num3 * 0;
		object obj12 = obj11 + obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180363600");
		object obj13 = default(object);
		if (obj13 == null)
		{
			PlayerPointerEventData buttonData2 = eventData.buttonData;
			GameObject eventHandler = ExecuteEvents.GetEventHandler<IScrollHandler>((GameObject)((PointerEventData)buttonData2)._003CpointerCurrentRaycast_003Ek__BackingField);
			GameObject gameObject = ExecuteEvents.ExecuteHierarchy(eventHandler, eventData.buttonData, ExecuteEvents.s_ScrollHandler);
		}
	}

	private bool SendUpdateEventToSelectedObject()
	{
		//IL_00c6: Expected I4, but got O
		EventSystem eventSystem = ((BaseInputModule)this).m_EventSystem;
		if ((object)((BaseInputModule)this).m_EventSystem != null)
		{
			if (!(eventSystem.m_CurrentSelected != null))
			{
				return false;
			}
			BaseEventData baseEventData = base.GetBaseEventData();
			EventSystem eventSystem2 = ((BaseInputModule)this).m_EventSystem;
			if ((object)((BaseInputModule)this).m_EventSystem != null)
			{
				bool flag = ExecuteEvents.Execute(eventSystem2.m_CurrentSelected, baseEventData, ExecuteEvents.s_UpdateSelectedHandler);
				if (baseEventData != null)
				{
					return baseEventData.used;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void ProcessMousePress(MouseButtonEventData data)
	{
		//IL_0529: Expected I, but got O
		//IL_05c3: Expected O, but got I
		//IL_00c7: Expected O, but got I
		//IL_02bd: Expected O, but got I
		//IL_02d2: Expected O, but got I
		//IL_0115: Expected O, but got I
		//IL_02f5: Expected O, but got I
		//IL_015b: Expected O, but got I
		//IL_038a: Expected O, but got I
		//IL_01dd: Expected O, but got I
		//IL_0434: Expected O, but got I
		//IL_0364: Expected O, but got I4
		//IL_0364: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_04d7: Expected O, but got I
		//IL_04d7: Expected O, but got I
		//IL_03f8: Expected O, but got I4
		//IL_03f8: Expected O, but got I
		//IL_0515: Expected O, but got I
		//IL_0249: Expected O, but got I
		//IL_04a0: Expected O, but got I
		BaseEventData buttonData = data.buttonData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+180]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+184]");
		IMouseInputSource mouseInputSource = GetMouseInputSource((int)num, 0);
		if (mouseInputSource == null)
		{
			return;
		}
		if (data.buttonState == PointerEventData.FramePressState.Pressed || data.buttonState == PointerEventData.FramePressState.PressedAndReleased)
		{
			_ = 1;
			nint num2 = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v48 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v49 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			_ = 0;
			_ = Vector2.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+104]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+60]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+108]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+90]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
			HandleMouseTouchDeselectionOnSelectionChanged((GameObject)0, buttonData);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
			GameObject gameObject = ExecuteEvents.ExecuteHierarchy((GameObject)0, buttonData, ExecuteEvents.s_PointerDownHandler);
			bool flag = gameObject == null;
			bool flag2 = !flag;
			GameObject gameObject2 = gameObject;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
				GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>((GameObject)0);
				gameObject2 = eventHandler;
			}
			ReInput.TimeHelper time = ReInput.time;
			double unscaledTime = time.unscaledTime;
			GameObject obj = gameObject2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+30]");
			bool flag3 = obj == (UnityEngine.Object)0;
			if (!flag3)
			{
				_ = 1;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm2,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm2\"");
				if ((flag3 ? 1 : 0) <= (false ? 1 : 0))
				{
					_ = 1;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+138]");
					_ = (nint)0 + (nint)1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm6\"");
				_ = 0;
			}
			((PointerEventData)buttonData).pointerPress = gameObject2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm6\"");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
			GameObject eventHandler2 = ExecuteEvents.GetEventHandler<IDragHandler>((GameObject)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+40]");
			if ((UnityEngine.Object)0 != null)
			{
				GameObject functor = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(null, null, null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+40]");
				bool flag4 = ExecuteEvents.Execute((GameObject)0, buttonData, (ExecuteEvents.EventFunction<IInitializePotentialDragHandler>)(object)functor);
			}
		}
		if (data.buttonState != PointerEventData.FramePressState.Released && data.buttonState != PointerEventData.FramePressState.PressedAndReleased)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+28]");
		bool flag5 = ExecuteEvents.Execute((GameObject)0, buttonData, ExecuteEvents.s_PointerUpHandler);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
		GameObject eventHandler3 = ExecuteEvents.GetEventHandler<IPointerClickHandler>((GameObject)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+28]");
		if ((UnityEngine.Object)0 == eventHandler3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+F8]");
			if ((nint)0 != 0)
			{
				bool flag6 = ExecuteEvents.Execute<IPointerUpHandler>(null, (BaseEventData)(object)eventHandler3, null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+28]");
				bool flag7 = ExecuteEvents.Execute((GameObject)0, buttonData, (ExecuteEvents.EventFunction<IPointerClickHandler>)flag6);
				goto IL_0402;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+40]");
		if ((UnityEngine.Object)0 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+145]");
			if ((nint)0 != 0)
			{
				bool flag8 = ExecuteEvents.Execute<IPointerUpHandler>(null, null, null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
				GameObject gameObject3 = ExecuteEvents.ExecuteHierarchy((GameObject)0, buttonData, (ExecuteEvents.EventFunction<IDropHandler>)flag8);
			}
		}
		goto IL_0402;
		IL_0402:
		_ = 0;
		((PointerEventData)buttonData).pointerPress = null;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+40]");
		if ((UnityEngine.Object)0 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+145]");
			if ((nint)0 != 0)
			{
				ExecuteEvents.EventFunction<IEndDragHandler> functor2 = (ExecuteEvents.EventFunction<IEndDragHandler>)(object)ExecuteEvents.ExecuteHierarchy<IDropHandler>(null, null, null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+40]");
				bool flag9 = ExecuteEvents.Execute((GameObject)0, buttonData, functor2);
			}
		}
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+20]");
		if ((UnityEngine.Object)num4 != (UnityEngine.Object)0)
		{
			HandlePointerExitAndEnter((PointerEventData)buttonData, null);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rbx_v2 (UnityEngine.EventSystems.BaseEventData)+50]");
			HandlePointerExitAndEnter((PointerEventData)buttonData, (GameObject)0);
		}
	}

	private void HandleMouseTouchDeselectionOnSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent)
	{
		UnityEngine.Object obj;
		UnityEngine.Object obj2;
		if (m_deselectIfBackgroundClicked && m_deselectBeforeSelecting)
		{
			GameObject eventHandler = ExecuteEvents.GetEventHandler<ISelectHandler>(currentOverGo);
			EventSystem eventSystem = ((BaseInputModule)this).m_EventSystem;
			obj = eventSystem.m_CurrentSelected;
			obj2 = eventHandler;
		}
		else
		{
			GameObject eventHandler2 = ExecuteEvents.GetEventHandler<ISelectHandler>(currentOverGo);
			if (!m_deselectIfBackgroundClicked)
			{
				if (!m_deselectBeforeSelecting || !(eventHandler2 != null))
				{
					return;
				}
				EventSystem eventSystem2 = ((BaseInputModule)this).m_EventSystem;
				obj = eventSystem2.m_CurrentSelected;
			}
			else
			{
				EventSystem eventSystem3 = ((BaseInputModule)this).m_EventSystem;
				if (!(eventHandler2 != eventSystem3.m_CurrentSelected))
				{
					return;
				}
				obj = null;
			}
			obj2 = eventHandler2;
		}
		if (obj2 != obj)
		{
			((BaseInputModule)this).m_EventSystem.SetSelectedGameObject(null, pointerEvent);
		}
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		m_HasFocus = hasFocus;
	}

	private bool ShouldIgnoreEventsOnNoFocus()
	{
		//IL_0056: Expected I4, but got O
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			ReInput.ConfigHelper configuration = ReInput.configuration;
			if (configuration != null)
			{
				return configuration.ignoreInputWhenAppNotInFocus;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return true;
	}

	protected override void OnDestroy()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		Action value = OnRewiredInitialized;
		ReInput.InitializedEvent -= value;
		Action value2 = OnRewiredShutDown;
		ReInput.ShutDownEvent -= value2;
		Action value3 = OnEditorRecompile;
		ReInput.EditorRecompileEvent -= value3;
	}

	protected override bool IsDefaultPlayer(int playerId)
	{
		//IL_0038: Expected O, but got I4
		//IL_0273: Expected O, but got I4
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_025b: Expected I4, but got O
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_020d: Expected O, but got I4
		if (playerIds != null && ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			object obj = 0;
			do
			{
				object obj2 = 0;
				while (true)
				{
					int[] array = playerIds;
					if ((nint)obj2 >= array.Length)
					{
						break;
					}
					ReInput.PlayerHelper players = ReInput.players;
					int[] array2 = playerIds;
					Player player;
					if ((nint)obj2 < array2.Length)
					{
						player = players.GetPlayer(array2[obj2]);
						if (player == null)
						{
							goto IL_017a;
						}
						if ((nint)obj < 1)
						{
							if (!usePlayingPlayersOnly)
							{
								goto IL_0159;
							}
							if (!player.isPlaying)
							{
								goto IL_017a;
							}
						}
						if ((nint)obj < 2)
						{
							goto IL_0159;
						}
						goto IL_01c7;
					}
					goto IL_024d;
					IL_017a:
					obj2++;
					continue;
					IL_01c7:
					int[] array3 = playerIds;
					if ((nint)obj2 < array3.Length)
					{
						object obj3 = array3[obj2] - playerId;
						return obj3 == null;
					}
					goto IL_024d;
					IL_0159:
					if (!player.controllers.hasMouse)
					{
						goto IL_017a;
					}
					goto IL_01c7;
					IL_024d:
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					return (byte)(int)ex != 0;
				}
				obj++;
			}
			while ((nint)obj < 3);
		}
		return false;
	}

	private void InitializeRewired()
	{
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			Action value = OnRewiredShutDown;
			ReInput.ShutDownEvent -= value;
			Action value2 = OnRewiredShutDown;
			ReInput.ShutDownEvent += value2;
			Action value3 = OnEditorRecompile;
			ReInput.EditorRecompileEvent -= value3;
			Action value4 = OnEditorRecompile;
			ReInput.EditorRecompileEvent += value4;
			SetupRewiredVars();
		}
		else
		{
			Debug.LogError("Rewired is not initialized! Are you missing a Rewired Input Manager in your scene?");
		}
	}

	private void SetupRewiredVars()
	{
		//IL_00a3: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		if (!ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			return;
		}
		SetUpRewiredActions();
		int num3;
		if (!useAllRewiredGamePlayers)
		{
			int[] array = rewiredPlayerIds;
			int capacity = default(int);
			List<int> list = new List<int>(capacity);
			capacity = array.Length + 1;
			int[] array2 = rewiredPlayerIds;
			int num = 0;
			object obj = 0;
			int num2 = 0;
			while (num2 < array2.Length)
			{
				ReInput.PlayerHelper players = ReInput.players;
				int[] array3 = rewiredPlayerIds;
				Player player = players.GetPlayer(array3[num]);
				if (player != null)
				{
					int id = player.id;
					if (!list.Contains(id))
					{
						int id2 = player.id;
						list.Add(id2);
						int id3 = player.id;
						if (id3 == 9999999)
						{
							obj = 1;
						}
					}
				}
				array2 = rewiredPlayerIds;
				num++;
				bool flag = rewiredPlayerIds != null;
				num2 = num;
				if (!flag)
				{
					throw new NullReferenceException();
				}
			}
			if (useRewiredSystemPlayer && obj == null)
			{
				ReInput.PlayerHelper players2 = ReInput.players;
				Player systemPlayer = players2.GetSystemPlayer();
				int id4 = systemPlayer.id;
				list.Insert(0, id4);
			}
			int[] array4 = list.ToArray();
			playerIds = array4;
			num3 = 0;
		}
		else
		{
			IList<Player> list2;
			if (useRewiredSystemPlayer)
			{
				ReInput.PlayerHelper players3 = ReInput.players;
				list2 = players3.AllPlayers;
			}
			else
			{
				ReInput.PlayerHelper players4 = ReInput.players;
				list2 = players4.Players;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			object obj2 = default(object);
			int[] array5 = new int[obj2];
			playerIds = array5;
			int num4 = 0;
			int num5 = 0;
			while (true)
			{
				int count = list2.Count;
				bool flag2 = num5 >= count;
				num3 = 0;
				if (flag2)
				{
					break;
				}
				int[] array6 = playerIds;
				Player player2 = list2.get_Item(num4);
				int id5 = player2.id;
				int num6 = num4 + 1;
				array6[num4] = id5;
				num4 = num6;
				num5 = num6;
			}
		}
		if (!ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			return;
		}
		List<IMouseInputSource> mouseInputSourcesList = base.m_MouseInputSourcesList;
		int version = mouseInputSourcesList._version + 1;
		mouseInputSourcesList._version = version;
		mouseInputSourcesList._size = num3;
		if (mouseInputSourcesList._size > 0)
		{
			Array.Clear(mouseInputSourcesList._items, 0, mouseInputSourcesList._size);
		}
		List<Rewired.Components.PlayerMouse> list3 = playerMice;
		for (int num7 = num3; num7 < list3._size; num7 = num3)
		{
			Rewired.Components.PlayerMouse playerMouse = playerMice.get_Item(num3);
			if (!UnityTools.IsNullOrDestroyed(playerMouse))
			{
				AddMouseInputSource(playerMouse);
			}
			list3 = playerMice;
			num3++;
		}
	}

	private void SetUpRewiredPlayerMice()
	{
		if (!ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			return;
		}
		List<IMouseInputSource> mouseInputSourcesList = base.m_MouseInputSourcesList;
		int version = mouseInputSourcesList._version + 1;
		mouseInputSourcesList._version = version;
		mouseInputSourcesList._size = 0;
		if (mouseInputSourcesList._size > 0)
		{
			Array.Clear(mouseInputSourcesList._items, 0, mouseInputSourcesList._size);
		}
		List<Rewired.Components.PlayerMouse> list = playerMice;
		int num = 0;
		for (int num2 = 0; num2 < list._size; num2 = num)
		{
			Rewired.Components.PlayerMouse playerMouse = playerMice.get_Item(num);
			if (!UnityTools.IsNullOrDestroyed(playerMouse))
			{
				AddMouseInputSource(playerMouse);
			}
			list = playerMice;
			num++;
		}
	}

	private void SetUpRewiredActions()
	{
		//IL_008b: Expected O, but got I
		//IL_009b: Expected O, but got I
		//IL_00b4: Expected I4, but got I8
		//IL_011b: Expected O, but got I
		//IL_012b: Expected O, but got I
		//IL_0144: Expected I4, but got I8
		//IL_01ab: Expected O, but got I
		//IL_01bb: Expected O, but got I
		//IL_01d4: Expected I4, but got I8
		//IL_0238: Expected O, but got I
		//IL_0248: Expected O, but got I
		//IL_0261: Expected I4, but got I8
		if (!ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			return;
		}
		if (setActionsById)
		{
			ReInput.MappingHelper mapping = ReInput.mapping;
			InputAction action = mapping.GetAction(horizontalActionId);
			if (action != null)
			{
				m_HorizontalAxis = action._name;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v45+B8]");
				object obj2 = 0;
				m_HorizontalAxis = (string)obj2;
				horizontalActionId = -1;
			}
			ReInput.MappingHelper mapping2 = ReInput.mapping;
			InputAction action2 = mapping2.GetAction(verticalActionId);
			if (action2 != null)
			{
				m_VerticalAxis = action2._name;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v41+B8]");
				object obj4 = 0;
				m_VerticalAxis = (string)obj4;
				verticalActionId = -1;
			}
			ReInput.MappingHelper mapping3 = ReInput.mapping;
			InputAction action3 = mapping3.GetAction(submitActionId);
			if (action3 != null)
			{
				m_SubmitButton = action3._name;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v37+B8]");
				object obj6 = 0;
				m_SubmitButton = (string)obj6;
				submitActionId = -1;
			}
			ReInput.MappingHelper mapping4 = ReInput.mapping;
			InputAction action4 = mapping4.GetAction(cancelActionId);
			if (action4 != null)
			{
				m_CancelButton = action4._name;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v33+B8]");
			object obj8 = 0;
			m_CancelButton = (string)obj8;
			cancelActionId = -1;
		}
		else
		{
			ReInput.MappingHelper mapping5 = ReInput.mapping;
			int actionId = mapping5.GetActionId(m_HorizontalAxis);
			horizontalActionId = actionId;
			ReInput.MappingHelper mapping6 = ReInput.mapping;
			int actionId2 = mapping6.GetActionId(m_VerticalAxis);
			verticalActionId = actionId2;
			ReInput.MappingHelper mapping7 = ReInput.mapping;
			int actionId3 = mapping7.GetActionId(m_SubmitButton);
			submitActionId = actionId3;
			ReInput.MappingHelper mapping8 = ReInput.mapping;
			int actionId4 = mapping8.GetActionId(m_CancelButton);
			cancelActionId = actionId4;
		}
	}

	private bool GetButton(Player player, int actionId)
	{
		//IL_0064: Expected I4, but got O
		if (actionId >= 0)
		{
			if (player != null)
			{
				return player.GetButton(actionId);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private bool GetButtonDown(Player player, int actionId)
	{
		//IL_0064: Expected I4, but got O
		if (actionId >= 0)
		{
			if (player != null)
			{
				return player.GetButtonDown(actionId);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private bool GetNegativeButton(Player player, int actionId)
	{
		//IL_0064: Expected I4, but got O
		if (actionId >= 0)
		{
			if (player != null)
			{
				return player.GetNegativeButton(actionId);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private bool GetNegativeButtonDown(Player player, int actionId)
	{
		//IL_0064: Expected I4, but got O
		if (actionId >= 0)
		{
			if (player != null)
			{
				return player.GetNegativeButtonDown(actionId);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private float GetAxis(Player player, int actionId)
	{
		//IL_0039: Expected F4, but got I4
		if (actionId >= 0)
		{
			return player.GetAxis(actionId);
		}
		return 0f;
	}

	private void CheckEditorRecompile()
	{
		if (recompiling && ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			recompiling = false;
			InitializeRewired();
		}
	}

	private void OnEditorRecompile()
	{
		recompiling = true;
		ClearRewiredVars();
	}

	private void ClearRewiredVars()
	{
		int[] array = playerIds;
		Array.Clear(playerIds, 0, array.Length);
		List<IMouseInputSource> mouseInputSourcesList = base.m_MouseInputSourcesList;
		int version = mouseInputSourcesList._version + 1;
		mouseInputSourcesList._version = version;
		mouseInputSourcesList._size = 0;
		if (mouseInputSourcesList._size > 0)
		{
			Array.Clear(mouseInputSourcesList._items, 0, mouseInputSourcesList._size);
		}
	}

	private bool DidAnyMouseMove()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0218: Expected I4, but got O
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		int[] array = playerIds;
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		object obj7 = default(object);
		while (true)
		{
			if ((nint)obj2 < array.Length)
			{
				int[] array2 = playerIds;
				if ((nint)obj >= array2.Length)
				{
					break;
				}
				ReInput.PlayerHelper players = ReInput.players;
				Player player = players.GetPlayer(array2[obj]);
				if (player != null && (!usePlayingPlayersOnly || player.isPlaying))
				{
					int mouseInputSourceCount = GetMouseInputSourceCount(array2[obj]);
					bool flag = mouseInputSourceCount <= 0;
					int num = 0;
					obj3 = obj3;
					obj4 = obj4;
					int num2 = 0;
					if (!flag)
					{
						bool flag2;
						do
						{
							IMouseInputSource mouseInputSource = GetMouseInputSource(array2[obj], num2);
							if (mouseInputSource != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								object obj5 = obj6 * obj6;
								obj3 = obj7 * obj7;
								obj4 = obj5 + obj3;
								if ((nint)obj4 > 0)
								{
									return true;
								}
							}
							num = num2 + 1;
							flag2 = num < mouseInputSourceCount;
							num2 = num;
						}
						while (flag2);
					}
				}
				array = playerIds;
				obj++;
				obj2 = obj;
				continue;
			}
			return false;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private bool GetMouseButtonDownOnAnyMouse(int buttonIndex)
	{
		//IL_01c2: Expected O, but got I4
		//IL_01cb: Expected O, but got I4
		//IL_01de: Expected I4, but got O
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		int[] array = playerIds;
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while (true)
		{
			if ((nint)obj2 < array.Length)
			{
				int[] array2 = playerIds;
				if ((nint)obj >= array2.Length)
				{
					break;
				}
				ReInput.PlayerHelper players = ReInput.players;
				Player player = players.GetPlayer(array2[obj]);
				if (player != null && (!usePlayingPlayersOnly || player.isPlaying))
				{
					int mouseInputSourceCount = GetMouseInputSourceCount(array2[obj]);
					bool flag = mouseInputSourceCount <= 0;
					int num = 0;
					int num2 = 0;
					if (!flag)
					{
						bool flag2;
						do
						{
							IMouseInputSource mouseInputSource = GetMouseInputSource(array2[obj], num2);
							if (mouseInputSource != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
								if (obj3 != null)
								{
									return true;
								}
							}
							num = num2 + 1;
							flag2 = num < mouseInputSourceCount;
							num2 = num;
						}
						while (flag2);
					}
				}
				array = playerIds;
				obj++;
				obj2 = obj;
				continue;
			}
			return false;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private void OnRewiredInitialized()
	{
		InitializeRewired();
	}

	private void OnRewiredShutDown()
	{
		ClearRewiredVars();
	}
}
