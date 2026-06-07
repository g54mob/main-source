using R3;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteToggle : MonoBehaviour
{
	[SerializeField]
	private GameObject muted;

	[SerializeField]
	private GameObject unmuted;

	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(((ReactiveProperty<bool>)ReactiveSettings.AudioMuted).Toggle);
		ReactiveSettings.AudioMuted.SubscribeToSetToggle(muted, unmuted).AddTo(this);
	}
}
