using System.Collections.Generic;

public class EvidenceSurveillance : Evidence
{
	public int captureID;

	public SceneRecorder.SceneCapture savedCapture;

	public EvidenceSurveillance(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override string GenerateName()
	{
		return null;
	}

	public override void OnDiscovery()
	{
	}
}
