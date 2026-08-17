using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data;

public abstract class UserDataStore_KeyValue : UserDataStore
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

	protected interface IDataStore
	{
		bool Save();

		bool Load();

		bool Clear();

		bool TryGetValue(string key, out object result);

		bool SetValue(string key, object value);
	}

	[Serializable]
	protected class ControllerElementByRoleMap
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_KeyValue+ControllerElementByRoleMap+Entry>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_KeyValue+ControllerElementByRoleMap+Entry>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_KeyValue+ControllerElementByRoleMap+Entry>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v3+18]");
			if (num >= 0)
			{
				object obj2 = default(object);
				list.AddWithResize((Entry)(&obj2));
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_KeyValue+ControllerElementByRoleMap+Entry>)+18]");
			object obj3 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_KeyValue+ControllerElementByRoleMap+Entry>)+18]");
			object obj4 = (nint)0 * (nint)4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_KeyValue+ControllerElementByRoleMap+Entry>)+18]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v27 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_KeyValue+ControllerElementByRoleMap+Entry>)+18]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v18 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_KeyValue+ControllerElementByRoleMap+Entry>)+18]");
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

	private sealed class _003C_003Ec__DisplayClass79_0
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

	private sealed class _003C_003Ec__DisplayClass79_1
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

	private sealed class _003C_003Ec__DisplayClass79_2
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

	private sealed class _003CLoadJoystickAssignmentsDeferred_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UserDataStore_KeyValue _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CLoadJoystickAssignmentsDeferred_003Ed__81(int _003C_003E1__state)
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
			UserDataStore_KeyValue userDataStore_KeyValue = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					userDataStore_KeyValue._deferredJoystickAssignmentLoadPending = true;
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
					userDataStore_KeyValue._deferredJoystickAssignmentLoadPending = false;
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

	private static readonly string thisScriptName;

	private const string logPrefix = "Rewired: ";

	private const string key_controllerAssignments = "ControllerAssignments";

	private const int controllerMapKeyVersion = 0;

	private const int controllerElementByRoleMapKeyVersion = 0;

	private bool _isEnabled = true;

	private bool _loadDataOnStart;

	private bool _loadJoystickAssignments;

	private bool _loadKeyboardAssignments;

	private bool _loadMouseAssignments = true;

	private ActionMappingSaveMode _actionMappingSaveMode;

	[NonSerialized]
	private bool _allowImpreciseJoystickAssignmentMatching = true;

	[NonSerialized]
	private bool _deferredJoystickAssignmentLoadPending;

	[NonSerialized]
	private bool _wasJoystickEverDetected;

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

	public bool isEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			_isEnabled = value;
		}
	}

	public bool loadDataOnStart
	{
		get
		{
			return _loadDataOnStart;
		}
		set
		{
			_loadDataOnStart = value;
		}
	}

	public bool loadJoystickAssignments
	{
		get
		{
			return _loadJoystickAssignments;
		}
		set
		{
			_loadJoystickAssignments = value;
		}
	}

	public bool loadKeyboardAssignments
	{
		get
		{
			return _loadKeyboardAssignments;
		}
		set
		{
			_loadKeyboardAssignments = value;
		}
	}

	public bool loadMouseAssignments
	{
		get
		{
			return _loadMouseAssignments;
		}
		set
		{
			_loadMouseAssignments = value;
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

	protected abstract IDataStore dataStore { get; }

	private bool loadControllerAssignments
	{
		get
		{
			if (!_loadKeyboardAssignments && !_loadMouseAssignments)
			{
				return _loadJoystickAssignments;
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
		if (_isEnabled)
		{
			SaveAll();
			return;
		}
		string message = "Rewired: " + thisScriptName + " is disabled and will not save any data.";
		Debug.LogWarning(message, this);
	}

	public override void SaveControllerData(int playerId, ControllerType controllerType, int controllerId)
	{
		if (_isEnabled)
		{
			SaveControllerMaps(playerId, controllerType, controllerId);
			SaveControllerData(controllerType, controllerId);
		}
		else
		{
			string message = "Rewired: " + thisScriptName + " is disabled and will not save any data.";
			Debug.LogWarning(message, this);
		}
	}

	public override void SaveControllerData(ControllerType controllerType, int controllerId)
	{
		if (_isEnabled)
		{
			if (controllerType == ControllerType.Joystick)
			{
				SaveJoystickCalibrationData(controllerId);
			}
		}
		else
		{
			string message = "Rewired: " + thisScriptName + " is disabled and will not save any data.";
			Debug.LogWarning(message, this);
		}
	}

	public override void SavePlayerData(int playerId)
	{
		if (_isEnabled)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(playerId);
			SavePlayerDataNow(player);
			IDataStore dataStore = this.dataStore;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			OnControllerMapsSaved(player);
		}
		else
		{
			string message = "Rewired: " + thisScriptName + " is disabled and will not save any data.";
			Debug.LogWarning(message, this);
		}
	}

	public override void SaveInputBehavior(int playerId, int behaviorId)
	{
		if (_isEnabled)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(playerId);
			if (player != null)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				InputBehavior inputBehavior = mapping.GetInputBehavior(playerId, behaviorId);
				if (inputBehavior != null)
				{
					string inputBehaviorKey = GetInputBehaviorKey(player, inputBehavior._id);
					IDataStore dataStore = this.dataStore;
					string text = inputBehavior.ToJsonString();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					IDataStore dataStore2 = this.dataStore;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				}
			}
		}
		else
		{
			string message = "Rewired: " + thisScriptName + " is disabled and will not save any data.";
			Debug.LogWarning(message, this);
		}
	}

	public override void Load()
	{
		if (_isEnabled)
		{
			int num = LoadAll();
			return;
		}
		string message = "Rewired: " + thisScriptName + " is disabled and will not load any data.";
		Debug.LogWarning(message, this);
	}

	public override void LoadControllerData(int playerId, ControllerType controllerType, int controllerId)
	{
		if (_isEnabled)
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
			string message = "Rewired: " + thisScriptName + " is disabled and will not load any data.";
			Debug.LogWarning(message, this);
		}
	}

	public override void LoadControllerData(ControllerType controllerType, int controllerId)
	{
		if (_isEnabled)
		{
			if (controllerType == ControllerType.Joystick)
			{
				int num = LoadJoystickCalibrationData(controllerId);
			}
		}
		else
		{
			string message = "Rewired: " + thisScriptName + " is disabled and will not load any data.";
			Debug.LogWarning(message, this);
		}
	}

	public override void LoadPlayerData(int playerId)
	{
		if (_isEnabled)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(playerId);
			int num = LoadPlayerDataNow(player);
		}
		else
		{
			string message = "Rewired: " + thisScriptName + " is disabled and will not load any data.";
			Debug.LogWarning(message, this);
		}
	}

	public override void LoadInputBehavior(int playerId, int behaviorId)
	{
		if (_isEnabled)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(playerId);
			if (player != null)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				InputBehavior inputBehavior = mapping.GetInputBehavior(playerId, behaviorId);
				if (inputBehavior != null)
				{
					int num = LoadInputBehaviorNow(player, inputBehavior);
				}
			}
		}
		else
		{
			string message = "Rewired: " + thisScriptName + " is disabled and will not load any data.";
			Debug.LogWarning(message, this);
		}
	}

	protected override void OnInitialize()
	{
		if (!_loadDataOnStart)
		{
			return;
		}
		Load();
		if (_loadKeyboardAssignments || _loadMouseAssignments || _loadJoystickAssignments)
		{
			ReInput.ControllerHelper controllers = ReInput.controllers;
			int joystickCount = controllers.joystickCount;
			if (joystickCount > 0)
			{
				_wasJoystickEverDetected = true;
				bool flag = SaveControllerAssignments();
			}
		}
	}

	protected override void OnControllerConnected(ControllerStatusChangedEventArgs args)
	{
		if (!_isEnabled || args.TBJGBmgQOKlmSbcCWSMuasdljEDyA != ControllerType.Joystick)
		{
			return;
		}
		int num = LoadJoystickData(args.iXAVgsIWgELasbcfAfmXauTcmuqDA);
		if (_loadDataOnStart)
		{
			if (!_loadJoystickAssignments)
			{
				goto IL_0129;
			}
			if (!_wasJoystickEverDetected)
			{
				_003CLoadJoystickAssignmentsDeferred_003Ed__81 obj = new _003CLoadJoystickAssignmentsDeferred_003Ed__81(0);
				obj._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj);
			}
		}
		if (_loadJoystickAssignments && !_deferredJoystickAssignmentLoadPending)
		{
			bool flag = SaveControllerAssignments();
		}
		goto IL_0129;
		IL_0129:
		_wasJoystickEverDetected = true;
	}

	protected override void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
	{
		if (_isEnabled && args.TBJGBmgQOKlmSbcCWSMuasdljEDyA == ControllerType.Joystick)
		{
			SaveJoystickData(args.iXAVgsIWgELasbcfAfmXauTcmuqDA);
		}
	}

	protected override void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
		if (_isEnabled && (_loadKeyboardAssignments || _loadMouseAssignments || _loadJoystickAssignments))
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
				IDataStore dataStore = this.dataStore;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
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

	public virtual void ClearSaveData()
	{
		IDataStore dataStore = this.dataStore;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
	}

	private int LoadAll()
	{
		//IL_016f: Expected I4, but got O
		bool flag2;
		if (!_loadKeyboardAssignments && !_loadMouseAssignments)
		{
			bool flag = !_loadJoystickAssignments;
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
		//IL_005e: Expected I4, but got O
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			Player player = players.GetPlayer(playerId);
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 59 Invalid \"Jump target not found in method: 0x180399AC0\"");
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
					UserDataStore_KeyValue userDataStore_KeyValue = null;
					object obj3 = default(object);
					while (true)
					{
						if (enumerator != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							if (obj3 != null)
							{
								bool flag = enumerator == null;
								userDataStore_KeyValue = null;
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
		//IL_0174: Expected I4, but got O
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
						string joystickCalibrationMapKey = GetJoystickCalibrationMapKey(joystick);
						IDataStore store = dataStore;
						bool flag = TryGetString(store, joystickCalibrationMapKey, out var result);
						bool flag2 = joystick.ImportCalibrationMapFromJsonString(result);
						bool flag3 = !flag2;
						bool flag4 = !flag3;
						num2 += (flag4 ? 1 : 0);
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
		if (joystick != null)
		{
			string joystickCalibrationMapKey = GetJoystickCalibrationMapKey(joystick);
			IDataStore store = dataStore;
			bool flag = TryGetString(store, joystickCalibrationMapKey, out var result);
			if (joystick.ImportCalibrationMapFromJsonString(result))
			{
				return 1;
			}
		}
		return 0;
	}

	private int LoadJoystickCalibrationData(int joystickId)
	{
		//IL_0062: Expected I4, but got O
		ReInput.ControllerHelper controllers = ReInput.controllers;
		if (controllers != null)
		{
			Joystick joystick = controllers.GetJoystick(joystickId);
			return LoadJoystickCalibrationData(joystick);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int LoadJoystickData(int joystickId)
	{
		//IL_0207: Expected I4, but got O
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
					ReInput.ControllerHelper controllers = ReInput.controllers;
					if (controllers == null)
					{
						break;
					}
					Joystick joystick = controllers.GetJoystick(joystickId);
					int num5 = LoadJoystickCalibrationData(joystick);
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
		//IL_148a: Expected O, but got I4
		//IL_0196: Expected O, but got I4
		//IL_019f: Expected O, but got I4
		//IL_01e8: Expected I, but got O
		//IL_02ab: Expected I4, but got O
		//IL_021f: Expected O, but got I
		//IL_1513: Expected O, but got I4
		//IL_02eb: Expected I4, but got O
		//IL_05c9: Expected O, but got I4
		//IL_05df: Expected O, but got I
		//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Expected O, but got Unknown
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Expected O, but got Unknown
		//IL_0336: Expected I4, but got O
		//IL_0383: Expected I4, but got O
		//IL_03c8: Expected I4, but got O
		//IL_0631: Expected I4, but got O
		//IL_0426: Expected I4, but got O
		//IL_042e: Expected I4, but got O
		//IL_14ee: Expected O, but got I
		//IL_0451: Expected O, but got I
		//IL_0461: Expected O, but got I
		//IL_048a: Expected O, but got Ref
		//IL_04ad: Expected O, but got I
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Expected O, but got Unknown
		//IL_06b8: Expected I4, but got O
		//IL_06c0: Expected I4, but got O
		//IL_06e7: Expected I4, but got O
		//IL_04f1: Expected I4, but got O
		//IL_0526: Expected I4, but got O
		//IL_053e: Expected O, but got I
		//IL_08e5: Expected O, but got Ref
		//IL_0565: Expected O, but got I
		//IL_0591: Expected O, but got I
		//IL_095f: Expected I4, but got O
		//IL_075e: Expected I4, but got O
		//IL_0766: Expected I4, but got O
		//IL_0921: Expected O, but got I4
		//IL_07ae: Expected I4, but got O
		//IL_1323: Expected O, but got I
		//IL_1333: Expected O, but got I
		//IL_1343: Expected O, but got I
		//IL_07e6: Expected I4, but got O
		//IL_0b3a: Expected O, but got I4
		//IL_081c: Expected I4, but got O
		//IL_0ad1: Expected O, but got I
		//IL_0ae1: Expected O, but got I
		//IL_0af1: Expected O, but got I
		//IL_0b9d: Expected I4, but got O
		//IL_0a83: Expected O, but got I4
		//IL_086e: Expected I4, but got O
		//IL_0876: Expected I4, but got O
		//IL_0c37: Expected O, but got I4
		//IL_0c49: Expected O, but got I4
		//IL_0e29: Expected O, but got I
		//IL_0e39: Expected O, but got I
		//IL_0e51: Expected O, but got I
		//IL_0e64: Expected I, but got O
		//IL_1731: Expected O, but got I
		//IL_1747: Expected O, but got Ref
		//IL_0c86: Expected I4, but got O
		//IL_0c8e: Expected I4, but got O
		//IL_1818: Expected O, but got I4
		//IL_12dc: Expected O, but got I
		//IL_0cdd: Expected I, but got O
		//IL_12a4: Expected I4, but got O
		//IL_12a9: Expected I, but got O
		//IL_162d: Expected O, but got I4
		//IL_0eda: Expected O, but got I4
		//IL_0ee2: Expected I4, but got O
		//IL_0d66: Expected I4, but got O
		//IL_0f10: Expected O, but got I4
		//IL_0f3d: Expected I4, but got O
		//IL_0dac: Expected I, but got O
		//IL_0de5: Expected O, but got I4
		//IL_0f7d: Expected O, but got I4
		//IL_0f85: Expected I4, but got O
		//IL_0fbb: Expected O, but got I4
		//IL_0fc3: Expected I4, but got O
		//IL_0ff3: Expected O, but got I
		//IL_105c: Expected O, but got I
		//IL_10aa: Expected O, but got I
		//IL_10c9: Expected O, but got I4
		//IL_183e: Expected O, but got I
		//IL_113d: Expected O, but got I4
		//IL_1145: Expected I4, but got O
		//IL_114d: Expected O, but got Ref
		//IL_166f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1674: Expected O, but got Unknown
		//IL_116c: Expected O, but got Ref
		//IL_1185: Expected O, but got I4
		//IL_118e: Expected O, but got I4
		//IL_119b: Expected I, but got O
		//IL_11a3: Expected O, but got Ref
		//IL_11e1: Expected I, but got O
		//IL_11e9: Expected O, but got Ref
		//IL_120f: Expected O, but got I
		//IL_122a: Expected O, but got I
		//IL_1699: Expected O, but got I4
		//IL_16a2: Expected O, but got I4
		//IL_16b3: Expected O, but got I4
		//IL_16c2: Expected O, but got I4
		//IL_1287: Expected O, but got I4
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
				goto IL_146c;
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
					goto IL_146c;
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
									goto IL_025e;
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
									goto IL_025e;
								}
								object obj4 = num8 + num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ r8_v62+8+v1753 @ rcx_v108*8]");
								object obj5 = (nint)0 << 4;
								object obj6 = obj5 + 312;
								object obj7 = obj6 + num6;
								goto IL_026d;
							}
							return num3;
							IL_026d:
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
											goto end_IL_1787;
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
												goto end_IL_1787;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v18 (Rewired.ReInput+MappingHelper)+60]");
											bool flag12 = (nint)0 == 0;
											num2 = (int)player2;
											controllerType2 = (ControllerType)(int)(&controllerIdentifier);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v18 (Rewired.ReInput+MappingHelper)+60]");
											mappingHelper = (ReInput.MappingHelper)0;
											if (flag12)
											{
												goto end_IL_1787;
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
										goto IL_1550;
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
											mappingHelper = (ReInput.MappingHelper)(this + 72);
											bool flag14 = dictionary2 == null;
											dictionary = dictionary2;
											num = num11;
											num2 = (int)dictionary2;
											controllerType2 = (ControllerType)list2;
											if (flag14)
											{
												goto end_IL_1787;
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
												goto end_IL_1787;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
											bool flag16 = element == null;
											num = num14;
											num2 = (int)typeof(IList<Controller.Element>);
											controllerType2 = (ControllerType)elements;
											mappingHelper = null;
											if (flag16)
											{
												goto end_IL_1787;
											}
											ControllerElementIdentifier elementIdentifier = element.elementIdentifier;
											bool flag17 = elementIdentifier == null;
											num = num14;
											num2 = 0;
											controllerType2 = (ControllerType)elements;
											mappingHelper = (ReInput.MappingHelper)(object)element;
											if (flag17)
											{
												goto end_IL_1787;
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
													goto end_IL_1787;
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
											goto end_IL_1787;
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
												goto end_IL_1787;
											}
											ControllerType type2 = controller2.type;
											bool flag23 = controllers2.maps == null;
											num2 = 0;
											controllerType2 = (ControllerType)(int)(&controllerIdentifier);
											mappingHelper = (ReInput.MappingHelper)(object)controller2;
											if (flag23)
											{
												goto end_IL_1787;
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
												goto end_IL_1787;
											}
											_tempElementByRoleMapsEnabled.Clear();
											bool flag26 = controllerMap4 == null;
											num2 = 0;
											mappingHelper = (ReInput.MappingHelper)(object)_tempElementByRoleMapsEnabled;
											if (flag26)
											{
												goto end_IL_1787;
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
															goto IL_1614;
														}
													}
													num = num16;
													controllerType2 = (ControllerType)num18;
													controllerMap4 = controllerMap3;
													goto IL_1614;
													IL_1614:
													num16--;
													object obj14 = !flag30;
													obj11 = obj12;
													num17 = num;
													if (obj14 != null)
													{
														continue;
													}
													goto IL_0e0f;
												}
												goto end_IL_1787;
											}
											goto IL_0e0f;
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
										goto IL_1765;
									}
									bool flag36 = ((Dictionary<string, bool>)(object)typeof(NotImplementedException)).TryGetValue((string)typeFromHandle, out *(bool*)(int)controllerType2);
									NotImplementedException ex = new NotImplementedException();
									bool flag37 = ((Dictionary<string, bool>)0).TryGetValue(null, out *(bool*)(int)controllerType2);
									throw ex;
									IL_1765:
									if (obj10 != null)
									{
										Player.ControllerHelper controllers3 = player.controllers;
										if (player.controllers == null)
										{
											goto end_IL_1787;
										}
										bool flag38 = controllers3.maps == null;
										mappingHelper = (ReInput.MappingHelper)(object)controllers3.maps;
										if (flag38)
										{
											goto end_IL_1787;
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
									goto IL_1550;
									IL_1550:
									num11++;
									num4 = num4;
									continue;
									IL_0e0f:
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
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-78+10]");
																bool flag45 = role2 == (string)0;
																num13 = num20;
																controllerType2 = ControllerType.Keyboard;
																if (flag45)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-78+18]");
																	bool flag46 = (nint)0 == 0;
																	num13 = num20;
																	controllerType2 = ControllerType.Keyboard;
																	if (!flag46)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-78+18]");
																		object obj16 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2482 @ rax_v95+18]");
																		bool flag47 = (nint)0 == 0;
																		num13 = num20;
																		controllerType2 = ControllerType.Keyboard;
																		if (!flag47)
																		{
																			num13 = num20;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-78+10]");
																			typeFromHandle = (ElementAssignment)0;
																			controllerType2 = ControllerType.Keyboard;
																			dictionary3 = (Dictionary<object, bool>)(object)elementIdentifier2._role;
																			object obj17 = 0;
																			while (true)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-78+18]");
																				object obj18 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-78+18]");
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
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-78+10]");
																							obj21 = 0;
																							Dictionary<string, bool> tempElementByRoleMapsEnabled2 = _tempElementByRoleMapsEnabled;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-78+10]");
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
									goto IL_1765;
								}
								actionElementMap = (ActionElementMap)enumerator3;
								list = mapCategories;
							}
							num4++;
							continue;
							IL_025e:
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
							goto IL_026d;
							continue;
							end_IL_1787:
							break;
						}
					}
				}
			}
		}
		num13 = num;
		obj21 = num2;
		throw new NullReferenceException();
		IL_146c:
		return 0;
	}

	private unsafe ControllerMap LoadControllerMap(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		//IL_0175: Expected O, but got Ref
		//IL_00af: Expected O, but got I4
		//IL_011e: Expected O, but got Ref
		//IL_0134: Expected O, but got Ref
		ControllerMap controllerMap;
		if (player != null)
		{
			int geiFrJCKClSdmONIywDTURjYPJnTA = default(int);
			int layoutId2 = default(int);
			int ppKeyVersion = default(int);
			string text;
			while (true)
			{
				string controllerMapKey = GetControllerMapKey(player, (ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), categoryId, layoutId2, ppKeyVersion);
				IDataStore store = dataStore;
				bool flag = TryGetString(store, controllerMapKey, out var result);
				bool flag2 = (flag ? 1 : 0) < (false ? 1 : 0);
				if (flag)
				{
					bool flag3 = string.IsNullOrEmpty(result);
					flag2 = (flag3 ? 1 : 0) < (false ? 1 : 0);
					if (!flag3)
					{
						text = result;
						break;
					}
				}
				object obj = !flag2;
				geiFrJCKClSdmONIywDTURjYPJnTA = controllerIdentifier.geiFrJCKClSdmONIywDTURjYPJnTA;
				if (obj == null)
				{
					text = null;
					break;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				controllerMap = ControllerMap.CreateFromJson(controllerIdentifier.jWEHFBYpJqUErvsQFOkVsnBjEAQe, text);
				if (controllerMap != null)
				{
					List<int> controllerMapKnownActionIds = GetControllerMapKnownActionIds(player, (ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), categoryId, layoutId2);
					AddDefaultMappingsForNewActions((ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), controllerMap, controllerMapKnownActionIds);
					goto IL_0188;
				}
			}
		}
		controllerMap = null;
		goto IL_0188;
		IL_0188:
		return controllerMap;
	}

	private bool LoadControllerElementMapByRole(Player player, Controller controller, string role, int mapCategoryId, int layoutId, Dictionary<string, ControllerElementByRoleMap> elementByRoleMaps)
	{
		//IL_01d9: Expected I4, but got O
		//IL_0181: Expected I4, but got O
		if (!string.IsNullOrEmpty(role))
		{
			_sb.Length = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317230A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			StringBuilder stringBuilder = _sb.Append("playerId=");
			int id = player.id;
			StringBuilder stringBuilder2 = _sb.Append(id);
			int categoryId = default(int);
			int layoutId2 = default(int);
			int keyVersion = default(int);
			AppendControllerElementByRoleMapKey(_sb, role, categoryId, layoutId2, keyVersion);
			IDataStore store = dataStore;
			if (_sb != null)
			{
				string key = _sb.ToString();
				if (TryGetString(store, key, out var result))
				{
					if (!string.IsNullOrEmpty(result))
					{
						ControllerElementByRoleMap controllerElementByRoleMap = ControllerElementByRoleMap.FromJson(role, result);
						if (controllerElementByRoleMap != null)
						{
							Dictionary<object, object> dictionary = default(Dictionary<object, object>);
							dictionary.set_Item((object)role, (object)controllerElementByRoleMap);
							return true;
						}
						return (byte)(int)controllerElementByRoleMap != 0;
					}
					return false;
				}
				return false;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private int LoadInputBehaviors(int playerId)
	{
		//IL_0178: Expected I4, but got O
		//IL_003c: Expected I4, but got O
		//IL_0070: Expected O, but got I4
		//IL_0134: Expected O, but got I4
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
						if (num2 >= count)
						{
							break;
						}
						InputBehavior inputBehavior = inputBehaviors.get_Item(num3);
						int num5 = LoadInputBehaviorNow((Player)num, inputBehavior);
						num4 += num5;
						num3++;
						num2 = num3;
					}
					return num4;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int LoadInputBehaviorNow(int playerId, int behaviorId)
	{
		//IL_00ee: Expected I4, but got O
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			Player player = players.GetPlayer(playerId);
			if (player != null)
			{
				ReInput.MappingHelper mapping = ReInput.mapping;
				if (mapping == null)
				{
					goto IL_00e0;
				}
				InputBehavior inputBehavior = mapping.GetInputBehavior(playerId, behaviorId);
				if (inputBehavior != null)
				{
					return LoadInputBehaviorNow(player, inputBehavior);
				}
			}
			return 0;
		}
		goto IL_00e0;
		IL_00e0:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int LoadInputBehaviorNow(Player player, InputBehavior inputBehavior)
	{
		//IL_0081: Expected O, but got I
		//IL_0091: Expected O, but got I
		if (player != null && inputBehavior != null)
		{
			string inputBehaviorKey = GetInputBehaviorKey(player, inputBehavior._id);
			IDataStore store = dataStore;
			bool flag = TryGetString(store, inputBehaviorKey, out var result);
			if (result != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v8+B8]");
				object obj2 = 0;
				if (result != (string)obj2 && inputBehavior.ImportJsonString(result))
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
			if (_loadKeyboardAssignments || _loadMouseAssignments)
			{
				bool flag = LoadKeyboardAndMouseAssignmentsNow(controllerAssignmentSaveInfo);
			}
			if (_loadJoystickAssignments)
			{
				bool flag2 = LoadJoystickAssignmentsNow(controllerAssignmentSaveInfo);
			}
			return true;
		}
		return false;
	}

	private unsafe bool LoadKeyboardAndMouseAssignmentsNow(ControllerAssignmentSaveInfo data)
	{
		//IL_03c0: Expected I4, but got O
		//IL_00ac: Expected O, but got Ref
		//IL_017b: Expected I, but got O
		//IL_02a0: Expected I, but got O
		//IL_031b: Expected I, but got O
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
				object obj3 = default(object);
				while (enumerator != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					if (obj2 != null)
					{
						if (enumerator != null)
						{
							Player current = enumerator.Current;
							if (current != null)
							{
								int id = current.id;
								if (controllerAssignmentSaveInfo != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039F3A0");
									bool flag3 = obj3 == null;
									nint num = (nint)typeof(IEnumerator<Player>);
									if (flag3)
									{
										continue;
									}
									ControllerAssignmentSaveInfo.PlayerInfo[] players2 = controllerAssignmentSaveInfo.players;
									int id2 = current.id;
									int num2 = controllerAssignmentSaveInfo.IndexOfPlayer(id2);
									if (controllerAssignmentSaveInfo.players != null)
									{
										ControllerAssignmentSaveInfo.PlayerInfo playerInfo = players2[num2];
										if (_loadKeyboardAssignments)
										{
											if (players2[num2] == null)
											{
												throw new NullReferenceException();
											}
											controllerHelper = current.controllers;
											if (current.controllers == null)
											{
												throw new NullReferenceException();
											}
											current.controllers.hasKeyboard = playerInfo.hasKeyboard;
										}
										bool flag4 = !_loadMouseAssignments;
										num = (nint)typeof(IEnumerator<Player>);
										if (!flag4)
										{
											if (players2[num2] == null)
											{
												throw new NullReferenceException();
											}
											if (current.controllers == null)
											{
												throw new NullReferenceException();
											}
											current.controllers.hasMouse = playerInfo.hasMouse;
											num = (nint)typeof(IEnumerator<Player>);
										}
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
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
					}
					return true;
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
		//IL_0e8a: Expected I4, but got O
		//IL_00fd: Expected O, but got Ref
		//IL_027c: Expected O, but got Ref
		//IL_06e1: Expected O, but got I4
		//IL_06ea: Expected O, but got I4
		//IL_06fd: Expected I, but got O
		//IL_0c35: Expected O, but got Ref
		//IL_0423: Expected O, but got I4
		//IL_0480: Expected O, but got I4
		//IL_04d6: Expected O, but got I
		//IL_0f3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f41: Expected O, but got Unknown
		//IL_0510: Expected O, but got I
		//IL_08c9: Expected O, but got I
		//IL_0947: Expected O, but got I
		//IL_0fa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fae: Expected O, but got Unknown
		//IL_0bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c04: Expected O, but got Unknown
		//IL_0c09: Expected I, but got O
		//IL_0bdf: Expected I, but got O
		//IL_0a2f: Expected I, but got O
		//IL_0b11: Expected O, but got Ref
		//IL_0ab4: Expected I, but got O
		//IL_0ae2: Expected I, but got O
		ReInput.ControllerHelper controllers = ReInput.controllers;
		if (controllers != null)
		{
			if (controllers.joystickCount == 0)
			{
				goto IL_0c61;
			}
			bool flag = data != null;
			ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = data;
			ControllerAssignmentSaveInfo controllerAssignmentSaveInfo2 = data;
			if (!flag)
			{
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo3 = LoadControllerAssignmentData();
				if (controllerAssignmentSaveInfo3 == null)
				{
					goto IL_0c61;
				}
				controllerAssignmentSaveInfo = controllerAssignmentSaveInfo3;
				controllerAssignmentSaveInfo2 = controllerAssignmentSaveInfo3;
			}
			ReInput.PlayerHelper players = ReInput.players;
			IList<Player> allPlayers = players.AllPlayers;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			IEnumerator<Player> enumerator = default(IEnumerator<Player>);
			object obj = (object)(&enumerator);
			Player.ControllerHelper controllerHelper = null;
			object obj2 = default(object);
			while (true)
			{
				if (enumerator != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					if (obj2 != null)
					{
						bool flag2 = enumerator == null;
						controllerHelper = null;
						if (!flag2)
						{
							Player current = enumerator.Current;
							bool flag3 = current == null;
							controllerHelper = (Player.ControllerHelper)(object)enumerator;
							if (!flag3)
							{
								controllerHelper = current.controllers;
								if (current.controllers != null)
								{
									current.controllers.ClearControllersOfType(ControllerType.Joystick);
									continue;
								}
								throw new NullReferenceException();
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
			List<JoystickAssignmentHistoryInfo> list2;
			if (_loadJoystickAssignments)
			{
				List<JoystickAssignmentHistoryInfo> list = new List<JoystickAssignmentHistoryInfo>();
				list2 = list;
				List<JoystickAssignmentHistoryInfo> list3 = list;
			}
			else
			{
				list2 = null;
				List<JoystickAssignmentHistoryInfo> list3 = null;
			}
			ReInput.PlayerHelper players2 = ReInput.players;
			IList<Player> allPlayers2 = players2.AllPlayers;
			if (allPlayers2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				IEnumerator enumerator2 = default(IEnumerator);
				object obj3 = (object)(&enumerator2);
				List<JoystickAssignmentHistoryInfo> list4 = null;
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo4 = null;
				UserDataStore_KeyValue userDataStore_KeyValue = this;
				Player player = default(Player);
				object obj4 = default(object);
				object obj6 = default(object);
				Player player2 = default(Player);
				while (true)
				{
					bool flag4 = enumerator2 == null;
					controllerHelper = (Player.ControllerHelper)(object)controllerAssignmentSaveInfo4;
					if (!flag4)
					{
						if (enumerator2.MoveNext())
						{
							bool flag5 = enumerator2 == null;
							controllerHelper = (Player.ControllerHelper)(object)enumerator2;
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								bool flag6 = player == null;
								controllerHelper = null;
								if (!flag6)
								{
									int id = player.id;
									bool flag7 = controllerAssignmentSaveInfo2 == null;
									controllerHelper = (Player.ControllerHelper)(object)player;
									if (!flag7)
									{
										bool flag8 = controllerAssignmentSaveInfo2.ContainsPlayer(id);
										bool flag9 = !flag8;
										controllerAssignmentSaveInfo4 = controllerAssignmentSaveInfo2;
										if (!flag9)
										{
											ControllerAssignmentSaveInfo.PlayerInfo[] players3 = controllerAssignmentSaveInfo2.players;
											int id2 = player.id;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039F400");
											bool flag10 = controllerAssignmentSaveInfo2.players == null;
											controllerHelper = (Player.ControllerHelper)(object)controllerAssignmentSaveInfo2;
											if (flag10)
											{
												throw new NullReferenceException();
											}
											bool flag11 = (nint)obj4 >= players3.Length;
											controllerHelper = (Player.ControllerHelper)(object)controllerAssignmentSaveInfo2;
											if (flag11)
											{
												throw new IndexOutOfRangeException();
											}
											List<JoystickAssignmentHistoryInfo> list3 = (List<JoystickAssignmentHistoryInfo>)(object)players3[obj4];
											bool flag12 = players3[obj4] == null;
											object obj5 = 0;
											controllerHelper = (Player.ControllerHelper)(object)controllerAssignmentSaveInfo2;
											if (flag12)
											{
												throw new NullReferenceException();
											}
											while (true)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803A55A0");
												if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
												{
													break;
												}
												_003C_003Ec__DisplayClass79_0 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass79_0();
												controllerHelper = (Player.ControllerHelper)list3._size;
												if (list3._size != 0)
												{
													if ((nint)obj5 < (controllerHelper.VcUGEYhvFTiouzwebDcrlbWmJbnNA ? 1 : 0))
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1948 @ rcx_v37 (Rewired.Player+ControllerHelper)+20+v872 @ rsi_v58*8]");
														ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = (ControllerAssignmentSaveInfo.JoystickInfo)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1948 @ rcx_v37 (Rewired.Player+ControllerHelper)+20+v872 @ rsi_v58*8]");
														if ((nint)0 != 0)
														{
															UserDataStore_KeyValue userDataStore_KeyValue2 = userDataStore_KeyValue;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1948 @ rcx_v37 (Rewired.Player+ControllerHelper)+20+v872 @ rsi_v58*8]");
															Joystick joystick = userDataStore_KeyValue2.FindJoystickPrecise((ControllerAssignmentSaveInfo.JoystickInfo)0);
															bool flag13 = CS_0024_003C_003E8__locals18 == null;
															controllerHelper = (Player.ControllerHelper)(object)userDataStore_KeyValue;
															if (flag13)
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
																		NullReferenceException ex2 = new NullReferenceException();
																		return (byte)(int)ex2 != 0;
																	}
																	object obj14 = (object)x.joystick - (object)CS_0024_003C_003E8__locals18.joystick;
																	return obj14 == null;
																};
																bool flag14 = list2 == null;
																controllerHelper = (Player.ControllerHelper)(object)predicate;
																if (flag14)
																{
																	throw new NullReferenceException();
																}
																JoystickAssignmentHistoryInfo joystickAssignmentHistoryInfo = list2.Find(predicate);
																if (joystickAssignmentHistoryInfo == null)
																{
																	JoystickAssignmentHistoryInfo item = new JoystickAssignmentHistoryInfo(CS_0024_003C_003E8__locals18.joystick, joystickInfo.id);
																	list2.Add(item);
																}
																controllerHelper = player.controllers;
																if (player.controllers == null)
																{
																	throw new NullReferenceException();
																}
																player.controllers.AddController(CS_0024_003C_003E8__locals18.joystick, removeFromOtherPlayers: false);
																userDataStore_KeyValue = this;
															}
														}
														obj5++;
														continue;
													}
													throw new IndexOutOfRangeException();
												}
												throw new NullReferenceException();
											}
											controllerAssignmentSaveInfo4 = (ControllerAssignmentSaveInfo)(object)list3;
											controllerAssignmentSaveInfo2 = controllerAssignmentSaveInfo;
										}
										player2 = player;
										list4 = null;
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						if (obj3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						}
						break;
					}
					throw new NullReferenceException();
				}
				if (userDataStore_KeyValue._allowImpreciseJoystickAssignmentMatching)
				{
					ReInput.PlayerHelper players4 = ReInput.players;
					IList<Player> allPlayers3 = players4.AllPlayers;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					List<object>.Enumerator enumerator3 = (List<object>.Enumerator)0;
					List<object>.Enumerator enumerator4 = (List<object>.Enumerator)0;
					List<Joystick> matches = null;
					nint num = (nint)typeof(IEnumerator);
					ReInput.PlayerHelper playerHelper = null;
					object obj7 = default(object);
					Player player3 = default(Player);
					object obj8 = default(object);
					object obj9 = default(object);
					object obj10 = default(object);
					Joystick joystick4 = default(Joystick);
					List<object>.Enumerator enumerator5 = default(List<object>.Enumerator);
					while (true)
					{
						if (enumerator != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							if (obj7 == null)
							{
								break;
							}
							bool flag15 = enumerator == null;
							playerHelper = null;
							if (!flag15)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								bool flag16 = player3 == null;
								playerHelper = null;
								if (!flag16)
								{
									int id3 = player3.id;
									if (controllerAssignmentSaveInfo2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039F3A0");
										if (obj8 == null)
										{
											continue;
										}
										ControllerAssignmentSaveInfo.PlayerInfo[] players5 = controllerAssignmentSaveInfo2.players;
										int id4 = player3.id;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039F400");
										if (controllerAssignmentSaveInfo2.players != null)
										{
											if ((nint)obj9 < players5.Length)
											{
												bool flag17 = players5[obj9] == null;
												List<JoystickAssignmentHistoryInfo> list5 = list4;
												Player player4 = player3;
												ReInput.PlayerHelper playerHelper2 = (ReInput.PlayerHelper)(object)players5[obj9];
												if (!flag17)
												{
													while (true)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803A55A0");
														if (System.Runtime.CompilerServices.Unsafe.As<List<JoystickAssignmentHistoryInfo>, UIntPtr>(ref list5) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
														{
															break;
														}
														_003C_003Ec__DisplayClass79_1 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass79_1();
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3318 @ rbx_v49 (Rewired.ReInput+PlayerHelper)+18]");
														object obj11 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3318 @ rbx_v49 (Rewired.ReInput+PlayerHelper)+18]");
														Joystick joystick2;
														List<JoystickAssignmentHistoryInfo> list7;
														if ((nint)0 != 0)
														{
															List<JoystickAssignmentHistoryInfo> list6 = list5;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2238 @ rdx_v75+18]");
															if ((nint)list6 < 0)
															{
																if (CS_0024_003C_003E8__locals20 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2238 @ rdx_v75+20+v2216 @ r12_v46 (System.Collections.Generic.List`1<Rewired.Data.UserDataStore_KeyValue+JoystickAssignmentHistoryInfo>)*8]");
																	CS_0024_003C_003E8__locals20.joystickInfo = (ControllerAssignmentSaveInfo.JoystickInfo)0;
																	if (CS_0024_003C_003E8__locals20.joystickInfo == null)
																	{
																		goto IL_0fa0;
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
																				object obj14 = x.oldJoystickId - joystickInfo3.id;
																				return obj14 == null;
																			}
																		}
																		NullReferenceException ex2 = new NullReferenceException();
																		return (byte)(int)ex2 != 0;
																	};
																	if (list2 != null)
																	{
																		int num2 = list2.FindIndex(match);
																		Joystick joystick3;
																		if (num2 < 0)
																		{
																			if (!userDataStore_KeyValue.TryFindJoysticksImprecise(CS_0024_003C_003E8__locals20.joystickInfo, out matches))
																			{
																				list5 = (List<JoystickAssignmentHistoryInfo>)(list5 + 1);
																				num = unchecked((nint)null);
																				playerHelper2 = (ReInput.PlayerHelper)(object)players5[obj9];
																				continue;
																			}
																			if (matches == null)
																			{
																				throw new NullReferenceException();
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
																			num = unchecked((nint)null);
																			while (true)
																			{
																				bool flag18 = enumerator3.MoveNext();
																				bool flag19 = !flag18;
																				joystick2 = (Joystick)(object)list4;
																				joystick3 = (Joystick)(object)list4;
																				if (flag19)
																				{
																					break;
																				}
																				_003C_003Ec__DisplayClass79_2 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass79_2();
																				if (CS_0024_003C_003E8__locals21 != null)
																				{
																					CS_0024_003C_003E8__locals21.match = joystick4;
																					Predicate<JoystickAssignmentHistoryInfo> match2 = (Predicate<object>)delegate(JoystickAssignmentHistoryInfo x)
																					{
																						//IL_0053: Expected I4, but got O
																						if (x == null)
																						{
																							NullReferenceException ex2 = new NullReferenceException();
																							return (byte)(int)ex2 != 0;
																						}
																						object obj14 = (object)x.joystick - (object)CS_0024_003C_003E8__locals21.match;
																						return obj14 == null;
																					};
																					JoystickAssignmentHistoryInfo joystickAssignmentHistoryInfo2 = list2.Find(match2);
																					bool flag20 = joystickAssignmentHistoryInfo2 != null;
																					num = unchecked((nint)null);
																					if (!flag20)
																					{
																						joystick3 = CS_0024_003C_003E8__locals21.match;
																						joystick2 = CS_0024_003C_003E8__locals21.match;
																						num = unchecked((nint)null);
																						break;
																					}
																					continue;
																				}
																				throw new NullReferenceException();
																			}
																			((List<Joystick>.Enumerator*)(&enumerator3))->Dispose();
																			bool flag21 = joystick3 == null;
																			Joystick joystick5 = joystick4;
																			enumerator3 = enumerator5;
																			enumerator4 = enumerator5;
																			list7 = null;
																			player4 = player3;
																			playerHelper2 = (ReInput.PlayerHelper)(object)players5[obj9];
																			if (flag21)
																			{
																				goto IL_1089;
																			}
																			ControllerAssignmentSaveInfo.JoystickInfo joystickInfo2 = CS_0024_003C_003E8__locals20.joystickInfo;
																			bool flag22 = CS_0024_003C_003E8__locals20.joystickInfo == null;
																			_003C_003Ec__DisplayClass79_2 obj12 = (_003C_003Ec__DisplayClass79_2)(&enumerator3);
																			if (flag22)
																			{
																				throw new NullReferenceException();
																			}
																			JoystickAssignmentHistoryInfo item2 = new JoystickAssignmentHistoryInfo(joystick3, joystickInfo2.id);
																			list2.Add(item2);
																			joystick5 = joystick4;
																			enumerator3 = enumerator5;
																			enumerator4 = enumerator5;
																			list4 = null;
																			player4 = player3;
																		}
																		else
																		{
																			JoystickAssignmentHistoryInfo joystickAssignmentHistoryInfo3 = list2.get_Item(num2);
																			if (joystickAssignmentHistoryInfo3 == null)
																			{
																				throw new NullReferenceException();
																			}
																			joystick3 = joystickAssignmentHistoryInfo3.joystick;
																			joystick2 = (Joystick)(object)player2;
																		}
																		if (player4.controllers != null)
																		{
																			player4.controllers.AddController(joystick3, removeFromOtherPlayers: false);
																			list7 = list4;
																			num = unchecked((nint)null);
																			playerHelper2 = (ReInput.PlayerHelper)(object)players5[obj9];
																			goto IL_1089;
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
														IL_1089:
														player2 = (Player)(object)joystick2;
														list4 = list7;
														userDataStore_KeyValue = this;
														goto IL_0fa0;
														IL_0fa0:
														list5 = (List<JoystickAssignmentHistoryInfo>)(list5 + 1);
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
					object obj13 = (object)(&enumerator);
					if (obj13 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
					}
				}
				ReInput.ConfigHelper configuration = ReInput.configuration;
				bool flag23 = configuration == null;
				controllerHelper = null;
				if (!flag23)
				{
					if (configuration.autoAssignJoysticks)
					{
						ReInput.ControllerHelper controllers2 = ReInput.controllers;
						bool flag24 = controllers2 == null;
						controllerHelper = null;
						if (flag24)
						{
							goto IL_0d11;
						}
						controllers2.AutoAssignJoysticks();
					}
					return true;
				}
				goto IL_0d11;
			}
			throw new NullReferenceException();
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0d11:
		throw new NullReferenceException();
		IL_0c61:
		return false;
	}

	private ControllerAssignmentSaveInfo LoadControllerAssignmentData()
	{
		IDataStore store = dataStore;
		if (TryGetString(store, "ControllerAssignments", out var result))
		{
			if (!string.IsNullOrEmpty(result))
			{
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = JsonParser.FromJson<ControllerAssignmentSaveInfo>(result);
				if (controllerAssignmentSaveInfo != null && controllerAssignmentSaveInfo.playerCount != 0)
				{
					return controllerAssignmentSaveInfo;
				}
				return null;
			}
			return null;
		}
		return null;
	}

	private IEnumerator LoadJoystickAssignmentsDeferred()
	{
		_003CLoadJoystickAssignmentsDeferred_003Ed__81 obj = new _003CLoadJoystickAssignmentsDeferred_003Ed__81(0);
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			return obj;
		}
		return (IEnumerator)new NullReferenceException();
	}

	private void SaveAll()
	{
		//IL_025b: Expected I, but got O
		//IL_004c: Expected O, but got I
		//IL_0055: Expected O, but got I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		ReInput.PlayerHelper players = ReInput.players;
		IList<Player> allPlayers = players.AllPlayers;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			nint num3 = (nint)allPlayers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r10_v3 (Il2CppClass<System.Collections.Generic.IList`1<Rewired.Player>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_008c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r10_v3 (Il2CppClass<System.Collections.Generic.IList`1<Rewired.Player>>)+B0]");
			object obj = 0;
			object obj2 = 0;
			while (true)
			{
				object obj3 = obj2 + obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ r8_v24+v216 @ rax_v58*8]");
				if (0 != (nint)typeof(ICollection<Player>))
				{
					obj2++;
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r10_v3 (Il2CppClass<System.Collections.Generic.IList`1<Rewired.Player>>)+12E]");
					if ((nint)obj4 < 0)
					{
						continue;
					}
					goto IL_008c;
				}
				break;
			}
			goto IL_009b;
			IL_008c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
			goto IL_009b;
			IL_009b:
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
		if (_loadKeyboardAssignments || _loadMouseAssignments || _loadJoystickAssignments)
		{
			bool flag = SaveControllerAssignments();
		}
		IDataStore dataStore = this.dataStore;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		int num4 = 0;
		int num5 = 0;
		while (true)
		{
			int count2 = allPlayers.Count;
			if (num4 < count2)
			{
				Player player2 = allPlayers.get_Item(num5);
				OnControllerMapsSaved(player2);
				num5++;
				num4 = num5;
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
		IDataStore dataStore = this.dataStore;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		OnControllerMapsSaved(player);
	}

	private unsafe void SavePlayerDataNow(Player player)
	{
		//IL_006f: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_010b: Expected O, but got Ref
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
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
				string inputBehaviorKey = GetInputBehaviorKey(player, inputBehavior._id);
				IDataStore dataStore = this.dataStore;
				string text = uKbXgORekfADCjZshCoaohGejMNib[obj].ToJsonString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
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
					string joystickCalibrationMapKey = GetJoystickCalibrationMapKey(joystick);
					IDataStore dataStore = this.dataStore;
					string text = ((CalibrationMapSaveData)calibrationMapSaveData).VqnmAbwSDTqMLcgCPcmAKZuKctiu.ToJsonString();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 59 Invalid \"Jump target not found in method: 0x18039C510\"");
		throw new NullReferenceException();
	}

	private void SaveJoystickCalibrationData(Joystick joystick)
	{
		if (joystick != null)
		{
			JoystickCalibrationMapSaveData calibrationMapSaveData = joystick.GetCalibrationMapSaveData();
			string joystickCalibrationMapKey = GetJoystickCalibrationMapKey(joystick);
			IDataStore dataStore = this.dataStore;
			string text = ((CalibrationMapSaveData)calibrationMapSaveData).VqnmAbwSDTqMLcgCPcmAKZuKctiu.ToJsonString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
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
			if (num < count)
			{
				Player player = allPlayers.get_Item(num2);
				if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
				{
					int id = player.id;
					SaveControllerMaps(id, ControllerType.Joystick, joystickId);
				}
				num2++;
				num = num2;
				continue;
			}
			break;
		}
		ReInput.ControllerHelper controllers = ReInput.controllers;
		Joystick joystick = controllers.GetJoystick(joystickId);
		SaveJoystickCalibrationData(joystick);
	}

	private void SaveControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
	{
		SaveControllerMaps(playerId, controllerType, controllerId);
		SaveControllerData(controllerType, controllerId);
	}

	private void SaveControllerDataNow(ControllerType controllerType, int controllerId)
	{
		if (controllerType == ControllerType.Joystick)
		{
			SaveJoystickCalibrationData(controllerId);
		}
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
		//IL_0051: Expected O, but got Ref
		//IL_00c6: Expected O, but got Ref
		Controller controller = controllerMap.controller;
		int categoryId = controllerMap.categoryId;
		int layoutId = controllerMap.layoutId;
		ControllerIdentifier controllerIdentifier = default(ControllerIdentifier);
		int layoutId2 = default(int);
		int ppKeyVersion = default(int);
		string controllerMapKey = GetControllerMapKey(player, (ControllerIdentifier)(&controllerIdentifier), categoryId, layoutId2, ppKeyVersion);
		IDataStore dataStore = this.dataStore;
		string text = controllerMap.ToJsonString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
		Controller controller2 = controllerMap.controller;
		int categoryId2 = controllerMap.categoryId;
		int layoutId3 = controllerMap.layoutId;
		string controllerMapKnownActionIdsKey = GetControllerMapKnownActionIdsKey(player, (ControllerIdentifier)(&controllerIdentifier), categoryId2, layoutId2, ppKeyVersion);
		IDataStore dataStore2 = this.dataStore;
		if (string.IsNullOrEmpty(__allActionIdsString))
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<int> list = allActionIds;
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v23 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)num3 >= (nint)0)
				{
					break;
				}
				int value;
				if (num > 0)
				{
					StringBuilder stringBuilder2 = stringBuilder.Append(",");
					value = list.get_Item(num);
				}
				else
				{
					value = list.get_Item(num);
				}
				StringBuilder stringBuilder3 = stringBuilder.Append(value);
				num++;
				num2 = num;
			}
			string _allActionIdsString = stringBuilder.ToString();
			__allActionIdsString = _allActionIdsString;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
	}

	private unsafe void SaveControllerMapByControllerElementRole(Player player, Controller controller, ControllerMap controllerMap)
	{
		//IL_002a: Expected I, but got O
		//IL_002f: Expected I, but got O
		//IL_00a9: Expected O, but got I4
		//IL_02c8: Expected I, but got O
		//IL_04e1: Expected O, but got I
		//IL_02e5: Expected I, but got O
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected O, but got Unknown
		//IL_0191: Expected O, but got I4
		//IL_0419: Expected O, but got I4
		if (controller == null)
		{
			return;
		}
		SaveControllerMapByController(player, controllerMap);
		IList<ActionElementMap> elementMaps = controllerMap.ElementMaps;
		nint num = unchecked((nint)null);
		nint num2 = unchecked((nint)null);
		Dictionary<string, ControllerElementByRoleMap> dictionary = null;
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
				controllerMap2 = null;
				while (true)
				{
					((Dictionary<string, ControllerElementByRoleMap>)null).Add((string)(object)typeof(ICollection<ActionElementMap>), (ControllerElementByRoleMap)elementMaps);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v57+1C]");
					Controller.Element elementById = controller.GetElementById(0);
					if (elementById != null)
					{
						ControllerElementIdentifier elementIdentifier2 = elementById.elementIdentifier;
						bool flag = elementIdentifier2._role != elementIdentifier._role;
						bool flag2 = !flag;
						if (!flag)
						{
							Controller controller2 = controllerMap.controller;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
							bool flag3 = AddControllerElementByRoleMapEntry(player, controller2, elementMap, ref *(Dictionary<string, ControllerElementByRoleMap>*)num3);
							bool flag4 = !flag2;
							controllerMap2 = (ControllerMap)flag4;
						}
					}
					obj++;
				}
				if (controllerMap2 == null)
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
		StringBuilder stringBuilder3 = default(StringBuilder);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				StringBuilder sb = _sb;
				if (_sb != null)
				{
					_sb.Length = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317230A]");
					bool flag6 = (nint)0 != 0;
					nint num4 = (nint)typeof(UserDataStore_KeyValue);
					if (!flag6)
					{
						_ = 1;
						num4 = unchecked((nint)"playerId=");
					}
					bool flag7 = _sb == null;
					sb = (StringBuilder)num4;
					if (!flag7)
					{
						StringBuilder stringBuilder = _sb.Append("playerId=");
						bool flag8 = player == null;
						sb = _sb;
						if (!flag8)
						{
							int id = player.id;
							StringBuilder stringBuilder2 = _sb.Append(id);
							bool flag9 = stringBuilder3 == null;
							sb = _sb;
							if (!flag9)
							{
								int categoryId = controllerMap.categoryId;
								int layoutId = controllerMap.layoutId;
								AppendControllerElementByRoleMapKey(_sb, (string)(object)stringBuilder3.m_ChunkChars, categoryId, layoutId, num3);
								IDataStore value = dataStore;
								sb = _sb;
								if (_sb == null)
								{
									break;
								}
								string text = _sb.ToString();
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039F9E0");
								((Dictionary<string, ControllerElementByRoleMap>)4).Add((string)(object)typeof(IDataStore), (ControllerElementByRoleMap)value);
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
			((Dictionary<string, ControllerElementByRoleMap>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private bool AddControllerElementByRoleMapEntry(Player player, Controller controller, ActionElementMap elementMap, ref Dictionary<string, ControllerElementByRoleMap> maps)
	{
		//IL_01c0: Expected I4, but got O
		ControllerElementByRoleMap controllerElementByRoleMap = default(ControllerElementByRoleMap);
		if (elementMap != null && controller != null)
		{
			ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(elementMap._elementIdentifierId);
			if (elementIdentifierById == null || string.IsNullOrEmpty(elementIdentifierById._role))
			{
				return false;
			}
			object obj = default(object);
			if (obj == null)
			{
				Dictionary<string, ControllerElementByRoleMap> dictionary = new Dictionary<string, ControllerElementByRoleMap>();
				obj = dictionary;
			}
			if (obj != null)
			{
				if (((Dictionary<object, object>)obj).TryGetValue((object)elementIdentifierById._role, out object _))
				{
					goto IL_016c;
				}
				controllerElementByRoleMap = new ControllerElementByRoleMap();
				if (controllerElementByRoleMap != null)
				{
					controllerElementByRoleMap.role = elementIdentifierById._role;
					if (obj != null)
					{
						((Dictionary<object, object>)obj).Add((object)elementIdentifierById._role, (object)controllerElementByRoleMap);
						goto IL_016c;
					}
				}
			}
		}
		goto IL_01b2;
		IL_01b2:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_016c:
		if (controllerElementByRoleMap != null)
		{
			controllerElementByRoleMap.Add(elementMap);
			return true;
		}
		goto IL_01b2;
	}

	private void SaveInputBehaviors(Player player, PlayerSaveData playerSaveData)
	{
		//IL_0038: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
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
				string inputBehaviorKey = GetInputBehaviorKey(player, inputBehavior._id);
				IDataStore dataStore = this.dataStore;
				string text = uKbXgORekfADCjZshCoaohGejMNib[obj2].ToJsonString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
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
				string inputBehaviorKey = GetInputBehaviorKey(player, inputBehavior._id);
				IDataStore dataStore = this.dataStore;
				string text = inputBehavior.ToJsonString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				IDataStore dataStore2 = this.dataStore;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			}
		}
	}

	private void SaveInputBehaviorNow(Player player, InputBehavior inputBehavior)
	{
		if (player != null && inputBehavior != null)
		{
			string inputBehaviorKey = GetInputBehaviorKey(player, inputBehavior._id);
			IDataStore dataStore = this.dataStore;
			string text = inputBehavior.ToJsonString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
		}
	}

	private bool SaveControllerAssignments()
	{
		//IL_0512: Expected I4, but got O
		//IL_0054: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_011e: Expected I, but got O
		//IL_012e: Expected O, but got I
		//IL_03f2: Expected O, but got I4
		//IL_023a: Expected O, but got I4
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		//IL_02ad: Expected I, but got O
		//IL_02bd: Expected O, but got I
		//IL_02e1: Expected O, but got I4
		//IL_031a: Expected I, but got O
		//IL_032a: Expected O, but got I
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			int allPlayerCount = players.allPlayerCount;
			ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = new ControllerAssignmentSaveInfo(allPlayerCount);
			object obj = 0;
			IList<Player> allPlayers;
			object obj3 = default(object);
			ControllerAssignmentSaveInfo.PlayerInfo playerInfo3 = default(ControllerAssignmentSaveInfo.PlayerInfo);
			Player player = default(Player);
			Controller controller = default(Controller);
			object obj5 = default(object);
			object obj7 = default(object);
			object obj6;
			IList<Player> list;
			while (true)
			{
				ReInput.PlayerHelper players2 = ReInput.players;
				int allPlayerCount2 = players2.allPlayerCount;
				if ((nint)obj < allPlayerCount2)
				{
					ReInput.PlayerHelper players3 = ReInput.players;
					allPlayers = players3.AllPlayers;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo = new ControllerAssignmentSaveInfo.PlayerInfo();
					ControllerAssignmentSaveInfo.PlayerInfo[] players4 = controllerAssignmentSaveInfo.players;
					bool flag = playerInfo == null;
					object obj2 = 0;
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo2 = playerInfo;
					if (!flag)
					{
						nint num = (nint)players4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ rdx_v55 (Il2CppClass<PlayerInfo[]>)+40]");
						obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
						bool flag2 = obj3 == null;
						playerInfo2 = playerInfo;
						if (flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
							obj2 = 0;
							playerInfo2 = playerInfo3;
							throw playerInfo3;
						}
					}
					if ((nint)obj >= players4.Length)
					{
						break;
					}
					players4[obj] = playerInfo;
					int id = player.id;
					playerInfo.id = id;
					bool hasKeyboard = player.controllers.hasKeyboard;
					playerInfo.hasKeyboard = hasKeyboard;
					bool hasMouse = player.controllers.hasMouse;
					playerInfo.hasMouse = hasMouse;
					int joystickCount = player.controllers.joystickCount;
					ControllerAssignmentSaveInfo.JoystickInfo[] array = (playerInfo.joysticks = new ControllerAssignmentSaveInfo.JoystickInfo[joystickCount]);
					object obj4 = 0;
					while (true)
					{
						int joystickCount2 = player.controllers.joystickCount;
						if ((nint)obj4 >= joystickCount2)
						{
							break;
						}
						IList<Joystick> joysticks = player.controllers.Joysticks;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
						ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = new ControllerAssignmentSaveInfo.JoystickInfo();
						nint num2 = (nint)controller;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1083 @ rax_v87 (Il2CppClass<Rewired.Controller>)+180]");
						list = (IList<Player>)0;
						joystickInfo.instanceGuid = (Guid)controller.deviceInstanceGuid._a;
						joystickInfo.id = controller.id;
						string hardwareIdentifier = controller.hardwareIdentifier;
						joystickInfo.hardwareIdentifier = hardwareIdentifier;
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1089 @ rdx_v52 (Il2CppClass<JoystickInfo[]>)+40]");
						obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
						bool flag3 = obj5 == null;
						obj6 = obj4;
						playerInfo2 = (ControllerAssignmentSaveInfo.PlayerInfo)(object)joystickInfo;
						if (!flag3)
						{
							array[obj4] = joystickInfo;
							obj4++;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						throw obj7;
					}
					obj++;
					continue;
				}
				IDataStore dataStore = this.dataStore;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1817B2820");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				IDataStore dataStore2 = this.dataStore;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				return true;
			}
			obj6 = obj;
			list = allPlayers;
			throw new IndexOutOfRangeException();
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static void AppendPlayerKey(StringBuilder sb, Player player)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317230A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		StringBuilder stringBuilder = sb.Append("playerId=");
		int id = player.id;
		StringBuilder stringBuilder2 = sb.Append(id);
	}

	private unsafe string GetControllerMapKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
		//IL_00f5: Expected O, but got Ref
		if (_sb != null)
		{
			_sb.Length = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317230A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (_sb != null)
			{
				StringBuilder stringBuilder = _sb.Append("playerId=");
				if (player != null)
				{
					int id = player.id;
					StringBuilder stringBuilder2 = _sb.Append(id);
					if (_sb != null)
					{
						StringBuilder stringBuilder3 = _sb.Append("|dataType=ControllerMap");
						object obj = default(object);
						int layoutId2 = default(int);
						int keyVersion = default(int);
						AppendControllerMapKeyCommonSuffix(_sb, player, (ControllerIdentifier)(&obj), categoryId, layoutId2, keyVersion);
						if (_sb != null)
						{
							return _sb.ToString();
						}
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private unsafe string GetControllerMapKnownActionIdsKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
		//IL_00f5: Expected O, but got Ref
		if (_sb != null)
		{
			_sb.Length = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317230A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (_sb != null)
			{
				StringBuilder stringBuilder = _sb.Append("playerId=");
				if (player != null)
				{
					int id = player.id;
					StringBuilder stringBuilder2 = _sb.Append(id);
					if (_sb != null)
					{
						StringBuilder stringBuilder3 = _sb.Append("|dataType=ControllerMap_KnownActionIds");
						object obj = default(object);
						int layoutId2 = default(int);
						int keyVersion = default(int);
						AppendControllerMapKeyCommonSuffix(_sb, player, (ControllerIdentifier)(&obj), categoryId, layoutId2, keyVersion);
						if (_sb != null)
						{
							return _sb.ToString();
						}
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private unsafe static void AppendControllerMapKeyCommonSuffix(StringBuilder sb, Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int keyVersion)
	{
		//IL_0195: Expected O, but got Ref
		StringBuilder stringBuilder = sb.Append("|kv=");
		int value = default(int);
		StringBuilder stringBuilder2 = sb.Append(value);
		StringBuilder stringBuilder3 = sb.Append("|controllerMapType=");
		StringBuilder stringBuilder4 = sb.Append((int)controllerIdentifier.jWEHFBYpJqUErvsQFOkVsnBjEAQe);
		StringBuilder stringBuilder5 = sb.Append("|categoryId=");
		StringBuilder stringBuilder6 = sb.Append(categoryId);
		StringBuilder stringBuilder7 = sb.Append("|");
		StringBuilder stringBuilder8 = sb.Append("layoutId=");
		int value2 = default(int);
		StringBuilder stringBuilder9 = sb.Append(value2);
		StringBuilder stringBuilder10 = sb.Append("|hardwareGuid=");
		object obj = default(object);
		object value3 = (Guid)obj;
		StringBuilder stringBuilder11 = sb.Append(value3);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
		object obj2 = default(object);
		if (obj2 != null)
		{
			StringBuilder stringBuilder12 = sb.Append("|hardwareIdentifier=");
			StringBuilder stringBuilder13 = sb.Append(controllerIdentifier.WqKxtyoOHIsKgjtDISLXKYcsazCQ);
		}
		if (controllerIdentifier.jWEHFBYpJqUErvsQFOkVsnBjEAQe == ControllerType.Joystick)
		{
			StringBuilder stringBuilder14 = sb.Append("|duplicate=");
			object obj3 = default(object);
			int duplicateIndex = GetDuplicateIndex(player, (ControllerIdentifier)(&obj3));
			int num = default(int);
			string value4 = num.ToString();
			StringBuilder stringBuilder15 = sb.Append(value4);
		}
	}

	private static void AppendControllerElementByRoleMapKey(StringBuilder sb, string elementRole, int categoryId, int layoutId, int keyVersion)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317230E]");
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

	private string GetJoystickCalibrationMapKey(Joystick joystick)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317230F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_sb != null)
		{
			_sb.Length = 0;
			if (_sb != null)
			{
				StringBuilder stringBuilder = _sb.Append("dataType=CalibrationMap");
				if (_sb != null)
				{
					StringBuilder stringBuilder2 = _sb.Append("|controllerType=");
					if (joystick != null)
					{
						ControllerType type = joystick.type;
						if (_sb != null)
						{
							StringBuilder stringBuilder3 = _sb.Append((int)type);
							if (_sb != null)
							{
								StringBuilder stringBuilder4 = _sb.Append("|hardwareIdentifier=");
								string hardwareIdentifier = joystick.hardwareIdentifier;
								if (_sb != null)
								{
									StringBuilder stringBuilder5 = _sb.Append(hardwareIdentifier);
									if (_sb != null)
									{
										StringBuilder stringBuilder6 = _sb.Append("|hardwareGuid=");
										Guid hardwareTypeGuid = joystick.hardwareTypeGuid;
										Guid guid = default(Guid);
										string value = guid.ToString();
										if (_sb != null)
										{
											StringBuilder stringBuilder7 = _sb.Append(value);
											if (_sb != null)
											{
												return _sb.ToString();
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
		return (string)(object)new NullReferenceException();
	}

	private string GetInputBehaviorKey(Player player, int inputBehaviorId)
	{
		if (_sb != null)
		{
			_sb.Length = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317230A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (_sb != null)
			{
				StringBuilder stringBuilder = _sb.Append("playerId=");
				if (player != null)
				{
					int id = player.id;
					StringBuilder stringBuilder2 = _sb.Append(id);
					if (_sb != null)
					{
						StringBuilder stringBuilder3 = _sb.Append("|dataType=InputBehavior");
						if (_sb != null)
						{
							StringBuilder stringBuilder4 = _sb.Append("|id=");
							if (_sb != null)
							{
								StringBuilder stringBuilder5 = _sb.Append(inputBehaviorId);
								if (_sb != null)
								{
									return _sb.ToString();
								}
							}
						}
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private unsafe string GetControllerMapJson(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		//IL_00d5: Expected O, but got Ref
		//IL_0083: Expected O, but got I4
		int geiFrJCKClSdmONIywDTURjYPJnTA = default(int);
		int layoutId2 = default(int);
		int ppKeyVersion = default(int);
		string result;
		while (true)
		{
			string controllerMapKey = GetControllerMapKey(player, (ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), categoryId, layoutId2, ppKeyVersion);
			IDataStore store = dataStore;
			bool flag = TryGetString(store, controllerMapKey, out result);
			bool flag2 = (flag ? 1 : 0) < (false ? 1 : 0);
			if (flag)
			{
				bool flag3 = string.IsNullOrEmpty(result);
				flag2 = (flag3 ? 1 : 0) < (false ? 1 : 0);
				if (!flag3)
				{
					break;
				}
			}
			object obj = !flag2;
			geiFrJCKClSdmONIywDTURjYPJnTA = controllerIdentifier.geiFrJCKClSdmONIywDTURjYPJnTA;
			if (obj == null)
			{
				return null;
			}
		}
		return result;
	}

	private unsafe List<int> GetControllerMapKnownActionIds(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		//IL_01a5: Expected O, but got Ref
		//IL_00a5: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		List<int> list = new List<int>();
		int geiFrJCKClSdmONIywDTURjYPJnTA = default(int);
		int layoutId2 = default(int);
		int ppKeyVersion = default(int);
		bool flag2;
		do
		{
			string controllerMapKnownActionIdsKey = GetControllerMapKnownActionIdsKey(player, (ControllerIdentifier)(&geiFrJCKClSdmONIywDTURjYPJnTA), categoryId, layoutId2, ppKeyVersion);
			IDataStore store = dataStore;
			bool flag = TryGetString(store, controllerMapKnownActionIdsKey, out var result);
			if (!flag)
			{
				flag2 = (flag ? 1 : 0) >= (false ? 1 : 0);
				geiFrJCKClSdmONIywDTURjYPJnTA = controllerIdentifier.geiFrJCKClSdmONIywDTURjYPJnTA;
				continue;
			}
			if (string.IsNullOrEmpty(result))
			{
				break;
			}
			string[] array = result.Split(',');
			int result2 = 0;
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
						if (int.TryParse(array[obj], out result2))
						{
							list.Add(result2);
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

	private string GetJoystickCalibrationMapJson(Joystick joystick)
	{
		string joystickCalibrationMapKey = GetJoystickCalibrationMapKey(joystick);
		IDataStore store = dataStore;
		bool flag = TryGetString(store, joystickCalibrationMapKey, out var result);
		return result;
	}

	private string GetInputBehaviorJson(Player player, int id)
	{
		string inputBehaviorKey = GetInputBehaviorKey(player, id);
		IDataStore store = dataStore;
		bool flag = TryGetString(store, inputBehaviorKey, out var result);
		return result;
	}

	private unsafe void AddDefaultMappingsForNewActions(ControllerIdentifier controllerIdentifier, ControllerMap controllerMap, List<int> knownActionIds)
	{
		//IL_008f: Expected O, but got Ref
		//IL_0185: Expected O, but got Ref
		//IL_0256: Expected I4, but got O
		//IL_0283: Expected I4, but got O
		//IL_030b: Expected O, but got Ref
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
		int num = default(int);
		ControllerMap controllerMapInstance = mapping.GetControllerMapInstance((ControllerIdentifier)(&num), categoryId, layoutId);
		if (controllerMapInstance == null)
		{
			return;
		}
		List<int> list = new List<int>();
		List<int> list2 = allActionIds;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
		List<int>.Enumerator enumerator = default(List<int>.Enumerator);
		int num2 = default(int);
		IEnumerator<ActionElementMap> enumerator2 = default(IEnumerator<ActionElementMap>);
		List<int>.Enumerator enumerator4 = default(List<int>.Enumerator);
		object obj2 = default(object);
		AxisRange axisRange = default(AxisRange);
		KeyCode keyCode2 = default(KeyCode);
		ModifierKeyFlags modifierKeyFlags2 = default(ModifierKeyFlags);
		int num5 = default(int);
		List<int>.Enumerator enumerator6 = default(List<int>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (!knownActionIds.Contains(num2))
				{
					if (list == null)
					{
						break;
					}
					list.Add(num2);
				}
				continue;
			}
			enumerator.Dispose();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)0 == 0)
			{
				return;
			}
			IList<ActionElementMap> allMaps = controllerMapInstance.AllMaps;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			object obj = (object)(&enumerator2);
			int num3 = layoutId;
			int num4 = num2;
			List<int>.Enumerator enumerator3 = enumerator4;
			IEnumerator<ActionElementMap> enumerator5 = null;
			ControllerMap controllerMap2 = controllerMap;
			while (true)
			{
				if (enumerator2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					if (obj2 != null)
					{
						bool flag = enumerator2 == null;
						enumerator5 = null;
						if (!flag)
						{
							ActionElementMap current = enumerator2.Current;
							if (current == null)
							{
								break;
							}
							bool flag2 = list.Contains(current._actionId);
							bool flag3 = !flag2;
							num3 = (int)typeof(IEnumerator<ActionElementMap>);
							if (!flag3)
							{
								bool flag4 = controllerMap2.DoesElementAssignmentConflict(current);
								num3 = (int)typeof(IEnumerator<ActionElementMap>);
								if (!flag4)
								{
									ControllerType controllerType = controllerMap2.controllerType;
									KeyCode keyCode = current.keyCode;
									ModifierKeyFlags modifierKeyFlags = current.modifierKeyFlags;
									ElementAssignment elementAssignment = new ElementAssignment(controllerType, current._elementType, current._elementIdentifierId, axisRange, keyCode2, modifierKeyFlags2, num5, (Pole)current._axisRange, (byte)keyCode != 0);
									bool flag5 = controllerMap.CreateElementMap((ElementAssignment)(&enumerator6));
									num3 = current._elementIdentifierId;
									num4 = 0;
									enumerator3 = (List<int>.Enumerator)elementAssignment;
									controllerMap2 = controllerMap;
								}
							}
							continue;
						}
						throw new NullReferenceException();
					}
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
					}
					return;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
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

	private unsafe static bool TryGetString(IDataStore store, string key, out string result)
	{
		object obj4 = default(object);
		ref string reference;
		if (store != null && !string.IsNullOrEmpty(key) && store.TryGetValue(key, out var result2))
		{
			if (result2 == null)
			{
				reference = ref *(string*)null;
			}
			else
			{
				object obj = result2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				bool flag = obj != null;
				object obj2 = null;
				if (!flag)
				{
					obj2 = result2;
				}
				reference = ref *(string*)obj2;
				object obj3 = result2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				if (obj3 == null)
				{
					goto IL_016b;
				}
			}
			bool flag2 = result2 == null;
			obj4 = null;
			if (!flag2)
			{
				object obj5 = result2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				bool flag3 = obj5 != null;
				obj4 = null;
				if (!flag3)
				{
					obj4 = result2;
				}
			}
			goto IL_016b;
		}
		reference = ref *(string*)null;
		return false;
		IL_016b:
		bool flag4 = obj4 == null;
		return !flag4;
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

	protected UserDataStore_KeyValue()
	{
		StringBuilder sb = new StringBuilder();
		_sb = sb;
		base._002Ector();
	}

	static UserDataStore_KeyValue()
	{
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(UserDataStore_KeyValue));
		string text = typeFromHandle.Name;
		thisScriptName = text;
	}
}
