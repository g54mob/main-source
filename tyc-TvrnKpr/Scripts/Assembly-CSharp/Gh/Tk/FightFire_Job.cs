using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class FightFire_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__25 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public FightFire_Job _003C_003E4__this;

			private FireExtinguisher _003CfireExtinguisherGox_003E5__2;

			private float _003CmaxDistance_003E5__3;

			private int _003Ci_003E5__4;

			private Tavern _003Ctavern_003E5__5;

			private IDisposable _003C_003E7__wrap5;

			private int _003Cj_003E5__7;

			private Tweener _003Ctween_003E5__8;

			Activity IEnumerator<Activity>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetActivities_003Ed__25(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Activity> IEnumerable<Activity>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public FireExtinguisherGameItem FireExtinguisher;

		[PersistenceOptIn]
		private Vector3 _startingCoord;

		[PersistenceOptIn]
		private TileData _currentFireFightTile;

		[PersistenceOptIn]
		private TileData _currentFireFightTileOverride;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameObjectX _currentOverrideIndicator;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameObjectX _currentGoxOnFire;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Sprinkler _sprinkler;

		[PersistenceOptIn]
		private Vector3 _targetPosition;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _done;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _activatingExtinguisher;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _wasRunning;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _firstAttemptGoNear;

		[PersistenceOptIn]
		private Vector3 _goNearPosition;

		public static string DistanceAnimationParameter;

		private GameObjectX CurrentGoxOnFire
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void InitPostLoad()
		{
		}

		private void CurrentGoxOnFireOnDestroyed(object sender, EventArgs e)
		{
		}

		public override bool IsValid()
		{
			return false;
		}

		private FightFire_Job()
		{
		}

		public FightFire_Job(FireExtinguisher source, int priority = 1050)
		{
		}

		protected override bool CheckOnHoldInternal()
		{
			return false;
		}

		public Room GetCurrentTargetRoom()
		{
			return null;
		}

		public override IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__25))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private double CalculatePriorityByDistanceAndBuildCost(Vector3 coord, Fire x)
		{
			return 0.0;
		}

		private void ResetTurningSpeed()
		{
		}

		private void SetAnimationFloat(string param, float value)
		{
		}

		private TileData GetBestTargetTile(Room room, IEnumerable<GameObjectX> goxsOnFire, float maxDistance)
		{
			return null;
		}

		private static TileData GetBestTargetTile(IEnumerable<GameObjectX> goxsOnFire, float maxDistance, IEnumerable<TileData> candidateTiles, Actor owner)
		{
			return null;
		}

		private static Room GetBestTargetRoom()
		{
			return null;
		}

		protected override void OnAbortedInternal()
		{
		}

		private void RemoveOverrideIndicator()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		private void RemoveSprinklerAndTrait()
		{
		}

		protected override void OnFinishInternal()
		{
		}

		protected override void OnErrorInternal()
		{
		}

		public void SetFireFightTileOverride(TileData tile)
		{
		}

		internal override void ForceCompleteReset(bool removeOwner = true, bool forceDestroy = false)
		{
		}
	}
}
