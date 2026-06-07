using JBooth.MicroSplat;
using UnityEngine;

namespace Assets.Scripts.Environment.Terrain
{
	[CreateAssetMenu(fileName = "MicrosplatMaterialData", menuName = "SimplePlanes 2/MicroSplat/Microsplat Material Data")]
	public class MicrosplatMaterialData : ScriptableObject
	{
		[SerializeField]
		private Material _material;

		[SerializeField]
		private MicroSplatKeywords _keywords;

		[SerializeField]
		private MicroSplatProceduralTextureConfig _proceduralTextureConfig;

		[SerializeField]
		private MicroSplatPropData _propData;

		public MicroSplatKeywords Keywords => _keywords;

		public Material Material => _material;

		public MicroSplatProceduralTextureConfig ProceduralTextureConfig => _proceduralTextureConfig;

		public MicroSplatPropData PropData => _propData;
	}
}
