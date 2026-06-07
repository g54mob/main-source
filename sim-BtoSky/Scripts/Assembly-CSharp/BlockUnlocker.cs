using MG_BlocksEngine2.UI;
using UnityEngine;

public class BlockUnlocker : MonoBehaviour
{
	public GameObject[] wingBlocks;

	public GameObject[] parachuteBlocks;

	public GameObject[] gyroBlocks;

	public BE2_UI_SelectionPanel[] pannels;

	private void Start()
	{
		ModuleSlot.OnModuleInstalled += ModuleSlot_OnModuleInstalled;
	}

	private void ModuleSlot_OnModuleInstalled(Chips obj)
	{
		if (obj.type == ChipType.Parachute)
		{
			GameObject[] array = parachuteBlocks;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}
		else if (obj.type == ChipType.WingControl)
		{
			GameObject[] array = wingBlocks;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}
		BE2_UI_SelectionPanel[] array2 = pannels;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].UpdateLayout();
		}
	}

	private void OnDestroy()
	{
		ModuleSlot.OnModuleInstalled -= ModuleSlot_OnModuleInstalled;
	}
}
