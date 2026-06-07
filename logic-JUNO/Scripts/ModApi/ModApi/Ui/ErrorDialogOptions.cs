using System;
using UnityEngine;

namespace ModApi.Ui
{
	public class ErrorDialogOptions
	{
		public static ErrorDialogOptions Default => new ErrorDialogOptions
		{
			ExtraWide = false,
			MaxLines = 35
		};

		public static ErrorDialogOptions LongError => new ErrorDialogOptions
		{
			ExtraWide = true,
			MaxLines = 35
		};

		public bool ExtraWide { get; set; }

		public int MaxLines { get; set; }

		public string OkayButtonText { get; set; }

		public Action OnCloseAction { get; set; }

		public Transform ParentTransform { get; set; }

		public string TruncationMessage { get; set; }

		public bool UseDangerButtonStyle { get; set; }
	}
}
