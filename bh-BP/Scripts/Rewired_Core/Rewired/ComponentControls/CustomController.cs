using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[AddComponentMenu("Rewired/Component Controls/Custom Controller")]
	public class CustomController : ComponentController
	{
		[Serializable]
		public class CreateCustomControllerSettings
		{
			[Tooltip("If true, a new Custom Controller will be created. Otherwise, an existing Custom Controller will be found using the selector properties.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _createCustomController;

			[Tooltip("The source id of the Custom Controller to create. Get this from the Rewired Input Manager.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _customControllerSourceId;

			[Tooltip("The Player that will be assigned this Custom Controller when it is created.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _assignToPlayerId;

			[Tooltip("If true, the Custom Controller created by this component will be destroyed when this component is destroyed.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _destroyCustomController;

			public bool createCustomController
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int customControllerSourceId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int assignToPlayerId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public bool destroyCustomController
			{
				get
				{
					return false;
				}
				set
				{
				}
			}
		}

		private struct HrgCtpIUUZZAYwLyETvThAPukDln
		{
			public CustomControllerElementSelector.ElementType ZtatxIsLdmiNTXiASEgldpwVmFky;

			public int TajASFrANYUtBBHVEfmtgrFxMKqoA;

			public float xOznKDjeNxSrVtfHuqNzKXzEofdK;

			public HrgCtpIUUZZAYwLyETvThAPukDln(CustomControllerElementSelector.ElementType P_0, int P_1, float P_2)
			{
				ZtatxIsLdmiNTXiASEgldpwVmFky = default(CustomControllerElementSelector.ElementType);
				TajASFrANYUtBBHVEfmtgrFxMKqoA = 0;
				xOznKDjeNxSrVtfHuqNzKXzEofdK = 0f;
			}

			public HrgCtpIUUZZAYwLyETvThAPukDln(CustomControllerElementSelector.ElementType P_0, int P_1, bool P_2)
			{
				ZtatxIsLdmiNTXiASEgldpwVmFky = default(CustomControllerElementSelector.ElementType);
				TajASFrANYUtBBHVEfmtgrFxMKqoA = 0;
				xOznKDjeNxSrVtfHuqNzKXzEofdK = 0f;
			}

			public bool xoabMAdiWrRIqYjPneeqAxdsjHjAA(CustomControllerElementSelector.ElementType P_0, int P_1)
			{
				return false;
			}

			public void IHTEUgVvsItMnubJsGAYgmLmubrq(float P_0)
			{
			}

			public void dWenWZymzqJTrxoQwgduOUEuMEAb(bool P_0)
			{
			}
		}

		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Custom Controller elements, etc.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private InputManager_Base _rewiredInputManager;

		[Tooltip("Contains search parameters to find a particular Custom Controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerSelector _customControllerSelector;

		[Tooltip("Settings for creating a Custom Controller on start.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CreateCustomControllerSettings _createCustomControllerSettings;

		private List<HrgCtpIUUZZAYwLyETvThAPukDln> oDjOXxXRDdAIFBzivOkmBkTDGUnP;

		[NonSerialized]
		private int wfenUpbdClMbjqnuiwfONDpypEXq;

		private Action zmxktTaTnjXsMgQdHUNWZJGCJYuC;

		public InputManager_Base rewiredInputManager
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CustomControllerSelector customControllerSelector => null;

		public CreateCustomControllerSettings createCustomControllerSettings => null;

		internal event Action InputSourceUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal CustomController()
		{
		}

		public Rewired.CustomController GetCustomController()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDestroy()
		{
		}

		internal override bool qnnOhHqUbTJfaKJMvhSGkKfgNwIo()
		{
			return false;
		}

		internal override void VwaVUxjMTSiSBOiayDTcbJgrpHuyA()
		{
		}

		internal override void HKZIjcNrZbeuHbqxOZfsSZtHhcAP()
		{
		}

		public override void ClearControlValues()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual bool GetUseCustomController()
		{
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void SetUseCustomController(bool value)
		{
		}

		internal void SetAxisValue(CustomControllerElementSelector element, float value)
		{
		}

		internal void SetButtonValue(CustomControllerElementSelector element, bool value)
		{
		}

		internal void ClearElementValue(CustomControllerElementTargetSet targetSet)
		{
		}

		internal void ClearElementValue(CustomControllerElementTarget target)
		{
		}

		internal void ClearElementValue(CustomControllerElementSelector element)
		{
		}

		internal int ElementExists_Editor(CustomControllerElementSelector element)
		{
			return 0;
		}

		internal bool ElementExists(CustomControllerElementSelector element)
		{
			return false;
		}

		internal bool ValidateElements(CustomControllerElementTargetSet targetSet)
		{
			return false;
		}

		internal bool ValidateElement(CustomControllerElementTarget target)
		{
			return false;
		}

		internal bool ValidateElement(CustomControllerElementSelector element)
		{
			return false;
		}

		private void YoVhayIjeKhZhlgJrPOTPKQuqZsV()
		{
		}

		private bool kSbhuzhDvIHHDxTTnnfyDDLknwkEc()
		{
			return false;
		}

		private void xhHVOTusHTileOWfdZBJYDJPfoLJ()
		{
		}

		private Rewired.CustomController MOzDGMmJJpyzjzCuJFgGSlgohESJ(bool P_0)
		{
			return null;
		}

		private void tHrrfVSffrDSRjVvAmWDgCRHLVTEb(Rewired.CustomController P_0)
		{
		}

		private void xtBGfccyRxcSyjNyMoEPlNeCmxNTA()
		{
		}

		private void bNMOdjFHHIZcdgzmwFGmEdmeabKDA()
		{
		}
	}
}
