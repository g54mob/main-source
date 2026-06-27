using System;
using UnityEngine;

namespace Restory.Gameplay.WorkshopRatings
{
	[Serializable]
	public struct ReviewComment
	{
		[SerializeField]
		public string[] sentences;

		public readonly string[] Sentences => sentences;

		public ReviewComment(params string[] sentences)
		{
			this.sentences = sentences ?? Array.Empty<string>();
		}
	}
}
