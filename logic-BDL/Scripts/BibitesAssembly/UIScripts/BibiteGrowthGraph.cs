using System.Collections.Generic;
using SimulationScripts.BibiteScripts;
using UIScripts.InfoHandles;
using UIScripts.UIReferences.Graphs;
using UnityEngine;

namespace UIScripts
{
	public class BibiteGrowthGraph
	{
		private SingleLineGraph graph;

		private int nP = 50;

		private Vector2[] values;

		private float xMin;

		private float xMax;

		private float scale;

		private float exponent;

		private float factor;

		private FloatValueFormat yformat = new FloatValueFormat
		{
			units = "u²/s",
			SI = false,
			precision = 2,
			precisionIsSI = true
		};

		private FloatValueFormat xformat = new FloatValueFormat
		{
			SI = false,
			precision = 2
		};

		private List<int> possibleN1 = new List<int> { 2, 3, 4, 5, 6 };

		public void Init(SingleLineGraph graphRef)
		{
			graph = graphRef;
			graph.SetGraduationLinesCount(11, 5);
			graph.InitGraph(xformat, yformat, Color.green, "Growth Curve", "Maturity", "The bibite's growth curve as it matures.\nDefines how fast the bibite will grow and develop over its lifetime.\nKeep in mind, this is the theoretical maximum, as it would mean a constant full activation of their growth node (in the brain)", "The curve start where the bibite is born (at a given maturity) and a bibite is considered mature when maturity reaches 1.0, meaning it will be able to hold an egg in its egg organ and reproduce.");
			SingleLineGraph singleLineGraph = graph;
			Vector2? maxBounds = new Vector2(1E-05f, 1E-06f);
			singleLineGraph.SetMinMax(null, maxBounds);
			values = new Vector2[nP];
		}

		public void UpdateCurve(float[] genes)
		{
			float num = BibiteGenes.GrowthAtBirth(genes);
			float num2 = BibiteGenes.GrowthAtMature(genes);
			float num3 = genes[3];
			scale = genes[4] * num3 * num3 * genes[22] / 100f * 80f;
			factor = genes[23];
			exponent = genes[24];
			int nX = graph.nX;
			xMin = num / num2;
			float num4 = Mathf.Max(scale, 1E-05f) / (1f + factor * Mathf.Pow(xMin, exponent));
			float num5 = Mathf.Pow(Mathf.Max(0f, 10f * scale / num4 - 1f) / factor, 1f / exponent);
			int num6 = possibleN1[0];
			foreach (int item in possibleN1)
			{
				if ((float)item < (float)nX / num5)
				{
					num6 = item;
					continue;
				}
				break;
			}
			float num7 = 1f / (float)num6;
			xMax = num7 * (float)(graph.nX - 1);
			for (int i = 0; i < nP; i++)
			{
				float x = xMin + (xMax - xMin) * (float)i / (float)(nP - 1);
				float y = BibiteGrowth.GrowthFunction(x, scale, factor, exponent);
				values[i] = new Vector2(x, y);
			}
			graph.SetCurve(values);
		}
	}
}
