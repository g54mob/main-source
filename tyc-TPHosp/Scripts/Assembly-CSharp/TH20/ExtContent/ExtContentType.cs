using I2.Loc;

namespace TH20.ExtContent
{
	public static class ExtContentType
	{
		public static bool IsValid(EContentType contentType)
		{
			if (contentType != EContentType.None && contentType != EContentType.Unknown)
			{
				return contentType != EContentType.NumTypes;
			}
			return false;
		}

		public static EContentType StringToContentType(string contentTypeStr)
		{
			EContentType result = EContentType.Unknown;
			contentTypeStr = contentTypeStr.ToLower();
			int i = 0;
			for (int num = 10; i < num; i++)
			{
				EContentType eContentType = (EContentType)i;
				if (eContentType.ToString().ToLower() == contentTypeStr)
				{
					result = eContentType;
					break;
				}
			}
			return result;
		}

		public static string ContentTypeToString(EContentType contentType)
		{
			return contentType.ToString();
		}

		public static string ContentTypeToStringLoc(EContentType contentType)
		{
			string text = string.Empty;
			switch (contentType)
			{
			case EContentType.Rug:
				text = ScriptLocalization.Menu_UGC_ContentType.Rug_CS;
				break;
			case EContentType.Picture:
				text = ScriptLocalization.Menu_UGC_ContentType.Picture_CS;
				break;
			case EContentType.SandboxSave:
				text = ScriptLocalization.Menu_UGC_ContentType.SandboxHospital_CS;
				break;
			case EContentType.Wall:
				text = ScriptLocalization.Menu_UGC_ContentType.Wall_CS;
				break;
			case EContentType.Floor:
				text = ScriptLocalization.Menu_UGC_ContentType.Floor_CS;
				break;
			case EContentType.MusicPack:
				text = ScriptLocalization.Menu_UGC_ContentType.MusicPack_CS;
				break;
			}
			if (text.IsNullOrEmpty())
			{
				text = ContentTypeToString(contentType);
			}
			return text;
		}
	}
}
