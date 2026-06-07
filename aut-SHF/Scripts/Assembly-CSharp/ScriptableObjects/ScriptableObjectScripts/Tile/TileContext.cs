using Factory.FieldObject;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	public class TileContext
	{
		public int TilemapLayer;

		public Vector3Int GridPos;

		public Vector2Int AddrCache;

		public TileBase TileBase;

		public UvAnimationTile[] UvAnimationTiles;

		public DTileBase2 OverrideAnimationTile;

		public string PartsName;

		public string PartsNameSuffix;

		public bool HasBillboard;

		public bool BillboardOnly;

		public bool PlayBillboardAnimation;

		public string[] BillboardPartsNames;

		public int? BillboardAnimationManualIndex;

		public float? BillboardAnimationSpecificRate;

		public bool? BillboardAnimationLoopOnce;

		public bool BillboardAnimationKeepIndex;

		public float AnimationSpeed;

		public int AnimationStartFrame;

		public TileAnimationFlags? TileAnimationFlags;

		public float? AnimationLayerRotateZForInserterGuide;

		public float? RotateZForRotatableAnimatedTile;

		public MultilayeredBillboardObject MultilayeredBillboardObjectCache;

		public int MinionNum;

		public bool IsEliteMinion;

		public int MinionLayer;

		public bool ArriveMinion;

		public bool LeaveMinion;

		public bool ArriveTile;

		public int CounterSignboardNumerator;

		public int CounterSignboardDenominator;

		public BillboardAnimationSpecificLayer[] PlayBillboardAnimationSeparately { get; set; }

		public override string ToString()
		{
			return null;
		}
	}
}
