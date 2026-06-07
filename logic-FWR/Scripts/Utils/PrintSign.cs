using System;
using TMPro;
using UnityEngine;

public class PrintSign : MonoBehaviour, IVisualEffect
{
	[SerializeField]
	private AnimationCurve growCurve;

	[SerializeField]
	private float startTimeOffset;

	[SerializeField]
	private float droneAnimDuration;

	[SerializeField]
	private float lifetime;

	[SerializeField]
	private AnimationCurve fadeCurve;

	[SerializeField]
	private float riseHeigth;

	[SerializeField]
	private int maxStringLength;

	[SerializeField]
	private TextMeshProUGUI text;

	private TMP_Text textMesh;

	private Mesh mesh;

	private Vector3[] vertices;

	private float startTime;

	private float width;

	private float startHeight;

	public bool IsPlaying()
	{
		return Time.time - startTime < lifetime;
	}

	public void Play()
	{
		startTime = Time.time + startTimeOffset;
		startHeight = base.transform.localPosition.z;
	}

	public void SetColor(Color color)
	{
		throw new NotImplementedException();
	}

	public float SetText(string printString)
	{
		string text = printString.Replace(" ", "\u00a0");
		text = ((text.Length > maxStringLength) ? (text.Substring(0, maxStringLength - 3) + "...") : text);
		this.text.text = text;
		textMesh = this.text.GetComponent<TMP_Text>();
		textMesh.ForceMeshUpdate();
		mesh = textMesh.mesh;
		vertices = mesh.vertices;
		width = vertices[vertices.Length - 1].x - vertices[0].x;
		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = Vector3.zero;
		}
		mesh.vertices = vertices;
		textMesh.canvasRenderer.SetMesh(mesh);
		return width;
	}

	private void Update()
	{
		float num = (Time.time - startTime) / lifetime;
		if (num > 1f)
		{
			return;
		}
		text.alpha = fadeCurve.Evaluate(num);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, startHeight + riseHeigth * num);
		textMesh.ForceMeshUpdate();
		mesh = textMesh.mesh;
		vertices = mesh.vertices;
		for (int i = 0; i < textMesh.textInfo.characterCount; i++)
		{
			TMP_CharacterInfo tMP_CharacterInfo = textMesh.textInfo.characterInfo[i];
			if (!char.IsWhiteSpace(tMP_CharacterInfo.character))
			{
				Vector3 vector = new Vector3((tMP_CharacterInfo.bottomLeft.x + tMP_CharacterInfo.topRight.x) / 2f, 0f, 0f);
				float time = num - droneAnimDuration * (vector.x + width * 0.5f) / width / lifetime;
				float num2 = Mathf.Max(0f, growCurve.Evaluate(time));
				_ = Vector3.up * num2;
				int vertexIndex = tMP_CharacterInfo.vertexIndex;
				vertices[vertexIndex] = (vertices[vertexIndex] - vector) * num2 + vector;
				vertices[vertexIndex + 1] = (vertices[vertexIndex + 1] - vector) * num2 + vector;
				vertices[vertexIndex + 2] = (vertices[vertexIndex + 2] - vector) * num2 + vector;
				vertices[vertexIndex + 3] = (vertices[vertexIndex + 3] - vector) * num2 + vector;
			}
		}
		mesh.vertices = vertices;
		textMesh.canvasRenderer.SetMesh(mesh);
	}
}
