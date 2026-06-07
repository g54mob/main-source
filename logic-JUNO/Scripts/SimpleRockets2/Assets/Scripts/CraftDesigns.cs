using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using UnityEngine;

namespace Assets.Scripts
{
	public class CraftDesigns
	{
		public const string DefaultEditorCraftId = "__editor__";

		public const string NewCraftCareerId = "__new_career__";

		public const string NewCraftSandboxId = "__new__";

		public const string NewPlaneId = "__new_plane__";

		public const string PartIconsCraftId = "__partIcons__";

		private static string _editorCraftId = "__editor__";

		private static string[] _stockCraftIds = new string[22]
		{
			"SimpleATV", "SimpleBeast", "SimpleBot", "SimpleCargo", "SimpleCopter", "SimpleCrew", "SimpleCub", "SimpleDrone", "SimpleFreighter", "SimpleHeavy",
			"SimpleHypersonic", "SimpleMartian", "SimpleOffroad", "SimpleRC", "SimpleRescue", "SimpleRetro", "SimpleSub", "SimpleTrainer", "SimpleTransporter", "SimpleTruck",
			"SimpleVTOL", "Wasp 3.0"
		};

		private XElement _editorCraftDesign;

		private string _userCraftDesignsFolder;

		public static string EditorCraftId
		{
			get
			{
				return _editorCraftId;
			}
			set
			{
				if (_editorCraftId != value)
				{
					_editorCraftId = value;
					Game.Instance.CraftDesigns._editorCraftDesign = null;
				}
			}
		}

		public static string NewCraftId
		{
			get
			{
				if (Game.Instance.GameState.Validator.IsCareerMode)
				{
					return "__new_career__";
				}
				return "__new__";
			}
		}

		public string RootFolderPath => _userCraftDesignsFolder;

		public CraftDesigns(string userCraftDesignsFolder)
		{
			_userCraftDesignsFolder = userCraftDesignsFolder;
		}

		public static bool IsStock(string craftId)
		{
			return _stockCraftIds.Contains(craftId);
		}

		public void DeleteCraftFile(string craftId)
		{
			if (craftId == EditorCraftId)
			{
				_editorCraftDesign = null;
			}
			FileInfo craftFile = GetCraftFile(craftId);
			if (craftFile.Exists)
			{
				try
				{
					craftFile.Delete();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public XElement GetCraftDesign(string craftId)
		{
			if (craftId == EditorCraftId)
			{
				if (_editorCraftDesign == null)
				{
					_editorCraftDesign = LoadDesign(craftId);
				}
				return _editorCraftDesign;
			}
			return LoadDesign(craftId);
		}

		public List<string> GetCraftDesignIds(bool excludeReservedIds = false)
		{
			List<string> list = new List<string>();
			FileInfo[] files = new DirectoryInfo(_userCraftDesignsFolder).GetFiles("*.xml");
			for (int i = 0; i < files.Length; i++)
			{
				string text = files[i].Name.Replace(".xml", string.Empty);
				if (!excludeReservedIds || !text.StartsWith("__"))
				{
					list.Add(text);
				}
			}
			list.Sort();
			return list;
		}

		public FileInfo GetCraftFile(string craftId)
		{
			return new FileInfo(Path.Combine(_userCraftDesignsFolder, craftId + ".xml"));
		}

		public bool HasCraft(string id)
		{
			foreach (string craftDesignId in GetCraftDesignIds())
			{
				if (string.Compare(craftDesignId, id, ignoreCase: true) == 0)
				{
					return true;
				}
			}
			return false;
		}

		public void SaveCraft(string craftId, XElement craftElement)
		{
			FileInfo craftFile = GetCraftFile(craftId);
			new XDocument(craftElement).Save(craftFile.FullName);
			if (craftId == EditorCraftId)
			{
				_editorCraftDesign = craftElement;
			}
		}

		private XElement LoadDesign(string craftId)
		{
			FileInfo craftFile = GetCraftFile(craftId);
			if (craftFile.Exists)
			{
				return CraftLoaderScript.LoadCraftXmlFromBytes(File.ReadAllBytes(craftFile.FullName));
			}
			return null;
		}
	}
}
