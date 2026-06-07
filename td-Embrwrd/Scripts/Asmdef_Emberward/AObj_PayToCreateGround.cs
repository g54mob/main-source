using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public abstract class AObj_PayToCreateGround : MonoBehaviour
{
	public enum eState
	{
		DEACTIVATED = 0,
		SELECTABLE = 1,
		ACTIVATED = 2
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private List<Renderer> list_OutlineRenderers;

	[SerializeField]
	protected GameObject obj_Statue;

	[SerializeField]
	protected GameObject node_After;

	[SerializeField]
	protected GameObject node_Preview;

	[SerializeField]
	protected float afterPurchaseAnimationTime;

	[SerializeField]
	private Material material_Preview;

	[SerializeField]
	private Renderer renderer_Statue;

	[SerializeField]
	private Material material_Statue_Deactivated;

	[SerializeField]
	private Material material_Statue_Clickable;

	private int currentRound;

	private bool isActivated;

	private List<Renderer> list_HintRenderers;

	private eState state;

	private TweenerCore<Vector3, Vector3, VectorOptions> tween;

	private bool isTooltipOn;

	private bool isOutlineOn;

	private void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	public void ToggleSelectable(bool isOn)
	{
	}

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

	private void OnRoundStart(int currentRound, int totalRound)
	{
	}

	public void Activate()
	{
	}

	protected abstract void ActivateProc();

	protected void Toggle(bool isOn)
	{
	}

	protected abstract IEnumerator CR_Purchase();

	private void OnMouseDown()
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	private void OnMouseOver()
	{
	}
}
