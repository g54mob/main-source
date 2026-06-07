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
	[AddComponentMenu("Rewired/Component Controls/Custom Controller")]
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

			[SerializeField]
			[Tooltip("The source id of the Custom Controller to create. Get this from the Rewired Input Manager.")]
			[CustomObfuscation(rename = false)]
			private int _customControllerSourceId = -1;

			[CustomObfuscation(rename = false)]
			[Tooltip("The Player that will be assigned this Custom Controller when it is created.")]
			[SerializeField]
			private int _assignToPlayerId;

			[CustomObfuscation(rename = false)]
			[Tooltip("If true, the Custom Controller created by this component will be destroyed when this component is destroyed.")]
			[SerializeField]
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

		private struct MdQdoDfHfbLfWFKXhNstanVhiXsCA
		{
			public CustomControllerElementSelector.ElementType ugEcvEUjcYzrLriOHSDCiapaTNEm;

			public int JnaqnwUXKgDmJYmGIqyOLHqXtkYU;

			public float ANnyYrpgRHgHrBXsbJxMFrsUzupD;

			public MdQdoDfHfbLfWFKXhNstanVhiXsCA(CustomControllerElementSelector.ElementType P_0, int P_1, float P_2)
			{
				ugEcvEUjcYzrLriOHSDCiapaTNEm = P_0;
				JnaqnwUXKgDmJYmGIqyOLHqXtkYU = P_1;
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = P_2;
			}

			public MdQdoDfHfbLfWFKXhNstanVhiXsCA(CustomControllerElementSelector.ElementType P_0, int P_1, bool P_2)
			{
				ugEcvEUjcYzrLriOHSDCiapaTNEm = P_0;
				JnaqnwUXKgDmJYmGIqyOLHqXtkYU = P_1;
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = (P_2 ? 1f : 0f);
			}

			public bool aMwTbzrVEsLpQOIuMafTaBuZcppe(CustomControllerElementSelector.ElementType P_0, int P_1)
			{
				if (ugEcvEUjcYzrLriOHSDCiapaTNEm == P_0)
				{
					return JnaqnwUXKgDmJYmGIqyOLHqXtkYU == P_1;
				}
				return false;
			}

			public void IdwGKNJkaXjzHIJrWUaMXhwlhIpX(float P_0)
			{
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = MathTools.MaxMagnitude(ANnyYrpgRHgHrBXsbJxMFrsUzupD, P_0);
			}

			public void IdwGKNJkaXjzHIJrWUaMXhwlhIpX(bool P_0)
			{
				if (P_0)
				{
					ANnyYrpgRHgHrBXsbJxMFrsUzupD = 1f;
				}
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Custom Controller elements, etc.")]
		private InputManager_Base _rewiredInputManager;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Contains search parameters to find a particular Custom Controller.")]
		private CustomControllerSelector _customControllerSelector = new CustomControllerSelector();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings for creating a Custom Controller on start.")]
		private CreateCustomControllerSettings _createCustomControllerSettings = new CreateCustomControllerSettings();

		private List<MdQdoDfHfbLfWFKXhNstanVhiXsCA> MJQvpjlWbKNkARNaYNQsoxhoTGqq = new List<MdQdoDfHfbLfWFKXhNstanVhiXsCA>(10);

		[NonSerialized]
		private int rLsxEKPBShdONDDyEFTmwMxyHIqv = -1;

		private Action nbhdZVJncuHWMBGRRnAbDyNXqRGqA;

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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public CustomControllerSelector customControllerSelector => _customControllerSelector;

		public CreateCustomControllerSettings createCustomControllerSettings => _createCustomControllerSettings;

		internal event Action InputSourceUpdateEvent
		{
			add
			{
				nbhdZVJncuHWMBGRRnAbDyNXqRGqA = (Action)Delegate.Combine(nbhdZVJncuHWMBGRRnAbDyNXqRGqA, value);
			}
			remove
			{
				nbhdZVJncuHWMBGRRnAbDyNXqRGqA = (Action)Delegate.Remove(nbhdZVJncuHWMBGRRnAbDyNXqRGqA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal CustomController()
		{
		}

		public Rewired.CustomController GetCustomController()
		{
			return ivkRKvvGYxrHvXDUIEhQMQamHUeC(false);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			_ = base.DlyzgeEtPbGSRivIvEmZhBSIEqiU;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				MJQvpjlWbKNkARNaYNQsoxhoTGqq.Clear();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				jebsoqOBGHhJxfFgdjbRaKVujtZwA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDestroy()
		{
			base.OnDestroy();
			ULCAKCJaSPXelLcFWMxQefqgJlqi();
		}

		internal virtual bool OnInitialize()
		{
			if (!base.BUnNPMFoanNJCVAmWibAzWafnjUk())
			{
				return false;
			}
			if (GetUseCustomController())
			{
				if (!MqWEGAfVINuauMCDaSCdKgUxLEpIA())
				{
					return false;
				}
				if (ivkRKvvGYxrHvXDUIEhQMQamHUeC(true) == null)
				{
					SetUseCustomController(value: false);
				}
			}
			return true;
		}

		internal virtual void OnSubscribeEvents()
		{
			base.OCbTyrEcaxLtyGXBEYyEklZHhUaE();
			tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
			if (ReInput.isReady)
			{
				ReInput.InputSourceUpdateEvent += WcLroPMwdeKLAKDtUTPbgUAjHaqt;
			}
		}

		internal virtual void OnUnsubscribeEvents()
		{
			base.tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
			ReInput.InputSourceUpdateEvent -= WcLroPMwdeKLAKDtUTPbgUAjHaqt;
		}

		public override void ClearControlValues()
		{
			base.ClearControlValues();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				MJQvpjlWbKNkARNaYNQsoxhoTGqq.Clear();
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
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU || element == null || !GetUseCustomController())
			{
				return;
			}
			Rewired.CustomController customController = ivkRKvvGYxrHvXDUIEhQMQamHUeC(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			_ = MJQvpjlWbKNkARNaYNQsoxhoTGqq.Count;
			for (int i = 0; i < MJQvpjlWbKNkARNaYNQsoxhoTGqq.Count; i++)
			{
				MdQdoDfHfbLfWFKXhNstanVhiXsCA value2 = MJQvpjlWbKNkARNaYNQsoxhoTGqq[i];
				if (value2.aMwTbzrVEsLpQOIuMafTaBuZcppe(element.elementType, elementIndex))
				{
					value2.IdwGKNJkaXjzHIJrWUaMXhwlhIpX(value);
					MJQvpjlWbKNkARNaYNQsoxhoTGqq[i] = value2;
					return;
				}
			}
			MJQvpjlWbKNkARNaYNQsoxhoTGqq.Add(new MdQdoDfHfbLfWFKXhNstanVhiXsCA(element.elementType, elementIndex, value));
		}

		internal void SetButtonValue(CustomControllerElementSelector element, bool value)
		{
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU || element == null || !GetUseCustomController())
			{
				return;
			}
			Rewired.CustomController customController = ivkRKvvGYxrHvXDUIEhQMQamHUeC(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			_ = MJQvpjlWbKNkARNaYNQsoxhoTGqq.Count;
			for (int i = 0; i < MJQvpjlWbKNkARNaYNQsoxhoTGqq.Count; i++)
			{
				MdQdoDfHfbLfWFKXhNstanVhiXsCA value2 = MJQvpjlWbKNkARNaYNQsoxhoTGqq[i];
				if (value2.aMwTbzrVEsLpQOIuMafTaBuZcppe(element.elementType, elementIndex))
				{
					value2.IdwGKNJkaXjzHIJrWUaMXhwlhIpX(value);
					MJQvpjlWbKNkARNaYNQsoxhoTGqq[i] = value2;
					return;
				}
			}
			MJQvpjlWbKNkARNaYNQsoxhoTGqq.Add(new MdQdoDfHfbLfWFKXhNstanVhiXsCA(element.elementType, elementIndex, value));
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
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU || element == null || !GetUseCustomController())
			{
				return;
			}
			Rewired.CustomController customController = ivkRKvvGYxrHvXDUIEhQMQamHUeC(false);
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
			_ = MJQvpjlWbKNkARNaYNQsoxhoTGqq.Count;
			for (int num = MJQvpjlWbKNkARNaYNQsoxhoTGqq.Count - 1; num >= 0; num--)
			{
				if (MJQvpjlWbKNkARNaYNQsoxhoTGqq[num].aMwTbzrVEsLpQOIuMafTaBuZcppe(element.elementType, elementIndex))
				{
					MJQvpjlWbKNkARNaYNQsoxhoTGqq.RemoveAt(num);
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
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				return false;
			}
			if (element == null)
			{
				return false;
			}
			Rewired.CustomController customController = ivkRKvvGYxrHvXDUIEhQMQamHUeC(false);
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
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
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
			Rewired.CustomController customController = ivkRKvvGYxrHvXDUIEhQMQamHUeC(false);
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

		private void jebsoqOBGHhJxfFgdjbRaKVujtZwA()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				MJQvpjlWbKNkARNaYNQsoxhoTGqq.Clear();
			}
		}

		private bool MqWEGAfVINuauMCDaSCdKgUxLEpIA()
		{
			if (ReInput.isReady)
			{
				return true;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Custom Controller. Custom Controller support will be disabled on this Custom Controller.");
			SetUseCustomController(value: false);
			return false;
		}

		private void GZLOFPCpcSnhWwJQFkhJEkCZndtX()
		{
			if (MJQvpjlWbKNkARNaYNQsoxhoTGqq.Count == 0)
			{
				return;
			}
			Rewired.CustomController customController = ivkRKvvGYxrHvXDUIEhQMQamHUeC(false);
			if (customController == null)
			{
				MJQvpjlWbKNkARNaYNQsoxhoTGqq.Clear();
				return;
			}
			for (int i = 0; i < MJQvpjlWbKNkARNaYNQsoxhoTGqq.Count; i++)
			{
				MdQdoDfHfbLfWFKXhNstanVhiXsCA mdQdoDfHfbLfWFKXhNstanVhiXsCA = MJQvpjlWbKNkARNaYNQsoxhoTGqq[i];
				switch (mdQdoDfHfbLfWFKXhNstanVhiXsCA.ugEcvEUjcYzrLriOHSDCiapaTNEm)
				{
				case CustomControllerElementSelector.ElementType.Axis:
					customController.SetAxisValue(mdQdoDfHfbLfWFKXhNstanVhiXsCA.JnaqnwUXKgDmJYmGIqyOLHqXtkYU, mdQdoDfHfbLfWFKXhNstanVhiXsCA.ANnyYrpgRHgHrBXsbJxMFrsUzupD);
					break;
				case CustomControllerElementSelector.ElementType.Button:
					customController.SetButtonValue(mdQdoDfHfbLfWFKXhNstanVhiXsCA.JnaqnwUXKgDmJYmGIqyOLHqXtkYU, mdQdoDfHfbLfWFKXhNstanVhiXsCA.ANnyYrpgRHgHrBXsbJxMFrsUzupD != 0f);
					break;
				default:
					throw new NotImplementedException();
				}
			}
			MJQvpjlWbKNkARNaYNQsoxhoTGqq.Clear();
		}

		private Rewired.CustomController ivkRKvvGYxrHvXDUIEhQMQamHUeC(bool P_0)
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
			if (rLsxEKPBShdONDDyEFTmwMxyHIqv >= 0)
			{
				customController = ReInput.controllers.GetCustomController(rLsxEKPBShdONDDyEFTmwMxyHIqv);
				if (customController == null)
				{
					rLsxEKPBShdONDDyEFTmwMxyHIqv = -1;
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
						rLsxEKPBShdONDDyEFTmwMxyHIqv = customController.id;
						TnZVSahqlwTMCZiUCxlpYkDFlpKi(customController);
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

		private void TnZVSahqlwTMCZiUCxlpYkDFlpKi(Rewired.CustomController P_0)
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

		private void ULCAKCJaSPXelLcFWMxQefqgJlqi()
		{
			if (rLsxEKPBShdONDDyEFTmwMxyHIqv >= 0 && _createCustomControllerSettings.destroyCustomController)
			{
				Rewired.CustomController customController = ivkRKvvGYxrHvXDUIEhQMQamHUeC(false);
				if (customController != null && ReInput.isReady)
				{
					ReInput.controllers.DestroyCustomController(customController);
					rLsxEKPBShdONDDyEFTmwMxyHIqv = -1;
				}
			}
		}

		private void WcLroPMwdeKLAKDtUTPbgUAjHaqt()
		{
			if (nbhdZVJncuHWMBGRRnAbDyNXqRGqA != null)
			{
				nbhdZVJncuHWMBGRRnAbDyNXqRGqA();
			}
			GZLOFPCpcSnhWwJQFkhJEkCZndtX();
		}
	}
}
