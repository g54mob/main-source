using System.Collections.Generic;

public class PreferenceData
{
	public bool generalRecovery = true;

	public bool displayHints = true;

	public int visualsWorkspace;

	public int visualsAntiAlias;

	public bool visualsAmbientOcclusion = true;

	public bool visualsShadows = true;

	public bool visualsVSync = true;

	public float visualsScale = 1f;

	public float gizmoScale = 1f;

	public float gridOpacity = 0.5f;

	public bool gridSelection = true;

	public List<string> favorites = new List<string>();
}
