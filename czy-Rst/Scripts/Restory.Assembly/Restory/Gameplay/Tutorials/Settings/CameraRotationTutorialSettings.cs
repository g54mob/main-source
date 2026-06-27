using System;
using Restory.Data.ToDoList;
using Restory.UI.Views.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.Tutorials.Settings
{
	[Serializable]
	public class CameraRotationTutorialSettings
	{
		[SerializeField]
		private ToDoItem targetToDoItem;

		[SerializeField]
		private GUI_ArrowTooltip arrowTooltipPrefab;

		public ToDoItem TargetToDoItem => targetToDoItem;

		public GUI_ArrowTooltip ArrowTooltipPrefab => arrowTooltipPrefab;
	}
}
