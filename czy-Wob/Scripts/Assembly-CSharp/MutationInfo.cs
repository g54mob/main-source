using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MutationInfo : MonoBehaviour
{
	public GameObject ageUpdatesHolder;

	public GameObject partUpdatesHolder;

	public GameObject valuesUpdateHolder;

	public GameObject materialUpdateHolder;

	public RectTransform progressBar;

	public GameObject positiveArrow;

	public GameObject negativeArrow;

	public TextMeshProUGUI centeredText;

	public TextMeshProUGUI mutationString;

	public TextMeshProUGUI percentageText;

	public AgeUpdateBar ageBar;

	public Image floraIcon;

	public RawImage mutatedMaterialImage;

	public RawImage originalMaterialImage;

	public RenderTexture legColorMutatedRenderTex;

	public RenderTexture legColorOriginalRenderTex;

	public RenderTexture bodyColorMutatedRenderTex;

	public RenderTexture bodyColorOriginalRenderTex;

	public RenderTexture noseEarColorMutatedRenderTex;

	public RenderTexture noseEarColorOriginalRenderTex;

	private float lowEndXPos = -370f;

	private float highEndXPos;

	private void Awake()
	{
		centeredText.gameObject.SetActive(value: false);
	}

	public void SetMutationString(string newString)
	{
		mutationString.text = newString;
	}

	public void SetTextOnly(string newText)
	{
		ageUpdatesHolder.SetActive(value: false);
		partUpdatesHolder.SetActive(value: false);
		valuesUpdateHolder.SetActive(value: false);
		materialUpdateHolder.SetActive(value: false);
		mutationString.gameObject.SetActive(value: false);
		centeredText.gameObject.SetActive(value: true);
		centeredText.text = newText;
	}

	public void SetUpdatedValues(float originalValue, float newValue, float minValue, float maxValue)
	{
		ageUpdatesHolder.SetActive(value: false);
		partUpdatesHolder.SetActive(value: false);
		materialUpdateHolder.SetActive(value: false);
		float num = maxValue - minValue;
		float num2 = (float)Math.Round((newValue - originalValue) / num * 100f, 1);
		if (newValue > originalValue)
		{
			positiveArrow.SetActive(value: true);
			negativeArrow.SetActive(value: false);
			percentageText.text = num2 + "%";
			percentageText.color = positiveArrow.GetComponent<Image>().color;
		}
		else
		{
			negativeArrow.SetActive(value: true);
			positiveArrow.SetActive(value: false);
			percentageText.text = num2 + "%";
			percentageText.color = negativeArrow.GetComponent<Image>().color;
		}
		float percentageOfRange = MathUtil.GetPercentageOfRange(newValue, minValue, maxValue);
		float x = (highEndXPos - lowEndXPos) * percentageOfRange + lowEndXPos;
		progressBar.anchoredPosition3D = new Vector3(x, progressBar.anchoredPosition3D.y, progressBar.anchoredPosition3D.z);
	}

	public void SetUpdatedMaterials(bool body = false, bool legs = false, bool noseEars = false)
	{
		ageUpdatesHolder.SetActive(value: false);
		partUpdatesHolder.SetActive(value: false);
		valuesUpdateHolder.SetActive(value: false);
		if (body)
		{
			mutatedMaterialImage.texture = bodyColorMutatedRenderTex;
			originalMaterialImage.texture = bodyColorOriginalRenderTex;
		}
		else if (legs)
		{
			mutatedMaterialImage.texture = legColorMutatedRenderTex;
			originalMaterialImage.texture = legColorOriginalRenderTex;
		}
		else if (noseEars)
		{
			mutatedMaterialImage.texture = noseEarColorMutatedRenderTex;
			originalMaterialImage.texture = noseEarColorOriginalRenderTex;
		}
	}

	public void SetUpdatedParts()
	{
		ageUpdatesHolder.SetActive(value: false);
		valuesUpdateHolder.SetActive(value: false);
		materialUpdateHolder.SetActive(value: false);
	}

	public void SetUpdatedAge(DogAge oldAge, DogAge newAge)
	{
		ageUpdatesHolder.SetActive(value: true);
		partUpdatesHolder.SetActive(value: false);
		valuesUpdateHolder.SetActive(value: false);
		materialUpdateHolder.SetActive(value: false);
		mutationString.gameObject.SetActive(value: false);
		ageBar.SetAges(oldAge, newAge);
	}

	public void AnimateAge()
	{
		ageBar.AnimateBar();
	}
}
