using TMPro;
using UnityEngine;

namespace Utilities.Text
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class StretchText : MonoBehaviour
	{
		[Range(0f, 500f)]
		public float cornerOffset = 20f;

		public RectTransform boundingBox;

		[SerializeField]
		private TextMeshProUGUI tmp;

		public void ApplyStretch(TMP_TextInfo textInfo)
		{
			int characterCount = textInfo.characterCount;
			if (characterCount < 2)
			{
				return;
			}
			float xMin = boundingBox.rect.xMin;
			float xMax = boundingBox.rect.xMax;
			float a = xMin + cornerOffset;
			float b = xMax - cornerOffset;
			for (int i = 0; i < characterCount; i++)
			{
				if (textInfo.characterInfo[i].isVisible)
				{
					TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
					int vertexIndex = tMP_CharacterInfo.vertexIndex;
					Vector3[] vertices = textInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex].vertices;
					float t = (float)i / (float)(characterCount - 1);
					float x = Mathf.Lerp(a, b, t);
					Vector3 vector = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
					Vector3 vector2 = new Vector3(x, vector.y, 0f) - vector;
					for (int j = 0; j < 4; j++)
					{
						vertices[vertexIndex + j] += vector2;
					}
				}
			}
		}
	}
}
