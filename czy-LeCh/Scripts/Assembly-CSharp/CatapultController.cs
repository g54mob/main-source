using System.Collections;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
	[SerializeField]
	private GameObject ammoCatapultPrefab;

	[SerializeField]
	private float timeTillAmmoDestroyed;

	[SerializeField]
	private float timeTillCatapultLaunch;

	[SerializeField]
	private Animator catapultAnimator;

	[SerializeField]
	private Transform catapultAmmoSpawnpoint;

	private void Start()
	{
		StartCoroutine(LaunchCatapult());
	}

	private IEnumerator LaunchCatapult()
	{
		yield return new WaitForSeconds(Random.Range(timeTillCatapultLaunch / 2f, timeTillCatapultLaunch));
		if (base.transform.root.gameObject.name != "PreviewObjectParent")
		{
			catapultAnimator.Play("anim_catapult shoot");
		}
		StartCoroutine(LaunchCatapult());
	}

	public void SpawnAmmoBall()
	{
		Object.Instantiate(ammoCatapultPrefab, catapultAmmoSpawnpoint.position, Quaternion.identity).GetComponent<CatapultAmmoController>().LaunchAmmo(catapultAmmoSpawnpoint, 10f);
	}
}
