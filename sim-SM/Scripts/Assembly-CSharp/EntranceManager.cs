using System.Collections.Generic;
using UnityEngine;

public class EntranceManager : NoktaSingleton<EntranceManager>
{
	[SerializeField]
	private List<EntranceVariantHolder> m_Entrances;

	private int m_CurrentEntranceID;

	private void Start()
	{
	}

	public void Initialize()
	{
	}

	public void ChangeEntranceVisual(int ID)
	{
	}

	public bool ApplyEntranceChanges()
	{
		return false;
	}

	public void ApplyEntranceChanges_Order(int entranceID)
	{
	}

	public void ResetEntrance()
	{
	}

	public void OnClick_Next()
	{
	}

	public void OnClick_Previous()
	{
	}
}
