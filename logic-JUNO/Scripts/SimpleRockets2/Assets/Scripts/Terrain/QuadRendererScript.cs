using Assets.Scripts.Terrain.Rendering;
using UnityEngine;

namespace Assets.Scripts.Terrain
{
	[SelectionBase]
	public class QuadRendererScript : MonoBehaviour
	{
		[SerializeField]
		private bool _isCulled;

		[SerializeField]
		private QuadScript _quad;

		[SerializeField]
		private MeshFilter _terrainMesh;

		[SerializeField]
		private MeshRenderer _terrainRenderer;

		[SerializeField]
		private MeshFilter _waterMesh;

		[SerializeField]
		private MeshRenderer _waterRenderer;

		public QuadScript Quad => _quad;

		public static QuadRendererScript Create(QuadScript quad)
		{
			QuadRendererScript quadRendererScript = Game.Instance.ResourceLoader.InstantiatePrefab<QuadRendererScript>("Planets/PlanetQuadRenderer");
			quadRendererScript.Initialize(quad);
			return quadRendererScript;
		}

		public static void Destroy(QuadRendererScript quad)
		{
			if (quad != null)
			{
				Object.Destroy(quad.gameObject);
			}
		}

		public void Initialize(QuadScript quad)
		{
			_quad = quad;
			base.gameObject.name = $"Quad_{quad.SubdivisionLevel}";
			Transform obj = base.transform;
			obj.SetParent(quad.QuadSphere.Transform, worldPositionStays: false);
			obj.localPosition = quad.PlanetPosition.ToVector3();
			QuadRenderingData renderingData = quad.RenderingData;
			_terrainMesh.sharedMesh = renderingData.TerrainMesh;
			_waterMesh.sharedMesh = renderingData.WaterMesh;
			_terrainRenderer.sharedMaterial = renderingData.TerrainMaterial;
			_waterRenderer.sharedMaterial = renderingData.WaterMaterial;
			_isCulled = true;
		}

		[ContextMenu("Refresh Quad")]
		public void RefreshQuad()
		{
			Quad.RefreshQuad();
		}

		public void SetVisibility(bool visible)
		{
			_isCulled = false;
			_terrainRenderer.enabled = visible;
			_waterRenderer.enabled = visible;
		}

		public void SetVisibilityAndHideChildren(bool visible)
		{
			if (visible || !_isCulled)
			{
				_isCulled = !visible;
				_terrainRenderer.enabled = visible;
				_waterRenderer.enabled = visible;
				HideAllChildren();
			}
		}

		protected virtual void OnDrawGizmosSelected()
		{
		}

		private void HideAllChildren()
		{
			QuadScript[] children = _quad.Children;
			if (children != null)
			{
				QuadRendererScript quadRenderer = children[0].QuadRenderer;
				if (!quadRenderer._isCulled)
				{
					quadRenderer.HideAllChildren();
					quadRenderer._isCulled = true;
					quadRenderer._terrainRenderer.enabled = false;
					quadRenderer._waterRenderer.enabled = false;
				}
				quadRenderer = children[1].QuadRenderer;
				if (!quadRenderer._isCulled)
				{
					quadRenderer.HideAllChildren();
					quadRenderer._isCulled = true;
					quadRenderer._terrainRenderer.enabled = false;
					quadRenderer._waterRenderer.enabled = false;
				}
				quadRenderer = children[2].QuadRenderer;
				if (!quadRenderer._isCulled)
				{
					quadRenderer.HideAllChildren();
					quadRenderer._isCulled = true;
					quadRenderer._terrainRenderer.enabled = false;
					quadRenderer._waterRenderer.enabled = false;
				}
				quadRenderer = children[3].QuadRenderer;
				if (!quadRenderer._isCulled)
				{
					quadRenderer.HideAllChildren();
					quadRenderer._isCulled = true;
					quadRenderer._terrainRenderer.enabled = false;
					quadRenderer._waterRenderer.enabled = false;
				}
			}
		}
	}
}
