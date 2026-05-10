using UnityEngine;

public class PlacementDirectionArrow : MonoBehaviour
{
	[SerializeField]
	private Color inputColor = Color.white;

	[SerializeField]
	private Color outputColor = Color.white;

	[SerializeField]
	private float arrowHeight = 0.35f;

	[SerializeField]
	private float arrowDistance = 1f;

	public void SetupArrow(ConveyorBelt cb, bool isInputOrientation)
	{
		_ = cb.PlacementComponent.MainObject.Model;
		EOrientation eOrientation = (isInputOrientation ? cb.InputOrientation : cb.OutputOrientation);
		if (eOrientation != EOrientation.None)
		{
			Vector3 directionFromOrientation = LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(eOrientation, cb.transform.eulerAngles.y));
			Vector3 vector = cb.transform.position + directionFromOrientation * arrowDistance;
			float y = Quaternion.LookRotation(isInputOrientation ? (cb.transform.position - vector) : (vector - cb.transform.position), Vector3.up).eulerAngles.y;
			base.transform.position = vector + Vector3.up * arrowHeight;
			base.transform.rotation = Quaternion.Euler(0f, y, 0f);
			GetComponentInChildren<Renderer>().material.SetColor("_Color", isInputOrientation ? inputColor : outputColor);
		}
	}
}
