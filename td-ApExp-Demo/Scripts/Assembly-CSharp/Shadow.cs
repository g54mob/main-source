using UnityEngine;

public class Shadow : MonoBehaviour
{
	private GameObject[] shadowGos;

	private SpriteRenderer[] shadowSrs;

	[SerializeField]
	private SpriteRenderer[] srs;

	public float height = 0.02f;

	private void Awake()
	{
		if (srs == null || srs.Length == 0)
		{
			srs = new SpriteRenderer[1] { GetComponent<SpriteRenderer>() };
		}
		InstantiateShadows();
	}

	private void Update()
	{
		UpdateShadows();
	}

	private void UpdateShadows()
	{
		float lightAngle = GameManager.Instance.lightAngle;
		Vector3 vector = Quaternion.Euler(0f, 0f, lightAngle) * Vector3.right * height;
		for (int i = 0; i < shadowSrs.Length; i++)
		{
			if (!(shadowGos[i] == null))
			{
				shadowGos[i].transform.position = shadowGos[i].transform.parent.position + vector;
				shadowGos[i].transform.rotation = shadowGos[i].transform.rotation;
				if (shadowSrs[i].sprite != srs[i].sprite)
				{
					shadowSrs[i].sprite = srs[i].sprite;
				}
			}
		}
	}

	private void InstantiateShadows()
	{
		shadowGos = new GameObject[srs.Length];
		shadowSrs = new SpriteRenderer[srs.Length];
		for (int i = 0; i < shadowGos.Length; i++)
		{
			SpriteRenderer spriteRenderer = srs[i];
			shadowGos[i] = new GameObject("Shadow");
			GameObject gameObject = shadowGos[i];
			gameObject.transform.SetParent(srs[i].transform, worldPositionStays: false);
			SpriteRenderer spriteRenderer2 = (shadowSrs[i] = shadowGos[i].AddComponent<SpriteRenderer>());
			if (base.gameObject.GetComponent<EnemyBase>() != null && !base.gameObject.GetComponent<EnemyBase>().IsGrounded)
			{
				spriteRenderer2.color = GameManager.Instance.shadowColorFlying;
				gameObject.transform.localScale *= 0.75f;
			}
			else
			{
				spriteRenderer2.color = GameManager.Instance.shadowColor;
			}
			spriteRenderer2.sprite = spriteRenderer.sprite;
			spriteRenderer2.sortingLayerID = spriteRenderer.sortingLayerID;
			spriteRenderer2.sortingOrder = -1;
			spriteRenderer2.maskInteraction = spriteRenderer.maskInteraction;
		}
	}

	public void SetShadowOpacity(float a)
	{
		SpriteRenderer[] array = shadowSrs;
		foreach (SpriteRenderer spriteRenderer in array)
		{
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, a);
		}
	}
}
