using System;
using System.Collections.Generic;
using Libs;
using Models;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	[Serializable]
	public class TileDetailPack
	{
		[Tooltip("機械自体の回転")]
		[FormerlySerializedAs("packRot2")]
		public Dir.Rot rotate;

		public Vector2Int size;

		[FormerlySerializedAs("tileAndStates")]
		[SerializeField]
		private List<TileDetail> tileDetails;

		public eMachine MachineID { get; set; }

		public bool IsGroup => false;

		public bool IsEmpty => false;

		public static TileDetailPack Empty => null;

		public TileDetail GetTileDetail(int index, TileBase overwriteTile = null)
		{
			return null;
		}

		public List<TileDetail> GetTileDetails(TileBase overwriteTile = null)
		{
			return null;
		}

		public TileDetailPack()
		{
		}

		public TileDetailPack(TileDetailPack other, eMachine machineID, int stretch = 0, int? joint = null, Dir.Rot? rotForMono = null, string[] partsNameForStream = null)
		{
		}

		public List<Vector2Int> GetInputAddrList(Vector2Int addr)
		{
			return null;
		}

		public List<(Vector2Int, Vector2Int)> GetInputAddrPairList(Vector2Int addr)
		{
			return null;
		}

		public List<(Vector2Int, Vector2Int)> GetOutputAddrPairList(Vector2Int addr)
		{
			return null;
		}

		public List<(Vector2Int, Vector2Int)> GetPipeAddrPairList(Vector2Int addr)
		{
			return null;
		}

		public List<(Vector2Int, Vector2Int)> GetInputAddrPairList(Vector2IntBundle addr)
		{
			return null;
		}

		public List<(Vector2Int, Vector2Int)> GetOutputAddrPairList(Vector2IntBundle addr)
		{
			return null;
		}

		public List<(Vector2Int, Vector2Int)> GetPipeAddrPairList(Vector2IntBundle addr)
		{
			return null;
		}

		public TileDetailPack CreateMergedPack(TileDetailPack other)
		{
			return null;
		}

		public List<StructureAddr> GetVector2Ints(Vector2Int basePos)
		{
			return null;
		}

		public List<StructureAddr> GetVector2Ints(Vector2IntBundle basePos)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToDump()
		{
			return null;
		}
	}
}
