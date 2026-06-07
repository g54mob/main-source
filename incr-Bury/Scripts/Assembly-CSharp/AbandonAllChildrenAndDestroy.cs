using UnityEngine;

public class AbandonAllChildrenAndDestroy : MonoBehaviour
{
	public Transform[] childrenToAbandon;

	[Header("Rigidbody Exploding")]
	[SerializeField]
	private Rigidbody[] rbsToExplode;

	[SerializeField]
	private float explosionForce;

	[SerializeField]
	private float additionalUpwardsForce;

	[SerializeField]
	private float torqueAmount;

	private void Start()
	{
		Transform[] array = childrenToAbandon;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetParent(null);
		}
		if (rbsToExplode.Length != 0)
		{
			Rigidbody[] array2 = rbsToExplode;
			foreach (Rigidbody rigidbody in array2)
			{
				Vector3 normalized = (rigidbody.transform.position - base.transform.position).normalized;
				rigidbody.AddForce(normalized * explosionForce, ForceMode.VelocityChange);
				if (additionalUpwardsForce != 0f)
				{
					rigidbody.AddForce(Vector3.up * additionalUpwardsForce, ForceMode.VelocityChange);
				}
				if (torqueAmount != 0f)
				{
					float x = ((Random.value < 0.5f) ? (0f - torqueAmount) : torqueAmount);
					float y = ((Random.value < 0.5f) ? (0f - torqueAmount) : torqueAmount);
					float z = ((Random.value < 0.5f) ? (0f - torqueAmount) : torqueAmount);
					rigidbody.AddTorque(new Vector3(x, y, z), ForceMode.VelocityChange);
				}
			}
		}
		Object.Destroy(base.gameObject);
	}
}
