using TMPro;
using UnityEngine;

public class MensurationScale : MonoBehaviour
{
	public TextMeshProUGUI scaleText;

	public GameObject Powder;

	public float totalGram;

	public float[] ingred = new float[3];

	private void Start()
	{
		ClearScale();
	}

	private void Update()
	{
	}

	public void PowderOnScale(int itemIndex)
	{
		if (totalGram > 100f)
		{
			scaleText.text = "Err";
			return;
		}
		float num = Time.deltaTime * 2f;
		switch (itemIndex)
		{
		case 0:
			ingred[0] += num;
			break;
		case 1:
			ingred[1] += num;
			break;
		case 2:
			ingred[2] += num;
			break;
		}
		totalGram = ingred[0] + ingred[1] + ingred[2];
		scaleText.text = (Mathf.Round(totalGram * 10f) / 10f).ToString("F1");
		if (Powder.transform.localScale.x < 6.2f)
		{
			Powder.transform.localScale += Vector3.one * Time.deltaTime * 0.5f;
		}
	}

	public void ObjectOnScale(int itemIndex, float grams)
	{
		if (totalGram > 100f)
		{
			scaleText.text = "Err";
			return;
		}
		switch (itemIndex)
		{
		case 0:
			ingred[0] += grams;
			break;
		case 1:
			ingred[1] += grams;
			break;
		case 2:
			ingred[2] += grams;
			break;
		}
		totalGram = ingred[0] + ingred[1] + ingred[2];
		scaleText.text = (Mathf.Round(totalGram * 10f) / 10f).ToString("F1");
	}

	public void ClearScale()
	{
		totalGram = 0f;
		for (int i = 0; i < ingred.Length; i++)
		{
			ingred[i] = 0f;
		}
		scaleText.text = (Mathf.Round(totalGram * 10f) / 10f).ToString("F1");
		Powder.transform.localScale = Vector3.zero;
	}
}
