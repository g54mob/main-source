using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class NavigationTransition
{
	public enum TransitionType
	{
		Teleport = 0,
		Arc = 1,
		Linear = 2,
		Cubic = 3
	}

	[Tooltip("Type of transition.")]
	public TransitionType Type;

	[Tooltip("Graph to start transition from.")]
	public Graph.Type StartingGraph = Graph.Type.WaterSurface;

	[Tooltip("Graph to end transition at.")]
	public Graph.Type TargetGraph = Graph.Type.Constructions;

	[FormerlySerializedAs("IntroTransition")]
	[Tooltip("Should the target position be offset? (Used to make drifters fall deeper into the water)")]
	public bool ApplyOffsetToTargetPosition;

	[Tooltip("The offset that should be applied to the TargetPosition.")]
	public Vector3 TargetPositionOffset = Vector3.zero;

	[Tooltip("Distance threshold at which to start the transition.")]
	public float ThresholdDistance = 5f;

	[Tooltip("Duration of the transition.")]
	public float Duration = 0.5f;

	[Tooltip("Height of the transition arc.")]
	public float Height = 2.4f;

	[Tooltip("Animation ID for the navigation. Use 'TransitionID' in the animator controller to acces this property.")]
	public int AnimationID;

	[Tooltip("Whether the navigator needs to adjust its rotation to look at the target.")]
	public bool LookAtTarget;

	[Tooltip("The curvature of the cubic intermediate points (mirrored). Relative to the start/end points.")]
	public Vector3 Curvature = new Vector3(0f, 0f, 0f);

	[Tooltip("The curve to determine the position of the agent to the time.")]
	public AnimationCurve AnimationCurve;

	private Vector3 _targetPosition;

	public float TimePassed { get; private set; }

	public Vector3 StartPosition { get; private set; }

	public PathfindingNode TargetNode { get; private set; }

	public Vector3 TargetPosition
	{
		get
		{
			if (!ApplyOffsetToTargetPosition)
			{
				return TargetNode.RootPosition;
			}
			return _targetPosition;
		}
		set
		{
			_targetPosition = value;
		}
	}

	public bool IsCompleted => Duration <= TimePassed;

	private NavigationTransition(NavigationTransition navigationTransition)
	{
		Type = navigationTransition.Type;
		StartingGraph = navigationTransition.StartingGraph;
		TargetGraph = navigationTransition.TargetGraph;
		ApplyOffsetToTargetPosition = navigationTransition.ApplyOffsetToTargetPosition;
		ThresholdDistance = navigationTransition.ThresholdDistance;
		Duration = navigationTransition.Duration;
		Height = navigationTransition.Height;
		AnimationID = navigationTransition.AnimationID;
		LookAtTarget = navigationTransition.LookAtTarget;
		Curvature = navigationTransition.Curvature;
		AnimationCurve = navigationTransition.AnimationCurve;
	}

	public bool TryGetInstance(out NavigationTransition navigationTransition, Navigator navigator, PathfindingNode targetNode)
	{
		if (navigator.IsOnGraph(StartingGraph) && targetNode != null && targetNode.Graph != null && targetNode.Graph.GraphType == TargetGraph && Vector3.Distance(navigator.transform.position, targetNode.RootPosition) <= ThresholdDistance)
		{
			navigationTransition = new NavigationTransition(this);
			navigationTransition.StartPosition = navigator.transform.position;
			navigationTransition.TargetNode = targetNode;
			navigationTransition._targetPosition = targetNode.RootPosition + TargetPositionOffset;
			return true;
		}
		navigationTransition = null;
		return false;
	}

	public void Progress(Transform transform, float RotationSpeed, float deltaTime)
	{
		TimePassed += deltaTime;
		TransitionType type = Type;
		if (type == TransitionType.Teleport || (uint)(type - 1) > 2u)
		{
			transform.position = TargetPosition;
		}
		else
		{
			LerpPositionAndRotation(Type, transform, RotationSpeed);
		}
	}

	public void FastForward(Transform transform)
	{
		TimePassed = Duration;
		transform.position = TargetPosition;
	}

	private void LerpPositionAndRotation(TransitionType transitionType, Transform transform = null, float rotationSpeed = 1f)
	{
		float progress = TimePassed / Duration;
		transform.position = ReturnLerpedPosition(transitionType, progress);
		switch (transitionType)
		{
		case TransitionType.Arc:
		case TransitionType.Linear:
			if (LookAtTarget)
			{
				Quaternion to = Quaternion.LookRotation(TargetPosition - StartPosition);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, to, rotationSpeed * Time.deltaTime);
			}
			break;
		case TransitionType.Cubic:
		{
			AnimationTween.Cubic cubic = AnimationTween.CubicLerp(StartPosition, TargetPosition, progress, Curvature, AnimationCurve);
			if (LookAtTarget)
			{
				transform.rotation = Quaternion.LookRotation(new Vector3(cubic.Derivative.x, 0f, cubic.Derivative.z));
			}
			break;
		}
		}
	}

	private Vector3 ReturnLerpedPosition(TransitionType transitionType, float progress)
	{
		switch (transitionType)
		{
		case TransitionType.Arc:
			return AnimationTween.SphericalPositionLerp(StartPosition, TargetPosition, progress, Height);
		case TransitionType.Linear:
			return AnimationTween.LinearPositionLerp(StartPosition, TargetPosition, progress);
		case TransitionType.Cubic:
			return AnimationTween.CubicLerp(StartPosition, TargetPosition, progress, Curvature, AnimationCurve).Position;
		default:
			Debug.LogWarning($"Tried to do a transition but the transition type was invalid: {transitionType}");
			return TargetPosition;
		}
	}
}
