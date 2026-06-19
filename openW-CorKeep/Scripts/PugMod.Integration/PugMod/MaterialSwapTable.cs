using System;
using System.Collections.Generic;
using UnityEngine;

namespace PugMod
{
	[CreateAssetMenu(fileName = "MaterialSwapTable.asset", menuName = "Pug/ModSDK/MaterialSwapTable")]
	public class MaterialSwapTable : ScriptableObject
	{
		[Serializable]
		public struct SwapEntry
		{
			public string materialName;

			public Material materialToSwapTo;
		}

		public List<SwapEntry> materials;
	}
}
