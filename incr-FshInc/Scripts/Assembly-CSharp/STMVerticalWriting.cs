using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SuperTextMesh))]
[ExecuteInEditMode]
public class STMVerticalWriting : MonoBehaviour
{
	[SerializeField]
	private SuperTextMesh textMesh;

	[Range(0f, 90f)]
	public float angle = 90f;

	private Vector3 _eulerRotation = Vector3.zero;

	public bool useEvenSpacing = true;

	public float evenSpacing = 0.1f;

	public char[] keepRotated = new char[1] { 'ー' };

	private Vector3 eulerRotation
	{
		get
		{
			_eulerRotation.z = angle;
			return _eulerRotation;
		}
	}

	private void Reset()
	{
		textMesh = GetComponent<SuperTextMesh>();
	}

	private void OnEnable()
	{
		textMesh.OnVertexMod += RotateLetters;
		textMesh.Rebuild();
	}

	private void OnDisable()
	{
		textMesh.OnVertexMod -= RotateLetters;
	}

	public void RotateLetters(Vector3[] verts, Vector3[] middles, Vector3[] positions)
	{
		float num = 0f;
		float num2 = 0f;
		int i = 0;
		for (int num3 = middles.Length; i < num3; i++)
		{
			if (verts[4 * i].x <= num)
			{
				num2 = 0f;
			}
			num = verts[4 * i].x;
			char value = textMesh.hyphenedText[i];
			if (!keepRotated.Contains(value))
			{
				verts[4 * i] = RotateVertAroundMiddle(verts[4 * i], middles[i], eulerRotation);
				verts[4 * i + 1] = RotateVertAroundMiddle(verts[4 * i + 1], middles[i], eulerRotation);
				verts[4 * i + 2] = RotateVertAroundMiddle(verts[4 * i + 2], middles[i], eulerRotation);
				verts[4 * i + 3] = RotateVertAroundMiddle(verts[4 * i + 3], middles[i], eulerRotation);
			}
			if (useEvenSpacing)
			{
				float num4 = num2 - verts[4 * i].x;
				verts[4 * i].x += num4;
				verts[4 * i + 1].x += num4;
				verts[4 * i + 2].x += num4;
				verts[4 * i + 3].x += num4;
				num2 = verts[4 * i + 2].x + evenSpacing;
			}
		}
		for (int j = 0; j < verts.Length; j++)
		{
			verts[j] = RotateVertAroundMiddle(verts[j], Vector3.zero, -eulerRotation);
		}
	}

	public Vector3 RotateVertAroundMiddle(Vector3 vert, Vector3 middle, Vector3 euler)
	{
		return Quaternion.Euler(euler) * (vert - middle) + middle;
	}
}
