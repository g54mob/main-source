using System.Collections.Generic;
using UnityEngine;

public class SaveVersionPopupHandler : MonoBehaviour
{
	public List<SaveVersionPopupData> SaveVersionPopups;

	private static bool Shown;

	public bool TryShow()
	{
		return false;
	}
}
