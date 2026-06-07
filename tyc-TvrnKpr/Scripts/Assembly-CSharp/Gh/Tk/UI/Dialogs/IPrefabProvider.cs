using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public interface IPrefabProvider
	{
		GameObject GetPrefab(string name);
	}
}
