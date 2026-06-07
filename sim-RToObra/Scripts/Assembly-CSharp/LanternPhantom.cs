using UnityEngine;

public class LanternPhantom : MonoBehaviour
{
	public string[] turnOnAfterMomentIds;

	public bool wantOn
	{
		get
		{
			string[] array = turnOnAfterMomentIds;
			foreach (string id in array)
			{
				if (SaveData.it.momentRo[id].visited)
				{
					return true;
				}
			}
			return false;
		}
	}
}
