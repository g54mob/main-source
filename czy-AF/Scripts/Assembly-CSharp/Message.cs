using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
	public Text message;

	private Vector2 target = new Vector2(0f, 0f);

	private void Awake()
	{
		target.y = 0f - base.transform.localPosition.y;
	}

	public void SetData(string text, float time)
	{
		message.text = text;
		Object.Destroy(base.gameObject, time);
	}

	public void UpdatePosition(float add = 0f)
	{
		target.y += add;
		iTween.MoveTo(base.gameObject, iTween.Hash("x", target.x, "y", 0f - target.y, "time", 0.1f, "easetype", "easeOutSine", "islocal", true));
	}
}
