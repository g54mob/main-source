using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("Rewired/Player Controller")]
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

			[SerializeField]
			[Tooltip("The element type.")]
			private Rewired.PlayerController.Element.TypeWithSource _elementType;

			[SerializeField]
			[Tooltip("Is this element enabled? Disabled elements return no value.")]
			private bool _enabled = true;

			[SerializeField]
			[Tooltip("The Action id of the Action which will be used as the input source for the Element.")]
			private int _actionId = -1;

			[SerializeField]
			[Tooltip("The output coordinate mode of the axis. An Absolute axis will only return value for input received from Absolute sources. A Relative axis will return value for input received from both Relative and Absolute sources. When converting from an Absolute input source to a Relative output, absoluteToRelativeSensitivity will be multiplied by the Absolute value to yield a simulated Relative value.")]
			private AxisCoordinateMode _coordinateMode;

			[Tooltip("The absolute to relative sensitivity multiplier. This is only applied when the axis coordinate mode is set to Relative and the axis receives Absolute coordinate mode input (joystick axes, keyboard keys, etc.).")]
			[FieldRange(0f, float.MaxValue)]
			[SerializeField]
			private float _absoluteToRelativeSensitivity = 1f;

			[Tooltip("The number of times per second the wheel ticks when the value source is an absolute axis value.")]
			[SerializeField]
			[FieldRange(0f, float.MaxValue)]
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
				Rewired.PlayerController.MouseWheelAxis.Definition definition4 = default(Rewired.PlayerController.MouseWheelAxis.Definition);
				Rewired.PlayerController.Axis.Definition definition2 = default(Rewired.PlayerController.Axis.Definition);
				while (true)
				{
					int num = -637792662;
					while (true)
					{
						switch (num ^ -637792658)
						{
						case 8:
							break;
						case 3:
							if (definition is Rewired.PlayerController.MouseWheelAxis.Definition)
							{
								definition4 = (Rewired.PlayerController.MouseWheelAxis.Definition)definition;
								num = -637792663;
								continue;
							}
							goto default;
						case 7:
							definition4.repeatRate = repeatRate;
							num = -637792658;
							continue;
						case 2:
							definition2.coordinateMode = coordinateMode;
							num = -637792661;
							continue;
						case 4:
							if (definition is Rewired.PlayerController.ElementWithSource.Definition)
							{
								Rewired.PlayerController.ElementWithSource.Definition definition3 = (Rewired.PlayerController.ElementWithSource.Definition)definition;
								definition3.actionId = actionId;
								num = -637792664;
								continue;
							}
							goto case 6;
						case 1:
							definition2 = (Rewired.PlayerController.Axis.Definition)definition;
							num = -637792660;
							continue;
						case 5:
							definition2.absoluteToRelativeSensitivity = absoluteSourceSensitivity;
							num = -637792659;
							continue;
						case 6:
						{
							int num2;
							if (!(definition is Rewired.PlayerController.Axis.Definition))
							{
								num = -637792659;
								num2 = num;
							}
							else
							{
								num = -637792657;
								num2 = num;
							}
							continue;
						}
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
			[Tooltip("The name of the element.")]
			[SerializeField]
			private string _name;

			[Tooltip("The element type.")]
			[SerializeField]
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
				Rewired.PlayerController.MouseWheelAxis.Definition definition6 = default(Rewired.PlayerController.MouseWheelAxis.Definition);
				while (true)
				{
					int num = 1392877230;
					while (true)
					{
						switch (num ^ 0x53059EAF)
						{
						case 8:
							break;
						case 0:
							if (_elements == null)
							{
								goto case 13;
							}
							if (_elements.Length == 0)
							{
								num = 1392877218;
								continue;
							}
							if (definition is Rewired.PlayerController.MouseWheel.Definition)
							{
								Rewired.PlayerController.MouseWheel.Definition definition2 = definition as Rewired.PlayerController.MouseWheel.Definition;
								try
								{
									if (_elements.Length >= 1)
									{
										goto IL_01fa;
									}
									goto IL_023c;
									IL_01fa:
									int num3 = 1392877230;
									goto IL_01ff;
									IL_01ff:
									while (true)
									{
										switch (num3 ^ 0x53059EAF)
										{
										case 2:
											break;
										default:
											goto end_IL_01ef;
										case 1:
											definition2.xAxis = (Rewired.PlayerController.MouseWheelAxis.Definition)_elements[0].ToDefinition();
											num3 = 1392877228;
											continue;
										case 3:
											goto IL_023c;
										case 0:
											goto end_IL_01ef;
										}
										break;
									}
									goto IL_01fa;
									IL_023c:
									if (_elements.Length >= 2)
									{
										definition2.yAxis = (Rewired.PlayerController.MouseWheelAxis.Definition)_elements[1].ToDefinition();
										num3 = 1392877231;
										goto IL_01ff;
									}
									end_IL_01ef:;
								}
								catch
								{
									Logger.LogError("Incorrect element source type found. Expecting MouseWheelAxis.");
									return null;
								}
							}
							else
							{
								if (!(definition is Rewired.PlayerController.Axis2D.Definition))
								{
									throw new NotImplementedException();
								}
								Rewired.PlayerController.Axis2D.Definition definition3 = definition as Rewired.PlayerController.Axis2D.Definition;
								try
								{
									if (_elements.Length >= 1)
									{
										definition3.xAxis = (Rewired.PlayerController.Axis.Definition)_elements[0].ToDefinition();
										goto IL_02b6;
									}
									goto IL_02d8;
									IL_02d8:
									int num4;
									int num5;
									if (_elements.Length >= 2)
									{
										num4 = 1392877229;
										num5 = num4;
									}
									else
									{
										num4 = 1392877231;
										num5 = num4;
									}
									goto IL_02bb;
									IL_02b6:
									num4 = 1392877230;
									goto IL_02bb;
									IL_02bb:
									while (true)
									{
										switch (num4 ^ 0x53059EAF)
										{
										case 3:
											break;
										default:
											goto end_IL_0292;
										case 1:
											goto IL_02d8;
										case 2:
											definition3.yAxis = (Rewired.PlayerController.Axis.Definition)_elements[1].ToDefinition();
											num4 = 1392877231;
											continue;
										case 0:
											goto end_IL_0292;
										}
										break;
									}
									goto IL_02b6;
									end_IL_0292:;
								}
								catch
								{
									Logger.LogError("Incorrect element source type found. Expecting Axis.");
									return null;
								}
							}
							goto IL_032c;
						case 6:
						{
							if (_elements.Length == 0)
							{
								num = 1392877224;
								continue;
							}
							Rewired.PlayerController.ElementWithSource.Definition definition4 = (Rewired.PlayerController.ElementWithSource.Definition)definition;
							definition4.name = _elements[0].name;
							definition4.enabled = _elements[0].enabled;
							definition4.actionId = _elements[0].actionId;
							num = 1392877221;
							continue;
						}
						case 3:
							if (definition is Rewired.PlayerController.MouseWheelAxis.Definition)
							{
								definition6 = (Rewired.PlayerController.MouseWheelAxis.Definition)definition;
								num = 1392877229;
								continue;
							}
							goto case 4;
						case 2:
							definition6.repeatRate = _elements[0].repeatRate;
							num = 1392877227;
							continue;
						case 9:
							return null;
						case 4:
							if (definition is Rewired.PlayerController.CompoundElement.Definition)
							{
								num = 1392877226;
								continue;
							}
							goto IL_032c;
						case 11:
							definition.enabled = enabled;
							num = 1392877231;
							continue;
						case 1:
							if (definition is Rewired.PlayerController.ElementWithSource.Definition)
							{
								int num2;
								if (_elements != null)
								{
									num = 1392877225;
									num2 = num;
								}
								else
								{
									num = 1392877224;
									num2 = num;
								}
								continue;
							}
							goto case 10;
						case 13:
							Logger.LogError("No element source was found for element with source definition.");
							num = 1392877219;
							continue;
						case 10:
							if (definition is Rewired.PlayerController.Axis.Definition)
							{
								Rewired.PlayerController.Axis.Definition definition5 = (Rewired.PlayerController.Axis.Definition)definition;
								definition5.coordinateMode = _elements[0].coordinateMode;
								definition5.absoluteToRelativeSensitivity = _elements[0].absoluteSourceSensitivity;
								num = 1392877228;
								continue;
							}
							goto case 3;
						case 5:
							definition.name = name;
							num = 1392877220;
							continue;
						case 7:
							Logger.LogError("No element source was found for element with source definition.");
							num = 1392877222;
							continue;
						default:
							{
								return null;
							}
							IL_032c:
							return definition;
						}
						break;
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Action ids, Player ids, etc.")]
		private InputManager_Base _rewiredInputManager;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Player id of the Player used for the source of input.")]
		private int _playerId = -1;

		[CustomObfuscation(rename = false)]
		[Tooltip("The elements that will be created in the controller.")]
		[SerializeField]
		private List<ElementInfo> _elements = new List<ElementInfo>();

		[SerializeField]
		[Tooltip("Triggered the first frame the button is pressed or released.")]
		[CustomObfuscation(rename = false)]
		private ButtonStateChangedHandler _onButtonStateChanged = new ButtonStateChangedHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Triggered when the axis value changes.")]
		private AxisValueChangedHandler _onAxisValueChanged = new AxisValueChangedHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
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
					return;
				}
				while (true)
				{
					_playerId = value;
					int num;
					int num2;
					if (base.initialized)
					{
						num = 754364614;
						num2 = num;
					}
					else
					{
						num = 754364612;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x2CF6B0C4)
						{
						case 3:
							num = 754364613;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							base.source.playerId = value;
							num = 754364612;
							continue;
						case 0:
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
					int num = 237611460;
					while (true)
					{
						switch (num ^ 0xE29A9C5)
						{
						case 0:
							goto IL_0009;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0009:
						num = 237611463;
					}
				}
			}
			remove
			{
				if (!base.initialized)
				{
					while (true)
					{
						switch (0x50D48577 ^ 0x50D48576)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				base.source.ButtonStateChangedEvent -= value;
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
						switch (0x4E146782 ^ 0x4E146783)
						{
						case 2:
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
				if (base.initialized)
				{
					base.source.AxisValueChangedEvent -= value;
				}
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
						switch (-582356332 ^ -582356331)
						{
						case 2:
							continue;
						case 1:
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
			UzkHQfNXUhjGwNFUUNIMsbBERxD();
			base.OnAwake();
		}

		protected override void OnAwakeFinished()
		{
			base.OnAwakeFinished();
			while (true)
			{
				int num = -979470303;
				while (true)
				{
					switch (num ^ -979470301)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						if (base.initialized)
						{
							goto IL_002c;
						}
						return;
					case 1:
						return;
					}
					break;
					IL_002c:
					gfEyKVJrrqjtVFzFzUhjtbILYEH(true);
					num = -979470302;
				}
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
			if (!base.initialized || !ReInput.isReady)
			{
				return;
			}
			while (true)
			{
				int num = -1864556084;
				while (true)
				{
					switch (num ^ -1864556082)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0033;
					case 1:
						return;
					}
					break;
					IL_0033:
					base.source.enabled = false;
					num = -1864556081;
				}
			}
		}

		protected override void OnValidated()
		{
			base.OnValidated();
			while (true)
			{
				int num = 1261585235;
				while (true)
				{
					switch (num ^ 0x4B324352)
					{
					case 0:
						break;
					case 1:
						goto IL_0024;
					default:
						_playerId = playerId;
						return;
					}
					break;
					IL_0024:
					playerId = _playerId;
					num = 1261585232;
				}
			}
		}

		protected override void OnReset()
		{
			base.OnReset();
			_rewiredInputManager = null;
			_playerId = -1;
			while (true)
			{
				int num = -903684007;
				while (true)
				{
					switch (num ^ -903684008)
					{
					case 3:
						break;
					case 1:
						_elements = new List<ElementInfo>();
						_onButtonStateChanged = new ButtonStateChangedHandler();
						num = -903684006;
						continue;
					case 2:
						_onAxisValueChanged = new AxisValueChangedHandler();
						_onEnabledStateChanged = new EnabledStateChangedHandler();
						num = -903684008;
						continue;
					default:
						UzkHQfNXUhjGwNFUUNIMsbBERxD();
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
			base.source.ButtonStateChangedEvent += ojouvCRvNtvQkGXIhJwwVUoITuk;
			while (true)
			{
				int num = -4628563;
				while (true)
				{
					switch (num ^ -4628564)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0043;
					case 0:
						return;
					}
					break;
					IL_0043:
					base.source.AxisValueChangedEvent += PmSBHqGtcObwsBsjhRGByRmNdVOn;
					base.source.EnabledStateChangedEvent += gfEyKVJrrqjtVFzFzUhjtbILYEH;
					num = -4628564;
				}
			}
		}

		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			while (true)
			{
				int num = -1981223919;
				while (true)
				{
					switch (num ^ -1981223920)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						if (base.source != null)
						{
							base.source.ButtonStateChangedEvent -= ojouvCRvNtvQkGXIhJwwVUoITuk;
							num = -1981223916;
							continue;
						}
						return;
					case 4:
						base.source.AxisValueChangedEvent -= PmSBHqGtcObwsBsjhRGByRmNdVOn;
						num = -1981223920;
						continue;
					case 0:
						base.source.EnabledStateChangedEvent -= gfEyKVJrrqjtVFzFzUhjtbILYEH;
						num = -1981223918;
						continue;
					case 2:
						return;
					}
					break;
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
			while (true)
			{
				int num = -1785525485;
				while (true)
				{
					switch (num ^ -1785525488)
					{
					case 0:
						break;
					case 3:
						if (list != null)
						{
							int num3;
							if (list.Count == 0)
							{
								num = -1785525487;
								num3 = num;
							}
							else
							{
								num = -1785525486;
								num3 = num;
							}
							continue;
						}
						goto case 1;
					case 1:
						Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
						list = aBrYrGQJXebUVwGGLglKxCeODnq();
						num = -1785525486;
						continue;
					default:
					{
						List<Rewired.PlayerController.Element.Definition> list2 = new List<Rewired.PlayerController.Element.Definition>(list.Count);
						using (IEnumerator<ElementInfo> enumerator = list.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								while (true)
								{
									ElementInfo current = enumerator.Current;
									int num2 = -1785525486;
									while (true)
									{
										switch (num2 ^ -1785525488)
										{
										case 3:
											num2 = -1785525487;
											continue;
										case 1:
											break;
										case 2:
											list2.Add(current.ToDefinition());
											num2 = -1785525488;
											continue;
										default:
											goto end_IL_0095;
										}
										break;
									}
									continue;
									end_IL_0095:
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
				}
			}
		}

		internal virtual List<ElementInfo> aBrYrGQJXebUVwGGLglKxCeODnq()
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
			return list;
		}

		private void ojouvCRvNtvQkGXIhJwwVUoITuk(int P_0, bool P_1)
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

		private void PmSBHqGtcObwsBsjhRGByRmNdVOn(int P_0, float P_1)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			try
			{
				if (_onAxisValueChanged == null)
				{
					return;
				}
				while (true)
				{
					int num = 758691856;
					while (true)
					{
						switch (num ^ 0x2D38B811)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002f;
						case 0:
							return;
						}
						break;
						IL_002f:
						_onAxisValueChanged.Invoke(P_0, P_1);
						num = 758691857;
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex);
			}
		}

		private void gfEyKVJrrqjtVFzFzUhjtbILYEH(bool P_0)
		{
			try
			{
				if (_onEnabledStateChanged == null)
				{
					return;
				}
				while (true)
				{
					int num = -1763974884;
					while (true)
					{
						switch (num ^ -1763974883)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0026;
						case 0:
							return;
						}
						break;
						IL_0026:
						_onEnabledStateChanged.Invoke(P_0);
						num = -1763974883;
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
			}
		}

		private void UzkHQfNXUhjGwNFUUNIMsbBERxD()
		{
			if (_elements != null)
			{
				while (true)
				{
					int num = -753847556;
					while (true)
					{
						switch (num ^ -753847554)
						{
						case 3:
							break;
						case 2:
							goto IL_002a;
						case 1:
							return;
						default:
							goto end_IL_0008;
						}
						break;
						IL_002a:
						int num2;
						if (_elements.Count <= 0)
						{
							num = -753847554;
							num2 = num;
						}
						else
						{
							num = -753847553;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			_elements = aBrYrGQJXebUVwGGLglKxCeODnq();
		}
	}
}
