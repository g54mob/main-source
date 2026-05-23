using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	public class UvAnimationTile : TileBase
	{
		public Sprite[] sprites;

		public TextAsset UvAnimationPartsMap;

		[NonSerialized]
		public eLuggage luggageId;

		[NonSerialized]
		public float craftSpeed;

		[NonSerialized]
		public int split;

		[NonSerialized]
		public int materialCount;

		[NonSerialized]
		public MstBlendDataEntities blendData;

		[Header("jsonを自動でセットしないモード。主にErrorテクスチャ用")]
		public bool manualMode;

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
		}

		public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
		{
			return false;
		}
	}
}
