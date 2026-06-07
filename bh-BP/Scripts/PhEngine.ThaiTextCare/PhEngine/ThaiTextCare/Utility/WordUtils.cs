using TMPro;
using UnityEngine;

namespace PhEngine.ThaiTextCare.Utility
{
	public static class WordUtils
	{
		public static bool TryGetHitFromMouse(TextMeshProUGUI targetText, out WordHit request, float maxDistance = 1f, char[] customSeparators = null)
		{
			request = null;
			return false;
		}

		public static bool TryGetHitFromMouse(TextMeshProUGUI targetText, Camera camera, out WordHit request, float maxDistance = 1f, char[] customSeparators = null)
		{
			request = null;
			return false;
		}

		public static bool TryGetHit(TextMeshProUGUI targetText, Vector3 position, out WordHit request, float maxDistance = 1f, char[] customSeparators = null)
		{
			request = null;
			return false;
		}

		public static bool TryGetHit(TextMeshProUGUI targetText, Vector3 position, Camera camera, out WordHit hit, float maxDistance = 1f, char[] customSeparators = null)
		{
			hit = null;
			return false;
		}

		public static bool GetWordFromCharacterInfoIndex(TextMeshProUGUI targetText, int characterInfoIndex, out WordHit hit, char[] customSeparators = null)
		{
			hit = null;
			return false;
		}

		private static int FindNearestCharacter(TextMeshProUGUI text, Vector3 position, Camera camera, bool visibleOnly, float maxDistance)
		{
			return 0;
		}

		private static bool PointIntersectRectangle(Vector3 m, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
		{
			return false;
		}

		private static string GetWord(TMP_CharacterInfo[] characters, int startIndex, int endIndex)
		{
			return null;
		}

		private static bool IsEndOfWordOrSpace(char currentChar, char[] customSeparators = null)
		{
			return false;
		}

		private static int FindNearestSeparator(TMP_CharacterInfo[] message, int startIndex, int direction, char[] customSeparators = null)
		{
			return 0;
		}
	}
}
