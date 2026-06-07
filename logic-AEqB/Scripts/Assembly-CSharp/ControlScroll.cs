using UnityEngine;
using UnityEngine.UI;

public class ControlScroll : MonoBehaviour
{
	public Scrollbar scroll;

	public Image img;

	public bool hide;

	private void Start()
	{
		scroll = GetComponent<Scrollbar>();
		img = GetComponent<Image>();
	}

	private void Update()
	{
		scroll.interactable = scroll.size != 1f;
		if (scroll.size == 1f || hide)
		{
			img.color = new Color(0f, 0f, 0f, 0f);
		}
		else
		{
			img.color = Color.white;
		}
	}
}
