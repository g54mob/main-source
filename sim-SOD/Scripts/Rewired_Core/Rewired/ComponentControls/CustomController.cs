using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
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
			[SerializeField]
			[Tooltip("If true, a new Custom Controller will be created. Otherwise, an existing Custom Controller will be found using the selector properties.")]
			[CustomObfuscation(rename = false)]
			private bool _createCustomController;

			[CustomObfuscation(rename = false)]
			[Tooltip("The source id of the Custom Controller to create. Get this from the Rewired Input Manager.")]
			[SerializeField]
			private int _customControllerSourceId;

			[CustomObfuscation(rename = false)]
			[SerializeField]
			[Tooltip("The Player that will be assigned this Custom Controller when it is created.")]
			private int _assignToPlayerId;

			[CustomObfuscation(rename = false)]
			[Tooltip("If true, the Custom Controller created by this component will be destroyed when this component is destroyed.")]
			[SerializeField]
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

		private struct hsWkTabRQDWMuzJhNkCSaFhlglq
		{
			public CustomControllerElementSelector.ElementType RQGZoMogFuHOLGUsbkOnblhupiPb;

			public int odulvcqauCVSLnEOyEezKGePTLZ;

			public float vlnXqrXZUnXUpcXPRJmvOerSEWc;

			public hsWkTabRQDWMuzJhNkCSaFhlglq(CustomControllerElementSelector.ElementType elementType, int elementIndex, float value)
			{
				RQGZoMogFuHOLGUsbkOnblhupiPb = default(CustomControllerElementSelector.ElementType);
				odulvcqauCVSLnEOyEezKGePTLZ = 0;
				vlnXqrXZUnXUpcXPRJmvOerSEWc = 0f;
			}

			public hsWkTabRQDWMuzJhNkCSaFhlglq(CustomControllerElementSelector.ElementType elementType, int elementIndex, bool value)
			{
				RQGZoMogFuHOLGUsbkOnblhupiPb = default(CustomControllerElementSelector.ElementType);
				odulvcqauCVSLnEOyEezKGePTLZ = 0;
				vlnXqrXZUnXUpcXPRJmvOerSEWc = 0f;
			}

			public bool RlqANpIJnOduAhvUGcsiZnLCZNqg(CustomControllerElementSelector.ElementType P_0, int P_1)
			{
				return false;
			}

			public void nNiVYBfRAlOWZnlvagKxCralTje(float P_0)
			{
			}

			public void nNiVYBfRAlOWZnlvagKxCralTje(bool P_0)
			{
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Custom Controller elements, etc.")]
		private InputManager_Base _rewiredInputManager;

		[Tooltip("Contains search parameters to find a particular Custom Controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerSelector _customControllerSelector;

		[SerializeField]
		[Tooltip("Settings for creating a Custom Controller on start.")]
		[CustomObfuscation(rename = false)]
		private CreateCustomControllerSettings _createCustomControllerSettings;

		private List<hsWkTabRQDWMuzJhNkCSaFhlglq> vaIrkfVEBoZfMimkeIbTvOxqjzp;

		[NonSerialized]
		private int AkkzxWxsgXqENmWewGRVbzbgSnh;

		private Action KphZZRrOwClKubNVdQUfnDMJmHW;

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

		internal override bool kCtpTQnECPegKfokmmotHswhcCLu()
		{
			return false;
		}

		internal override void zZvUXvigSJSyudmZqKMfzEpXBSj()
		{
		}

		internal override void ARKxKpVNqBlBYALxhmjYIBkRyuM()
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

		private void ILfKseeIovFotfIwVedwwNJgiCCt()
		{
		}

		private bool bMIiSxGkpDXqlaJYsYKdSEpblu()
		{
			return false;
		}

		private void hdJDOHuwYuCUEJKQxlFqRyCZSeg()
		{
		}

		private Rewired.CustomController VTacJbNtkBaYtHePmjQrCDEkukro(bool P_0)
		{
			return null;
		}

		private void aiXKJoHVRIOwAwqMoavCVuBDGWZ(Rewired.CustomController P_0)
		{
		}

		private void zjSsOUfjKptmdoTHkPGfrnmywun()
		{
		}

		private void fhHsOFeQDGqUEtnrsXTOrvEpHIl()
		{
		}
	}
}
