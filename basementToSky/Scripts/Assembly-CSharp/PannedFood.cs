using RainbowArt.CleanFlatUI;
using UnityEngine;

public class PannedFood : MonoBehaviour
{
	private Renderer rend;

	public Color plainColor;

	public Color overCookedColor;

	public float cookingGageFront;

	public float cookingGageBack;

	public float totalCookingGage;

	public float maxGage = 20f;

	private bool isInthePan;

	public ProgressBarSpecialPattern cookingGage;

	private void Start()
	{
		rend = GetComponentInChildren<Renderer>();
		cookingGageFront = 0.1f;
		cookingGageBack = 0.1f;
		totalCookingGage = 0f;
		maxGage = 100f;
	}

	private void Update()
	{
		if (!isInthePan)
		{
			return;
		}
		if (Vector3.Dot(base.transform.up, Vector3.up) >= 0f)
		{
			if (cookingGageBack < maxGage / 2f)
			{
				cookingGageBack += Time.deltaTime * 10f;
				if (totalCookingGage < maxGage)
				{
					totalCookingGage += Time.deltaTime * 10f;
				}
			}
			else if (totalCookingGage >= 0f)
			{
				totalCookingGage -= Time.deltaTime * 5f;
			}
			else
			{
				totalCookingGage = 0f;
			}
		}
		else if (cookingGageFront < maxGage / 2f)
		{
			cookingGageFront += Time.deltaTime * 10f;
			if (totalCookingGage < maxGage)
			{
				totalCookingGage += Time.deltaTime * 10f;
			}
		}
		else if (totalCookingGage > 0f)
		{
			totalCookingGage -= Time.deltaTime * 5f;
		}
		else
		{
			totalCookingGage = 0f;
		}
		cookingGage.CurrentValue = totalCookingGage;
		Color color = Color.Lerp(plainColor, overCookedColor, totalCookingGage / maxGage);
		rend.material.color = color;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Pan"))
		{
			isInthePan = true;
			AudioManager.S.PlayCookingSFX(AudioManager.S.cookingPan, 1f);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Pan"))
		{
			isInthePan = false;
			AudioManager.S.PlayCookingSFX(AudioManager.S.cookingPan, 0.2f);
		}
	}
}
