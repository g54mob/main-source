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

		private readonly ReadOnlyList<string> hjdMFRlZuGgWsSrbzVoEyHMXbAwz;

		private readonly IList<string> NbjfbTzoVtfpNYEKwYCkUkpDCcSFA;

		private readonly ReadOnlyList<Guid> toVQuxdSAkxQmllnXwCZFJStzFBN;

		private string hLlUQJeAJwJLXgfnTeeEFOpWgrqR;

		private Bytes20 wZLBGVgWDELZwgztilwGMaKrZngv;

		private bool bbWGTLFVLArqZDrJwxODoQjkyhdeA;

		public ReadOnlyList<string> parentKeys => hjdMFRlZuGgWsSrbzVoEyHMXbAwz;

		public ReadOnlyList<Guid> controllerTemplateGuids => toVQuxdSAkxQmllnXwCZFJStzFBN;

		public string additionalIdentifyingInformation
		{
			get
			{
				return hLlUQJeAJwJLXgfnTeeEFOpWgrqR;
			}
			set
			{
				jtSAgTAbuVwmpJNJJCUOALKqofHpA();
				hLlUQJeAJwJLXgfnTeeEFOpWgrqR = value;
			}
		}

		public Bytes20 hash => wZLBGVgWDELZwgztilwGMaKrZngv;

		public DeviceLocalizationInfo()
		{
			NbjfbTzoVtfpNYEKwYCkUkpDCcSFA = new List<string>();
			hjdMFRlZuGgWsSrbzVoEyHMXbAwz = new ReadOnlyList<string>(NbjfbTzoVtfpNYEKwYCkUkpDCcSFA);
		}

		public DeviceLocalizationInfo(ControllerType P_0, bool P_1, Guid P_2, IList<string> P_3, IList<Guid> P_4)
		{
			controllerType = P_0;
			isControllerTemplate = P_1;
			guid = P_2;
			IList<string> nbjfbTzoVtfpNYEKwYCkUkpDCcSFA;
			if (P_3 == null)
			{
				IList<string> list = new List<string>();
				nbjfbTzoVtfpNYEKwYCkUkpDCcSFA = list;
			}
			else
			{
				nbjfbTzoVtfpNYEKwYCkUkpDCcSFA = P_3;
			}
			NbjfbTzoVtfpNYEKwYCkUkpDCcSFA = nbjfbTzoVtfpNYEKwYCkUkpDCcSFA;
			hjdMFRlZuGgWsSrbzVoEyHMXbAwz = new ReadOnlyList<string>(NbjfbTzoVtfpNYEKwYCkUkpDCcSFA);
			if (P_4 != null)
			{
				toVQuxdSAkxQmllnXwCZFJStzFBN = new ReadOnlyList<Guid>(P_4);
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
			NbjfbTzoVtfpNYEKwYCkUkpDCcSFA = ((P_0.NbjfbTzoVtfpNYEKwYCkUkpDCcSFA != null) ? new List<string>(P_0.NbjfbTzoVtfpNYEKwYCkUkpDCcSFA) : new List<string>());
			hjdMFRlZuGgWsSrbzVoEyHMXbAwz = new ReadOnlyList<string>(NbjfbTzoVtfpNYEKwYCkUkpDCcSFA);
			if (P_0.controllerTemplateGuids != null)
			{
				toVQuxdSAkxQmllnXwCZFJStzFBN = new ReadOnlyList<Guid>(P_0.controllerTemplateGuids);
			}
			bbWGTLFVLArqZDrJwxODoQjkyhdeA = P_0.bbWGTLFVLArqZDrJwxODoQjkyhdeA;
		}

		public void InsertParentKey(int index, string key)
		{
			jtSAgTAbuVwmpJNJJCUOALKqofHpA();
			if (!string.IsNullOrEmpty(key))
			{
				NbjfbTzoVtfpNYEKwYCkUkpDCcSFA.Insert(index, key);
			}
		}

		public void FinishRuntimeSetup()
		{
			ComputeHash();
			zfZfKPEikbhVHpKvIoATzvfDPrCP();
		}

		public Bytes20 ComputeHash()
		{
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			sharedStringBuilder.Append(controllerType.ToString());
			bool flag = isControllerTemplate;
			sharedStringBuilder.Append(flag.ToString());
			sharedStringBuilder.Append(guid.ToString());
			int count = NbjfbTzoVtfpNYEKwYCkUkpDCcSFA.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.IsNullOrEmpty(NbjfbTzoVtfpNYEKwYCkUkpDCcSFA[i]))
				{
					sharedStringBuilder.Append(NbjfbTzoVtfpNYEKwYCkUkpDCcSFA[i]);
				}
			}
			sharedStringBuilder.Append(hLlUQJeAJwJLXgfnTeeEFOpWgrqR);
			wZLBGVgWDELZwgztilwGMaKrZngv = MiscTools.HashSHA1(sharedStringBuilder.ToString());
			return wZLBGVgWDELZwgztilwGMaKrZngv;
		}

		private void zfZfKPEikbhVHpKvIoATzvfDPrCP()
		{
			bbWGTLFVLArqZDrJwxODoQjkyhdeA = true;
		}

		private void jtSAgTAbuVwmpJNJJCUOALKqofHpA()
		{
			if (bbWGTLFVLArqZDrJwxODoQjkyhdeA)
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
			if (a.controllerType != b.controllerType || a.isControllerTemplate != b.isControllerTemplate || a.guid != b.guid || a.NbjfbTzoVtfpNYEKwYCkUkpDCcSFA.Count != b.NbjfbTzoVtfpNYEKwYCkUkpDCcSFA.Count)
			{
				return false;
			}
			int count = a.NbjfbTzoVtfpNYEKwYCkUkpDCcSFA.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.Equals(a.NbjfbTzoVtfpNYEKwYCkUkpDCcSFA[i], b.NbjfbTzoVtfpNYEKwYCkUkpDCcSFA[i], StringComparison.Ordinal))
				{
					return false;
				}
			}
			int num = ((a.toVQuxdSAkxQmllnXwCZFJStzFBN != null) ? a.toVQuxdSAkxQmllnXwCZFJStzFBN.Count : 0);
			int num2 = ((b.toVQuxdSAkxQmllnXwCZFJStzFBN != null) ? b.toVQuxdSAkxQmllnXwCZFJStzFBN.Count : 0);
			if (num != num2)
			{
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				if (a.toVQuxdSAkxQmllnXwCZFJStzFBN[j] != b.toVQuxdSAkxQmllnXwCZFJStzFBN[j])
				{
					return false;
				}
			}
			return true;
		}
	}
}
