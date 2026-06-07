using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class EvaChairScript : PartModifierScript<EvaChairData>, IFlightUpdate, IGameLoopItem
	{
		private CrewCompartmentScript _crewCompartment;

		private FullBodyBipedIK _pilotIK;

		private Transform _pilotLeftFeet;

		private HandPoser _pilotLeftHand;

		private Transform _pilotRightFeet;

		private HandPoser _pilotRightHand;

		private AttachPoint _seatAttachPoint;

		private PartData _leftFootBend;

		private PartData _leftFootTarget;

		private PartData _leftHandBend;

		private PartData _leftHandTarget;

		private PartData _rightFootBend;

		private PartData _rightFootTarget;

		private PartData _rightHandBend;

		private PartData _rightHandTarget;

		public string Animation => Style.Data["Animation"];

		private IPartStyle Style => base.PartScript.Data.Styles[0].Style;

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			UpdatePilot();
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			_crewCompartment = base.PartScript.GetModifier<CrewCompartmentScript>();
			_crewCompartment.CrewEnter += OnPilotEnter;
			_crewCompartment.CrewExit += OnPilotExit;
			UpdatePartStyle();
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			base.OnSymmetry(mode, originalPart, created);
			if (created)
			{
				base.Data.RemoveAllTargets();
			}
		}

		public void UpdatePartStyle()
		{
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			string id = Style.Id;
			foreach (IPartStyle style in partStyleManager.GetStyles(base.PartScript.Data.PartType.Id, 0))
			{
				string id2 = style.Id;
				GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren(id2, base.PartScript.GameObject);
				if (gameObject == null && id == id2)
				{
					gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/Prefabs/Eva/EvaChairs/" + id2);
					gameObject.transform.SetParent(base.gameObject.transform, worldPositionStays: false);
					gameObject.layer = base.gameObject.layer;
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.name = id2;
					base.PartScript.PartMaterialScript.AddRenderer(gameObject.GetComponent<MeshRenderer>(), true);
				}
				if (!(gameObject != null))
				{
					continue;
				}
				if (id == id2)
				{
					gameObject.SetActive(value: true);
					GameObject gameObject2 = Utilities.FindFirstGameObjectMyselfOrChildren("AttachPointPosition", gameObject);
					if (gameObject2 != null)
					{
						Transform obj = base.transform;
						Vector3 vector = obj.InverseTransformPoint(gameObject2.transform.position);
						Vector3 eulerAngles = (Quaternion.Inverse(obj.rotation) * gameObject2.transform.rotation).eulerAngles;
						_seatAttachPoint.Position = vector;
						if (Game.InDesignerScene)
						{
							_seatAttachPoint.AttachPointScript.transform.SetLocalPositionAndRotation(vector, Quaternion.Euler(eulerAngles));
						}
						_crewCompartment.SetCrewOrientation(vector, eulerAngles);
					}
					else
					{
						Debug.LogErrorFormat("Could not find attach point position in chair style '{0}'", id);
					}
				}
				else if (Game.InDesignerScene)
				{
					gameObject.SetActive(value: false);
				}
				else
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(gameObject.GetComponent<MeshRenderer>());
					Object.Destroy(gameObject);
				}
			}
			_crewCompartment.SetCrewLoadedAnimation(Animation);
		}

		public void UpdatePilot(bool updateTargets = false)
		{
			if (updateTargets)
			{
				UpdateTargets();
			}
			if (_pilotIK != null)
			{
				IKSolverFullBodyBiped solver = _pilotIK.solver;
				solver.boneMappings[0].maintainRotationWeight = base.Data.ForwardLook;
				int num = SetExtremity(_rightHandTarget, _rightHandBend, solver.rightHandEffector, solver.rightArmChain, (base.Data.Version > 1) ? new Vector3(0.1f, 0.01f, -0.02f) : Vector3.zero);
				if (num <= 0)
				{
					base.Data.RightHandBend = -1;
				}
				else if (num == 0)
				{
					base.Data.RightHandTarget = -1;
				}
				num = SetExtremity(_leftHandTarget, _leftHandBend, solver.leftHandEffector, solver.leftArmChain, (base.Data.Version > 1) ? new Vector3(-0.1f, -0.01f, 0.02f) : Vector3.zero);
				if (num <= 0)
				{
					base.Data.LeftHandBend = -1;
				}
				else if (num == 0)
				{
					base.Data.LeftHandTarget = -1;
				}
				num = SetExtremity(_rightFootTarget, _rightFootBend, solver.rightFootEffector, solver.rightLegChain);
				if (num <= 0)
				{
					base.Data.RightFootBend = -1;
				}
				else if (num == 0)
				{
					base.Data.RightFootTarget = -1;
				}
				num = SetExtremity(_leftFootTarget, _leftFootBend, solver.leftFootEffector, solver.leftLegChain);
				if (num <= 0)
				{
					base.Data.LeftFootBend = -1;
				}
				else if (num == 0)
				{
					base.Data.LeftFootTarget = -1;
				}
			}
		}

		public void UpdateTargetIDs()
		{
			base.Data.RightHandTarget = _rightHandTarget?.Id ?? (-1);
			base.Data.RightHandBend = _rightHandBend?.Id ?? (-1);
			base.Data.LeftHandTarget = _leftHandTarget?.Id ?? (-1);
			base.Data.LeftHandBend = _leftHandBend?.Id ?? (-1);
			base.Data.RightFootTarget = _rightFootTarget?.Id ?? (-1);
			base.Data.RightFootBend = _rightFootBend?.Id ?? (-1);
			base.Data.LeftFootTarget = _leftFootTarget?.Id ?? (-1);
			base.Data.LeftFootBend = _leftFootBend?.Id ?? (-1);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (_pilotIK != null && _pilotRightHand != null && _pilotLeftHand != null && _pilotLeftFeet != null && _pilotRightFeet != null)
			{
				IKSolverFullBodyBiped solver = _pilotIK.solver;
				float snapRange = base.Data.SnapRange;
				if (_rightHandTarget != null && (_pilotRightHand.transform.position - _rightHandTarget.PartScript.Transform.position).sqrMagnitude > snapRange)
				{
					SetExtremity(null, null, solver.rightHandEffector, solver.rightArmChain);
					_rightHandTarget = null;
					base.Data.RightHandTarget = -1;
					base.Data.RightHandBend = -1;
				}
				if (_leftHandTarget != null && (_pilotLeftHand.transform.position - _leftHandTarget.PartScript.Transform.position).sqrMagnitude > snapRange)
				{
					SetExtremity(null, null, solver.leftHandEffector, solver.leftArmChain);
					_leftHandTarget = null;
					base.Data.LeftHandTarget = -1;
					base.Data.LeftHandBend = -1;
				}
				if (_rightFootTarget != null && (_pilotRightFeet.position - _rightFootTarget.PartScript.Transform.position).sqrMagnitude > snapRange)
				{
					SetExtremity(null, null, solver.rightFootEffector, solver.rightLegChain);
					_rightFootTarget = null;
					base.Data.RightFootTarget = -1;
					base.Data.RightFootBend = -1;
				}
				if (_leftFootTarget != null && (_pilotLeftFeet.position - _leftFootTarget.PartScript.Transform.position).sqrMagnitude > snapRange)
				{
					SetExtremity(null, null, solver.leftFootEffector, solver.leftLegChain);
					_leftFootTarget = null;
					base.Data.LeftFootTarget = -1;
					base.Data.LeftFootBend = -1;
				}
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_seatAttachPoint = base.PartScript.Data.GetAttachPoint("AttachPointSeat");
			UpdateTargets();
		}

		private void OnPilotEnter(EvaScript crew)
		{
			_pilotIK = crew.GetComponentInChildren<FullBodyBipedIK>();
			_pilotRightHand = crew.GetComponentsInChildren<HandPoser>().First((HandPoser x) => x.transform.name == "RightHand");
			_pilotLeftHand = crew.GetComponentsInChildren<HandPoser>().First((HandPoser x) => x.transform.name == "LeftHand");
			_pilotLeftFeet = crew.transform.Find("Root/Offset/Hips/LeftHip/LeftKnee/LeftAnkle");
			_pilotRightFeet = crew.transform.Find("Root/Offset/Hips/RightHip/RightKnee/RightAnkle");
			UpdatePilot();
		}

		private void OnPilotExit(EvaScript crew)
		{
			if (_pilotIK != null)
			{
				IKSolverFullBodyBiped solver = _pilotIK.solver;
				solver.rightHandEffector.target = null;
				solver.rightHandEffector.positionWeight = 0f;
				solver.rightHandEffector.rotationWeight = 0f;
				solver.rightArmChain.bendConstraint.bendGoal = null;
				solver.rightArmChain.bendConstraint.weight = 0f;
				solver.leftHandEffector.target = null;
				solver.leftHandEffector.positionWeight = 0f;
				solver.leftHandEffector.rotationWeight = 0f;
				solver.leftArmChain.bendConstraint.bendGoal = null;
				solver.leftArmChain.bendConstraint.weight = 0f;
				solver.rightFootEffector.target = null;
				solver.rightFootEffector.positionWeight = 0f;
				solver.rightFootEffector.rotationWeight = 0f;
				solver.rightLegChain.bendConstraint.bendGoal = null;
				solver.rightLegChain.bendConstraint.weight = 0f;
				solver.leftFootEffector.target = null;
				solver.leftFootEffector.positionWeight = 0f;
				solver.leftFootEffector.rotationWeight = 0f;
				solver.leftLegChain.bendConstraint.bendGoal = null;
				solver.leftLegChain.bendConstraint.weight = 0f;
				solver.boneMappings[0].maintainRotationWeight = 0f;
				_pilotIK = null;
				_pilotRightHand = null;
				_pilotLeftHand = null;
				_pilotLeftFeet = null;
				_pilotRightFeet = null;
			}
		}

		private int SetExtremity(PartData target, PartData bendTarget, IKEffector targetEffector, FBIKChain targetBendChain, Vector3? offset = null)
		{
			if (target == null || target.IsDestroyed)
			{
				targetEffector.target = null;
				targetEffector.positionWeight = 0f;
				targetEffector.rotationWeight = 0f;
				targetBendChain.bendConstraint.bendGoal = null;
				targetBendChain.bendConstraint.weight = 0f;
				targetEffector.fixedOffset = Vector3.zero;
				return 0;
			}
			targetEffector.target = target.PartScript.Transform;
			targetEffector.positionWeight = 1f;
			targetEffector.rotationWeight = 1f;
			if (offset.HasValue)
			{
				targetEffector.fixedOffset = offset.Value;
			}
			if (bendTarget == null || bendTarget.IsDestroyed)
			{
				targetBendChain.bendConstraint.bendGoal = null;
				targetBendChain.bendConstraint.weight = 0f;
				return -1;
			}
			targetBendChain.bendConstraint.bendGoal = bendTarget.PartScript.Transform;
			targetBendChain.bendConstraint.weight = 1f;
			return 1;
		}

		private void UpdateTargets()
		{
			if (base.Data.RightHandTarget >= 0)
			{
				_rightHandTarget = base.PartScript.CraftScript.Data.Assembly.GetPartById(base.Data.RightHandTarget)?.PartScript.Data;
			}
			else
			{
				_rightHandTarget = null;
			}
			if (base.Data.RightHandBend >= 0)
			{
				_rightHandBend = base.PartScript.CraftScript.Data.Assembly.GetPartById(base.Data.RightHandBend)?.PartScript.Data;
			}
			else
			{
				_rightHandBend = null;
			}
			if (base.Data.LeftHandTarget >= 0)
			{
				_leftHandTarget = base.PartScript.CraftScript.Data.Assembly.GetPartById(base.Data.LeftHandTarget)?.PartScript.Data;
			}
			else
			{
				_leftHandTarget = null;
			}
			if (base.Data.LeftHandBend >= 0)
			{
				_leftHandBend = base.PartScript.CraftScript.Data.Assembly.GetPartById(base.Data.LeftHandBend)?.PartScript.Data;
			}
			else
			{
				_leftHandBend = null;
			}
			if (base.Data.RightFootTarget >= 0)
			{
				_rightFootTarget = base.PartScript.CraftScript.Data.Assembly.GetPartById(base.Data.RightFootTarget)?.PartScript.Data;
			}
			else
			{
				_rightFootTarget = null;
			}
			if (base.Data.RightFootBend >= 0)
			{
				_rightFootBend = base.PartScript.CraftScript.Data.Assembly.GetPartById(base.Data.RightFootBend)?.PartScript.Data;
			}
			else
			{
				_rightFootBend = null;
			}
			if (base.Data.LeftFootTarget >= 0)
			{
				_leftFootTarget = base.PartScript.CraftScript.Data.Assembly.GetPartById(base.Data.LeftFootTarget)?.PartScript.Data;
			}
			else
			{
				_leftFootTarget = null;
			}
			if (base.Data.LeftFootBend >= 0)
			{
				_leftFootBend = base.PartScript.CraftScript.Data.Assembly.GetPartById(base.Data.LeftFootBend)?.PartScript.Data;
			}
			else
			{
				_leftFootBend = null;
			}
		}
	}
}
