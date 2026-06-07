using System;
using UnityEngine;

public class ModuleSlotGizmo : MonoBehaviour
{
	public static event Action<ModuleSlotGizmo, GameObject> OnModuleSlotGizmoClicked;

	private void Start()
	{
		OnModuleSlotGizmoClicked += ModuleSlotGizmo_OnModuleSlotGizmoClicked;
		LapTop.OffLapTop += LapTop_OffLapTop;
	}

	private void LapTop_OffLapTop()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		OnModuleSlotGizmoClicked -= ModuleSlotGizmo_OnModuleSlotGizmoClicked;
		LapTop.OffLapTop -= LapTop_OffLapTop;
	}

	private void ModuleSlotGizmo_OnModuleSlotGizmoClicked(ModuleSlotGizmo arg1, GameObject arg2)
	{
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
	}

	public void Clicked(GameObject module)
	{
		ModuleSlotGizmo.OnModuleSlotGizmoClicked?.Invoke(this, module);
	}
}
