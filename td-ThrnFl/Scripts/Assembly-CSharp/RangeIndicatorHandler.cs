using System.Collections.Generic;
using UnityEngine;

public class RangeIndicatorHandler : MonoBehaviour
{
	public class IndicatorHandle
	{
		public GameObject targetObject;

		public Transform targetTransform;

		public Material targetMaterial;

		public float targetFade;

		public IndicatorHandle(GameObject target)
		{
			targetObject = target;
			targetTransform = target.transform;
			targetMaterial = target.GetComponent<MeshRenderer>().material;
			targetMaterial.SetFloat("_Intersection_Depth", 0f);
		}
	}

	public enum IndicatorType
	{
		Built = 0,
		Preview = 1,
		Special = 2
	}

	public const float FADE_SPEED = 1.75f;

	public const float TARGET_DEPTH = 0.75f;

	public static RangeIndicatorHandler instance;

	public GameObject builtIndicatorPrefab;

	public GameObject previewIndicatorPrefab;

	public GameObject specialIndicatorPrefab;

	private Dictionary<GameObject, IndicatorHandle> builtIndicators = new Dictionary<GameObject, IndicatorHandle>();

	private Dictionary<GameObject, IndicatorHandle> previewIndicators = new Dictionary<GameObject, IndicatorHandle>();

	private Dictionary<GameObject, IndicatorHandle> specialIndicators = new Dictionary<GameObject, IndicatorHandle>();

	private List<GameObject> removeFromBuilt = new List<GameObject>();

	private List<GameObject> removeFromPreview = new List<GameObject>();

	private List<GameObject> removeFromSpecial = new List<GameObject>();

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(this);
		}
		else
		{
			instance = this;
		}
	}

	private void Update()
	{
		if (builtIndicators.Count == 0 && previewIndicators.Count == 0 && specialIndicators.Count == 0)
		{
			return;
		}
		removeFromBuilt.Clear();
		removeFromPreview.Clear();
		removeFromSpecial.Clear();
		foreach (KeyValuePair<GameObject, IndicatorHandle> builtIndicator in builtIndicators)
		{
			float num = builtIndicator.Value.targetMaterial.GetFloat("_Intersection_Depth");
			if (num == 0f && builtIndicator.Value.targetFade == 0f)
			{
				Object.Destroy(builtIndicator.Value.targetObject);
				removeFromBuilt.Add(builtIndicator.Key);
			}
			else
			{
				num = Mathf.MoveTowards(num, builtIndicator.Value.targetFade, 1.75f * Time.deltaTime);
				builtIndicator.Value.targetMaterial.SetFloat("_Intersection_Depth", num);
			}
		}
		foreach (KeyValuePair<GameObject, IndicatorHandle> previewIndicator in previewIndicators)
		{
			float num2 = previewIndicator.Value.targetMaterial.GetFloat("_Intersection_Depth");
			if (num2 == 0f && previewIndicator.Value.targetFade == 0f)
			{
				Object.Destroy(previewIndicator.Value.targetObject);
				removeFromPreview.Add(previewIndicator.Key);
			}
			else
			{
				num2 = Mathf.MoveTowards(num2, previewIndicator.Value.targetFade, 1.75f * Time.deltaTime);
				previewIndicator.Value.targetMaterial.SetFloat("_Intersection_Depth", num2);
			}
		}
		foreach (KeyValuePair<GameObject, IndicatorHandle> specialIndicator in specialIndicators)
		{
			float num3 = specialIndicator.Value.targetMaterial.GetFloat("_Intersection_Depth");
			if (num3 == 0f && specialIndicator.Value.targetFade == 0f)
			{
				Object.Destroy(specialIndicator.Value.targetObject);
				removeFromSpecial.Add(specialIndicator.Key);
			}
			else
			{
				num3 = Mathf.MoveTowards(num3, specialIndicator.Value.targetFade, 1.75f * Time.deltaTime);
				specialIndicator.Value.targetMaterial.SetFloat("_Intersection_Depth", num3);
			}
		}
		foreach (GameObject item in removeFromBuilt)
		{
			builtIndicators.Remove(item);
		}
		foreach (GameObject item2 in removeFromPreview)
		{
			previewIndicators.Remove(item2);
		}
		foreach (GameObject item3 in removeFromSpecial)
		{
			specialIndicators.Remove(item3);
		}
	}

	public void ShowIndicator(Vector3 position, float range, GameObject sender, IndicatorType indicatorType)
	{
		Dictionary<GameObject, IndicatorHandle> dictionary = null;
		GameObject original = null;
		switch (indicatorType)
		{
		case IndicatorType.Built:
			dictionary = builtIndicators;
			original = builtIndicatorPrefab;
			break;
		case IndicatorType.Preview:
			dictionary = previewIndicators;
			original = previewIndicatorPrefab;
			break;
		case IndicatorType.Special:
			dictionary = specialIndicators;
			original = specialIndicatorPrefab;
			break;
		}
		if (dictionary.ContainsKey(sender))
		{
			IndicatorHandle indicatorHandle = dictionary[sender];
			indicatorHandle.targetObject.SetActive(value: true);
			indicatorHandle.targetTransform.localScale = Vector3.one * range * 2f;
			indicatorHandle.targetTransform.position = position;
			indicatorHandle.targetFade = 0.75f;
		}
		else
		{
			IndicatorHandle indicatorHandle2 = new IndicatorHandle(Object.Instantiate(original, position, Quaternion.identity));
			indicatorHandle2.targetTransform.localScale = Vector3.one * range * 2f;
			indicatorHandle2.targetFade = 0.75f;
			dictionary.Add(sender, indicatorHandle2);
		}
	}

	public void HideIndicator(GameObject sender, IndicatorType indicatorType)
	{
		switch (indicatorType)
		{
		case IndicatorType.Built:
			if (builtIndicators.ContainsKey(sender))
			{
				builtIndicators[sender].targetFade = 0f;
			}
			break;
		case IndicatorType.Preview:
			if (previewIndicators.ContainsKey(sender))
			{
				previewIndicators[sender].targetFade = 0f;
			}
			break;
		case IndicatorType.Special:
			if (specialIndicators.ContainsKey(sender))
			{
				specialIndicators[sender].targetFade = 0f;
			}
			break;
		}
	}

	private void OnDisable()
	{
		foreach (KeyValuePair<GameObject, IndicatorHandle> builtIndicator in builtIndicators)
		{
			Object.Destroy(builtIndicator.Value.targetObject);
			removeFromBuilt.Add(builtIndicator.Key);
		}
		foreach (KeyValuePair<GameObject, IndicatorHandle> previewIndicator in previewIndicators)
		{
			Object.Destroy(previewIndicator.Value.targetObject);
			removeFromPreview.Add(previewIndicator.Key);
		}
	}
}
