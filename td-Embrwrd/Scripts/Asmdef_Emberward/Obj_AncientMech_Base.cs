using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public abstract class Obj_AncientMech_Base : MonoBehaviour
{
	[SerializeField]
	private Renderer renderer_ElectricBoard;

	[SerializeField]
	protected Material material_ElectricEffect;

	[SerializeField]
	private ParticleSystem particle_ActivateEffect;

	[SerializeField]
	protected List<Renderer> list_Renderers;

	[SerializeField]
	private List<Obj_ElectricConnectIndicator> list_ConnectIndicators;

	[SerializeField]
	[Header("這個機器的內部邊緣，用來作為從這台機器往外傳播電流的偵測點")]
	private List<Transform> list_InnerBorderNodes;

	[SerializeField]
	protected float explosionEventRadius;

	[SerializeField]
	protected GameObject node_DestroyedEffect;

	private List<Vector3Int> list_DetectStartPosition;

	private List<Vector3Int> list_InnerBorderPositions;

	protected bool isActivated;

	protected bool isDestoryedByEvent;

	public bool IsActivated => false;

	public bool IsDestoryedByEvent => false;

	private void OnEnable()
	{
	}

	protected virtual void OnEnableProc()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OnDisableProc()
	{
	}

	private void Start()
	{
	}

	private void OnAncientCircuitUpdated(List<Obj_ElectricCircuit.ElectricCircuitNode> list_Nodes, List<Obj_AncientMech_Base> obj_AncientMechs)
	{
	}

	protected void UpdateConnectStatus(bool isConnected)
	{
	}

	private void UpdateElectricMaterial(bool isOn)
	{
	}

	protected abstract void OnEffectActivateProc();

	protected abstract void OnEffectDeactivateProc();

	public List<Vector3Int> GetElectricConnectedPositions()
	{
		return null;
	}

	public List<Vector3Int> GetDetectStartPositions()
	{
		return null;
	}

	public void DestroyAncientMech()
	{
	}

	protected virtual void OnDestoryAncientMechProc()
	{
	}
}
