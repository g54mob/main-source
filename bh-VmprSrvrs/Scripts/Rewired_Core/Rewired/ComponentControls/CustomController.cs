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

		private struct DpgMkxoXQafxlgxjAXAOorUCsvPC
		{
			public CustomControllerElementSelector.ElementType HMsAsHWfkBgVyRrPUsaeebIjkkOX;

			public int RFjjnQVrIfKYaXNGAlaaqgjNetSbA;

			public float jrvuCKZWWSbfutYUiqqsFEZsVfXf;

			public DpgMkxoXQafxlgxjAXAOorUCsvPC(CustomControllerElementSelector.ElementType P_0, int P_1, float P_2)
			{
				HMsAsHWfkBgVyRrPUsaeebIjkkOX = default(CustomControllerElementSelector.ElementType);
				RFjjnQVrIfKYaXNGAlaaqgjNetSbA = 0;
				jrvuCKZWWSbfutYUiqqsFEZsVfXf = 0f;
			}

			public DpgMkxoXQafxlgxjAXAOorUCsvPC(CustomControllerElementSelector.ElementType P_0, int P_1, bool P_2)
			{
				HMsAsHWfkBgVyRrPUsaeebIjkkOX = default(CustomControllerElementSelector.ElementType);
				RFjjnQVrIfKYaXNGAlaaqgjNetSbA = 0;
				jrvuCKZWWSbfutYUiqqsFEZsVfXf = 0f;
			}

			public bool nRyGhBPSNCglRIPMdPexTqXAAoXN(CustomControllerElementSelector.ElementType P_0, int P_1)
			{
				return false;
			}

			public void AYBnlzvBffVMMyUEyeCDzmxCPEXo(float P_0)
			{
			}

			public void dJuyQEMLtZSgynTdusmcTMeoCxubA(bool P_0)
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

		private List<DpgMkxoXQafxlgxjAXAOorUCsvPC> qcxetinQGQhjsXkzrgnpQVlzvHJf;

		[NonSerialized]
		private int mAsdJmNGDKMxWczvqpaVOVRChtvj;

		private Action hTlmDKYbsSqilaWqDhCLSplqXaYu;

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

		internal override bool oSvYgASTscWXHSsDtWoLjQXKLikj()
		{
			return false;
		}

		internal override void LJsjFsLEXxnYmCrOiRqtEKrLybAC()
		{
		}

		internal override void ZvPAMhphMUiXojMkOSttLdHrLDoM()
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

		private void GRNPrdyBhnHeGrmWxfUOQNcCNiIX()
		{
		}

		private bool uzMPufhuxtooeNSlKtjdIbETFOvB()
		{
			return false;
		}

		private void nYNzeEAOpyjHNEKFbsNOjDvvoOnOA()
		{
		}

		private Rewired.CustomController WrvvoTOOKWONEvvfTHZPBsUYQQcl(bool P_0)
		{
			return null;
		}

		private void nyrUUCwByKfmoRvoMWwUFTflaerK(Rewired.CustomController P_0)
		{
		}

		private void nVkYnOhGKevZfTvMlYOKCYclArjb()
		{
		}

		private void jSUIhwroYtFyOoxhkQgxPAPSWvaD()
		{
		}
	}
}
