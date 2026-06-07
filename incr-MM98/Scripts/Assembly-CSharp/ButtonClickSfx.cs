using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickSfx : MonoBehaviour
{
	[SerializeField]
	private AudioDataType sfx;

	[Header("Randomization Settings")]
	[Tooltip("The lowest possible pitch (1.0 is default)")]
	[Range(0.5f, 1.5f)]
	[SerializeField]
	private float minPitch = 0.95f;

	[Tooltip("The highest possible pitch")]
	[Range(0.5f, 1.5f)]
	[SerializeField]
	private float maxPitch = 1.05f;

	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(delegate
		{
			Audio.PlaySfx(sfx, Random.Range(minPitch, maxPitch));
		});
	}
}
