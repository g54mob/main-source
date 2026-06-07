using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class PartMeshScript : MonoBehaviour
	{
		private PartMeshRenderQueue _defaultRenderQueue;

		[SerializeField]
		[Tooltip("A value indicating whether to exclude this mesh from the drag model. By default, all mesh renderers are included in the drag calculation, so this flag can be set to remove specific renderers from the calculation.")]
		private bool _excludeFromDragModel;

		[SerializeField]
		[Tooltip("A value indicating if this mesh should be excluded from the combining of neighboring meshes.")]
		private bool _excludeFromMeshCombine;

		[SerializeField]
		[Tooltip("A value indicating if this mesh should be excluded from having its materials overwritten by the part.")]
		private bool _excludeFromPartMaterials;

		[SerializeField]
		[Tooltip("A value indicating what render queue to use for this object's material.")]
		private PartMeshRenderQueue _renderQueue;

		[SerializeField]
		[Tooltip("A flag used by some modifiers to indicate that this mesh is used when overriding the alpha-ness of the part material.")]
		private bool _usesAlphaOverride;

		[SerializeField]
		[Tooltip("A flag used by some modifiers to indicate that this mesh is used when overriding the emissive-ness of the part material.")]
		private bool _usesEmissiveOverride;

		[SerializeField]
		[Tooltip("A flag used to indicate that this mesh is a depth mask.")]
		private bool _isDepthMask;

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

		public bool IsDepthmask => _isDepthMask;

		public PartMeshRenderQueue RenderQueue
		{
			get
			{
				return _renderQueue;
			}
			set
			{
				if (IsDepthmask)
				{
					if (value == PartMeshRenderQueue.Transparent)
					{
						GetComponent<MeshRenderer>().enabled = false;
					}
					else
					{
						GetComponent<MeshRenderer>().enabled = true;
					}
					_renderQueue = value;
				}
				else if (value == PartMeshRenderQueue.Default)
				{
					_renderQueue = _defaultRenderQueue;
				}
				else
				{
					_renderQueue = value;
				}
			}
		}

		public bool UsesAlphaOverride
		{
			get
			{
				return _usesAlphaOverride;
			}
			set
			{
				_usesAlphaOverride = value;
			}
		}

		public bool UsesEmissiveOverride
		{
			get
			{
				return _usesEmissiveOverride;
			}
			set
			{
				_usesEmissiveOverride = value;
			}
		}

		protected virtual void Awake()
		{
			_defaultRenderQueue = _renderQueue;
		}
	}
}
