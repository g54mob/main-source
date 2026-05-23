using System;
using UnityEngine;

public class SaveLoadEntity : MonoBehaviour
{
	[SerializeField]
	private string guid = "";

	public string GUID => guid;

	public void AssignNewGUID()
	{
		guid = Guid.NewGuid().ToString();
	}

	public void ExecuteBeforeMainLoadPass()
	{
		if (guid.Length == 0)
		{
			Debug.LogError("NO GUID ASSIGNED", base.gameObject);
		}
		else if (base.gameObject.activeInHierarchy)
		{
			BroadcastMessage("OnBeforeMainLoadPass", guid);
		}
	}

	public void ExecuteLoad()
	{
		if (guid.Length == 0)
		{
			Debug.LogError("NO GUID ASSIGNED", base.gameObject);
		}
		else if (base.gameObject.activeInHierarchy)
		{
			BroadcastMessage("OnLoad", guid);
		}
	}

	public void ExecuteAfterMainLoadPass()
	{
		if (guid.Length == 0)
		{
			Debug.LogError("NO GUID ASSIGNED", base.gameObject);
		}
		else if (base.gameObject.activeInHierarchy)
		{
			BroadcastMessage("OnAfterMainLoadPass", guid);
		}
	}

	public void ExecuteSave()
	{
		if (guid.Length == 0)
		{
			Debug.LogError("NO GUID ASSIGNED", base.gameObject);
		}
		else if (base.gameObject.activeInHierarchy)
		{
			BroadcastMessage("OnSave", guid);
		}
	}
}
