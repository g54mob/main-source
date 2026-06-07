using System;
using Coherence.Toolkit;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Items
{
	public class PickupCoffinEmpty : PickupGuarded
	{
		private SpriteRenderer _charSprite;

		private SpriteRenderer _lid;

		private bool _isOpened;

		private Tween _charScaleTween;

		private Tween _charMoveTween;

		private Sequence _lidTween;

		[Sync]
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

		private CharacterType CharCff { get; set; }

		public Action OnOpen { get; set; }

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

		protected void OnCharTypeUpdated(int oldChar, int newChar)
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

		private void TriggerCharacterPanel()
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
	}
}
