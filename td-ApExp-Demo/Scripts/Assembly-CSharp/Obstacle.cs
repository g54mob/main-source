using UnityEngine;

public class Obstacle : MonoBehaviour
{
	[Header("Obstacle")]
	[SerializeField]
	protected bool groundObstacle = true;

	[SerializeField]
	protected float damage;

	[SerializeField]
	private LayerMask targetLayerMask = 64;

	[Header("Art")]
	[SerializeField]
	protected bool limitCountByArt;

	[SerializeField]
	protected Sprite[] obstaclesArt;

	[SerializeField]
	protected Sprite[] baseArt;

	[SerializeField]
	protected SpriteRenderer obstacleSr;

	[SerializeField]
	protected SpriteRenderer baseSr;

	protected int currentSpriteIndex = -1;

	protected virtual void Start()
	{
		if ((bool)baseSr && baseArt != null && obstaclesArt != null && obstaclesArt.Length != baseArt.Length)
		{
			Debug.LogError("[Obstacle] " + base.name + ": Obstacle Art and Base Art arrays do not have the same number of elements when Base Art list is not empty. Check setup in inspector.");
		}
		currentSpriteIndex = Random.Range(0, obstaclesArt.Length);
		if (obstaclesArt != null && obstaclesArt.Length != 0)
		{
			SetSprite(currentSpriteIndex);
		}
	}

	public virtual void SetSprite(int i)
	{
		if (i >= 0 && i < obstaclesArt.Length)
		{
			obstacleSr.sprite = obstaclesArt[i];
		}
		if (baseSr != null && i >= 0 && i < baseArt.Length)
		{
			baseSr.sprite = baseArt[i];
		}
	}

	protected virtual void OnDisable()
	{
	}
}
