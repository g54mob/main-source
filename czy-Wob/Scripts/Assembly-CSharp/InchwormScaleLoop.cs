using System.Collections.Generic;
using UnityEngine;

public class InchwormScaleLoop : MonoBehaviour
{
	public List<Vector3> scaleValues = new List<Vector3>();

	public List<float> scaleTimes = new List<float>();

	private int index;

	private Segment currentSegment;

	private Vector3 startScale;

	private Inchworm inchworm;

	private void Start()
	{
		inchworm = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		startScale = base.transform.localScale;
		ContinueLoop();
	}

	public void ForceCancel()
	{
		if (currentSegment != null)
		{
			inchworm.CancelAndFinishEase(ref currentSegment);
			currentSegment = null;
			base.gameObject.transform.localScale = startScale;
		}
	}

	public void ContinueLoop()
	{
		if (currentSegment == null)
		{
			Vector3 targetScale = new Vector3(scaleValues[index].x * startScale.x, scaleValues[index].y * startScale.y, scaleValues[index].z * startScale.z);
			currentSegment = inchworm.RequestEaseToScale(base.gameObject, targetScale, scaleTimes[index], Inchworm.EaseStyle.QuadraticOut, ScaleCallback);
		}
	}

	private void ScaleCallback()
	{
		currentSegment = null;
		index++;
		if (index >= scaleValues.Count)
		{
			index = 0;
		}
		ContinueLoop();
	}
}
