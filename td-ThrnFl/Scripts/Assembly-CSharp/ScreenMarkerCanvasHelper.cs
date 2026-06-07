using UnityEngine;

public class ScreenMarkerCanvasHelper : MonoBehaviour
{
	public static ScreenMarkerCanvasHelper instance;

	[SerializeField]
	private RectTransform ownRT;

	public float Height => ownRT.sizeDelta.y;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
}
