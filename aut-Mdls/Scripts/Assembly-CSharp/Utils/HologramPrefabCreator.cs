using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Utils
{
	public class HologramPrefabCreator : MonoBehaviour
	{
		[Header("Static Refs, no touch")]
		[SerializeField]
		[HideInInspector]
		private Material _hologramMaterial;

		[SerializeField]
		[HideInInspector]
		private Material _outlineMaterial;

		[SerializeField]
		[HideInInspector]
		private Material _baseAppearMaterial;

		[SerializeField]
		[ValidateInput("IsNotNullOrEmpty", "Must provide operator name, i.e: \"Cutter\"")]
		private string _operatorName = "";

		[SerializeField]
		private bool _includeChildren = true;

		[SerializeField]
		private List<MeshFilter> _hologramMeshes;

		private const string APPEAR_MATERIAL_PATH = "Assets/Art Assets/VFX/Holograms/Material/CuttedAppear/";
	}
}
