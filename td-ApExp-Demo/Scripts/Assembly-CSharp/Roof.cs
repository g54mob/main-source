using UnityEngine;

public class Roof : MonoBehaviour
{
	[SerializeField]
	private float transparentAlpha = 0.3f;

	private SpriteRenderer sr;

	private SpriteMask sm;

	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		sm = GetComponent<SpriteMask>();
	}

	public void SetVisible(RoofVisibility visibility)
	{
		switch (visibility)
		{
		case RoofVisibility.Invisible:
			sr.enabled = false;
			sm.enabled = true;
			break;
		case RoofVisibility.Transparent:
			sr.enabled = true;
			sm.enabled = false;
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Train.Instance.WAGON_TRANSPARENCY_ALPHA);
			break;
		case RoofVisibility.Visible:
			sr.enabled = true;
			sm.enabled = false;
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
			break;
		}
	}
}
