using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class DeviceLocalizationInfo
	{
		public readonly Guid guid;

		public readonly ControllerType controllerType;

		public readonly bool isControllerTemplate;

		private readonly ReadOnlyList<string> dxlyuUBMzfpeDODepsvNvhodfdIp;

		private readonly IList<string> TEdeGILgIYQUsSNHewSzNZDvnFgq;

		private readonly ReadOnlyList<Guid> rRFBhaBNRLlWRlSaLICOCOiBirtJ;

		private string zuxspQSWOBVwuwKcXogFOMFiUsYk;

		private Bytes20 igJFnQSgYhwkBoWqevyRBUkLqQYt;

		private bool ffAoQrhAnrDiFvMgcMYuVJxESZhc;

		public ReadOnlyList<string> parentKeys => null;

		public ReadOnlyList<Guid> controllerTemplateGuids => null;

		public string additionalIdentifyingInformation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Bytes20 hash => default(Bytes20);

		public DeviceLocalizationInfo()
		{
		}

		public DeviceLocalizationInfo(ControllerType P_0, bool P_1, Guid P_2, IList<string> P_3, IList<Guid> P_4)
		{
		}

		public DeviceLocalizationInfo(DeviceLocalizationInfo P_0)
		{
		}

		public void InsertParentKey(int index, string key)
		{
		}

		public void FinishRuntimeSetup()
		{
		}

		public Bytes20 ComputeHash()
		{
			return default(Bytes20);
		}

		private void hAHlWOoaxKDmuKbuYpMUhyPvqYaBA()
		{
		}

		private void xMGhNAgsfiyPQPHCBNURILgKCIjt()
		{
		}

		public static bool DataMatches(DeviceLocalizationInfo a, DeviceLocalizationInfo b)
		{
			return false;
		}
	}
}
