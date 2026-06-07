using System;
using UnityEngine;
using UnityEngine.UI;

public class ProGifPreviewSharePanel : MonoBehaviour
{
	public GameObject containerGO;

	public GameObject shareBarGO;

	public GameObject shareBarGO_V;

	public Image m_GifImage;

	public RectTransform m_PreviewBorderRectT;

	[HideInInspector]
	public string gifPath;

	public static ProGifPreviewSharePanel Create(GameObject prefab, Transform parentT)
	{
		ProGifPreviewSharePanel proGifPreviewSharePanel = ProGifManager.InstantiatePrefab<ProGifPreviewSharePanel>(prefab);
		proGifPreviewSharePanel.transform.SetParent(parentT);
		proGifPreviewSharePanel.transform.rotation = parentT.rotation;
		proGifPreviewSharePanel.transform.localScale = Vector3.one;
		proGifPreviewSharePanel.transform.localPosition = Vector3.zero;
		proGifPreviewSharePanel.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);
		proGifPreviewSharePanel.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);
		return proGifPreviewSharePanel;
	}

	public void Setup(string gifPath, bool loadFile = false, Action<float> onLoading = null)
	{
		this.gifPath = gifPath;
		ProGifManager.Instance.PlayGif(m_GifImage, delegate(float progress)
		{
			m_GifImage.SetNativeSize();
			float num = m_GifImage.sprite.texture.width;
			float num2 = m_GifImage.sprite.texture.height;
			float num3 = num * 0.04f;
			m_PreviewBorderRectT.sizeDelta = new Vector2(num + num3, num2 + num3);
			_CheckAndSetRotation();
			if (onLoading != null)
			{
				onLoading(progress);
			}
		});
		shareBarGO_V.SetActive(value: false);
		shareBarGO.SetActive(value: false);
		if (Screen.width > Screen.height)
		{
			shareBarGO = shareBarGO_V;
		}
		_Show();
	}

	public void SetPingPongPlayMode()
	{
		ProGifManager.Instance.m_GifPlayer.PingPong();
	}

	public void CancelPingPongPlayMode()
	{
		ProGifManager.Instance.m_GifPlayer.CancelPingPong();
	}

	public void SetReverse()
	{
		CancelPingPongPlayMode();
		ProGifManager.Instance.m_GifPlayer.Reverse();
	}

	public void ShareToFacebook()
	{
		ProGifManager.Instance.ShareFacebook(gifPath);
	}

	public void ShareToTwitter()
	{
		ProGifManager.Instance.ShareTwitter(gifPath);
	}

	private void _CheckAndSetRotation()
	{
		ImageRotator.Rotation rotation = ProGifManager.Instance.m_GifPlayer.rotation;
		float z = 0f;
		switch (rotation)
		{
		case ImageRotator.Rotation.Left:
			z = 90f;
			break;
		case ImageRotator.Rotation.Right:
			z = -90f;
			break;
		case ImageRotator.Rotation.HalfCircle:
			z = 180f;
			break;
		}
		Vector3 localEulerAngles = m_PreviewBorderRectT.localEulerAngles;
		m_PreviewBorderRectT.localEulerAngles = new Vector3(localEulerAngles.x, localEulerAngles.y, z);
	}

	private void _Show()
	{
		base.gameObject.SetActive(value: true);
		SDemoAnimation.Instance.Scale(containerGO, Vector3.zero, Vector3.one, 0.3f, SDemoAnimation.LoopType.None, delegate
		{
			shareBarGO.SetActive(value: true);
			SDemoAnimation.Instance.Scale(shareBarGO, Vector3.one * 3f, Vector3.one, 0.3f);
		});
	}

	public void Close()
	{
		_Close();
	}

	private void _Close()
	{
		SDemoAnimation.Instance.Scale(shareBarGO, Vector3.one, Vector3.zero, 0.3f, SDemoAnimation.LoopType.None, delegate
		{
			SDemoAnimation.Instance.Scale(containerGO, Vector3.one, Vector3.zero, 0.3f, SDemoAnimation.LoopType.None, delegate
			{
				ProGifManager.Instance.Clear();
				if (m_GifImage.sprite != null && m_GifImage.sprite.texture != null)
				{
					UnityEngine.Object.Destroy(m_GifImage.sprite.texture);
				}
				UnityEngine.Object.Destroy(base.gameObject);
			});
		});
	}
}
