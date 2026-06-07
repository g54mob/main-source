using System;
using UnityEngine;

public class LODFurn : MonoBehaviour
{
	public MeshRenderer Rend;

	public MeshFilter Mesh;

	[Header("LOD 0")]
	[ContextMenuItem("Show", "ShowLOD0")]
	[ContextMenuItem("Set", "SetLOD0")]
	public Mesh LOD0;

	public Vector3 Pos0;

	public Vector3 Scale0;

	[EulerAngles]
	public Quaternion Rot0;

	public Material Mat0;

	[Header("LOD 1")]
	[ContextMenuItem("Show", "ShowLOD1")]
	[ContextMenuItem("Set", "SetLOD1")]
	public Mesh LOD1;

	public Vector3 Pos1;

	public Vector3 Scale1;

	[EulerAngles]
	public Quaternion Rot1;

	public Material Mat1;

	[Header("LOD 2")]
	[ContextMenuItem("Show", "ShowLOD2")]
	[ContextMenuItem("Set", "SetLOD2")]
	public Mesh LOD2;

	public Vector3 Pos2;

	public Vector3 Scale2;

	[EulerAngles]
	public Quaternion Rot2;

	public Material Mat2;

	[Header("Overrides")]
	public bool OverrideTransform;

	public bool OverrideMaterial;

	public void ShowLOD0()
	{
		SetLOD(0);
	}

	public void SetLOD0()
	{
		LOD0 = Mesh.sharedMesh;
		Pos0 = base.transform.localPosition;
		Rot0 = base.transform.localRotation;
		Scale0 = base.transform.localScale;
		Mat0 = Rend.sharedMaterial;
	}

	public void ShowLOD1()
	{
		SetLOD(1);
	}

	public void SetLOD1()
	{
		LOD1 = Mesh.sharedMesh;
		Pos1 = base.transform.localPosition;
		Rot1 = base.transform.localRotation;
		Scale1 = base.transform.localScale;
		Mat1 = Rend.sharedMaterial;
	}

	public void ShowLOD2()
	{
		SetLOD(2);
	}

	public void SetLOD2()
	{
		LOD2 = Mesh.sharedMesh;
		Pos2 = base.transform.localPosition;
		Rot2 = base.transform.localRotation;
		Scale2 = base.transform.localScale;
		Mat2 = Rend.sharedMaterial;
	}

	[ContextMenu("Initialize")]
	public void Init()
	{
		Rend = GetComponent<MeshRenderer>();
		Mesh = GetComponent<MeshFilter>();
		LOD0 = (LOD1 = (LOD2 = Mesh.sharedMesh));
		Pos0 = (Pos1 = (Pos2 = base.transform.localPosition));
		Rot0 = (Rot1 = (Rot2 = base.transform.localRotation));
		Scale0 = (Scale1 = (Scale2 = base.transform.localScale));
		Mat0 = (Mat1 = (Mat2 = Rend.sharedMaterial));
	}

	[ContextMenu("Check Diff")]
	public void Diff()
	{
		float num = LOD0.triangles.Length;
		float num2 = LOD1.triangles.Length;
		Debug.Log(string.Concat(str2: ((float)LOD2.triangles.Length / num).ToPercent(), str0: (num2 / num).ToPercent(), str1: " -> "));
	}

	public void SetLOD(int g)
	{
		Mesh.sharedMesh = GetLOD(g);
		if (OverrideMaterial)
		{
			Rend.sharedMaterial = GetLODMaterial(g);
		}
		if (OverrideTransform)
		{
			base.transform.localPosition = GetLODPos(g);
			base.transform.localRotation = GetLODRot(g);
			base.transform.localScale = GetLODScale(g);
		}
	}

	public Mesh GetLOD(int g)
	{
		switch (g)
		{
		case 0:
			return LOD0;
		case 1:
			return LOD1;
		case 2:
			return LOD2;
		default:
			throw new Exception("Got out of range LOD group");
		}
	}

	public Vector3 GetLODPos(int g)
	{
		switch (g)
		{
		case 0:
			return Pos0;
		case 1:
			return Pos1;
		case 2:
			return Pos2;
		default:
			throw new Exception("Got out of range LOD group");
		}
	}

	public Quaternion GetLODRot(int g)
	{
		switch (g)
		{
		case 0:
			return Rot0;
		case 1:
			return Rot1;
		case 2:
			return Rot2;
		default:
			throw new Exception("Got out of range LOD group");
		}
	}

	public Vector3 GetLODScale(int g)
	{
		switch (g)
		{
		case 0:
			return Scale0;
		case 1:
			return Scale1;
		case 2:
			return Scale2;
		default:
			throw new Exception("Got out of range LOD group");
		}
	}

	public Material GetLODMaterial(int g)
	{
		switch (g)
		{
		case 0:
			return Mat0;
		case 1:
			return Mat1;
		case 2:
			return Mat2;
		default:
			throw new Exception("Got out of range LOD group");
		}
	}
}
