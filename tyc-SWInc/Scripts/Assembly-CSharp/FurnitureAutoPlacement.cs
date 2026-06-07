using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public static class FurnitureAutoPlacement
{
	public class PlacementData
	{
		public Vector3 P;

		public Quaternion R;

		public SnapPoint Snap;

		public WallEdge E1;

		public WallEdge E2;

		public float WallPos;

		public PlacementData(Vector3 p, Quaternion r)
		{
			P = p;
			R = r;
		}

		public PlacementData(SnapPoint snap)
		{
			P = snap.transform.position;
			R = snap.transform.rotation;
			Snap = snap;
		}

		public PlacementData(SnapPoint snap, Quaternion r)
		{
			P = snap.transform.position;
			R = r;
			Snap = snap;
		}

		public PlacementData(SnapPoint snap, Vector3 p, Quaternion r)
		{
			P = p;
			R = r;
			Snap = snap;
		}

		public PlacementData(Vector3 p, Quaternion r, WallEdge e1, WallEdge e2, float wallPos)
		{
			P = p;
			R = r;
			E1 = e1;
			E2 = e2;
			WallPos = wallPos;
		}
	}

	public class PlacementAlgorithm
	{
		public string LocName;

		public Func<Furniture, Room, Quaternion, List<PlacementData>> F;

		public PlacementAlgorithm(string locName, Func<Furniture, Room, Quaternion, List<PlacementData>> f)
		{
			LocName = locName;
			F = f;
		}
	}

	public class CoverItem
	{
		public Furniture F;

		public Vector2 P;

		public float Cover;

		public CoverItem(Furniture f, Vector2 p)
		{
			F = f;
			P = p;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass24_0
	{
		public IList<Vector2> polygon;
	}

	public static Dictionary<string, PlacementAlgorithm> AutoPlacementFunctions = new Dictionary<string, PlacementAlgorithm>
	{
		{
			"Trashcan",
			new PlacementAlgorithm("PlacementNearComputer", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				foreach (PlacementData item in PlaceToCover(f, r, (Furniture x) => x.Type.Equals("Computer") && x.GetTrashCan() == null, new ValueTuple<Vector2, float>[3]
				{
					new ValueTuple<Vector2, float>(new Vector2(-0.5f, 0.75f), 90f),
					new ValueTuple<Vector2, float>(new Vector2(0.5f, 0.75f), 90f),
					new ValueTuple<Vector2, float>(new Vector2(0f, 1.2f), 0f)
				}, (Furniture x) =>
				{
					TrashCan component;
					return (!x.Type.Equals("Trashcan") || !x.TryGetComponent<TrashCan>(out component)) ? 0f : ((float)component.MaxTrash / 7f);
				}, 12.25f, 1f))
				{
					list.Add(item);
				}
				return list;
			})
		},
		{
			"Sprinkler",
			new PlacementAlgorithm("PlacementGrid", delegate(Furniture f, Room r, Quaternion rot)
			{
				float num = Mathf.Sqrt(2f) * 2f;
				List<PlacementData> list = new List<PlacementData>();
				foreach (PlacementData item2 in PlaceInGrid(f, r, rot, Mathf.Max(1, Mathf.FloorToInt(r.RoomBounds.width / num)), Mathf.Max(1, Mathf.FloorToInt(r.RoomBounds.height / num)), num, true, true, 4f))
				{
					list.Add(item2);
				}
				return list;
			})
		},
		{
			"Radiator",
			new PlacementAlgorithm("PlacementAlongWalls", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				float temperatureArea = r.GetTemperatureArea(false);
				temperatureArea -= r.TheoHeatingControlArea;
				float[] validHeights = GetValidHeights(f);
				using (IEnumerator<PlacementData> enumerator = FindPlaceOnWall(f, r, validHeights).GetEnumerator())
				{
					while (temperatureArea > 0f && enumerator.MoveNext())
					{
						temperatureArea -= f.HeatCoolArea;
						list.Add(enumerator.Current);
					}
				}
				return list;
			})
		},
		{
			"Ventilation",
			new PlacementAlgorithm("PlacementAlongWalls", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				float temperatureArea = r.GetTemperatureArea(true);
				temperatureArea -= r.TheoCoolingControlArea;
				float[] validHeights = GetValidHeights(f);
				using (IEnumerator<PlacementData> enumerator = FindPlaceOnWall(f, r, validHeights).GetEnumerator())
				{
					while (temperatureArea > 0f && enumerator.MoveNext())
					{
						temperatureArea -= f.HeatCoolArea;
						list.Add(enumerator.Current);
					}
				}
				return list;
			})
		},
		{
			"AllValidSnaps",
			new PlacementAlgorithm("PlacementEverywhere", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				foreach (SnapPoint item3 in FindAllSnaps(f, r, null, false, false))
				{
					list.Add(new PlacementData(item3));
				}
				return list;
			})
		},
		{
			"PCDesk",
			new PlacementAlgorithm("PlacementAtDesk", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				foreach (SnapPoint item4 in FindAllSnaps(f, r, null, true, true, (Furniture sf, SnapPoint s) => (s.transform.position.FlattenVector3() - sf.transform.position.FlattenVector3()).sqrMagnitude, (Furniture x) => x.SnapPoints.Count((SnapPoint z) => "OnTable".Equals(z.Name)) > 1))
				{
					list.Add(new PlacementData(item4));
				}
				return list;
			})
		},
		{
			"PCChair",
			new PlacementAlgorithm("PlacementNearComputer", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				HashList<Furniture> furniture = r.GetFurniture("Computer");
				if (furniture.Count > 0)
				{
					Vector3[] array = ((f.BuildBoundary == null) ? Array.Empty<Vector3>() : f.BuildBoundary.SelectInPlace((Vector2 x) => x.ToVector3(0f)));
					Vector2[] array2 = new Vector2[array.Length];
					for (int num = 0; num < furniture.Count; num++)
					{
						Furniture furniture2 = furniture[num];
						if (furniture2.SnappedTo != null && furniture2.ComputerChair == null)
						{
							foreach (SnapPoint link in furniture2.SnappedTo.Links)
							{
								if (f.DoesSnapTo(link.Name) && link.IsFree(true))
								{
									float y = Quaternion.LookRotation(link.transform.position - furniture2.transform.position).eulerAngles.y;
									y = Mathf.Max(Mathf.Abs(Mathf.DeltaAngle(furniture2.transform.rotation.eulerAngles.y, y)), Mathf.Abs(Mathf.DeltaAngle(link.transform.rotation.eulerAngles.y - 180f, y)));
									if (y < 5f)
									{
										ConvertBounds(array, array2, link.transform.localToWorldMatrix);
										if (CheckValid(f, link, null, null, link.transform.position, array2, r))
										{
											list.Add(new PlacementData(link));
										}
										break;
									}
								}
							}
						}
					}
				}
				return list;
			})
		},
		{
			"LampGrid",
			new PlacementAlgorithm("PlacementGrid", delegate(Furniture f, Room r, Quaternion rot)
			{
				if (f.Lighting <= 0f)
				{
					return new List<PlacementData>();
				}
				List<PlacementData> list = new List<PlacementData>();
				float num = 1f;
				float num2 = r.GetAtriumArea() / 16f;
				List<Furniture> furnitures = r.GetFurnitures();
				for (int i = 0; i < furnitures.Count; i++)
				{
					Furniture furniture = furnitures[i];
					num -= furniture.Lighting / num2;
				}
				int num3 = Mathf.CeilToInt(num * num2 / f.Lighting);
				if (num3 > 0)
				{
					Vector2Int gridSize = GetGridSize(r.RoomBounds, num3);
					foreach (PlacementData item5 in PlaceInGrid(f, r, rot, gridSize.x, gridSize.y, 2f))
					{
						list.Add(item5);
					}
				}
				return list;
			})
		},
		{
			"PalletDrop",
			new PlacementAlgorithm("NotApplicableAbbr", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				foreach (PlacementData item6 in PlacePalletPoint(f, r, true))
				{
					list.Add(item6);
				}
				return list;
			})
		},
		{
			"PalletPick",
			new PlacementAlgorithm("NotApplicableAbbr", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				foreach (PlacementData item7 in PlacePalletPoint(f, r, false))
				{
					list.Add(item7);
				}
				return list;
			})
		},
		{
			"Acoustics",
			new PlacementAlgorithm("PlacementOnWalls", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				int num = r.GetMissingAcousticElements(f.AcousticDampening);
				if (num > 0)
				{
					float[] validHeights = f.ValidHeights;
					if (num > validHeights.Length)
					{
						num = Mathf.CeilToInt((float)num / (float)validHeights.Length) * validHeights.Length;
					}
					using (IEnumerator<PlacementData> enumerator = FindPlaceOnWall(f, r, validHeights).GetEnumerator())
					{
						for (int i = 0; i < num; i++)
						{
							if (!enumerator.MoveNext())
							{
								break;
							}
							list.Add(enumerator.Current);
						}
					}
				}
				return list;
			})
		},
		{
			"AcousticsStagger",
			new PlacementAlgorithm("PlacementStaggered", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				int num = r.GetMissingAcousticElements(f.AcousticDampening);
				if (num > 0)
				{
					float[] validHeights = f.ValidHeights;
					if (num > validHeights.Length)
					{
						num = Mathf.CeilToInt((float)num / (float)validHeights.Length) * validHeights.Length;
					}
					using (IEnumerator<PlacementData> enumerator = FindPlaceOnWall(f, r, validHeights, Mathf.Max(f.Height2 - f.Height1, f.WallWidth) / 2f).GetEnumerator())
					{
						for (int i = 0; i < num; i++)
						{
							if (!enumerator.MoveNext())
							{
								break;
							}
							list.Add(enumerator.Current);
						}
					}
				}
				return list;
			})
		},
		{
			"FloorCool",
			new PlacementAlgorithm("PlacementAlongWalls", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				float temperatureArea = r.GetTemperatureArea(true);
				temperatureArea -= r.TheoCoolingControlArea;
				using (IEnumerator<PlacementData> enumerator = AlongBoundary(f, r).GetEnumerator())
				{
					while (temperatureArea > 0f && enumerator.MoveNext())
					{
						temperatureArea -= f.HeatCoolArea;
						list.Add(enumerator.Current);
					}
				}
				return list;
			})
		},
		{
			"FloorHeat",
			new PlacementAlgorithm("PlacementAlongWalls", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				float temperatureArea = r.GetTemperatureArea(false);
				temperatureArea -= r.TheoHeatingControlArea;
				using (IEnumerator<PlacementData> enumerator = AlongBoundary(f, r).GetEnumerator())
				{
					while (temperatureArea > 0f && enumerator.MoveNext())
					{
						temperatureArea -= f.HeatCoolArea;
						list.Add(enumerator.Current);
					}
				}
				return list;
			})
		},
		{
			"CeilingCool",
			new PlacementAlgorithm("PlacementGrid", delegate(Furniture f, Room r, Quaternion rot)
			{
				List<PlacementData> list = new List<PlacementData>();
				int num = Mathf.CeilToInt((r.GetTemperatureArea(true) - r.TheoCoolingControlArea) / f.HeatCoolArea);
				if (num > 0)
				{
					Vector2Int gridSize = GetGridSize(r.RoomBounds, num);
					using (IEnumerator<PlacementData> enumerator = PlaceInGrid(f, r, rot, gridSize.x, gridSize.y, 2f).GetEnumerator())
					{
						while (num > 0 && enumerator.MoveNext())
						{
							list.Add(enumerator.Current);
							num--;
						}
					}
				}
				return list;
			})
		}
	};

	private static bool[] _coveredABuffer;

	private static bool[] _usedBBuffer;

	private static int[] _aCoverageCountBuffer;

	private const int MaxIterations = 8;

	private static List<Rect> _rectCache = new List<Rect>();

	private static int[] _oscDesc = new int[4];

	private static int _lastPlace = 0;

	private static Vector2[] _cornerCache = new Vector2[4];

	private static Vector2Int GetGridSize(Rect bounds, int placements)
	{
		float num = bounds.width / bounds.height;
		int num2 = Mathf.Max(1, Mathf.RoundToInt(Mathf.Sqrt((float)placements * num)));
		int num3 = Mathf.Max(1, Mathf.RoundToInt(Mathf.Sqrt((float)placements / num)));
		while (true)
		{
			if (num2 * num3 < placements)
			{
				if (num2 > num3)
				{
					num2++;
				}
				else
				{
					num3++;
				}
				continue;
			}
			if (num2 > num3 && num2 > 1 && (num2 - 1) * num3 >= placements)
			{
				num2--;
				continue;
			}
			if (num3 <= num2 || num3 <= 1 || num2 * (num3 - 1) < placements)
			{
				break;
			}
			num3--;
		}
		return new Vector2Int(num2, num3);
	}

	private static IEnumerable<PlacementData> PlaceToCover(Furniture f, Room r, Func<Furniture, bool> needsCover, ValueTuple<Vector2, float>[] off, Func<Furniture, float> covers, float coverDistanceSqr, float maxMovementSqr)
	{
		List<CoverItem> list = new List<CoverItem>();
		List<Furniture> furnitures = r.GetFurnitures();
		for (int i = 0; i < furnitures.Count; i++)
		{
			Furniture furniture = furnitures[i];
			if (needsCover(furniture))
			{
				list.Add(new CoverItem(furniture, furniture.transform.position.FlattenVector3()));
			}
		}
		if (list.Count > 0 && covers != null)
		{
			List<CoverItem> list2 = new List<CoverItem>();
			List<Furniture> furnitures2 = r.GetFurnitures();
			for (int j = 0; j < furnitures2.Count; j++)
			{
				Furniture furniture2 = furnitures2[j];
				float num = covers(furniture2);
				if (!(num > 0f))
				{
					continue;
				}
				list2.Clear();
				for (int k = 0; k < list.Count; k++)
				{
					if ((list[k].P - furniture2.transform.position.FlattenVector3()).sqrMagnitude < coverDistanceSqr)
					{
						list2.Add(list[k]);
					}
				}
				for (int l = 0; l < list2.Count; l++)
				{
					list2[l].Cover += num / (float)list2.Count;
					if (list2[l].Cover >= 1f)
					{
						list.Remove(list2[l]);
					}
				}
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		List<ValueTuple<PlacementData, Vector2>> list3 = new List<ValueTuple<PlacementData, Vector2>>();
		List<Rect> applicableRects = GetApplicableRects(f, r, r.Floor * 2);
		Vector3[] array = ((f.BuildBoundary == null) ? Array.Empty<Vector3>() : f.BuildBoundary.SelectInPlace((Vector2 x) => x.ToVector3(0f)));
		Vector2[] transBounds = new Vector2[array.Length];
		Vector2[] offset = r.Edges.SelectInPlace((WallEdge x) => x.Pos).GetOffset(Room.WallOffset * 0.5f);
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			CoverItem coverItem = list[num2];
			for (int num3 = 0; num3 < off.Length; num3++)
			{
				ValueTuple<Vector2, float> valueTuple = off[num3];
				PlacementData placementData = new PlacementData((coverItem.P + (coverItem.F.transform.rotation * valueTuple.Item1.ToVector3(0f)).FlattenVector3()).ToVector3((float)r.Floor * 2f), Quaternion.Euler(0f, valueTuple.Item2, 0f) * coverItem.F.transform.rotation);
				if (FixData(f, r, placementData, maxMovementSqr, applicableRects, offset, array, transBounds))
				{
					list3.Add(new ValueTuple<PlacementData, Vector2>(placementData, placementData.P.FlattenVector3()));
				}
			}
		}
		if (list3.Count == 0)
		{
			yield break;
		}
		float coverCount = ((covers != null) ? covers(f) : 9999f);
		foreach (var item in FindMinimumCoveringB(list, list3, coverDistanceSqr, coverCount, (ValueTuple<PlacementData, Vector2> x) => x.Item2))
		{
			yield return item.Item1;
		}
	}

	public static IEnumerable<T> FindMinimumCoveringB<T>(List<CoverItem> A, List<T> B, float sqrDistance, float coverCount, Func<T, Vector2> getB)
	{
		int aCount = A.Count;
		int bCount = B.Count;
		if (aCount == 0 || bCount == 0)
		{
			yield break;
		}
		EnsureCapacity(ref _coveredABuffer, aCount);
		EnsureCapacity(ref _usedBBuffer, bCount);
		EnsureCapacity(ref _aCoverageCountBuffer, aCount);
		bool[] coveredA = _coveredABuffer;
		bool[] usedB = _usedBBuffer;
		int[] aCoverageCount = _aCoverageCountBuffer;
		Array.Clear(coveredA, 0, aCount);
		Array.Clear(usedB, 0, bCount);
		Array.Clear(aCoverageCount, 0, aCount);
		int coveredCount = 0;
		for (int i = 0; i < aCount; i++)
		{
			A[i].Cover = 0f;
		}
		List<List<int>> bCovers = new List<List<int>>(bCount);
		for (int j = 0; j < bCount; j++)
		{
			List<int> list = new List<int>();
			Vector2 vector = getB(B[j]);
			for (int k = 0; k < aCount; k++)
			{
				if ((A[k].P - vector).sqrMagnitude < sqrDistance)
				{
					list.Add(k);
					aCoverageCount[k]++;
				}
			}
			bCovers.Add(list);
		}
		while (coveredCount < aCount)
		{
			int bestBIndex = -1;
			float num = 0f;
			for (int l = 0; l < bCount; l++)
			{
				if (usedB[l])
				{
					continue;
				}
				List<int> list2 = bCovers[l];
				int num2 = 0;
				for (int m = 0; m < list2.Count; m++)
				{
					int num3 = list2[m];
					if (!coveredA[num3])
					{
						num2++;
					}
				}
				if (num2 == 0)
				{
					continue;
				}
				float a = coverCount / (float)num2;
				float num4 = 0f;
				for (int n = 0; n < list2.Count; n++)
				{
					int num5 = list2[n];
					if (coveredA[num5])
					{
						continue;
					}
					float num6 = 1f - A[num5].Cover;
					if (!(num6 <= 0f))
					{
						float num7 = Mathf.Min(a, num6);
						int num8 = aCoverageCount[num5];
						if (num8 > 0)
						{
							num4 += num7 / (float)num8;
						}
					}
				}
				if (num4 > num)
				{
					num = num4;
					bestBIndex = l;
				}
			}
			if (bestBIndex == -1 || num <= 0f)
			{
				break;
			}
			usedB[bestBIndex] = true;
			yield return B[bestBIndex];
			List<int> list3 = bCovers[bestBIndex];
			int num9 = 0;
			for (int num10 = 0; num10 < list3.Count; num10++)
			{
				int num11 = list3[num10];
				if (!coveredA[num11])
				{
					num9++;
				}
			}
			if (num9 == 0)
			{
				continue;
			}
			float num12 = coverCount / (float)num9;
			for (int num13 = 0; num13 < list3.Count; num13++)
			{
				int num14 = list3[num13];
				if (!coveredA[num14])
				{
					A[num14].Cover += num12;
					if (A[num14].Cover >= 1f)
					{
						coveredA[num14] = true;
						coveredCount++;
					}
				}
			}
		}
	}

	private static void EnsureCapacity<TItem>(ref TItem[] buffer, int needed)
	{
		if (buffer == null || buffer.Length < needed)
		{
			buffer = new TItem[needed];
		}
	}

	private static bool FixData(Furniture furn, Room r, PlacementData input, float maxMovementSqr, List<Rect> rects, Vector2[] rPoly, Vector3[] bounds, Vector2[] transBounds)
	{
		ConvertBounds(bounds, transBounds, Matrix4x4.TRS(input.P, input.R, Vector3.one));
		if (CheckValid(furn, null, null, null, input.P, transBounds, r))
		{
			return true;
		}
		Vector2 v = EaseFurniture(furn, input.P.FlattenVector3(), input.R, rects, rPoly);
		if (v.sqrMagnitude > maxMovementSqr)
		{
			return false;
		}
		input.P += v.ToVector3(0f);
		ConvertBounds(bounds, transBounds, Matrix4x4.TRS(input.P, input.R, Vector3.one));
		return CheckValid(furn, null, null, null, input.P, transBounds, r);
	}

	private static IEnumerable<PlacementData> PlacePalletPoint(Furniture furn, Room r, bool first)
	{
		HashSet<Furniture> hashSet = r.GetFurniture("Pallet").ToHashSet();
		if (furn.Conveyor.PalletOutput)
		{
			foreach (Furniture item in r.GetFurniture("PalletConnection"))
			{
				if (item.Conveyor.PalletOutput)
				{
					Conveyor output = item.Conveyor.GetOutput(0);
					if (output != null)
					{
						hashSet.Remove(output.Parent);
					}
				}
			}
		}
		List<SnapPoint> conveyors = new List<SnapPoint>();
		foreach (Furniture item2 in r.GetFurniture("Conveyor"))
		{
			SnapPoint snapPoint = item2.SnapPoints.FirstOrDefault((SnapPoint x) => furn.DoesSnapTo(x.Name));
			if (snapPoint != null)
			{
				conveyors.Add(snapPoint);
			}
		}
		Vector3[] bounds = ((furn.BuildBoundary == null) ? Array.Empty<Vector3>() : furn.BuildBoundary.SelectInPlace((Vector2 x) => x.ToVector3(0f)));
		Vector2[] transBounds = new Vector2[bounds.Length];
		foreach (Furniture item3 in hashSet)
		{
			if ((furn.Conveyor.PalletInput && item3.Conveyor.GetOutput(0) != null) || !item3.HasConveyor || !item3.Conveyor.PalletToInput)
			{
				continue;
			}
			Dictionary<Furniture, Quaternion?> dictionary = new Dictionary<Furniture, Quaternion?>();
			foreach (SnapPoint item4 in conveyors)
			{
				if (Conveyor.WithinDist(item4.transform.localToWorldMatrix.MultiplyPoint(furn.Conveyor.ConnectionPos.localPosition), item3.transform.position))
				{
					dictionary.Add(item4.Parent, item4.IsFree(true) ? new Quaternion?(Quaternion.identity) : ((Quaternion?)null));
				}
				else if (Conveyor.WithinDist(Matrix4x4.TRS(item4.transform.position, Quaternion.Euler(0f, 180f, 0f) * item4.transform.rotation, Vector3.one).MultiplyPoint(furn.Conveyor.ConnectionPos.localPosition), item3.transform.position))
				{
					dictionary.Add(item4.Parent, item4.IsFree(true) ? new Quaternion?(Quaternion.Euler(0f, 180f, 0f)) : ((Quaternion?)null));
				}
			}
			foreach (KeyValuePair<Furniture, Quaternion?> item5 in dictionary)
			{
				if (!item5.Value.HasValue)
				{
					continue;
				}
				Conveyor output2 = item5.Key.Conveyor.GetOutput(0);
				if (!(output2 != null))
				{
					continue;
				}
				if (dictionary.ContainsKey(output2.Parent))
				{
					if (first)
					{
						conveyors.Remove(item5);
						SnapPoint snapPoint2 = item5.Key.SnapPoints.First((SnapPoint x) => furn.DoesSnapTo(x.Name));
						Quaternion quaternion = item5.Value.Value * snapPoint2.transform.rotation;
						ConvertBounds(bounds, transBounds, Matrix4x4.TRS(snapPoint2.transform.position, quaternion, Vector3.one));
						if (CheckValid(furn, snapPoint2, null, null, snapPoint2.transform.position, transBounds, r))
						{
							yield return new PlacementData(snapPoint2, quaternion);
							break;
						}
					}
				}
				else if (!first)
				{
					conveyors.Remove(item5);
					SnapPoint snapPoint3 = item5.Key.SnapPoints.First((SnapPoint x) => furn.DoesSnapTo(x.Name));
					Quaternion quaternion2 = item5.Value.Value * snapPoint3.transform.rotation;
					ConvertBounds(bounds, transBounds, Matrix4x4.TRS(snapPoint3.transform.position, quaternion2, Vector3.one));
					if (CheckValid(furn, snapPoint3, null, null, snapPoint3.transform.position, transBounds, r))
					{
						yield return new PlacementData(snapPoint3, quaternion2);
						break;
					}
				}
			}
		}
	}

	private static IEnumerable<PlacementData> PlaceInGrid(Furniture furn, Room r, Quaternion rot, int w, int h, float padding, bool ignoreOutside = false, bool hardMax = false, float minDistSqr = -1f)
	{
		Vector3[] bounds = ((furn.BuildBoundary == null) ? Array.Empty<Vector3>() : furn.BuildBoundary.SelectInPlace((Vector2 v) => v.ToVector3(0f)));
		Vector2[] transBounds = new Vector2[bounds.Length];
		Rect buildRect = furn.GetBuildRect(Vector2.zero, rot);
		padding = Mathf.Max(buildRect.width, buildRect.height, padding);
		float wStep = ((w < 2) ? 0f : ((r.RoomBounds.width - padding) / (float)(w - 1)));
		float hStep = ((h < 2) ? 0f : ((r.RoomBounds.height - padding) / (float)(h - 1)));
		float padX = ((w < 2) ? (r.RoomBounds.width / 2f) : (padding / 2f));
		float padY = ((h < 2) ? (r.RoomBounds.height / 2f) : (padding / 2f));
		int k = w * h;
		if (hardMax)
		{
			k -= r.GetFurniture(furn.Type).Count;
		}
		List<Rect> applicableRects = GetApplicableRects(furn, r, r.Floor * 2);
		Vector2[] rPoly = r.Edges.SelectInPlace((WallEdge wallEdge) => wallEdge.Pos).GetOffset(Room.WallOffset * 0.5f);
		for (int x = 0; x < w; x++)
		{
			if (k <= 0)
			{
				break;
			}
			for (int y = 0; y < h && k > 0; y++)
			{
				float x2 = r.RoomBounds.xMin + padX + wStep * (float)x;
				float z = r.RoomBounds.yMin + padY + hStep * (float)y;
				Vector3 vector = new Vector3(x2, r.Floor * 2, z);
				if (ignoreOutside && !r.IsInside(vector))
				{
					continue;
				}
				if (minDistSqr > 0f)
				{
					HashList<Furniture> furniture = r.GetFurniture(furn.Type);
					bool flag = false;
					for (int num = 0; num < furniture.Count; num++)
					{
						if ((furniture[num].transform.position - vector).sqrMagnitude < minDistSqr)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
				}
				ConvertBounds(bounds, transBounds, Matrix4x4.TRS(vector, rot, Vector3.one));
				if (CheckValid(furn, null, null, null, vector, transBounds, r))
				{
					k--;
					yield return new PlacementData(vector, rot);
					continue;
				}
				vector += EaseFurniture(furn, vector.FlattenVector3(), rot, applicableRects, rPoly).ToVector3(0f);
				ConvertBounds(bounds, transBounds, Matrix4x4.TRS(vector, rot, Vector3.one));
				if (CheckValid(furn, null, null, null, vector, transBounds, r))
				{
					k--;
					yield return new PlacementData(vector, rot);
				}
			}
		}
	}

	private static List<Rect> GetApplicableRects(Furniture f, Room r, float y)
	{
		float floorOffset = y.GetFloorOffset(r.Floor);
		float height = f.Height1 + floorOffset;
		float height2 = f.Height2 + floorOffset;
		_rectCache.Clear();
		List<Furniture> furnitures = r.GetFurnitures();
		for (int i = 0; i < furnitures.Count; i++)
		{
			Furniture furniture = furnitures[i];
			if (UseFurn(f, furniture, null, height, height2))
			{
				_rectCache.Add(furniture.GetBuildRect().Expand(0.002f, 0.002f));
			}
		}
		return _rectCache;
	}

	private static bool DetectOsc()
	{
		if (_lastPlace > 2 && _oscDesc[0] == _oscDesc[2] && _oscDesc[1] == _oscDesc[3] && _oscDesc[0] != _oscDesc[1] && _oscDesc[0] >= 0)
		{
			return _oscDesc[1] >= 0;
		}
		return false;
	}

	private static Vector2 EaseFurniture(Furniture f, Vector2 pos, Quaternion rot, List<Rect> against, Vector2[] rPoly)
	{
		Vector2 vector = pos;
		Rect buildRect = f.GetBuildRect(pos, rot);
		Vector2 rhs = Vector2.zero;
		_lastPlace = 0;
		for (int i = 0; i < 8; i++)
		{
			Vector2 zero = Vector2.zero;
			for (int j = 0; j < against.Count; j++)
			{
				if (buildRect.FixedOverlaps(against[j]))
				{
					Vector2 vector2 = ResolveOverlap(buildRect, against[j]);
					if (vector2 != Vector2.zero)
					{
						zero += vector2;
						_oscDesc[_lastPlace % _oscDesc.Length] = j;
						_lastPlace++;
					}
				}
			}
			Vector2 vector3 = KeepRectInsidePolygon(buildRect, rPoly);
			if (vector3 != Vector2.zero)
			{
				zero += vector3;
				_oscDesc[_lastPlace % _oscDesc.Length] = -1;
				_lastPlace++;
			}
			if (DetectOsc())
			{
				zero += (against[_oscDesc[0]].center - against[_oscDesc[1]].center).normalized.Turn90();
			}
			if (!(zero != Vector2.zero))
			{
				break;
			}
			if (Vector2.Dot(zero, rhs) < 0f)
			{
				zero *= 0.3f;
			}
			rhs = zero;
			pos += zero;
			buildRect.position += zero;
		}
		return pos - vector;
	}

	private static bool UseFurn(Furniture check, Furniture against, Furniture ignore, float height1, float height2)
	{
		if (against != ignore && !against.IgnoreBoundary && against.FinalBoundary != null && !against.Type.Equals(check.IgnoreType) && !check.Type.Equals(against.IgnoreType) && (check.InFloor || against.InFloor || Utilities.Overlap(against.OffsetHeight(0), against.OffsetHeight(1), height1, height2)) && (!check.InFloor || against.InFloor || against.BlocksFloor))
		{
			if (against.InFloor && !check.InFloor)
			{
				return check.BlocksFloor;
			}
			return true;
		}
		return false;
	}

	private static Vector2 ResolveOverlap(Rect a, Rect b)
	{
		float num = b.xMax - a.xMin;
		float num2 = a.xMax - b.xMin;
		float num3 = b.yMax - a.yMin;
		float num4 = a.yMax - b.yMin;
		float num5 = Mathf.Min(num, num2);
		float num6 = Mathf.Min(num3, num4);
		Vector2 zero = Vector2.zero;
		if (num5 < num6)
		{
			if (num < num2)
			{
				zero.x = num;
			}
			else
			{
				zero.x = 0f - num2;
			}
		}
		else if (num3 < num4)
		{
			zero.y = num3;
		}
		else
		{
			zero.y = 0f - num4;
		}
		return zero;
	}

	public static Vector2 KeepRectInsidePolygon(Rect rect, IList<Vector2> polygon, float skin = 0.001f)
	{
		_003C_003Ec__DisplayClass24_0 _003C_003Ec__DisplayClass24_1 = default(_003C_003Ec__DisplayClass24_0);
		_003C_003Ec__DisplayClass24_1.polygon = polygon;
		if (_003C_003Ec__DisplayClass24_1.polygon == null || _003C_003Ec__DisplayClass24_1.polygon.Count < 3)
		{
			return Vector2.zero;
		}
		_cornerCache[0] = rect.min;
		_cornerCache[1] = new Vector2(rect.xMax, rect.yMin);
		_cornerCache[2] = rect.max;
		_cornerCache[3] = new Vector2(rect.xMin, rect.yMax);
		Vector2 zero = Vector2.zero;
		int num = 0;
		for (int i = 0; i < _cornerCache.Length; i++)
		{
			Vector2 vector = _cornerCache[i];
			if (_003CKeepRectInsidePolygon_003Eg__PointInPolygon_007C24_0(vector, ref _003C_003Ec__DisplayClass24_1))
			{
				continue;
			}
			float num2 = float.MaxValue;
			Vector2 vector2 = Vector2.zero;
			for (int j = 0; j < _003C_003Ec__DisplayClass24_1.polygon.Count; j++)
			{
				Vector2 vector3 = _003C_003Ec__DisplayClass24_1.polygon[j];
				Vector2 vector4 = _003C_003Ec__DisplayClass24_1.polygon[(j + 1) % _003C_003Ec__DisplayClass24_1.polygon.Count];
				Vector2 vector5 = _003CKeepRectInsidePolygon_003Eg__ClosestPointOnSegment_007C24_1(vector, vector3, vector4);
				Vector2 vector6 = vector4 - vector3;
				Vector2 vector7 = new Vector2(0f - vector6.y, vector6.x).normalized;
				if (!_003CKeepRectInsidePolygon_003Eg__PointInPolygon_007C24_0(vector5 + vector7 * 0.01f, ref _003C_003Ec__DisplayClass24_1))
				{
					vector7 = -vector7;
				}
				Vector2 vector8 = vector5 - vector + vector7 * skin;
				float sqrMagnitude = vector8.sqrMagnitude;
				if (sqrMagnitude < num2)
				{
					num2 = sqrMagnitude;
					vector2 = vector8;
				}
			}
			zero += vector2;
			num++;
		}
		if (num > 0)
		{
			return zero / num;
		}
		return Vector2.zero;
	}

	private static IEnumerable<SnapPoint> FindAllSnaps(Furniture furn, Room room, string limitFurniture, bool onePerFurn, bool forceOne, Func<Furniture, SnapPoint, float> priority = null, Func<Furniture, bool> valid = null, Func<SnapPoint, bool> validSnap = null)
	{
		Vector3[] bounds = ((furn.BuildBoundary == null) ? Array.Empty<Vector3>() : furn.BuildBoundary.SelectInPlace((Vector2 x) => x.ToVector3(0f)));
		Vector2[] transBounds = new Vector2[bounds.Length];
		IList<Furniture> list;
		if (limitFurniture == null)
		{
			IList<Furniture> furnitures = room.GetFurnitures();
			list = furnitures;
		}
		else
		{
			IList<Furniture> furnitures = room.GetFurniture(limitFurniture);
			list = furnitures;
		}
		IList<Furniture> fs = list;
		for (int i = 0; i < fs.Count; i++)
		{
			Furniture f = fs[i];
			if (valid != null && !valid(f))
			{
				continue;
			}
			if (priority != null)
			{
				foreach (SnapPoint item in f.SnapPoints.OrderBy((SnapPoint x) => priority(f, x)))
				{
					if ((validSnap != null && !validSnap(item)) || !furn.DoesSnapTo(item.Name))
					{
						continue;
					}
					if (item.IsFree(true))
					{
						ConvertBounds(bounds, transBounds, item.transform.localToWorldMatrix);
						if (CheckValid(furn, item, null, null, item.transform.position, transBounds, room))
						{
							yield return item;
							if (onePerFurn)
							{
								break;
							}
						}
					}
					else if (forceOne)
					{
						break;
					}
				}
				continue;
			}
			for (int j = 0; j < f.SnapPoints.Length; j++)
			{
				SnapPoint snapPoint = f.SnapPoints[j];
				if ((validSnap != null && !validSnap(snapPoint)) || !furn.DoesSnapTo(snapPoint.Name))
				{
					continue;
				}
				if (snapPoint.IsFree(true))
				{
					ConvertBounds(bounds, transBounds, snapPoint.transform.localToWorldMatrix);
					if (CheckValid(furn, snapPoint, null, null, snapPoint.transform.position, transBounds, room))
					{
						yield return snapPoint;
						if (onePerFurn)
						{
							break;
						}
					}
				}
				else if (forceOne)
				{
					break;
				}
			}
		}
	}

	private static Room GetRoomAbove(Vector3 p)
	{
		return GameSettings.Instance.sRoomManager.GetRoomFromPoint(p + Vector3.up * 2f);
	}

	private static bool CheckValid(Furniture furn, SnapPoint snap, WallEdge edge1, WallEdge edge2, Vector3 pos, Vector2[] ps, Room r)
	{
		if (((r.Outdoors && furn.ValidOutdoors) || (!r.Outdoors && furn.ValidIndoors)) && (!furn.OnlyOnGrass || "None".Equals(r.FloorMat) || r.Outside) && (furn.BasementValid || r.Floor >= 0) && (!furn.NeedsRoadConnection || r.Outside))
		{
			float floorOffset = pos.y.GetFloorOffset(r.Floor);
			float num = furn.Height1 + floorOffset;
			float num2 = furn.Height2 + floorOffset;
			if (furn.WallFurn && furn.PokesThroughWall && edge1 != null && edge2 != null)
			{
				Room room = edge2.GetRoom(edge1);
				if (room != null)
				{
					if (!FurnitureBuilder.IsValid(furn, pos, ps, num, num2, room, false))
					{
						return false;
					}
				}
				else if (GameSettings.Instance.ActiveFloor == 0 && !FurnitureBuilder.IsValid(furn, pos, ps, num, num2, GameSettings.Instance.sRoomManager.Outside, false))
				{
					return false;
				}
			}
			Room roomAbove = GetRoomAbove(pos);
			Furniture[] ignore = ((!(snap != null)) ? Array.Empty<Furniture>() : new Furniture[1] { snap.Parent });
			if ((!furn.IsSnapping || furn.CanNotSnap || (snap != null && snap.CheckCollisions(pos.FlattenVector3(), furn.SurfaceSnapRadius, furn, null))) && FurnitureBuilder.IsValid(furn, pos, ps, num, num2, r, false, snap != null, ignore) && (!furn.TwoFloors || FurnitureBuilder.IsValid(furn, pos, ps, num + 2f, num2 + 2f, roomAbove, true, false)))
			{
				if (furn.PokesThroughRoof)
				{
					return roomAbove == null;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private static float[] GetValidHeights(Furniture furn)
	{
		if (!furn.CustomHeight)
		{
			return new float[1];
		}
		if (furn.ValidHeights.Length == 0)
		{
			return new float[1] { furn.WallHeight };
		}
		if (furn.ValidHeights.Length == 1)
		{
			return furn.ValidHeights;
		}
		float num = furn.Height2 - furn.Height1;
		float num2 = furn.ValidHeights[0] + num / 2f;
		float num3 = furn.ValidHeights[furn.ValidHeights.Length - 1] - num / 2f;
		int num4 = Mathf.Max(1, Mathf.FloorToInt((num2 - num3) / num));
		float[] array = new float[num4];
		for (int i = 0; i < num4; i++)
		{
			array[i] = num3 + num / 2f + num * (float)i;
		}
		return array;
	}

	private static IEnumerable<PlacementData> FindPlaceOnWall(Furniture furn, Room room, float[] validHeights, float? stagger = null)
	{
		Vector3[] bounds = ((furn.BuildBoundary == null) ? Array.Empty<Vector3>() : furn.BuildBoundary.SelectInPlace((Vector2 x) => x.ToVector3(0f)));
		Vector2[] transBounds = new Vector2[bounds.Length];
		float off = furn.WallWidth / 2f + Room.WallOffset / 2f;
		float[] lastPlacements = new float[validHeights.Length];
		for (int i = 0; i < room.Edges.Count; i++)
		{
			WallEdge e1 = room.Edges[i];
			WallEdge e2 = room.Edges[(i + 1) % room.Edges.Count];
			if ((furn.OnlyExteriorWalls && !e1.IsAgainstOutside(e2)) || (furn.OnlyInteriorWalls && e1.IsAgainstOutside(e2)))
			{
				continue;
			}
			Vector2 dir = e2.Pos - e1.Pos;
			float dist = dir.magnitude;
			if (!(dist >= off * 2f))
			{
				continue;
			}
			dir *= 1f / dist;
			float max = dist - off * 2f;
			for (int num = 0; num < lastPlacements.Length; num++)
			{
				lastPlacements[num] = 0f;
			}
			float j;
			for (j = 0f; j < max; j += (stagger.HasValue ? (stagger.Value * 2f) : furn.WallWidth))
			{
				float lastWallPos = 0f;
				bool any = false;
				for (int k = 0; k < validHeights.Length; k++)
				{
					bool flag = stagger.HasValue && k % 2 == 1;
					float num2 = (flag ? stagger.Value : 0f);
					Vector2 pos = e1.Pos + dir * (off + num2 + j);
					float height = validHeights[k];
					if (!e1.ValidSegment(ref pos, ref height, furn.WallWidth, e2, !furn.PokesThroughWall, furn.IsConnecter, furn.ReverseWallSide, true, false, furn.Height1, furn.Height2, false, 0f, 0f, false, null, furn.CustomHeight, furn.GetValidHeight(0), furn.GetValidHeight(1), true, null, false))
					{
						continue;
					}
					Vector3 vector = pos.ToVector3((float)room.Floor * 2f + height);
					Quaternion quaternion = Quaternion.LookRotation(new Vector3(0f - dir.y, 0f, dir.x));
					Matrix4x4 mat = Matrix4x4.TRS(vector, quaternion, Vector3.one);
					ConvertBounds(bounds, transBounds, mat);
					if (!CheckValid(furn, null, e1, e2, vector, transBounds, room))
					{
						continue;
					}
					float magnitude = (e1.Pos - pos).magnitude;
					if (!(magnitude - furn.WallWidth / 2f < lastPlacements[k]))
					{
						if (!flag)
						{
							lastWallPos = Mathf.Max(lastWallPos, magnitude);
							any = true;
						}
						lastPlacements[k] = magnitude;
						yield return new PlacementData(vector, quaternion, e1, e2, magnitude / dist);
					}
				}
				j = ((!any) ? (j - furn.WallWidth * 0.9f) : (lastWallPos - off));
			}
		}
	}

	private static Rect GetWH(Furniture furn, Quaternion rot)
	{
		if (furn.BuildBoundary != null)
		{
			if (furn.BuildBoundary.Length > 1)
			{
				return ((IList<Vector2>)furn.BuildBoundary).GetBounds();
			}
			if (furn.BuildBoundary.Length == 1)
			{
				return new Rect(furn.BuildBoundary[0].x, furn.BuildBoundary[0].y, 0f, 0f);
			}
		}
		return Rect.zero;
	}

	private static IEnumerable<PlacementData> AlongBoundary(Furniture furn, Room r)
	{
		Vector3[] bounds = ((furn.BuildBoundary == null) ? Array.Empty<Vector3>() : furn.BuildBoundary.SelectInPlace((Vector2 x) => x.ToVector3(0f)));
		Vector2[] transBounds = new Vector2[bounds.Length];
		Rect rect = GetWH(furn, Quaternion.identity);
		List<Rect> rects = GetApplicableRects(furn, r, r.Floor * 2);
		Vector2[] rPoly = r.Edges.SelectInPlace((WallEdge x) => x.Pos).GetOffset(Room.WallOffset * 0.5f);
		for (int k = 0; k < 2; k++)
		{
			for (int i = 0; i < r.Edges.Count; i++)
			{
				WallEdge wallEdge = r.Edges[(i == 0) ? (r.Edges.Count - 1) : (i - 1)];
				WallEdge wallEdge2 = r.Edges[i];
				WallEdge wallEdge3 = r.Edges[(i + 1) % r.Edges.Count];
				WallEdge wallEdge4 = r.Edges[(i + 2) % r.Edges.Count];
				Vector2 offset = Utilities.GetOffset(wallEdge.Pos, wallEdge2.Pos, wallEdge3.Pos, Room.WallOffset / 2f);
				Vector2 v = Utilities.GetOffset(wallEdge2.Pos, wallEdge3.Pos, wallEdge4.Pos, Room.WallOffset / 2f) - offset;
				float magnitude = v.magnitude;
				v *= 1f / magnitude;
				Vector2 v2 = v.Turn90();
				Quaternion aR = Quaternion.LookRotation(v2.ToVector3(0f));
				Vector2 vector = (aR * rect.center.ToVector3(0f)).FlattenVector3();
				Vector2 left = (aR * new Vector3(rect.width, 0f, 0f)).FlattenVector3();
				Vector2 vector2 = (aR * new Vector3(0f, 0f, rect.height)).FlattenVector3();
				int c = Mathf.FloorToInt(magnitude / rect.width);
				if (c <= 0)
				{
					continue;
				}
				Vector2 start = offset + left * 0.5f + vector2 * ((float)k + 0.5f) - vector;
				if (i > 0)
				{
					start += vector2.Turn90() * 1.01f;
				}
				for (int j = 0; j < c; j++)
				{
					Vector3 vector3 = start.ToVector3(r.Floor * 2);
					Matrix4x4 mat = Matrix4x4.TRS(vector3, aR, Vector3.one);
					ConvertBounds(bounds, transBounds, mat);
					if (CheckValid(furn, null, null, null, vector3, transBounds, r))
					{
						yield return new PlacementData(vector3, aR);
					}
					else if (k > 0)
					{
						Vector2 vector4 = EaseFurniture(furn, start, aR, rects, rPoly);
						if (vector4 != Vector2.zero)
						{
							vector3 = (start + vector4).ToVector3(r.Floor * 2);
							mat = Matrix4x4.TRS(vector3, aR, Vector3.one);
							ConvertBounds(bounds, transBounds, mat);
							if (CheckValid(furn, null, null, null, vector3, transBounds, r))
							{
								start += left.normalized * vector4.magnitude;
								yield return new PlacementData(vector3, aR);
							}
						}
					}
					start += left * 1.01f;
				}
			}
		}
	}

	private static void ConvertBounds(Vector3[] bounds, Vector2[] output, Matrix4x4 mat4)
	{
		for (int i = 0; i < bounds.Length; i++)
		{
			output[i] = mat4.MultiplyPoint(bounds[i]).FlattenVector3();
		}
	}

	[CompilerGenerated]
	private static bool _003CKeepRectInsidePolygon_003Eg__PointInPolygon_007C24_0(Vector2 p, ref _003C_003Ec__DisplayClass24_0 P_1)
	{
		bool flag = false;
		int count = P_1.polygon.Count;
		int num = 0;
		int index = count - 1;
		while (num < count)
		{
			Vector2 vector = P_1.polygon[num];
			Vector2 vector2 = P_1.polygon[index];
			if (vector.y > p.y != vector2.y > p.y && p.x < (vector2.x - vector.x) * (p.y - vector.y) / (vector2.y - vector.y) + vector.x)
			{
				flag = !flag;
			}
			index = num++;
		}
		return flag;
	}

	[CompilerGenerated]
	internal static Vector2 _003CKeepRectInsidePolygon_003Eg__ClosestPointOnSegment_007C24_1(Vector2 p, Vector2 a, Vector2 b)
	{
		Vector2 vector = b - a;
		float value = Vector2.Dot(p - a, vector) / vector.sqrMagnitude;
		return a + Mathf.Clamp01(value) * vector;
	}
}
