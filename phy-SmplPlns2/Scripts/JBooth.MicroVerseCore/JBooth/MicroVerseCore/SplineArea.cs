using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace JBooth.MicroVerseCore
{
	public class SplineArea : Stamp, IModifier
	{
		public SplineContainer spline;

		[Tooltip("This is the resolution of the signed distance field used to represent this spline")]
		public SplinePath.SDFRes sdfRes = SplinePath.SDFRes.k512;

		[Tooltip("This is the max distance for effects which use the spline to fall off. Because a spline area can be used by many different things, you have to set this on the area")]
		public float maxSDF = 128f;

		public Noise positionNoise = new Noise();

		private Dictionary<Terrain, SplineRenderer> splineRenderers = new Dictionary<Terrain, SplineRenderer>();

		private Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

		public bool NeedCurvatureMap()
		{
			return false;
		}

		public override void OnEnable()
		{
			if (spline == null)
			{
				spline = GetComponent<SplineContainer>();
			}
		}

		private void ClearSplineRenders()
		{
			foreach (SplineRenderer value in splineRenderers.Values)
			{
				value.Dispose();
			}
			splineRenderers.Clear();
		}

		private SplineRenderer GetSplineRenderer(Terrain terrain)
		{
			SplineRenderer.RenderDesc.Mode mode = (spline.Spline.Closed ? SplineRenderer.RenderDesc.Mode.Area : SplineRenderer.RenderDesc.Mode.Path);
			if (splineRenderers.ContainsKey(terrain))
			{
				SplineRenderer splineRenderer = splineRenderers[terrain];
				if (!(splineRenderer.lastMaxSDF < maxSDF))
				{
					return splineRenderer;
				}
				splineRenderer.Render(spline, terrain, positionNoise, null, (int)sdfRes, maxSDF, mode);
			}
			else if (TerrainUtil.ComputeTerrainBounds(terrain).Intersects(GetBounds()))
			{
				SplineRenderer splineRenderer2 = new SplineRenderer();
				bounds = new Bounds(Vector3.zero, Vector3.zero);
				splineRenderer2.Render(spline, terrain, positionNoise, null, (int)sdfRes, maxSDF, mode);
				splineRenderers.Add(terrain, splineRenderer2);
				return splineRenderer2;
			}
			return null;
		}

		public void UpdateSplineSDFs()
		{
			ClearSplineRenders();
			if (!(spline == null) && !(MicroVerse.instance == null))
			{
				MicroVerse.instance.SyncTerrainList();
				Terrain[] terrains = MicroVerse.instance.terrains;
				foreach (Terrain terrain in terrains)
				{
					GetSplineRenderer(terrain);
				}
			}
		}

		public void Initialize()
		{
		}

		public RenderTexture GetSDF(Terrain t)
		{
			return GetSplineRenderer(t)?.splineSDF;
		}

		public override void OnDisable()
		{
			base.OnDisable();
			ClearSplineRenders();
		}

		protected override void OnDestroy()
		{
			ClearSplineRenders();
			base.OnDestroy();
		}

		public void Dispose()
		{
		}

		public override Bounds GetBounds()
		{
			if (bounds.center == Vector3.zero && bounds.size == Vector3.zero)
			{
				bounds = SplinePath.ComputeBounds(spline, Mathf.Max(maxSDF, positionNoise.amplitude * 0.5f));
			}
			return bounds;
		}
	}
}
