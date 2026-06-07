using UnityEngine;
using UnityEngine.UI;

public class PulsatingImageColor : MonoBehaviour
{
	private Image image;

	private Color origColor;

	private Color tempColor1;

	private Color tempColor2;

	private Color cTemp;

	[SerializeField]
	private Color color2;

	[SerializeField]
	[Range(0f, 1f)]
	private float lerpTime;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void TweenTheColors()
	{
	}

	private void setColorCallback(Color c)
	{
	}

	private void OnDisable()
	{
	}
}
