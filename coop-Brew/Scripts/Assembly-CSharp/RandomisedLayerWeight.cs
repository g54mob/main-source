using UnityEngine;
using UnityEngine.UI;

public class RandomisedLayerWeight : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[Header("Random Variance Settings")]
	[SerializeField]
	[Range(0f, 1f)]
	private float maxRandomVariance;

	[SerializeField]
	private Slider randomVarianceSlider;

	[SerializeField]
	private Text maxRandomVarianceText;

	[Header("Layer Weight Settings")]
	[SerializeField]
	[Range(0f, 1f)]
	private float layerWeight;

	[SerializeField]
	private Slider layerWeightSlider;

	[SerializeField]
	private Text layerWeightText;

	[Header("Transition Settings")]
	[SerializeField]
	private string layerName;

	[SerializeField]
	private float averageTransitionTime;

	[SerializeField]
	private float transitionVariationAmount;

	[Header("Hold Settings")]
	[SerializeField]
	private float averageHoldTime;

	[SerializeField]
	private float holdVariationAmount;

	private int layerIndex;

	private float currentWeight;

	private float targetWeight;

	private float transitionTimer;

	private float holdTimer;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void StartTransition()
	{
	}

	private float GenerateTransitionTime()
	{
		return 0f;
	}

	private float GenerateHoldTime()
	{
		return 0f;
	}

	private void SetMaxRandomVariance(float value)
	{
	}

	private void SetLayerWeight(float value)
	{
	}
}
