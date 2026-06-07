using UnityEngine;

[RequireComponent(typeof(Spin))]
public class SpinRandomizer : MonoBehaviour
{
	[SerializeField]
	private Spin scpt_spin;

	[SerializeField]
	private float randomizeSpeed;

	private Vector3 spinOriginalSpeed;

	private float totalSpeed;

	private Vector3 updatedSpinSpeed;

	private void Reset()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
