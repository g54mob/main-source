using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInteresectingGeometryJobcast : MonoBehaviour
{
	public CharacterController characterController;

	public FirstPersonController fpsController;

	private Vector3 _origin;

	private Vector3 _direction;

	public LayerMask mask;

	private void Update()
	{
	}
}
