using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneInfo : MonoBehaviour
{
	public GeneticInspectionGUIManager geneticInspectionRef;

	public GameObject partUpdatesHolder;

	public GameObject valuesUpdateHolder;

	public GameObject materialUpdateHolder;

	public GameObject mainButton;

	public RectTransform progressBar;

	public TextMeshProUGUI centeredText;

	public TextMeshProUGUI centeredNumber;

	public TextMeshProUGUI mutationString;

	public TextMeshProUGUI percentageText;

	public RawImage materialImage;

	public CoreButtonUnityGUI infoButton;

	public RenderTexture legColorRenderTex;

	public RenderTexture bodyColorRenderTex;

	public RenderTexture noseEarColorRenderTex;

	public Color defaultBarColor;

	public Color supersizedBarColor;

	public Image progressBarGraphic;

	private Coroutine updateRoutine;

	private float targetPercentage;

	private float currentPercentage;

	private float startPercentage;

	private float timeTaken;

	private float timeNeeded = 0.25f;

	private List<GeneticDomRecProperty> linkedProperties = new List<GeneticDomRecProperty>();

	private string mysteryString = "???";

	private float lowEndXPos = -502f;

	private float highEndXPos;

	private void Awake()
	{
		centeredText.gameObject.SetActive(value: false);
		centeredNumber.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		if (updateRoutine != null)
		{
			StopCoroutine(updateRoutine);
			updateRoutine = null;
		}
	}

	public void SetMutationString(string newString)
	{
		mutationString.text = newString;
	}

	public void SetLinkedProperties(List<GeneticDomRecProperty> props)
	{
		linkedProperties.Clear();
		linkedProperties.AddRange(props);
		if (linkedProperties.Count > 0)
		{
			infoButton.gameObject.SetActive(value: true);
		}
	}

	public void SetMutationStringAndCenteredText(string mutationTextValue, string centeredTextValue)
	{
		mainButton.SetActive(value: true);
		partUpdatesHolder.SetActive(value: false);
		valuesUpdateHolder.SetActive(value: false);
		materialUpdateHolder.SetActive(value: false);
		centeredText.gameObject.SetActive(value: true);
		mutationString.gameObject.SetActive(value: true);
		centeredText.text = centeredTextValue;
		mutationString.text = mutationTextValue;
		infoButton.gameObject.SetActive(value: false);
	}

	public void SetMutationStringAndCenteredNumber(string mutationTextValue, string centeredNumberValue)
	{
		mainButton.SetActive(value: true);
		partUpdatesHolder.SetActive(value: false);
		valuesUpdateHolder.SetActive(value: false);
		materialUpdateHolder.SetActive(value: false);
		centeredNumber.gameObject.SetActive(value: true);
		mutationString.gameObject.SetActive(value: true);
		centeredNumber.text = centeredNumberValue;
		mutationString.text = mutationTextValue;
		infoButton.gameObject.SetActive(value: false);
	}

	public void UpdateCenteredNumberValue(string centeredNumberValue)
	{
		centeredNumber.text = centeredNumberValue;
	}

	public void SetValues(float geneValue, float minValue, float maxValue, bool mysteryValue = false)
	{
		mainButton.SetActive(value: false);
		partUpdatesHolder.SetActive(value: false);
		materialUpdateHolder.SetActive(value: false);
		float percentageOfRange = MathUtil.GetPercentageOfRange(geneValue, minValue, maxValue);
		SetPercentage(percentageOfRange, mysteryValue);
	}

	private void SetPercentage(float percentage, bool mysteryValue = false)
	{
		if (mysteryValue)
		{
			percentage = 0f;
		}
		currentPercentage = percentage;
		float x = (highEndXPos - lowEndXPos) * Mathf.Min(currentPercentage, 1f) + lowEndXPos;
		percentageText.text = MathUtil.Round(percentage * 100f, 2) + "%";
		progressBar.anchoredPosition3D = new Vector3(x, progressBar.anchoredPosition3D.y, progressBar.anchoredPosition3D.z);
		if (mysteryValue)
		{
			percentageText.text = mysteryString;
			progressBarGraphic.color = defaultBarColor;
		}
		else if (currentPercentage > 1f)
		{
			progressBarGraphic.color = supersizedBarColor;
		}
		else
		{
			progressBarGraphic.color = defaultBarColor;
		}
	}

	public void UpdateValues(float geneValue, float minValue, float maxValue)
	{
		if (updateRoutine != null)
		{
			StopCoroutine(updateRoutine);
			updateRoutine = null;
		}
		float percentageOfRange = MathUtil.GetPercentageOfRange(geneValue, minValue, maxValue);
		if (currentPercentage != percentageOfRange)
		{
			timeTaken = 0f;
			targetPercentage = percentageOfRange;
			startPercentage = currentPercentage;
			updateRoutine = StartCoroutine(ValueUpdateRoutine());
		}
	}

	private IEnumerator ValueUpdateRoutine()
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		float range = targetPercentage - startPercentage;
		if (startPercentage > targetPercentage)
		{
			range = startPercentage - targetPercentage;
		}
		while (timeTaken < timeNeeded)
		{
			timeTaken += Time.unscaledDeltaTime * 2f;
			if (timeTaken > timeNeeded)
			{
				timeTaken = timeNeeded;
			}
			if (targetPercentage > currentPercentage)
			{
				currentPercentage = startPercentage + MathUtil.GetValueOfRangePercentage(timeTaken / timeNeeded, 0f, range);
			}
			else
			{
				currentPercentage = startPercentage - MathUtil.GetValueOfRangePercentage(timeTaken / timeNeeded, 0f, range);
			}
			SetPercentage(currentPercentage);
			yield return frameWait;
			yield return frameWait;
		}
		SetPercentage(targetPercentage);
		updateRoutine = null;
	}

	public void SetMaterials(bool body = false, bool legs = false, bool noseEars = false)
	{
		mainButton.SetActive(value: false);
		partUpdatesHolder.SetActive(value: false);
		valuesUpdateHolder.SetActive(value: false);
		if (body)
		{
			materialImage.texture = bodyColorRenderTex;
		}
		else if (legs)
		{
			materialImage.texture = legColorRenderTex;
		}
		else if (noseEars)
		{
			materialImage.texture = noseEarColorRenderTex;
		}
	}

	public void SetParts()
	{
		mainButton.SetActive(value: false);
		valuesUpdateHolder.SetActive(value: false);
		materialUpdateHolder.SetActive(value: false);
	}

	public void OnButtonOver()
	{
		if (mainButton.activeSelf && geneticInspectionRef != null)
		{
			geneticInspectionRef.OnDomRecGeneticsMouseOn(linkedProperties);
		}
	}

	public void OnButtonOff()
	{
		if (geneticInspectionRef != null)
		{
			geneticInspectionRef.OnDomRecGeneticsMouseOff(linkedProperties);
		}
	}
}
