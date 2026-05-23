using System;
using System.Collections.Generic;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.ExtendData;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	[Serializable]
	public class TileDetail
	{
		public string partsName;

		[FormerlySerializedAs("出力")]
		public int outPort;

		[FormerlySerializedAs("出力方向")]
		[Tooltip("常に全体が右向きの時を基準角度として考えること")]
		public Dir.DirFlag outDir;

		[FormerlySerializedAs("入力")]
		public int inPort;

		[FormerlySerializedAs("入力方向")]
		[Tooltip("常に全体が右向きの時を基準角度として考えること")]
		public Dir.DirFlag inDir;

		public int pipePort;

		public Dir.DirFlag pipeDir;

		private int _outPortOrg;

		private int _inPortOrg;

		private int _pipePortOrg;

		public List<Dir.DirFlag> DirLayers { get; set; }

		public TileBase TileAsset { get; set; }

		public eMachine MachineID { get; set; }

		public ExtMachineData ExtMachineData { get; set; }

		public Dir.Rot Rot { get; set; }

		public List<TileAppend> TileAppends { get; private set; }

		public TileDetail(TileDetail other, ExtMachineData extDat, Dir.Rot packRot, TileBase overwriteTile = null, int? index = null)
		{
		}

		public void UpdatePort(ExtMachineData extDat)
		{
		}

		public Dir.DirFlag GetPipeDir(int streamLayer)
		{
			return default(Dir.DirFlag);
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
