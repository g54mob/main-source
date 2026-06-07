using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class WorldMapRegion3DUIView : MapVisual, ITooltipDelayOverrider
	{
		[CompilerGenerated]
		private sealed class _003CUnlockSubregionsCoroutine_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WorldMapRegion3DUIView _003C_003E4__this;

			public bool skipTransition;

			private IEnumerator<WorldMapRegion3DUIView> _003C_003E7__wrap1;

			object IEnumerator<object>.Current
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
			public _003CUnlockSubregionsCoroutine_003Ed__31(int _003C_003E1__state)
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
		}

		public const float DEFAULT_TOOLTIP_DELAY = 0.5f;

		[SerializeField]
		private List<GameObject> _mapVisualChildren;

		private List<MapVisual> _mapVisualChildrenCache;

		[SerializeField]
		private MapVisual _borderVisual;

		[SerializeField]
		[Tooltip("(only for main regions) these regions will not be automatically unlocked when the main region unlocks")]
		private WorldMapRegion3DUIView[] _excludeRegionsFromAutoUnlock;

		private bool _subRegionsUnlockCalled;

		private string _regionId;

		private bool _isLocked;

		private WorldMapRegion3DUIView[] _unlockableSubRegions;

		[SerializeField]
		private GameObject _unlockVisualButtonPrefab;

		private GameObject _unlockVisualButton;

		private const string MainRegionSuffix = "Mainregion";

		private WorldMapRegion3DUIView _mainRegion;

		protected static readonly int _skipTransition;

		public bool IsMainRegion { get; private set; }

		private string RegionId => null;

		public override bool IsLocked => false;

		public bool HasUnlockAnimationPlayed { get; private set; }

		private WorldMapRegion3DUIView MainRegion => null;

		public event EventHandler RegionUnlockedVisually
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

		protected override void Awake()
		{
		}

		public override void CheckState()
		{
		}

		public void UnlockRegion(bool autoPlayAnimation = false, bool skipTransition = false)
		{
		}

		private void TriggerUnlockAnimation()
		{
		}

		private void TriggerUnlockAnimation(bool skipTransition)
		{
		}

		private void UnlockSubRegions()
		{
		}

		private WorldMapRegion3DUIView[] GetUnlockableSubRegions()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CUnlockSubregionsCoroutine_003Ed__31))]
		private IEnumerator UnlockSubregionsCoroutine(bool skipTransition)
		{
			return null;
		}

		public override void OnClicked()
		{
		}

		protected override void TriggerUnlocking()
		{
		}

		private void SetupUnlockInteractions()
		{
		}

		private void RemoveUnlockInteractions()
		{
		}

		private void RegisterUnlockClickListeners()
		{
		}

		private void DeregisterUnlockClickListeners()
		{
		}

		public void RefreshUnlockState()
		{
		}

		public void ResetState()
		{
		}

		protected override void OnEnable()
		{
		}

		private bool HasMainRegionUnlockedVisually()
		{
			return false;
		}

		public void RefreshVisual()
		{
		}

		private void SetLocked(bool isLocked, bool skipTransition = false)
		{
		}

		private bool IsBorderVisible()
		{
			return false;
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		public float GetTooltipDelay()
		{
			return 0f;
		}
	}
}
