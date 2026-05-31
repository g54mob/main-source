using System.Collections.Generic;
using UnityEngine;

namespace TinyGiantStudio.Text.FontCreation
{
	public class CharacterGenerator
	{
		private float sizeXY;

		private float sizeZ;

		private int vertexDensity;

		private float autoSmoothAngle;

		public TypeFace typeFace;

		private int lastUsedFontsInstanceID;

		private int totalVerticies;

		private int totalTriangles;

		public float averageYValue;

		public float lineHeight;

		private List<FailedCharacter> failedCharacters;

		private GameObject gameObject;

		public void GetFontObject(GameObject newGameObject, byte[] fileContent, List<char> characterList, float sizeXYInput, float sizeZInput, int vertexDensityInput, float autoSmoothAngleInput, Material material)
		{
		}

		public void CreateTypeFace(byte[] fileContent)
		{
		}

		private void CreateFont(List<char> characterList, float sizeXYInput, float sizeZInput, int vertexDensityInput, float autoSmoothAngleInput, Material material)
		{
		}

		private void SetAverageYPivot(List<char> characterList)
		{
		}

		private void ProcessCharacterList(List<char> characterList, Material material)
		{
		}

		private void CreateCharacterObjectForFont(GameObject gameObject, Mesh mesh, char character, Material material)
		{
		}

		private string GetCharacterObjectName(char myChar, Transform target)
		{
			return null;
		}

		private string GetEscapeSequence(char c)
		{
			return null;
		}

		private int GetNextVertexDensityTry()
		{
			return 0;
		}

		private void ProcessFailedCharacters(Material material)
		{
		}

		public Mesh GetMesh(byte[] fileContent, float sizeXYInput, float sizeZInput, float autoSmoothAngleInput, float averageYValueInput, int vertexDensityInput, char c)
		{
			return null;
		}

		public Mesh GetMesh(byte[] fileContent, float sizeXYInput, float sizeZInput, float autoSmoothAngleInput, float averageYValueInput, char c)
		{
			return null;
		}

		public Mesh GetMesh(int fontInstanceID, TypeFace newTypeFace, float sizeXYInput, float sizeZInput, float autoSmoothAngleInput, float averageYValueInput, char c)
		{
			return null;
		}

		private void SetValues(float sizeXYInput, float sizeZInput, float autoSmoothAngleInput, float averageYValueInput)
		{
		}

		private Mesh JustGetMesh(Vector3[] totalVerts, int[] totalTris, Vector2[] meshUVs, char character)
		{
			return null;
		}

		private void GetMeshData(char character, out Vector3[] totalVerts, out int[] totalTris, out Vector2[] meshUVs, bool keepFailedCharacters)
		{
			totalVerts = null;
			totalTris = null;
			meshUVs = null;
		}

		private void SetPivot(Vector3[] totalVerts, Vector3[] thisVerts, float zPosition, int vertexCount, float xMax, float scaleFactor)
		{
		}

		private bool GetVerticiesAndTrianglesCount(char myChar, TypeFace thisFont, bool keepFailedCharacters)
		{
			return false;
		}

		private List<DataClass> GetCharacterData(char c)
		{
			return null;
		}

		private bool GetTagData(ref string s, out string tag, out string data)
		{
			tag = null;
			data = null;
			return false;
		}

		public void GetTypeFaceInformation(ref float lineHeight, ref float unitsPerEM, ref float whiteSpaceSpacing)
		{
		}

		public int Index(char myChar)
		{
			return 0;
		}

		public char Character(int index)
		{
			return '\0';
		}

		public bool GlyphExists(char c)
		{
			return false;
		}

		public ushort GetCharacterAdvance(int index)
		{
			return 0;
		}

		public int GetCharacterLeftSideBearing(int index)
		{
			return 0;
		}

		public bool KerningSupported()
		{
			return false;
		}

		public void GetKerningInfo(out List<int> lefts, out List<int> rights, out List<short> offsets)
		{
			lefts = null;
			rights = null;
			offsets = null;
		}
	}
}
