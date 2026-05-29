using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Modules.Processing
{
	[SelectionBase]
	public class ModuleImporter : MonoBehaviour
	{
		public GameObject input;

		public GameObject toDisable;

		public ModuleLibrary moduleLibrary;

		public MappedMaterialSettings mappedMaterialSettings;

		public MeshFilter debugMeshFilter;

		public Transform prefabContainer;

		[Space]
		public int3 waterModule;

		public int srcModuleCount;

		public uint sideHashCount;

		public List<ProtoModuleMesh> protoModuleMeshes;

		public List<ProtoModule> protoModules;

		public ProtoModule selectedProtoModule;

		public Module selectedModule;

		public DecorModule selectedDecor;

		private void Awake()
		{
		}
	}
}
