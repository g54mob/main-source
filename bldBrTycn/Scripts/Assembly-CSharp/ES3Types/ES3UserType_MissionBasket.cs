using System.Collections.Generic;
using CTS;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_MissionBasket : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MissionBasket()
			: base(typeof(MissionBasket))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MissionBasket missionBasket = (MissionBasket)obj;
			if ((bool)missionBasket.CurrentMission)
			{
				writer.WriteAssetReference("CurrentMission", missionBasket.CurrentMission);
			}
			if (missionBasket.CurrentMissionStatus.Count <= 0)
			{
				return;
			}
			Dictionary<AssetRef<StockItemSO>, MissionBasket.MissionItemCapacity> dictionary = new Dictionary<AssetRef<StockItemSO>, MissionBasket.MissionItemCapacity>();
			foreach (var (stockItemSO2, value) in missionBasket.CurrentMissionStatus)
			{
				if ((bool)stockItemSO2)
				{
					dictionary[stockItemSO2] = value;
				}
			}
			if (dictionary.Count > 0)
			{
				writer.WriteProperty("MissionStatus", dictionary);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MissionBasket missionBasket = (MissionBasket)obj;
			StockMissionData stockMissionData = null;
			Dictionary<StockItemSO, MissionBasket.MissionItemCapacity> dictionary = new Dictionary<StockItemSO, MissionBasket.MissionItemCapacity>();
			foreach (string property in reader.Properties)
			{
				if (!(property == "CurrentMission"))
				{
					if (property == "MissionStatus")
					{
						foreach (var (assetRef2, value) in reader.Read<Dictionary<AssetRef<StockItemSO>, MissionBasket.MissionItemCapacity>>())
						{
							if ((bool)assetRef2.Asset)
							{
								dictionary[assetRef2.Asset] = value;
							}
						}
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					stockMissionData = reader.ReadAssetReference<StockMissionData>();
				}
			}
			if (!missionBasket.HasMission() && (bool)stockMissionData)
			{
				missionBasket.SetMission(stockMissionData, dictionary);
			}
		}
	}
}
