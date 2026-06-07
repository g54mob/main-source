using System;
using UnityEngine;

public class MotherboardBottom : MonoBehaviour
{
	private Gadget gadget;

	private Motherboard motherboard;

	[NonSerialized]
	[HideInInspector]
	public SpriteRenderer mainRenderer;

	private Material material;

	private bool init;

	private void Init()
	{
	}

	public void Setup(Gadget gadget, Motherboard motherboard)
	{
	}

	public void OnNewCoverTexture(RenderTexture renderTexture)
	{
	}
}
