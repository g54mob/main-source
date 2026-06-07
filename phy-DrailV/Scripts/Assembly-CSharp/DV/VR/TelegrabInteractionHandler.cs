using UnityEngine;
using VRTK;

namespace DV.VR
{
	public class TelegrabInteractionHandler : MonoBehaviour
	{
		public class FakeController : MonoBehaviour
		{
			public TelegrabInteractionHandler handler;

			public VRTK_ControllerReference realController => VRTK_ControllerReference.GetControllerReference(handler.ControllerEvents.gameObject);
		}

		private TelegrabbableInteractionTarget activeTarget;

		private VRTK_InteractGrab fakeController;

		private VRTK_InteractTouch touchScript;

		public VRTK_ControllerEvents ControllerEvents { get; private set; }

		public VRTK_ControllerReference ControllerReference => VRTK_ControllerReference.GetControllerReference(ControllerEvents.gameObject);

		public TouchpadInputInterpreter TouchpadInput { get; private set; }

		public FakeInteractableObjectProvider FakeInteractableObjectProvider { get; private set; }

		public TeleGrab Telegrab { get; private set; }

		public bool IsWand { get; private set; }

		private void Awake()
		{
			Telegrab = GetComponent<TeleGrab>();
			ControllerEvents = GetComponentInParent<VRTK_ControllerEvents>();
			IsWand = ControllerEvents.GetControllerType() == SDK_BaseController.ControllerType.SteamVR_ViveWand;
			TouchpadInput = GetComponentInParent<TouchpadInputInterpreter>();
			FakeInteractableObjectProvider = ControllerEvents.gameObject.GetComponent<FakeInteractableObjectProvider>();
			touchScript = GetComponentInParent<VRTK_InteractTouch>();
			if (IsWand)
			{
				ControllerEvents.TriggerClicked += delegate
				{
					AttemptStartInteraction();
				};
			}
			else
			{
				ControllerEvents.TriggerPressed += delegate
				{
					AttemptStartInteraction();
				};
			}
			CreateFakeController();
		}

		private void CreateFakeController()
		{
			GameObject gameObject = new GameObject("FakeController");
			gameObject.SetActive(value: false);
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			VRTK_InteractTouch interactTouch = gameObject.AddComponent<VRTK_InteractTouch>();
			gameObject.AddComponent<VRTK_InteractUse>();
			VRTK_ControllerEvents controllerEvents = gameObject.AddComponent<VRTK_ControllerEvents>();
			VRTK_InteractGrab vRTK_InteractGrab = gameObject.AddComponent<VRTK_InteractGrab>();
			gameObject.AddComponent<FakeController>().handler = this;
			vRTK_InteractGrab.interactTouch = interactTouch;
			vRTK_InteractGrab.controllerEvents = controllerEvents;
			rigidbody.isKinematic = true;
			vRTK_InteractGrab.controllerAttachPoint = rigidbody;
			GameObject obj = new GameObject();
			obj.transform.parent = gameObject.transform;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localScale = Vector3.one * 0.05f;
			obj.AddComponent<BoxCollider>().enabled = false;
			fakeController = vRTK_InteractGrab;
		}

		private void Update()
		{
			if ((bool)activeTarget && (IsWand ? (!ControllerEvents.triggerClicked) : (!ControllerEvents.triggerPressed)))
			{
				StopInteracting();
			}
		}

		public void StopInteracting()
		{
			base.enabled = false;
			if ((bool)activeTarget)
			{
				activeTarget.StopInteraction(this);
				activeTarget = null;
			}
		}

		private void AttemptStartInteraction()
		{
			if (!activeTarget)
			{
				Telegrabbable pointedTeleinteractable = Telegrab.CurrentTelegrabData.PointedTeleinteractable;
				if ((bool)pointedTeleinteractable && pointedTeleinteractable is TelegrabbableInteractionTarget telegrabbableInteractionTarget && !(touchScript.GetTouchedObject() != null))
				{
					activeTarget = telegrabbableInteractionTarget;
					telegrabbableInteractionTarget.StartInteraction(this);
					base.enabled = true;
				}
			}
		}

		public VRTK_InteractGrab GetFakeController()
		{
			fakeController.gameObject.SetActive(value: true);
			return fakeController;
		}

		public void ReturnFakeController()
		{
			fakeController.gameObject.SetActive(value: false);
		}
	}
}
