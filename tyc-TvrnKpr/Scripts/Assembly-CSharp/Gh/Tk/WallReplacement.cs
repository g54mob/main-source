using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class WallReplacement : WallAddOn
	{
		public static HashSet<WallReplacement> AllWallReplacements;

		public string type;

		private int sessionId;

		private Transform[] _visualFullWall;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public List<Wall> AffectedWalls { get; internal set; }

		public Room[] CurrentRooms => null;

		public List<TileData> CurrentTiles => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public void Build()
		{
		}

		public override void Demolish(bool withRefund = true)
		{
		}

		public override void OnDestroy()
		{
		}

		public override void Start()
		{
		}

		public void RemoveFromGrid()
		{
		}

		public override void ExitEditMode()
		{
		}

		public override void EnterEditMode(bool ignoreSnapping = false)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		private void UpdateVisibility()
		{
		}

		private void UpdateVisibility(bool full)
		{
		}
	}
}
