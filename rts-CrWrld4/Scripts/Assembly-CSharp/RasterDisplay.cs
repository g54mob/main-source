using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RasterDisplay : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private class BlitFadeData
	{
		public int x;

		public int y;

		public Color32[] colorData;

		public int width;

		public float startAlpha;

		public float endAlpha;

		public int totalTime;

		public int currentTime;

		public BlitFadeData(int x, int y, List<RplCore.Data> tdata, int width, float startAlpha, float endAlpha, int time)
		{
		}

		public float GetCurrentAlpha()
		{
			return 0f;
		}

		public bool AdvanceTime()
		{
			return false;
		}
	}

	public RawImage image;

	public RawImage backgroundImage;

	private Texture2D tex;

	private bool inited;

	private NativeArray<Color32> data;

	private bool dirty;

	private Color32 color;

	private float clickScale;

	private List<BlitFadeData> blitFadeData;

	private List<BlitFadeData> bfdRemove;

	public void Awake()
	{
	}

	public void Init(int width, int height)
	{
	}

	private void SetSize(float scale)
	{
	}

	public void ClearDisplay(Color32 color)
	{
	}

	public void Set(int x, int y, Color32 color)
	{
	}

	public void SetC(int x, int y)
	{
	}

	public void Blit(int x, int y, List<RplCore.Data> tdata, int width)
	{
	}

	public void BlitFade(int x, int y, List<RplCore.Data> tdata, int width, float startAlpha, float endAlpha, int time)
	{
	}

	public void SetColor(Color32 color)
	{
	}

	public void Apply()
	{
	}

	public void GameUpdate()
	{
	}

	private void BlitAlpha(BlitFadeData bfd)
	{
	}

	public void LateUpdate()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
