using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class PopupEffect : MonoBehaviour, IVisualEffect
{
	[SerializeField]
	private float popup_time = 0.1f;

	[SerializeField]
	private float life_time = 1f;

	private TextMeshPro tmp_text;

	private void Awake()
	{
		tmp_text = GetComponent<TextMeshPro>();
	}

	public bool IsPlaying()
	{
		return LeanTween.isTweening(base.gameObject);
	}

	public void Play()
	{
		base.transform.localScale = Vector3.one;
		LeanTween.scale(base.gameObject, Vector3.zero, life_time - popup_time).setEaseOutQuint();
	}

	public void SetColor(Color color)
	{
		tmp_text.color = color;
	}

	public float SetText(string text)
	{
		tmp_text.text = text;
		return 0f;
	}
}
