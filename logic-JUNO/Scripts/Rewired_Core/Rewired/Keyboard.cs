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
		private sealed class PgfGhCuXVTufHJBBEALDiVYrQDOn : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int cBfKFWOTkhbIApavuiHWvPfysFJN;

			private ControllerPollingInfo ESlTzrFDDTYHbryfFIbFVDolUWDT;

			private int cUrcTaxtgkKoHAOHviZUilSqEDYG;

			public Keyboard HthbLcNPSDHdxNoTuhgLEXirTZol;

			private int GfvqzCNQylcCssneigWpDuGNXcWb;

			private int SnSGUsqwVbWJMmwXbzQMzHmoBbyg;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ESlTzrFDDTYHbryfFIbFVDolUWDT;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ESlTzrFDDTYHbryfFIbFVDolUWDT;
				}
			}

			[DebuggerHidden]
			public PgfGhCuXVTufHJBBEALDiVYrQDOn(int P_0)
			{
				cBfKFWOTkhbIApavuiHWvPfysFJN = P_0;
				cUrcTaxtgkKoHAOHviZUilSqEDYG = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = cBfKFWOTkhbIApavuiHWvPfysFJN;
				Keyboard hthbLcNPSDHdxNoTuhgLEXirTZol = HthbLcNPSDHdxNoTuhgLEXirTZol;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					cBfKFWOTkhbIApavuiHWvPfysFJN = -1;
					goto IL_00bf;
				}
				cBfKFWOTkhbIApavuiHWvPfysFJN = -1;
				if (ReInput._id != hthbLcNPSDHdxNoTuhgLEXirTZol.RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(hthbLcNPSDHdxNoTuhgLEXirTZol.RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return false;
				}
				GfvqzCNQylcCssneigWpDuGNXcWb = Consts.keyboardKeyValues.Count;
				SnSGUsqwVbWJMmwXbzQMzHmoBbyg = 0;
				goto IL_00cf;
				IL_00cf:
				if (SnSGUsqwVbWJMmwXbzQMzHmoBbyg < GfvqzCNQylcCssneigWpDuGNXcWb)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[SnSGUsqwVbWJMmwXbzQMzHmoBbyg];
					if (hthbLcNPSDHdxNoTuhgLEXirTZol.GetKey(keyCode))
					{
						ESlTzrFDDTYHbryfFIbFVDolUWDT = new ControllerPollingInfo(true, -1, hthbLcNPSDHdxNoTuhgLEXirTZol.id, hthbLcNPSDHdxNoTuhgLEXirTZol._name, hthbLcNPSDHdxNoTuhgLEXirTZol._type, ControllerElementType.Button, SnSGUsqwVbWJMmwXbzQMzHmoBbyg, Pole.Positive, GetKeyName(keyCode), hthbLcNPSDHdxNoTuhgLEXirTZol.NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.buttonElementIdentifierIds[SnSGUsqwVbWJMmwXbzQMzHmoBbyg], keyCode);
						cBfKFWOTkhbIApavuiHWvPfysFJN = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				SnSGUsqwVbWJMmwXbzQMzHmoBbyg++;
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
				PgfGhCuXVTufHJBBEALDiVYrQDOn pgfGhCuXVTufHJBBEALDiVYrQDOn;
				if (cBfKFWOTkhbIApavuiHWvPfysFJN == -2 && cUrcTaxtgkKoHAOHviZUilSqEDYG == Environment.CurrentManagedThreadId)
				{
					cBfKFWOTkhbIApavuiHWvPfysFJN = 0;
					pgfGhCuXVTufHJBBEALDiVYrQDOn = this;
				}
				else
				{
					pgfGhCuXVTufHJBBEALDiVYrQDOn = new PgfGhCuXVTufHJBBEALDiVYrQDOn(0);
					pgfGhCuXVTufHJBBEALDiVYrQDOn.HthbLcNPSDHdxNoTuhgLEXirTZol = HthbLcNPSDHdxNoTuhgLEXirTZol;
				}
				return pgfGhCuXVTufHJBBEALDiVYrQDOn;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class yCuwZoHCkUYloPGNBuzLBlTNCjub : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int CZIgxAQxWyBctBBbuLOcIkImOBjeb;

			private ControllerPollingInfo fBkwoOoFyCaaPmHChedFBNOruicH;

			private int sZCnsetYKlHPdJJzieozqXQgGlBHA;

			public Keyboard LZHnGpLiSiaklzBOSFdUQVzdLbKp;

			private int YysuLevIdibsEUKqadxHJeuNlAUR;

			private int XpUgnWdgeEYbfqdoKBltaShjRDLTB;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return fBkwoOoFyCaaPmHChedFBNOruicH;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return fBkwoOoFyCaaPmHChedFBNOruicH;
				}
			}

			[DebuggerHidden]
			public yCuwZoHCkUYloPGNBuzLBlTNCjub(int P_0)
			{
				CZIgxAQxWyBctBBbuLOcIkImOBjeb = P_0;
				sZCnsetYKlHPdJJzieozqXQgGlBHA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int cZIgxAQxWyBctBBbuLOcIkImOBjeb = CZIgxAQxWyBctBBbuLOcIkImOBjeb;
				Keyboard lZHnGpLiSiaklzBOSFdUQVzdLbKp = LZHnGpLiSiaklzBOSFdUQVzdLbKp;
				if (cZIgxAQxWyBctBBbuLOcIkImOBjeb != 0)
				{
					if (cZIgxAQxWyBctBBbuLOcIkImOBjeb != 1)
					{
						return false;
					}
					CZIgxAQxWyBctBBbuLOcIkImOBjeb = -1;
					goto IL_00bf;
				}
				CZIgxAQxWyBctBBbuLOcIkImOBjeb = -1;
				if (ReInput._id != lZHnGpLiSiaklzBOSFdUQVzdLbKp.RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(lZHnGpLiSiaklzBOSFdUQVzdLbKp.RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return false;
				}
				YysuLevIdibsEUKqadxHJeuNlAUR = Consts.keyboardKeyValues.Count;
				XpUgnWdgeEYbfqdoKBltaShjRDLTB = 0;
				goto IL_00cf;
				IL_00cf:
				if (XpUgnWdgeEYbfqdoKBltaShjRDLTB < YysuLevIdibsEUKqadxHJeuNlAUR)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[XpUgnWdgeEYbfqdoKBltaShjRDLTB];
					if (lZHnGpLiSiaklzBOSFdUQVzdLbKp.GetKeyDown(keyCode))
					{
						fBkwoOoFyCaaPmHChedFBNOruicH = new ControllerPollingInfo(true, -1, lZHnGpLiSiaklzBOSFdUQVzdLbKp.id, lZHnGpLiSiaklzBOSFdUQVzdLbKp._name, lZHnGpLiSiaklzBOSFdUQVzdLbKp._type, ControllerElementType.Button, XpUgnWdgeEYbfqdoKBltaShjRDLTB, Pole.Positive, GetKeyName(keyCode), lZHnGpLiSiaklzBOSFdUQVzdLbKp.NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.buttonElementIdentifierIds[XpUgnWdgeEYbfqdoKBltaShjRDLTB], keyCode);
						CZIgxAQxWyBctBBbuLOcIkImOBjeb = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				XpUgnWdgeEYbfqdoKBltaShjRDLTB++;
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
				yCuwZoHCkUYloPGNBuzLBlTNCjub yCuwZoHCkUYloPGNBuzLBlTNCjub2;
				if (CZIgxAQxWyBctBBbuLOcIkImOBjeb == -2 && sZCnsetYKlHPdJJzieozqXQgGlBHA == Environment.CurrentManagedThreadId)
				{
					CZIgxAQxWyBctBBbuLOcIkImOBjeb = 0;
					yCuwZoHCkUYloPGNBuzLBlTNCjub2 = this;
				}
				else
				{
					yCuwZoHCkUYloPGNBuzLBlTNCjub2 = new yCuwZoHCkUYloPGNBuzLBlTNCjub(0);
					yCuwZoHCkUYloPGNBuzLBlTNCjub2.LZHnGpLiSiaklzBOSFdUQVzdLbKp = LZHnGpLiSiaklzBOSFdUQVzdLbKp;
				}
				return yCuwZoHCkUYloPGNBuzLBlTNCjub2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private static Keyboard VrvwlJkIHvoYmQDwSNZuHGTcKwdD;

		private readonly IUnifiedKeyboardSource IQEptNZggUgJXbXZZNigbxRmPTlE;

		private ModifierKeyFlags KOIFqoapuFklGaulBaoCegKxeUIiB;

		private ModifierKeyFlags tOVqSEZejmwKCjosGfUBrCfqpwAA;

		private Func<KeyboardKeyCode, int> BRggsKAvyqhRPHWApmLTVrDSkKLIb;

		private readonly int[] GlWgsPcderdBlvASZkVoowJxZRKV;

		private static KeyboardKeyCode[] ugYvZBmVrKNgSOKxHQGVketIsYsl;

		private readonly int kpkGkpDYaLeNhUURWbUQbxKiumtq;

		private static Guid XWTAoTkXiYiNdNFPKRvdboacbGxHb;

		private static KeyboardKeyCode[] ljBuuAkGsPegUkqWTcAThIClNllL
		{
			get
			{
				if (ugYvZBmVrKNgSOKxHQGVketIsYsl == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					ugYvZBmVrKNgSOKxHQGVketIsYsl = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						ugYvZBmVrKNgSOKxHQGVketIsYsl[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return ugYvZBmVrKNgSOKxHQGVketIsYsl;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return Guid.Empty;
				}
				return XWTAoTkXiYiNdNFPKRvdboacbGxHb;
			}
		}

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
		{
			XWTAoTkXiYiNdNFPKRvdboacbGxHb = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int i = 0; i < num; i++)
			{
				if (keyboardKeyValues[i] > kpkGkpDYaLeNhUURWbUQbxKiumtq)
				{
					kpkGkpDYaLeNhUURWbUQbxKiumtq = keyboardKeyValues[i];
				}
			}
			GlWgsPcderdBlvASZkVoowJxZRKV = new int[kpkGkpDYaLeNhUURWbUQbxKiumtq + 1];
			ArrayTools.Fill(GlWgsPcderdBlvASZkVoowJxZRKV, -1);
			for (int j = 0; j < num; j++)
			{
				GlWgsPcderdBlvASZkVoowJxZRKV[keyboardKeyValues[j]] = j;
			}
			IQEptNZggUgJXbXZZNigbxRmPTlE = P_1;
			blqnoKjqhVSIFnqRKLejmqEtdoFaA();
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
		{
			VrvwlJkIHvoYmQDwSNZuHGTcKwdD = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return 0.0;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return 0.0;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if (!fpQosnnSTJFlgFeNPRHWkMURemZQ(out var button, out var button2, key))
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if (!fpQosnnSTJFlgFeNPRHWkMURemZQ(out var button, out var button2, key))
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if (!fpQosnnSTJFlgFeNPRHWkMURemZQ(out var button, out var button2, key))
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if (!fpQosnnSTJFlgFeNPRHWkMURemZQ(out var button, out var button2, key))
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			if (!fpQosnnSTJFlgFeNPRHWkMURemZQ(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			if (!fpQosnnSTJFlgFeNPRHWkMURemZQ(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return KeyCode.None;
			}
			return KBTdOfYSoejBVTWIajKwoodwuukt(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return -1;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return -1;
			}
			return GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return null;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
		}

		[IteratorStateMachine(typeof(PgfGhCuXVTufHJBBEALDiVYrQDOn))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return new PgfGhCuXVTufHJBBEALDiVYrQDOn(-2)
			{
				HthbLcNPSDHdxNoTuhgLEXirTZol = this
			};
		}

		[IteratorStateMachine(typeof(yCuwZoHCkUYloPGNBuzLBlTNCjub))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return new yCuwZoHCkUYloPGNBuzLBlTNCjub(-2)
			{
				LZHnGpLiSiaklzBOSFdUQVzdLbKp = this
			};
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
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

		internal static bool GQqeejAYZmrpBEukiKQMsAughgffA(KeyboardKeyCode P_0)
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
			if (VrvwlJkIHvoYmQDwSNZuHGTcKwdD == null)
			{
				return string.Empty;
			}
			int buttonIndex = VrvwlJkIHvoYmQDwSNZuHGTcKwdD.GetButtonIndex(SkWJKaKQzacnGBhlAhZVBZAnpnsQA(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return VrvwlJkIHvoYmQDwSNZuHGTcKwdD.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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

		internal static KeyboardKeyCode SkWJKaKQzacnGBhlAhZVBZAnpnsQA(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode KBTdOfYSoejBVTWIajKwoodwuukt(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags DAjJzVTCXTqyafqPXHKyzrGVFqev(ModifierKeyFlags P_0)
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

		internal static int hwUtGMJILscNAaSoWujSKdRPoRBT(ModifierKeyFlags P_0)
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
			return ljBuuAkGsPegUkqWTcAThIClNllL[buttonIndex];
		}

		internal static int PYvDBmmVmdPzOqnzaqMoZHAQEYJs(KeyboardKeyCode P_0)
		{
			int buttonIndex = VrvwlJkIHvoYmQDwSNZuHGTcKwdD.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return VrvwlJkIHvoYmQDwSNZuHGTcKwdD.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
		}

		internal static void MErBeKKWydGjCGddAMBfOvLVvvaP(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = PYvDBmmVmdPzOqnzaqMoZHAQEYJs(SkWJKaKQzacnGBhlAhZVBZAnpnsQA(P_1));
			}
			else
			{
				P_1 = ReInput.WUBqcfcHLvbkdiiUnEhQlzYVACJm.WNWSmXDJjWGCNaqhXgXPNVyPdtGgb.GetKeyCodeById(P_0);
			}
		}

		internal void yxRbalHfwoPCaUWQkbyTwwOTysiJ(UpdateLoopType P_0)
		{
			IQEptNZggUgJXbXZZNigbxRmPTlE.UpdateInputData(rGVdhXruOTgLzoPtrwxfhKmroixX);
			base.EjKubThADKiQfHetvzpyLeiJitWy(P_0);
			ypiTNhtqihMcLitbjarCtxcRvZB();
		}

		internal void BwTpcClexmNgVnZhgmPtFdErrEtr(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, rGVdhXruOTgLzoPtrwxfhKmroixX);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, rGVdhXruOTgLzoPtrwxfhKmroixX);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, rGVdhXruOTgLzoPtrwxfhKmroixX);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, rGVdhXruOTgLzoPtrwxfhKmroixX);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, rGVdhXruOTgLzoPtrwxfhKmroixX);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, rGVdhXruOTgLzoPtrwxfhKmroixX);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, rGVdhXruOTgLzoPtrwxfhKmroixX);
		}

		internal bool kNqCeKujRhBOLgaHFpQHDqmKvnlHb(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool DWHKhqZcJCUNOdxaoDnehordhKFs(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return false;
			}
			int num = GlWgsPcderdBlvASZkVoowJxZRKV[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool cCrGvDbJVDKMAGBaeXUHojDCcNqfb(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!kNqCeKujRhBOLgaHFpQHDqmKvnlHb(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & tOVqSEZejmwKCjosGfUBrCfqpwAA) != P_1)
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

		internal bool WebRmupPvfdFfndUZEappQJjYzft(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (kNqCeKujRhBOLgaHFpQHDqmKvnlHb(P_0))
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
			if ((uint)keyCode > (uint)kpkGkpDYaLeNhUURWbUQbxKiumtq)
			{
				return -1;
			}
			return GlWgsPcderdBlvASZkVoowJxZRKV[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> list = controllerMap.WlfiRVollhePcNcyfbYblQBgHIiM;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					KQvZlmyPDCAbJMosZEJiaypfudNPA(controllerMap, list[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.TdyJaYSxTvfwLaVFZuETMDHOmkgH(controllerMap);
		}

		internal void JclHkQcxUCTVDDdymuDLNQAPxMxY()
		{
			base.gBKPqeqzjNmvysiIfrLGGzRfmdWS();
			KOIFqoapuFklGaulBaoCegKxeUIiB = ModifierKeyFlags.None;
			tOVqSEZejmwKCjosGfUBrCfqpwAA = ModifierKeyFlags.None;
		}

		internal bool WibDQKsAJBgjEWFOIqqaFcUgISCT(bool P_0)
		{
			if (!base.BXxyidqXWhYGVbTpYPscakwYIxji(P_0))
			{
				return false;
			}
			if (IQEptNZggUgJXbXZZNigbxRmPTlE is IGetSetEnabled)
			{
				(IQEptNZggUgJXbXZZNigbxRmPTlE as IGetSetEnabled).enabled = P_0;
			}
			return true;
		}

		private bool fpQosnnSTJFlgFeNPRHWkMURemZQ(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[GlWgsPcderdBlvASZkVoowJxZRKV[306]];
				P_1 = buttons[GlWgsPcderdBlvASZkVoowJxZRKV[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[GlWgsPcderdBlvASZkVoowJxZRKV[308]];
				P_1 = buttons[GlWgsPcderdBlvASZkVoowJxZRKV[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[GlWgsPcderdBlvASZkVoowJxZRKV[310]];
				P_1 = buttons[GlWgsPcderdBlvASZkVoowJxZRKV[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[GlWgsPcderdBlvASZkVoowJxZRKV[304]];
				P_1 = buttons[GlWgsPcderdBlvASZkVoowJxZRKV[303]];
				return true;
			default:
				return false;
			}
		}

		private void ypiTNhtqihMcLitbjarCtxcRvZB()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[GlWgsPcderdBlvASZkVoowJxZRKV[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[GlWgsPcderdBlvASZkVoowJxZRKV[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[GlWgsPcderdBlvASZkVoowJxZRKV[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[GlWgsPcderdBlvASZkVoowJxZRKV[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[GlWgsPcderdBlvASZkVoowJxZRKV[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[GlWgsPcderdBlvASZkVoowJxZRKV[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[GlWgsPcderdBlvASZkVoowJxZRKV[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[GlWgsPcderdBlvASZkVoowJxZRKV[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			KOIFqoapuFklGaulBaoCegKxeUIiB = modifierKeyFlags;
			tOVqSEZejmwKCjosGfUBrCfqpwAA = DAjJzVTCXTqyafqPXHKyzrGVFqev(modifierKeyFlags);
		}
	}
}
