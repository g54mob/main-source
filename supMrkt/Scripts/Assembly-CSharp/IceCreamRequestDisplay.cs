using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IceCreamRequestDisplay : MonoBehaviour
{
	[SerializeField]
	private RawImage m_Image;

	private Canvas m_Canvas;

	private CanvasGroup m_CanvasGroup;

	private Tween m_Tween;

	[SerializeField]
	private RectTransform m_Content;

	private float m_StartX;

	public RenderTexture Texture => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void SetRequestTexture(RenderTexture rt)
	{
	}

	public void Toggle(bool value)
	{
	}

	private void PlayOpen()
	{
	}

	private void PlayClose()
	{
	}
}
