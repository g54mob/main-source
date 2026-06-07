using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Sharing
{
	public class ZipHelper : IDisposable
	{
		private const int CompressionLevel = 5;

		private bool _disposedValue;

		private string _tempFileName;

		private string _tempFullyQualified;

		private static string TempFolder
		{
			get
			{
				string text = Path.Combine(Application.persistentDataPath, "Temp");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				return text;
			}
		}

		public ZipHelper()
		{
			_tempFileName = $"{Guid.NewGuid().ToString()}.zip";
			_tempFullyQualified = Path.Combine(TempFolder, _tempFileName);
		}

		~ZipHelper()
		{
			Dispose(disposing: false);
		}

		public static void CleanTempFolder()
		{
			Directory.Delete(TempFolder);
		}

		public void AddFileBytes(byte[] bytes, string fileName)
		{
			lzip.buffer2File(5, _tempFullyQualified, fileName, bytes, append: true);
		}

		public void AddTextFile(string fileName, string text)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(text);
			AddFileBytes(bytes, fileName);
		}

		public void AddXml(string fileName, XDocument doc)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(doc.ToString());
			AddFileBytes(bytes, fileName);
		}

		public void AddXml(string fileName, XElement doc)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(doc.ToString());
			AddFileBytes(bytes, fileName);
		}

		public void AddXmlFile(string fileName, string xml)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(xml);
			AddFileBytes(bytes, fileName);
		}

		public void AddXmlRange(Dictionary<string, XDocument> values)
		{
			foreach (KeyValuePair<string, XDocument> value in values)
			{
				AddXml(value.Key, value.Value);
			}
		}

		public void AddXmlRange(Dictionary<string, XElement> values)
		{
			foreach (KeyValuePair<string, XElement> value in values)
			{
				AddXml(value.Key, value.Value);
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public byte[] GetBytes()
		{
			return File.ReadAllBytes(_tempFullyQualified);
		}

		public void Save(string fullyQualifiedPath)
		{
			File.Move(_tempFullyQualified, fullyQualifiedPath);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				CleanTemporary();
				_disposedValue = true;
			}
		}

		private void CleanTemporary()
		{
			if (File.Exists(_tempFullyQualified))
			{
				File.Delete(_tempFullyQualified);
			}
		}
	}
}
