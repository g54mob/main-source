using System;
using System.Collections.Generic;
using DG.Tweening;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class TileVisual : MonoBehaviour, IBiomeAffectedObject, ITileStateReceiver
{
	[SerializeField]
	[FormerlySerializedAs("tileGround")]
	private Renderer tileGroundReplacement;

	[SerializeField]
	private List<GameObject> decorationEdgeContainers;

	[SerializeField]
	private Material previewMat;

	public ElementType tileGroundElementType;

	public Instanceable tileGroundReference;

	[SerializeField]
	private InstanceableVisual tileGroundVisual;

	private List<Renderer> objectRenderers;

	private List<Material> originalMats;

	private ElementGroupSegment[] elementGroupSegments;

	private bool groundReplaced;

	public Action<int> OnSetLayer;

	private Tile tile;

	private Tween placementAnimation;

	private Instanceable nonInstancedInstanceable;

	private MeshRenderer nonInstancedMeshRenderer;

	public int Seed => tile.Seed;

	private void Awake()
	{
		tile = GetComponentInParent<Tile>();
		elementGroupSegments = new ElementGroupSegment[0];
	}

	public void Initialize()
	{
		SetupRenderers();
		RandomizeFloor();
		if (decorationEdgeContainers.Count > 0)
		{
			for (int i = 0; i < 6; i++)
			{
				bool active = tile.GetEdgeTypes(i, Space.Self).Count == 0;
				decorationEdgeContainers[i].SetActive(active);
			}
		}
	}

	public void SetupRenderers()
	{
		elementGroupSegments = GetComponentsInChildren<ElementGroupSegment>();
	}

	public void ChangeTileState(TileState targetState, bool animate = true)
	{
		switch (targetState)
		{
		case TileState.stacked:
			if (tileGroundVisual.isInitialized)
			{
				tileGroundVisual.ChangeDisplayState(InstancingDisplayState.Regular);
			}
			break;
		case TileState.placed:
			if (animate)
			{
				placementAnimation = TweenSettingsExtensions.OnComplete(ShortcutExtensions.DOPunchScale(base.transform, Vector3.one * -0.1f, 0.3f, 10, 0.8f), delegate
				{
					ShortcutExtensions.DOScale(base.transform, Vector3.one, 0.1f);
					tile.RemoveRunningAnimation(placementAnimation);
				});
				tile.AddRunningAnimation(placementAnimation);
			}
			break;
		}
		if (tileGroundVisual.isInitialized && !groundReplaced)
		{
			tileGroundVisual.ChangeTileState(targetState);
		}
	}

	public void Rotate(int targetRotation, bool animate = true)
	{
		if (animate)
		{
			ShortcutExtensions.DOLocalRotate(base.transform, Quaternion.AngleAxis(targetRotation * 60, Vector3.up).eulerAngles, 0.1f);
		}
		else
		{
			base.transform.localRotation = Quaternion.AngleAxis(targetRotation * 60, Vector3.up);
		}
	}

	public void RandomizeFloor()
	{
		if (!groundReplaced && tileGroundVisual.isInitialized)
		{
			tileGroundVisual.Randomize(tile.Seed);
		}
	}

	public void SetGroundReplacement(MeshRenderer overwriteGround)
	{
		tileGroundReplacement = overwriteGround;
		if (!groundReplaced)
		{
			ShowReplacedGround(tile.State != TileState.stacked);
		}
	}

	public void ShowReplacedGround(bool showReplacedGround)
	{
		if ((bool)tileGroundReplacement)
		{
			tileGroundReplacement.gameObject.SetActive(showReplacedGround);
			groundReplaced = showReplacedGround;
			if (tileGroundVisual.isInitialized)
			{
				tileGroundVisual.ChangeDisplayState(groundReplaced ? InstancingDisplayState.Hidden : InstancingDisplayState.Regular);
			}
		}
	}

	public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		if (!groundReplaced && tileGroundVisual.isInitialized)
		{
			tileGroundVisual.ApplyBiomeConfiguration(biomeConfiguration);
			return;
		}
		TileGround[] componentsInChildren = GetComponentsInChildren<TileGround>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].ApplyBiomeConfiguration(biomeConfiguration);
		}
	}

	private void InitializeInstancedTileGround()
	{
		if (!tileGroundElementType || !tileGroundReference)
		{
			Debug.LogError($"tileVisual {base.name} elementType: {tileGroundElementType}, instanceableReference: {tileGroundReference}");
			return;
		}
		tileGroundVisual.SetElementType(tileGroundElementType);
		tileGroundVisual.SetInstanceable(tileGroundReference);
		tileGroundVisual.Initialize(base.transform, Vector3.zero);
	}

	public void ChangeTileState(TileState targetState)
	{
		if (tileGroundVisual.isInitialized && !groundReplaced)
		{
			tileGroundVisual.ChangeTileState(targetState);
		}
	}

	public void SetRendererLayer(int targetLayer)
	{
		if (tileGroundVisual.isInitialized)
		{
			tileGroundVisual.SetLayer(targetLayer);
		}
	}

	public void SetAnimationsRunning(bool animationsRunning)
	{
		if (tileGroundVisual.isInitialized && !groundReplaced)
		{
			tileGroundVisual.SetAnimationsRunning(animationsRunning);
		}
	}

	public void SetTileReference(Tile tile)
	{
		this.tile = tile;
	}

	private void _003CChangeTileState_003Eb__18_0()
	{
		ShortcutExtensions.DOScale(base.transform, Vector3.one, 0.1f);
		tile.RemoveRunningAnimation(placementAnimation);
	}
}
