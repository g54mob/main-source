using System;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC
{
	[Serializable]
	public class DlcDataDictionary : UnitySerializedDictionary<DlcType, DlcData>
	{
	}
}
