using System;
using TMPro;
using UnityEngine;

namespace PhEngine.ThaiTextCare.Utility
{
	[Serializable]
	public class WordHit
	{
		public string word;

		public char nearestCharacter;

		public TMP_Text text;

		public float fontSize;

		[Header("Start")]
		public int startIndex;

		public Vector3 startPosition;

		[Header("End")]
		public int endIndex;

		public Vector3 endPosition;

		public float Width => 0f;

		public WordHit(TMP_Text text, string word, char nearestCharacter, Vector3 startPosition, Vector3 endPosition, int endIndex, int startIndex)
		{
		}

		public bool IsSameAs(WordHit other)
		{
			return false;
		}
	}
}
