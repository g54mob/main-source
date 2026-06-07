using Coherence;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;

namespace VampireSurvivors.Objects.Items
{
	public class TreasureChest : NetworkPickup
	{
		[Sync]
		public byte[] SerializedTreasure;

		private Treasure _treasure;

		private bool _hasArcana;

		private bool _hasEvo;

		private bool _hasRandoms;

		private bool _hasSpecial;

		private static bool _globalTakeAssigned;

		public bool HasArcana
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override bool UsesOrderedCommand => false;

		public Treasure TreasureData => null;

		public bool HasSpecial => false;

		public int blessedTimes { get; set; }

		protected override void Awake()
		{
		}

		public void SetData(ItemType itemType, Treasure treasure)
		{
		}

		private void UpdateSerializedTreasureData()
		{
		}

		public void SetArcana(bool hasArcana)
		{
		}

		public void SetWithEvo()
		{
		}

		public void SetDarkVFX(bool hasRandoms)
		{
		}

		public void SetSpecial()
		{
		}

		public override void InternalUpdate()
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void RequestTreasureTake(CoherenceSync openingPlayer)
		{
		}

		[Command]
		public void PerformTreasureTake(long startingSimFrame, CoherenceSync openingPlayer, CoherenceSync winningPlayer, byte[] serializedPrizePairs, byte[] serializedWeaponPrizes, int coins, bool quickTreasureAnim, byte[] serializedTreasure)
		{
		}

		public override void GetOnlineTaken()
		{
		}

		public override void GetTaken()
		{
		}

		private void SpawnSpecial()
		{
		}

		public void RemoveCursor()
		{
		}

		public override void Despawn()
		{
		}

		public override void Bless(float value, HitVfxType hitVFXType = HitVfxType.Prism)
		{
		}

		[Command]
		public void DoBless(int changedIndex)
		{
		}

		private void AdjustTreasureLevelFromArcana()
		{
		}

		private void AddDefaultCursor()
		{
		}

		private void AddArcanaCursor()
		{
		}

		protected override void TrackItemPickup(bool trackRunPickup = true)
		{
		}

		private void CheckMinMaxStageValues()
		{
		}
	}
}
