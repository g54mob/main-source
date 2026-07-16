using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AudioSystem;
using UnityEngine;

public class PreYardCannon : MonoBehaviour
{
	public GameObject Cannonball;

	public GameObject Explosion;

	public Transform CannonMuzzle;

	public SoundData CannonBallSfx;

	public bool isTopSide;

	public float CannonballSpeed;

	public SpriteRenderer BobbyCannoneerSr;

	public List<Sprite> Cannoneers;

	private Transform target;

	private Transform cannonballTf;

	private Vector3 shootPos = Vector3.zero;

	private bool ready;

	private void OnEnable()
	{
		if (Cannonball == null || EnemyManager.Instance.Enemies.Count == 0 || BobbyCannoneerSr == null)
		{
			return;
		}
		BobbyCannoneerSr.sprite = Cannoneers[Random.Range(0, Cannoneers.Count)];
		int sign = 0;
		if (isTopSide)
		{
			sign = 1;
		}
		else
		{
			sign = -1;
		}
		List<EnemyBase> list = EnemyManager.Instance.Enemies.Where((EnemyBase e) => e.IsEnemy && e.GetComponent<APCMissile>() == null && e.posSign == (float)sign).ToList();
		if (list.Count != 0)
		{
			target = list[Random.Range(0, list.Count)].transform;
			if (!(target == null))
			{
				shootPos = target.transform.position;
				StartCoroutine(Shoot());
			}
		}
	}

	private void OnDisable()
	{
		ready = false;
	}

	private IEnumerator Shoot()
	{
		yield return new WaitForSeconds(Random.Range(0f, 1f));
		GameObject gameObject = Object.Instantiate(Cannonball, CannonMuzzle);
		cannonballTf = gameObject.transform;
		PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder().Play(CannonBallSfx);
		ready = true;
	}

	private void Explode()
	{
		Object.Instantiate(Explosion, cannonballTf.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.6f, 3f);
		CameraController.Instance.Shake(0.25f, 0.5f, force: true);
		Object.Destroy(cannonballTf.gameObject);
	}

	private void FixedUpdate()
	{
		if (!(shootPos == Vector3.zero) && ready && !(cannonballTf == null))
		{
			float maxDistanceDelta = Time.deltaTime * CannonballSpeed;
			cannonballTf.position = Vector3.MoveTowards(cannonballTf.position, shootPos, maxDistanceDelta);
			if (Vector2.Distance(cannonballTf.position, shootPos) <= 0.5f)
			{
				Explode();
			}
		}
	}
}
