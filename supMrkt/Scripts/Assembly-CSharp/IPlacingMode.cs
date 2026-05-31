using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public abstract class IPlacingMode : MonoBehaviour
{
	public List<string> m_ExcludeTag;

	public bool IsMine;

	[SerializeField]
	protected Renderer[] m_Renderers;

	[SerializeField]
	private List<Collider> m_OwnerCollider;

	[SerializeField]
	private BoxCollider m_PlacingModeCollider;

	private PhotonView m_ParentPhotonView;

	protected bool m_PlacingMode;

	protected bool m_OverrideAvailability;

	protected List<Collider> m_Triggers;

	protected Dictionary<Renderer, Material[]> m_DefaultMaterials;

	protected Dictionary<Renderer, Material[]> m_AppliedMaterials;

	private readonly List<Material> m_InstancedHologramMaterials;

	protected bool furniturePlacingMode;

	public PhotonView ParentPhotonView => null;

	public Color HologramColor
	{
		set
		{
		}
	}

	public virtual bool AvailablePosition => false;

	public virtual float OuterRadius => 0f;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OverlapBoxes()
	{
	}

	public virtual void PlacingMode(bool value, Material hologramMaterial = null)
	{
	}

	public void SetAvailabilityColor(bool value)
	{
	}

	public void UpdateHologramColor()
	{
	}

	public void UpdateClientHologramColor()
	{
	}

	protected void SaveDefaultMaterials()
	{
	}

	protected void ClearTriggers(bool force = false)
	{
	}

	public void TogglePlacingMaterial(bool value, Material hologramMaterial = null)
	{
	}

	private void ReleaseInstancedHologramMaterials()
	{
	}
}
