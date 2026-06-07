using System.Collections.Generic;
using UnityEngine;

namespace TinyGiantStudio.Text
{
	[PreferBinarySerialization]
	[CreateAssetMenu(fileName = "New 3D Font", menuName = "Tiny Giant Studio/Modular 3D Text/Font/New Font")]
	public class Font : ScriptableObject
	{
		public List<Character> characters;

		[Tooltip("Use UpperCase If LowerCase Is Missing")]
		public bool useUpperCaseLettersIfLowerCaseIsMissing;

		[Tooltip("Mono space means all characters are spaced equally.\nIf turned on, individual spacing value from list below is ignored. The information is not removed to avoid accidentally turning it on ruin the font. \nCharacter spacing is used for everything")]
		public bool monoSpaceFont;

		public float monoSpaceSpacing;

		[Tooltip("Word spacing and spacing for unavailable characters")]
		public float emptySpaceSpacing;

		public float characterSpacing;

		[Space]
		[Tooltip("Avoid recursive references")]
		public List<Font> fallbackFonts;

		[Tooltip("The 3d object with the characters as child object. \nNOT required.")]
		public GameObject modelSource;

		public bool enableKerning;

		public float kerningMultiplier;

		public List<KerningPair> kernTable;

		[Tooltip("An em is a unit of measurement, relative to the size of the font; therefore, in a typeface set at a font-size of 16px, one em is 16px.")]
		public float unitPerEM;

		[Tooltip("Text's character spacing = font's character spacing * text's character spacing")]
		public float lineHeight;

		[SerializeField]
		private TypeFace _typeFace;

		public byte[] fontBytes;

		public int sizeXYInput;

		public int sizeZInput;

		public float vertexDensityInput;

		public float autoSmoothAngleInput;

		public float averageYValue;

		public TypeFace TypeFace
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float TabSpace()
		{
			return 0f;
		}

		public (Mesh, Character) RetrievePrefabAndCharacter(char c, bool checkFallBackFonts = true)
		{
			return default((Mesh, Character));
		}

		private Mesh MeshPrefab(int i)
		{
			return null;
		}

		public float Spacing(char c)
		{
			return 0f;
		}

		public float Spacing(char previousCharacter, char currentCharacter)
		{
			return 0f;
		}

		public float Spacing(float rawAdvance)
		{
			return 0f;
		}

		public float MonoSpaceSpacing()
		{
			return 0f;
		}

		private float Kerning(char previousChar, Character currentChar)
		{
			return 0f;
		}

		public float Kerning(char previousChar, char currentChar)
		{
			return 0f;
		}

		public float ConvertedValue(float spacing)
		{
			return 0f;
		}

		public int KerningReferencesCount(int index)
		{
			return 0;
		}

		public void UpdateCharacterList(GameObject prefab)
		{
		}

		public void UpdateCharacterList(bool overwriteOldSet)
		{
		}

		public void UpdateCharacterList()
		{
		}

		public void AddCharacter(GameObject obj)
		{
		}

		private bool CharacterAlreadyExists(char character)
		{
			return false;
		}

		public void AddCharacter(Mesh mesh)
		{
		}

		private void ProcessName(string name, out char character, out float spacing)
		{
			character = default(char);
			spacing = default(float);
		}

		private void NewMethod(string name, out char character, out float spacing)
		{
			character = default(char);
			spacing = default(float);
		}

		private void OldMethod(string name, out char character, out float spacing)
		{
			character = default(char);
			spacing = default(float);
		}

		private float GetSpacing(string numberString)
		{
			return 0f;
		}

		public void GetMonoSpacingFromAverageCharacterSpacing()
		{
		}

		public void SetFontBytes(byte[] newFontBytes)
		{
		}

		public void GetTypeFaceFromBytes()
		{
		}
	}
}
