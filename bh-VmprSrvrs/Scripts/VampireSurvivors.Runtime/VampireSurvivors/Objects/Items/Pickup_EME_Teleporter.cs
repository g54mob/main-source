using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Items
{
	public class Pickup_EME_Teleporter : PickupTeleporter
	{
		[SerializeField]
		private GameObject _doorClosed;

		[SerializeField]
		private GameObject _doorOpen;

		[SerializeField]
		private float _playerProximityDistance;

		[SerializeField]
		private float _maxDisabledTime;

		private MapToken _mapToken;

		private EME_TeleportFader _teleportFader;

		private float _disabledTimer;

		private bool _disabledDueToProximity;

		[SerializeField]
		public BackgroundEmerald.EmeraldsBiomes EmeraldBiome;

		private BackgroundEmerald _bgManager;

		private BackgroundEmerald.EmeraldsBiomes _myBiome;

		private bool _showingCursor;

		private bool _wantsCursors;

		private bool _isOpen;

		[Sync]
		public string DestinationName { get; set; }

		public void Init(EME_TeleportFader teleportFader)
		{
		}

		public void SetDoorOpen(bool isOpen)
		{
		}

		public void SetDestinationName(string destination)
		{
		}

		public override void GetOnlineTaken()
		{
		}

		public override void GetTaken()
		{
		}

		protected override void DoTeleportAnimation()
		{
		}

		protected override void GenerateSpritesAndAnims()
		{
		}

		private void InvertDoor(Transform doorTransform)
		{
		}

		public void TemporarilyDisableDueToProximity()
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SetMapTokenHidden(bool isHidden)
		{
		}

		protected override void OnDrawGizmos()
		{
		}

		protected override void ToggleCursors(UISignals.ToggleGuidesSignal sig)
		{
		}

		private void SpawnCursor()
		{
		}

		private void RemoveCursor()
		{
		}
	}
}
