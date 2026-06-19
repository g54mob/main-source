using System.Collections.Generic;
using UnityEngine;

public class ScalableUIComponent : MonoBehaviour
{
	public bool relativeToMainCam;

	public Transform refTransform;

	public float defaultDist = 25f;

	public List<ScalableUIContainer.AnchorType> anchors = new List<ScalableUIContainer.AnchorType>();

	private ScalableUIContainer container;

	private void Awake()
	{
		container = new ScalableUIContainer();
		container.anchors = anchors;
		container.containSelf = true;
		container.LoadSelfContainer(base.transform);
	}

	private void Update()
	{
		container.CheckResize();
		if (relativeToMainCam)
		{
			container.CheckCamScale(defaultDist, refTransform);
		}
	}

	public Transform GetBGTransform()
	{
		return container.GetBGTransform();
	}

	public float GetDistanceScale()
	{
		return container.GetDistanceScale(defaultDist, refTransform);
	}
}
