using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class QuestGiver : MonoBehaviour, IBiomeAffectedObject, ITileStateReceiver
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<ElementVisual, bool> _003C_003E9__23_0;

		internal bool _003CInitializeElementVisual_003Eb__23_0(ElementVisual x)
		{
			return !x.IsDecoration;
		}
	}

	[SerializeField]
	private ElementType questGiverType;

	[SerializeField]
	private bool neverExchangeVisual;

	[SerializeField]
	private AudioClipOptions idleSound;

	public UnityEvent OnPlaced;

	private QuestTile questTile;

	private QuestWatcher questWatcher;

	private MeshRenderer[] renderers;

	private ElementVisual questGiverVisual;

	private float variationAlpha = -1f;

	private VehicleDriver vehicleDriver;

	public GroupType GroupType => null;

	public ElementType ElementType => questGiverType;

	public ElementSubType SubType => null;

	public int Seed => questTile.Seed;

	public float VariationAlpha
	{
		get
		{
			if (variationAlpha < 0f)
			{
				UnityEngine.Random.InitState(Seed);
				variationAlpha = UnityEngine.Random.Range(0f, 1f);
				Randomizer.RandomizeSeed();
			}
			return variationAlpha;
		}
	}

	private void Awake()
	{
		questWatcher = GetComponent<QuestWatcher>();
		renderers = GetComponentsInChildren<MeshRenderer>();
		if (!questGiverVisual)
		{
			InitializeElementVisual();
		}
		questTile = GetComponentInParent<QuestTile>();
		vehicleDriver = GetComponent<VehicleDriver>();
	}

	private void Start()
	{
		if ((bool)idleSound)
		{
			AudioManager.Instance.PlaySoundAtTransform(idleSound, base.transform);
		}
	}

	public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		if ((bool)biomeConfiguration.visual && !neverExchangeVisual)
		{
			MasterObjectPool.Instance.StoreObject(questGiverVisual);
			questGiverVisual = MasterObjectPool.Instance.GetObject(biomeConfiguration.visual);
			questGiverVisual.transform.parent = base.transform;
			questGiverVisual.transform.localPosition = Vector3.zero;
			questGiverVisual.transform.localRotation = Quaternion.identity;
			questGiverVisual.transform.localScale = Vector3.one;
			questGiverVisual.SetLayer(base.gameObject.layer);
			if ((bool)vehicleDriver)
			{
				vehicleDriver.StartParticleSystemIfMoving();
			}
		}
		questGiverVisual.ApplyBiomeConfiguration(biomeConfiguration);
	}

	public void InitializeElementVisual()
	{
		ElementVisual[] componentsInChildren = GetComponentsInChildren<ElementVisual>(includeInactive: true);
		componentsInChildren = Enumerable.ToArray(Enumerable.Where(componentsInChildren, (ElementVisual x) => !x.IsDecoration));
		if (componentsInChildren.Length == 1)
		{
			questGiverVisual = componentsInChildren[0];
		}
		else if (componentsInChildren.Length > 1)
		{
			ElementVisual[] array = componentsInChildren;
			foreach (ElementVisual elementVisual in array)
			{
				if (elementVisual.enabled)
				{
					questGiverVisual = elementVisual;
					break;
				}
				UnityEngine.Object.Destroy(elementVisual.gameObject);
			}
		}
		else
		{
			questGiverVisual = null;
		}
	}

	public void ChangeTileState(TileState targetState)
	{
		base.gameObject.SetActive(targetState != TileState.stacked);
		if (targetState == TileState.placed)
		{
			OnPlaced.Invoke();
		}
	}

	public void SetRendererLayer(int targetLayer)
	{
		if ((bool)questGiverVisual)
		{
			questGiverVisual.SetLayer(targetLayer);
		}
	}

	public void SetAnimationsRunning(bool animationsRunning)
	{
	}

	public void SetTileReference(Tile tile)
	{
	}
}
