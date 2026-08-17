using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data;

public class UserDataStore_PlayerPrefs : UserDataStore
{
	private class ControllerAssignmentSaveInfo
	{
		public class PlayerInfo
		{
			public int id;

			public bool hasKeyboard;

			public bool hasMouse;

			public JoystickInfo[] joysticks;

			public int joystickCount
			{
				get
				{
					if (joysticks != null)
					{
						JoystickInfo[] array = joysticks;
						return array.Length;
					}
					return 0;
				}
			}

			public int IndexOfJoystick(int joystickId)
			{
				//IL_00ea: Expected I4, but got I8
				//IL_00fd: Expected I4, but got O
				JoystickInfo[] array = joysticks;
				bool flag = joysticks == null;
				int i = 0;
				if (!flag)
				{
					for (; i < array.Length; i++)
					{
						if (joysticks != null)
						{
							if (array[i] == null)
							{
								continue;
							}
							JoystickInfo joystickInfo = array[i];
							if (joystickInfo.id != joystickId)
							{
								continue;
							}
							goto IL_00fd;
						}
						NullReferenceException ex = new NullReferenceException();
						return (int)ex;
					}
				}
				i = -1;
				goto IL_00fd;
				IL_00fd:
				return i;
			}

			public bool ContainsJoystick(int joystickId)
			{
				//IL_0024: Expected O, but got I4
				//IL_00ea: Expected O, but got I8
				//IL_0114: Unknown result type (might be due to invalid IL or missing references)
				//IL_0119: Expected I4, but got Unknown
				//IL_00fd: Expected I4, but got O
				//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d8: Expected O, but got Unknown
				JoystickInfo[] array = joysticks;
				bool flag = joysticks == null;
				object obj = 0;
				if (!flag)
				{
					for (; (nint)obj < array.Length; obj++)
					{
						if (joysticks != null)
						{
							if (array[obj] == null)
							{
								continue;
							}
							JoystickInfo joystickInfo = array[obj];
							if (joystickInfo.id != joystickId)
							{
								continue;
							}
							goto IL_00fd;
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
				}
				obj = 4294967295L;
				goto IL_00fd;
				IL_00fd:
				object obj2 = obj >> 31;
				return (byte)(obj2 ^ 1) != 0;
			}
		}

		public class JoystickInfo
		{
			public Guid instanceGuid;

			public string hardwareIdentifier;

			public int id;
		}

		public PlayerInfo[] players;

		public int playerCount
		{
			get
			{
				if (players != null)
				{
					PlayerInfo[] array = players;
					return array.Length;
				}
				return 0;
			}
		}

		public ControllerAssignmentSaveInfo()
		{
		}

		public ControllerAssignmentSaveInfo(int playerCount)
		{
			//IL_002e: Expected O, but got I4
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Expected O, but got Unknown
			//IL_0058: Expected I, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			PlayerInfo[] array = new PlayerInfo[playerCount];
			players = array;
			if (playerCount <= 0)
			{
				return;
			}
			object obj = 0;
			object obj2 = default(object);
			while (true)
			{
				PlayerInfo[] array2 = players;
				PlayerInfo playerInfo = new PlayerInfo();
				if (playerInfo != null)
				{
					nint num = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					if (obj2 == null)
					{
						break;
					}
				}
				array2[obj] = playerInfo;
				obj++;
				if ((nint)obj >= playerCount)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
			object obj3 = default(object);
			throw obj3;
		}

		public int IndexOfPlayer(int playerId)
		{
			//IL_00ea: Expected I4, but got I8
			//IL_00fd: Expected I4, but got O
			PlayerInfo[] array = players;
			bool flag = players == null;
			int i = 0;
			if (!flag)
			{
				for (; i < array.Length; i++)
				{
					if (players != null)
					{
						if (array[i] == null)
						{
							continue;
						}
						PlayerInfo playerInfo = array[i];
						if (playerInfo.id != playerId)
						{
							continue;
						}
						goto IL_00fd;
					}
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
			}
			i = -1;
			goto IL_00fd;
			IL_00fd:
			return i;
		}

		public bool ContainsPlayer(int playerId)
		{
			//IL_0024: Expected O, but got I4
			//IL_00ea: Expected O, but got I8
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected I4, but got Unknown
			//IL_00fd: Expected I4, but got O
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			PlayerInfo[] array = players;
			bool flag = players == null;
			object obj = 0;
			if (!flag)
			{
				for (; (nint)obj < array.Length; obj++)
				{
					if (players != null)
					{
						if (array[obj] == null)
						{
							continue;
						}
						PlayerInfo playerInfo = array[obj];
						if (playerInfo.id != playerId)
						{
							continue;
						}
						goto IL_00fd;
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
			}
			obj = 4294967295L;
			goto IL_00fd;
			IL_00fd:
			object obj2 = obj >> 31;
			return (byte)(obj2 ^ 1) != 0;
		}
	}

	private class JoystickAssignmentHistoryInfo
	{
		public readonly Joystick joystick;

		public readonly int oldJoystickId;

		public JoystickAssignmentHistoryInfo(Joystick joystick, int oldJoystickId)
		{
			if (joystick != null)
			{
				this.joystick = joystick;
				this.oldJoystickId = oldJoystickId;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			ArgumentNullException ex = new ArgumentNullException("joystick");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	[Serializable]
	private class ControllerElementByRoleMap
	{
		[Serializable]
		public struct Entry
		{
			public int actionId;

			public ControllerElementType elementType;

			public AxisRange axisRange;

			public bool invert;

			public Pole axisContribution;

			public unsafe bool TryGetElementAssignment(ControllerType controllerType, Controller.Element targetElement, out ElementAssignment assignment)
			{
				//IL_021b: Expected I4, but got O
				int id;
				Pole pole;
				bool flag;
				ControllerElementType controllerElementType;
				ControllerElementType type;
				ref ElementAssignment reference;
				if (targetElement != null)
				{
					if (targetElement.type != elementType)
					{
						if (elementType == ControllerElementType.Axis)
						{
							if (targetElement.type == ControllerElementType.Button)
							{
								ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
								if (this.axisRange != AxisRange.Full || !invert)
								{
									elementIdentifier = targetElement.elementIdentifier;
									if (elementIdentifier == null)
									{
										goto IL_020d;
									}
								}
								id = elementIdentifier._id;
								pole = Pole.Positive;
								flag = false;
								controllerElementType = targetElement.type;
								goto IL_0245;
							}
						}
						else if (elementType == ControllerElementType.Button && targetElement.type == ControllerElementType.Axis)
						{
							type = targetElement.type;
							ControllerElementIdentifier elementIdentifier2 = targetElement.elementIdentifier;
							if (elementIdentifier2 == null)
							{
								goto IL_020d;
							}
							id = elementIdentifier2._id;
							pole = Pole.Negative;
							flag = false;
							goto IL_0299;
						}
						reference = ref *(ElementAssignment*)null;
						_ = 0;
						_ = 0;
						return false;
					}
					type = targetElement.type;
					ControllerElementIdentifier elementIdentifier3 = targetElement.elementIdentifier;
					if (elementIdentifier3 != null)
					{
						id = elementIdentifier3._id;
						pole = (Pole)this.axisRange;
						flag = false;
						goto IL_0299;
					}
				}
				goto IL_020d;
				IL_0299:
				controllerElementType = type;
				goto IL_0245;
				IL_020d:
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
				IL_0245:
				AxisRange axisRange = default(AxisRange);
				KeyCode keyboardKey = default(KeyCode);
				ModifierKeyFlags modifierKeyFlags = default(ModifierKeyFlags);
				int num = default(int);
				ElementAssignment elementAssignment = ElementAssignment.CompleteAssignment(controllerType, controllerElementType, id, axisRange, keyboardKey, modifierKeyFlags, num, pole, flag);
				reference = ref *(ElementAssignment*)(int)elementAssignment.type;
				_ = elementAssignment.keyboardKey;
				_ = elementAssignment.invert;
				return true;
			}

			public override string ToString()
			{
				//IL_004a: Expected I4, but got O
				//IL_0084: Expected I4, but got O
				//IL_00e3: Expected I4, but got O
				StringBuilder stringBuilder = new StringBuilder();
				if (stringBuilder != null)
				{
					StringBuilder stringBuilder2 = stringBuilder.Append("actionId: ");
					StringBuilder stringBuilder3 = stringBuilder.Append(actionId);
					StringBuilder stringBuilder4 = stringBuilder.Append("\nelementType: ");
					object obj = default(object);
					object value = (ControllerElementType)obj;
					StringBuilder stringBuilder5 = stringBuilder.Append(value);
					StringBuilder stringBuilder6 = stringBuilder.Append("\naxisRange: ");
					object obj2 = default(object);
					object value2 = (AxisRange)obj2;
					StringBuilder stringBuilder7 = stringBuilder.Append(value2);
					StringBuilder stringBuilder8 = stringBuilder.Append("\ninvert: ");
					StringBuilder stringBuilder9 = stringBuilder.Append(invert);
					StringBuilder stringBuilder10 = stringBuilder.Append("\naxisContribution: ");
					object obj3 = default(object);
					object value3 = (Pole)obj3;
					StringBuilder stringBuilder11 = stringBuilder.Append(value3);
					return stringBuilder.ToString();
				}
				return (string)(object)new NullReferenceException();
			}
		}

		public string role;

		public List<Entry> data;

		public ControllerElementByRoleMap()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			List<Entry> list = new List<Entry>();
			data = list;
		}

		public unsafe void Add(ActionElementMap elementMap)
		{
			//IL_0037: Expected O, but got I
			//IL_008c: Expected O, but got I
			//IL_00ac: Expected O, but got I
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_0075: Expected O, but got Ref
			List<Entry> list = data;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v3+18]");
			if (num >= 0)
			{
				object obj2 = default(object);
				list.AddWithResize((Entry)(&obj2));
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
			object obj3 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
			object obj4 = (nint)0 * (nint)4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
			object obj5 = 0 + obj4;
			_ = elementMap._actionId;
			_ = elementMap._axisContribution;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = stringBuilder.Append("role: ");
			StringBuilder stringBuilder3 = stringBuilder.Append(role);
			StringBuilder stringBuilder4 = stringBuilder.Append("\nentries:");
			int value;
			if (data != null)
			{
				List<Entry> list = data;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v27 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
				value = 0;
			}
			else
			{
				value = 0;
			}
			StringBuilder stringBuilder5 = stringBuilder.Append(value);
			StringBuilder stringBuilder6 = stringBuilder.Append("\n");
			if (data != null)
			{
				List<Entry> list2 = data;
				int num = 0;
				int num2 = 0;
				object obj = default(object);
				object obj2 = default(object);
				while (true)
				{
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v18 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
					if ((nint)num3 >= (nint)0)
					{
						break;
					}
					StringBuilder stringBuilder7 = stringBuilder.Append("Entry[");
					StringBuilder stringBuilder8 = stringBuilder.Append(num);
					StringBuilder stringBuilder9 = stringBuilder.Append("]:\n");
					if (data != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18112EC00");
						object value2 = (Entry)obj;
						StringBuilder stringBuilder10 = stringBuilder.Append(value2);
						list2 = data;
						num++;
						obj = obj2;
						num2 = num;
						continue;
					}
					return (string)(object)new NullReferenceException();
				}
			}
			return stringBuilder.ToString();
		}

		public string ToJson()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1817B2820");
			string result = default(string);
			return result;
		}

		public static ControllerElementByRoleMap FromJson(string role, string json)
		{
			ControllerElementByRoleMap controllerElementByRoleMap = JsonParser.FromJson<ControllerElementByRoleMap>(json);
			if (controllerElementByRoleMap != null)
			{
				controllerElementByRoleMap.role = role;
			}
			return controllerElementByRoleMap;
		}
	}

	public enum ActionMappingSaveMode
	{
		ByController,
		ByControllerElementRole
	}

	private sealed class _003C_003Ec__DisplayClass86_0
	{
		public Joystick joystick;

		internal bool _003CLoadJoystickAssignmentsNow_003Eb__0(JoystickAssignmentHistoryInfo x)
		{
			//IL_0053: Expected I4, but got O
			if (x != null)
			{
				object obj = (object)x.joystick - (object)joystick;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass86_1
	{
		public ControllerAssignmentSaveInfo.JoystickInfo joystickInfo;

		internal bool _003CLoadJoystickAssignmentsNow_003Eb__1(JoystickAssignmentHistoryInfo x)
		{
			//IL_007f: Expected I4, but got O
			//IL_005d: Expected O, but got I4
			if (x != null)
			{
				ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = this.joystickInfo;
				if (this.joystickInfo != null)
				{
					object obj = x.oldJoystickId - joystickInfo.id;
					return obj == null;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass86_2
	{
		public Joystick match;

		internal bool _003CLoadJoystickAssignmentsNow_003Eb__2(JoystickAssignmentHistoryInfo x)
		{
			//IL_0053: Expected I4, but got O
			if (x != null)
			{
				object obj = (object)x.joystick - (object)match;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003CLoadJoystickAssignmentsDeferred_003Ed__88 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UserDataStore_PlayerPrefs _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CLoadJoystickAssignmentsDeferred_003Ed__88(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_009c: Expected I4, but got I8
			//IL_0128: Expected I4, but got O
			UserDataStore_PlayerPrefs userDataStore_PlayerPrefs = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					userDataStore_PlayerPrefs.deferredJoystickAssignmentLoadPending = true;
					WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
					_003C_003E2__current = waitForEndOfFrame;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_011a;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
				{
					if ((object)_003C_003E4__this == null)
					{
						goto IL_011a;
					}
					bool flag = _003C_003E4__this.LoadJoystickAssignmentsNow(null);
					bool flag2 = _003C_003E4__this.SaveControllerAssignments();
					userDataStore_PlayerPrefs.deferredJoystickAssignmentLoadPending = false;
				}
			}
			return false;
			IL_011a:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private const string thisScriptName = "UserDataStore_PlayerPrefs";

	private const string logPrefix = "Rewired: ";

	private const string playerPrefsKeySuffix_controllerAssignments = "ControllerAssignments";

	private const int controllerMapPPKeyVersion_original = 0;

	private const int controllerMapPPKeyVersion_includeDuplicateJoystickIndex = 1;

	private const int controllerMapPPKeyVersion_supportDisconnectedControllers = 2;

	private const int controllerMapPPKeyVersion_includeFormatVersion = 2;

	private const int controllerMapPPKeyVersion = 2;

	private const int controllerElementByRoleMapPPKeyVersion = 0;

	private bool isEnabled = true;

	private bool loadDataOnStart;

	private bool loadJoystickAssignments;

	private bool loadKeyboardAssignments;

	private bool loadMouseAssignments = true;

	private ActionMappingSaveMode _actionMappingSaveMode;

	private string playerPrefsKeyPrefix = "RewiredSaveData";

	[NonSerialized]
	private bool allowImpreciseJoystickAssignmentMatching = true;

	[NonSerialized]
	private bool deferredJoystickAssignmentLoadPending;

	[NonSerialized]
	private bool wasJoystickEverDetected;

	[NonSerialized]
	private List<int> __allActionIds;

	[NonSerialized]
	private string __allActionIdsString;

	[NonSerialized]
	private readonly StringBuilder _sb;

	[NonSerialized]
	private Dictionary<string, ControllerElementByRoleMap> _tempElementByRoleMaps;

	[NonSerialized]
	private Dictionary<string, bool> _tempElementByRoleMapsEnabled;

	public bool IsEnabled
	{
		get
		{
			return isEnabled;
		}
		set
		{
			isEnabled = value;
		}
	}

	public bool LoadDataOnStart
	{
		get
		{
			return loadDataOnStart;
		}
		set
		{
			loadDataOnStart = value;
		}
	}

	public bool LoadJoystickAssignments
	{
		get
		{
			return loadJoystickAssignments;
		}
		set
		{
			loadJoystickAssignments = value;
		}
	}

	public bool LoadKeyboardAssignments
	{
		get
		{
			return loadKeyboardAssignments;
		}
		set
		{
			loadKeyboardAssignments = value;
		}
	}

	public bool LoadMouseAssignments
	{
		get
		{
			return loadMouseAssignments;
		}
		set
		{
			loadMouseAssignments = value;
		}
	}

	public ActionMappingSaveMode actionMappingSaveMode
	{
		get
		{
			return _actionMappingSaveMode;
		}
		set
		{
			_actionMappingSaveMode = value;
		}
	}

	public string PlayerPrefsKeyPrefix
	{
		get
		{
			return playerPrefsKeyPrefix;
		}
		set
		{
			playerPrefsKeyPrefix = value;
		}
	}

	private string playerPrefsKey_controllerAssignments
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172327]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return string.Format("{0}_{1}", playerPrefsKeyPrefix, "ControllerAssignments");
		}
	}

	private bool loadControllerAssignments
	{
		get
		{
			if (!loadKeyboardAssignments && !loadMouseAssignments)
			{
				return loadJoystickAssignments;
			}
			return true;
		}
	}

	private List<int> allActionIds
	{
		get
		{
			//IL_011f: Expected O, but got I
			//IL_0154: Expected O, but got I
			//IL_01c3: Expected O, but got I
			if (__allActionIds == null)
			{
				List<int> list = new List<int>();
				ReInput.MappingHelper mapping = ReInput.mapping;
				if (mapping != null)
				{
					IList<InputAction> actions = mapping.Actions;
					if (actions != null)
					{
						int num = 0;
						int num2 = 0;
						while (true)
						{
							int count = actions.Count;
							if (num < count)
							{
								InputAction inputAction = actions.get_Item(num2);
								if (inputAction == null || list == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+10]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+10]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+18]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+18]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ r8_v6+18]");
								if (num3 >= 0)
								{
									list.AddWithResize(inputAction._id);
									num2++;
									num = num2;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+18]");
									object obj3 = (nint)0 + (nint)1;
									num2++;
									_ = inputAction._id;
									num = num2;
								}
								continue;
							}
							__allActionIds = list;
							return list;
						}
					}
				}
				return (List<int>)(object)new NullReferenceException();
			}
			return __allActionIds;
		}
	}

	private string allActionIdsString
	{
		get
		{
			if (string.IsNullOrEmpty(__allActionIdsString))
			{
				StringBuilder stringBuilder = new StringBuilder();
				List<int> list = allActionIds;
				bool flag = list == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					while (true)
					{
						int num3 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v6 (System.Collections.Generic.List`1<System.Int32>)+18]");
						if ((nint)num3 < (nint)0)
						{
							int value;
							if (num > 0)
							{
								if (stringBuilder == null)
								{
									break;
								}
								StringBuilder stringBuilder2 = stringBuilder.Append(",");
								value = list.get_Item(num);
							}
							else
							{
								value = list.get_Item(num);
								if (stringBuilder == null)
								{
									break;
								}
							}
							StringBuilder stringBuilder3 = stringBuilder.Append(value);
							num++;
							num2 = num;
							continue;
						}
						if (stringBuilder == null)
						{
							break;
						}
						string _allActionIdsString = stringBuilder.ToString();
						__allActionIdsString = _allActionIdsString;
						return __allActionIdsString;
					}
				}
				return (string)(object)new NullReferenceException();
			}
			return __allActionIdsString;
		}
	}

	public override void Save()
	{
		if (isEnabled)
		{
			SaveAll();
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not save any data.", this);
		}
	}

	public override void SaveControllerData(int playerId, ControllerType controllerType, int controllerId)
	{
		if (isEnabled)
		{
			SaveControllerMaps(playerId, controllerType, controllerId);
			if (controllerType == ControllerType.Joystick)
			{
				SaveJoystickCalibrationData(controllerId);
			}
			PlayerPrefs.Save();
			PlayerPrefs.Save();
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not save any data.", this);
		}
	}

	public override void SaveControllerData(ControllerType controllerType, int controllerId)
	{
		if (isEnabled)
		{
			if (controllerType == ControllerType.Joystick)
			{
				SaveJoystickCalibrationData(controllerId);
			}
			PlayerPrefs.Save();
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not save any data.", this);
		}
	}

	public override void SavePlayerData(int playerId)
	{
		if (isEnabled)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(playerId);
			SavePlayerDataNow(player);
			PlayerPrefs.Save();
			OnControllerMapsSaved(player);
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not save any data.", this);
		}
	}

	public override void SaveInputBehavior(int playerId, int behaviorId)
	{
		if (isEnabled)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(playerId);
			if (player != null)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				InputBehavior inputBehavior = mapping.GetInputBehavior(playerId, behaviorId);
				if (inputBehavior != null)
				{
					string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey(player, inputBehavior._id);
					string value = inputBehavior.ToXmlString();
					PlayerPrefs.SetString(inputBehaviorPlayerPrefsKey, value);
					PlayerPrefs.Save();
				}
			}
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not save any data.", this);
		}
	}

	public override void Load()
	{
		if (isEnabled)
		{
			int num = LoadAll();
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not load any data.", this);
		}
	}

	public override void LoadControllerData(int playerId, ControllerType controllerType, int controllerId)
	{
		if (isEnabled)
		{
			int num = LoadControllerMaps(playerId, controllerType, controllerId);
			RefreshLayoutManager(playerId);
			if (controllerType == ControllerType.Joystick)
			{
				int num2 = LoadJoystickCalibrationData(controllerId);
			}
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not load any data.", this);
		}
	}

	public override void LoadControllerData(ControllerType controllerType, int controllerId)
	{
		if (isEnabled)
		{
			if (controllerType == ControllerType.Joystick)
			{
				int num = LoadJoystickCalibrationData(controllerId);
			}
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not load any data.", this);
		}
	}

	public override void LoadPlayerData(int playerId)
	{
		if (isEnabled)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(playerId);
			int num = LoadPlayerDataNow(player);
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not load any data.", this);
		}
	}

	public override void LoadInputBehavior(int playerId, int behaviorId)
	{
		//IL_0107: Expected O, but got I
		//IL_0117: Expected O, but got I
		//IL_00ea: Expected O, but got I
		//IL_0134: Expected O, but got I
		if (isEnabled)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(playerId);
			if (player == null)
			{
				return;
			}
			ReInput.MappingHelper mapping = ReInput.mapping;
			InputBehavior inputBehavior = mapping.GetInputBehavior(playerId, behaviorId);
			if (inputBehavior == null)
			{
				return;
			}
			string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey(player, inputBehavior._id);
			string text2;
			if (PlayerPrefs.HasKey(inputBehaviorPlayerPrefsKey))
			{
				string text = PlayerPrefs.GetString(inputBehaviorPlayerPrefsKey);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				text2 = text;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v8+B8]");
				object obj2 = 0;
				text2 = (string)obj2;
			}
			if (text2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v8+B8]");
				object obj3 = 0;
				if (text2 != (string)obj3)
				{
					bool flag = inputBehavior.ImportXmlString(text2);
				}
			}
		}
		else
		{
			Debug.LogWarning("Rewired: UserDataStore_PlayerPrefs is disabled and will not load any data.", this);
		}
	}

	protected override void OnInitialize()
	{
		if (!loadDataOnStart)
		{
			return;
		}
		Load();
		if (loadKeyboardAssignments || loadMouseAssignments || loadJoystickAssignments)
		{
			ReInput.ControllerHelper controllers = ReInput.controllers;
			int joystickCount = controllers.joystickCount;
			if (joystickCount > 0)
			{
				wasJoystickEverDetected = true;
				bool flag = SaveControllerAssignments();
			}
		}
	}

	protected override void OnControllerConnected(ControllerStatusChangedEventArgs args)
	{
		if (!isEnabled || args.TBJGBmgQOKlmSbcCWSMuasdljEDyA != ControllerType.Joystick)
		{
			return;
		}
		int num = LoadJoystickData(args.iXAVgsIWgELasbcfAfmXauTcmuqDA);
		if (loadDataOnStart)
		{
			if (!loadJoystickAssignments)
			{
				goto IL_0100;
			}
			if (!wasJoystickEverDetected)
			{
				_003CLoadJoystickAssignmentsDeferred_003Ed__88 obj = new _003CLoadJoystickAssignmentsDeferred_003Ed__88(0);
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj);
			}
		}
		if (loadJoystickAssignments && !deferredJoystickAssignmentLoadPending)
		{
			bool flag = SaveControllerAssignments();
		}
		goto IL_0100;
		IL_0100:
		wasJoystickEverDetected = true;
	}

	protected override void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
	{
		if (isEnabled && args.TBJGBmgQOKlmSbcCWSMuasdljEDyA == ControllerType.Joystick)
		{
			SaveJoystickData(args.iXAVgsIWgELasbcfAfmXauTcmuqDA);
		}
	}

	protected override void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
		if (isEnabled && (loadKeyboardAssignments || loadMouseAssignments || loadJoystickAssignments))
		{
			bool flag = SaveControllerAssignments();
		}
	}

	public override void SaveControllerMap(int playerId, ControllerMap controllerMap)
	{
		if (controllerMap != null)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(playerId);
			if (player != null)
			{
				SaveControllerMap(player, controllerMap);
			}
		}
	}

	public unsafe override ControllerMap LoadControllerMap(int playerId, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		//IL_006f: Expected O, but got Ref
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			ControllerMap player = (ControllerMap)(object)players.GetPlayer(playerId);
			object obj = default(object);
			int layoutId2 = default(int);
			if (player != null)
			{
				return LoadControllerMap((Player)(object)player, (ControllerIdentifier)(&obj), categoryId, layoutId2);
			}
			return player;
		}
		return (ControllerMap)(object)new NullReferenceException();
	}

	private int LoadAll()
	{
		//IL_016f: Expected I4, but got O
		bool flag2;
		if (!loadKeyboardAssignments && !loadMouseAssignments)
		{
			bool flag = !loadJoystickAssignments;
			flag2 = false;
			if (flag)
			{
				goto IL_0066;
			}
		}
		bool flag3 = LoadControllerAssignmentsNow();
		flag2 = flag3;
		goto IL_0066;
		IL_0066:
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			IList<Player> allPlayers = players.AllPlayers;
			if (allPlayers != null)
			{
				int num = 0;
				int num2 = 0;
				while (true)
				{
					int count = allPlayers.Count;
					if (num >= count)
					{
						break;
					}
					Player player = allPlayers.get_Item(num2);
					int num3 = LoadPlayerDataNow(player);
					flag2 = (byte)((flag2 ? 1u : 0u) + (uint)num3) != 0;
					num2++;
					num = num2;
				}
				int num4 = LoadAllJoystickCalibrationData();
				return num4 + (flag2 ? 1 : 0);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int LoadPlayerDataNow(int playerId)
	{
		//IL_0062: Expected I4, but got O
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			Player player = players.GetPlayer(playerId);
			return LoadPlayerDataNow(player);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private unsafe int LoadPlayerDataNow(Player player)
	{
		//IL_0231: Expected I4, but got O
		//IL_00d7: Expected O, but got I4
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected I4, but got Unknown
		//IL_00f6: Expected O, but got Ref
		if (player != null)
		{
			int id = player.id;
			int num = LoadInputBehaviors(id);
			int id2 = player.id;
			int num2 = LoadControllerMaps(id2, ControllerType.Keyboard, 0);
			int id3 = player.id;
			int num3 = LoadControllerMaps(id3, ControllerType.Mouse, 0);
			if (player.controllers != null)
			{
				IList<Joystick> joysticks = player.controllers.Joysticks;
				if (joysticks != null)
				{
					object obj = num3 + num2;
					int num4 = obj + num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					IEnumerator<Joystick> enumerator = default(IEnumerator<Joystick>);
					object obj2 = (object)(&enumerator);
					int num5 = 0;
					UserDataStore_PlayerPrefs userDataStore_PlayerPrefs = null;
					object obj3 = default(object);
					while (true)
					{
						if (enumerator != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							if (obj3 != null)
							{
								bool flag = enumerator == null;
								userDataStore_PlayerPrefs = null;
								if (!flag)
								{
									Joystick current = enumerator.Current;
									int id4 = player.id;
									num5 = current.id;
									int num6 = LoadControllerMaps(id4, ControllerType.Joystick, current.id);
									num4 += num6;
									continue;
								}
								throw new NullReferenceException();
							}
							if (obj2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
							}
							break;
						}
						throw new NullReferenceException();
					}
					int id5 = player.id;
					RefreshLayoutManager(id5);
					return num4;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		return 0;
	}

	private int LoadAllJoystickCalibrationData()
	{
		//IL_017a: Expected I4, but got O
		//IL_012f: Expected O, but got I
		//IL_013f: Expected O, but got I
		ReInput.ControllerHelper controllers = ReInput.controllers;
		if (controllers != null)
		{
			IList<Joystick> joysticks = controllers.Joysticks;
			if (joysticks != null)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				while (true)
				{
					int count = joysticks.Count;
					if (num >= count)
					{
						break;
					}
					Joystick joystick = joysticks.get_Item(num3);
					if (joystick != null)
					{
						string joystickCalibrationMapPlayerPrefsKey = GetJoystickCalibrationMapPlayerPrefsKey(joystick);
						string xmlString;
						if (PlayerPrefs.HasKey(joystickCalibrationMapPlayerPrefsKey))
						{
							xmlString = PlayerPrefs.GetString(joystickCalibrationMapPlayerPrefsKey);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rax_v19+B8]");
							object obj2 = 0;
							xmlString = (string)obj2;
						}
						bool flag = joystick.ImportCalibrationMapFromXmlString(xmlString);
						bool flag2 = !flag;
						bool flag3 = !flag2;
						num2 += (flag3 ? 1 : 0);
						num3++;
						num = num3;
					}
					else
					{
						num3++;
						num = num3;
					}
				}
				return num2;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int LoadJoystickCalibrationData(Joystick joystick)
	{
		//IL_0078: Expected O, but got I
		//IL_0088: Expected O, but got I
		if (joystick != null)
		{
			string joystickCalibrationMapPlayerPrefsKey = GetJoystickCalibrationMapPlayerPrefsKey(joystick);
			string xmlString;
			if (PlayerPrefs.HasKey(joystickCalibrationMapPlayerPrefsKey))
			{
				xmlString = PlayerPrefs.GetString(joystickCalibrationMapPlayerPrefsKey);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v8+B8]");
				object obj2 = 0;
				xmlString = (string)obj2;
			}
			if (joystick.ImportCalibrationMapFromXmlString(xmlString))
			{
				return 1;
			}
		}
		return 0;
	}

	private int LoadJoystickCalibrationData(int joystickId)
	{
		//IL_00e5: Expected I4, but got O
		//IL_00b4: Expected O, but got I
		//IL_00c4: Expected O, but got I
		ReInput.ControllerHelper controllers = ReInput.controllers;
		if (controllers != null)
		{
			Joystick joystick = controllers.GetJoystick(joystickId);
			if (joystick != null)
			{
				string joystickCalibrationMapPlayerPrefsKey = GetJoystickCalibrationMapPlayerPrefsKey(joystick);
				string xmlString;
				if (PlayerPrefs.HasKey(joystickCalibrationMapPlayerPrefsKey))
				{
					xmlString = PlayerPrefs.GetString(joystickCalibrationMapPlayerPrefsKey);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v12+B8]");
					object obj2 = 0;
					xmlString = (string)obj2;
				}
				bool flag = joystick.ImportCalibrationMapFromXmlString(xmlString);
				bool flag2 = !flag;
				return (!flag2) ? 1 : 0;
			}
			return 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int LoadJoystickData(int joystickId)
	{
		//IL_01c6: Expected I4, but got O
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			IList<Player> allPlayers = players.AllPlayers;
			if (allPlayers != null)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				while (true)
				{
					int count = allPlayers.Count;
					if (num < count)
					{
						Player player = allPlayers.get_Item(num2);
						if (player == null || player.controllers == null)
						{
							break;
						}
						if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
						{
							int id = player.id;
							int num4 = LoadControllerMaps(id, ControllerType.Joystick, joystickId);
							num3 += num4;
							int id2 = player.id;
							RefreshLayoutManager(id2);
						}
						num2++;
						num = num2;
						continue;
					}
					int num5 = LoadJoystickCalibrationData(joystickId);
					return num5 + num3;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int LoadControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
	{
		int num = LoadControllerMaps(playerId, controllerType, controllerId);
		RefreshLayoutManager(playerId);
		bool flag = controllerType != ControllerType.Joystick;
		int num2 = 0;
		if (!flag)
		{
			num2 = LoadJoystickCalibrationData(controllerId);
		}
		return num2 + num;
	}

	private int LoadControllerDataNow(ControllerType controllerType, int controllerId)
	{
		if (controllerType == ControllerType.Joystick)
		{
			return LoadJoystickCalibrationData(controllerId);
		}
		return 0;
	}

	private unsafe int LoadControllerMaps(int playerId, ControllerType controllerType, int controllerId)
	{
		//IL_1488: Expected O, but got I4
		//IL_0194: Expected O, but got I4
		//IL_019d: Expected O, but got I4
		//IL_01e6: Expected I, but got O
		//IL_02a9: Expected I4, but got O
		//IL_021d: Expected O, but got I
		//IL_1511: Expected O, but got I4
		//IL_02e9: Expected I4, but got O
		//IL_05c7: Expected O, but got I4
		//IL_05dd: Expected O, but got I
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Expected O, but got Unknown
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Expected O, but got Unknown
		//IL_0334: Expected I4, but got O
		//IL_0381: Expected I4, but got O
		//IL_03c6: Expected I4, but got O
		//IL_062f: Expected I4, but got O
		//IL_0424: Expected I4, but got O
		//IL_042c: Expected I4, but got O
		//IL_14ec: Expected O, but got I
		//IL_044f: Expected O, but got I
		//IL_045f: Expected O, but got I
		//IL_0488: Expected O, but got Ref
		//IL_04ab: Expected O, but got I
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_068f: Expected O, but got Unknown
		//IL_06b6: Expected I4, but got O
		//IL_06be: Expected I4, but got O
		//IL_06e5: Expected I4, but got O
		//IL_04ef: Expected I4, but got O
		//IL_0524: Expected I4, but got O
		//IL_053c: Expected O, but got I
		//IL_08e3: Expected O, but got Ref
		//IL_0563: Expected O, but got I
		//IL_058f: Expected O, but got I
		//IL_095d: Expected I4, but got O
		//IL_075c: Expected I4, but got O
		//IL_0764: Expected I4, but got O
		//IL_091f: Expected O, but got I4
		//IL_07ac: Expected I4, but got O
		//IL_1321: Expected O, but got I
		//IL_1331: Expected O, but got I
		//IL_1341: Expected O, but got I
		//IL_07e4: Expected I4, but got O
		//IL_0b38: Expected O, but got I4
		//IL_081a: Expected I4, but got O
		//IL_0acf: Expected O, but got I
		//IL_0adf: Expected O, but got I
		//IL_0aef: Expected O, but got I
		//IL_0b9b: Expected I4, but got O
		//IL_0a81: Expected O, but got I4
		//IL_086c: Expected I4, but got O
		//IL_0874: Expected I4, but got O
		//IL_0c35: Expected O, but got I4
		//IL_0c47: Expected O, but got I4
		//IL_0e27: Expected O, but got I
		//IL_0e37: Expected O, but got I
		//IL_0e4f: Expected O, but got I
		//IL_0e62: Expected I, but got O
		//IL_1737: Expected O, but got I
		//IL_174d: Expected O, but got Ref
		//IL_0c84: Expected I4, but got O
		//IL_0c8c: Expected I4, but got O
		//IL_181e: Expected O, but got I4
		//IL_12da: Expected O, but got I
		//IL_0cdb: Expected I, but got O
		//IL_12a2: Expected I4, but got O
		//IL_12a7: Expected I, but got O
		//IL_162b: Expected O, but got I4
		//IL_0ed8: Expected O, but got I4
		//IL_0ee0: Expected I4, but got O
		//IL_0d64: Expected I4, but got O
		//IL_0f0e: Expected O, but got I4
		//IL_0f3b: Expected I4, but got O
		//IL_0daa: Expected I, but got O
		//IL_0de3: Expected O, but got I4
		//IL_0f7b: Expected O, but got I4
		//IL_0f83: Expected I4, but got O
		//IL_0fb9: Expected O, but got I4
		//IL_0fc1: Expected I4, but got O
		//IL_0ff1: Expected O, but got I
		//IL_105a: Expected O, but got I
		//IL_10a8: Expected O, but got I
		//IL_10c7: Expected O, but got I4
		//IL_1844: Expected O, but got I
		//IL_113b: Expected O, but got I4
		//IL_1143: Expected I4, but got O
		//IL_114b: Expected O, but got Ref
		//IL_166d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1672: Expected O, but got Unknown
		//IL_116a: Expected O, but got Ref
		//IL_1183: Expected O, but got I4
		//IL_118c: Expected O, but got I4
		//IL_1199: Expected I, but got O
		//IL_11a1: Expected O, but got Ref
		//IL_11df: Expected I, but got O
		//IL_11e7: Expected O, but got Ref
		//IL_120d: Expected O, but got I
		//IL_1228: Expected O, but got I
		//IL_169f: Expected O, but got I4
		//IL_16a8: Expected O, but got I4
		//IL_16b9: Expected O, but got I4
		//IL_16c8: Expected O, but got I4
		//IL_1285: Expected O, but got I4
		ReInput.PlayerHelper players = ReInput.players;
		bool flag = players == null;
		int num = controllerId;
		ControllerType controllerType2 = controllerType;
		ReInput.MappingHelper mappingHelper = null;
		int num2 = default(int);
		nint num13;
		object obj21;
		if (!flag)
		{
			Player player = players.GetPlayer(num2);
			if (player == null)
			{
				goto IL_146a;
			}
			ReInput.ControllerHelper controllers = ReInput.controllers;
			bool flag2 = controllers == null;
			num = controllerId;
			controllerType2 = ControllerType.Keyboard;
			mappingHelper = null;
			if (!flag2)
			{
				Controller controller = controllers.GetController(controllerType, controllerId);
				if (controller == null)
				{
					goto IL_146a;
				}
				ReInput.MappingHelper mapping = ReInput.mapping;
				bool flag3 = mapping == null;
				num = 0;
				num2 = (int)controllerType;
				controllerType2 = (ControllerType)controllerId;
				mappingHelper = null;
				if (!flag3)
				{
					IList<InputMapCategory> mapCategories = mapping.MapCategories;
					bool flag4 = mapCategories == null;
					num = 0;
					num2 = 0;
					controllerType2 = (ControllerType)controllerId;
					mappingHelper = mapping;
					if (!flag4)
					{
						bool value = false;
						ActionElementMap result = null;
						ActionElementMap actionElementMap = null;
						Dictionary<object, object>.Enumerator enumerator = (Dictionary<object, object>.Enumerator)0;
						Dictionary<object, object>.Enumerator enumerator2 = (Dictionary<object, object>.Enumerator)0;
						int num3 = 0;
						Controller controller2 = controller;
						num = 0;
						Player player2 = player;
						IList<InputMapCategory> list = mapCategories;
						int num4 = 0;
						int num5 = 0;
						object obj = default(object);
						object obj8 = default(object);
						object obj9 = default(object);
						ControllerIdentifier controllerIdentifier = default(ControllerIdentifier);
						int num12 = default(int);
						Controller.Element element = default(Controller.Element);
						int layoutId = default(int);
						Dictionary<string, ControllerElementByRoleMap> elementByRoleMaps = default(Dictionary<string, ControllerElementByRoleMap>);
						object obj13 = default(object);
						Dictionary<object, object>.Enumerator enumerator6 = default(Dictionary<object, object>.Enumerator);
						object obj15 = default(object);
						object obj20 = default(object);
						ControllerIdentifier controllerIdentifier3 = default(ControllerIdentifier);
						ControllerIdentifier controllerIdentifier4 = default(ControllerIdentifier);
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							if (num4 < (nint)obj)
							{
								nint num6 = (nint)list;
								int num7 = num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r10_v13 (Il2CppClass<System.Collections.Generic.IList`1<Rewired.InputMapCategory>>)+12E]");
								if ((nint)num7 >= (nint)0)
								{
									goto IL_025c;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r10_v13 (Il2CppClass<System.Collections.Generic.IList`1<Rewired.InputMapCategory>>)+B0]");
								object obj2 = 0;
								int num8 = num5;
								while (true)
								{
									object obj3 = num8 + num8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ r8_v62+v1693 @ rax_v145*8]");
									if (0 == (nint)typeof(IList<InputMapCategory>))
									{
										break;
									}
									num8++;
									int num9 = num8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r10_v13 (Il2CppClass<System.Collections.Generic.IList`1<Rewired.InputMapCategory>>)+12E]");
									if ((nint)num9 < (nint)0)
									{
										continue;
									}
									goto IL_025c;
								}
								object obj4 = num8 + num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ r8_v62+8+v1753 @ rcx_v108*8]");
								object obj5 = (nint)0 << 4;
								object obj6 = obj5 + 312;
								object obj7 = obj6 + num6;
								goto IL_026b;
							}
							return num3;
							IL_026b:
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1750 @ rax_v43+8]");
							controllerType2 = ControllerType.Keyboard;
							InputMapCategory inputMapCategory = list.get_Item(num4);
							bool flag5 = inputMapCategory == null;
							num = (int)typeof(IList<InputMapCategory>);
							num2 = num4;
							mappingHelper = (ReInput.MappingHelper)(object)list;
							if (flag5)
							{
								break;
							}
							bool flag6 = !((InputCategory)inputMapCategory)._userAssignable;
							num = (int)typeof(IList<InputMapCategory>);
							if (!flag6)
							{
								ReInput.MappingHelper mapping2 = ReInput.mapping;
								ControllerType type = controller2.type;
								bool flag7 = mapping2 == null;
								num = (int)typeof(IList<InputMapCategory>);
								num2 = 0;
								mappingHelper = (ReInput.MappingHelper)(object)controller2;
								if (flag7)
								{
									break;
								}
								IList<InputLayout> list2 = mapping2.MapLayouts(type);
								bool flag8 = list2 == null;
								num = (int)typeof(IList<InputMapCategory>);
								num2 = (int)type;
								controllerType2 = ControllerType.Keyboard;
								mappingHelper = mapping2;
								if (flag8)
								{
									break;
								}
								Dictionary<object, object>.Enumerator enumerator3 = (Dictionary<object, object>.Enumerator)actionElementMap;
								int num10 = num3;
								num = (int)typeof(IList<InputMapCategory>);
								int num11 = num5;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
									if (num11 >= (nint)obj8)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
									Dictionary<object, object>.Enumerator enumerator5;
									Dictionary<object, object>.Enumerator enumerator4;
									if (_actionMappingSaveMode == ActionMappingSaveMode.ByController)
									{
										bool flag9 = obj9 == null;
										num = num11;
										num2 = (int)typeof(IList<InputLayout>);
										controllerType2 = (ControllerType)list2;
										mappingHelper = null;
										if (flag9)
										{
											goto end_IL_178d;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+80]");
										enumerator4 = (Dictionary<object, object>.Enumerator)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+90]");
										enumerator2 = (Dictionary<object, object>.Enumerator)0;
										num = ((InputCategory)inputMapCategory)._id;
										ControllerMap controllerMap = LoadControllerMap(player2, (ControllerIdentifier)(&controllerIdentifier), ((InputCategory)inputMapCategory)._id, num12);
										bool flag10 = controllerMap == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+80]");
										enumerator5 = (Dictionary<object, object>.Enumerator)0;
										controllerIdentifier = controller2.oTTDACSTacXivteChZwMofyljqVj;
										if (!flag10)
										{
											mappingHelper = (ReInput.MappingHelper)(object)player2.controllers;
											bool flag11 = player2.controllers == null;
											num2 = (int)player2;
											controllerType2 = (ControllerType)(int)(&controllerIdentifier);
											if (flag11)
											{
												goto end_IL_178d;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v18 (Rewired.ReInput+MappingHelper)+60]");
											bool flag12 = (nint)0 == 0;
											num2 = (int)player2;
											controllerType2 = (ControllerType)(int)(&controllerIdentifier);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v18 (Rewired.ReInput+MappingHelper)+60]");
											mappingHelper = (ReInput.MappingHelper)0;
											if (flag12)
											{
												goto end_IL_178d;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v18 (Rewired.ReInput+MappingHelper)+60]");
											((Player.ControllerHelper.MapHelper)0).AddMap(controller2, controllerMap);
											num3++;
											num11++;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+80]");
											enumerator5 = (Dictionary<object, object>.Enumerator)0;
											controllerIdentifier = controller2.oTTDACSTacXivteChZwMofyljqVj;
											num10 = num3;
											num = 0;
											num4 = num4;
											continue;
										}
										goto IL_154e;
									}
									bool flag13 = _actionMappingSaveMode != ActionMappingSaveMode.ByControllerElementRole;
									num13 = num11;
									ElementAssignment typeFromHandle = (ElementAssignment)typeof(IList<InputLayout>);
									controllerType2 = (ControllerType)list2;
									int num15;
									object obj10;
									ControllerMap controllerMap3;
									object obj11;
									ControllerMap map2;
									if (!flag13)
									{
										Dictionary<string, ControllerElementByRoleMap> dictionary;
										if (_tempElementByRoleMaps != null)
										{
											dictionary = _tempElementByRoleMaps;
										}
										else
										{
											Dictionary<string, ControllerElementByRoleMap> dictionary2 = (_tempElementByRoleMaps = new Dictionary<string, ControllerElementByRoleMap>());
											mappingHelper = (ReInput.MappingHelper)(this + 88);
											bool flag14 = dictionary2 == null;
											dictionary = dictionary2;
											num = num11;
											num2 = (int)dictionary2;
											controllerType2 = (ControllerType)list2;
											if (flag14)
											{
												goto end_IL_178d;
											}
										}
										dictionary.Clear();
										num = num11;
										controllerType2 = (ControllerType)list2;
										int num14 = num5;
										while (true)
										{
											int elementCount = controller2.elementCount;
											if (num14 >= elementCount)
											{
												break;
											}
											IList<Controller.Element> elements = controller2.Elements;
											bool flag15 = elements == null;
											num2 = 0;
											mappingHelper = (ReInput.MappingHelper)(object)controller2;
											if (flag15)
											{
												goto end_IL_178d;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
											bool flag16 = element == null;
											num = num14;
											num2 = (int)typeof(IList<Controller.Element>);
											controllerType2 = (ControllerType)elements;
											mappingHelper = null;
											if (flag16)
											{
												goto end_IL_178d;
											}
											ControllerElementIdentifier elementIdentifier = element.elementIdentifier;
											bool flag17 = elementIdentifier == null;
											num = num14;
											num2 = 0;
											controllerType2 = (ControllerType)elements;
											mappingHelper = (ReInput.MappingHelper)(object)element;
											if (flag17)
											{
												goto end_IL_178d;
											}
											bool flag18 = string.IsNullOrEmpty(elementIdentifier._role);
											num = num14;
											controllerType2 = (ControllerType)elements;
											if (!flag18)
											{
												bool flag19 = obj9 == null;
												num = num14;
												num2 = 0;
												controllerType2 = (ControllerType)elements;
												mappingHelper = (ReInput.MappingHelper)(object)elementIdentifier._role;
												if (flag19)
												{
													goto end_IL_178d;
												}
												bool flag20 = LoadControllerElementMapByRole(player, controller2, elementIdentifier._role, num12, layoutId, elementByRoleMaps);
												num = (int)elementIdentifier._role;
												controllerType2 = (ControllerType)controller2;
											}
											num14++;
										}
										bool flag21 = obj9 == null;
										num2 = 0;
										mappingHelper = (ReInput.MappingHelper)(object)controller2;
										if (flag21)
										{
											goto end_IL_178d;
										}
										num = ((InputCategory)inputMapCategory)._id;
										ControllerMap controllerMap2 = LoadControllerMap(player, (ControllerIdentifier)(&controllerIdentifier), ((InputCategory)inputMapCategory)._id, num12);
										ControllerMap controllerMap4;
										if (controllerMap2 != null)
										{
											num15 = num11;
											controllerMap3 = controllerMap2;
											obj10 = 1;
											controllerType2 = (ControllerType)(int)(&controllerIdentifier);
											controllerMap4 = controllerMap2;
										}
										else
										{
											Player.ControllerHelper controllers2 = player.controllers;
											bool flag22 = player.controllers == null;
											num2 = (int)player;
											controllerType2 = (ControllerType)(int)(&controllerIdentifier);
											mappingHelper = (ReInput.MappingHelper)(object)this;
											if (flag22)
											{
												goto end_IL_178d;
											}
											ControllerType type2 = controller2.type;
											bool flag23 = controllers2.maps == null;
											num2 = 0;
											controllerType2 = (ControllerType)(int)(&controllerIdentifier);
											mappingHelper = (ReInput.MappingHelper)(object)controller2;
											if (flag23)
											{
												goto end_IL_178d;
											}
											num = ((InputCategory)inputMapCategory)._id;
											ControllerMap map = controllers2.maps.GetMap(type2, controller.id, ((InputCategory)inputMapCategory)._id, num12);
											if (map == null)
											{
												if (dictionary.Count == 0)
												{
													num11++;
													controllerMap3 = map;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+80]");
													enumerator5 = (Dictionary<object, object>.Enumerator)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+80]");
													enumerator4 = (Dictionary<object, object>.Enumerator)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+90]");
													enumerator2 = (Dictionary<object, object>.Enumerator)0;
													num3 = num10;
													controller2 = controller;
													player2 = player;
													num4 = num4;
													num5 = 0;
													continue;
												}
												int id = ((InputCategory)inputMapCategory)._id;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1933 @ rax_v52+28]");
												ControllerMap controllerMap5 = ControllerMap.Create(controller, id, 0);
												num15 = num11;
												controllerMap3 = controllerMap5;
												obj10 = 0;
												num = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1933 @ rax_v52+28]");
												controllerType2 = ControllerType.Keyboard;
												controllerMap4 = controllerMap5;
											}
											else
											{
												num15 = num11;
												controllerMap3 = map;
												obj10 = 0;
												controllerType2 = (ControllerType)controller.id;
												controllerMap4 = map;
											}
										}
										if (dictionary.Count != 0)
										{
											bool flag24 = _tempElementByRoleMapsEnabled != null;
											num2 = 0;
											if (!flag24)
											{
												num2 = (int)(_tempElementByRoleMapsEnabled = new Dictionary<string, bool>());
											}
											bool flag25 = _tempElementByRoleMapsEnabled == null;
											mappingHelper = (ReInput.MappingHelper)(object)_tempElementByRoleMapsEnabled;
											if (flag25)
											{
												goto end_IL_178d;
											}
											_tempElementByRoleMapsEnabled.Clear();
											bool flag26 = controllerMap4 == null;
											num2 = 0;
											mappingHelper = (ReInput.MappingHelper)(object)_tempElementByRoleMapsEnabled;
											if (flag26)
											{
												goto end_IL_178d;
											}
											int elementMapCount = controllerMap4.elementMapCount;
											int num16 = elementMapCount - 1;
											bool flag27 = num16 < 0;
											obj11 = 0;
											int num17 = num;
											object obj12 = 0;
											if (!flag27)
											{
												while (true)
												{
													IList<ActionElementMap> elementMaps = controllerMap4.ElementMaps;
													bool flag28 = elementMaps == null;
													num = num17;
													num2 = 0;
													mappingHelper = (ReInput.MappingHelper)(object)controllerMap4;
													if (flag28)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
													bool flag29 = obj13 == null;
													num = num16;
													num2 = (int)typeof(IList<ActionElementMap>);
													controllerType2 = (ControllerType)elementMaps;
													mappingHelper = null;
													if (flag29)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v73+1C]");
													ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(0);
													bool flag30 = (nint)elementIdentifierById < 0;
													bool flag31 = elementIdentifierById == null;
													nint num18 = unchecked((nint)null);
													if (!flag31)
													{
														bool flag32 = dictionary.ContainsKey(elementIdentifierById._role);
														flag30 = (flag32 ? 1 : 0) < (false ? 1 : 0);
														bool flag33 = !flag32;
														num18 = 0;
														if (!flag33)
														{
															flag30 = (nint)_tempElementByRoleMapsEnabled < 0;
															bool flag34 = _tempElementByRoleMapsEnabled == null;
															num = num16;
															num2 = (int)elementIdentifierById._role;
															controllerType2 = ControllerType.Keyboard;
															mappingHelper = (ReInput.MappingHelper)(object)_tempElementByRoleMapsEnabled;
															if (flag34)
															{
																break;
															}
															Dictionary<string, bool> tempElementByRoleMapsEnabled = _tempElementByRoleMapsEnabled;
															string role = elementIdentifierById._role;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v73+48]");
															((Dictionary<object, bool>)(object)tempElementByRoleMapsEnabled).set_Item((object)role, false);
															nint num19 = (nint)controllerMap3;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2456 @ rax_v79 (Il2CppClass<Rewired.ControllerMap>)+1B0]");
															controllerType2 = ControllerType.Keyboard;
															ControllerMap controllerMap6 = controllerMap3;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v73+50]");
															bool flag35 = controllerMap6.DeleteElementMap(0);
															num = 0;
															obj12 = 1;
															controllerMap4 = controllerMap3;
															goto IL_1612;
														}
													}
													num = num16;
													controllerType2 = (ControllerType)num18;
													controllerMap4 = controllerMap3;
													goto IL_1612;
													IL_1612:
													num16--;
													object obj14 = !flag30;
													obj11 = obj12;
													num17 = num;
													if (obj14 != null)
													{
														continue;
													}
													goto IL_0e0d;
												}
												goto end_IL_178d;
											}
											goto IL_0e0d;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+80]");
										enumerator5 = (Dictionary<object, object>.Enumerator)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+80]");
										enumerator4 = (Dictionary<object, object>.Enumerator)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+90]");
										enumerator2 = (Dictionary<object, object>.Enumerator)0;
										num2 = 0;
										mappingHelper = (ReInput.MappingHelper)(object)dictionary;
										map2 = controllerMap3;
										num5 = 0;
										goto IL_176b;
									}
									bool flag36 = ((Dictionary<string, bool>)(object)typeof(NotImplementedException)).TryGetValue((string)typeFromHandle, out *(bool*)(int)controllerType2);
									NotImplementedException ex = new NotImplementedException();
									bool flag37 = ((Dictionary<string, bool>)0).TryGetValue(null, out *(bool*)(int)controllerType2);
									throw ex;
									IL_176b:
									if (obj10 != null)
									{
										Player.ControllerHelper controllers3 = player.controllers;
										if (player.controllers == null)
										{
											goto end_IL_178d;
										}
										bool flag38 = controllers3.maps == null;
										mappingHelper = (ReInput.MappingHelper)(object)controllers3.maps;
										if (flag38)
										{
											goto end_IL_178d;
										}
										controllers3.maps.AddMap(controller, map2);
										num3 = num10 + 1;
										num11 = num15 + 1;
										num10 = num3;
										controller2 = controller;
										num = 0;
										player2 = player;
										num4 = num4;
										continue;
									}
									num3 = num10;
									controller2 = controller;
									player2 = player;
									num11 = num15;
									goto IL_154e;
									IL_154e:
									num11++;
									num4 = num4;
									continue;
									IL_0e0d:
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+80]");
									enumerator5 = (Dictionary<object, object>.Enumerator)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+80]");
									enumerator4 = (Dictionary<object, object>.Enumerator)0;
									controllerIdentifier = (ControllerIdentifier)enumerator6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+90]");
									enumerator2 = (Dictionary<object, object>.Enumerator)0;
									Controller controller3 = controller;
									controllerType2 = ControllerType.Keyboard;
									nint num20 = unchecked((nint)null);
									while (enumerator.MoveNext())
									{
										ControllerIdentifier controllerIdentifier2 = (ControllerIdentifier)enumerator2;
										num13 = num;
										IList<Controller.Element> elements2;
										while (true)
										{
											elements2 = controller3.Elements;
											bool flag39 = elements2 == null;
											typeFromHandle = (ElementAssignment)0;
											Dictionary<object, bool> dictionary3 = (Dictionary<object, bool>)(object)controller3;
											if (!flag39)
											{
												bool flag40 = ((Dictionary<string, bool>)null).TryGetValue((string)(object)typeof(ICollection<Controller.Element>), out *(bool*)elements2);
												if (num20 >= (flag40 ? 1 : 0))
												{
													break;
												}
												IList<Controller.Element> elements3 = controller3.Elements;
												bool flag41 = elements3 == null;
												typeFromHandle = (ElementAssignment)0;
												controllerType2 = (ControllerType)elements2;
												dictionary3 = (Dictionary<object, bool>)(object)controller3;
												if (!flag41)
												{
													Controller.Element element2 = (Controller.Element)((Dictionary<string, bool>)null).TryGetValue((string)(object)typeof(IList<Controller.Element>), out *(bool*)elements3);
													bool flag42 = element2 == null;
													num13 = num20;
													typeFromHandle = (ElementAssignment)typeof(IList<Controller.Element>);
													controllerType2 = (ControllerType)elements3;
													dictionary3 = null;
													if (!flag42)
													{
														ControllerElementIdentifier elementIdentifier2 = element2.elementIdentifier;
														bool flag43 = elementIdentifier2 == null;
														num13 = num20;
														typeFromHandle = (ElementAssignment)0;
														controllerType2 = (ControllerType)elements3;
														dictionary3 = (Dictionary<object, bool>)(object)element2;
														if (!flag43)
														{
															bool flag44 = obj15 == null;
															num13 = num20;
															typeFromHandle = (ElementAssignment)0;
															controllerType2 = (ControllerType)elements3;
															dictionary3 = (Dictionary<object, bool>)(object)element2;
															if (!flag44)
															{
																string role2 = elementIdentifier2._role;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-90+10]");
																bool flag45 = role2 == (string)0;
																num13 = num20;
																controllerType2 = ControllerType.Keyboard;
																if (flag45)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-90+18]");
																	bool flag46 = (nint)0 == 0;
																	num13 = num20;
																	controllerType2 = ControllerType.Keyboard;
																	if (!flag46)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-90+18]");
																		object obj16 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2482 @ rax_v95+18]");
																		bool flag47 = (nint)0 == 0;
																		num13 = num20;
																		controllerType2 = ControllerType.Keyboard;
																		if (!flag47)
																		{
																			num13 = num20;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-90+10]");
																			typeFromHandle = (ElementAssignment)0;
																			controllerType2 = ControllerType.Keyboard;
																			dictionary3 = (Dictionary<object, bool>)(object)elementIdentifier2._role;
																			object obj17 = 0;
																			while (true)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-90+18]");
																				object obj18 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-90+18]");
																				if ((nint)0 != 0)
																				{
																					object obj19 = obj17;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1032 @ rax_v97+18]");
																					if ((nint)obj19 >= 0)
																					{
																						break;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18112EC00");
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803A21C0");
																					bool flag48 = obj20 == null;
																					Dictionary<object, object>.Enumerator enumerator7 = enumerator5;
																					controllerIdentifier2 = controllerIdentifier;
																					num13 = (nint)(&controllerIdentifier3);
																					typeFromHandle = (ElementAssignment)controllerType;
																					controllerType2 = (ControllerType)element2;
																					dictionary3 = (Dictionary<object, bool>)(&controllerIdentifier4);
																					if (!flag48)
																					{
																						bool flag49 = controllerMap3.CreateElementMap((ElementAssignment)(&controllerIdentifier), out result);
																						bool flag50 = !flag49;
																						enumerator7 = (Dictionary<object, object>.Enumerator)0;
																						enumerator4 = (Dictionary<object, object>.Enumerator)0;
																						controllerIdentifier2 = controllerIdentifier3;
																						num13 = unchecked((nint)null);
																						typeFromHandle = (ElementAssignment)(&controllerIdentifier);
																						controllerType2 = (ControllerType)(int)(&result);
																						dictionary3 = (Dictionary<object, bool>)(object)controllerMap3;
																						if (!flag50)
																						{
																							dictionary3 = (Dictionary<object, bool>)(object)_tempElementByRoleMapsEnabled;
																							bool flag51 = _tempElementByRoleMapsEnabled == null;
																							num13 = unchecked((nint)null);
																							typeFromHandle = (ElementAssignment)(&controllerIdentifier);
																							controllerType2 = (ControllerType)(int)(&result);
																							if (flag51)
																							{
																								throw new NullReferenceException();
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-90+10]");
																							obj21 = 0;
																							Dictionary<string, bool> tempElementByRoleMapsEnabled2 = _tempElementByRoleMapsEnabled;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-90+10]");
																							if (((Dictionary<object, bool>)(object)tempElementByRoleMapsEnabled2).TryGetValue((object)0, out value))
																							{
																								bool flag52 = result == null;
																								num13 = 0;
																								controllerType2 = (ControllerType)(int)(&value);
																								if (flag52)
																								{
																									typeFromHandle = (ElementAssignment)obj21;
																									throw new NullReferenceException();
																								}
																								result.sJiZjarByPFOekuKHAIndKOqaLbdb = value;
																								dictionary3 = (Dictionary<object, bool>)value;
																							}
																							enumerator7 = (Dictionary<object, object>.Enumerator)0;
																							enumerator4 = (Dictionary<object, object>.Enumerator)0;
																							controllerIdentifier2 = controllerIdentifier3;
																							obj10 = 1;
																							num13 = 0;
																							obj11 = 1;
																							typeFromHandle = (ElementAssignment)obj21;
																							controllerType2 = (ControllerType)(int)(&value);
																						}
																					}
																					obj17++;
																					controllerIdentifier4 = controllerIdentifier;
																					enumerator5 = enumerator7;
																					continue;
																				}
																				throw new NullReferenceException();
																			}
																		}
																	}
																}
																num20++;
																controller3 = controller;
																continue;
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										enumerator2 = (Dictionary<object, object>.Enumerator)controllerIdentifier2;
										num = (int)num13;
										controllerType2 = (ControllerType)elements2;
										num20 = unchecked((nint)null);
									}
									((Dictionary<string, ControllerElementByRoleMap>.Enumerator*)(&enumerator))->Dispose();
									bool flag53 = obj11 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+90]");
									enumerator3 = (Dictionary<object, object>.Enumerator)0;
									enumerator = enumerator6;
									num2 = 0;
									mappingHelper = (ReInput.MappingHelper)(&enumerator);
									map2 = controllerMap3;
									num5 = (int)num20;
									if (!flag53)
									{
										controllerMap3.isModified = false;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ r12_v18 (Rewired.Controller)+90]");
										enumerator3 = (Dictionary<object, object>.Enumerator)0;
										enumerator = enumerator6;
										num2 = 0;
										controllerType2 = ControllerType.Keyboard;
										mappingHelper = (ReInput.MappingHelper)(object)controllerMap3;
										map2 = controllerMap3;
										num5 = (int)num20;
									}
									goto IL_176b;
								}
								actionElementMap = (ActionElementMap)enumerator3;
								list = mapCategories;
							}
							num4++;
							continue;
							IL_025c:
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
							goto IL_026b;
							continue;
							end_IL_178d:
							break;
						}
					}
				}
			}
		}
		num13 = num;
		obj21 = num2;
		throw new NullReferenceException();
		IL_146a:
		return 0;
	}

	private unsafe ControllerMap LoadControllerMap(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		//IL_0258: Expected O, but got Ref
		//IL_02c9: Expected O, but got Ref
		//IL_00ed: Expected O, but got Ref
		//IL_0183: Expected O, but got I4
		//IL_018c: Expected O, but got I4
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		ControllerMap controllerMap;
		if (player != null)
		{
			int geiFrJCKClSdmONIywDTURjYPJnTA = default(int);
			int layoutId2 = default(int);
			int ppKeyVersion = default(int);
			string text;
			while (true)
			{
				string controllerMapPlayerPrefsKey = GetControllerMapPlayerPrefsKey(player, (ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), categoryId, layoutId2, ppKeyVersion);
				bool flag = PlayerPrefs.HasKey(controllerMapPlayerPrefsKey);
				if (!flag)
				{
					bool flag2 = (flag ? 1 : 0) >= (false ? 1 : 0);
					geiFrJCKClSdmONIywDTURjYPJnTA = controllerIdentifier.geiFrJCKClSdmONIywDTURjYPJnTA;
					if (!flag2)
					{
						text = null;
						break;
					}
					continue;
				}
				string text2 = PlayerPrefs.GetString(controllerMapPlayerPrefsKey);
				text = text2;
				break;
			}
			if (!string.IsNullOrEmpty(text))
			{
				controllerMap = ControllerMap.CreateFromXml(controllerIdentifier.jWEHFBYpJqUErvsQFOkVsnBjEAQe, text);
				if (controllerMap != null)
				{
					List<int> list = new List<int>();
					geiFrJCKClSdmONIywDTURjYPJnTA = controllerIdentifier.geiFrJCKClSdmONIywDTURjYPJnTA;
					while (true)
					{
						string controllerMapKnownActionIdsPlayerPrefsKey = GetControllerMapKnownActionIdsPlayerPrefsKey(player, (ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), categoryId, layoutId2, ppKeyVersion);
						bool flag3 = PlayerPrefs.HasKey(controllerMapKnownActionIdsPlayerPrefsKey);
						if (!flag3)
						{
							bool flag4 = (flag3 ? 1 : 0) >= (false ? 1 : 0);
							geiFrJCKClSdmONIywDTURjYPJnTA = controllerIdentifier.geiFrJCKClSdmONIywDTURjYPJnTA;
							if (!flag4)
							{
								break;
							}
							continue;
						}
						string text3 = PlayerPrefs.GetString(controllerMapKnownActionIdsPlayerPrefsKey);
						if (string.IsNullOrEmpty(text3))
						{
							break;
						}
						if (text3 != null)
						{
							string[] array = text3.Split(',');
							if (array != null)
							{
								int result = 0;
								object obj = 0;
								for (object obj2 = 0; (nint)obj < array.Length; obj2++, obj = obj2)
								{
									if (string.IsNullOrEmpty(array[obj2]) || !int.TryParse(array[obj2], out result))
									{
										continue;
									}
									if (list != null)
									{
										list.Add(result);
										continue;
									}
									goto IL_02ed;
								}
								break;
							}
						}
						goto IL_02ed;
						IL_02ed:
						return (ControllerMap)(object)new NullReferenceException();
					}
					AddDefaultMappingsForNewActions((ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), controllerMap, list);
					goto IL_02e8;
				}
			}
		}
		controllerMap = null;
		goto IL_02e8;
		IL_02e8:
		return controllerMap;
	}

	private bool LoadControllerElementMapByRole(Player player, Controller controller, string role, int mapCategoryId, int layoutId, Dictionary<string, ControllerElementByRoleMap> elementByRoleMaps)
	{
		//IL_0116: Expected I4, but got O
		//IL_0153: Expected I4, but got O
		if (!string.IsNullOrEmpty(role))
		{
			int categoryId = default(int);
			int layoutId2 = default(int);
			int ppKeyVersion = default(int);
			string controllerElementByRoleMapPlayerPrefsKey = GetControllerElementByRoleMapPlayerPrefsKey(player, role, categoryId, layoutId2, ppKeyVersion);
			if (PlayerPrefs.HasKey(controllerElementByRoleMapPlayerPrefsKey))
			{
				string text = PlayerPrefs.GetString(controllerElementByRoleMapPlayerPrefsKey);
				if (!string.IsNullOrEmpty(text))
				{
					if (!string.IsNullOrEmpty(text))
					{
						ControllerElementByRoleMap controllerElementByRoleMap = JsonParser.FromJson<ControllerElementByRoleMap>(text);
						if (controllerElementByRoleMap != null)
						{
							controllerElementByRoleMap.role = role;
							Dictionary<object, object> dictionary = default(Dictionary<object, object>);
							if (dictionary != null)
							{
								dictionary.set_Item((object)role, (object)controllerElementByRoleMap);
								return true;
							}
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						return (byte)(int)controllerElementByRoleMap != 0;
					}
					return false;
				}
			}
			return false;
		}
		return false;
	}

	private int LoadInputBehaviors(int playerId)
	{
		//IL_0291: Expected I4, but got O
		//IL_003c: Expected I4, but got O
		//IL_0070: Expected O, but got I4
		//IL_0156: Expected O, but got I4
		//IL_01bf: Expected O, but got I
		//IL_01cf: Expected O, but got I
		//IL_01a2: Expected O, but got I
		//IL_01ec: Expected O, but got I
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			int num = (int)players.GetPlayer(playerId);
			if (num == 0)
			{
				return num;
			}
			ReInput.MappingHelper mapping = ReInput.mapping;
			int id = ((Player)num).id;
			if (mapping != null)
			{
				IList<InputBehavior> inputBehaviors = mapping.GetInputBehaviors(id);
				if (inputBehaviors != null)
				{
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					while (true)
					{
						int count = inputBehaviors.Count;
						if (num4 >= count)
						{
							break;
						}
						InputBehavior inputBehavior = inputBehaviors.get_Item(num3);
						if (inputBehavior != null)
						{
							string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey((Player)num, inputBehavior._id);
							string text2;
							if (PlayerPrefs.HasKey(inputBehaviorPlayerPrefsKey))
							{
								string text = PlayerPrefs.GetString(inputBehaviorPlayerPrefsKey);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
								object obj = 0;
								text2 = text;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rdx_v15+B8]");
								object obj2 = 0;
								text2 = (string)obj2;
							}
							if (text2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rdx_v15+B8]");
								object obj3 = 0;
								if (text2 != (string)obj3)
								{
									bool flag = inputBehavior.ImportXmlString(text2);
									bool flag2 = !flag;
									bool flag3 = !flag2;
									num2 += (flag3 ? 1 : 0);
									num3++;
									num4 = num3;
									continue;
								}
							}
						}
						num3++;
						num4 = num3;
					}
					return num2;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int LoadInputBehaviorNow(int playerId, int behaviorId)
	{
		//IL_01d8: Expected I4, but got O
		//IL_0132: Expected O, but got I
		//IL_0142: Expected O, but got I
		//IL_0115: Expected O, but got I
		//IL_015f: Expected O, but got I
		ReInput.PlayerHelper players = ReInput.players;
		bool result;
		if (players != null)
		{
			Player player = players.GetPlayer(playerId);
			if (player != null)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				if (mapping == null)
				{
					goto IL_01ca;
				}
				InputBehavior inputBehavior = mapping.GetInputBehavior(playerId, behaviorId);
				if (inputBehavior != null)
				{
					string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey(player, inputBehavior._id);
					string text2;
					if (PlayerPrefs.HasKey(inputBehaviorPlayerPrefsKey))
					{
						string text = PlayerPrefs.GetString(inputBehaviorPlayerPrefsKey);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
						object obj = 0;
						text2 = text;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdx_v8+B8]");
						object obj2 = 0;
						text2 = (string)obj2;
					}
					if (text2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdx_v8+B8]");
						object obj3 = 0;
						if (text2 != (string)obj3)
						{
							bool flag = inputBehavior.ImportXmlString(text2);
							bool flag2 = !flag;
							result = !flag2;
							goto IL_01fa;
						}
					}
					result = false;
					goto IL_01fa;
				}
			}
			return 0;
		}
		goto IL_01ca;
		IL_01ca:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_01fa:
		return result ? 1 : 0;
	}

	private int LoadInputBehaviorNow(Player player, InputBehavior inputBehavior)
	{
		//IL_00b6: Expected O, but got I
		//IL_00c6: Expected O, but got I
		//IL_0099: Expected O, but got I
		//IL_00e3: Expected O, but got I
		if (player != null && inputBehavior != null)
		{
			string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey(player, inputBehavior._id);
			string text2;
			if (PlayerPrefs.HasKey(inputBehaviorPlayerPrefsKey))
			{
				string text = PlayerPrefs.GetString(inputBehaviorPlayerPrefsKey);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				text2 = text;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v3+B8]");
				object obj2 = 0;
				text2 = (string)obj2;
			}
			if (text2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v3+B8]");
				object obj3 = 0;
				if (text2 != (string)obj3 && inputBehavior.ImportXmlString(text2))
				{
					return 1;
				}
			}
		}
		return 0;
	}

	private bool LoadControllerAssignmentsNow()
	{
		ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = LoadControllerAssignmentData();
		if (controllerAssignmentSaveInfo != null)
		{
			if (loadKeyboardAssignments || loadMouseAssignments)
			{
				bool flag = LoadKeyboardAndMouseAssignmentsNow(controllerAssignmentSaveInfo);
			}
			if (loadJoystickAssignments)
			{
				bool flag2 = LoadJoystickAssignmentsNow(controllerAssignmentSaveInfo);
			}
			return true;
		}
		return false;
	}

	private unsafe bool LoadKeyboardAndMouseAssignmentsNow(ControllerAssignmentSaveInfo data)
	{
		//IL_0541: Expected I4, but got O
		//IL_00ac: Expected O, but got Ref
		//IL_0103: Expected I, but got O
		//IL_013b: Expected O, but got I
		//IL_0144: Expected O, but got I4
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0217: Expected O, but got I4
		//IL_0204: Expected O, but got I4
		//IL_02b3: Expected O, but got I8
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		bool flag = data != null;
		ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = data;
		if (!flag)
		{
			ControllerAssignmentSaveInfo controllerAssignmentSaveInfo2 = LoadControllerAssignmentData();
			bool flag2 = controllerAssignmentSaveInfo2 != null;
			controllerAssignmentSaveInfo = controllerAssignmentSaveInfo2;
			if (!flag2)
			{
				return false;
			}
		}
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			IList<Player> allPlayers = players.AllPlayers;
			if (allPlayers != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				IEnumerator<Player> enumerator = default(IEnumerator<Player>);
				object obj = (object)(&enumerator);
				Player.ControllerHelper controllerHelper = null;
				object obj2 = default(object);
				while (enumerator != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo;
					if (obj2 != null)
					{
						if (enumerator != null)
						{
							nint num = (nint)enumerator;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ r10_v7 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Rewired.Player>>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_017b;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ r10_v7 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Rewired.Player>>)+B0]");
							playerInfo = (ControllerAssignmentSaveInfo.PlayerInfo)0;
							object obj3 = 0;
							while (true)
							{
								object obj4 = obj3 + obj3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ r8_v29 (Rewired.Data.UserDataStore_PlayerPrefs+ControllerAssignmentSaveInfo+PlayerInfo)+v441 @ rax_v68*8]");
								if (0 != (nint)typeof(IEnumerator<Player>))
								{
									obj3++;
									object obj5 = obj3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ r10_v7 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Rewired.Player>>)+12E]");
									if ((nint)obj5 < 0)
									{
										continue;
									}
									goto IL_017b;
								}
								break;
							}
							goto IL_018f;
						}
						throw new NullReferenceException();
					}
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
					}
					return true;
					IL_017b:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
					playerInfo = null;
					goto IL_018f;
					IL_018f:
					Player current = enumerator.Current;
					if (current != null)
					{
						int id = current.id;
						if (controllerAssignmentSaveInfo != null)
						{
							ControllerAssignmentSaveInfo controllerAssignmentSaveInfo3 = null;
							ControllerAssignmentSaveInfo controllerAssignmentSaveInfo4;
							while (true)
							{
								object obj6;
								if (controllerAssignmentSaveInfo.players != null)
								{
									ControllerAssignmentSaveInfo.PlayerInfo[] players2 = controllerAssignmentSaveInfo.players;
									obj6 = players2.Length;
								}
								else
								{
									obj6 = 0;
								}
								if (System.Runtime.CompilerServices.Unsafe.As<ControllerAssignmentSaveInfo, UIntPtr>(ref controllerAssignmentSaveInfo3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
								{
									ControllerAssignmentSaveInfo.PlayerInfo[] players3 = controllerAssignmentSaveInfo.players;
									if (players3[(object)controllerAssignmentSaveInfo3] != null)
									{
										playerInfo = players3[(object)controllerAssignmentSaveInfo3];
										bool flag3 = playerInfo.id == id;
										controllerAssignmentSaveInfo4 = controllerAssignmentSaveInfo3;
										if (flag3)
										{
											break;
										}
									}
									controllerAssignmentSaveInfo3 = (ControllerAssignmentSaveInfo)(controllerAssignmentSaveInfo3 + 1);
									continue;
								}
								controllerAssignmentSaveInfo4 = (ControllerAssignmentSaveInfo)4294967295L;
								break;
							}
							controllerHelper = (Player.ControllerHelper)((object)controllerAssignmentSaveInfo4 >> 31);
							bool flag4 = controllerHelper != null;
							int num2 = id;
							if (flag4)
							{
								continue;
							}
							ControllerAssignmentSaveInfo.PlayerInfo[] players4 = controllerAssignmentSaveInfo.players;
							int id2 = current.id;
							int num3 = controllerAssignmentSaveInfo.IndexOfPlayer(id2);
							if (controllerAssignmentSaveInfo.players != null)
							{
								if (num3 < players4.Length)
								{
									ControllerAssignmentSaveInfo.PlayerInfo playerInfo2 = players4[num3];
									bool flag5 = !loadKeyboardAssignments;
									controllerHelper = (Player.ControllerHelper)(object)controllerAssignmentSaveInfo;
									if (!flag5)
									{
										bool flag6 = players4[num3] == null;
										controllerAssignmentSaveInfo3 = controllerAssignmentSaveInfo;
										if (flag6)
										{
											throw new NullReferenceException();
										}
										controllerHelper = current.controllers;
										bool flag7 = current.controllers == null;
										controllerAssignmentSaveInfo3 = (ControllerAssignmentSaveInfo)(object)current.controllers;
										if (flag7)
										{
											throw new NullReferenceException();
										}
										current.controllers.hasKeyboard = playerInfo2.hasKeyboard;
									}
									bool flag8 = !loadMouseAssignments;
									num2 = id;
									if (!flag8)
									{
										if (players4[num3] == null)
										{
											throw new NullReferenceException();
										}
										controllerHelper = current.controllers;
										bool flag9 = current.controllers == null;
										controllerAssignmentSaveInfo3 = (ControllerAssignmentSaveInfo)(object)current.controllers;
										if (flag9)
										{
											throw new NullReferenceException();
										}
										current.controllers.hasMouse = playerInfo2.hasMouse;
										num2 = id;
									}
									continue;
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool LoadJoystickAssignmentsNow(ControllerAssignmentSaveInfo data)
	{
		//IL_153a: Expected I4, but got O
		//IL_00fd: Expected O, but got Ref
		//IL_010b: Expected I, but got O
		//IL_15a4: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_016a: Expected I, but got O
		//IL_0185: Expected I, but got O
		//IL_0242: Expected O, but got I4
		//IL_0250: Expected I, but got O
		//IL_01bd: Expected O, but got I
		//IL_027b: Expected O, but got I4
		//IL_0289: Expected I, but got O
		//IL_02e9: Expected O, but got I
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_03b3: Expected O, but got Ref
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_02b8: Expected I, but got O
		//IL_03ca: Expected I, but got O
		//IL_0401: Expected O, but got I
		//IL_0561: Expected O, but got I
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected O, but got Unknown
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Expected O, but got Unknown
		//IL_1703: Expected O, but got I4
		//IL_1711: Expected I, but got O
		//IL_0aff: Expected I, but got O
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_0b42: Expected O, but got I4
		//IL_0b4b: Expected O, but got I4
		//IL_0b5e: Expected I, but got O
		//IL_12c7: Expected I, but got O
		//IL_0539: Expected O, but got I4
		//IL_11e1: Expected O, but got Ref
		//IL_11f8: Expected O, but got Ref
		//IL_1206: Expected I, but got O
		//IL_0720: Expected O, but got I8
		//IL_059b: Expected I, but got O
		//IL_05b8: Expected O, but got I4
		//IL_1234: Expected I, but got O
		//IL_05f0: Expected O, but got I4
		//IL_0794: Expected O, but got I4
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Expected O, but got Unknown
		//IL_0648: Expected O, but got I4
		//IL_0680: Expected O, but got I4
		//IL_0c3b: Expected O, but got I4
		//IL_0d7e: Expected O, but got I8
		//IL_06a6: Expected O, but got I
		//IL_06c6: Expected O, but got I4
		//IL_083c: Expected O, but got I4
		//IL_0d67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6c: Expected O, but got Unknown
		//IL_08ab: Expected O, but got I4
		//IL_08b1: Expected I, but got O
		//IL_08cf: Expected O, but got I
		//IL_16c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c7: Expected O, but got Unknown
		//IL_0906: Expected O, but got I
		//IL_0e70: Expected O, but got I4
		//IL_0a70: Expected O, but got I
		//IL_0a9d: Expected O, but got I
		//IL_0aa7: Expected I, but got O
		//IL_09fa: Expected O, but got I4
		//IL_09ff: Expected I, but got O
		//IL_0a05: Expected I, but got O
		//IL_137a: Expected O, but got I
		//IL_17e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e6: Expected O, but got Unknown
		//IL_0fc7: Expected I, but got O
		//IL_11bc: Expected I, but got O
		//IL_1002: Expected I, but got O
		//IL_10f6: Expected O, but got Ref
		//IL_1094: Expected I, but got O
		//IL_10c2: Expected I, but got O
		ReInput.ControllerHelper controllers = ReInput.controllers;
		if (controllers != null)
		{
			if (controllers.joystickCount == 0)
			{
				goto IL_1239;
			}
			bool flag = data != null;
			ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = data;
			ControllerAssignmentSaveInfo controllerAssignmentSaveInfo2 = data;
			if (!flag)
			{
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo3 = LoadControllerAssignmentData();
				if (controllerAssignmentSaveInfo3 == null)
				{
					goto IL_1239;
				}
				controllerAssignmentSaveInfo = controllerAssignmentSaveInfo3;
				controllerAssignmentSaveInfo2 = controllerAssignmentSaveInfo3;
			}
			ReInput.PlayerHelper players = ReInput.players;
			IList<Player> allPlayers = players.AllPlayers;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			IEnumerator<Player> enumerator = default(IEnumerator<Player>);
			object obj = (object)(&enumerator);
			nint num = (nint)typeof(IEnumerable<Player>);
			Player.ControllerHelper controllerHelper = null;
			object obj2 = default(object);
			while (true)
			{
				bool flag2 = enumerator == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)0;
				IEnumerator<Player> enumerator3 = enumerator;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					if (obj2 != null)
					{
						bool flag3 = enumerator == null;
						enumerator2 = (List<object>.Enumerator)0;
						enumerator3 = enumerator;
						num = (nint)typeof(IEnumerator);
						controllerHelper = null;
						if (!flag3)
						{
							nint num2 = (nint)enumerator;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ r10_v55 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Rewired.Player>>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_01f9;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ r10_v55 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Rewired.Player>>)+B0]");
							enumerator3 = (IEnumerator<Player>)0;
							List<JoystickAssignmentHistoryInfo> list = null;
							while (true)
							{
								object obj3 = (object)list + (object)list;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r8_v52 (System.Collections.Generic.IEnumerator`1<Rewired.Player>)+v929 @ rax_v254*8]");
								if (0 == (nint)typeof(IEnumerator<Player>))
								{
									break;
								}
								list = (List<JoystickAssignmentHistoryInfo>)(list + 1);
								List<JoystickAssignmentHistoryInfo> list2 = list;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ r10_v55 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Rewired.Player>>)+12E]");
								if ((nint)list2 < 0)
								{
									continue;
								}
								goto IL_01f9;
							}
							object obj4 = (object)list + (object)list;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r8_v52 (System.Collections.Generic.IEnumerator`1<Rewired.Player>)+8+v1055 @ rcx_v185*8]");
							object obj5 = (nint)0 << 4;
							object obj6 = obj5 + 312;
							object obj7 = obj6 + num2;
							goto IL_020d;
						}
						throw new NullReferenceException();
					}
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
					}
					break;
				}
				throw new NullReferenceException();
				IL_01f9:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
				enumerator3 = null;
				goto IL_020d;
				IL_020d:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ rax_v247+8]");
				num = 0;
				Player current = enumerator.Current;
				bool flag4 = current == null;
				enumerator2 = (List<object>.Enumerator)0;
				nint num3 = (nint)typeof(IEnumerator<Player>);
				if (!flag4)
				{
					bool flag5 = current.controllers == null;
					enumerator2 = (List<object>.Enumerator)0;
					num3 = (nint)typeof(IEnumerator<Player>);
					if (!flag5)
					{
						current.controllers.ClearControllersOfType(ControllerType.Joystick);
						num3 = (nint)typeof(IEnumerator<Player>);
						num = 2;
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			List<JoystickAssignmentHistoryInfo> list4;
			if (loadJoystickAssignments)
			{
				List<JoystickAssignmentHistoryInfo> list3 = new List<JoystickAssignmentHistoryInfo>();
				list4 = list3;
			}
			else
			{
				list4 = null;
			}
			ReInput.PlayerHelper players2 = ReInput.players;
			IList<Player> allPlayers2 = players2.AllPlayers;
			bool flag6 = allPlayers2 == null;
			ReInput.PlayerHelper playerHelper = players2;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				IEnumerator enumerator4 = default(IEnumerator);
				object obj8 = (object)(&enumerator4);
				List<JoystickAssignmentHistoryInfo> list5 = null;
				IEnumerator enumerator5 = null;
				nint num5;
				Player player = default(Player);
				object obj14 = default(object);
				List<object>.Enumerator enumerator2;
				nint num3;
				while (true)
				{
					IEnumerator<Player> enumerator3;
					if (enumerator4 != null)
					{
						nint num4 = (nint)enumerator4;
						List<JoystickAssignmentHistoryInfo> list6 = list5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ r10_v54 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						if ((nint)list6 >= 0)
						{
							goto IL_0440;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ r10_v54 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						enumerator3 = (IEnumerator<Player>)0;
						List<JoystickAssignmentHistoryInfo> list7 = list5;
						while (true)
						{
							object obj9 = (object)list7 + (object)list7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r8_v52 (System.Collections.Generic.IEnumerator`1<Rewired.Player>)+v1955 @ rax_v238*8]");
							if (0 == (nint)typeof(IEnumerator))
							{
								break;
							}
							list7 = (List<JoystickAssignmentHistoryInfo>)(list7 + 1);
							List<JoystickAssignmentHistoryInfo> list8 = list7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ r10_v54 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
							if ((nint)list8 < 0)
							{
								continue;
							}
							goto IL_0440;
						}
						object obj10 = (object)list7 + (object)list7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r8_v52 (System.Collections.Generic.IEnumerator`1<Rewired.Player>)+8+v2089 @ rcx_v172*8]");
						object obj11 = (nint)0 << 4;
						object obj12 = obj11 + 312;
						object obj13 = obj12 + num4;
						goto IL_0454;
					}
					throw new NullReferenceException();
					IL_0454:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2086 @ rax_v132+8]");
					num5 = 0;
					if (enumerator4.MoveNext())
					{
						bool flag7 = enumerator4 == null;
						enumerator5 = enumerator4;
						if (!flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							bool flag8 = player == null;
							enumerator5 = null;
							if (!flag8)
							{
								int id = player.id;
								bool flag9 = controllerAssignmentSaveInfo2 == null;
								enumerator5 = (IEnumerator)(object)player;
								if (!flag9)
								{
									IEnumerator enumerator6 = enumerator4;
									List<JoystickAssignmentHistoryInfo> list9 = list5;
									while (true)
									{
										List<JoystickAssignmentHistoryInfo> list10;
										if (controllerAssignmentSaveInfo2.players != null)
										{
											ControllerAssignmentSaveInfo.PlayerInfo[] players3 = controllerAssignmentSaveInfo2.players;
											list10 = (List<JoystickAssignmentHistoryInfo>)players3.Length;
										}
										else
										{
											list10 = list5;
										}
										if (System.Runtime.CompilerServices.Unsafe.As<List<JoystickAssignmentHistoryInfo>, UIntPtr>(ref list9) < System.Runtime.CompilerServices.Unsafe.As<List<JoystickAssignmentHistoryInfo>, UIntPtr>(ref list10))
										{
											num = (nint)controllerAssignmentSaveInfo2.players;
											bool flag10 = controllerAssignmentSaveInfo2.players == null;
											enumerator2 = (List<object>.Enumerator)0;
											num3 = id;
											if (!flag10)
											{
												List<JoystickAssignmentHistoryInfo> list11 = list9;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1500 @ rdx_v47 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Rewired.Player>>)+18]");
												bool flag11 = (nint)list11 >= 0;
												enumerator2 = (List<object>.Enumerator)0;
												num3 = id;
												if (!flag11)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1500 @ rdx_v47 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Rewired.Player>>)+20+v3348 @ rcx_v142 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+JoystickAssignmentHistoryInfo>)*8]");
													if ((nint)0 != 0)
													{
														bool flag12 = controllerAssignmentSaveInfo2.players == null;
														enumerator2 = (List<object>.Enumerator)0;
														num3 = id;
														if (flag12)
														{
															throw new NullReferenceException();
														}
														List<JoystickAssignmentHistoryInfo> list12 = list9;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1500 @ rdx_v47 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Rewired.Player>>)+18]");
														bool flag13 = (nint)list12 >= 0;
														enumerator2 = (List<object>.Enumerator)0;
														num3 = id;
														if (flag13)
														{
															throw new IndexOutOfRangeException();
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1500 @ rdx_v47 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Rewired.Player>>)+20+v3348 @ rcx_v142 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+JoystickAssignmentHistoryInfo>)*8]");
														enumerator6 = (IEnumerator)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1500 @ rdx_v47 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Rewired.Player>>)+20+v3348 @ rcx_v142 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+JoystickAssignmentHistoryInfo>)*8]");
														bool flag14 = (nint)0 == 0;
														enumerator2 = (List<object>.Enumerator)0;
														num3 = id;
														if (flag14)
														{
															throw new NullReferenceException();
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3039 @ r8_v101 (System.Collections.IEnumerator)+10]");
														if ((nint)0 == id)
														{
															break;
														}
													}
													list9 = (List<JoystickAssignmentHistoryInfo>)(list9 + 1);
													continue;
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										list9 = (List<JoystickAssignmentHistoryInfo>)4294967295L;
										break;
									}
									enumerator5 = (IEnumerator)((object)list9 >> 31);
									if (enumerator5 != null)
									{
										continue;
									}
									ControllerAssignmentSaveInfo.PlayerInfo[] players4 = controllerAssignmentSaveInfo2.players;
									int id2 = player.id;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039F400");
									bool flag15 = controllerAssignmentSaveInfo2.players == null;
									enumerator5 = (IEnumerator)controllerAssignmentSaveInfo2;
									if (!flag15)
									{
										bool flag16 = (nint)obj14 >= players4.Length;
										enumerator2 = (List<object>.Enumerator)0;
										num3 = id;
										num = id2;
										if (!flag16)
										{
											ControllerAssignmentSaveInfo.PlayerInfo playerInfo = players4[obj14];
											bool flag17 = players4[obj14] == null;
											num3 = id;
											List<JoystickAssignmentHistoryInfo> list13 = list5;
											ArgumentNullException ex = (ArgumentNullException)(object)controllerAssignmentSaveInfo2;
											if (!flag17)
											{
												List<JoystickAssignmentHistoryInfo> list14;
												while (true)
												{
													if (playerInfo.joysticks != null)
													{
														ControllerAssignmentSaveInfo.JoystickInfo[] joysticks = playerInfo.joysticks;
														list14 = (List<JoystickAssignmentHistoryInfo>)joysticks.Length;
													}
													else
													{
														list14 = list5;
													}
													if (System.Runtime.CompilerServices.Unsafe.As<List<JoystickAssignmentHistoryInfo>, UIntPtr>(ref list13) >= System.Runtime.CompilerServices.Unsafe.As<List<JoystickAssignmentHistoryInfo>, UIntPtr>(ref list14))
													{
														break;
													}
													_003C_003Ec__DisplayClass86_0 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass86_0();
													ex = (ArgumentNullException)(object)playerInfo.joysticks;
													if (playerInfo.joysticks != null)
													{
														List<JoystickAssignmentHistoryInfo> list15 = list13;
														string message = ((Exception)ex)._message;
														bool flag18 = System.Runtime.CompilerServices.Unsafe.As<List<JoystickAssignmentHistoryInfo>, UIntPtr>(ref list15) >= System.Runtime.CompilerServices.Unsafe.As<string, UIntPtr>(ref message);
														enumerator2 = (List<object>.Enumerator)0;
														num = unchecked((nint)null);
														if (!flag18)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2644 @ rcx_v47 (System.ArgumentNullException)+20+v1417 @ r15_v68 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+JoystickAssignmentHistoryInfo>)*8]");
															ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = (ControllerAssignmentSaveInfo.JoystickInfo)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2644 @ rcx_v47 (System.ArgumentNullException)+20+v1417 @ r15_v68 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+JoystickAssignmentHistoryInfo>)*8]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2644 @ rcx_v47 (System.ArgumentNullException)+20+v1417 @ r15_v68 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+JoystickAssignmentHistoryInfo>)*8]");
																Joystick joystick = FindJoystickPrecise((ControllerAssignmentSaveInfo.JoystickInfo)0);
																bool flag19 = CS_0024_003C_003E8__locals18 == null;
																ex = (ArgumentNullException)(object)this;
																if (flag19)
																{
																	throw new NullReferenceException();
																}
																CS_0024_003C_003E8__locals18.joystick = joystick;
																if (CS_0024_003C_003E8__locals18.joystick != null)
																{
																	Predicate<JoystickAssignmentHistoryInfo> predicate = (Predicate<object>)delegate(JoystickAssignmentHistoryInfo x)
																	{
																		//IL_0053: Expected I4, but got O
																		if (x == null)
																		{
																			NullReferenceException ex4 = new NullReferenceException();
																			return (byte)(int)ex4 != 0;
																		}
																		object obj18 = (object)x.joystick - (object)CS_0024_003C_003E8__locals18.joystick;
																		return obj18 == null;
																	};
																	bool flag20 = list4 == null;
																	ex = (ArgumentNullException)(object)predicate;
																	if (flag20)
																	{
																		throw new NullReferenceException();
																	}
																	JoystickAssignmentHistoryInfo joystickAssignmentHistoryInfo = list4.Find(predicate);
																	if (joystickAssignmentHistoryInfo == null)
																	{
																		JoystickAssignmentHistoryInfo joystickAssignmentHistoryInfo2 = new JoystickAssignmentHistoryInfo(null, 0);
																		bool flag21 = CS_0024_003C_003E8__locals18.joystick == null;
																		enumerator2 = (List<object>.Enumerator)0;
																		num3 = unchecked((nint)null);
																		num = unchecked((nint)null);
																		if (flag21)
																		{
																			JoystickAssignmentHistoryInfo joystickAssignmentHistoryInfo3 = ((List<JoystickAssignmentHistoryInfo>)(object)typeof(ArgumentNullException)).Find((Predicate<JoystickAssignmentHistoryInfo>)num);
																			ArgumentNullException ex2 = new ArgumentNullException("joystick");
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
																			ex = ex2;
																			throw ex2;
																		}
																		joystickAssignmentHistoryInfo2.joystick = CS_0024_003C_003E8__locals18.joystick;
																		joystickAssignmentHistoryInfo2.oldJoystickId = joystickInfo.id;
																		list4.Add(joystickAssignmentHistoryInfo2);
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2378 @ rax_v203 (Rewired.Player)+50]");
																	bool flag22 = (nint)0 == 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2378 @ rax_v203 (Rewired.Player)+50]");
																	ex = (ArgumentNullException)0;
																	if (flag22)
																	{
																		throw new NullReferenceException();
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2378 @ rax_v203 (Rewired.Player)+50]");
																	((Player.ControllerHelper)0).AddController(CS_0024_003C_003E8__locals18.joystick, removeFromOtherPlayers: false);
																	list5 = null;
																	num3 = unchecked((nint)null);
																}
															}
															list13 = (List<JoystickAssignmentHistoryInfo>)(list13 + 1);
															continue;
														}
														throw new IndexOutOfRangeException();
													}
													throw new NullReferenceException();
												}
												enumerator5 = (IEnumerator)list14;
												controllerAssignmentSaveInfo2 = controllerAssignmentSaveInfo;
												continue;
											}
											enumerator5 = (IEnumerator)ex;
											throw new NullReferenceException();
										}
										throw new IndexOutOfRangeException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					if (obj8 != null)
					{
						enumerator3 = (IEnumerator<Player>)obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						num5 = (nint)typeof(IDisposable);
					}
					break;
					IL_0440:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
					enumerator3 = null;
					goto IL_0454;
				}
				bool flag23 = !allowImpreciseJoystickAssignmentMatching;
				enumerator2 = (List<object>.Enumerator)0;
				num3 = (nint)typeof(IEnumerator);
				nint num6 = num5;
				if (!flag23)
				{
					ReInput.PlayerHelper players5 = ReInput.players;
					IList<Player> allPlayers3 = players5.AllPlayers;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					List<object>.Enumerator enumerator7 = (List<object>.Enumerator)0;
					enumerator2 = (List<object>.Enumerator)0;
					List<Joystick> matches = null;
					num3 = (nint)typeof(IEnumerator);
					playerHelper = null;
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo2 = default(ControllerAssignmentSaveInfo.PlayerInfo);
					object obj15 = default(object);
					Player player2 = default(Player);
					object obj16 = default(object);
					Joystick joystick3 = default(Joystick);
					List<object>.Enumerator enumerator8 = default(List<object>.Enumerator);
					while (true)
					{
						if (playerInfo2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							if (obj15 == null)
							{
								break;
							}
							bool flag24 = playerInfo2 == null;
							playerHelper = null;
							if (!flag24)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								bool flag25 = player2 == null;
								playerHelper = null;
								if (!flag25)
								{
									int id3 = player2.id;
									bool flag26 = controllerAssignmentSaveInfo2 == null;
									playerHelper = (ReInput.PlayerHelper)(object)player2;
									if (!flag26)
									{
										ControllerAssignmentSaveInfo.PlayerInfo playerInfo3 = playerInfo2;
										enumerator5 = (IEnumerator)list5;
										while (true)
										{
											List<JoystickAssignmentHistoryInfo> list16;
											if (controllerAssignmentSaveInfo2.players != null)
											{
												ControllerAssignmentSaveInfo.PlayerInfo[] players6 = controllerAssignmentSaveInfo2.players;
												list16 = (List<JoystickAssignmentHistoryInfo>)players6.Length;
											}
											else
											{
												list16 = list5;
											}
											if (System.Runtime.CompilerServices.Unsafe.As<IEnumerator, UIntPtr>(ref enumerator5) < System.Runtime.CompilerServices.Unsafe.As<List<JoystickAssignmentHistoryInfo>, UIntPtr>(ref list16))
											{
												ControllerAssignmentSaveInfo.PlayerInfo[] players7 = controllerAssignmentSaveInfo2.players;
												if (controllerAssignmentSaveInfo2.players != null)
												{
													if ((nint)enumerator5 < players7.Length)
													{
														if (players7[(object)enumerator5] != null)
														{
															if (controllerAssignmentSaveInfo2.players == null)
															{
																throw new NullReferenceException();
															}
															if ((nint)enumerator5 >= players7.Length)
															{
																throw new IndexOutOfRangeException();
															}
															playerInfo3 = players7[(object)enumerator5];
															if (players7[(object)enumerator5] == null)
															{
																throw new NullReferenceException();
															}
															if (playerInfo3.id == id3)
															{
																break;
															}
														}
														enumerator5 = (IEnumerator)(enumerator5 + 1);
														continue;
													}
													throw new IndexOutOfRangeException();
												}
												throw new NullReferenceException();
											}
											enumerator5 = (IEnumerator)4294967295L;
											break;
										}
										playerHelper = (ReInput.PlayerHelper)((object)enumerator5 >> 31);
										bool flag27 = playerHelper != null;
										num3 = id3;
										if (flag27)
										{
											continue;
										}
										ControllerAssignmentSaveInfo.PlayerInfo[] players8 = controllerAssignmentSaveInfo2.players;
										int id4 = player2.id;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039F400");
										bool flag28 = controllerAssignmentSaveInfo2.players == null;
										playerHelper = (ReInput.PlayerHelper)(object)controllerAssignmentSaveInfo2;
										if (!flag28)
										{
											if ((nint)obj16 < players8.Length)
											{
												ControllerAssignmentSaveInfo.PlayerInfo playerInfo4 = players8[obj16];
												if (players8[obj16] != null)
												{
													List<JoystickAssignmentHistoryInfo> list17 = list5;
													List<JoystickAssignmentHistoryInfo> list18 = list4;
													num3 = id3;
													Player player3 = player2;
													UserDataStore_PlayerPrefs userDataStore_PlayerPrefs = this;
													while (true)
													{
														if (playerInfo4.joysticks != null)
														{
															ControllerAssignmentSaveInfo.JoystickInfo[] joysticks2 = playerInfo4.joysticks;
															playerHelper = (ReInput.PlayerHelper)joysticks2.Length;
														}
														else
														{
															playerHelper = (ReInput.PlayerHelper)(object)list5;
														}
														if (System.Runtime.CompilerServices.Unsafe.As<List<JoystickAssignmentHistoryInfo>, UIntPtr>(ref list17) >= System.Runtime.CompilerServices.Unsafe.As<ReInput.PlayerHelper, UIntPtr>(ref playerHelper))
														{
															break;
														}
														_003C_003Ec__DisplayClass86_1 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass86_1();
														ControllerAssignmentSaveInfo.JoystickInfo[] joysticks3 = playerInfo4.joysticks;
														if (playerInfo4.joysticks != null)
														{
															if ((nint)list17 < joysticks3.Length)
															{
																if (CS_0024_003C_003E8__locals20 != null)
																{
																	CS_0024_003C_003E8__locals20.joystickInfo = joysticks3[(object)list17];
																	if (CS_0024_003C_003E8__locals20.joystickInfo == null)
																	{
																		goto IL_17d8;
																	}
																	Predicate<JoystickAssignmentHistoryInfo> match = (Predicate<object>)delegate(JoystickAssignmentHistoryInfo x)
																	{
																		//IL_007f: Expected I4, but got O
																		//IL_005d: Expected O, but got I4
																		if (x != null)
																		{
																			ControllerAssignmentSaveInfo.JoystickInfo joystickInfo3 = CS_0024_003C_003E8__locals20.joystickInfo;
																			if (CS_0024_003C_003E8__locals20.joystickInfo != null)
																			{
																				object obj18 = x.oldJoystickId - joystickInfo3.id;
																				return obj18 == null;
																			}
																		}
																		NullReferenceException ex4 = new NullReferenceException();
																		return (byte)(int)ex4 != 0;
																	};
																	if (list18 != null)
																	{
																		int num7 = list18.FindIndex(match);
																		Joystick joystick2;
																		if (num7 < 0)
																		{
																			bool flag29 = userDataStore_PlayerPrefs.TryFindJoysticksImprecise(CS_0024_003C_003E8__locals20.joystickInfo, out matches);
																			bool flag30 = !flag29;
																			num3 = unchecked((nint)null);
																			if (flag30)
																			{
																				goto IL_17d8;
																			}
																			if (matches == null)
																			{
																				throw new NullReferenceException();
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
																			num3 = unchecked((nint)null);
																			nint num8 = 0;
																			int oldJoystickId;
																			while (true)
																			{
																				bool flag31 = enumerator7.MoveNext();
																				bool flag32 = !flag31;
																				oldJoystickId = (int)num8;
																				joystick2 = null;
																				if (flag32)
																				{
																					break;
																				}
																				_003C_003Ec__DisplayClass86_2 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass86_2();
																				if (CS_0024_003C_003E8__locals21 != null)
																				{
																					CS_0024_003C_003E8__locals21.match = joystick3;
																					Predicate<JoystickAssignmentHistoryInfo> match2 = (Predicate<object>)delegate(JoystickAssignmentHistoryInfo x)
																					{
																						//IL_0053: Expected I4, but got O
																						if (x == null)
																						{
																							NullReferenceException ex4 = new NullReferenceException();
																							return (byte)(int)ex4 != 0;
																						}
																						object obj18 = (object)x.joystick - (object)CS_0024_003C_003E8__locals21.match;
																						return obj18 == null;
																					};
																					JoystickAssignmentHistoryInfo joystickAssignmentHistoryInfo4 = list4.Find(match2);
																					bool flag33 = joystickAssignmentHistoryInfo4 != null;
																					list18 = list4;
																					num3 = unchecked((nint)null);
																					num8 = 0;
																					if (!flag33)
																					{
																						joystick2 = CS_0024_003C_003E8__locals21.match;
																						list18 = list4;
																						num3 = unchecked((nint)null);
																						oldJoystickId = 0;
																						break;
																					}
																					continue;
																				}
																				throw new NullReferenceException();
																			}
																			((List<Joystick>.Enumerator*)(&enumerator7))->Dispose();
																			bool flag34 = joystick2 == null;
																			Joystick joystick4 = joystick3;
																			enumerator7 = enumerator8;
																			enumerator2 = enumerator8;
																			player3 = player2;
																			if (flag34)
																			{
																				goto IL_11c2;
																			}
																			ControllerAssignmentSaveInfo.JoystickInfo joystickInfo2 = CS_0024_003C_003E8__locals20.joystickInfo;
																			bool flag35 = CS_0024_003C_003E8__locals20.joystickInfo == null;
																			_003C_003Ec__DisplayClass86_2 obj17 = (_003C_003Ec__DisplayClass86_2)(&enumerator7);
																			if (flag35)
																			{
																				throw new NullReferenceException();
																			}
																			JoystickAssignmentHistoryInfo item = new JoystickAssignmentHistoryInfo(null, oldJoystickId);
																			_ = joystickInfo2.id;
																			list18.Add(item);
																			joystick4 = joystick3;
																			enumerator7 = enumerator8;
																			enumerator2 = enumerator8;
																			player3 = player2;
																		}
																		else
																		{
																			JoystickAssignmentHistoryInfo joystickAssignmentHistoryInfo5 = list18.get_Item(num7);
																			if (joystickAssignmentHistoryInfo5 == null)
																			{
																				throw new NullReferenceException();
																			}
																			joystick2 = joystickAssignmentHistoryInfo5.joystick;
																		}
																		if (player3.controllers != null)
																		{
																			player3.controllers.AddController(joystick2, removeFromOtherPlayers: false);
																			num3 = unchecked((nint)null);
																			goto IL_11c2;
																		}
																		throw new NullReferenceException();
																	}
																	throw new NullReferenceException();
																}
																throw new NullReferenceException();
															}
															throw new IndexOutOfRangeException();
														}
														throw new NullReferenceException();
														IL_11c2:
														userDataStore_PlayerPrefs = this;
														goto IL_17d8;
														IL_17d8:
														list17 = (List<JoystickAssignmentHistoryInfo>)(list17 + 1);
														list5 = null;
													}
													controllerAssignmentSaveInfo2 = controllerAssignmentSaveInfo;
													continue;
												}
												throw new NullReferenceException();
											}
											throw new IndexOutOfRangeException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					IEnumerator<Player> enumerator9 = (IEnumerator<Player>)(&playerInfo2);
					bool flag36 = enumerator9 == null;
					IEnumerator<Player> enumerator3 = (IEnumerator<Player>)(&playerInfo2);
					num6 = (nint)typeof(IEnumerator);
					if (!flag36)
					{
						enumerator3 = enumerator9;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						num6 = (nint)typeof(IDisposable);
					}
				}
				ReInput.ConfigHelper configuration = ReInput.configuration;
				bool flag37 = configuration == null;
				num = num6;
				controllerHelper = null;
				if (!flag37)
				{
					if (configuration.autoAssignJoysticks)
					{
						ReInput.ControllerHelper controllers2 = ReInput.controllers;
						bool flag38 = controllers2 == null;
						num = unchecked((nint)null);
						controllerHelper = null;
						if (flag38)
						{
							goto IL_12f6;
						}
						controllers2.AutoAssignJoysticks();
					}
					return true;
				}
				goto IL_12f6;
			}
			throw new NullReferenceException();
		}
		NullReferenceException ex3 = new NullReferenceException();
		return (byte)(int)ex3 != 0;
		IL_12f6:
		throw new NullReferenceException();
		IL_1239:
		return false;
	}

	private ControllerAssignmentSaveInfo LoadControllerAssignmentData()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172327]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string key = string.Format("{0}_{1}", playerPrefsKeyPrefix, "ControllerAssignments");
		if (PlayerPrefs.HasKey(key))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172327]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string key2 = string.Format("{0}_{1}", playerPrefsKeyPrefix, "ControllerAssignments");
			string text = PlayerPrefs.GetString(key2);
			if (!string.IsNullOrEmpty(text))
			{
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = JsonParser.FromJson<ControllerAssignmentSaveInfo>(text);
				if (controllerAssignmentSaveInfo != null && controllerAssignmentSaveInfo.players != null)
				{
					ControllerAssignmentSaveInfo.PlayerInfo[] players = controllerAssignmentSaveInfo.players;
					if (players.Length != 0)
					{
						return controllerAssignmentSaveInfo;
					}
				}
				return null;
			}
			return null;
		}
		return null;
	}

	private IEnumerator LoadJoystickAssignmentsDeferred()
	{
		_003CLoadJoystickAssignmentsDeferred_003Ed__88 obj = new _003CLoadJoystickAssignmentsDeferred_003Ed__88(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void SaveAll()
	{
		ReInput.PlayerHelper players = ReInput.players;
		IList<Player> allPlayers = players.AllPlayers;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int count = allPlayers.Count;
			if (num >= count)
			{
				break;
			}
			Player player = allPlayers.get_Item(num2);
			SavePlayerDataNow(player);
			num2++;
			num = num2;
		}
		SaveAllJoystickCalibrationData();
		if (loadKeyboardAssignments || loadMouseAssignments || loadJoystickAssignments)
		{
			bool flag = SaveControllerAssignments();
		}
		PlayerPrefs.Save();
		int num3 = 0;
		int num4 = 0;
		while (true)
		{
			int count2 = allPlayers.Count;
			if (num3 < count2)
			{
				Player player2 = allPlayers.get_Item(num4);
				OnControllerMapsSaved(player2);
				num4++;
				num3 = num4;
				continue;
			}
			break;
		}
	}

	private void SavePlayerDataNow(int playerId)
	{
		ReInput.PlayerHelper players = ReInput.players;
		Player player = players.GetPlayer(playerId);
		SavePlayerDataNow(player);
		PlayerPrefs.Save();
		OnControllerMapsSaved(player);
	}

	private unsafe void SavePlayerDataNow(Player player)
	{
		//IL_005b: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_0111: Expected O, but got Ref
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		if (player == null)
		{
			return;
		}
		InputBehavior[] uKbXgORekfADCjZshCoaohGejMNib = player.GetSaveData(userAssignableMapsOnly: true).uKbXgORekfADCjZshCoaohGejMNib;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < uKbXgORekfADCjZshCoaohGejMNib.Length)
		{
			InputBehavior inputBehavior = uKbXgORekfADCjZshCoaohGejMNib[obj];
			if (uKbXgORekfADCjZshCoaohGejMNib[obj] != null)
			{
				string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey(player, inputBehavior._id);
				string value = uKbXgORekfADCjZshCoaohGejMNib[obj].ToXmlString();
				PlayerPrefs.SetString(inputBehaviorPlayerPrefsKey, value);
			}
			obj++;
			obj2 = obj;
		}
		JoystickMapSaveData[] array = default(JoystickMapSaveData[]);
		SaveControllerMaps(player, (PlayerSaveData)(&array));
	}

	private void SaveAllJoystickCalibrationData()
	{
		ReInput.ControllerHelper controllers = ReInput.controllers;
		IList<Joystick> joysticks = controllers.Joysticks;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int count = joysticks.Count;
			if (num < count)
			{
				Joystick joystick = joysticks.get_Item(num2);
				if (joystick != null)
				{
					JoystickCalibrationMapSaveData calibrationMapSaveData = joystick.GetCalibrationMapSaveData();
					string joystickCalibrationMapPlayerPrefsKey = GetJoystickCalibrationMapPlayerPrefsKey(joystick);
					string value = ((CalibrationMapSaveData)calibrationMapSaveData).VqnmAbwSDTqMLcgCPcmAKZuKctiu.ToXmlString();
					PlayerPrefs.SetString(joystickCalibrationMapPlayerPrefsKey, value);
				}
				num2++;
				num = num2;
				continue;
			}
			break;
		}
	}

	private void SaveJoystickCalibrationData(int joystickId)
	{
		ReInput.ControllerHelper controllers = ReInput.controllers;
		Joystick joystick = controllers.GetJoystick(joystickId);
		if (joystick != null)
		{
			JoystickCalibrationMapSaveData calibrationMapSaveData = joystick.GetCalibrationMapSaveData();
			string joystickCalibrationMapPlayerPrefsKey = GetJoystickCalibrationMapPlayerPrefsKey(joystick);
			string value = ((CalibrationMapSaveData)calibrationMapSaveData).VqnmAbwSDTqMLcgCPcmAKZuKctiu.ToXmlString();
			PlayerPrefs.SetString(joystickCalibrationMapPlayerPrefsKey, value);
		}
	}

	private void SaveJoystickCalibrationData(Joystick joystick)
	{
		if (joystick != null)
		{
			JoystickCalibrationMapSaveData calibrationMapSaveData = joystick.GetCalibrationMapSaveData();
			string joystickCalibrationMapPlayerPrefsKey = GetJoystickCalibrationMapPlayerPrefsKey(joystick);
			string value = ((CalibrationMapSaveData)calibrationMapSaveData).VqnmAbwSDTqMLcgCPcmAKZuKctiu.ToXmlString();
			PlayerPrefs.SetString(joystickCalibrationMapPlayerPrefsKey, value);
		}
	}

	private void SaveJoystickData(int joystickId)
	{
		ReInput.PlayerHelper players = ReInput.players;
		IList<Player> allPlayers = players.AllPlayers;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int count = allPlayers.Count;
			if (num >= count)
			{
				break;
			}
			Player player = allPlayers.get_Item(num2);
			if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
			{
				int id = player.id;
				SaveControllerMaps(id, ControllerType.Joystick, joystickId);
			}
			num2++;
			num = num2;
		}
		SaveJoystickCalibrationData(joystickId);
	}

	private void SaveControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
	{
		SaveControllerMaps(playerId, controllerType, controllerId);
		if (controllerType == ControllerType.Joystick)
		{
			SaveJoystickCalibrationData(controllerId);
		}
		PlayerPrefs.Save();
		PlayerPrefs.Save();
	}

	private void SaveControllerDataNow(ControllerType controllerType, int controllerId)
	{
		if (controllerType == ControllerType.Joystick)
		{
			SaveJoystickCalibrationData(controllerId);
		}
		PlayerPrefs.Save();
	}

	private unsafe void SaveControllerMaps(Player player, PlayerSaveData playerSaveData)
	{
		//IL_019f: Expected O, but got I
		IEnumerable<ControllerMapSaveData> allControllerMapSaveData = ((PlayerSaveData*)playerSaveData)->AllControllerMapSaveData;
		List<ControllerMapSaveData> list = (List<ControllerMapSaveData>)(object)new List<object>(allControllerMapSaveData);
		int num;
		int num2;
		if (_actionMappingSaveMode == ActionMappingSaveMode.ByControllerElementRole)
		{
			Comparison<ControllerMapSaveData> comparison = SortOldestToNewest;
			((List<object>)(object)list).Sort((Comparison<object>)comparison);
			num = 0;
			num2 = 0;
		}
		else
		{
			num = 0;
			num2 = 0;
		}
		while (true)
		{
			if (num >= list._size)
			{
				return;
			}
			ControllerMapSaveData controllerMapSaveData = list.get_Item(num2);
			ControllerMap map = controllerMapSaveData.map;
			if (_actionMappingSaveMode == ActionMappingSaveMode.ByController)
			{
				SaveControllerMapByController(player, map);
				num2++;
				num = num2;
				continue;
			}
			if (_actionMappingSaveMode != ActionMappingSaveMode.ByControllerElementRole)
			{
				break;
			}
			Controller controller = map.controller;
			SaveControllerMapByControllerElementRole(player, controller, map);
			num2++;
			num = num2;
		}
		ControllerMapSaveData controllerMapSaveData2 = ((List<ControllerMapSaveData>)(object)typeof(NotImplementedException)).get_Item(0);
		NotImplementedException ex = new NotImplementedException();
		ControllerMapSaveData controllerMapSaveData3 = ((List<ControllerMapSaveData>)0).get_Item(0);
		throw ex;
	}

	private void SaveControllerMaps(int playerId, ControllerType controllerType, int controllerId)
	{
		//IL_0137: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_0231: Expected O, but got I
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		ReInput.PlayerHelper players = ReInput.players;
		Player player = players.GetPlayer(playerId);
		if (player == null || !player.controllers.ContainsController(controllerType, controllerId))
		{
			return;
		}
		Player.ControllerHelper controllers = player.controllers;
		ControllerMapSaveData[] mapSaveData = controllers.maps.GetMapSaveData(controllerType, controllerId, userAssignableMapsOnly: true);
		if (mapSaveData == null)
		{
			return;
		}
		if (_actionMappingSaveMode == ActionMappingSaveMode.ByControllerElementRole)
		{
			List<ControllerMapSaveData> list = (List<ControllerMapSaveData>)(object)new List<object>(mapSaveData);
			Comparison<ControllerMapSaveData> comparison = SortOldestToNewest;
			((List<object>)(object)list).Sort((Comparison<object>)comparison);
			list.CopyTo(mapSaveData);
		}
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj >= mapSaveData.Length)
			{
				return;
			}
			ControllerMap map = mapSaveData[obj2].map;
			if (_actionMappingSaveMode == ActionMappingSaveMode.ByController)
			{
				SaveControllerMapByController(player, map);
				obj2++;
				obj = obj2;
				continue;
			}
			if (_actionMappingSaveMode != ActionMappingSaveMode.ByControllerElementRole)
			{
				break;
			}
			Controller controller = map.controller;
			SaveControllerMapByControllerElementRole(player, controller, map);
			obj2++;
			obj = obj2;
		}
		((List<ControllerMapSaveData>)(object)typeof(NotImplementedException)).CopyTo((ControllerMapSaveData[])null);
		NotImplementedException ex = new NotImplementedException();
		((List<ControllerMapSaveData>)0).CopyTo(null);
		throw ex;
	}

	private void SaveControllerMap(Player player, ControllerMap controllerMap)
	{
		if (_actionMappingSaveMode == ActionMappingSaveMode.ByController)
		{
			SaveControllerMapByController(player, controllerMap);
			return;
		}
		if (_actionMappingSaveMode == ActionMappingSaveMode.ByControllerElementRole)
		{
			Controller controller = controllerMap.controller;
			SaveControllerMapByControllerElementRole(player, controller, controllerMap);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		NotImplementedException ex = new NotImplementedException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	private unsafe void SaveControllerMapByController(Player player, ControllerMap controllerMap)
	{
		//IL_0060: Expected O, but got Ref
		//IL_00ce: Expected O, but got Ref
		Controller controller = controllerMap.controller;
		int categoryId = controllerMap.categoryId;
		int layoutId = controllerMap.layoutId;
		ControllerIdentifier controllerIdentifier = default(ControllerIdentifier);
		int layoutId2 = default(int);
		int ppKeyVersion = default(int);
		string controllerMapPlayerPrefsKey = GetControllerMapPlayerPrefsKey(player, (ControllerIdentifier)(&controllerIdentifier), categoryId, layoutId2, ppKeyVersion);
		string value = controllerMap.ToXmlString();
		PlayerPrefs.SetString(controllerMapPlayerPrefsKey, value);
		Controller controller2 = controllerMap.controller;
		int categoryId2 = controllerMap.categoryId;
		int layoutId3 = controllerMap.layoutId;
		string controllerMapKnownActionIdsPlayerPrefsKey = GetControllerMapKnownActionIdsPlayerPrefsKey(player, (ControllerIdentifier)(&controllerIdentifier), categoryId2, layoutId2, ppKeyVersion);
		if (string.IsNullOrEmpty(__allActionIdsString))
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<int> list = allActionIds;
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v20 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)num3 >= (nint)0)
				{
					break;
				}
				int value2;
				if (num > 0)
				{
					StringBuilder stringBuilder2 = stringBuilder.Append(",");
					value2 = list.get_Item(num);
				}
				else
				{
					value2 = list.get_Item(num);
				}
				StringBuilder stringBuilder3 = stringBuilder.Append(value2);
				num++;
				num2 = num;
			}
			string _allActionIdsString = stringBuilder.ToString();
			__allActionIdsString = _allActionIdsString;
		}
		PlayerPrefs.SetString(controllerMapKnownActionIdsPlayerPrefsKey, __allActionIdsString);
	}

	private unsafe void SaveControllerMapByControllerElementRole(Player player, Controller controller, ControllerMap controllerMap)
	{
		//IL_002a: Expected I, but got O
		//IL_002f: Expected I, but got O
		//IL_00b1: Expected O, but got I4
		//IL_02d8: Expected O, but got I
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Expected O, but got Unknown
		//IL_0199: Expected O, but got I4
		if (controller == null)
		{
			return;
		}
		SaveControllerMapByController(player, controllerMap);
		IList<ActionElementMap> elementMaps = controllerMap.ElementMaps;
		nint num = unchecked((nint)null);
		nint num2 = unchecked((nint)null);
		Dictionary<string, ControllerElementByRoleMap> dictionary = null;
		Player player2 = player;
		ControllerMap controllerMap2 = controllerMap;
		Controller.Element element = default(Controller.Element);
		object obj2 = default(object);
		ActionElementMap elementMap = default(ActionElementMap);
		int num3 = default(int);
		while (true)
		{
			int elementCount = controller.elementCount;
			if (num >= elementCount)
			{
				break;
			}
			IList<Controller.Element> elements = controller.Elements;
			((Dictionary<string, ControllerElementByRoleMap>)null).Add((string)(object)typeof(IList<Controller.Element>), (ControllerElementByRoleMap)elements);
			ControllerElementIdentifier elementIdentifier = element.elementIdentifier;
			if (!string.IsNullOrEmpty(elementIdentifier._role))
			{
				object obj = 0;
				player2 = null;
				while (true)
				{
					((Dictionary<string, ControllerElementByRoleMap>)null).Add((string)(object)typeof(ICollection<ActionElementMap>), (ControllerElementByRoleMap)elementMaps);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rax_v35+1C]");
					Controller.Element elementById = controller.GetElementById(0);
					if (elementById != null)
					{
						ControllerElementIdentifier elementIdentifier2 = elementById.elementIdentifier;
						bool flag = elementIdentifier2._role != elementIdentifier._role;
						bool flag2 = !flag;
						if (!flag)
						{
							Controller controller2 = controllerMap2.controller;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
							bool flag3 = AddControllerElementByRoleMapEntry(player, controller2, elementMap, ref *(Dictionary<string, ControllerElementByRoleMap>*)num3);
							bool flag4 = !flag2;
							player2 = (Player)flag4;
							controllerMap2 = controllerMap;
						}
					}
					obj++;
				}
				if (player2 == null)
				{
					bool flag5 = dictionary != null;
					Dictionary<string, ControllerElementByRoleMap> dictionary2 = dictionary;
					if (!flag5)
					{
						Dictionary<string, ControllerElementByRoleMap> dictionary3 = new Dictionary<string, ControllerElementByRoleMap>();
						dictionary2 = dictionary3;
						dictionary = dictionary3;
					}
					ControllerElementByRoleMap controllerElementByRoleMap = new ControllerElementByRoleMap();
					controllerElementByRoleMap.role = elementIdentifier._role;
					((Dictionary<object, object>)(object)dictionary2).Add((object)elementIdentifier._role, (object)controllerElementByRoleMap);
					controllerMap2 = controllerMap;
				}
			}
			num2++;
			num = num2;
		}
		if (dictionary == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		object obj3 = default(object);
		int ppKeyVersion = default(int);
		string value = default(string);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj3 == null)
				{
					break;
				}
				int categoryId = controllerMap.categoryId;
				int layoutId = controllerMap.layoutId;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ stack_-78+10]");
				string controllerElementByRoleMapPlayerPrefsKey = GetControllerElementByRoleMapPlayerPrefsKey(player, (string)0, categoryId, num3, ppKeyVersion);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1817B2820");
				PlayerPrefs.SetString(controllerElementByRoleMapPlayerPrefsKey, value);
				continue;
			}
			((Dictionary<string, ControllerElementByRoleMap>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe bool AddControllerElementByRoleMapEntry(Player player, Controller controller, ActionElementMap elementMap, ref Dictionary<string, ControllerElementByRoleMap> maps)
	{
		//IL_0214: Expected O, but got I
		//IL_0125: Expected O, but got I
		//IL_017e: Expected O, but got I
		//IL_0235: Expected I4, but got O
		//IL_0163: Expected O, but got Ref
		//IL_01c8: Expected O, but got I
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(elementMap._elementIdentifierId);
		if (elementIdentifierById != null && !string.IsNullOrEmpty(elementIdentifierById._role))
		{
			object obj = default(object);
			if (obj == null)
			{
				Dictionary<string, ControllerElementByRoleMap> dictionary = new Dictionary<string, ControllerElementByRoleMap>();
				obj = dictionary;
			}
			if (!((Dictionary<object, object>)obj).TryGetValue((object)elementIdentifierById._role, out object _))
			{
				ControllerElementByRoleMap controllerElementByRoleMap = new ControllerElementByRoleMap();
				controllerElementByRoleMap.role = elementIdentifierById._role;
				((Dictionary<object, object>)obj).Add((object)elementIdentifierById._role, (object)controllerElementByRoleMap);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rax_v26 (Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap)+18]");
			List<ControllerElementByRoleMap.Entry> list = (List<ControllerElementByRoleMap.Entry>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v12 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v12 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v12 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v10+18]");
			if (num >= 0)
			{
				object obj3 = default(object);
				list.AddWithResize((ControllerElementByRoleMap.Entry)(&obj3));
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v12 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
				object obj4 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v12 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v10+18]");
				if (num2 >= 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v12 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
				object obj5 = (nint)0 * (nint)4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v12 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_PlayerPrefs+ControllerElementByRoleMap+Entry>)+18]");
				object obj6 = 0 + obj5;
				_ = elementMap._actionId;
				_ = elementMap._axisContribution;
			}
			return true;
		}
		return false;
	}

	private void SaveInputBehaviors(Player player, PlayerSaveData playerSaveData)
	{
		//IL_0038: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00c6: Expected O, but got I4
		if (player == null)
		{
			return;
		}
		PlayerSaveData playerSaveData2 = default(PlayerSaveData);
		InputBehavior[] uKbXgORekfADCjZshCoaohGejMNib = playerSaveData2.uKbXgORekfADCjZshCoaohGejMNib;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < uKbXgORekfADCjZshCoaohGejMNib.Length)
		{
			InputBehavior inputBehavior = uKbXgORekfADCjZshCoaohGejMNib[obj2];
			if (uKbXgORekfADCjZshCoaohGejMNib[obj2] != null)
			{
				string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey(player, inputBehavior._id);
				string value = uKbXgORekfADCjZshCoaohGejMNib[obj2].ToXmlString();
				PlayerPrefs.SetString(inputBehaviorPlayerPrefsKey, value);
				playerSaveData2 = (PlayerSaveData)0;
			}
			obj2++;
			obj = obj2;
		}
	}

	private void SaveInputBehaviorNow(int playerId, int behaviorId)
	{
		ReInput.PlayerHelper players = ReInput.players;
		Player player = players.GetPlayer(playerId);
		if (player != null)
		{
			ReInput.MappingHelper mapping = ReInput.mapping;
			InputBehavior inputBehavior = mapping.GetInputBehavior(playerId, behaviorId);
			if (inputBehavior != null)
			{
				string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey(player, inputBehavior._id);
				string value = inputBehavior.ToXmlString();
				PlayerPrefs.SetString(inputBehaviorPlayerPrefsKey, value);
				PlayerPrefs.Save();
			}
		}
	}

	private void SaveInputBehaviorNow(Player player, InputBehavior inputBehavior)
	{
		if (player != null && inputBehavior != null)
		{
			string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey(player, inputBehavior._id);
			string value = inputBehavior.ToXmlString();
			PlayerPrefs.SetString(inputBehaviorPlayerPrefsKey, value);
		}
	}

	private unsafe bool SaveControllerAssignments()
	{
		//IL_0672: Expected I4, but got O
		//IL_0054: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00de: Expected I, but got O
		//IL_00ee: Expected O, but got I
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_053d: Expected O, but got I4
		//IL_0217: Expected O, but got I4
		//IL_0235: Expected I, but got O
		//IL_0245: Expected O, but got I
		//IL_0286: Expected O, but got I
		//IL_0578: Expected O, but got I4
		//IL_0389: Expected O, but got I4
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Expected O, but got Unknown
		//IL_0411: Expected O, but got I
		//IL_044b: Expected O, but got I4
		//IL_0469: Expected I, but got O
		//IL_0479: Expected O, but got I
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			int allPlayerCount = players.allPlayerCount;
			ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = new ControllerAssignmentSaveInfo();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			ControllerAssignmentSaveInfo.PlayerInfo[] players2 = new ControllerAssignmentSaveInfo.PlayerInfo[allPlayerCount];
			controllerAssignmentSaveInfo.players = players2;
			object obj = 0;
			object obj3 = default(object);
			ControllerAssignmentSaveInfo.PlayerInfo playerInfo3 = default(ControllerAssignmentSaveInfo.PlayerInfo);
			object obj6 = default(object);
			ControllerAssignmentSaveInfo.PlayerInfo playerInfo6 = default(ControllerAssignmentSaveInfo.PlayerInfo);
			Player player = default(Player);
			int num3 = default(int);
			object instanceGuid = default(object);
			object obj9 = default(object);
			object obj10 = default(object);
			string value2 = default(string);
			while (true)
			{
				if ((nint)obj < allPlayerCount)
				{
					ControllerAssignmentSaveInfo.PlayerInfo[] players3 = controllerAssignmentSaveInfo.players;
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo = new ControllerAssignmentSaveInfo.PlayerInfo();
					bool flag = controllerAssignmentSaveInfo.players == null;
					object obj2 = 0;
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo2 = playerInfo;
					if (flag)
					{
						break;
					}
					bool flag2 = playerInfo == null;
					obj2 = 0;
					playerInfo2 = playerInfo;
					if (!flag2)
					{
						nint num = (nint)players3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdx_v64 (Il2CppClass<PlayerInfo[]>)+40]");
						obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
						bool flag3 = obj3 == null;
						playerInfo2 = playerInfo;
						if (flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
							obj2 = 0;
							playerInfo2 = playerInfo3;
							throw playerInfo3;
						}
					}
					if ((nint)obj < players3.Length)
					{
						players3[obj] = playerInfo;
						obj++;
						continue;
					}
					throw new IndexOutOfRangeException();
				}
				object obj4 = 0;
				while (true)
				{
					ReInput.PlayerHelper players4 = ReInput.players;
					int allPlayerCount2 = players4.allPlayerCount;
					if ((nint)obj4 < allPlayerCount2)
					{
						ReInput.PlayerHelper players5 = ReInput.players;
						IList<Player> allPlayers = players5.AllPlayers;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
						ControllerAssignmentSaveInfo.PlayerInfo playerInfo4 = new ControllerAssignmentSaveInfo.PlayerInfo();
						ControllerAssignmentSaveInfo.PlayerInfo[] players6 = controllerAssignmentSaveInfo.players;
						bool flag4 = playerInfo4 == null;
						object obj5 = 0;
						ControllerAssignmentSaveInfo.PlayerInfo playerInfo5 = playerInfo4;
						IList<Player> list;
						object obj7;
						if (!flag4)
						{
							nint num2 = (nint)players6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ rdx_v57 (Il2CppClass<PlayerInfo[]>)+40]");
							obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							bool flag5 = obj6 == null;
							playerInfo5 = playerInfo4;
							list = allPlayers;
							obj7 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ rdx_v57 (Il2CppClass<PlayerInfo[]>)+40]");
							object obj2 = 0;
							ControllerAssignmentSaveInfo.PlayerInfo playerInfo2 = playerInfo4;
							if (flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
								obj5 = 0;
								playerInfo5 = playerInfo6;
								throw playerInfo6;
							}
						}
						bool flag6 = (nint)obj4 >= players6.Length;
						list = allPlayers;
						obj7 = obj4;
						if (flag6)
						{
							break;
						}
						players6[obj4] = playerInfo4;
						int id = player.id;
						playerInfo4.id = id;
						bool hasKeyboard = player.controllers.hasKeyboard;
						playerInfo4.hasKeyboard = hasKeyboard;
						bool hasMouse = player.controllers.hasMouse;
						playerInfo4.hasMouse = hasMouse;
						int joystickCount = player.controllers.joystickCount;
						ControllerAssignmentSaveInfo.JoystickInfo[] array = (playerInfo4.joysticks = new ControllerAssignmentSaveInfo.JoystickInfo[joystickCount]);
						object obj8 = 0;
						while (true)
						{
							int joystickCount2 = player.controllers.joystickCount;
							if ((nint)obj8 >= joystickCount2)
							{
								break;
							}
							IList<Joystick> joysticks = player.controllers.Joysticks;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
							ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = new ControllerAssignmentSaveInfo.JoystickInfo();
							int value = ((int*)num3)->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1228 @ rax_v90 (System.Int32)+180]");
							list = (IList<Player>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1228 @ rax_v90 (System.Int32)+178] (should have been resolved before IL gen)");
							joystickInfo.instanceGuid = (Guid)instanceGuid;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1225 @ rax_v87 (System.Int32)+10]");
							joystickInfo.id = 0;
							string hardwareIdentifier = ((Controller)num3).hardwareIdentifier;
							joystickInfo.hardwareIdentifier = hardwareIdentifier;
							nint num4 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1234 @ rdx_v54 (Il2CppClass<JoystickInfo[]>)+40]");
							obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							bool flag7 = obj9 == null;
							obj7 = obj8;
							playerInfo5 = (ControllerAssignmentSaveInfo.PlayerInfo)(object)joystickInfo;
							if (!flag7)
							{
								array[obj8] = joystickInfo;
								obj8++;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
							throw obj10;
						}
						obj4++;
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172327]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					string key = string.Format("{0}_{1}", playerPrefsKeyPrefix, "ControllerAssignments");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1817B2820");
					PlayerPrefs.SetString(key, value2);
					PlayerPrefs.Save();
					return true;
				}
				throw new IndexOutOfRangeException();
			}
			throw new NullReferenceException();
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool ControllerAssignmentSaveDataExists()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172327]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string key = string.Format("{0}_{1}", playerPrefsKeyPrefix, "ControllerAssignments");
		if (PlayerPrefs.HasKey(key))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172327]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string key2 = string.Format("{0}_{1}", playerPrefsKeyPrefix, "ControllerAssignments");
			string value = PlayerPrefs.GetString(key2);
			if (!string.IsNullOrEmpty(value))
			{
				return true;
			}
		}
		return false;
	}

	private unsafe string GetControllerMapPlayerPrefsKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
		//IL_0152: Expected O, but got Ref
		if (_sb != null)
		{
			_sb.Length = 0;
			if (_sb != null)
			{
				StringBuilder stringBuilder = _sb.Append(playerPrefsKeyPrefix);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172350]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (_sb != null)
				{
					StringBuilder stringBuilder2 = _sb.Append("|playerName=");
					if (player != null)
					{
						string value = player.name;
						StringBuilder stringBuilder3 = _sb.Append(value);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172351]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (_sb != null)
						{
							StringBuilder stringBuilder4 = _sb.Append("|dataType=ControllerMap");
							object obj = default(object);
							int layoutId2 = default(int);
							int ppKeyVersion2 = default(int);
							AppendControllerMapKeyCommonSuffix(_sb, player, (ControllerIdentifier)(&obj), categoryId, layoutId2, ppKeyVersion2);
							if (_sb != null)
							{
								return _sb.ToString();
							}
						}
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private string GetControllerElementByRoleMapPlayerPrefsKey(Player player, string elementRole, int categoryId, int layoutId, int ppKeyVersion)
	{
		if (_sb != null)
		{
			_sb.Length = 0;
			if (_sb != null)
			{
				StringBuilder stringBuilder = _sb.Append(playerPrefsKeyPrefix);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172350]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (_sb != null)
				{
					StringBuilder stringBuilder2 = _sb.Append("|playerName=");
					if (player != null)
					{
						string value = player.name;
						StringBuilder stringBuilder3 = _sb.Append(value);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172354]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (_sb != null)
						{
							StringBuilder stringBuilder4 = _sb.Append("|dataType=ElementRoleMap");
							StringBuilder stringBuilder5 = _sb.Append("|kv=");
							int value2 = default(int);
							StringBuilder stringBuilder6 = _sb.Append(value2);
							StringBuilder stringBuilder7 = _sb.Append("|categoryId=");
							StringBuilder stringBuilder8 = _sb.Append(categoryId);
							StringBuilder stringBuilder9 = _sb.Append("|layoutId=");
							int value3 = default(int);
							StringBuilder stringBuilder10 = _sb.Append(value3);
							StringBuilder stringBuilder11 = _sb.Append("|role=");
							StringBuilder stringBuilder12 = _sb.Append(elementRole);
							if (_sb != null)
							{
								return _sb.ToString();
							}
						}
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private unsafe string GetJoystickCalibrationMapPlayerPrefsKey(Joystick joystick)
	{
		//IL_008f: Expected O, but got Ref
		_sb.Length = 0;
		StringBuilder stringBuilder = _sb.Append(playerPrefsKeyPrefix);
		if (_sb != null)
		{
			StringBuilder stringBuilder2 = _sb.Append("|dataType=CalibrationMap");
			StringBuilder stringBuilder3 = _sb.Append("|controllerType=");
			if (joystick != null)
			{
				ControllerType type = joystick.type;
				IntPtr intPtr = default(IntPtr);
				string value = ((Enum)(&intPtr)).ToString();
				StringBuilder stringBuilder4 = _sb.Append(value);
				StringBuilder stringBuilder5 = _sb.Append("|hardwareIdentifier=");
				string hardwareIdentifier = joystick.hardwareIdentifier;
				StringBuilder stringBuilder6 = _sb.Append(hardwareIdentifier);
				StringBuilder stringBuilder7 = _sb.Append("|hardwareGuid=");
				Guid hardwareTypeGuid = joystick.hardwareTypeGuid;
				Guid guid = default(Guid);
				string value2 = guid.ToString();
				StringBuilder stringBuilder8 = _sb.Append(value2);
				return _sb.ToString();
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private unsafe string GetControllerMapKnownActionIdsPlayerPrefsKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
		//IL_0152: Expected O, but got Ref
		if (_sb != null)
		{
			_sb.Length = 0;
			if (_sb != null)
			{
				StringBuilder stringBuilder = _sb.Append(playerPrefsKeyPrefix);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172350]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (_sb != null)
				{
					StringBuilder stringBuilder2 = _sb.Append("|playerName=");
					if (player != null)
					{
						string value = player.name;
						StringBuilder stringBuilder3 = _sb.Append(value);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172352]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (_sb != null)
						{
							StringBuilder stringBuilder4 = _sb.Append("|dataType=ControllerMap_KnownActionIds");
							object obj = default(object);
							int layoutId2 = default(int);
							int ppKeyVersion2 = default(int);
							AppendControllerMapKeyCommonSuffix(_sb, player, (ControllerIdentifier)(&obj), categoryId, layoutId2, ppKeyVersion2);
							if (_sb != null)
							{
								return _sb.ToString();
							}
						}
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private string GetInputBehaviorPlayerPrefsKey(Player player, int inputBehaviorId)
	{
		if (_sb != null)
		{
			_sb.Length = 0;
			if (_sb != null)
			{
				StringBuilder stringBuilder = _sb.Append(playerPrefsKeyPrefix);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172350]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (_sb != null)
				{
					StringBuilder stringBuilder2 = _sb.Append("|playerName=");
					if (player != null)
					{
						string value = player.name;
						StringBuilder stringBuilder3 = _sb.Append(value);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172356]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (_sb != null)
						{
							StringBuilder stringBuilder4 = _sb.Append("|dataType=InputBehavior");
							StringBuilder stringBuilder5 = _sb.Append("|id=");
							StringBuilder stringBuilder6 = _sb.Append(inputBehaviorId);
							if (_sb != null)
							{
								return _sb.ToString();
							}
						}
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private static void AppendBaseKey(StringBuilder sb, string playerPrefsKeyPrefix)
	{
		StringBuilder stringBuilder = sb.Append(playerPrefsKeyPrefix);
	}

	private static void AppendPlayerKey(StringBuilder sb, Player player)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172350]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		StringBuilder stringBuilder = sb.Append("|playerName=");
		string value = player.name;
		StringBuilder stringBuilder2 = sb.Append(value);
	}

	private unsafe static void AppendControllerMapKey(StringBuilder sb, Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
		//IL_0062: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172351]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		StringBuilder stringBuilder = sb.Append("|dataType=ControllerMap");
		object obj = default(object);
		int layoutId2 = default(int);
		int ppKeyVersion2 = default(int);
		AppendControllerMapKeyCommonSuffix(sb, player, (ControllerIdentifier)(&obj), categoryId, layoutId2, ppKeyVersion2);
	}

	private unsafe static void AppendControllerMapKnownActionIdsKey(StringBuilder sb, Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
		//IL_0062: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172352]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		StringBuilder stringBuilder = sb.Append("|dataType=ControllerMap_KnownActionIds");
		object obj = default(object);
		int layoutId2 = default(int);
		int ppKeyVersion2 = default(int);
		AppendControllerMapKeyCommonSuffix(sb, player, (ControllerIdentifier)(&obj), categoryId, layoutId2, ppKeyVersion2);
	}

	private unsafe static void AppendControllerMapKeyCommonSuffix(StringBuilder sb, Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
		//IL_010b: Expected I, but got O
		//IL_0074: Expected O, but got I4
		//IL_0119: Expected O, but got I
		//IL_00f8: Expected I, but got O
		//IL_00e5: Expected I, but got O
		//IL_0363: Expected O, but got Ref
		//IL_00d2: Expected I, but got O
		//IL_0274: Expected O, but got Ref
		int num = default(int);
		if (num >= 2)
		{
			StringBuilder stringBuilder = sb.Append("|kv=");
			StringBuilder stringBuilder2 = sb.Append(num);
		}
		StringBuilder stringBuilder3 = sb.Append("|controllerMapType=");
		bool flag = controllerIdentifier.jWEHFBYpJqUErvsQFOkVsnBjEAQe == ControllerType.Keyboard;
		Guid rKtQsXAZcumTLjWzMqyhDpcCPQTx = default(Guid);
		nint num2;
		if (!flag)
		{
			object obj = controllerIdentifier.jWEHFBYpJqUErvsQFOkVsnBjEAQe - 1;
			if (!flag)
			{
				if ((nint)obj != 1)
				{
					if (controllerIdentifier.jWEHFBYpJqUErvsQFOkVsnBjEAQe != ControllerType.Custom)
					{
						string text = ((Enum)(&rKtQsXAZcumTLjWzMqyhDpcCPQTx)).ToString();
						string message = "Rewired: Unknown ControllerType " + text;
						Debug.LogWarning(message);
						throw new NullReferenceException();
					}
					num2 = (nint)typeof(CustomControllerMap);
				}
				else
				{
					num2 = (nint)typeof(JoystickMap);
				}
			}
			else
			{
				num2 = (nint)typeof(MouseMap);
			}
		}
		else
		{
			num2 = (nint)typeof(KeyboardMap);
		}
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)num2);
		string value = typeFromHandle.Name;
		StringBuilder stringBuilder4 = sb.Append(value);
		StringBuilder stringBuilder5 = sb.Append("|categoryId=");
		StringBuilder stringBuilder6 = sb.Append(categoryId);
		StringBuilder stringBuilder7 = sb.Append("|layoutId=");
		int value2 = default(int);
		StringBuilder stringBuilder8 = sb.Append(value2);
		object obj2 = default(object);
		if (num < 2)
		{
			StringBuilder stringBuilder9 = sb.Append("|hardwareIdentifier=");
			StringBuilder stringBuilder10 = sb.Append(controllerIdentifier.WqKxtyoOHIsKgjtDISLXKYcsazCQ);
			if (controllerIdentifier.jWEHFBYpJqUErvsQFOkVsnBjEAQe != ControllerType.Joystick)
			{
				return;
			}
			StringBuilder stringBuilder11 = sb.Append("|hardwareGuid=");
			object value3 = (Guid)obj2;
			StringBuilder stringBuilder12 = sb.Append(value3);
			if (num < 1)
			{
				return;
			}
		}
		else
		{
			StringBuilder stringBuilder13 = sb.Append("|hardwareGuid=");
			object value4 = (Guid)obj2;
			StringBuilder stringBuilder14 = sb.Append(value4);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
			object obj3 = default(object);
			if (obj3 != null)
			{
				StringBuilder stringBuilder15 = sb.Append("|hardwareIdentifier=");
				StringBuilder stringBuilder16 = sb.Append(controllerIdentifier.WqKxtyoOHIsKgjtDISLXKYcsazCQ);
			}
			if (controllerIdentifier.jWEHFBYpJqUErvsQFOkVsnBjEAQe != ControllerType.Joystick)
			{
				return;
			}
			rKtQsXAZcumTLjWzMqyhDpcCPQTx = controllerIdentifier.RKtQsXAZcumTLjWzMqyhDpcCPQTx;
		}
		StringBuilder stringBuilder17 = sb.Append("|duplicate=");
		int duplicateIndex = GetDuplicateIndex(player, (ControllerIdentifier)(&rKtQsXAZcumTLjWzMqyhDpcCPQTx));
		StringBuilder stringBuilder18 = sb.Append(duplicateIndex);
	}

	private static void AppendControllerElementByRoleMapKey(StringBuilder sb, string elementRole, int categoryId, int layoutId, int ppKeyVersion)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172354]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		StringBuilder stringBuilder = sb.Append("|dataType=ElementRoleMap");
		StringBuilder stringBuilder2 = sb.Append("|kv=");
		int value = default(int);
		StringBuilder stringBuilder3 = sb.Append(value);
		StringBuilder stringBuilder4 = sb.Append("|categoryId=");
		StringBuilder stringBuilder5 = sb.Append(categoryId);
		StringBuilder stringBuilder6 = sb.Append("|layoutId=");
		StringBuilder stringBuilder7 = sb.Append(layoutId);
		StringBuilder stringBuilder8 = sb.Append("|role=");
		StringBuilder stringBuilder9 = sb.Append(elementRole);
	}

	private unsafe static void AppendJoystickCalibrationMapKey(StringBuilder sb, Joystick joystick)
	{
		//IL_0044: Expected O, but got Ref
		StringBuilder stringBuilder = sb.Append("|dataType=CalibrationMap");
		StringBuilder stringBuilder2 = sb.Append("|controllerType=");
		ControllerType type = joystick.type;
		IntPtr intPtr = default(IntPtr);
		string value = ((Enum)(&intPtr)).ToString();
		StringBuilder stringBuilder3 = sb.Append(value);
		StringBuilder stringBuilder4 = sb.Append("|hardwareIdentifier=");
		string hardwareIdentifier = joystick.hardwareIdentifier;
		StringBuilder stringBuilder5 = sb.Append(hardwareIdentifier);
		StringBuilder stringBuilder6 = sb.Append("|hardwareGuid=");
		Guid hardwareTypeGuid = joystick.hardwareTypeGuid;
		Guid guid = default(Guid);
		string value2 = guid.ToString();
		StringBuilder stringBuilder7 = sb.Append(value2);
	}

	private static void AppendInputBehaviorKey(StringBuilder sb, int inputBehaviorId)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172356]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		StringBuilder stringBuilder = sb.Append("|dataType=InputBehavior");
		StringBuilder stringBuilder2 = sb.Append("|id=");
		StringBuilder stringBuilder3 = sb.Append(inputBehaviorId);
	}

	private unsafe string GetControllerMapXml(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		//IL_006f: Expected O, but got Ref
		string controllerMapPlayerPrefsKey;
		int geiFrJCKClSdmONIywDTURjYPJnTA = default(int);
		int layoutId2 = default(int);
		int ppKeyVersion = default(int);
		while (true)
		{
			controllerMapPlayerPrefsKey = GetControllerMapPlayerPrefsKey(player, (ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), categoryId, layoutId2, ppKeyVersion);
			bool flag = PlayerPrefs.HasKey(controllerMapPlayerPrefsKey);
			if (flag)
			{
				break;
			}
			bool flag2 = (flag ? 1 : 0) >= (false ? 1 : 0);
			geiFrJCKClSdmONIywDTURjYPJnTA = controllerIdentifier.geiFrJCKClSdmONIywDTURjYPJnTA;
			if (!flag2)
			{
				return null;
			}
		}
		return PlayerPrefs.GetString(controllerMapPlayerPrefsKey);
	}

	private unsafe List<int> GetControllerMapKnownActionIds(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		//IL_0194: Expected O, but got Ref
		//IL_0094: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		List<int> list = new List<int>();
		int geiFrJCKClSdmONIywDTURjYPJnTA = default(int);
		int layoutId2 = default(int);
		int ppKeyVersion = default(int);
		bool flag2;
		do
		{
			string controllerMapKnownActionIdsPlayerPrefsKey = GetControllerMapKnownActionIdsPlayerPrefsKey(player, (ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), categoryId, layoutId2, ppKeyVersion);
			bool flag = PlayerPrefs.HasKey(controllerMapKnownActionIdsPlayerPrefsKey);
			if (!flag)
			{
				flag2 = (flag ? 1 : 0) >= (false ? 1 : 0);
				geiFrJCKClSdmONIywDTURjYPJnTA = controllerIdentifier.geiFrJCKClSdmONIywDTURjYPJnTA;
				continue;
			}
			string text = PlayerPrefs.GetString(controllerMapKnownActionIdsPlayerPrefsKey);
			if (string.IsNullOrEmpty(text))
			{
				break;
			}
			string[] array = text.Split(',');
			int result = 0;
			object obj = 0;
			for (object obj2 = 0; (nint)obj2 < array.Length; obj++, obj2 = obj)
			{
				if ((nint)obj < array.Length)
				{
					if (string.IsNullOrEmpty(array[obj]))
					{
						continue;
					}
					if ((nint)obj < array.Length)
					{
						if (int.TryParse(array[obj], out result))
						{
							list.Add(result);
						}
						continue;
					}
				}
				return (List<int>)(object)new IndexOutOfRangeException();
			}
			break;
		}
		while (flag2);
		return list;
	}

	private string GetJoystickCalibrationMapXml(Joystick joystick)
	{
		//IL_005b: Expected O, but got I
		//IL_006b: Expected O, but got I
		string joystickCalibrationMapPlayerPrefsKey = GetJoystickCalibrationMapPlayerPrefsKey(joystick);
		if (PlayerPrefs.HasKey(joystickCalibrationMapPlayerPrefsKey))
		{
			return PlayerPrefs.GetString(joystickCalibrationMapPlayerPrefsKey);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v3+B8]");
		return (string)0;
	}

	private string GetInputBehaviorXml(Player player, int id)
	{
		//IL_005f: Expected O, but got I
		//IL_006f: Expected O, but got I
		string inputBehaviorPlayerPrefsKey = GetInputBehaviorPlayerPrefsKey(player, id);
		if (PlayerPrefs.HasKey(inputBehaviorPlayerPrefsKey))
		{
			return PlayerPrefs.GetString(inputBehaviorPlayerPrefsKey);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rax_v3+B8]");
		return (string)0;
	}

	private unsafe void AddDefaultMappingsForNewActions(ControllerIdentifier controllerIdentifier, ControllerMap controllerMap, List<int> knownActionIds)
	{
		//IL_00af: Expected O, but got Ref
		//IL_046f: Expected O, but got Ref
		//IL_01e2: Expected O, but got Ref
		//IL_0208: Expected O, but got I4
		//IL_02b4: Expected I4, but got O
		//IL_02e1: Expected I4, but got O
		//IL_0369: Expected O, but got Ref
		//IL_0394: Expected O, but got I4
		if (controllerMap == null || knownActionIds == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [knownActionIds @ r9 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		ReInput.MappingHelper mapping = ReInput.mapping;
		int categoryId = controllerMap.categoryId;
		int layoutId = controllerMap.layoutId;
		bool flag = mapping == null;
		ControllerMap controllerMap2 = controllerMap;
		if (!flag)
		{
			int num = default(int);
			ControllerMap controllerMapInstance = mapping.GetControllerMapInstance((ControllerIdentifier)(&num), categoryId, layoutId);
			if (controllerMapInstance == null)
			{
				return;
			}
			List<int> list = new List<int>();
			List<int> list2 = allActionIds;
			bool flag2 = list2 == null;
			controllerMap2 = (ControllerMap)(object)this;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
				List<int>.Enumerator enumerator = default(List<int>.Enumerator);
				int num2 = default(int);
				while (enumerator.MoveNext())
				{
					if (!knownActionIds.Contains(num2))
					{
						if (list == null)
						{
							throw new NullReferenceException();
						}
						list.Add(num2);
					}
				}
				enumerator.Dispose();
				bool flag3 = list == null;
				controllerMap2 = (ControllerMap)(&enumerator);
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
					if ((nint)0 == 0)
					{
						return;
					}
					IList<ActionElementMap> allMaps = controllerMapInstance.AllMaps;
					bool flag4 = allMaps == null;
					controllerMap2 = controllerMapInstance;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						IEnumerator<ActionElementMap> enumerator2 = default(IEnumerator<ActionElementMap>);
						object obj = (object)(&enumerator2);
						int num3 = layoutId;
						int num4 = num2;
						List<int>.Enumerator enumerator4 = default(List<int>.Enumerator);
						List<int>.Enumerator enumerator3 = enumerator4;
						IEnumerator<ActionElementMap> enumerator5 = null;
						object obj2 = 0;
						object obj3 = default(object);
						AxisRange axisRange = default(AxisRange);
						KeyCode keyCode2 = default(KeyCode);
						ModifierKeyFlags modifierKeyFlags2 = default(ModifierKeyFlags);
						int num5 = default(int);
						List<int>.Enumerator enumerator6 = default(List<int>.Enumerator);
						while (true)
						{
							if (enumerator2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								if (obj3 != null)
								{
									bool flag5 = enumerator2 == null;
									enumerator5 = null;
									if (!flag5)
									{
										ActionElementMap current = enumerator2.Current;
										if (current != null)
										{
											bool flag6 = list.Contains(current._actionId);
											bool flag7 = !flag6;
											num3 = (int)typeof(IEnumerator<ActionElementMap>);
											if (!flag7)
											{
												bool flag8 = controllerMap.DoesElementAssignmentConflict(current);
												num3 = (int)typeof(IEnumerator<ActionElementMap>);
												if (!flag8)
												{
													ControllerType controllerType = controllerMap.controllerType;
													KeyCode keyCode = current.keyCode;
													ModifierKeyFlags modifierKeyFlags = current.modifierKeyFlags;
													ElementAssignment elementAssignment = new ElementAssignment(controllerType, current._elementType, current._elementIdentifierId, axisRange, keyCode2, modifierKeyFlags2, num5, (Pole)current._axisRange, (byte)keyCode != 0);
													bool flag9 = controllerMap.CreateElementMap((ElementAssignment)(&enumerator6));
													num3 = current._elementIdentifierId;
													num4 = 0;
													enumerator3 = (List<int>.Enumerator)elementAssignment;
													obj2 = 1;
												}
											}
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
								}
								break;
							}
							throw new NullReferenceException();
						}
						if (obj2 != null)
						{
							controllerMap.isModified = false;
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private Joystick FindJoystickPrecise(ControllerAssignmentSaveInfo.JoystickInfo joystickInfo)
	{
		//IL_00a3: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		if (joystickInfo != null)
		{
			Guid instanceGuid = joystickInfo.instanceGuid;
			Guid empty = Guid.Empty;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
			object obj = default(object);
			if (obj == null)
			{
				ReInput.ControllerHelper controllers = ReInput.controllers;
				if (controllers != null)
				{
					IList<Joystick> joysticks = controllers.Joysticks;
					if (joysticks != null)
					{
						object obj2 = 0;
						object obj3 = 0;
						Guid empty2 = Guid.Empty;
						Guid instanceGuid2 = joystickInfo.instanceGuid;
						object obj4 = default(object);
						object obj5 = default(object);
						object obj7 = default(object);
						object obj8 = default(object);
						Joystick result = default(Joystick);
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
							if (obj5 != null)
							{
								object obj6 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ r9_v4+178] (should have been resolved before IL gen)");
								empty = joystickInfo.instanceGuid;
								instanceGuid = (Guid)obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
								if (obj8 == null)
								{
									obj3++;
									obj2 = obj3;
									empty2 = (Guid)obj7;
									instanceGuid2 = joystickInfo.instanceGuid;
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
								return result;
							}
							goto IL_0188;
						}
						goto IL_017e;
					}
				}
				goto IL_0188;
			}
		}
		goto IL_017e;
		IL_0188:
		return (Joystick)(object)new NullReferenceException();
		IL_017e:
		return null;
	}

	private unsafe bool TryFindJoysticksImprecise(ControllerAssignmentSaveInfo.JoystickInfo joystickInfo, out List<Joystick> matches)
	{
		//IL_0225: Expected I4, but got O
		ref List<Joystick> reference = ref *(List<Joystick>*)null;
		if (joystickInfo != null && !string.IsNullOrEmpty(joystickInfo.hardwareIdentifier))
		{
			ReInput.ControllerHelper controllers = ReInput.controllers;
			if (controllers != null)
			{
				IList<Joystick> joysticks = controllers.Joysticks;
				if (joysticks != null)
				{
					int num = 0;
					int num2 = 0;
					Joystick item = default(Joystick);
					while (true)
					{
						int count = joysticks.Count;
						if (num < count)
						{
							Joystick joystick = joysticks.get_Item(num2);
							if (joystick == null)
							{
								break;
							}
							string hardwareIdentifier = joystick.hardwareIdentifier;
							if (string.Equals(hardwareIdentifier, joystickInfo.hardwareIdentifier, StringComparison.OrdinalIgnoreCase))
							{
								if (matches == null)
								{
									List<Joystick> list = new List<Joystick>();
									reference = ref *(List<Joystick>*)list;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
								if (matches == null)
								{
									break;
								}
								matches.Add(item);
							}
							num2++;
							num = num2;
							continue;
						}
						bool flag = (nint)matches < 0;
						bool flag2 = matches == null;
						bool flag3 = !flag;
						bool flag4 = !flag2;
						return flag4 & flag3;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private unsafe static int GetDuplicateIndex(Player player, ControllerIdentifier controllerIdentifier)
	{
		//IL_0057: Expected O, but got Ref
		//IL_0072: Expected I4, but got O
		//IL_0103: Expected O, but got Ref
		//IL_01cc: Expected I, but got O
		//IL_044b: Expected I, but got O
		//IL_020f: Expected I, but got O
		//IL_021d: Expected I, but got O
		//IL_022d: Expected O, but got I
		//IL_0269: Expected O, but got I
		//IL_0499: Expected I, but got O
		//IL_02a6: Expected O, but got I
		//IL_02ae: Expected I, but got O
		//IL_02be: Expected O, but got I
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_05ac: Expected O, but got Ref
		//IL_05ac: Expected O, but got Ref
		//IL_033b: Expected I, but got O
		//IL_0348: Expected O, but got I4
		//IL_0350: Expected O, but got Ref
		//IL_038e: Expected O, but got Ref
		//IL_038e: Expected O, but got Ref
		//IL_03a0: Expected I4, but got O
		//IL_03b6: Expected I4, but got O
		ReInput.ControllerHelper controllers = ReInput.controllers;
		int result;
		if (controllers != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [controllerIdentifier @ rdx (Rewired.ControllerIdentifier)+10]");
			int num = 0;
			Guid guid = controllerIdentifier.GJgdWGVVIcKdNIXnufUhLdsqTUZH;
			int num2 = default(int);
			Controller controller = controllers.GetController((ControllerIdentifier)(&num2));
			bool flag = controller == null;
			result = (int)controller;
			if (flag)
			{
				goto IL_0540;
			}
			if (player != null && player.controllers != null)
			{
				IEnumerable<Controller> controllers2 = player.controllers.Controllers;
				if (controllers2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					IEnumerator<Controller> enumerator = default(IEnumerator<Controller>);
					object obj = (object)(&enumerator);
					int num3 = 0;
					IEnumerator<Controller> enumerator2 = null;
					object obj2 = default(object);
					int num9 = default(int);
					int num10 = default(int);
					int a = default(int);
					while (true)
					{
						Controller current;
						int num11;
						int num12;
						Guid guid2;
						nint num4;
						if (enumerator != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							if (obj2 != null)
							{
								bool flag2 = enumerator == null;
								enumerator2 = null;
								if (!flag2)
								{
									current = enumerator.Current;
									if (current != null)
									{
										ControllerType type = current.type;
										ControllerType type2 = controller.type;
										bool flag3 = type != type2;
										num4 = (nint)typeof(IEnumerator<Controller>);
										if (flag3)
										{
											continue;
										}
										ControllerType type3 = controller.type;
										if (type3 == ControllerType.Joystick)
										{
											nint num5 = (nint)current;
											nint num6 = (nint)typeof(Joystick);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r8_v20 (Il2CppClass<Rewired.Joystick>)+130]");
											Controller controller2 = (Controller)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v28 (Il2CppClass<Rewired.Controller>)+130]");
											nint num7 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r8_v20 (Il2CppClass<Rewired.Joystick>)+130]");
											if (num7 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v28 (Il2CppClass<Rewired.Controller>)+C8]");
												object obj3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v39+FFFFFFF8+v194 @ rax_v38 (Rewired.Controller)*8]");
												if (0 == (nint)typeof(Joystick))
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ r8_v20 (Il2CppClass<Rewired.Joystick>)+130]");
													object obj4 = 0;
													nint num8 = (nint)current;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v781 @ rax_v40 (Il2CppClass<Rewired.Controller>)+C8]");
													object obj5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rcx_v31+FFFFFFF8+v780 @ rdx_v29*8]");
													object obj6 = 0 - typeof(Joystick);
													bool flag4 = obj6 == null;
													bool flag5 = !flag4;
													Controller controller3 = null;
													if (!flag5)
													{
														controller3 = current;
													}
													Guid hardwareTypeGuid = controller3.hardwareTypeGuid;
													num9 = hardwareTypeGuid._a;
													Guid hardwareTypeGuid2 = controller.hardwareTypeGuid;
													bool flag6 = (Guid)(&num10) == (Guid)(&a);
													num10 = hardwareTypeGuid._a;
													a = hardwareTypeGuid2._a;
													num4 = (nint)typeof(IEnumerator<Controller>);
													guid = (Guid)hardwareTypeGuid2._a;
													enumerator2 = (IEnumerator<Controller>)(&num10);
													if (!flag6)
													{
														continue;
													}
													Guid hardwareTypeGuid3 = controller.hardwareTypeGuid;
													guid = Guid.Empty;
													num = hardwareTypeGuid3._a;
													bool flag7 = (Guid)(&a) != (Guid)(&num10);
													num10 = (int)Guid.Empty;
													a = hardwareTypeGuid3._a;
													num10 = (int)Guid.Empty;
													a = hardwareTypeGuid3._a;
													num11 = hardwareTypeGuid._a;
													num12 = hardwareTypeGuid3._a;
													guid2 = Guid.Empty;
													if (!flag7)
													{
														goto IL_03f5;
													}
													goto IL_0459;
												}
											}
											throw new NullReferenceException();
										}
										goto IL_03f5;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
							}
							break;
						}
						throw new NullReferenceException();
						IL_0459:
						if (current != controller)
						{
							num3++;
							num9 = num11;
							num4 = (nint)typeof(IEnumerator<Controller>);
							num = num12;
							guid = guid2;
							continue;
						}
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						}
						break;
						IL_03f5:
						string hardwareIdentifier = current.hardwareIdentifier;
						string hardwareIdentifier2 = controller.hardwareIdentifier;
						bool flag8 = hardwareIdentifier != hardwareIdentifier2;
						num11 = num9;
						num12 = num;
						guid2 = guid;
						num4 = (nint)typeof(IEnumerator<Controller>);
						if (flag8)
						{
							continue;
						}
						goto IL_0459;
					}
					result = num3;
					goto IL_0540;
				}
			}
		}
		throw new NullReferenceException();
		IL_0540:
		return result;
	}

	private void RefreshLayoutManager(int playerId)
	{
		ReInput.PlayerHelper players = ReInput.players;
		Player player = players.GetPlayer(playerId);
		if (player != null)
		{
			Player.ControllerHelper controllers = player.controllers;
			Player.ControllerHelper.MapHelper maps = controllers.maps;
			maps.ZTANhMenjbgZacEQYZVeToTTPxnKA.Apply();
		}
	}

	private void OnControllerMapsSaved(Player player)
	{
		if (_actionMappingSaveMode != ActionMappingSaveMode.ByControllerElementRole)
		{
			return;
		}
		int joystickCount = player.controllers.joystickCount;
		if (joystickCount > 1)
		{
			int num = 0;
			do
			{
				int id = player.id;
				IList<Joystick> joysticks = player.controllers.Joysticks;
				Joystick joystick = joysticks.get_Item(num);
				int num2 = LoadControllerMaps(id, ControllerType.Joystick, joystick.id);
				num++;
			}
			while (num < joystickCount);
			int id2 = player.id;
			ReInput.PlayerHelper players = ReInput.players;
			Player player2 = players.GetPlayer(id2);
			if (player2 != null)
			{
				Player.ControllerHelper controllers = player2.controllers;
				Player.ControllerHelper.MapHelper maps = controllers.maps;
				maps.ZTANhMenjbgZacEQYZVeToTTPxnKA.Apply();
			}
		}
	}

	private unsafe static Type GetControllerMapType(ControllerType controllerType)
	{
		//IL_00d6: Expected I, but got O
		//IL_0013: Expected O, but got I4
		//IL_00e4: Expected O, but got I
		//IL_00c3: Expected I, but got O
		//IL_00b0: Expected I, but got O
		//IL_009d: Expected I, but got O
		//IL_0064: Expected O, but got Ref
		bool flag = controllerType == ControllerType.Keyboard;
		nint num;
		if (!flag)
		{
			object obj = controllerType - 1;
			if (!flag)
			{
				if ((nint)obj != 1)
				{
					if (controllerType != ControllerType.Custom)
					{
						object obj2 = default(object);
						string text = ((Enum)(&obj2)).ToString();
						string message = "Rewired: Unknown ControllerType " + text;
						Debug.LogWarning(message);
						return null;
					}
					num = (nint)typeof(CustomControllerMap);
				}
				else
				{
					num = (nint)typeof(JoystickMap);
				}
			}
			else
			{
				num = (nint)typeof(MouseMap);
			}
		}
		else
		{
			num = (nint)typeof(KeyboardMap);
		}
		return Type.GetTypeFromHandle((RuntimeTypeHandle)num);
	}

	private static int SortOldestToNewest(ControllerMapSaveData a, ControllerMapSaveData b)
	{
		//IL_0155: Expected I4, but got O
		//IL_0133: Unsupported input type for neg.
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected I4, but got Unknown
		if (a != null)
		{
			ControllerMap map = a.map;
			if (b != null)
			{
				if (map == null)
				{
					ControllerMap map2 = b.map;
					int result = 0 - map2;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb eax,eax\"");
					return result;
				}
				ControllerMap map3 = b.map;
				if (map3 == null)
				{
					return 1;
				}
				ControllerMap map4 = a.map;
				if (map4 != null)
				{
					double modifiedTime = map4.modifiedTime;
					ControllerMap map5 = b.map;
					if (map5 != null)
					{
						double modifiedTime2 = map5.modifiedTime;
						double num = default(double);
						return num.CompareTo(modifiedTime2);
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public UserDataStore_PlayerPrefs()
	{
		StringBuilder sb = new StringBuilder();
		_sb = sb;
		base._002Ector();
	}
}
