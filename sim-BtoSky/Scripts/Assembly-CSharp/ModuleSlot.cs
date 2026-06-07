using System;
using UnityEngine;

[Serializable]
public class ModuleSlot
{
	public string slotName;

	public Transform position;

	public bool isOpen;

	public Chips attachedModule;

	public ModuleSlotGizmo gizmo;

	public ChipType type;

	public bool IsOccupied => attachedModule != null;

	public static event Action<Chips> OnModuleInstalled;

	public void SetSlotState(bool open)
	{
		isOpen = open;
		Debug.Log(slotName + " 슬롯이 " + (isOpen ? "열렸습니다" : "닫혔습니다") + ".");
	}

	public bool InstallModule(Chips module)
	{
		if (!isOpen)
		{
			Debug.LogWarning(slotName + "이 닫혀있어 모듈을 설치할 수 없습니다!");
			return false;
		}
		if (IsOccupied)
		{
			Debug.LogWarning(slotName + "에 이미 모듈이 존재합니다!");
			return false;
		}
		attachedModule = module;
		module.transform.SetParent(position);
		module.transform.localPosition = Vector3.zero;
		module.transform.localRotation = Quaternion.identity;
		module.transform.localScale = Vector3.one;
		ModuleSlot.OnModuleInstalled?.Invoke(module);
		return true;
	}

	public void LoadModule(Chips module)
	{
		isOpen = true;
		attachedModule = module;
		ModuleSlot.OnModuleInstalled?.Invoke(module);
	}
}
