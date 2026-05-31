using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThidPersonExampleController : MonoBehaviour
{
	public float MovementSpeed;

	private Transform _mainCameraTransform;

	private Transform _transform;

	private CharacterController _characterController;

	private void OnEnable()
	{
	}

	public void Update()
	{
	}
}
