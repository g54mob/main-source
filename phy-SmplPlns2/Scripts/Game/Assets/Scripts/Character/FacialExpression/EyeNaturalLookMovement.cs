using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Scripts.Character.FacialExpression
{
	public class EyeNaturalLookMovement : MonoBehaviour
	{
		[SerializeField]
		private LookAtIK _lookAtIk;

		[SerializeField]
		private Transform _target;

		[SerializeField]
		private float _targetAdjustmentMultiplier = 0.2f;

		private float _targetGoalTime;

		[SerializeField]
		private Vector2 _targetGoalTimeMinMax;

		[SerializeField]
		private float _targetMoveRate = 1f;

		private Vector3 _targetPositionGoal;

		[SerializeField]
		private Vector3 _targetPositionMaximums;

		[SerializeField]
		private Vector3 _targetPositionMinimums;

		[SerializeField]
		private Vector3 _targetPositionNeutral;

		protected void Start()
		{
			if (_lookAtIk == null)
			{
				_lookAtIk = GetComponentInParent<LookAtIK>();
				if (_lookAtIk == null)
				{
					Debug.LogWarning("Look At IK not present, eye movement will not function.");
					return;
				}
			}
			if (_target != null)
			{
				_lookAtIk.solver.target = _target;
				_targetPositionGoal = _target.localPosition;
			}
			else
			{
				Debug.LogWarning("Eye Movement target is not set, eye movement will not function.");
				_lookAtIk.solver.eyesWeight = 0f;
			}
		}

		protected void Update()
		{
			if (!(_lookAtIk != null) || !(_target != null))
			{
				return;
			}
			_lookAtIk.solver.target = _target;
			if (_targetGoalTime <= 0f)
			{
				_targetGoalTime = Random.Range(_targetGoalTimeMinMax.x, _targetGoalTimeMinMax.y);
				switch (Random.Range(0, 4))
				{
				case 0:
					_targetPositionGoal = _targetPositionNeutral;
					break;
				case 1:
				case 2:
					_targetPositionGoal = new Vector3(Random.Range(_targetPositionMinimums.x, _targetPositionMaximums.x), Random.Range(_targetPositionMinimums.y, _targetPositionMaximums.y), Random.Range(_targetPositionMinimums.z, _targetPositionMaximums.z));
					_targetPositionGoal = new Vector3(Mathf.Clamp(_target.localPosition.x + _targetPositionGoal.x * _targetAdjustmentMultiplier, _targetPositionMinimums.x, _targetPositionMaximums.x), Mathf.Clamp(_target.localPosition.y + _targetPositionGoal.y * _targetAdjustmentMultiplier, _targetPositionMinimums.y, _targetPositionMaximums.y), Mathf.Clamp(_target.localPosition.z + _targetPositionGoal.z * _targetAdjustmentMultiplier, _targetPositionMinimums.z, _targetPositionMaximums.z));
					break;
				default:
					_targetPositionGoal = new Vector3(Random.Range(_targetPositionMinimums.x, _targetPositionMaximums.x), Random.Range(_targetPositionMinimums.y, _targetPositionMaximums.y), Random.Range(_targetPositionMinimums.z, _targetPositionMaximums.z));
					break;
				}
			}
			_target.localPosition = Vector3.MoveTowards(_target.localPosition, _targetPositionGoal, _targetMoveRate * Time.deltaTime);
			_targetGoalTime -= Time.deltaTime;
		}
	}
}
