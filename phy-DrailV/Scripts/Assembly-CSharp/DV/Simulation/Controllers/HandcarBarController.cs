using System.Collections;
using DV.CabControls;
using DV.CabControls.NonVR;
using DV.HUD;
using DV.KeyboardInput;
using DV.Simulation.Cars;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class HandcarBarController : MonoBehaviour
	{
		[PortId(PortType.EXTERNAL_IN, PortValueType.CONTROL, false)]
		public string handleEngagedPortId;

		private bool initialized;

		private TrainCar car;

		private HandcarController handcarController;

		private Port handleEngagedPort;

		private ControlImplBase handleInteractable;

		private HingeJoint handleHingeJoint;

		private SteppedJoint handleSteppedJoint;

		private float originalSpring = 100f;

		private LeverNonVR leverNonVR;

		private MouseScrollKeyboardInput mouseScrollKeyboardInput;

		private InteriorControlsManager interiorControlsManager;

		private IEnumerator Start()
		{
			car = TrainCar.Resolve(base.gameObject);
			SimController simController = car?.SimController;
			if (simController == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find simController, HandcarBarController destroying self!");
				Object.Destroy(this);
				yield break;
			}
			SimulationFlow simFlow = simController.simFlow;
			if (simFlow == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find simFlow, HandcarBarController destroying self");
				Object.Destroy(this);
				yield break;
			}
			if (!simFlow.TryGetPort(handleEngagedPortId, out handleEngagedPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find port id handleEngagedPortId, HandcarBarController destroying self");
				Object.Destroy(this);
				yield break;
			}
			ASimInitializedController[] otherSimControllers = simController.otherSimControllers;
			for (int i = 0; i < otherSimControllers.Length; i++)
			{
				if (otherSimControllers[i] is HandcarController handcarController)
				{
					this.handcarController = handcarController;
					break;
				}
			}
			if (this.handcarController == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find handcarController, HandcarBarController destroying self");
				Object.Destroy(this);
				yield break;
			}
			mouseScrollKeyboardInput = GetComponent<MouseScrollKeyboardInput>();
			if (mouseScrollKeyboardInput == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find mouseScrollKeyboardInput, HandcarBarController keyboard input won't work!");
			}
			OnInteriorLoadedStateChanged(car.loadedInterior);
			car.InteriorLoaded += OnInteriorLoadedStateChanged;
			yield return null;
			yield return null;
			handleInteractable = GetComponent<ControlImplBase>();
			handleHingeJoint = GetComponent<HingeJoint>();
			handleSteppedJoint = GetComponent<SteppedJoint>();
			if (handleInteractable == null || handleHingeJoint == null || handleSteppedJoint == null)
			{
				Debug.LogError("Unexpected state: One of the handle related components not found, HandcarBarController destroying self");
				Object.Destroy(this);
				yield break;
			}
			originalSpring = handleHingeJoint.spring.spring;
			base.gameObject.AddComponent<HighlightTag>().renderers.Add(this.handcarController.visualHandlebar.GetComponentInChildren<Renderer>());
			if (!VRManager.IsVREnabled())
			{
				leverNonVR = GetComponent<LeverNonVR>();
				if (leverNonVR == null)
				{
					Debug.LogError("Unexpected state: leverNonVR not found, scrolling direction won't be affected by player position!");
				}
			}
			initialized = true;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				if (handleEngagedPort != null)
				{
					handleEngagedPort.ExternalValueUpdate(0f);
				}
				if (car != null)
				{
					car.InteriorLoaded -= OnInteriorLoadedStateChanged;
				}
			}
		}

		private void Update()
		{
			if (!initialized)
			{
				return;
			}
			Transform playerTransform = PlayerManager.PlayerTransform;
			if (!(playerTransform == null))
			{
				if (leverNonVR != null)
				{
					bool flag = handcarController.visualHandlebar.InverseTransformPoint(playerTransform.position).z < 0f;
					leverNonVR.InvertScrollingDirection = !flag;
				}
				bool flag2 = handleInteractable.IsGrabbedOrHoverScrolled() || (mouseScrollKeyboardInput != null && mouseScrollKeyboardInput.IsScrollingInProgress) || (interiorControlsManager != null && interiorControlsManager.IsControlScrolledRecently(InteriorControlsManager.ControlType.Throttle)) || handleInteractable.LastSetValueSource == ControlImplBase.SetValueSource.Analog;
				handleEngagedPort.ExternalValueUpdate(flag2 ? 1f : 0f);
				if (flag2)
				{
					handleSteppedJoint.enabled = true;
					JointSpring spring = handleHingeJoint.spring;
					spring.spring = originalSpring;
					handleHingeJoint.spring = spring;
				}
				else
				{
					handleSteppedJoint.enabled = false;
					JointSpring spring2 = handleHingeJoint.spring;
					spring2.targetPosition = handcarController.VisualHandlebarRotationX;
					spring2.spring = 100000f;
					handleHingeJoint.spring = spring2;
				}
			}
		}

		private void OnInteriorLoadedStateChanged(GameObject interior)
		{
			interiorControlsManager = null;
			if (interior != null)
			{
				interiorControlsManager = interior.GetComponent<InteriorControlsManager>();
				if (!interiorControlsManager)
				{
					Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find interiorControlsManager, HandcarBarController UI input won't work!");
				}
			}
		}
	}
}
