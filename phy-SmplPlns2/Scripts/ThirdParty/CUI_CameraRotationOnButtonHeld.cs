using UnityEngine;

public class CUI_CameraRotationOnButtonHeld : MonoBehaviour
{
	[SerializeField]
	private float Sensitivity = 0.5f;

	private Vector3 oldMousePos;

	private bool move = true;

	private void Start()
	{
		oldMousePos = Input.mousePosition;
	}
}
