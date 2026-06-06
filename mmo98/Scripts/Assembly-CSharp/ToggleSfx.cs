using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleSfx : MonoBehaviour
{
	[SerializeField]
	private AudioDataType onSfx;

	[SerializeField]
	private AudioDataType offSfx;

	private void Awake()
	{
		GetComponent<Toggle>().onValueChanged.AddListener(PlaySfx);
	}

	private void PlaySfx(bool value)
	{
		Audio.PlaySfx(value ? onSfx : offSfx);
	}
}
