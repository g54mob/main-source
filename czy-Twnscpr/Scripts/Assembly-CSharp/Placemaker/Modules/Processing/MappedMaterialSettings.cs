using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Modules.Processing
{
	[CreateAssetMenu]
	public class MappedMaterialSettings : ScriptableObject
	{
		public List<MappedMaterial> mappedMaterials;
	}
}
