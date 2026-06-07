using System.Collections.Generic;
using System.Linq;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/CouplerStateSaveGameUpgrade (v12 -> v13)")]
public class Upgrade_V12_to_V13_CouplerStateSaveGame : ASaveSnapshotUpgrader
{
	public override int InputVersion => 12;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		foreach (KeyValuePair<string, JToken> datum in data)
		{
			if (!datum.Key.StartsWith("Cars#") || !(datum.Value is JObject jObject))
			{
				continue;
			}
			foreach (JObject item in (jObject["carsData"] as JArray).Cast<JObject>())
			{
				item.SetInt("couplerStateF", (int)CouplerState(item.GetBool("coupledF") == true));
				item.Remove("coupledF");
				item.SetInt("couplerStateR", (int)CouplerState(item.GetBool("coupledR") == true));
				item.Remove("coupledR");
			}
		}
		return data;
		ChainCouplerInteraction.State CouplerState(bool oldCoupled)
		{
			if (!oldCoupled)
			{
				return ChainCouplerInteraction.State.Parked;
			}
			return ChainCouplerInteraction.State.Attached_Tight;
		}
	}
}
