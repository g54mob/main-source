using TMPro;
using UnityEngine;

namespace LogoMaker.Extensions
{
	public static class TextMeshProExtensions
	{
		public static Bounds GetActualBounds(this TextMeshPro text)
		{
			text.ForceMeshUpdate();
			Bounds result = new Bounds(text.textInfo.characterInfo[0].topLeft, Vector3.zero);
			TMP_CharacterInfo[] characterInfo = text.textInfo.characterInfo;
			for (int i = 0; i < characterInfo.Length; i++)
			{
				TMP_CharacterInfo tMP_CharacterInfo = characterInfo[i];
				if (tMP_CharacterInfo.isVisible)
				{
					result.Encapsulate(tMP_CharacterInfo.topLeft);
					result.Encapsulate(tMP_CharacterInfo.topRight);
					result.Encapsulate(tMP_CharacterInfo.bottomLeft);
					result.Encapsulate(tMP_CharacterInfo.bottomRight);
				}
			}
			return result;
		}
	}
}
