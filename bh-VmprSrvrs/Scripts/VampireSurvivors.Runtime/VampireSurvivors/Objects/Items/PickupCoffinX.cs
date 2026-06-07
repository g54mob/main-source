using Coherence.Toolkit;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Items
{
	public class PickupCoffinX : PickupGuarded
	{
		private SpriteRenderer _charSprite;

		private SpriteRenderer _lid;

		private bool _isOpened;

		private Tween _charScaleTween;

		private Tween _charMoveTween;

		private Sequence _lidTween;

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

		protected override void OnRecycle()
		{
		}

		public override void GetOnlineTaken()
		{
		}

		public override void GetTaken()
		{
		}

		protected void OnCharacterSetRemotely(int old, int newChar)
		{
		}
	}
}
