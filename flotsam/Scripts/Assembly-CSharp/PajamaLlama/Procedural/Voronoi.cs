using System.Collections;
using System.Collections.Generic;
using External.Zalgo2462.VoronoiLib;
using External.Zalgo2462.VoronoiLib.Structures;
using UnityEngine;

namespace PajamaLlama.Procedural
{
	public class Voronoi
	{
		public static List<VoronoiSite> Sites { get; private set; }

		public static LinkedList<VEdge> Edges { get; private set; }

		public static void Generate(List<Vector2> sites, Rect bounds, int itterations = 0)
		{
			GetGenerateEnumerator(sites, bounds, itterations).MoveNext();
		}

		public static IEnumerator GetGenerateEnumerator(List<Vector2> sites, Rect bounds, int itterations, bool debug = false)
		{
			itterations = Mathf.Max(itterations, 1);
			if (Sites == null)
			{
				Sites = new List<VoronoiSite>();
			}
			else
			{
				Sites.Clear();
			}
			foreach (Vector2 site in sites)
			{
				Sites.Add(new VoronoiSite(site));
			}
			for (int i = 0; i < itterations; i++)
			{
				RunFortunesAlgorithm(Sites, bounds);
				if (debug)
				{
					yield return null;
				}
				if (0 < i)
				{
					CenterSitePositions(Sites);
				}
			}
		}

		private static void RunFortunesAlgorithm(List<VoronoiSite> voronoiSites, Rect bounds)
		{
			using PooledList<FortuneSite> sites = PooledList<FortuneSite>.Get(voronoiSites);
			Edges = FortunesAlgorithm.Run(sites, bounds.xMin, bounds.yMin, bounds.xMax, bounds.yMax);
			foreach (VEdge edge in Edges)
			{
				(edge.Left as VoronoiSite).AddEdge(edge);
				(edge.Right as VoronoiSite).AddEdge(edge);
			}
			int num = 0;
			foreach (VoronoiSite voronoiSite in voronoiSites)
			{
				voronoiSite.ConstructPolygon(bounds);
				num++;
			}
		}

		private static void CenterSitePositions(List<VoronoiSite> voronoisSites)
		{
			foreach (VoronoiSite voronoisSite in voronoisSites)
			{
				voronoisSite.SetPositionToCellCenterAndReset();
			}
		}
	}
}
