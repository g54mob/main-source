using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Cpp2ILInjected;
using UnityEngine;

public class RequirementsContainer : MonoBehaviour
{
	public RequirementPrefab[] reqContainers;

	public void Set(UnlockableBase unlockable)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0101: Expected O, but got I4
		//IL_010a: Expected O, but got I4
		//IL_01a9: Expected O, but got I
		RequirementPrefab[] array = reqContainers;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			GameObject gameObject = array[obj].gameObject;
			gameObject.SetActive(value: false);
			obj++;
			obj2 = obj;
		}
		MyAchievement unlockRequirement = unlockable.GetUnlockRequirement();
		object obj4;
		if (unlockRequirement != null)
		{
			RequirementPrefab[] array2 = reqContainers;
			GameObject gameObject2 = array2[0].gameObject;
			gameObject2.SetActive(value: true);
			RequirementPrefab[] array3 = reqContainers;
			array3[0].Set(unlockRequirement);
			object obj3 = 40;
			obj4 = 1;
		}
		else
		{
			object obj3 = 32;
			obj4 = 0;
		}
		UnlockableBase unlockableRequirement = unlockable.GetUnlockableRequirement();
		if (unlockableRequirement != null)
		{
			RequirementPrefab[] array4 = reqContainers;
			GameObject gameObject3 = array4[obj4].gameObject;
			gameObject3.SetActive(value: true);
			RequirementPrefab[] array5 = reqContainers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v21 (RequirementPrefab[])+v50 @ rbp_v3]");
			((RequirementPrefab)0).Set(unlockableRequirement);
		}
	}

	public void HideBar()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		RequirementPrefab[] array = reqContainers;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			RequirementPrefab requirementPrefab = array[obj2];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831720E0]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			requirementPrefab.progress.SetActive(value: false);
			requirementPrefab.t_progress.text = "";
			obj2++;
			obj = obj2;
		}
	}
}
