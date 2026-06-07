using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public struct ERCrosswalkInstance
	{
		public List<int> indexes;

		public ERSideWalk sidewalk;

		public List<float> uvy;

		public float curbHeight;

		public int subDivisionCount;

		public ERCrosswalkInstance(List<int> _indexes, ERSideWalk _sidewalk, List<float> _uvy, float _curbHeight, int _subDivisionCount)
		{
			indexes = _indexes;
			sidewalk = _sidewalk;
			uvy = _uvy;
			curbHeight = _curbHeight;
			subDivisionCount = _subDivisionCount;
		}

		public List<Vector3> CreateCrosswalk(ref List<Vector3> verts, ref List<Vector2> uvs, ref List<int> tris, ref int lastPavementCount, int leftright, bool triangulateSidewalk, bool isConnector, ERModularRoad road, ERCrossingPrefabs prefabScript)
		{
			string text = "";
			if (road != null)
			{
				text = "road object '" + road.gameObject.name + "'";
			}
			else if (prefabScript != null)
			{
				text = "road object '" + prefabScript.gameObject.name + "'";
			}
			bool flag = false;
			int count = verts.Count;
			int num = count;
			int num2 = indexes[0];
			int num3 = indexes[0];
			List<Vector3> list = new List<Vector3>();
			int count2 = uvy.Count;
			if (uvy[0] == 0f)
			{
				uvy.RemoveAt(0);
			}
			int num4 = 0;
			int num5 = 0;
			if (!sidewalk.includeOuterStrip)
			{
				num4 = num2 + sidewalk.realColCount + subDivisionCount;
				num5 = num2 + sidewalk.realColCount + 1 + subDivisionCount * 2;
				if (num4 >= num || num5 >= num)
				{
					num4 = num - 1;
					num5 = num4;
					if (!flag)
					{
						Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
					}
					flag = true;
				}
				Vector3 vector = Vector3.Lerp(verts[num4], verts[num5], sidewalk.crosswalkOuterOffset);
				Vector3 normalized = (vector - verts[num4]).normalized;
				verts.Add(vector);
				num++;
				list.Add(vector);
				uvs.Add(new Vector2(sidewalk.crosswalkOuterUVX, uvy[0]));
				if (triangulateSidewalk)
				{
					if (leftright == -1)
					{
						tris.Add(num2);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(num2);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(count);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
						tris.Add(count);
					}
					else
					{
						tris.Add(count);
						tris.Add(num2);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(num2);
						tris.Add(count);
						tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(count);
					}
				}
				count++;
				for (int i = 0; i < 4; i++)
				{
					num2 += sidewalk.realColCount + subDivisionCount;
					num3 = num2 + sidewalk.realColCount + subDivisionCount;
					num4 = num2 + sidewalk.realColCount + subDivisionCount;
					num5 = num2 + sidewalk.realColCount + 1 + subDivisionCount * 2;
					if (num4 >= num || num5 >= num)
					{
						num4 = num - 1;
						num5 = num4;
						if (!flag)
						{
							Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
						}
						flag = true;
					}
					vector = verts[num4];
					if (i < 3)
					{
						vector.y += curbHeight;
					}
					if (!isConnector)
					{
						vector = Vector3.Lerp(vector, verts[num5], sidewalk.crosswalkOuterOffset);
					}
					else
					{
						vector += normalized * sidewalk.crosswalkWidth;
					}
					list.Add(vector);
					if (triangulateSidewalk)
					{
						verts.Add(vector);
						num++;
						if (i < count2 - 1)
						{
							uvs.Add(new Vector2(sidewalk.crosswalkOuterUVX, uvy[1 + i]));
						}
						else
						{
							Debug.Log("EasyRoads3Dv3 warning: Crosswalk UV data is incorrect");
							uvs.Add(new Vector2(sidewalk.crosswalkOuterUVX, uvy[count2 - 1]));
						}
						if (leftright == -1)
						{
							tris.Add(count - 1);
							tris.Add(num2 + 1 + subDivisionCount * 2);
							tris.Add(count);
							tris.Add(num2 + 1 + subDivisionCount * 2);
							tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
							tris.Add(count);
						}
						else
						{
							tris.Add(num2 + 1 + subDivisionCount * 2);
							tris.Add(count - 1);
							tris.Add(count);
							tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
							tris.Add(num2 + 1 + subDivisionCount * 2);
							tris.Add(count);
						}
					}
					if (!sidewalk.useCrosswalkUVs)
					{
						if (!triangulateSidewalk)
						{
							verts.Add(vector);
							num++;
							if (i < count2 - 1)
							{
								if (uvy[1 + i] == 0f)
								{
									uvs.Add(new Vector2(sidewalk.crosswalkOuterUVX, uvs[num3].y));
								}
								else
								{
									uvs.Add(new Vector2(sidewalk.crosswalkOuterUVX, uvy[1 + i]));
								}
							}
							else
							{
								Debug.Log("EasyRoads3Dv3 warning: Crosswalk UV data is incorrect");
								uvs.Add(new Vector2(sidewalk.crosswalkOuterUVX, uvy[count2 - 1]));
							}
						}
						if (leftright == -1)
						{
							if (i < 3)
							{
								tris.Add(count - 1);
								tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
								tris.Add(num2);
								tris.Add(count - 1);
								tris.Add(count);
								tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
							}
							else
							{
								tris.Add(count - 1);
								tris.Add(count);
								tris.Add(num2);
								tris.Add(num2);
								tris.Add(count);
								tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
							}
						}
						else if (i < 3)
						{
							tris.Add(count - 1);
							tris.Add(num2);
							tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
							tris.Add(count - 1);
							tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
							tris.Add(count);
						}
						else
						{
							tris.Add(count - 1);
							tris.Add(num2);
							tris.Add(count);
							tris.Add(count);
							tris.Add(num2);
							tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						}
					}
					count++;
				}
				count--;
				num2 += sidewalk.realColCount + subDivisionCount;
				lastPavementCount = num2 + sidewalk.realColCount + subDivisionCount;
				if (triangulateSidewalk)
				{
					if (leftright == -1)
					{
						tris.Add(num2);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(count);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
					}
					else
					{
						tris.Add(count);
						tris.Add(num2);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
					}
				}
				if (sidewalk.useCrosswalkUVs)
				{
					num2 = indexes[0] + sidewalk.realColCount + subDivisionCount;
					count = (lastPavementCount = verts.Count);
					num4 = num2;
					num5 = num2 + sidewalk.realColCount + subDivisionCount;
					if (num4 >= num || num5 >= num)
					{
						num4 = num - 1;
						num5 = num4;
						if (!flag)
						{
							Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
						}
						flag = true;
					}
					verts.Add(verts[num4]);
					num++;
					uvs.Add(sidewalk.crosswalkUVs[0]);
					verts.Add(list[0]);
					num++;
					uvs.Add(sidewalk.crosswalkUVs[4]);
					verts.Add(verts[num5]);
					num++;
					uvs.Add(sidewalk.crosswalkUVs[1]);
					verts.Add(list[1]);
					num++;
					uvs.Add(new Vector2(sidewalk.crosswalkUVs[4].x, sidewalk.crosswalkUVs[1].y));
					if (leftright == -1)
					{
						tris.Add(count);
						tris.Add(count + 1);
						tris.Add(count + 2);
						tris.Add(count + 2);
						tris.Add(count + 1);
						tris.Add(count + 3);
					}
					else
					{
						tris.Add(count + 1);
						tris.Add(count);
						tris.Add(count + 2);
						tris.Add(count + 1);
						tris.Add(count + 2);
						tris.Add(count + 3);
					}
					num4 = num2 + (sidewalk.realColCount + subDivisionCount) * 2;
					if (num4 >= num)
					{
						num4 = num - 1;
						num5 = num4;
						if (!flag)
						{
							Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
						}
						flag = true;
					}
					verts.Add(verts[num4]);
					num++;
					float y = Mathf.Lerp(sidewalk.crosswalkUVs[0].x, sidewalk.crosswalkUVs[3].x, 0.5f);
					uvs.Add(new Vector2(sidewalk.crosswalkUVs[0].x, y));
					verts.Add(list[2]);
					num++;
					uvs.Add(new Vector2(sidewalk.crosswalkUVs[4].x, y));
					if (leftright == -1)
					{
						tris.Add(count + 2);
						tris.Add(count + 3);
						tris.Add(count + 4);
						tris.Add(count + 4);
						tris.Add(count + 3);
						tris.Add(count + 5);
					}
					else
					{
						tris.Add(count + 3);
						tris.Add(count + 2);
						tris.Add(count + 4);
						tris.Add(count + 3);
						tris.Add(count + 4);
						tris.Add(count + 5);
					}
					num4 = num2 + (sidewalk.realColCount + subDivisionCount) * 3;
					if (num4 >= num)
					{
						num4 = num - 1;
						num5 = num4;
						if (!flag)
						{
							Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
						}
						flag = true;
					}
					verts.Add(verts[num4]);
					num++;
					uvs.Add(sidewalk.crosswalkUVs[2]);
					verts.Add(list[3]);
					num++;
					uvs.Add(new Vector2(sidewalk.crosswalkUVs[4].x, sidewalk.crosswalkUVs[2].y));
					if (leftright == -1)
					{
						tris.Add(count + 4);
						tris.Add(count + 5);
						tris.Add(count + 7);
						tris.Add(count + 4);
						tris.Add(count + 7);
						tris.Add(count + 6);
					}
					else
					{
						tris.Add(count + 5);
						tris.Add(count + 4);
						tris.Add(count + 7);
						tris.Add(count + 7);
						tris.Add(count + 4);
						tris.Add(count + 6);
					}
					num4 = num2 + (sidewalk.realColCount + subDivisionCount) * 4;
					if (num4 >= num)
					{
						num4 = num - 1;
						num5 = num4;
						if (!flag)
						{
							Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
						}
						flag = true;
					}
					verts.Add(verts[num4]);
					num++;
					uvs.Add(sidewalk.crosswalkUVs[3]);
					verts.Add(list[4]);
					num++;
					uvs.Add(sidewalk.crosswalkUVs[5]);
					if (leftright == -1)
					{
						tris.Add(count + 6);
						tris.Add(count + 7);
						tris.Add(count + 9);
						tris.Add(count + 6);
						tris.Add(count + 9);
						tris.Add(count + 8);
					}
					else
					{
						tris.Add(count + 7);
						tris.Add(count + 6);
						tris.Add(count + 9);
						tris.Add(count + 9);
						tris.Add(count + 6);
						tris.Add(count + 8);
					}
				}
			}
			else
			{
				num4 = num2 + sidewalk.realColCount + subDivisionCount;
				num5 = num2 + sidewalk.realColCount + 1 + subDivisionCount * 2;
				if (num4 >= num || num5 >= num)
				{
					num4 = num - 1;
					num5 = num4;
					if (!flag)
					{
						Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
					}
					flag = true;
				}
				Vector3 vector2 = Vector3.Lerp(verts[num4], verts[num5], sidewalk.crosswalkOuterStripOffset);
				verts.Add(vector2);
				num++;
				list.Add(vector2);
				uvs.Add(new Vector2(sidewalk.crosswalkStripUVX, uvy[0]));
				Vector3 normalized2 = (vector2 - verts[num4]).normalized;
				Vector3 vector3 = Vector3.Lerp(verts[num4], verts[num5], sidewalk.crosswalkOuterOffset);
				verts.Add(vector3);
				num++;
				list.Add(vector3);
				uvs.Add(new Vector2(sidewalk.crosswalkOuterUVX, uvy[0]));
				float num6 = Vector3.Distance(vector2, vector3);
				if (triangulateSidewalk)
				{
					if (leftright == -1)
					{
						tris.Add(num2);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(num2);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(count);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
						tris.Add(count);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(count + 1);
						tris.Add(count);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
						tris.Add(count + 1);
					}
					else
					{
						tris.Add(count);
						tris.Add(num2);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(num2);
						tris.Add(count);
						tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(count);
						tris.Add(count + 1);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(count);
						tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(count + 1);
					}
				}
				count += 2;
				for (int j = 0; j < 6; j++)
				{
					num2 += sidewalk.realColCount + subDivisionCount;
					num4 = num2 + sidewalk.realColCount + subDivisionCount;
					num5 = num2 + sidewalk.realColCount + 1 + subDivisionCount * 2;
					if (num4 >= num || num5 >= num)
					{
						num4 = num - 1;
						num5 = num4;
						if (!flag)
						{
							Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
						}
						flag = true;
					}
					vector3 = verts[num4];
					if (j > 0 && j < 4)
					{
						vector3.y += curbHeight;
					}
					if (!isConnector)
					{
						vector3 = Vector3.Lerp(vector3, verts[num5], sidewalk.crosswalkOuterOffset);
					}
					else
					{
						vector3 += normalized2 * sidewalk.crosswalkWidth;
					}
					list.Add(vector3);
					if (triangulateSidewalk)
					{
						verts.Add(vector3);
						num++;
						if (j < count2 - 1)
						{
							uvs.Add(new Vector2(sidewalk.crosswalkOuterUVX, uvy[1 + j]));
						}
						else
						{
							Debug.Log("EasyRoads3Dv3 warning: Crosswalk UV data is incorrect");
							uvs.Add(new Vector2(sidewalk.crosswalkOuterUVX, uvy[count2 - 1]));
						}
						if (leftright == -1)
						{
							tris.Add(count - 1);
							tris.Add(num2 + 1 + subDivisionCount);
							tris.Add(count);
							tris.Add(num2 + 1 + subDivisionCount);
							tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
							tris.Add(count);
						}
						else
						{
							tris.Add(num2 + 1 + subDivisionCount);
							tris.Add(count - 1);
							tris.Add(count);
							tris.Add(num2 + 1 + sidewalk.realColCount + subDivisionCount * 2);
							tris.Add(num2 + 1 + subDivisionCount);
							tris.Add(count);
						}
					}
					count++;
				}
				num2 += sidewalk.realColCount + subDivisionCount;
				lastPavementCount = num2 + sidewalk.realColCount + subDivisionCount;
				num4 = num2;
				num5 = num2 + 1 + subDivisionCount * 2;
				if (num4 >= num || num5 >= num)
				{
					num4 = num - 1;
					num5 = num4;
					if (!flag)
					{
						Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
					}
					flag = true;
				}
				vector3 = (isConnector ? (verts[num4] + normalized2 * (sidewalk.crosswalkWidth - num6)) : Vector3.Lerp(verts[num4], verts[num5], sidewalk.crosswalkOuterStripOffset));
				list.Add(vector3);
				if (triangulateSidewalk)
				{
					verts.Add(vector3);
					num++;
					if (count2 > 6)
					{
						uvs.Add(new Vector2(sidewalk.crosswalkStripUVX, uvy[6]));
					}
					else
					{
						Debug.Log("EasyRoads3Dv3 warning: Crosswalk UV data is incorrect");
						uvs.Add(new Vector2(sidewalk.crosswalkStripUVX, uvy[count2 - 1]));
					}
					if (leftright == -1)
					{
						tris.Add(num2);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(count);
						tris.Add(count - 1);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
						tris.Add(count - 1);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
					}
					else
					{
						tris.Add(count);
						tris.Add(num2);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + subDivisionCount);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
						tris.Add(count - 1);
						tris.Add(count);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
						tris.Add(num2 + 1 + subDivisionCount);
						tris.Add(count - 1);
						tris.Add(num2 + sidewalk.realColCount + 1 + subDivisionCount * 2);
					}
				}
				num2 = indexes[0] + sidewalk.realColCount + subDivisionCount;
				count = verts.Count;
				num4 = num2;
				num5 = num2 + sidewalk.realColCount + subDivisionCount;
				int num7 = num2 + 1 + sidewalk.realColCount + subDivisionCount * 2;
				if (num4 >= num || num5 >= num || num7 >= num)
				{
					num4 = num - 1;
					num5 = (num7 = num4);
					if (!flag)
					{
						Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
					}
					flag = true;
				}
				verts.Add(verts[num4]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[0]);
				verts.Add(list[0]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[6]);
				verts.Add(list[1]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[10]);
				verts.Add(verts[num5]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[1]);
				vector3 = Vector3.Lerp(verts[num5], verts[num7], sidewalk.crosswalkOuterStripOffset);
				verts.Add(vector3);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[7]);
				verts.Add(list[2]);
				num++;
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[10].x, sidewalk.crosswalkUVs[7].y));
				if (leftright == -1)
				{
					tris.Add(count);
					tris.Add(count + 1);
					tris.Add(count + 3);
					tris.Add(count + 1);
					tris.Add(count + 4);
					tris.Add(count + 3);
					tris.Add(count + 1);
					tris.Add(count + 2);
					tris.Add(count + 4);
					tris.Add(count + 2);
					tris.Add(count + 5);
					tris.Add(count + 4);
				}
				else
				{
					tris.Add(count + 1);
					tris.Add(count);
					tris.Add(count + 3);
					tris.Add(count + 4);
					tris.Add(count + 1);
					tris.Add(count + 3);
					tris.Add(count + 2);
					tris.Add(count + 1);
					tris.Add(count + 4);
					tris.Add(count + 5);
					tris.Add(count + 2);
					tris.Add(count + 4);
				}
				num4 = num2 + (sidewalk.realColCount + subDivisionCount) * 2;
				num5 = num2 + 1 + subDivisionCount + (sidewalk.realColCount + subDivisionCount) * 2;
				if (num4 >= num || num5 >= num)
				{
					num4 = num - 1;
					num5 = num4;
					if (!flag)
					{
						Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
					}
					flag = true;
				}
				verts.Add(verts[num4]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[2]);
				vector3 = verts[num4];
				vector3.y += curbHeight;
				vector3 = Vector3.Lerp(vector3, verts[num5], sidewalk.crosswalkOuterStripOffset);
				verts.Add(vector3);
				num++;
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[6].x, sidewalk.crosswalkUVs[2].y));
				verts.Add(list[3]);
				num++;
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[10].x, sidewalk.crosswalkUVs[2].y));
				if (leftright == -1)
				{
					tris.Add(count + 6);
					tris.Add(count + 4);
					tris.Add(count + 7);
					tris.Add(count + 6);
					tris.Add(count + 3);
					tris.Add(count + 4);
					tris.Add(count + 4);
					tris.Add(count + 5);
					tris.Add(count + 7);
					tris.Add(count + 5);
					tris.Add(count + 8);
					tris.Add(count + 7);
				}
				else
				{
					tris.Add(count + 4);
					tris.Add(count + 6);
					tris.Add(count + 7);
					tris.Add(count + 3);
					tris.Add(count + 6);
					tris.Add(count + 4);
					tris.Add(count + 5);
					tris.Add(count + 4);
					tris.Add(count + 7);
					tris.Add(count + 8);
					tris.Add(count + 5);
					tris.Add(count + 7);
				}
				num4 = num2 + (sidewalk.realColCount + subDivisionCount) * 3;
				num5 = num2 + 1 + subDivisionCount + (sidewalk.realColCount + subDivisionCount) * 3;
				if (num4 >= num || num5 >= num)
				{
					num4 = num - 1;
					num5 = num4;
					if (!flag)
					{
						Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
					}
					flag = true;
				}
				verts.Add(verts[num4]);
				num++;
				float y2 = Mathf.Lerp(sidewalk.crosswalkUVs[3].y, sidewalk.crosswalkUVs[2].y, 0.5f);
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[0].x, y2));
				vector3 = verts[num4];
				vector3.y += curbHeight;
				vector3 = Vector3.Lerp(vector3, verts[num5], sidewalk.crosswalkOuterStripOffset);
				verts.Add(vector3);
				num++;
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[6].x, y2));
				verts.Add(list[4]);
				num++;
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[10].x, y2));
				if (leftright == -1)
				{
					tris.Add(count + 9);
					tris.Add(count + 7);
					tris.Add(count + 10);
					tris.Add(count + 9);
					tris.Add(count + 6);
					tris.Add(count + 7);
					tris.Add(count + 7);
					tris.Add(count + 8);
					tris.Add(count + 10);
					tris.Add(count + 8);
					tris.Add(count + 11);
					tris.Add(count + 10);
				}
				else
				{
					tris.Add(count + 7);
					tris.Add(count + 9);
					tris.Add(count + 10);
					tris.Add(count + 6);
					tris.Add(count + 9);
					tris.Add(count + 7);
					tris.Add(count + 8);
					tris.Add(count + 7);
					tris.Add(count + 10);
					tris.Add(count + 11);
					tris.Add(count + 8);
					tris.Add(count + 10);
				}
				num4 = num2 + (sidewalk.realColCount + subDivisionCount) * 4;
				num5 = num2 + 1 + subDivisionCount + (sidewalk.realColCount + subDivisionCount) * 4;
				if (num4 >= num || num5 >= num)
				{
					num4 = num - 1;
					num5 = num4;
					if (!flag)
					{
						Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
					}
					flag = true;
				}
				verts.Add(verts[num4]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[3]);
				vector3 = verts[num4];
				vector3.y += curbHeight;
				vector3 = Vector3.Lerp(vector3, verts[num5], sidewalk.crosswalkOuterStripOffset);
				verts.Add(vector3);
				num++;
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[6].x, sidewalk.crosswalkUVs[3].y));
				verts.Add(list[5]);
				num++;
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[10].x, sidewalk.crosswalkUVs[3].y));
				if (leftright == -1)
				{
					tris.Add(count + 9);
					tris.Add(count + 13);
					tris.Add(count + 12);
					tris.Add(count + 9);
					tris.Add(count + 10);
					tris.Add(count + 13);
					tris.Add(count + 10);
					tris.Add(count + 14);
					tris.Add(count + 13);
					tris.Add(count + 10);
					tris.Add(count + 11);
					tris.Add(count + 14);
				}
				else
				{
					tris.Add(count + 13);
					tris.Add(count + 9);
					tris.Add(count + 12);
					tris.Add(count + 10);
					tris.Add(count + 9);
					tris.Add(count + 13);
					tris.Add(count + 14);
					tris.Add(count + 10);
					tris.Add(count + 13);
					tris.Add(count + 11);
					tris.Add(count + 10);
					tris.Add(count + 14);
				}
				num4 = num2 + (sidewalk.realColCount + subDivisionCount) * 5;
				num5 = num2 + 1 + subDivisionCount + (sidewalk.realColCount + subDivisionCount) * 5;
				if (num4 >= num || num5 >= num)
				{
					num4 = num - 1;
					num5 = num4;
					if (!flag)
					{
						Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
					}
					flag = true;
				}
				verts.Add(verts[num4]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[4]);
				vector3 = Vector3.Lerp(verts[num4], verts[num5], sidewalk.crosswalkOuterStripOffset);
				verts.Add(vector3);
				num++;
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[6].x, sidewalk.crosswalkUVs[4].y));
				verts.Add(list[6]);
				num++;
				uvs.Add(new Vector2(sidewalk.crosswalkUVs[10].x, sidewalk.crosswalkUVs[4].y));
				if (leftright == -1)
				{
					tris.Add(count + 12);
					tris.Add(count + 16);
					tris.Add(count + 15);
					tris.Add(count + 12);
					tris.Add(count + 13);
					tris.Add(count + 16);
					tris.Add(count + 13);
					tris.Add(count + 17);
					tris.Add(count + 16);
					tris.Add(count + 13);
					tris.Add(count + 14);
					tris.Add(count + 17);
				}
				else
				{
					tris.Add(count + 16);
					tris.Add(count + 12);
					tris.Add(count + 15);
					tris.Add(count + 13);
					tris.Add(count + 12);
					tris.Add(count + 16);
					tris.Add(count + 17);
					tris.Add(count + 13);
					tris.Add(count + 16);
					tris.Add(count + 14);
					tris.Add(count + 13);
					tris.Add(count + 17);
				}
				num4 = num2 + (sidewalk.realColCount + subDivisionCount) * 6;
				if (num4 >= num)
				{
					num4 = num - 1;
					num5 = num4;
					if (!flag)
					{
						Debug.Log("EasyRoads3Dv3 Warning: Issue detected with Sidewalk " + sidewalk.name + " on " + text + ", please report with a screenshot of the specific sidewalk");
					}
					flag = true;
				}
				verts.Add(verts[num4]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[5]);
				verts.Add(list[8]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[9]);
				verts.Add(list[7]);
				num++;
				uvs.Add(sidewalk.crosswalkUVs[11]);
				if (leftright == -1)
				{
					tris.Add(count + 15);
					tris.Add(count + 19);
					tris.Add(count + 18);
					tris.Add(count + 15);
					tris.Add(count + 16);
					tris.Add(count + 19);
					tris.Add(count + 16);
					tris.Add(count + 20);
					tris.Add(count + 19);
					tris.Add(count + 16);
					tris.Add(count + 17);
					tris.Add(count + 20);
				}
				else
				{
					tris.Add(count + 19);
					tris.Add(count + 15);
					tris.Add(count + 18);
					tris.Add(count + 16);
					tris.Add(count + 15);
					tris.Add(count + 19);
					tris.Add(count + 20);
					tris.Add(count + 16);
					tris.Add(count + 19);
					tris.Add(count + 17);
					tris.Add(count + 16);
					tris.Add(count + 20);
				}
			}
			return list;
		}
	}
}
