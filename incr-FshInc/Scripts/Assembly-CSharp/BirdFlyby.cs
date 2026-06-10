using UnityEngine;

public class BirdFlyby : MonoBehaviour
{
	[Tooltip("Base speed at which the bird flies across the screen.")]
	public float flySpeed = 8f;

	[Tooltip("Flight pattern. Straight = linear, Sine = wave, Dive = swoop down then up.")]
	public FlyPattern pattern;

	[Header("Sine Pattern Settings")]
	public float sineAmplitude = 1.5f;

	public float sineFrequency = 2f;

	[Header("Dive Pattern Settings")]
	public float diveDepth = 3f;

	public float diveDuration = 1.5f;

	[Header("Achievement")]
	[Tooltip("If true, spotting this bird triggers the 'Did you see that?' achievement.")]
	public bool isKingfisher;

	[Header("Shadow")]
	[Tooltip("If assigned, this sprite is used as the bird's ground shadow. Add as a child object on the prefab.")]
	public SpriteRenderer shadowSprite;

	[Tooltip("How far below the bird the shadow sits (world units).")]
	public float shadowGroundOffset = 3f;

	[Tooltip("Shadow opacity.")]
	[Range(0f, 1f)]
	public float shadowAlpha = 0.3f;

	private Camera mainCam;

	private FlyDirection direction;

	private Vector3 moveDir;

	private Vector3 perpDir;

	private Vector3 startPos;

	private float flyTime;

	private bool achievementUnlocked;

	private float erraticTargetOffset;

	private Transform shadowTransform;

	private float shadowBaseY;

	private Vector3 shadowBaseScale;

	private SpriteRenderer birdRenderer;

	public void SetDirection(FlyDirection dir)
	{
		direction = dir;
	}

	private void Start()
	{
		mainCam = Camera.main;
		startPos = base.transform.position;
		flyTime = 0f;
		switch (direction)
		{
		case FlyDirection.Leftward:
			moveDir = Vector3.left;
			perpDir = Vector3.up;
			break;
		case FlyDirection.Rightward:
			moveDir = Vector3.right;
			perpDir = Vector3.up;
			FlipX();
			break;
		case FlyDirection.Downward:
			moveDir = Vector3.down;
			perpDir = Vector3.right;
			break;
		case FlyDirection.Upward:
			moveDir = Vector3.up;
			perpDir = Vector3.right;
			FlipY();
			break;
		}
		if (pattern == FlyPattern.Straight && Random.value < 0.35f)
		{
			pattern = FlyPattern.Sine;
		}
		if (pattern == FlyPattern.Erratic)
		{
			erraticTargetOffset = Random.Range(0f, 100f);
		}
		SetupShadow();
		Object.Destroy(base.gameObject, 20f);
	}

	private void SetupShadow()
	{
		if (!(shadowSprite == null))
		{
			birdRenderer = GetComponent<SpriteRenderer>();
			shadowTransform = shadowSprite.transform;
			shadowBaseScale = shadowTransform.lossyScale;
			shadowTransform.SetParent(null);
			shadowTransform.localScale = shadowBaseScale;
			shadowBaseY = startPos.y - shadowGroundOffset;
			shadowTransform.position = new Vector3(startPos.x, shadowBaseY, 0f);
			Color black = Color.black;
			black.a = shadowAlpha;
			shadowSprite.color = black;
			if (birdRenderer != null)
			{
				shadowSprite.sortingLayerID = birdRenderer.sortingLayerID;
				shadowSprite.sortingOrder = birdRenderer.sortingOrder - 1;
			}
			Object.Destroy(shadowTransform.gameObject, 20f);
		}
	}

	private void Update()
	{
		flyTime += Time.deltaTime;
		Vector3 vector = startPos + moveDir * (flySpeed * flyTime);
		switch (pattern)
		{
		case FlyPattern.Sine:
			vector += perpDir * (Mathf.Sin(flyTime * sineFrequency) * sineAmplitude);
			break;
		case FlyPattern.Dive:
		{
			float num3 = flyTime / diveDuration;
			float num4 = (0f - diveDepth) * (4f * num3 * (1f - num3));
			if (direction == FlyDirection.Leftward || direction == FlyDirection.Rightward)
			{
				vector.y += num4;
			}
			else
			{
				vector.x += num4;
			}
			break;
		}
		case FlyPattern.Erratic:
		{
			float num = Mathf.Sin(flyTime * 3.5f) * 0.6f;
			float num2 = (Mathf.PerlinNoise(flyTime * 2.5f, erraticTargetOffset) - 0.5f) * 1.2f;
			vector += perpDir * (num + num2);
			break;
		}
		}
		base.transform.position = vector;
		UpdateShadow(vector);
		if (isKingfisher && flyTime > 1f && !achievementUnlocked)
		{
			Debug.Log("[BirdFlyby] Kingfisher spotted! Triggering achievement.");
			if (SteamAchievementManager.Instance != null)
			{
				SteamAchievementManager.Instance.NotifyBirdSpotted();
			}
			achievementUnlocked = true;
		}
		if (!(mainCam != null))
		{
			return;
		}
		Vector3 vector2 = mainCam.WorldToViewportPoint(base.transform.position);
		if (vector2.x < -0.4f || vector2.x > 1.4f || vector2.y < -0.4f || vector2.y > 1.4f)
		{
			if (shadowTransform != null)
			{
				Object.Destroy(shadowTransform.gameObject);
			}
			Object.Destroy(base.gameObject);
		}
	}

	private void UpdateShadow(Vector3 birdPos)
	{
		if (!(shadowTransform == null))
		{
			shadowTransform.position = new Vector3(birdPos.x, shadowBaseY, 0f);
			float t = Mathf.Clamp01((birdPos.y - shadowBaseY) / (shadowGroundOffset * 2f));
			float num = Mathf.Lerp(1f, 0.4f, t);
			shadowTransform.localScale = shadowBaseScale * num;
			float a = Mathf.Lerp(shadowAlpha, shadowAlpha * 0.3f, t);
			Color color = shadowSprite.color;
			color.a = a;
			shadowSprite.color = color;
		}
	}

	private void FlipX()
	{
		Vector3 localScale = base.transform.localScale;
		localScale.x = 0f - Mathf.Abs(localScale.x);
		base.transform.localScale = localScale;
	}

	private void FlipY()
	{
		Vector3 localScale = base.transform.localScale;
		localScale.y = 0f - Mathf.Abs(localScale.y);
		base.transform.localScale = localScale;
	}
}
