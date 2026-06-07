using System;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace DV.PointSet.MeshUtils
{
	[BurstCompile]
	public struct GetProfileFromMeshJob : IJob
	{
		public NativeMeshProfile profile;

		public NativeMeshContainer mesh;

		public GetProfileFromMeshJob(NativeMeshContainer mesh, NativeMeshProfile profile)
		{
			this.profile = profile;
			this.mesh = mesh;
		}

		public void Execute()
		{
			if (mesh.indices.Length % 3 != 0)
			{
				throw new Exception("Mesh is not made out of only triangles!");
			}
			for (int i = 0; i < mesh.indices.Length; i += 3)
			{
				NativeMeshContainer.Vertex v = mesh.vertices[mesh.indices[i]];
				NativeMeshContainer.Vertex v2 = mesh.vertices[mesh.indices[i + 1]];
				NativeMeshContainer.Vertex v3 = mesh.vertices[mesh.indices[i + 2]];
				int num = 0;
				if (v.pos.z > 0f)
				{
					num++;
				}
				if (v2.pos.z > 0f)
				{
					num++;
				}
				if (v3.pos.z > 0f)
				{
					num++;
				}
				NativeMeshContainer.Vertex d;
				NativeMeshContainer.Vertex e;
				bool dSet;
				if (num == 1)
				{
					d = default(NativeMeshContainer.Vertex);
					e = default(NativeMeshContainer.Vertex);
					dSet = false;
					CheckSide(v);
					CheckSide(v2);
					CheckSide(v3);
					if (Vector3.SignedAngle(d.pos - e.pos, d.normal, Vector3.forward) > 0f)
					{
						AddVertex(d, profile);
						AddVertex(e, profile);
					}
					else
					{
						AddVertex(e, profile);
						AddVertex(d, profile);
					}
				}
				void CheckSide(NativeMeshContainer.Vertex vertex)
				{
					if (vertex.pos.z < 0f)
					{
						if (dSet)
						{
							e = vertex;
						}
						else
						{
							d = vertex;
							dSet = true;
						}
					}
				}
			}
			void AddVertex(NativeMeshContainer.Vertex vertex, NativeMeshProfile profile)
			{
				float2 uv = ((profile.uvDirection == NativeMeshProfile.UVDirection.X) ? vertex.uv.yx : vertex.uv.xy);
				profile.vertices.Add(new NativeMeshProfile.ProfileVertex
				{
					pos = vertex.pos.xy,
					normal = vertex.normal,
					uv = uv
				});
			}
		}
	}
}
