using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Utils;
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

		private readonly ReadOnlyList<string> uOeDFEUBaGgbDFNpTUloYDAFjHTe;

		private readonly IList<string> CFIZbNUxqtiFGDDuMXqTcVoRqZhU;

		private readonly ReadOnlyList<Guid> swagbhSfrkmzdoTGryaahXUpwTmE;

		private string cYUHQBXageGbMgrHvbCvYbkWrQPaA;

		private Bytes20 bdwxSRJqgANptriRWmAzymNvZMTm;

		private bool cMpBbXcbuIeUYscbSDegcmkgyACkA;

		public ReadOnlyList<string> parentKeys => uOeDFEUBaGgbDFNpTUloYDAFjHTe;

		public ReadOnlyList<Guid> controllerTemplateGuids => swagbhSfrkmzdoTGryaahXUpwTmE;

		public string additionalIdentifyingInformation
		{
			get
			{
				return cYUHQBXageGbMgrHvbCvYbkWrQPaA;
			}
			set
			{
				kUdzsRniNDPKkYxrdRsnnsXafMaW();
				cYUHQBXageGbMgrHvbCvYbkWrQPaA = value;
			}
		}

		public Bytes20 hash => bdwxSRJqgANptriRWmAzymNvZMTm;

		public DeviceLocalizationInfo()
		{
			CFIZbNUxqtiFGDDuMXqTcVoRqZhU = new List<string>();
			uOeDFEUBaGgbDFNpTUloYDAFjHTe = new ReadOnlyList<string>(CFIZbNUxqtiFGDDuMXqTcVoRqZhU);
		}

		public DeviceLocalizationInfo(ControllerType P_0, bool P_1, Guid P_2, IList<string> P_3, IList<Guid> P_4)
		{
			controllerType = P_0;
			isControllerTemplate = P_1;
			guid = P_2;
			IList<string> cFIZbNUxqtiFGDDuMXqTcVoRqZhU;
			if (P_3 == null)
			{
				IList<string> list = new List<string>();
				cFIZbNUxqtiFGDDuMXqTcVoRqZhU = list;
			}
			else
			{
				cFIZbNUxqtiFGDDuMXqTcVoRqZhU = P_3;
			}
			CFIZbNUxqtiFGDDuMXqTcVoRqZhU = cFIZbNUxqtiFGDDuMXqTcVoRqZhU;
			uOeDFEUBaGgbDFNpTUloYDAFjHTe = new ReadOnlyList<string>(CFIZbNUxqtiFGDDuMXqTcVoRqZhU);
			if (P_4 != null)
			{
				swagbhSfrkmzdoTGryaahXUpwTmE = new ReadOnlyList<Guid>(P_4);
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
			CFIZbNUxqtiFGDDuMXqTcVoRqZhU = ((P_0.CFIZbNUxqtiFGDDuMXqTcVoRqZhU != null) ? new List<string>(P_0.CFIZbNUxqtiFGDDuMXqTcVoRqZhU) : new List<string>());
			uOeDFEUBaGgbDFNpTUloYDAFjHTe = new ReadOnlyList<string>(CFIZbNUxqtiFGDDuMXqTcVoRqZhU);
			if (P_0.controllerTemplateGuids != null)
			{
				swagbhSfrkmzdoTGryaahXUpwTmE = new ReadOnlyList<Guid>(P_0.controllerTemplateGuids);
			}
			cMpBbXcbuIeUYscbSDegcmkgyACkA = P_0.cMpBbXcbuIeUYscbSDegcmkgyACkA;
		}

		public void InsertParentKey(int index, string key)
		{
			kUdzsRniNDPKkYxrdRsnnsXafMaW();
			if (!string.IsNullOrEmpty(key))
			{
				CFIZbNUxqtiFGDDuMXqTcVoRqZhU.Insert(index, key);
			}
		}

		public void FinishRuntimeSetup()
		{
			ComputeHash();
			ahuWjNtYFfvxKeBZmBkchVaLAQhWA();
		}

		public Bytes20 ComputeHash()
		{
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			sharedStringBuilder.Append(controllerType.ToString());
			bool flag = isControllerTemplate;
			sharedStringBuilder.Append(flag.ToString());
			sharedStringBuilder.Append(guid.ToString());
			int count = CFIZbNUxqtiFGDDuMXqTcVoRqZhU.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.IsNullOrEmpty(CFIZbNUxqtiFGDDuMXqTcVoRqZhU[i]))
				{
					sharedStringBuilder.Append(CFIZbNUxqtiFGDDuMXqTcVoRqZhU[i]);
				}
			}
			sharedStringBuilder.Append(cYUHQBXageGbMgrHvbCvYbkWrQPaA);
			bdwxSRJqgANptriRWmAzymNvZMTm = MiscTools.HashSHA1(sharedStringBuilder.ToString());
			return bdwxSRJqgANptriRWmAzymNvZMTm;
		}

		private void ahuWjNtYFfvxKeBZmBkchVaLAQhWA()
		{
			cMpBbXcbuIeUYscbSDegcmkgyACkA = true;
		}

		private void kUdzsRniNDPKkYxrdRsnnsXafMaW()
		{
			if (cMpBbXcbuIeUYscbSDegcmkgyACkA)
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
			if (a.controllerType != b.controllerType || a.isControllerTemplate != b.isControllerTemplate || a.guid != b.guid || a.CFIZbNUxqtiFGDDuMXqTcVoRqZhU.Count != b.CFIZbNUxqtiFGDDuMXqTcVoRqZhU.Count)
			{
				return false;
			}
			int count = a.CFIZbNUxqtiFGDDuMXqTcVoRqZhU.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.Equals(a.CFIZbNUxqtiFGDDuMXqTcVoRqZhU[i], b.CFIZbNUxqtiFGDDuMXqTcVoRqZhU[i], StringComparison.Ordinal))
				{
					return false;
				}
			}
			int num = ((a.swagbhSfrkmzdoTGryaahXUpwTmE != null) ? a.swagbhSfrkmzdoTGryaahXUpwTmE.Count : 0);
			int num2 = ((b.swagbhSfrkmzdoTGryaahXUpwTmE != null) ? b.swagbhSfrkmzdoTGryaahXUpwTmE.Count : 0);
			if (num != num2)
			{
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				if (a.swagbhSfrkmzdoTGryaahXUpwTmE[j] != b.swagbhSfrkmzdoTGryaahXUpwTmE[j])
				{
					return false;
				}
			}
			return true;
		}
	}
}
