using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using Rewired.Data;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomController : ComponentController
	{
		[Serializable]
		public class CreateCustomControllerSettings
		{
			[CustomObfuscation(rename = false)]
			[Tooltip("If true, a new Custom Controller will be created. Otherwise, an existing Custom Controller will be found using the selector properties.")]
			[SerializeField]
			private bool _createCustomController = true;

			[CustomObfuscation(rename = false)]
			[SerializeField]
			[Tooltip("The source id of the Custom Controller to create. Get this from the Rewired Input Manager.")]
			private int _customControllerSourceId = -1;

			[SerializeField]
			[Tooltip("The Player that will be assigned this Custom Controller when it is created.")]
			[CustomObfuscation(rename = false)]
			private int _assignToPlayerId;

			[Tooltip("If true, the Custom Controller created by this component will be destroyed when this component is destroyed.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
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
							switch (0x34E58405 ^ 0x34E58404)
							{
							case 0:
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Custom Controller elements, etc.")]
		private InputManager_Base _rewiredInputManager;

		[Tooltip("Contains search parameters to find a particular Custom Controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerSelector _customControllerSelector = new CustomControllerSelector();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings for creating a Custom Controller on start.")]
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
				if (_rewiredInputManager == value)
				{
					return;
				}
				while (true)
				{
					_rewiredInputManager = value;
					int num = 66832616;
					while (true)
					{
						switch (num ^ 0x3FBC8EA)
						{
						case 0:
							goto IL_000f;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000f:
						num = 66832619;
					}
				}
			}
		}

		public CustomControllerSelector customControllerSelector
		{
			get
			{
				return _customControllerSelector;
			}
		}

		public CreateCustomControllerSettings createCustomControllerSettings
		{
			get
			{
				return _createCustomControllerSettings;
			}
		}

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
			return GetCustomController(false);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			bool initialized2 = base.initialized;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (!base.initialized)
			{
				while (true)
				{
					switch (-1945437067 ^ -1945437068)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			_inputEvents.Clear();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.initialized)
			{
				OnSetProperty();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDestroy()
		{
			base.OnDestroy();
			TryDestroyCustomController();
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			if (GetUseCustomController())
			{
				while (true)
				{
					int num = 1175591779;
					while (true)
					{
						switch (num ^ 0x46121B62)
						{
						case 2:
							break;
						case 1:
							goto IL_0030;
						default:
							goto end_IL_0012;
						}
						break;
						IL_0030:
						if (!CheckIsRewiredReady())
						{
							return false;
						}
						if (GetCustomController(true) != null)
						{
							goto end_IL_0012;
						}
						SetUseCustomController(false);
						num = 1175591778;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			return true;
		}

		internal override void OnSubscribeEvents()
		{
			base.OnSubscribeEvents();
			OnUnsubscribeEvents();
			if (!ReInput.isReady)
			{
				return;
			}
			while (true)
			{
				ReInput.InputSourceUpdateEvent += OnInputSourceUpdate;
				int num = -2097228882;
				while (true)
				{
					switch (num ^ -2097228882)
					{
					case 2:
						goto IL_0014;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0014:
					num = -2097228881;
				}
			}
		}

		internal override void OnUnsubscribeEvents()
		{
			base.OnUnsubscribeEvents();
			ReInput.InputSourceUpdateEvent -= OnInputSourceUpdate;
		}

		public override void ClearControlValues()
		{
			base.ClearControlValues();
			while (true)
			{
				int num = -1867961112;
				while (true)
				{
					switch (num ^ -1867961110)
					{
					case 3:
						break;
					case 2:
					{
						int num2;
						if (!base.initialized)
						{
							num = -1867961109;
							num2 = num;
						}
						else
						{
							num = -1867961110;
							num2 = num;
						}
						continue;
					}
					case 1:
						return;
					default:
						_inputEvents.Clear();
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
				goto IL_000b;
			}
			goto IL_00b1;
			IL_000b:
			int num = -1559281537;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			Rewired.CustomController customController = default(Rewired.CustomController);
			int elementIndex = default(int);
			InputEvent value2 = default(InputEvent);
			while (true)
			{
				switch (num ^ -1559281549)
				{
				case 6:
					break;
				case 1:
					num2++;
					num = -1559281551;
					continue;
				case 5:
					return;
				case 8:
					num = -1559281551;
					continue;
				case 15:
					if (customController == null)
					{
						return;
					}
					goto case 0;
				case 12:
					return;
				case 0:
					elementIndex = element.GetElementIndex(customController);
					num = -1559281544;
					continue;
				case 7:
					goto IL_009f;
				case 9:
					goto IL_00b1;
				case 11:
					goto IL_00c2;
				case 4:
					if (value2.TargetMatches(element.elementType, elementIndex))
					{
						value2.Merge(value);
						_inputEvents[num2] = value2;
						num = -1559281552;
						continue;
					}
					goto case 1;
				case 10:
					value2 = _inputEvents[num2];
					num = -1559281545;
					continue;
				case 14:
				{
					int count = _inputEvents.Count;
					num2 = 0;
					num = -1559281541;
					continue;
				}
				case 3:
					return;
				case 13:
					goto IL_0146;
				default:
					if (num2 >= _inputEvents.Count)
					{
						_inputEvents.Add(new InputEvent(element.elementType, elementIndex, value));
						return;
					}
					goto case 10;
				}
				break;
				IL_00c2:
				int num3;
				if (elementIndex < 0)
				{
					num = -1559281546;
					num3 = num;
				}
				else
				{
					num = -1559281539;
					num3 = num;
				}
			}
			goto IL_000b;
			IL_009f:
			customController = GetCustomController(false);
			num = -1559281540;
			goto IL_0010;
			IL_00b1:
			if (element == null)
			{
				return;
			}
			goto IL_0146;
			IL_0146:
			if (!GetUseCustomController())
			{
				return;
			}
			goto IL_009f;
		}

		internal void SetButtonValue(CustomControllerElementSelector element, bool value)
		{
			if (!base.initialized)
			{
				return;
			}
			int elementIndex = default(int);
			Rewired.CustomController customController = default(Rewired.CustomController);
			int num3 = default(int);
			InputEvent value2 = default(InputEvent);
			while (true)
			{
				int num;
				int num2;
				if (element == null)
				{
					num = -2053908485;
					num2 = num;
				}
				else
				{
					num = -2053908486;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2053908487)
					{
					case 4:
						num = -2053908495;
						continue;
					case 3:
						if (!GetUseCustomController())
						{
							return;
						}
						goto case 11;
					case 7:
						return;
					case 8:
						break;
					case 9:
					{
						elementIndex = element.GetElementIndex(customController);
						int num4;
						if (elementIndex >= 0)
						{
							num = -2053908493;
							num4 = num;
						}
						else
						{
							num = -2053908482;
							num4 = num;
						}
						continue;
					}
					case 10:
					{
						int count = _inputEvents.Count;
						num3 = 0;
						num = -2053908487;
						continue;
					}
					case 5:
						num3++;
						num = -2053908487;
						continue;
					case 11:
						customController = GetCustomController(false);
						if (customController == null)
						{
							return;
						}
						goto case 9;
					case 6:
						if (value2.TargetMatches(element.elementType, elementIndex))
						{
							value2.Merge(value);
							_inputEvents[num3] = value2;
							return;
						}
						goto case 5;
					case 2:
						return;
					case 1:
						value2 = _inputEvents[num3];
						num = -2053908481;
						continue;
					default:
						if (num3 >= _inputEvents.Count)
						{
							_inputEvents.Add(new InputEvent(element.elementType, elementIndex, value));
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		internal void ClearElementValue(CustomControllerElementTargetSet targetSet)
		{
			if (targetSet == null)
			{
				return;
			}
			while (true)
			{
				int targetCount = targetSet.targetCount;
				int num = 0;
				int num2 = 272825111;
				while (true)
				{
					switch (num2 ^ 0x1042FB15)
					{
					case 0:
						num2 = 272825108;
						continue;
					case 1:
						break;
					case 3:
						ClearElementValue(targetSet[num]);
						num++;
						num2 = 272825111;
						continue;
					default:
						if (num >= targetCount)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
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
				int num = 120742099;
				while (true)
				{
					switch (num ^ 0x73260D1)
					{
					case 0:
						goto IL_0004;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0004:
					num = 120742096;
				}
			}
		}

		internal void ClearElementValue(CustomControllerElementSelector element)
		{
			if (!base.initialized)
			{
				goto IL_000b;
			}
			goto IL_0118;
			IL_000b:
			int num = -971939943;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			int elementIndex = default(int);
			while (true)
			{
				switch (num ^ -971939947)
				{
				case 2:
					break;
				case 9:
					goto IL_0060;
				case 10:
				{
					int count = _inputEvents.Count;
					num = -971939951;
					continue;
				}
				case 4:
					num2 = _inputEvents.Count - 1;
					num = -971939941;
					continue;
				case 3:
					throw new NotImplementedException();
				case 0:
					goto IL_00a9;
				case 8:
					goto IL_00ba;
				case 15:
					goto IL_00d1;
				case 5:
					if (_inputEvents[num2].TargetMatches(element.elementType, elementIndex))
					{
						_inputEvents.RemoveAt(num2);
						num = -971939948;
						continue;
					}
					goto case 1;
				case 7:
					goto IL_0118;
				case 1:
					num2--;
					num = -971939941;
					continue;
				case 13:
					goto IL_0134;
				case 11:
					goto IL_0153;
				case 12:
					return;
				case 6:
					num = -971939946;
					continue;
				default:
					if (num2 < 0)
					{
						return;
					}
					goto case 5;
				}
				break;
			}
			goto IL_000b;
			IL_00a9:
			Rewired.CustomController customController = default(Rewired.CustomController);
			customController.ClearButtonValue(elementIndex);
			num = -971939937;
			goto IL_0010;
			IL_0060:
			customController.ClearAxisValue(elementIndex);
			num = -971939937;
			goto IL_0010;
			IL_0149:
			num = -971939949;
			goto IL_0010;
			IL_0118:
			if (element == null)
			{
				return;
			}
			goto IL_00d1;
			IL_0134:
			switch (element.elementType)
			{
			case CustomControllerElementSelector.ElementType.Axis:
				break;
			case CustomControllerElementSelector.ElementType.Button:
				goto IL_00a9;
			default:
				goto IL_0149;
			}
			goto IL_0060;
			IL_00d1:
			if (!GetUseCustomController())
			{
				return;
			}
			goto IL_0153;
			IL_0153:
			customController = GetCustomController(false);
			if (customController == null)
			{
				return;
			}
			goto IL_00ba;
			IL_00ba:
			elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			goto IL_0134;
		}

		internal int ElementExists_Editor(CustomControllerElementSelector element)
		{
			if (element == null)
			{
				return -1;
			}
			if (!element.isAssigned)
			{
				return -1;
			}
			if (_rewiredInputManager == null)
			{
				return -1;
			}
			if (!_customControllerSelector.findUsingSourceId)
			{
				return -1;
			}
			CustomController_Editor customControllerById = _rewiredInputManager.userData.GetCustomControllerById(_customControllerSelector.sourceId);
			if (customControllerById == null)
			{
				return -1;
			}
			int num;
			CustomControllerElementSelector.ElementType elementType = default(CustomControllerElementSelector.ElementType);
			switch (element.selectorType)
			{
			default:
				num = -955432962;
				goto IL_006d;
			case CustomControllerElementSelector.SelectorType.Id:
				goto IL_00fc;
			case CustomControllerElementSelector.SelectorType.Index:
				elementType = element.elementType;
				num = -955432968;
				goto IL_006d;
			case CustomControllerElementSelector.SelectorType.Name:
				break;
				IL_006d:
				while (true)
				{
					switch (num ^ -955432967)
					{
					case 4:
						break;
					case 3:
						goto IL_00b1;
					case 6:
						throw new NotImplementedException();
					case 0:
						goto IL_00c2;
					case 5:
						return 0;
					case 9:
						goto IL_00fc;
					case 1:
						goto IL_011f;
					case 8:
						goto IL_0146;
					default:
						goto end_IL_0057;
					case 7:
						throw new NotImplementedException();
					}
					break;
					IL_011f:
					switch (elementType)
					{
					case CustomControllerElementSelector.ElementType.Button:
						break;
					default:
						goto IL_012d;
					case CustomControllerElementSelector.ElementType.Axis:
						goto IL_0146;
					}
					if (element.elementIndex >= 0)
					{
						if (element.elementIndex < customControllerById.buttonCount)
						{
							return 1;
						}
						num = -955432966;
						continue;
					}
					goto IL_00b1;
					IL_0146:
					int num2;
					if (element.elementIndex >= 0)
					{
						num = -955432967;
						num2 = num;
					}
					else
					{
						num = -955432964;
						num2 = num;
					}
					continue;
					IL_00c2:
					if (element.elementIndex >= customControllerById.axisCount)
					{
						num = -955432964;
						continue;
					}
					return 1;
					IL_00b1:
					return 0;
					IL_012d:
					num = -955432961;
				}
				goto default;
				IL_00fc:
				if (!customControllerById.ContainsElementIdentifier(element.elementId))
				{
					return 0;
				}
				return 1;
				end_IL_0057:
				break;
			}
			if (!ArrayTools.Contains(customControllerById.GetElementIdentifierNames(), element.elementName))
			{
				return 0;
			}
			return 1;
		}

		internal bool ElementExists(CustomControllerElementSelector element)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			int num;
			if (element == null)
			{
				num = 673406330;
				goto IL_000d;
			}
			Rewired.CustomController customController = GetCustomController(false);
			if (customController == null)
			{
				return false;
			}
			return element.GetElementIndex(customController) >= 0;
			IL_000d:
			switch (num ^ 0x28235D78)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0008;
			IL_0008:
			num = 673406329;
			goto IL_000d;
		}

		internal bool ValidateElements(CustomControllerElementTargetSet targetSet)
		{
			if (targetSet == null)
			{
				goto IL_0003;
			}
			bool flag = true;
			int targetCount = targetSet.targetCount;
			int num = 0;
			int num2 = 2007217439;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ 0x77A3B51B)
				{
				case 3:
					break;
				case 2:
					flag &= ValidateElement(targetSet[num]);
					num2 = 2007217438;
					continue;
				case 5:
					num++;
					num2 = 2007217435;
					continue;
				case 1:
					return false;
				case 4:
					num2 = 2007217435;
					continue;
				default:
					if (num >= targetCount)
					{
						return flag;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = 2007217434;
			goto IL_0008;
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
				goto IL_0008;
			}
			if (!GetUseCustomController())
			{
				return false;
			}
			int num;
			Rewired.CustomController customController = default(Rewired.CustomController);
			if (element == null)
			{
				num = 1562344425;
			}
			else
			{
				if (!element.isAssigned)
				{
					return false;
				}
				customController = GetCustomController(false);
				num = 1562344426;
			}
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x5D1F7BE8)
			{
			case 0:
				break;
			case 3:
				return false;
			case 1:
				return false;
			default:
				if (customController == null)
				{
					return false;
				}
				if (!ElementExists(element))
				{
					Logger.LogWarning("No element found for " + element.GetSelectorFormattedString() + " in Custom Controller \"" + customController.name + "\"");
					return false;
				}
				return true;
			}
			goto IL_0008;
			IL_0008:
			num = 1562344427;
			goto IL_000d;
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
				goto IL_0007;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Custom Controller. Custom Controller support will be disabled on this Custom Controller.");
			int num = -184281198;
			goto IL_000c;
			IL_000c:
			switch (num ^ -184281197)
			{
			case 0:
				break;
			case 2:
				return true;
			default:
				SetUseCustomController(false);
				return false;
			}
			goto IL_0007;
			IL_0007:
			num = -184281199;
			goto IL_000c;
		}

		private void ProcessInputEvents()
		{
			int count = _inputEvents.Count;
			Rewired.CustomController customController = default(Rewired.CustomController);
			InputEvent inputEvent = default(InputEvent);
			int num2 = default(int);
			CustomControllerElementSelector.ElementType elementType = default(CustomControllerElementSelector.ElementType);
			while (true)
			{
				int num = 1998850868;
				while (true)
				{
					switch (num ^ 0x77240B3F)
					{
					case 12:
						break;
					case 11:
					{
						int num3;
						if (count != 0)
						{
							num = 1998850877;
							num3 = num;
						}
						else
						{
							num = 1998850869;
							num3 = num;
						}
						continue;
					}
					case 2:
						customController = GetCustomController(false);
						num = 1998850866;
						continue;
					case 9:
						customController.SetAxisValue(inputEvent.elementIndex, inputEvent.value);
						num = 1998850872;
						continue;
					case 4:
						throw new NotImplementedException();
					case 1:
					{
						inputEvent = _inputEvents[num2];
						CustomControllerElementSelector.ElementType elementType2 = inputEvent.elementType;
						elementType = elementType2;
						num = 1998850874;
						continue;
					}
					case 5:
						switch (elementType)
						{
						case CustomControllerElementSelector.ElementType.Axis:
							break;
						default:
							goto IL_00dd;
						case CustomControllerElementSelector.ElementType.Button:
							goto IL_011a;
						}
						goto case 9;
					case 13:
						if (customController == null)
						{
							_inputEvents.Clear();
							return;
						}
						goto case 8;
					case 7:
						num2++;
						num = 1998850876;
						continue;
					case 8:
						num2 = 0;
						num = 1998850876;
						continue;
					case 0:
						goto IL_011a;
					case 10:
						return;
					case 6:
						num = 1998850872;
						continue;
					default:
						{
							if (num2 >= _inputEvents.Count)
							{
								_inputEvents.Clear();
								return;
							}
							goto case 1;
						}
						IL_011a:
						customController.SetButtonValue(inputEvent.elementIndex, inputEvent.value != 0f);
						num = 1998850873;
						continue;
						IL_00dd:
						num = 1998850875;
						continue;
					}
					break;
				}
			}
		}

		private Rewired.CustomController GetCustomController(bool warn)
		{
			if (!GetUseCustomController())
			{
				goto IL_0008;
			}
			if (!ReInput.isReady)
			{
				return null;
			}
			int num;
			int num2;
			if (_createdCustomControllerId < 0)
			{
				num = 583601120;
				num2 = num;
			}
			else
			{
				num = 583601133;
				num2 = num;
			}
			goto IL_000d;
			IL_000d:
			Rewired.CustomController customController = default(Rewired.CustomController);
			while (true)
			{
				switch (num ^ 0x22C90BEB)
				{
				case 8:
					break;
				case 1:
					TryAssignCustomControllerToPlayer(customController);
					num = 583601134;
					continue;
				case 2:
					customController = _customControllerSelector.GetCustomController();
					num = 583601132;
					continue;
				case 3:
					return null;
				case 7:
				{
					int num4;
					if (warn)
					{
						num = 583601135;
						num4 = num;
					}
					else
					{
						num = 583601131;
						num4 = num;
					}
					continue;
				}
				case 9:
				{
					int num3;
					if (customController == null)
					{
						num = 583601127;
						num3 = num;
					}
					else
					{
						num = 583601121;
						num3 = num;
					}
					continue;
				}
				case 5:
					num = 583601132;
					continue;
				case 4:
					if (customController == null && GetUseCustomController())
					{
						Logger.LogWarning("No Custom Controller was found matching the search parameters.");
						num = 583601131;
						continue;
					}
					goto default;
				case 11:
					customController = null;
					num = 583601121;
					continue;
				case 6:
					customController = ReInput.controllers.GetCustomController(_createdCustomControllerId);
					num = 583601122;
					continue;
				case 10:
					if (customController == null)
					{
						if (!_createCustomControllerSettings.createCustomController)
						{
							goto case 2;
						}
						customController = ReInput.controllers.CreateCustomController(_createCustomControllerSettings.customControllerSourceId);
						if (customController != null)
						{
							_createdCustomControllerId = customController.id;
							num = 583601130;
							continue;
						}
					}
					goto case 7;
				case 12:
					_createdCustomControllerId = -1;
					num = 583601121;
					continue;
				default:
					return customController;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num = 583601128;
			goto IL_000d;
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
				IL_009b:
				int num;
				if (_createCustomControllerSettings.assignToPlayerId == -1)
				{
					if (!Application.isEditor)
					{
						break;
					}
					Logger.LogWarning("The Custom Controller has not been assigned to any Player and will not be used for input until it is assigned. You should set the Player to assign it to in the inspector.");
					num = 1953800426;
					goto IL_000c;
				}
				goto IL_0048;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x7474A0EB)
					{
					case 3:
						num = 1953800430;
						continue;
					default:
						return;
					case 2:
						break;
					case 0:
						goto IL_0048;
					case 1:
						return;
					case 5:
						goto IL_009b;
					case 4:
						return;
					}
					break;
				}
				goto IL_0034;
				IL_0034:
				player.controllers.AddController(customController, true);
				num = 1953800431;
				goto IL_000c;
				IL_0048:
				player = ReInput.players.GetPlayer(_createCustomControllerSettings.assignToPlayerId);
				if (player == null)
				{
					Logger.LogError("Invalid Player Id " + _createCustomControllerSettings.assignToPlayerId + ". Cannot assign Custom Controller to Player.");
					break;
				}
				goto IL_0034;
			}
		}

		private void TryDestroyCustomController()
		{
			if (_createdCustomControllerId < 0)
			{
				while (true)
				{
					switch (-1242356446 ^ -1242356441)
					{
					case 0:
						break;
					case 5:
						return;
					case 2:
						goto end_IL_0009;
					case 3:
						goto IL_004a;
					case 1:
						goto IL_005f;
					default:
						goto IL_0072;
					}
					continue;
					end_IL_0009:
					break;
				}
				goto IL_003b;
			}
			goto IL_004a;
			IL_0072:
			Rewired.CustomController customController = default(Rewired.CustomController);
			ReInput.controllers.DestroyCustomController(customController);
			_createdCustomControllerId = -1;
			return;
			IL_004a:
			if (!_createCustomControllerSettings.destroyCustomController)
			{
				return;
			}
			goto IL_005f;
			IL_005f:
			customController = GetCustomController(false);
			if (customController == null)
			{
				return;
			}
			goto IL_003b;
			IL_003b:
			if (!ReInput.isReady)
			{
				return;
			}
			goto IL_0072;
		}

		private void OnInputSourceUpdate()
		{
			if (_InputSourceUpdateEvent != null)
			{
				while (true)
				{
					int num = 340979273;
					while (true)
					{
						switch (num ^ 0x1452EE48)
						{
						case 0:
							break;
						case 1:
							_InputSourceUpdateEvent();
							num = 340979274;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			ProcessInputEvents();
		}
	}
}
