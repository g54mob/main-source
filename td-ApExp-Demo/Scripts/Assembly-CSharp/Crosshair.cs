using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
	private Image fillImage;

	private float timeToRefill;

	private float refillElapsed;

	private void Awake()
	{
		fillImage = base.transform.GetChild(0).GetChild(0).GetComponent<Image>();
	}

	private void Update()
	{
		UpdateRefill();
	}

	public void StartRefill(float timeToRefill)
	{
		if (!(timeToRefill < this.timeToRefill))
		{
			this.timeToRefill = timeToRefill;
			refillElapsed = 0f;
		}
	}

	private void UpdateRefill()
	{
		refillElapsed += Time.deltaTime;
		fillImage.fillAmount = refillElapsed / timeToRefill;
		if (refillElapsed + Time.deltaTime * 2f >= timeToRefill)
		{
			timeToRefill = 0f;
		}
	}
}
