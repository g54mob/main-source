using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace CTS
{
	public class RoomVisuals : MonoBehaviour
	{
		private SurfaceObject[] _floorTiles;

		private SurfaceObject[] _wallPieces;

		[field: FormerlySerializedAs("_floorData")]
		[field: SerializeField]
		public SurfaceData FloorData { get; private set; }

		[field: SerializeField]
		public SurfaceData WallData { get; private set; }

		private void Awake()
		{
			foreach (Transform child in base.transform.GetChildren())
			{
				if (child.name == "Floor")
				{
					_floorTiles = child.GetComponentsInChildren<SurfaceObject>(includeInactive: true);
				}
				else if (child.name == "Walls")
				{
					_wallPieces = child.GetComponentsInChildren<SurfaceObject>(includeInactive: true);
				}
			}
		}

		private void Start()
		{
			if ((bool)FloorData)
			{
				ChangeFloorMaterial(FloorData);
			}
			if ((bool)WallData)
			{
				ChangeWallMaterial(WallData);
			}
		}

		public void ChangeFloorMaterial(SurfaceData surfaceData)
		{
			FloorData = surfaceData;
			LoopChange(_floorTiles, FloorData.MaterialData);
		}

		public void ChangeWallMaterial(SurfaceData surfaceData)
		{
			WallData = surfaceData;
			LoopChange(_wallPieces, WallData.MaterialData);
		}

		private void LoopChange(IEnumerable<SurfaceObject> surfaces, Material newMaterial)
		{
			foreach (SurfaceObject surface in surfaces)
			{
				surface.ChangeMaterial(newMaterial);
			}
		}
	}
}
