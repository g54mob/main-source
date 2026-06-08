using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
	[SerializeField]
	private int color;

	[SerializeField]
	private AudioClip audioClip;

	private AudioSource audioSource;

	private Notepad notepad;

	public void Awake()
	{
		notepad = GetComponentInParent<Notepad>();
		audioSource = GetComponentInParent<AudioSource>();
		GetComponent<Button>().onClick.AddListener(SwitchColor);
	}

	public void SwitchColor()
	{
		notepad.SetColorInteractable(color);
		notepad.SetColor(color);
		audioSource.PlayOneShot(audioClip);
	}

	public Color GetColor()
	{
		return GetComponent<Button>().colors.normalColor;
	}
}
