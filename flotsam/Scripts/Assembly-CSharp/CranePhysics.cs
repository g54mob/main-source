using UnityEngine;

public class CranePhysics : MonoBehaviour
{
	[Tooltip("Multiplier for the poke force to the crane.")]
	[SerializeField]
	private float _pokeForceMultiplier = 0.1f;

	private Rigidbody _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void OnMouseUp()
	{
		_rigidbody.AddForce(CameraController.Instance.transform.forward * GameManager.Settings.PokeForce * _pokeForceMultiplier, ForceMode.Impulse);
	}
}
