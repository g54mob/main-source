using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Logging;
using Assets.Scripts.PlanetStudio;
using ModApi.PlanetStudio;
using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.BugReport
{
	public class BugReportFormData
	{
		public bool AutoReport { get; private set; }

		public string CelestialBody { get; private set; }

		public string DesignerCraft { get; private set; }

		public string InputState { get; private set; }

		public string LogContents { get; set; }

		public string PlanetarySystem { get; private set; }

		public Dictionary<string, byte[]> Screenshots { get; set; }

		public string Settings { get; private set; }

		private BugReportFormData()
		{
		}

		public static BugReportFormData CreateFromBugReport(string logFileContents, string inputState, Dictionary<string, byte[]> screenshots)
		{
			return new BugReportFormData
			{
				LogContents = logFileContents,
				Screenshots = screenshots,
				InputState = inputState,
				AutoReport = true
			};
		}

		public static BugReportFormData CreateFromCurrentScene()
		{
			return CreateCommon();
		}

		private static BugReportFormData CreateCommon()
		{
			BugReportFormData bugReportFormData = new BugReportFormData();
			try
			{
				bugReportFormData.InputState = null;
				bugReportFormData.LogContents = LogHistory.Instance.GenerateReport(rootErrorsOnly: true, clearAfter: false);
				if (Game.InPlanetStudioScene)
				{
					if (PlanetStudioScript.Instance.PlanetStudioUI.EditMode == PlanetStudioEditMode.CelestialBody)
					{
						XDocument xDocument = PlanetStudioScript.Instance.CelestialBodyDesignerScript.SaveXml(useFilePaths: true);
						bugReportFormData.CelestialBody = xDocument.ToString();
					}
				}
				else
				{
					XElement craftDesign = Game.Instance.CraftDesigns.GetCraftDesign(CraftDesigns.EditorCraftId);
					bugReportFormData.DesignerCraft = craftDesign.ToString();
				}
				bugReportFormData.Settings = Game.Instance.Settings.SaveXml().ToString();
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			return bugReportFormData;
		}
	}
}
