using UnityEngine;

public class KeepRelativeRotationTo : MonoBehaviour
{
	[SerializeField]
	private Transform transformToKeepRelativeRotationTo;

	[SerializeField]
	private Vector3 upVector = Vector3.up;

	private Quaternion initialOffset;

	private Vector3 selfPosition;

	private Vector3 otherPosition;

	private Quaternion localRotationStart;

	private Vector3 upVectorAdjusted;

	private void PrepareData()
	{
		if ((bool)base.transform.parent)
		{
			selfPosition = base.transform.localPosition;
			otherPosition = base.transform.parent.worldToLocalMatrix.MultiplyPoint(transformToKeepRelativeRotationTo.position);
			upVectorAdjusted = upVector;
		}
		else
		{
			selfPosition = base.transform.position;
			otherPosition = transformToKeepRelativeRotationTo.position;
			upVectorAdjusted = upVector;
		}
	}

	private void Start()
	{
		if ((bool)base.transform.parent)
		{
			upVector = base.transform.localToWorldMatrix.MultiplyVector(upVector);
			upVector = base.transform.parent.localToWorldMatrix.MultiplyVector(upVector);
			upVector = upVector.normalized;
		}
		localRotationStart = base.transform.localRotation;
		PrepareData();
		initialOffset = Quaternion.Inverse(Quaternion.LookRotation(otherPosition - selfPosition, upVectorAdjusted));
	}

	private void Update()
	{
		if ((bool)transformToKeepRelativeRotationTo)
		{
			PrepareData();
			Quaternion quaternion = Quaternion.LookRotation(otherPosition - selfPosition, upVectorAdjusted);
			base.transform.localRotation = quaternion * initialOffset * localRotationStart;
		}
	}
}
