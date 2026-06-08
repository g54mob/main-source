using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using Rewired.Data;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Custom Controller")]
	public class CustomController : ComponentController
	{
		[Serializable]
		public class CreateCustomControllerSettings
		{
			[CustomObfuscation(rename = false)]
			[SerializeField]
			[Tooltip("If true, a new Custom Controller will be created. Otherwise, an existing Custom Controller will be found using the selector properties.")]
			private bool _createCustomController = true;

			[CustomObfuscation(rename = false)]
			[SerializeField]
			[Tooltip("The source id of the Custom Controller to create. Get this from the Rewired Input Manager.")]
			private int _customControllerSourceId = -1;

			[SerializeField]
			[CustomObfuscation(rename = false)]
			[Tooltip("The Player that will be assigned this Custom Controller when it is created.")]
			private int _assignToPlayerId;

			[SerializeField]
			[CustomObfuscation(rename = false)]
			[Tooltip("If true, the Custom Controller created by this component will be destroyed when this component is destroyed.")]
			private bool _destroyCustomController = true;

			public bool createCustomController
			{
				get
				{
					return _createCustomController;
				}
				set
				{
					if (_createCustomController == value)
					{
						while (true)
						{
							switch (-1688530948 ^ -1688530947)
							{
							case 2:
								continue;
							case 1:
								return;
							}
							break;
						}
					}
					_createCustomController = value;
				}
			}

			public int customControllerSourceId
			{
				get
				{
					return _customControllerSourceId;
				}
				set
				{
					_customControllerSourceId = value;
				}
			}

			public int assignToPlayerId
			{
				get
				{
					return _assignToPlayerId;
				}
				set
				{
					_assignToPlayerId = value;
				}
			}

			public bool destroyCustomController
			{
				get
				{
					return _destroyCustomController;
				}
				set
				{
					_destroyCustomController = value;
				}
			}
		}

		private struct InputEvent
		{
			public CustomControllerElementSelector.ElementType elementType;

			public int elementIndex;

			public float value;

			public InputEvent(CustomControllerElementSelector.ElementType elementType, int elementIndex, float value)
			{
				this.elementType = elementType;
				this.elementIndex = elementIndex;
				this.value = value;
			}

			public InputEvent(CustomControllerElementSelector.ElementType elementType, int elementIndex, bool value)
			{
				this.elementType = elementType;
				this.elementIndex = elementIndex;
				this.value = (value ? 1f : 0f);
			}

			public bool TargetMatches(CustomControllerElementSelector.ElementType elementType, int elementIndex)
			{
				if (this.elementType == elementType)
				{
					return this.elementIndex == elementIndex;
				}
				return false;
			}

			public void Merge(float value)
			{
				this.value = MathTools.MaxMagnitude(this.value, value);
			}

			public void Merge(bool value)
			{
				if (value)
				{
					this.value = 1f;
				}
			}
		}

		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Custom Controller elements, etc.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private InputManager_Base _rewiredInputManager;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Contains search parameters to find a particular Custom Controller.")]
		private CustomControllerSelector _customControllerSelector = new CustomControllerSelector();

		[Tooltip("Settings for creating a Custom Controller on start.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CreateCustomControllerSettings _createCustomControllerSettings = new CreateCustomControllerSettings();

		private List<InputEvent> _inputEvents = new List<InputEvent>(10);

		[NonSerialized]
		private int _createdCustomControllerId = -1;

		private Action _InputSourceUpdateEvent;

		public InputManager_Base rewiredInputManager
		{
			get
			{
				return _rewiredInputManager;
			}
			set
			{
				if (!(_rewiredInputManager == value))
				{
					_rewiredInputManager = value;
					OnSetProperty();
				}
			}
		}

		public CustomControllerSelector customControllerSelector => _customControllerSelector;

		public CreateCustomControllerSettings createCustomControllerSettings => _createCustomControllerSettings;

		internal event Action InputSourceUpdateEvent
		{
			add
			{
				_InputSourceUpdateEvent = (Action)Delegate.Combine(_InputSourceUpdateEvent, value);
			}
			remove
			{
				_InputSourceUpdateEvent = (Action)Delegate.Remove(_InputSourceUpdateEvent, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal CustomController()
		{
		}

		public Rewired.CustomController GetCustomController()
		{
			return GetCustomController(warn: false);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			_ = base.initialized;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0038;
			IL_000e:
			int num = -572609594;
			goto IL_0013;
			IL_0013:
			switch (num ^ -572609593)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 0:
				goto IL_0038;
			case 3:
				return;
			}
			goto IL_000e;
			IL_0038:
			_inputEvents.Clear();
			num = -572609596;
			goto IL_0013;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				OnSetProperty();
				int num = -1709678258;
				while (true)
				{
					switch (num ^ -1709678257)
					{
					case 0:
						goto IL_000f;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_000f:
					num = -1709678259;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDestroy()
		{
			base.OnDestroy();
			TryDestroyCustomController();
		}

		internal virtual bool OnInitialize()
		{
			if (!base.KeoQNyZvcuilfnGKgmHgqyJYGhr())
			{
				return false;
			}
			if (GetUseCustomController())
			{
				if (!CheckIsRewiredReady())
				{
					return false;
				}
				if (GetCustomController(warn: true) == null)
				{
					SetUseCustomController(value: false);
				}
			}
			return true;
		}

		internal virtual void OnSubscribeEvents()
		{
			base.NjkGaTSbjeAmPqdpyKMonMbyiMJ();
			while (true)
			{
				int num = 859419664;
				while (true)
				{
					switch (num ^ 0x3339B411)
					{
					case 2:
						break;
					case 1:
						goto IL_0028;
					case 3:
						if (!ReInput.isReady)
						{
							return;
						}
						goto default;
					default:
						ReInput.InputSourceUpdateEvent += OnInputSourceUpdate;
						return;
					}
					break;
					IL_0028:
					erHIwspAqyvfsFjxpigiGUNoawW();
					num = 859419666;
				}
			}
		}

		internal virtual void OnUnsubscribeEvents()
		{
			base.erHIwspAqyvfsFjxpigiGUNoawW();
			ReInput.InputSourceUpdateEvent -= OnInputSourceUpdate;
		}

		public override void ClearControlValues()
		{
			base.ClearControlValues();
			while (true)
			{
				int num = -1488358924;
				while (true)
				{
					switch (num ^ -1488358923)
					{
					case 2:
						break;
					default:
						return;
					case 1:
					{
						int num2;
						if (!base.initialized)
						{
							num = -1488358927;
							num2 = num;
						}
						else
						{
							num = -1488358923;
							num2 = num;
						}
						continue;
					}
					case 4:
						return;
					case 0:
						_inputEvents.Clear();
						num = -1488358922;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual bool GetUseCustomController()
		{
			return true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void SetUseCustomController(bool value)
		{
		}

		internal void SetAxisValue(CustomControllerElementSelector element, float value)
		{
			if (!base.initialized)
			{
				return;
			}
			int elementIndex = default(int);
			InputEvent value2 = default(InputEvent);
			int num2 = default(int);
			while (element != null)
			{
				while (true)
				{
					if (!GetUseCustomController())
					{
						return;
					}
					while (true)
					{
						Rewired.CustomController customController = GetCustomController(warn: false);
						int num = 2131769283;
						while (true)
						{
							switch (num ^ 0x7F1037C4)
							{
							case 10:
								num = 2131769281;
								continue;
							default:
								return;
							case 7:
								if (customController == null)
								{
									return;
								}
								goto case 3;
							case 3:
								elementIndex = element.GetElementIndex(customController);
								if (elementIndex < 0)
								{
									return;
								}
								goto case 12;
							case 11:
								break;
							case 1:
								value2 = _inputEvents[num2];
								num = 2131769289;
								continue;
							case 8:
								goto end_IL_007b;
							case 9:
								num2++;
								num = 2131769280;
								continue;
							case 5:
								goto end_IL_00a1;
							case 4:
								if (num2 >= _inputEvents.Count)
								{
									_inputEvents.Add(new InputEvent(element.elementType, elementIndex, value));
									num = 2131769282;
									continue;
								}
								goto case 1;
							case 12:
								_ = _inputEvents.Count;
								num = 2131769286;
								continue;
							case 13:
								if (value2.TargetMatches(element.elementType, elementIndex))
								{
									value2.Merge(value);
									_inputEvents[num2] = value2;
									num = 2131769284;
									continue;
								}
								goto case 9;
							case 2:
								num2 = 0;
								num = 2131769280;
								continue;
							case 0:
								return;
							case 6:
								return;
							}
							break;
						}
						continue;
						end_IL_007b:
						break;
					}
					continue;
					end_IL_00a1:
					break;
				}
			}
		}

		internal void SetButtonValue(CustomControllerElementSelector element, bool value)
		{
			if (!base.initialized)
			{
				return;
			}
			InputEvent value2 = default(InputEvent);
			while (element != null)
			{
				while (true)
				{
					IL_00a4:
					if (!GetUseCustomController())
					{
						return;
					}
					while (true)
					{
						IL_00f2:
						Rewired.CustomController customController = GetCustomController(warn: false);
						if (customController == null)
						{
							return;
						}
						while (true)
						{
							IL_00b7:
							int elementIndex = element.GetElementIndex(customController);
							if (elementIndex < 0)
							{
								return;
							}
							while (true)
							{
								_ = _inputEvents.Count;
								int num = 0;
								int num2 = 324301571;
								while (true)
								{
									switch (num2 ^ 0x13547304)
									{
									case 9:
										num2 = 324301573;
										continue;
									case 5:
										value2 = _inputEvents[num];
										num2 = 324301568;
										continue;
									case 10:
										value2.Merge(value);
										_inputEvents[num] = value2;
										return;
									case 8:
										break;
									case 1:
										goto end_IL_007e;
									case 0:
										goto IL_00a4;
									case 2:
										goto IL_00b7;
									case 4:
										goto IL_00ce;
									case 3:
										goto IL_00f2;
									case 6:
										num++;
										num2 = 324301571;
										continue;
									default:
										if (num >= _inputEvents.Count)
										{
											_inputEvents.Add(new InputEvent(element.elementType, elementIndex, value));
											return;
										}
										goto case 5;
									}
									break;
									IL_00ce:
									int num3;
									if (!value2.TargetMatches(element.elementType, elementIndex))
									{
										num2 = 324301570;
										num3 = num2;
									}
									else
									{
										num2 = 324301582;
										num3 = num2;
									}
								}
								continue;
								end_IL_007e:
								break;
							}
							break;
						}
						break;
					}
					break;
				}
			}
		}

		internal void ClearElementValue(CustomControllerElementTargetSet targetSet)
		{
			if (targetSet == null)
			{
				goto IL_0003;
			}
			goto IL_0041;
			IL_0003:
			int num = 1765137084;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int targetCount = default(int);
			while (true)
			{
				switch (num ^ 0x6935DABD)
				{
				case 0:
					break;
				case 2:
					ClearElementValue(targetSet[num2]);
					num = 1765137080;
					continue;
				case 4:
					goto IL_0041;
				case 1:
					return;
				case 5:
					num2++;
					num = 1765137086;
					continue;
				default:
					if (num2 >= targetCount)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0003;
			IL_0041:
			targetCount = targetSet.targetCount;
			num2 = 0;
			num = 1765137086;
			goto IL_0008;
		}

		internal void ClearElementValue(CustomControllerElementTarget target)
		{
			if (target == null)
			{
				return;
			}
			while (true)
			{
				ClearElementValue(target.element);
				int num = -638787824;
				while (true)
				{
					switch (num ^ -638787823)
					{
					case 0:
						goto IL_0004;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0004:
					num = -638787821;
				}
			}
		}

		internal void ClearElementValue(CustomControllerElementSelector element)
		{
			if (!base.initialized)
			{
				return;
			}
			int num3 = default(int);
			int elementIndex = default(int);
			InputEvent inputEvent = default(InputEvent);
			while (element != null)
			{
				while (true)
				{
					if (!GetUseCustomController())
					{
						return;
					}
					while (true)
					{
						IL_0145:
						Rewired.CustomController customController = GetCustomController(warn: false);
						int num;
						int num2;
						if (customController == null)
						{
							num = 22335267;
							num2 = num;
						}
						else
						{
							num = 22335264;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x154CF2D)
							{
							case 7:
								num = 22335276;
								continue;
							case 6:
								_ = _inputEvents.Count;
								num3 = _inputEvents.Count - 1;
								num = 22335268;
								continue;
							case 8:
								customController.ClearAxisValue(elementIndex);
								num = 22335275;
								continue;
							case 13:
								elementIndex = element.GetElementIndex(customController);
								if (elementIndex < 0)
								{
									return;
								}
								goto case 2;
							case 11:
								break;
							case 5:
								goto IL_00b9;
							case 10:
								inputEvent = _inputEvents[num3];
								num = 22335273;
								continue;
							case 4:
								if (inputEvent.TargetMatches(element.elementType, elementIndex))
								{
									_inputEvents.RemoveAt(num3);
									num = 22335265;
									continue;
								}
								goto case 12;
							case 2:
								switch (element.elementType)
								{
								case CustomControllerElementSelector.ElementType.Axis:
									break;
								case CustomControllerElementSelector.ElementType.Button:
									goto IL_00b9;
								default:
									goto IL_011d;
								}
								goto case 8;
							case 12:
								num3--;
								num = 22335268;
								continue;
							case 3:
								throw new NotImplementedException();
							case 0:
								goto IL_0145;
							case 14:
								return;
							case 1:
								goto end_IL_00a3;
							default:
								{
									if (num3 < 0)
									{
										return;
									}
									goto case 10;
								}
								IL_011d:
								num = 22335278;
								continue;
								IL_00b9:
								customController.ClearButtonValue(elementIndex);
								num = 22335275;
								continue;
							}
							break;
						}
						break;
					}
					continue;
					end_IL_00a3:
					break;
				}
			}
		}

		internal int ElementExists_Editor(CustomControllerElementSelector element)
		{
			if (element == null)
			{
				return -1;
			}
			if (!element.isAssigned)
			{
				goto IL_0010;
			}
			CustomController_Editor customControllerById = default(CustomController_Editor);
			int num;
			if (!(_rewiredInputManager == null))
			{
				if (!_customControllerSelector.findUsingSourceId)
				{
					return -1;
				}
				customControllerById = _rewiredInputManager.userData.GetCustomControllerById(_customControllerSelector.sourceId);
				num = 1804295136;
			}
			else
			{
				num = 1804295139;
			}
			goto IL_0015;
			IL_0010:
			num = 1804295141;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ 0x6B8B5BE2)
				{
				case 8:
					break;
				case 4:
					if (element.elementIndex >= 0)
					{
						if (element.elementIndex >= customControllerById.axisCount)
						{
							num = 1804295143;
							continue;
						}
						return 1;
					}
					goto case 5;
				case 1:
					return -1;
				case 7:
					return -1;
				case 0:
					if (!customControllerById.ContainsElementIdentifier(element.elementId))
					{
						return 0;
					}
					return 1;
				case 3:
					return 0;
				case 2:
					if (customControllerById == null)
					{
						return -1;
					}
					switch (element.selectorType)
					{
					case CustomControllerElementSelector.SelectorType.Id:
						break;
					case CustomControllerElementSelector.SelectorType.Index:
						goto IL_00d0;
					case CustomControllerElementSelector.SelectorType.Name:
						goto IL_0154;
					default:
						throw new NotImplementedException();
					}
					goto case 0;
				case 5:
					return 0;
				default:
					goto IL_0154;
					IL_0154:
					if (!ArrayTools.Contains(customControllerById.GetElementIdentifierNames(), element.elementName))
					{
						return 0;
					}
					return 1;
					IL_00d0:
					switch (element.elementType)
					{
					case CustomControllerElementSelector.ElementType.Axis:
						break;
					default:
						throw new NotImplementedException();
					case CustomControllerElementSelector.ElementType.Button:
						goto IL_0133;
					}
					goto case 4;
					IL_0133:
					if (element.elementIndex >= 0)
					{
						if (element.elementIndex < customControllerById.buttonCount)
						{
							return 1;
						}
						num = 1804295137;
						continue;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0010;
		}

		internal bool ElementExists(CustomControllerElementSelector element)
		{
			if (!base.initialized)
			{
				return false;
			}
			if (element == null)
			{
				return false;
			}
			Rewired.CustomController customController = GetCustomController(warn: false);
			if (customController == null)
			{
				return false;
			}
			return element.GetElementIndex(customController) >= 0;
		}

		internal bool ValidateElements(CustomControllerElementTargetSet targetSet)
		{
			if (targetSet == null)
			{
				return false;
			}
			bool flag = true;
			int targetCount = targetSet.targetCount;
			int num = 0;
			while (num < targetCount)
			{
				while (true)
				{
					flag &= ValidateElement(targetSet[num]);
					num++;
					int num2 = 1303852042;
					while (true)
					{
						switch (num2 ^ 0x4DB7340B)
						{
						case 0:
							num2 = 1303852041;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return flag;
		}

		internal bool ValidateElement(CustomControllerElementTarget target)
		{
			if (target == null)
			{
				return false;
			}
			return ValidateElement(target.element);
		}

		internal bool ValidateElement(CustomControllerElementSelector element)
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!GetUseCustomController())
			{
				return false;
			}
			if (element == null)
			{
				return false;
			}
			if (!element.isAssigned)
			{
				return false;
			}
			Rewired.CustomController customController = GetCustomController(warn: false);
			if (customController == null)
			{
				return false;
			}
			if (!ElementExists(element))
			{
				string[] array = new string[5];
				while (true)
				{
					int num = 1309337734;
					while (true)
					{
						switch (num ^ 0x4E0AE887)
						{
						case 2:
							break;
						case 1:
							goto IL_005e;
						default:
							return false;
						}
						break;
						IL_005e:
						array[0] = "No element found for ";
						array[1] = element.GetSelectorFormattedString();
						array[2] = " in Custom Controller \"";
						array[3] = customController.name;
						array[4] = "\"";
						Logger.LogWarning(string.Concat(array));
						num = 1309337735;
					}
				}
			}
			return true;
		}

		private void OnSetProperty()
		{
			if (base.initialized)
			{
				_inputEvents.Clear();
			}
		}

		private bool CheckIsRewiredReady()
		{
			if (ReInput.isReady)
			{
				return true;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Custom Controller. Custom Controller support will be disabled on this Custom Controller.");
			SetUseCustomController(value: false);
			return false;
		}

		private void ProcessInputEvents()
		{
			if (_inputEvents.Count == 0)
			{
				return;
			}
			InputEvent inputEvent = default(InputEvent);
			int num2 = default(int);
			CustomControllerElementSelector.ElementType elementType2 = default(CustomControllerElementSelector.ElementType);
			CustomControllerElementSelector.ElementType elementType = default(CustomControllerElementSelector.ElementType);
			while (true)
			{
				Rewired.CustomController customController = GetCustomController(warn: false);
				int num;
				if (customController == null)
				{
					_inputEvents.Clear();
					num = 419293920;
					goto IL_0018;
				}
				goto IL_013f;
				IL_0018:
				while (true)
				{
					switch (num ^ 0x18FDEAEC)
					{
					case 8:
						num = 419293934;
						continue;
					case 11:
						num = 419293932;
						continue;
					case 6:
						num = 419293922;
						continue;
					case 1:
						customController.SetAxisValue(inputEvent.elementIndex, inputEvent.value);
						num = 419293926;
						continue;
					case 13:
						inputEvent = _inputEvents[num2];
						elementType2 = inputEvent.elementType;
						num = 419293925;
						continue;
					case 10:
						num2++;
						num = 419293922;
						continue;
					case 14:
						break;
					case 0:
						throw new NotImplementedException();
					case 9:
						elementType = elementType2;
						num = 419293931;
						continue;
					case 12:
						return;
					case 7:
						switch (elementType)
						{
						case CustomControllerElementSelector.ElementType.Axis:
							break;
						default:
							goto IL_0115;
						case CustomControllerElementSelector.ElementType.Button:
							goto IL_014b;
						}
						goto case 1;
					case 2:
						goto end_IL_0018;
					case 5:
						goto IL_013f;
					case 4:
						goto IL_014b;
					default:
						{
							_inputEvents.Clear();
							return;
						}
						IL_014b:
						customController.SetButtonValue(inputEvent.elementIndex, inputEvent.value != 0f);
						num = 419293926;
						continue;
						IL_0115:
						num = 419293927;
						continue;
					}
					int num3;
					if (num2 >= _inputEvents.Count)
					{
						num = 419293935;
						num3 = num;
					}
					else
					{
						num = 419293921;
						num3 = num;
					}
					continue;
					end_IL_0018:
					break;
				}
				continue;
				IL_013f:
				num2 = 0;
				num = 419293930;
				goto IL_0018;
			}
		}

		private Rewired.CustomController GetCustomController(bool warn)
		{
			if (!GetUseCustomController())
			{
				return null;
			}
			if (!ReInput.isReady)
			{
				goto IL_0011;
			}
			if (_createdCustomControllerId < 0)
			{
				goto IL_00f2;
			}
			Rewired.CustomController customController = ReInput.controllers.GetCustomController(_createdCustomControllerId);
			int num;
			if (customController == null)
			{
				_createdCustomControllerId = -1;
				num = 1549867460;
				goto IL_0016;
			}
			goto IL_00fe;
			IL_0016:
			while (true)
			{
				switch (num ^ 0x5C6119C6)
				{
				case 7:
					break;
				case 1:
					return null;
				case 8:
					if (!_createCustomControllerSettings.createCustomController)
					{
						goto case 6;
					}
					customController = ReInput.controllers.CreateCustomController(_createCustomControllerSettings.customControllerSourceId);
					if (customController != null)
					{
						_createdCustomControllerId = customController.id;
						num = 1549867459;
						continue;
					}
					goto case 10;
				case 5:
					TryAssignCustomControllerToPlayer(customController);
					num = 1549867468;
					continue;
				case 2:
					num = 1549867458;
					continue;
				case 6:
					customController = _customControllerSelector.GetCustomController();
					num = 1549867468;
					continue;
				case 0:
					goto IL_00f2;
				case 4:
					goto IL_00fe;
				case 10:
					if (warn && customController == null)
					{
						goto IL_011b;
					}
					goto default;
				case 3:
					Logger.LogWarning("No Custom Controller was found matching the search parameters.");
					num = 1549867471;
					continue;
				default:
					return customController;
				}
				break;
				IL_011b:
				int num2;
				if (!GetUseCustomController())
				{
					num = 1549867471;
					num2 = num;
				}
				else
				{
					num = 1549867461;
					num2 = num;
				}
			}
			goto IL_0011;
			IL_00f2:
			customController = null;
			num = 1549867458;
			goto IL_0016;
			IL_00fe:
			int num3;
			if (customController != null)
			{
				num = 1549867468;
				num3 = num;
			}
			else
			{
				num = 1549867470;
				num3 = num;
			}
			goto IL_0016;
			IL_0011:
			num = 1549867463;
			goto IL_0016;
		}

		private void TryAssignCustomControllerToPlayer(Rewired.CustomController customController)
		{
			if (customController == null)
			{
				return;
			}
			Player player = default(Player);
			while (true)
			{
				int num;
				int num2;
				if (_createCustomControllerSettings.assignToPlayerId != -1)
				{
					num = -1684938195;
					num2 = num;
				}
				else
				{
					num = -1684938196;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1684938197)
					{
					case 0:
						num = -1684938205;
						continue;
					default:
						return;
					case 1:
						return;
					case 4:
						player.controllers.AddController(customController, removeFromOtherPlayers: true);
						num = -1684938200;
						continue;
					case 8:
						break;
					case 6:
						player = ReInput.players.GetPlayer(_createCustomControllerSettings.assignToPlayerId);
						num = -1684938194;
						continue;
					case 7:
						if (!Application.isEditor)
						{
							return;
						}
						Logger.LogWarning("The Custom Controller has not been assigned to any Player and will not be used for input until it is assigned. You should set the Player to assign it to in the inspector.");
						num = -1684938198;
						continue;
					case 2:
						return;
					case 5:
						if (player == null)
						{
							Logger.LogError("Invalid Player Id " + _createCustomControllerSettings.assignToPlayerId + ". Cannot assign Custom Controller to Player.");
							num = -1684938199;
							continue;
						}
						goto case 4;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void TryDestroyCustomController()
		{
			if (_createdCustomControllerId >= 0 && _createCustomControllerSettings.destroyCustomController)
			{
				Rewired.CustomController customController = GetCustomController(warn: false);
				if (customController != null && ReInput.isReady)
				{
					ReInput.controllers.DestroyCustomController(customController);
					_createdCustomControllerId = -1;
				}
			}
		}

		private void OnInputSourceUpdate()
		{
			if (_InputSourceUpdateEvent != null)
			{
				_InputSourceUpdateEvent();
				goto IL_0013;
			}
			goto IL_0031;
			IL_0031:
			ProcessInputEvents();
			int num = -1688477591;
			goto IL_0018;
			IL_0013:
			num = -1688477590;
			goto IL_0018;
			IL_0018:
			switch (num ^ -1688477592)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0031;
			case 1:
				return;
			}
			goto IL_0013;
		}
	}
}
