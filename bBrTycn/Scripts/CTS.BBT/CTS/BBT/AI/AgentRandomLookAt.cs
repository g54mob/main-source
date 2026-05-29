using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentRandomLookAt : CTSBehaviour
	{
		[Inject(false)]
		private Agent _agentRef;

		[Inject(false)]
		private AgentActionPlayer _actionPlayer;

		[SerializeField]
		[MinMaxSlider(0.5f, 10f)]
		private Vector2 _minMaxRandomTime = new Vector2(0.5f, 1f);

		[SerializeField]
		private bool _debug;

		private float _nextCheck;

		private Transform _currentLookAt;

		private LayerMask _physicsMask => 1 << LayerMask.NameToLayer("AgentInterCollision");

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_actionPlayer.OnActionChanged += OnCurrentActionChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_actionPlayer.OnActionChanged -= OnCurrentActionChanged;
		}

		private void Update()
		{
			CheckCurrentLookAt();
			if (_actionPlayer.ActionQueue.Count > 0 || _actionPlayer.CurrentAction != null)
			{
				AgentAction.EStatus? eStatus = _actionPlayer.CurrentAction?.Status;
				if (eStatus.HasValue && eStatus == AgentAction.EStatus.InProgress)
				{
					StopLookAt();
					return;
				}
			}
			if (!_agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				StopLookAt();
			}
			else
			{
				if (Time.time < _nextCheck)
				{
					return;
				}
				SetNextCheck();
				Collider[] array = PhysicsAllocation.Get(4);
				_agentRef.Selection.InterCollider.enabled = false;
				int num = Physics.OverlapSphereNonAlloc(base.transform.position + Vector3.up + base.transform.forward * 1.5f, 3f, array, _physicsMask);
				_agentRef.Selection.InterCollider.enabled = true;
				if (num > 0)
				{
					int num2 = Random.Range(0, num + 1);
					SelectableObject component;
					Transform boneTransform;
					if (num2 == num)
					{
						StopLookAt();
					}
					else if (array[num2].transform.parent.TryGetComponent<SelectableObject>(out component) && component.SelectionTarget is Agent agent && agent.SkeletonData.TryGetBone(EBone.Head, out boneTransform))
					{
						StartLookAt(boneTransform);
					}
				}
			}
		}

		private void CheckCurrentLookAt()
		{
			if ((bool)_currentLookAt)
			{
				if (_agentRef.ProceduralAnimator.LookAtTarget != _currentLookAt)
				{
					_currentLookAt = null;
				}
				else if (Vector3.SqrMagnitude((_currentLookAt.position - (base.transform.position + base.transform.forward * 1.5f)).FlattenY()) > 3f)
				{
					_agentRef.ProceduralAnimator.StopLookAt();
					_currentLookAt = null;
				}
			}
		}

		private void StartLookAt(Transform target)
		{
			_currentLookAt = target;
			_agentRef.ProceduralAnimator.LookAt(target);
		}

		private void StopLookAt()
		{
			if (_currentLookAt == _agentRef.ProceduralAnimator.LookAtTarget)
			{
				_agentRef.ProceduralAnimator.StopLookAt();
			}
			_currentLookAt = null;
		}

		private void SetNextCheck()
		{
			_nextCheck = Time.time + Random.Range(_minMaxRandomTime.x, _minMaxRandomTime.y);
		}

		private void OnCurrentActionChanged(AgentAction action)
		{
			if (action == null)
			{
				SetNextCheck();
			}
		}
	}
}
