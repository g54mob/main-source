using UnityEngine;

public class RotateAround_PickUppable : MonoBehaviour
{
	private PickUppable ourPickuppable;

	[SerializeField]
	private Transform rotateAround;

	[SerializeField]
	private Vector3 rotationDir;

	[SerializeField]
	private float rotationSpeed;

	private void Awake()
	{
		ourPickuppable = GetComponent<PickUppable>();
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (ourPickuppable.GetHasBeenActivated())
		{
			base.enabled = false;
		}
		base.transform.RotateAround(rotateAround.position, rotationDir, Time.deltaTime * rotationSpeed);
	}
}
