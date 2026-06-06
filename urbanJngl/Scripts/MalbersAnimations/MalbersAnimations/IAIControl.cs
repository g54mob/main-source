using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations
{
	public interface IAIControl
	{
		Transform Transform { get; }

		Transform Owner { get; }

		int Index { get; set; }

		Transform Target { get; set; }

		Transform NextTarget { get; set; }

		Vector3 DestinationPosition { get; set; }

		Vector3 AIDirection { get; set; }

		IAITarget IsAITarget { get; set; }

		float StoppingDistance { get; set; }

		float AdditiveStopDistance { get; set; }

		float CurrentSlowingDistance { get; set; }

		float SlowingDistance { get; }

		float Height { get; }

		float RemainingDistance { get; set; }

		bool HasArrived { get; set; }

		bool IsWaitingOnTarget { get; set; }

		bool IsMoving { get; }

		bool InOffMeshLink { get; set; }

		bool TargetIsMoving { get; }

		bool AutoNextTarget { get; set; }

		bool AIReady { get; }

		bool Active { get; }

		bool LookAtTargetOnArrival { get; set; }

		bool UpdateDestinationPosition { get; set; }

		TransformEvent TargetSet { get; }

		TransformEvent OnArrived { get; }

		Vector3 GetTargetPosition();

		void ResetStoppingDistance();

		void SetTarget(Transform target, bool move);

		void SetNextTarget(GameObject next);

		void ClearTarget();

		void MovetoNextTarget();

		void SetDestination(Vector3 PositionTarget, bool move);

		void Stop();

		void StopWait();

		void Move();

		void SetActive(bool value);

		void CompleteOffMeshLink();
	}
}
