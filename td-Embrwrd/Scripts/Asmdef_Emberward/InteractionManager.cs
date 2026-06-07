using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
	[SerializeField]
	[Header("Settings")]
	private LayerMask interactableLayer;

	[SerializeField]
	private float rayDistance;

	[Header("控制器使用")]
	[SerializeField]
	private Obj_GridInputControl obj_GridInputControl;

	[SerializeField]
	private IInteractable[] currentTargets;

	[SerializeField]
	private bool isControllerMode;

	private bool isInitReady;

	private int defaultEventMask;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void ShowCommonIngameUI()
	{
	}

	protected override void Awake()
	{
	}

	private void Update()
	{
	}

	private void DetectInputMode()
	{
	}

	private void SetControllerMode(bool controller)
	{
	}

	private void HandleRaycast()
	{
	}

	private Ray GetCurrentRay()
	{
		return default(Ray);
	}

	private void HandleInteractionInput()
	{
	}

	private void ClearCurrentTargets()
	{
	}
}
