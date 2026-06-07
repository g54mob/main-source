using System;
using System.Collections.Generic;
using UnityEngine;

public class Solderer : MonoBehaviour
{
	public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
	{
		public int Compare(TKey x, TKey y)
		{
			return 0;
		}
	}

	private struct GetLinkResult
	{
		public Motherboard motherboard;

		public MotherboardShape.NodeLink link;

		public GetLinkResult(Motherboard motherboard, MotherboardShape.NodeLink link)
		{
			this.motherboard = null;
			this.link = default(MotherboardShape.NodeLink);
		}
	}

	public SoldererSprite tableSprite;

	public SoldererSprite[] mainSoldererSprites;

	public SoldererSprite[] externalSoldererSprites;

	private bool interpolate;

	private int spriteI;

	private PixelCameraManager pixelCamera;

	private bool showTableSprite;

	private Material _blitMotherboardCaseDataMaterial;

	private Vector3 positionVel;

	private Material blitMotherboardCaseDataMaterial => null;

	private void Awake()
	{
	}

	public Vector2 GetCenter()
	{
		return default(Vector2);
	}

	public void UpdatePosition()
	{
	}

	private Vector3 GetFinalPosition()
	{
		return default(Vector3);
	}

	public void Enable(Vector3 position, Vector3 initialVelocity)
	{
	}

	public void Disable()
	{
	}

	public void SetSpriteI(int spriteI)
	{
	}

	public void ShowTableSprite(bool showTableSprite)
	{
	}

	public bool UpdateInteraction(MultitoolProjector_SoldererRay ray)
	{
		return false;
	}

	private List<GetLinkResult> GetLinks(Vector2 position)
	{
		return null;
	}

	private void Solder(GetLinkResult link1, GetLinkResult link2, bool bigSlot)
	{
	}

	private bool Unsolder(Motherboard motherboard, MotherboardShape.NodeLink link1, MotherboardShape.NodeLink link2, bool bigSlot)
	{
		return false;
	}
}
