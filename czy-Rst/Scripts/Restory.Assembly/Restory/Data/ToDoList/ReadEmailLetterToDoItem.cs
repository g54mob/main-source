using Restory.Data.Email;
using UnityEngine;

namespace Restory.Data.ToDoList
{
	[CreateAssetMenu(menuName = "Restory/ToDoList/ReadEmailLetterToDoItem", fileName = "ReadEmail - ToDoItem")]
	public class ReadEmailLetterToDoItem : ToDoItem
	{
		[SerializeField]
		private EmailMessageInfo emailMessage;

		public EmailMessageInfo EmailMessage => emailMessage;
	}
}
