using UnityEngine;

namespace Pathfinding
{
	public readonly struct Progress
	{
		public readonly float progress;

		internal readonly ScanningStage stage;

		internal readonly int graphIndex;

		internal readonly int graphCount;

		public Progress(float progress, ScanningStage stage, int graphIndex = 0, int graphCount = 0)
		{
			this.progress = progress;
			this.stage = stage;
			this.graphIndex = graphIndex;
			this.graphCount = graphCount;
		}

		public Progress MapTo(float min, float max)
		{
			return new Progress(Mathf.Lerp(min, max, progress), stage, graphIndex, graphCount);
		}

		public override string ToString()
		{
			string text = progress.ToString("0%") + " ";
			switch (stage)
			{
			case ScanningStage.PreProcessingGraphs:
				text += "Pre-processing graphs";
				break;
			case ScanningStage.PreProcessingGraph:
				text = text + "Pre-processing graph " + (graphIndex + 1) + " of " + graphCount;
				break;
			case ScanningStage.ScanningGraph:
				text = text + "Scanning graph " + (graphIndex + 1) + " of " + graphCount;
				break;
			case ScanningStage.PostProcessingGraph:
				text = text + "Post-processing graph " + (graphIndex + 1) + " of " + graphCount;
				break;
			case ScanningStage.FinishingScans:
				text += "Finalizing graph scans";
				break;
			}
			return text;
		}
	}
}
