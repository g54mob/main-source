using System;
using System.Text;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class ActionElementMap
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _actionCategoryId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _actionId;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ControllerElementType _elementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _elementIdentifierId;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal AxisRange _axisRange;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal bool _invert;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal Pole _axisContribution;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal KeyboardKeyCode _keyboardKeyCode;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ModifierKey _modifierKey1;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ModifierKey _modifierKey2;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ModifierKey _modifierKey3;

		[NonSerialized]
		internal ControllerMap FcwxSEAqxlQQhiIiSEyJjkwZaAa;

		[NonSerialized]
		internal bool FnzJwrQpikWfZbmfjZhFwutJGAA = true;

		[NonSerialized]
		private string kyNQyqewsLrqXDcmgwjbeFBcFgr;

		[NonSerialized]
		internal string jKsjebElKYBNHCrAVSmYvYhecRcc;

		[NonSerialized]
		internal int ouusLSVThShOJXeTBDNomJoAhtU;

		[NonSerialized]
		internal readonly int tqPurZpByiUWRrPJKwHxxaZZua;

		[NonSerialized]
		private string MAOhYYBDLoJqDsAkhoyEDCouxuJ;

		[NonSerialized]
		private ModifierKeyFlags KEYdJniEjNqfJwfPvpCYoKEFHig;

		private static int uidCounter = 0;

		private static StringBuilder s_toStringSB;

		public int actionId
		{
			get
			{
				return _actionId;
			}
			set
			{
				if (value == _actionId)
				{
					return;
				}
				while (true)
				{
					_actionId = value;
					if (!Application.isPlaying)
					{
						break;
					}
					zrnaxNhDeSQHhxssshFKwWxPjNK();
					int num = 387535662;
					while (true)
					{
						switch (num ^ 0x1719532E)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = 387535663;
					}
				}
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return _elementType;
			}
			internal set
			{
				_elementType = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return _elementIdentifierId;
			}
			set
			{
				if (_elementIdentifierId == value)
				{
					return;
				}
				Controller controller = default(Controller);
				while (true)
				{
					_elementIdentifierId = value;
					int num = -1708832652;
					while (true)
					{
						switch (num ^ -1708832651)
						{
						case 0:
							num = -1708832655;
							continue;
						default:
							return;
						case 4:
							break;
						case 2:
						{
							Controller.Element elementById = controller.GetElementById(value);
							if (elementById != null && elementById.type != _elementType)
							{
								FcwxSEAqxlQQhiIiSEyJjkwZaAa.oxrBoullAMNVxCxvjekQmHcGjxP(tqPurZpByiUWRrPJKwHxxaZZua, elementById.type);
								num = -1708832656;
								continue;
							}
							goto case 5;
						}
						case 5:
							if (Application.isPlaying)
							{
								ENoWuIxoJpbiEHGViijOxvkWIbli(false);
								num = -1708832650;
								continue;
							}
							return;
						case 1:
							if (Application.isPlaying && FcwxSEAqxlQQhiIiSEyJjkwZaAa != null)
							{
								controller = ReInput.akUdmKMbrqFLXkjqdKLUZOPTArx.lRKToUyChtEIyMHppndqwlmeZVh(FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType, FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerId, true);
								int num2;
								if (controller != null)
								{
									num = -1708832649;
									num2 = num;
								}
								else
								{
									num = -1708832656;
									num2 = num;
								}
								continue;
							}
							goto case 5;
						case 3:
							return;
						}
						break;
					}
				}
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return _axisRange;
			}
			set
			{
				if (_axisRange == value)
				{
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (_elementType == ControllerElementType.Axis)
					{
						num = 468673317;
						num2 = num;
					}
					else
					{
						num = 468673313;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x1BEF6320)
						{
						case 0:
							num = 468673316;
							continue;
						default:
							return;
						case 5:
							_axisRange = value;
							if (Application.isPlaying)
							{
								ENoWuIxoJpbiEHGViijOxvkWIbli(false);
								num = 468673315;
								continue;
							}
							return;
						case 1:
							if (Application.isPlaying)
							{
								Logger.LogWarning("You cannot change AxisRange of a non-Axis mapping.");
								num = 468673314;
								continue;
							}
							goto case 5;
						case 2:
							return;
						case 4:
							break;
						case 3:
							return;
						}
						break;
					}
				}
			}
		}

		public bool invert
		{
			get
			{
				return _invert;
			}
			set
			{
				_invert = value;
			}
		}

		public Pole axisContribution
		{
			get
			{
				return _axisContribution;
			}
			set
			{
				if (_axisContribution == value)
				{
					return;
				}
				while (true)
				{
					_axisContribution = value;
					if (!Application.isPlaying)
					{
						break;
					}
					ENoWuIxoJpbiEHGViijOxvkWIbli(false);
					int num = -1415809830;
					while (true)
					{
						switch (num ^ -1415809829)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = -1415809831;
					}
				}
			}
		}

		public KeyboardKeyCode keyboardKeyCode
		{
			get
			{
				return _keyboardKeyCode;
			}
			set
			{
				if (_keyboardKeyCode == value)
				{
					goto IL_0009;
				}
				goto IL_0068;
				IL_0009:
				int num = 1759005000;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x68D84949)
					{
					case 5:
						break;
					default:
						return;
					case 1:
						return;
					case 4:
						goto IL_003b;
					case 0:
						ENoWuIxoJpbiEHGViijOxvkWIbli(true);
						num = 1759005002;
						continue;
					case 2:
						goto IL_0068;
					case 3:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_003b:
				_keyboardKeyCode = value;
				int num2;
				if (Application.isPlaying)
				{
					num = 1759005001;
					num2 = num;
				}
				else
				{
					num = 1759005002;
					num2 = num;
				}
				goto IL_000e;
				IL_0068:
				if (FcwxSEAqxlQQhiIiSEyJjkwZaAa != null && FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set the key code on a non-Keyboard mapping.");
					return;
				}
				goto IL_003b;
			}
		}

		public ModifierKey modifierKey1
		{
			get
			{
				return _modifierKey1;
			}
			set
			{
				if (_modifierKey1 == value)
				{
					return;
				}
				while (FcwxSEAqxlQQhiIiSEyJjkwZaAa == null || FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType == ControllerType.Keyboard)
				{
					while (true)
					{
						IL_006b:
						_modifierKey1 = value;
						int num;
						int num2;
						if (Application.isPlaying)
						{
							num = -2069118873;
							num2 = num;
						}
						else
						{
							num = -2069118878;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -2069118877)
							{
							case 0:
								num = -2069118880;
								continue;
							default:
								return;
							case 3:
								break;
							case 4:
								jcbuOQFDzxESUfImeQizRwqhadk();
								ENoWuIxoJpbiEHGViijOxvkWIbli(true);
								num = -2069118878;
								continue;
							case 2:
								goto IL_006b;
							case 1:
								return;
							}
							break;
						}
						break;
					}
				}
				Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
			}
		}

		public ModifierKey modifierKey2
		{
			get
			{
				return _modifierKey2;
			}
			set
			{
				if (_modifierKey2 == value)
				{
					return;
				}
				while (true)
				{
					int num;
					if (FcwxSEAqxlQQhiIiSEyJjkwZaAa != null && FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType != ControllerType.Keyboard)
					{
						Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
						num = 294106962;
						goto IL_000f;
					}
					goto IL_007d;
					IL_007d:
					_modifierKey2 = value;
					num = 294106967;
					goto IL_000f;
					IL_000f:
					while (true)
					{
						switch (num ^ 0x1187B756)
						{
						case 3:
							num = 294106964;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							if (Application.isPlaying)
							{
								jcbuOQFDzxESUfImeQizRwqhadk();
								ENoWuIxoJpbiEHGViijOxvkWIbli(true);
								num = 294106963;
								continue;
							}
							return;
						case 4:
							return;
						case 0:
							goto IL_007d;
						case 5:
							return;
						}
						break;
					}
				}
			}
		}

		public ModifierKey modifierKey3
		{
			get
			{
				return _modifierKey3;
			}
			set
			{
				if (_modifierKey3 == value)
				{
					return;
				}
				while (FcwxSEAqxlQQhiIiSEyJjkwZaAa == null || FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType == ControllerType.Keyboard)
				{
					while (true)
					{
						IL_0057:
						_modifierKey3 = value;
						if (!Application.isPlaying)
						{
							return;
						}
						jcbuOQFDzxESUfImeQizRwqhadk();
						int num = -732674942;
						while (true)
						{
							switch (num ^ -732674938)
							{
							case 0:
								num = -732674937;
								continue;
							default:
								return;
							case 1:
								break;
							case 2:
								goto IL_0057;
							case 4:
								ENoWuIxoJpbiEHGViijOxvkWIbli(true);
								num = -732674939;
								continue;
							case 3:
								return;
							}
							break;
						}
						break;
					}
				}
				Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
			}
		}

		public AxisType axisType
		{
			get
			{
				if (_elementType != ControllerElementType.Axis)
				{
					return AxisType.None;
				}
				if (_axisRange == AxisRange.Full)
				{
					return AxisType.Normal;
				}
				return AxisType.Split;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
				modifierKeyFlags |= Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey1);
				modifierKeyFlags |= Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey2);
				return modifierKeyFlags | Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey3);
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return Keyboard.KeyboardKeyCodeToKeyCode(_keyboardKeyCode);
			}
			set
			{
				keyboardKeyCode = Keyboard.KeyCodeToKeyboardKeyCode(value);
			}
		}

		public bool hasModifiers
		{
			get
			{
				if (_keyboardKeyCode == KeyboardKeyCode.None)
				{
					goto IL_0008;
				}
				int num;
				if (_modifierKey1 == ModifierKey.None)
				{
					int num2;
					if (_modifierKey2 == ModifierKey.None)
					{
						num = -1420893962;
						num2 = num;
					}
					else
					{
						num = -1420893964;
						num2 = num;
					}
					goto IL_000d;
				}
				goto IL_005c;
				IL_000d:
				while (true)
				{
					switch (num ^ -1420893962)
					{
					case 3:
						break;
					case 1:
						return false;
					case 0:
						goto IL_004d;
					default:
						goto IL_005c;
					}
					break;
					IL_004d:
					if (_modifierKey3 != ModifierKey.None)
					{
						num = -1420893964;
						continue;
					}
					return false;
				}
				goto IL_0008;
				IL_0008:
				num = -1420893961;
				goto IL_000d;
				IL_005c:
				return true;
			}
		}

		public ControllerMap controllerMap => FcwxSEAqxlQQhiIiSEyJjkwZaAa;

		public bool enabled
		{
			get
			{
				return FnzJwrQpikWfZbmfjZhFwutJGAA;
			}
			set
			{
				FnzJwrQpikWfZbmfjZhFwutJGAA = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				if (FcwxSEAqxlQQhiIiSEyJjkwZaAa == null || FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType != ControllerType.Keyboard)
				{
					return kyNQyqewsLrqXDcmgwjbeFBcFgr;
				}
				return wueqfXAZLaYjqFZjPBaDrsMHUFd();
			}
		}

		public string actionDescriptiveName => jKsjebElKYBNHCrAVSmYvYhecRcc;

		public int elementIndex => ouusLSVThShOJXeTBDNomJoAhtU;

		public int id => tqPurZpByiUWRrPJKwHxxaZZua;

		private bool isKeyboardMap
		{
			get
			{
				if (FcwxSEAqxlQQhiIiSEyJjkwZaAa != null)
				{
					return FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType == ControllerType.Keyboard;
				}
				return false;
			}
		}

		private static int nextUid
		{
			get
			{
				int result = uidCounter;
				if (uidCounter == int.MaxValue)
				{
					goto IL_0012;
				}
				goto IL_0041;
				IL_0012:
				int num = 1752247986;
				goto IL_0017;
				IL_0017:
				while (true)
				{
					switch (num ^ 0x68712EB3)
					{
					case 2:
						break;
					case 1:
						uidCounter = 0;
						num = 1752247984;
						continue;
					case 0:
						goto IL_0041;
					default:
						return result;
					}
					break;
				}
				goto IL_0012;
				IL_0041:
				uidCounter++;
				num = 1752247984;
				goto IL_0017;
			}
		}

		internal static bool nQrkQvPPbIngfQlYzgfwckugskm(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			int num;
			if (P_0._actionId != -1)
			{
				num = 2047928531;
				goto IL_0008;
			}
			goto IL_0052;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x7A10E8D0)
				{
				case 0:
					break;
				case 2:
					return false;
				case 3:
					goto IL_0037;
				default:
					return false;
				}
				break;
				IL_0037:
				if (!ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QUzJIwsyLBGiiDjdziRDeDUvrEq(P_0._actionId))
				{
					num = 2047928529;
					continue;
				}
				goto IL_0052;
			}
			goto IL_0003;
			IL_0052:
			return true;
			IL_0003:
			num = 2047928530;
			goto IL_0008;
		}

		internal static void suomRVbxJkVEMzejgdnCBIIjpE(ActionElementMap P_0, ActionElementMap P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			while (true)
			{
				int num;
				int num2;
				if (P_1 == null)
				{
					num = 2025614219;
					num2 = num;
				}
				else
				{
					num = 2025614223;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x78BC6B8A)
					{
					case 4:
						num = 2025614216;
						continue;
					case 0:
						P_1._axisContribution = P_0._axisContribution;
						P_1._keyboardKeyCode = P_0._keyboardKeyCode;
						P_1._modifierKey1 = P_0._modifierKey1;
						P_1._modifierKey2 = P_0._modifierKey2;
						P_1._modifierKey3 = P_0._modifierKey3;
						P_1.FcwxSEAqxlQQhiIiSEyJjkwZaAa = P_0.FcwxSEAqxlQQhiIiSEyJjkwZaAa;
						num = 2025614221;
						continue;
					case 5:
						P_1._actionId = P_0._actionId;
						P_1._actionCategoryId = P_0._actionCategoryId;
						P_1._elementType = P_0._elementType;
						num = 2025614220;
						continue;
					case 7:
						P_1.kyNQyqewsLrqXDcmgwjbeFBcFgr = P_0.kyNQyqewsLrqXDcmgwjbeFBcFgr;
						num = 2025614210;
						continue;
					case 2:
						break;
					case 3:
						P_1._axisRange = P_0._axisRange;
						P_1._invert = P_0._invert;
						num = 2025614218;
						continue;
					case 6:
						P_1._elementIdentifierId = P_0._elementIdentifierId;
						num = 2025614217;
						continue;
					case 1:
						throw new ArgumentNullException("destination");
					default:
						P_1.ouusLSVThShOJXeTBDNomJoAhtU = P_0.ouusLSVThShOJXeTBDNomJoAhtU;
						P_1.FnzJwrQpikWfZbmfjZhFwutJGAA = P_0.FnzJwrQpikWfZbmfjZhFwutJGAA;
						P_1.jKsjebElKYBNHCrAVSmYvYhecRcc = P_0.jKsjebElKYBNHCrAVSmYvYhecRcc;
						return;
					}
					break;
				}
			}
		}

		public ActionElementMap()
		{
			tqPurZpByiUWRrPJKwHxxaZZua = nextUid;
			_actionId = -1;
			_elementIdentifierId = -1;
			FnzJwrQpikWfZbmfjZhFwutJGAA = true;
		}

		public ActionElementMap(ActionElementMap map)
			: this()
		{
			suomRVbxJkVEMzejgdnCBIIjpE(map, this);
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, int elementIdentifierId)
			: this()
		{
			_actionId = actionId;
			_elementType = elementType;
			_elementIdentifierId = elementIdentifierId;
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, int elementIdentifierId, Pole axisContribution, AxisRange axisRange)
			: this()
		{
			_actionId = actionId;
			_elementType = elementType;
			_elementIdentifierId = elementIdentifierId;
			_axisContribution = axisContribution;
			_axisRange = axisRange;
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, int elementIdentifierId, Pole axisContribution, AxisRange axisRange, bool invert)
			: this()
		{
			while (true)
			{
				int num = -1427816878;
				while (true)
				{
					switch (num ^ -1427816880)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						_elementIdentifierId = elementIdentifierId;
						_axisContribution = axisContribution;
						_axisRange = axisRange;
						_invert = invert;
						return;
					}
					break;
					IL_0024:
					_actionId = actionId;
					_elementType = elementType;
					num = -1427816879;
				}
			}
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, Pole axisContribution, KeyboardKeyCode keyboardKeyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
			: this()
		{
			_actionId = actionId;
			_elementType = elementType;
			_axisContribution = axisContribution;
			_keyboardKeyCode = keyboardKeyCode;
			_modifierKey1 = modifierKey1;
			_modifierKey2 = modifierKey2;
			_modifierKey3 = modifierKey3;
			psyGyXcdIoxDtsumpEoOpeuUMVQG();
		}

		public bool CheckForAssignmentConflict(ElementAssignment elementAssignment)
		{
			if (!gzusTFvKqJnwoNpIYMjOFRWPrFT(elementAssignment.type))
			{
				return false;
			}
			if (!isKeyboardMap)
			{
				goto IL_0019;
			}
			goto IL_004e;
			IL_004e:
			KeyCode keyCode = elementAssignment.keyboardKey;
			int num;
			int num2;
			if (keyCode != KeyCode.None)
			{
				num = -547421081;
				num2 = num;
			}
			else
			{
				num = -547421082;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = -547421087;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -547421083)
				{
				case 0:
					break;
				case 4:
					goto IL_003f;
				case 1:
					goto IL_004e;
				case 3:
					keyCode = ReInput.akUdmKMbrqFLXkjqdKLUZOPTArx.Keyboard.GetKeyCodeById(elementAssignment.elementIdentifierId);
					num = -547421081;
					continue;
				default:
					return YAcPRNplUJzFvkUvcxdkWapQziT(Keyboard.KeyCodeToKeyboardKeyCode(keyCode), elementAssignment.modifierKeyFlags);
				}
				break;
				IL_003f:
				if (_keyboardKeyCode != KeyboardKeyCode.None)
				{
					num = -547421084;
					continue;
				}
				return qFLtgYctbdFNOOEkPYHsPdNcHnS(elementAssignment.elementIdentifierId, elementAssignment.axisRange);
			}
			goto IL_0019;
		}

		public bool CheckForAssignmentConflict(ActionElementMap elementMap)
		{
			if (elementMap == null)
			{
				goto IL_0025;
			}
			if (elementMap == this)
			{
				goto IL_0007;
			}
			if (_elementType != elementMap._elementType)
			{
				return false;
			}
			int num;
			if (!isKeyboardMap)
			{
				if (_keyboardKeyCode != KeyboardKeyCode.None)
				{
					num = -1018290511;
					goto IL_000c;
				}
				return qFLtgYctbdFNOOEkPYHsPdNcHnS(elementMap._elementIdentifierId, elementMap._axisRange);
			}
			goto IL_004e;
			IL_004e:
			return YAcPRNplUJzFvkUvcxdkWapQziT(elementMap._keyboardKeyCode, elementMap.modifierKeyFlags);
			IL_0025:
			return false;
			IL_0007:
			num = -1018290512;
			goto IL_000c;
			IL_000c:
			switch (num ^ -1018290511)
			{
			case 2:
				break;
			case 1:
				goto IL_0025;
			default:
				goto IL_004e;
			}
			goto IL_0007;
		}

		public bool ShowInField(AxisRange fieldActionRange)
		{
			if (!ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QUzJIwsyLBGiiDjdziRDeDUvrEq(_actionId))
			{
				goto IL_0012;
			}
			int num;
			if (fieldActionRange == AxisRange.Full)
			{
				num = -1949700398;
			}
			else
			{
				if (elementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
				{
					return false;
				}
				if (ReInput.lUCgcEIquFfuykgBneGrfARQlcR.lwbVaAtXlFYOutHegWQNuVVFpCl(_actionId).type != InputActionType.Axis)
				{
					if (axisContribution != axisContribution)
					{
						return false;
					}
					goto IL_00fe;
				}
				if (fieldActionRange != AxisRange.Positive)
				{
					goto IL_00d5;
				}
				num = -1949700400;
			}
			goto IL_0017;
			IL_00fe:
			return true;
			IL_00cb:
			if (axisContribution != Pole.Positive)
			{
				return false;
			}
			goto IL_00d5;
			IL_0017:
			while (true)
			{
				switch (num ^ -1949700398)
				{
				case 6:
					break;
				case 1:
					return false;
				case 4:
					return false;
				case 3:
					return false;
				case 0:
					goto IL_00b1;
				case 2:
					goto IL_00cb;
				default:
					goto IL_00e3;
				}
				break;
				IL_00e3:
				if (axisContribution != Pole.Negative)
				{
					return false;
				}
				goto IL_00fe;
				IL_00b1:
				if (_elementType != ControllerElementType.Axis)
				{
					if (_elementType == ControllerElementType.Button && ReInput.lUCgcEIquFfuykgBneGrfARQlcR.lwbVaAtXlFYOutHegWQNuVVFpCl(_actionId).type == InputActionType.Axis)
					{
						num = -1949700394;
						continue;
					}
				}
				else if (axisRange != AxisRange.Full)
				{
					num = -1949700399;
					continue;
				}
				goto IL_00fe;
			}
			goto IL_0012;
			IL_0012:
			num = -1949700397;
			goto IL_0017;
			IL_00d5:
			if (fieldActionRange == AxisRange.Negative)
			{
				num = -1949700393;
				goto IL_0017;
			}
			goto IL_00fe;
		}

		public bool IsTarget(ControllerElementTarget elementTarget)
		{
			TtePFCKBdNmQRluqYJdgMTWVuTZ ttePFCKBdNmQRluqYJdgMTWVuTZ = TtePFCKBdNmQRluqYJdgMTWVuTZ.axyDWBaevBEdcNutlzYJvrYkUXO(elementTarget);
			bool result = IsTarget(ttePFCKBdNmQRluqYJdgMTWVuTZ);
			TtePFCKBdNmQRluqYJdgMTWVuTZ.nUqfikRMgdyVbwPofFMThwkULhhr(ttePFCKBdNmQRluqYJdgMTWVuTZ);
			return result;
		}

		public bool IsTarget(IControllerElementTarget elementTarget)
		{
			if (elementTarget == null)
			{
				return false;
			}
			if (FcwxSEAqxlQQhiIiSEyJjkwZaAa != null)
			{
				goto IL_000d;
			}
			goto IL_006a;
			IL_006a:
			int num;
			if (_elementType != elementTarget.elementType)
			{
				num = 565816655;
				goto IL_0012;
			}
			if (_elementType == ControllerElementType.Axis)
			{
				if (_elementIdentifierId == elementTarget.elementIdentifierId)
				{
					return _axisRange == elementTarget.axisRange;
				}
				return false;
			}
			if (_elementType == ControllerElementType.Button)
			{
				return _elementIdentifierId == elementTarget.elementIdentifierId;
			}
			throw new NotImplementedException();
			IL_000d:
			num = 565816654;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x21B9AD4D)
				{
				case 0:
					break;
				case 3:
					goto IL_002f;
				case 1:
					goto IL_0068;
				default:
					return false;
				}
				break;
				IL_002f:
				Controller controller = elementTarget.controller;
				if (controller == null)
				{
					return false;
				}
				if (controller.id != FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerId)
				{
					goto IL_0068;
				}
				if (controller.type != FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType)
				{
					num = 565816652;
					continue;
				}
				goto IL_006a;
				IL_0068:
				return false;
			}
			goto IL_000d;
		}

		internal void ENoWuIxoJpbiEHGViijOxvkWIbli(ControllerMap P_0)
		{
			FcwxSEAqxlQQhiIiSEyJjkwZaAa = P_0;
			ControllerType controllerType = P_0.controllerType;
			HardwareControllerMap_Game hardwareControllerMap_Game = default(HardwareControllerMap_Game);
			while (true)
			{
				int num = 125074081;
				while (true)
				{
					HardwareControllerMap_Game obj;
					switch (num ^ 0x7747AA0)
					{
					case 2:
						break;
					case 1:
						obj = ((P_0.controller != null) ? P_0.controller.REZiFujnwfIcWniRKvMxDxhPHlx : null);
						goto IL_0042;
					default:
						ENoWuIxoJpbiEHGViijOxvkWIbli(controllerType, hardwareControllerMap_Game, controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
						return;
					}
					break;
					IL_0042:
					hardwareControllerMap_Game = obj;
					num = 125074080;
				}
			}
		}

		internal void syoLKvwgLHlzNdcGEpvMJwQYhMw(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
			FcwxSEAqxlQQhiIiSEyJjkwZaAa = P_0;
			ENoWuIxoJpbiEHGViijOxvkWIbli(P_0.controllerType, P_1, P_0.controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		private void ENoWuIxoJpbiEHGViijOxvkWIbli(bool P_0)
		{
			if (FcwxSEAqxlQQhiIiSEyJjkwZaAa != null)
			{
				ENoWuIxoJpbiEHGViijOxvkWIbli(FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType, (FcwxSEAqxlQQhiIiSEyJjkwZaAa.controller != null) ? FcwxSEAqxlQQhiIiSEyJjkwZaAa.controller.REZiFujnwfIcWniRKvMxDxhPHlx : null, P_0);
			}
		}

		private void ENoWuIxoJpbiEHGViijOxvkWIbli(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
			if (FcwxSEAqxlQQhiIiSEyJjkwZaAa == null)
			{
				return;
			}
			Keyboard keyboard = default(Keyboard);
			while (true)
			{
				int num;
				int num2;
				if (P_0 != ControllerType.Keyboard)
				{
					num = -48608414;
					num2 = num;
				}
				else
				{
					num = -48608398;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -48608414)
					{
					case 10:
						num = -48608405;
						continue;
					default:
						return;
					case 9:
						break;
					case 0:
						if (P_1 == null)
						{
							return;
						}
						goto case 1;
					case 14:
						ouusLSVThShOJXeTBDNomJoAhtU = P_1.GetButtonIndex(_elementIdentifierId);
						kyNQyqewsLrqXDcmgwjbeFBcFgr = P_1.GetElementIdentifierName(_elementIdentifierId);
						num = -48608411;
						continue;
					case 12:
						kyNQyqewsLrqXDcmgwjbeFBcFgr = P_1.GetElementIdentifierNegativeName(_elementIdentifierId);
						if (string.IsNullOrEmpty(elementIdentifierName))
						{
							kyNQyqewsLrqXDcmgwjbeFBcFgr = P_1.GetElementIdentifierName(_elementIdentifierId) + " -";
							num = -48608411;
							continue;
						}
						goto case 7;
					case 4:
						kyNQyqewsLrqXDcmgwjbeFBcFgr = P_1.GetElementIdentifierName(_elementIdentifierId) + " +";
						num = -48608411;
						continue;
					case 2:
						throw new NotImplementedException();
					case 15:
						if (axisType == AxisType.Split)
						{
							if (_axisRange == AxisRange.Positive)
							{
								kyNQyqewsLrqXDcmgwjbeFBcFgr = P_1.GetElementIdentifierPositiveName(_elementIdentifierId);
								int num3;
								if (string.IsNullOrEmpty(elementIdentifierName))
								{
									num = -48608410;
									num3 = num;
								}
								else
								{
									num = -48608411;
									num3 = num;
								}
								continue;
							}
							goto case 12;
						}
						goto case 3;
					case 13:
						goto IL_017c;
					case 11:
						WvnaZBDwqkTrSoproPBquQJFyPXf();
						num = -48608411;
						continue;
					case 7:
						zrnaxNhDeSQHhxssshFKwWxPjNK();
						num = -48608397;
						continue;
					case 3:
						kyNQyqewsLrqXDcmgwjbeFBcFgr = P_1.GetElementIdentifierName(_elementIdentifierId);
						num = -48608412;
						continue;
					case 6:
						num = -48608411;
						continue;
					case 16:
						keyboard = ReInput.controllers.Keyboard;
						if (P_2)
						{
							ouusLSVThShOJXeTBDNomJoAhtU = keyboard.GetButtonIndex(_keyboardKeyCode);
							num = -48608409;
							continue;
						}
						goto case 8;
					case 1:
						switch (_elementType)
						{
						case ControllerElementType.Button:
							break;
						case ControllerElementType.Axis:
							goto IL_017c;
						default:
							goto IL_021d;
						}
						goto case 14;
					case 5:
						psyGyXcdIoxDtsumpEoOpeuUMVQG();
						num = -48608411;
						continue;
					case 8:
						ouusLSVThShOJXeTBDNomJoAhtU = keyboard.GetButtonIndexById(_elementIdentifierId);
						num = -48608407;
						continue;
					case 17:
						return;
						IL_021d:
						num = -48608416;
						continue;
						IL_017c:
						ouusLSVThShOJXeTBDNomJoAhtU = P_1.GetAxisIndex(_elementIdentifierId);
						num = -48608403;
						continue;
					}
					break;
				}
			}
		}

		private void zrnaxNhDeSQHhxssshFKwWxPjNK()
		{
			InputAction inputAction = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.lwbVaAtXlFYOutHegWQNuVVFpCl(_actionId);
			while (true)
			{
				int num = 1524574734;
				while (true)
				{
					switch (num ^ 0x5ADF2A1C)
					{
					case 7:
						break;
					case 1:
						return;
					case 10:
						if (_elementType != ControllerElementType.Axis)
						{
							int num5;
							if (_elementType != ControllerElementType.Button)
							{
								num = 1524574750;
								num5 = num;
							}
							else
							{
								num = 1524574735;
								num5 = num;
							}
							continue;
						}
						goto case 19;
					case 12:
						return;
					case 6:
						jKsjebElKYBNHCrAVSmYvYhecRcc = inputAction.negativeDescriptiveName;
						num = 1524574736;
						continue;
					case 18:
						if (inputAction == null)
						{
							jKsjebElKYBNHCrAVSmYvYhecRcc = string.Empty;
							num = 1524574737;
							continue;
						}
						goto case 17;
					case 13:
						return;
					case 4:
						if (_elementType != ControllerElementType.Axis)
						{
							int num2;
							if (_elementType != ControllerElementType.Button)
							{
								num = 1524574732;
								num2 = num;
							}
							else
							{
								num = 1524574751;
								num2 = num;
							}
							continue;
						}
						goto case 3;
					case 15:
						jKsjebElKYBNHCrAVSmYvYhecRcc = inputAction.descriptiveName;
						return;
					case 3:
						if (_axisContribution == Pole.Positive)
						{
							jKsjebElKYBNHCrAVSmYvYhecRcc = inputAction.positiveDescriptiveName;
							return;
						}
						goto case 11;
					case 5:
						return;
					case 2:
						throw new NotImplementedException();
					case 17:
						if (inputAction.type == InputActionType.Axis)
						{
							int num3;
							if (_elementType == ControllerElementType.Axis)
							{
								num = 1524574748;
								num3 = num;
							}
							else
							{
								num = 1524574744;
								num3 = num;
							}
							continue;
						}
						goto case 14;
					case 14:
						if (inputAction.type == InputActionType.Button)
						{
							if (_elementType == ControllerElementType.Axis && _axisRange == AxisRange.Full)
							{
								jKsjebElKYBNHCrAVSmYvYhecRcc = inputAction.descriptiveName;
								num = 1524574749;
								continue;
							}
							goto case 10;
						}
						goto default;
					case 19:
						if (_axisContribution == Pole.Negative)
						{
							jKsjebElKYBNHCrAVSmYvYhecRcc = inputAction.negativeDescriptiveName;
							return;
						}
						goto case 15;
					case 0:
						if (_axisRange == AxisRange.Full)
						{
							jKsjebElKYBNHCrAVSmYvYhecRcc = inputAction.descriptiveName;
							num = 1524574745;
							continue;
						}
						goto case 4;
					case 11:
					{
						int num4;
						if (_axisContribution == Pole.Negative)
						{
							num = 1524574746;
							num4 = num;
						}
						else
						{
							num = 1524574741;
							num4 = num;
						}
						continue;
					}
					case 9:
						throw new NotImplementedException();
					case 16:
						throw new NotImplementedException();
					default:
						throw new NotImplementedException();
					}
					break;
				}
			}
		}

		private string wueqfXAZLaYjqFZjPBaDrsMHUFd()
		{
			string text = Keyboard.GetKeyName((KeyCode)_keyboardKeyCode);
			while (true)
			{
				int num = 1037696577;
				while (true)
				{
					switch (num ^ 0x3DD9FE46)
					{
					case 6:
						break;
					case 3:
					{
						int num3;
						if (_modifierKey3 == ModifierKey.None)
						{
							num = 1037696583;
							num3 = num;
						}
						else
						{
							num = 1037696579;
							num3 = num;
						}
						continue;
					}
					case 0:
						KEYdJniEjNqfJwfPvpCYoKEFHig = modifierKeyFlags;
						num = 1037696581;
						continue;
					case 2:
					{
						int num2;
						if (_modifierKey1 == ModifierKey.None)
						{
							num = 1037696590;
							num2 = num;
						}
						else
						{
							num = 1037696578;
							num2 = num;
						}
						continue;
					}
					case 1:
						if (_modifierKey2 != ModifierKey.None)
						{
							text = $"{Consts.modifierKeyShortNames[(int)_modifierKey2]} + {text}";
							num = 1037696580;
							continue;
						}
						goto case 2;
					case 7:
						if (string.Equals(text, MAOhYYBDLoJqDsAkhoyEDCouxuJ, StringComparison.Ordinal) && KEYdJniEjNqfJwfPvpCYoKEFHig == modifierKeyFlags)
						{
							return kyNQyqewsLrqXDcmgwjbeFBcFgr;
						}
						MAOhYYBDLoJqDsAkhoyEDCouxuJ = text;
						num = 1037696582;
						continue;
					case 5:
						text = $"{Consts.modifierKeyShortNames[(int)_modifierKey3]} + {text}";
						num = 1037696583;
						continue;
					case 4:
						text = $"{Consts.modifierKeyShortNames[(int)_modifierKey1]} + {text}";
						num = 1037696590;
						continue;
					default:
						kyNQyqewsLrqXDcmgwjbeFBcFgr = text;
						return text;
					}
					break;
				}
			}
		}

		internal void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			_actionCategoryId = -1;
			_actionId = -1;
			while (true)
			{
				int num = -209532556;
				while (true)
				{
					switch (num ^ -209532555)
					{
					case 0:
						break;
					case 1:
						_elementType = ControllerElementType.Axis;
						_elementIdentifierId = -1;
						num = -209532554;
						continue;
					case 4:
						_modifierKey3 = ModifierKey.None;
						FcwxSEAqxlQQhiIiSEyJjkwZaAa = null;
						FnzJwrQpikWfZbmfjZhFwutJGAA = true;
						num = -209532553;
						continue;
					case 3:
						_axisRange = AxisRange.Full;
						_invert = false;
						_axisContribution = Pole.Positive;
						_keyboardKeyCode = KeyboardKeyCode.None;
						_modifierKey1 = ModifierKey.None;
						_modifierKey2 = ModifierKey.None;
						num = -209532559;
						continue;
					default:
						kyNQyqewsLrqXDcmgwjbeFBcFgr = string.Empty;
						MAOhYYBDLoJqDsAkhoyEDCouxuJ = null;
						KEYdJniEjNqfJwfPvpCYoKEFHig = ModifierKeyFlags.None;
						ouusLSVThShOJXeTBDNomJoAhtU = -1;
						return;
					}
					break;
				}
			}
		}

		private bool YAcPRNplUJzFvkUvcxdkWapQziT(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (_elementType != ControllerElementType.Button)
			{
				return false;
			}
			if (P_0 == KeyboardKeyCode.None)
			{
				return false;
			}
			if (_keyboardKeyCode != P_0)
			{
				return false;
			}
			if (Keyboard.ConvertModifierKeyFlagsSingleToDouble(modifierKeyFlags) != Keyboard.ConvertModifierKeyFlagsSingleToDouble(P_1))
			{
				return false;
			}
			return true;
		}

		private bool qFLtgYctbdFNOOEkPYHsPdNcHnS(int P_0, AxisRange P_1)
		{
			if (_elementIdentifierId != P_0)
			{
				return false;
			}
			if (_elementType == ControllerElementType.Button)
			{
				return true;
			}
			if (_elementType == ControllerElementType.Axis)
			{
				while (true)
				{
					int num = -1344428546;
					while (true)
					{
						switch (num ^ -1344428545)
						{
						case 0:
							break;
						case 3:
							return true;
						case 2:
							return true;
						case 1:
							if (_axisRange == AxisRange.Full)
							{
								goto case 2;
							}
							if (P_1 == AxisRange.Full)
							{
								num = -1344428547;
								continue;
							}
							if (_axisRange == AxisRange.Positive && P_1 == AxisRange.Positive)
							{
								num = -1344428548;
								continue;
							}
							if (_axisRange == AxisRange.Negative)
							{
								num = -1344428549;
								continue;
							}
							goto IL_0084;
						default:
							{
								if (P_1 == AxisRange.Negative)
								{
									return true;
								}
								goto IL_0084;
							}
							IL_0084:
							return false;
						}
						break;
					}
				}
			}
			throw new NotImplementedException();
		}

		private bool gzusTFvKqJnwoNpIYMjOFRWPrFT(ElementAssignmentType P_0)
		{
			if (_elementType == ControllerElementType.Button)
			{
				if (P_0 == ElementAssignmentType.Button)
				{
					goto IL_005b;
				}
				if (P_0 == ElementAssignmentType.KeyboardKey)
				{
					goto IL_0011;
				}
				goto IL_0079;
			}
			if (_elementType != ControllerElementType.Axis)
			{
				throw new NotImplementedException();
			}
			int num;
			int num2;
			if (P_0 != ElementAssignmentType.FullAxis)
			{
				num = -866327294;
				num2 = num;
			}
			else
			{
				num = -866327296;
				num2 = num;
			}
			goto IL_0016;
			IL_0079:
			return false;
			IL_0016:
			while (true)
			{
				switch (num ^ -866327295)
				{
				case 4:
					break;
				case 1:
					return true;
				case 3:
					goto IL_0046;
				case 2:
					goto IL_005b;
				default:
					goto IL_0079;
				}
				break;
				IL_0046:
				int num3;
				if (P_0 == ElementAssignmentType.SplitAxis)
				{
					num = -866327296;
					num3 = num;
				}
				else
				{
					num = -866327295;
					num3 = num;
				}
			}
			goto IL_0011;
			IL_0011:
			num = -866327293;
			goto IL_0016;
			IL_005b:
			return true;
		}

		private void psyGyXcdIoxDtsumpEoOpeuUMVQG()
		{
			_elementIdentifierId = Keyboard.GetElementIdentifierIdByKeyCode(_keyboardKeyCode);
		}

		private void WvnaZBDwqkTrSoproPBquQJFyPXf()
		{
			if (_elementIdentifierId < 0)
			{
				_keyboardKeyCode = KeyboardKeyCode.None;
			}
			else if (ReInput.isReady)
			{
				_keyboardKeyCode = Keyboard.KeyCodeToKeyboardKeyCode(ReInput.akUdmKMbrqFLXkjqdKLUZOPTArx.Keyboard.GetKeyCodeById(_elementIdentifierId));
			}
		}

		private void jcbuOQFDzxESUfImeQizRwqhadk()
		{
			if (_modifierKey1 != ModifierKey.None)
			{
				if (_modifierKey1 == _modifierKey2)
				{
					goto IL_001c;
				}
				goto IL_00ca;
			}
			goto IL_00ec;
			IL_00ca:
			int num;
			int num2;
			if (_modifierKey1 == _modifierKey3)
			{
				num = -466574973;
				num2 = num;
			}
			else
			{
				num = -466574969;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = -466574970;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ -466574973)
				{
				case 3:
					break;
				default:
					return;
				case 5:
					_modifierKey2 = ModifierKey.None;
					num = -466574971;
					continue;
				case 2:
					goto IL_005f;
				case 0:
					_modifierKey3 = ModifierKey.None;
					num = -466574969;
					continue;
				case 7:
					goto IL_009d;
				case 6:
					goto IL_00ca;
				case 4:
					goto IL_00ec;
				case 1:
					return;
				}
				break;
			}
			goto IL_001c;
			IL_005f:
			if (_modifierKey2 != ModifierKey.None && _modifierKey1 == ModifierKey.None)
			{
				_modifierKey1 = _modifierKey2;
				_modifierKey2 = ModifierKey.None;
				num = -466574974;
				goto IL_0021;
			}
			return;
			IL_00ec:
			if (_modifierKey2 != ModifierKey.None && _modifierKey2 == _modifierKey3)
			{
				_modifierKey3 = ModifierKey.None;
				num = -466574972;
				goto IL_0021;
			}
			goto IL_009d;
			IL_009d:
			if (_modifierKey3 != ModifierKey.None && _modifierKey2 == ModifierKey.None)
			{
				_modifierKey2 = _modifierKey3;
				_modifierKey3 = ModifierKey.None;
				num = -466574975;
				goto IL_0021;
			}
			goto IL_005f;
		}

		internal SerializedObject mtMtVVrohwWTxFPivXmGbDyGevo()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("actionCategoryId", _actionCategoryId);
			while (true)
			{
				int num = -1442280555;
				while (true)
				{
					switch (num ^ -1442280556)
					{
					case 2:
						break;
					case 1:
						serializedObject.Add("actionId", _actionId);
						serializedObject.Add("elementType", _elementType);
						serializedObject.Add("elementIdentifierId", _elementIdentifierId);
						serializedObject.Add("axisRange", _axisRange);
						serializedObject.Add("invert", _invert);
						serializedObject.Add("axisContribution", _axisContribution);
						serializedObject.Add("keyboardKeyCode", _keyboardKeyCode);
						serializedObject.Add("modifierKey1", _modifierKey1);
						num = -1442280556;
						continue;
					case 0:
						serializedObject.Add("modifierKey2", _modifierKey2);
						serializedObject.Add("modifierKey3", _modifierKey3);
						serializedObject.Add("enabled", FnzJwrQpikWfZbmfjZhFwutJGAA);
						num = -1442280553;
						continue;
					default:
						return serializedObject;
					}
					break;
				}
			}
		}

		internal void FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject P_0)
		{
			_actionCategoryId = -1;
			_actionId = -1;
			_elementIdentifierId = -1;
			while (true)
			{
				int num = 190952754;
				while (true)
				{
					switch (num ^ 0xB61B535)
					{
					case 0:
						break;
					case 7:
						_axisRange = AxisRange.Full;
						_invert = false;
						_axisContribution = Pole.Positive;
						_keyboardKeyCode = KeyboardKeyCode.None;
						num = 190952759;
						continue;
					case 6:
						P_0.TryGetDeserializedValueByRef("elementType", ref _elementType);
						P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref _elementIdentifierId);
						P_0.TryGetDeserializedValueByRef("axisRange", ref _axisRange);
						P_0.TryGetDeserializedValueByRef("invert", ref _invert);
						num = 190952758;
						continue;
					case 5:
						_modifierKey3 = ModifierKey.None;
						FnzJwrQpikWfZbmfjZhFwutJGAA = true;
						P_0.TryGetDeserializedValueByRef("actionCategoryId", ref _actionCategoryId);
						num = 190952756;
						continue;
					case 4:
						_modifierKey2 = ModifierKey.None;
						num = 190952752;
						continue;
					case 1:
						P_0.TryGetDeserializedValueByRef("actionId", ref _actionId);
						num = 190952755;
						continue;
					case 2:
						_modifierKey1 = ModifierKey.None;
						num = 190952753;
						continue;
					default:
						P_0.TryGetDeserializedValueByRef("axisContribution", ref _axisContribution);
						P_0.TryGetDeserializedValueByRef("keyboardKeyCode", ref _keyboardKeyCode);
						P_0.TryGetDeserializedValueByRef("modifierKey1", ref _modifierKey1);
						P_0.TryGetDeserializedValueByRef("modifierKey2", ref _modifierKey2);
						P_0.TryGetDeserializedValueByRef("modifierKey3", ref _modifierKey3);
						P_0.TryGetDeserializedValueByRef("enabled", ref FnzJwrQpikWfZbmfjZhFwutJGAA);
						return;
					}
					break;
				}
			}
		}

		public override string ToString()
		{
			if (s_toStringSB == null)
			{
				goto IL_000a;
			}
			goto IL_0115;
			IL_000a:
			int num = -1573489425;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num ^ -1573489427)
				{
				case 0:
					break;
				case 4:
					StringTools.WriteVar(s_toStringSB, "Element Index", ouusLSVThShOJXeTBDNomJoAhtU);
					StringTools.WriteVar(s_toStringSB, "Axis Range", _axisRange);
					StringTools.WriteVar(s_toStringSB, "Invert", _invert);
					StringTools.WriteVar(s_toStringSB, "Axis Contribution", _axisContribution);
					StringTools.WriteVar(s_toStringSB, "Keyboard Key Code", _keyboardKeyCode);
					StringTools.WriteVar(s_toStringSB, "Has Modifiers", hasModifiers);
					StringTools.WriteVar(s_toStringSB, "Modifier Key 1", _modifierKey1);
					StringTools.WriteVar(s_toStringSB, "modifier Key 2", _modifierKey2);
					num = -1573489428;
					continue;
				case 3:
					goto IL_0115;
				case 6:
					StringTools.WriteVar(s_toStringSB, "Controller Map Id", (FcwxSEAqxlQQhiIiSEyJjkwZaAa != null) ? FcwxSEAqxlQQhiIiSEyJjkwZaAa.id : (-1));
					StringTools.WriteVar(s_toStringSB, "Action Id", _actionId);
					StringTools.WriteVar(s_toStringSB, "Action Descriptive Name", jKsjebElKYBNHCrAVSmYvYhecRcc);
					StringTools.WriteVar(s_toStringSB, "Element Type", _elementType);
					StringTools.WriteVar(s_toStringSB, "Element Identifier Id", _elementIdentifierId);
					StringTools.WriteVar(s_toStringSB, "Element Identifier Name", kyNQyqewsLrqXDcmgwjbeFBcFgr);
					num = -1573489431;
					continue;
				case 2:
					s_toStringSB = new StringBuilder();
					num = -1573489426;
					continue;
				case 1:
					StringTools.WriteVar(s_toStringSB, "modifier Key 3", _modifierKey3);
					StringTools.WriteVar(s_toStringSB, "modifier Key Flags", modifierKeyFlags);
					num = -1573489432;
					continue;
				default:
				{
					string result = s_toStringSB.ToString();
					s_toStringSB.Length = 0;
					return result;
				}
				}
				break;
			}
			goto IL_000a;
			IL_0115:
			StringTools.WriteVar(s_toStringSB, "Id", tqPurZpByiUWRrPJKwHxxaZZua);
			StringTools.WriteVar(s_toStringSB, "Enabled", FnzJwrQpikWfZbmfjZhFwutJGAA);
			num = -1573489429;
			goto IL_000f;
		}
	}
}
