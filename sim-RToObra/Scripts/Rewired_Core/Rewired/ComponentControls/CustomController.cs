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

			[Tooltip("The source id of the Custom Controller to create. Get this from the Rewired Input Manager.")]
			[CustomObfuscation(rename = false)]
			[SerializeField]
			private int _customControllerSourceId = -1;

			[Tooltip("The Player that will be assigned this Custom Controller when it is created.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _assignToPlayerId;

			[SerializeField]
			[Tooltip("If true, the Custom Controller created by this component will be destroyed when this component is destroyed.")]
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
					if (_createCustomController != value)
					{
						_createCustomController = value;
					}
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
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Custom Controller elements, etc.")]
		[CustomObfuscation(rename = false)]
		private InputManager_Base _rewiredInputManager;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Contains search parameters to find a particular Custom Controller.")]
		private CustomControllerSelector _customControllerSelector = new CustomControllerSelector();

		[SerializeField]
		[Tooltip("Settings for creating a Custom Controller on start.")]
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
				if (_rewiredInputManager == value)
				{
					while (true)
					{
						switch (0x4829C9EE ^ 0x4829C9EC)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_rewiredInputManager = value;
				OnSetProperty();
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
			while (true)
			{
				switch (-25376587 ^ -25376588)
				{
				case 2:
					continue;
				case 1:
					if (!base.initialized)
					{
						return;
					}
					break;
				}
				break;
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
				if (!CheckIsRewiredReady())
				{
					return false;
				}
				if (GetCustomController(true) == null)
				{
					SetUseCustomController(false);
				}
			}
			return true;
		}

		internal override void OnSubscribeEvents()
		{
			base.OnSubscribeEvents();
			while (true)
			{
				int num = 818270591;
				while (true)
				{
					switch (num ^ 0x30C5D17E)
					{
					case 0:
						break;
					case 1:
						goto IL_0028;
					case 2:
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
					OnUnsubscribeEvents();
					num = 818270588;
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
			if (!base.initialized)
			{
				while (true)
				{
					switch (-323664354 ^ -323664356)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			_inputEvents.Clear();
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
				goto IL_0008;
			}
			goto IL_0064;
			IL_0008:
			int num = 1539790129;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			InputEvent value2 = default(InputEvent);
			int elementIndex = default(int);
			while (true)
			{
				switch (num ^ 0x5BC75534)
				{
				case 7:
					break;
				case 2:
					goto IL_0051;
				case 11:
					goto IL_0064;
				case 0:
					num = 1539790140;
					continue;
				case 1:
					goto IL_0079;
				case 6:
				{
					int count = _inputEvents.Count;
					num2 = 0;
					num = 1539790132;
					continue;
				}
				case 9:
					return;
				case 4:
					num2++;
					num = 1539790140;
					continue;
				case 3:
					goto IL_00ca;
				case 10:
					goto IL_00fb;
				case 12:
					value2.Merge(value);
					_inputEvents[num2] = value2;
					return;
				case 5:
					return;
				default:
					if (num2 >= _inputEvents.Count)
					{
						_inputEvents.Add(new InputEvent(element.elementType, elementIndex, value));
						return;
					}
					goto IL_00ca;
				}
				break;
				IL_00ca:
				value2 = _inputEvents[num2];
				int num3;
				if (value2.TargetMatches(element.elementType, elementIndex))
				{
					num = 1539790136;
					num3 = num;
				}
				else
				{
					num = 1539790128;
					num3 = num;
				}
			}
			goto IL_0008;
			IL_0079:
			Rewired.CustomController customController = default(Rewired.CustomController);
			elementIndex = element.GetElementIndex(customController);
			int num4;
			if (elementIndex < 0)
			{
				num = 1539790141;
				num4 = num;
			}
			else
			{
				num = 1539790130;
				num4 = num;
			}
			goto IL_000d;
			IL_00fb:
			if (!GetUseCustomController())
			{
				return;
			}
			goto IL_0051;
			IL_0051:
			customController = GetCustomController(false);
			if (customController == null)
			{
				return;
			}
			goto IL_0079;
			IL_0064:
			if (element == null)
			{
				return;
			}
			goto IL_00fb;
		}

		internal void SetButtonValue(CustomControllerElementSelector element, bool value)
		{
			if (!base.initialized)
			{
				return;
			}
			int num3 = default(int);
			InputEvent value2 = default(InputEvent);
			int elementIndex = default(int);
			Rewired.CustomController customController = default(Rewired.CustomController);
			while (element != null)
			{
				while (true)
				{
					int num;
					int num2;
					if (GetUseCustomController())
					{
						num = 1995998160;
						num2 = num;
					}
					else
					{
						num = 1995998170;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x76F883DA)
						{
						case 6:
							num = 1995998163;
							continue;
						case 5:
							_inputEvents[num3] = value2;
							return;
						case 7:
							elementIndex = element.GetElementIndex(customController);
							if (elementIndex < 0)
							{
								return;
							}
							goto case 2;
						case 1:
							value2 = _inputEvents[num3];
							if (value2.TargetMatches(element.elementType, elementIndex))
							{
								value2.Merge(value);
								num = 1995998175;
								continue;
							}
							goto case 8;
						case 2:
						{
							int count = _inputEvents.Count;
							num3 = 0;
							num = 1995998174;
							continue;
						}
						case 10:
							customController = GetCustomController(false);
							if (customController == null)
							{
								return;
							}
							goto case 7;
						case 8:
							num3++;
							num = 1995998174;
							continue;
						case 3:
							break;
						case 9:
							goto end_IL_00e1;
						case 0:
							return;
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
					continue;
					end_IL_00e1:
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
			int num2 = default(int);
			while (true)
			{
				int targetCount = targetSet.targetCount;
				int num = -416638113;
				while (true)
				{
					switch (num ^ -416638115)
					{
					case 3:
						num = -416638116;
						continue;
					case 1:
						break;
					case 2:
						num2 = 0;
						num = -416638115;
						continue;
					case 4:
						ClearElementValue(targetSet[num2]);
						num2++;
						num = -416638115;
						continue;
					default:
						if (num2 >= targetCount)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		internal void ClearElementValue(CustomControllerElementTarget target)
		{
			if (target != null)
			{
				ClearElementValue(target.element);
			}
		}

		internal void ClearElementValue(CustomControllerElementSelector element)
		{
			if (!base.initialized)
			{
				return;
			}
			int num2 = default(int);
			while (element != null)
			{
				while (true)
				{
					IL_016b:
					if (!GetUseCustomController())
					{
						return;
					}
					while (true)
					{
						IL_00a3:
						Rewired.CustomController customController = GetCustomController(false);
						if (customController == null)
						{
							return;
						}
						while (true)
						{
							IL_00fe:
							int elementIndex = element.GetElementIndex(customController);
							if (elementIndex < 0)
							{
								return;
							}
							while (true)
							{
								IL_00ed:
								CustomControllerElementSelector.ElementType elementType = element.elementType;
								int num = 1246951194;
								while (true)
								{
									switch (num ^ 0x4A52F718)
									{
									case 13:
										num = 1246951199;
										continue;
									case 7:
										break;
									case 2:
										switch (elementType)
										{
										case CustomControllerElementSelector.ElementType.Axis:
											goto IL_0081;
										case CustomControllerElementSelector.ElementType.Button:
											goto IL_0092;
										}
										num = 1246951196;
										continue;
									case 1:
										goto IL_0081;
									case 15:
										goto IL_0092;
									case 5:
										goto IL_00a3;
									case 6:
									{
										int count = _inputEvents.Count;
										num2 = _inputEvents.Count - 1;
										num = 1246951190;
										continue;
									}
									case 11:
										throw new NotImplementedException();
									case 12:
										goto IL_00ed;
									case 9:
										goto IL_00fe;
									case 8:
										num2--;
										num = 1246951190;
										continue;
									case 10:
										num = 1246951198;
										continue;
									case 4:
										num = 1246951187;
										continue;
									case 3:
										if (_inputEvents[num2].TargetMatches(element.elementType, elementIndex))
										{
											_inputEvents.RemoveAt(num2);
											num = 1246951184;
											continue;
										}
										goto case 8;
									case 0:
										goto IL_016b;
									default:
										{
											if (num2 < 0)
											{
												return;
											}
											goto case 3;
										}
										IL_0092:
										customController.ClearButtonValue(elementIndex);
										num = 1246951198;
										continue;
										IL_0081:
										customController.ClearAxisValue(elementIndex);
										num = 1246951186;
										continue;
									}
									break;
								}
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

		internal int ElementExists_Editor(CustomControllerElementSelector element)
		{
			if (element == null)
			{
				goto IL_0003;
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
			switch (element.selectorType)
			{
			case CustomControllerElementSelector.SelectorType.Id:
				break;
			default:
				goto IL_00e1;
			case CustomControllerElementSelector.SelectorType.Index:
				goto IL_0128;
			case CustomControllerElementSelector.SelectorType.Name:
				goto IL_0166;
			}
			goto IL_0058;
			IL_00eb:
			return 0;
			IL_0058:
			int num;
			if (!customControllerById.ContainsElementIdentifier(element.elementId))
			{
				num = 1997840803;
				goto IL_0008;
			}
			return 1;
			IL_0166:
			if (!ArrayTools.Contains(customControllerById.GetElementIdentifierNames(), element.elementName))
			{
				return 0;
			}
			return 1;
			IL_00e1:
			num = 1997840805;
			goto IL_0008;
			IL_0003:
			num = 1997840801;
			goto IL_0008;
			IL_0128:
			switch (element.elementType)
			{
			default:
				throw new NotImplementedException();
			case CustomControllerElementSelector.ElementType.Button:
				break;
			case CustomControllerElementSelector.ElementType.Axis:
				goto IL_0149;
			}
			if (element.elementIndex >= 0)
			{
				if (element.elementIndex < customControllerById.buttonCount)
				{
					return 1;
				}
				num = 1997840806;
				goto IL_0008;
			}
			goto IL_00eb;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x7714A1A2)
				{
				case 0:
					break;
				case 6:
					goto IL_0040;
				case 5:
					goto IL_0058;
				case 3:
					return -1;
				case 4:
					goto IL_00eb;
				case 8:
					return 0;
				case 1:
					return 0;
				case 9:
					goto IL_0149;
				default:
					goto IL_0166;
				case 7:
					throw new NotImplementedException();
				}
				break;
				IL_0040:
				if (element.elementIndex >= customControllerById.axisCount)
				{
					num = 1997840810;
					continue;
				}
				return 1;
			}
			goto IL_0003;
			IL_0149:
			int num2;
			if (element.elementIndex < 0)
			{
				num = 1997840810;
				num2 = num;
			}
			else
			{
				num = 1997840804;
				num2 = num;
			}
			goto IL_0008;
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
			Rewired.CustomController customController = GetCustomController(false);
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
			int num2 = default(int);
			int targetCount = default(int);
			while (true)
			{
				int num = 1674573297;
				while (true)
				{
					switch (num ^ 0x63CFF5F0)
					{
					case 3:
						break;
					case 0:
						flag &= ValidateElement(targetSet[num2]);
						num2++;
						num = 1674573300;
						continue;
					case 2:
						num2 = 0;
						num = 1674573300;
						continue;
					case 4:
					{
						int num3;
						if (num2 >= targetCount)
						{
							num = 1674573301;
							num3 = num;
						}
						else
						{
							num = 1674573296;
							num3 = num;
						}
						continue;
					}
					case 1:
						targetCount = targetSet.targetCount;
						num = 1674573298;
						continue;
					default:
						return flag;
					}
					break;
				}
			}
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
			Rewired.CustomController customController = default(Rewired.CustomController);
			int num;
			if (element != null)
			{
				if (element.isAssigned)
				{
					customController = GetCustomController(false);
					num = 825681090;
				}
				else
				{
					num = 825681093;
				}
			}
			else
			{
				num = 825681089;
			}
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x3136E4C1)
			{
			case 2:
				break;
			case 4:
				return false;
			case 0:
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
			num = 825681088;
			goto IL_000d;
		}

		private void OnSetProperty()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				_inputEvents.Clear();
				int num = -2070346464;
				while (true)
				{
					switch (num ^ -2070346464)
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
					num = -2070346463;
				}
			}
		}

		private bool CheckIsRewiredReady()
		{
			if (ReInput.isReady)
			{
				return true;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Custom Controller. Custom Controller support will be disabled on this Custom Controller.");
			SetUseCustomController(false);
			return false;
		}

		private void ProcessInputEvents()
		{
			if (_inputEvents.Count == 0)
			{
				goto IL_0012;
			}
			goto IL_00c1;
			IL_0012:
			int num = 750639870;
			goto IL_0017;
			IL_0017:
			CustomControllerElementSelector.ElementType elementType = default(CustomControllerElementSelector.ElementType);
			int num2 = default(int);
			InputEvent inputEvent = default(InputEvent);
			Rewired.CustomController customController = default(Rewired.CustomController);
			while (true)
			{
				switch (num ^ 0x2CBDDAF7)
				{
				case 13:
					break;
				case 5:
					switch (elementType)
					{
					case CustomControllerElementSelector.ElementType.Axis:
						goto IL_011f;
					case CustomControllerElementSelector.ElementType.Button:
						goto IL_013d;
					}
					num = 750639857;
					continue;
				case 12:
					num2++;
					num = 750639856;
					continue;
				case 11:
					elementType = inputEvent.elementType;
					num = 750639858;
					continue;
				case 7:
					goto IL_0094;
				case 9:
					return;
				case 3:
					goto IL_00c1;
				case 4:
					inputEvent = _inputEvents[num2];
					num = 750639868;
					continue;
				case 10:
					num2 = 0;
					num = 750639856;
					continue;
				case 0:
					if (customController == null)
					{
						_inputEvents.Clear();
						return;
					}
					goto case 10;
				case 6:
					throw new NotImplementedException();
				case 1:
					goto IL_011f;
				case 8:
					goto IL_013d;
				default:
					{
						_inputEvents.Clear();
						return;
					}
					IL_011f:
					customController.SetAxisValue(inputEvent.elementIndex, inputEvent.value);
					num = 750639867;
					continue;
					IL_013d:
					customController.SetButtonValue(inputEvent.elementIndex, inputEvent.value != 0f);
					num = 750639867;
					continue;
				}
				break;
				IL_0094:
				int num3;
				if (num2 < _inputEvents.Count)
				{
					num = 750639859;
					num3 = num;
				}
				else
				{
					num = 750639861;
					num3 = num;
				}
			}
			goto IL_0012;
			IL_00c1:
			customController = GetCustomController(false);
			num = 750639863;
			goto IL_0017;
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
			Rewired.CustomController customController = default(Rewired.CustomController);
			int num;
			if (_createdCustomControllerId >= 0)
			{
				customController = ReInput.controllers.GetCustomController(_createdCustomControllerId);
				int num2;
				if (customController != null)
				{
					num = 48518318;
					num2 = num;
				}
				else
				{
					num = 48518305;
					num2 = num;
				}
				goto IL_000d;
			}
			goto IL_007a;
			IL_007a:
			customController = null;
			num = 48518318;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x2E454A6)
				{
				case 0:
					break;
				case 5:
					return null;
				case 1:
					goto IL_007a;
				case 6:
					if (warn && customController == null && GetUseCustomController())
					{
						Logger.LogWarning("No Custom Controller was found matching the search parameters.");
						num = 48518308;
						continue;
					}
					goto default;
				case 3:
					customController = ReInput.controllers.CreateCustomController(_createCustomControllerSettings.customControllerSourceId);
					if (customController != null)
					{
						_createdCustomControllerId = customController.id;
						TryAssignCustomControllerToPlayer(customController);
						num = 48518304;
						continue;
					}
					goto case 6;
				case 8:
					if (customController != null)
					{
						goto case 6;
					}
					goto IL_00e7;
				case 7:
					_createdCustomControllerId = -1;
					num = 48518318;
					continue;
				case 4:
					customController = _customControllerSelector.GetCustomController();
					num = 48518304;
					continue;
				default:
					return customController;
				}
				break;
				IL_00e7:
				int num3;
				if (!_createCustomControllerSettings.createCustomController)
				{
					num = 48518306;
					num3 = num;
				}
				else
				{
					num = 48518309;
					num3 = num;
				}
			}
			goto IL_0008;
			IL_0008:
			num = 48518307;
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
				int num;
				int num2;
				if (_createCustomControllerSettings.assignToPlayerId == -1)
				{
					num = -92714701;
					num2 = num;
				}
				else
				{
					num = -92714698;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -92714701)
					{
					case 3:
						num = -92714699;
						continue;
					case 2:
						return;
					case 5:
						player = ReInput.players.GetPlayer(_createCustomControllerSettings.assignToPlayerId);
						if (player == null)
						{
							Logger.LogError("Invalid Player Id " + _createCustomControllerSettings.assignToPlayerId + ". Cannot assign Custom Controller to Player.");
							num = -92714697;
							continue;
						}
						goto default;
					case 4:
						return;
					case 0:
						if (!Application.isEditor)
						{
							return;
						}
						Logger.LogWarning("The Custom Controller has not been assigned to any Player and will not be used for input until it is assigned. You should set the Player to assign it to in the inspector.");
						num = -92714703;
						continue;
					case 6:
						break;
					default:
						player.controllers.AddController(customController, true);
						return;
					}
					break;
				}
			}
		}

		private void TryDestroyCustomController()
		{
			if (_createdCustomControllerId < 0)
			{
				return;
			}
			while (_createCustomControllerSettings.destroyCustomController)
			{
				while (true)
				{
					IL_0058:
					Rewired.CustomController customController = GetCustomController(false);
					if (customController == null)
					{
						return;
					}
					while (true)
					{
						IL_0049:
						if (!ReInput.isReady)
						{
							return;
						}
						while (true)
						{
							IL_006b:
							ReInput.controllers.DestroyCustomController(customController);
							_createdCustomControllerId = -1;
							int num = 2093657275;
							while (true)
							{
								switch (num ^ 0x7CCAACB8)
								{
								case 2:
									num = 2093657273;
									continue;
								default:
									return;
								case 1:
									break;
								case 5:
									goto IL_0049;
								case 0:
									goto IL_0058;
								case 4:
									goto IL_006b;
								case 3:
									return;
								}
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

		private void OnInputSourceUpdate()
		{
			if (_InputSourceUpdateEvent != null)
			{
				_InputSourceUpdateEvent();
			}
			ProcessInputEvents();
		}
	}
}
