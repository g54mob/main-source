using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class FireExtinguisher : GameItemVisual
	{
		public static HashSet<FireExtinguisher> AllFireExtinguishers;

		private readonly List<Transform>[] _fillLevelTransforms;

		private GametimeTimer _timer;

		public List<Animator> SubAnimators;

		public static event EventHandler<EventArgs<FireExtinguisher>> FireExtinguisherAdded
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

		public static event EventHandler<EventArgs<FireExtinguisher>> FireExtinguisherRemoved
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

		private void InitFillTransforms()
		{
		}

		private void Refill()
		{
		}

		public override void OnDestroy()
		{
		}

		public void SetBarrel(GameItem item)
		{
		}

		public bool IsLoaded()
		{
			return false;
		}

		public void StartSpraying()
		{
		}

		public void StopSpraying()
		{
		}

		public override void RestoreState(IDataStore data)
		{
		}

		public override void SaveState(IDataStore data)
		{
		}

		public bool IsSpraying()
		{
			return false;
		}

		private void RefreshFillVisuals()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public void SetDistance(float distance)
		{
		}
	}
}
