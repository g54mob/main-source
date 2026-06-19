using System;
using System.Collections.Generic;
using System.IO;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public static class AssetIDMappingCSVGenerator
	{
		public static void GenerateAssetIDCSVFile(ISharedInstance rootObject, string filePath)
		{
			List<AssetIDMapping.ToVisit> list = new List<AssetIDMapping.ToVisit>();
			AssetIDMapping.GenerateExternalReferencesListInternal(new AssetIDMapping.ToVisit(rootObject, rootObject.GetID, ""), list);
			list.Sort((AssetIDMapping.ToVisit x, AssetIDMapping.ToVisit y) => Mathf.Clamp(x.OwningAssetID.CompareTo(y.OwningAssetID), -1, 1) * 4 + Mathf.Clamp(string.CompareOrdinal(x.MemberPath, y.MemberPath), -1, 1) * 2 + Mathf.Clamp(x.ID.CompareTo(y.ID), -1, 1));
			using FileStream stream = File.Create(filePath);
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.WriteLine("\"ID\",IsRoot,MemberPath,Type,OwningAssetID,ToString");
			foreach (AssetIDMapping.ToVisit item in list)
			{
				streamWriter.WriteLine("{0},{1},{2},{3},{4},{5}", item.ID, (item.MemberPath == "") ? "1" : "0", SanitiseForCSV(item.MemberPath), SanitiseForCSV(item.Obj.GetType().ToString()), item.OwningAssetID, SanitiseForCSV(LimitChars(item.Obj.ToString())));
			}
		}

		private static string SanitiseForCSV(string input)
		{
			if (input.Contains("\"") || input.Contains(",") || input.Contains("\n") || input.Contains("\r"))
			{
				return "\"" + input.Replace("\"", "\"\"") + "\"";
			}
			return input;
		}

		private static string LimitChars(string input)
		{
			return input.Substring(0, Math.Min(input.Length, 100));
		}
	}
}
