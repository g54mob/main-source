using UnityEngine;

public class GnomeDuplicator : MonoBehaviour
{
	[SerializeField]
	private float duplicateTimer_Curr;

	private Vector2 timerMinMax = new Vector2(5f, 15f);

	public bool duplicateActive;

	private void Start()
	{
		GameManager.Singleton.gnomeEnding_SpawnedGnomes.Add(this);
		GetNewDuplicateTime();
	}

	private void OnDestroy()
	{
		GameManager.Singleton.gnomeEnding_SpawnedGnomes.Remove(this);
	}

	private void FixedUpdate()
	{
		HandleDuplication();
	}

	private void HandleDuplication()
	{
		if (duplicateActive && GameManager.Singleton.gnomeEnding_SpawnedGnomes.Count < 500)
		{
			if (duplicateTimer_Curr > 0f)
			{
				duplicateTimer_Curr -= Time.fixedDeltaTime;
				return;
			}
			DuplicateGnome();
			GetNewDuplicateTime();
		}
	}

	private void DuplicateGnome()
	{
		Object.Instantiate(GameManager.Singleton.gnomeEnding_GnomePrefabs[Random.Range(0, GameManager.Singleton.gnomeEnding_GnomePrefabs.Count)], base.transform.position, base.transform.rotation).GetComponent<GnomeDuplicator>().duplicateActive = true;
		AudioManager.Singleton.PlayGnomeMemeSFX(base.transform.position);
	}

	public void GetNewDuplicateTime()
	{
		duplicateTimer_Curr = Random.Range(timerMinMax.x, timerMinMax.y);
	}
}
