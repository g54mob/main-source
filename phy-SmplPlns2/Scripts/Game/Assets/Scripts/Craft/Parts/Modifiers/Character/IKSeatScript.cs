using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.Events;
using Jundroo.Common.Utils;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Character
{
	public class IKSeatScript : PartModifierScript
	{
		private int _animationInitFrames = 2;

		private FullBodyBipedIK _bipedIk;

		private PartData _bodyTarget;

		private GameObject _characterModel;

		private PartData _leftElbowTarget;

		private Transform _leftFoot;

		private PartData _leftFootTarget;

		private HandPoser _leftHandPoser;

		private PartData _leftHandTarget;

		private PartData _leftKneeTarget;

		private Transform _leftShoulder;

		private PartData _leftShoulderTarget;

		private PartData _rightElbowTarget;

		private Transform _rightFoot;

		private PartData _rightFootTarget;

		private HandPoser _rightHandPoser;

		private PartData _rightHandTarget;

		private PartData _rightKneeTarget;

		private Transform _rightShoulder;

		private PartData _rightShoulderTarget;

		public GameObject CharacterModel => _characterModel;

		public IKSeatData Data { get; private set; }

		public void AutoAssignTargets()
		{
			foreach (PartData part in base.PartScript.Aircraft.Parts)
			{
				foreach (IKTargetData modifier in part.GetModifiers<IKTargetData>())
				{
					switch (modifier.Type)
					{
					case IKTargetType.RightHand:
						if (CheckAutoTarget(ref _rightHandTarget, modifier))
						{
							Data.RightHandTarget = _rightHandTarget.Id;
							Data.QueueUIRefresh();
						}
						break;
					case IKTargetType.LeftHand:
						if (CheckAutoTarget(ref _leftHandTarget, modifier))
						{
							Data.LeftHandTarget = _leftHandTarget.Id;
							Data.QueueUIRefresh();
						}
						break;
					}
				}
			}
			if (_bipedIk != null)
			{
				SetExtemities();
			}
		}

		public void DestroyDesignerCharacter()
		{
			if (base.PartScript.Part.LoadContext == CraftLoadContext.Designer && _characterModel != null)
			{
				if (_bipedIk != null)
				{
					ReleasePose();
				}
				Object.Destroy(_characterModel);
				_characterModel = null;
			}
		}

		public void Initialize(IKSeatData data)
		{
			Data = data;
		}

		public void ReleasePose()
		{
			if (_bipedIk != null)
			{
				_bipedIk.solver.headMapping.maintainRotationWeight = 0f;
				SetExtremity(null, null, _bipedIk.solver.leftShoulderEffector, null, IKTargetType.LeftShoulder, IKTargetType.LeftShoulder);
				SetExtremity(null, null, _bipedIk.solver.rightShoulderEffector, null, IKTargetType.RightShoulder, IKTargetType.RightShoulder);
				SetExtremity(null, null, _bipedIk.solver.leftHandEffector, _bipedIk.solver.leftArmChain, IKTargetType.LeftHand, IKTargetType.LeftElbow);
				SetExtremity(null, null, _bipedIk.solver.rightHandEffector, _bipedIk.solver.rightArmChain, IKTargetType.RightHand, IKTargetType.RightElbow);
				SetExtremity(null, null, _bipedIk.solver.leftFootEffector, _bipedIk.solver.leftLegChain, IKTargetType.LeftFoot, IKTargetType.LeftKnee);
				SetExtremity(null, null, _bipedIk.solver.rightFootEffector, _bipedIk.solver.rightLegChain, IKTargetType.RightFoot, IKTargetType.RightKnee);
				SetExtremity(null, null, _bipedIk.solver.bodyEffector, null, IKTargetType.Body, IKTargetType.Body);
				_bipedIk = null;
			}
		}

		public void SetDesignerCharacter(string designerCharacter)
		{
			if (base.PartScript.Part.LoadContext != CraftLoadContext.Designer)
			{
				return;
			}
			string value;
			if (designerCharacter == "None")
			{
				DestroyDesignerCharacter();
			}
			else if (Data.CharacterPaths.TryGetValue(designerCharacter, out value))
			{
				DestroyDesignerCharacter();
				SeatScript modifier = base.PartScript.GetModifier<SeatScript>();
				Transform transform = Object.Instantiate(Resources.Load<GameObject>(value)).transform;
				transform.SetParent(modifier.transform, worldPositionStays: true);
				LayerUtility.SetLayerRecursive(transform.gameObject, 17);
				transform.SetLocalPositionAndRotation(modifier.Data.SeatedPosition, Quaternion.Euler(modifier.Data.SeatedRotation));
				if (!string.IsNullOrWhiteSpace(modifier.Data.Animation))
				{
					RuntimeAnimatorController runtimeAnimatorController = Game.Instance.ResourceLoader.Load<RuntimeAnimatorController>(modifier.Data.Animation);
					Animator componentInChildren = transform.GetComponentInChildren<Animator>();
					if (runtimeAnimatorController != null)
					{
						componentInChildren.runtimeAnimatorController = runtimeAnimatorController;
						_animationInitFrames = 2;
						componentInChildren.Update(0f);
					}
				}
				StartPose(transform);
			}
			else
			{
				Debug.Log("Cannot find character path for '" + designerCharacter + "'");
			}
		}

		public IEnumerator SetDesignerCharacterDelayed(string designerCharacter)
		{
			for (int i = 0; i < 10; i++)
			{
				yield return new WaitForEndOfFrame();
			}
			SetDesignerCharacter(designerCharacter);
		}

		public void StartPose(Transform characterModel)
		{
			if (_bipedIk != null)
			{
				ReleasePose();
			}
			_characterModel = characterModel.gameObject;
			FullBodyBipedIK componentInChildren = characterModel.GetComponentInChildren<FullBodyBipedIK>();
			if (!(componentInChildren == null))
			{
				_bipedIk = componentInChildren;
				UpdateMaintainHeadRotation();
				UpdateTargets();
				SetExtemities();
			}
		}

		public void UpdateMaintainHeadRotation()
		{
			if (_bipedIk != null)
			{
				_bipedIk.solver.headMapping.maintainRotationWeight = Data.MaintainHeadRotation;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				Designer.Instance.PartDeleted -= DesignerPartDeleted;
			}
			else if (_bipedIk != null)
			{
				ReleasePose();
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_animationInitFrames = 2;
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				Designer.Instance.PartDeleted += DesignerPartDeleted;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault | CraftUpdateFlags.DesignerScene);
		}

		private int AdjustPriority(int priority, Vector3 position, IKTargetType type)
		{
			Vector3 vector = base.transform.InverseTransformPoint(position);
			if (vector.z < -0.2f)
			{
				priority += 10;
			}
			if (type == IKTargetType.LeftHand || type == IKTargetType.RightHand)
			{
				priority = ((!(vector.y > -0.292f)) ? (priority + 5) : (priority - 5));
			}
			if (type == IKTargetType.LeftFoot || type == IKTargetType.RightFoot)
			{
				priority = ((!(vector.y < -0.492f)) ? (priority + 5) : (priority - 5));
			}
			if (Mathf.Abs(vector.x) > 0.6f)
			{
				priority += 10;
			}
			if (Mathf.Abs(vector.y) > 1f)
			{
				priority += 10;
			}
			if (Mathf.Abs(vector.z) > 1f)
			{
				priority += 10;
			}
			switch (type)
			{
			case IKTargetType.LeftHand:
			case IKTargetType.LeftFoot:
			case IKTargetType.LeftElbow:
				priority = ((!(vector.x < -0.1f)) ? (priority + 5) : (priority - 5));
				break;
			case IKTargetType.RightHand:
			case IKTargetType.RightFoot:
			case IKTargetType.RightElbow:
				priority = ((!(vector.x >= 0f)) ? (priority + 5) : (priority - 5));
				break;
			}
			return priority;
		}

		private bool CheckAutoTarget(ref PartData targetPart, IKTargetData newTarget)
		{
			if (targetPart == null)
			{
				targetPart = newTarget.Part;
				return true;
			}
			_ = newTarget.Priority;
			int num = 1000;
			List<IKTargetData> modifiers = targetPart.GetModifiers<IKTargetData>();
			if (modifiers.Count == 0)
			{
				targetPart = newTarget.Part;
				return true;
			}
			foreach (IKTargetData item in modifiers)
			{
				if (item.Type == newTarget.Type)
				{
					num = AdjustPriority(item.Priority, item.Script.transform.position, item.Type);
					if (AdjustPriority(newTarget.Priority, newTarget.Script.transform.position, newTarget.Type) < num)
					{
						targetPart = newTarget.Part;
						return true;
					}
				}
			}
			return false;
		}

		private void DesignerPartDeleted(object sender, PartDeletedEventArgs e)
		{
			if (!(_bipedIk == null))
			{
				IKSolverFullBodyBiped solver = _bipedIk.solver;
				if (e.Part.Part == _leftHandTarget)
				{
					SetExtremity(null, null, solver.leftHandEffector, solver.leftArmChain, IKTargetType.LeftHand, IKTargetType.LeftElbow);
					_leftHandTarget = null;
				}
				if (e.Part.Part == _rightHandTarget)
				{
					SetExtremity(null, null, solver.rightHandEffector, solver.rightArmChain, IKTargetType.RightHand, IKTargetType.RightElbow);
					_rightHandTarget = null;
				}
				if (e.Part.Part == _leftFootTarget)
				{
					SetExtremity(null, null, solver.leftFootEffector, solver.leftLegChain, IKTargetType.LeftFoot, IKTargetType.LeftKnee);
					_leftFootTarget = null;
				}
				if (e.Part.Part == _rightFootTarget)
				{
					SetExtremity(null, null, solver.rightFootEffector, solver.rightLegChain, IKTargetType.RightFoot, IKTargetType.RightKnee);
					_rightFootTarget = null;
				}
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			if (frame.CraftLoadContext != CraftLoadContext.Designer)
			{
				return;
			}
			if (Data.SelfAssignTargets)
			{
				foreach (IKTargetScript modifier in base.PartScript.GetModifiers<IKTargetScript>())
				{
					switch (modifier.Type)
					{
					case IKTargetType.LeftShoulder:
						Data.LeftShoulderTarget = Data.Part.Id;
						break;
					case IKTargetType.RightShoulder:
						Data.RightShoulderTarget = Data.Part.Id;
						break;
					case IKTargetType.Body:
						Data.BodyTarget = Data.Part.Id;
						break;
					}
				}
			}
			StartCoroutine(SetDesignerCharacterDelayed(Data.DesignerCharacter));
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (frame.Paused && base.LoadContext != CraftLoadContext.Designer)
			{
				return;
			}
			if (_characterModel != null && base.LoadContext == CraftLoadContext.Designer)
			{
				bool flag = base.PartScript.PartMaterialScript.TutorialHighlight == null && Designer.Instance.ViewMode != DesignerViewMode.Powertrain;
				if (_characterModel.activeSelf != flag)
				{
					_characterModel.SetActive(flag);
				}
			}
			if (_animationInitFrames > 0)
			{
				_animationInitFrames--;
			}
			else if (_bipedIk != null)
			{
				IKSolverFullBodyBiped solver = _bipedIk.solver;
				float snapRange = Data.SnapRange;
				if (_leftHandPoser != null && _leftHandTarget?.PartScript != null && ((_leftHandPoser.transform.position - solver.leftHandEffector.target.position).sqrMagnitude > snapRange || !_leftHandTarget.PartScript.isActiveAndEnabled))
				{
					SetExtremity(null, null, solver.leftHandEffector, solver.leftArmChain, IKTargetType.LeftHand, IKTargetType.LeftElbow);
					_leftHandTarget = null;
				}
				if (_rightHandPoser != null && _rightHandTarget?.PartScript != null && ((_rightHandPoser.transform.position - solver.rightHandEffector.target.position).sqrMagnitude > snapRange || !_rightHandTarget.PartScript.isActiveAndEnabled))
				{
					SetExtremity(null, null, solver.rightHandEffector, solver.rightArmChain, IKTargetType.RightHand, IKTargetType.RightElbow);
					_rightHandTarget = null;
				}
				if (_leftFoot != null && _leftFootTarget?.PartScript != null && ((_leftFoot.position - solver.leftFootEffector.target.position).sqrMagnitude > snapRange || !_leftFootTarget.PartScript.isActiveAndEnabled))
				{
					SetExtremity(null, null, solver.leftFootEffector, solver.leftLegChain, IKTargetType.LeftFoot, IKTargetType.LeftKnee);
					_leftFootTarget = null;
				}
				if (_rightFoot != null && _rightFootTarget?.PartScript != null && ((_rightFoot.position - solver.rightFootEffector.target.position).sqrMagnitude > snapRange || !_rightFootTarget.PartScript.isActiveAndEnabled))
				{
					SetExtremity(null, null, solver.rightFootEffector, solver.rightLegChain, IKTargetType.RightFoot, IKTargetType.RightKnee);
					_rightFootTarget = null;
				}
			}
		}

		private void SetExtemities()
		{
			if (_bipedIk != null)
			{
				SetExtremity(_leftShoulderTarget, null, _bipedIk.solver.leftShoulderEffector, null, IKTargetType.LeftShoulder, IKTargetType.LeftShoulder);
				SetExtremity(_rightShoulderTarget, null, _bipedIk.solver.rightShoulderEffector, null, IKTargetType.RightShoulder, IKTargetType.RightShoulder);
				SetExtremity(_leftHandTarget, _leftElbowTarget, _bipedIk.solver.leftHandEffector, _bipedIk.solver.leftArmChain, IKTargetType.LeftHand, IKTargetType.LeftElbow);
				SetExtremity(_rightHandTarget, _rightElbowTarget, _bipedIk.solver.rightHandEffector, _bipedIk.solver.rightArmChain, IKTargetType.RightHand, IKTargetType.RightElbow);
				SetExtremity(_leftFootTarget, _leftKneeTarget, _bipedIk.solver.leftFootEffector, _bipedIk.solver.leftLegChain, IKTargetType.LeftFoot, IKTargetType.LeftKnee);
				SetExtremity(_rightFootTarget, _rightKneeTarget, _bipedIk.solver.rightFootEffector, _bipedIk.solver.rightLegChain, IKTargetType.RightFoot, IKTargetType.RightKnee);
				SetExtremity(_bodyTarget, null, _bipedIk.solver.bodyEffector, null, IKTargetType.Body, IKTargetType.Body);
			}
		}

		private int SetExtremity(PartData target, PartData bendTarget, IKEffector targetEffector, FBIKChain targetBendChain, IKTargetType targetType, IKTargetType bendTargetType)
		{
			if (target == null || !target.PartScript.gameObject.activeSelf)
			{
				if (targetEffector.target != null && targetEffector.target.TryGetComponent<IKTargetScript>(out var component))
				{
					component.OnTargeted(null);
				}
				targetEffector.target = null;
				targetEffector.positionWeight = 0f;
				targetEffector.rotationWeight = 0f;
				if (targetBendChain != null)
				{
					targetBendChain.bendConstraint.bendGoal = null;
					targetBendChain.bendConstraint.weight = 0f;
				}
				if (targetType == IKTargetType.LeftHand && _leftHandPoser != null)
				{
					_leftHandPoser.poseRoot = null;
					_leftHandPoser.weight = 0f;
					_leftHandPoser.localRotationWeight = 0f;
					_leftHandPoser = null;
				}
				else if (targetType == IKTargetType.RightHand && _rightHandPoser != null)
				{
					_rightHandPoser.poseRoot = null;
					_rightHandPoser.weight = 0f;
					_rightHandPoser.localRotationWeight = 0f;
					_rightHandPoser = null;
				}
				return 0;
			}
			IEnumerable<IKTargetData> enumerable = target.Modifiers.OfType<IKTargetData>();
			IKTargetData iKTargetData = enumerable.FirstOrDefault((IKTargetData x) => x.Type == targetType);
			targetEffector.target = ((iKTargetData != null) ? iKTargetData.Script.transform : target.PartScript.transform);
			targetEffector.positionWeight = iKTargetData?.PositionWeight ?? 1f;
			targetEffector.rotationWeight = iKTargetData?.RotationWeight ?? 1f;
			if (iKTargetData?.Script != null)
			{
				iKTargetData.Script.OnTargeted(_bipedIk);
			}
			if (targetType == IKTargetType.LeftHand)
			{
				_leftHandPoser = _bipedIk.GetComponentsInChildren<HandPoser>().First((HandPoser x) => x.transform.name == "arm_L0_hand_Jnt");
				int num = _leftHandPoser.GetComponentsInChildren<Transform>().Length;
				int num2 = targetEffector.target.GetComponentsInChildren<Transform>().Length;
				if (num != num2)
				{
					_leftHandPoser = null;
				}
				else
				{
					_leftHandPoser.poseRoot = targetEffector.target;
					_leftHandPoser.weight = 1f;
					_leftHandPoser.localRotationWeight = 1f;
				}
			}
			else if (targetType == IKTargetType.RightHand)
			{
				_rightHandPoser = _bipedIk.GetComponentsInChildren<HandPoser>().First((HandPoser x) => x.transform.name == "arm_R0_hand_Jnt");
				int num3 = _rightHandPoser.GetComponentsInChildren<Transform>().Length;
				int num4 = targetEffector.target.GetComponentsInChildren<Transform>().Length;
				if (num3 != num4)
				{
					_rightHandPoser = null;
				}
				else
				{
					_rightHandPoser.poseRoot = targetEffector.target;
					_rightHandPoser.weight = 1f;
					_rightHandPoser.localRotationWeight = 1f;
				}
			}
			else if (targetType == IKTargetType.LeftShoulder)
			{
				_leftShoulder = _bipedIk.solver.leftShoulderEffector.bone;
			}
			else if (targetType == IKTargetType.RightShoulder)
			{
				_rightShoulder = _bipedIk.solver.rightShoulderEffector.bone;
			}
			else if (targetType == IKTargetType.LeftFoot)
			{
				_leftFoot = _bipedIk.solver.leftFootEffector.bone;
			}
			else if (targetType == IKTargetType.RightFoot)
			{
				_rightFoot = _bipedIk.solver.rightFootEffector.bone;
			}
			else if (targetType == IKTargetType.Body)
			{
				_bipedIk.solver.bodyEffector.effectChildNodes = iKTargetData?.UseThighs == true;
			}
			if (targetBendChain != null)
			{
				if (bendTarget == null || !bendTarget.PartScript.gameObject.activeSelf)
				{
					targetBendChain.bendConstraint.bendGoal = null;
					targetBendChain.bendConstraint.weight = 0f;
					return -1;
				}
				IKTargetData iKTargetData2 = ((target == bendTarget) ? enumerable : bendTarget.Modifiers.OfType<IKTargetData>()).FirstOrDefault((IKTargetData x) => x.Type == bendTargetType);
				targetBendChain.bendConstraint.bendGoal = ((iKTargetData2 != null) ? iKTargetData2.Script.transform : bendTarget.PartScript.transform);
				targetBendChain.bendConstraint.weight = iKTargetData2?.PositionWeight ?? 1f;
			}
			return 1;
		}

		private void UpdateTargets()
		{
			_leftShoulderTarget = ((Data.LeftShoulderTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.LeftShoulderTarget, includeDisconnected: true) : null);
			_leftElbowTarget = ((Data.LeftElbowTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.LeftElbowTarget, includeDisconnected: true) : null);
			_leftHandTarget = ((Data.LeftHandTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.LeftHandTarget, includeDisconnected: true) : null);
			_rightShoulderTarget = ((Data.RightShoulderTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.RightShoulderTarget, includeDisconnected: true) : null);
			_rightElbowTarget = ((Data.RightElbowTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.RightElbowTarget, includeDisconnected: true) : null);
			_rightHandTarget = ((Data.RightHandTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.RightHandTarget, includeDisconnected: true) : null);
			_leftFootTarget = ((Data.LeftFootTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.LeftFootTarget, includeDisconnected: true) : null);
			_leftKneeTarget = ((Data.LeftKneeTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.LeftKneeTarget, includeDisconnected: true) : null);
			_rightFootTarget = ((Data.RightFootTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.RightFootTarget, includeDisconnected: true) : null);
			_rightKneeTarget = ((Data.RightKneeTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.RightKneeTarget, includeDisconnected: true) : null);
			_bodyTarget = ((Data.BodyTarget != 0) ? base.PartScript.Aircraft.GetPartById(Data.BodyTarget, includeDisconnected: true) : null);
		}
	}
}
