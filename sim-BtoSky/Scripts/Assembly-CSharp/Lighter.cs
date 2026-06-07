using UnityEngine;

public class Lighter : MonoBehaviour
{
	public bool isHandled;

	public bool isPouring;

	private Vector3 genPos;

	private float targetZ = -35f;

	[SerializeField]
	private Transform flamePos;

	private void Start()
	{
		isHandled = false;
		isPouring = false;
		genPos = base.transform.position;
	}

	private void Update()
	{
		if (!isHandled && Vector3.Magnitude(base.transform.position - genPos) > 0.01f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, genPos, Time.deltaTime * 5f);
		}
		if (isHandled)
		{
			float z = Mathf.LerpAngle(base.transform.eulerAngles.z, targetZ, Time.deltaTime * 4f);
			base.transform.rotation = Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, z);
			int mask = LayerMask.GetMask("Interactable");
			Collider[] array = Physics.OverlapSphere(flamePos.position, 0.2f, mask);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].TryGetComponent<CurrentCraftingRocketGrain>(out var component))
				{
					component.Ignite();
				}
			}
		}
		else
		{
			float z2 = base.transform.eulerAngles.z;
			if (z2 > 0.01f)
			{
				float z3 = Mathf.LerpAngle(z2, 0f, Time.deltaTime * 5f);
				base.transform.rotation = Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, z3);
			}
		}
	}
}
