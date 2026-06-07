using Coherence.Toolkit;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class PickupWeapon : PickupGuarded
	{
		private PhaserSprite _shadow;

		private PhaserSprite _glow;

		private WeaponType _weaponType;

		private WeaponData _weaponData;

		private LevelUpFactory _levelUpFactory;

		private float _colorValue;

		private bool _triggerOnGet;

		private bool _despawnOnUnavailable;

		private Tween _floatTween;

		private Tween _shadowTween;

		private Tween _glowTween;

		private Sprite _sprite;

		private VampireSurvivors.Objects.Characters.CharacterController _markedForSpecificCharacter;

		public WeaponType WeaponType => default(WeaponType);

		[Sync]
		[OnValueSynced("OnWeaponUpdatedRemotely")]
		public int SyncedWeaponType
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
		public bool DespawnOnUnavailable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public CoherenceSync MarkedForSpecificCharacter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override bool UsesOrderedCommand => false;

		[Inject]
		private void Construct(LevelUpFactory levelUpFactory)
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnDisable()
		{
		}

		public override void GetOnlineTaken()
		{
		}

		public void MarkForSpecificCharacter(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public void SetWeaponType(WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void UpdateDepth()
		{
		}

		public void TriggerOnGet()
		{
		}

		public new void StopFloat()
		{
		}

		public void ResumeFloat()
		{
		}

		public void SetVfxVisible(bool visible)
		{
		}

		private void OnWeaponUpdatedRemotely(int old, int newValue)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnRecycle()
		{
		}

		public override void GetTaken()
		{
		}

		private bool ShouldAbortTake()
		{
			return false;
		}

		private void SetWeaponDataUnlocked(WeaponType weaponType)
		{
		}

		private void UpdateColor()
		{
		}

		private void DisposeTweens()
		{
		}

		private void CheckIfRemovedFromWeaponStore()
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
