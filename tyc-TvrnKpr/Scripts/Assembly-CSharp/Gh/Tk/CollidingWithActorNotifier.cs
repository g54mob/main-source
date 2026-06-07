using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Collider))]
	[DisallowMultipleComponent]
	public class CollidingWithActorNotifier : AttachedBehaviour
	{
		private Collider _collider;

		private List<Collider> _allCollidersOfTargetObject;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private List<Actor> _collidingActors;

		public override void Start()
		{
		}

		private void OnPreSaveEvent(object sender, EventArgs e)
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private Actor GetActor(Collider other)
		{
			return null;
		}
	}
}
