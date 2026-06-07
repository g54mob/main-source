using System;
using Coherence.Toolkit;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Items
{
	public class PickupCoffin : PickupGuarded
	{
		private SpriteRenderer _charSprite;

		private SpriteRenderer _lid;

		private bool _isOpened;

		private Tween _charScaleTween;

		private Tween _charMoveTween;

		private Sequence _lidTween;

		private Vector2 _lidStartPosition;

		public Action OnGotTaken;

		[Sync]
		[OnValueSynced("OnCharacterSetRemotely")]
		public int SyncedCharCff
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		[OnValueSynced("OnLidSpriteChanged")]
		public string LidSpriteName { get; set; }

		private CharacterType CharCff { get; set; }

		protected override bool UsesOrderedCommand => false;

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SetChar(CharacterType characterType)
		{
		}

		public override void UpdateDepth()
		{
		}

		public void SetWhiteCoffinSprites()
		{
		}

		public override void GetOnlineTaken()
		{
		}

		private void OnLidSpriteChanged(string old, string newSprite)
		{
		}

		protected override void OnRecycle()
		{
		}

		public override void GetTaken()
		{
		}

		private void PlaySfx()
		{
		}

		private void TriggerCharacterPanel(VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
		{
		}

		private void SpawnCursor()
		{
		}

		private void RemoveCursor()
		{
		}

		protected override void ToggleCursors(UISignals.ToggleGuidesSignal sig)
		{
		}

		protected void OnCharacterSetRemotely(int old, int newChar)
		{
		}
	}
}
