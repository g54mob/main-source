using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	public sealed class Keyboard : ControllerWithMap
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class ModifierKeyInfo
		{
			public readonly string shortName;

			public readonly string longName;

			public readonly string shortKey;

			public readonly string longKey;

			public ModifierKeyInfo(string P_0, string P_1, string P_2, string P_3)
			{
				shortName = P_0;
				longName = P_1;
				shortKey = P_2;
				longKey = P_3;
			}

			public string GetName(bool useShort)
			{
				if (!useShort)
				{
					return longName;
				}
				return shortName;
			}

			public string GetKey(bool useShort)
			{
				if (!useShort)
				{
					return longKey;
				}
				return shortKey;
			}
		}

		private class yGeBEzJkmLddMihODueUaZNoFBrKc
		{
			public readonly ihvpemfLZpBtYcDmDFrxrfBcDorG tXkBNZLbhNWzAGXgfCKRTDClDOYL;

			public readonly ihvpemfLZpBtYcDmDFrxrfBcDorG lyATzGIeVgoDvlAQrmADUpaADOwq;

			public yGeBEzJkmLddMihODueUaZNoFBrKc(string P_0, string P_1)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					tXkBNZLbhNWzAGXgfCKRTDClDOYL = new ihvpemfLZpBtYcDmDFrxrfBcDorG(new LocalizedString());
				}
				if (!string.IsNullOrEmpty(P_1))
				{
					lyATzGIeVgoDvlAQrmADUpaADOwq = new ihvpemfLZpBtYcDmDFrxrfBcDorG(new LocalizedString());
				}
			}
		}

		private sealed class ihvpemfLZpBtYcDmDFrxrfBcDorG
		{
			public readonly LocalizedString sTmyJNtmOyAYuQrhzXjiKIHKIkkCA;

			public bool DmvsVranThEksPhqxehxVlazJTbD;

			public ihvpemfLZpBtYcDmDFrxrfBcDorG(LocalizedString P_0)
			{
				sTmyJNtmOyAYuQrhzXjiKIHKIkkCA = P_0;
			}
		}

		private sealed class DuzcGKeeKxJTFNXSnXTeBsgjGYsG
		{
			public readonly KeyedGlyph rJdzzWXjXskzhCNerKMJZZcCrAKk;

			public bool PMkpuKXkzYjPmbmNWNfHWLotELjR;

			public DuzcGKeeKxJTFNXSnXTeBsgjGYsG(KeyedGlyph P_0)
			{
				rJdzzWXjXskzhCNerKMJZZcCrAKk = P_0;
			}
		}

		private sealed class qQlqkLHOrZivxuhfTIOySTEchGtn : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int djIlTfTqNPUWRSsAPKJUmICCjjso;

			private ControllerPollingInfo tgAeetazWfxmASySohzvdEaAxGiz;

			private int oFMIYEEyQiFSEjWGsxIkLosrqYESA;

			public Keyboard DzrDEYhglUpRldZbtNfyKYHpzWbKA;

			private int tbBcCBIjLtdzxXBGJoCUawGvfiepA;

			private int YUMoimxThgLEfkFZvBhjhseFakHZA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return tgAeetazWfxmASySohzvdEaAxGiz;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return tgAeetazWfxmASySohzvdEaAxGiz;
				}
			}

			[DebuggerHidden]
			public qQlqkLHOrZivxuhfTIOySTEchGtn(int P_0)
			{
				djIlTfTqNPUWRSsAPKJUmICCjjso = P_0;
				oFMIYEEyQiFSEjWGsxIkLosrqYESA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				djIlTfTqNPUWRSsAPKJUmICCjjso = -2;
			}

			private bool MoveNext()
			{
				int num = djIlTfTqNPUWRSsAPKJUmICCjjso;
				Keyboard dzrDEYhglUpRldZbtNfyKYHpzWbKA = DzrDEYhglUpRldZbtNfyKYHpzWbKA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					djIlTfTqNPUWRSsAPKJUmICCjjso = -1;
					goto IL_00bf;
				}
				djIlTfTqNPUWRSsAPKJUmICCjjso = -1;
				if (ReInput._id != dzrDEYhglUpRldZbtNfyKYHpzWbKA.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(dzrDEYhglUpRldZbtNfyKYHpzWbKA.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return false;
				}
				tbBcCBIjLtdzxXBGJoCUawGvfiepA = Consts.keyboardKeyValues.Count;
				YUMoimxThgLEfkFZvBhjhseFakHZA = 0;
				goto IL_00cf;
				IL_00cf:
				if (YUMoimxThgLEfkFZvBhjhseFakHZA < tbBcCBIjLtdzxXBGJoCUawGvfiepA)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[YUMoimxThgLEfkFZvBhjhseFakHZA];
					if (dzrDEYhglUpRldZbtNfyKYHpzWbKA.GetKey(keyCode))
					{
						tgAeetazWfxmASySohzvdEaAxGiz = new ControllerPollingInfo(true, -1, dzrDEYhglUpRldZbtNfyKYHpzWbKA.id, dzrDEYhglUpRldZbtNfyKYHpzWbKA._name, dzrDEYhglUpRldZbtNfyKYHpzWbKA._type, ControllerElementType.Button, YUMoimxThgLEfkFZvBhjhseFakHZA, Pole.Positive, GetKeyName(keyCode), dzrDEYhglUpRldZbtNfyKYHpzWbKA.LJmpCFrENABMhmUxmGaTconkDyoGA.buttonElementIdentifierIds[YUMoimxThgLEfkFZvBhjhseFakHZA], keyCode);
						djIlTfTqNPUWRSsAPKJUmICCjjso = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				YUMoimxThgLEfkFZvBhjhseFakHZA++;
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
				qQlqkLHOrZivxuhfTIOySTEchGtn qQlqkLHOrZivxuhfTIOySTEchGtn2;
				if (djIlTfTqNPUWRSsAPKJUmICCjjso == -2 && oFMIYEEyQiFSEjWGsxIkLosrqYESA == Environment.CurrentManagedThreadId)
				{
					djIlTfTqNPUWRSsAPKJUmICCjjso = 0;
					qQlqkLHOrZivxuhfTIOySTEchGtn2 = this;
				}
				else
				{
					qQlqkLHOrZivxuhfTIOySTEchGtn2 = new qQlqkLHOrZivxuhfTIOySTEchGtn(0);
					qQlqkLHOrZivxuhfTIOySTEchGtn2.DzrDEYhglUpRldZbtNfyKYHpzWbKA = DzrDEYhglUpRldZbtNfyKYHpzWbKA;
				}
				return qQlqkLHOrZivxuhfTIOySTEchGtn2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class TdQIGqQzhMvzOlmvzgNsRFtcKBit : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int xGPEBqXFaWinCbXEtDwlHyBFwDtB;

			private ControllerPollingInfo mWRGnxfJqWvPDSupEbfGGUBdoGBdB;

			private int PJKatZDKiwcFqwlDrpZDyNUuyegw;

			public Keyboard pxLAlCFpjqbvLVgOwaSAgQozEwKyA;

			private int SHvpryynXoXbJHzVlZWmusIrQghh;

			private int HOXKJomgbEBsMjKEqATxIvZYqYgl;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return mWRGnxfJqWvPDSupEbfGGUBdoGBdB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return mWRGnxfJqWvPDSupEbfGGUBdoGBdB;
				}
			}

			[DebuggerHidden]
			public TdQIGqQzhMvzOlmvzgNsRFtcKBit(int P_0)
			{
				xGPEBqXFaWinCbXEtDwlHyBFwDtB = P_0;
				PJKatZDKiwcFqwlDrpZDyNUuyegw = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				xGPEBqXFaWinCbXEtDwlHyBFwDtB = -2;
			}

			private bool MoveNext()
			{
				int num = xGPEBqXFaWinCbXEtDwlHyBFwDtB;
				Keyboard keyboard = pxLAlCFpjqbvLVgOwaSAgQozEwKyA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					xGPEBqXFaWinCbXEtDwlHyBFwDtB = -1;
					goto IL_00bf;
				}
				xGPEBqXFaWinCbXEtDwlHyBFwDtB = -1;
				if (ReInput._id != keyboard.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(keyboard.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return false;
				}
				SHvpryynXoXbJHzVlZWmusIrQghh = Consts.keyboardKeyValues.Count;
				HOXKJomgbEBsMjKEqATxIvZYqYgl = 0;
				goto IL_00cf;
				IL_00cf:
				if (HOXKJomgbEBsMjKEqATxIvZYqYgl < SHvpryynXoXbJHzVlZWmusIrQghh)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[HOXKJomgbEBsMjKEqATxIvZYqYgl];
					if (keyboard.GetKeyDown(keyCode))
					{
						mWRGnxfJqWvPDSupEbfGGUBdoGBdB = new ControllerPollingInfo(true, -1, keyboard.id, keyboard._name, keyboard._type, ControllerElementType.Button, HOXKJomgbEBsMjKEqATxIvZYqYgl, Pole.Positive, GetKeyName(keyCode), keyboard.LJmpCFrENABMhmUxmGaTconkDyoGA.buttonElementIdentifierIds[HOXKJomgbEBsMjKEqATxIvZYqYgl], keyCode);
						xGPEBqXFaWinCbXEtDwlHyBFwDtB = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				HOXKJomgbEBsMjKEqATxIvZYqYgl++;
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
				TdQIGqQzhMvzOlmvzgNsRFtcKBit tdQIGqQzhMvzOlmvzgNsRFtcKBit;
				if (xGPEBqXFaWinCbXEtDwlHyBFwDtB == -2 && PJKatZDKiwcFqwlDrpZDyNUuyegw == Environment.CurrentManagedThreadId)
				{
					xGPEBqXFaWinCbXEtDwlHyBFwDtB = 0;
					tdQIGqQzhMvzOlmvzgNsRFtcKBit = this;
				}
				else
				{
					tdQIGqQzhMvzOlmvzgNsRFtcKBit = new TdQIGqQzhMvzOlmvzgNsRFtcKBit(0);
					tdQIGqQzhMvzOlmvzgNsRFtcKBit.pxLAlCFpjqbvLVgOwaSAgQozEwKyA = pxLAlCFpjqbvLVgOwaSAgQozEwKyA;
				}
				return tdQIGqQzhMvzOlmvzgNsRFtcKBit;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private const string rqEtceMrXIIRAYdvlARKbVePqebG = " + ";

		private static Keyboard XwjLuuCunWktoBxnUUCsJpNKwlmT;

		private static KeyboardKeyCode[] aGMFVoUuBhdnKLyVPRwFgjsynxhJ;

		private static Guid BRJbmenXUbfGrGVbWlghmExUuxgu;

		private readonly IUnifiedKeyboardSource EqKRrgfXShRrNkIvFpYuhJyERmkv;

		private ModifierKeyFlags WnWiFDTbWoAgUfxHmQdKsYXSPxVP;

		private ModifierKeyFlags dqOJytbnGEkrILKWgwwQdmDFKAfN;

		private Func<KeyboardKeyCode, int> BswypxRyCNSZHDxsjQQHxpYsrWEE;

		private readonly int[] GDEAsiRaWYwSbDPqBIGwuWAJkXXl;

		private readonly int wUaaChdOpuUlPFfICVCIjByIFhye;

		private readonly gjMBNBgPUgnpVrmJwQZQrVmLNmagb VUsEoHHGmpyLPtoHYVGExajfkEdFb;

		private readonly awrViSzSdJenxOiWAZboqHxpzxSK BTkqwmPfSebrVBpBMrhhlIzkqoDF;

		private Dictionary<int, yGeBEzJkmLddMihODueUaZNoFBrKc> OdRzfDpxBwwdHwheNXHmhnVqJaNv;

		private Dictionary<int, DuzcGKeeKxJTFNXSnXTeBsgjGYsG> GohmzwIMJylrcxGboiIexRzaSCwo;

		private static KeyboardKeyCode[] tPTmwzICmqybIjKCBNvJvrLPDouX
		{
			get
			{
				if (aGMFVoUuBhdnKLyVPRwFgjsynxhJ == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					aGMFVoUuBhdnKLyVPRwFgjsynxhJ = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						aGMFVoUuBhdnKLyVPRwFgjsynxhJ[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return aGMFVoUuBhdnKLyVPRwFgjsynxhJ;
			}
		}

		private Dictionary<int, yGeBEzJkmLddMihODueUaZNoFBrKc> BEWLWpoHgPTHNeWNBqvZaUYDVsAB
		{
			get
			{
				if (OdRzfDpxBwwdHwheNXHmhnVqJaNv == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, yGeBEzJkmLddMihODueUaZNoFBrKc> dictionary = new Dictionary<int, yGeBEzJkmLddMihODueUaZNoFBrKc>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							dictionary.Add(item.Key, new yGeBEzJkmLddMihODueUaZNoFBrKc(item.Value.shortKey, item.Value.longKey));
						}
					}
					OdRzfDpxBwwdHwheNXHmhnVqJaNv = dictionary;
				}
				return OdRzfDpxBwwdHwheNXHmhnVqJaNv;
			}
		}

		private Dictionary<int, DuzcGKeeKxJTFNXSnXTeBsgjGYsG> PfCIgVIhXtlPcINCEYZbxdLSleJPc
		{
			get
			{
				if (GohmzwIMJylrcxGboiIexRzaSCwo == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, DuzcGKeeKxJTFNXSnXTeBsgjGYsG> dictionary = new Dictionary<int, DuzcGKeeKxJTFNXSnXTeBsgjGYsG>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							DuzcGKeeKxJTFNXSnXTeBsgjGYsG value = new DuzcGKeeKxJTFNXSnXTeBsgjGYsG(new KeyedGlyph());
							dictionary.Add(item.Key, value);
						}
					}
					GohmzwIMJylrcxGboiIexRzaSCwo = dictionary;
				}
				return GohmzwIMJylrcxGboiIexRzaSCwo;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return Guid.Empty;
				}
				return BRJbmenXUbfGrGVbWlghmExUuxgu;
			}
		}

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
		{
			BRJbmenXUbfGrGVbWlghmExUuxgu = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			VUsEoHHGmpyLPtoHYVGExajfkEdFb = new gjMBNBgPUgnpVrmJwQZQrVmLNmagb(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					sHHAgZrPFlTcUDEXkthrWnjeRoYl(values[i], true);
					sHHAgZrPFlTcUDEXkthrWnjeRoYl(values[i], false);
				}
			});
			BTkqwmPfSebrVBpBMrhhlIzkqoDF = new awrViSzSdJenxOiWAZboqHxpzxSK(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					ODSXxHYgqJaCsEzSAUmzUZGVPjFk(values[i]);
				}
			});
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int num2 = 0; num2 < num; num2++)
			{
				if (keyboardKeyValues[num2] > wUaaChdOpuUlPFfICVCIjByIFhye)
				{
					wUaaChdOpuUlPFfICVCIjByIFhye = keyboardKeyValues[num2];
				}
			}
			GDEAsiRaWYwSbDPqBIGwuWAJkXXl = new int[wUaaChdOpuUlPFfICVCIjByIFhye + 1];
			ArrayTools.Fill(GDEAsiRaWYwSbDPqBIGwuWAJkXXl, -1);
			for (int num3 = 0; num3 < num; num3++)
			{
				GDEAsiRaWYwSbDPqBIGwuWAJkXXl[keyboardKeyValues[num3]] = num3;
			}
			EqKRrgfXShRrNkIvFpYuhJyERmkv = P_1;
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((nYVWMTKfnKjTqnJzQqfdswXfeTcY)VUsEoHHGmpyLPtoHYVGExajfkEdFb).Localize();
			}
			if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
			{
				((IPrefetch)BTkqwmPfSebrVBpBMrhhlIzkqoDF).Prefetch();
			}
			vXguOrVHQgZdRgenIvihyjDDIBEO();
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
		{
			XwjLuuCunWktoBxnUUCsJpNKwlmT = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return 0.0;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return 0.0;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if (!pwAeYUZnrusCsIvIDOtIoLanBmSD(out var button, out var button2, key))
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if (!pwAeYUZnrusCsIvIDOtIoLanBmSD(out var button, out var button2, key))
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if (!pwAeYUZnrusCsIvIDOtIoLanBmSD(out var button, out var button2, key))
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if (!pwAeYUZnrusCsIvIDOtIoLanBmSD(out var button, out var button2, key))
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			if (!pwAeYUZnrusCsIvIDOtIoLanBmSD(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			if (!pwAeYUZnrusCsIvIDOtIoLanBmSD(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return KeyCode.None;
			}
			return WaJDKWeoSDKSZsMkwkPqJseQhHfuA(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return -1;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return -1;
			}
			return GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return null;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return LJmpCFrENABMhmUxmGaTconkDyoGA.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), LJmpCFrENABMhmUxmGaTconkDyoGA.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
		}

		[IteratorStateMachine(typeof(qQlqkLHOrZivxuhfTIOySTEchGtn))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return new qQlqkLHOrZivxuhfTIOySTEchGtn(-2)
			{
				DzrDEYhglUpRldZbtNfyKYHpzWbKA = this
			};
		}

		[IteratorStateMachine(typeof(TdQIGqQzhMvzOlmvzgNsRFtcKBit))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return new TdQIGqQzhMvzOlmvzgNsRFtcKBit(-2)
			{
				pxLAlCFpjqbvLVgOwaSAgQozEwKyA = this
			};
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), LJmpCFrENABMhmUxmGaTconkDyoGA.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
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

		internal static bool QXaakIyvlTOgNrkYoQHCAOjOARgdA(KeyboardKeyCode P_0)
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
			if (XwjLuuCunWktoBxnUUCsJpNKwlmT == null)
			{
				return string.Empty;
			}
			int buttonIndex = XwjLuuCunWktoBxnUUCsJpNKwlmT.GetButtonIndex(AUeMZhkPXDeIyANKhGXLPPPdAvEb(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return XwjLuuCunWktoBxnUUCsJpNKwlmT.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
		}

		public static string GetKeyName(KeyCode key, ModifierKeyFlags flags)
		{
			string text = GetKeyName(key);
			if (flags != ModifierKeyFlags.None)
			{
				StringBuilder stringBuilder = new StringBuilder(text);
				stringBuilder.Append(" + ");
				stringBuilder.Append(ModifierKeyFlagsToString(flags));
				text = stringBuilder.ToString();
			}
			return text;
		}

		public static string GetModifierKeyName(ModifierKey modifierKey)
		{
			if (XwjLuuCunWktoBxnUUCsJpNKwlmT == null)
			{
				return string.Empty;
			}
			return XwjLuuCunWktoBxnUUCsJpNKwlmT.sHHAgZrPFlTcUDEXkthrWnjeRoYl(modifierKey, false);
		}

		public static string GetModifierKeyName(ModifierKey modifierKey, bool getShortName)
		{
			if (XwjLuuCunWktoBxnUUCsJpNKwlmT == null)
			{
				return string.Empty;
			}
			return XwjLuuCunWktoBxnUUCsJpNKwlmT.sHHAgZrPFlTcUDEXkthrWnjeRoYl(modifierKey, getShortName);
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags, bool getShortName)
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			if (ModifierKeyFlagsContain(flags, ModifierKey.Control))
			{
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Control, getShortName));
				num++;
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Command))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Command, getShortName));
				num++;
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Alt))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Alt, getShortName));
				num++;
			}
			if (num >= 3)
			{
				return stringBuilder.ToString();
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Shift))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Shift, getShortName));
				num++;
			}
			return stringBuilder.ToString();
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return ModifierKeyFlagsToString(flags, getShortName: false);
		}

		public static object GetModifierKeyGlyph(ModifierKey modifierKey)
		{
			if (XwjLuuCunWktoBxnUUCsJpNKwlmT == null)
			{
				return null;
			}
			return XwjLuuCunWktoBxnUUCsJpNKwlmT.ODSXxHYgqJaCsEzSAUmzUZGVPjFk(modifierKey);
		}

		internal static string EflTTUsFOLYXwndvQGCiDDfPWmhJA(ModifierKey P_0)
		{
			if (XwjLuuCunWktoBxnUUCsJpNKwlmT == null)
			{
				return string.Empty;
			}
			return XwjLuuCunWktoBxnUUCsJpNKwlmT.IiHNkrXHZbqCmOjQiAwYbETaFhEg(P_0);
		}

		internal static KeyboardKeyCode AUeMZhkPXDeIyANKhGXLPPPdAvEb(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode WaJDKWeoSDKSZsMkwkPqJseQhHfuA(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags RdxtctnxchnmSejZFVqBjXtRBpjb(ModifierKeyFlags P_0)
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

		internal static int dDKffpgttNOWABdGbMoWVASvtyWPb(ModifierKeyFlags P_0)
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
			return tPTmwzICmqybIjKCBNvJvrLPDouX[buttonIndex];
		}

		internal static int DzpRBVAMKQgMDrJWkjigDFCmpkIC(KeyboardKeyCode P_0)
		{
			int buttonIndex = XwjLuuCunWktoBxnUUCsJpNKwlmT.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return XwjLuuCunWktoBxnUUCsJpNKwlmT.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
		}

		internal static void EfnCgvkaMMnmCiLNUrWbSEUfNAxNA(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = DzpRBVAMKQgMDrJWkjigDFCmpkIC(AUeMZhkPXDeIyANKhGXLPPPdAvEb(P_1));
			}
			else
			{
				P_1 = ReInput.YNZnkUUWdETsfnFwfyPUjVPxExCq.WbGyhovABrZvNbHXBQtDZzjtIeFm.GetKeyCodeById(P_0);
			}
		}

		internal void uJLAwYDxQJqRatLqypdHeqVbQDvmA(UpdateLoopType P_0)
		{
			EqKRrgfXShRrNkIvFpYuhJyERmkv.UpdateInputData(zfVdfqKDuqZKjafBdqgdinjRQNeGb);
			base.KvONimPsnvghlMkZzyXoBEjvJCHX(P_0);
			cVlksmZnFDkggAaOzLcwKgiUposR();
		}

		internal void PiJegrHBDJdMBsHBkIOpZqNVApwP(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
		}

		internal bool steBetEKpQeVFLbrDsJTwcfilAyIA(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool XJxCDjPffENUibIuwXwrPwZnhQH(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return false;
			}
			int num = GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool iOdavyvglsRJMSaQiqNVvnWyeinW(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!steBetEKpQeVFLbrDsJTwcfilAyIA(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & dqOJytbnGEkrILKWgwwQdmDFKAfN) != P_1)
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

		internal bool UxbcWFRNfUOovwmPBfOvpMKFOkke(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (steBetEKpQeVFLbrDsJTwcfilAyIA(P_0))
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
			if ((uint)keyCode > (uint)wUaaChdOpuUlPFfICVCIjByIFhye)
			{
				return -1;
			}
			return GDEAsiRaWYwSbDPqBIGwuWAJkXXl[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> list = controllerMap.QzzwgmKQPAOvkCxEzGFvpXQEKzfn;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					MLdcpPOYjvtoDJPENGusyemNCWAq(controllerMap, list[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.PKuPVtkPJEWiXrQtJpzVObMiLTlx(controllerMap);
		}

		internal void ThhgjrNakhHABgMAgwWFKKFndziK()
		{
			base.scCwpLEHFiuvitLgzEfOOpCTYgPj();
			WnWiFDTbWoAgUfxHmQdKsYXSPxVP = ModifierKeyFlags.None;
			dqOJytbnGEkrILKWgwwQdmDFKAfN = ModifierKeyFlags.None;
		}

		internal bool UbpIRvCQrsImCHBaOlrmMFFUXfFTA(bool P_0)
		{
			if (!base.XExEgWAUoYDZHOcZKsQgKkhupxolA(P_0))
			{
				return false;
			}
			if (EqKRrgfXShRrNkIvFpYuhJyERmkv is IGetSetEnabled)
			{
				(EqKRrgfXShRrNkIvFpYuhJyERmkv as IGetSetEnabled).enabled = P_0;
			}
			return true;
		}

		private bool pwAeYUZnrusCsIvIDOtIoLanBmSD(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[306]];
				P_1 = buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[308]];
				P_1 = buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[310]];
				P_1 = buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[304]];
				P_1 = buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[303]];
				return true;
			default:
				return false;
			}
		}

		private void cVlksmZnFDkggAaOzLcwKgiUposR()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[GDEAsiRaWYwSbDPqBIGwuWAJkXXl[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			WnWiFDTbWoAgUfxHmQdKsYXSPxVP = modifierKeyFlags;
			dqOJytbnGEkrILKWgwwQdmDFKAfN = RdxtctnxchnmSejZFVqBjXtRBpjb(modifierKeyFlags);
		}

		private string sHHAgZrPFlTcUDEXkthrWnjeRoYl(ModifierKey P_0, bool P_1)
		{
			if (P_0 == ModifierKey.None)
			{
				return string.Empty;
			}
			ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
			string result = modifierKeyInfo.GetName(P_1);
			if (!LocalizationManager.isEnabled)
			{
				return result;
			}
			if (!BEWLWpoHgPTHNeWNBqvZaUYDVsAB.TryGetValue((int)P_0, out var value))
			{
				return result;
			}
			string result2;
			if (P_1)
			{
				if (value.tXkBNZLbhNWzAGXgfCKRTDClDOYL != null && VHsPaJiGdLNhwGxEOjzRNBMPFOIJ(value.tXkBNZLbhNWzAGXgfCKRTDClDOYL, modifierKeyInfo.shortKey, modifierKeyInfo.shortName, LJmpCFrENABMhmUxmGaTconkDyoGA.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				if (value.lyATzGIeVgoDvlAQrmADUpaADOwq != null && VHsPaJiGdLNhwGxEOjzRNBMPFOIJ(value.lyATzGIeVgoDvlAQrmADUpaADOwq, modifierKeyInfo.longKey, modifierKeyInfo.longName, LJmpCFrENABMhmUxmGaTconkDyoGA.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				return result;
			}
			if (value.lyATzGIeVgoDvlAQrmADUpaADOwq == null)
			{
				return result;
			}
			VHsPaJiGdLNhwGxEOjzRNBMPFOIJ(value.lyATzGIeVgoDvlAQrmADUpaADOwq, modifierKeyInfo.longKey, modifierKeyInfo.longName, LJmpCFrENABMhmUxmGaTconkDyoGA.deviceLocalizationInfo, out result2);
			return result2;
		}

		private static bool VHsPaJiGdLNhwGxEOjzRNBMPFOIJ(ihvpemfLZpBtYcDmDFrxrfBcDorG P_0, string P_1, string P_2, DeviceLocalizationInfo P_3, out string P_4)
		{
			LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = iiskKgDbWxOwEGnzrXYHgovqbhjF.VhENRjIxLhqhGsEQNdNJljKDGOp(P_0.sTmyJNtmOyAYuQrhzXjiKIHKIkkCA, P_1, "controller", P_2, P_3, hhwQItrOtauBvPHQAFLgRDRQAhcP.Keyboard, -1, AxisRange.Full, -1, out P_4);
			if ((getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				P_0.DmvsVranThEksPhqxehxVlazJTbD = (getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized) != 0;
			}
			return P_0.DmvsVranThEksPhqxehxVlazJTbD;
		}

		private object ODSXxHYgqJaCsEzSAUmzUZGVPjFk(ModifierKey P_0)
		{
			if (P_0 == ModifierKey.None)
			{
				return null;
			}
			ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
			if (!GlyphManager.isEnabled)
			{
				return null;
			}
			if (!PfCIgVIhXtlPcINCEYZbxdLSleJPc.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (jfQjVSATkEzFNCrSFiUPEnPqHFyHA(value, modifierKeyInfo.longKey, LJmpCFrENABMhmUxmGaTconkDyoGA.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private string IiHNkrXHZbqCmOjQiAwYbETaFhEg(ModifierKey P_0)
		{
			if (P_0 == ModifierKey.None)
			{
				return null;
			}
			ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
			if (!GlyphManager.isEnabled)
			{
				return null;
			}
			if (!PfCIgVIhXtlPcINCEYZbxdLSleJPc.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (bkXlRQUcAJDwXBdfNdwaCzBoiXub(value, modifierKeyInfo.longKey, LJmpCFrENABMhmUxmGaTconkDyoGA.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private static bool jfQjVSATkEzFNCrSFiUPEnPqHFyHA(DuzcGKeeKxJTFNXSnXTeBsgjGYsG P_0, string P_1, DeviceLocalizationInfo P_2, out object P_3)
		{
			GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = ACofeCgEBALSsUvdlTeHnDWjlznoA.vflqRqCSdpSgIqOMfianbTukarQtA(P_0.rJdzzWXjXskzhCNerKMJZZcCrAKk, P_1, "controller", P_2, hhwQItrOtauBvPHQAFLgRDRQAhcP.Keyboard, -1, AxisRange.Full, -1, out P_3);
			if ((getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.Changed) != GlyphManager.GetAndUpdateGlyphResultFlags.None)
			{
				P_0.PMkpuKXkzYjPmbmNWNfHWLotELjR = (getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.JustGot) != 0;
			}
			return P_0.PMkpuKXkzYjPmbmNWNfHWLotELjR;
		}

		private static bool bkXlRQUcAJDwXBdfNdwaCzBoiXub(DuzcGKeeKxJTFNXSnXTeBsgjGYsG P_0, string P_1, DeviceLocalizationInfo P_2, out string P_3)
		{
			object obj;
			bool result = jfQjVSATkEzFNCrSFiUPEnPqHFyHA(P_0, P_1, P_2, out obj);
			P_3 = P_0.rJdzzWXjXskzhCNerKMJZZcCrAKk.cachedKey;
			return result;
		}

		[CompilerGenerated]
		private void VjIGrOOiodrbeKEYvYKpMQmVwPMF()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				sHHAgZrPFlTcUDEXkthrWnjeRoYl(values[i], true);
				sHHAgZrPFlTcUDEXkthrWnjeRoYl(values[i], false);
			}
		}

		[CompilerGenerated]
		private void KwmAHhchHTDueSSjbKpzfLhBmEtsb()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				ODSXxHYgqJaCsEzSAUmzUZGVPjFk(values[i]);
			}
		}
	}
}
