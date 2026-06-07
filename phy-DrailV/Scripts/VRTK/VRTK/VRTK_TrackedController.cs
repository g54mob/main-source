using System.Collections;
using UnityEngine;

namespace VRTK
{
	public class VRTK_TrackedController : MonoBehaviour
	{
		public uint index = uint.MaxValue;

		protected GameObject aliasController;

		protected SDK_BaseController.ControllerType controllerType;

		protected bool controllerModelWaitSubscribed;

		protected Coroutine emitControllerEnabledRoutine;

		protected Coroutine emitControllerModelAvailableRoutine;

		protected VRTK_ControllerReference controllerReference => VRTK_ControllerReference.GetControllerReference(index);

		public event VRTKTrackedControllerEventHandler ControllerEnabled;

		public event VRTKTrackedControllerEventHandler ControllerDisabled;

		public event VRTKTrackedControllerEventHandler ControllerIndexChanged;

		public event VRTKTrackedControllerEventHandler ControllerModelAvailable;

		public virtual void OnControllerEnabled(VRTKTrackedControllerEventArgs e)
		{
			if (this.ControllerEnabled != null)
			{
				this.ControllerEnabled(this, e);
			}
		}

		public virtual void OnControllerDisabled(VRTKTrackedControllerEventArgs e)
		{
			if (this.ControllerDisabled != null)
			{
				this.ControllerDisabled(this, e);
			}
		}

		public virtual void OnControllerIndexChanged(VRTKTrackedControllerEventArgs e)
		{
			if (this.ControllerIndexChanged != null)
			{
				this.ControllerIndexChanged(this, e);
			}
		}

		public virtual void OnControllerModelAvailable(VRTKTrackedControllerEventArgs e)
		{
			if (this.ControllerModelAvailable != null)
			{
				this.ControllerModelAvailable(this, e);
			}
		}

		public virtual SDK_BaseController.ControllerType GetControllerType()
		{
			return controllerType;
		}

		protected virtual VRTKTrackedControllerEventArgs SetEventPayload(uint previousIndex = uint.MaxValue)
		{
			VRTKTrackedControllerEventArgs result = default(VRTKTrackedControllerEventArgs);
			result.currentIndex = index;
			result.previousIndex = previousIndex;
			return result;
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			aliasController = VRTK_DeviceFinder.GetScriptAliasController(base.gameObject);
			if (aliasController == null)
			{
				aliasController = base.gameObject;
			}
			index = VRTK_DeviceFinder.GetControllerIndex(base.gameObject);
			SetControllerType();
			StartEmitControllerEnabledAtEndOfFrame();
			ManageControllerModelListeners(register: true);
		}

		protected virtual void OnDisable()
		{
			CancelCoroutines();
			index = uint.MaxValue;
			ManageControllerModelListeners(register: false);
			OnControllerDisabled(SetEventPayload());
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void FixedUpdate()
		{
			VRTK_SDK_Bridge.ControllerProcessFixedUpdate(VRTK_ControllerReference.GetControllerReference(index));
		}

		protected virtual void Update()
		{
			uint controllerIndex = VRTK_DeviceFinder.GetControllerIndex(base.gameObject);
			if (controllerIndex != index)
			{
				uint eventPayload = index;
				index = controllerIndex;
				if (controllerModelWaitSubscribed)
				{
					ManageControllerModelListeners(register: false);
					ManageControllerModelListeners(register: true);
				}
				OnControllerIndexChanged(SetEventPayload(eventPayload));
				SetControllerType();
			}
			VRTK_SDK_Bridge.ControllerProcessUpdate(VRTK_ControllerReference.GetControllerReference(index));
			if (aliasController != null && base.gameObject.activeInHierarchy && !aliasController.activeSelf)
			{
				aliasController.SetActive(value: true);
			}
		}

		protected virtual void ManageLeftControllerListener(bool register, VRTKSDKBaseControllerEventHandler callbackMethod)
		{
			if (register)
			{
				VRTK_SDK_Bridge.GetControllerSDK().LeftControllerModelReady += callbackMethod;
			}
			else
			{
				VRTK_SDK_Bridge.GetControllerSDK().LeftControllerModelReady -= callbackMethod;
			}
		}

		protected virtual void ManageRightControllerListener(bool register, VRTKSDKBaseControllerEventHandler callbackMethod)
		{
			if (register)
			{
				VRTK_SDK_Bridge.GetControllerSDK().RightControllerModelReady += callbackMethod;
			}
			else
			{
				VRTK_SDK_Bridge.GetControllerSDK().RightControllerModelReady -= callbackMethod;
			}
		}

		protected virtual void RegisterHandControllerListener(bool register, SDK_BaseController.ControllerHand givenHand)
		{
			switch (givenHand)
			{
			case SDK_BaseController.ControllerHand.Left:
				ManageLeftControllerListener(register, ControllerModelReady);
				break;
			case SDK_BaseController.ControllerHand.Right:
				ManageRightControllerListener(register, ControllerModelReady);
				break;
			}
			controllerModelWaitSubscribed = register;
		}

		protected virtual void ManageControllerModelListener(bool register, SDK_BaseController.ControllerHand givenHand)
		{
			if (VRTK_SDK_Bridge.WaitForControllerModel(givenHand))
			{
				RegisterHandControllerListener(register, givenHand);
			}
			else if (register)
			{
				StartEmitControllerModelReadyAtEndOfFrame();
			}
			else if (controllerModelWaitSubscribed)
			{
				RegisterHandControllerListener(register, givenHand);
			}
		}

		protected virtual void ManageControllerModelListeners(bool register)
		{
			ManageControllerModelListener(register, VRTK_DeviceFinder.GetControllerHand(base.gameObject));
		}

		protected virtual void SetControllerType()
		{
			controllerType = ((controllerReference != null) ? VRTK_DeviceFinder.GetCurrentControllerType(controllerReference) : SDK_BaseController.ControllerType.Undefined);
		}

		protected virtual void StartEmitControllerEnabledAtEndOfFrame()
		{
			if (base.gameObject.activeInHierarchy)
			{
				emitControllerEnabledRoutine = StartCoroutine(EmitControllerEnabledAtEndOfFrame());
			}
		}

		protected virtual IEnumerator EmitControllerEnabledAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			OnControllerEnabled(SetEventPayload());
		}

		protected virtual void ControllerModelReady(object sender, VRTKSDKBaseControllerEventArgs e)
		{
			SetControllerType();
			if (e.controllerReference == null || controllerReference == e.controllerReference)
			{
				StartEmitControllerModelReadyAtEndOfFrame();
			}
		}

		protected virtual void StartEmitControllerModelReadyAtEndOfFrame()
		{
			if (base.gameObject != null && base.gameObject.activeInHierarchy)
			{
				emitControllerModelAvailableRoutine = StartCoroutine(EmitControllerModelReadyAtEndOfFrame());
			}
		}

		protected virtual IEnumerator EmitControllerModelReadyAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			SDK_BaseController.ControllerHand controllerHand = VRTK_DeviceFinder.GetControllerHand(base.gameObject);
			SDK_BaseController.ControllerHand hand = VRTK_ControllerReference.GetControllerReference(controllerHand).hand;
			if (controllerHand != hand)
			{
				Debug.LogWarning(string.Format("{0}: Hand mismatch for {1} controller (should be: {2}). Skipping ControllerModelAvailable event invocation (this is expected in some cases.", "VRTK_TrackedController", controllerHand, hand));
			}
			else
			{
				OnControllerModelAvailable(SetEventPayload());
			}
		}

		protected virtual void CancelCoroutines()
		{
			if (emitControllerModelAvailableRoutine != null)
			{
				StopCoroutine(emitControllerModelAvailableRoutine);
			}
			if (emitControllerEnabledRoutine != null)
			{
				StopCoroutine(emitControllerEnabledRoutine);
			}
		}
	}
}
