using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class StyleController : SingletonMonoBehaviour<StyleController>
	{
		public bool neverCacheStyles;

		public List<SwatchMaterialTemplate> swatchMaterialTemplates;

		public Material[] materialsToIgnore;

		public List<StyleSwatch> styleSwatches;

		public List<StyleSet> styleSets;

		public Material GetDefaultTemplateMaterial()
		{
			return null;
		}

		public SwatchMaterialTemplate GetTemplateById(string id)
		{
			return null;
		}

		public SwatchMaterialTemplate GetTemplateByMaterialName(string matName)
		{
			return null;
		}

		public bool IsMaterialATemplate(Material mat)
		{
			return false;
		}

		private void Start()
		{
		}

		public StyleSwatch GetSwatch(string id)
		{
			return null;
		}

		public StyleSet GetStyleSet(string id)
		{
			return null;
		}
	}
}
