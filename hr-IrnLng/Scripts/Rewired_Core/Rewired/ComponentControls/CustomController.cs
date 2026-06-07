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

		private struct lRmrHsqLcFcVTSRrpRQFOFioHXm
		{
			public CustomControllerElementSelector.ElementType LSmTRdvHuagVChPSPaniDTWrvDKL;

			public int wHCEUJitVESWMGMqQdXkciHhAsCv;

			public float lvXCTCWOhrCtuFDbbEqyqyUVPhp;

			public lRmrHsqLcFcVTSRrpRQFOFioHXm(CustomControllerElementSelector.ElementType elementType, int elementIndex, float value)
			{
				LSmTRdvHuagVChPSPaniDTWrvDKL = elementType;
				wHCEUJitVESWMGMqQdXkciHhAsCv = elementIndex;
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = value;
			}

			public lRmrHsqLcFcVTSRrpRQFOFioHXm(CustomControllerElementSelector.ElementType elementType, int elementIndex, bool value)
			{
				LSmTRdvHuagVChPSPaniDTWrvDKL = elementType;
				wHCEUJitVESWMGMqQdXkciHhAsCv = elementIndex;
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = (value ? 1f : 0f);
			}

			public bool TyAacSKSOAvqZSAcEHUnZdyICsr(CustomControllerElementSelector.ElementType P_0, int P_1)
			{
				if (LSmTRdvHuagVChPSPaniDTWrvDKL == P_0)
				{
					return wHCEUJitVESWMGMqQdXkciHhAsCv == P_1;
				}
				return false;
			}

			public void hPOzNiwavldFMYQXIDniqgXapIz(float P_0)
			{
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = MathTools.MaxMagnitude(lvXCTCWOhrCtuFDbbEqyqyUVPhp, P_0);
			}

			public void hPOzNiwavldFMYQXIDniqgXapIz(bool P_0)
			{
				if (P_0)
				{
					lvXCTCWOhrCtuFDbbEqyqyUVPhp = 1f;
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

		private List<lRmrHsqLcFcVTSRrpRQFOFioHXm> xdwMOMIOkuEXZJCKUxXAPCAtQUe = new List<lRmrHsqLcFcVTSRrpRQFOFioHXm>(10);

		[NonSerialized]
		private int WuGBOdcgXJdHSfLEIRaIyBSnmCmb = -1;

		private Action KTLrwuiGjGUcPQzxFhtPZjyUcXS;

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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
				}
			}
		}

		public CustomControllerSelector customControllerSelector => _customControllerSelector;

		public CreateCustomControllerSettings createCustomControllerSettings => _createCustomControllerSettings;

		internal event Action InputSourceUpdateEvent
		{
			add
			{
				KTLrwuiGjGUcPQzxFhtPZjyUcXS = (Action)Delegate.Combine(KTLrwuiGjGUcPQzxFhtPZjyUcXS, value);
			}
			remove
			{
				KTLrwuiGjGUcPQzxFhtPZjyUcXS = (Action)Delegate.Remove(KTLrwuiGjGUcPQzxFhtPZjyUcXS, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal CustomController()
		{
		}

		public Rewired.CustomController GetCustomController()
		{
			return XLOkGOGTJTTMgVorWpHofbbxLFg(false);
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
				xdwMOMIOkuEXZJCKUxXAPCAtQUe.Clear();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.initialized)
			{
				MxNDYRdNWvbuwnEvdAejdyZphUD();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDestroy()
		{
			base.OnDestroy();
			zCwAtpeorhClkhFfYLduhTJpVRuu();
		}

		internal virtual bool OnInitialize()
		{
			if (!base.yTsKtkkrFvbLTmEALJcKJZadFG())
			{
				return false;
			}
			if (GetUseCustomController())
			{
				if (!tEqphnoHVvCOndCzqPfTWFzclCvm())
				{
					return false;
				}
				if (XLOkGOGTJTTMgVorWpHofbbxLFg(true) == null)
				{
					SetUseCustomController(value: false);
				}
			}
			return true;
		}

		internal virtual void OnSubscribeEvents()
		{
			base.dJZdkEnsfJibdbIbYyjwTTIGMtqV();
			EryQQjAUaPnoItWfLGLmyUsSpHl();
			if (ReInput.isReady)
			{
				ReInput.InputSourceUpdateEvent += dzjATuhbuUkfLYIJCbgHnJvyfsed;
			}
		}

		internal virtual void OnUnsubscribeEvents()
		{
			base.EryQQjAUaPnoItWfLGLmyUsSpHl();
			ReInput.InputSourceUpdateEvent -= dzjATuhbuUkfLYIJCbgHnJvyfsed;
		}

		public override void ClearControlValues()
		{
			base.ClearControlValues();
			if (base.initialized)
			{
				xdwMOMIOkuEXZJCKUxXAPCAtQUe.Clear();
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
			Rewired.CustomController customController = XLOkGOGTJTTMgVorWpHofbbxLFg(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			_ = xdwMOMIOkuEXZJCKUxXAPCAtQUe.Count;
			for (int i = 0; i < xdwMOMIOkuEXZJCKUxXAPCAtQUe.Count; i++)
			{
				lRmrHsqLcFcVTSRrpRQFOFioHXm value2 = xdwMOMIOkuEXZJCKUxXAPCAtQUe[i];
				if (value2.TyAacSKSOAvqZSAcEHUnZdyICsr(element.elementType, elementIndex))
				{
					value2.hPOzNiwavldFMYQXIDniqgXapIz(value);
					xdwMOMIOkuEXZJCKUxXAPCAtQUe[i] = value2;
					return;
				}
			}
			xdwMOMIOkuEXZJCKUxXAPCAtQUe.Add(new lRmrHsqLcFcVTSRrpRQFOFioHXm(element.elementType, elementIndex, value));
		}

		internal void SetButtonValue(CustomControllerElementSelector element, bool value)
		{
			if (!base.initialized || element == null || !GetUseCustomController())
			{
				return;
			}
			Rewired.CustomController customController = XLOkGOGTJTTMgVorWpHofbbxLFg(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			_ = xdwMOMIOkuEXZJCKUxXAPCAtQUe.Count;
			for (int i = 0; i < xdwMOMIOkuEXZJCKUxXAPCAtQUe.Count; i++)
			{
				lRmrHsqLcFcVTSRrpRQFOFioHXm value2 = xdwMOMIOkuEXZJCKUxXAPCAtQUe[i];
				if (value2.TyAacSKSOAvqZSAcEHUnZdyICsr(element.elementType, elementIndex))
				{
					value2.hPOzNiwavldFMYQXIDniqgXapIz(value);
					xdwMOMIOkuEXZJCKUxXAPCAtQUe[i] = value2;
					return;
				}
			}
			xdwMOMIOkuEXZJCKUxXAPCAtQUe.Add(new lRmrHsqLcFcVTSRrpRQFOFioHXm(element.elementType, elementIndex, value));
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
			Rewired.CustomController customController = XLOkGOGTJTTMgVorWpHofbbxLFg(false);
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
			_ = xdwMOMIOkuEXZJCKUxXAPCAtQUe.Count;
			for (int num = xdwMOMIOkuEXZJCKUxXAPCAtQUe.Count - 1; num >= 0; num--)
			{
				if (xdwMOMIOkuEXZJCKUxXAPCAtQUe[num].TyAacSKSOAvqZSAcEHUnZdyICsr(element.elementType, elementIndex))
				{
					xdwMOMIOkuEXZJCKUxXAPCAtQUe.RemoveAt(num);
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
			Rewired.CustomController customController = XLOkGOGTJTTMgVorWpHofbbxLFg(false);
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
			Rewired.CustomController customController = XLOkGOGTJTTMgVorWpHofbbxLFg(false);
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

		private void MxNDYRdNWvbuwnEvdAejdyZphUD()
		{
			if (base.initialized)
			{
				xdwMOMIOkuEXZJCKUxXAPCAtQUe.Clear();
			}
		}

		private bool tEqphnoHVvCOndCzqPfTWFzclCvm()
		{
			if (ReInput.isReady)
			{
				return true;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Custom Controller. Custom Controller support will be disabled on this Custom Controller.");
			SetUseCustomController(value: false);
			return false;
		}

		private void hFhAiaIxdsMFHcmsXAArNhfWgnrx()
		{
			if (xdwMOMIOkuEXZJCKUxXAPCAtQUe.Count == 0)
			{
				return;
			}
			Rewired.CustomController customController = XLOkGOGTJTTMgVorWpHofbbxLFg(false);
			if (customController == null)
			{
				xdwMOMIOkuEXZJCKUxXAPCAtQUe.Clear();
				return;
			}
			for (int i = 0; i < xdwMOMIOkuEXZJCKUxXAPCAtQUe.Count; i++)
			{
				lRmrHsqLcFcVTSRrpRQFOFioHXm lRmrHsqLcFcVTSRrpRQFOFioHXm2 = xdwMOMIOkuEXZJCKUxXAPCAtQUe[i];
				switch (lRmrHsqLcFcVTSRrpRQFOFioHXm2.LSmTRdvHuagVChPSPaniDTWrvDKL)
				{
				case CustomControllerElementSelector.ElementType.Axis:
					customController.SetAxisValue(lRmrHsqLcFcVTSRrpRQFOFioHXm2.wHCEUJitVESWMGMqQdXkciHhAsCv, lRmrHsqLcFcVTSRrpRQFOFioHXm2.lvXCTCWOhrCtuFDbbEqyqyUVPhp);
					break;
				case CustomControllerElementSelector.ElementType.Button:
					customController.SetButtonValue(lRmrHsqLcFcVTSRrpRQFOFioHXm2.wHCEUJitVESWMGMqQdXkciHhAsCv, lRmrHsqLcFcVTSRrpRQFOFioHXm2.lvXCTCWOhrCtuFDbbEqyqyUVPhp != 0f);
					break;
				default:
					throw new NotImplementedException();
				}
			}
			xdwMOMIOkuEXZJCKUxXAPCAtQUe.Clear();
		}

		private Rewired.CustomController XLOkGOGTJTTMgVorWpHofbbxLFg(bool P_0)
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
			if (WuGBOdcgXJdHSfLEIRaIyBSnmCmb >= 0)
			{
				customController = ReInput.controllers.GetCustomController(WuGBOdcgXJdHSfLEIRaIyBSnmCmb);
				if (customController == null)
				{
					WuGBOdcgXJdHSfLEIRaIyBSnmCmb = -1;
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
						WuGBOdcgXJdHSfLEIRaIyBSnmCmb = customController.id;
						garaJqAmHWhgPRqkUEEPlkwCtxI(customController);
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

		private void garaJqAmHWhgPRqkUEEPlkwCtxI(Rewired.CustomController P_0)
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

		private void zCwAtpeorhClkhFfYLduhTJpVRuu()
		{
			if (WuGBOdcgXJdHSfLEIRaIyBSnmCmb >= 0 && _createCustomControllerSettings.destroyCustomController)
			{
				Rewired.CustomController customController = XLOkGOGTJTTMgVorWpHofbbxLFg(false);
				if (customController != null && ReInput.isReady)
				{
					ReInput.controllers.DestroyCustomController(customController);
					WuGBOdcgXJdHSfLEIRaIyBSnmCmb = -1;
				}
			}
		}

		private void dzjATuhbuUkfLYIJCbgHnJvyfsed()
		{
			if (KTLrwuiGjGUcPQzxFhtPZjyUcXS != null)
			{
				KTLrwuiGjGUcPQzxFhtPZjyUcXS();
			}
			hFhAiaIxdsMFHcmsXAArNhfWgnrx();
		}
	}
}
