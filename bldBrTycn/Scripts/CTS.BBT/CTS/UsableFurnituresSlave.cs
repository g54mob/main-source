using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace CTS
{
	[Obsolete("This script is obsolete, please use the Furniture Syncer")]
	public class UsableFurnituresSlave : CTSBehaviour
	{
		[field: SerializeField]
		[field: FormerlySerializedAs("UsableFurnituresCategoriesSO")]
		public UsableFurnituresCategoriesSO UsableFurnituresCategoriesSO { get; set; }
	}
}
