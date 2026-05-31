using TMPro;
using UnityEngine;

public class PulsatingText : MonoBehaviour
{
	private TextMeshProUGUI textMesh;

	private Color tempColor1;

	private Color tempColor2;

	private Color cTemp;

	[SerializeField]
	private Color color2;

	[SerializeField]
	[Range(0f, 1f)]
	private float lerpTime;

	private void Start()
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
}
