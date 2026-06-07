using UnityEngine;

public class Func_RandomRotationOnEnable : MonoBehaviour
{
	[SerializeField]
	private bool x_Axis;

	[SerializeField]
	private bool y_Axis;

	[SerializeField]
	private bool z_Axis;

	[SerializeField]
	private bool limitTo90Degree;

	private void OnEnable()
	{
	}
}
