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

		private readonly ReadOnlyList<string> tHlXBMJZSOIIGphXgEfxirQwnDwAA;

		private readonly IList<string> PbxbEqLnatfpptgSxZNYLzmcvQMb;

		private readonly ReadOnlyList<Guid> flHxisTsioWOWYKJEjLueIMGiYDKA;

		private string jJrYGCWMboXMtDzRGxIlKorpgFql;

		private Bytes20 uADKOOOvhWNCAPHltpOhPWuSwawC;

		private bool xuCENUhOlWhkrkIlbzXeLLhPzghS;

		public ReadOnlyList<string> parentKeys => tHlXBMJZSOIIGphXgEfxirQwnDwAA;

		public ReadOnlyList<Guid> controllerTemplateGuids => flHxisTsioWOWYKJEjLueIMGiYDKA;

		public string additionalIdentifyingInformation
		{
			get
			{
				return jJrYGCWMboXMtDzRGxIlKorpgFql;
			}
			set
			{
				vGKyEHkKNVoBQghYbXtNCQNneTZA();
				jJrYGCWMboXMtDzRGxIlKorpgFql = value;
			}
		}

		public Bytes20 hash => uADKOOOvhWNCAPHltpOhPWuSwawC;

		public DeviceLocalizationInfo()
		{
			PbxbEqLnatfpptgSxZNYLzmcvQMb = new List<string>();
			tHlXBMJZSOIIGphXgEfxirQwnDwAA = new ReadOnlyList<string>(PbxbEqLnatfpptgSxZNYLzmcvQMb);
		}

		public DeviceLocalizationInfo(ControllerType P_0, bool P_1, Guid P_2, IList<string> P_3, IList<Guid> P_4)
		{
			controllerType = P_0;
			isControllerTemplate = P_1;
			guid = P_2;
			IList<string> pbxbEqLnatfpptgSxZNYLzmcvQMb;
			if (P_3 == null)
			{
				IList<string> list = new List<string>();
				pbxbEqLnatfpptgSxZNYLzmcvQMb = list;
			}
			else
			{
				pbxbEqLnatfpptgSxZNYLzmcvQMb = P_3;
			}
			PbxbEqLnatfpptgSxZNYLzmcvQMb = pbxbEqLnatfpptgSxZNYLzmcvQMb;
			tHlXBMJZSOIIGphXgEfxirQwnDwAA = new ReadOnlyList<string>(PbxbEqLnatfpptgSxZNYLzmcvQMb);
			if (P_4 != null)
			{
				flHxisTsioWOWYKJEjLueIMGiYDKA = new ReadOnlyList<Guid>(P_4);
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
			PbxbEqLnatfpptgSxZNYLzmcvQMb = ((P_0.PbxbEqLnatfpptgSxZNYLzmcvQMb != null) ? new List<string>(P_0.PbxbEqLnatfpptgSxZNYLzmcvQMb) : new List<string>());
			tHlXBMJZSOIIGphXgEfxirQwnDwAA = new ReadOnlyList<string>(PbxbEqLnatfpptgSxZNYLzmcvQMb);
			if (P_0.controllerTemplateGuids != null)
			{
				flHxisTsioWOWYKJEjLueIMGiYDKA = new ReadOnlyList<Guid>(P_0.controllerTemplateGuids);
			}
			xuCENUhOlWhkrkIlbzXeLLhPzghS = P_0.xuCENUhOlWhkrkIlbzXeLLhPzghS;
		}

		public void InsertParentKey(int index, string key)
		{
			vGKyEHkKNVoBQghYbXtNCQNneTZA();
			if (!string.IsNullOrEmpty(key))
			{
				PbxbEqLnatfpptgSxZNYLzmcvQMb.Insert(index, key);
			}
		}

		public void FinishRuntimeSetup()
		{
			ComputeHash();
			zZHjMVcSEhBvhSVQVNqUuruxmCcb();
		}

		public Bytes20 ComputeHash()
		{
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			sharedStringBuilder.Append(controllerType.ToString());
			bool flag = isControllerTemplate;
			sharedStringBuilder.Append(flag.ToString());
			sharedStringBuilder.Append(guid.ToString());
			int count = PbxbEqLnatfpptgSxZNYLzmcvQMb.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.IsNullOrEmpty(PbxbEqLnatfpptgSxZNYLzmcvQMb[i]))
				{
					sharedStringBuilder.Append(PbxbEqLnatfpptgSxZNYLzmcvQMb[i]);
				}
			}
			sharedStringBuilder.Append(jJrYGCWMboXMtDzRGxIlKorpgFql);
			uADKOOOvhWNCAPHltpOhPWuSwawC = MiscTools.HashSHA1(sharedStringBuilder.ToString());
			return uADKOOOvhWNCAPHltpOhPWuSwawC;
		}

		private void zZHjMVcSEhBvhSVQVNqUuruxmCcb()
		{
			xuCENUhOlWhkrkIlbzXeLLhPzghS = true;
		}

		private void vGKyEHkKNVoBQghYbXtNCQNneTZA()
		{
			if (xuCENUhOlWhkrkIlbzXeLLhPzghS)
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
			if (a.controllerType != b.controllerType || a.isControllerTemplate != b.isControllerTemplate || a.guid != b.guid || a.PbxbEqLnatfpptgSxZNYLzmcvQMb.Count != b.PbxbEqLnatfpptgSxZNYLzmcvQMb.Count)
			{
				return false;
			}
			int count = a.PbxbEqLnatfpptgSxZNYLzmcvQMb.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.Equals(a.PbxbEqLnatfpptgSxZNYLzmcvQMb[i], b.PbxbEqLnatfpptgSxZNYLzmcvQMb[i], StringComparison.Ordinal))
				{
					return false;
				}
			}
			int num = ((a.flHxisTsioWOWYKJEjLueIMGiYDKA != null) ? a.flHxisTsioWOWYKJEjLueIMGiYDKA.Count : 0);
			int num2 = ((b.flHxisTsioWOWYKJEjLueIMGiYDKA != null) ? b.flHxisTsioWOWYKJEjLueIMGiYDKA.Count : 0);
			if (num != num2)
			{
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				if (a.flHxisTsioWOWYKJEjLueIMGiYDKA[j] != b.flHxisTsioWOWYKJEjLueIMGiYDKA[j])
				{
					return false;
				}
			}
			return true;
		}
	}
}
