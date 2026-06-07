using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedKeyboardSource : CustomPlatformUnifiedControllerSource
	{
		public sealed class KeyPropertyMap
		{
			public struct Key
			{
				public KeyboardKeyCode keyCode;

				public string label;
			}

			private IndexedDictionary<int, string> vaIEghPAboHwIPNgqwTCZGekbqwy;

			private bool mdMyYyAAXDzSYarCRutVucoZBWyn;

			internal bool OnRxreGlEgGwfgwKpUVBLuxSmtnQ
			{
				get
				{
					return mdMyYyAAXDzSYarCRutVucoZBWyn;
				}
				set
				{
					mdMyYyAAXDzSYarCRutVucoZBWyn = flag;
				}
			}

			public KeyPropertyMap()
			{
				vaIEghPAboHwIPNgqwTCZGekbqwy = new IndexedDictionary<int, string>();
				IList<int> keyboardKeyValues = Consts.keyboardKeyValues;
				IList<string> keyboardKeyNames = Consts.keyboardKeyNames;
				for (int i = 0; i < 132; i++)
				{
					vaIEghPAboHwIPNgqwTCZGekbqwy.Add(keyboardKeyValues[i], keyboardKeyNames[i]);
				}
				mdMyYyAAXDzSYarCRutVucoZBWyn = true;
			}

			public KeyPropertyMap(KeyPropertyMap P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("other");
				}
				vaIEghPAboHwIPNgqwTCZGekbqwy = new IndexedDictionary<int, string>(P_0.vaIEghPAboHwIPNgqwTCZGekbqwy);
				mdMyYyAAXDzSYarCRutVucoZBWyn = true;
			}

			public Key Get(KeyboardKeyCode keyCode)
			{
				if (!vaIEghPAboHwIPNgqwTCZGekbqwy.TryGetValue((int)keyCode, out var value))
				{
					return default(Key);
				}
				return new Key
				{
					keyCode = keyCode,
					label = value
				};
			}

			public void Set(Key key)
			{
				vaIEghPAboHwIPNgqwTCZGekbqwy.SetValue((int)key.keyCode, key.label);
				mdMyYyAAXDzSYarCRutVucoZBWyn = true;
			}

			public Key[] Get()
			{
				Key[] array = new Key[vaIEghPAboHwIPNgqwTCZGekbqwy.Count];
				int count = vaIEghPAboHwIPNgqwTCZGekbqwy.Count;
				for (int i = 0; i < count; i++)
				{
					array[i] = new Key
					{
						keyCode = (KeyboardKeyCode)vaIEghPAboHwIPNgqwTCZGekbqwy.GetKeyAt(i),
						label = vaIEghPAboHwIPNgqwTCZGekbqwy[i]
					};
				}
				return array;
			}

			public void Set(ICollection<Key> keys)
			{
				if (keys == null)
				{
					throw new ArgumentNullException("keys");
				}
				foreach (Key key in keys)
				{
					vaIEghPAboHwIPNgqwTCZGekbqwy.SetValue((int)key.keyCode, key.label);
				}
				mdMyYyAAXDzSYarCRutVucoZBWyn = true;
			}
		}

		private KeyPropertyMap aNIXKEtFeveOvidsOcRbdheCCEgqA;

		public KeyPropertyMap keyPropertyMap
		{
			get
			{
				if (aNIXKEtFeveOvidsOcRbdheCCEgqA == null)
				{
					aNIXKEtFeveOvidsOcRbdheCCEgqA = new KeyPropertyMap();
				}
				return aNIXKEtFeveOvidsOcRbdheCCEgqA;
			}
			set
			{
				if (value == null)
				{
					value = new KeyPropertyMap();
				}
				aNIXKEtFeveOvidsOcRbdheCCEgqA = value;
				jTeKKYQPCHdKwFeKSKEpFcCmePJ();
			}
		}

		public CustomPlatformUnifiedKeyboardSource()
			: base(0, Consts._keyboardKeyValues.Length)
		{
		}

		protected void SetKeyValue(KeyboardKeyCode keyCode, bool value)
		{
			int buttonIndex = ReInput.controllers.Keyboard.GetButtonIndex(keyCode);
			if (buttonIndex >= 0)
			{
				SetButtonValue(buttonIndex, value);
			}
		}

		internal virtual void zYKZqdUJsGGCsagimbdiopOSNabN()
		{
			base.TIKdBwxaeOhaemHAHHwQGGsEYTfS();
			if (aNIXKEtFeveOvidsOcRbdheCCEgqA != null && aNIXKEtFeveOvidsOcRbdheCCEgqA.OnRxreGlEgGwfgwKpUVBLuxSmtnQ)
			{
				jTeKKYQPCHdKwFeKSKEpFcCmePJ();
			}
		}

		private void jTeKKYQPCHdKwFeKSKEpFcCmePJ()
		{
			HardwareControllerMap_Game qfUAjoZEkUJBMcgOHFRLtyQzKjdR = ReInput.controllers.Keyboard.qfUAjoZEkUJBMcgOHFRLtyQzKjdR;
			int totalCount = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.elementIdentifiers.TotalCount;
			for (int i = 0; i < totalCount; i++)
			{
				if (qfUAjoZEkUJBMcgOHFRLtyQzKjdR.elementIdentifiers.TryGetValueAt(i, out var value))
				{
					KeyboardKeyCode keyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid];
					string label = aNIXKEtFeveOvidsOcRbdheCCEgqA.Get(keyCode).label;
					if (!string.Equals(value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, label))
					{
						value.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename = label;
					}
				}
			}
			aNIXKEtFeveOvidsOcRbdheCCEgqA.OnRxreGlEgGwfgwKpUVBLuxSmtnQ = false;
		}
	}
}
