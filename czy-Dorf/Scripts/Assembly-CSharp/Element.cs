using System;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour, IBiomeAffectedObject, ITileStateReceiver
{
	[SerializeField]
	private GroupType groupType;

	[SerializeField]
	private ElementType elementType;

	[SerializeField]
	private ElementSubType elementSubType;

	[SerializeField]
	public bool randomizeRotation = true;

	[SerializeField]
	public Vector2 minMaxTilt;

	[SerializeField]
	public bool ignoreDisplayProbability;

	[SerializeField]
	public bool ignoreTileStateChange;

	private ElementVisual _003CElementVisual_003Ek__BackingField;

	[SerializeField]
	private int seed;

	[SerializeField]
	private float variationAlpha;

	[SerializeField]
	private float hidingAlpha;

	private List<BiomeEffectValue> biomeEffectValues;

	public bool alwaysEnabled;

	protected bool hidden;

	[SerializeField]
	private float displayProbabilityFactor = 1f;

	[SerializeField]
	private bool useOverwriteDisplayProbability;

	[SerializeField]
	private float overwriteDisplayProbability;

	private TileState currentTileState;

	public ElementVisual ElementVisual
	{
		get
		{
			return _003CElementVisual_003Ek__BackingField;
		}
		private set
		{
			_003CElementVisual_003Ek__BackingField = value;
		}
	}

	public GroupType GroupType => groupType;

	public ElementType ElementType => elementType;

	public ElementSubType SubType => elementSubType;

	public int Seed => seed;

	public float VariationAlpha => variationAlpha;

	public virtual bool IsDecoration => !ignoreDisplayProbability;

	public TileState CurrentTileState => currentTileState;

	protected virtual void Awake()
	{
		if (!ElementVisual)
		{
			InitializeElementVisual();
		}
	}

	public void Randomize(int overwriteSeed = -1)
	{
		seed = ((overwriteSeed == -1) ? (GetHashCode() + (int)DateTime.Now.Ticks) : overwriteSeed);
		UnityEngine.Random.InitState(seed);
		variationAlpha = UnityEngine.Random.value;
		hidingAlpha = UnityEngine.Random.value;
		if (randomizeRotation)
		{
			base.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.value * 360f, UnityEngine.Random.Range(minMaxTilt.x, minMaxTilt.y));
		}
		if ((bool)ElementVisual)
		{
			ElementVisual.Setup(this);
		}
		Randomizer.RandomizeSeed();
	}

	public virtual void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		if (!ignoreDisplayProbability && biomeConfiguration.biomeValues.ContainsKey("displayProbability"))
		{
			bool flag = (useOverwriteDisplayProbability ? overwriteDisplayProbability : ((float)biomeConfiguration.biomeValues["displayProbability"] * displayProbabilityFactor)) >= hidingAlpha;
			base.gameObject.SetActive(flag);
			hidden = !flag;
			if (!ElementVisual)
			{
				InitializeElementVisual();
			}
			ElementVisual.Show(flag);
			if (!flag)
			{
				return;
			}
		}
		biomeEffectValues = new List<BiomeEffectValue>();
		foreach (BiomeEffectValue biomeEffectValue in biomeConfiguration.biomeEffectValues)
		{
			biomeEffectValues.Add(biomeEffectValue);
		}
		if ((bool)biomeConfiguration.visual)
		{
			if (!ElementVisual)
			{
				InitializeElementVisual();
			}
			ElementVisual.RemoveGPUInstance(enableRenderers: true);
			if (ElementVisual.RecyclableId == RecyclableType.Undefined || ElementVisual.RecyclableId != biomeConfiguration.visual.RecyclableId)
			{
				MasterObjectPool.Instance.StoreObject(ElementVisual);
				ElementVisual = MasterObjectPool.Instance.GetObject(biomeConfiguration.visual);
				Transform obj = ElementVisual.transform;
				obj.parent = base.transform;
				obj.localPosition = Vector3.zero;
				obj.localRotation = Quaternion.identity;
				obj.localScale = Vector3.one;
				ElementVisual.Setup(this);
			}
			ElementVisual.SetLayer(base.gameObject.layer);
			ElementVisual.ApplyBiomeConfiguration(biomeConfiguration);
		}
	}

	public void InitializeElementVisual()
	{
		ElementVisual[] componentsInChildren = GetComponentsInChildren<ElementVisual>(includeInactive: true);
		if (componentsInChildren.Length == 1)
		{
			ElementVisual = componentsInChildren[0];
		}
		else if (componentsInChildren.Length > 1)
		{
			ElementVisual[] array = componentsInChildren;
			foreach (ElementVisual elementVisual in array)
			{
				if (elementVisual.enabled)
				{
					if (this is DecorationElement || !elementVisual.IsDecoration)
					{
						ElementVisual = elementVisual;
						break;
					}
				}
				else
				{
					UnityEngine.Object.Destroy(elementVisual.gameObject);
				}
			}
		}
		else
		{
			ElementVisual = null;
		}
		if (ElementVisual != null)
		{
			ElementVisual.Setup(this);
		}
		else
		{
			Debug.Log($"{GetComponentInParent<Tile>()} {base.name} found no ElementVisual", this);
		}
	}

	public void SetRendererLayer(int targetLayer)
	{
		if (!hidden)
		{
			base.gameObject.layer = targetLayer;
			if ((bool)ElementVisual)
			{
				ElementVisual.SetLayer(targetLayer);
			}
		}
	}

	public void SetAnimationsRunning(bool animationsRunning)
	{
		if ((bool)ElementVisual)
		{
			ElementVisual.SetAnimationsRunning(animationsRunning);
		}
	}

	public void SetTileReference(Tile tile)
	{
	}

	public void Highlight(bool newHighlight)
	{
		if (!hidden && (!ignoreTileStateChange || (bool)ElementVisual))
		{
			ElementVisual.Highlight(newHighlight);
		}
	}

	public void Show(bool show)
	{
		if (!hidden && !ignoreTileStateChange && !alwaysEnabled)
		{
			base.gameObject.SetActive(show);
		}
	}

	public void ChangeTileState(TileState targetState)
	{
		currentTileState = targetState;
		if ((bool)ElementVisual)
		{
			ElementVisual.ChangeTileState(targetState);
		}
		Show(targetState != TileState.stacked);
	}

	public void Destroy()
	{
		if ((bool)ElementVisual)
		{
			ElementVisual.RemoveGPUInstance(enableRenderers: true);
		}
	}
}
