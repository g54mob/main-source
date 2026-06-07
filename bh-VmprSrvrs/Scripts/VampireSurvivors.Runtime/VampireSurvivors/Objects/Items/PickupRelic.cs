using System;
using Coherence.Toolkit;
using DG.Tweening;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Items
{
	public class PickupRelic : PickupGuarded
	{
		private PhaserSprite _shadow;

		private PhaserSprite _glow;

		private ItemType _itemType;

		private ItemData _itemData;

		private float _colorValue;

		private MultiTargetTween _floatTween;

		private MultiTargetTween _shadowTween;

		private Tween _glowTween;

		private Action<float> _onPickedUpCallback;

		[Sync]
		[OnValueSynced("OnRelicTypeSetRemotely")]
		public int SyncedRelicType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override bool UsesOrderedCommand => false;

		public ItemType ItemType => default(ItemType);

		public PhaserSprite Shadow => null;

		public PhaserSprite Glow => null;

		public Action<float> OnPickedUpCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SetItemType(ItemType itemType)
		{
		}

		public override void UpdateDepth()
		{
		}

		public override void Despawn()
		{
		}

		public override void GetTaken()
		{
		}

		protected void OnRelicTypeSetRemotely(int oldType, int newType)
		{
		}

		private void ProcessNewItemType()
		{
		}

		protected override void OnRecycle()
		{
		}

		private void UpdateGlowColor()
		{
		}

		private void DisposeTweens()
		{
		}

		public void StopFloatTween()
		{
		}

		public void StartFloatTween()
		{
		}

		public void SetVfxVisible(bool visible)
		{
		}

		protected override void TrackItemPickup(bool trackRunPickup = true)
		{
		}

		public void SpawnCursor()
		{
		}

		public void HideCursor()
		{
		}
	}
}
