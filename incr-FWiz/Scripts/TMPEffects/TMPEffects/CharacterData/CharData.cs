using System.Collections.Generic;
using TMPEffects.Modifiers;
using TMPro;
using UnityEngine;

namespace TMPEffects.CharacterData
{
	public class CharData
	{
		public struct Info
		{
			public readonly int index;

			public readonly int wordFirstIndex;

			public readonly int wordLastIndex;

			public readonly int wordLen;

			public readonly Color32 color;

			public readonly float pointSize;

			public readonly char character;

			public readonly bool isVisible;

			public readonly int lineNumber;

			public readonly int pageNumber;

			public readonly int wordNumber;

			public readonly float baseLine;

			public readonly float ascender;

			public readonly float descender;

			public readonly float xAdvance;

			public readonly TMP_FontAsset fontAsset;

			public readonly TMP_SpriteAsset spriteAsset;

			public readonly TMP_TextElementType elementType;

			public readonly float origin;

			public readonly float referenceScale;

			public readonly ReadOnlyVertexData initialMesh;

			public readonly Vector3 InitialPosition;

			public readonly Quaternion InitialRotation;

			public readonly Vector3 InitialScale;

			internal Info(int index, TMP_CharacterInfo cInfo, int wordIndex)
			{
				this.index = 0;
				wordFirstIndex = 0;
				wordLastIndex = 0;
				wordLen = 0;
				color = default(Color32);
				pointSize = 0f;
				character = '\0';
				isVisible = false;
				lineNumber = 0;
				pageNumber = 0;
				wordNumber = 0;
				baseLine = 0f;
				ascender = 0f;
				descender = 0f;
				xAdvance = 0f;
				fontAsset = null;
				spriteAsset = null;
				elementType = default(TMP_TextElementType);
				origin = 0f;
				referenceScale = 0f;
				initialMesh = null;
				InitialPosition = default(Vector3);
				InitialRotation = default(Quaternion);
				InitialScale = default(Vector3);
			}

			public Info(int index, TMP_CharacterInfo cInfo, int wordIndex, TMP_WordInfo wInfo)
			{
				this.index = 0;
				wordFirstIndex = 0;
				wordLastIndex = 0;
				wordLen = 0;
				color = default(Color32);
				pointSize = 0f;
				character = '\0';
				isVisible = false;
				lineNumber = 0;
				pageNumber = 0;
				wordNumber = 0;
				baseLine = 0f;
				ascender = 0f;
				descender = 0f;
				xAdvance = 0f;
				fontAsset = null;
				spriteAsset = null;
				elementType = default(TMP_TextElementType);
				origin = 0f;
				referenceScale = 0f;
				initialMesh = null;
				InitialPosition = default(Vector3);
				InitialRotation = default(Quaternion);
				InitialScale = default(Vector3);
			}

			private static Vector3 GetCenter(in ReadOnlyVertexData data)
			{
				return default(Vector3);
			}
		}

		public static readonly Vector3 defaultScale;

		public static readonly Quaternion defaultRotation;

		public readonly Info info;

		public readonly VertexData mesh;

		private TMPCharacterModifiers characterModifiers;

		public TMPCharacterModifiers CharacterModifiers => null;

		public TMPMeshModifiers MeshModifiers => null;

		public bool positionDirty => false;

		public bool rotationDirty => false;

		public bool scaleDirty => false;

		public bool verticesDirty => false;

		public bool colorsDirty => false;

		public bool alphasDirty => false;

		public bool uvsDirty => false;

		public Vector3 Position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 PositionDelta
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 Scale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public IReadOnlyList<Rotation> Rotations => null;

		public Vector3 InitialPosition => default(Vector3);

		public Quaternion InitialRotation => default(Quaternion);

		public Vector3 InitialScale => default(Vector3);

		public ReadOnlyVertexData InitialMesh => null;

		public CharData(int index, TMP_CharacterInfo cInfo, int wordIndex)
		{
		}

		public CharData(int index, TMP_CharacterInfo cInfo, int wordIndex, TMP_WordInfo? wInfo = null)
		{
		}

		public void SetPosition(Vector3 position)
		{
		}

		public void SetPositionDelta(Vector3 delta)
		{
		}

		public void ClearPosition()
		{
		}

		public void AddRotation(Vector3 eulerAngles, Vector3 pivot)
		{
		}

		public void RemoveRotation(int index)
		{
		}

		public void InsertRotation(int index, Vector3 eulerAngles, Vector3 pivot)
		{
		}

		public void ClearRotations()
		{
		}

		public void SetScale(Vector3 scale)
		{
		}

		public void ClearScale()
		{
		}

		public void Reset()
		{
		}
	}
}
