using System;
using System.Collections;
using UnityEngine;

public class Bombardment : MonoBehaviour
{
	public GameObject bombPrefab;

	public GameObject explosionPrefab;

	public float timeBetweenSurroundingExplosions = 0.3f;

	private float timer;

	[NonSerialized]
	public bool ready;

	[SerializeField]
	private float percentDamageTakenFromLineBombing;

	private void Start()
	{
		timer = timeBetweenSurroundingExplosions;
	}

	private void Update()
	{
		if (ready)
		{
			timer -= Time.deltaTime;
			if (timer < 0f)
			{
				Vector2 zero = Vector2.zero;
				UnityEngine.Object.Instantiate(position: (UnityEngine.Random.Range(0, 2) != 0) ? new Vector2(UnityEngine.Random.Range(-2.25f, 2.25f), UnityEngine.Random.Range(0.5f, 1.5f)) : new Vector2(UnityEngine.Random.Range(-2.25f, 2.25f), UnityEngine.Random.Range(-1.5f, -0.5f)), original: explosionPrefab, rotation: Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.3f, 0f);
				timer = timeBetweenSurroundingExplosions;
			}
		}
	}

	public IEnumerator LineBombing(int lineToBomb)
	{
		float lineYpos = 0f;
		switch (lineToBomb)
		{
		case 1:
			lineYpos = -0.35f;
			break;
		case 2:
			lineYpos = 0f;
			break;
		case 3:
			lineYpos = 0.35f;
			break;
		}
		UnityEngine.Object.Instantiate(bombPrefab, new Vector2(3f, lineYpos), Quaternion.identity).GetComponent<Bomb>().Ready(new Vector2(-2f, lineYpos));
		yield return new WaitForSeconds(0.15f);
		UnityEngine.Object.Instantiate(bombPrefab, new Vector2(3f, lineYpos), Quaternion.identity).GetComponent<Bomb>().Ready(new Vector2(-1.75f, lineYpos));
		yield return new WaitForSeconds(0.15f);
		UnityEngine.Object.Instantiate(bombPrefab, new Vector2(3f, lineYpos), Quaternion.identity).GetComponent<Bomb>().Ready(new Vector2(-1.5f, lineYpos));
		yield return new WaitForSeconds(0.15f);
		Bomb newBomb4 = UnityEngine.Object.Instantiate(bombPrefab, new Vector2(3f, lineYpos), Quaternion.identity).GetComponent<Bomb>();
		newBomb4.Ready(new Vector2(-1.25f, lineYpos));
		yield return new WaitForSeconds(0.15f);
		if (!GameManager.Instance.ringMinigame.lastRingOutcome)
		{
			Train.Instance.GetHitByBombardment((0f - percentDamageTakenFromLineBombing) / 2f, newBomb4.gameObject);
		}
		UnityEngine.Object.Instantiate(bombPrefab, new Vector2(3f, lineYpos), Quaternion.identity).GetComponent<Bomb>().Ready(new Vector2(-1f, lineYpos));
		yield return new WaitForSeconds(0.15f);
		UnityEngine.Object.Instantiate(bombPrefab, new Vector2(3f, lineYpos), Quaternion.identity).GetComponent<Bomb>().Ready(new Vector2(-0.75f, lineYpos));
		yield return new WaitForSeconds(0.15f);
		UnityEngine.Object.Instantiate(bombPrefab, new Vector2(3f, lineYpos), Quaternion.identity).GetComponent<Bomb>().Ready(new Vector2(-0.5f, lineYpos));
		yield return new WaitForSeconds(0.15f);
	}
}
