using System.Collections.Generic;
using UnityEngine;

public class TrackYardBefore : Track
{
	public List<GameObject> regularDefenses;

	public List<GameObject> w3Defenses;

	public void SetupPreYard()
	{
		DisableDefenses();
		if (ZoneManager.Instance.CurrentZone == null || ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial")
		{
			return;
		}
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z3_Viaduct")
		{
			foreach (GameObject w3Defense in w3Defenses)
			{
				w3Defense.SetActive(value: true);
			}
			return;
		}
		foreach (GameObject regularDefense in regularDefenses)
		{
			regularDefense.SetActive(value: true);
		}
	}

	private void DisableDefenses()
	{
		foreach (GameObject regularDefense in regularDefenses)
		{
			regularDefense.SetActive(value: false);
		}
		foreach (GameObject w3Defense in w3Defenses)
		{
			w3Defense.SetActive(value: false);
		}
	}
}
