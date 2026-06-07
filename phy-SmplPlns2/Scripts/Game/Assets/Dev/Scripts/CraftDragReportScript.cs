using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design;
using UnityEngine;

namespace Assets.Dev.Scripts
{
	public class CraftDragReportScript : MonoBehaviour
	{
		private const char Delim = '\t';

		[ContextMenu("Run Report")]
		protected void RunReport()
		{
			StartCoroutine(RunReportCoroutine());
		}

		protected IEnumerator RunReportCoroutine()
		{
			yield return new WaitForEndOfFrame();
			List<CraftFileInfo> crafts = Assets.Scripts.Game.Instance.CraftDatabase.GetCrafts();
			StringBuilder output = new StringBuilder();
			output.AppendLine($"Craft{'\t'}Direction{'\t'}DragLegacy{'\t'}DragNew");
			PartDrag.DragDirection[] directions = new PartDrag.DragDirection[3]
			{
				PartDrag.DragDirection.Forward,
				PartDrag.DragDirection.Downward,
				PartDrag.DragDirection.Rightward
			};
			float[] dragComparisonDirection = new float[directions.Length];
			for (int i = 0; i < directions.Length; i++)
			{
				dragComparisonDirection[i] = 0f;
			}
			int numCrafts = 0;
			foreach (CraftFileInfo craft in crafts)
			{
				if (craft.IsHidden || craft.Id.Contains("(Simple)"))
				{
					Debug.Log("Skipping " + craft.Id);
					continue;
				}
				yield return new WaitForEndOfFrame();
				yield return new WaitForEndOfFrame();
				for (int j = 0; j < directions.Length; j++)
				{
					PartDrag.DragDirection direction = directions[j];
					XElement aircraftElement = craft.LoadXml(showErrorDialogs: false);
					Designer.Instance.LoadXml(aircraftElement);
					yield return new WaitForEndOfFrame();
					yield return new WaitForEndOfFrame();
					float dragLegacy = CalculateDrag(Designer.Instance.Aircraft, legacyModel: true, direction);
					yield return new WaitForEndOfFrame();
					yield return new WaitForEndOfFrame();
					float num = CalculateDrag(Designer.Instance.Aircraft, legacyModel: false, direction);
					dragComparisonDirection[j] += num / dragLegacy;
					output.AppendLine($"{craft.Id}{'\t'}{direction}{'\t'}{dragLegacy}{'\t'}{num}");
				}
				numCrafts++;
				Debug.Log("Processed " + craft.Id);
			}
			File.WriteAllText("C:\\temp\\drag-comparison.csv", output.ToString());
			string text = "Total Drag Comparison\n";
			for (int k = 0; k < directions.Length; k++)
			{
				text += $"Direction: {directions[k]} New Drag vs Old Drag: {dragComparisonDirection[k] / (float)numCrafts:n3}\n";
			}
			Debug.Log(text);
		}

		private static float CalculateDrag(AircraftScript craft, bool legacyModel, PartDrag.DragDirection direction)
		{
			float dragCount = 0f;
			if (legacyModel)
			{
				dragCount = new DragCalculator(craft.Parts).CalculateDragCount(direction);
			}
			else
			{
				Designer.Instance.DesignerScript.DragCalculator.CalculateDragInDesigner(craft, direction, out dragCount);
			}
			return dragCount;
		}
	}
}
