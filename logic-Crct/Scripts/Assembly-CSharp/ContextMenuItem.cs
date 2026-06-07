using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContextMenuItem : MonoBehaviour
{
	[Header("Components")]
	public Text functionText;

	public Text shortcutText;

	public Image functionImage;

	public Button button;

	public KeyCode[] shortcutKeys;

	private UnityEvent unityEvent;

	private ContextMenu contextMenu;

	public void Initialise(ContextMenu c, string f, KeyCode[] k, UnityEvent e, Sprite img = null)
	{
	}

	private void Trigger()
	{
	}

	public void Update()
	{
	}
}
