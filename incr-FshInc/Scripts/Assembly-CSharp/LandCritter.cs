using DG.Tweening;
using UnityEngine;

public class LandCritter : MonoBehaviour
{
	public enum WalkPreset
	{
		Duck = 0,
		Crab = 1,
		Turtle = 2,
		Ghost = 3,
		Custom = 4
	}

	[Header("Behaviour")]
	public WalkPreset preset;

	[Header("Bounds (use a separate empty GameObject)")]
	public Transform boundsCenter;

	public Vector2 boundsSize = new Vector2(4f, 2f);

	public bool randomizeStartPosition = true;

	[Header("Spawn")]
	public CritterSpawnChance spawnChance;

	[Header("Animation Mode")]
	public bool useAnimator = true;

	[Header("Animator References (useAnimator = true)")]
	public Animator animator;

	[Header("Custom Overrides (only used when preset = Custom)")]
	public float moveDistance = 2f;

	public float moveSpeed = 1f;

	public bool moveOnYAxis;

	public float minIdleTime = 1f;

	public float maxIdleTime = 3f;

	public float startDelay;

	public float walkRotation = 8f;

	public float walkRotationSpeed = 0.12f;

	public float idleBobAmount = 0.03f;

	public float idleBobSpeed = 1.5f;

	public float idleScalePulse = 0.03f;

	[Header("Sound")]
	public string clickSoundID = "critter_click";

	[Range(0f, 1f)]
	public float clickSoundVolume = 0.5f;

	[Header("References")]
	public SpriteRenderer spriteRenderer;

	private Tween _moveTween;

	private Sequence _walkAnimSequence;

	private Sequence _idleAnimSequence;

	private Sequence _ghostSequence;

	private Tween _pokeSquash;

	private Vector3 _originalScale;

	private bool _isGhost;

	private float _ghostBobSeed;

	private void Start()
	{
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
		if (useAnimator && animator == null)
		{
			animator = GetComponent<Animator>();
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
		if (_isGhost)
		{
			_ghostBobSeed = Random.Range(0f, 100f);
			StartGhostLoop();
			return;
		}
		if (!useAnimator)
		{
			StartIdleAnim();
		}
		Invoke("IdleThenMove", startDelay + Random.Range(0f, minIdleTime * 0.5f));
	}

	private void ApplyPreset()
	{
		switch (preset)
		{
		case WalkPreset.Duck:
			moveDistance = 2f;
			moveSpeed = 1f;
			moveOnYAxis = true;
			minIdleTime = 1.5f;
			maxIdleTime = 4f;
			startDelay = 0f;
			walkRotation = 10f;
			walkRotationSpeed = 0.12f;
			idleBobAmount = 0.03f;
			idleBobSpeed = 1.5f;
			idleScalePulse = 0.03f;
			break;
		case WalkPreset.Crab:
			moveDistance = 1.5f;
			moveSpeed = 1.8f;
			minIdleTime = 1f;
			maxIdleTime = 3f;
			startDelay = 0f;
			walkRotation = 4f;
			walkRotationSpeed = 0.06f;
			idleBobAmount = 0.01f;
			idleBobSpeed = 1f;
			idleScalePulse = 0.02f;
			break;
		case WalkPreset.Turtle:
			moveDistance = 1f;
			moveSpeed = 0.3f;
			moveOnYAxis = true;
			minIdleTime = 3f;
			maxIdleTime = 7f;
			startDelay = 0f;
			walkRotation = 3f;
			walkRotationSpeed = 0.2f;
			idleBobAmount = 0.01f;
			idleBobSpeed = 2f;
			idleScalePulse = 0.015f;
			break;
		case WalkPreset.Ghost:
			moveDistance = 2.5f;
			moveSpeed = 0.4f;
			moveOnYAxis = true;
			minIdleTime = 2f;
			maxIdleTime = 5f;
			startDelay = 0f;
			walkRotation = 0f;
			walkRotationSpeed = 0f;
			idleBobAmount = 0f;
			idleBobSpeed = 0f;
			idleScalePulse = 0f;
			_isGhost = true;
			break;
		case WalkPreset.Custom:
			break;
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

	private void StartGhostLoop()
	{
		if (spriteRenderer != null)
		{
			Color color = spriteRenderer.color;
			color.a = 0f;
			spriteRenderer.color = color;
			spriteRenderer.DOFade(0.5f, 1.5f).SetEase(Ease.InOutSine);
		}
		GhostDrift();
	}

	private void GhostDrift()
	{
		float num = Random.Range(moveDistance * 0.5f, moveDistance);
		Vector3 vector = PickDirection();
		Vector3 vector2 = base.transform.position + vector * num;
		Vector2 vector3 = boundsSize * 0.5f;
		Vector3 position = boundsCenter.position;
		vector2.x = Mathf.Clamp(vector2.x, position.x - vector3.x, position.x + vector3.x);
		vector2.y = Mathf.Clamp(vector2.y, position.y - vector3.y, position.y + vector3.y);
		if (spriteRenderer != null)
		{
			spriteRenderer.flipX = vector2.x < base.transform.position.x;
		}
		float num2 = Mathf.Max(Vector3.Distance(base.transform.position, vector2) / moveSpeed, 0.5f);
		_ghostSequence?.Kill();
		_ghostSequence = DOTween.Sequence();
		_ghostSequence.Append(base.transform.DOMove(vector2, num2).SetEase(Ease.InOutSine));
		if (spriteRenderer != null)
		{
			_ghostSequence.Join(spriteRenderer.DOFade(0.25f, num2 * 0.5f).SetEase(Ease.InOutSine));
			_ghostSequence.Append(spriteRenderer.DOFade(0.5f, num2 * 0.5f).SetEase(Ease.InOutSine));
		}
		_ghostSequence.AppendInterval(Random.Range(minIdleTime, maxIdleTime));
		_ghostSequence.OnComplete(delegate
		{
			GhostDrift();
		});
	}

	private void Update()
	{
		if (_isGhost)
		{
			float num = (Mathf.PerlinNoise(Time.time * 0.8f, _ghostBobSeed) - 0.5f) * 0.3f;
			Vector3 position = base.transform.position;
			position.y += num * Time.deltaTime;
			base.transform.position = position;
		}
	}

	private void IdleThenMove()
	{
		if (useAnimator)
		{
			if (animator != null)
			{
				animator.SetBool("isMoving", value: true);
			}
		}
		else
		{
			StopIdleAnim();
			StartWalkAnim();
		}
		float num = Random.Range(moveDistance * 0.5f, moveDistance);
		Vector3 vector = PickDirection();
		Vector3 vector2 = base.transform.position + vector * num;
		Vector2 vector3 = boundsSize * 0.5f;
		Vector3 position = boundsCenter.position;
		vector2.x = Mathf.Clamp(vector2.x, position.x - vector3.x, position.x + vector3.x);
		vector2.y = Mathf.Clamp(vector2.y, position.y - vector3.y, position.y + vector3.y);
		if (spriteRenderer != null)
		{
			spriteRenderer.flipX = vector2.x < base.transform.position.x;
		}
		float num2 = Vector3.Distance(base.transform.position, vector2) / moveSpeed;
		if (num2 < 0.1f)
		{
			OnMoveComplete();
		}
		else
		{
			_moveTween = base.transform.DOMove(vector2, num2).SetEase(Ease.Linear).OnComplete(OnMoveComplete);
		}
	}

	private void OnMoveComplete()
	{
		if (useAnimator)
		{
			if (animator != null)
			{
				animator.SetBool("isMoving", value: false);
			}
		}
		else
		{
			StopWalkAnim();
			base.transform.DORotate(Vector3.zero, walkRotationSpeed).SetEase(Ease.OutQuad);
			StartIdleAnim();
		}
		Invoke("IdleThenMove", Random.Range(minIdleTime, maxIdleTime));
	}

	private void StartWalkAnim()
	{
		_walkAnimSequence = DOTween.Sequence();
		_walkAnimSequence.Append(base.transform.DORotate(new Vector3(0f, 0f, walkRotation), walkRotationSpeed).SetEase(Ease.InOutSine));
		_walkAnimSequence.Append(base.transform.DORotate(new Vector3(0f, 0f, 0f - walkRotation), walkRotationSpeed).SetEase(Ease.InOutSine));
		_walkAnimSequence.SetLoops(-1, LoopType.Yoyo);
	}

	private void StopWalkAnim()
	{
		_walkAnimSequence?.Kill();
		_walkAnimSequence = null;
	}

	private void StartIdleAnim()
	{
		_idleAnimSequence = DOTween.Sequence();
		_idleAnimSequence.Append(base.transform.DORotate(new Vector3(0f, 0f, idleBobAmount * 100f), idleBobSpeed).SetEase(Ease.InOutSine));
		_idleAnimSequence.Append(base.transform.DORotate(new Vector3(0f, 0f, (0f - idleBobAmount) * 100f), idleBobSpeed).SetEase(Ease.InOutSine));
		_idleAnimSequence.Join(base.transform.DOScale(_originalScale * (1f + idleScalePulse), idleBobSpeed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo));
		_idleAnimSequence.SetLoops(-1, LoopType.Restart);
	}

	private void StopIdleAnim()
	{
		_idleAnimSequence?.Kill();
		_idleAnimSequence = null;
		base.transform.localScale = _originalScale;
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
		_moveTween?.Kill();
		_pokeSquash?.Kill();
		_ghostSequence?.Kill();
		StopWalkAnim();
		StopIdleAnim();
		CancelInvoke();
		base.transform.localScale = _originalScale;
		base.transform.rotation = Quaternion.identity;
	}
}
