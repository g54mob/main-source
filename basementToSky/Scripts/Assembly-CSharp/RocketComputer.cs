using System;
using System.Collections.Generic;
using UnityEngine;

public class RocketComputer : MonoBehaviour
{
	[Header("Module Slots")]
	public List<ModuleSlot> slots = new List<ModuleSlot>();

	public ModuleSlot cpuSlot;

	public ModuleSlotGizmo cupGizmo;

	public static event Action OnCpuInstalled;

	public static event Action<Chips> OnChipInstalled;

	private void Start()
	{
		ModuleSlotGizmo.OnModuleSlotGizmoClicked += ModuleSlotGizmo_OnModuleSlotGizmoClicked;
		foreach (ModuleSlot slot in slots)
		{
			slot.SetSlotState(open: false);
		}
		if (cpuSlot.position.childCount > 0)
		{
			cpuSlot.LoadModule(cpuSlot.position.GetChild(0).GetComponent<Chips>());
			foreach (ModuleSlot slot2 in slots)
			{
				slot2.SetSlotState(open: true);
			}
		}
		else
		{
			foreach (ModuleSlot slot3 in slots)
			{
				slot3.SetSlotState(open: false);
			}
		}
		foreach (ModuleSlot slot4 in slots)
		{
			if (slot4.position.childCount > 0)
			{
				slot4.LoadModule(slot4.position.GetChild(0).GetComponent<Chips>());
			}
		}
	}

	private void OnDestroy()
	{
		ModuleSlotGizmo.OnModuleSlotGizmoClicked -= ModuleSlotGizmo_OnModuleSlotGizmoClicked;
	}

	private void ModuleSlotGizmo_OnModuleSlotGizmoClicked(ModuleSlotGizmo arg1, GameObject arg2)
	{
		foreach (ModuleSlot slot in slots)
		{
			if (slot.gizmo == arg1)
			{
				if (slot.attachedModule != null)
				{
					UnityEngine.Object.Destroy(slot.attachedModule.gameObject);
					slot.attachedModule = null;
				}
				Chips component = UnityEngine.Object.Instantiate(arg2, FirstPersonController.S.transform.position + Vector3.back, Quaternion.identity).GetComponent<Chips>();
				slot.InstallModule(component);
				RocketComputer.OnChipInstalled?.Invoke(component);
				AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
				return;
			}
		}
		if (cpuSlot.gizmo == arg1)
		{
			InstallCPU(arg2);
		}
	}

	public bool CheckModuleExist(ChipType type)
	{
		foreach (ModuleSlot slot in slots)
		{
			if (slot.type == type && slot.attachedModule != null)
			{
				return true;
			}
		}
		return false;
	}

	public void ActiveGizmos(ChipType type)
	{
		foreach (ModuleSlot slot in slots)
		{
			if (slot.isOpen && slot.type == type)
			{
				slot.gizmo.gameObject.SetActive(value: true);
			}
		}
		if (type == ChipType.Cpu)
		{
			cpuSlot.gizmo.gameObject.SetActive(value: true);
		}
	}

	public void ToggleSlot(int index)
	{
		if (index >= 0 && index < slots.Count)
		{
			slots[index].SetSlotState(!slots[index].isOpen);
		}
	}

	public void PlugInModule(int slotIndex, Chips newModule)
	{
		if (slots[slotIndex].InstallModule(newModule))
		{
			Debug.Log(newModule.name + " 장착 완료!");
		}
	}

	public void ReorganizeSlots()
	{
		int num = Mathf.Clamp(cpuSlot.attachedModule.slots, 0, slots.Count);
		for (int i = 0; i < slots.Count; i++)
		{
			if (i >= num)
			{
				ClearAndCloseSlot(slots[i]);
			}
		}
		Debug.Log($"슬롯 재구성 완료: {num}개 활성, {slots.Count - num}개 정리됨.");
	}

	private void ClearAndCloseSlot(ModuleSlot slot)
	{
		if (slot.attachedModule != null)
		{
			UnityEngine.Object.Destroy(slot.attachedModule.gameObject);
			slot.attachedModule = null;
		}
		slot.SetSlotState(open: false);
	}

	public void InstallCPU(GameObject go)
	{
		if (cpuSlot.attachedModule != null)
		{
			UnityEngine.Object.Destroy(cpuSlot.attachedModule.gameObject);
			cpuSlot.attachedModule = null;
		}
		Chips component = UnityEngine.Object.Instantiate(go, FirstPersonController.S.transform.position + Vector3.back, Quaternion.identity).GetComponent<Chips>();
		cpuSlot.InstallModule(component);
		foreach (ModuleSlot slot in slots)
		{
			slot.SetSlotState(open: true);
		}
		RocketComputer.OnCpuInstalled?.Invoke();
		AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
		GameManager.S.isCpuInstalled = true;
	}
}
