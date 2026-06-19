using TMPro;
using UnityEngine;

namespace UI.Text
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TextShake : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _tmpText;

		public float shakeMagnitude = 1f;

		public float shakeSpeed = 5f;

		public void ApplyShake(TMP_TextInfo textInfo)
		{
			for (int i = 0; i < textInfo.characterCount; i++)
			{
				if (textInfo.characterInfo[i].isVisible)
				{
					int vertexIndex = textInfo.characterInfo[i].vertexIndex;
					int materialReferenceIndex = textInfo.characterInfo[i].materialReferenceIndex;
					Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
					Vector3 vector = new Vector3(Mathf.Sin(Time.time * shakeSpeed + (float)i) * shakeMagnitude, Mathf.Cos(Time.time * shakeSpeed + (float)i) * shakeMagnitude, 0f);
					for (int j = 0; j < 4; j++)
					{
						vertices[vertexIndex + j] += vector;
					}
				}
			}
		}
	}
}
