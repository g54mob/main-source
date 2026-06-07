using System.Collections.Generic;
using UnityEngine;

public class TelescopicPositioner : MonoBehaviour
{
	private enum AxisEnum
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	[SerializeField]
	private AxisEnum axis;

	[SerializeField]
	private GameObject baseObject;

	[SerializeField]
	private GameObject movableObject;

	[SerializeField]
	private List<GameObject> braces;

	private void Update()
	{
		float num = Vector3.Distance(baseObject.transform.localPosition, movableObject.transform.localPosition);
		float num2 = 1f / (float)(braces.Count + 1);
		for (int i = 0; i < braces.Count; i++)
		{
			float num3 = num * num2 * (float)(i + 1);
			switch (axis)
			{
			case AxisEnum.X:
				braces[i].transform.SetLocalPositionX(num3);
				break;
			case AxisEnum.Y:
				braces[i].transform.SetLocalPositionY(num3);
				break;
			case AxisEnum.Z:
				braces[i].transform.SetLocalPositionZ(num3);
				break;
			default:
				braces[i].transform.SetLocalPositionX(num3);
				break;
			}
		}
	}
}
