using System;
using System.Collections.Generic;
using Fix;
using UnityEngine;
using UnityEngine.Rendering;

public class MotherboardCover : MonoBehaviour
{
	public enum InteractionMode
	{
		None = 0,
		OpenClose = 1,
		Archive = 2
	}

	public PolygonCollider2D caseFullCollider;

	[NonSerialized]
	[HideInInspector]
	public SpriteRenderer mainRenderer;

	[NonSerialized]
	[HideInInspector]
	public SortingGroup sortingGroup;

	private MotherboardLayerRenderer[] additionalRenderers;

	private Transform caseContent;

	private DraggablePanel panel;

	private InteractableHandle interactableHandle;

	private InteractableProxy interactableArchivableProxy;

	private Material material;

	[HideInInspector]
	public RenderTexture paintRenderTexture;

	[HideInInspector]
	public RenderTexture stickersRenderTexture;

	private Gadget gadget;

	private Motherboard motherboard;

	private List<SpriteRenderer> spriteRenderers;

	private Dictionary<SpriteMask, SpriteMaskReplica> spriteMasks;

	private Dictionary<SpriteRenderer, BoxCollider2D> openCaseColliders;

	private SpriteShadow shadow;

	private bool init;

	public InteractionMode interactionMode { get; private set; }

	private string sortingLayerWhenClosed => null;

	private string sortingLayerWhenOpen => null;

	public bool isOpen => false;

	public bool isMoving => false;

	private void Init()
	{
	}

	public void Setup(Gadget gadget, Motherboard motherboard)
	{
	}

	public void SetupRenderTextureMaterialParams(SpriteRenderer renderer, Vector2 modulePosition = default(Vector2), Quaternion moduleRotation = default(Quaternion))
	{
	}

	private void SetupMaterial()
	{
	}

	public byte[] GetColorData()
	{
		return null;
	}

	public void ApplyColorData(byte[] colorData)
	{
	}

	private void OnDestroy()
	{
	}

	private void LateUpdate()
	{
	}

	public void Refresh()
	{
	}

	public void OnMotherboardPositionChange(Motherboard.Position position)
	{
	}

	public void Open(float speed = 1f)
	{
	}

	public void Close(float speed = 1f)
	{
	}

	public void SetCurrentTweenDelay(float delay)
	{
	}

	public void SetCurrentTweenSpeed(float speed)
	{
	}

	public void SetInteractionMask(Mask mask)
	{
	}

	public void SetInteractionMode(InteractionMode interactionMode, bool force = false)
	{
	}

	public void AddSpriteRenderer(SpriteRenderer spriteRenderer)
	{
	}

	public void RemoveSpriteRenderer(SpriteRenderer spriteRenerer)
	{
	}

	public void AddSpriteMask(SpriteMask spriteMask)
	{
	}

	public void RemoveSpriteMask(SpriteMask spriteMask)
	{
	}
}
