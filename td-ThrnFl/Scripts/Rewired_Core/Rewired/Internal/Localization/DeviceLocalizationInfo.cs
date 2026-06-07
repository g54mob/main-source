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

		private readonly ReadOnlyList<string> QJVVkyXGPGYZBOhGEsJAvQbMhZvDA;

		private readonly IList<string> oRFUcOHarpqiHQncRpiSJAWuzTFb;

		private readonly ReadOnlyList<Guid> ALxYVEHXbacJHzKAsSxZGvlarCQT;

		private string IgXpvkILacIJkuIAaVoMMAGTEqdn;

		private Bytes20 TNzpoGQkPCYDgoGiPHFKRdycigjE;

		private bool YyuIcsvEmSmvaxXyJajPRbQhQaqW;

		public ReadOnlyList<string> parentKeys => QJVVkyXGPGYZBOhGEsJAvQbMhZvDA;

		public ReadOnlyList<Guid> controllerTemplateGuids => ALxYVEHXbacJHzKAsSxZGvlarCQT;

		public string additionalIdentifyingInformation
		{
			get
			{
				return IgXpvkILacIJkuIAaVoMMAGTEqdn;
			}
			set
			{
				YauZKugTkVllYPeRwlqAWfDnenSe();
				IgXpvkILacIJkuIAaVoMMAGTEqdn = value;
			}
		}

		public Bytes20 hash => TNzpoGQkPCYDgoGiPHFKRdycigjE;

		public DeviceLocalizationInfo()
		{
			oRFUcOHarpqiHQncRpiSJAWuzTFb = new List<string>();
			QJVVkyXGPGYZBOhGEsJAvQbMhZvDA = new ReadOnlyList<string>(oRFUcOHarpqiHQncRpiSJAWuzTFb);
		}

		public DeviceLocalizationInfo(ControllerType P_0, bool P_1, Guid P_2, IList<string> P_3, IList<Guid> P_4)
		{
			controllerType = P_0;
			isControllerTemplate = P_1;
			guid = P_2;
			IList<string> list2;
			if (P_3 == null)
			{
				IList<string> list = new List<string>();
				list2 = list;
			}
			else
			{
				list2 = P_3;
			}
			oRFUcOHarpqiHQncRpiSJAWuzTFb = list2;
			QJVVkyXGPGYZBOhGEsJAvQbMhZvDA = new ReadOnlyList<string>(oRFUcOHarpqiHQncRpiSJAWuzTFb);
			if (P_4 != null)
			{
				ALxYVEHXbacJHzKAsSxZGvlarCQT = new ReadOnlyList<Guid>(P_4);
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
			oRFUcOHarpqiHQncRpiSJAWuzTFb = ((P_0.oRFUcOHarpqiHQncRpiSJAWuzTFb != null) ? new List<string>(P_0.oRFUcOHarpqiHQncRpiSJAWuzTFb) : new List<string>());
			QJVVkyXGPGYZBOhGEsJAvQbMhZvDA = new ReadOnlyList<string>(oRFUcOHarpqiHQncRpiSJAWuzTFb);
			if (P_0.controllerTemplateGuids != null)
			{
				ALxYVEHXbacJHzKAsSxZGvlarCQT = new ReadOnlyList<Guid>(P_0.controllerTemplateGuids);
			}
			YyuIcsvEmSmvaxXyJajPRbQhQaqW = P_0.YyuIcsvEmSmvaxXyJajPRbQhQaqW;
		}

		public void InsertParentKey(int index, string key)
		{
			YauZKugTkVllYPeRwlqAWfDnenSe();
			if (!string.IsNullOrEmpty(key))
			{
				oRFUcOHarpqiHQncRpiSJAWuzTFb.Insert(index, key);
			}
		}

		public void FinishRuntimeSetup()
		{
			ComputeHash();
			OMpGmXiRjrGmkxOvtxVAwGxGeBgB();
		}

		public Bytes20 ComputeHash()
		{
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			sharedStringBuilder.Append(controllerType.ToString());
			bool flag = isControllerTemplate;
			sharedStringBuilder.Append(flag.ToString());
			sharedStringBuilder.Append(guid.ToString());
			int count = oRFUcOHarpqiHQncRpiSJAWuzTFb.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.IsNullOrEmpty(oRFUcOHarpqiHQncRpiSJAWuzTFb[i]))
				{
					sharedStringBuilder.Append(oRFUcOHarpqiHQncRpiSJAWuzTFb[i]);
				}
			}
			sharedStringBuilder.Append(IgXpvkILacIJkuIAaVoMMAGTEqdn);
			TNzpoGQkPCYDgoGiPHFKRdycigjE = MiscTools.HashSHA1(sharedStringBuilder.ToString());
			return TNzpoGQkPCYDgoGiPHFKRdycigjE;
		}

		private void OMpGmXiRjrGmkxOvtxVAwGxGeBgB()
		{
			YyuIcsvEmSmvaxXyJajPRbQhQaqW = true;
		}

		private void YauZKugTkVllYPeRwlqAWfDnenSe()
		{
			if (YyuIcsvEmSmvaxXyJajPRbQhQaqW)
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
			if (a.controllerType != b.controllerType || a.isControllerTemplate != b.isControllerTemplate || a.guid != b.guid || a.oRFUcOHarpqiHQncRpiSJAWuzTFb.Count != b.oRFUcOHarpqiHQncRpiSJAWuzTFb.Count)
			{
				return false;
			}
			int count = a.oRFUcOHarpqiHQncRpiSJAWuzTFb.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.Equals(a.oRFUcOHarpqiHQncRpiSJAWuzTFb[i], b.oRFUcOHarpqiHQncRpiSJAWuzTFb[i], StringComparison.Ordinal))
				{
					return false;
				}
			}
			int num = ((a.ALxYVEHXbacJHzKAsSxZGvlarCQT != null) ? a.ALxYVEHXbacJHzKAsSxZGvlarCQT.Count : 0);
			int num2 = ((b.ALxYVEHXbacJHzKAsSxZGvlarCQT != null) ? b.ALxYVEHXbacJHzKAsSxZGvlarCQT.Count : 0);
			if (num != num2)
			{
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				if (a.ALxYVEHXbacJHzKAsSxZGvlarCQT[j] != b.ALxYVEHXbacJHzKAsSxZGvlarCQT[j])
				{
					return false;
				}
			}
			return true;
		}
	}
}
