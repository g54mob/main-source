namespace Assets.Scripts.Sharing
{
	public class BinaryDataUploadContent
	{
		public byte[] Data { get; set; }

		public string FieldName { get; set; }

		public string FileName { get; set; }

		public string MimeType
		{
			get
			{
				switch (Type)
				{
				case BinaryDataUploadContentType.Jpg:
					return "image/jpeg";
				case BinaryDataUploadContentType.Png:
					return "image/png";
				case BinaryDataUploadContentType.Text:
				case BinaryDataUploadContentType.Xml:
					return "text/xml";
				default:
					return "application/octet-stream";
				}
			}
		}

		public BinaryDataUploadContentType Type { get; set; }

		public BinaryDataUploadContent(byte[] data, string fieldName, string fileName, BinaryDataUploadContentType type)
		{
			Data = data;
			FieldName = fieldName;
			FileName = fileName;
			Type = type;
		}
	}
}
