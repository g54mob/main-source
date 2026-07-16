using UnityEngine;

public class Bomb : MonoBehaviour
{
	public GameObject explosionPrefab;

	private bool ready;

	private Vector2 targetPosition;

	private void Update()
	{
		if (ready)
		{
			base.transform.position = Vector2.MoveTowards(base.transform.position, targetPosition, 5f * Time.deltaTime);
			base.transform.localScale = Vector2.MoveTowards(base.transform.localScale, new Vector2(0.8f, 0.8f), Time.deltaTime);
			if ((Vector2)base.transform.position == targetPosition)
			{
				Object.Instantiate(explosionPrefab, targetPosition, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.3f, 0f);
				CameraController.Instance.Shake(0.2f, 0.5f, force: true);
				Object.Destroy(base.gameObject);
			}
		}
	}

	public void Ready(Vector2 targetPos)
	{
		targetPosition = targetPos;
		ready = true;
	}
}
