using System;

[Serializable]
public struct AnimatorState : IEquatable<AnimatorState>
{
	public string AgentName;

	public bool Alive;

	public Navigator.TerrainType Terrain;

	public int BoatID;

	public Activity Activity;

	public bool TriggerActivity;

	public int LoopBlocked;

	public int AttributeVariation;

	public AnimatorState(Agent agent, bool triggerActivity, int loopBlock)
	{
		AgentName = agent.Name;
		Navigator.TerrainType terrain = agent.ReturnNavigator(alwaysReturnDrifter: true).Terrain;
		bool flag = terrain == Navigator.TerrainType.UnityNavMesh;
		Terrain = (flag ? Navigator.TerrainType.Construction : terrain);
		Alive = agent.IsAlive;
		Activity = ((agent.CurrentActivity == Activity.Idling && flag) ? Activity.Landmark_Idling : agent.CurrentActivity);
		TriggerActivity = triggerActivity;
		BoatID = -1;
		LoopBlocked = loopBlock;
		AttributeVariation = agent.DrifterRig.AttributeVariation;
		if (Alive && Terrain == Navigator.TerrainType.Vessel && agent.Boat != null)
		{
			BoatID = agent.Boat.BoatAnimationID;
		}
	}

	public bool Equals(AnimatorState other)
	{
		return object.Equals(other, this);
	}

	public bool Equals(Agent agent, bool triggerActivity, int loopBlocked)
	{
		Navigator.TerrainType terrain = agent.ReturnNavigator(alwaysReturnDrifter: true).Terrain;
		terrain = ((terrain == Navigator.TerrainType.UnityNavMesh) ? Navigator.TerrainType.Construction : terrain);
		int boatID = -1;
		if (Alive && Terrain == Navigator.TerrainType.Vessel && agent.Boat != null)
		{
			boatID = agent.Boat.BoatAnimationID;
		}
		return Equals(terrain, agent.IsAlive, agent.CurrentActivity, triggerActivity, boatID, loopBlocked, agent.DrifterRig.AttributeVariation);
	}

	public bool Equals(Navigator.TerrainType terrain, bool alive, Activity activity, bool triggerActivity, int boatID, int loopBlocked, int attributeVariation)
	{
		if (terrain == Terrain && alive == Alive && activity == Activity && triggerActivity == TriggerActivity && boatID == BoatID && loopBlocked == LoopBlocked)
		{
			return attributeVariation == AttributeVariation;
		}
		return false;
	}

	public override bool Equals(object animatorStateObject)
	{
		if (animatorStateObject == null || GetType() != animatorStateObject.GetType())
		{
			return false;
		}
		return ((AnimatorState)animatorStateObject).Equals(Terrain, Alive, Activity, TriggerActivity, BoatID, LoopBlocked, AttributeVariation);
	}

	public static bool operator ==(AnimatorState firstAnimatorState, AnimatorState secondAnimatorState)
	{
		return firstAnimatorState.Equals(secondAnimatorState);
	}

	public static bool operator !=(AnimatorState firstAnimatorState, AnimatorState secondAnimatorState)
	{
		return !firstAnimatorState.Equals(secondAnimatorState);
	}

	public override int GetHashCode()
	{
		return ((17 * 23 + Terrain.GetHashCode()) * 23 + BoatID.GetHashCode()) * 23 + Activity.GetHashCode();
	}
}
