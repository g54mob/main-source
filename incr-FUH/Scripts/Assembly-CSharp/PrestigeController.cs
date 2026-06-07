using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PrestigeController : MonoBehaviour
{
	public GameObject SparkTemplate;

	public ParticleSystem Explosion;

	public ParticleSystem Explosion2;

	public List<GameObject> StartingPoints;

	public GameObject TopMenu;

	private List<GameObject> _sparks = new List<GameObject>();

	private bool _executed;

	private int _amountToThrow;

	private Vector3 _amountLocation;

	public void Awake()
	{
		SparkTemplate.SetActive(value: false);
	}

	public void Update()
	{
	}

	public void StartAnimation(List<Vector3> moreOrigin, float destinationX, int amountToThrow)
	{
		GameController.Instance.FreezeSave = true;
		_executed = false;
		_amountToThrow = amountToThrow;
		_amountLocation = new Vector3(destinationX, 7f, 0f);
		CameraController.Instance.PrestigeShake();
		Explosion.Play();
		Vector3 endLocation = new Vector3(destinationX, 7f, 0f);
		foreach (GameObject startingPoint in StartingPoints)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(SparkTemplate, SparkTemplate.transform.parent);
			gameObject.transform.position = startingPoint.transform.position;
			_sparks.Add(gameObject);
		}
		if (moreOrigin != null)
		{
			foreach (Vector3 item in moreOrigin)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(SparkTemplate, SparkTemplate.transform.parent);
				gameObject2.transform.position = item;
				_sparks.Add(gameObject2);
			}
		}
		foreach (GameObject spark in _sparks)
		{
			spark.SetActive(value: true);
			spark.transform.DOMove(endLocation, 3f).SetEase(Ease.InBounce).OnComplete(delegate
			{
				RunExplosion2(endLocation);
			});
		}
	}

	private void RunExplosion2(Vector3 endLocation)
	{
		if (_executed)
		{
			return;
		}
		_executed = true;
		Explosion2.transform.position = endLocation;
		Explosion2.Play();
		GlobalSfx2Controller.Instance.PlayFromDistance(SoundManager.SoundTypeEnum.ga_shard_appear, endLocation.x);
		GameController.Instance.GarbageController.Generate(endLocation, 2, GarbageInfo.GarbageTypeEnum.ShardBlue, GarbageInfo.CameFromEnum.None, isEvil: false);
		foreach (GameObject spark in _sparks)
		{
			spark.SetActive(value: false);
			UnityEngine.Object.Destroy(spark, 1f);
		}
		_sparks.Clear();
		StartCoroutine(SpawnObjects());
		GameController.Instance.FreezeSave = false;
	}

	private IEnumerator SpawnObjects()
	{
		int valueOfGarbage = 5;
		int garbageToGenerate = _amountToThrow / valueOfGarbage;
		if (garbageToGenerate > 50)
		{
			garbageToGenerate = 50;
			valueOfGarbage = _amountToThrow / garbageToGenerate;
		}
		for (int t = 0; t < garbageToGenerate; t += 5)
		{
			for (int i = t; i < Math.Min(t + 5, garbageToGenerate); i++)
			{
				Garbage garbage = GameController.Instance.GarbageController.Generate(_amountLocation, valueOfGarbage, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.None, isEvil: false);
				garbage.Info.ForceZap();
				garbage.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
			}
			yield return new WaitForSeconds(0.1f);
		}
	}
}
