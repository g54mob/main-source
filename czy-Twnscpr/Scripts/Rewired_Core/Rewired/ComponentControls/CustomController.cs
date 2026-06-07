using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[CustomClassObfuscation]
	public class CustomController : ComponentController
	{
		[Serializable]
		public class CreateCustomControllerSettings
		{
			[SerializeField]
			[CustomObfuscation]
			private bool _createCustomController;

			[CustomObfuscation]
			[SerializeField]
			private int _customControllerSourceId;

			[SerializeField]
			[CustomObfuscation]
			private int _assignToPlayerId;

			[SerializeField]
			[CustomObfuscation]
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

		private struct InputEvent
		{
			public CustomControllerElementSelector.ElementType elementType;

			public int elementIndex;

			public float value;

			public InputEvent(CustomControllerElementSelector.ElementType elementType, int elementIndex, float value)
			{
				this.elementType = default(CustomControllerElementSelector.ElementType);
				this.elementIndex = 0;
				this.value = 0f;
			}

			public InputEvent(CustomControllerElementSelector.ElementType elementType, int elementIndex, bool value)
			{
				this.elementType = default(CustomControllerElementSelector.ElementType);
				this.elementIndex = 0;
				this.value = 0f;
			}

			public bool TargetMatches(CustomControllerElementSelector.ElementType elementType, int elementIndex)
			{
				return false;
			}

			public void Merge(float value)
			{
			}

			public void Merge(bool value)
			{
			}
		}

		[CustomObfuscation]
		[SerializeField]
		private InputManager_Base _rewiredInputManager;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerSelector _customControllerSelector;

		[SerializeField]
		[CustomObfuscation]
		private CreateCustomControllerSettings _createCustomControllerSettings;

		private List<InputEvent> _inputEvents;

		[NonSerialized]
		private int _createdCustomControllerId;

		private Action _InputSourceUpdateEvent;

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

		[CustomObfuscation]
		internal CustomController()
		{
		}

		public Rewired.CustomController GetCustomController()
		{
			return null;
		}

		[CustomObfuscation]
		internal override void OnEnable()
		{
		}

		[CustomObfuscation]
		internal override void OnDisable()
		{
		}

		[CustomObfuscation]
		internal override void OnValidate()
		{
		}

		[CustomObfuscation]
		internal override void OnDestroy()
		{
		}

		internal override bool vTErMpFqqbrJIuisyHNZEKHQiIJk()
		{
			return false;
		}

		internal override void icQxdQEDgrvBqfMTuplRHxKgMmr()
		{
		}

		internal override void NdtcFvGfnnZoRnENbmFXoawgFosU()
		{
		}

		public override void ClearControlValues()
		{
		}

		[CustomObfuscation]
		internal virtual bool GetUseCustomController()
		{
			return false;
		}

		[CustomObfuscation]
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

		private void OnSetProperty()
		{
		}

		private bool CheckIsRewiredReady()
		{
			return false;
		}

		private void ProcessInputEvents()
		{
		}

		private Rewired.CustomController GetCustomController(bool warn)
		{
			return null;
		}

		private void TryAssignCustomControllerToPlayer(Rewired.CustomController customController)
		{
		}

		private void TryDestroyCustomController()
		{
		}

		private void OnInputSourceUpdate()
		{
		}
	}
}
