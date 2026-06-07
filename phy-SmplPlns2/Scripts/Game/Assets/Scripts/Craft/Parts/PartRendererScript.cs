using System;
using System.Collections.Generic;
using System.Linq;
using Jundroo.Common.Attributes;
using Jundroo.Common.Utils;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartRendererScript : MonoBehaviour
	{
		private delegate void UpdateConfigNameAndIndexDelegate(PartRendererMaterialConfiguration config, int submeshIndex, string name);

		[Serializable]
		public class PartRendererMaterialConfiguration
		{
			[SerializeField]
			[HideInInspector]
			private string __name;

			[SerializeField]
			[ReadOnlyInInspector("Submesh Index")]
			[Tooltip("The index of the submesh represented by this material configuration.")]
			private int __submeshIndex;

			[SerializeField]
			[Tooltip("The material level (trim) assigned to this submesh.")]
			private PartRendererMaterialLevel _materialLevel;

			[SerializeField]
			[Tooltip("The material type to use for this submesh. 'Default' uses the default behavior of SimplePlanes and generally works best, allowing the user to color the part as they wish. 'Custom With Original Colors' will preserve any custom materials and textures of the mesh. 'Custom With Theme Colors' will preserve any custom materials and textures of the mesh but will also allow the material color to be set on the mesh based on how the user colors the part.")]
			private PartRendererMaterialType _materialType;

			[SerializeField]
			[Tooltip("The default normal map assigned to this submesh (if any).")]
			private Texture2D _normalMap;

			[SerializeField]
			[Tooltip("The default occlusion map assigned to this submesh (if any).")]
			private Texture2D _occlusionMap;

			[SerializeField]
			[Tooltip("The default parallax map assigned to this submesh (if any).")]
			private Texture2D _parallaxMap;

			public PartRendererMaterialLevel MaterialLevel
			{
				get
				{
					return _materialLevel;
				}
				set
				{
					_materialLevel = value;
				}
			}

			public PartRendererMaterialType MaterialType
			{
				get
				{
					return _materialType;
				}
				set
				{
					_materialType = value;
				}
			}

			public string Name
			{
				get
				{
					return __name;
				}
				private set
				{
					__name = value;
				}
			}

			public Texture2D NormalMap
			{
				get
				{
					return _normalMap;
				}
				set
				{
					_normalMap = value;
				}
			}

			public Texture2D OcclusionMap
			{
				get
				{
					return _occlusionMap;
				}
				set
				{
					_occlusionMap = value;
				}
			}

			public Texture2D ParallaxMap
			{
				get
				{
					return _parallaxMap;
				}
				set
				{
					_parallaxMap = value;
				}
			}

			public int SubmeshIndex
			{
				get
				{
					return __submeshIndex;
				}
				private set
				{
					__submeshIndex = value;
				}
			}

			static PartRendererMaterialConfiguration()
			{
				_updateConfig = UpdateConfig;
			}

			private static void UpdateConfig(PartRendererMaterialConfiguration config, int submeshIndex, string name)
			{
				config.SubmeshIndex = submeshIndex;
				config.Name = name;
			}
		}

		private static UpdateConfigNameAndIndexDelegate _updateConfig;

		[SerializeField]
		[Tooltip("A value indicating whether to exclude this renderer from the drag model. By default, all mesh renderers are included in the drag calculation, so this flag can be set to remove specific renderers from the calculation.")]
		private bool _excludeFromDragModel;

		[SerializeField]
		[Tooltip("A value indicating if this mesh should be excluded from the combining of neighboring meshes.")]
		private bool _excludeFromMeshCombine;

		[SerializeField]
		[Tooltip("A value indicating if this renderer should be completely excluded from having its materials overwritten by the part.")]
		private bool _excludeFromPartMaterials;

		[SerializeField]
		[Tooltip("A value indicating whether to skip the assignment of part materials, but still do UV changes.")]
		private bool _excludeFromPartMaterialsAssignment;

		[SerializeField]
		[Tooltip("Material configuration information related to this specific part renderer.")]
		private PartRendererMaterialConfiguration[] _materials;

		private bool _onValidateCalled;

		public bool ExcludeFromDragModel
		{
			get
			{
				return _excludeFromDragModel;
			}
			set
			{
				_excludeFromDragModel = value;
			}
		}

		public bool ExcludeFromMeshCombine
		{
			get
			{
				return _excludeFromMeshCombine;
			}
			set
			{
				_excludeFromMeshCombine = value;
			}
		}

		public bool ExcludeFromPartMaterials
		{
			get
			{
				return _excludeFromPartMaterials;
			}
			set
			{
				_excludeFromPartMaterials = value;
			}
		}

		public bool ExcludeFromPartMaterialsAssignment
		{
			get
			{
				return _excludeFromPartMaterialsAssignment;
			}
			set
			{
				_excludeFromPartMaterialsAssignment = value;
			}
		}

		public IReadOnlyList<PartRendererMaterialConfiguration> Materials
		{
			get
			{
				return _materials;
			}
			set
			{
				_materials = value.ToArray();
				UpdateMaterialConfigs();
			}
		}

		protected virtual void OnValidate()
		{
			if (_onValidateCalled && Application.isPlaying)
			{
				return;
			}
			bool flag = false;
			if (!_onValidateCalled)
			{
				flag = _materials == null || _materials.Length == 0;
			}
			else if (Application.isPlaying)
			{
				return;
			}
			_onValidateCalled = true;
			if (!TryGetComponent<MeshFilter>(out var component))
			{
				if (!TryGetComponent<TextMeshPro>(out var _))
				{
					string fullObjectHierarchy = Utilities.GetFullObjectHierarchy(base.transform);
					Debug.LogWarning("The " + typeof(PartRendererScript).Name + " has no associated MeshFilter '" + fullObjectHierarchy + "'", this);
				}
				return;
			}
			Mesh sharedMesh = component.sharedMesh;
			if (sharedMesh == null)
			{
				string fullObjectHierarchy2 = Utilities.GetFullObjectHierarchy(base.transform);
				Debug.LogWarning("The " + typeof(PartRendererScript).Name + " has no associated mesh on its MeshFilter component on part '" + fullObjectHierarchy2 + "'", base.gameObject);
				return;
			}
			if (flag)
			{
				_materials = new PartRendererMaterialConfiguration[sharedMesh.subMeshCount];
				for (int i = 0; i < _materials.Length; i++)
				{
					_materials[i] = new PartRendererMaterialConfiguration();
				}
			}
			if (_materials == null)
			{
				_materials = new PartRendererMaterialConfiguration[0];
			}
			UpdateMaterialConfigs();
			if (sharedMesh.subMeshCount != _materials.Length)
			{
				string fullObjectHierarchy3 = Utilities.GetFullObjectHierarchy(base.transform);
				Debug.LogWarning($"The {typeof(PartRendererScript).Name} has {_materials.Length} materials levels defined but its mesh contains {sharedMesh.subMeshCount} submeshes on part '{fullObjectHierarchy3}'", base.gameObject);
			}
		}

		private void UpdateMaterialConfigs()
		{
			if (_materials == null)
			{
				return;
			}
			for (int i = 0; i < _materials.Length; i++)
			{
				PartRendererMaterialConfiguration partRendererMaterialConfiguration = _materials[i];
				_updateConfig(partRendererMaterialConfiguration, i, $"{i}: {partRendererMaterialConfiguration.MaterialLevel} ({partRendererMaterialConfiguration.MaterialType})");
				if ((partRendererMaterialConfiguration.NormalMap != null || partRendererMaterialConfiguration.OcclusionMap != null || partRendererMaterialConfiguration.ParallaxMap != null) && partRendererMaterialConfiguration.MaterialType == PartRendererMaterialType.DefaultShared)
				{
					partRendererMaterialConfiguration.MaterialType = PartRendererMaterialType.DefaultInstanced;
				}
			}
		}
	}
}
