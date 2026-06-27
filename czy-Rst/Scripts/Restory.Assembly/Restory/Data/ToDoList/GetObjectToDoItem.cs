using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.ToDoList
{
	[CreateAssetMenu(menuName = "Restory/ToDoList/GetObjectToDoItem", fileName = "GetObject - ToDoItem")]
	public class GetObjectToDoItem : ToDoItem
	{
		[SerializeField]
		private RestoryEntityInfoBase objectInfoToTrack;

		public RestoryEntityInfoBase ObjectInfoToTrack => objectInfoToTrack;
	}
}
