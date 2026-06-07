using TMPro;
using UnityEngine;

public class WaveText : MonoBehaviour
{
	public TMP_Text textComponent;

	private void Update()
	{
		textComponent.ForceMeshUpdate();
		Wave(textComponent.textInfo);
	}

	private void Wave(TMP_TextInfo textInfo)
	{
		for (int i = 0; i < textInfo.characterCount; i++)
		{
			TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
			if (tMP_CharacterInfo.isVisible)
			{
				Vector3[] vertices = textInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex].vertices;
				for (int j = 0; j < 4; j++)
				{
					Vector3 vector = vertices[tMP_CharacterInfo.vertexIndex + j];
					vertices[tMP_CharacterInfo.vertexIndex + j] = vector + new Vector3(0f, Mathf.Sin(Time.time * 2f + vector.x * 0.03f) * -2.5f, 0f);
				}
			}
		}
		for (int k = 0; k < textInfo.meshInfo.Length; k++)
		{
			TMP_MeshInfo tMP_MeshInfo = textInfo.meshInfo[k];
			tMP_MeshInfo.mesh.vertices = tMP_MeshInfo.vertices;
			textComponent.UpdateGeometry(tMP_MeshInfo.mesh, k);
		}
	}
}
