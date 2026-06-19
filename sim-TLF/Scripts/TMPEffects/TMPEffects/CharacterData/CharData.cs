using System.Collections.Generic;
using System.Linq;
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
				this.index = index;
				isVisible = cInfo.isVisible;
				wordNumber = wordIndex;
				wordFirstIndex = -1;
				wordLastIndex = -1;
				wordLen = -1;
				color = cInfo.color;
				lineNumber = cInfo.lineNumber;
				pageNumber = cInfo.pageNumber;
				pointSize = cInfo.pointSize;
				character = cInfo.character;
				baseLine = cInfo.baseLine;
				ascender = cInfo.ascender;
				descender = cInfo.descender;
				xAdvance = cInfo.xAdvance;
				referenceScale = cInfo.scale;
				fontAsset = cInfo.fontAsset;
				InitialRotation = defaultRotation;
				InitialScale = defaultScale;
				ReadOnlyVertexData readOnlyVertexData = new ReadOnlyVertexData(cInfo);
				initialMesh = readOnlyVertexData;
				InitialPosition = GetCenter(in initialMesh);
				if (cInfo.elementType == TMP_TextElementType.Sprite)
				{
					TMP_SpriteCharacter tMP_SpriteCharacter = (TMP_SpriteCharacter)cInfo.textElement;
					spriteAsset = tMP_SpriteCharacter.textAsset as TMP_SpriteAsset;
				}
				else
				{
					spriteAsset = null;
				}
				elementType = cInfo.elementType;
				origin = cInfo.origin;
			}

			public Info(int index, TMP_CharacterInfo cInfo, int wordIndex, TMP_WordInfo wInfo)
				: this(index, cInfo, wordIndex)
			{
				wordFirstIndex = wInfo.firstCharacterIndex;
				wordLastIndex = wInfo.lastCharacterIndex;
				wordLen = wInfo.characterCount;
			}

			private static Vector3 GetCenter(in ReadOnlyVertexData data)
			{
				Vector3 zero = Vector3.zero;
				for (int i = 0; i < 4; i++)
				{
					zero += data.GetPosition(i);
				}
				return zero / 4f;
			}
		}

		public static readonly Vector3 defaultScale = new Vector3(1f, 1f, 1f);

		public static readonly Quaternion defaultRotation = Quaternion.identity;

		public readonly Info info;

		public readonly VertexData mesh;

		private TMPCharacterModifiers characterModifiers;

		public TMPCharacterModifiers CharacterModifiers => characterModifiers;

		public TMPMeshModifiers MeshModifiers => mesh.Modifiers;

		public bool positionDirty => characterModifiers.PositionDelta != Vector3.zero;

		public bool rotationDirty => characterModifiers.Rotations.Any();

		public bool scaleDirty => characterModifiers.ScaleDelta != Matrix4x4.identity;

		public bool verticesDirty => mesh.positionsDirty;

		public bool colorsDirty => mesh.colorsDirty;

		public bool alphasDirty => mesh.alphasDirty;

		public bool uvsDirty => mesh.uvsDirty;

		public Vector3 Position
		{
			get
			{
				return characterModifiers.PositionDelta + InitialPosition;
			}
			set
			{
				characterModifiers.PositionDelta = value - InitialPosition;
			}
		}

		public Vector3 PositionDelta
		{
			get
			{
				return characterModifiers.PositionDelta;
			}
			set
			{
				characterModifiers.PositionDelta = value;
			}
		}

		public Vector3 Scale
		{
			get
			{
				return characterModifiers.ScaleDelta.lossyScale;
			}
			set
			{
				characterModifiers.ScaleDelta = Matrix4x4.Scale(value);
			}
		}

		public IReadOnlyList<Rotation> Rotations => characterModifiers.Rotations;

		public Vector3 InitialPosition => info.InitialPosition;

		public Quaternion InitialRotation => info.InitialRotation;

		public Vector3 InitialScale => info.InitialScale;

		public ReadOnlyVertexData InitialMesh => info.initialMesh;

		public CharData(int index, TMP_CharacterInfo cInfo, int wordIndex)
		{
			info = new Info(index, cInfo, wordIndex);
			mesh = new VertexData(cInfo);
			characterModifiers = new TMPCharacterModifiers();
		}

		public CharData(int index, TMP_CharacterInfo cInfo, int wordIndex, TMP_WordInfo? wInfo = null)
		{
			info = ((!wInfo.HasValue) ? new Info(index, cInfo, wordIndex) : new Info(index, cInfo, wordIndex, wInfo.Value));
			mesh = new VertexData(cInfo);
			characterModifiers = new TMPCharacterModifiers();
		}

		public void SetPosition(Vector3 position)
		{
			characterModifiers.PositionDelta = position - InitialPosition;
		}

		public void SetPositionDelta(Vector3 delta)
		{
			characterModifiers.PositionDelta = delta;
		}

		public void ClearPosition()
		{
			characterModifiers.ClearModifiers(TMPCharacterModifiers.ModifierFlags.PositionDelta);
		}

		public void AddRotation(Vector3 eulerAngles, Vector3 pivot)
		{
			characterModifiers.AddRotation(new Rotation(eulerAngles, pivot));
		}

		public void RemoveRotation(int index)
		{
			characterModifiers.RemoveRotation(index);
		}

		public void InsertRotation(int index, Vector3 eulerAngles, Vector3 pivot)
		{
			characterModifiers.InsertRotation(index, new Rotation(eulerAngles, pivot));
		}

		public void ClearRotations()
		{
			characterModifiers.ClearModifiers(TMPCharacterModifiers.ModifierFlags.Rotations);
		}

		public void SetScale(Vector3 scale)
		{
			characterModifiers.ScaleDelta = Matrix4x4.Scale(scale);
		}

		public void ClearScale()
		{
			characterModifiers.ClearModifiers(TMPCharacterModifiers.ModifierFlags.Scale);
		}

		public void Reset()
		{
			characterModifiers.ClearModifiers();
			MeshModifiers.ClearModifiers();
		}
	}
}
