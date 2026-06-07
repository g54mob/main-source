using System.Collections.Generic;
using UnityEngine;

public class PACustomMeshParticleGenerator : PAMeshParticle, PAICustomParticleGenerator
{
	public List<PACustomMeshParticle> particles;

	private void Awake()
	{
		PAParticleField component = GetComponent<PAParticleField>();
		if ((bool)component && component.generatorType != PAParticleField.ParticleType.Custom)
		{
			component.generatorType = PAParticleField.ParticleType.Custom;
		}
	}

	private void OnValidate()
	{
		PAParticleField component = GetComponent<PAParticleField>();
		if ((bool)component && component.generatorType != PAParticleField.ParticleType.Custom)
		{
			component.generatorType = PAParticleField.ParticleType.Custom;
		}
		particles.ForEach(delegate(PACustomMeshParticle obj)
		{
			obj.SetDefaultValuesIfUninitialized();
		});
	}

	protected override void UpdateCache(PAParticleField settings)
	{
	}

	protected override int SetParticleCapacity(int count)
	{
		return particles.Count;
	}

	[ContextMenu("Apply Particles")]
	public void ApplyParticles()
	{
		Mesh sharedMesh = GetComponent<MeshFilter>().sharedMesh;
		if (!(sharedMesh != null) || particles == null || particles.Count <= 0)
		{
			return;
		}
		List<Vector3> list = new List<Vector3>();
		List<Vector3> list2 = new List<Vector3>();
		List<Vector4> list3 = new List<Vector4>();
		List<Vector2> list4 = new List<Vector2>();
		List<Vector2> list5 = new List<Vector2>();
		List<Color> list6 = new List<Color>();
		List<int> list7 = new List<int>();
		for (int i = 0; i < particles.Count; i++)
		{
			PACustomMeshParticle pACustomMeshParticle = particles[i];
			if (pACustomMeshParticle.mesh == null)
			{
				continue;
			}
			for (int j = 0; j < pACustomMeshParticle.mesh.triangles.Length; j++)
			{
				list7.Add(pACustomMeshParticle.mesh.triangles[j] + list.Count);
			}
			for (int k = 0; k < pACustomMeshParticle.mesh.vertexCount; k++)
			{
				list.Add(pACustomMeshParticle.mesh.vertices[k] * pACustomMeshParticle.size);
				if (pACustomMeshParticle.mesh.tangents != null && pACustomMeshParticle.mesh.tangents.Length != 0)
				{
					list3.Add(pACustomMeshParticle.mesh.tangents[k]);
				}
				else
				{
					list3.Add(new Vector4(0f, 1f, 0f, 1f));
				}
				Vector2 item = Vector2.Scale(pACustomMeshParticle.mesh.uv[k], pACustomMeshParticle.uv.size) + pACustomMeshParticle.uv.position;
				list4.Add(item);
				Vector2 zero = Vector2.zero;
				zero.x = PAMeshParticle.Vector3ToFloat(pACustomMeshParticle.mesh.normals[k]);
				zero.y = PAMeshParticle.Vector3ToFloat(pACustomMeshParticle.originDirection);
				list5.Add(zero);
				Color color = Color.white;
				if (pACustomMeshParticle.mesh.colors != null && pACustomMeshParticle.mesh.colors.Length != 0)
				{
					color = pACustomMeshParticle.mesh.colors[k];
				}
				list6.Add(color * pACustomMeshParticle.color);
				Vector3 zero2 = Vector3.zero;
				zero2.x = pACustomMeshParticle.speed;
				zero2.y = pACustomMeshParticle.spinSpeed;
				zero2.z = PAMeshParticle.Vector3ToFloat(pACustomMeshParticle.spinAxis);
				list2.Add(zero2);
			}
		}
		verts = list.ToArray();
		normals = list2.ToArray();
		tangents = list3.ToArray();
		uv0 = list4.ToArray();
		uv1 = list5.ToArray();
		colors = list6.ToArray();
		triangles = list7.ToArray();
		FillMesh(sharedMesh);
	}
}
