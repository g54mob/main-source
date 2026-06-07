using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERSideWalk
	{
		public string name = "";

		public double id;

		public double timestamp;

		public int layer = 0;

		public float sidewalkWidth = 1.5f;

		public float curbHeight = 0.25f;

		public float curbDepth = 0.25f;

		public bool beveledCurb = false;

		public float beveledHeight = 0f;

		public float beveledDepth = 0f;

		public bool outerCurb = false;

		public bool roadSideCurbUVControl = false;

		public bool outerSideCurbUVControl = false;

		public Material material;

		public Material pavementMaterial;

		public bool hardEdges = false;

		public float hardEdgePadding = 0f;

		public List<Vector2> shape = new List<Vector2>();

		public List<float> shapePercentages = new List<float>();

		public List<float> shapeCurbPercentages = new List<float>();

		public List<float> sidewalkUVs = new List<float>();

		public List<float> curbUVs = new List<float>();

		public List<bool> doConnectionTri = new List<bool>();

		public Rect tileRect = default(Rect);

		public float tileSize = 1f;

		public float tiling = 1f;

		public float uvRatio = 1f;

		public float minEnd = 1f;

		public float maxEnd = 1f;

		public bool lockUVs = false;

		public bool planarUVs = false;

		public float planarTileSize = 1f;

		public Vector2 planarTiling = Vector2.one;

		public float planarUVRatioX = 1f;

		public float planarUVRatioY = 1f;

		public float cornerRadius = 1f;

		public float defaultCornerRadius = 1f;

		public int cornerSegments = 5;

		public int defaultCornerSegments = 5;

		public float innerSegmentDistance = 0.5f;

		public int pavementIndex = 2;

		public float pavementSize = 0f;

		public int curbVecCount = 0;

		public int subdivision = 0;

		public bool crosswalkPavement = false;

		public bool crosswalkPavementCurb = false;

		public bool includeOuterStrip = false;

		public bool useCrosswalkUVs = false;

		public float crosswalkLevelDistance = 0.5f;

		public float crosswalkdepth = 1f;

		public List<Vector2> crosswalkUVs = new List<Vector2>();

		public float crosswalkLevelYLeft = 0.9f;

		public float crosswalkLevelYRight = 0.1f;

		public float crosswalkStripYLeft = 0.95f;

		public float crosswalkStripYRight = 0.05f;

		public float crosswalkSize = 5f;

		public float crosswalkWidth = 1f;

		public float crosswalkMinHeight = 0.02f;

		public float crosswalkMaxHeight = 0.05f;

		public float bottomInnerDistance = 0f;

		public float topInnerDistance = 0f;

		public float bottomStripDistance = 0f;

		public float topStripDistance = 0f;

		public List<float> yPositions = new List<float>();

		public int realPavementIndex = 0;

		public int realColCount = 0;

		public float crosswalkOuterUVX = 0f;

		public float crosswalkOuterOffset;

		public float crosswalkOuterStripOffset;

		public float crosswalkStripUVX = 0f;

		public float texSizeRatio = 1f;

		public bool castShadow = true;

		public bool isStatic = true;

		public static ERSideWalk CreateInstance(int count)
		{
			ERSideWalk eRSideWalk = new ERSideWalk();
			eRSideWalk.name = "Sidewalk " + count;
			eRSideWalk.timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			eRSideWalk.id = eRSideWalk.timestamp;
			return eRSideWalk;
		}

		public void UpdateTimestamp()
		{
			timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}

		public static ERSideWalk GetSidewalk(List<ERSideWalk> sidewalks, double id)
		{
			if (sidewalks.Count > 0)
			{
				for (int i = 0; i < sidewalks.Count; i++)
				{
					if (sidewalks[i].id == id)
					{
						return sidewalks[i];
					}
				}
			}
			return null;
		}

		public static int GetSidewalkIndex(List<ERSideWalk> sidewalks, double id)
		{
			if (sidewalks.Count > 0)
			{
				for (int i = 0; i < sidewalks.Count; i++)
				{
					if (sidewalks[i].id == id)
					{
						return i + 1;
					}
				}
			}
			return 0;
		}

		public static string[] SidewalkNames(List<ERSideWalk> tsidewalks, double id, ref int index, ref double[] swIndexes)
		{
			List<ERSideWalk> list = new List<ERSideWalk>(tsidewalks);
			List<string> list2 = new List<string>();
			List<double> list3 = new List<double>();
			if (list.Count > 0)
			{
				list2.Add("Select Sidewalk");
				list3.Add(0.0);
				int num = 1;
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].id == id)
					{
						index = i + 1;
					}
					list2.Add(num + ".  " + list[i].name);
					list3.Add(list[i].id);
					num++;
				}
			}
			else
			{
				list2.Add("No Sidewalks Available");
			}
			swIndexes = list3.ToArray();
			return list2.ToArray();
		}

		public static void CopySidewalk(ERSideWalk source, ERSideWalk target)
		{
			target.name = source.name;
			target.id = source.id;
			target.timestamp = source.timestamp;
			target.layer = source.layer;
			target.sidewalkWidth = source.sidewalkWidth;
			target.curbHeight = source.curbHeight;
			target.curbDepth = source.curbDepth;
			target.beveledCurb = source.beveledCurb;
			target.beveledHeight = source.beveledHeight;
			target.beveledDepth = source.beveledDepth;
			target.outerCurb = source.outerCurb;
			target.roadSideCurbUVControl = source.roadSideCurbUVControl;
			target.outerSideCurbUVControl = source.outerSideCurbUVControl;
			target.material = source.material;
			target.pavementMaterial = source.pavementMaterial;
			target.hardEdges = source.hardEdges;
			target.shape = new List<Vector2>(source.shape);
			target.sidewalkUVs = new List<float>(source.sidewalkUVs);
			target.curbUVs = new List<float>(source.curbUVs);
			target.doConnectionTri = new List<bool>(source.doConnectionTri);
			target.tileRect = source.tileRect;
			target.tileSize = source.tileSize;
			target.tiling = source.tiling;
			target.minEnd = source.minEnd;
			target.maxEnd = source.maxEnd;
			target.lockUVs = source.lockUVs;
			target.subdivision = source.subdivision;
			target.planarUVs = source.planarUVs;
			target.planarTileSize = source.planarTileSize;
			target.planarTiling = source.planarTiling;
			target.planarUVRatioX = source.planarUVRatioX;
			target.cornerRadius = source.cornerRadius;
			target.cornerSegments = source.cornerSegments;
			target.innerSegmentDistance = source.innerSegmentDistance;
			target.pavementIndex = source.pavementIndex;
			target.pavementSize = source.pavementSize;
			target.crosswalkPavement = source.crosswalkPavement;
			target.crosswalkPavementCurb = source.crosswalkPavementCurb;
			target.includeOuterStrip = source.includeOuterStrip;
			target.crosswalkUVs = new List<Vector2>(source.crosswalkUVs);
			target.crosswalkLevelYLeft = source.crosswalkLevelYLeft;
			target.crosswalkLevelYRight = source.crosswalkLevelYRight;
			target.crosswalkStripYLeft = source.crosswalkStripYLeft;
			target.crosswalkStripYRight = source.crosswalkStripYRight;
			target.crosswalkSize = source.crosswalkSize;
			target.crosswalkWidth = source.crosswalkWidth;
			target.crosswalkMinHeight = source.crosswalkMinHeight;
			target.crosswalkMaxHeight = source.crosswalkMaxHeight;
			target.bottomInnerDistance = source.bottomInnerDistance;
			target.topInnerDistance = source.topInnerDistance;
			target.bottomStripDistance = source.bottomStripDistance;
			target.topStripDistance = source.topStripDistance;
			target.yPositions = new List<float>(source.yPositions);
			target.realPavementIndex = source.realPavementIndex;
			target.realColCount = source.realColCount;
			target.crosswalkOuterUVX = source.crosswalkOuterUVX;
			target.crosswalkOuterOffset = source.crosswalkOuterOffset;
			target.crosswalkOuterStripOffset = source.crosswalkOuterStripOffset;
			target.crosswalkStripUVX = source.crosswalkStripUVX;
			target.crosswalkLevelDistance = source.crosswalkLevelDistance;
			target.crosswalkdepth = source.crosswalkdepth;
			target.texSizeRatio = source.texSizeRatio;
			target.castShadow = source.castShadow;
		}

		public static ERSideWalk Upgrade(List<ERSideWalk> sidewalks, float width, float curbHeight, float curbDepth, bool beveledCurb, float bevelHeight, float beveldepth, bool outerCurb, List<float> uvs, Material mat)
		{
			ERSideWalk eRSideWalk = FindSidewalk(sidewalks, width, curbHeight, curbDepth, beveledCurb, bevelHeight, beveldepth, outerCurb, mat);
			if (eRSideWalk == null)
			{
				sidewalks.Add(CreateInstance(sidewalks.Count + 1));
				eRSideWalk = sidewalks[sidewalks.Count - 1];
				eRSideWalk.beveledCurb = beveledCurb;
				eRSideWalk.beveledDepth = beveldepth;
				eRSideWalk.beveledHeight = bevelHeight;
				eRSideWalk.curbDepth = curbDepth;
				eRSideWalk.curbHeight = curbHeight;
				eRSideWalk.outerCurb = outerCurb;
				eRSideWalk.sidewalkWidth = width;
				eRSideWalk.sidewalkUVs = new List<float>(uvs);
				eRSideWalk.material = mat;
				ERSideWalkVecs.OCCDCDODDO(eRSideWalk, null, null, -1, 0f, updateMesh: false);
				eRSideWalk.OCOODDDQCC();
				eRSideWalk.GetCrosswalkWidth();
			}
			return eRSideWalk;
		}

		public static ERSideWalk FindSidewalk(List<ERSideWalk> sidewalks, float width, float curbHeight, float curbDepth, bool beveledCurb, float bevelHeight, float beveldepth, bool outerCurb, Material mat)
		{
			ERSideWalk result = null;
			for (int i = 0; i < sidewalks.Count; i++)
			{
				if (sidewalks[i].beveledCurb == beveledCurb && sidewalks[i].beveledDepth == beveldepth && sidewalks[i].beveledHeight == bevelHeight && sidewalks[i].curbDepth == curbDepth && sidewalks[i].curbHeight == curbHeight && sidewalks[i].outerCurb == outerCurb && sidewalks[i].sidewalkWidth == width && sidewalks[i].material == mat)
				{
					result = sidewalks[i];
					break;
				}
			}
			return result;
		}

		public static void RefreshSidewalks(List<ERSideWalk> sidewalks)
		{
			ERSideWalkInstanceScript[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERSideWalkInstanceScript)) as ERSideWalkInstanceScript[];
			ERSideWalkInstanceScript[] array2 = array;
			foreach (ERSideWalkInstanceScript eRSideWalkInstanceScript in array2)
			{
				if (eRSideWalkInstanceScript.instance == null)
				{
					continue;
				}
				foreach (ERSideWalk sidewalk in sidewalks)
				{
					if (eRSideWalkInstanceScript.instance.id == sidewalk.id)
					{
						if (eRSideWalkInstanceScript.instance.sidewalk != sidewalk)
						{
							eRSideWalkInstanceScript.instance.sidewalk = sidewalk;
						}
						break;
					}
				}
			}
		}

		public void OCOODDDQCC()
		{
			texSizeRatio = 1f;
			if (material != null && material.mainTexture != null)
			{
				texSizeRatio = (float)material.mainTexture.width * 1f / ((float)material.mainTexture.height * 1f);
			}
			float num = Mathf.Abs(sidewalkUVs[sidewalkUVs.Count - 1] - sidewalkUVs[0]) * texSizeRatio;
			float num2 = 0f;
			for (int i = 0; i < shape.Count - 1; i++)
			{
				num2 += Vector2.Distance(shape[i], shape[i + 1]);
			}
			uvRatio = num2 / num;
			realColCount = shape.Count;
			if (!beveledCurb)
			{
				pavementIndex = (realPavementIndex = 2);
				curbVecCount = 2;
				if (hardEdges)
				{
					curbVecCount++;
					realColCount++;
					if (outerCurb)
					{
						realColCount++;
					}
					realPavementIndex = pavementIndex + 1;
				}
			}
			else if (beveledHeight > 0f && beveledDepth > 0f)
			{
				pavementIndex = (realPavementIndex = 3);
				curbVecCount = 3;
				if (hardEdges)
				{
					curbVecCount += 2;
					realColCount += 2;
					if (outerCurb)
					{
						realColCount += 2;
					}
					realPavementIndex = pavementIndex + 2;
				}
			}
			else if (beveledHeight > 0f)
			{
				pavementIndex = (realPavementIndex = 2);
				curbVecCount = 2;
				if (hardEdges)
				{
					curbVecCount++;
					realColCount++;
					if (outerCurb)
					{
						realColCount++;
					}
					realPavementIndex = pavementIndex + 1;
				}
			}
			else if (beveledDepth > 0f)
			{
				pavementIndex = (realPavementIndex = 3);
				curbVecCount = 2;
				if (hardEdges)
				{
					curbVecCount++;
					realColCount++;
					if (outerCurb)
					{
						realColCount++;
					}
					realPavementIndex = pavementIndex + 1;
				}
			}
			else
			{
				pavementIndex = (realPavementIndex = 1);
				curbVecCount = 1;
				if (hardEdges)
				{
					realColCount++;
					if (outerCurb)
					{
						realColCount++;
					}
					realPavementIndex = pavementIndex + 1;
				}
			}
			pavementSize = shape[pavementIndex + 1].x - shape[pavementIndex].x;
			planarUVRatioX = (planarUVRatioY = pavementSize);
			shapePercentages.Clear();
			shapeCurbPercentages.Clear();
			for (int j = 0; j < shape.Count; j++)
			{
				shapePercentages.Add(shape[j].x / sidewalkWidth);
				float num3 = 0f;
				if (j <= pavementIndex)
				{
					num3 = shape[j].x / shape[pavementIndex].x;
					shapeCurbPercentages.Add(num3);
				}
				else
				{
					num3 = (shape[j].x - shape[pavementIndex + 1].x) / (sidewalkWidth - shape[pavementIndex + 1].x);
					shapeCurbPercentages.Add(num3);
				}
			}
		}

		public void SetCrosswalkUVs(int curbNodes)
		{
			crosswalkUVs.Clear();
			float num = sidewalkUVs[sidewalkUVs.Count - 1] + 0.05f;
			switch (curbNodes)
			{
			case 6:
				crosswalkUVs.Add(new Vector2(num, 0f));
				crosswalkUVs.Add(new Vector2(num, crosswalkLevelYRight));
				crosswalkUVs.Add(new Vector2(num, crosswalkLevelYLeft));
				crosswalkUVs.Add(new Vector2(num, 1f));
				if (crosswalkPavementCurb)
				{
					num += sidewalkUVs[1] - sidewalkUVs[0];
					crosswalkUVs.Add(new Vector2(num, 0f));
					crosswalkUVs.Add(new Vector2(num, crosswalkLevelYRight));
					crosswalkUVs.Add(new Vector2(num, crosswalkLevelYLeft));
					crosswalkUVs.Add(new Vector2(num, 0f));
					num += sidewalkUVs[2] - sidewalkUVs[1];
					crosswalkUVs.Add(new Vector2(num, 0f));
					crosswalkUVs.Add(new Vector2(num, crosswalkLevelYRight));
					crosswalkUVs.Add(new Vector2(num, crosswalkLevelYLeft));
					crosswalkUVs.Add(new Vector2(num, 0f));
					if (curbNodes >= 3)
					{
						num += sidewalkUVs[3] - sidewalkUVs[2];
						crosswalkUVs.Add(new Vector2(num, 0f));
						crosswalkUVs.Add(new Vector2(num, crosswalkLevelYRight));
						crosswalkUVs.Add(new Vector2(num, crosswalkLevelYLeft));
						crosswalkUVs.Add(new Vector2(num, 0f));
					}
				}
				num += 0.25f;
				crosswalkUVs.Add(new Vector2(num, 0f));
				crosswalkUVs.Add(new Vector2(num, 1f));
				break;
			case 12:
				crosswalkUVs.Add(new Vector2(num, 0f));
				crosswalkUVs.Add(new Vector2(num, crosswalkStripYRight));
				crosswalkUVs.Add(new Vector2(num, crosswalkLevelYRight));
				crosswalkUVs.Add(new Vector2(num, crosswalkLevelYLeft));
				crosswalkUVs.Add(new Vector2(num, crosswalkStripYLeft));
				crosswalkUVs.Add(new Vector2(num, 1f));
				num += 0.2f;
				crosswalkUVs.Add(new Vector2(num, 0f));
				crosswalkUVs.Add(new Vector2(num, crosswalkStripYRight));
				crosswalkUVs.Add(new Vector2(num, crosswalkStripYLeft));
				crosswalkUVs.Add(new Vector2(num, 1f));
				num += 0.05f;
				crosswalkUVs.Add(new Vector2(num, 0f));
				crosswalkUVs.Add(new Vector2(num, 1f));
				break;
			}
		}

		public void GetCrosswalkWidth()
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			if (!useCrosswalkUVs || crosswalkUVs.Count < 6)
			{
				yPositions.Clear();
				yPositions.Add(0f);
				yPositions.Add(crosswalkLevelDistance);
				yPositions.Add(crosswalkSize * 0.5f);
				yPositions.Add(crosswalkSize - crosswalkLevelDistance);
				yPositions.Add(crosswalkSize);
				crosswalkWidth = crosswalkdepth;
			}
			else if (crosswalkUVs.Count == 6)
			{
				num = crosswalkUVs[3].y - crosswalkUVs[0].y;
				num2 = crosswalkUVs[crosswalkUVs.Count - 2].x - crosswalkUVs[0].x;
				crosswalkWidth = num2 / num * crosswalkSize * texSizeRatio;
				bottomInnerDistance = (crosswalkUVs[1].y - crosswalkUVs[0].y) / num * crosswalkSize;
				topInnerDistance = (crosswalkUVs[2].y - crosswalkUVs[0].y) / num * crosswalkSize;
				yPositions.Clear();
				yPositions.Add(0f);
				yPositions.Add(bottomInnerDistance);
				yPositions.Add(crosswalkSize * 0.5f);
				yPositions.Add(topInnerDistance);
				yPositions.Add(crosswalkSize);
			}
			else
			{
				num = crosswalkUVs[5].y - crosswalkUVs[0].y;
				num2 = crosswalkUVs[crosswalkUVs.Count - 2].x - crosswalkUVs[0].x;
				float num4 = crosswalkUVs[6].x - crosswalkUVs[0].x;
				crosswalkWidth = num2 / num * crosswalkSize * texSizeRatio;
				num3 = num4 / num * crosswalkSize * texSizeRatio;
				bottomStripDistance = (crosswalkUVs[1].y - crosswalkUVs[0].y) / num * crosswalkSize;
				bottomInnerDistance = (crosswalkUVs[2].y - crosswalkUVs[0].y) / num * crosswalkSize;
				topInnerDistance = (crosswalkUVs[3].y - crosswalkUVs[0].y) / num * crosswalkSize;
				topStripDistance = (crosswalkUVs[4].y - crosswalkUVs[0].y) / num * crosswalkSize;
				yPositions.Clear();
				yPositions.Add(0f);
				yPositions.Add(bottomStripDistance);
				yPositions.Add(bottomInnerDistance);
				yPositions.Add(crosswalkSize * 0.5f);
				yPositions.Add(topInnerDistance);
				yPositions.Add(topStripDistance);
				yPositions.Add(crosswalkSize);
			}
			if (crosswalkWidth > sidewalkWidth - 2f * curbDepth)
			{
				crosswalkWidth = sidewalkWidth - 2f * curbDepth - 0.25f;
				Debug.LogWarning("EasyRoads3Dv3 Warning: " + name + " - The calculated crosswalk width is larger than the sidewalk pavement. The crosswalk width has been adjusted to fit the pavement width");
			}
			crosswalkOuterOffset = crosswalkWidth / (shape[pavementIndex + 1].x - shape[pavementIndex].x);
			crosswalkOuterStripOffset = num3 / (shape[pavementIndex + 1].x - shape[pavementIndex].x);
			crosswalkOuterUVX = Mathf.Lerp(sidewalkUVs[pavementIndex], sidewalkUVs[pavementIndex + 1], crosswalkOuterOffset);
			crosswalkStripUVX = Mathf.Lerp(sidewalkUVs[pavementIndex], sidewalkUVs[pavementIndex + 1], crosswalkOuterStripOffset);
		}

		public static void ClearSidewalkObjects(ERModularRoad road)
		{
			ERSideWalkInstanceScript[] componentsInChildren = road.gameObject.GetComponentsInChildren<ERSideWalkInstanceScript>();
			ERSideWalkInstanceScript[] array = componentsInChildren;
			foreach (ERSideWalkInstanceScript eRSideWalkInstanceScript in array)
			{
				UnityEngine.Object.DestroyImmediate(eRSideWalkInstanceScript.gameObject);
			}
		}
	}
}
