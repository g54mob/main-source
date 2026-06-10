using System.Collections.Generic;
using UnityEngine;

namespace BrainFailProductions.PolyFew.AsImpL
{
	public class MultiObjectImporter : ObjectImporter
	{
		[Tooltip("Load models in the list on start")]
		public bool autoLoadOnStart;

		[Tooltip("Models to load on startup")]
		public List<ModelImportInfo> objectsList;

		[Tooltip("Default import options")]
		public ImportOptions defaultImportOptions;

		[SerializeField]
		private PathSettings pathSettings;

		public string RootPath => null;

		public void ImportModelListAsync(ModelImportInfo[] modelsInfo)
		{
		}

		protected virtual void Start()
		{
		}
	}
}
