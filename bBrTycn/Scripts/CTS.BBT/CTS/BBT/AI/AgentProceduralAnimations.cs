using CTS.Core.Utilities;
using RootMotion.FinalIK;
using UnityEngine;

namespace CTS.BBT.AI
{
	[DefaultExecutionOrder(100)]
	public class AgentProceduralAnimations : MonoBehaviour
	{
		private Agent _agentRef;

		[SerializeField]
		private float _updateSpeed = 2f;

		[SerializeField]
		private float _headUpdateSpeed = 2f;

		[SerializeField]
		private Transform _lookAtTarget;

		[SerializeField]
		private bool _debug;

		private GrabData _currentLeftData;

		private GrabData _currentRightData;

		private Transform _leftBoneAnchor;

		private Transform _leftElbowAnchor;

		private Transform _rightBoneAnchor;

		private Transform _rightElbowAnchor;

		private LimbIK _leftArm;

		private float _leftWeight;

		private LimbIK _rightArm;

		private float _rightWeight;

		private float _leftHandTargetWeight;

		private float _rightHandTargetWeight;

		private IKSolverLookAt _lookIk;

		private float _lookTargetWeight;

		public float WeightMultiplier { get; set; } = 1f;

		public Transform LookAtTarget { get; private set; }

		private void Awake()
		{
			_agentRef = GetComponentInParent<Agent>();
			LimbIK[] components = GetComponents<LimbIK>();
			_lookIk = GetComponent<LookAtIK>().solver;
			LimbIK[] array = components;
			foreach (LimbIK limbIK in array)
			{
				if (limbIK.solver.goal == AvatarIKGoal.LeftHand)
				{
					_leftArm = limbIK;
				}
				else
				{
					_rightArm = limbIK;
				}
			}
			_leftBoneAnchor = new GameObject("ProcLeftBoneAnchor").transform;
			_leftBoneAnchor.SetParent(base.transform);
			_leftElbowAnchor = new GameObject("ProcLeftElbow").transform;
			_leftElbowAnchor.SetParent(_leftBoneAnchor);
			_rightBoneAnchor = new GameObject("ProcRightBoneAnchor").transform;
			_rightBoneAnchor.SetParent(base.transform);
			_rightElbowAnchor = new GameObject("ProcRightElbow").transform;
			_rightElbowAnchor.SetParent(_rightBoneAnchor);
		}

		private void OnEnable()
		{
			_agentRef.ObjectHolding.OnItemGrab += OnItemGrabbed;
		}

		private void OnDisable()
		{
			_agentRef.ObjectHolding.OnItemGrab -= OnItemGrabbed;
		}

		private void Update()
		{
			float num = Time.deltaTime * _updateSpeed;
			if (num <= 0f)
			{
				return;
			}
			UpdateArm(num, ref _leftWeight, _leftHandTargetWeight, _leftArm.solver, _currentLeftData);
			UpdateArm(num, ref _rightWeight, _rightHandTargetWeight, _rightArm.solver, _currentRightData);
			if ((bool)LookAtTarget)
			{
				_lookAtTarget.transform.position = Vector3.Lerp(_lookAtTarget.transform.position, LookAtTarget.position, Time.deltaTime * _headUpdateSpeed);
				float iKPositionWeight = _lookIk.GetIKPositionWeight();
				iKPositionWeight = MathPlus.AddTowards(iKPositionWeight, Time.deltaTime, _lookTargetWeight);
				_lookIk.SetIKPositionWeight(iKPositionWeight);
				if (iKPositionWeight <= 0f)
				{
					LookAtTarget = null;
				}
			}
		}

		private void UpdateArm(float p_delta, ref float p_weight, float p_targetWeight, IKSolverLimb p_solverLimb, GrabData p_currentPoint)
		{
			if (p_currentPoint == null)
			{
				return;
			}
			p_weight = MathPlus.AddTowards(p_weight, p_delta, p_targetWeight * WeightMultiplier);
			float num = p_weight;
			p_solverLimb.SetIKPositionWeight(num * p_currentPoint.MaxWeight);
			p_solverLimb.SetIKRotationWeight(num);
			p_solverLimb.bendModifierWeight = num;
			if (p_currentPoint.IsRightHand)
			{
				if (_rightWeight <= 0f)
				{
					_currentRightData = null;
				}
			}
			else if (_leftWeight <= 0f)
			{
				_currentLeftData = null;
			}
		}

		internal void OnItemGrabbed(Item itemGrabbed)
		{
			DisableGrab();
			if ((object)itemGrabbed != null)
			{
				GrabData[] proceduralGrabData = itemGrabbed.ProceduralGrabData;
				foreach (GrabData point in proceduralGrabData)
				{
					EnableGrab(point);
				}
			}
		}

		public void LookAt(Transform anchor)
		{
			LookAtTarget = anchor;
			_lookTargetWeight = 1f;
		}

		public void StopLookAt()
		{
			_lookTargetWeight = 0f;
		}

		public void EnableGrab(GrabData point)
		{
			Transform target = null;
			if (point.IsRightHand)
			{
				SetTransforms(_rightBoneAnchor, _rightElbowAnchor, _rightArm.solver);
				_rightHandTargetWeight = 1f;
				_currentRightData = point;
			}
			else
			{
				SetTransforms(_leftBoneAnchor, _leftElbowAnchor, _leftArm.solver);
				_leftHandTargetWeight = 1f;
				_currentLeftData = point;
			}
			static void SetGoal(IKSolverLimb p_solver, Transform p_elbow)
			{
				if ((bool)p_elbow)
				{
					p_solver.bendModifier = IKSolverLimb.BendModifier.Goal;
					p_solver.bendGoal = p_elbow;
				}
				else
				{
					p_solver.bendModifier = IKSolverLimb.BendModifier.Animation;
				}
			}
			void SetTransforms(Transform boneAnchor, Transform elbowAnchor, IKSolverLimb solver)
			{
				if (!(point is GrabDataAnchor grabDataAnchor))
				{
					if (point is GrabDataBone grabDataBone)
					{
						boneAnchor.SetParent(_agentRef.SkeletonData.TryGetBone(grabDataBone.BoneTarget, out var boneTransform) ? boneTransform : base.transform);
						boneAnchor.SetLocalPositionAndRotation(grabDataBone.PositionOffset, Quaternion.Euler(grabDataBone.RotationOffset));
						target = boneAnchor;
						if (grabDataBone.ElbowAnchor)
						{
							elbowAnchor.localPosition = grabDataBone.ElbowPositionOffset;
							SetGoal(solver, elbowAnchor);
						}
						else
						{
							SetGoal(solver, null);
						}
					}
				}
				else
				{
					target = grabDataAnchor.AnchorTarget;
					SetGoal(solver, grabDataAnchor.ElbowAnchor);
				}
				solver.target = target;
			}
		}

		public void DisableGrab()
		{
			_leftHandTargetWeight = 0f;
			_rightHandTargetWeight = 0f;
		}
	}
}
