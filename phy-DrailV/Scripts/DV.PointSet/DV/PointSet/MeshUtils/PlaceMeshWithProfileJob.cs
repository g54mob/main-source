using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;

namespace DV.PointSet.MeshUtils
{
	[BurstCompile]
	public struct PlaceMeshWithProfileJob : IJob
	{
		public NativeMeshContainer mesh;

		public NativeMeshProfile profile;

		public NativeEquiPointSet pointSet;

		public float startSpan;

		public float endSpan;

		public float slicesPerMeter;

		public float uvPerMeter;

		public float2 startPosOffset;

		public float2 endPosOffset;

		public float startSkew;

		public float endSkew;

		public bool useDeviationBasedPlacing;

		public float maxDeviation;

		private bool dirX;

		public void Execute()
		{
			startSpan = math.max(startSpan, 0f);
			endSpan = math.min(endSpan, pointSet.Span);
			float x = math.round((endSpan - startSpan) * slicesPerMeter);
			x = math.max(x, 2f);
			dirX = profile.uvDirection == NativeMeshProfile.UVDirection.X;
			if (useDeviationBasedPlacing)
			{
				float num = 0.2f;
				float num2 = startSpan;
				pointSet.Sample(num2, out var position, out var forward, out var up);
				for (float num3 = num2 + num; num3 < endSpan; num3 += num)
				{
					pointSet.Sample(num3, out var position2, out var _, out var _);
					position2 -= position;
					position2 = math.mul(math.inverse(quaternion.LookRotation(forward, up)), position2);
					if (math.abs(position2.x) > maxDeviation)
					{
						AddSection(math.unlerp(startSpan, endSpan, num2), math.unlerp(startSpan, endSpan, num3));
						num2 = num3;
						pointSet.Sample(num2, out position, out forward, out up);
					}
				}
				AddSection(math.unlerp(startSpan, endSpan, num2), 1f);
			}
			else
			{
				for (int i = 0; (float)i < x; i++)
				{
					float t = (float)i / x;
					float t2 = (float)(i + 1) / x;
					AddSection(t, t2);
				}
			}
		}

		private void AddSection(float t1, float t2)
		{
			float num = math.lerp(startSpan, endSpan, t1);
			float num2 = math.lerp(startSpan, endSpan, t2);
			pointSet.Sample(num, out var position, out var forward, out var up);
			quaternion q = quaternion.LookRotation(forward, up);
			pointSet.Sample(num2, out var position2, out var forward2, out var up2);
			quaternion q2 = quaternion.LookRotation(forward2, up2);
			float num3 = math.lerp(startSkew, endSkew, t1);
			float num4 = math.lerp(startSkew, endSkew, t2);
			float2 float5 = math.lerp(startPosOffset, endPosOffset, t1);
			float2 float6 = math.lerp(startPosOffset, endPosOffset, t2);
			for (int i = 0; i < profile.vertices.Length; i += 2)
			{
				NativeMeshProfile.ProfileVertex profileVertex = profile.vertices[i];
				NativeMeshProfile.ProfileVertex profileVertex2 = profile.vertices[i + 1];
				NativeMeshContainer.Vertex a = default(NativeMeshContainer.Vertex);
				NativeMeshContainer.Vertex b = default(NativeMeshContainer.Vertex);
				NativeMeshContainer.Vertex c = default(NativeMeshContainer.Vertex);
				NativeMeshContainer.Vertex d = default(NativeMeshContainer.Vertex);
				profileVertex.pos += float5;
				profileVertex2.pos += float6;
				a.pos = position + math.mul(q, new float3(profileVertex.pos, 0f));
				b.pos = position + math.mul(q, new float3(profileVertex2.pos, 0f));
				c.pos = position2 + math.mul(q2, new float3(profileVertex.pos, 0f));
				d.pos = position2 + math.mul(q2, new float3(profileVertex2.pos, 0f));
				a.pos += forward * num3 * profileVertex.pos.x;
				b.pos += forward * num3 * profileVertex2.pos.x;
				c.pos += forward2 * num4 * profileVertex.pos.x;
				d.pos += forward2 * num4 * profileVertex2.pos.x;
				a.normal = math.mul(q, profileVertex.normal);
				b.normal = math.mul(q, profileVertex2.normal);
				c.normal = math.mul(q2, profileVertex.normal);
				d.normal = math.mul(q2, profileVertex2.normal);
				float2 float7 = new float2(profileVertex.uv.x, (num + num3 * profileVertex.pos.x) * uvPerMeter + profileVertex.uv.y);
				float2 float8 = new float2(profileVertex2.uv.x, (num + num3 * profileVertex2.pos.x) * uvPerMeter + profileVertex2.uv.y);
				float2 float9 = new float2(profileVertex.uv.x, (num2 + num4 * profileVertex.pos.x) * uvPerMeter + profileVertex.uv.y);
				float2 float10 = new float2(profileVertex2.uv.x, (num2 + num4 * profileVertex2.pos.x) * uvPerMeter + profileVertex2.uv.y);
				a.uv = (dirX ? float7.yx : float7.xy);
				b.uv = (dirX ? float8.yx : float8.xy);
				c.uv = (dirX ? float9.yx : float9.xy);
				d.uv = (dirX ? float10.yx : float10.xy);
				AddQuad(a, b, c, d);
			}
		}

		private void AddQuad(NativeMeshContainer.Vertex a, NativeMeshContainer.Vertex b, NativeMeshContainer.Vertex c, NativeMeshContainer.Vertex d)
		{
			int length = mesh.vertices.Length;
			mesh.vertices.Add(a);
			mesh.vertices.Add(b);
			mesh.vertices.Add(c);
			mesh.vertices.Add(d);
			mesh.indices.Add(length);
			mesh.indices.Add(length + 1);
			mesh.indices.Add(length + 2);
			mesh.indices.Add(length + 1);
			mesh.indices.Add(length + 3);
			mesh.indices.Add(length + 2);
		}
	}
}
