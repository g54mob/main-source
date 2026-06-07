using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class VampireBat : MonoBehaviour
{
	public enum Direction
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3
	}

	public Direction direction;

	[SerializeField]
	private float speed = 1f;

	[SerializeField]
	private int health = 5;

	[SerializeField]
	private float range = 9f;

	[SerializeField]
	private bool randomness = true;

	[Space]
	[SerializeField]
	private SpriteRenderer batSprite;

	[SerializeField]
	private Animator batAnimator;

	[SerializeField]
	private SpriteRenderer shadowSprite;

	[SerializeField]
	private SpriteRenderer cropSprite;

	[Header("Health bar")]
	[SerializeField]
	private SpriteRenderer healthBarSprite;

	[SerializeField]
	private Sprite[] healthSprites;

	[SerializeField]
	private bool canTakeDamage = true;

	[SerializeField]
	private int damageAmount = 22;

	[SerializeField]
	private VampireSurvivorDamageNumber damageNumber;

	[SerializeField]
	private GameObject deathEffect;

	[SerializeField]
	private AnimationCurve dropRate;

	private List<CropSlot> harvestableCrops;

	private Vector3 startPoint;

	private void Start()
	{
		cropSprite.gameObject.SetActive(value: false);
		healthBarSprite.gameObject.SetActive(value: false);
		if (randomness)
		{
			speed *= Random.Range(0.99f, 1.01f);
		}
		startPoint = base.transform.position;
		StartCoroutine(WaitForNextAction());
		GameManager.ins.vampireBats.Add(this);
	}

	public void SetHealth(int unblockedLands)
	{
		health = 4 + unblockedLands;
	}

	private void TryInitialHarvest()
	{
		CollectCropsThatAreHarvestable();
		CropSlot cropSlot = null;
		if (harvestableCrops.Count > 0)
		{
			cropSlot = harvestableCrops[Random.Range(0, harvestableCrops.Count)];
		}
		if (cropSlot == null)
		{
			StartCoroutine(WaitForNextAction());
		}
		else
		{
			StartCoroutine(GoToHarvest(cropSlot));
		}
	}

	private void CollectCropsThatAreHarvestable()
	{
		harvestableCrops = new List<CropSlot>();
		for (int i = 0; i < GameManager.ins.cropSlots.Count; i++)
		{
			if ((GameManager.ins.cropSlots[i].state == CropSlot.State.NeedHarvest || GameManager.ins.cropSlots[i].state == CropSlot.State.MarkedForHarvest) && Vector2.Distance(GameManager.ins.cropSlots[i].transform.position, base.transform.position) < range)
			{
				harvestableCrops.Add(GameManager.ins.cropSlots[i]);
			}
		}
	}

	private IEnumerator WaitForNextAction()
	{
		if (!this)
		{
			yield break;
		}
		Vector2 vector = RandomPointForward();
		if (SaveData.ins.verticalMode)
		{
			if (vector.x > 7.5f)
			{
				vector = new Vector2(7.5f, vector.y);
			}
			if (vector.x < -7.5f)
			{
				vector = new Vector2(-7.5f, vector.y);
			}
		}
		else
		{
			if (vector.y > 4.5f)
			{
				vector = new Vector2(vector.x, 4.5f);
			}
			if (vector.y < -4f)
			{
				vector = new Vector2(vector.x, -4f);
			}
		}
		float num = 82f;
		float num2 = 48f;
		if ((direction == Direction.Up && vector.y > num2) || (direction == Direction.Down && vector.y < 0f - num2) || (direction == Direction.Left && vector.x < 0f - num) || (direction == Direction.Right && vector.x > num))
		{
			DieAndSpawnLoot(spawnLoot: false);
			yield break;
		}
		SetDirection(vector);
		yield return new WaitForPositionReached(base.transform, vector, speed * 0.65f);
		TryInitialHarvest();
	}

	private Vector2 RandomPointForward()
	{
		float num = Random.Range(-0.25f, 0.25f);
		if (!randomness)
		{
			num = Random.Range(-0.0625f, 0.0625f);
		}
		if (direction == Direction.Up)
		{
			return new Vector2(base.transform.position.x + num, base.transform.position.y + 1f);
		}
		if (direction == Direction.Down)
		{
			return new Vector2(base.transform.position.x + num, base.transform.position.y - 1f);
		}
		if (direction == Direction.Left)
		{
			return new Vector2(base.transform.position.x - 1f, base.transform.position.y + num);
		}
		if (direction == Direction.Right)
		{
			return new Vector2(base.transform.position.x + 1f, base.transform.position.y + num);
		}
		return Vector2.zero;
	}

	private IEnumerator GoToHarvest(CropSlot crop)
	{
		if (!this)
		{
			yield break;
		}
		Vector2 vector = crop.transform.position;
		SetDirection(vector);
		yield return new WaitForPositionReached(base.transform, vector, speed);
		if (health > 0)
		{
			if ((bool)crop && crop.cropType != CropType.None && (crop.state == CropSlot.State.NeedHarvest || crop.state == CropSlot.State.MarkedForHarvest))
			{
				Sprite sprite = GameManager.ins.getCropSprite(crop.cropType);
				crop.RemoveCropNoSound();
				cropSprite.gameObject.SetActive(value: true);
				cropSprite.sprite = sprite;
				StartCoroutine(TakeCropsToStartPoint());
			}
			else
			{
				StartCoroutine(WaitForNextAction());
			}
		}
	}

	private IEnumerator TakeCropsToHouse()
	{
		if ((bool)this)
		{
			Vector2 zero = Vector2.zero;
			healthBarSprite.transform.DOLocalMoveY(healthBarSprite.transform.localPosition.y + 3f, 60f).SetEase(Ease.OutElastic);
			batSprite.transform.DOLocalMoveY(batSprite.transform.localPosition.y + 3f, 60f).SetEase(Ease.OutElastic);
			cropSprite.transform.DOLocalMoveY(cropSprite.transform.localPosition.y + 3f, 60f).SetEase(Ease.OutElastic);
			StartCoroutine(ChangeSortingOrder());
			SetDirection(zero);
			yield return new WaitForPositionReached(base.transform, zero, speed * 1.25f);
			DieAndSpawnLoot(spawnLoot: false);
		}
	}

	private IEnumerator TakeCropsToStartPoint()
	{
		if ((bool)this)
		{
			Vector2 vector = startPoint;
			if (SaveData.ins.verticalMode)
			{
				vector.x = 0f;
			}
			else
			{
				vector.y = 0f;
			}
			healthBarSprite.transform.DOLocalMoveY(healthBarSprite.transform.localPosition.y + 3f, 60f).SetEase(Ease.OutElastic);
			batSprite.transform.DOLocalMoveY(batSprite.transform.localPosition.y + 3f, 60f).SetEase(Ease.OutElastic);
			cropSprite.transform.DOLocalMoveY(cropSprite.transform.localPosition.y + 3f, 60f).SetEase(Ease.OutElastic);
			StartCoroutine(ChangeSortingOrder());
			SetDirection(vector);
			yield return new WaitForPositionReached(base.transform, vector, speed * 1.25f);
			DieAndSpawnLoot(spawnLoot: false);
		}
	}

	private IEnumerator FlyIntoHouse()
	{
		if ((bool)this)
		{
			Vector2 zero = Vector2.zero;
			healthBarSprite.transform.DOLocalMoveY(healthBarSprite.transform.localPosition.y + 3f, 1.5f).SetEase(Ease.InOutSine);
			batSprite.transform.DOLocalMoveY(batSprite.transform.localPosition.y + 3f, 1.5f).SetEase(Ease.InOutSine);
			cropSprite.transform.DOLocalMoveY(cropSprite.transform.localPosition.y + 3f, 1.5f).SetEase(Ease.InOutSine);
			StartCoroutine(ChangeSortingOrder());
			SetDirection(zero);
			yield return new WaitForPositionReached(base.transform, zero, speed * 1.15f);
			DieAndSpawnLoot(spawnLoot: false);
		}
	}

	private IEnumerator ChangeSortingOrder()
	{
		yield return new WaitForSeconds(0.5f);
		healthBarSprite.sortingOrder = 1;
		batSprite.sortingOrder = 1;
		cropSprite.sortingOrder = 1;
	}

	private void SetDirection(Vector2 target)
	{
		if (base.transform.position.x > target.x)
		{
			batSprite.flipX = false;
			shadowSprite.flipX = false;
		}
		else
		{
			batSprite.flipX = true;
			shadowSprite.flipX = true;
		}
	}

	public void TakeDamage()
	{
		if (!cropSprite.gameObject.activeSelf)
		{
			health--;
			if (health > 0)
			{
				SpawnPopUp(Random.Range(damageAmount, damageAmount * 2));
			}
			if (health < 0)
			{
				health = 0;
			}
			PlayHurtAnimation();
			if (health == 0)
			{
				DieAndSpawnLoot(spawnLoot: true);
			}
		}
	}

	private void PlayHurtAnimation()
	{
		batSprite.transform.DOKill();
		float z = -20f;
		if (batSprite.flipX)
		{
			z = 20f;
		}
		batSprite.transform.localRotation = Quaternion.Euler(0f, 0f, z);
		batSprite.transform.DOLocalRotate(Vector3.zero, 0.5f).SetEase(Ease.OutBack);
	}

	private void SpawnPopUp(int amount)
	{
		VampireSurvivorDamageNumber pooledDmg = VampireSurvivorPoolingManager.ins.GetPooledDmg();
		Vector3 up = Vector3.up;
		pooledDmg.transform.position = base.transform.position + up;
		pooledDmg.gameObject.SetActive(value: true);
		pooledDmg.DisplayNumber(amount);
	}

	private IEnumerator CanTakeDamageCooldown()
	{
		canTakeDamage = false;
		yield return new WaitForSeconds(1f);
		canTakeDamage = true;
	}

	private IEnumerator DelayedDeath()
	{
		yield return new WaitForSeconds(0.5f);
		DieAndSpawnLoot(spawnLoot: true);
	}

	private void DieAndSpawnLoot(bool spawnLoot)
	{
		if (spawnLoot)
		{
			VampireSurvivorExperiencePoint vampireSurvivorExperiencePoint = null;
			vampireSurvivorExperiencePoint = VampireSurvivorPoolingManager.ins.GetPooledExp();
			if (vampireSurvivorExperiencePoint != null)
			{
				vampireSurvivorExperiencePoint.SetToType(getExpPointFromAnimationCurve());
				vampireSurvivorExperiencePoint.transform.position = base.transform.position;
				vampireSurvivorExperiencePoint.gameObject.SetActive(value: true);
			}
			if ((bool)batAnimator)
			{
				batAnimator.Play("Death");
			}
			batSprite.transform.parent = null;
			Object.Destroy(batSprite.gameObject, 1f);
		}
		GameManager.ins.vampireBats.Remove(this);
		healthBarSprite.transform.DOKill();
		batSprite.transform.DOKill();
		cropSprite.transform.DOKill();
		Object.Destroy(base.gameObject);
	}

	private VampireSurvivorExperiencePoint.EXPOINT getExpPointFromAnimationCurve()
	{
		float value = Random.value;
		if (value < dropRate.Evaluate(0.1f))
		{
			return VampireSurvivorExperiencePoint.EXPOINT.Combined;
		}
		if (value < dropRate.Evaluate(0.25f))
		{
			return VampireSurvivorExperiencePoint.EXPOINT.Biofuel;
		}
		return VampireSurvivorExperiencePoint.EXPOINT.SpareParts;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, range);
	}
}
