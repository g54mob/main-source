using UnityEngine;

public class CursorOverride : MonoBehaviour, ICursorOverride
{
	public string Cursor;

	public string CursorOverrideName
	{
		get
		{
			return Cursor;
		}
	}
}
