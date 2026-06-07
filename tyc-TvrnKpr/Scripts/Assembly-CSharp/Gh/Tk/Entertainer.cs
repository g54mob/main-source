using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class Entertainer : Actor
	{
		public static HashSet<Entertainer> AllEntertainers;

		private Transform _pelvis;

		private EntertainerProfile _entertainerProfile;

		[PersistenceOptIn]
		private bool _isEntertaining;

		[PersistenceOptIn]
		private float _emissionRadius;

		private static Color _sphereGizmoColour;

		private static Color _lineConnectedGizmoColour;

		private static Color _lineDisconnectedGizmoColour;

		public EntertainerData EntertainerData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public EntertainerProfile EntertainerProfile => null;

		[JsonIgnore]
		public bool IsEntertaining => false;

		public float EmissionRadius => 0f;

		public static event EventHandler<EventArgs<Entertainer>> StartedEntertaining
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Entertainer>> FinishedEntertaining
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void InitNavigation()
		{
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		private void OnAnimationTriggeredEntertainerEffect(object sender, AnimationEventArgs e)
		{
		}

		public override void Init()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		protected void RaiseStartedEntertainingEvent()
		{
		}

		public void StartEntertaining()
		{
		}

		protected void RaiseFinishedEntertainingEvent()
		{
		}

		public void StopEntertaining()
		{
		}

		public void TriggerEntertainerEffect()
		{
		}

		private IEnumerable<Actor> GetActorsToInfluence()
		{
			return null;
		}

		protected override Job GetNextJob()
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}

		public override void MarkToDestroy()
		{
		}
	}
}
