using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Email
{
	[CreateAssetMenu(menuName = "Restory/Email/EmailCommentsCollection", fileName = "EmailCommentsCollection")]
	public class EmailCommentsCollection : ScriptableObject
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float commentChance = 0.5f;

		[SerializeField]
		private EmailComment[] entries = new EmailComment[0];

		public float CommentChance => commentChance;

		public IReadOnlyList<EmailComment> EmailComments => entries;
	}
}
