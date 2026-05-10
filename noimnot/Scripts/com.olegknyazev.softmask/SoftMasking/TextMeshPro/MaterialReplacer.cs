using UnityEngine;
using UnityEngine.Scripting;

namespace SoftMasking.TextMeshPro
{
	[Preserve]
	[GlobalMaterialReplacer]
	public class MaterialReplacer : IMaterialReplacer
	{
		public int order => 0;

		public Material Replace(Material material)
		{
			return null;
		}
	}
}
