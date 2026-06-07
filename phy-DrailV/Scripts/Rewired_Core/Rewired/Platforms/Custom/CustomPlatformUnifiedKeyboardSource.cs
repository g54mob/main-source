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

			private IndexedDictionary<int, string> KetGkzwinelAvpNwKhWFMuQhnwdM;

			private bool tZvLCwVIauCmGlVTyGfCgZaucgIpA;

			internal bool pLqmriLMEpPIMhriuSqZUCTalLLe
			{
				get
				{
					return tZvLCwVIauCmGlVTyGfCgZaucgIpA;
				}
				set
				{
					tZvLCwVIauCmGlVTyGfCgZaucgIpA = flag;
				}
			}

			public KeyPropertyMap()
			{
				KetGkzwinelAvpNwKhWFMuQhnwdM = new IndexedDictionary<int, string>();
				IList<int> keyboardKeyValues = Consts.keyboardKeyValues;
				IList<string> keyboardKeyNames = Consts.keyboardKeyNames;
				for (int i = 0; i < 132; i++)
				{
					KetGkzwinelAvpNwKhWFMuQhnwdM.Add(keyboardKeyValues[i], keyboardKeyNames[i]);
				}
				tZvLCwVIauCmGlVTyGfCgZaucgIpA = true;
			}

			public KeyPropertyMap(KeyPropertyMap P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("other");
				}
				KetGkzwinelAvpNwKhWFMuQhnwdM = new IndexedDictionary<int, string>(P_0.KetGkzwinelAvpNwKhWFMuQhnwdM);
				tZvLCwVIauCmGlVTyGfCgZaucgIpA = true;
			}

			public Key Get(KeyboardKeyCode keyCode)
			{
				if (!KetGkzwinelAvpNwKhWFMuQhnwdM.TryGetValue((int)keyCode, out var value))
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
				KetGkzwinelAvpNwKhWFMuQhnwdM.SetValue((int)key.keyCode, key.label);
				tZvLCwVIauCmGlVTyGfCgZaucgIpA = true;
			}

			public Key[] Get()
			{
				Key[] array = new Key[KetGkzwinelAvpNwKhWFMuQhnwdM.Count];
				int count = KetGkzwinelAvpNwKhWFMuQhnwdM.Count;
				for (int i = 0; i < count; i++)
				{
					array[i] = new Key
					{
						keyCode = (KeyboardKeyCode)KetGkzwinelAvpNwKhWFMuQhnwdM.GetKeyAt(i),
						label = KetGkzwinelAvpNwKhWFMuQhnwdM[i]
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
					KetGkzwinelAvpNwKhWFMuQhnwdM.SetValue((int)key.keyCode, key.label);
				}
				tZvLCwVIauCmGlVTyGfCgZaucgIpA = true;
			}
		}

		private KeyPropertyMap oGTxFJoYZDdtHnHkHVuNizFWOCSK;

		public KeyPropertyMap keyPropertyMap
		{
			get
			{
				if (oGTxFJoYZDdtHnHkHVuNizFWOCSK == null)
				{
					oGTxFJoYZDdtHnHkHVuNizFWOCSK = new KeyPropertyMap();
				}
				return oGTxFJoYZDdtHnHkHVuNizFWOCSK;
			}
			set
			{
				if (value == null)
				{
					value = new KeyPropertyMap();
				}
				oGTxFJoYZDdtHnHkHVuNizFWOCSK = value;
				jGYBtKcIbpOPOjOdxwBNGaoKLUYzA();
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

		internal override void cwOErHdoGDKEsFmyGHskstVlrOhbB()
		{
			base.cwOErHdoGDKEsFmyGHskstVlrOhbB();
			if (oGTxFJoYZDdtHnHkHVuNizFWOCSK != null && oGTxFJoYZDdtHnHkHVuNizFWOCSK.pLqmriLMEpPIMhriuSqZUCTalLLe)
			{
				jGYBtKcIbpOPOjOdxwBNGaoKLUYzA();
			}
		}

		private void jGYBtKcIbpOPOjOdxwBNGaoKLUYzA()
		{
			HardwareControllerMap_Game aWCbIECppuLDtCThiwONsElGeIEub = ReInput.controllers.Keyboard.AWCbIECppuLDtCThiwONsElGeIEub;
			int totalCount = aWCbIECppuLDtCThiwONsElGeIEub.elementIdentifiers.TotalCount;
			for (int i = 0; i < totalCount; i++)
			{
				if (aWCbIECppuLDtCThiwONsElGeIEub.elementIdentifiers.TryGetValueAt(i, out var value))
				{
					KeyboardKeyCode keyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[value.id];
					string label = oGTxFJoYZDdtHnHkHVuNizFWOCSK.Get(keyCode).label;
					if (!string.Equals(value.name, label))
					{
						value.name = label;
					}
				}
			}
			oGTxFJoYZDdtHnHkHVuNizFWOCSK.pLqmriLMEpPIMhriuSqZUCTalLLe = false;
		}
	}
}
