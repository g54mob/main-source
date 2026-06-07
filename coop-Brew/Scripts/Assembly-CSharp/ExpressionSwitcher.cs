using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpressionSwitcher : MonoBehaviour
{
	private Animator _animator;

	private List<string> _expressionNames;

	private int _currentIndex;

	[SerializeField]
	private Text _emotionText;

	[SerializeField]
	private Button _cycleButton;

	[SerializeField]
	private Slider _transitionTimeSlider;

	private float _transitionTime;

	private void Start()
	{
	}

	private void PopulateExpressionNames()
	{
	}

	public void CycleExpressions()
	{
	}

	private void UpdateEmotionText()
	{
	}

	private void UpdateTransitionTime(float value)
	{
	}
}
