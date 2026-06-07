using System.Collections.Generic;
using DV.Utils;
using UnityEngine;
using VerletRope;

public class CouplingHoseDebugGUI : SingletonBehaviour<CouplingHoseDebugGUI>
{
	private Rect windowRect = new Rect(20f, -20f, 300f, 0f);

	private VerletSolver solver;

	public new static string AllowAutoCreate()
	{
		return "[CouplingHoseDebugGUI]";
	}

	private void OnGUI()
	{
		GUI.skin = DVGUI.skin;
		windowRect = GUILayout.Window(0, windowRect, Window, "");
	}

	private void Window(int id)
	{
		if (!solver)
		{
			solver = Object.FindObjectOfType<VerletSolver>();
		}
		if (!solver)
		{
			GUILayout.Label("No solver found");
			GUILayout.Label("(doing FindObjectOfType every frame!)");
			return;
		}
		List<Rope> registeredRopes = solver.GetRegisteredRopes();
		int num = 0;
		foreach (Rope item in registeredRopes)
		{
			if (item.behaviour.meshGenerator.GetComponent<Renderer>().enabled)
			{
				num++;
			}
		}
		GUILayout.Label($"Ropes in solver: {registeredRopes.Count}");
		GUILayout.Label($"Enabled renderers: {num}");
		GUILayout.Label($"Flush jobs: {solver.flushJobs}  (H to toggle)");
		GUILayout.Label("Schedule " + (solver.ScheduleAtEndOfFrame ? "at end of frame" : "in Update") + "  (J to toggle)");
		GUILayout.Label($"Solver enabled: {solver.enabled}  (K to toggle)");
	}

	private void Update()
	{
		if ((bool)solver && Input.GetKeyDown(KeyCode.K))
		{
			solver.enabled = !solver.enabled;
		}
	}
}
