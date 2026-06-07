using UnityEngine;

public class ReplacementMesh : MonoBehaviour
{
	public MeshFilter MF;

	public MeshRenderer MR;

	public LODFurn LOD;

	public bool ReplaceMaterial = true;

	public bool HasLOD;

	public string ReplacementName = "";

	private void Reset()
	{
		MF = GetComponent<MeshFilter>();
		MR = GetComponent<MeshRenderer>();
		LOD = GetComponent<LODFurn>();
		HasLOD = LOD != null;
		ReplacementName = base.name;
	}
}
