using UnityEngine;
using VRTK;

public class UpdateBigDestinationOnPoint : MonoBehaviour
{
	private void Start()
	{
		VRTK_Pointer[] componentsInChildren = base.transform.parent.GetComponentsInChildren<VRTK_Pointer>(includeInactive: true);
		int num = 4;
		if (componentsInChildren.Length != num)
		{
			Debug.LogWarning("UpdateBigDestinationOnPoint expecting to find " + num + " pointers, found " + componentsInChildren.Length, this);
		}
		VRTK_Pointer[] array = componentsInChildren;
		foreach (VRTK_Pointer pointer in array)
		{
			SetupPointer(pointer);
		}
	}

	private void SetupPointer(VRTK_Pointer pointer)
	{
		pointer.DestinationMarkerHover += OnHover;
	}

	private void OnHover(object sender, DestinationMarkerEventArgs e)
	{
	}
}
