using Assets.Scripts.Craft.MeshGen;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public static class SectionJoiner
	{
		[BurstCompile]
		private struct JoinJob : IJob
		{
			public CrossSection sectionA;

			public CrossSection sectionB;

			public NativeMesh mesh;

			public void Execute()
			{
				CrossSection section = sectionA;
				CrossSection section2 = sectionB;
				int num = -1;
				int num2 = -1;
				int num3 = 0;
				int num4 = 0;
				int num5 = -1;
				int num6 = -1;
				bool flag = false;
				bool flag2 = false;
				int num7 = 0;
				int num8 = 0;
				while (num3 < section.Points.Length || num4 < section2.Points.Length)
				{
					int num9 = num3 % section.Points.Length;
					int num10 = num4 % section2.Points.Length;
					Point point = section.Points[num9];
					Point point2 = section2.Points[num10];
					bool flag3;
					if (num3 == section.Points.Length)
					{
						flag3 = false;
					}
					else if (num4 == section2.Points.Length)
					{
						flag3 = true;
					}
					else if (num7 < num8)
					{
						flag3 = true;
					}
					else if (num7 > num8)
					{
						flag3 = false;
					}
					else if (flag || flag2)
					{
						flag3 = flag;
					}
					else
					{
						Point point3 = section.Points[(num3 + 1) % section.Points.Length];
						Point point4 = section2.Points[(num4 + 1) % section2.Points.Length];
						flag3 = math.distancesq(point3.Position, point2.Position) < math.distancesq(point4.Position, point.Position);
					}
					int num11 = (flag3 ? ((num3 + 1) % section.Points.Length) : ((num4 + 1) % section2.Points.Length));
					Point point5 = (flag3 ? section.Points[num11] : section2.Points[num11]);
					if (num == -1)
					{
						int num12 = (point.IsSmooth ? point.MeshIndexA : point.MeshIndexB);
						num = ((num12 != -1 && section.IsSmoothed) ? num12 : AddVertexToMesh(in section, num9, point.IsSmooth, !point.IsSmooth));
						num5 = num;
					}
					else if (!point.IsSmooth)
					{
						bool flag4 = flag2;
						int num13 = (flag4 ? point.MeshIndexA : point.MeshIndexB);
						num = ((num13 != -1) ? num13 : AddVertexToMesh(in section, num9, flag4, !flag4));
					}
					if (num2 == -1)
					{
						int num14 = (point2.IsSmooth ? point2.MeshIndexA : point2.MeshIndexB);
						num2 = ((num14 != -1 && section2.IsSmoothed) ? num14 : AddVertexToMesh(in section2, num10, point2.IsSmooth, !point2.IsSmooth));
						num6 = num2;
					}
					else if (!point2.IsSmooth)
					{
						bool flag5 = flag;
						int num15 = (flag5 ? point2.MeshIndexA : point2.MeshIndexB);
						num2 = ((num15 != -1) ? num15 : AddVertexToMesh(in section2, num10, flag5, !flag5));
					}
					CrossSection section3 = (flag3 ? section : section2);
					int num16 = ((num11 != 0 || !point5.IsSmooth) ? ((point5.MeshIndexA != -1 && section3.IsSmoothed) ? point5.MeshIndexA : AddVertexToMesh(in section3, num11, setMeshIdA: true, setMeshIdB: false)) : (flag3 ? num5 : num6));
					mesh.Tri(num, num2, num16);
					if (flag3)
					{
						num = num16;
						num3++;
						if (!point5.IsSmooth)
						{
							if (flag)
							{
								flag = false;
							}
							else
							{
								flag2 = true;
							}
						}
						if (point5.JoinProportionally)
						{
							num7++;
						}
						continue;
					}
					num2 = num16;
					num4++;
					if (!point5.IsSmooth)
					{
						if (flag2)
						{
							flag2 = false;
						}
						else
						{
							flag = true;
						}
					}
					if (point5.JoinProportionally)
					{
						num8++;
					}
				}
			}

			private int AddVertexToMesh(in CrossSection section, int idx, bool setMeshIdA, bool setMeshIdB)
			{
				NativeList<Point> points = section.Points;
				Point point = points[idx];
				int num = mesh.Vert(section.GetMeshPosition(point));
				if (setMeshIdA)
				{
					point.MeshIndexA = (short)num;
				}
				if (setMeshIdB)
				{
					point.MeshIndexB = (short)num;
				}
				if (setMeshIdA || setMeshIdB)
				{
					points[idx] = point;
				}
				return num;
			}
		}

		public static void Join(CrossSection root, CrossSection tip, MeshBuilder mesh)
		{
			new JoinJob
			{
				sectionA = root,
				sectionB = tip,
				mesh = mesh
			}.Run();
		}
	}
}
