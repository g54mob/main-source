using System;
using System.Collections.Generic;
using Libs;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	[Serializable]
	public class StreamLayerParts
	{
		[Tooltip("Rの時のパーツ名でいい")]
		public string partsName;

		public List<Dir.DirFlag> layers;
	}
}
