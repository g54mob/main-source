using System;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	public interface INPCMotor
	{
		MotorOwner CurrentOwner { get; }

		bool IsAgentReady { get; }

		Vector3 CurrentDestination { get; }

		bool HasActiveDestination { get; }

		float RemainingDistance { get; }

		bool HasPath { get; }

		bool IsPathPending { get; }

		float VelocitySqrMagnitude { get; }

		float CurrentSpeed { get; }

		bool IsMoving { get; }

		bool IsStuck { get; }

		bool IsPathLost { get; }

		bool IsNavigationPending { get; }

		event Action OnDestinationCleared;

		bool TryAcquire(MotorOwner requester);

		void Release(MotorOwner owner);

		void StopAndRelease(MotorOwner caller);

		void ForceRelease(string reason = "Forced");

		bool IsOwner(MotorOwner owner);

		bool CanAcquire(MotorOwner requester);

		bool SetDestination(MotorOwner caller, Vector3 destination);

		bool SetDestination(MotorOwner caller, Vector3 destination, int priority);

		void Stop(MotorOwner caller);

		void SetSpeed(MotorOwner caller, float speed);

		void SetStopped(MotorOwner caller, bool stopped);

		void ResetPath(MotorOwner caller);

		void SetUpdateRotation(MotorOwner caller, bool enabled);

		bool SetDestinationSameFloor(MotorOwner caller, Vector3 destination, float maxHeightDifference = 0.5f);

		bool IsArrived(float stoppingDistance = 0f);

		bool HasArrived(float stoppingDistance = 0f);

		float GetActualDistanceToTarget();

		float GetPathDistance();

		float GetSpeed();

		string GetNavStatus();

		bool DoesCurrentPathGoAbove(float yThreshold);

		bool TryRepath();

		bool WarpToNavMesh(Vector3 position, bool allowLongDistance = false);

		void SetAgentEnabled(bool enabled);
	}
}
