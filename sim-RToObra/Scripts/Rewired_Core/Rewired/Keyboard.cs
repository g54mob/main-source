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
				goto IL_0057;
				IL_0012:
				int num = 1828958141;
				goto IL_0017;
				IL_0017:
				_003CPollForAllKeys_003Ed__0 _003CPollForAllKeys_003Ed__1 = default(_003CPollForAllKeys_003Ed__0);
				while (true)
				{
					switch (num ^ 0x6D03AFBC)
					{
					case 0:
						break;
					case 6:
						num = 1828958143;
						continue;
					case 5:
						_003C_003E1__state = 0;
						_003CPollForAllKeys_003Ed__1 = this;
						num = 1828958138;
						continue;
					case 4:
						goto IL_0057;
					case 2:
						_003CPollForAllKeys_003Ed__1._003C_003E4__this = _003C_003E4__this;
						num = 1828958143;
						continue;
					case 1:
						goto IL_0078;
					default:
						return _003CPollForAllKeys_003Ed__1;
					}
					break;
					IL_0078:
					int num2;
					if (_003C_003E1__state == -2)
					{
						num = 1828958137;
						num2 = num;
					}
					else
					{
						num = 1828958136;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_0057:
				_003CPollForAllKeys_003Ed__1 = new _003CPollForAllKeys_003Ed__0(0);
				num = 1828958142;
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
				{
					_003C_003E1__state = -1;
					int num2;
					if (ReInput._id == _003C_003E4__this.znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						num = -101520402;
						num2 = num;
					}
					else
					{
						num = -101520407;
						num2 = num;
					}
					goto IL_001f;
				}
				case 1:
					{
						_003C_003E1__state = -1;
						num = -101520406;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -101520401)
						{
						case 3:
							num = -101520409;
							continue;
						case 8:
							break;
						case 0:
							num = -101520411;
							continue;
						case 2:
							if (_003Cvalue_003E5__4)
							{
								_003C_003E2__current = new ControllerPollingInfo(true, -1, _003C_003E4__this.id, _003C_003E4__this._name, _003C_003E4__this._type, ControllerElementType.Button, _003Ci_003E5__2, Pole.Positive, GetKeyName(_003CkeyCode_003E5__3), _003C_003E4__this.RCNejcvnZtMAmgendVbiwgNYmdD.buttonElementIdentifierIds[_003Ci_003E5__2], _003CkeyCode_003E5__3);
								num = -101520410;
								continue;
							}
							goto case 5;
						case 9:
							_003C_003E1__state = 1;
							return true;
						case 1:
							_003Ccount_003E5__1 = Consts.keyboardKeyValues.Count;
							_003Ci_003E5__2 = 0;
							num = -101520408;
							continue;
						case 5:
							_003Ci_003E5__2++;
							num = -101520408;
							continue;
						case 7:
							goto IL_0152;
						case 4:
							_003CkeyCode_003E5__3 = (KeyCode)Consts.keyboardKeyValues[_003Ci_003E5__2];
							_003Cvalue_003E5__4 = _003C_003E4__this.GetKey(_003CkeyCode_003E5__3);
							num = -101520403;
							continue;
						case 6:
							ReInput.CheckInitialized(_003C_003E4__this.znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -101520401;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0152:
						int num3;
						if (_003Ci_003E5__2 < _003Ccount_003E5__1)
						{
							num = -101520405;
							num3 = num;
						}
						else
						{
							num = -101520411;
							num3 = num;
						}
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
					int num = keyboardKeyValues.Length;
					__keyIndexToKeyboardKeyCode = new KeyboardKeyCode[num];
					int num3 = default(int);
					while (true)
					{
						int num2 = 500384956;
						while (true)
						{
							switch (num2 ^ 0x1DD344BF)
							{
							case 0:
								break;
							case 3:
								num3 = 0;
								num2 = 500384957;
								continue;
							case 4:
								__keyIndexToKeyboardKeyCode[num3] = (KeyboardKeyCode)keyboardKeyValues[num3];
								num3++;
								num2 = 500384958;
								continue;
							case 2:
								num2 = 500384958;
								continue;
							case 1:
								goto IL_006b;
							default:
								goto end_IL_001c;
							}
							break;
							IL_006b:
							int num4;
							if (num3 >= num)
							{
								num2 = 500384954;
								num4 = num2;
							}
							else
							{
								num2 = 500384955;
								num4 = num2;
							}
						}
						continue;
						end_IL_001c:
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
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Guid.Empty;
				}
				return s_deviceInstanceGuid;
			}
		}

		internal Keyboard(string name, IUnifiedKeyboardSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.hardwareMap, 132, new ControllerDataUpdater(source.inputSource, 0, 132, null))
		{
			int num5 = default(int);
			int[] keyboardKeyValues = default(int[]);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 516366536;
				while (true)
				{
					switch (num ^ 0x1EC720CA)
					{
					case 8:
						break;
					case 1:
						num = 516366531;
						continue;
					case 0:
						ArrayTools.Fill(keyCodeToKeyIndex, -1);
						num5 = 0;
						num = 516366537;
						continue;
					case 4:
						if (keyboardKeyValues[num2] > maxKeyValue)
						{
							maxKeyValue = keyboardKeyValues[num2];
							num = 516366541;
							continue;
						}
						goto case 7;
					case 2:
						s_deviceInstanceGuid = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
						num = 516366528;
						continue;
					case 3:
						if (num5 >= num3)
						{
							_source = source;
							num = 516366543;
							continue;
						}
						goto case 6;
					case 7:
						num2++;
						num = 516366531;
						continue;
					case 10:
						keyboardKeyValues = Consts._keyboardKeyValues;
						num3 = keyboardKeyValues.Length;
						num2 = 0;
						num = 516366539;
						continue;
					case 11:
						num5++;
						num = 516366537;
						continue;
					case 9:
					{
						int num4;
						if (num2 >= num3)
						{
							num = 516366534;
							num4 = num;
						}
						else
						{
							num = 516366542;
							num4 = num;
						}
						continue;
					}
					case 6:
						keyCodeToKeyIndex[keyboardKeyValues[num5]] = num5;
						num = 516366529;
						continue;
					case 12:
						keyCodeToKeyIndex = new int[maxKeyValue + 1];
						num = 516366538;
						continue;
					default:
						snpHjGkGVogejiySyWIFjoJWDLTS();
						return;
					}
					break;
				}
			}
		}

		private Keyboard(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, HardwareControllerMap_Game hardwareMap, int buttonCount, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, buttonCount, null, hardwareMap, null, dataUpdater)
		{
			singleton = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				num = -511143236;
				goto IL_001e;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].JustDoublePressed(speed);
			IL_0019:
			num = -511143233;
			goto IL_001e;
			IL_001e:
			switch (num ^ -511143235)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				return false;
			}
			goto IL_0019;
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = -361217251;
					while (true)
					{
						switch (num ^ -361217252)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = -361217250;
					}
				}
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return false;
			}
			return buttons[keyCodeToKeyIndex[(int)keyCode]].valuePrev;
		}

		public float GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
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
					num = -861138804;
					goto IL_0012;
				}
				return false;
			}
			goto IL_005f;
			IL_005f:
			return true;
			IL_0012:
			switch (num ^ -861138804)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			default:
				goto IL_005f;
			}
			goto IL_000d;
			IL_000d:
			num = -861138803;
			goto IL_0012;
		}

		public bool GetModifierKeyDown(ModifierKey key)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			goto IL_0069;
			IL_0037:
			int num;
			while (true)
			{
				switch (num ^ -735309499)
				{
				case 4:
					break;
				case 2:
					goto IL_0058;
				case 3:
					return false;
				case 1:
					goto IL_0082;
				default:
					return false;
				}
				break;
				IL_0082:
				if (rightButton.valuePrev)
				{
					num = -735309499;
					continue;
				}
				return true;
				IL_0058:
				if (!rightButton.value)
				{
					num = -735309498;
					continue;
				}
				goto IL_0069;
			}
			goto IL_0032;
			IL_0069:
			int num2;
			if (leftButton.valuePrev)
			{
				num = -735309499;
				num2 = num;
			}
			else
			{
				num = -735309500;
				num2 = num;
			}
			goto IL_0037;
			IL_0032:
			num = -735309497;
			goto IL_0037;
		}

		public bool GetModifierKeyUp(ModifierKey key)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
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
					num = -1759833831;
					goto IL_001e;
				}
				if (!leftButton.valuePrev && !rightButton.valuePrev)
				{
					return false;
				}
				return true;
			}
			goto IL_005f;
			IL_001e:
			switch (num ^ -1759833832)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				goto IL_005f;
			}
			goto IL_0019;
			IL_005f:
			return false;
			IL_0019:
			num = -1759833830;
			goto IL_001e;
		}

		public bool GetModifierKeyPrev(ModifierKey key)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			Button leftButton;
			Button rightButton;
			if (!GetControlButtons(out leftButton, out rightButton, key))
			{
				return false;
			}
			if (!leftButton.valuePrev)
			{
				while (true)
				{
					int num = 1519210743;
					while (true)
					{
						switch (num ^ 0x5A8D50F5)
						{
						case 0:
							break;
						case 2:
							goto IL_0050;
						default:
							goto end_IL_0032;
						}
						break;
						IL_0050:
						if (rightButton.valuePrev)
						{
							num = 1519210740;
							continue;
						}
						return false;
					}
					continue;
					end_IL_0032:
					break;
				}
			}
			return true;
		}

		public float GetModifierKeyTimePressed(ModifierKey key)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			Button leftButton;
			Button rightButton;
			int num;
			if (!GetControlButtons(out leftButton, out rightButton, key))
			{
				num = 1924273764;
				goto IL_0012;
			}
			return MathTools.Max(leftButton.timePressed, rightButton.timePressed);
			IL_000d:
			num = 1924273765;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x72B21664)
				{
				case 3:
					break;
				case 1:
					goto IL_002f;
				case 2:
					return 0f;
				default:
					return 0f;
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				num = 1924273766;
			}
			goto IL_000d;
		}

		public float GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return KeyCode.None;
			}
			return KeyboardKeyCodeToKeyCode(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			if ((uint)keyCode > (uint)maxKeyValue)
			{
				return null;
			}
			return RCNejcvnZtMAmgendVbiwgNYmdD.buttonElementIdentifiers_cache[keyCodeToKeyIndex[(int)keyCode]];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_0010;
			}
			int count = Consts.keyboardKeyValues.Count;
			int num = 0;
			int num2 = 1642487499;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x61E65EC8)
				{
				case 2:
					break;
				case 1:
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[num];
					if (GetKey(keyCode))
					{
						return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, GetKeyName(keyCode), RCNejcvnZtMAmgendVbiwgNYmdD.buttonElementIdentifierIds[num], keyCode);
					}
					num++;
					num2 = 1642487496;
					continue;
				}
				case 3:
					num2 = 1642487496;
					continue;
				case 5:
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				case 4:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num2 = 1642487501;
					continue;
				default:
					if (num >= count)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					goto case 1;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num2 = 1642487500;
			goto IL_0015;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			//yield-return decompiler failed: Unable to find new state assignment for yield return
			_003CPollForAllKeys_003Ed__0 _003CPollForAllKeys_003Ed__1 = new _003CPollForAllKeys_003Ed__0(-2);
			_003CPollForAllKeys_003Ed__1._003C_003E4__this = this;
			return _003CPollForAllKeys_003Ed__1;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			int i = default(int);
			int count = default(int);
			while (true)
			{
				int num = -174218142;
				while (true)
				{
					switch (num ^ -174218141)
					{
					case 6:
						num = -174218144;
						continue;
					default:
						yield break;
					case 0:
						i++;
						num = -174218137;
						continue;
					case 1:
						if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
						{
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -174218138;
							continue;
						}
						goto case 2;
					case 2:
						count = Consts.keyboardKeyValues.Count;
						i = 0;
						num = -174218137;
						continue;
					case 4:
						num = ((i >= count) ? (-174218138) : (-174218140));
						continue;
					case 3:
						break;
					case 7:
					{
						KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
						if (GetKeyDown(keyCode))
						{
							yield return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), RCNejcvnZtMAmgendVbiwgNYmdD.buttonElementIdentifierIds[i], keyCode);
							num = -174218141;
							continue;
						}
						goto case 0;
					}
					}
					break;
				}
			}
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int count = Consts.keyboardKeyValues.Count;
			int num = 0;
			int num2 = -430520513;
			goto IL_001e;
			IL_001e:
			KeyCode keyCode = default(KeyCode);
			while (true)
			{
				switch (num2 ^ -430520518)
				{
				case 3:
					break;
				case 1:
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				case 5:
				{
					int num3;
					if (num < count)
					{
						num2 = -430520518;
						num3 = num2;
					}
					else
					{
						num2 = -430520520;
						num3 = num2;
					}
					continue;
				}
				case 0:
					keyCode = (KeyCode)Consts.keyboardKeyValues[num];
					num2 = -430520514;
					continue;
				case 4:
					if (GetKeyDown(keyCode))
					{
						return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, GetKeyName(keyCode), RCNejcvnZtMAmgendVbiwgNYmdD.buttonElementIdentifierIds[num], keyCode);
					}
					num++;
					num2 = -430520513;
					continue;
				default:
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num2 = -430520517;
			goto IL_001e;
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
			while (true)
			{
				switch (-1730521028 ^ -1730521027)
				{
				case 0:
					continue;
				case 1:
					switch (key)
					{
					case KeyCode.None:
						break;
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
					break;
				}
				break;
			}
			return false;
		}

		internal static bool IsModifierKey(KeyboardKeyCode key)
		{
			if (key != KeyboardKeyCode.None)
			{
				while (true)
				{
					int num = -1559012944;
					while (true)
					{
						switch (num ^ -1559012943)
						{
						case 3:
							break;
						case 1:
							goto IL_0028;
						default:
							goto end_IL_0006;
						case 0:
							return false;
						}
						break;
						IL_0028:
						switch (key)
						{
						case KeyboardKeyCode.RightShift:
						case KeyboardKeyCode.LeftShift:
						case KeyboardKeyCode.RightControl:
						case KeyboardKeyCode.LeftControl:
						case KeyboardKeyCode.RightAlt:
						case KeyboardKeyCode.LeftAlt:
						case KeyboardKeyCode.RightCommand:
						case KeyboardKeyCode.LeftCommand:
							return true;
						}
						num = -1559012943;
					}
					continue;
					end_IL_0006:
					break;
				}
			}
			return false;
		}

		public static ModifierKey KeyCodeToModifierKey(KeyCode key)
		{
			switch (key)
			{
			default:
				while (true)
				{
					switch (0xEF76071 ^ 0xEF76070)
					{
					case 2:
						continue;
					case 1:
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
					switch (-855488918 ^ -855488920)
					{
					case 0:
						continue;
					case 2:
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
			while (true)
			{
				int num = 1408765900;
				while (true)
				{
					switch (num ^ 0x53F80FCE)
					{
					case 6:
						break;
					case 2:
						switch (key)
						{
						case ModifierKey.Shift:
							if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
							{
								return true;
							}
							if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
							{
								num = 1408765902;
								continue;
							}
							return false;
						case ModifierKey.Alt:
							if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
							{
								num = 1408765899;
								continue;
							}
							if ((flags & ModifierKeyFlags.RightAlt) != ModifierKeyFlags.RightAlt)
							{
								return false;
							}
							num = 1408765903;
							continue;
						case ModifierKey.None:
							break;
						case ModifierKey.Control:
							if ((flags & ModifierKeyFlags.LeftControl) != ModifierKeyFlags.LeftControl)
							{
								if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
								{
									return true;
								}
								return false;
							}
							num = 1408765898;
							continue;
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
							return false;
						}
						goto case 3;
					case 1:
						return true;
					case 4:
						return true;
					case 3:
						return false;
					case 5:
						return true;
					default:
						return true;
					}
					break;
				}
			}
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, KeyCode key)
		{
			if (key != KeyCode.None)
			{
				while (true)
				{
					int num = -266983462;
					while (true)
					{
						switch (num ^ -266983464)
						{
						case 0:
							break;
						case 2:
							goto IL_0028;
						case 1:
							goto end_IL_0006;
						default:
							return true;
						}
						break;
						IL_0028:
						switch (key)
						{
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
								return true;
							}
							return false;
						case KeyCode.RightShift:
							if ((flags & ModifierKeyFlags.RightShift) != ModifierKeyFlags.RightShift)
							{
								return false;
							}
							break;
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
						num = -266983461;
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
				return ModifierKey.Control;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return ModifierKey.Control;
			}
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				goto IL_0016;
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
				num = 896516840;
				goto IL_001b;
			}
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return ModifierKey.Command;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return ModifierKey.Command;
			}
			return ModifierKey.None;
			IL_0016:
			num = 896516841;
			goto IL_001b;
			IL_001b:
			switch (num ^ 0x356FC2E8)
			{
			case 2:
				break;
			case 1:
				return ModifierKey.Alt;
			default:
				return ModifierKey.Shift;
			}
			goto IL_0016;
		}

		public static KeyCode ModifierKeyFlagsToKeyCode(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				goto IL_0006;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return KeyCode.RightControl;
			}
			int num;
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				num = -715626863;
			}
			else
			{
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
				if ((flags & ModifierKeyFlags.LeftCommand) != ModifierKeyFlags.LeftCommand)
				{
					if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
					{
						return KeyCode.RightCommand;
					}
					return KeyCode.None;
				}
				num = -715626862;
			}
			goto IL_000b;
			IL_0006:
			num = -715626861;
			goto IL_000b;
			IL_000b:
			switch (num ^ -715626862)
			{
			case 2:
				break;
			case 1:
				return KeyCode.LeftControl;
			case 3:
				return KeyCode.LeftAlt;
			default:
				return KeyCode.LeftCommand;
			}
			goto IL_0006;
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
				return string.Empty;
			}
			int buttonIndex = singleton.GetButtonIndex(KeyCodeToKeyboardKeyCode(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return singleton.ButtonElementIdentifiers[buttonIndex].name;
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
			string text = string.Empty;
			while (true)
			{
				int num2 = -243438445;
				while (true)
				{
					switch (num2 ^ -243438438)
					{
					case 10:
						break;
					case 13:
						if (ModifierKeyFlagsContain(flags, ModifierKey.Alt))
						{
							int num3;
							if (num > 0)
							{
								num2 = -243438442;
								num3 = num2;
							}
							else
							{
								num2 = -243438436;
								num3 = num2;
							}
							continue;
						}
						goto case 0;
					case 5:
						text += "Shift";
						num++;
						num2 = -243438446;
						continue;
					case 1:
						if (!ModifierKeyFlagsContain(flags, ModifierKey.Command))
						{
							goto case 13;
						}
						if (num > 0)
						{
							text += " + ";
							num2 = -243438435;
							continue;
						}
						goto case 7;
					case 7:
						if (!abbreviate)
						{
							text += "Command";
							num2 = -243438440;
							continue;
						}
						goto case 11;
					case 6:
						text += "Alt";
						num++;
						num2 = -243438438;
						continue;
					case 0:
						if (num >= 3)
						{
							return text;
						}
						if (ModifierKeyFlagsContain(flags, ModifierKey.Shift))
						{
							if (num > 0)
							{
								text += " + ";
								num2 = -243438433;
								continue;
							}
							goto case 5;
						}
						goto default;
					case 12:
						text += " + ";
						num2 = -243438436;
						continue;
					case 3:
						num++;
						num2 = -243438437;
						continue;
					case 2:
						num++;
						num2 = -243438441;
						continue;
					case 9:
						if (!ModifierKeyFlagsContain(flags, ModifierKey.Control))
						{
							goto case 1;
						}
						if (!abbreviate)
						{
							text += "Control";
							num2 = -243438439;
							continue;
						}
						goto case 4;
					case 4:
						text += "Ctrl";
						num2 = -243438439;
						continue;
					case 11:
						text += "Cmd";
						num2 = -243438440;
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
				flags |= ModifierKeyFlags.RightControl;
				goto IL_000e;
			}
			goto IL_00f4;
			IL_004f:
			int num;
			int num2;
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				num = 1474377799;
				num2 = num;
			}
			else
			{
				num = 1474377796;
				num2 = num;
			}
			goto IL_0013;
			IL_000e:
			num = 1474377792;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ 0x57E13841)
				{
				case 8:
					break;
				case 3:
					goto IL_004f;
				case 5:
					goto IL_0066;
				case 4:
					goto IL_007f;
				case 9:
					if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
					{
						flags |= ModifierKeyFlags.LeftShift;
						num = 1474377803;
						continue;
					}
					goto default;
				case 2:
					goto IL_00b2;
				case 6:
					flags |= ModifierKeyFlags.LeftAlt;
					num = 1474377796;
					continue;
				case 7:
					goto IL_00d6;
				case 1:
					goto IL_00f4;
				case 0:
					flags |= ModifierKeyFlags.RightShift;
					num = 1474377800;
					continue;
				default:
					return flags;
				}
				break;
				IL_0066:
				int num3;
				if ((flags & ModifierKeyFlags.LeftShift) != ModifierKeyFlags.LeftShift)
				{
					num = 1474377800;
					num3 = num;
				}
				else
				{
					num = 1474377793;
					num3 = num;
				}
			}
			goto IL_000e;
			IL_00b2:
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				flags |= ModifierKeyFlags.RightAlt;
				num = 1474377794;
				goto IL_0013;
			}
			goto IL_004f;
			IL_00f4:
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				flags |= ModifierKeyFlags.LeftControl;
				num = 1474377797;
				goto IL_0013;
			}
			goto IL_007f;
			IL_00d6:
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				flags |= ModifierKeyFlags.LeftCommand;
				num = 1474377795;
				goto IL_0013;
			}
			goto IL_00b2;
			IL_007f:
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				flags |= ModifierKeyFlags.RightCommand;
				num = 1474377798;
				goto IL_0013;
			}
			goto IL_00d6;
		}

		internal static int GetDoubledModifierKeyCount(ModifierKeyFlags flags)
		{
			if (flags == ModifierKeyFlags.None)
			{
				goto IL_0006;
			}
			int num = 0;
			int num2;
			int num3;
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				num2 = 1578704570;
				num3 = num2;
			}
			else
			{
				num2 = 1578704571;
				num3 = num2;
			}
			goto IL_000b;
			IL_0006:
			num2 = 1578704566;
			goto IL_000b;
			IL_000b:
			while (true)
			{
				switch (num2 ^ 0x5E191EBE)
				{
				case 14:
					break;
				case 2:
					if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
					{
						num++;
						num2 = 1578704562;
						continue;
					}
					goto case 0;
				case 12:
				{
					int num6;
					if ((flags & ModifierKeyFlags.LeftAlt) != ModifierKeyFlags.LeftAlt)
					{
						num2 = 1578704567;
						num6 = num2;
					}
					else
					{
						num2 = 1578704575;
						num6 = num2;
					}
					continue;
				}
				case 0:
					if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
					{
						num++;
						num2 = 1578704562;
						continue;
					}
					goto case 12;
				case 9:
					if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
					{
						num++;
						num2 = 1578704573;
						continue;
					}
					goto case 3;
				case 13:
					num++;
					num2 = 1578704572;
					continue;
				case 1:
					num++;
					num2 = 1578704565;
					continue;
				case 4:
					num++;
					num2 = 1578704572;
					continue;
				case 7:
				{
					int num5;
					if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
					{
						num2 = 1578704568;
						num5 = num2;
					}
					else
					{
						num2 = 1578704564;
						num5 = num2;
					}
					continue;
				}
				case 8:
					return 0;
				case 11:
					num2 = 1578704573;
					continue;
				case 3:
					if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
					{
						num++;
						num2 = 1578704564;
						continue;
					}
					goto case 7;
				case 6:
					num++;
					num2 = 1578704564;
					continue;
				case 5:
				{
					int num4;
					if ((flags & ModifierKeyFlags.RightControl) != ModifierKeyFlags.RightControl)
					{
						num2 = 1578704572;
						num4 = num2;
					}
					else
					{
						num2 = 1578704563;
						num4 = num2;
					}
					continue;
				}
				default:
					return num;
				}
				break;
			}
			goto IL_0006;
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
				while (true)
				{
					switch (0x43C011BF ^ 0x43C011BE)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			keyCode = ReInput.uzYFVAOPCugnffcKSwcZmFfGUjB.Keyboard.GetKeyCodeById(elementIdentifierId);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			_source.UpdateInputData(ybiZyKuVmvsrOHqZzdmfwidXkdm);
			base.UpdateData(updateLoop);
			UpdateCurrentModifierKeyFlags();
		}

		internal void UpdateData_AndroidKeyboardDisabled(UpdateLoopType updateLoop)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].MPPQJfVkqEnvckKDMacDSmlvhjwB(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, ybiZyKuVmvsrOHqZzdmfwidXkdm);
			while (true)
			{
				int num = 1554473165;
				while (true)
				{
					switch (num ^ 0x5CA760CC)
					{
					case 2:
						break;
					case 1:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].MPPQJfVkqEnvckKDMacDSmlvhjwB(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, ybiZyKuVmvsrOHqZzdmfwidXkdm);
						num = 1554473167;
						continue;
					case 3:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].MPPQJfVkqEnvckKDMacDSmlvhjwB(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, ybiZyKuVmvsrOHqZzdmfwidXkdm);
						num = 1554473164;
						continue;
					default:
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].MPPQJfVkqEnvckKDMacDSmlvhjwB(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, ybiZyKuVmvsrOHqZzdmfwidXkdm);
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].MPPQJfVkqEnvckKDMacDSmlvhjwB(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, ybiZyKuVmvsrOHqZzdmfwidXkdm);
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].MPPQJfVkqEnvckKDMacDSmlvhjwB(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, ybiZyKuVmvsrOHqZzdmfwidXkdm);
						buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].MPPQJfVkqEnvckKDMacDSmlvhjwB(updateLoop, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, ybiZyKuVmvsrOHqZzdmfwidXkdm);
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
				goto IL_000c;
			}
			int num;
			float keyTimePressed = default(float);
			if (doubledFlags != ModifierKeyFlags.None)
			{
				if ((doubledFlags & currentModfierKeyFlagsDouble) != doubledFlags)
				{
					num = 1995701518;
				}
				else
				{
					keyTimePressed = GetKeyTimePressed((KeyCode)keyCode);
					num = 1995701513;
				}
			}
			else
			{
				num = 1995701517;
			}
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num ^ 0x76F3FD0F)
				{
				case 5:
					break;
				case 6:
					if ((doubledFlags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
					{
						num = 1995701519;
						continue;
					}
					goto IL_0067;
				case 2:
					return true;
				case 0:
					if (keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Control))
					{
						return false;
					}
					goto IL_0067;
				case 1:
					return false;
				case 3:
					return false;
				default:
					{
						return false;
					}
					IL_0067:
					if ((doubledFlags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Command))
					{
						num = 1995701515;
						continue;
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
			goto IL_000c;
			IL_000c:
			num = 1995701516;
			goto IL_0011;
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
				return;
			}
			int num2 = default(int);
			while (true)
			{
				IList<ActionElementMap> buttonMaps_orig = controllerMap.ButtonMaps_orig;
				int count = buttonMaps_orig.Count;
				int num = -1330164755;
				while (true)
				{
					switch (num ^ -1330164760)
					{
					case 0:
						num = -1330164756;
						continue;
					default:
						return;
					case 6:
					{
						int num3;
						if (num2 >= count)
						{
							num = -1330164757;
							num3 = num;
						}
						else
						{
							num = -1330164759;
							num3 = num;
						}
						continue;
					}
					case 5:
						num2 = 0;
						num = -1330164758;
						continue;
					case 2:
						num = -1330164754;
						continue;
					case 4:
						break;
					case 1:
						BakeActionElementMap(controllerMap, buttonMaps_orig[num2]);
						num2++;
						num = -1330164754;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			if (map != null)
			{
				map.IKsKsQjqHpGcmPftZSVTCEpXtFB(controllerMap);
			}
		}

		internal override void Clear()
		{
			base.Clear();
			currentModfierKeyFlags = ModifierKeyFlags.None;
			while (true)
			{
				int num = -560657025;
				while (true)
				{
					switch (num ^ -560657026)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002b;
					case 2:
						return;
					}
					break;
					IL_002b:
					currentModfierKeyFlagsDouble = ModifierKeyFlags.None;
					num = -560657028;
				}
			}
		}

		private bool GetControlButtons(out Button leftButton, out Button rightButton, ModifierKey key)
		{
			leftButton = null;
			rightButton = null;
			while (true)
			{
				int num = 1550527495;
				while (true)
				{
					switch (num ^ 0x5C6B2C06)
					{
					case 0:
						break;
					case 5:
						rightButton = buttons[keyCodeToKeyIndex[305]];
						num = 1550527493;
						continue;
					case 4:
						return false;
					case 1:
						switch (key)
						{
						case ModifierKey.None:
							break;
						case ModifierKey.Control:
							leftButton = buttons[keyCodeToKeyIndex[306]];
							num = 1550527491;
							continue;
						case ModifierKey.Alt:
							leftButton = buttons[keyCodeToKeyIndex[308]];
							num = 1550527492;
							continue;
						case ModifierKey.Command:
							leftButton = buttons[keyCodeToKeyIndex[310]];
							rightButton = buttons[keyCodeToKeyIndex[309]];
							return true;
						case ModifierKey.Shift:
							leftButton = buttons[keyCodeToKeyIndex[304]];
							rightButton = buttons[keyCodeToKeyIndex[303]];
							return true;
						default:
							return false;
						}
						goto case 4;
					case 3:
						return true;
					default:
						rightButton = buttons[keyCodeToKeyIndex[307]];
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
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
				goto IL_0020;
			}
			goto IL_0098;
			IL_0098:
			int num;
			int num2;
			if (!buttons[keyCodeToKeyIndex[305]].value)
			{
				num = 1017209373;
				num2 = num;
			}
			else
			{
				num = 1017209371;
				num2 = num;
			}
			goto IL_0025;
			IL_0020:
			num = 1017209360;
			goto IL_0025;
			IL_0025:
			while (true)
			{
				switch (num ^ 0x3CA16218)
				{
				case 0:
					break;
				case 4:
					if (buttons[keyCodeToKeyIndex[308]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
						num = 1017209370;
						continue;
					}
					goto case 2;
				case 3:
					modifierKeyFlags |= ModifierKeyFlags.RightControl;
					num = 1017209373;
					continue;
				case 8:
					goto IL_0098;
				case 1:
					goto IL_00c6;
				case 9:
					goto IL_00f4;
				case 6:
					modifierKeyFlags |= ModifierKeyFlags.LeftShift;
					num = 1017209375;
					continue;
				case 10:
					modifierKeyFlags |= ModifierKeyFlags.RightCommand;
					num = 1017209372;
					continue;
				case 2:
					if (buttons[keyCodeToKeyIndex[307]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.RightAlt;
						num = 1017209361;
						continue;
					}
					goto IL_00f4;
				case 5:
					if (buttons[keyCodeToKeyIndex[310]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
						num = 1017209369;
						continue;
					}
					goto IL_00c6;
				case 7:
					if (buttons[keyCodeToKeyIndex[303]].value)
					{
						modifierKeyFlags |= ModifierKeyFlags.RightShift;
						num = 1017209363;
						continue;
					}
					goto default;
				default:
					currentModfierKeyFlags = modifierKeyFlags;
					currentModfierKeyFlagsDouble = ConvertModifierKeyFlagsSingleToDouble(modifierKeyFlags);
					return;
				}
				break;
				IL_00c6:
				int num3;
				if (!buttons[keyCodeToKeyIndex[309]].value)
				{
					num = 1017209372;
					num3 = num;
				}
				else
				{
					num = 1017209362;
					num3 = num;
				}
				continue;
				IL_00f4:
				int num4;
				if (!buttons[keyCodeToKeyIndex[304]].value)
				{
					num = 1017209375;
					num4 = num;
				}
				else
				{
					num = 1017209374;
					num4 = num;
				}
			}
			goto IL_0020;
		}
	}
}
