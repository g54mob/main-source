using System;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;

namespace VampireSurvivors
{
	[Serializable]
	public class SelectedDLCDictionary : UnitySerializedDictionary<DlcType, bool>
	{
	}
}
