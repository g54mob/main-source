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
		private sealed class VazoiUYSTmYteGgVPvPZFhJRBpd : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public Keyboard kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int ukEpIHkZkiiVnMRHvoIgHtDiHZf;

			public int WEaqIZlkOXafrZCTcGmyQTyddIOi;

			public KeyCode jRzqrAtSPxjlaxBviefnncGXMQA;

			public bool wtKARKgfopiasDBuyCedmzJxWci;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				VazoiUYSTmYteGgVPvPZFhJRBpd vazoiUYSTmYteGgVPvPZFhJRBpd;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					vazoiUYSTmYteGgVPvPZFhJRBpd = this;
				}
				else
				{
					vazoiUYSTmYteGgVPvPZFhJRBpd = new VazoiUYSTmYteGgVPvPZFhJRBpd(0);
					vazoiUYSTmYteGgVPvPZFhJRBpd.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return vazoiUYSTmYteGgVPvPZFhJRBpd;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						break;
					}
					ukEpIHkZkiiVnMRHvoIgHtDiHZf = Consts.keyboardKeyValues.Count;
					WEaqIZlkOXafrZCTcGmyQTyddIOi = 0;
					goto IL_0116;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0108;
					}
					IL_0116:
					if (WEaqIZlkOXafrZCTcGmyQTyddIOi >= ukEpIHkZkiiVnMRHvoIgHtDiHZf)
					{
						break;
					}
					jRzqrAtSPxjlaxBviefnncGXMQA = (KeyCode)Consts.keyboardKeyValues[WEaqIZlkOXafrZCTcGmyQTyddIOi];
					wtKARKgfopiasDBuyCedmzJxWci = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetKey(jRzqrAtSPxjlaxBviefnncGXMQA);
					if (wtKARKgfopiasDBuyCedmzJxWci)
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = new ControllerPollingInfo(success: true, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO.id, kdBZqupjvsCsVkwJiOeEQzkEDVO._name, kdBZqupjvsCsVkwJiOeEQzkEDVO._type, ControllerElementType.Button, WEaqIZlkOXafrZCTcGmyQTyddIOi, Pole.Positive, GetKeyName(jRzqrAtSPxjlaxBviefnncGXMQA), kdBZqupjvsCsVkwJiOeEQzkEDVO.ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonElementIdentifierIds[WEaqIZlkOXafrZCTcGmyQTyddIOi], jRzqrAtSPxjlaxBviefnncGXMQA);
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_0108;
					IL_0108:
					WEaqIZlkOXafrZCTcGmyQTyddIOi++;
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
			public VazoiUYSTmYteGgVPvPZFhJRBpd(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class CfrnrXZYMMZGGTVFlxzojziMwPX : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public Keyboard kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int OESQldHDmyxQLXdSsRBfmgMpOFC;

			public int MEcCQFHbfgBWbTwXMVopAVVdGLj;

			public KeyCode ceLpgybcMUAaQOnSsatecFWLKUvc;

			public bool LAchsqOcyOJoBnmuQDnBeQIaUKBw;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				CfrnrXZYMMZGGTVFlxzojziMwPX cfrnrXZYMMZGGTVFlxzojziMwPX;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					cfrnrXZYMMZGGTVFlxzojziMwPX = this;
				}
				else
				{
					cfrnrXZYMMZGGTVFlxzojziMwPX = new CfrnrXZYMMZGGTVFlxzojziMwPX(0);
					cfrnrXZYMMZGGTVFlxzojziMwPX.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return cfrnrXZYMMZGGTVFlxzojziMwPX;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						break;
					}
					OESQldHDmyxQLXdSsRBfmgMpOFC = Consts.keyboardKeyValues.Count;
					MEcCQFHbfgBWbTwXMVopAVVdGLj = 0;
					goto IL_0116;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0108;
					}
					IL_0116:
					if (MEcCQFHbfgBWbTwXMVopAVVdGLj >= OESQldHDmyxQLXdSsRBfmgMpOFC)
					{
						break;
					}
					ceLpgybcMUAaQOnSsatecFWLKUvc = (KeyCode)Consts.keyboardKeyValues[MEcCQFHbfgBWbTwXMVopAVVdGLj];
					LAchsqOcyOJoBnmuQDnBeQIaUKBw = kdBZqupjvsCsVkwJiOeEQzkEDVO.GetKeyDown(ceLpgybcMUAaQOnSsatecFWLKUvc);
					if (LAchsqOcyOJoBnmuQDnBeQIaUKBw)
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = new ControllerPollingInfo(success: true, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO.id, kdBZqupjvsCsVkwJiOeEQzkEDVO._name, kdBZqupjvsCsVkwJiOeEQzkEDVO._type, ControllerElementType.Button, MEcCQFHbfgBWbTwXMVopAVVdGLj, Pole.Positive, GetKeyName(ceLpgybcMUAaQOnSsatecFWLKUvc), kdBZqupjvsCsVkwJiOeEQzkEDVO.ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonElementIdentifierIds[MEcCQFHbfgBWbTwXMVopAVVdGLj], ceLpgybcMUAaQOnSsatecFWLKUvc);
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_0108;
					IL_0108:
					MEcCQFHbfgBWbTwXMVopAVVdGLj++;
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
			public CfrnrXZYMMZGGTVFlxzojziMwPX(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private static Keyboard kzUJjtEFRxsLglcUrDwekzbuHhI;

		private readonly IUnifiedKeyboardSource NsRIQHseimotuEJGoIuiBqmlsEN;

		private ModifierKeyFlags QkaOYeJfMEvGRQmObeUBisAsPNDG;

		private ModifierKeyFlags kMHejTBiMeZcDcxrlTFoGnZjosce;

		private Func<KeyboardKeyCode, int> DEGekDBNBwqZBkaujPsKHhjvDjER;

		private readonly int[] RIVBtlAbAYNoaeaBwCECfoVCFnIT;

		private static KeyboardKeyCode[] MbDDLpSbtmQlOKMENrODPFSDpGZ;

		private readonly int BukTegbYDJItSjLUZOcyVNBHKSu;

		private static Guid IQcFpAKvLgzUgbAfXoMHZXcNPEzT;

		private static KeyboardKeyCode[] keyIndexToKeyboardKeyCode
		{
			get
			{
				if (MbDDLpSbtmQlOKMENrODPFSDpGZ == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					MbDDLpSbtmQlOKMENrODPFSDpGZ = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						MbDDLpSbtmQlOKMENrODPFSDpGZ[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return MbDDLpSbtmQlOKMENrODPFSDpGZ;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Guid.Empty;
				}
				return IQcFpAKvLgzUgbAfXoMHZXcNPEzT;
			}
		}

		internal Keyboard(string name, IUnifiedKeyboardSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.hardwareMap, 132, source?.controllerExtension, new ControllerDataUpdater(source.inputSource, 0, 132, null))
		{
			IQcFpAKvLgzUgbAfXoMHZXcNPEzT = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int i = 0; i < num; i++)
			{
				if (keyboardKeyValues[i] > BukTegbYDJItSjLUZOcyVNBHKSu)
				{
					BukTegbYDJItSjLUZOcyVNBHKSu = keyboardKeyValues[i];
				}
			}
			RIVBtlAbAYNoaeaBwCECfoVCFnIT = new int[BukTegbYDJItSjLUZOcyVNBHKSu + 1];
			ArrayTools.Fill(RIVBtlAbAYNoaeaBwCECfoVCFnIT, -1);
			for (int j = 0; j < num; j++)
			{
				RIVBtlAbAYNoaeaBwCECfoVCFnIT[keyboardKeyValues[j]] = j;
			}
			NsRIQHseimotuEJGoIuiBqmlsEN = source;
			guKElsGLCmgnAbWmxWZxRdTPwg();
		}

		private Keyboard(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, HardwareControllerMap_Game hardwareMap, int buttonCount, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
			kzUJjtEFRxsLglcUrDwekzbuHhI = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return 0.0;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return 0.0;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (!dapiLepgwhEsRtBNoccstDnpLvR(out var button, out var button2, key))
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (!dapiLepgwhEsRtBNoccstDnpLvR(out var button, out var button2, key))
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (!dapiLepgwhEsRtBNoccstDnpLvR(out var button, out var button2, key))
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (!dapiLepgwhEsRtBNoccstDnpLvR(out var button, out var button2, key))
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (!dapiLepgwhEsRtBNoccstDnpLvR(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (!dapiLepgwhEsRtBNoccstDnpLvR(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return KeyCode.None;
			}
			return wQMWGDbGSkKqmCNSneVJmJHYQyk(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return -1;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return -1;
			}
			return RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return null;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			VazoiUYSTmYteGgVPvPZFhJRBpd vazoiUYSTmYteGgVPvPZFhJRBpd = new VazoiUYSTmYteGgVPvPZFhJRBpd(-2);
			vazoiUYSTmYteGgVPvPZFhJRBpd.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			return vazoiUYSTmYteGgVPvPZFhJRBpd;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			CfrnrXZYMMZGGTVFlxzojziMwPX cfrnrXZYMMZGGTVFlxzojziMwPX = new CfrnrXZYMMZGGTVFlxzojziMwPX(-2);
			cfrnrXZYMMZGGTVFlxzojziMwPX.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			return cfrnrXZYMMZGGTVFlxzojziMwPX;
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
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

		internal static bool GmqhzweNAHplSqjZKHhRiuBhQrT(KeyboardKeyCode P_0)
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
			if (kzUJjtEFRxsLglcUrDwekzbuHhI == null)
			{
				return string.Empty;
			}
			int buttonIndex = kzUJjtEFRxsLglcUrDwekzbuHhI.GetButtonIndex(UWlRgNZqLmGCLLFMtxvUbShaHkE(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return kzUJjtEFRxsLglcUrDwekzbuHhI.ButtonElementIdentifiers[buttonIndex].name;
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

		internal static KeyboardKeyCode UWlRgNZqLmGCLLFMtxvUbShaHkE(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode wQMWGDbGSkKqmCNSneVJmJHYQyk(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags ZPsaRkKxYGPSXubHHPCEuomKAhT(ModifierKeyFlags P_0)
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

		internal static int ahsFqIAjKQQPzWJwfWcxbuQGiWxu(ModifierKeyFlags P_0)
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

		internal static int HqJTpZisZbxvxTtmqzLpDeQxDuT(KeyboardKeyCode P_0)
		{
			int buttonIndex = kzUJjtEFRxsLglcUrDwekzbuHhI.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return kzUJjtEFRxsLglcUrDwekzbuHhI.ButtonElementIdentifiers[buttonIndex].id;
		}

		internal static void pVpzVTFcuJpkyCBLMXuWlfgKhbMJ(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = HqJTpZisZbxvxTtmqzLpDeQxDuT(UWlRgNZqLmGCLLFMtxvUbShaHkE(P_1));
			}
			else
			{
				P_1 = ReInput.aPNcjJCKQolbdJEKHuJkfRPTMco.Keyboard.GetKeyCodeById(P_0);
			}
		}

		internal override void qLvftnPJXcUYQsqiHkMAPRekFwO(UpdateLoopType P_0)
		{
			NsRIQHseimotuEJGoIuiBqmlsEN.UpdateInputData(ebxBmtwxyRprAbJBnnRdvbVCKbL);
			base.qLvftnPJXcUYQsqiHkMAPRekFwO(P_0);
			uTNzqBZutKUvyyPedQDmJpzROVo();
		}

		internal void gkZMTNuuOHGkOJFzBnsouHaoKMr(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].GcIuKOHgXujXqCTdAuwBBVguUoX(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, ebxBmtwxyRprAbJBnnRdvbVCKbL);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].GcIuKOHgXujXqCTdAuwBBVguUoX(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, ebxBmtwxyRprAbJBnnRdvbVCKbL);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].GcIuKOHgXujXqCTdAuwBBVguUoX(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, ebxBmtwxyRprAbJBnnRdvbVCKbL);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].GcIuKOHgXujXqCTdAuwBBVguUoX(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, ebxBmtwxyRprAbJBnnRdvbVCKbL);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].GcIuKOHgXujXqCTdAuwBBVguUoX(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, ebxBmtwxyRprAbJBnnRdvbVCKbL);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].GcIuKOHgXujXqCTdAuwBBVguUoX(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, ebxBmtwxyRprAbJBnnRdvbVCKbL);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].GcIuKOHgXujXqCTdAuwBBVguUoX(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, ebxBmtwxyRprAbJBnnRdvbVCKbL);
		}

		internal bool wTAaLLJvKJshQxazybysdRuUePU(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool DiJqtHpGmiDnYaDYVZspVrfLwLk(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return false;
			}
			int num = RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool UajMhGPRKPMztrzwOEyXLqefmDv(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!wTAaLLJvKJshQxazybysdRuUePU(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & kMHejTBiMeZcDcxrlTFoGnZjosce) != P_1)
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

		internal bool KxWCKrBiUIhldHeEEdaVKyCDBJam(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (wTAaLLJvKJshQxazybysdRuUePU(P_0))
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
			if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
			{
				return -1;
			}
			return RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode];
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
					sSQYMATtZixpYjjUsqaWsAupijI(controllerMap, buttonMaps_orig[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.WydnbjhvuRfUebKtXVYHLAcSJCu(controllerMap);
		}

		internal override void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			base.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			QkaOYeJfMEvGRQmObeUBisAsPNDG = ModifierKeyFlags.None;
			kMHejTBiMeZcDcxrlTFoGnZjosce = ModifierKeyFlags.None;
		}

		private bool dapiLepgwhEsRtBNoccstDnpLvR(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[306]];
				P_1 = buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[308]];
				P_1 = buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[310]];
				P_1 = buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[304]];
				P_1 = buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[303]];
				return true;
			default:
				return false;
			}
		}

		private void uTNzqBZutKUvyyPedQDmJpzROVo()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[RIVBtlAbAYNoaeaBwCECfoVCFnIT[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			QkaOYeJfMEvGRQmObeUBisAsPNDG = modifierKeyFlags;
			kMHejTBiMeZcDcxrlTFoGnZjosce = ZPsaRkKxYGPSXubHHPCEuomKAhT(modifierKeyFlags);
		}
	}
}
