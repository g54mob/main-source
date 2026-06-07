using UnityEngine;

public class StartupTutComicsBackHelper : MonoBehaviour
{
	public GameObject top;

	public GameObject bot;

	private RectTransform selfRect;

	private void Start()
	{
		selfRect = base.gameObject.GetComponent<RectTransform>();
	}

	private void Update()
	{
		Vector2 sizeDelta = selfRect.sizeDelta;
		sizeDelta.y = top.transform.localPosition.y - bot.transform.localPosition.y + 100f;
		selfRect.sizeDelta = sizeDelta;
	}
}
