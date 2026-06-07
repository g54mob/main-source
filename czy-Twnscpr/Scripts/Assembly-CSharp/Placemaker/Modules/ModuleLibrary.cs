using System.Collections.Generic;
using Os.Utils;
using UnityEngine;

namespace Placemaker.Modules
{
	[CreateAssetMenu]
	public class ModuleLibrary : ScriptableObject
	{
		public List<uint> waterSides;

		public List<Module> modules;

		public List<DecorModule> decorModules;

		public List<CornerLookup> cornerLookups;

		public List<SideProfile> sideLookups;

		public List<ModuleMesh> moduleMeshes;

		public List<int> decorOverlaps;

		public ByteFloat2 groundUv0;

		public ByteFloat2 groundUv1;

		public Dictionary<ByteQube, int> cornerDict;

		private void OnEnable()
		{
		}

		public void Setup()
		{
		}

		public bool GetDecorOverlap(OrientedModule decor0, OrientedModule decor1)
		{
			return false;
		}
	}
}
