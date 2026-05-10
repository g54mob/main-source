using System;
using UnityEngine;

namespace CTS
{
	public class DataImportAtRuntime : MonoBehaviour
	{
		[Flags]
		public enum EAutomaticImport
		{
			None = 0,
			Editor = 1,
			DevBuild = 2
		}

		[SerializeField]
		private EAutomaticImport _importType;

		private void Start()
		{
		}

		private void StartImport(bool saveData = false)
		{
			GoogleSheetDataImporter.ImportAll(saveData);
		}
	}
}
