using CTS.AI;
using CTS.BBT.AI;
using CTS.Core;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	public class Crossbow : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private Animation _animation;

		[SerializeField]
		[Inject(false)]
		private Agent _agent;

		[SerializeField]
		private Vector3 _restPosition;

		[SerializeField]
		private Quaternion _restRotation;

		[SerializeField]
		private Vector3 _handPosition;

		[SerializeField]
		private Quaternion _handRotation;

		[SerializeField]
		private MonoTimer _boltPrefab;

		[SerializeField]
		private MonoTimer _hitPrefab;

		[InjectScope(EGetScope.ChildrenExclusive)]
		[Inject(false)]
		private Transform _bolt;

		[InjectScope(EGetScope.ParentExclusive)]
		[Inject(false)]
		private Transform _originalParent;

		protected override void OnAwake()
		{
			base.OnAwake();
			_agent.Spawned += OnAgentSpawned;
		}

		private void OnDestroy()
		{
			_agent.Spawned -= OnAgentSpawned;
		}

		private void OnAgentSpawned()
		{
			Idle();
			SetAtRest();
		}

		public void Shoot()
		{
			_bolt.gameObject.SetActive(value: true);
			_animation.Play("A_Crossbow_Shoot");
		}

		public void ShootTarget(Transform target)
		{
			MonoTimer monoTimer = CTSFactory.Instantiate(_boltPrefab, false);
			monoTimer.transform.SetPositionAndRotation(_bolt.position, _bolt.rotation);
			monoTimer.gameObject.SetActive(value: true);
			monoTimer.transform.DOMove(target.position, 0.1f);
			monoTimer.Play();
			MonoTimer monoTimer2 = CTSFactory.Instantiate(_hitPrefab, false);
			monoTimer2.transform.SetParent(monoTimer.transform);
			monoTimer2.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			monoTimer2.transform.localScale = Vector3.one;
			monoTimer2.gameObject.SetActive(value: true);
		}

		public void MissTarget(Transform target)
		{
			MonoTimer monoTimer = CTSFactory.Instantiate(_boltPrefab, false);
			monoTimer.transform.SetPositionAndRotation(_bolt.position, _bolt.rotation);
			monoTimer.gameObject.SetActive(value: true);
			Vector3 position = target.position;
			Vector3 vector = position + (position - monoTimer.transform.position).normalized * 3f + ((Random.value > 0.5f) ? monoTimer.transform.right : (-monoTimer.transform.right)) * 2f - monoTimer.transform.position;
			Vector3 normalized = vector.normalized;
			if (Physics.Raycast(monoTimer.transform.position, normalized, out var hitInfo, vector.magnitude, AgentsMover.StaticWorldMask, QueryTriggerInteraction.Collide))
			{
				vector = normalized * hitInfo.distance;
			}
			monoTimer.transform.DOMove(monoTimer.transform.position + vector, 0.1f);
			monoTimer.Play();
		}

		public void Reload()
		{
			_animation.Play("A_Crossbow_Reload");
		}

		public void Idle()
		{
			_bolt.gameObject.SetActive(value: true);
			_animation.Play("A_Crossbow_Idle");
		}

		public void SetAtRest()
		{
			if (_agent.SkeletonData.TryGetBone(EBone.UpperSpine, out var boneTransform))
			{
				base.transform.SetParent(boneTransform);
				base.transform.SetLocalPositionAndRotation(_restPosition, _restRotation);
			}
		}

		public void SetInHands()
		{
			if (_agent.SkeletonData.TryGetBone(EBone.RHand, out var boneTransform))
			{
				base.transform.SetParent(boneTransform);
				base.transform.SetLocalPositionAndRotation(_handPosition, _handRotation);
			}
		}
	}
}
