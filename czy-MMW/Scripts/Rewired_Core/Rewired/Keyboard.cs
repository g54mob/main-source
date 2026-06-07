using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public sealed class Keyboard : ControllerWithMap
	{
		private sealed class ZjyDtSrEFfJPKZOBewXSAuqmdMqC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int giHRSNcfBJSTjpaABmBPMHjohjV;

			private ControllerPollingInfo EwaEmhMZIpncorMarzSOntWkMazq;

			private int qXqvkgsnpMtGCAgKNZaHAePlAymN;

			public Keyboard ZmgYusKgRhMFmJDYOTTYsFEkdbMV;

			private int KLqvJzKMHVDIPasmCZCTjFYKDjMw;

			private int GTLNictYzHlcRqbxPUoNDOzbtUCJ;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return EwaEmhMZIpncorMarzSOntWkMazq;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EwaEmhMZIpncorMarzSOntWkMazq;
				}
			}

			[DebuggerHidden]
			public ZjyDtSrEFfJPKZOBewXSAuqmdMqC(int P_0)
			{
				giHRSNcfBJSTjpaABmBPMHjohjV = P_0;
				qXqvkgsnpMtGCAgKNZaHAePlAymN = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = giHRSNcfBJSTjpaABmBPMHjohjV;
				Keyboard zmgYusKgRhMFmJDYOTTYsFEkdbMV = ZmgYusKgRhMFmJDYOTTYsFEkdbMV;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					giHRSNcfBJSTjpaABmBPMHjohjV = -1;
					goto IL_00bf;
				}
				giHRSNcfBJSTjpaABmBPMHjohjV = -1;
				if (ReInput._id != zmgYusKgRhMFmJDYOTTYsFEkdbMV.FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(zmgYusKgRhMFmJDYOTTYsFEkdbMV.FtWUXMFFyhqCthzgjKfOhWsryipI);
					return false;
				}
				KLqvJzKMHVDIPasmCZCTjFYKDjMw = Consts.keyboardKeyValues.Count;
				GTLNictYzHlcRqbxPUoNDOzbtUCJ = 0;
				goto IL_00cf;
				IL_00cf:
				if (GTLNictYzHlcRqbxPUoNDOzbtUCJ < KLqvJzKMHVDIPasmCZCTjFYKDjMw)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[GTLNictYzHlcRqbxPUoNDOzbtUCJ];
					if (zmgYusKgRhMFmJDYOTTYsFEkdbMV.GetKey(keyCode))
					{
						EwaEmhMZIpncorMarzSOntWkMazq = new ControllerPollingInfo(true, -1, zmgYusKgRhMFmJDYOTTYsFEkdbMV.id, zmgYusKgRhMFmJDYOTTYsFEkdbMV._name, zmgYusKgRhMFmJDYOTTYsFEkdbMV._type, ControllerElementType.Button, GTLNictYzHlcRqbxPUoNDOzbtUCJ, Pole.Positive, GetKeyName(keyCode), zmgYusKgRhMFmJDYOTTYsFEkdbMV.XRregwEugLWeubJCKxSQAwUDapNP.buttonElementIdentifierIds[GTLNictYzHlcRqbxPUoNDOzbtUCJ], keyCode);
						giHRSNcfBJSTjpaABmBPMHjohjV = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				GTLNictYzHlcRqbxPUoNDOzbtUCJ++;
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
				ZjyDtSrEFfJPKZOBewXSAuqmdMqC zjyDtSrEFfJPKZOBewXSAuqmdMqC;
				if (giHRSNcfBJSTjpaABmBPMHjohjV == -2 && qXqvkgsnpMtGCAgKNZaHAePlAymN == Environment.CurrentManagedThreadId)
				{
					giHRSNcfBJSTjpaABmBPMHjohjV = 0;
					zjyDtSrEFfJPKZOBewXSAuqmdMqC = this;
				}
				else
				{
					zjyDtSrEFfJPKZOBewXSAuqmdMqC = new ZjyDtSrEFfJPKZOBewXSAuqmdMqC(0);
					zjyDtSrEFfJPKZOBewXSAuqmdMqC.ZmgYusKgRhMFmJDYOTTYsFEkdbMV = ZmgYusKgRhMFmJDYOTTYsFEkdbMV;
				}
				return zjyDtSrEFfJPKZOBewXSAuqmdMqC;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class kZtffFAOHgncmDCJnkNoljXOoiXO : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int QCHtsYPTFMfFuPMcUhbxaUmnKbTJA;

			private ControllerPollingInfo tHlCvGlQziIPCqwTJtFMrvcmEMYu;

			private int kgDCxumsDVGysCRgSyBajSoxKJnAA;

			public Keyboard DgQBkbAAJEHVqHxXyKMRPiHmdTuQA;

			private int CcbvAyyDiEDaPIxhYYtAxrUGuYwh;

			private int HSFQcErDlkPKehSjcaAqiaDKfjlPA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return tHlCvGlQziIPCqwTJtFMrvcmEMYu;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return tHlCvGlQziIPCqwTJtFMrvcmEMYu;
				}
			}

			[DebuggerHidden]
			public kZtffFAOHgncmDCJnkNoljXOoiXO(int P_0)
			{
				QCHtsYPTFMfFuPMcUhbxaUmnKbTJA = P_0;
				kgDCxumsDVGysCRgSyBajSoxKJnAA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int qCHtsYPTFMfFuPMcUhbxaUmnKbTJA = QCHtsYPTFMfFuPMcUhbxaUmnKbTJA;
				Keyboard dgQBkbAAJEHVqHxXyKMRPiHmdTuQA = DgQBkbAAJEHVqHxXyKMRPiHmdTuQA;
				if (qCHtsYPTFMfFuPMcUhbxaUmnKbTJA != 0)
				{
					if (qCHtsYPTFMfFuPMcUhbxaUmnKbTJA != 1)
					{
						return false;
					}
					QCHtsYPTFMfFuPMcUhbxaUmnKbTJA = -1;
					goto IL_00bf;
				}
				QCHtsYPTFMfFuPMcUhbxaUmnKbTJA = -1;
				if (ReInput._id != dgQBkbAAJEHVqHxXyKMRPiHmdTuQA.FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(dgQBkbAAJEHVqHxXyKMRPiHmdTuQA.FtWUXMFFyhqCthzgjKfOhWsryipI);
					return false;
				}
				CcbvAyyDiEDaPIxhYYtAxrUGuYwh = Consts.keyboardKeyValues.Count;
				HSFQcErDlkPKehSjcaAqiaDKfjlPA = 0;
				goto IL_00cf;
				IL_00cf:
				if (HSFQcErDlkPKehSjcaAqiaDKfjlPA < CcbvAyyDiEDaPIxhYYtAxrUGuYwh)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[HSFQcErDlkPKehSjcaAqiaDKfjlPA];
					if (dgQBkbAAJEHVqHxXyKMRPiHmdTuQA.GetKeyDown(keyCode))
					{
						tHlCvGlQziIPCqwTJtFMrvcmEMYu = new ControllerPollingInfo(true, -1, dgQBkbAAJEHVqHxXyKMRPiHmdTuQA.id, dgQBkbAAJEHVqHxXyKMRPiHmdTuQA._name, dgQBkbAAJEHVqHxXyKMRPiHmdTuQA._type, ControllerElementType.Button, HSFQcErDlkPKehSjcaAqiaDKfjlPA, Pole.Positive, GetKeyName(keyCode), dgQBkbAAJEHVqHxXyKMRPiHmdTuQA.XRregwEugLWeubJCKxSQAwUDapNP.buttonElementIdentifierIds[HSFQcErDlkPKehSjcaAqiaDKfjlPA], keyCode);
						QCHtsYPTFMfFuPMcUhbxaUmnKbTJA = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				HSFQcErDlkPKehSjcaAqiaDKfjlPA++;
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
				kZtffFAOHgncmDCJnkNoljXOoiXO kZtffFAOHgncmDCJnkNoljXOoiXO2;
				if (QCHtsYPTFMfFuPMcUhbxaUmnKbTJA == -2 && kgDCxumsDVGysCRgSyBajSoxKJnAA == Environment.CurrentManagedThreadId)
				{
					QCHtsYPTFMfFuPMcUhbxaUmnKbTJA = 0;
					kZtffFAOHgncmDCJnkNoljXOoiXO2 = this;
				}
				else
				{
					kZtffFAOHgncmDCJnkNoljXOoiXO2 = new kZtffFAOHgncmDCJnkNoljXOoiXO(0);
					kZtffFAOHgncmDCJnkNoljXOoiXO2.DgQBkbAAJEHVqHxXyKMRPiHmdTuQA = DgQBkbAAJEHVqHxXyKMRPiHmdTuQA;
				}
				return kZtffFAOHgncmDCJnkNoljXOoiXO2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private static Keyboard LoadhNlAEFaFvHCKmSqpIdetZwFz;

		private readonly IUnifiedKeyboardSource EnRuGRWFpaNXElCOfbipHsZvpJZl;

		private ModifierKeyFlags OsRrfyielvPSHaccUGTPAUqfHgejA;

		private ModifierKeyFlags jLVpVOEHrBRZDWJbSGXFHKiyRQEj;

		private Func<KeyboardKeyCode, int> JltQhIeChELqIEAXBreKVrzDeobr;

		private readonly int[] YeDQdRkljRGekQeRduwjIdzadtycA;

		private static KeyboardKeyCode[] gaRHMLhxueOJDIMgzAlAhAJHYwYRA;

		private readonly int gLfWrhSKfpDkwWHCgUzJVScrcOTy;

		private static Guid JQOmzFInngmscZfWaYWuGVAhskBp;

		private static KeyboardKeyCode[] pPMbzYlYVjHnXssfdHrEXpqmhKJg
		{
			get
			{
				if (gaRHMLhxueOJDIMgzAlAhAJHYwYRA == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					gaRHMLhxueOJDIMgzAlAhAJHYwYRA = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						gaRHMLhxueOJDIMgzAlAhAJHYwYRA[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return gaRHMLhxueOJDIMgzAlAhAJHYwYRA;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return Guid.Empty;
				}
				return JQOmzFInngmscZfWaYWuGVAhskBp;
			}
		}

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
		{
			JQOmzFInngmscZfWaYWuGVAhskBp = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int i = 0; i < num; i++)
			{
				if (keyboardKeyValues[i] > gLfWrhSKfpDkwWHCgUzJVScrcOTy)
				{
					gLfWrhSKfpDkwWHCgUzJVScrcOTy = keyboardKeyValues[i];
				}
			}
			YeDQdRkljRGekQeRduwjIdzadtycA = new int[gLfWrhSKfpDkwWHCgUzJVScrcOTy + 1];
			ArrayTools.Fill(YeDQdRkljRGekQeRduwjIdzadtycA, -1);
			for (int j = 0; j < num; j++)
			{
				YeDQdRkljRGekQeRduwjIdzadtycA[keyboardKeyValues[j]] = j;
			}
			EnRuGRWFpaNXElCOfbipHsZvpJZl = P_1;
			rHrZhWmlidFfQIdUaELuLMacpKhFA();
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
		{
			LoadhNlAEFaFvHCKmSqpIdetZwFz = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return 0.0;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return 0.0;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if (!vLFDdrcuQlPWtgVAnOkRkQkOKKtwA(out var button, out var button2, key))
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if (!vLFDdrcuQlPWtgVAnOkRkQkOKKtwA(out var button, out var button2, key))
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if (!vLFDdrcuQlPWtgVAnOkRkQkOKKtwA(out var button, out var button2, key))
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if (!vLFDdrcuQlPWtgVAnOkRkQkOKKtwA(out var button, out var button2, key))
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			if (!vLFDdrcuQlPWtgVAnOkRkQkOKKtwA(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			if (!vLFDdrcuQlPWtgVAnOkRkQkOKKtwA(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return KeyCode.None;
			}
			return OfCNknHjvWuFWXcJUAjpYhJvOYIN(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return -1;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return -1;
			}
			return YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return null;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return XRregwEugLWeubJCKxSQAwUDapNP.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), XRregwEugLWeubJCKxSQAwUDapNP.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
		}

		[IteratorStateMachine(typeof(ZjyDtSrEFfJPKZOBewXSAuqmdMqC))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return new ZjyDtSrEFfJPKZOBewXSAuqmdMqC(-2)
			{
				ZmgYusKgRhMFmJDYOTTYsFEkdbMV = this
			};
		}

		[IteratorStateMachine(typeof(kZtffFAOHgncmDCJnkNoljXOoiXO))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return new kZtffFAOHgncmDCJnkNoljXOoiXO(-2)
			{
				DgQBkbAAJEHVqHxXyKMRPiHmdTuQA = this
			};
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), XRregwEugLWeubJCKxSQAwUDapNP.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
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

		internal static bool SkfNhnJOGYVGCgQtCFzBiaMxvERy(KeyboardKeyCode P_0)
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
			if (LoadhNlAEFaFvHCKmSqpIdetZwFz == null)
			{
				return string.Empty;
			}
			int buttonIndex = LoadhNlAEFaFvHCKmSqpIdetZwFz.GetButtonIndex(GQPyDmRjsYNCPFQsslsUvqcurVKM(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return LoadhNlAEFaFvHCKmSqpIdetZwFz.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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

		internal static KeyboardKeyCode GQPyDmRjsYNCPFQsslsUvqcurVKM(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode OfCNknHjvWuFWXcJUAjpYhJvOYIN(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags VGcYyBOHCbhFjbBQbXjzLjeUDSEdA(ModifierKeyFlags P_0)
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

		internal static int hZJmtIKQvYcSDwdkaSaHsdlKdnUc(ModifierKeyFlags P_0)
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
			return pPMbzYlYVjHnXssfdHrEXpqmhKJg[buttonIndex];
		}

		internal static int HfoWUohxjLpEXszmGVPxhJmNRcfp(KeyboardKeyCode P_0)
		{
			int buttonIndex = LoadhNlAEFaFvHCKmSqpIdetZwFz.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return LoadhNlAEFaFvHCKmSqpIdetZwFz.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
		}

		internal static void EygbfUBdfHOlPWAecJsoicbWKRQT(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = HfoWUohxjLpEXszmGVPxhJmNRcfp(GQPyDmRjsYNCPFQsslsUvqcurVKM(P_1));
			}
			else
			{
				P_1 = ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.IHPfnLMrgyTtYeIwxJsMlnCYMDst.GetKeyCodeById(P_0);
			}
		}

		internal void mACzghIQxSrcrAvHOPeEGFcSBSUS(UpdateLoopType P_0)
		{
			EnRuGRWFpaNXElCOfbipHsZvpJZl.UpdateInputData(jaSaHPudVtcyecnoPKkgZIAqgGJr);
			base.WpPadHsJSmWHmPNyDjEbriEWORwq(P_0);
			cImdyVqGsUOwlJklXQtxcFPtnoZK();
		}

		internal void TcIfnUdqgUkRCynaQhayszccQyNGA(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, jaSaHPudVtcyecnoPKkgZIAqgGJr);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, jaSaHPudVtcyecnoPKkgZIAqgGJr);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, jaSaHPudVtcyecnoPKkgZIAqgGJr);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, jaSaHPudVtcyecnoPKkgZIAqgGJr);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, jaSaHPudVtcyecnoPKkgZIAqgGJr);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, jaSaHPudVtcyecnoPKkgZIAqgGJr);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, jaSaHPudVtcyecnoPKkgZIAqgGJr);
		}

		internal bool orxplOtEWPddMakCbleQKnOLNaTJ(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool LdUZucKTGmHwLxBfGeEjKLTyJmtY(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return false;
			}
			int num = YeDQdRkljRGekQeRduwjIdzadtycA[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool yVcNqBAEUxlpRZSbUhvGHtzNLxSO(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!orxplOtEWPddMakCbleQKnOLNaTJ(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & jLVpVOEHrBRZDWJbSGXFHKiyRQEj) != P_1)
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

		internal bool KKyfdqFksTnwwrSLdZRmNNziGBRcA(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (orxplOtEWPddMakCbleQKnOLNaTJ(P_0))
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
			if ((uint)keyCode > (uint)gLfWrhSKfpDkwWHCgUzJVScrcOTy)
			{
				return -1;
			}
			return YeDQdRkljRGekQeRduwjIdzadtycA[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> list = controllerMap.OEydHsjiiTRjhFtrBfeqPfyluIMc;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					YTencsjPWuJIOCxnxAitAELcIHlkA(controllerMap, list[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.PZvEkWRBkXBIEonMjbHYqghRdEUeA(controllerMap);
		}

		internal void VVeRbKeFXkjaAvvlCjmGuAcGjiZeA()
		{
			base.oiLcdkgzyxvAnauVHzgHdoryrXqiA();
			OsRrfyielvPSHaccUGTPAUqfHgejA = ModifierKeyFlags.None;
			jLVpVOEHrBRZDWJbSGXFHKiyRQEj = ModifierKeyFlags.None;
		}

		internal bool OBuQmGdKvrGdJSXMoDkzdwolcBie(bool P_0)
		{
			if (!base.LAwnernCBTrnUblykcVvSoWLkSFf(P_0))
			{
				return false;
			}
			if (EnRuGRWFpaNXElCOfbipHsZvpJZl is IGetSetEnabled)
			{
				(EnRuGRWFpaNXElCOfbipHsZvpJZl as IGetSetEnabled).enabled = P_0;
			}
			return true;
		}

		private bool vLFDdrcuQlPWtgVAnOkRkQkOKKtwA(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[YeDQdRkljRGekQeRduwjIdzadtycA[306]];
				P_1 = buttons[YeDQdRkljRGekQeRduwjIdzadtycA[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[YeDQdRkljRGekQeRduwjIdzadtycA[308]];
				P_1 = buttons[YeDQdRkljRGekQeRduwjIdzadtycA[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[YeDQdRkljRGekQeRduwjIdzadtycA[310]];
				P_1 = buttons[YeDQdRkljRGekQeRduwjIdzadtycA[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[YeDQdRkljRGekQeRduwjIdzadtycA[304]];
				P_1 = buttons[YeDQdRkljRGekQeRduwjIdzadtycA[303]];
				return true;
			default:
				return false;
			}
		}

		private void cImdyVqGsUOwlJklXQtxcFPtnoZK()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[YeDQdRkljRGekQeRduwjIdzadtycA[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[YeDQdRkljRGekQeRduwjIdzadtycA[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[YeDQdRkljRGekQeRduwjIdzadtycA[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[YeDQdRkljRGekQeRduwjIdzadtycA[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[YeDQdRkljRGekQeRduwjIdzadtycA[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[YeDQdRkljRGekQeRduwjIdzadtycA[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[YeDQdRkljRGekQeRduwjIdzadtycA[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[YeDQdRkljRGekQeRduwjIdzadtycA[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			OsRrfyielvPSHaccUGTPAUqfHgejA = modifierKeyFlags;
			jLVpVOEHrBRZDWJbSGXFHKiyRQEj = VGcYyBOHCbhFjbBQbXjzLjeUDSEdA(modifierKeyFlags);
		}
	}
}
