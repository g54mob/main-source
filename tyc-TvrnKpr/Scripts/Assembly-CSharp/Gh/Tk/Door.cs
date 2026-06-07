using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class Door : Prop
	{
		public static HashSet<Door> AllDoors;

		private Transform VisualNotBuilt;

		private Transform VisualBuilt;

		private Transform VisualFull;

		private Transform VisualHalf;

		public static event EventHandler AllDoorsChanged
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

		public static event EventHandler DoorPositionChanged
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

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override void Start()
		{
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		public bool IsOutsideDoor()
		{
			return false;
		}

		private void UpdateVisibility()
		{
		}

		private void UpdateVisibility(bool full)
		{
		}

		private void UpdateHighlights()
		{
		}

		public override void Init()
		{
		}

		public void InstantiateVisual()
		{
		}

		public override void PostBuiltInit()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
