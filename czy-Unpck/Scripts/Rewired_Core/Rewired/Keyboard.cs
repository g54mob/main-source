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
		private sealed class _003CPollForAllKeys_003Ed__0 : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public Keyboard _003C_003E4__this;

			public int _003Ccount_003E5__1;

			public int _003Ci_003E5__2;

			public KeyCode _003CkeyCode_003E5__3;

			public bool _003Cvalue_003E5__4;

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
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId)
				{
					goto IL_0012;
				}
				goto IL_004e;
				IL_0012:
				int num = -1744539382;
				goto IL_0017;
				IL_0017:
				_003CPollForAllKeys_003Ed__0 result = default(_003CPollForAllKeys_003Ed__0);
				while (true)
				{
					switch (num ^ -1744539384)
					{
					case 0:
						break;
					case 2:
						if (_003C_003E1__state == -2)
						{
							_003C_003E1__state = 0;
							result = this;
							num = -1744539383;
							continue;
						}
						goto IL_004e;
					case 3:
						goto IL_004e;
					default:
						return result;
					}
					break;
				}
				goto IL_0012;
				IL_004e:
				result = new _003CPollForAllKeys_003Ed__0(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
				num = -1744539383;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					num = -2082923840;
					goto IL_001f;
				case 1:
					{
						_003C_003E1__state = -1;
						num = -2082923834;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -2082923838)
						{
						case 6:
							num = -2082923835;
							continue;
						case 5:
							ReInput.CheckInitialized(_003C_003E4__this.vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = -2082923829;
							continue;
						case 1:
							_003CkeyCode_003E5__3 = (KeyCode)Consts.keyboardKeyValues[_003Ci_003E5__2];
							_003Cvalue_003E5__4 = _003C_003E4__this.GetKey(_003CkeyCode_003E5__3);
							if (_003Cvalue_003E5__4)
							{
								_003C_003E2__current = new ControllerPollingInfo(success: true, -1, _003C_003E4__this.id, _003C_003E4__this._name, _003C_003E4__this._type, ControllerElementType.Button, _003Ci_003E5__2, Pole.Positive, GetKeyName(_003CkeyCode_003E5__3), _003C_003E4__this.REZiFujnwfIcWniRKvMxDxhPHlx.buttonElementIdentifierIds[_003Ci_003E5__2], _003CkeyCode_003E5__3);
								_003C_003E1__state = 1;
								num = -2082923838;
								continue;
							}
							goto case 4;
						case 8:
							break;
						case 7:
							goto end_IL_001f;
						case 4:
							_003Ci_003E5__2++;
							num = -2082923830;
							continue;
						case 2:
							goto IL_0161;
						case 0:
							return true;
						case 3:
							_003Ccount_003E5__1 = Consts.keyboardKeyValues.Count;
							_003Ci_003E5__2 = 0;
							num = -2082923830;
							continue;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (_003Ci_003E5__2 >= _003Ccount_003E5__1)
						{
							num = -2082923829;
							num2 = num;
						}
						else
						{
							num = -2082923837;
							num2 = num;
						}
						continue;
						IL_0161:
						int num3;
						if (ReInput._id != _003C_003E4__this.vuPDNwATQFuTZgAqTRoviXUGAgFM)
						{
							num = -2082923833;
							num3 = num;
						}
						else
						{
							num = -2082923839;
							num3 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					goto case 0;
					end_IL_0008:
					break;
				}
				return false;
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
			public _003CPollForAllKeys_003Ed__0(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

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
				_003CPollForAllKeysDown_003Ed__7 _003CPollForAllKeysDown_003Ed__8;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CPollForAllKeysDown_003Ed__8 = this;
				}
				else
				{
					while (true)
					{
						_003CPollForAllKeysDown_003Ed__8 = new _003CPollForAllKeysDown_003Ed__7(0);
						int num = 515382675;
						while (true)
						{
							switch (num ^ 0x1EB81D91)
							{
							case 0:
								num = 515382672;
								continue;
							case 1:
								break;
							case 2:
								_003CPollForAllKeysDown_003Ed__8._003C_003E4__this = _003C_003E4__this;
								num = 515382674;
								continue;
							default:
								goto end_IL_0049;
							}
							break;
						}
						continue;
						end_IL_0049:
						break;
					}
				}
				return _003CPollForAllKeysDown_003Ed__8;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (_003C_003E1__state)
				{
				default:
					num = -2027704674;
					goto IL_001a;
				case 1:
					_003C_003E1__state = -1;
					num = -2027704675;
					goto IL_001a;
				case 0:
					goto IL_014a;
					IL_001a:
					while (true)
					{
						switch (num ^ -2027704678)
						{
						case 0:
							break;
						case 4:
							num = -2027704688;
							continue;
						case 8:
							goto IL_005d;
						case 1:
							num = -2027704688;
							continue;
						case 2:
							num = -2027704679;
							continue;
						case 5:
							goto IL_0089;
						case 6:
							_003C_003E2__current = new ControllerPollingInfo(success: true, -1, _003C_003E4__this.id, _003C_003E4__this._name, _003C_003E4__this._type, ControllerElementType.Button, _003Ci_003E5__9, Pole.Positive, GetKeyName(_003CkeyCode_003E5__a), _003C_003E4__this.REZiFujnwfIcWniRKvMxDxhPHlx.buttonElementIdentifierIds[_003Ci_003E5__9], _003CkeyCode_003E5__a);
							_003C_003E1__state = 1;
							return true;
						case 9:
							goto IL_014a;
						case 7:
							_003Ci_003E5__9++;
							num = -2027704679;
							continue;
						case 3:
							goto IL_0199;
						default:
							return false;
						}
						break;
						IL_0199:
						int num2;
						if (_003Ci_003E5__9 < _003Ccount_003E5__8)
						{
							num = -2027704673;
							num2 = num;
						}
						else
						{
							num = -2027704688;
							num2 = num;
						}
						continue;
						IL_0089:
						_003CkeyCode_003E5__a = (KeyCode)Consts.keyboardKeyValues[_003Ci_003E5__9];
						_003Cvalue_003E5__b = _003C_003E4__this.GetKeyDown(_003CkeyCode_003E5__a);
						int num3;
						if (_003Cvalue_003E5__b)
						{
							num = -2027704676;
							num3 = num;
						}
						else
						{
							num = -2027704675;
							num3 = num;
						}
					}
					goto default;
					IL_014a:
					_003C_003E1__state = -1;
					if (ReInput._id != _003C_003E4__this.vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(_003C_003E4__this.vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = -2027704677;
						goto IL_001a;
					}
					goto IL_005d;
					IL_005d:
					_003Ccount_003E5__8 = Consts.keyboardKeyValues.Count;
					_003Ci_003E5__9 = 0;
					num = -2027704680;
					goto IL_001a;
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
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num3 = default(int);
					int num2 = default(int);
					while (true)
					{
						int num = 552937815;
						while (true)
						{
							switch (num ^ 0x20F52956)
							{
							case 3:
								break;
							case 1:
								num3 = keyboardKeyValues.Length;
								__keyIndexToKeyboardKeyCode = new KeyboardKeyCode[num3];
								num2 = 0;
								num = 552937812;
								continue;
							case 4:
								__keyIndexToKeyboardKeyCode[num2] = (KeyboardKeyCode)keyboardKeyValues[num2];
								num2++;
								num = 552937812;
								continue;
							case 2:
								goto IL_0060;
							default:
								goto end_IL_000d;
							}
							break;
							IL_0060:
							int num4;
							if (num2 >= num3)
							{
								num = 552937814;
								num4 = num;
							}
							else
							{
								num = 552937810;
								num4 = num;
							}
						}
						continue;
						end_IL_000d:
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Guid.Empty;
				}
				return s_deviceInstanceGuid;
			}
		}

		internal Keyboard(string name, IUnifiedKeyboardSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.hardwareMap, 132, source?.controllerExtension, new ControllerDataUpdater(source.inputSource, 0, 132, null))
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
			aNzXPWgGkyjIHrJsRxlIZSjJoXv();
		}

		private Keyboard(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, HardwareControllerMap_Game hardwareMap, int buttonCount, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
			singleton = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			int num2;
			if (num < 0)
			{
				num2 = 1039050358;
				goto IL_001e;
			}
			return buttons[num].value;
			IL_0019:
			num2 = 1039050359;
			goto IL_001e;
			IL_001e:
			switch (num2 ^ 0x3DEEA676)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0019;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			int num2 = -943762230;
			goto IL_0012;
			IL_000d:
			num2 = -943762231;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ -943762229)
				{
				case 0:
					break;
				case 2:
					goto IL_002f;
				case 3:
					return false;
				default:
					if (num < 0)
					{
						return false;
					}
					return buttons[num].DoublePressedAndHeld(speed);
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				num2 = -943762232;
			}
			goto IL_000d;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return 0.0;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return 0.0;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if (!GetControlButtons(out var leftButton, out var rightButton, key))
			{
				return false;
			}
			if (leftButton.value || rightButton.value)
			{
				return true;
			}
			return false;
		}

		public bool GetModifierKeyDown(ModifierKey key)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			Button rightButton = default(Button);
			if (!GetControlButtons(out var leftButton, out rightButton, key))
			{
				return false;
			}
			if (!leftButton.value && !rightButton.value)
			{
				return false;
			}
			int num;
			int num2;
			if (!leftButton.valuePrev)
			{
				num = 1819937852;
				num2 = num;
			}
			else
			{
				num = 1819937855;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 1819937854;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x6C7A0C3F)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				case 3:
					if (rightButton.valuePrev)
					{
						goto IL_007f;
					}
					return true;
				default:
					return false;
				}
				break;
				IL_007f:
				num = 1819937855;
			}
			goto IL_000d;
		}

		public bool GetModifierKeyUp(ModifierKey key)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			if (GetControlButtons(out var leftButton, out var rightButton, key))
			{
				if (leftButton.value)
				{
					goto IL_0033;
				}
				if (!rightButton.value)
				{
					if (leftButton.valuePrev || rightButton.valuePrev)
					{
						return true;
					}
					num = -84823978;
				}
				else
				{
					num = -84823977;
				}
			}
			else
			{
				num = -84823982;
			}
			goto IL_0012;
			IL_0012:
			switch (num ^ -84823978)
			{
			case 2:
				break;
			case 1:
				goto IL_0033;
			case 4:
				return false;
			case 3:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			default:
				return false;
			}
			goto IL_000d;
			IL_000d:
			num = -84823979;
			goto IL_0012;
			IL_0033:
			return false;
		}

		public bool GetModifierKeyPrev(ModifierKey key)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			if (!GetControlButtons(out var leftButton, out var rightButton, key))
			{
				return false;
			}
			int num;
			if (!leftButton.valuePrev)
			{
				if (rightButton.valuePrev)
				{
					num = 1762040538;
					goto IL_001e;
				}
				return false;
			}
			goto IL_005f;
			IL_001e:
			switch (num ^ 0x69069AD8)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				goto IL_005f;
			}
			goto IL_0019;
			IL_005f:
			return true;
			IL_0019:
			num = 1762040537;
			goto IL_001e;
		}

		public double GetModifierKeyTimePressed(ModifierKey key)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if (!GetControlButtons(out var leftButton, out var rightButton, key))
			{
				return 0.0;
			}
			return MathTools.Max(leftButton.timePressed, rightButton.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					int num = -1924915556;
					while (true)
					{
						switch (num ^ -1924915554)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return 0.0;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = -1924915553;
					}
				}
			}
			if (!GetControlButtons(out var leftButton, out var rightButton, key))
			{
				return 0.0;
			}
			return MathTools.Min(leftButton.timeUnpressed, rightButton.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return KeyCode.None;
			}
			return KeyboardKeyCodeToKeyCode(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				num = 788097675;
				goto IL_0012;
			}
			int num2 = keyCodeToKeyIndex[(int)keyCode];
			if (num2 < 0)
			{
				return null;
			}
			return REZiFujnwfIcWniRKvMxDxhPHlx.buttonElementIdentifiers_cache[num2];
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2EF96A88)
				{
				case 0:
					break;
				case 2:
					goto IL_002f;
				case 1:
					return null;
				default:
					return null;
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				num = 788097673;
			}
			goto IL_000d;
			IL_000d:
			num = 788097674;
			goto IL_0012;
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
			}
			int count = Consts.keyboardKeyValues.Count;
			int num = 0;
			KeyCode keyCode = default(KeyCode);
			while (true)
			{
				int num2 = -1906676750;
				while (true)
				{
					switch (num2 ^ -1906676746)
					{
					case 0:
						break;
					case 4:
						num2 = -1906676745;
						continue;
					case 2:
						keyCode = (KeyCode)Consts.keyboardKeyValues[num];
						num2 = -1906676747;
						continue;
					case 3:
						if (GetKey(keyCode))
						{
							return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, GetKeyName(keyCode), REZiFujnwfIcWniRKvMxDxhPHlx.buttonElementIdentifierIds[num], keyCode);
						}
						num++;
						num2 = -1906676745;
						continue;
					default:
						if (num >= count)
						{
							return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			//yield-return decompiler failed: Unable to find 'return true' for yield return
			_003CPollForAllKeys_003Ed__0 _003CPollForAllKeys_003Ed__1 = new _003CPollForAllKeys_003Ed__0(-2);
			_003CPollForAllKeys_003Ed__1._003C_003E4__this = this;
			return _003CPollForAllKeys_003Ed__1;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			_003CPollForAllKeysDown_003Ed__7 _003CPollForAllKeysDown_003Ed__8 = new _003CPollForAllKeysDown_003Ed__7(-2);
			while (true)
			{
				int num = -1705040904;
				while (true)
				{
					switch (num ^ -1705040903)
					{
					case 2:
						break;
					case 1:
						goto IL_0026;
					default:
						return _003CPollForAllKeysDown_003Ed__8;
					}
					break;
					IL_0026:
					_003CPollForAllKeysDown_003Ed__8._003C_003E4__this = this;
					num = -1705040903;
				}
			}
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
			}
			int count = Consts.keyboardKeyValues.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[num];
					if (GetKeyDown(keyCode))
					{
						return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, GetKeyName(keyCode), REZiFujnwfIcWniRKvMxDxhPHlx.buttonElementIdentifierIds[num], keyCode);
					}
					num++;
					int num2 = -519225677;
					while (true)
					{
						switch (num2 ^ -519225678)
						{
						case 0:
							num2 = -519225680;
							continue;
						case 2:
							break;
						default:
							goto end_IL_004c;
						}
						break;
					}
					continue;
					end_IL_004c:
					break;
				}
			}
			return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
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
			default:
				while (true)
				{
					switch (0x36F9C6CC ^ 0x36F9C6CE)
					{
					case 0:
						continue;
					case 2:
						return false;
					}
					break;
				}
				goto case KeyCode.None;
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
			switch (key)
			{
			default:
				while (true)
				{
					switch (-283321050 ^ -283321052)
					{
					case 0:
						continue;
					case 2:
						return ModifierKey.None;
					}
					break;
				}
				goto case KeyCode.None;
			case KeyCode.None:
				return ModifierKey.None;
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
			}
		}

		public static ModifierKeyFlags KeyCodeToModifierKeyFlags(KeyCode key)
		{
			switch (key)
			{
			default:
				while (true)
				{
					switch (-799100859 ^ -799100860)
					{
					case 0:
						continue;
					case 1:
						return ModifierKeyFlags.None;
					}
					break;
				}
				goto case KeyCode.LeftControl;
			case KeyCode.LeftControl:
				return ModifierKeyFlags.LeftControl;
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
			}
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, ModifierKey key)
		{
			int num;
			switch (key)
			{
			case ModifierKey.Shift:
				if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
				{
					num = -1923345844;
					goto IL_0026;
				}
				if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
				{
					return true;
				}
				return false;
			case ModifierKey.Alt:
				if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightAlt) != ModifierKeyFlags.RightAlt)
				{
					return false;
				}
				num = -1923345845;
				goto IL_0026;
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightControl) != ModifierKeyFlags.RightControl)
				{
					return false;
				}
				num = -1923345847;
				goto IL_0026;
			case ModifierKey.Command:
				if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
				{
					return true;
				}
				return false;
			default:
				{
					return false;
				}
				IL_0026:
				while (true)
				{
					switch (num ^ -1923345848)
					{
					case 0:
						goto IL_0021;
					case 3:
						return true;
					case 1:
						return true;
					case 2:
						break;
					default:
						return true;
					}
					break;
					IL_0021:
					num = -1923345846;
				}
				goto case ModifierKey.None;
			}
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, KeyCode key)
		{
			while (true)
			{
				int num = 930626286;
				while (true)
				{
					switch (num ^ 0x37783AEF)
					{
					case 2:
						break;
					case 1:
						switch (key)
						{
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
								num = 930626287;
								continue;
							}
							return false;
						case KeyCode.None:
							break;
						case KeyCode.LeftControl:
							if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
							{
								return true;
							}
							return false;
						case KeyCode.RightControl:
							if ((flags & ModifierKeyFlags.RightControl) != ModifierKeyFlags.RightControl)
							{
								return false;
							}
							num = 930626283;
							continue;
						case KeyCode.RightShift:
							if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
							{
								return true;
							}
							return false;
						case KeyCode.LeftCommand:
							if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
							{
								return true;
							}
							return false;
						case KeyCode.RightCommand:
							if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
							{
								return true;
							}
							return false;
						default:
							return false;
						}
						goto case 3;
					case 4:
						return true;
					case 3:
						return false;
					default:
						return true;
					}
					break;
				}
			}
		}

		public static ModifierKey ModifierKeyFlagsToModifierKey(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return ModifierKey.Control;
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
				goto IL_0028;
			}
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return ModifierKey.Shift;
			}
			int num;
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				num = 1053966963;
			}
			else
			{
				if ((flags & ModifierKeyFlags.RightCommand) != ModifierKeyFlags.RightCommand)
				{
					return ModifierKey.None;
				}
				num = 1053966962;
			}
			goto IL_002d;
			IL_0028:
			num = 1053966960;
			goto IL_002d;
			IL_002d:
			switch (num ^ 0x3ED24271)
			{
			case 0:
				break;
			case 1:
				return ModifierKey.Shift;
			case 2:
				return ModifierKey.Command;
			default:
				return ModifierKey.Command;
			}
			goto IL_0028;
		}

		public static KeyCode ModifierKeyFlagsToKeyCode(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return KeyCode.LeftControl;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return KeyCode.RightControl;
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
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return KeyCode.RightShift;
			}
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return KeyCode.LeftCommand;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return KeyCode.RightCommand;
			}
			return KeyCode.None;
		}

		public static ModifierKeyFlags ModifierKeyToModifierKeyFlags(ModifierKey key)
		{
			switch (key)
			{
			default:
				while (true)
				{
					switch (0x6005C846 ^ 0x6005C847)
					{
					case 0:
						continue;
					case 1:
						return ModifierKeyFlags.None;
					}
					break;
				}
				goto case ModifierKey.None;
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
			}
		}

		public static string GetKeyName(KeyCode key)
		{
			if (singleton == null)
			{
				return string.Empty;
			}
			int buttonIndex = singleton.GetButtonIndex(KeyCodeToKeyboardKeyCode(key));
			while (true)
			{
				int num = 243926941;
				while (true)
				{
					switch (num ^ 0xE8A079F)
					{
					case 0:
						break;
					case 2:
						if (buttonIndex < 0)
						{
							goto IL_0040;
						}
						return singleton.ButtonElementIdentifiers[buttonIndex].name;
					default:
						return string.Empty;
					}
					break;
					IL_0040:
					num = 243926942;
				}
			}
		}

		public static string GetKeyName(KeyCode key, ModifierKeyFlags flags)
		{
			string text = GetKeyName(key);
			if (flags != ModifierKeyFlags.None)
			{
				text = text + " + " + ModifierKeyFlagsToString(flags);
			}
			return text;
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags, bool abbreviate)
		{
			int num = 0;
			string text = default(string);
			while (true)
			{
				int num2 = 552691073;
				while (true)
				{
					switch (num2 ^ 0x20F16586)
					{
					case 13:
						break;
					case 12:
						text += "Shift";
						num++;
						num2 = 552691094;
						continue;
					case 15:
						text += "Command";
						num2 = 552691080;
						continue;
					case 5:
						text += "Cmd";
						num2 = 552691078;
						continue;
					case 2:
						if (ModifierKeyFlagsContain(flags, ModifierKey.Alt))
						{
							if (num > 0)
							{
								text += " + ";
								num2 = 552691086;
								continue;
							}
							goto case 8;
						}
						goto case 6;
					case 11:
						text += "Control";
						num2 = 552691079;
						continue;
					case 4:
						text += "Ctrl";
						num2 = 552691084;
						continue;
					case 8:
						text += "Alt";
						num++;
						num2 = 552691072;
						continue;
					case 14:
						num2 = 552691078;
						continue;
					case 9:
						if (!ModifierKeyFlagsContain(flags, ModifierKey.Command))
						{
							goto case 2;
						}
						if (num > 0)
						{
							text += " + ";
							num2 = 552691077;
							continue;
						}
						goto case 3;
					case 1:
						num2 = 552691084;
						continue;
					case 6:
						if (num >= 3)
						{
							return text;
						}
						if (ModifierKeyFlagsContain(flags, ModifierKey.Shift))
						{
							if (num > 0)
							{
								text += " + ";
								num2 = 552691082;
								continue;
							}
							goto case 12;
						}
						goto default;
					case 7:
						text = string.Empty;
						num2 = 552691095;
						continue;
					case 10:
						num++;
						num2 = 552691087;
						continue;
					case 3:
					{
						int num4;
						if (!abbreviate)
						{
							num2 = 552691081;
							num4 = num2;
						}
						else
						{
							num2 = 552691075;
							num4 = num2;
						}
						continue;
					}
					case 17:
						if (ModifierKeyFlagsContain(flags, ModifierKey.Control))
						{
							int num3;
							if (abbreviate)
							{
								num2 = 552691074;
								num3 = num2;
							}
							else
							{
								num2 = 552691085;
								num3 = num2;
							}
							continue;
						}
						goto case 9;
					case 0:
						num++;
						num2 = 552691076;
						continue;
					default:
						return text;
					}
					break;
				}
			}
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return ModifierKeyFlagsToString(flags, abbreviate: false);
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
				flags |= ModifierKeyFlags.RightControl;
				goto IL_000e;
			}
			goto IL_00d4;
			IL_0101:
			int num;
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				flags |= ModifierKeyFlags.RightCommand;
				num = -2111546313;
				goto IL_0013;
			}
			goto IL_00a6;
			IL_000e:
			num = -2111546318;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ -2111546317)
				{
				case 10:
					break;
				case 9:
					goto IL_004f;
				case 2:
					flags |= ModifierKeyFlags.RightAlt;
					num = -2111546314;
					continue;
				case 7:
					if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
					{
						flags |= ModifierKeyFlags.LeftShift;
						num = -2111546317;
						continue;
					}
					goto default;
				case 6:
					goto IL_008c;
				case 4:
					goto IL_00a6;
				case 8:
					flags |= ModifierKeyFlags.RightShift;
					num = -2111546316;
					continue;
				case 1:
					goto IL_00d4;
				case 5:
					if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
					{
						flags |= ModifierKeyFlags.LeftAlt;
						num = -2111546310;
						continue;
					}
					goto IL_004f;
				case 3:
					goto IL_0101;
				default:
					return flags;
				}
				break;
				IL_004f:
				int num2;
				if ((flags & ModifierKeyFlags.LeftShift) != ModifierKeyFlags.LeftShift)
				{
					num = -2111546316;
					num2 = num;
				}
				else
				{
					num = -2111546309;
					num2 = num;
				}
			}
			goto IL_000e;
			IL_00d4:
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				flags |= ModifierKeyFlags.LeftControl;
				num = -2111546320;
				goto IL_0013;
			}
			goto IL_0101;
			IL_00a6:
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				flags |= ModifierKeyFlags.LeftCommand;
				num = -2111546315;
				goto IL_0013;
			}
			goto IL_008c;
			IL_008c:
			int num3;
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				num = -2111546319;
				num3 = num;
			}
			else
			{
				num = -2111546314;
				num3 = num;
			}
			goto IL_0013;
		}

		internal static int GetDoubledModifierKeyCount(ModifierKeyFlags flags)
		{
			if (flags == ModifierKeyFlags.None)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1842529899;
				while (true)
				{
					switch (num2 ^ -1842529896)
					{
					case 11:
						break;
					case 9:
						if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
						{
							num++;
							num2 = -1842529902;
							continue;
						}
						goto case 1;
					case 0:
						if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
						{
							num++;
							num2 = -1842529903;
							continue;
						}
						goto case 9;
					case 10:
						num2 = -1842529891;
						continue;
					case 1:
						if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
						{
							num++;
							num2 = -1842529891;
							continue;
						}
						goto case 5;
					case 4:
						num++;
						num2 = -1842529893;
						continue;
					case 5:
						if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
						{
							num++;
							num2 = -1842529894;
							continue;
						}
						goto case 8;
					case 12:
						num++;
						num2 = -1842529903;
						continue;
					case 3:
					{
						int num5;
						if ((flags & ModifierKeyFlags.LeftCommand) != ModifierKeyFlags.LeftCommand)
						{
							num2 = -1842529896;
							num5 = num2;
						}
						else
						{
							num2 = -1842529900;
							num5 = num2;
						}
						continue;
					}
					case 8:
					{
						int num4;
						if ((flags & ModifierKeyFlags.RightShift) != ModifierKeyFlags.RightShift)
						{
							num2 = -1842529894;
							num4 = num2;
						}
						else
						{
							num2 = -1842529890;
							num4 = num2;
						}
						continue;
					}
					case 7:
					{
						int num3;
						if ((flags & ModifierKeyFlags.RightControl) != ModifierKeyFlags.RightControl)
						{
							num2 = -1842529893;
							num3 = num2;
						}
						else
						{
							num2 = -1842529892;
							num3 = num2;
						}
						continue;
					}
					case 6:
						num++;
						num2 = -1842529894;
						continue;
					case 13:
						if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
						{
							num++;
							num2 = -1842529893;
							continue;
						}
						goto case 7;
					default:
						return num;
					}
					break;
				}
			}
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
				goto IL_0004;
			}
			goto IL_003c;
			IL_0004:
			int num = 1776725874;
			goto IL_0009;
			IL_0009:
			switch (num ^ 0x69E6AF70)
			{
			case 3:
				break;
			default:
				return;
			case 2:
				elementIdentifierId = GetElementIdentifierIdByKeyCode(KeyCodeToKeyboardKeyCode(keyCode));
				return;
			case 1:
				goto IL_003c;
			case 0:
				return;
			}
			goto IL_0004;
			IL_003c:
			keyCode = ReInput.akUdmKMbrqFLXkjqdKLUZOPTArx.Keyboard.GetKeyCodeById(elementIdentifierId);
			num = 1776725872;
			goto IL_0009;
		}

		internal void UpdateData(UpdateLoopType updateLoop)
		{
			_source.UpdateInputData(cMcAtEwaThLpgGZfIIRmVCJQjDU);
			base.kckuoUXEwQcigNbCseRHnXueOkT(updateLoop);
			UpdateCurrentModifierKeyFlags();
		}

		internal void UpdateData_AndroidKeyboardDisabled(UpdateLoopType updateLoop)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].KyHpjvRkJIBKWzDbtHSSnZwunyW(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, cMcAtEwaThLpgGZfIIRmVCJQjDU);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].KyHpjvRkJIBKWzDbtHSSnZwunyW(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, cMcAtEwaThLpgGZfIIRmVCJQjDU);
			while (true)
			{
				int num = -1984434266;
				while (true)
				{
					switch (num ^ -1984434265)
					{
					case 0:
						break;
					case 1:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].KyHpjvRkJIBKWzDbtHSSnZwunyW(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, cMcAtEwaThLpgGZfIIRmVCJQjDU);
						num = -1984434268;
						continue;
					case 2:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].KyHpjvRkJIBKWzDbtHSSnZwunyW(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, cMcAtEwaThLpgGZfIIRmVCJQjDU);
						num = -1984434269;
						continue;
					case 3:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].KyHpjvRkJIBKWzDbtHSSnZwunyW(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, cMcAtEwaThLpgGZfIIRmVCJQjDU);
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].KyHpjvRkJIBKWzDbtHSSnZwunyW(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, cMcAtEwaThLpgGZfIIRmVCJQjDU);
						num = -1984434267;
						continue;
					default:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].KyHpjvRkJIBKWzDbtHSSnZwunyW(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, cMcAtEwaThLpgGZfIIRmVCJQjDU);
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
			int num = keyCodeToKeyIndex[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool GetKeyPrev(KeyboardKeyCode keyCode)
		{
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				goto IL_0009;
			}
			int num = keyCodeToKeyIndex[(int)keyCode];
			int num2;
			if (num < 0)
			{
				num2 = 1354096207;
				goto IL_000e;
			}
			return buttons[num].valuePrev;
			IL_0009:
			num2 = 1354096204;
			goto IL_000e;
			IL_000e:
			switch (num2 ^ 0x50B5DE4D)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0009;
		}

		internal bool AllRequiredKeysPressed(KeyboardKeyCode keyCode, ModifierKeyFlags doubledFlags)
		{
			if (!GetKey(keyCode))
			{
				goto IL_0009;
			}
			if (doubledFlags == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((doubledFlags & currentModfierKeyFlagsDouble) != doubledFlags)
			{
				return false;
			}
			double keyTimePressed = GetKeyTimePressed((KeyCode)keyCode);
			int num = 987839566;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x3AE13C4A)
				{
				case 0:
					break;
				case 2:
					return false;
				case 4:
					if ((doubledFlags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
					{
						num = 987839563;
						continue;
					}
					goto IL_0072;
				case 1:
					if (keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Control))
					{
						num = 987839561;
						continue;
					}
					goto IL_0072;
				default:
					{
						return false;
					}
					IL_0072:
					if ((doubledFlags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Command))
					{
						return false;
					}
					if ((doubledFlags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Alt))
					{
						return false;
					}
					if ((doubledFlags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Shift))
					{
						return false;
					}
					return true;
				}
				break;
			}
			goto IL_0009;
			IL_0009:
			num = 987839560;
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
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap == null)
			{
				return;
			}
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				IList<ActionElementMap> buttonMaps_orig = controllerMap.ButtonMaps_orig;
				int num = -222012929;
				while (true)
				{
					switch (num ^ -222012935)
					{
					case 5:
						num = -222012936;
						continue;
					default:
						return;
					case 2:
					{
						int num3;
						if (num2 >= count)
						{
							num = -222012934;
							num3 = num;
						}
						else
						{
							num = -222012935;
							num3 = num;
						}
						continue;
					}
					case 0:
						kHBFOpXfsCHmoMIFXGRFYWyjgTV(controllerMap, buttonMaps_orig[num2]);
						num2++;
						num = -222012933;
						continue;
					case 4:
						num2 = 0;
						num = -222012933;
						continue;
					case 6:
						count = buttonMaps_orig.Count;
						num = -222012931;
						continue;
					case 1:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.ENoWuIxoJpbiEHGViijOxvkWIbli(controllerMap);
		}

		internal void Clear()
		{
			base.tAgADqjTsMUxSqYXeDyJIdETYRAp();
			currentModfierKeyFlags = ModifierKeyFlags.None;
			currentModfierKeyFlagsDouble = ModifierKeyFlags.None;
		}

		private bool GetControlButtons(out Button leftButton, out Button rightButton, ModifierKey key)
		{
			leftButton = null;
			rightButton = null;
			while (true)
			{
				int num = -412512240;
				while (true)
				{
					switch (num ^ -412512235)
					{
					case 6:
						break;
					case 0:
						rightButton = buttons[keyCodeToKeyIndex[309]];
						num = -412512236;
						continue;
					case 2:
						return false;
					case 5:
						switch (key)
						{
						case ModifierKey.None:
							break;
						case ModifierKey.Control:
							leftButton = buttons[keyCodeToKeyIndex[306]];
							rightButton = buttons[keyCodeToKeyIndex[305]];
							num = -412512238;
							continue;
						default:
							num = -412512234;
							continue;
						case ModifierKey.Alt:
							leftButton = buttons[keyCodeToKeyIndex[308]];
							rightButton = buttons[keyCodeToKeyIndex[307]];
							num = -412512239;
							continue;
						case ModifierKey.Command:
							leftButton = buttons[keyCodeToKeyIndex[310]];
							num = -412512235;
							continue;
						case ModifierKey.Shift:
							leftButton = buttons[keyCodeToKeyIndex[304]];
							rightButton = buttons[keyCodeToKeyIndex[303]];
							return true;
						}
						goto case 2;
					case 7:
						return true;
					case 4:
						return true;
					default:
						return true;
					case 3:
						return false;
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
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
				goto IL_0023;
			}
			goto IL_00ce;
			IL_00ce:
			int num;
			int num2;
			if (!buttons[keyCodeToKeyIndex[305]].value)
			{
				num = 2144161966;
				num2 = num;
			}
			else
			{
				num = 2144161962;
				num2 = num;
			}
			goto IL_0028;
			IL_0023:
			num = 2144161955;
			goto IL_0028;
			IL_0028:
			while (true)
			{
				switch (num ^ 0x7FCD50AB)
				{
				case 11:
					break;
				case 0:
					goto IL_006c;
				case 2:
					if (buttons[keyCodeToKeyIndex[304]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.LeftShift;
						num = 2144161963;
						continue;
					}
					goto IL_006c;
				case 3:
					modifierKeyFlags |= ModifierKeyFlags.RightAlt;
					num = 2144161961;
					continue;
				case 8:
					goto IL_00ce;
				case 12:
					if (buttons[keyCodeToKeyIndex[309]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.RightCommand;
						num = 2144161967;
						continue;
					}
					goto case 4;
				case 6:
					modifierKeyFlags |= ModifierKeyFlags.RightShift;
					num = 2144161964;
					continue;
				case 7:
					currentModfierKeyFlags = modifierKeyFlags;
					num = 2144161953;
					continue;
				case 1:
					modifierKeyFlags |= ModifierKeyFlags.RightControl;
					num = 2144161966;
					continue;
				case 4:
					if (buttons[keyCodeToKeyIndex[308]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
						num = 2144161954;
						continue;
					}
					goto IL_01aa;
				case 5:
					if (buttons[keyCodeToKeyIndex[310]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
						num = 2144161959;
						continue;
					}
					goto case 12;
				case 9:
					goto IL_01aa;
				default:
					currentModfierKeyFlagsDouble = ConvertModifierKeyFlagsSingleToDouble(modifierKeyFlags);
					return;
				}
				break;
				IL_01aa:
				int num3;
				if (!buttons[keyCodeToKeyIndex[307]].value)
				{
					num = 2144161961;
					num3 = num;
				}
				else
				{
					num = 2144161960;
					num3 = num;
				}
				continue;
				IL_006c:
				int num4;
				if (buttons[keyCodeToKeyIndex[303]].value)
				{
					num = 2144161965;
					num4 = num;
				}
				else
				{
					num = 2144161964;
					num4 = num;
				}
			}
			goto IL_0023;
		}
	}
}
