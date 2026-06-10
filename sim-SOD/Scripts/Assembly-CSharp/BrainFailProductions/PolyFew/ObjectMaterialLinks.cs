using System.Collections.Generic;
using BrainFailProductions.PolyFewRuntime;
using UnityEngine;

namespace BrainFailProductions.PolyFew
{
	[ExecuteInEditMode]
	public class ObjectMaterialLinks : MonoBehaviour
	{
		[SerializeField]
		private List<CombiningInformation.MaterialEntity> linkedEntities;

		public List<PolyfewRuntime.MaterialProperties> materialsProperties;

		public Texture2D linkedAttrImg;

		public List<CombiningInformation.MaterialEntity> linkedMaterialEntities
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Start()
		{
		}
	}
}
