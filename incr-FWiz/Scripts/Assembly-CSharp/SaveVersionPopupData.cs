using System;
using UnityEngine.Localization;

[Serializable]
public class SaveVersionPopupData
{
	public SaveCore.SaveVersionLocation Version;

	public LocalizedString Title;

	public LocalizedString Message;
}
