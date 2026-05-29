using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Try1 : MonoBehaviour
{
	private RectTransform r;

	public Scrollbar scroll;

	private int i;

	private void Start()
	{
		r = base.gameObject.GetComponent<RectTransform>();
	}

	private void Update()
	{
		i++;
		if (i % 100 == 0)
		{
			GetComponent<TMP_Text>().text = GetComponent<TMP_Text>().text + i + "\n";
			r.sizeDelta = new Vector2(r.sizeDelta.x, GetComponent<TMP_Text>().textBounds.size.y);
			Canvas.ForceUpdateCanvases();
		}
	}
}
