using Restory.Data.Equipment;
using UnityEngine;

namespace Restory.Data.ToDoList
{
	[CreateAssetMenu(menuName = "Restory/ToDoList/UseToolToDoItem", fileName = "UseTool - ToDoItem")]
	public class UseCleaningToolToDoItem : ToDoItem
	{
		[SerializeField]
		private ToolInfo tool;

		public ToolInfo Tool => tool;
	}
}
