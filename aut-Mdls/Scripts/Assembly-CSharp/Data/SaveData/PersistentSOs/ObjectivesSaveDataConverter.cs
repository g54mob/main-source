using System;
using System.Collections.Generic;
using Data.Shapes;

namespace Data.SaveData.PersistentSOs
{
	public class ObjectivesSaveDataConverter : SaveDataConverter<ObjectiveSaveData>
	{
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public Dictionary<int, List<bool>> ClaimedDeliveryTargets;

			public Dictionary<string, List<bool>> ClaimedModuleChallenges;

			public ISaveVersion ToNextVersion()
			{
				Dictionary<int, int> dictionary = new Dictionary<int, int>(ClaimedDeliveryTargets.Count);
				Dictionary<RotationIndependentHash, int> dictionary2 = new Dictionary<RotationIndependentHash, int>(ClaimedModuleChallenges.Count);
				foreach (KeyValuePair<int, List<bool>> claimedDeliveryTarget in ClaimedDeliveryTargets)
				{
					int num = 0;
					using (List<bool>.Enumerator enumerator2 = claimedDeliveryTarget.Value.GetEnumerator())
					{
						while (enumerator2.MoveNext() && enumerator2.Current)
						{
							num++;
						}
					}
					dictionary.Add(claimedDeliveryTarget.Key, num);
				}
				foreach (KeyValuePair<string, List<bool>> claimedModuleChallenge in ClaimedModuleChallenges)
				{
					int num2 = 0;
					using (List<bool>.Enumerator enumerator2 = claimedModuleChallenge.Value.GetEnumerator())
					{
						while (enumerator2.MoveNext() && enumerator2.Current)
						{
							num2++;
						}
					}
					dictionary2.Add(RotationIndependentHash.Parse(claimedModuleChallenge.Key), num2);
				}
				return new ObjectiveSaveData(dictionary, dictionary2, null);
			}
		}

		public ObjectivesSaveDataConverter()
			: base(1)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			if (version == 0)
			{
				return typeof(Version0);
			}
			return null;
		}
	}
}
