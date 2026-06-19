using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using Rewired.Data;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[AddComponentMenu("Rewired/Custom Controller")]
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomController : ComponentController
	{
		[Serializable]
		public class CreateCustomControllerSettings
		{
			[Tooltip("If true, a new Custom Controller will be created. Otherwise, an existing Custom Controller will be found using the selector properties.")]
			[CustomObfuscation(rename = false)]
			[SerializeField]
			private bool _createCustomController = true;

			[Tooltip("The source id of the Custom Controller to create. Get this from the Rewired Input Manager.")]
			[CustomObfuscation(rename = false)]
			[SerializeField]
			private int _customControllerSourceId = -1;

			[CustomObfuscation(rename = false)]
			[Tooltip("The Player that will be assigned this Custom Controller when it is created.")]
			[SerializeField]
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

		private struct LYAhiUcFZMayBLLJgaBStMTCEJGl
		{
			public CustomControllerElementSelector.ElementType vfOgoNYdPlyNOyYmKzOzPipRXne;

			public int UloOtbULeVUrORAYJCJnAyyehmkS;

			public float HpxePuhaScltgSCBmgsrsCpjliL;

			public LYAhiUcFZMayBLLJgaBStMTCEJGl(CustomControllerElementSelector.ElementType elementType, int elementIndex, float value)
			{
				vfOgoNYdPlyNOyYmKzOzPipRXne = elementType;
				UloOtbULeVUrORAYJCJnAyyehmkS = elementIndex;
				HpxePuhaScltgSCBmgsrsCpjliL = value;
			}

			public LYAhiUcFZMayBLLJgaBStMTCEJGl(CustomControllerElementSelector.ElementType elementType, int elementIndex, bool value)
			{
				vfOgoNYdPlyNOyYmKzOzPipRXne = elementType;
				UloOtbULeVUrORAYJCJnAyyehmkS = elementIndex;
				HpxePuhaScltgSCBmgsrsCpjliL = (value ? 1f : 0f);
			}

			public bool hmkPsphheTYdZDOLVHqiRPAqwRH(CustomControllerElementSelector.ElementType P_0, int P_1)
			{
				if (vfOgoNYdPlyNOyYmKzOzPipRXne == P_0)
				{
					return UloOtbULeVUrORAYJCJnAyyehmkS == P_1;
				}
				return false;
			}

			public void XImAuIRApcwcMBrvVxengcVQCDZ(float P_0)
			{
				HpxePuhaScltgSCBmgsrsCpjliL = MathTools.MaxMagnitude(HpxePuhaScltgSCBmgsrsCpjliL, P_0);
			}

			public void XImAuIRApcwcMBrvVxengcVQCDZ(bool P_0)
			{
				if (P_0)
				{
					HpxePuhaScltgSCBmgsrsCpjliL = 1f;
				}
			}
		}

		[SerializeField]
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Custom Controller elements, etc.")]
		[CustomObfuscation(rename = false)]
		private InputManager_Base _rewiredInputManager;

		[Tooltip("Contains search parameters to find a particular Custom Controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerSelector _customControllerSelector = new CustomControllerSelector();

		[Tooltip("Settings for creating a Custom Controller on start.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CreateCustomControllerSettings _createCustomControllerSettings = new CreateCustomControllerSettings();

		private List<LYAhiUcFZMayBLLJgaBStMTCEJGl> XqAzjexJLpltRKUuPNhRPBtFOWW = new List<LYAhiUcFZMayBLLJgaBStMTCEJGl>(10);

		[NonSerialized]
		private int wnejoFRbwIeQKOpoFkrJNSzNGzA = -1;

		private Action uapjRCHVYLXRJmHVSxlSgZLoTDyw;

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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public CustomControllerSelector customControllerSelector => _customControllerSelector;

		public CreateCustomControllerSettings createCustomControllerSettings => _createCustomControllerSettings;

		internal event Action InputSourceUpdateEvent
		{
			add
			{
				uapjRCHVYLXRJmHVSxlSgZLoTDyw = (Action)Delegate.Combine(uapjRCHVYLXRJmHVSxlSgZLoTDyw, value);
			}
			remove
			{
				uapjRCHVYLXRJmHVSxlSgZLoTDyw = (Action)Delegate.Remove(uapjRCHVYLXRJmHVSxlSgZLoTDyw, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal CustomController()
		{
		}

		public Rewired.CustomController GetCustomController()
		{
			return bsfTsyrwELqckGDTZplJtQXhLEf(false);
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
			if (base.initialized)
			{
				XqAzjexJLpltRKUuPNhRPBtFOWW.Clear();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.initialized)
			{
				qdlBanCKskFYgFyewDKidbPGRpbJ();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDestroy()
		{
			base.OnDestroy();
			FGQMDJXIUmODsSDZDbYhTdsDZDS();
		}

		internal virtual bool OnInitialize()
		{
			if (!base.USdTaHHNWIGWTOHgBLrxEkaEfPs())
			{
				return false;
			}
			if (GetUseCustomController())
			{
				if (!PKKDMThTkiBdpZTPzcnUnTCYFQLr())
				{
					return false;
				}
				if (bsfTsyrwELqckGDTZplJtQXhLEf(true) == null)
				{
					SetUseCustomController(value: false);
				}
			}
			return true;
		}

		internal virtual void OnSubscribeEvents()
		{
			base.BxlLqiGbAIUodNYPXhhbDFpwdiA();
			eyUExPEfJOvDMpgTWfZhKmVaJVBB();
			if (ReInput.isReady)
			{
				ReInput.InputSourceUpdateEvent += LiDluCQjLVuCVZMhJkcOXwACQkW;
			}
		}

		internal virtual void OnUnsubscribeEvents()
		{
			base.eyUExPEfJOvDMpgTWfZhKmVaJVBB();
			ReInput.InputSourceUpdateEvent -= LiDluCQjLVuCVZMhJkcOXwACQkW;
		}

		public override void ClearControlValues()
		{
			base.ClearControlValues();
			if (base.initialized)
			{
				XqAzjexJLpltRKUuPNhRPBtFOWW.Clear();
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
			if (!base.initialized || element == null || !GetUseCustomController())
			{
				return;
			}
			Rewired.CustomController customController = bsfTsyrwELqckGDTZplJtQXhLEf(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			_ = XqAzjexJLpltRKUuPNhRPBtFOWW.Count;
			for (int i = 0; i < XqAzjexJLpltRKUuPNhRPBtFOWW.Count; i++)
			{
				LYAhiUcFZMayBLLJgaBStMTCEJGl value2 = XqAzjexJLpltRKUuPNhRPBtFOWW[i];
				if (value2.hmkPsphheTYdZDOLVHqiRPAqwRH(element.elementType, elementIndex))
				{
					value2.XImAuIRApcwcMBrvVxengcVQCDZ(value);
					XqAzjexJLpltRKUuPNhRPBtFOWW[i] = value2;
					return;
				}
			}
			XqAzjexJLpltRKUuPNhRPBtFOWW.Add(new LYAhiUcFZMayBLLJgaBStMTCEJGl(element.elementType, elementIndex, value));
		}

		internal void SetButtonValue(CustomControllerElementSelector element, bool value)
		{
			if (!base.initialized || element == null || !GetUseCustomController())
			{
				return;
			}
			Rewired.CustomController customController = bsfTsyrwELqckGDTZplJtQXhLEf(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			_ = XqAzjexJLpltRKUuPNhRPBtFOWW.Count;
			for (int i = 0; i < XqAzjexJLpltRKUuPNhRPBtFOWW.Count; i++)
			{
				LYAhiUcFZMayBLLJgaBStMTCEJGl value2 = XqAzjexJLpltRKUuPNhRPBtFOWW[i];
				if (value2.hmkPsphheTYdZDOLVHqiRPAqwRH(element.elementType, elementIndex))
				{
					value2.XImAuIRApcwcMBrvVxengcVQCDZ(value);
					XqAzjexJLpltRKUuPNhRPBtFOWW[i] = value2;
					return;
				}
			}
			XqAzjexJLpltRKUuPNhRPBtFOWW.Add(new LYAhiUcFZMayBLLJgaBStMTCEJGl(element.elementType, elementIndex, value));
		}

		internal void ClearElementValue(CustomControllerElementTargetSet targetSet)
		{
			if (targetSet != null)
			{
				int targetCount = targetSet.targetCount;
				for (int i = 0; i < targetCount; i++)
				{
					ClearElementValue(targetSet[i]);
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
			if (!base.initialized || element == null || !GetUseCustomController())
			{
				return;
			}
			Rewired.CustomController customController = bsfTsyrwELqckGDTZplJtQXhLEf(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			switch (element.elementType)
			{
			case CustomControllerElementSelector.ElementType.Axis:
				customController.ClearAxisValue(elementIndex);
				break;
			case CustomControllerElementSelector.ElementType.Button:
				customController.ClearButtonValue(elementIndex);
				break;
			default:
				throw new NotImplementedException();
			}
			_ = XqAzjexJLpltRKUuPNhRPBtFOWW.Count;
			for (int num = XqAzjexJLpltRKUuPNhRPBtFOWW.Count - 1; num >= 0; num--)
			{
				if (XqAzjexJLpltRKUuPNhRPBtFOWW[num].hmkPsphheTYdZDOLVHqiRPAqwRH(element.elementType, elementIndex))
				{
					XqAzjexJLpltRKUuPNhRPBtFOWW.RemoveAt(num);
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
				if (!customControllerById.ContainsElementIdentifier(element.elementId))
				{
					return 0;
				}
				return 1;
			case CustomControllerElementSelector.SelectorType.Index:
				switch (element.elementType)
				{
				case CustomControllerElementSelector.ElementType.Axis:
					if (element.elementIndex < 0 || element.elementIndex >= customControllerById.axisCount)
					{
						return 0;
					}
					return 1;
				case CustomControllerElementSelector.ElementType.Button:
					if (element.elementIndex < 0 || element.elementIndex >= customControllerById.buttonCount)
					{
						return 0;
					}
					return 1;
				default:
					throw new NotImplementedException();
				}
			case CustomControllerElementSelector.SelectorType.Name:
				if (!ArrayTools.Contains(customControllerById.GetElementIdentifierNames(), element.elementName))
				{
					return 0;
				}
				return 1;
			default:
				throw new NotImplementedException();
			}
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
			Rewired.CustomController customController = bsfTsyrwELqckGDTZplJtQXhLEf(false);
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
			for (int i = 0; i < targetCount; i++)
			{
				flag &= ValidateElement(targetSet[i]);
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
			Rewired.CustomController customController = bsfTsyrwELqckGDTZplJtQXhLEf(false);
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

		private void qdlBanCKskFYgFyewDKidbPGRpbJ()
		{
			if (base.initialized)
			{
				XqAzjexJLpltRKUuPNhRPBtFOWW.Clear();
			}
		}

		private bool PKKDMThTkiBdpZTPzcnUnTCYFQLr()
		{
			if (ReInput.isReady)
			{
				return true;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Custom Controller. Custom Controller support will be disabled on this Custom Controller.");
			SetUseCustomController(value: false);
			return false;
		}

		private void XSBlLWUAWfcmTcjMSrQgxnIspdFS()
		{
			if (XqAzjexJLpltRKUuPNhRPBtFOWW.Count == 0)
			{
				return;
			}
			Rewired.CustomController customController = bsfTsyrwELqckGDTZplJtQXhLEf(false);
			if (customController == null)
			{
				XqAzjexJLpltRKUuPNhRPBtFOWW.Clear();
				return;
			}
			for (int i = 0; i < XqAzjexJLpltRKUuPNhRPBtFOWW.Count; i++)
			{
				LYAhiUcFZMayBLLJgaBStMTCEJGl lYAhiUcFZMayBLLJgaBStMTCEJGl = XqAzjexJLpltRKUuPNhRPBtFOWW[i];
				switch (lYAhiUcFZMayBLLJgaBStMTCEJGl.vfOgoNYdPlyNOyYmKzOzPipRXne)
				{
				case CustomControllerElementSelector.ElementType.Axis:
					customController.SetAxisValue(lYAhiUcFZMayBLLJgaBStMTCEJGl.UloOtbULeVUrORAYJCJnAyyehmkS, lYAhiUcFZMayBLLJgaBStMTCEJGl.HpxePuhaScltgSCBmgsrsCpjliL);
					break;
				case CustomControllerElementSelector.ElementType.Button:
					customController.SetButtonValue(lYAhiUcFZMayBLLJgaBStMTCEJGl.UloOtbULeVUrORAYJCJnAyyehmkS, lYAhiUcFZMayBLLJgaBStMTCEJGl.HpxePuhaScltgSCBmgsrsCpjliL != 0f);
					break;
				default:
					throw new NotImplementedException();
				}
			}
			XqAzjexJLpltRKUuPNhRPBtFOWW.Clear();
		}

		private Rewired.CustomController bsfTsyrwELqckGDTZplJtQXhLEf(bool P_0)
		{
			if (!GetUseCustomController())
			{
				return null;
			}
			if (!ReInput.isReady)
			{
				return null;
			}
			Rewired.CustomController customController;
			if (wnejoFRbwIeQKOpoFkrJNSzNGzA >= 0)
			{
				customController = ReInput.controllers.GetCustomController(wnejoFRbwIeQKOpoFkrJNSzNGzA);
				if (customController == null)
				{
					wnejoFRbwIeQKOpoFkrJNSzNGzA = -1;
				}
			}
			else
			{
				customController = null;
			}
			if (customController == null)
			{
				if (_createCustomControllerSettings.createCustomController)
				{
					customController = ReInput.controllers.CreateCustomController(_createCustomControllerSettings.customControllerSourceId);
					if (customController != null)
					{
						wnejoFRbwIeQKOpoFkrJNSzNGzA = customController.id;
						IGNFOrhoHRUKHMLAXKHShaBkdYo(customController);
					}
				}
				else
				{
					customController = _customControllerSelector.GetCustomController();
				}
			}
			if (P_0 && customController == null && GetUseCustomController())
			{
				Logger.LogWarning("No Custom Controller was found matching the search parameters.");
			}
			return customController;
		}

		private void IGNFOrhoHRUKHMLAXKHShaBkdYo(Rewired.CustomController P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			if (_createCustomControllerSettings.assignToPlayerId == -1)
			{
				if (Application.isEditor)
				{
					Logger.LogWarning("The Custom Controller has not been assigned to any Player and will not be used for input until it is assigned. You should set the Player to assign it to in the inspector.");
				}
				return;
			}
			Player player = ReInput.players.GetPlayer(_createCustomControllerSettings.assignToPlayerId);
			if (player == null)
			{
				Logger.LogError("Invalid Player Id " + _createCustomControllerSettings.assignToPlayerId + ". Cannot assign Custom Controller to Player.");
			}
			else
			{
				player.controllers.AddController(P_0, removeFromOtherPlayers: true);
			}
		}

		private void FGQMDJXIUmODsSDZDbYhTdsDZDS()
		{
			if (wnejoFRbwIeQKOpoFkrJNSzNGzA >= 0 && _createCustomControllerSettings.destroyCustomController)
			{
				Rewired.CustomController customController = bsfTsyrwELqckGDTZplJtQXhLEf(false);
				if (customController != null && ReInput.isReady)
				{
					ReInput.controllers.DestroyCustomController(customController);
					wnejoFRbwIeQKOpoFkrJNSzNGzA = -1;
				}
			}
		}

		private void LiDluCQjLVuCVZMhJkcOXwACQkW()
		{
			if (uapjRCHVYLXRJmHVSxlSgZLoTDyw != null)
			{
				uapjRCHVYLXRJmHVSxlSgZLoTDyw();
			}
			XSBlLWUAWfcmTcjMSrQgxnIspdFS();
		}
	}
}
