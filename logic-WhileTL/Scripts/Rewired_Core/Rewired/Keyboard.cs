using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public sealed class Keyboard : ControllerWithMap
	{
		private sealed class rxFaEIzQeCUvtZJyMZKJxDwDbcGy : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public Keyboard GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int rQxXsDHwqrAGdbUKSjizQYdQKkCA;

			private int eolRghqutZOOIGqvOFTzJOGfYTsn;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public rxFaEIzQeCUvtZJyMZKJxDwDbcGy(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				Keyboard gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_00bf;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				rQxXsDHwqrAGdbUKSjizQYdQKkCA = Consts.keyboardKeyValues.Count;
				eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
				goto IL_00cf;
				IL_00cf:
				if (eolRghqutZOOIGqvOFTzJOGfYTsn < rQxXsDHwqrAGdbUKSjizQYdQKkCA)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[eolRghqutZOOIGqvOFTzJOGfYTsn];
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.GetKey(keyCode))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(true, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY.id, gZXxEqHwrHYIyUJtInpLwgTukJaY._name, gZXxEqHwrHYIyUJtInpLwgTukJaY._type, ControllerElementType.Button, eolRghqutZOOIGqvOFTzJOGfYTsn, Pole.Positive, GetKeyName(keyCode), gZXxEqHwrHYIyUJtInpLwgTukJaY.jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonElementIdentifierIds[eolRghqutZOOIGqvOFTzJOGfYTsn], keyCode);
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				eolRghqutZOOIGqvOFTzJOGfYTsn++;
				goto IL_00cf;
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				rxFaEIzQeCUvtZJyMZKJxDwDbcGy rxFaEIzQeCUvtZJyMZKJxDwDbcGy2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					rxFaEIzQeCUvtZJyMZKJxDwDbcGy2 = this;
				}
				else
				{
					rxFaEIzQeCUvtZJyMZKJxDwDbcGy2 = new rxFaEIzQeCUvtZJyMZKJxDwDbcGy(0);
					rxFaEIzQeCUvtZJyMZKJxDwDbcGy2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return rxFaEIzQeCUvtZJyMZKJxDwDbcGy2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class IkUwFFIbjTXBLXajResnIDVhlCrh : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public Keyboard GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int rQxXsDHwqrAGdbUKSjizQYdQKkCA;

			private int eolRghqutZOOIGqvOFTzJOGfYTsn;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public IkUwFFIbjTXBLXajResnIDVhlCrh(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				Keyboard gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_00bf;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				rQxXsDHwqrAGdbUKSjizQYdQKkCA = Consts.keyboardKeyValues.Count;
				eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
				goto IL_00cf;
				IL_00cf:
				if (eolRghqutZOOIGqvOFTzJOGfYTsn < rQxXsDHwqrAGdbUKSjizQYdQKkCA)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[eolRghqutZOOIGqvOFTzJOGfYTsn];
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.GetKeyDown(keyCode))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(true, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY.id, gZXxEqHwrHYIyUJtInpLwgTukJaY._name, gZXxEqHwrHYIyUJtInpLwgTukJaY._type, ControllerElementType.Button, eolRghqutZOOIGqvOFTzJOGfYTsn, Pole.Positive, GetKeyName(keyCode), gZXxEqHwrHYIyUJtInpLwgTukJaY.jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonElementIdentifierIds[eolRghqutZOOIGqvOFTzJOGfYTsn], keyCode);
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				eolRghqutZOOIGqvOFTzJOGfYTsn++;
				goto IL_00cf;
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				IkUwFFIbjTXBLXajResnIDVhlCrh ikUwFFIbjTXBLXajResnIDVhlCrh;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					ikUwFFIbjTXBLXajResnIDVhlCrh = this;
				}
				else
				{
					ikUwFFIbjTXBLXajResnIDVhlCrh = new IkUwFFIbjTXBLXajResnIDVhlCrh(0);
					ikUwFFIbjTXBLXajResnIDVhlCrh.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return ikUwFFIbjTXBLXajResnIDVhlCrh;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private static Keyboard YjYKKlgaJQlKHVPsHLphCECUobgV;

		private readonly IUnifiedKeyboardSource vPTVBGMeTSLLhqcGnbvGjLFkMncb;

		private ModifierKeyFlags opaFEghCMbaskujcLLdCQPzQBjdj;

		private ModifierKeyFlags IRZacNAmKTcWsgHXVBUnRViHawMbb;

		private Func<KeyboardKeyCode, int> hiWCtFheHJBvkFQWZhrRITEVkrkNA;

		private readonly int[] nfBdsxGcSnOQTMYpOdFZnKqcjnilA;

		private static KeyboardKeyCode[] mXHlGxuBdNscjkKwbegOAdftDrrqA;

		private readonly int bSkEQoFNHmMejiZadjRvNbwinMCUE;

		private static Guid yokikIRxPHuRDmPVzFwYrBTdCeXH;

		private static KeyboardKeyCode[] dACURjPmCYbTzEYUAZAgPxmkuauy
		{
			get
			{
				if (mXHlGxuBdNscjkKwbegOAdftDrrqA == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					mXHlGxuBdNscjkKwbegOAdftDrrqA = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						mXHlGxuBdNscjkKwbegOAdftDrrqA[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return mXHlGxuBdNscjkKwbegOAdftDrrqA;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Guid.Empty;
				}
				return yokikIRxPHuRDmPVzFwYrBTdCeXH;
			}
		}

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
		{
			yokikIRxPHuRDmPVzFwYrBTdCeXH = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int i = 0; i < num; i++)
			{
				if (keyboardKeyValues[i] > bSkEQoFNHmMejiZadjRvNbwinMCUE)
				{
					bSkEQoFNHmMejiZadjRvNbwinMCUE = keyboardKeyValues[i];
				}
			}
			nfBdsxGcSnOQTMYpOdFZnKqcjnilA = new int[bSkEQoFNHmMejiZadjRvNbwinMCUE + 1];
			ArrayTools.Fill(nfBdsxGcSnOQTMYpOdFZnKqcjnilA, -1);
			for (int j = 0; j < num; j++)
			{
				nfBdsxGcSnOQTMYpOdFZnKqcjnilA[keyboardKeyValues[j]] = j;
			}
			vPTVBGMeTSLLhqcGnbvGjLFkMncb = P_1;
			WCmnBnYePrGAMdoiUNBATVOhqgEEA();
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
		{
			YjYKKlgaJQlKHVPsHLphCECUobgV = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return 0.0;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return 0.0;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (!RkvDdcDkaSZgyZofWltlTuEZTRdP(out var button, out var button2, key))
			{
				return false;
			}
			if (button.value || button2.value)
			{
				return true;
			}
			return false;
		}

		public bool GetModifierKeyDown(ModifierKey key)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (!RkvDdcDkaSZgyZofWltlTuEZTRdP(out var button, out var button2, key))
			{
				return false;
			}
			if (!button.value && !button2.value)
			{
				return false;
			}
			if (button.valuePrev || button2.valuePrev)
			{
				return false;
			}
			return true;
		}

		public bool GetModifierKeyUp(ModifierKey key)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (!RkvDdcDkaSZgyZofWltlTuEZTRdP(out var button, out var button2, key))
			{
				return false;
			}
			if (button.value || button2.value)
			{
				return false;
			}
			if (!button.valuePrev && !button2.valuePrev)
			{
				return false;
			}
			return true;
		}

		public bool GetModifierKeyPrev(ModifierKey key)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (!RkvDdcDkaSZgyZofWltlTuEZTRdP(out var button, out var button2, key))
			{
				return false;
			}
			if (button.valuePrev || button2.valuePrev)
			{
				return true;
			}
			return false;
		}

		public double GetModifierKeyTimePressed(ModifierKey key)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			if (!RkvDdcDkaSZgyZofWltlTuEZTRdP(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			if (!RkvDdcDkaSZgyZofWltlTuEZTRdP(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return KeyCode.None;
			}
			return SiQpXJLzEXeaVoEePDzKhMakYCUfA(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return -1;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return -1;
			}
			return nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return null;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return new rxFaEIzQeCUvtZJyMZKJxDwDbcGy(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return new IkUwFFIbjTXBLXajResnIDVhlCrh(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
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
			case KeyCode.RightMeta:
			case KeyCode.LeftMeta:
				return true;
			default:
				return false;
			}
		}

		internal static bool wVmqsgOApqHhpSlhioGKGueFIHvD(KeyboardKeyCode P_0)
		{
			switch (P_0)
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
			case KeyCode.None:
				return ModifierKey.None;
			case KeyCode.RightControl:
			case KeyCode.LeftControl:
				return ModifierKey.Control;
			case KeyCode.RightAlt:
			case KeyCode.LeftAlt:
				return ModifierKey.Alt;
			case KeyCode.RightMeta:
			case KeyCode.LeftMeta:
				return ModifierKey.Command;
			case KeyCode.RightShift:
			case KeyCode.LeftShift:
				return ModifierKey.Shift;
			default:
				return ModifierKey.None;
			}
		}

		public static ModifierKeyFlags KeyCodeToModifierKeyFlags(KeyCode key)
		{
			return key switch
			{
				KeyCode.LeftControl => ModifierKeyFlags.LeftControl, 
				KeyCode.RightControl => ModifierKeyFlags.RightControl, 
				KeyCode.LeftAlt => ModifierKeyFlags.LeftAlt, 
				KeyCode.RightAlt => ModifierKeyFlags.RightAlt, 
				KeyCode.LeftShift => ModifierKeyFlags.LeftShift, 
				KeyCode.RightShift => ModifierKeyFlags.RightShift, 
				KeyCode.LeftMeta => ModifierKeyFlags.LeftCommand, 
				KeyCode.RightMeta => ModifierKeyFlags.RightCommand, 
				_ => ModifierKeyFlags.None, 
			};
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, ModifierKey key)
		{
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
					return true;
				}
				if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
				{
					return true;
				}
				return false;
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
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, KeyCode key)
		{
			switch (key)
			{
			case KeyCode.None:
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
					return true;
				}
				return false;
			case KeyCode.RightShift:
				if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
				{
					return true;
				}
				return false;
			case KeyCode.LeftMeta:
				if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
				{
					return true;
				}
				return false;
			case KeyCode.RightMeta:
				if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
				{
					return true;
				}
				return false;
			default:
				return false;
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
				return ModifierKey.Shift;
			}
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return ModifierKey.Shift;
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
				return KeyCode.LeftMeta;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return KeyCode.RightMeta;
			}
			return KeyCode.None;
		}

		public static ModifierKeyFlags ModifierKeyToModifierKeyFlags(ModifierKey key)
		{
			return key switch
			{
				ModifierKey.None => ModifierKeyFlags.None, 
				ModifierKey.Control => ModifierKeyFlags.LeftControl | ModifierKeyFlags.RightControl, 
				ModifierKey.Alt => ModifierKeyFlags.LeftAlt | ModifierKeyFlags.RightAlt, 
				ModifierKey.Shift => ModifierKeyFlags.LeftShift | ModifierKeyFlags.RightShift, 
				ModifierKey.Command => ModifierKeyFlags.LeftCommand | ModifierKeyFlags.RightCommand, 
				_ => ModifierKeyFlags.None, 
			};
		}

		public static string GetKeyName(KeyCode key)
		{
			if (YjYKKlgaJQlKHVPsHLphCECUobgV == null)
			{
				return string.Empty;
			}
			int buttonIndex = YjYKKlgaJQlKHVPsHLphCECUobgV.GetButtonIndex(kEtfTVdBeByvgzacNiNLTEzUmusc(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return YjYKKlgaJQlKHVPsHLphCECUobgV.ButtonElementIdentifiers[buttonIndex].name;
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
			if (ModifierKeyFlagsContain(flags, ModifierKey.Control))
			{
				text = (abbreviate ? (text + "Ctrl") : (text + "Control"));
				num++;
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Command))
			{
				if (num > 0)
				{
					text += " + ";
				}
				text = (abbreviate ? (text + "Cmd") : (text + "Command"));
				num++;
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Alt))
			{
				if (num > 0)
				{
					text += " + ";
				}
				text += "Alt";
				num++;
			}
			if (num >= 3)
			{
				return text;
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Shift))
			{
				if (num > 0)
				{
					text += " + ";
				}
				text += "Shift";
				num++;
			}
			return text;
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return ModifierKeyFlagsToString(flags, abbreviate: false);
		}

		internal static KeyboardKeyCode kEtfTVdBeByvgzacNiNLTEzUmusc(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode SiQpXJLzEXeaVoEePDzKhMakYCUfA(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags nmwDMeCeKnoseUUzdfXRMUJcsxheA(ModifierKeyFlags P_0)
		{
			if ((P_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				P_0 |= ModifierKeyFlags.RightControl;
			}
			if ((P_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				P_0 |= ModifierKeyFlags.LeftControl;
			}
			if ((P_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				P_0 |= ModifierKeyFlags.RightCommand;
			}
			if ((P_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				P_0 |= ModifierKeyFlags.LeftCommand;
			}
			if ((P_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				P_0 |= ModifierKeyFlags.RightAlt;
			}
			if ((P_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				P_0 |= ModifierKeyFlags.LeftAlt;
			}
			if ((P_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				P_0 |= ModifierKeyFlags.RightShift;
			}
			if ((P_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				P_0 |= ModifierKeyFlags.LeftShift;
			}
			return P_0;
		}

		internal static int SxabNIXxQbdKAbhMVvfcMfjmjWBn(ModifierKeyFlags P_0)
		{
			if (P_0 == ModifierKeyFlags.None)
			{
				return 0;
			}
			int num = 0;
			if ((P_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				num++;
			}
			if ((P_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				num++;
			}
			if ((P_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				num++;
			}
			if ((P_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				num++;
			}
			return num;
		}

		[CustomObfuscation(rename = false)]
		internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
		{
			if ((uint)buttonIndex > 132u)
			{
				return KeyboardKeyCode.None;
			}
			return dACURjPmCYbTzEYUAZAgPxmkuauy[buttonIndex];
		}

		internal static int jlNwGBEmXGMRExmAEcsgpQxZAkpeA(KeyboardKeyCode P_0)
		{
			int buttonIndex = YjYKKlgaJQlKHVPsHLphCECUobgV.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return YjYKKlgaJQlKHVPsHLphCECUobgV.ButtonElementIdentifiers[buttonIndex].id;
		}

		internal static void VEtEFJdPkgAIPgWrifMLJrFsdpef(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = jlNwGBEmXGMRExmAEcsgpQxZAkpeA(kEtfTVdBeByvgzacNiNLTEzUmusc(P_1));
			}
			else
			{
				P_1 = ReInput.OkLkjfkBGntRAvakyAvYRRgphMAiA.ZvUlvpaVsbPQTtRuvnrrPLgdkCtF.GetKeyCodeById(P_0);
			}
		}

		internal override void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
			vPTVBGMeTSLLhqcGnbvGjLFkMncb.UpdateInputData(WlduKdCdymfJzhLxPcswpRugJOzgb);
			base.OPzMeptHNTMsrWdWvslRxoVUdTujA(P_0);
			YqVdeXrtrrDmDGgAXWExvUSpFIGi();
		}

		internal void AtZsPRMlIyAwbhaBjgudEKPCjOTUA(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].oZQllQxQuNaPXytzirxUjNaKuQtr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, WlduKdCdymfJzhLxPcswpRugJOzgb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].oZQllQxQuNaPXytzirxUjNaKuQtr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, WlduKdCdymfJzhLxPcswpRugJOzgb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].oZQllQxQuNaPXytzirxUjNaKuQtr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, WlduKdCdymfJzhLxPcswpRugJOzgb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].oZQllQxQuNaPXytzirxUjNaKuQtr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, WlduKdCdymfJzhLxPcswpRugJOzgb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].oZQllQxQuNaPXytzirxUjNaKuQtr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, WlduKdCdymfJzhLxPcswpRugJOzgb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].oZQllQxQuNaPXytzirxUjNaKuQtr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, WlduKdCdymfJzhLxPcswpRugJOzgb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].oZQllQxQuNaPXytzirxUjNaKuQtr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, WlduKdCdymfJzhLxPcswpRugJOzgb);
		}

		internal bool OqIVvNhSUckGdBVPATbxZKFuFBoR(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool pWJCpPePiHmPfMQsjqxyqjShHDGz(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return false;
			}
			int num = nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool adWmGbiOufRWIJOuXfEhtFDuBHOA(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!OqIVvNhSUckGdBVPATbxZKFuFBoR(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & IRZacNAmKTcWsgHXVBUnRViHawMbb) != P_1)
			{
				return false;
			}
			double keyTimePressed = GetKeyTimePressed((KeyCode)P_0);
			if ((P_1 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Control))
			{
				return false;
			}
			if ((P_1 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Command))
			{
				return false;
			}
			if ((P_1 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Alt))
			{
				return false;
			}
			if ((P_1 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Shift))
			{
				return false;
			}
			return true;
		}

		internal bool ihAXxhYFApHXSIzqThzQCxbhfHWO(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (OqIVvNhSUckGdBVPATbxZKFuFBoR(P_0))
			{
				return true;
			}
			if (GetModifierKey(ModifierKeyFlagsToModifierKey(P_1)))
			{
				return true;
			}
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal int GetButtonIndex(KeyboardKeyCode keyCode)
		{
			if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
			{
				return -1;
			}
			return nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> list = controllerMap.fHfLawVRnAIjFLcvXQTtiXDuzgak;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					OkYVVItyDNIRrZjZSvdPINJLnmkM(controllerMap, list[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.kArqsxPmpmoyPVFqtFYUjLfaKBQC(controllerMap);
		}

		internal override void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			base.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			opaFEghCMbaskujcLLdCQPzQBjdj = ModifierKeyFlags.None;
			IRZacNAmKTcWsgHXVBUnRViHawMbb = ModifierKeyFlags.None;
		}

		internal override bool CPoVkJzroBtMRwmbFEndkvOzAAwfb(bool P_0)
		{
			if (!base.CPoVkJzroBtMRwmbFEndkvOzAAwfb(P_0))
			{
				return false;
			}
			if (vPTVBGMeTSLLhqcGnbvGjLFkMncb is IGetSetEnabled)
			{
				(vPTVBGMeTSLLhqcGnbvGjLFkMncb as IGetSetEnabled).enabled = P_0;
			}
			return true;
		}

		private bool RkvDdcDkaSZgyZofWltlTuEZTRdP(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[306]];
				P_1 = buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[308]];
				P_1 = buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[310]];
				P_1 = buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[304]];
				P_1 = buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[303]];
				return true;
			default:
				return false;
			}
		}

		private void YqVdeXrtrrDmDGgAXWExvUSpFIGi()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			opaFEghCMbaskujcLLdCQPzQBjdj = modifierKeyFlags;
			IRZacNAmKTcWsgHXVBUnRViHawMbb = nmwDMeCeKnoseUUzdfXRMUJcsxheA(modifierKeyFlags);
		}
	}
}
