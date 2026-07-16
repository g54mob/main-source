using System;
using UnityEngine;

public class TrackObstacle : Obstacle
{
	private bool isTrainHit;

	private SpriteRenderer wagonSr;

	private ExplodeSprite explodeSprite;

	[SerializeField]
	private GameObject explosionPrefab;

	[NonSerialized]
	public bool isNextTurnFake;

	protected new void Start()
	{
		isTrainHit = false;
		obstacleSr = GetComponent<SpriteRenderer>();
		wagonSr = Train.Instance.Wagons[0].gameObject.GetComponent<SpriteRenderer>();
		explodeSprite = base.gameObject.GetComponent<ExplodeSprite>();
		obstacleSr.enabled = true;
	}

	private void FixedUpdate()
	{
		if (ObstacleLeftMostXpos() < WagonRightMostXpos() && Mathf.Abs(ObstacleLeftMostXpos() - WagonRightMostXpos()) <= 0.5f && !isTrainHit && Train.Instance.Wagons[0].pathFollower.IsTurning() == isNextTurnFake)
		{
			if (explodeSprite.IsSet())
			{
				UnityEngine.Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.5f, 0f);
				obstacleSr.enabled = false;
				explodeSprite.Explode();
			}
			Train.Instance.GetHitByObstacle((int)damage, base.gameObject);
			isTrainHit = true;
		}
	}

	protected override void OnDisable()
	{
		obstacleSr.enabled = true;
		isTrainHit = false;
	}

	private float ObstacleLeftMostXpos()
	{
		return base.gameObject.transform.position.x - obstacleSr.bounds.size.x / 4f;
	}

	private float WagonRightMostXpos()
	{
		return Train.Instance.Wagons[0].gameObject.transform.position.x + wagonSr.bounds.size.x / 2f;
	}

	public void Setup(int zoneIndex)
	{
		SetSprite(zoneIndex);
		explodeSprite.SetSprite(wagonSr.sprite);
	}
}
