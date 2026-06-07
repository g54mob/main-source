using UnityEngine;
using UnityEngine.UI;

public class RectToRectFade : MonoBehaviour
{
	public Image Img;

	public Gradient Anim;

	public RectTransform Self;

	public RectTransform Begin;

	public RectTransform End;

	public float Speed = 1f;

	private float _timer;

	private void Update()
	{
		_timer += Time.deltaTime * Speed;
		if (_timer >= 1f)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Vector3 a = Begin.position - Vector3.Scale(Begin.pivot + Vector2.down, Begin.rect.size);
		Vector3 b = End.position - Vector3.Scale(End.pivot + Vector2.down, End.rect.size);
		float t = Mathf.Pow(1f - _timer, 2f);
		Img.color = Anim.Evaluate(_timer);
		Self.position = Vector3.Lerp(a, b, t);
		Self.sizeDelta = Vector2.Lerp(Begin.rect.size, End.rect.size, t);
	}
}
