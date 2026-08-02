using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[Serializable]
	public struct EquipmentSkin
	{
		public string Name;

		public Mesh SharedMesh;

		public Material[] SharedMaterials;
	}
}
