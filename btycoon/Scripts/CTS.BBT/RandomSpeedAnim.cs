using UnityEngine;

public class RandomSpeedAnim : MonoBehaviour
{
	public Vector2 range;

	public float rand;

	public Animator anim;

	private void Start()
	{
		rand = Random.Range(range.x, range.y);
		if (base.gameObject.TryGetComponent<Animator>(out var component))
		{
			component.speed = rand;
		}
	}

	private void Update()
	{
	}
}
