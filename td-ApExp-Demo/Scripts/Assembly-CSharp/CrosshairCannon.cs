using UnityEngine;
using UnityEngine.UI;

public class CrosshairCannon : MonoBehaviour
{
	private float timeToRefill;

	private float refillElapsed;

	[SerializeField]
	private Sprite reloadingSprite;

	[SerializeField]
	private Sprite firingSprite;

	[SerializeField]
	private Sprite reloadingMask;

	[SerializeField]
	private Sprite firingMask;

	[SerializeField]
	private Sprite outOfAmmoSprite;

	[SerializeField]
	private Color reloadingColor;

	[SerializeField]
	private Color firingColor;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Image mask;

	[SerializeField]
	private Image fillImage;

	private bool outOfAmmo;

	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		UpdateRefill();
	}

	public void SetEmptyFill()
	{
		fillImage.fillAmount = 0f;
	}

	public void StartRefill(float timeToRefill, bool isFullReload)
	{
		if (!(timeToRefill < this.timeToRefill))
		{
			outOfAmmo = false;
			fillImage.enabled = true;
			this.timeToRefill = timeToRefill;
			refillElapsed = 0f;
			if (isFullReload)
			{
				image.sprite = reloadingSprite;
				mask.sprite = reloadingMask;
				fillImage.color = reloadingColor;
				fillImage.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
				UIManager.Instance.MouseCursor.CannonReloadStart();
			}
		}
	}

	private void UpdateRefill()
	{
		refillElapsed += Time.deltaTime;
		fillImage.fillAmount = refillElapsed / timeToRefill;
		if (refillElapsed >= timeToRefill)
		{
			timeToRefill = 0f;
			if (!outOfAmmo)
			{
				image.sprite = firingSprite;
				mask.sprite = firingMask;
				fillImage.color = firingColor;
				fillImage.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				UIManager.Instance.MouseCursor.CannonReloadEnd();
			}
		}
	}

	public void StopRefil()
	{
		image.sprite = firingSprite;
		mask.sprite = firingMask;
		fillImage.color = firingColor;
		fillImage.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		fillImage.fillAmount = 1f;
		refillElapsed = timeToRefill + 1f;
		UIManager.Instance.MouseCursor.CannonReloadEnd();
	}

	public void OutOfAmmo()
	{
		outOfAmmo = true;
		image.sprite = outOfAmmoSprite;
		fillImage.enabled = false;
	}

	public void OnShoot()
	{
		animator.Play("CannonCrosshairAnim", -1, 0f);
	}
}
