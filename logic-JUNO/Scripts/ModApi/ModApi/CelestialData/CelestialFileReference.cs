using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;

namespace ModApi.CelestialData
{
	public class CelestialFileReference
	{
		public Guid? FileId { get; }

		public CelestialFilePath FilePath { get; }

		public string LocalId { get; }

		public CelestialFileReference(XElement xml)
		{
			LocalId = xml.GetStringAttribute("id");
			FileId = xml.GetGuidAttributeOrNull("hash");
			FilePath = CelestialFilePath.FromRelativePath(xml.GetStringAttribute("path"));
		}

		public CelestialFileReference(string localId, Guid? fileId, CelestialFilePath filePath)
		{
			LocalId = localId;
			FileId = fileId;
			FilePath = filePath;
		}

		public static CelestialFileReference CreateWithFileId(string localId, CelestialFile file)
		{
			return new CelestialFileReference(localId, file.Id, null);
		}

		public static CelestialFileReference CreateWithFileId(string localId, Guid fileId)
		{
			return new CelestialFileReference(localId, fileId, null);
		}

		public static CelestialFileReference CreateWithFilePath(string localId, CelestialFile file)
		{
			return new CelestialFileReference(localId, null, file.Path);
		}

		public static CelestialFileReference CreateWithFilePath(string localId, CelestialFilePath filePath)
		{
			return new CelestialFileReference(localId, null, filePath);
		}

		public static CelestialFileReference LoadFromXml(XElement element)
		{
			return new CelestialFileReference(element);
		}

		public XElement SaveToXml(string elementName)
		{
			return new XElement(elementName, (LocalId == null) ? null : new XAttribute("id", LocalId), (!FileId.HasValue) ? null : new XAttribute("hash", FileId), (FilePath == null) ? null : new XAttribute("path", FilePath.RelativePath));
		}

		public override string ToString()
		{
			return $"CelestialFileReference {{ LocalId: {LocalId ?? string.Empty}, FileId: {FileId}, FilePath: {FilePath.RelativePath} }}";
		}
	}
}
