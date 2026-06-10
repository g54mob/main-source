using UnityEngine;

namespace NSMedieval
{
	public class AnimalGridOffset : MonoBehaviour
	{
		[SerializeField]
		private Transform root;

		[SerializeField]
		[Range(0f, 0.3f)]
		private float amount;

		private void Start()
		{
			Vector3 vector = VectorRandomize(amount);
			root.localPosition += vector;
		}

		private Vector3 VectorRandomize(float val)
		{
			return new Vector3(Random.Range(0f - val, val), 0f, Random.Range(0f - val, val));
		}
	}
}
