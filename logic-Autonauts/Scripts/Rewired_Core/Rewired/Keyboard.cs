using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public sealed class Keyboard : ControllerWithMap
	{
		[CompilerGenerated]
		private sealed class _003CPollForAllKeysDown_003Ed__7 : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public Keyboard _003C_003E4__this;

			public int _003Ccount_003E5__8;

			public int _003Ci_003E5__9;

			public KeyCode _003CkeyCode_003E5__a;

			public bool _003Cvalue_003E5__b;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				_003CPollForAllKeysDown_003Ed__7 result;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					result = this;
				}
				else
				{
					while (true)
					{
						result = new _003CPollForAllKeysDown_003Ed__7(0)
						{
							_003C_003E4__this = _003C_003E4__this
						};
						int num = 2129228603;
						while (true)
						{
							switch (num ^ 0x7EE9733B)
							{
							case 2:
								num = 2129228602;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				return result;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				while (true)
				{
					int num2 = 1879361420;
					while (true)
					{
						switch (num2 ^ 0x7004C78D)
						{
						case 2:
							break;
						case 11:
							_003CkeyCode_003E5__a = (KeyCode)Consts.keyboardKeyValues[_003Ci_003E5__9];
							_003Cvalue_003E5__b = _003C_003E4__this.GetKeyDown(_003CkeyCode_003E5__a);
							num2 = 1879361422;
							continue;
						case 5:
							_003Ci_003E5__9++;
							num2 = 1879361421;
							continue;
						case 4:
							_003C_003E1__state = -1;
							if (ReInput._id != _003C_003E4__this.SsPwhbdijXONOlkRKHOkXryZrDq)
							{
								ReInput.CheckInitialized(_003C_003E4__this.SsPwhbdijXONOlkRKHOkXryZrDq);
								num2 = 1879361415;
								continue;
							}
							goto case 7;
						case 0:
						{
							int num3;
							if (_003Ci_003E5__9 >= _003Ccount_003E5__8)
							{
								num2 = 1879361415;
								num3 = num2;
							}
							else
							{
								num2 = 1879361414;
								num3 = num2;
							}
							continue;
						}
						case 9:
							return true;
						case 1:
							switch (num)
							{
							case 0:
								break;
							case 1:
								_003C_003E1__state = -1;
								num2 = 1879361416;
								continue;
							default:
								num2 = 1879361415;
								continue;
							}
							goto case 4;
						case 7:
							_003Ccount_003E5__8 = Consts.keyboardKeyValues.Count;
							_003Ci_003E5__9 = 0;
							num2 = 1879361419;
							continue;
						case 3:
							if (_003Cvalue_003E5__b)
							{
								_003C_003E2__current = new ControllerPollingInfo(true, -1, _003C_003E4__this.id, _003C_003E4__this._name, _003C_003E4__this._type, ControllerElementType.Button, _003Ci_003E5__9, Pole.Positive, GetKeyName(_003CkeyCode_003E5__a), _003C_003E4__this.kABaypBwJpdJPQfaNrcsDzJUopW.buttonElementIdentifierIds[_003Ci_003E5__9], _003CkeyCode_003E5__a);
								num2 = 1879361413;
								continue;
							}
							goto case 5;
						case 6:
							num2 = 1879361421;
							continue;
						case 8:
							_003C_003E1__state = 1;
							num2 = 1879361412;
							continue;
						default:
							return false;
						}
						break;
					}
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public _003CPollForAllKeysDown_003Ed__7(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private static Keyboard singleton;

		private readonly IUnifiedKeyboardSource _source;

		private ModifierKeyFlags currentModfierKeyFlags;

		private ModifierKeyFlags currentModfierKeyFlagsDouble;

		private Func<KeyboardKeyCode, int> _getKeyIndexDelegate;

		private readonly int[] keyCodeToKeyIndex;

		private static KeyboardKeyCode[] __keyIndexToKeyboardKeyCode;

		private readonly int maxKeyValue;

		private static Guid s_deviceInstanceGuid;

		private static KeyboardKeyCode[] keyIndexToKeyboardKeyCode
		{
			get
			{
				if (__keyIndexToKeyboardKeyCode == null)
				{
					int num3 = default(int);
					int[] keyboardKeyValues = default(int[]);
					int num2 = default(int);
					while (true)
					{
						int num = 492750810;
						while (true)
						{
							switch (num ^ 0x1D5EC7D9)
							{
							case 0:
								break;
							case 5:
								__keyIndexToKeyboardKeyCode[num3] = (KeyboardKeyCode)keyboardKeyValues[num3];
								num = 492750808;
								continue;
							case 1:
								num3++;
								num = 492750815;
								continue;
							case 3:
								keyboardKeyValues = Consts._keyboardKeyValues;
								num = 492750811;
								continue;
							case 2:
								num2 = keyboardKeyValues.Length;
								__keyIndexToKeyboardKeyCode = new KeyboardKeyCode[num2];
								num3 = 0;
								num = 492750815;
								continue;
							case 6:
								goto IL_0079;
							default:
								goto end_IL_000a;
							}
							break;
							IL_0079:
							int num4;
							if (num3 < num2)
							{
								num = 492750812;
								num4 = num;
							}
							else
							{
								num = 492750813;
								num4 = num;
							}
						}
						continue;
						end_IL_000a:
						break;
					}
				}
				return __keyIndexToKeyboardKeyCode;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Guid.Empty;
				}
				return s_deviceInstanceGuid;
			}
		}

		internal Keyboard(string name, IUnifiedKeyboardSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.hardwareMap, 132, new ControllerDataUpdater(source.inputSource, 0, 132, null))
		{
			s_deviceInstanceGuid = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int i = 0; i < num; i++)
			{
				if (keyboardKeyValues[i] > maxKeyValue)
				{
					maxKeyValue = keyboardKeyValues[i];
				}
			}
			keyCodeToKeyIndex = new int[maxKeyValue + 1];
			ArrayTools.Fill(keyCodeToKeyIndex, -1);
			for (int j = 0; j < num; j++)
			{
				keyCodeToKeyIndex[keyboardKeyValues[j]] = j;
			}
			_source = source;
			DRbMoDMaPuHTEfQNWMCHwDDCfEIB();
		}

		private Keyboard(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, HardwareControllerMap_Game hardwareMap, int buttonCount, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, buttonCount, null, hardwareMap, null, dataUpdater)
		{
			singleton = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = -576391451;
					while (true)
					{
						switch (num ^ -576391452)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = -576391452;
					}
				}
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				num = 542540936;
				goto IL_0012;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].JustDoublePressed(speed);
			IL_000d:
			num = 542540937;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2056848A)
				{
				case 0:
					break;
				case 3:
					goto IL_002f;
				case 1:
					return false;
				default:
					return false;
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				num = 542540939;
			}
			goto IL_000d;
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].valuePrev;
		}

		public float GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return 0f;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].timePressed;
		}

		public float GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return 0f;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			Button leftButton;
			Button rightButton = default(Button);
			if (!GetControlButtons(out leftButton, out rightButton, key))
			{
				return false;
			}
			int num;
			int num2;
			if (!leftButton.value)
			{
				num = -1592549374;
				num2 = num;
			}
			else
			{
				num = -1592549372;
				num2 = num;
			}
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1592549376)
				{
				case 0:
					break;
				case 2:
					if (rightButton.value)
					{
						num = -1592549372;
						continue;
					}
					return false;
				case 1:
					return false;
				case 3:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = -1592549375;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -1592549373;
			goto IL_0012;
		}

		public bool GetModifierKeyDown(ModifierKey key)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			Button leftButton;
			Button rightButton;
			if (!GetControlButtons(out leftButton, out rightButton, key))
			{
				return false;
			}
			if (!leftButton.value)
			{
				goto IL_0032;
			}
			goto IL_0065;
			IL_0065:
			int num;
			if (!leftButton.valuePrev)
			{
				if (rightButton.valuePrev)
				{
					num = -681714968;
					goto IL_0037;
				}
				return true;
			}
			goto IL_007c;
			IL_007c:
			return false;
			IL_0032:
			num = -681714965;
			goto IL_0037;
			IL_0037:
			while (true)
			{
				switch (num ^ -681714966)
				{
				case 3:
					break;
				case 1:
					goto IL_0054;
				case 0:
					return false;
				default:
					goto IL_007c;
				}
				break;
				IL_0054:
				if (!rightButton.value)
				{
					num = -681714966;
					continue;
				}
				goto IL_0065;
			}
			goto IL_0032;
		}

		public bool GetModifierKeyUp(ModifierKey key)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			Button leftButton;
			Button rightButton;
			if (!GetControlButtons(out leftButton, out rightButton, key))
			{
				return false;
			}
			int num;
			if (!leftButton.value)
			{
				if (rightButton.value)
				{
					goto IL_003a;
				}
				if (!leftButton.valuePrev && !rightButton.valuePrev)
				{
					num = -1822461147;
					goto IL_003f;
				}
				return true;
			}
			goto IL_0058;
			IL_003f:
			switch (num ^ -1822461148)
			{
			case 0:
				break;
			case 2:
				goto IL_0058;
			default:
				return false;
			}
			goto IL_003a;
			IL_0058:
			return false;
			IL_003a:
			num = -1822461146;
			goto IL_003f;
		}

		public bool GetModifierKeyPrev(ModifierKey key)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			Button leftButton;
			Button rightButton;
			if (!GetControlButtons(out leftButton, out rightButton, key))
			{
				goto IL_0028;
			}
			int num;
			int num2;
			if (leftButton.valuePrev)
			{
				num = -2052868891;
				num2 = num;
			}
			else
			{
				num = -2052868892;
				num2 = num;
			}
			goto IL_002d;
			IL_002d:
			while (true)
			{
				switch (num ^ -2052868891)
				{
				case 3:
					break;
				case 2:
					return false;
				case 1:
					if (rightButton.valuePrev)
					{
						goto IL_006d;
					}
					return false;
				default:
					return true;
				}
				break;
				IL_006d:
				num = -2052868891;
			}
			goto IL_0028;
			IL_0028:
			num = -2052868889;
			goto IL_002d;
		}

		public float GetModifierKeyTimePressed(ModifierKey key)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			Button leftButton;
			Button rightButton;
			if (!GetControlButtons(out leftButton, out rightButton, key))
			{
				return 0f;
			}
			return MathTools.Max(leftButton.timePressed, rightButton.timePressed);
		}

		public float GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			Button leftButton;
			Button rightButton;
			if (!GetControlButtons(out leftButton, out rightButton, key))
			{
				return 0f;
			}
			return MathTools.Min(leftButton.timeUnpressed, rightButton.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return KeyCode.None;
			}
			return KeyboardKeyCodeToKeyCode(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return -1;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return -1;
			}
			return keyCodeToKeyIndex[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return null;
			}
			return kABaypBwJpdJPQfaNrcsDzJUopW.buttonElementIdentifiers_cache[keyCodeToKeyIndex[(int)keyCode]];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
			}
			int count = Consts.keyboardKeyValues.Count;
			int num = 0;
			bool key = default(bool);
			KeyCode keyCode = default(KeyCode);
			while (true)
			{
				int num2 = -933762787;
				while (true)
				{
					switch (num2 ^ -933762786)
					{
					case 0:
						break;
					case 2:
						if (key)
						{
							return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, GetKeyName(keyCode), kABaypBwJpdJPQfaNrcsDzJUopW.buttonElementIdentifierIds[num], keyCode);
						}
						num++;
						num2 = -933762790;
						continue;
					case 1:
						keyCode = (KeyCode)Consts.keyboardKeyValues[num];
						num2 = -933762789;
						continue;
					case 3:
						num2 = -933762790;
						continue;
					case 5:
						key = GetKey(keyCode);
						num2 = -933762788;
						continue;
					default:
						if (num >= count)
						{
							return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			int i = default(int);
			int count = default(int);
			while (true)
			{
				int num = ((ReInput._id == SsPwhbdijXONOlkRKHOkXryZrDq) ? (-754215357) : (-754215360));
				while (true)
				{
					switch (num ^ -754215354)
					{
					case 4:
						num = -754215356;
						continue;
					default:
						yield break;
					case 0:
					{
						KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
						if (GetKey(keyCode))
						{
							yield return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), kABaypBwJpdJPQfaNrcsDzJUopW.buttonElementIdentifierIds[i], keyCode);
							num = -754215359;
							continue;
						}
						goto case 7;
					}
					case 1:
						num = ((i < count) ? (-754215354) : (-754215355));
						continue;
					case 5:
						count = Consts.keyboardKeyValues.Count;
						i = 0;
						num = -754215353;
						continue;
					case 2:
						break;
					case 6:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = -754215355;
						continue;
					case 7:
						i++;
						num = -754215353;
						continue;
					}
					break;
				}
			}
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			//yield-return decompiler failed: Unable to find new state assignment for yield return
			_003CPollForAllKeysDown_003Ed__7 _003CPollForAllKeysDown_003Ed__8 = new _003CPollForAllKeysDown_003Ed__7(-2);
			_003CPollForAllKeysDown_003Ed__8._003C_003E4__this = this;
			return _003CPollForAllKeysDown_003Ed__8;
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
			}
			int count = Consts.keyboardKeyValues.Count;
			int num = 0;
			KeyCode keyCode = default(KeyCode);
			while (true)
			{
				int num2 = 401155557;
				while (true)
				{
					switch (num2 ^ 0x17E925E6)
					{
					case 0:
						break;
					case 3:
						num2 = 401155554;
						continue;
					case 2:
						keyCode = (KeyCode)Consts.keyboardKeyValues[num];
						if (GetKeyDown(keyCode))
						{
							num2 = 401155559;
							continue;
						}
						num++;
						num2 = 401155554;
						continue;
					case 1:
						return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, GetKeyName(keyCode), kABaypBwJpdJPQfaNrcsDzJUopW.buttonElementIdentifierIds[num], keyCode);
					default:
						if (num >= count)
						{
							return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public override ControllerPollingInfo PollForFirstButton()
		{
			return PollForFirstKey();
		}

		public override ControllerPollingInfo PollForFirstButtonDown()
		{
			return PollForFirstKeyDown();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return PollForAllKeys();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return PollForAllKeysDown();
		}

		public static bool IsModifierKey(KeyCode key)
		{
			switch (key)
			{
			case KeyCode.None:
				return false;
			case KeyCode.RightShift:
			case KeyCode.LeftShift:
			case KeyCode.RightControl:
			case KeyCode.LeftControl:
			case KeyCode.RightAlt:
			case KeyCode.LeftAlt:
			case KeyCode.RightCommand:
			case KeyCode.LeftCommand:
				return true;
			default:
				return false;
			}
		}

		internal static bool IsModifierKey(KeyboardKeyCode key)
		{
			switch (key)
			{
			case KeyboardKeyCode.None:
				return false;
			case KeyboardKeyCode.RightShift:
			case KeyboardKeyCode.LeftShift:
			case KeyboardKeyCode.RightControl:
			case KeyboardKeyCode.LeftControl:
			case KeyboardKeyCode.RightAlt:
			case KeyboardKeyCode.LeftAlt:
			case KeyboardKeyCode.RightCommand:
			case KeyboardKeyCode.LeftCommand:
				return true;
			default:
				return false;
			}
		}

		public static ModifierKey KeyCodeToModifierKey(KeyCode key)
		{
			if (key != KeyCode.None)
			{
				while (true)
				{
					switch (-2048911414 ^ -2048911413)
					{
					case 2:
						continue;
					case 1:
						switch (key)
						{
						case KeyCode.RightControl:
						case KeyCode.LeftControl:
							return ModifierKey.Control;
						case KeyCode.RightAlt:
						case KeyCode.LeftAlt:
							return ModifierKey.Alt;
						case KeyCode.RightCommand:
						case KeyCode.LeftCommand:
							return ModifierKey.Command;
						case KeyCode.RightShift:
						case KeyCode.LeftShift:
							return ModifierKey.Shift;
						default:
							return ModifierKey.None;
						}
					}
					break;
				}
			}
			return ModifierKey.None;
		}

		public static ModifierKeyFlags KeyCodeToModifierKeyFlags(KeyCode key)
		{
			while (true)
			{
				switch (-1830666540 ^ -1830666538)
				{
				case 0:
					continue;
				case 2:
					switch (key)
					{
					case KeyCode.LeftControl:
						break;
					case KeyCode.RightControl:
						return ModifierKeyFlags.RightControl;
					case KeyCode.LeftAlt:
						return ModifierKeyFlags.LeftAlt;
					case KeyCode.RightAlt:
						return ModifierKeyFlags.RightAlt;
					case KeyCode.LeftShift:
						return ModifierKeyFlags.LeftShift;
					case KeyCode.RightShift:
						return ModifierKeyFlags.RightShift;
					case KeyCode.LeftCommand:
						return ModifierKeyFlags.LeftCommand;
					case KeyCode.RightCommand:
						return ModifierKeyFlags.RightCommand;
					default:
						return ModifierKeyFlags.None;
					}
					break;
				}
				break;
			}
			return ModifierKeyFlags.LeftControl;
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, ModifierKey key)
		{
			int num;
			switch (key)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
				{
					return true;
				}
				return false;
			case ModifierKey.Alt:
				if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
				{
					return true;
				}
				return false;
			case ModifierKey.Shift:
				if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
				{
					num = 1979511832;
					goto IL_0026;
				}
				if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
				{
					return true;
				}
				return false;
			case ModifierKey.Command:
				if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
				{
					num = 1979511833;
				}
				else
				{
					if ((flags & ModifierKeyFlags.RightCommand) != ModifierKeyFlags.RightCommand)
					{
						return false;
					}
					num = 1979511834;
				}
				goto IL_0026;
			default:
				{
					return false;
				}
				IL_0026:
				while (true)
				{
					switch (num ^ 0x75FCF419)
					{
					case 4:
						goto IL_0021;
					case 2:
						break;
					case 1:
						return true;
					case 0:
						return true;
					default:
						return true;
					}
					break;
					IL_0021:
					num = 1979511835;
				}
				goto case ModifierKey.None;
			}
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, KeyCode key)
		{
			if (key != KeyCode.None)
			{
				while (true)
				{
					int num = -309532122;
					while (true)
					{
						switch (num ^ -309532128)
						{
						case 5:
							break;
						case 3:
							return true;
						case 2:
							return true;
						case 0:
							goto end_IL_0006;
						case 6:
							goto IL_00b2;
						case 1:
							return true;
						default:
							return true;
						case 7:
							return false;
						}
						break;
						IL_00b2:
						switch (key)
						{
						case KeyCode.LeftCommand:
							if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
							{
								num = -309532126;
								break;
							}
							return false;
						case KeyCode.RightCommand:
							if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
							{
								num = -309532124;
								break;
							}
							return false;
						case KeyCode.LeftControl:
							if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
							{
								return true;
							}
							return false;
						case KeyCode.RightControl:
							if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
							{
								return true;
							}
							return false;
						case KeyCode.LeftAlt:
							if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
							{
								return true;
							}
							return false;
						case KeyCode.RightAlt:
							if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
							{
								return true;
							}
							return false;
						case KeyCode.LeftShift:
							if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
							{
								num = -309532127;
								break;
							}
							return false;
						default:
							num = -309532121;
							break;
						case KeyCode.RightShift:
							if ((flags & ModifierKeyFlags.RightShift) != ModifierKeyFlags.RightShift)
							{
								return false;
							}
							num = -309532125;
							break;
						}
					}
					continue;
					end_IL_0006:
					break;
				}
			}
			return false;
		}

		public static ModifierKey ModifierKeyFlagsToModifierKey(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				goto IL_0006;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return ModifierKey.Control;
			}
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return ModifierKey.Alt;
			}
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return ModifierKey.Alt;
			}
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return ModifierKey.Shift;
			}
			int num;
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				num = -1252675807;
			}
			else
			{
				if ((flags & ModifierKeyFlags.LeftCommand) != ModifierKeyFlags.LeftCommand)
				{
					if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
					{
						return ModifierKey.Command;
					}
					return ModifierKey.None;
				}
				num = -1252675805;
			}
			goto IL_000b;
			IL_0006:
			num = -1252675806;
			goto IL_000b;
			IL_000b:
			switch (num ^ -1252675805)
			{
			case 3:
				break;
			case 1:
				return ModifierKey.Control;
			case 2:
				return ModifierKey.Shift;
			default:
				return ModifierKey.Command;
			}
			goto IL_0006;
		}

		public static KeyCode ModifierKeyFlagsToKeyCode(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return KeyCode.LeftControl;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				goto IL_0012;
			}
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return KeyCode.LeftAlt;
			}
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return KeyCode.RightAlt;
			}
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return KeyCode.LeftShift;
			}
			int num;
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				num = -763319143;
			}
			else
			{
				if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
				{
					return KeyCode.LeftCommand;
				}
				if ((flags & ModifierKeyFlags.RightCommand) != ModifierKeyFlags.RightCommand)
				{
					return KeyCode.None;
				}
				num = -763319141;
			}
			goto IL_0017;
			IL_0017:
			switch (num ^ -763319143)
			{
			case 3:
				break;
			case 1:
				return KeyCode.RightControl;
			case 0:
				return KeyCode.RightShift;
			default:
				return KeyCode.RightCommand;
			}
			goto IL_0012;
			IL_0012:
			num = -763319144;
			goto IL_0017;
		}

		public static ModifierKeyFlags ModifierKeyToModifierKeyFlags(ModifierKey key)
		{
			switch (key)
			{
			case ModifierKey.None:
				return ModifierKeyFlags.None;
			case ModifierKey.Control:
				return ModifierKeyFlags.LeftControl | ModifierKeyFlags.RightControl;
			case ModifierKey.Alt:
				return ModifierKeyFlags.LeftAlt | ModifierKeyFlags.RightAlt;
			case ModifierKey.Shift:
				return ModifierKeyFlags.LeftShift | ModifierKeyFlags.RightShift;
			case ModifierKey.Command:
				return ModifierKeyFlags.LeftCommand | ModifierKeyFlags.RightCommand;
			default:
				return ModifierKeyFlags.None;
			}
		}

		public static string GetKeyName(KeyCode key)
		{
			if (singleton == null)
			{
				goto IL_0007;
			}
			int buttonIndex = singleton.GetButtonIndex(KeyCodeToKeyboardKeyCode(key));
			int num;
			if (buttonIndex < 0)
			{
				num = -1151810835;
				goto IL_000c;
			}
			return singleton.ButtonElementIdentifiers[buttonIndex].name;
			IL_0007:
			num = -1151810834;
			goto IL_000c;
			IL_000c:
			switch (num ^ -1151810836)
			{
			case 0:
				break;
			case 2:
				return string.Empty;
			default:
				return string.Empty;
			}
			goto IL_0007;
		}

		public static string GetKeyName(KeyCode key, ModifierKeyFlags flags)
		{
			string text = GetKeyName(key);
			while (true)
			{
				int num = 1959704793;
				while (true)
				{
					switch (num ^ 0x74CEB8D8)
					{
					case 0:
						break;
					case 1:
					{
						int num2;
						if (flags == ModifierKeyFlags.None)
						{
							num = 1959704794;
							num2 = num;
						}
						else
						{
							num = 1959704795;
							num2 = num;
						}
						continue;
					}
					case 3:
						text = text + " + " + ModifierKeyFlagsToString(flags);
						num = 1959704794;
						continue;
					default:
						return text;
					}
					break;
				}
			}
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags, bool abbreviate)
		{
			int num = 0;
			string text = string.Empty;
			if (!ModifierKeyFlagsContain(flags, ModifierKey.Control))
			{
				goto IL_00d5;
			}
			if (abbreviate)
			{
				goto IL_0075;
			}
			text += "Control";
			goto IL_0147;
			IL_00d5:
			int num2;
			if (ModifierKeyFlagsContain(flags, ModifierKey.Command))
			{
				int num3;
				if (num <= 0)
				{
					num2 = -382568334;
					num3 = num2;
				}
				else
				{
					num2 = -382568332;
					num3 = num2;
				}
				goto IL_002d;
			}
			goto IL_00f6;
			IL_00f6:
			int num4;
			if (!ModifierKeyFlagsContain(flags, ModifierKey.Alt))
			{
				num2 = -382568328;
				num4 = num2;
			}
			else
			{
				num2 = -382568325;
				num4 = num2;
			}
			goto IL_002d;
			IL_0147:
			num++;
			num2 = -382568330;
			goto IL_002d;
			IL_002d:
			while (true)
			{
				switch (num2 ^ -382568336)
				{
				case 9:
					num2 = -382568335;
					continue;
				case 1:
					break;
				case 5:
					text += "Cmd";
					num2 = -382568323;
					continue;
				case 13:
					num++;
					num2 = -382568329;
					continue;
				case 4:
					text += " + ";
					num2 = -382568334;
					continue;
				case 2:
					if (!abbreviate)
					{
						text += "Command";
						num2 = -382568323;
						continue;
					}
					goto case 5;
				case 6:
					goto IL_00d5;
				case 7:
					goto IL_00f6;
				case 0:
					goto IL_0113;
				case 11:
					if (num > 0)
					{
						text += " + ";
						num2 = -382568324;
						continue;
					}
					goto case 12;
				case 10:
					goto IL_0147;
				case 12:
					text += "Alt";
					num++;
					num2 = -382568328;
					continue;
				case 8:
					goto IL_016f;
				default:
					goto IL_0198;
				}
				break;
				IL_016f:
				if (num >= 3)
				{
					return text;
				}
				if (ModifierKeyFlagsContain(flags, ModifierKey.Shift))
				{
					if (num > 0)
					{
						text += " + ";
						num2 = -382568336;
						continue;
					}
					goto IL_0113;
				}
				goto IL_0198;
				IL_0198:
				return text;
				IL_0113:
				text += "Shift";
				num++;
				num2 = -382568333;
			}
			goto IL_0075;
			IL_0075:
			text += "Ctrl";
			num2 = -382568326;
			goto IL_002d;
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return ModifierKeyFlagsToString(flags, false);
		}

		internal static KeyboardKeyCode KeyCodeToKeyboardKeyCode(KeyCode keyCode)
		{
			return (KeyboardKeyCode)keyCode;
		}

		internal static KeyCode KeyboardKeyCodeToKeyCode(KeyboardKeyCode keyCode)
		{
			return (KeyCode)keyCode;
		}

		internal static ModifierKeyFlags ConvertModifierKeyFlagsSingleToDouble(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				goto IL_0006;
			}
			goto IL_0057;
			IL_0006:
			int num = 761301285;
			goto IL_000b;
			IL_000b:
			while (true)
			{
				switch (num ^ 0x2D60892C)
				{
				case 5:
					break;
				case 3:
					flags |= ModifierKeyFlags.LeftAlt;
					num = 761301284;
					continue;
				case 2:
					goto IL_0057;
				case 4:
					goto IL_0069;
				case 8:
					if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
					{
						flags |= ModifierKeyFlags.RightShift;
						num = 761301293;
						continue;
					}
					goto case 1;
				case 1:
					if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
					{
						flags |= ModifierKeyFlags.LeftShift;
						num = 761301287;
						continue;
					}
					goto default;
				case 9:
					flags |= ModifierKeyFlags.RightControl;
					num = 761301294;
					continue;
				case 7:
					goto IL_00c3;
				case 6:
					flags |= ModifierKeyFlags.RightAlt;
					num = 761301291;
					continue;
				case 10:
					goto IL_00ec;
				case 0:
					goto IL_010a;
				default:
					return flags;
				}
				break;
				IL_00c3:
				int num2;
				if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
				{
					num = 761301295;
					num2 = num;
				}
				else
				{
					num = 761301284;
					num2 = num;
				}
			}
			goto IL_0006;
			IL_0057:
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				flags |= ModifierKeyFlags.LeftControl;
				num = 761301288;
				goto IL_000b;
			}
			goto IL_0069;
			IL_00ec:
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				flags |= ModifierKeyFlags.LeftCommand;
				num = 761301292;
				goto IL_000b;
			}
			goto IL_010a;
			IL_010a:
			int num3;
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				num = 761301290;
				num3 = num;
			}
			else
			{
				num = 761301291;
				num3 = num;
			}
			goto IL_000b;
			IL_0069:
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				flags |= ModifierKeyFlags.RightCommand;
				num = 761301286;
				goto IL_000b;
			}
			goto IL_00ec;
		}

		internal static int GetDoubledModifierKeyCount(ModifierKeyFlags flags)
		{
			if (flags == ModifierKeyFlags.None)
			{
				return 0;
			}
			int num = 0;
			if ((flags & ModifierKeyFlags.LeftControl) != ModifierKeyFlags.LeftControl)
			{
				goto IL_0072;
			}
			num++;
			goto IL_00c8;
			IL_0072:
			int num2;
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				num++;
				num2 = 244624780;
				goto IL_001b;
			}
			goto IL_00c8;
			IL_001b:
			while (true)
			{
				switch (num2 ^ 0xE94AD86)
				{
				case 6:
					num2 = 244624775;
					continue;
				case 8:
					num2 = 244624769;
					continue;
				case 7:
					if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
					{
						num++;
						num2 = 244624772;
						continue;
					}
					goto case 3;
				case 1:
					break;
				case 2:
					if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
					{
						num++;
						num2 = 244624770;
						continue;
					}
					goto case 5;
				case 5:
					if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
					{
						num++;
						num2 = 244624770;
						continue;
					}
					goto default;
				case 0:
					if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
					{
						num++;
						num2 = 244624769;
						continue;
					}
					goto case 7;
				case 10:
					goto IL_00c8;
				case 9:
					num++;
					num2 = 244624782;
					continue;
				case 3:
					if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
					{
						num++;
						num2 = 244624772;
						continue;
					}
					goto case 2;
				default:
					return num;
				}
				break;
			}
			goto IL_0072;
			IL_00c8:
			int num3;
			if ((flags & ModifierKeyFlags.LeftCommand) != ModifierKeyFlags.LeftCommand)
			{
				num2 = 244624774;
				num3 = num2;
			}
			else
			{
				num2 = 244624783;
				num3 = num2;
			}
			goto IL_001b;
		}

		[CustomObfuscation(rename = false)]
		internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
		{
			if ((uint)buttonIndex > 132u)
			{
				return KeyboardKeyCode.None;
			}
			return keyIndexToKeyboardKeyCode[buttonIndex];
		}

		internal static int GetElementIdentifierIdByKeyCode(KeyboardKeyCode keyCode)
		{
			int buttonIndex = singleton.GetButtonIndex(keyCode);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return singleton.ButtonElementIdentifiers[buttonIndex].id;
		}

		internal static void FixKeyboardAssignments(ref int elementIdentifierId, ref KeyCode keyCode)
		{
			if (keyCode != KeyCode.None)
			{
				elementIdentifierId = GetElementIdentifierIdByKeyCode(KeyCodeToKeyboardKeyCode(keyCode));
			}
			else
			{
				keyCode = ReInput.TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Keyboard.GetKeyCodeById(elementIdentifierId);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			_source.UpdateInputData(ROoGdHjYclVKlAjCTYtzRRhBjqvj);
			base.UpdateData(updateLoop);
			UpdateCurrentModifierKeyFlags();
		}

		internal void UpdateData_AndroidKeyboardDisabled(UpdateLoopType updateLoop)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].zxLhCcrlwKIIJANOaByFjYpjSot(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, ROoGdHjYclVKlAjCTYtzRRhBjqvj);
			while (true)
			{
				int num = 1080723849;
				while (true)
				{
					switch (num ^ 0x406A898D)
					{
					case 2:
						break;
					default:
						return;
					case 4:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].zxLhCcrlwKIIJANOaByFjYpjSot(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, ROoGdHjYclVKlAjCTYtzRRhBjqvj);
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].zxLhCcrlwKIIJANOaByFjYpjSot(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, ROoGdHjYclVKlAjCTYtzRRhBjqvj);
						num = 1080723854;
						continue;
					case 3:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].zxLhCcrlwKIIJANOaByFjYpjSot(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, ROoGdHjYclVKlAjCTYtzRRhBjqvj);
						num = 1080723853;
						continue;
					case 0:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].zxLhCcrlwKIIJANOaByFjYpjSot(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, ROoGdHjYclVKlAjCTYtzRRhBjqvj);
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].zxLhCcrlwKIIJANOaByFjYpjSot(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, ROoGdHjYclVKlAjCTYtzRRhBjqvj);
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].zxLhCcrlwKIIJANOaByFjYpjSot(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, ROoGdHjYclVKlAjCTYtzRRhBjqvj);
						num = 1080723852;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		internal bool GetKey(KeyboardKeyCode keyCode)
		{
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].value;
		}

		internal bool GetKeyPrev(KeyboardKeyCode keyCode)
		{
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].valuePrev;
		}

		internal bool AllRequiredKeysPressed(KeyboardKeyCode keyCode, ModifierKeyFlags doubledFlags)
		{
			if (!GetKey(keyCode))
			{
				return false;
			}
			if (doubledFlags == ModifierKeyFlags.None)
			{
				goto IL_000e;
			}
			if ((doubledFlags & currentModfierKeyFlagsDouble) != doubledFlags)
			{
				return false;
			}
			float keyTimePressed = GetKeyTimePressed((KeyCode)keyCode);
			if ((doubledFlags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Control))
			{
				return false;
			}
			int num;
			if ((doubledFlags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Command))
			{
				num = 746960509;
			}
			else
			{
				if ((doubledFlags & ModifierKeyFlags.LeftAlt) != ModifierKeyFlags.LeftAlt || !(keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Alt)))
				{
					if ((doubledFlags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Shift))
					{
						return false;
					}
					return true;
				}
				num = 746960510;
			}
			goto IL_0013;
			IL_000e:
			num = 746960511;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x2C85B67E)
			{
			case 2:
				break;
			case 1:
				return true;
			case 3:
				return false;
			default:
				return false;
			}
			goto IL_000e;
		}

		internal bool IsAnyComponentKeyActive(KeyboardKeyCode keyCode, ModifierKeyFlags doubledFlags)
		{
			if (GetKey(keyCode))
			{
				return true;
			}
			if (GetModifierKey(ModifierKeyFlagsToModifierKey(doubledFlags)))
			{
				return true;
			}
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal int GetButtonIndex(KeyboardKeyCode keyCode)
		{
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return -1;
			}
			return keyCodeToKeyIndex[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal override void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap == null)
			{
				goto IL_0003;
			}
			goto IL_0055;
			IL_0003:
			int num = 1787351674;
			goto IL_0008;
			IL_0008:
			IList<ActionElementMap> buttonMaps_orig = default(IList<ActionElementMap>);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ 0x6A88D278)
				{
				case 5:
					break;
				case 2:
					return;
				case 0:
					BakeActionElementMap(controllerMap, buttonMaps_orig[num2]);
					num = 1787351675;
					continue;
				case 3:
					num2++;
					num = 1787351676;
					continue;
				case 1:
					goto IL_0055;
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0003;
			IL_0055:
			buttonMaps_orig = controllerMap.ButtonMaps_orig;
			count = buttonMaps_orig.Count;
			num2 = 0;
			num = 1787351676;
			goto IL_0008;
		}

		[CustomObfuscation(rename = false)]
		internal override void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			if (map != null)
			{
				map.rlmHPtRaQxhZqxiQpUHlvKLFmAK(controllerMap);
			}
		}

		internal override void Clear()
		{
			base.Clear();
			currentModfierKeyFlags = ModifierKeyFlags.None;
			currentModfierKeyFlagsDouble = ModifierKeyFlags.None;
		}

		private bool GetControlButtons(out Button leftButton, out Button rightButton, ModifierKey key)
		{
			leftButton = null;
			ModifierKey modifierKey = default(ModifierKey);
			while (true)
			{
				int num = -1612986235;
				while (true)
				{
					switch (num ^ -1612986240)
					{
					case 0:
						break;
					case 5:
						rightButton = null;
						modifierKey = key;
						num = -1612986234;
						continue;
					case 7:
						return false;
					case 2:
						return true;
					case 3:
						rightButton = buttons[keyCodeToKeyIndex[309]];
						return true;
					case 6:
						switch (modifierKey)
						{
						case ModifierKey.None:
							break;
						case ModifierKey.Control:
							leftButton = buttons[keyCodeToKeyIndex[306]];
							rightButton = buttons[keyCodeToKeyIndex[305]];
							num = -1612986238;
							continue;
						case ModifierKey.Alt:
							leftButton = buttons[keyCodeToKeyIndex[308]];
							rightButton = buttons[keyCodeToKeyIndex[307]];
							return true;
						case ModifierKey.Command:
							leftButton = buttons[keyCodeToKeyIndex[310]];
							num = -1612986237;
							continue;
						case ModifierKey.Shift:
							leftButton = buttons[keyCodeToKeyIndex[304]];
							num = -1612986236;
							continue;
						default:
							return false;
						}
						goto case 7;
					case 4:
						rightButton = buttons[keyCodeToKeyIndex[303]];
						num = -1612986239;
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}

		private void UpdateCurrentModifierKeyFlags()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[keyCodeToKeyIndex[306]].value)
			{
				goto IL_001f;
			}
			goto IL_01d3;
			IL_001f:
			int num = -1301423060;
			goto IL_0024;
			IL_0024:
			while (true)
			{
				switch (num ^ -1301423058)
				{
				case 12:
					break;
				case 6:
					if (buttons[keyCodeToKeyIndex[307]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.RightAlt;
						num = -1301423066;
						continue;
					}
					goto IL_00c3;
				case 1:
					goto IL_0095;
				case 8:
					goto IL_00c3;
				case 7:
					goto IL_00f1;
				case 0:
					goto IL_011f;
				case 3:
					modifierKeyFlags |= ModifierKeyFlags.RightControl;
					num = -1301423057;
					continue;
				case 14:
					modifierKeyFlags |= ModifierKeyFlags.RightShift;
					num = -1301423062;
					continue;
				case 9:
					modifierKeyFlags |= ModifierKeyFlags.LeftShift;
					num = -1301423063;
					continue;
				case 2:
					modifierKeyFlags |= ModifierKeyFlags.LeftControl;
					num = -1301423067;
					continue;
				case 5:
					modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
					num = -1301423064;
					continue;
				case 10:
					modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
					num = -1301423069;
					continue;
				case 13:
					if (buttons[keyCodeToKeyIndex[309]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.RightCommand;
						num = -1301423058;
						continue;
					}
					goto IL_011f;
				case 11:
					goto IL_01d3;
				default:
					currentModfierKeyFlags = modifierKeyFlags;
					currentModfierKeyFlagsDouble = ConvertModifierKeyFlagsSingleToDouble(modifierKeyFlags);
					return;
				}
				break;
				IL_011f:
				int num2;
				if (buttons[keyCodeToKeyIndex[308]].value)
				{
					num = -1301423061;
					num2 = num;
				}
				else
				{
					num = -1301423064;
					num2 = num;
				}
				continue;
				IL_0095:
				int num3;
				if (buttons[keyCodeToKeyIndex[310]].value)
				{
					num = -1301423068;
					num3 = num;
				}
				else
				{
					num = -1301423069;
					num3 = num;
				}
				continue;
				IL_00c3:
				int num4;
				if (!buttons[keyCodeToKeyIndex[304]].value)
				{
					num = -1301423063;
					num4 = num;
				}
				else
				{
					num = -1301423065;
					num4 = num;
				}
				continue;
				IL_00f1:
				int num5;
				if (buttons[keyCodeToKeyIndex[303]].value)
				{
					num = -1301423072;
					num5 = num;
				}
				else
				{
					num = -1301423062;
					num5 = num;
				}
			}
			goto IL_001f;
			IL_01d3:
			int num6;
			if (!buttons[keyCodeToKeyIndex[305]].value)
			{
				num = -1301423057;
				num6 = num;
			}
			else
			{
				num = -1301423059;
				num6 = num;
			}
			goto IL_0024;
		}
	}
}
