using System;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class AISaveState
	{
		public int gameID;

		public int modelIndex;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 agentVelocity;

		public EAIBehaviourState state;

		public Vector3 destination;

		public Vector3 destinationForward;

		public float destinationRadius;

		public bool destinationHasTargetRotation;

		public bool hasEnteredDestination;

		public bool isAtDestination;

		public AIStandSituation standSituation;

		public float waitTimerValue;

		public float activityTimelineTimeLeft;

		public AISaveState(AIBehaviour ai, AICharacter character)
		{
			gameID = ai.GameID;
			modelIndex = character.ModelIndex;
			position = character.Position;
			rotation = character.Rotation;
			agentVelocity = ai.GetNavAgentState();
			state = ai.State;
			(Vector3, Vector3, float, bool) tuple = ai.GetDestination();
			destination = tuple.Item1;
			destinationForward = tuple.Item2;
			destinationRadius = tuple.Item3;
			destinationHasTargetRotation = tuple.Item4;
			hasEnteredDestination = ai.HasEnteredDestination;
			isAtDestination = ai.IsAtDestination;
			standSituation = ai.StandSituation;
			waitTimerValue = ai.GetWaitTimeLeft();
			activityTimelineTimeLeft = ai.GetActivityTimelineTimeLeft();
		}
	}
}
