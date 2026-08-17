using System;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC;

[Serializable]
public class DlcDataDictionary : UnitySerializedDictionary<DlcType, DlcData>
{
	public DlcDataDictionary()
	{
		((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
	}
}
