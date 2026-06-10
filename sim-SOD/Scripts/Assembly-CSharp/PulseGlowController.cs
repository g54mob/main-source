using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PulseGlowController : MonoBehaviour
{
	public Image imageToGlow;

	public RawImage rawImageToGlow;

	public TextMeshProUGUI textToGlow;

	public bool glowActiveOnStart;

	public bool glowActive;

	public float pulseSpeed;

	private float glowState;

	private bool glowSwitch;

	public bool useLerpColour;

	public Color originalColour;

	public Color lerpColour;

	private void Awake()
	{
	}

	public void SetGlow(bool onOff)
	{
	}

	private void Update()
	{
	}
}
