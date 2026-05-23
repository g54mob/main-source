using System.Collections.Generic;
using Factory.FieldObject;
using Libs;
using UnityEngine;
using UnityEngine.Search;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	[CreateAssetMenu(fileName = "DTileBase2", menuName = "Factory/DTileBase2")]
	public class DTileBase2 : TileBase
	{
		[Header("==ビルボード関係==")]
		[FormerlySerializedAs("prefab")]
		[SerializeField]
		internal GameObject billboardPrefab;

		[SerializeField]
		private LayeredBillboardObjectInit[] billboardObjectInits;

		public TextureSet[] billboardTextureSets;

		public NamedSprites[] billboardSpriteParts;

		[SerializeField]
		private Vector2 signboardOffset;

		[SerializeField]
		private bool signboardMultiMinion;

		[SerializeField]
		private bool signboardCounter;

		[Header("==Animation(Frame)レイヤー==")]
		[SerializeField]
		private DTileBase2 animationTile;

		[Tooltip("カーソルの時だけ表示する")]
		[SerializeField]
		private bool animationTileCursorPreviewOnly;

		[Header("==Mainレイヤー==")]
		public Texture2D[] textures;

		[Tooltip("自動的にアニメーションさせない")]
		[SerializeField]
		private bool manualAnimation;

		[SearchContext("ext:json")]
		public TextAsset texturePartsMap;

		public string fallbackPartsName;

		public NamedSprites[] parts;

		internal Dictionary<string, NamedSprites> PartsDic;

		public static float manualAnimationSpeed;

		internal virtual void Awake()
		{
		}

		internal void SetupDics()
		{
		}

		public override void RefreshTile(Vector3Int position, ITilemap tilemap)
		{
		}

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
		}

		public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
		{
			return false;
		}

		internal virtual NamedSprites GetPartsSprites(string partsName, string partsNameSuffix)
		{
			return null;
		}

		public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
		{
			return false;
		}

		public Sprite GetTypicalSprite()
		{
			return null;
		}

		public DTileBase2 GetAnimationLayerTile(bool cursorPreview)
		{
			return null;
		}
	}
}
