using Restory.Data.ToDoList;
using Restory.Gameplay.EmailSystems;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public sealed class ReadEmailLetterToDoItemHandler : ToDoItemHandler
	{
		private EmailService emailService;

		private ReadEmailLetterToDoItem readEmailLetterToDoItem;

		[Inject]
		private void Construct(EmailService emailService)
		{
			this.emailService = emailService;
		}

		public override void Initialize(ToDoItem item, ToDoListService toDoListService)
		{
			base.Initialize(item, toDoListService);
			if (!(item is ReadEmailLetterToDoItem readEmailLetterToDoItem))
			{
				Debug.LogError("[ReadEmailLetterToDoItemHandler] tried to initialize, but the supplied item is not [ReadEmailLetterToDoItem], but [" + item.GetType().Name + "] instead!");
				return;
			}
			this.readEmailLetterToDoItem = readEmailLetterToDoItem;
			emailService.OnLettersReadStatusChanged += ResolveLettersReadStatusChanged;
		}

		public override void Dispose()
		{
			if (emailService.MonoShellExists())
			{
				emailService.OnLettersReadStatusChanged -= ResolveLettersReadStatusChanged;
			}
			readEmailLetterToDoItem = null;
			base.Dispose();
		}

		public override void ForceCheckCompletionConditions()
		{
			base.ForceCheckCompletionConditions();
			ResolveLettersReadStatusChanged();
		}

		private void ResolveLettersReadStatusChanged()
		{
			if ((bool)readEmailLetterToDoItem && emailService.TryGetNarrativeEmailLetterRecordByID(readEmailLetterToDoItem.EmailMessage.ID, out var foundLetterRecord) && emailService.WasMessageRead(foundLetterRecord))
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}
	}
}
