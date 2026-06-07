using UnityEngine;

public class OrthoBillBoard : MonoBehaviour
{
	public Transform FacedObject;

	[SerializeField]
	private bool isCashier;

	private static Camera _camera;

	private Transform ActiveFacedObject => null;

	private void LateUpdate()
	{
	}
}
