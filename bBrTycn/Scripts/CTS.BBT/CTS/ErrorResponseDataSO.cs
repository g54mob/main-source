using System;
using CTS.UI;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "ReportSystem_ErrorResponseData", menuName = "CTS/Report System/Error Response Data")]
	public class ErrorResponseDataSO : ScriptableObject
	{
		[Serializable]
		public class ErrorData
		{
			public int errorCode;

			public PaletteData borderColor;

			public LocalizedString messageKey;
		}

		public ErrorData[] errorDataArray;
	}
}
