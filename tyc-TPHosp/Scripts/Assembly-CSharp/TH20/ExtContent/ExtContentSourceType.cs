namespace TH20.ExtContent
{
	public static class ExtContentSourceType
	{
		public const string cPrefixDelimiter = "#";

		public const int cPrefixStringLen = 2;

		public static bool IsValid(EContentSourceType contentSourceType)
		{
			if (contentSourceType != EContentSourceType.None)
			{
				return contentSourceType != EContentSourceType.NumTypes;
			}
			return false;
		}

		public static string GetContentSourceTypePrefix(EContentSourceType contentSourceType, bool bWithDelemiter = false)
		{
			string text = "?";
			switch (contentSourceType)
			{
			case EContentSourceType.Workshop:
				text = "W";
				break;
			case EContentSourceType.LocalMods:
				text = "L";
				break;
			}
			if (bWithDelemiter)
			{
				text += "#";
			}
			return text;
		}

		public static EContentSourceType GetContentSourceTypeFromPrefix(string inStr)
		{
			EContentSourceType result = EContentSourceType.None;
			int num = 1;
			if (num < inStr.Length && inStr.Substring(num, 1) == "#")
			{
				if (inStr.StartsWith("W"))
				{
					result = EContentSourceType.Workshop;
				}
				else if (inStr.StartsWith("L"))
				{
					result = EContentSourceType.LocalMods;
				}
			}
			return result;
		}

		public static bool EnsureValidSourceTypePrefix(EContentSourceType contentSourceType, ref string retStr)
		{
			bool result = false;
			if (!retStr.IsNullOrEmpty())
			{
				string contentSourceTypePrefix = GetContentSourceTypePrefix(contentSourceType, bWithDelemiter: true);
				if (!retStr.StartsWith(contentSourceTypePrefix))
				{
					if (retStr.Substring(1, 1) == "#")
					{
						retStr = retStr.Substring(2);
					}
					retStr = contentSourceTypePrefix + retStr;
					result = true;
				}
			}
			return result;
		}

		public static EContentSourceType StringToContentSourceType(string contentSourceTypeStr)
		{
			EContentSourceType result = EContentSourceType.None;
			contentSourceTypeStr = contentSourceTypeStr.ToLower();
			int i = 0;
			for (int num = 3; i < num; i++)
			{
				EContentSourceType eContentSourceType = (EContentSourceType)i;
				if (eContentSourceType.ToString().ToLower() == contentSourceTypeStr)
				{
					result = eContentSourceType;
					break;
				}
			}
			return result;
		}

		public static string ContentSourceTypeToString(EContentSourceType contentSourceType)
		{
			return contentSourceType.ToString();
		}
	}
}
