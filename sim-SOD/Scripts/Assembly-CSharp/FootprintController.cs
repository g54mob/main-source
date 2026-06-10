using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FootprintController : MonoBehaviour
{
	private const int INITIAL_POOL_SIZE = 300;

	private const float RECYCLED_Y_POSITION = -1000f;

	private static Queue<FootprintController> footprintPool;

	[Header("Components")]
	public GameplayController.Footprint footprint;

	public MeshRenderer quad;

	public DecalProjector projector;

	public Human human;

	[Header("Values/Settings")]
	[Tooltip("Use a quad instead of a decal projector")]
	public bool useQuad;

	public float scanProgress;

	public bool printConfirmed;

	public InteractableController printInteractable;

	public void Setup(GameplayController.Footprint newFootprint)
	{
	}

	public void SetUseQuad(bool val)
	{
	}

	public void ResetScan()
	{
	}

	public void PrintConfirmed()
	{
	}

	public static void InitialisePool()
	{
	}

	public static FootprintController GetNewFootprint()
	{
		return null;
	}

	public static void RecycleFootprint(FootprintController footprintController)
	{
	}
}
