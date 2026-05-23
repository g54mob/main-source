using System;
using System.Collections.Generic;
using Pathfinding.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Seeker")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/seeker.html")]
	public class Seeker : VersionedMonoBehaviour
	{
		public enum ModifierPass
		{
			PreProcess = 0,
			PostProcess = 2
		}

		public bool drawGizmos = true;

		public bool detailedGizmos;

		[HideInInspector]
		public StartEndModifier startEndModifier = new StartEndModifier();

		[HideInInspector]
		public int traversableTags = -1;

		[HideInInspector]
		public int[] tagPenalties = new int[32];

		[HideInInspector]
		public GraphMask graphMask = GraphMask.everything;

		public ITraversalProvider traversalProvider;

		[FormerlySerializedAs("graphMask")]
		private int graphMaskCompatibility = -1;

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

		private readonly List<IPathModifier> modifiers = new List<IPathModifier>();

		public Seeker()
		{
			onPathDelegate = OnPathComplete;
			onPartialPathDelegate = OnPartialPathComplete;
		}

		protected override void Awake()
		{
			base.Awake();
			startEndModifier.Awake(this);
		}

		public Path GetCurrentPath()
		{
			return path;
		}

		public void CancelCurrentPathRequest(bool pool = true)
		{
			if (!IsDone())
			{
				path.FailWithError("Canceled by script (Seeker.CancelCurrentPathRequest)");
				if (pool)
				{
					path.Claim(path);
					path.Release(path);
				}
			}
		}

		private void OnDestroy()
		{
			ReleaseClaimedPath();
			startEndModifier.OnDestroy(this);
		}

		private void ReleaseClaimedPath()
		{
			if (prevPath != null)
			{
				prevPath.Release(this, silent: true);
				prevPath = null;
			}
		}

		public void RegisterModifier(IPathModifier modifier)
		{
			modifiers.Add(modifier);
			modifiers.Sort((IPathModifier a, IPathModifier b) => a.Order.CompareTo(b.Order));
		}

		public void DeregisterModifier(IPathModifier modifier)
		{
			modifiers.Remove(modifier);
		}

		public void PostProcess(Path path)
		{
			RunModifiers(ModifierPass.PostProcess, path);
		}

		public void RunModifiers(ModifierPass pass, Path path)
		{
			switch (pass)
			{
			case ModifierPass.PreProcess:
			{
				if (preProcessPath != null)
				{
					preProcessPath(path);
				}
				for (int j = 0; j < modifiers.Count; j++)
				{
					modifiers[j].PreProcess(path);
				}
				break;
			}
			case ModifierPass.PostProcess:
			{
				if (postProcessPath != null)
				{
					postProcessPath(path);
				}
				for (int i = 0; i < modifiers.Count; i++)
				{
					modifiers[i].Apply(path);
				}
				break;
			}
			}
		}

		public bool IsDone()
		{
			if (path != null)
			{
				return path.PipelineState >= PathState.Returning;
			}
			return true;
		}

		private void OnPathComplete(Path path)
		{
			OnPathComplete(path, runModifiers: true, sendCallbacks: true);
		}

		private void OnPathComplete(Path p, bool runModifiers, bool sendCallbacks)
		{
			if ((p != null && p != path && sendCallbacks) || this == null || p == null || p != path)
			{
				return;
			}
			if (!path.error && runModifiers)
			{
				RunModifiers(ModifierPass.PostProcess, path);
			}
			if (!sendCallbacks)
			{
				return;
			}
			p.Claim(this);
			if (tmpPathCallback != null || pathCallback != null)
			{
				if (tmpPathCallback != null)
				{
					tmpPathCallback(p);
				}
				if (pathCallback != null)
				{
					pathCallback(p);
				}
			}
			if (prevPath != null)
			{
				prevPath.Release(this, silent: true);
			}
			prevPath = p;
		}

		private void OnPartialPathComplete(Path p)
		{
			OnPathComplete(p, runModifiers: true, sendCallbacks: false);
		}

		private void OnMultiPathComplete(Path p)
		{
			OnPathComplete(p, runModifiers: false, sendCallbacks: true);
		}

		[Obsolete("Use the overload that takes a callback instead")]
		public Path StartPath(Vector3 start, Vector3 end)
		{
			return StartPath(start, end, null);
		}

		public Path StartPath(Vector3 start, Vector3 end, OnPathDelegate callback)
		{
			return StartPath(ABPath.Construct(start, end), callback);
		}

		public Path StartPath(Vector3 start, Vector3 end, OnPathDelegate callback, GraphMask graphMask)
		{
			return StartPath(ABPath.Construct(start, end), callback, graphMask);
		}

		public Path StartPath(Path p)
		{
			return StartPath(p, null);
		}

		public Path StartPath(Path p, OnPathDelegate callback)
		{
			if ((int)p.nnConstraint.graphMask == -1)
			{
				p.nnConstraint.graphMask = graphMask;
			}
			StartPathInternal(p, callback);
			return p;
		}

		public Path StartPath(Path p, OnPathDelegate callback, GraphMask graphMask)
		{
			p.nnConstraint.graphMask = graphMask;
			StartPathInternal(p, callback);
			return p;
		}

		private void StartPathInternal(Path p, OnPathDelegate callback)
		{
			if (p is MultiTargetPath multiTargetPath)
			{
				OnPathDelegate[] array = new OnPathDelegate[multiTargetPath.targetPoints.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = onPartialPathDelegate;
				}
				multiTargetPath.callbacks = array;
				p.callback = (OnPathDelegate)Delegate.Combine(p.callback, new OnPathDelegate(OnMultiPathComplete));
			}
			else
			{
				p.callback = (OnPathDelegate)Delegate.Combine(p.callback, onPathDelegate);
			}
			p.enabledTags = traversableTags;
			p.tagPenalties = tagPenalties;
			if (traversalProvider != null)
			{
				p.traversalProvider = traversalProvider;
			}
			if (path != null && path.PipelineState <= PathState.Processing && path.CompleteState != PathCompleteState.Error && lastPathID == path.pathID)
			{
				path.FailWithError("Canceled path because a new one was requested.\nThis happens when a new path is requested from the seeker when one was already being calculated.\nFor example if a unit got a new order, you might request a new path directly instead of waiting for the now invalid path to be calculated. Which is probably what you want.\nIf you are getting this a lot, you might want to consider how you are scheduling path requests.");
			}
			path = p;
			tmpPathCallback = callback;
			lastPathID = path.pathID;
			RunModifiers(ModifierPass.PreProcess, path);
			AstarPath.StartPath(path);
		}

		public MultiTargetPath StartMultiTargetPath(Vector3 start, Vector3[] endPoints, bool pathsForAll, OnPathDelegate callback, GraphMask graphMask)
		{
			MultiTargetPath multiTargetPath = MultiTargetPath.Construct(start, endPoints, null);
			multiTargetPath.pathsForAll = pathsForAll;
			StartPath(multiTargetPath, callback, graphMask);
			return multiTargetPath;
		}

		public MultiTargetPath StartMultiTargetPath(Vector3 start, Vector3[] endPoints, bool pathsForAll, OnPathDelegate callback)
		{
			return StartMultiTargetPath(start, endPoints, pathsForAll, callback, graphMask);
		}

		public MultiTargetPath StartMultiTargetPath(Vector3[] startPoints, Vector3 end, bool pathsForAll, OnPathDelegate callback, GraphMask graphMask)
		{
			MultiTargetPath multiTargetPath = MultiTargetPath.Construct(startPoints, end, null);
			multiTargetPath.pathsForAll = pathsForAll;
			StartPath(multiTargetPath, callback, graphMask);
			return multiTargetPath;
		}

		public MultiTargetPath StartMultiTargetPath(Vector3[] startPoints, Vector3 end, bool pathsForAll, OnPathDelegate callback)
		{
			return StartMultiTargetPath(startPoints, end, pathsForAll, callback, graphMask);
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			if (graphMaskCompatibility != -1)
			{
				graphMask = graphMaskCompatibility;
				graphMaskCompatibility = -1;
			}
			base.OnUpgradeSerializedData(ref migrations, unityThread);
		}
	}
}
