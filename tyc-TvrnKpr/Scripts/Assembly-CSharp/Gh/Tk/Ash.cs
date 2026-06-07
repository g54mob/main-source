using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class Ash : DirtBase
	{
		public static HashSet<Ash> AllAsh;

		public GameObject[] ModelVariants;

		[PersistenceOptIn]
		private int _visualIndex;

		private GameObject _currentModel;

		[PersistenceOptIn]
		private float _yEulerAngle;

		[PersistenceOptIn]
		private IRng _rng;

		public static event EventHandler<EventArgs<Ash>> AshAdded
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

		public static event EventHandler<EventArgs<Ash>> AshRemoved
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

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		private void RandomizeVisual()
		{
		}

		private void UpdateVisual()
		{
		}

		private GameObject GetAshPrefab()
		{
			return null;
		}

		public override bool CanUseDirectly(Actor actor)
		{
			return false;
		}
	}
}
