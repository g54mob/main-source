using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Seeker")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_seeker.php")]
	public class Seeker : VersionedMonoBehaviour
	{
		public enum ModifierPass
		{
			PreProcess = 0,
			PostProcess = 2
		}

		public bool drawGizmos;

		public bool detailedGizmos;

		[HideInInspector]
		public StartEndModifier startEndModifier;

		[HideInInspector]
		public int traversableTags;

		[HideInInspector]
		public int[] tagPenalties;

		[HideInInspector]
		public GraphMask graphMask;

		[FormerlySerializedAs("graphMask")]
		private int graphMaskCompatibility;

		public OnPathDelegate pathCallback;

		public OnPathDelegate preProcessPath;

		public OnPathDelegate postProcessPath;

		[NonSerialized]
		private List<Vector3> lastCompletedVectorPath;

		[NonSerialized]
		private List<GraphNode> lastCompletedNodePath;

		[NonSerialized]
		protected Path path;

		[NonSerialized]
		private Path prevPath;

		private readonly OnPathDelegate onPathDelegate;

		private readonly OnPathDelegate onPartialPathDelegate;

		private OnPathDelegate tmpPathCallback;

		protected uint lastPathID;

		private readonly List<IPathModifier> modifiers;

		protected override void Awake()
		{
		}

		public Path GetCurrentPath()
		{
			return null;
		}

		public void CancelCurrentPathRequest(bool pool = true)
		{
		}

		public void OnDestroy()
		{
		}

		private void ReleaseClaimedPath()
		{
		}

		public void RegisterModifier(IPathModifier modifier)
		{
		}

		public void DeregisterModifier(IPathModifier modifier)
		{
		}

		public void PostProcess(Path path)
		{
		}

		public void RunModifiers(ModifierPass pass, Path path)
		{
		}

		public bool IsDone()
		{
			return false;
		}

		private void OnPathComplete(Path path)
		{
		}

		private void OnPathComplete(Path p, bool runModifiers, bool sendCallbacks)
		{
		}

		private void OnPartialPathComplete(Path p)
		{
		}

		private void OnMultiPathComplete(Path p)
		{
		}

		[Obsolete("Use ABPath.Construct(start, end, null) instead")]
		public ABPath GetNewPath(Vector3 start, Vector3 end)
		{
			return null;
		}

		public Path StartPath(Vector3 start, Vector3 end)
		{
			return null;
		}

		public Path StartPath(Vector3 start, Vector3 end, OnPathDelegate callback)
		{
			return null;
		}

		public Path StartPath(Vector3 start, Vector3 end, OnPathDelegate callback, GraphMask graphMask)
		{
			return null;
		}

		public Path StartPath(Path p, OnPathDelegate callback = null)
		{
			return null;
		}

		public Path StartPath(Path p, OnPathDelegate callback, GraphMask graphMask)
		{
			return null;
		}

		private void StartPathInternal(Path p, OnPathDelegate callback)
		{
		}

		public MultiTargetPath StartMultiTargetPath(Vector3 start, Vector3[] endPoints, bool pathsForAll, OnPathDelegate callback = null, int graphMask = -1)
		{
			return null;
		}

		public MultiTargetPath StartMultiTargetPath(Vector3[] startPoints, Vector3 end, bool pathsForAll, OnPathDelegate callback = null, int graphMask = -1)
		{
			return null;
		}

		[Obsolete("You can use StartPath instead of this method now. It will behave identically.")]
		public MultiTargetPath StartMultiTargetPath(MultiTargetPath p, OnPathDelegate callback = null, int graphMask = -1)
		{
			return null;
		}

		public void OnDrawGizmos()
		{
		}

		protected override int OnUpgradeSerializedData(int version, bool unityThread)
		{
			return 0;
		}
	}
}
