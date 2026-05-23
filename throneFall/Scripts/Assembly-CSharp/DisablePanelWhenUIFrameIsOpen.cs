using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class DisablePanelWhenUIFrameIsOpen : MonoBehaviour
{
	private Canvas targetCanvas;

	private void Start()
	{
		targetCanvas = GetComponent<Canvas>();
	}

	private void Update()
	{
		targetCanvas.enabled = UIFrameManager.instance.ActiveFrame == null;
	}
}
