using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MediaPlayerToggle : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(UI.Registry.popup.mediaPlayer.ToggleContent);
	}
}
