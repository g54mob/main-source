using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MotherboardRenderable : SerializedMonoBehaviour
{
	public enum RotationMode
	{
		None = 0,
		Eight = 1,
		Four = 2
	}

	public enum RenderingMode
	{
		None = 0,
		Fixed = 1,
		Moving = 2,
		Drawer = 3
	}

	public RotationMode rotationMode;

	[Space]
	public TurnableSpriteMask caseSpriteMask;

	public TurnableRenderer[] backRenderers;

	public TurnableRenderer[] bottomRenderers;

	public TurnableRenderer[] caseRenderers;

	public TurnableRenderer[] topRenderers;

	public bool alwaysShowCaseRenderer;

	[Space]
	public Transform visualsRoot;

	public Transform lightsRoot;

	[HideInInspector]
	public int drawerSortingLayerID;

	[HideInInspector]
	public int drawerSortingLayerOrder;

	[NonSerialized]
	[HideInInspector]
	public Light2D[] lights;

	[NonSerialized]
	[HideInInspector]
	public int maxSortingOrder;

	[NonSerialized]
	[HideInInspector]
	public PcbSide pcbSide;

	protected int rotation;

	private bool renderersAreOnMotherboard;

	public int rotationCount => 0;

	public Motherboard motherboard { get; protected set; }

	public Gadget gadget => null;

	public RenderingMode renderingMode { get; private set; }

	public virtual void InitMotherboardRenderable()
	{
	}

	public void RefreshRenderingMode()
	{
	}

	public virtual void SetRenderingMode(RenderingMode renderingMode, bool force = false)
	{
	}

	protected virtual void OnDestroy()
	{
	}

	public int GetRotation()
	{
		return 0;
	}

	public virtual void SetRotation(int rotationI)
	{
	}

	public Vector2 TransformPoint(Vector2 local)
	{
		return default(Vector2);
	}

	public Vector2 TransformPoint(Vector2Int local)
	{
		return default(Vector2);
	}

	public Quaternion GetQuaternionRotation()
	{
		return default(Quaternion);
	}
}
