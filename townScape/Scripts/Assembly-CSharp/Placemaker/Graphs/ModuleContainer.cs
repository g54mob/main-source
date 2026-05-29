using System.Collections.Generic;
using Placemaker.Modules;
using UnityEngine;

namespace Placemaker.Graphs
{
	public class ModuleContainer : MonoBehaviour
	{
		public OrientedModule orientedModule;

		public bool hasProps;

		public int propIndex;

		public List<BigMeshPart> bigMeshParts;
	}
}
