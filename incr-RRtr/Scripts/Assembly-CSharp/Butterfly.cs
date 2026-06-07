using DG.Tweening;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
	[SerializeField]
	private Transform[] waypoints;

	private Animator anim;

	private void Start()
	{
		base.transform.position = waypoints[Random.Range(0, waypoints.Length)].position;
		Invoke("GoToRandomWaypoint", Random.Range(0f, 5f));
		anim = GetComponent<Animator>();
		anim.speed = Random.Range(0.8f, 1.2f);
	}

	private void GoToRandomWaypoint()
	{
		Vector2 vector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		Vector2 vector2 = waypoints[Random.Range(0, waypoints.Length)].position;
		if (vector2.x + vector.x > base.transform.position.x)
		{
			base.transform.localScale = new Vector2(1f, 1f);
		}
		else
		{
			base.transform.localScale = new Vector2(-1f, 1f);
		}
		base.transform.DOMove(vector2 + vector, 0.25f).SetSpeedBased().SetEase(Ease.InOutSine)
			.OnComplete(Repeat);
	}

	private void Repeat()
	{
		anim.speed = Random.Range(0.8f, 1.2f);
		Invoke("GoToRandomWaypoint", Random.Range(1f, 5f));
	}
}
