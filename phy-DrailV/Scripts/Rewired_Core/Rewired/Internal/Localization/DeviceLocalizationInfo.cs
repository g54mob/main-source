using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.Internal.Localization
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal sealed class DeviceLocalizationInfo
	{
		public readonly Guid guid;

		public readonly ControllerType controllerType;

		public readonly bool isControllerTemplate;

		private readonly ReadOnlyList<string> aypLAZjHgvvfwJidbnYiWeiKMnqs;

		private readonly IList<string> VCeEXhAeaEIoxQkmjBHMEEteLqczA;

		private readonly ReadOnlyList<Guid> wzjUqbpoEFFffvphzRLyMHRWldzp;

		private string GvIWBjWHeEzXvnkSUjjFHPimjJeB;

		private Bytes20 sNUrEJShwNRaABDmDGdeZnKxQLPh;

		private bool rCxpMQVgnbHMXbPnzbIJKnLAsxtgA;

		public ReadOnlyList<string> parentKeys => aypLAZjHgvvfwJidbnYiWeiKMnqs;

		public ReadOnlyList<Guid> controllerTemplateGuids => wzjUqbpoEFFffvphzRLyMHRWldzp;

		public string additionalIdentifyingInformation
		{
			get
			{
				return GvIWBjWHeEzXvnkSUjjFHPimjJeB;
			}
			set
			{
				jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
				GvIWBjWHeEzXvnkSUjjFHPimjJeB = value;
			}
		}

		public Bytes20 hash => sNUrEJShwNRaABDmDGdeZnKxQLPh;

		public DeviceLocalizationInfo()
		{
			VCeEXhAeaEIoxQkmjBHMEEteLqczA = new List<string>();
			aypLAZjHgvvfwJidbnYiWeiKMnqs = new ReadOnlyList<string>(VCeEXhAeaEIoxQkmjBHMEEteLqczA);
		}

		public DeviceLocalizationInfo(ControllerType P_0, bool P_1, Guid P_2, IList<string> P_3, IList<Guid> P_4)
		{
			controllerType = P_0;
			isControllerTemplate = P_1;
			guid = P_2;
			IList<string> vCeEXhAeaEIoxQkmjBHMEEteLqczA;
			if (P_3 == null)
			{
				IList<string> list = new List<string>();
				vCeEXhAeaEIoxQkmjBHMEEteLqczA = list;
			}
			else
			{
				vCeEXhAeaEIoxQkmjBHMEEteLqczA = P_3;
			}
			VCeEXhAeaEIoxQkmjBHMEEteLqczA = vCeEXhAeaEIoxQkmjBHMEEteLqczA;
			aypLAZjHgvvfwJidbnYiWeiKMnqs = new ReadOnlyList<string>(VCeEXhAeaEIoxQkmjBHMEEteLqczA);
			if (P_4 != null)
			{
				wzjUqbpoEFFffvphzRLyMHRWldzp = new ReadOnlyList<Guid>(P_4);
			}
		}

		public DeviceLocalizationInfo(DeviceLocalizationInfo P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			guid = P_0.guid;
			controllerType = P_0.controllerType;
			isControllerTemplate = P_0.isControllerTemplate;
			VCeEXhAeaEIoxQkmjBHMEEteLqczA = ((P_0.VCeEXhAeaEIoxQkmjBHMEEteLqczA != null) ? new List<string>(P_0.VCeEXhAeaEIoxQkmjBHMEEteLqczA) : new List<string>());
			aypLAZjHgvvfwJidbnYiWeiKMnqs = new ReadOnlyList<string>(VCeEXhAeaEIoxQkmjBHMEEteLqczA);
			if (P_0.controllerTemplateGuids != null)
			{
				wzjUqbpoEFFffvphzRLyMHRWldzp = new ReadOnlyList<Guid>(P_0.controllerTemplateGuids);
			}
			rCxpMQVgnbHMXbPnzbIJKnLAsxtgA = P_0.rCxpMQVgnbHMXbPnzbIJKnLAsxtgA;
		}

		public void InsertParentKey(int index, string key)
		{
			jHgdLFzMmLjYvBcEPnGErfbqaMhjA();
			if (!string.IsNullOrEmpty(key))
			{
				VCeEXhAeaEIoxQkmjBHMEEteLqczA.Insert(index, key);
			}
		}

		public void FinishRuntimeSetup()
		{
			ComputeHash();
			uhLedAjVNVYAXfGcIiKHDptbdCciB();
		}

		public Bytes20 ComputeHash()
		{
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			sharedStringBuilder.Append(controllerType.ToString());
			sharedStringBuilder.Append(isControllerTemplate.ToString());
			sharedStringBuilder.Append(guid.ToString());
			int count = VCeEXhAeaEIoxQkmjBHMEEteLqczA.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.IsNullOrEmpty(VCeEXhAeaEIoxQkmjBHMEEteLqczA[i]))
				{
					sharedStringBuilder.Append(VCeEXhAeaEIoxQkmjBHMEEteLqczA[i]);
				}
			}
			sharedStringBuilder.Append(GvIWBjWHeEzXvnkSUjjFHPimjJeB);
			sNUrEJShwNRaABDmDGdeZnKxQLPh = MiscTools.HashSHA1(sharedStringBuilder.ToString());
			return sNUrEJShwNRaABDmDGdeZnKxQLPh;
		}

		private void uhLedAjVNVYAXfGcIiKHDptbdCciB()
		{
			rCxpMQVgnbHMXbPnzbIJKnLAsxtgA = true;
		}

		private void jHgdLFzMmLjYvBcEPnGErfbqaMhjA()
		{
			if (rCxpMQVgnbHMXbPnzbIJKnLAsxtgA)
			{
				throw new Exception("Cannot modify a read-only object.");
			}
		}

		public static bool DataMatches(DeviceLocalizationInfo a, DeviceLocalizationInfo b)
		{
			if (a == null || b == null)
			{
				return false;
			}
			if (a.controllerType != b.controllerType || a.isControllerTemplate != b.isControllerTemplate || a.guid != b.guid || a.VCeEXhAeaEIoxQkmjBHMEEteLqczA.Count != b.VCeEXhAeaEIoxQkmjBHMEEteLqczA.Count)
			{
				return false;
			}
			int count = a.VCeEXhAeaEIoxQkmjBHMEEteLqczA.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.Equals(a.VCeEXhAeaEIoxQkmjBHMEEteLqczA[i], b.VCeEXhAeaEIoxQkmjBHMEEteLqczA[i], StringComparison.Ordinal))
				{
					return false;
				}
			}
			int num = ((a.wzjUqbpoEFFffvphzRLyMHRWldzp != null) ? a.wzjUqbpoEFFffvphzRLyMHRWldzp.Count : 0);
			int num2 = ((b.wzjUqbpoEFFffvphzRLyMHRWldzp != null) ? b.wzjUqbpoEFFffvphzRLyMHRWldzp.Count : 0);
			if (num != num2)
			{
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				if (a.wzjUqbpoEFFffvphzRLyMHRWldzp[j] != b.wzjUqbpoEFFffvphzRLyMHRWldzp[j])
				{
					return false;
				}
			}
			return true;
		}
	}
}
