using System;
using MalbersAnimations.Reactions;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class TransformTracker
	{
		public enum ModeStatus
		{
			Start = 0,
			Exit = 1
		}

		[HideInInspector]
		public string name;

		[HideInInspector]
		public bool Active;

		[Flag]
		[HideInInspector]
		public TrackerType track = TrackerType.State;

		[Hide("track", false, true, true, new int[] { 1 })]
		public StateID State;

		[Hide("track", false, true, true, new int[] { 2 })]
		public StanceID Stance;

		[Hide("track", false, true, true, new int[] { 4, 8 })]
		public ModeID Mode;

		[Hide("track", false, true, true, new int[] { 8 })]
		[Min(-1f)]
		public int Ability = -1;

		[Hide("track", false, true, true, new int[] { 4, 8 })]
		public ModeStatus ModeAction;

		[Space]
		[SerializeReference]
		[SubclassSelector]
		public Reaction reaction;

		[HideInInspector]
		public bool RepositionTracker = true;

		[Hide("RepositionTracker", false, true)]
		[Tooltip("Lerp Speed to the new Tracker Position")]
		public float Lerp = 2f;

		[Hide("RepositionTracker", false, true)]
		public Vector3 Position;

		[Hide("RepositionTracker", false, true)]
		public Vector3 Rotation;

		[Hide("RepositionTracker", false, true)]
		[Tooltip("Use this Node Transform to a of the Tracker Object. Reference for the Local Position of the tracker")]
		public Transform RelativeTo;

		[Hide("RepositionTracker", false, true)]
		public Color DebugColor = Color.green;

		public bool CheckStance => (track & TrackerType.Stance) == TrackerType.Stance;

		public bool CheckState => (track & TrackerType.State) == TrackerType.State;

		public bool CheckMode => (track & TrackerType.Mode) == TrackerType.Mode;

		public bool CheckAbility => (track & TrackerType.Ability) == TrackerType.Ability;
	}
}
