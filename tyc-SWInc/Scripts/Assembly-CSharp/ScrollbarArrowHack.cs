using UnityEngine;
using UnityEngine.UI;

public class ScrollbarArrowHack : MonoBehaviour
{
	public Sprite Horizontal;

	public Sprite Vertical;

	private void Start()
	{
		base.transform.GetChild(0).GetChild(0).GetComponent<Image>()
			.sprite = ((GetComponent<Scrollbar>().direction < Scrollbar.Direction.BottomToTop) ? Horizontal : Vertical);
		Object.Destroy(this);
	}
}
