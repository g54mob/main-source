using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class LODMeshFusionSource : MeshFusionSource
	{
		[SerializeField]
		[HideInInspector]
		private LODGroup _group;

		private LODGroupCombineSource _source;

		private CombinedLODGroupPart _part;

		private Bounds? _savedBounds;

		public override bool TryGetBounds(ref Bounds bounds)
		{
			if (_source != null)
			{
				bounds = _source.Bounds;
				return true;
			}
			if (_part != null)
			{
				bounds = _part.Bounds;
				return true;
			}
			if (_savedBounds.HasValue)
			{
				bounds = _savedBounds.Value;
				return true;
			}
			if (base.IsIncompatible)
			{
				return false;
			}
			LOD[] lODs = _group.GetLODs();
			bounds = new Bounds(base.transform.position, Vector3.zero);
			for (int i = 0; i < lODs.Length; i++)
			{
				Renderer[] renderers = lODs[i].renderers;
				for (int j = 0; j < renderers.Length; j++)
				{
					if (!(renderers[j] == null))
					{
						bounds.Encapsulate(renderers[j].bounds);
					}
				}
			}
			_savedBounds = bounds;
			return true;
		}

		protected override void OnSourceCombinedInternal(ICombinedObject root, ICombinedObjectPart part)
		{
			_part = (CombinedLODGroupPart)part;
		}

		protected override bool CheckCompatibilityAndGetComponents(out string incompatibilityReason)
		{
			if (_group == null)
			{
				_group = GetComponent<LODGroup>();
			}
			if (_group == null)
			{
				incompatibilityReason = "LODGroup not found";
				return false;
			}
			incompatibilityReason = "Compatible renderers not found";
			MeshFilter filter = null;
			Mesh mesh = null;
			LOD[] lODs = _group.GetLODs();
			for (int i = 0; i < lODs.Length; i++)
			{
				Renderer[] renderers = lODs[i].renderers;
				for (int j = 0; j < renderers.Length; j++)
				{
					MeshRenderer renderer = renderers[j] as MeshRenderer;
					if (!(renderer == null))
					{
						string incompatibilityReason2 = "";
						if (CanCreateCombineSource(renderer.gameObject, ref incompatibilityReason2, ref renderer, ref filter, ref mesh))
						{
							incompatibilityReason = "";
							return true;
						}
						incompatibilityReason += $"\n\n {renderer.gameObject.name} {incompatibilityReason2}";
						filter = null;
						mesh = null;
					}
				}
			}
			return false;
		}

		protected override void CreateSources()
		{
			_source = new LODGroupCombineSource(_group);
		}

		protected override IEnumerable<ICombineSource> GetCombineSources()
		{
			if (_source != null)
			{
				yield return _source;
			}
		}

		protected override IEnumerable<ICombinedObjectPart> GetCombinedParts()
		{
			if (_part != null)
			{
				yield return _part;
			}
		}

		protected override void ClearSources()
		{
			if (_source != null)
			{
				_source = null;
			}
		}

		protected override void ClearParts()
		{
			if (_part != null)
			{
				_part = null;
			}
		}

		protected override void ToggleComponents(bool enabled)
		{
			LOD[] lODs = _group.GetLODs();
			for (int i = 0; i < lODs.Length; i++)
			{
				Renderer[] renderers = lODs[i].renderers;
				for (int j = 0; j < renderers.Length; j++)
				{
					if (!(renderers[j] == null))
					{
						renderers[j].enabled = enabled;
					}
				}
			}
			_group.enabled = enabled;
		}
	}
}
