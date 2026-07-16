using UnityEngine;

public class TrainFollower : MonoBehaviour
{
	[SerializeField]
	private GameObject Train;

	private void Update()
	{
		base.transform.position = new Vector3(Train.transform.position.x, Train.transform.position.y, -3f);
	}
}
