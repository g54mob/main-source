using DG.Tweening;
using UnityEngine;

public class HoppingCritter : MonoBehaviour
{
	public enum HopPreset
	{
		Frog = 0,
		Bunny = 1,
		Penguin = 2,
		Custom = 3
	}

	[Header("Behaviour")]
	public HopPreset preset;

	[Header("Bounds (use a separate empty GameObject)")]
	public Transform boundsCenter;

	public Vector2 boundsSize = new Vector2(4f, 2f);

	public bool randomizeStartPosition = true;

	[Header("Spawn")]
	public CritterSpawnChance spawnChance;

	[Header("Custom Overrides (only used when preset = Custom)")]
	public float hopDistance = 1f;

	public float hopDuration = 0.3f;

	public int hopsPerMove = 2;

	public bool moveOnYAxis;

	public float squashAmount = 0.2f;

	public float stretchAmount = 0.15f;

	public float minIdleTime = 2f;

	public float maxIdleTime = 5f;

	public float pauseBetweenHops = 0.15f;

	public float startDelay;

	[Header("Sound")]
	public string clickSoundID = "critter_click";

	[Range(0f, 1f)]
	public float clickSoundVolume = 0.5f;

	[Header("References")]
	public SpriteRenderer spriteRenderer;

	private Vector3 _originalScale;

	private Sequence _hopSequence;

	private Tween _pokeSquash;

	private void Start()
	{
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
		_originalScale = base.transform.localScale;
		ApplyPreset();
		if (Random.value > CritterSpawnChanceHelper.GetValue(spawnChance))
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		if (boundsCenter == null)
		{
			boundsCenter = base.transform;
		}
		if (randomizeStartPosition)
		{
			base.transform.position = GetRandomPointInBounds();
		}
		Invoke("StartHopping", startDelay + Random.Range(0f, minIdleTime * 0.5f));
	}

	private void ApplyPreset()
	{
		switch (preset)
		{
		case HopPreset.Frog:
			hopDistance = 1f;
			hopDuration = 0.3f;
			hopsPerMove = 2;
			moveOnYAxis = true;
			squashAmount = 0.2f;
			stretchAmount = 0.15f;
			minIdleTime = 2f;
			maxIdleTime = 5f;
			pauseBetweenHops = 0.15f;
			startDelay = 0f;
			break;
		case HopPreset.Bunny:
			hopDistance = 1.1f;
			hopDuration = 0.35f;
			hopsPerMove = 2;
			moveOnYAxis = true;
			squashAmount = 0.15f;
			stretchAmount = 0.2f;
			minIdleTime = 3f;
			maxIdleTime = 6f;
			pauseBetweenHops = 0.2f;
			startDelay = 0f;
			break;
		case HopPreset.Penguin:
			hopDistance = 0.25f;
			hopDuration = 0.55f;
			hopsPerMove = 2;
			moveOnYAxis = true;
			squashAmount = 0.06f;
			stretchAmount = 0.04f;
			minIdleTime = 3f;
			maxIdleTime = 7f;
			pauseBetweenHops = 0.35f;
			startDelay = 0f;
			break;
		case HopPreset.Custom:
			break;
		}
	}

	private void StartHopping()
	{
		Vector3 vector = PickDirection();
		if (spriteRenderer != null)
		{
			spriteRenderer.flipX = vector.x < 0f;
		}
		int num = Random.Range(1, hopsPerMove + 1);
		_hopSequence = DOTween.Sequence();
		for (int i = 0; i < num; i++)
		{
			float num2 = Random.Range(hopDistance * 0.6f, hopDistance);
			_hopSequence.Append(base.transform.DOScale(new Vector3(_originalScale.x * (1f + squashAmount), _originalScale.y * (1f - squashAmount), _originalScale.z), hopDuration * 0.25f).SetEase(Ease.OutQuad));
			float hopDist = num2;
			_hopSequence.AppendCallback(delegate
			{
				Vector3 vector2 = PickDirection();
				if (spriteRenderer != null)
				{
					spriteRenderer.flipX = vector2.x < 0f;
				}
				Vector3 target = base.transform.position + vector2 * hopDist;
				target = ClampToBounds(target);
				base.transform.DOMove(target, hopDuration * 0.5f).SetEase(Ease.OutQuad);
				base.transform.DOScale(new Vector3(_originalScale.x * (1f - stretchAmount), _originalScale.y * (1f + stretchAmount), _originalScale.z), hopDuration * 0.5f).SetEase(Ease.OutQuad);
			});
			_hopSequence.AppendInterval(hopDuration * 0.5f);
			_hopSequence.Append(base.transform.DOScale(new Vector3(_originalScale.x * (1f + squashAmount * 0.5f), _originalScale.y * (1f - squashAmount * 0.5f), _originalScale.z), hopDuration * 0.15f).SetEase(Ease.OutQuad));
			_hopSequence.Append(base.transform.DOScale(_originalScale, hopDuration * 0.2f).SetEase(Ease.InOutQuad));
			if (i < num - 1)
			{
				_hopSequence.AppendInterval(pauseBetweenHops);
			}
		}
		_hopSequence.OnComplete(delegate
		{
			base.transform.localScale = _originalScale;
			Invoke("StartHopping", Random.Range(minIdleTime, maxIdleTime));
		});
	}

	private void OnMouseDown()
	{
		if (_pokeSquash == null || !_pokeSquash.IsActive())
		{
			if (SteamAchievementManager.Instance != null)
			{
				SteamAchievementManager.Instance.NotifyCritterPoked();
			}
			if (!string.IsNullOrEmpty(clickSoundID))
			{
				SoundManager.PlaySound(clickSoundID, clickSoundVolume);
			}
			_pokeSquash = DOTween.Sequence().Append(base.transform.DOScale(new Vector3(_originalScale.x * 1.3f, _originalScale.y * 0.7f, _originalScale.z), 0.1f).SetEase(Ease.OutQuad)).Append(base.transform.DOScale(new Vector3(_originalScale.x * 0.85f, _originalScale.y * 1.15f, _originalScale.z), 0.1f).SetEase(Ease.OutQuad))
				.Append(base.transform.DOScale(_originalScale, 0.15f).SetEase(Ease.OutBounce));
		}
	}

	private Vector3 PickDirection()
	{
		Vector3 position = boundsCenter.position;
		Vector2 vector = boundsSize * 0.5f;
		Vector3 position2 = base.transform.position;
		float num = ((vector.x > 0.01f) ? (Mathf.Abs(position2.x - position.x) / vector.x) : 0f);
		float b = ((vector.y > 0.01f) ? (Mathf.Abs(position2.y - position.y) / vector.y) : 0f);
		if (moveOnYAxis)
		{
			float num2 = Mathf.Max(num, b);
			if (num2 > 0.6f)
			{
				Vector3 normalized = (position - position2).normalized;
				return Vector3.Lerp(Random.insideUnitCircle.normalized, normalized, num2).normalized;
			}
			return Random.insideUnitCircle.normalized;
		}
		if (num > 0.6f)
		{
			if (!(position2.x > position.x))
			{
				return Vector3.right;
			}
			return Vector3.left;
		}
		if (!(Random.value > 0.5f))
		{
			return Vector3.left;
		}
		return Vector3.right;
	}

	private Vector3 ClampToBounds(Vector3 target)
	{
		Vector2 vector = boundsSize * 0.5f;
		Vector3 position = boundsCenter.position;
		target.x = Mathf.Clamp(target.x, position.x - vector.x, position.x + vector.x);
		target.y = Mathf.Clamp(target.y, position.y - vector.y, position.y + vector.y);
		return target;
	}

	private Vector3 GetRandomPointInBounds()
	{
		Vector2 vector = boundsSize * 0.5f;
		Vector3 position = boundsCenter.position;
		return new Vector3(Random.Range(position.x - vector.x, position.x + vector.x), Random.Range(position.y - vector.y, position.y + vector.y), base.transform.position.z);
	}

	private void OnDrawGizmosSelected()
	{
		Vector3 center = ((boundsCenter != null) ? boundsCenter.position : base.transform.position);
		Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
		Gizmos.DrawCube(center, new Vector3(boundsSize.x, boundsSize.y, 0.1f));
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(center, new Vector3(boundsSize.x, boundsSize.y, 0.1f));
	}

	private void OnDisable()
	{
		_hopSequence?.Kill();
		_pokeSquash?.Kill();
		CancelInvoke();
		base.transform.localScale = _originalScale;
	}
}
