using System;
using UnityEngine;

namespace CTS
{
	public class NamesScriptable : ScriptableObject
	{
		[HideInInspector]
		[SerializeField]
		public string SheetName = "";

		[HideInInspector]
		[SerializeField]
		public string WorksheetName = "";

		public NamesData[] dataArray;

		private void OnEnable()
		{
			if (dataArray == null)
			{
				dataArray = Array.Empty<NamesData>();
			}
		}
	}
}
