using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class DisembarkBoat : TaskBase
{
	public class MooringPointDistanceComparer : IComparer<MooringPointBase>
	{
		private Vector3 _position;

		private static MooringPointDistanceComparer _instance;

		private MooringPointDistanceComparer()
		{
		}

		public int Compare(MooringPointBase x, MooringPointBase y)
		{
			float num = _position.DistanceToSquared(x.transform.position);
			float num2 = _position.DistanceToSquared(y.transform.position);
			if (num < num2)
			{
				return -1;
			}
			if (num > num2)
			{
				return 1;
			}
			return 0;
		}

		public static MooringPointDistanceComparer Get(Vector3 position)
		{
			if (_instance == null)
			{
				_instance = new MooringPointDistanceComparer();
			}
			_instance._position = position;
			return _instance;
		}
	}

	public bool MooringPointAtTarget;

	public bool ClearAgentShoppinglist;

	public bool RemoveItemsFromProject;

	public override TaskType Type => TaskType.MoorBoat;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if (!agent.IsCaptain)
		{
			yield break;
		}
		Boat boat = agent.Boat;
		yield return TryReserveDisembarkMooringPointCoroutine(agent, boat);
		MooringPointBase mooringPoint = _assignment.ReservedDisembarkMooringPoint;
		if (mooringPoint != null)
		{
			agent.transform.localRotation = Quaternion.identity;
			yield return MoveAgentCoroutine(mooringPoint.MooringTarget);
			if (boat.Navigator.IsInRange(mooringPoint.MooringTarget))
			{
				_assignment.Disembark();
				if (!mooringPoint.IsInTown)
				{
					_assignment.ReserveBoat(mooringPoint.MooredBoat);
				}
				yield break;
			}
		}
		Debug.LogWarningFormat("'{0}' is unable to moor boat '{1}' it is the captain of. It wil return to the town and abandon the boat!", agent.Name, boat.Type);
		if (boat.TownMooringPoint != null)
		{
			yield return MoveAgentCoroutine(boat.TownMooringPoint.MooringTarget, allowIncompletePath: true);
			boat.TownMooringPoint.MoorBoat(boat);
			boat.Disembark(agent);
			yield break;
		}
		if (TryReturnGoToTownTarget(agent, boat.Navigator, out var target))
		{
			yield return MoveAgentCoroutine(target);
		}
		boat.Abandon(agent);
		yield return MoveAgentCoroutine(ReturnTarget(MoveTarget.NearestCommunityConstruction));
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		_ = project.NavigationTarget;
		return ProjectBlocker.None;
	}

	protected override void OnGUI()
	{
		Header("Disembark boat", 3, ReturnTypeColor());
		MooringPointAtTarget = EditorGUI_Toggle("Mooring point at target", MooringPointAtTarget);
		ClearAgentShoppinglist = EditorGUI_Toggle("Clear agent shopping list", ClearAgentShoppinglist);
		RemoveItemsFromProject = EditorGUI_Toggle("Remove items from project", RemoveItemsFromProject);
		EditorGUI_HelpBox("Moor the boat at a mooring point. If the mooring point is part of the player community the boat will be moored at the closest available mooring point.");
	}

	private IEnumerator TryReserveDisembarkMooringPointCoroutine(Agent agent, Boat boat)
	{
		ListPool<MooringPointBase>.Get();
		if (!_assignment.ReservedDisembarkMooringPoint && Pathfinder.TryQueuePath(out var queuedPath, boat.Navigator, boat.TownMooringPoint.MooringTarget))
		{
			while (!queuedPath.Processed)
			{
				yield return null;
			}
			_assignment.ReserveDisembarkMooringPoint(boat.TownMooringPoint);
		}
	}

	private bool TryReturnGoToTownTarget(Agent agent, Navigator navigator, out ITarget target)
	{
		Construction construction = agent.ReturnClosestConstruction(onlyFinished: false);
		int range = Mathf.CeilToInt(construction.GetComponent<Obstacle>().Polygon.Bounds.size.magnitude / 2f + (float)(int)navigator.PreferredClearance);
		Vector3 position = construction.transform.position;
		Vector3 position2 = navigator.transform.position;
		PathfindingNode[] array = GameManager.GraphManager.WaterSurfaceGraph.ReturnNeighborhood(position.x, position.y, range);
		PathfindingNode pathfindingNode = null;
		float num = float.MaxValue;
		PathfindingNode[] array2 = array;
		foreach (PathfindingNode pathfindingNode2 in array2)
		{
			if (pathfindingNode2.CanFitNavigator(navigator))
			{
				float num2 = position2.DistanceToSquared(pathfindingNode2.RootPosition);
				if (num2 < num)
				{
					pathfindingNode = pathfindingNode2;
					num = num2;
				}
			}
		}
		if (pathfindingNode == null)
		{
			target = null;
			return false;
		}
		target = new PathfindingNodeTarget(pathfindingNode);
		return true;
	}
}
