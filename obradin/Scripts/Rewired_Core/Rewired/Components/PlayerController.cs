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
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
		[CustomObfuscation(rename = false)]
		internal sealed class ElementWithSourceInfo
		{
			[Tooltip("The name of the element.")]
			[SerializeField]
			private string _name;

			[SerializeField]
			[Tooltip("The element type.")]
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

			[Tooltip("The absolute to relative sensitivity multiplier. This is only applied when the axis coordinate mode is set to Relative and the axis receives Absolute coordinate mode input (joystick axes, keyboard keys, etc.).")]
			[FieldRange(0f, float.MaxValue)]
			[SerializeField]
			private float _absoluteToRelativeSensitivity = 1f;

			[FieldRange(0f, float.MaxValue)]
			[Tooltip("The number of times per second the wheel ticks when the value source is an absolute axis value.")]
			[SerializeField]
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
				Rewired.PlayerController.Axis.Definition definition2 = default(Rewired.PlayerController.Axis.Definition);
				while (true)
				{
					int num = 2095577215;
					while (true)
					{
						switch (num ^ 0x7CE7F879)
						{
						case 0:
							break;
						case 6:
						{
							int num2;
							if (!(definition is Rewired.PlayerController.ElementWithSource.Definition))
							{
								num = 2095577208;
								num2 = num;
							}
							else
							{
								num = 2095577212;
								num2 = num;
							}
							continue;
						}
						case 5:
						{
							Rewired.PlayerController.ElementWithSource.Definition definition3 = (Rewired.PlayerController.ElementWithSource.Definition)definition;
							definition3.actionId = actionId;
							num = 2095577208;
							continue;
						}
						case 3:
							if (definition is Rewired.PlayerController.MouseWheelAxis.Definition)
							{
								Rewired.PlayerController.MouseWheelAxis.Definition definition4 = (Rewired.PlayerController.MouseWheelAxis.Definition)definition;
								definition4.repeatRate = repeatRate;
								num = 2095577211;
								continue;
							}
							goto default;
						case 1:
							if (definition is Rewired.PlayerController.Axis.Definition)
							{
								definition2 = (Rewired.PlayerController.Axis.Definition)definition;
								definition2.coordinateMode = coordinateMode;
								num = 2095577213;
								continue;
							}
							goto case 3;
						case 4:
							definition2.absoluteToRelativeSensitivity = absoluteSourceSensitivity;
							num = 2095577210;
							continue;
						default:
							definition.enabled = enabled;
							definition.name = name;
							return definition;
						}
						break;
					}
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
		[CustomObfuscation(rename = false)]
		internal sealed class ElementInfo
		{
			[SerializeField]
			[Tooltip("The name of the element.")]
			private string _name;

			[Tooltip("The element type.")]
			[SerializeField]
			private Rewired.PlayerController.Element.Type _elementType;

			[SerializeField]
			[Tooltip("Is this element enabled? Disabled elements return no value.")]
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
				int num;
				if (definition is Rewired.PlayerController.ElementWithSource.Definition)
				{
					if (_elements != null)
					{
						if (_elements.Length == 0)
						{
							goto IL_0029;
						}
						Rewired.PlayerController.ElementWithSource.Definition definition2 = (Rewired.PlayerController.ElementWithSource.Definition)definition;
						definition2.name = _elements[0].name;
						definition2.enabled = _elements[0].enabled;
						definition2.actionId = _elements[0].actionId;
						num = 73505331;
						goto IL_002e;
					}
					goto IL_0099;
				}
				goto IL_00ef;
				IL_002e:
				while (true)
				{
					switch (num ^ 0x4619A35)
					{
					case 0:
						break;
					case 7:
						if (_elements != null)
						{
							goto IL_006a;
						}
						goto case 8;
					case 8:
						Logger.LogError("No element source was found for element with source definition.");
						return null;
					case 3:
						goto IL_0099;
					case 6:
						goto IL_00ef;
					case 1:
						goto IL_010b;
					case 4:
					{
						Rewired.PlayerController.Axis.Definition definition4 = (Rewired.PlayerController.Axis.Definition)definition;
						definition4.coordinateMode = _elements[0].coordinateMode;
						definition4.absoluteToRelativeSensitivity = _elements[0].absoluteSourceSensitivity;
						num = 73505335;
						continue;
					}
					case 2:
						if (definition is Rewired.PlayerController.MouseWheelAxis.Definition)
						{
							Rewired.PlayerController.MouseWheelAxis.Definition definition3 = (Rewired.PlayerController.MouseWheelAxis.Definition)definition;
							definition3.repeatRate = _elements[0].repeatRate;
							num = 73505332;
							continue;
						}
						goto IL_010b;
					default:
						goto IL_019b;
					}
					break;
					IL_019b:
					Rewired.PlayerController.MouseWheel.Definition definition5 = definition as Rewired.PlayerController.MouseWheel.Definition;
					try
					{
						if (_elements.Length >= 1)
						{
							definition5.xAxis = (Rewired.PlayerController.MouseWheelAxis.Definition)_elements[0].ToDefinition();
							goto IL_01c7;
						}
						goto IL_01e9;
						IL_01e9:
						int num2;
						int num3;
						if (_elements.Length >= 2)
						{
							num2 = 73505335;
							num3 = num2;
						}
						else
						{
							num2 = 73505332;
							num3 = num2;
						}
						goto IL_01cc;
						IL_01c7:
						num2 = 73505334;
						goto IL_01cc;
						IL_01cc:
						while (true)
						{
							switch (num2 ^ 0x4619A35)
							{
							case 0:
								break;
							default:
								goto end_IL_01a3;
							case 3:
								goto IL_01e9;
							case 2:
								definition5.yAxis = (Rewired.PlayerController.MouseWheelAxis.Definition)_elements[1].ToDefinition();
								num2 = 73505332;
								continue;
							case 1:
								goto end_IL_01a3;
							}
							break;
						}
						goto IL_01c7;
						end_IL_01a3:;
					}
					catch
					{
						while (true)
						{
							int num4 = 73505332;
							while (true)
							{
								switch (num4 ^ 0x4619A35)
								{
								case 2:
									break;
								case 1:
									goto IL_0249;
								default:
									return null;
								}
								break;
								IL_0249:
								Logger.LogError("Incorrect element source type found. Expecting MouseWheelAxis.");
								num4 = 73505333;
							}
						}
					}
					goto IL_0305;
					IL_010b:
					if (definition is Rewired.PlayerController.CompoundElement.Definition)
					{
						definition.name = name;
						definition.enabled = enabled;
						num = 73505330;
						continue;
					}
					goto IL_0305;
					IL_0305:
					return definition;
					IL_006a:
					if (_elements.Length == 0)
					{
						num = 73505341;
						continue;
					}
					if (definition is Rewired.PlayerController.MouseWheel.Definition)
					{
						num = 73505328;
						continue;
					}
					if (definition is Rewired.PlayerController.Axis2D.Definition)
					{
						Rewired.PlayerController.Axis2D.Definition definition6 = definition as Rewired.PlayerController.Axis2D.Definition;
						try
						{
							if (_elements.Length >= 1)
							{
								goto IL_0280;
							}
							goto IL_02c2;
							IL_0280:
							int num5 = 73505334;
							goto IL_0285;
							IL_0285:
							while (true)
							{
								switch (num5 ^ 0x4619A35)
								{
								case 0:
									break;
								default:
									goto end_IL_0275;
								case 3:
									definition6.xAxis = (Rewired.PlayerController.Axis.Definition)_elements[0].ToDefinition();
									num5 = 73505335;
									continue;
								case 2:
									goto IL_02c2;
								case 1:
									goto end_IL_0275;
								}
								break;
							}
							goto IL_0280;
							IL_02c2:
							if (_elements.Length >= 2)
							{
								definition6.yAxis = (Rewired.PlayerController.Axis.Definition)_elements[1].ToDefinition();
								num5 = 73505332;
								goto IL_0285;
							}
							end_IL_0275:;
						}
						catch
						{
							Logger.LogError("Incorrect element source type found. Expecting Axis.");
							return null;
						}
						goto IL_0305;
					}
					throw new NotImplementedException();
				}
				goto IL_0029;
				IL_00ef:
				int num6;
				if (!(definition is Rewired.PlayerController.Axis.Definition))
				{
					num = 73505335;
					num6 = num;
				}
				else
				{
					num = 73505329;
					num6 = num;
				}
				goto IL_002e;
				IL_0099:
				Logger.LogError("No element source was found for element with source definition.");
				return null;
				IL_0029:
				num = 73505334;
				goto IL_002e;
			}
		}

		[CustomObfuscation(rename = false)]
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Action ids, Player ids, etc.")]
		[SerializeField]
		private InputManager_Base _rewiredInputManager;

		[Tooltip("The Player id of the Player used for the source of input.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _playerId = -1;

		[Tooltip("The elements that will be created in the controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ElementInfo> _elements = new List<ElementInfo>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Triggered the first frame the button is pressed or released.")]
		private ButtonStateChangedHandler _onButtonStateChanged = new ButtonStateChangedHandler();

		[Tooltip("Triggered when the axis value changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AxisValueChangedHandler _onAxisValueChanged = new AxisValueChangedHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Triggered when the controller is enabled or disabled.")]
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
					goto IL_002e;
				}
				goto IL_0058;
				IL_0033:
				int num;
				switch (num ^ 0x4F44F9A0)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0058;
				case 3:
					return;
				}
				goto IL_002e;
				IL_0058:
				_playerId = value;
				if (base.initialized)
				{
					base.source.playerId = value;
					num = 1329920419;
					goto IL_0033;
				}
				return;
				IL_002e:
				num = 1329920417;
				goto IL_0033;
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
					while (true)
					{
						switch (0x49EF36C9 ^ 0x49EF36CB)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				base.source.ButtonStateChangedEvent += value;
			}
			remove
			{
				if (base.initialized)
				{
					base.source.ButtonStateChangedEvent -= value;
				}
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (!base.initialized)
				{
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = 298169601;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x11C5B503)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_0032;
				case 0:
					return;
				}
				goto IL_0008;
				IL_0032:
				base.source.AxisValueChangedEvent += value;
				num = 298169603;
				goto IL_000d;
			}
			remove
			{
				if (!base.initialized)
				{
					while (true)
					{
						switch (-126190751 ^ -126190752)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				base.source.AxisValueChangedEvent -= value;
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (base.initialized)
				{
					base.source.EnabledStateChangedEvent += value;
				}
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
			MnydutHyxjmwKMpspBpJJJfHkpz();
			base.OnAwake();
		}

		protected override void OnAwakeFinished()
		{
			base.OnAwakeFinished();
			if (base.initialized)
			{
				caWcTTXIQkNAnQIlYjScUWgCTQn(true);
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			while (true)
			{
				int num = 1966844255;
				while (true)
				{
					switch (num ^ 0x753BA95E)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (base.initialized && ReInput.isReady)
						{
							goto IL_0033;
						}
						return;
					case 0:
						return;
					}
					break;
					IL_0033:
					base.source.enabled = true;
					num = 1966844254;
				}
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num = 1953048717;
				while (true)
				{
					switch (num ^ 0x7469288C)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (ReInput.isReady)
						{
							goto IL_0033;
						}
						return;
					case 0:
						return;
					}
					break;
					IL_0033:
					base.source.enabled = false;
					num = 1953048716;
				}
			}
		}

		protected override void OnValidated()
		{
			base.OnValidated();
			playerId = _playerId;
			_playerId = playerId;
		}

		protected override void OnReset()
		{
			base.OnReset();
			_rewiredInputManager = null;
			while (true)
			{
				int num = 1802121166;
				while (true)
				{
					switch (num ^ 0x6B6A2FCF)
					{
					case 2:
						break;
					case 1:
						_playerId = -1;
						num = 1802121167;
						continue;
					case 0:
						_elements = new List<ElementInfo>();
						_onButtonStateChanged = new ButtonStateChangedHandler();
						_onAxisValueChanged = new AxisValueChangedHandler();
						_onEnabledStateChanged = new EnabledStateChangedHandler();
						num = 1802121164;
						continue;
					default:
						MnydutHyxjmwKMpspBpJJJfHkpz();
						return;
					}
					break;
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
			while (true)
			{
				int num = -2052731091;
				while (true)
				{
					switch (num ^ -2052731092)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002c;
					case 2:
						return;
					}
					break;
					IL_002c:
					base.source.ButtonStateChangedEvent += uDgBeWNklnmhCPigKVFjshKBCmM;
					base.source.AxisValueChangedEvent += HWFhkFlLkYUKyhTUFbGsyGCYFc;
					base.source.EnabledStateChangedEvent += caWcTTXIQkNAnQIlYjScUWgCTQn;
					num = -2052731090;
				}
			}
		}

		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			while (true)
			{
				int num = -1219820434;
				while (true)
				{
					switch (num ^ -1219820433)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (base.source != null)
						{
							goto IL_002c;
						}
						return;
					case 0:
						return;
					}
					break;
					IL_002c:
					base.source.ButtonStateChangedEvent -= uDgBeWNklnmhCPigKVFjshKBCmM;
					base.source.AxisValueChangedEvent -= HWFhkFlLkYUKyhTUFbGsyGCYFc;
					base.source.EnabledStateChangedEvent -= caWcTTXIQkNAnQIlYjScUWgCTQn;
					num = -1219820433;
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
			if (list != null)
			{
				goto IL_000a;
			}
			goto IL_0043;
			IL_000a:
			int num = -461564194;
			goto IL_000f;
			IL_000f:
			List<Rewired.PlayerController.Element.Definition> list2 = default(List<Rewired.PlayerController.Element.Definition>);
			while (true)
			{
				switch (num ^ -461564198)
				{
				case 0:
					break;
				case 3:
					list2 = new List<Rewired.PlayerController.Element.Definition>(list.Count);
					num = -461564200;
					continue;
				case 1:
					goto IL_0043;
				case 4:
					goto IL_005b;
				default:
				{
					IEnumerator<ElementInfo> enumerator = list.GetEnumerator();
					try
					{
						while (true)
						{
							IL_00bb:
							int num2;
							int num3;
							if (!enumerator.MoveNext())
							{
								num2 = -461564199;
								num3 = num2;
							}
							else
							{
								num2 = -461564200;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ -461564198)
								{
								case 0:
									num2 = -461564200;
									continue;
								default:
									goto end_IL_0083;
								case 2:
								{
									ElementInfo current = enumerator.Current;
									list2.Add(current.ToDefinition());
									num2 = -461564197;
									continue;
								}
								case 1:
									break;
								case 3:
									goto end_IL_0083;
								}
								goto IL_00bb;
								continue;
								end_IL_0083:
								break;
							}
							break;
						}
					}
					finally
					{
						if (enumerator != null)
						{
							while (true)
							{
								IL_00db:
								int num4 = -461564200;
								while (true)
								{
									switch (num4 ^ -461564198)
									{
									case 0:
										break;
									default:
										goto end_IL_00e0;
									case 2:
										goto IL_00f9;
									case 1:
										goto end_IL_00e0;
									}
									goto IL_00db;
									IL_00f9:
									enumerator.Dispose();
									num4 = -461564197;
									continue;
									end_IL_00e0:
									break;
								}
								break;
							}
						}
					}
					Rewired.PlayerController.Definition definition = new Rewired.PlayerController.Definition();
					definition.playerId = _playerId;
					definition.elements = list2;
					return Rewired.PlayerController.Factory.Create(definition);
				}
				}
				break;
				IL_005b:
				int num5;
				if (list.Count == 0)
				{
					num = -461564197;
					num5 = num;
				}
				else
				{
					num = -461564199;
					num5 = num;
				}
			}
			goto IL_000a;
			IL_0043:
			Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
			list = CreateDefaultElementInfos();
			num = -461564199;
			goto IL_000f;
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
			while (true)
			{
				int num = -1812488648;
				while (true)
				{
					switch (num ^ -1812488646)
					{
					case 0:
						break;
					case 2:
						goto IL_009f;
					default:
						return list;
					}
					break;
					IL_009f:
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
					num = -1812488645;
				}
			}
		}

		private void uDgBeWNklnmhCPigKVFjshKBCmM(int P_0, bool P_1)
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

		private void HWFhkFlLkYUKyhTUFbGsyGCYFc(int P_0, float P_1)
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
				while (true)
				{
					int num = -1281025690;
					while (true)
					{
						switch (num ^ -1281025692)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_003f;
						case 1:
							return;
						}
						break;
						IL_003f:
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex);
						num = -1281025691;
					}
				}
			}
		}

		private void caWcTTXIQkNAnQIlYjScUWgCTQn(bool P_0)
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
				while (true)
				{
					int num = -1831588639;
					while (true)
					{
						switch (num ^ -1831588640)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0035;
						case 2:
							return;
						}
						break;
						IL_0035:
						Logger.LogError("An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
						num = -1831588638;
					}
				}
			}
		}

		private void MnydutHyxjmwKMpspBpJJJfHkpz()
		{
			if (_elements != null && _elements.Count > 0)
			{
				return;
			}
			while (true)
			{
				_elements = CreateDefaultElementInfos();
				int num = 1053349689;
				while (true)
				{
					switch (num ^ 0x3EC8D738)
					{
					case 0:
						goto IL_0017;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0017:
					num = 1053349690;
				}
			}
		}
	}
}
