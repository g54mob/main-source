using System;
using UnityEngine;

namespace Gh.Tk
{
	public class MapVisual : BaseInteractable3DUIView
	{
		public bool visibleWhenRegionLockedVisually;

		[Header("Map Mode")]
		public bool visibleOnMainMenu;

		public bool visibleOnTradingWorldmap;

		[Header("Zoom Level")]
		public bool zoomedInMaxVisible;

		public bool zoomedInMediumVisible;

		public bool zoomedOutMediumVisible;

		public bool zoomedOutMaxVisible;

		private static readonly int IsDisabledAnimatorHash;

		private Animator _animator;

		private Collider _collider;

		private static readonly int _isParentRegionLocked;

		private float _lastZoomLevel;

		private WorldMapRegion3DUIView _parentRegion;

		protected override void Awake()
		{
		}

		public void Init()
		{
		}

		private void OnActiveCameraChanged(object sender, EventArgs e)
		{
		}

		public virtual void OnLevelChanged()
		{
		}

		private void OnZoomChanged(object sender, EventArgs eventArgs)
		{
		}

		public override void CheckState()
		{
		}

		private void SetEnabled(bool isEnabled)
		{
		}

		public void SetParentRegion(WorldMapRegion3DUIView region)
		{
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		public override Vector3 GetTooltipPosition()
		{
			return default(Vector3);
		}
	}
}
