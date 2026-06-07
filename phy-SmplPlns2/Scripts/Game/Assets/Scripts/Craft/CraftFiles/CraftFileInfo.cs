using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.CraftFiles
{
	public class CraftFileInfo
	{
		public class IdComparer : IComparer<CraftFileInfo>
		{
			public static readonly IdComparer Default = new IdComparer();

			public int Compare(CraftFileInfo x, CraftFileInfo y)
			{
				return string.Compare(x?.Id, y?.Id, StringComparison.Ordinal);
			}
		}

		public class IdHashEqualityComparer : IEqualityComparer<CraftFileInfo>
		{
			public static readonly IdHashEqualityComparer Default = new IdHashEqualityComparer();

			public bool Equals(CraftFileInfo x, CraftFileInfo y)
			{
				return x?.IdHash == y?.IdHash;
			}

			public int GetHashCode(CraftFileInfo obj)
			{
				return obj?.IdHash ?? 0;
			}
		}

		private static readonly XmlReaderSettings _xmlReaderSettings = new XmlReaderSettings();

		private Dictionary<AircraftScript.AircraftStats, float> _stats;

		private List<string> _tags;

		private int _xmlVersion = 1;

		public bool Exists { get; private set; }

		public string FileName { get; }

		public string FileNameWithoutExtension { get; }

		public string FullFilePath { get; }

		public string Id { get; }

		public int IdHash { get; }

		public bool IsHidden { get; }

		public bool IsValid { get; private set; }

		public DateTime LastModified { get; private set; }

		public string Name { get; private set; }

		public IReadOnlyDictionary<AircraftScript.AircraftStats, float> Stats => _stats;

		public string SubdirectoryPath { get; }

		public IReadOnlyList<string> Tags => _tags;

		public int XmlVersion => _xmlVersion;

		public CraftFileInfo(string relativePath)
		{
			if (string.IsNullOrWhiteSpace(relativePath))
			{
				throw new ArgumentException("Invalid craft path: '" + (relativePath ?? string.Empty) + "'", "relativePath");
			}
			if (Path.DirectorySeparatorChar != Path.AltDirectorySeparatorChar && relativePath.Contains(Path.AltDirectorySeparatorChar))
			{
				relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			}
			if (relativePath[0] == Path.DirectorySeparatorChar)
			{
				relativePath = relativePath.TrimStart(Path.DirectorySeparatorChar);
				if (string.IsNullOrWhiteSpace(relativePath))
				{
					throw new ArgumentException("Invalid craft path: '" + (relativePath ?? string.Empty) + "'", "relativePath");
				}
			}
			if (relativePath.Length > 0 && relativePath[relativePath.Length - 1] == Path.DirectorySeparatorChar)
			{
				throw new ArgumentException("Invalid craft path: '" + (relativePath ?? string.Empty) + "'", "relativePath");
			}
			Id = relativePath;
			IdHash = relativePath.GetHashCode(StringComparison.OrdinalIgnoreCase);
			FullFilePath = Path.GetFullPath(Path.Combine(Game.Instance.CraftDatabase.CraftFilesRootPath, relativePath));
			FileName = Path.GetFileName(relativePath);
			FileNameWithoutExtension = Path.GetFileNameWithoutExtension(relativePath);
			IsHidden = false;
			if (FileName.Length > 6 && FileName[0] == '_' && FileName[1] == '_')
			{
				int num = FileName.LastIndexOf('.');
				if (num >= 5)
				{
					IsHidden = FileName[num - 1] == '_' && FileName[num - 2] == '_';
				}
			}
			int num2 = relativePath.LastIndexOf(Path.DirectorySeparatorChar);
			SubdirectoryPath = ((num2 >= 0) ? relativePath.Substring(0, num2) : string.Empty);
			_tags = new List<string>();
			_stats = new Dictionary<AircraftScript.AircraftStats, float>();
		}

		public void Delete()
		{
			Game.Instance.CraftDatabase.DeleteCraft(this);
		}

		public override int GetHashCode()
		{
			return IdHash;
		}

		public XElement LoadXml(bool showErrorDialogs)
		{
			return Game.Instance.CraftDatabase.LoadCraftXml(this, showErrorDialogs);
		}

		public void Refresh()
		{
			Exists = false;
			IsValid = false;
			LastModified = DateTime.Now;
			Name = Id;
			_tags.Clear();
			try
			{
				Exists = File.Exists(FullFilePath);
				if (!Exists)
				{
					return;
				}
				RefreshLastModified();
				using FileStream input = File.OpenRead(FullFilePath);
				using XmlReader xmlReader = XmlReader.Create(input, _xmlReaderSettings);
				if (!xmlReader.ReadToFollowing("Aircraft"))
				{
					Debug.LogError("Unable to read the root element of craft file: " + FullFilePath);
					return;
				}
				if (xmlReader.MoveToAttribute("name"))
				{
					Name = xmlReader.Value;
				}
				if (xmlReader.MoveToAttribute("tags"))
				{
					StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(xmlReader.Value, ',').GetEnumerator();
					while (enumerator.MoveNext())
					{
						StringUtility.StringSplitEntry current = enumerator.Current;
						_tags.Add(current);
					}
				}
				if (xmlReader.MoveToAttribute("xmlVersion") && !int.TryParse(xmlReader.Value, out _xmlVersion))
				{
					_xmlVersion = 1;
				}
				if (_xmlVersion >= 23 && xmlReader.ReadToFollowing("Specifications"))
				{
					AircraftScript.AircraftStats[] array = (AircraftScript.AircraftStats[])Enum.GetValues(typeof(AircraftScript.AircraftStats));
					for (int i = 0; i < array.Length; i++)
					{
						AircraftScript.AircraftStats key = array[i];
						if (xmlReader.MoveToAttribute(key.ToString()) && float.TryParse(xmlReader.Value, out var result))
						{
							_stats[key] = result;
						}
					}
				}
				IsValid = true;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Unable to get craft file info. The craft file may be corrupt or invalid. Craft file path: " + FullFilePath);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RefreshLastModified()
		{
			LastModified = File.GetLastWriteTime(FullFilePath).ToLocalTime();
		}

		public CraftFileInfo Rename(string relativePath)
		{
			return Game.Instance.CraftDatabase.RenameCraft(this, relativePath);
		}

		public CraftFileInfo Save(string craftXml, bool backupPreviousFile, bool updateXmlVersion)
		{
			return Game.Instance.CraftDatabase.SaveCraft(Id, craftXml, backupPreviousFile, updateXmlVersion);
		}

		public CraftFileInfo Save(XElement craftXml, bool backupPreviousFile, bool updateXmlVersion)
		{
			return Game.Instance.CraftDatabase.SaveCraft(Id, craftXml, backupPreviousFile, updateXmlVersion);
		}
	}
}
