using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace JBooth.MicroVerseCore
{
	[Serializable]
	public class DetailPrototypeSerializable
	{
		public GameObject prototype;

		public float alignToGround;

		public float density;

		public Color dryColor = Color.white;

		public Color healthyColor = Color.white;

		public float holeEdgePadding;

		public float minWidth;

		public float maxWidth;

		public float minHeight;

		public float maxHeight;

		public int noiseSeed;

		public float noiseSpread;

		public float positionJitter;

		public Texture2D prototypeTexture;

		public DetailRenderMode renderMode;

		public float targetCoverage;

		public bool useInstancing;

		public bool useDensityScaling;

		public bool usePrototypeMesh;

		public override int GetHashCode()
		{
			return HashCode.Combine(prototype);
		}

		public static bool operator ==(DetailPrototypeSerializable obj1, DetailPrototypeSerializable obj2)
		{
			if ((object)obj1 == obj2)
			{
				return true;
			}
			if ((object)obj1 == null)
			{
				return false;
			}
			if ((object)obj2 == null)
			{
				return false;
			}
			return obj1.Equals(obj2);
		}

		public static bool operator !=(DetailPrototypeSerializable obj1, DetailPrototypeSerializable obj2)
		{
			return !(obj1 == obj2);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as DetailPrototypeSerializable);
		}

		public bool Equals(DetailPrototypeSerializable x)
		{
			if ((object)x == null)
			{
				return false;
			}
			if ((object)this == x)
			{
				return true;
			}
			return (byte)(1u & ((x.prototype == prototype) ? 1u : 0u) & ((x.alignToGround == alignToGround) ? 1u : 0u) & ((x.targetCoverage == targetCoverage) ? 1u : 0u) & ((x.useDensityScaling == useDensityScaling) ? 1u : 0u) & ((x.positionJitter == positionJitter) ? 1u : 0u) & ((x.density == density) ? 1u : 0u) & ((x.dryColor == dryColor) ? 1u : 0u) & ((x.healthyColor == healthyColor) ? 1u : 0u) & ((x.holeEdgePadding == holeEdgePadding) ? 1u : 0u) & ((x.maxHeight == maxHeight) ? 1u : 0u) & ((x.minHeight == minHeight) ? 1u : 0u) & ((x.maxWidth == maxWidth) ? 1u : 0u) & ((x.minWidth == minWidth) ? 1u : 0u) & ((x.noiseSeed == noiseSeed) ? 1u : 0u) & ((x.noiseSpread == noiseSpread) ? 1u : 0u) & ((x.prototypeTexture == prototypeTexture) ? 1u : 0u) & ((x.renderMode == renderMode) ? 1u : 0u) & ((x.useInstancing == useInstancing) ? 1u : 0u) & ((x.usePrototypeMesh == usePrototypeMesh) ? 1u : 0u)) != 0;
		}

		public int GetHashCode(DetailPrototypeSerializable t)
		{
			if ((object)t == null)
			{
				return 0;
			}
			return 0 ^ ((!(prototype == null)) ? prototype.GetHashCode() : 0) ^ alignToGround.GetHashCode() ^ targetCoverage.GetHashCode() ^ useDensityScaling.GetHashCode() ^ positionJitter.GetHashCode() ^ density.GetHashCode() ^ dryColor.GetHashCode() ^ healthyColor.GetHashCode() ^ holeEdgePadding.GetHashCode() ^ maxHeight.GetHashCode() ^ minHeight.GetHashCode() ^ maxWidth.GetHashCode() ^ minWidth.GetHashCode() ^ noiseSeed.GetHashCode() ^ noiseSpread.GetHashCode() ^ ((!(prototypeTexture == null)) ? prototypeTexture.GetHashCode() : 0) ^ renderMode.GetHashCode() ^ useInstancing.GetHashCode() ^ usePrototypeMesh.GetHashCode();
		}

		public bool IsValid()
		{
			if (usePrototypeMesh && prototype == null)
			{
				return false;
			}
			if (!usePrototypeMesh && prototypeTexture == null)
			{
				return false;
			}
			return true;
		}

		public DetailPrototypeSerializable()
		{
			ResetToMesh(seed: false);
		}

		public void ResetToMesh(bool seed = true)
		{
			noiseSeed = 0;
			if (seed)
			{
				noiseSeed = UnityEngine.Random.Range(1, int.MaxValue);
			}
			useDensityScaling = true;
			usePrototypeMesh = true;
			noiseSpread = 1f;
			useInstancing = true;
			minHeight = 1f;
			minWidth = 1f;
			maxHeight = 2f;
			maxWidth = 2f;
			density = 1f;
			renderMode = DetailRenderMode.VertexLit;
		}

		public void ResetToTexture()
		{
			ResetToMesh();
			renderMode = DetailRenderMode.GrassBillboard;
			usePrototypeMesh = false;
			if (GraphicsSettings.currentRenderPipeline != null && GraphicsSettings.currentRenderPipeline.terrainDetailGrassBillboardShader == null)
			{
				renderMode = DetailRenderMode.Grass;
			}
		}

		public DetailPrototypeSerializable(DetailPrototype d)
		{
			prototype = d.prototype;
			alignToGround = d.alignToGround;
			positionJitter = d.positionJitter;
			targetCoverage = d.targetCoverage;
			useDensityScaling = d.useDensityScaling;
			density = d.density;
			dryColor = d.dryColor;
			healthyColor = d.healthyColor;
			holeEdgePadding = d.holeEdgePadding;
			maxHeight = d.maxHeight;
			minHeight = d.minHeight;
			maxWidth = d.maxWidth;
			minWidth = d.minWidth;
			useInstancing = d.useInstancing;
			noiseSeed = d.noiseSeed;
			noiseSpread = d.noiseSpread;
			prototypeTexture = d.prototypeTexture;
			renderMode = d.renderMode;
			usePrototypeMesh = d.usePrototypeMesh;
		}

		public DetailPrototype GetPrototype()
		{
			DetailPrototype detailPrototype = new DetailPrototype();
			detailPrototype.prototype = prototype;
			if (prototype != null)
			{
				LODGroup component = prototype.GetComponent<LODGroup>();
				if (component != null)
				{
					foreach (Transform item in component.transform)
					{
						if (item.GetComponent<Renderer>() != null && item.GetSiblingIndex() == 0)
						{
							detailPrototype.prototype = item.gameObject;
						}
					}
				}
			}
			detailPrototype.alignToGround = alignToGround;
			detailPrototype.positionJitter = positionJitter;
			detailPrototype.targetCoverage = targetCoverage;
			detailPrototype.useDensityScaling = useDensityScaling;
			detailPrototype.density = density;
			detailPrototype.dryColor = dryColor;
			detailPrototype.healthyColor = healthyColor;
			detailPrototype.holeEdgePadding = holeEdgePadding;
			detailPrototype.maxHeight = maxHeight;
			detailPrototype.minHeight = minHeight;
			detailPrototype.maxWidth = maxWidth;
			detailPrototype.minWidth = minWidth;
			detailPrototype.useInstancing = useInstancing;
			detailPrototype.noiseSeed = noiseSeed;
			detailPrototype.noiseSpread = noiseSpread;
			detailPrototype.prototypeTexture = prototypeTexture;
			detailPrototype.renderMode = renderMode;
			detailPrototype.usePrototypeMesh = usePrototypeMesh;
			if (!detailPrototype.usePrototypeMesh)
			{
				detailPrototype.prototype = null;
				detailPrototype.useInstancing = false;
			}
			else
			{
				detailPrototype.prototypeTexture = null;
			}
			return detailPrototype;
		}

		public bool IsEqualToDetail(DetailPrototype detail)
		{
			return (byte)(1u & ((detail.prototype == prototype || detail.prototype?.transform.root?.gameObject == prototype) ? 1u : 0u) & ((detail.alignToGround == alignToGround) ? 1u : 0u) & ((detail.targetCoverage == targetCoverage) ? 1u : 0u) & ((detail.useDensityScaling == useDensityScaling) ? 1u : 0u) & ((detail.positionJitter == positionJitter) ? 1u : 0u) & ((detail.density == density) ? 1u : 0u) & ((detail.dryColor == dryColor) ? 1u : 0u) & ((detail.healthyColor == healthyColor) ? 1u : 0u) & ((detail.holeEdgePadding == holeEdgePadding) ? 1u : 0u) & ((detail.maxHeight == maxHeight) ? 1u : 0u) & ((detail.minHeight == minHeight) ? 1u : 0u) & ((detail.maxWidth == maxWidth) ? 1u : 0u) & ((detail.minWidth == minWidth) ? 1u : 0u) & ((detail.noiseSeed == noiseSeed) ? 1u : 0u) & ((detail.noiseSpread == noiseSpread) ? 1u : 0u) & ((detail.prototypeTexture == prototypeTexture) ? 1u : 0u) & ((detail.renderMode == renderMode) ? 1u : 0u) & ((detail.usePrototypeMesh == usePrototypeMesh) ? 1u : 0u)) != 0;
		}
	}
}
