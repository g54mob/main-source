using System.Collections.Generic;
using Restory.Data.Email;
using UnityEngine;

namespace Restory.Gameplay.EmailSystems
{
	public sealed class EmailCommentsService : MonoBehaviour
	{
		[SerializeField]
		private EmailCommentsCollection emailCommentsCollection;

		private List<EmailComment> availableEmailComments = new List<EmailComment>();

		private List<EmailComment> usedUniqueEmailComments = new List<EmailComment>();

		private void Awake()
		{
			foreach (EmailComment emailComment in emailCommentsCollection.EmailComments)
			{
				if (!availableEmailComments.Contains(emailComment) && !usedUniqueEmailComments.Contains(emailComment))
				{
					availableEmailComments.Add(emailComment);
				}
			}
		}

		public bool TryToGetRandomEmailComment(out EmailComment emailComment)
		{
			int count = availableEmailComments.Count;
			if (count == 0 || Random.Range(0f, 1f) > emailCommentsCollection.CommentChance)
			{
				emailComment = null;
				return false;
			}
			int index = Random.Range(0, count);
			emailComment = availableEmailComments[index];
			if (emailComment.IsUnique)
			{
				availableEmailComments.RemoveAt(index);
				usedUniqueEmailComments.Add(emailComment);
			}
			return true;
		}
	}
}
