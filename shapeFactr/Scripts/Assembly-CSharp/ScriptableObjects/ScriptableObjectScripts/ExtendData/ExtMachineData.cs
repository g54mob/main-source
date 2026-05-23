using System;
using System.Collections.Generic;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.ScriptableObjectScripts.ExtendData
{
	public class ExtMachineData : ScriptableObject
	{
		[Serializable]
		public class ProductIcon
		{
			public string icon;

			public int portPriority;

			public Dir.DirFlag dir;

			public eAttachment[] attachments;
		}

		[SerializeField]
		private eMachine machineID;

		public DTileBase2 tileAsset;

		[FormerlySerializedAs("existObject")]
		[Tooltip("ビルボードオブジェクトが付随するか")]
		[SerializeField]
		private bool hasBillboard;

		[FormerlySerializedAs("packDataAry2")]
		[SerializeField]
		[EnumLabel(typeof(Dir.Rot))]
		public List<TileDetailPack> tileDetailPacks;

		[Header("一つのタイルに複数のストリームが含まれる")]
		public List<StreamLayerParts> streamLayerPartsList;

		[Header("破壊不能")]
		[SerializeField]
		private bool unbreakable;

		[Header("抽出機専用：どの資源に隣接させるか")]
		[FormerlySerializedAs("requireNeighborAutoRotateToPrimaryCategory")]
		[FormerlySerializedAs("requireNeighborAutoRotate")]
		public ePrimaryMachineCategory neighborExtractorPrimaryCategory;

		[Header("装置のタイプ")]
		[FormerlySerializedAs("RyuroType")]
		[FormerlySerializedAs("流路")]
		[SerializeField]
		private bool StreamType;

		[FormerlySerializedAs("資源Type")]
		[SerializeField]
		private bool ShigenType;

		[FormerlySerializedAs("加工Type")]
		[SerializeField]
		private bool KakouType;

		[Header("産出資源")]
		[FormerlySerializedAs("_産出資源")]
		[SerializeField]
		public eLuggage naturalResource;

		[Header("アタッチメントでポート解放")]
		public int outPortBlockFirst;

		public eAttachment[] outPortOpen;

		public int inPortBlockFirst;

		public eAttachment inPortOpen;

		public int pipePortBlockFirst;

		public eAttachment pipePortOpen;

		[Header("プロダクトアイコン")]
		public ProductIcon[] outPortProductIcons;

		public ProductIcon[] inPortProductIcons;

		public eMachine MachineID => default(eMachine);

		public bool IsGroup => false;

		public int RotCount => 0;

		public Vector2Int TypicalSize => default(Vector2Int);

		public bool HasToggle => false;

		public TileDetailPack GetTileDetailPack(Dir.Rot rot, int stretch = 0, int? joint = null, string[] partsNameForStream = null)
		{
			return null;
		}

		public Vector2Int Size(Dir.Rot rot)
		{
			return default(Vector2Int);
		}

		public (Vector2Int, List<TileDetail>) GetSizeAndTileAppends(Dir.Rot rot)
		{
			return default((Vector2Int, List<TileDetail>));
		}

		public Sprite GetMainSprite()
		{
			return null;
		}

		public Sprite GetTypicalSprite()
		{
			return null;
		}

		public TileBase GetTileBase()
		{
			return null;
		}

		public DTileBase2 GetDTileBase()
		{
			return null;
		}

		public void ReflectTo(ref MstMachineDataEntities mstData)
		{
		}
	}
}
