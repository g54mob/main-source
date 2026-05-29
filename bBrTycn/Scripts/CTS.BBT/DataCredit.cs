using System;
using UnityEngine;

[Serializable]
public class DataCredit
{
	[Space]
	public string Team;

	[Space]
	public string Title;

	[Space]
	public string Name;

	public static DataCredit CreateCopyWithNewValues(DataCredit p_original, CreditImportStruct p_data)
	{
		return new DataCredit
		{
			Title = p_data.Title,
			Name = p_data.Name,
			Team = p_data.Team
		};
	}

	public void SetNewValues(CreditImportStruct p_data)
	{
		Title = p_data.Title;
		Name = p_data.Name;
		Team = p_data.Team;
	}

	public static DataCredit CreateNewFromImport(CreditImportStruct importData, CreditsDatabase creditsDataBase)
	{
		DataCredit dataCredit = new DataCredit
		{
			Title = importData.Title,
			Name = importData.Name,
			Team = importData.Team
		};
		creditsDataBase.AddItem(dataCredit.Name, dataCredit.Title, dataCredit.Team);
		return dataCredit;
	}
}
