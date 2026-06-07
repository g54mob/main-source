using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public class FolderAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string Folder;

		public readonly string Title;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy { get; }

		public FolderAttribute(string folder = "", string title = "", string groupBy = "")
		{
			GroupBy = groupBy;
			Folder = folder;
			Title = title;
		}
	}
}
