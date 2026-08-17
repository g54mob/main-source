using System;
using System.Collections.Generic;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;

namespace VampireSurvivors;

[Serializable]
public class SelectedDLCDictionary : UnitySerializedDictionary<DlcType, bool>
{
	public SelectedDLCDictionary()
	{
		List<DlcType> list = new List<DlcType>();
		List<bool> list2 = new List<bool>();
		((Dictionary<DlcType, bool>)this)._002Ector();
	}
}
