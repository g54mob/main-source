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
		private sealed class tDRFwMjiItbaWNzETnSxRwrUJTC : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public Keyboard GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int YgmehtADDvbivqVnswAptXeSdHLD;

			public int oBOFhxdKvEEGhfOjCxobcSPpBKcK;

			public KeyCode BEHDqyKFleaCqaRdvImkvmXbaCq;

			public bool IPmCvoXVJeDFaCdCxLiccQiDFmU;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				tDRFwMjiItbaWNzETnSxRwrUJTC tDRFwMjiItbaWNzETnSxRwrUJTC2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					tDRFwMjiItbaWNzETnSxRwrUJTC2 = this;
				}
				else
				{
					tDRFwMjiItbaWNzETnSxRwrUJTC2 = new tDRFwMjiItbaWNzETnSxRwrUJTC(0);
					tDRFwMjiItbaWNzETnSxRwrUJTC2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return tDRFwMjiItbaWNzETnSxRwrUJTC2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
						break;
					}
					YgmehtADDvbivqVnswAptXeSdHLD = Consts.keyboardKeyValues.Count;
					oBOFhxdKvEEGhfOjCxobcSPpBKcK = 0;
					goto IL_0116;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_0108;
					}
					IL_0116:
					if (oBOFhxdKvEEGhfOjCxobcSPpBKcK >= YgmehtADDvbivqVnswAptXeSdHLD)
					{
						break;
					}
					BEHDqyKFleaCqaRdvImkvmXbaCq = (KeyCode)Consts.keyboardKeyValues[oBOFhxdKvEEGhfOjCxobcSPpBKcK];
					IPmCvoXVJeDFaCdCxLiccQiDFmU = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetKey(BEHDqyKFleaCqaRdvImkvmXbaCq);
					if (IPmCvoXVJeDFaCdCxLiccQiDFmU)
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = new ControllerPollingInfo(success: true, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE.id, GxphHAMqMhNBLjnlhXuBQmXaALiE._name, GxphHAMqMhNBLjnlhXuBQmXaALiE._type, ControllerElementType.Button, oBOFhxdKvEEGhfOjCxobcSPpBKcK, Pole.Positive, GetKeyName(BEHDqyKFleaCqaRdvImkvmXbaCq), GxphHAMqMhNBLjnlhXuBQmXaALiE.rEqQznEUmYwtoLNJsErzjlKjjYY.buttonElementIdentifierIds[oBOFhxdKvEEGhfOjCxobcSPpBKcK], BEHDqyKFleaCqaRdvImkvmXbaCq);
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_0108;
					IL_0108:
					oBOFhxdKvEEGhfOjCxobcSPpBKcK++;
					goto IL_0116;
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
			public tDRFwMjiItbaWNzETnSxRwrUJTC(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class mBLKjFyrlLaRWKMlypnyjuAcgnh : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public Keyboard GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int wBgEIDJiBrlhVbAcvGJmqgrFlNyE;

			public int aOIfInsKRtdajIhjJoRyIUaPDsH;

			public KeyCode UQxOOSElxHPpGFcbhvWjDvUfCPZ;

			public bool frQUZAlXZLLLVobAJrEEQjrEBEj;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				mBLKjFyrlLaRWKMlypnyjuAcgnh mBLKjFyrlLaRWKMlypnyjuAcgnh2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					mBLKjFyrlLaRWKMlypnyjuAcgnh2 = this;
				}
				else
				{
					mBLKjFyrlLaRWKMlypnyjuAcgnh2 = new mBLKjFyrlLaRWKMlypnyjuAcgnh(0);
					mBLKjFyrlLaRWKMlypnyjuAcgnh2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return mBLKjFyrlLaRWKMlypnyjuAcgnh2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
						break;
					}
					wBgEIDJiBrlhVbAcvGJmqgrFlNyE = Consts.keyboardKeyValues.Count;
					aOIfInsKRtdajIhjJoRyIUaPDsH = 0;
					goto IL_0116;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_0108;
					}
					IL_0116:
					if (aOIfInsKRtdajIhjJoRyIUaPDsH >= wBgEIDJiBrlhVbAcvGJmqgrFlNyE)
					{
						break;
					}
					UQxOOSElxHPpGFcbhvWjDvUfCPZ = (KeyCode)Consts.keyboardKeyValues[aOIfInsKRtdajIhjJoRyIUaPDsH];
					frQUZAlXZLLLVobAJrEEQjrEBEj = GxphHAMqMhNBLjnlhXuBQmXaALiE.GetKeyDown(UQxOOSElxHPpGFcbhvWjDvUfCPZ);
					if (frQUZAlXZLLLVobAJrEEQjrEBEj)
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = new ControllerPollingInfo(success: true, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE.id, GxphHAMqMhNBLjnlhXuBQmXaALiE._name, GxphHAMqMhNBLjnlhXuBQmXaALiE._type, ControllerElementType.Button, aOIfInsKRtdajIhjJoRyIUaPDsH, Pole.Positive, GetKeyName(UQxOOSElxHPpGFcbhvWjDvUfCPZ), GxphHAMqMhNBLjnlhXuBQmXaALiE.rEqQznEUmYwtoLNJsErzjlKjjYY.buttonElementIdentifierIds[aOIfInsKRtdajIhjJoRyIUaPDsH], UQxOOSElxHPpGFcbhvWjDvUfCPZ);
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_0108;
					IL_0108:
					aOIfInsKRtdajIhjJoRyIUaPDsH++;
					goto IL_0116;
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
			public mBLKjFyrlLaRWKMlypnyjuAcgnh(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private static Keyboard SmacmFrjqcSZueakikcbqMOYGpkG;

		private readonly IUnifiedKeyboardSource fzzXbvFoZzdAqHDolrszRhFTkOz;

		private ModifierKeyFlags cGWcxMeRpTFnHjBueQYYnybOYBl;

		private ModifierKeyFlags GGzOGzHtpxbNHybZmOHhzOgHAgG;

		private Func<KeyboardKeyCode, int> vhyOFdsOkzFkBvmWaieNjLAXtzu;

		private readonly int[] dtxMxRdhsXLfunxytSkHyaamzSw;

		private static KeyboardKeyCode[] eyluWFpIExHrGJEcUqxUXOtdnrt;

		private readonly int rdWmoGEkvOvoCewjGCXfZasrOuI;

		private static Guid aDUsEiUYonPfaVuLAuUCTJVjSYF;

		private static KeyboardKeyCode[] keyIndexToKeyboardKeyCode
		{
			get
			{
				if (eyluWFpIExHrGJEcUqxUXOtdnrt == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					eyluWFpIExHrGJEcUqxUXOtdnrt = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						eyluWFpIExHrGJEcUqxUXOtdnrt[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return eyluWFpIExHrGJEcUqxUXOtdnrt;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Guid.Empty;
				}
				return aDUsEiUYonPfaVuLAuUCTJVjSYF;
			}
		}

		internal Keyboard(string name, IUnifiedKeyboardSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.hardwareMap, 132, source?.controllerExtension, new ControllerDataUpdater(source.inputSource, 0, 132, null))
		{
			aDUsEiUYonPfaVuLAuUCTJVjSYF = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int i = 0; i < num; i++)
			{
				if (keyboardKeyValues[i] > rdWmoGEkvOvoCewjGCXfZasrOuI)
				{
					rdWmoGEkvOvoCewjGCXfZasrOuI = keyboardKeyValues[i];
				}
			}
			dtxMxRdhsXLfunxytSkHyaamzSw = new int[rdWmoGEkvOvoCewjGCXfZasrOuI + 1];
			ArrayTools.Fill(dtxMxRdhsXLfunxytSkHyaamzSw, -1);
			for (int j = 0; j < num; j++)
			{
				dtxMxRdhsXLfunxytSkHyaamzSw[keyboardKeyValues[j]] = j;
			}
			fzzXbvFoZzdAqHDolrszRhFTkOz = source;
			ANKdbHXpmTNShTcixGbSxMIpqJK();
		}

		private Keyboard(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, HardwareControllerMap_Game hardwareMap, int buttonCount, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
			SmacmFrjqcSZueakikcbqMOYGpkG = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return 0.0;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return 0.0;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (!XmRHUGQmTcdKJwmvjcCfpZCNVwx(out var button, out var button2, key))
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (!XmRHUGQmTcdKJwmvjcCfpZCNVwx(out var button, out var button2, key))
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (!XmRHUGQmTcdKJwmvjcCfpZCNVwx(out var button, out var button2, key))
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (!XmRHUGQmTcdKJwmvjcCfpZCNVwx(out var button, out var button2, key))
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if (!XmRHUGQmTcdKJwmvjcCfpZCNVwx(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if (!XmRHUGQmTcdKJwmvjcCfpZCNVwx(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return KeyCode.None;
			}
			return IhmChxYtdttpyTboioqMaXomHIW(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return -1;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return -1;
			}
			return dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return null;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return rEqQznEUmYwtoLNJsErzjlKjjYY.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), rEqQznEUmYwtoLNJsErzjlKjjYY.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			tDRFwMjiItbaWNzETnSxRwrUJTC tDRFwMjiItbaWNzETnSxRwrUJTC2 = new tDRFwMjiItbaWNzETnSxRwrUJTC(-2);
			tDRFwMjiItbaWNzETnSxRwrUJTC2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			return tDRFwMjiItbaWNzETnSxRwrUJTC2;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			mBLKjFyrlLaRWKMlypnyjuAcgnh mBLKjFyrlLaRWKMlypnyjuAcgnh2 = new mBLKjFyrlLaRWKMlypnyjuAcgnh(-2);
			mBLKjFyrlLaRWKMlypnyjuAcgnh2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			return mBLKjFyrlLaRWKMlypnyjuAcgnh2;
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), rEqQznEUmYwtoLNJsErzjlKjjYY.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
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

		internal static bool syYuQKZtfCqCEpvzRDtOqpqJaUlg(KeyboardKeyCode P_0)
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
				KeyCode.LeftCommand => ModifierKeyFlags.LeftCommand, 
				KeyCode.RightCommand => ModifierKeyFlags.RightCommand, 
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
			if (SmacmFrjqcSZueakikcbqMOYGpkG == null)
			{
				return string.Empty;
			}
			int buttonIndex = SmacmFrjqcSZueakikcbqMOYGpkG.GetButtonIndex(eTNgJxbiatprFUOeyypTPrSKrwwN(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return SmacmFrjqcSZueakikcbqMOYGpkG.ButtonElementIdentifiers[buttonIndex].name;
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

		internal static KeyboardKeyCode eTNgJxbiatprFUOeyypTPrSKrwwN(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode IhmChxYtdttpyTboioqMaXomHIW(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags pdWwsAjklZfWFhcbWEXNcFLahil(ModifierKeyFlags P_0)
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

		internal static int WAEsFkGMlHvkpOfQuzuewsriBKBd(ModifierKeyFlags P_0)
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
			return keyIndexToKeyboardKeyCode[buttonIndex];
		}

		internal static int rCtikjLooiIEdUQxxlwmHbJJqAx(KeyboardKeyCode P_0)
		{
			int buttonIndex = SmacmFrjqcSZueakikcbqMOYGpkG.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return SmacmFrjqcSZueakikcbqMOYGpkG.ButtonElementIdentifiers[buttonIndex].id;
		}

		internal static void VpPkczmTNQbDyXwjTOeJteHwqti(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = rCtikjLooiIEdUQxxlwmHbJJqAx(eTNgJxbiatprFUOeyypTPrSKrwwN(P_1));
			}
			else
			{
				P_1 = ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.Keyboard.GetKeyCodeById(P_0);
			}
		}

		internal override void KcNfORqUkjxfSzjWExwXXCRKlZu(UpdateLoopType P_0)
		{
			fzzXbvFoZzdAqHDolrszRhFTkOz.UpdateInputData(QlXkhNBHPYUNWwhKurdwrqFgWTf);
			base.KcNfORqUkjxfSzjWExwXXCRKlZu(P_0);
			AXnkZhmOKHVMmlFYiKXtPWIbMLM();
		}

		internal void WxdpFdTfMOdtOWHKOpbraLqOYhP(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].aYsFvoceHxJCyLcdXQiYPSoYSvl(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, QlXkhNBHPYUNWwhKurdwrqFgWTf);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].aYsFvoceHxJCyLcdXQiYPSoYSvl(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, QlXkhNBHPYUNWwhKurdwrqFgWTf);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].aYsFvoceHxJCyLcdXQiYPSoYSvl(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, QlXkhNBHPYUNWwhKurdwrqFgWTf);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].aYsFvoceHxJCyLcdXQiYPSoYSvl(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, QlXkhNBHPYUNWwhKurdwrqFgWTf);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].aYsFvoceHxJCyLcdXQiYPSoYSvl(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, QlXkhNBHPYUNWwhKurdwrqFgWTf);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].aYsFvoceHxJCyLcdXQiYPSoYSvl(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, QlXkhNBHPYUNWwhKurdwrqFgWTf);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].aYsFvoceHxJCyLcdXQiYPSoYSvl(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, QlXkhNBHPYUNWwhKurdwrqFgWTf);
		}

		internal bool KXaPbukfFUJAJqHNnclnvNPyViv(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool bBhTabSRUbMgYvmjGcfcTAOrHoG(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return false;
			}
			int num = dtxMxRdhsXLfunxytSkHyaamzSw[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool mnTzQwiMlCKWrqCIVIoUFKFNePR(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!KXaPbukfFUJAJqHNnclnvNPyViv(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & GGzOGzHtpxbNHybZmOHhzOgHAgG) != P_1)
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

		internal bool qKuqfNFubTEInzOesyiOykphHPAa(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (KXaPbukfFUJAJqHNnclnvNPyViv(P_0))
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
			if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
			{
				return -1;
			}
			return dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> buttonMaps_orig = controllerMap.ButtonMaps_orig;
				int count = buttonMaps_orig.Count;
				for (int i = 0; i < count; i++)
				{
					IginakiartMCXcNztgFGkBgBmEe(controllerMap, buttonMaps_orig[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.qOVDONBKVKOloJeRYYKGTFZqcKAM(controllerMap);
		}

		internal override void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			base.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			cGWcxMeRpTFnHjBueQYYnybOYBl = ModifierKeyFlags.None;
			GGzOGzHtpxbNHybZmOHhzOgHAgG = ModifierKeyFlags.None;
		}

		private bool XmRHUGQmTcdKJwmvjcCfpZCNVwx(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[dtxMxRdhsXLfunxytSkHyaamzSw[306]];
				P_1 = buttons[dtxMxRdhsXLfunxytSkHyaamzSw[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[dtxMxRdhsXLfunxytSkHyaamzSw[308]];
				P_1 = buttons[dtxMxRdhsXLfunxytSkHyaamzSw[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[dtxMxRdhsXLfunxytSkHyaamzSw[310]];
				P_1 = buttons[dtxMxRdhsXLfunxytSkHyaamzSw[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[dtxMxRdhsXLfunxytSkHyaamzSw[304]];
				P_1 = buttons[dtxMxRdhsXLfunxytSkHyaamzSw[303]];
				return true;
			default:
				return false;
			}
		}

		private void AXnkZhmOKHVMmlFYiKXtPWIbMLM()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[dtxMxRdhsXLfunxytSkHyaamzSw[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[dtxMxRdhsXLfunxytSkHyaamzSw[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[dtxMxRdhsXLfunxytSkHyaamzSw[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[dtxMxRdhsXLfunxytSkHyaamzSw[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[dtxMxRdhsXLfunxytSkHyaamzSw[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[dtxMxRdhsXLfunxytSkHyaamzSw[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[dtxMxRdhsXLfunxytSkHyaamzSw[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[dtxMxRdhsXLfunxytSkHyaamzSw[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			cGWcxMeRpTFnHjBueQYYnybOYBl = modifierKeyFlags;
			GGzOGzHtpxbNHybZmOHhzOgHAgG = pdWwsAjklZfWFhcbWEXNcFLahil(modifierKeyFlags);
		}
	}
}
