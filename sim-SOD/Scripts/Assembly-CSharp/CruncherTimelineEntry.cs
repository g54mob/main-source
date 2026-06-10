using System;
using UnityEngine.UI;

public class CruncherTimelineEntry : ComputerOSUIComponent
{
	public SurveillanceApp app;

	public Image img;

	public JuiceController juice;

	[NonSerialized]
	public SceneRecorder.SceneCapture sceneReference;

	public bool mousedOver;

	public bool flagged;

	public void Setup(SurveillanceApp newApp, SceneRecorder.SceneCapture newCap)
	{
	}

	public void SetMouseOver(bool val)
	{
	}

	public void SetFlagged(bool val)
	{
	}

	public void VisualUpdate()
	{
	}

	public override void OnLeftClick()
	{
	}
}
