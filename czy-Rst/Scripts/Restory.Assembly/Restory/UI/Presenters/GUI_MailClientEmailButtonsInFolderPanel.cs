using System;
using System.Collections.Generic;
using Restory.Gameplay.EmailSystems;
using Restory.ObjectPools;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GUI_MailClientEmailButtonsInFolderPanel : MonoBehaviour
	{
		private struct LetterAndButtonPair
		{
			public GUI_EmailMessageButton Button;

			public IEmailLetterRecord Letter;
		}

		[SerializeField]
		private Transform messagesParent;

		private ConcreteGameObjectPool emailsPool;

		private readonly List<LetterAndButtonPair> emailLettersAndTheirButtons = new List<LetterAndButtonPair>();

		private IEmailLetterRecord currentlySelectedLetter;

		public IEmailLetterRecord CurrentlySelectedLetter => currentlySelectedLetter;

		public event Action OnEmailSelected;

		[Inject]
		private void Construct(ConcreteGameObjectPool emailsPool)
		{
			this.emailsPool = emailsPool;
		}

		private void OnDisable()
		{
			foreach (LetterAndButtonPair emailLettersAndTheirButton in emailLettersAndTheirButtons)
			{
				if (emailLettersAndTheirButton.Button.MonoShellExists())
				{
					emailLettersAndTheirButton.Button.OnClick -= ResolveEmailButtonClicked;
				}
			}
		}

		public void ShowMessagesList(IList<IEmailLetterRecord> emailsToShow, Func<IEmailLetterRecord, bool> wasEmailReadFunction)
		{
			Transform parent = (messagesParent ? messagesParent : base.transform);
			for (int num = emailsToShow.Count - 1; num >= 0; num--)
			{
				IEmailLetterRecord emailLetterRecord = emailsToShow[num];
				GUI_EmailMessageButton gUI_EmailMessageButton = emailsPool.Get<GUI_EmailMessageButton>(parent);
				SetUpMessageButton(gUI_EmailMessageButton, emailLetterRecord, wasEmailReadFunction);
				emailLettersAndTheirButtons.Add(new LetterAndButtonPair
				{
					Button = gUI_EmailMessageButton,
					Letter = emailLetterRecord
				});
				gUI_EmailMessageButton.OnClick += ResolveEmailButtonClicked;
			}
		}

		public void RefreshExistingMessagesButtons(Func<IEmailLetterRecord, bool> wasMessageRead)
		{
			foreach (LetterAndButtonPair emailLettersAndTheirButton in emailLettersAndTheirButtons)
			{
				if ((bool)emailLettersAndTheirButton.Button)
				{
					SetUpMessageButton(emailLettersAndTheirButton.Button, emailLettersAndTheirButton.Letter, wasMessageRead);
				}
			}
		}

		public void SetInitialState()
		{
			foreach (LetterAndButtonPair emailLettersAndTheirButton in emailLettersAndTheirButtons)
			{
				if ((bool)emailLettersAndTheirButton.Button)
				{
					emailLettersAndTheirButton.Button.ChangeSelection(shouldBeSelected: false);
				}
			}
			currentlySelectedLetter = null;
		}

		public bool TryToRestoreButtonSelection()
		{
			bool flag = false;
			foreach (LetterAndButtonPair emailLettersAndTheirButton in emailLettersAndTheirButtons)
			{
				if ((bool)emailLettersAndTheirButton.Button)
				{
					bool flag2 = currentlySelectedLetter != null && emailLettersAndTheirButton.Letter == currentlySelectedLetter;
					emailLettersAndTheirButton.Button.ChangeSelection(flag2);
					if (flag2)
					{
						flag = true;
					}
				}
			}
			if (!flag)
			{
				currentlySelectedLetter = null;
			}
			return flag;
		}

		public void ClearMessagesList()
		{
			foreach (LetterAndButtonPair emailLettersAndTheirButton in emailLettersAndTheirButtons)
			{
				if ((bool)emailLettersAndTheirButton.Button)
				{
					emailLettersAndTheirButton.Button.OnClick -= ResolveEmailButtonClicked;
					emailsPool.Release(emailLettersAndTheirButton.Button);
				}
			}
			emailLettersAndTheirButtons.Clear();
		}

		public void Clear()
		{
			ClearMessagesList();
			currentlySelectedLetter = null;
		}

		private static void SetUpMessageButton(GUI_EmailMessageButton emailMessageButton, IEmailLetterRecord email, Func<IEmailLetterRecord, bool> wasEmailReadFunction)
		{
			if (email is EmailLetterOrderRecord emailLetterOrderRecord)
			{
				emailMessageButton.SetUp(emailLetterOrderRecord.SenderContactInfo.EmailAddress, emailLetterOrderRecord.DeviceCondition.DeviceInfo.NameLocalizationKey, emailLetterOrderRecord.SubjectLocalizationKey, wasEmailReadFunction(emailLetterOrderRecord));
			}
			else
			{
				emailMessageButton.SetUp(email.SenderContactInfo.EmailAddress, string.Empty, email.SubjectLocalizationKey, wasEmailReadFunction(email));
			}
		}

		private void ResolveEmailButtonClicked(GUI_EmailMessageButton clickedButton)
		{
			foreach (LetterAndButtonPair emailLettersAndTheirButton in emailLettersAndTheirButtons)
			{
				if (emailLettersAndTheirButton.Button == clickedButton)
				{
					currentlySelectedLetter = emailLettersAndTheirButton.Letter;
					emailLettersAndTheirButton.Button.ChangeSelection(shouldBeSelected: true);
				}
				else
				{
					emailLettersAndTheirButton.Button.ChangeSelection(shouldBeSelected: false);
				}
			}
			this.OnEmailSelected?.Invoke();
		}
	}
}
