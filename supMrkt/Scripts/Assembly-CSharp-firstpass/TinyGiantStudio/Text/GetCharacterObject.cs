using TinyGiantStudio.Layout;
using TinyGiantStudio.Text.FontCreation;
using UnityEngine;

namespace TinyGiantStudio.Text
{
	public class GetCharacterObject
	{
		private static readonly float unitConverted;

		public static MeshLayout GetMeshLayout(char currentChar, Modular3DText text, MeshPostProcess meshPostProcess)
		{
			return null;
		}

		public static MeshLayout GetMeshLayout(char previousChar, char currentChar, Modular3DText text, MeshPostProcess meshPostProcess)
		{
			return null;
		}

		public static GameObject GetObject(char c, Modular3DText text, MeshPostProcess meshPostProcess)
		{
			return null;
		}

		public static GameObject GetObject(char previousChar, char currentChar, Modular3DText text, MeshPostProcess meshPostProcess)
		{
			return null;
		}

		private static MeshLayout ProcessNormalCharacter(char c, Modular3DText text, MeshPostProcess meshPostProcess)
		{
			return null;
		}

		private static Mesh GetMeshFromFallbackFonts(char c, Modular3DText text, CharacterGenerator creator, Mesh mesh)
		{
			return null;
		}

		private static MeshLayout ProcessNormalCharacter(char previousChar, char currentChar, Modular3DText text, MeshPostProcess meshPostProcess)
		{
			return null;
		}

		private static GameObject ProcessNormalCharacter(char c, Modular3DText text, GameObject obj, LayoutElement layoutElement, MeshPostProcess meshPostProcess)
		{
			return null;
		}

		private static GameObject ProcessNormalCharacter(char previousChar, char currentChar, Modular3DText text, GameObject obj, LayoutElement layoutElement, MeshPostProcess meshPostProcess)
		{
			return null;
		}

		private static bool IsSpecialSymbol(char c)
		{
			return false;
		}

		private static MeshLayout ProcessSpecialCharacter(char c, Modular3DText text)
		{
			return null;
		}

		private static GameObject ProcessSpecialCharacter(char c, Font font, Modular3DText text, LayoutElement layoutElement, GameObject obj)
		{
			return null;
		}
	}
}
