using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CuttingMat : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public InteractableHandle handle;

	public SpriteRenderer handleSpriteRenderer;

	private DraggablePanel panel;

	private Material material;

	private Sprite mainSprite;

	private Texture2D defaultTexture;

	private List<Texture2D> textures;

	private Texture2D currentTexture;

	private Sequence handleTween;

	private bool _init;

	public void Init()
	{
	}

	private int GetIndex(string name)
	{
		return 0;
	}

	private void SetTexture(int index)
	{
	}

	private void SetTexture(Texture2D texture)
	{
	}

	public void OnOpenPanel()
	{
	}

	public void ShowHandle()
	{
	}

	public void HideHandle(bool immediate = false)
	{
	}
}
