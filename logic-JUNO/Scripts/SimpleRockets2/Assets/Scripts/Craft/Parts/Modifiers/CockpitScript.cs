using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CockpitScript : PartModifierScript<CockpitData>, IFlightStart, IGameLoopItem, IFlightUpdate
	{
		private const float JoystickMaximumRotation = 15f;

		private ICommandPod _commandPod;

		private CrewCompartmentScript _crewCompartment;

		private Transform _joystick;

		private Transform _joystickHandPosition;

		private Vector3 _joystickTargetRotation = Vector3.zero;

		private IInputController _joystickXController;

		private IInputController _joystickZController;

		private Transform _leftElbowBendGoal;

		private HandPoser _leftHandPoser;

		private EvaScript _pilot;

		private FullBodyBipedIK _pilotIK;

		private ICommandPod _pilotPod;

		private HandPoser _rightHandPoser;

		private Transform _rudderLeft;

		private Transform _rudderLeftFootPosition;

		private Transform _rudderRight;

		private Transform _rudderRightFootPosition;

		private IInputController _ruddersController;

		private AttachPoint _seatAttachPoint;

		private Transform _throttleHandle;

		private IInputController _throttleHandleController;

		private Transform _throttleHandPosition;

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_joystickXController = GetInputController("JoystickPitch", (CraftControls x) => x.Pitch);
			_joystickZController = GetInputController("JoystickRoll", (CraftControls x) => x.Roll);
			_throttleHandleController = GetInputController("ThrottleHandle", (CraftControls x) => x.Throttle);
			_ruddersController = GetInputController("Rudders", (CraftControls x) => x.Yaw);
			if (_crewCompartment.Crew.Count > 0)
			{
				SetPilot(_crewCompartment.Crew[0]);
			}
			SimpleInputController simpleInputController = _joystickXController as SimpleInputController;
			SimpleInputController simpleInputController2 = _joystickZController as SimpleInputController;
			SimpleInputController simpleInputController3 = _throttleHandleController as SimpleInputController;
			SimpleInputController simpleInputController4 = _ruddersController as SimpleInputController;
			if (simpleInputController != null)
			{
				simpleInputController.IgnorePartActivated = true;
			}
			if (simpleInputController2 != null)
			{
				simpleInputController2.IgnorePartActivated = true;
			}
			if (simpleInputController3 != null)
			{
				simpleInputController3.IgnorePartActivated = true;
			}
			if (simpleInputController4 != null)
			{
				simpleInputController4.IgnorePartActivated = true;
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			_joystickTargetRotation = Vector3.Lerp(b: new Vector3(_joystickXController.Value * 15f, 0f, (0f - _joystickZController.Value) * 15f), a: _joystickTargetRotation, t: frame.DeltaTimeUnscaled * 10f);
			_joystick.localRotation = Quaternion.Euler(_joystickTargetRotation);
			Vector3 localPosition = new Vector3(_throttleHandle.localPosition.x, _throttleHandle.localPosition.y, Mathf.Lerp(0.3f, 0.39f, _throttleHandleController.Value));
			_throttleHandle.localPosition = localPosition;
			Vector3 euler = new Vector3(_ruddersController.Value * 20f, 0f, 0f);
			Vector3 euler2 = new Vector3((0f - _ruddersController.Value) * 20f, 0f, 0f);
			_rudderRight.localRotation = Quaternion.Euler(euler);
			_rudderLeft.localRotation = Quaternion.Euler(euler2);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			bool flag = craftScript.ActiveCommandPod == _commandPod || craftScript.ActiveCommandPod == _pilotPod;
			if (!Game.InFlightScene)
			{
				flag = flag || craftScript.PrimaryCommandPod == _commandPod || craftScript.PrimaryCommandPod == _pilotPod;
			}
			SetIKEnabled(flag);
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			_crewCompartment = base.PartScript.GetModifier<CrewCompartmentScript>();
			_crewCompartment.SetCrewOrientation(_seatAttachPoint.Position, _seatAttachPoint.Rotation);
			_crewCompartment.SetCrewLoadedAnimation("Craft/Parts/Animations/Controllers/ChairCockpit");
			_crewCompartment.CrewEnter += OnPilotEnter;
			_crewCompartment.CrewExit += OnPilotExit;
			_commandPod = base.PartScript.GetModifierWithInterface<ICommandPod>();
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			SetPilot(null);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_seatAttachPoint = base.PartScript.Data.GetAttachPoint("AttachPointSeat");
			_joystick = Utilities.FindFirstGameObjectMyselfOrChildren("Joystick", base.gameObject).transform;
			_joystickHandPosition = _joystick.Find("HandPosition");
			_throttleHandle = Utilities.FindFirstGameObjectMyselfOrChildren("ThrottleHandle", base.gameObject).transform;
			_throttleHandPosition = _throttleHandle.Find("HandPosition");
			_rudderRight = Utilities.FindFirstGameObjectMyselfOrChildren("CockpitRudderRight", base.gameObject).transform;
			_rudderLeft = Utilities.FindFirstGameObjectMyselfOrChildren("CockpitRudderLeft", base.gameObject).transform;
			_rudderRightFootPosition = _rudderRight.Find("FootPosition");
			_rudderLeftFootPosition = _rudderLeft.Find("FootPosition");
			_leftElbowBendGoal = Utilities.FindFirstGameObjectMyselfOrChildren("LeftElbowBendGoal", base.gameObject).transform;
		}

		private void OnPilotEnter(EvaScript crew)
		{
			SetPilot(crew);
		}

		private void OnPilotExit(EvaScript crew)
		{
			if (crew == _pilot)
			{
				SetPilot(null);
			}
		}

		private void SetIKEnabled(bool enabled)
		{
			if (!(_pilotIK != null))
			{
				return;
			}
			if (enabled)
			{
				_pilotIK.solver.rightHandEffector.target = _joystickHandPosition;
				_pilotIK.solver.rightHandEffector.positionWeight = 1f;
				_pilotIK.solver.rightHandEffector.rotationWeight = 1f;
				_pilotIK.solver.leftHandEffector.target = _throttleHandPosition;
				_pilotIK.solver.leftHandEffector.positionWeight = 1f;
				_pilotIK.solver.leftHandEffector.rotationWeight = 1f;
				_pilotIK.solver.leftArmChain.bendConstraint.bendGoal = _leftElbowBendGoal;
				_pilotIK.solver.leftArmChain.bendConstraint.weight = 0.8f;
				_pilotIK.solver.rightFootEffector.target = _rudderRightFootPosition;
				_pilotIK.solver.rightFootEffector.positionWeight = 1f;
				_pilotIK.solver.rightFootEffector.rotationWeight = 1f;
				_pilotIK.solver.leftFootEffector.target = _rudderLeftFootPosition;
				_pilotIK.solver.leftFootEffector.positionWeight = 1f;
				_pilotIK.solver.leftFootEffector.rotationWeight = 1f;
				_rightHandPoser = _pilot.GetComponentsInChildren<HandPoser>().First((HandPoser x) => x.transform.name == "RightHand");
				_rightHandPoser.poseRoot = _joystickHandPosition.GetChild(0);
				_rightHandPoser.weight = 1f;
				_rightHandPoser.localRotationWeight = 1f;
				_leftHandPoser = _pilot.GetComponentsInChildren<HandPoser>().First((HandPoser x) => x.transform.name == "LeftHand");
				_leftHandPoser.poseRoot = _throttleHandPosition.GetChild(0);
				_leftHandPoser.weight = 1f;
				_leftHandPoser.localRotationWeight = 1f;
			}
			else
			{
				_pilotIK.solver.rightHandEffector.target = null;
				_pilotIK.solver.rightHandEffector.positionWeight = 0f;
				_pilotIK.solver.rightHandEffector.rotationWeight = 0f;
				_pilotIK.solver.leftHandEffector.target = null;
				_pilotIK.solver.leftHandEffector.positionWeight = 0f;
				_pilotIK.solver.leftHandEffector.rotationWeight = 0f;
				_pilotIK.solver.leftArmChain.bendConstraint.bendGoal = null;
				_pilotIK.solver.leftArmChain.bendConstraint.weight = 0f;
				_pilotIK.solver.rightFootEffector.target = null;
				_pilotIK.solver.rightFootEffector.positionWeight = 0f;
				_pilotIK.solver.rightFootEffector.rotationWeight = 0f;
				_pilotIK.solver.leftFootEffector.target = null;
				_pilotIK.solver.leftFootEffector.positionWeight = 0f;
				_pilotIK.solver.leftFootEffector.rotationWeight = 0f;
				if (_rightHandPoser != null)
				{
					_rightHandPoser.poseRoot = null;
					_rightHandPoser.weight = 0f;
					_rightHandPoser.localRotationWeight = 0f;
				}
				if (_leftHandPoser != null)
				{
					_leftHandPoser.poseRoot = null;
					_leftHandPoser.weight = 0f;
					_leftHandPoser.localRotationWeight = 0f;
				}
			}
		}

		private void SetPilot(EvaScript pilot)
		{
			_pilot = pilot;
			if (pilot == null)
			{
				SetIKEnabled(enabled: false);
				_pilotIK = null;
				return;
			}
			_pilotIK = _pilot.GetComponentInChildren<FullBodyBipedIK>();
			_pilotPod = _pilot.PartScript.GetModifierWithInterface<ICommandPod>();
			bool flag = base.PartScript.CraftScript.ActiveCommandPod == _commandPod || base.PartScript.CraftScript.ActiveCommandPod == _pilotPod;
			if (!Game.InFlightScene)
			{
				flag = flag || base.PartScript.CraftScript.PrimaryCommandPod == _commandPod || base.PartScript.CraftScript.PrimaryCommandPod == _pilotPod;
			}
			if (flag)
			{
				SetIKEnabled(enabled: true);
			}
		}
	}
}
