using System;
using System.Collections.Generic;
using Pathfinding.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Seeker")]
	[DisallowMultipleComponent]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/seeker.html")]
	public class Seeker : VersionedMonoBehaviour
	{
		public enum ModifierPass
		{
			PreProcess = 0,
			PostProcess = 2
		}

		public bool drawGizmos;

		public bool detailedGizmos;

		public StartEndModifier startEndModifier;

		public int traversableTags;

		public float[] tagCostMultipliers;

		[FormerlySerializedAs("tagPenalties")]
		public uint[] tagEntryCosts;

		public GraphMask graphMask;

		public ITraversalProvider traversalProvider;

		[FormerlySerializedAs("graphMask")]
		private int graphMaskCompatibility;

		[Obsolete("Pass a callback every time to the StartPath method instead, or use ai.SetPath+ai.pathPending on the movement script. You can cache it in your own script if you want to avoid the GC allocation of creating a new delegate.")]
		public OnPathDelegate pathCallback;

		public OnPathDelegate preProcessPath;

		public OnPathDelegate postProcessPath;

		[NonSerialized]
		protected Path path;

		[NonSerialized]
		private Path prevPath;

		private readonly OnPathDelegate onPathDelegate;

		private readonly OnPathDelegate onPartialPathDelegate;

		private OnPathDelegate tmpPathCallback;

		protected uint lastPathID;

		private readonly List<IPathModifier> modifiers;

		[Obsolete("Use tagEntryCosts or tagCostMultipliers instead", false)]
		public uint[] tagPenalties
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		private void OnDestroy()
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

		private void ForceRegisterModifiers()
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

		[Obsolete("Use the overload that takes a callback instead")]
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

		public Path StartPath(Path p)
		{
			return null;
		}

		public Path StartPath(Path p, OnPathDelegate callback)
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

		public MultiTargetPath StartMultiTargetPath(Vector3 start, Vector3[] endPoints, bool pathsForAll, OnPathDelegate callback, GraphMask graphMask)
		{
			return null;
		}

		public MultiTargetPath StartMultiTargetPath(Vector3 start, Vector3[] endPoints, bool pathsForAll, OnPathDelegate callback)
		{
			return null;
		}

		public MultiTargetPath StartMultiTargetPath(Vector3[] startPoints, Vector3 end, bool pathsForAll, OnPathDelegate callback, GraphMask graphMask)
		{
			return null;
		}

		public MultiTargetPath StartMultiTargetPath(Vector3[] startPoints, Vector3 end, bool pathsForAll, OnPathDelegate callback)
		{
			return null;
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}
	}
}
