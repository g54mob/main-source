using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components
{
	[Serializable]
	public class PlayerController : ComponentWrapper<Rewired.PlayerController>, IPlayerController
	{
		[Serializable]
		public class ButtonStateChangedHandler : UnityEvent<int, bool>
		{
		}

		[Serializable]
		public class AxisValueChangedHandler : UnityEvent<int, float>
		{
		}

		[Serializable]
		public class EnabledStateChangedHandler : UnityEvent<bool>
		{
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
		internal sealed class ElementWithSourceInfo
		{
			[Tooltip("The name of the element.")]
			[SerializeField]
			private string _name;

			[Tooltip("The element type.")]
			[SerializeField]
			private Rewired.PlayerController.Element.TypeWithSource _elementType;

			[Tooltip("Is this element enabled? Disabled elements return no value.")]
			[SerializeField]
			private bool _enabled = true;

			[Tooltip("The Action id of the Action which will be used as the input source for the Element.")]
			[SerializeField]
			private int _actionId = -1;

			[SerializeField]
			[Tooltip("The output coordinate mode of the axis. An Absolute axis will only return value for input received from Absolute sources. A Relative axis will return value for input received from both Relative and Absolute sources. When converting from an Absolute input source to a Relative output, absoluteToRelativeSensitivity will be multiplied by the Absolute value to yield a simulated Relative value.")]
			private AxisCoordinateMode _coordinateMode;

			[SerializeField]
			[Tooltip("The absolute to relative sensitivity multiplier. This is only applied when the axis coordinate mode is set to Relative and the axis receives Absolute coordinate mode input (joystick axes, keyboard keys, etc.).")]
			[FieldRange(0f, float.MaxValue)]
			private float _absoluteToRelativeSensitivity = 1f;

			[FieldRange(0f, float.MaxValue)]
			[SerializeField]
			[Tooltip("The number of times per second the wheel ticks when the value source is an absolute axis value.")]
			private float _repeatRate = 4f;

			public string name
			{
				get
				{
					return _name;
				}
				set
				{
					_name = value;
				}
			}

			public Rewired.PlayerController.Element.TypeWithSource elementType
			{
				get
				{
					return _elementType;
				}
				set
				{
					_elementType = value;
				}
			}

			public bool enabled
			{
				get
				{
					return _enabled;
				}
				set
				{
					_enabled = value;
				}
			}

			public int actionId
			{
				get
				{
					return _actionId;
				}
				set
				{
					_actionId = value;
				}
			}

			public AxisCoordinateMode coordinateMode
			{
				get
				{
					return _coordinateMode;
				}
				set
				{
					_coordinateMode = value;
				}
			}

			public float absoluteSourceSensitivity
			{
				get
				{
					return _absoluteToRelativeSensitivity;
				}
				set
				{
					_absoluteToRelativeSensitivity = value;
				}
			}

			public float repeatRate
			{
				get
				{
					return _repeatRate;
				}
				set
				{
					_repeatRate = value;
				}
			}

			public Rewired.PlayerController.Element.Definition ToDefinition()
			{
				Rewired.PlayerController.Element.Definition definition = Rewired.PlayerController.Element.CreateDefinition((Rewired.PlayerController.Element.Type)elementType);
				Rewired.PlayerController.ElementWithSource.Definition definition2 = default(Rewired.PlayerController.ElementWithSource.Definition);
				if (definition is Rewired.PlayerController.ElementWithSource.Definition)
				{
					definition2 = (Rewired.PlayerController.ElementWithSource.Definition)definition;
					goto IL_001e;
				}
				goto IL_00c7;
				IL_0079:
				int num;
				if (definition is Rewired.PlayerController.MouseWheelAxis.Definition)
				{
					Rewired.PlayerController.MouseWheelAxis.Definition definition3 = (Rewired.PlayerController.MouseWheelAxis.Definition)definition;
					definition3.repeatRate = repeatRate;
					num = 1677023011;
					goto IL_0023;
				}
				goto IL_009b;
				IL_001e:
				num = 1677023014;
				goto IL_0023;
				IL_0023:
				Rewired.PlayerController.Axis.Definition definition4 = default(Rewired.PlayerController.Axis.Definition);
				while (true)
				{
					switch (num ^ 0x63F55723)
					{
					case 2:
						break;
					case 5:
						definition2.actionId = actionId;
						num = 1677023013;
						continue;
					case 1:
						definition4.absoluteToRelativeSensitivity = absoluteSourceSensitivity;
						num = 1677023012;
						continue;
					case 7:
						goto IL_0079;
					case 0:
						goto IL_009b;
					case 3:
						definition4.coordinateMode = coordinateMode;
						num = 1677023010;
						continue;
					case 6:
						goto IL_00c7;
					default:
						definition.name = name;
						return definition;
					}
					break;
				}
				goto IL_001e;
				IL_009b:
				definition.enabled = enabled;
				num = 1677023015;
				goto IL_0023;
				IL_00c7:
				if (definition is Rewired.PlayerController.Axis.Definition)
				{
					definition4 = (Rewired.PlayerController.Axis.Definition)definition;
					num = 1677023008;
					goto IL_0023;
				}
				goto IL_0079;
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
		internal sealed class ElementInfo
		{
			[Tooltip("The name of the element.")]
			[SerializeField]
			private string _name;

			[SerializeField]
			[Tooltip("The element type.")]
			private Rewired.PlayerController.Element.Type _elementType;

			[Tooltip("Is this element enabled? Disabled elements return no value.")]
			[SerializeField]
			private bool _enabled = true;

			[SerializeField]
			private ElementWithSourceInfo[] _elements = new ElementWithSourceInfo[0];

			public string name
			{
				get
				{
					return _name;
				}
				set
				{
					_name = value;
				}
			}

			public Rewired.PlayerController.Element.Type elementType
			{
				get
				{
					return _elementType;
				}
				set
				{
					_elementType = value;
				}
			}

			public bool enabled
			{
				get
				{
					return _enabled;
				}
				set
				{
					_enabled = value;
				}
			}

			public ElementWithSourceInfo[] elements
			{
				get
				{
					return _elements;
				}
				set
				{
					_elements = value;
				}
			}

			public Rewired.PlayerController.Element.Definition ToDefinition()
			{
				Rewired.PlayerController.Element.Definition definition = Rewired.PlayerController.Element.CreateDefinition(elementType);
				if (!(definition is Rewired.PlayerController.ElementWithSource.Definition))
				{
					goto IL_0144;
				}
				Rewired.PlayerController.ElementWithSource.Definition definition2 = default(Rewired.PlayerController.ElementWithSource.Definition);
				int num;
				if (_elements != null)
				{
					if (_elements.Length == 0)
					{
						goto IL_002f;
					}
					definition2 = (Rewired.PlayerController.ElementWithSource.Definition)definition;
					num = 906966920;
					goto IL_0034;
				}
				goto IL_017f;
				IL_01d7:
				Rewired.PlayerController.Element.Definition result = default(Rewired.PlayerController.Element.Definition);
				if (definition is Rewired.PlayerController.MouseWheel.Definition)
				{
					Rewired.PlayerController.MouseWheel.Definition definition3 = definition as Rewired.PlayerController.MouseWheel.Definition;
					try
					{
						if (_elements.Length >= 1)
						{
							goto IL_01f5;
						}
						goto IL_0237;
						IL_01f5:
						int num2 = 906966920;
						goto IL_01fa;
						IL_01fa:
						while (true)
						{
							switch (num2 ^ 0x360F3789)
							{
							case 3:
								break;
							default:
								goto end_IL_01ea;
							case 1:
								definition3.xAxis = (Rewired.PlayerController.MouseWheelAxis.Definition)_elements[0].ToDefinition();
								num2 = 906966921;
								continue;
							case 0:
								goto IL_0237;
							case 2:
								goto end_IL_01ea;
							}
							break;
						}
						goto IL_01f5;
						IL_0237:
						if (_elements.Length >= 2)
						{
							definition3.yAxis = (Rewired.PlayerController.MouseWheelAxis.Definition)_elements[1].ToDefinition();
							num2 = 906966923;
							goto IL_01fa;
						}
						end_IL_01ea:;
					}
					catch
					{
						Logger.LogError("Incorrect element source type found. Expecting MouseWheelAxis.");
						result = null;
						goto IL_0339;
					}
				}
				else
				{
					if (!(definition is Rewired.PlayerController.Axis2D.Definition))
					{
						throw new NotImplementedException();
					}
					Rewired.PlayerController.Axis2D.Definition definition4 = definition as Rewired.PlayerController.Axis2D.Definition;
					try
					{
						if (_elements.Length >= 1)
						{
							definition4.xAxis = (Rewired.PlayerController.Axis.Definition)_elements[0].ToDefinition();
							goto IL_02b1;
						}
						goto IL_02cf;
						IL_02cf:
						int num3;
						if (_elements.Length >= 2)
						{
							definition4.yAxis = (Rewired.PlayerController.Axis.Definition)_elements[1].ToDefinition();
							num3 = 906966921;
							goto IL_02b6;
						}
						goto end_IL_028d;
						IL_02b1:
						num3 = 906966920;
						goto IL_02b6;
						IL_02b6:
						switch (num3 ^ 0x360F3789)
						{
						case 2:
							break;
						default:
							goto end_IL_028d;
						case 1:
							goto IL_02cf;
						case 0:
							goto end_IL_028d;
						}
						goto IL_02b1;
						end_IL_028d:;
					}
					catch
					{
						Logger.LogError("Incorrect element source type found. Expecting Axis.");
						while (true)
						{
							IL_0307:
							int num4 = 906966920;
							while (true)
							{
								switch (num4 ^ 0x360F3789)
								{
								case 0:
									break;
								case 1:
									goto IL_0325;
								default:
									goto end_IL_030c;
								}
								goto IL_0307;
								IL_0325:
								result = null;
								num4 = 906966923;
								continue;
								end_IL_030c:
								break;
							}
							break;
						}
						goto IL_0339;
					}
				}
				goto IL_0337;
				IL_0339:
				return result;
				IL_0337:
				return definition;
				IL_002f:
				num = 906966912;
				goto IL_0034;
				IL_0034:
				Rewired.PlayerController.Axis.Definition definition6 = default(Rewired.PlayerController.Axis.Definition);
				while (true)
				{
					switch (num ^ 0x360F3789)
					{
					case 4:
						break;
					case 10:
						definition6.coordinateMode = _elements[0].coordinateMode;
						definition6.absoluteToRelativeSensitivity = _elements[0].absoluteSourceSensitivity;
						num = 906966917;
						continue;
					case 1:
						definition2.name = _elements[0].name;
						num = 906966926;
						continue;
					case 8:
						Logger.LogError("No element source was found for element with source definition.");
						num = 906966923;
						continue;
					case 3:
						definition6 = (Rewired.PlayerController.Axis.Definition)definition;
						num = 906966915;
						continue;
					case 11:
						goto IL_00e7;
					case 7:
						definition2.enabled = _elements[0].enabled;
						definition2.actionId = _elements[0].actionId;
						num = 906966927;
						continue;
					case 6:
						goto IL_0144;
					case 0:
						if (_elements == null)
						{
							goto case 8;
						}
						goto IL_016b;
					case 9:
						goto IL_017f;
					case 12:
						if (definition is Rewired.PlayerController.MouseWheelAxis.Definition)
						{
							Rewired.PlayerController.MouseWheelAxis.Definition definition5 = (Rewired.PlayerController.MouseWheelAxis.Definition)definition;
							definition5.repeatRate = _elements[0].repeatRate;
							num = 906966914;
							continue;
						}
						goto IL_00e7;
					case 5:
						return null;
					default:
						return null;
					}
					break;
					IL_016b:
					if (_elements.Length == 0)
					{
						num = 906966913;
						continue;
					}
					goto IL_01d7;
					IL_00e7:
					if (definition is Rewired.PlayerController.CompoundElement.Definition)
					{
						definition.name = name;
						definition.enabled = enabled;
						num = 906966921;
						continue;
					}
					goto IL_0337;
				}
				goto IL_002f;
				IL_0144:
				int num5;
				if (!(definition is Rewired.PlayerController.Axis.Definition))
				{
					num = 906966917;
					num5 = num;
				}
				else
				{
					num = 906966922;
					num5 = num;
				}
				goto IL_0034;
				IL_017f:
				Logger.LogError("No element source was found for element with source definition.");
				num = 906966924;
				goto IL_0034;
			}
		}

		[SerializeField]
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Action ids, Player ids, etc.")]
		[CustomObfuscation(rename = false)]
		private InputManager_Base _rewiredInputManager;

		[CustomObfuscation(rename = false)]
		[Tooltip("The Player id of the Player used for the source of input.")]
		[SerializeField]
		private int _playerId = -1;

		[SerializeField]
		[Tooltip("The elements that will be created in the controller.")]
		[CustomObfuscation(rename = false)]
		private List<ElementInfo> _elements = new List<ElementInfo>();

		[Tooltip("Triggered the first frame the button is pressed or released.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ButtonStateChangedHandler _onButtonStateChanged = new ButtonStateChangedHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Triggered when the axis value changes.")]
		private AxisValueChangedHandler _onAxisValueChanged = new AxisValueChangedHandler();

		[Tooltip("Triggered when the controller is enabled or disabled.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private EnabledStateChangedHandler _onEnabledStateChanged = new EnabledStateChangedHandler();

		public int playerId
		{
			get
			{
				if (!base.initialized)
				{
					return _playerId;
				}
				return base.source.playerId;
			}
			set
			{
				if (ReInput.isReady && ReInput.players.GetPlayer(value) == null)
				{
					Logger.LogWarning("Player id " + value + " does not exist.");
					return;
				}
				while (true)
				{
					_playerId = value;
					int num = 1145250339;
					while (true)
					{
						switch (num ^ 0x44432221)
						{
						case 0:
							num = 1145250338;
							continue;
						default:
							return;
						case 3:
							break;
						case 2:
							if (base.initialized)
							{
								base.source.playerId = value;
								num = 1145250336;
								continue;
							}
							return;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		public IList<Rewired.PlayerController.Button> buttons
		{
			get
			{
				if (!base.initialized)
				{
					return EmptyObjects<Rewired.PlayerController.Button>.EmptyReadOnlyIListT;
				}
				return base.source.buttons;
			}
		}

		public IList<Rewired.PlayerController.Axis> axes
		{
			get
			{
				if (!base.initialized)
				{
					return EmptyObjects<Rewired.PlayerController.Axis>.EmptyReadOnlyIListT;
				}
				return base.source.axes;
			}
		}

		public IList<Rewired.PlayerController.Element> elements
		{
			get
			{
				if (!base.initialized)
				{
					return EmptyObjects<Rewired.PlayerController.Element>.EmptyReadOnlyIListT;
				}
				return base.source.elements;
			}
		}

		public int buttonCount
		{
			get
			{
				if (!base.initialized)
				{
					return 0;
				}
				return base.source.buttonCount;
			}
		}

		public int axisCount
		{
			get
			{
				if (!base.initialized)
				{
					return 0;
				}
				return base.source.axisCount;
			}
		}

		public int elementCount
		{
			get
			{
				if (!base.initialized)
				{
					return 0;
				}
				return base.source.elementCount;
			}
		}

		bool IPlayerController.enabled
		{
			get
			{
				return base.enabled;
			}
			set
			{
				base.enabled = flag;
			}
		}

		public event Action<int, bool> ButtonStateChangedEvent
		{
			add
			{
				if (!base.initialized)
				{
					return;
				}
				while (true)
				{
					base.source.ButtonStateChangedEvent += value;
					int num = -209186905;
					while (true)
					{
						switch (num ^ -209186905)
						{
						case 2:
							goto IL_0009;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_0009:
						num = -209186906;
					}
				}
			}
			remove
			{
				if (!base.initialized)
				{
					return;
				}
				while (true)
				{
					base.source.ButtonStateChangedEvent -= value;
					int num = -1917577010;
					while (true)
					{
						switch (num ^ -1917577010)
						{
						case 2:
							goto IL_0009;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_0009:
						num = -1917577009;
					}
				}
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (!base.initialized)
				{
					while (true)
					{
						switch (-392326313 ^ -392326314)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				base.source.AxisValueChangedEvent += value;
			}
			remove
			{
				if (!base.initialized)
				{
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = 591456337;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x2340E850)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0032;
				case 3:
					return;
				}
				goto IL_0008;
				IL_0032:
				base.source.AxisValueChangedEvent -= value;
				num = 591456339;
				goto IL_000d;
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (!base.initialized)
				{
					while (true)
					{
						switch (0x2F2EFA75 ^ 0x2F2EFA77)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				base.source.EnabledStateChangedEvent += value;
			}
			remove
			{
				if (base.initialized)
				{
					base.source.EnabledStateChangedEvent -= value;
				}
			}
		}

		public bool GetButton(int index)
		{
			if (!base.initialized)
			{
				return false;
			}
			return base.source.GetButton(index);
		}

		public bool GetButtonDown(int index)
		{
			if (!base.initialized)
			{
				return false;
			}
			return base.source.GetButtonDown(index);
		}

		public bool GetButtonUp(int index)
		{
			if (!base.initialized)
			{
				return false;
			}
			return base.source.GetButtonUp(index);
		}

		public float GetAxis(int index)
		{
			if (!base.initialized)
			{
				return 0f;
			}
			return base.source.GetAxis(index);
		}

		public float GetAxisRaw(int index)
		{
			if (!base.initialized)
			{
				return 0f;
			}
			return base.source.GetAxisRaw(index);
		}

		public Rewired.PlayerController.Element GetElement(int index)
		{
			if (!base.initialized)
			{
				return null;
			}
			return base.source.GetElement(index);
		}

		public T GetElement<T>(int index) where T : Rewired.PlayerController.Element
		{
			if (!base.initialized)
			{
				return null;
			}
			return base.source.GetElement<T>(index);
		}

		protected override void OnAwake()
		{
			jVwxryfKhzFmxmHzPrrJuKzRgae();
			base.OnAwake();
		}

		protected override void OnAwakeFinished()
		{
			base.OnAwakeFinished();
			if (base.initialized)
			{
				XXEfUKrOFwaAfiipmGuqzcwMXgm(true);
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if (base.initialized && ReInput.isReady)
			{
				base.source.enabled = true;
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if (base.initialized && ReInput.isReady)
			{
				base.source.enabled = false;
			}
		}

		protected override void OnValidated()
		{
			base.OnValidated();
			while (true)
			{
				int num = 1020096464;
				while (true)
				{
					switch (num ^ 0x3CCD6FD2)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						_playerId = playerId;
						return;
					}
					break;
					IL_0024:
					playerId = _playerId;
					num = 1020096467;
				}
			}
		}

		protected override void OnReset()
		{
			base.OnReset();
			_rewiredInputManager = null;
			while (true)
			{
				int num = 2091498253;
				while (true)
				{
					switch (num ^ 0x7CA9BB0C)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_002b;
					case 0:
						return;
					}
					break;
					IL_002b:
					_playerId = -1;
					_elements = new List<ElementInfo>();
					_onButtonStateChanged = new ButtonStateChangedHandler();
					_onAxisValueChanged = new AxisValueChangedHandler();
					_onEnabledStateChanged = new EnabledStateChangedHandler();
					jVwxryfKhzFmxmHzPrrJuKzRgae();
					num = 2091498252;
				}
			}
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			if (base.source == null)
			{
				return;
			}
			base.source.ButtonStateChangedEvent += VqGeBdFijLEfjhjmhHpNWQPOnN;
			while (true)
			{
				int num = 466854053;
				while (true)
				{
					switch (num ^ 0x1BD3A0A7)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0043;
					case 1:
						return;
					}
					break;
					IL_0043:
					base.source.AxisValueChangedEvent += ikGcuzFLbQzirRQpqnEOPYpKOAv;
					base.source.EnabledStateChangedEvent += XXEfUKrOFwaAfiipmGuqzcwMXgm;
					num = 466854054;
				}
			}
		}

		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			if (base.source == null)
			{
				return;
			}
			while (true)
			{
				int num = 1858938336;
				while (true)
				{
					switch (num ^ 0x6ECD25E2)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_002c;
					case 1:
						return;
					}
					break;
					IL_002c:
					base.source.ButtonStateChangedEvent -= VqGeBdFijLEfjhjmhHpNWQPOnN;
					base.source.AxisValueChangedEvent -= ikGcuzFLbQzirRQpqnEOPYpKOAv;
					base.source.EnabledStateChangedEvent -= XXEfUKrOFwaAfiipmGuqzcwMXgm;
					num = 1858938339;
				}
			}
		}

		protected override object GetCreateSourceArgs()
		{
			return _elements;
		}

		protected override Rewired.PlayerController CreateSource(object args)
		{
			IList<ElementInfo> list = args as IList<ElementInfo>;
			ElementInfo current = default(ElementInfo);
			while (true)
			{
				int num = 1416842479;
				while (true)
				{
					switch (num ^ 0x54734CEE)
					{
					case 3:
						break;
					case 1:
						if (list != null)
						{
							int num4;
							if (list.Count == 0)
							{
								num = 1416842478;
								num4 = num;
							}
							else
							{
								num = 1416842476;
								num4 = num;
							}
							continue;
						}
						goto case 0;
					case 0:
						Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
						list = CreateDefaultElementInfos();
						num = 1416842476;
						continue;
					default:
					{
						List<Rewired.PlayerController.Element.Definition> list2 = new List<Rewired.PlayerController.Element.Definition>(list.Count);
						using (IEnumerator<ElementInfo> enumerator = list.GetEnumerator())
						{
							while (true)
							{
								IL_0099:
								int num2;
								int num3;
								if (!enumerator.MoveNext())
								{
									num2 = 1416842477;
									num3 = num2;
								}
								else
								{
									num2 = 1416842479;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ 0x54734CEE)
									{
									case 2:
										num2 = 1416842479;
										continue;
									default:
										goto end_IL_0078;
									case 4:
										break;
									case 0:
										list2.Add(current.ToDefinition());
										num2 = 1416842474;
										continue;
									case 1:
										current = enumerator.Current;
										num2 = 1416842478;
										continue;
									case 3:
										goto end_IL_0078;
									}
									goto IL_0099;
									continue;
									end_IL_0078:
									break;
								}
								break;
							}
						}
						Rewired.PlayerController.Definition definition = new Rewired.PlayerController.Definition();
						definition.playerId = _playerId;
						definition.elements = list2;
						return Rewired.PlayerController.Factory.Create(definition);
					}
					}
					break;
				}
			}
		}

		internal virtual List<ElementInfo> CreateDefaultElementInfos()
		{
			List<ElementInfo> list = new List<ElementInfo>();
			list.Add(new ElementInfo
			{
				name = "Stick",
				elementType = Rewired.PlayerController.Element.Type.Axis2D,
				elements = new ElementWithSourceInfo[2]
				{
					new ElementWithSourceInfo
					{
						name = "Stick Horizontal",
						elementType = Rewired.PlayerController.Element.TypeWithSource.Axis,
						coordinateMode = AxisCoordinateMode.Absolute
					},
					new ElementWithSourceInfo
					{
						name = "Stick Vertical",
						elementType = Rewired.PlayerController.Element.TypeWithSource.Axis,
						coordinateMode = AxisCoordinateMode.Absolute
					}
				}
			});
			list.Add(new ElementInfo
			{
				elements = new ElementWithSourceInfo[1]
				{
					new ElementWithSourceInfo
					{
						name = "Button 1",
						elementType = Rewired.PlayerController.Element.TypeWithSource.Button
					}
				}
			});
			list.Add(new ElementInfo
			{
				elements = new ElementWithSourceInfo[1]
				{
					new ElementWithSourceInfo
					{
						name = "Button 2",
						elementType = Rewired.PlayerController.Element.TypeWithSource.Button
					}
				}
			});
			list.Add(new ElementInfo
			{
				elements = new ElementWithSourceInfo[1]
				{
					new ElementWithSourceInfo
					{
						name = "Button 3",
						elementType = Rewired.PlayerController.Element.TypeWithSource.Button
					}
				}
			});
			while (true)
			{
				int num = -748957729;
				while (true)
				{
					switch (num ^ -748957730)
					{
					case 0:
						break;
					case 1:
						goto IL_015f;
					default:
						return list;
					}
					break;
					IL_015f:
					list.Add(new ElementInfo
					{
						elements = new ElementWithSourceInfo[1]
						{
							new ElementWithSourceInfo
							{
								name = "Button 4",
								elementType = Rewired.PlayerController.Element.TypeWithSource.Button
							}
						}
					});
					num = -748957732;
				}
			}
		}

		private void VqGeBdFijLEfjhjmhHpNWQPOnN(int P_0, bool P_1)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			try
			{
				if (_onButtonStateChanged != null)
				{
					_onButtonStateChanged.Invoke(P_0, P_1);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
			}
		}

		private void ikGcuzFLbQzirRQpqnEOPYpKOAv(int P_0, float P_1)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			try
			{
				if (_onAxisValueChanged != null)
				{
					_onAxisValueChanged.Invoke(P_0, P_1);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex);
			}
		}

		private void XXEfUKrOFwaAfiipmGuqzcwMXgm(bool P_0)
		{
			try
			{
				if (_onEnabledStateChanged != null)
				{
					_onEnabledStateChanged.Invoke(P_0);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
			}
		}

		private void jVwxryfKhzFmxmHzPrrJuKzRgae()
		{
			if (_elements == null || _elements.Count <= 0)
			{
				_elements = CreateDefaultElementInfos();
			}
		}
	}
}
