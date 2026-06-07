using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Tools;
using Jundroo.Common.Extensions;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Design.Symmetry
{
	public static class SymmetryUtility
	{
		public enum SymmetricAttachPointsAvailability
		{
			NotFound = 0,
			NotAvailable = 1,
			Available = 2
		}

		public struct AsymmetricRepositionPrepassData
		{
			public bool IsSupported { get; set; }

			public HashSet<uint> SymmetryIdsToIgnore { get; set; }

			public AsymmetricRepositionPrepassData(bool isAllowed, HashSet<uint> symmetryIdsToIgnore)
			{
				IsSupported = isAllowed;
				SymmetryIdsToIgnore = symmetryIdsToIgnore;
			}
		}

		public class TogglePartSymmetryReport
		{
			public bool CloneUnlinkedOrToggleAndDelete { get; }

			public List<PartConnectionFailure> ConnectionFailures { get; }

			public List<IReadOnlyList<PartData>> CreatedParts { get; }

			public List<PartData> DeletedParts { get; }

			public List<IReadOnlyList<PartData>> LinkedParts { get; }

			public PartData SourcePart { get; }

			public int SourceSelectionCount { get; }

			public bool SymmetryDisabled { get; }

			public SymmetryMode SymmetryMode { get; }

			public List<IReadOnlyList<PartData>> UnlinkedParts { get; }

			public TogglePartSymmetryReport(SymmetryMode mode, bool symmetryDisabled, bool cloneUnlinkedOrToggleAndDelete, PartData sourcePart, int sourceSelectionCount)
			{
				SymmetryMode = mode;
				SymmetryDisabled = symmetryDisabled;
				CloneUnlinkedOrToggleAndDelete = cloneUnlinkedOrToggleAndDelete;
				SourcePart = sourcePart;
				SourceSelectionCount = sourceSelectionCount;
				UnlinkedParts = new List<IReadOnlyList<PartData>>();
				LinkedParts = new List<IReadOnlyList<PartData>>();
				CreatedParts = new List<IReadOnlyList<PartData>>();
				DeletedParts = new List<PartData>();
				ConnectionFailures = new List<PartConnectionFailure>();
			}

			public string GetDesignerMessage()
			{
				bool flag = SymmetryMode == SymmetryMode.Disabled || SymmetryMode == SymmetryMode.Mirrored;
				if (UnlinkedParts.Count == 0 && SymmetryDisabled)
				{
					return (flag ? "Mirroring" : "Symmetry") + " disabled for part " + PartString(SourcePart);
				}
				if (UnlinkedParts.Count == 1)
				{
					IReadOnlyList<PartData> readOnlyList = UnlinkedParts[0];
					if (readOnlyList.Count <= 1)
					{
						return "Symmetry disabled for part " + PartString(SourcePart);
					}
					if (readOnlyList.Count == 2)
					{
						string text = "Mirroring disabled for part " + PartString(readOnlyList[0]) + " and part " + PartString(readOnlyList[1]);
						if (CloneUnlinkedOrToggleAndDelete && DeletedParts.Count > 0)
						{
							text += ((DeletedParts.Count == 1) ? (".\nDeleted symmetric part " + PartString(DeletedParts[0]) + ".") : $".\nDeleted {DeletedParts.Count} symmetric parts.");
						}
						return text;
					}
					string text2 = $"Symmetry disabled for part {PartString(SourcePart)} and its {readOnlyList.Count - 1} symmetric parts";
					if (CloneUnlinkedOrToggleAndDelete && DeletedParts.Count > 0)
					{
						text2 += $".\nDeleted {DeletedParts.Count} symmetric parts.";
					}
					return text2;
				}
				if (UnlinkedParts.Count > 1)
				{
					int num = UnlinkedParts.Max((IReadOnlyList<PartData> x) => x.Count);
					int num2 = UnlinkedParts.Sum((IReadOnlyList<PartData> x) => x.Count);
					string text3 = string.Format("{0} disabled for part {1} and {2} other parts", (num == 2) ? "Mirroring" : "Symmetry", PartString(SourcePart), num2 - 1);
					if (CloneUnlinkedOrToggleAndDelete && DeletedParts.Count > 0)
					{
						text3 += $".\nDeleted {DeletedParts.Count} symmetric parts.";
					}
					return text3;
				}
				if ((SymmetryMode == SymmetryMode.Disabled || CloneUnlinkedOrToggleAndDelete) && !SymmetryDisabled)
				{
					if (SourceSelectionCount == 1)
					{
						if (CreatedParts.Count == 0 || CreatedParts[0].Count == 0)
						{
							if (LinkedParts.Count == 1 && LinkedParts[0].Count == 2)
							{
								PartData partData = ((SourcePart == LinkedParts[0][0]) ? LinkedParts[0][1] : LinkedParts[0][0]);
								return "Unable to mirror part " + PartString(SourcePart) + ". Matching part " + PartString(partData) + " already exists";
							}
							return "Unable to mirror part " + PartString(SourcePart);
						}
						if (CreatedParts.Count == 1)
						{
							IReadOnlyList<PartData> readOnlyList2 = CreatedParts[0];
							if (readOnlyList2.Count == 1)
							{
								return "Created unlinked mirrored part " + PartString(readOnlyList2[0]) + " from source part " + PartString(SourcePart);
							}
							return $"Created {readOnlyList2.Count} unlinked mirrored parts from source part {PartString(SourcePart)}";
						}
						return $"Created {CreatedParts.Sum((IReadOnlyList<PartData> x) => x.Count)} unlinked mirrored parts from source part {PartString(SourcePart)}";
					}
					int num3 = CreatedParts?.Sum((IReadOnlyList<PartData> x) => x.Count) ?? 0;
					return $"Created {num3} unlinked mirrored parts from source part {PartString(SourcePart)} and {SourceSelectionCount - 1} other parts";
				}
				if (!SymmetryDisabled)
				{
					if (SourceSelectionCount == 1)
					{
						if (LinkedParts.Count > 0)
						{
							if (LinkedParts.Count == 1 && LinkedParts[0].Count == 2)
							{
								IReadOnlyList<PartData> readOnlyList3 = LinkedParts[0];
								PartData partData2 = ((readOnlyList3[0] == SourcePart) ? readOnlyList3[1] : readOnlyList3[0]);
								return "Mirroring enabled for part " + PartString(SourcePart) + " and automatically linked to mirrored part " + PartString(partData2);
							}
							if (LinkedParts.Count == 1)
							{
								return $"Symmetry enabled for part {PartString(SourcePart)} and automatically linked to {LinkedParts[0].Count - 1} other parts";
							}
							return $"Symmetry enabled for part {PartString(SourcePart)} and {LinkedParts.Count - 1} other sets of parts";
						}
						if (CreatedParts.Count > 0)
						{
							if (CreatedParts.Count == 1 && CreatedParts[0].Count == 1)
							{
								return "Mirroring enabled for part " + PartString(SourcePart) + " and automatically created mirrored part " + PartString(CreatedParts[0][0]);
							}
							if (CreatedParts.Count == 1)
							{
								return $"Symmetry enabled for part {PartString(SourcePart)} and automatically created {CreatedParts[0].Count} symmetric parts";
							}
							return $"Symmetry enabled for part {PartString(SourcePart)} and {CreatedParts.Count} sets of symmetric parts were created";
						}
						return (flag ? "Mirroring" : "Symmetry") + " enabled for part " + PartString(SourcePart);
					}
					string text4 = string.Format("{0} enabled for part {1} and {2} other parts.", flag ? "Mirroring" : "Symmetry", PartString(SourcePart), SourceSelectionCount - 1);
					if (LinkedParts.Sum((IReadOnlyList<PartData> x) => x.Count) > 0)
					{
						int num4 = LinkedParts.Max((IReadOnlyList<PartData> x) => x.Count);
						text4 += string.Format("\nAutomatically linked {0} existing sets of {1} parts.", LinkedParts.Count, (num4 == 2) ? "mirrored" : "symmetric");
					}
					int num5 = CreatedParts.Sum((IReadOnlyList<PartData> x) => x.Count);
					if (num5 > 0)
					{
						int num6 = CreatedParts.Max((IReadOnlyList<PartData> x) => x.Count);
						text4 += string.Format("\nAutomatically created {0} {1} parts.", num5, (num6 == 1) ? "mirrored" : "symmetric");
					}
					return text4;
				}
				return string.Format("Symmetry {0} for part {1} and {2} other parts", SymmetryDisabled ? "disabled" : "enabled", PartString(SourcePart), SourceSelectionCount - 1);
				static string PartString(PartData partData3)
				{
					return $"'{partData3.Name} (Id: {partData3.Id})'";
				}
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker AsymmetricRepositionPrepass = new ProfilerMarker("SymmetryUtility.AsymmetricRepositionPrepass");

			public static readonly ProfilerMarker AutoLinkSymmetricParts = new ProfilerMarker("SymmetryUtility.AutoLinkSymmetricParts");

			public static readonly ProfilerMarker ConnectSymmetricParts = new ProfilerMarker("SymmetryUtility.ConnectSymmetricParts");

			public static readonly ProfilerMarker CreateSymmetricParts = new ProfilerMarker("SymmetryUtility.CreateSymmetricParts");

			public static readonly ProfilerMarker CreateSymmetricPartSelections = new ProfilerMarker("SymmetryUtility.CreateSymmetricPartSelections");

			public static readonly ProfilerMarker DeleteInvalidSymmetricPart = new ProfilerMarker("SymmetryUtility.DeleteInvalidSymmetricPart");

			public static readonly ProfilerMarker DuplicatePart = new ProfilerMarker("SymmetryUtility.DuplicatePart");

			public static readonly ProfilerMarker FindSymmetricAttachPoint = new ProfilerMarker("SymmetryUtility.FindSymmetricAttachPoint");

			public static readonly ProfilerMarker FindSymmetricParts = new ProfilerMarker("SymmetryUtility.FindSymmetricParts");

			public static readonly ProfilerMarker FindUnlinkedSymmetricParts = new ProfilerMarker("SymmetryUtility.FindUnlinkedSymmetricParts");

			public static readonly ProfilerMarker GetAllConnectedParts = new ProfilerMarker("SymmetryUtility.GetAllConnectedParts");

			public static readonly ProfilerMarker GetAllSymmetricAndConnectedParts = new ProfilerMarker("SymmetryUtility.GetAllSymmetricAndConnectedParts");

			public static readonly ProfilerMarker GetMirroredModifier = new ProfilerMarker("SymmetryUtility.GetMirroredModifier");

			public static readonly ProfilerMarker GetMirroredPart = new ProfilerMarker("SymmetryUtility.GetMirroredPart");

			public static readonly ProfilerMarker GetMirroredPosition = new ProfilerMarker("SymmetryUtility.GetMirroredPosition");

			public static readonly ProfilerMarker GetRadialPosition = new ProfilerMarker("SymmetryUtility.GetRadialPosition");

			public static readonly ProfilerMarker GetSymmetricAttachPointsAvailability = new ProfilerMarker("SymmetryUtility.GetSymmetricAttachPointsAvailability");

			public static readonly ProfilerMarker GetSymmetricPairs = new ProfilerMarker("SymmetryUtility.GetSymmetricPairs");

			public static readonly ProfilerMarker GetSymmetricPairSliceIndex = new ProfilerMarker("SymmetryUtility.GetSymmetricPairSliceIndex");

			public static readonly ProfilerMarker GetSymmetricPartGroups = new ProfilerMarker("SymmetryUtility.GetSymmetricPartGroups");

			public static readonly ProfilerMarker GetSymmetricPosition = new ProfilerMarker("SymmetryUtility.GetSymmetricPosition");

			public static readonly ProfilerMarker GetSymmetricPositions = new ProfilerMarker("SymmetryUtility.GetSymmetricPositions");

			public static readonly ProfilerMarker GetSymmetricSliceIndex = new ProfilerMarker("SymmetryUtility.GetSymmetricSliceIndex");

			public static readonly ProfilerMarker GetSymmetricTransforms = new ProfilerMarker("SymmetryUtility.GetSymmetricTransforms");

			public static readonly ProfilerMarker HasOverlappingSymmetricParts = new ProfilerMarker("SymmetryUtility.HasOverlappingSymmetricParts");

			public static readonly ProfilerMarker IsConnectedToCockpit = new ProfilerMarker("SymmetryUtility.IsConnectedToCockpit");

			public static readonly ProfilerMarker IsOverlappingSymmetricParts = new ProfilerMarker("SymmetryUtility.IsOverlappingSymmetricParts");

			public static readonly ProfilerMarker IsSymmetricAttachPoint = new ProfilerMarker("SymmetryUtility.IsSymmetricAttachPoint");

			public static readonly ProfilerMarker IsSymmetricPartsValid = new ProfilerMarker("SymmetryUtility.IsSymmetricPartsValid");

			public static readonly ProfilerMarker PartsSpanSymmetricOrigin = new ProfilerMarker("SymmetryUtility.PartsSpanSymmetricOrigin");

			public static readonly ProfilerMarker RepositionParts = new ProfilerMarker("SymmetryUtility.RepositionParts");

			public static readonly ProfilerMarker TogglePartSymmetryDisabledState = new ProfilerMarker("SymmetryUtility.TogglePartSymmetryDisabledState");
		}

		public const float Epsilon = 0.001f;

		public static AsymmetricRepositionPrepassData AsymmetricRepositionPrepass(PartData rootPart, PartConnection rootPartConnection, SymmetryConfig symmetry)
		{
			using (Profile.AsymmetricRepositionPrepass.Auto())
			{
				if (rootPart == null)
				{
					throw new ArgumentNullException("rootPart");
				}
				if (rootPartConnection == null)
				{
					throw new ArgumentNullException("rootPartConnection");
				}
				PartData otherPart = rootPartConnection.GetOtherPart(rootPart);
				if (otherPart == null)
				{
					return new AsymmetricRepositionPrepassData(isAllowed: true, null);
				}
				HashSet<uint> hashSet = new HashSet<uint>();
				Assembly assembly = rootPart.PartScript.Aircraft.Aircraft.Assembly;
				PartData part = rootPart.PartScript.Aircraft.MainCockpit.Part;
				Queue<PartData> value;
				using (QueuePool<PartData>.Get(out value))
				{
					HashSet<int> value2;
					using (CollectionPool<HashSet<int>, int>.Get(out value2))
					{
						HashSet<uint> value3;
						using (CollectionPool<HashSet<uint>, uint>.Get(out value3))
						{
							List<PartData> value4;
							using (CollectionPool<List<PartData>, PartData>.Get(out value4))
							{
								value2.Add(rootPart.Id);
								if (rootPart.SymmetryId != 0)
								{
									value3.Add(rootPart.SymmetryId);
								}
								value2.Add(otherPart.Id);
								value.Enqueue(otherPart);
								while (value.Count > 0)
								{
									PartData partData = value.Dequeue();
									if (partData == part)
									{
										return new AsymmetricRepositionPrepassData(isAllowed: false, null);
									}
									if (partData.SymmetryId != 0 && !hashSet.Contains(partData.SymmetryId))
									{
										if (!value3.Add(partData.SymmetryId))
										{
											return new AsymmetricRepositionPrepassData(isAllowed: false, null);
										}
										value4.Clear();
										assembly.GetOtherSymmetricParts(partData, value4);
										if (!IsSymmetricPartsValid(partData, value4, symmetry))
										{
											hashSet.Add(partData.SymmetryId);
										}
									}
									foreach (PartConnection partConnection in partData.PartConnections)
									{
										PartData otherPart2 = partConnection.GetOtherPart(partData);
										if (value2.Add(otherPart2.Id))
										{
											value.Enqueue(otherPart2);
										}
									}
								}
								return new AsymmetricRepositionPrepassData(isAllowed: true, hashSet);
							}
						}
					}
				}
			}
		}

		public static void AutoLinkSymmetricParts(PartSelection partSelection, bool partSelectionOnly, bool ignoreSymmetryDisabled, SymmetryConfig symmetry)
		{
			using (Profile.AutoLinkSymmetricParts.Auto())
			{
				if (symmetry.Mode == SymmetryMode.Disabled)
				{
					return;
				}
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					foreach (PartScript part in partSelection.Parts)
					{
						value.Add(part.Part);
					}
					AutoLinkSymmetricParts(value, partSelectionOnly ? value : null, ignoreSymmetryDisabled, symmetry);
				}
			}
		}

		public static void AutoLinkSymmetricParts(IList<PartData> parts, IReadOnlyList<PartData> partsToSearch, bool ignoreSymmetryDisabled, SymmetryConfig symmetry)
		{
			using (Profile.AutoLinkSymmetricParts.Auto())
			{
				if (symmetry.Mode == SymmetryMode.Disabled || parts == null || parts.Count == 0)
				{
					return;
				}
				PartScript mainCockpit = parts[0].PartScript.Aircraft.MainCockpit;
				Assembly assembly = parts[0].PartScript.Aircraft.Aircraft.Assembly;
				if (partsToSearch == null)
				{
					partsToSearch = assembly.Parts;
				}
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					foreach (PartData item in partsToSearch)
					{
						if ((!item.SymmetryDisabled || ignoreSymmetryDisabled) && item.SymmetryId == 0)
						{
							value.Add(item);
						}
					}
					List<PartData> value2;
					using (CollectionPool<List<PartData>, PartData>.Get(out value2))
					{
						int symmetricPartGroupCount = GetSymmetricPartGroupCount(symmetry.Mode);
						foreach (PartData part in parts)
						{
							if ((part.SymmetryDisabled && !ignoreSymmetryDisabled) || part.SymmetryId != 0)
							{
								continue;
							}
							value2.Clear();
							FindUnlinkedSymmetricParts(part, includeSelf: true, ignoreSymmetryDisabled, allowSamePosition: false, value, symmetry, value2);
							bool flag = value2.Count == symmetricPartGroupCount;
							if (flag)
							{
								foreach (PartData item2 in value2)
								{
									if (item2.PartScript == mainCockpit)
									{
										flag = false;
										break;
									}
								}
							}
							if (flag)
							{
								assembly.LinkSymmetricParts(value2, ignoreSymmetryDisabled);
							}
						}
					}
				}
			}
		}

		public static void ConnectSymmetricParts(AttachPointScript attachPointScript, AttachPointScript targetAttachPointScript, SymmetryConfig symmetry, bool showConnectionFailureMessages, List<(PartData PartA, PartData PartB)> connectedParts = null, List<PartConnectionFailure> connectionFailures = null)
		{
			using (Profile.ConnectSymmetricParts.Auto())
			{
				if (showConnectionFailureMessages)
				{
					bool flag = connectionFailures == null;
					if (connectionFailures == null)
					{
						connectionFailures = CollectionPool<List<PartConnectionFailure>, PartConnectionFailure>.Get();
					}
					ConnectSymmetricParts(attachPointScript, targetAttachPointScript, symmetry, connectedParts, connectionFailures);
					PartConnectionFailure.LogWarnings(connectionFailures);
					if (connectionFailures.Count > 0)
					{
						string text = string.Empty;
						string text2 = ((Designer.Instance.Symmetry.Mode == SymmetryMode.Mirrored) ? "mirrored" : "symmetric");
						for (int i = 0; i < connectionFailures.Count; i++)
						{
							PartConnectionFailure partConnectionFailure = connectionFailures[i];
							if (partConnectionFailure.PartA != null && partConnectionFailure.PartB != null)
							{
								text = text + ((i == 0) ? string.Empty : "\n") + "Failed to create " + text2 + " connection between part " + PartString(partConnectionFailure.PartA) + " and part " + PartString(partConnectionFailure.PartB) + "." + ((partConnectionFailure.Reason == PartConnectionFailureReason.AttachPointUnavailable) ? "The attach point is unavailable." : string.Empty);
							}
						}
						if (!string.IsNullOrEmpty(text))
						{
							Designer.Instance.DesignerScript.DesignerUI.AppendMessage(text);
						}
					}
					if (flag)
					{
						CollectionPool<List<PartConnectionFailure>, PartConnectionFailure>.Release(connectionFailures);
					}
				}
				else
				{
					ConnectSymmetricParts(attachPointScript, targetAttachPointScript, symmetry, connectedParts, connectionFailures);
				}
			}
			static string PartString(PartData partData)
			{
				return $"'{partData.Name} (Id: {partData.Id})'";
			}
		}

		public static void ConnectSymmetricParts(AttachPointScript attachPointScript, AttachPointScript targetAttachPointScript, SymmetryConfig symmetry, List<(PartData PartA, PartData PartB)> connectedParts = null, List<PartConnectionFailure> connectionFailures = null)
		{
			using (Profile.ConnectSymmetricParts.Auto())
			{
				if (symmetry.Mode == SymmetryMode.Disabled)
				{
					return;
				}
				PartData part = attachPointScript.PartScript.Part;
				PartData part2 = targetAttachPointScript.PartScript.Part;
				if (part.SymmetryId == 0 && part2.SymmetryId == 0)
				{
					return;
				}
				List<(PartData, PartData)> value;
				using (CollectionPool<List<(PartData, PartData)>, (PartData, PartData)>.Get(out value))
				{
					GetSymmetricPairs(part, part2, allowUnlinkedSymmetricParts: true, symmetry, value);
					foreach (var item in value)
					{
						var (partData, partData2) = item;
						if (partData == null || partData2 == null)
						{
							string message = $"Unable to connect symmetric parts when connecting part id '{part.Id}' to part id '{part2.Id}'. " + "A valid symmetricical pair of parts could not be found.";
							OnConnectionFailure(connectionFailures, partData, partData2, PartConnectionFailureReason.SymmetricPairNotFound, message);
						}
						else
						{
							if ((part == partData && part2 == partData2) || (part == partData2 && part2 == partData))
							{
								continue;
							}
							int? symmetricPairSliceIndex = GetSymmetricPairSliceIndex(partData, partData2, part, part2, symmetry);
							if (!symmetricPairSliceIndex.HasValue)
							{
								string message2 = $"Unable to connect symmetric parts when connecting part id '{part.Id}' to part id '{part2.Id}'. " + $"An error occurred determining the symmetric slice to which part '{partData.Id}' and part '{partData2.Id}' belong";
								OnConnectionFailure(connectionFailures, partData, partData2, PartConnectionFailureReason.SymmetricSliceNotFound, message2);
								continue;
							}
							if ((part.SymmetryId != 0 && part.SymmetryId == partData2.SymmetryId) || (part2.SymmetryId != 0 && part2.SymmetryId == partData.SymmetryId))
							{
								PartData partData3 = partData2;
								PartData partData4 = partData;
								partData = partData3;
								partData2 = partData4;
							}
							AttachPointData attachPointData = FindSymmetricAttachPoint(attachPointScript.AttachPoint, partData, symmetricPairSliceIndex.Value, symmetry);
							AttachPointData attachPointData2 = FindSymmetricAttachPoint(targetAttachPointScript.AttachPoint, partData2, symmetricPairSliceIndex.Value, symmetry);
							if (attachPointData == null)
							{
								string message3 = $"Unable to connect symmetric parts when connecting part id '{part.Id}' to part id '{part2.Id}'. " + $"Could not find the symmetric attach point for symmetric part id '{partData.Id}'";
								OnConnectionFailure(connectionFailures, partData, partData2, PartConnectionFailureReason.SymmetricAttachPointNotFound, message3);
							}
							else if (attachPointData2 == null)
							{
								string message4 = $"Unable to connect symmetric parts when connecting part id '{part.Id}' to part id '{part2.Id}'. " + $"Could not find the symmetric attach point for symmetric part id '{partData2.Id}'";
								OnConnectionFailure(connectionFailures, partData, partData2, PartConnectionFailureReason.SymmetricAttachPointNotFound, message4);
							}
							else if (!CheckIfPartConnectionExists(partData, partData2, attachPointData, attachPointData2))
							{
								partData.PartScript.ConnectToPart(attachPointData.AttachPointScript, attachPointData2.AttachPointScript, isSymmetryOperation: true);
								connectedParts?.Add((partData, partData2));
							}
						}
					}
				}
			}
			static void OnConnectionFailure(List<PartConnectionFailure> list, PartData partA, PartData partB, PartConnectionFailureReason reason, string text)
			{
				if (list == null)
				{
					Debug.LogWarning(text);
				}
				else
				{
					list.Add(new PartConnectionFailure(partA, partB, reason, text));
				}
			}
		}

		public static void CreateSymmetricParts(PartData part, bool allowOverlappingPositions, SymmetryConfig symmetry, IList<PartData> symmetricParts = null)
		{
			using (Profile.CreateSymmetricParts.Auto())
			{
				if (symmetry.Mode == SymmetryMode.Disabled)
				{
					return;
				}
				bool flag = symmetry.Mode == SymmetryMode.Mirrored;
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					if (symmetricParts == null)
					{
						symmetricParts = value;
					}
					List<SymmetryTransform> value2;
					using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value2))
					{
						GetSymmetricTransforms(part, symmetry, value2);
						if (!allowOverlappingPositions)
						{
							bool flag2 = false;
							Vector3 position = part.PartScript.transform.position;
							foreach (SymmetryTransform item in value2)
							{
								if (!Utilities.CompareVector3s(item.Position, position, 0.001f))
								{
									continue;
								}
								flag2 = true;
								if (flag && part.PartType.HasAttachPointAtPartOrigin)
								{
									foreach (AttachPointData attachPoint in part.AttachPoints)
									{
										if (attachPoint.Position == Vector3.zero)
										{
											flag2 = (Utilities.CompareFloats(Vector3.Dot(attachPoint.AttachPointScript.WorldNormal, symmetry.MirrorPlane.Normal), 0f, 0.001f) ? true : false);
											break;
										}
									}
								}
								if (flag2)
								{
									break;
								}
							}
							if (flag2)
							{
								return;
							}
						}
						foreach (SymmetryTransform item2 in value2)
						{
							PartData partData = DuplicatePart(part, flag);
							partData.PartScript.transform.SetPositionAndRotation(item2.Position, item2.Rotation);
							symmetricParts.Add(partData);
						}
						List<PartData> value3;
						using (CollectionPool<List<PartData>, PartData>.Get(out value3))
						{
							value3.Add(part);
							value3.AddRange(symmetricParts);
							part.PartScript.Aircraft.Aircraft.Assembly.LinkSymmetricParts(value3, forceSymmetryEnabled: false);
						}
					}
				}
			}
		}

		public static void CreateSymmetricPartSelections(Designer designer, PartSelection partSelection, PartScript basePart, bool rebuildValidSymmetry, bool singlePart, bool preserveConnections, bool raiseAircraftStructureChanged, IList<PartSelection> symmetricPartSelections)
		{
			using (Profile.CreateSymmetricPartSelections.Auto())
			{
				symmetricPartSelections.Clear();
				SymmetryConfig symmetry = designer.Symmetry;
				Assembly assembly = basePart.Aircraft.Aircraft.Assembly;
				if (partSelection == null || basePart == null)
				{
					CreateEmptyPartSelections(symmetry, symmetricPartSelections);
					return;
				}
				if (basePart == designer.Aircraft.MainCockpit)
				{
					CreateEmptyPartSelections(symmetry, symmetricPartSelections);
					return;
				}
				if (singlePart && partSelection.Parts.Count > 1 && !partSelection.IsWingAndControlSurfaces())
				{
					Debug.LogError($"An attempt was made to create symmetric part selections with the 'single part' flag set while the source part selection contains '{partSelection.Parts.Count}' parts.");
					singlePart = false;
				}
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					HashSet<int> value2;
					using (CollectionPool<HashSet<int>, int>.Get(out value2))
					{
						foreach (PartScript part in partSelection.Parts)
						{
							value2.Add(part.Part.Id);
						}
						if (!rebuildValidSymmetry)
						{
							HashSet<uint> value3;
							using (CollectionPool<HashSet<uint>, uint>.Get(out value3))
							{
								foreach (PartScript part2 in partSelection.Parts)
								{
									value.Clear();
									assembly.GetOtherSymmetricParts(part2.Part, value);
									if (value.Count == 0)
									{
										continue;
									}
									if (!IsSymmetricPartsValid(part2.Part, value, symmetry))
									{
										value3.Add(part2.Part.SymmetryId);
										continue;
									}
									foreach (PartData item in value)
									{
										if (value2.Contains(item.Id))
										{
											value3.Add(part2.Part.SymmetryId);
											break;
										}
									}
								}
								CreateSymmetricPartSelections(partSelection, value3, singlePart, preserveConnections, symmetry, symmetricPartSelections);
							}
						}
						else
						{
							int num = 0;
							foreach (PartScript part3 in partSelection.Parts)
							{
								value.Clear();
								assembly.GetOtherSymmetricParts(part3.Part, value);
								if (value.Count == 0)
								{
									continue;
								}
								bool flag = false;
								foreach (PartData item2 in value)
								{
									if (value2.Contains(item2.Id))
									{
										flag = true;
										break;
									}
								}
								if (flag)
								{
									assembly.UnlinkSymmetricParts(part3.Part.SymmetryId, disableSymmetry: false);
								}
								else
								{
									if (IsSymmetricPartsValid(part3.Part, value, symmetry))
									{
										continue;
									}
									foreach (PartData item3 in value)
									{
										num += DeleteInvalidSymmetricPart(designer, item3, raiseAircraftStructureChanged: false);
									}
								}
							}
							if (num > 0)
							{
								designer.OnAircraftStructureChanged();
							}
							foreach (PartScript part4 in partSelection.Parts)
							{
								value.Clear();
								assembly.GetOtherSymmetricParts(part4.Part, value);
								if (value.Count == 0)
								{
									if (part4.Part.SymmetryId != 0)
									{
										Debug.LogError($"Part with id '{part4.Part.Id}' and symmetry id '{part4.Part.SymmetryId}' could not find its symmetric parts.");
									}
									else if (!part4.Part.SymmetryDisabled)
									{
										CreateSymmetricParts(part4.Part, allowOverlappingPositions: true, symmetry);
									}
								}
							}
							foreach (PartScript part5 in partSelection.Parts)
							{
								if (part5.Part.SymmetryId == 0)
								{
									continue;
								}
								foreach (PartConnection partConnection in part5.Part.PartConnections)
								{
									partConnection.RebuildSymmetricConnections(symmetry);
								}
							}
							CreateSymmetricPartSelections(partSelection, null, singlePart, preserveConnections, symmetry, symmetricPartSelections);
							if (basePart == designer.SelectedPart)
							{
								basePart.PartMaterialScript.SetSelected(selected: true, updateSymmetricParts: true);
							}
						}
						if (symmetricPartSelections.Count != GetSymmetricPartGroupCount(designer.Symmetry.Mode) - 1)
						{
							Debug.LogError("Failed to create symmetric part selections");
						}
						if (raiseAircraftStructureChanged)
						{
							designer.OnAircraftStructureChanged();
						}
					}
				}
			}
			static void CreateEmptyPartSelections(SymmetryConfig symmetryConfig, IList<PartSelection> partSelections)
			{
				int num2 = GetSymmetricPartGroupCount(symmetryConfig.Mode) - 1;
				for (int i = 0; i < num2; i++)
				{
					partSelections.Add(new PartSelection(Array.Empty<PartScript>(), Vector3.zero, Quaternion.identity, showAttachPoints: false));
				}
			}
		}

		public static void CreateSymmetricPartSelections(PartSelection partSelection, HashSet<uint> symmetryIdsToIgnore, bool singlePart, bool preserveConnections, SymmetryConfig symmetry, IList<PartSelection> symmetricPartSelections)
		{
			using (Profile.CreateSymmetricPartSelections.Auto())
			{
				symmetricPartSelections.Clear();
				if (singlePart && partSelection.Parts.Count > 1 && !partSelection.IsWingAndControlSurfaces())
				{
					Debug.LogError($"An attempt was made to create symmetric part selections with the 'single part' flag set while the source part selection contains '{partSelection.Parts.Count}' parts.");
					singlePart = false;
				}
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					foreach (PartScript part in partSelection.Parts)
					{
						uint symmetryId = part.Part.SymmetryId;
						if (symmetryId != 0 && (symmetryIdsToIgnore == null || !symmetryIdsToIgnore.Contains(symmetryId)))
						{
							value.Add(part.Part);
						}
					}
					List<SymmetryPartGroup> value2;
					using (CollectionPool<List<SymmetryPartGroup>, SymmetryPartGroup>.Get(out value2))
					{
						GetSymmetricPartGroups(value, symmetry, value2);
						SymmetryTransform transform = new SymmetryTransform(partSelection.ContainerParent.position, partSelection.ContainerParent.rotation);
						List<SymmetryTransform> value3;
						using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value3))
						{
							GetSymmetricTransforms(transform, symmetry, value3);
							if (value2.Count != value3.Count)
							{
								Debug.LogError($"Symmetric part group count '{value2.Count}' does not match symmetric transforms count '{value3.Count}'");
								return;
							}
							for (int i = 0; i < value2.Count; i++)
							{
								SymmetryPartGroup symmetryPartGroup = value2[i];
								PartSelection item = PartSelection.CreateSymmetricPartSelection(symmetryPartGroup.Parts, value3[i].Position, value3[i].Rotation, singlePart, preserveConnections, showAttachPoints: false);
								symmetricPartSelections.Add(item);
								symmetryPartGroup.Dispose();
							}
						}
					}
				}
			}
		}

		public static PartData DuplicatePart(PartData part, bool mirrored)
		{
			using (Profile.DuplicatePart.Auto())
			{
				PartData partData = new PartData(part.GenerateXml(), 23, part.LoadContext);
				partData.SymmetryId = 0u;
				PartScript part2 = partData.CreateGameObject(part.PartScript.Aircraft, part.PartCreationInfoUsedForInitialization);
				partData.EnableModifiers();
				partData.OnPartCloned(part);
				if (mirrored)
				{
					WingScript modifier = partData.PartScript.GetModifier<WingScript>();
					if (modifier != null)
					{
						modifier.Wing.Inverted = !modifier.Wing.Inverted;
						Vector3 tipPosition = modifier.Wing.TipPosition;
						tipPosition.x = 0f - tipPosition.x;
						modifier.UpdateWingPoint(tipPosition, WingScript.WingPointType.TipPosition, snapPosition: false);
					}
					foreach (PartModifierScript modifier2 in partData.PartScript.Modifiers)
					{
						modifier2.OnMirrored(part);
					}
				}
				Assembly.RunPreStartInitialization(part2);
				part.PartScript.Aircraft.Aircraft.Assembly.AddPart(partData);
				return partData;
			}
		}

		public static List<PartData> DuplicateParts(PartSelection partSelection)
		{
			List<PartData> list = new List<PartData>(partSelection.Parts.Count);
			Dictionary<int, PartData> value;
			using (CollectionPool<Dictionary<int, PartData>, KeyValuePair<int, PartData>>.Get(out value))
			{
				Dictionary<int, int> value2;
				using (CollectionPool<Dictionary<int, int>, KeyValuePair<int, int>>.Get(out value2))
				{
					foreach (PartScript part in partSelection.Parts)
					{
						PartData partData = DuplicatePart(part.Part, mirrored: false);
						list.Add(partData);
						value.Add(part.Part.Id, partData);
						value2.Add(part.Part.Id, partData.Id);
					}
					foreach (PartScript part2 in partSelection.Parts)
					{
						foreach (PartConnection partConnection in part2.Part.PartConnections)
						{
							PartData partA = partConnection.PartA;
							PartData partB = partConnection.PartB;
							if (!value.TryGetValue(partA.Id, out var value3) || !value.TryGetValue(partB.Id, out var value4))
							{
								continue;
							}
							int num = Mathf.Min(partConnection.AttachPointsA.Count, partConnection.AttachPointsB.Count);
							for (int i = 0; i < num; i++)
							{
								AttachPointData attachPointData = partConnection.AttachPointsA[i];
								AttachPointData attachPointData2 = partConnection.AttachPointsB[i];
								AttachPointData attachPoint = value3.GetAttachPoint(attachPointData.Id);
								AttachPointData attachPoint2 = value4.GetAttachPoint(attachPointData2.Id);
								if (!CheckIfPartConnectionExists(value3, value4, attachPoint, attachPoint2))
								{
									value3.PartScript.ConnectToPart(attachPoint.AttachPointScript, attachPoint2.AttachPointScript);
								}
							}
						}
					}
					foreach (PartData item in list)
					{
						foreach (PartModifierData modifier in item.Modifiers)
						{
							if (modifier is IPartIDChangedListener partIDChangedListener)
							{
								partIDChangedListener.OnPartIDsRemapped(value2);
							}
						}
					}
					return list;
				}
			}
		}

		public static AttachPointData FindSymmetricAttachPoint(AttachPointData attachPoint, PartData symmetricPart, int symmetricSliceIndex, SymmetryConfig symmetry)
		{
			using (Profile.FindSymmetricAttachPoint.Auto())
			{
				foreach (AttachPointData attachPoint2 in symmetricPart.AttachPoints)
				{
					if (IsSymmetricAttachPoint(attachPoint, attachPoint2, symmetricSliceIndex, symmetry))
					{
						return attachPoint2;
					}
				}
				return null;
			}
		}

		public static void FindSymmetricParts(PartData part, bool includeSelf, IList<PartData> symmetricParts)
		{
			using (Profile.FindSymmetricParts.Auto())
			{
				if (includeSelf)
				{
					symmetricParts.Add(part);
				}
				part.PartScript.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(part, symmetricParts);
			}
		}

		public static void FindUnlinkedSymmetricParts(PartData part, bool includeSelf, bool ignoreSymmetryDisabled, bool allowSamePosition, IReadOnlyList<PartData> partsToSearch, SymmetryConfig symmetry, IList<PartData> symmetricParts)
		{
			using (Profile.FindUnlinkedSymmetricParts.Auto())
			{
				if (part.SymmetryId != 0)
				{
					Debug.LogError($"Unable to find unlinked symmetric parts for a part with id '{part.Id}' and symmetry id '{part.SymmetryId}' because the part already has symmetric linkage.");
					return;
				}
				if (part.SymmetryDisabled && !ignoreSymmetryDisabled)
				{
					Debug.LogError($"Unable to find unlinked symmetric parts for a part with id '{part.Id}' and symmetry id '{part.SymmetryId}' because the part has symmetry disabled.");
					return;
				}
				List<SymmetryTransform> value;
				using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value))
				{
					GetSymmetricTransforms(part, symmetry, value);
					if (includeSelf)
					{
						symmetricParts.Add(part);
					}
					Vector3? vector = (allowSamePosition ? ((Vector3?)null) : new Vector3?(part.PartScript.transform.position));
					bool flag = symmetry.Mode == SymmetryMode.Mirrored;
					IReadOnlyList<PartData> readOnlyList = partsToSearch ?? part.PartScript.Aircraft.Aircraft.Assembly.Parts;
					foreach (SymmetryTransform item in value)
					{
						foreach (PartData item2 in readOnlyList)
						{
							if (item2 == part || item2.SymmetryId != 0 || item2.PartType != part.PartType || (item2.SymmetryDisabled && !ignoreSymmetryDisabled) || !Utilities.CompareVector3s(item2.PartScript.transform.position, item.Position, 0.001f))
							{
								continue;
							}
							bool flag2 = true;
							foreach (PartModifierData modifier2 in part.Modifiers)
							{
								PartModifierData modifier = item2.GetModifier(modifier2.GetType());
								if (modifier == null || !modifier2.IsSymmetricMatch(modifier, symmetry))
								{
									flag2 = false;
									break;
								}
							}
							if (flag2 && vector.HasValue && Utilities.CompareVector3s(vector.Value, item.Position, 0.001f))
							{
								flag2 = false;
								if (flag && part.PartType.HasAttachPointAtPartOrigin)
								{
									List<AttachPointData> attachPoints = part.AttachPoints;
									List<AttachPointData> attachPoints2 = item2.AttachPoints;
									if (attachPoints.Count != attachPoints2.Count)
									{
										flag2 = false;
									}
									else
									{
										for (int i = 0; i < attachPoints.Count; i++)
										{
											AttachPointScript attachPointScript = attachPoints[i].AttachPointScript;
											AttachPointScript attachPointScript2 = attachPoints2[i].AttachPointScript;
											if (Utilities.CompareVector3s(attachPointScript.transform.position, attachPointScript2.transform.position, 0.001f))
											{
												flag2 = (Utilities.CompareVector3s(GetMirroredPosition(attachPointScript.WorldNormal, symmetry), attachPointScript2.WorldNormal, 0.001f) ? true : false);
												break;
											}
										}
									}
								}
							}
							if (flag2)
							{
								symmetricParts.Add(item2);
								break;
							}
						}
					}
				}
			}
		}

		public static void GetAllConnectedParts(PartData rootPart, List<PartData> parts, List<PartData> excludedParts = null)
		{
			using (Profile.GetAllConnectedParts.Auto())
			{
				if (rootPart == null)
				{
					throw new ArgumentNullException("rootPart", "Root part cannot be null.");
				}
				if (parts == null)
				{
					throw new ArgumentNullException("parts", "Parts list cannot be null.");
				}
				Queue<PartData> value;
				using (QueuePool<PartData>.Get(out value))
				{
					HashSet<int> value2;
					using (CollectionPool<HashSet<int>, int>.Get(out value2))
					{
						value2.Add(rootPart.Id);
						value.Enqueue(rootPart);
						if (excludedParts != null)
						{
							for (int i = 0; i < excludedParts.Count; i++)
							{
								value2.Add(excludedParts[i].Id);
							}
						}
						while (value.Count > 0)
						{
							PartData partData = value.Dequeue();
							parts.Add(partData);
							foreach (PartConnection partConnection in partData.PartConnections)
							{
								PartData otherPart = partConnection.GetOtherPart(partData);
								if (value2.Add(otherPart.Id))
								{
									value.Enqueue(otherPart);
								}
							}
						}
					}
				}
			}
		}

		public static void GetAllConnectedParts(PartScript rootPart, List<PartScript> parts, List<PartScript> excludedParts = null)
		{
			using (Profile.GetAllConnectedParts.Auto())
			{
				if (rootPart == null)
				{
					throw new ArgumentNullException("rootPart", "Root part cannot be null.");
				}
				if (parts == null)
				{
					throw new ArgumentNullException("parts", "Parts list cannot be null.");
				}
				Queue<PartData> value;
				using (QueuePool<PartData>.Get(out value))
				{
					HashSet<int> value2;
					using (CollectionPool<HashSet<int>, int>.Get(out value2))
					{
						value2.Add(rootPart.Part.Id);
						value.Enqueue(rootPart.Part);
						if (excludedParts != null)
						{
							for (int i = 0; i < excludedParts.Count; i++)
							{
								value2.Add(excludedParts[i].Part.Id);
							}
						}
						while (value.Count > 0)
						{
							PartData partData = value.Dequeue();
							parts.Add(partData.PartScript);
							foreach (PartConnection partConnection in partData.PartConnections)
							{
								PartData otherPart = partConnection.GetOtherPart(partData);
								if (value2.Add(otherPart.Id))
								{
									value.Enqueue(otherPart);
								}
							}
						}
					}
				}
			}
		}

		public static void GetAllSymmetricAndConnectedParts(List<PartScript> sourceParts, List<PartData> parts)
		{
			using (Profile.GetAllSymmetricAndConnectedParts.Auto())
			{
				if (sourceParts == null || sourceParts.Count == 0)
				{
					return;
				}
				Assembly assembly = sourceParts[0].Aircraft.Aircraft.Assembly;
				Queue<PartData> value;
				using (QueuePool<PartData>.Get(out value))
				{
					HashSet<int> value2;
					using (CollectionPool<HashSet<int>, int>.Get(out value2))
					{
						foreach (PartScript sourcePart in sourceParts)
						{
							value2.Add(sourcePart.Part.Id);
						}
						foreach (PartScript sourcePart2 in sourceParts)
						{
							PartData part = sourcePart2.Part;
							if (part.SymmetryId == 0)
							{
								continue;
							}
							foreach (PartData symmetricPart in assembly.GetSymmetricParts(part.SymmetryId))
							{
								if (symmetricPart != part && value2.Add(symmetricPart.Id))
								{
									value.Enqueue(symmetricPart);
								}
							}
						}
						while (value.Count > 0)
						{
							PartData partData = value.Dequeue();
							parts.Add(partData);
							foreach (PartConnection partConnection in partData.PartConnections)
							{
								PartData otherPart = partConnection.GetOtherPart(partData);
								if (value2.Add(otherPart.Id) && otherPart.SymmetryId == 0)
								{
									value.Enqueue(otherPart);
								}
							}
						}
					}
				}
			}
		}

		public static T GetMirroredModifier<T>(T modifier) where T : PartModifierData
		{
			using (Profile.GetMirroredModifier.Auto())
			{
				PartData mirroredPart = GetMirroredPart(modifier?.Part);
				if (mirroredPart != null)
				{
					int num = modifier.Part.Modifiers.IndexOf(modifier);
					if (num >= 0 && num < mirroredPart.Modifiers.Count)
					{
						return mirroredPart.Modifiers[num] as T;
					}
				}
				return null;
			}
		}

		public static PartData GetMirroredPart(PartData part)
		{
			using (Profile.GetMirroredPart.Auto())
			{
				if (part == null || part.SymmetryId == 0)
				{
					return null;
				}
				IReadOnlyList<PartData> symmetricParts = part.PartScript.Aircraft.Aircraft.Assembly.GetSymmetricParts(part.SymmetryId);
				if (symmetricParts.Count == 2)
				{
					return (symmetricParts[0] == part) ? symmetricParts[1] : symmetricParts[0];
				}
				return null;
			}
		}

		public static Vector3 GetMirroredPosition(Vector3 position, Unity.Mathematics.Geometry.Plane mirrorPlane)
		{
			using (Profile.GetMirroredPosition.Auto())
			{
				float num = math.dot(mirrorPlane.Normal, position) + mirrorPlane.Distance;
				return position - 2f * num * (Vector3)mirrorPlane.Normal;
			}
		}

		public static Vector3 GetMirroredPosition(Vector3 position, SymmetryConfig symmetry)
		{
			return GetMirroredPosition(position, symmetry.MirrorPlane);
		}

		public static Vector3 GetRadialPosition(Vector3 position, int symmetricSliceIndex, SymmetryConfig symmetry)
		{
			using (Profile.GetRadialPosition.Auto())
			{
				if (symmetricSliceIndex == 0)
				{
					return position;
				}
				float radialAngle = 360f / (float)GetSymmetricPartGroupCount(symmetry.Mode) * (float)symmetricSliceIndex;
				return GetRadialPosition(position, radialAngle, symmetry.RadialAxis.Axis, symmetry.RadialAxis.Point);
			}
		}

		public static Vector3 GetRadialPosition(Vector3 sourcePosition, float radialAngle, Vector3 radialAxis, Vector3 radialPoint)
		{
			return Quaternion.AngleAxis(radialAngle, radialAxis) * (sourcePosition - radialPoint) + radialPoint;
		}

		public static SymmetricAttachPointsAvailability GetSymmetricAttachPointsAvailability(AttachPointData sourceAttachPoint, AttachPointData targetAttachPoint, SymmetryConfig symmetry, out PartData unavailableSymmetricPart)
		{
			using (Profile.GetSymmetricAttachPointsAvailability.Auto())
			{
				if (sourceAttachPoint == null)
				{
					throw new ArgumentNullException("sourceAttachPoint");
				}
				if (targetAttachPoint == null)
				{
					throw new ArgumentNullException("targetAttachPoint");
				}
				if (symmetry == null)
				{
					throw new ArgumentNullException("symmetry");
				}
				unavailableSymmetricPart = null;
				if (symmetry.Mode == SymmetryMode.Disabled)
				{
					return SymmetricAttachPointsAvailability.Available;
				}
				PartData part = sourceAttachPoint.AttachPointScript.PartScript.Part;
				if (part.SymmetryId == 0)
				{
					return SymmetricAttachPointsAvailability.Available;
				}
				List<(PartData, PartData)> value;
				using (CollectionPool<List<(PartData, PartData)>, (PartData, PartData)>.Get(out value))
				{
					GetSymmetricPairs(sourceAttachPoint.AttachPointScript.PartScript.Part, targetAttachPoint.AttachPointScript.PartScript.Part, allowUnlinkedSymmetricParts: true, symmetry, value);
					if (value.Count == 0)
					{
						return SymmetricAttachPointsAvailability.Available;
					}
					SymmetricAttachPointsAvailability result = SymmetricAttachPointsAvailability.Available;
					PartData part2 = targetAttachPoint.AttachPointScript.PartScript.Part;
					foreach (var item in value)
					{
						if (item.Item1 == null || item.Item2 == null)
						{
							result = SymmetricAttachPointsAvailability.NotFound;
							continue;
						}
						int? symmetricPairSliceIndex = GetSymmetricPairSliceIndex(item.Item1, item.Item2, part, part2, symmetry);
						if (!symmetricPairSliceIndex.HasValue)
						{
							result = SymmetricAttachPointsAvailability.NotFound;
							continue;
						}
						AttachPointData attachPointData = FindSymmetricAttachPoint(sourceAttachPoint, item.Item1, symmetricPairSliceIndex.Value, symmetry);
						if (attachPointData == null)
						{
							if (Device.IsUnityEditor && part2 != item.Item1)
							{
								Debug.LogError($"Failed to find an attach point symmetric to attach point id '{sourceAttachPoint.Id}' on part '{part.Name} (Id: {part.Id})' " + $"for symmetric part '{item.Item1.Name} (Id: {item.Item1.Id})'. Is the part mirrored correctly?");
							}
							(unavailableSymmetricPart, _) = item;
							return SymmetricAttachPointsAvailability.NotFound;
						}
						if (attachPointData.IsAvailable)
						{
							AttachPointData attachPointData2 = FindSymmetricAttachPoint(targetAttachPoint, item.Item2, symmetricPairSliceIndex.Value, symmetry);
							if (attachPointData2 == null)
							{
								if (Device.IsUnityEditor && part2 != item.Item2)
								{
									Debug.LogError($"Failed to find an attach point symmetric to attach point id '{targetAttachPoint.Id}' on part '{part2.Name} (Id: {part2.Id})' " + $"for symmetric part '{item.Item2.Name} (Id: {item.Item2.Id})'. Is the part mirrored correctly?");
								}
								unavailableSymmetricPart = item.Item2;
								return SymmetricAttachPointsAvailability.NotFound;
							}
							if (attachPointData2.IsAvailable)
							{
								continue;
							}
							unavailableSymmetricPart = item.Item2;
							return SymmetricAttachPointsAvailability.NotAvailable;
						}
						(unavailableSymmetricPart, _) = item;
						return SymmetricAttachPointsAvailability.NotAvailable;
					}
					return result;
				}
			}
		}

		public static void GetSymmetricModifiers(PartModifierData partModifier, bool includeCurrentModifier, IList<PartModifierData> symmetricModifiers)
		{
			SymmetryUtility.GetSymmetricModifiers<PartModifierData>(partModifier, includeCurrentModifier, symmetricModifiers);
		}

		public static void GetSymmetricModifiers<T>(T partModifier, bool includeCurrentModifier, IList<T> symmetricModifiers) where T : PartModifierData
		{
			if (includeCurrentModifier)
			{
				symmetricModifiers.Add(partModifier);
			}
			PartData part = partModifier.Part;
			if (part.SymmetryId == 0)
			{
				return;
			}
			int num = 0;
			Type type = partModifier.GetType();
			bool flag = false;
			foreach (PartModifierData modifier in part.Modifiers)
			{
				if (modifier == partModifier)
				{
					flag = true;
					break;
				}
				if (modifier.GetType() == type)
				{
					num++;
				}
			}
			if (!flag)
			{
				Debug.LogError($"Unable to find the specified part modifier ('{type.Name}') in the modifier list for its own part ({part.Id}).");
				return;
			}
			Assembly assembly = part.PartScript.Aircraft.Aircraft.Assembly;
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				assembly.GetOtherSymmetricParts(partModifier.Part, value);
				foreach (PartData item in value)
				{
					PartModifierData partModifierData = null;
					int num2 = 0;
					foreach (PartModifierData modifier2 in item.Modifiers)
					{
						if (modifier2.GetType() == type)
						{
							if (num2 == num)
							{
								partModifierData = modifier2;
								break;
							}
							num2++;
						}
					}
					if (partModifierData == null)
					{
						Debug.LogError($"Unable to find the symmetric part modifier on part {item.Id} for source part {part.Id} and modifier " + "'" + type.FullName + "'" + ((num == 0) ? string.Empty : $" at index {num}"));
					}
					else
					{
						symmetricModifiers.Add((T)partModifierData);
					}
				}
			}
		}

		public static void GetSymmetricPairs(PartData partA, PartData partB, bool allowUnlinkedSymmetricParts, SymmetryConfig symmetry, IList<(PartData PartA, PartData PartB)> symmetricPairs)
		{
			using (Profile.GetSymmetricPairs.Auto())
			{
				symmetricPairs.Clear();
				bool flag = partA.SymmetryId != 0;
				bool flag2 = partB.SymmetryId != 0;
				if (!flag && !flag2)
				{
					return;
				}
				Assembly assembly = partA.PartScript.Aircraft.Aircraft.Assembly;
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					if (flag)
					{
						assembly.GetOtherSymmetricParts(partA, value);
					}
					else if (allowUnlinkedSymmetricParts)
					{
						FindUnlinkedSymmetricParts(partA, includeSelf: false, ignoreSymmetryDisabled: true, allowSamePosition: true, null, symmetry, value);
					}
					List<PartData> value2;
					using (CollectionPool<List<PartData>, PartData>.Get(out value2))
					{
						if (flag2)
						{
							assembly.GetOtherSymmetricParts(partB, value2);
						}
						else if (allowUnlinkedSymmetricParts)
						{
							FindUnlinkedSymmetricParts(partB, includeSelf: false, ignoreSymmetryDisabled: true, allowSamePosition: true, null, symmetry, value2);
						}
						int num = GetSymmetricPartGroupCount(symmetry.Mode) - 1;
						if (flag && flag2)
						{
							if (value.Count != num || value2.Count != num)
							{
								Debug.LogError($"An error occurred trying to find symmetric part pairs for parts '{partA.Id}' and '{partB.Id}'. " + $"{num} pairs were expected but part '{partA.Id}' found {value.Count} symmetric parts and part '{partB.Id}' found '{value2.Count}' symmetric parts.");
								return;
							}
						}
						else
						{
							List<PartData> list = (flag ? value2 : value);
							PartData partData = (flag ? partB : partA);
							Vector3 position = partData.PartScript.transform.position;
							Vector3 symmetricPosition = GetSymmetricPosition(position, 0, symmetry);
							Vector3 symmetricPosition2 = GetSymmetricPosition(position, 1, symmetry);
							if (Utilities.CompareVector3s(symmetricPosition, symmetricPosition2, 0.001f))
							{
								for (int i = list.Count; i < num; i++)
								{
									list.Add(partData);
								}
							}
							else
							{
								for (int j = list.Count; j < num; j++)
								{
									list.Add(null);
								}
							}
						}
						if (num == 1)
						{
							symmetricPairs.Add((value[0], value2[0]));
							return;
						}
						bool flag3 = !flag;
						if (flag3)
						{
							PartData partData2 = partB;
							PartData partData3 = partA;
							partA = partData2;
							partB = partData3;
							List<PartData> list2 = value2;
							List<PartData> list3 = value;
							value = list2;
							value2 = list3;
						}
						float sqrMagnitude = (partA.PartScript.transform.position - partB.PartScript.transform.position).sqrMagnitude;
						int count = value.Count;
						int num2 = value2.Count;
						for (int k = 0; k < count; k++)
						{
							int num3 = -1;
							for (int l = 0; l < num2; l++)
							{
								if (value2[l] == null)
								{
									num3 = l;
								}
								else if (System.Math.Abs((value[k].PartScript.transform.position - value2[l].PartScript.transform.position).sqrMagnitude - sqrMagnitude) < 0.001f)
								{
									num3 = l;
									break;
								}
							}
							if (num3 != -1)
							{
								symmetricPairs.Add(flag3 ? (value2[num3], value[k]) : (value[k], value2[num3]));
								value2.RemoveAt(num3);
								num2--;
							}
						}
						if (symmetricPairs.Count != count || num2 != 0)
						{
							Debug.LogError($"An error occurred trying to find symmetric part pairs for parts '{partA.Id}' and '{partB.Id}'. Not all pairs could be found. Expected '{count}' pairs.");
							symmetricPairs.Clear();
						}
					}
				}
			}
		}

		public static int? GetSymmetricPairSliceIndex(PartData partA, PartData partB, PartData sourcePartA, PartData sourcePartB, SymmetryConfig symmetry)
		{
			using (Profile.GetSymmetricPairSliceIndex.Auto())
			{
				int? symmetricSliceIndex = GetSymmetricSliceIndex(partA, sourcePartA, symmetry);
				int? symmetricSliceIndex2 = GetSymmetricSliceIndex(partB, sourcePartB, symmetry);
				if (!symmetricSliceIndex.HasValue || !symmetricSliceIndex2.HasValue)
				{
					if (!symmetricSliceIndex.HasValue)
					{
						Debug.LogWarning($"Unable to determine the symmetric slice index of parts '{partA.Id}' and '{partB.Id}' relative to parts '{sourcePartA.Id}' and '{sourcePartB.Id}'. " + $"An error occurred determining the symmetric slice to which part '{partA.Id}' belongs (relative to part '{sourcePartA.Id}')");
					}
					if (!symmetricSliceIndex2.HasValue)
					{
						Debug.LogWarning($"Unable to determine the symmetric slice index of parts '{partA.Id}' and '{partB.Id}' relative to parts '{sourcePartA.Id}' and '{sourcePartB.Id}'. " + $"An error occurred determining the symmetric slice to which part '{partB.Id}' belongs (relative to part '{sourcePartB.Id}')");
					}
					return null;
				}
				if (symmetricSliceIndex.Value != symmetricSliceIndex2.Value && symmetricSliceIndex.Value != 0 && symmetricSliceIndex2.Value != 0)
				{
					Debug.LogWarning($"Unable to determine the symmetric slice index of parts '{partA.Id}' and '{partB.Id}' relative to parts '{sourcePartA.Id}' and '{sourcePartB.Id}'. " + $"Part '{partA.Id}' belongs to symmetric slice '{symmetricSliceIndex.Value}' but part '{partB.Id}' belongs to symmetric slice '{symmetricSliceIndex2.Value}'");
					return null;
				}
				int num = ((symmetricSliceIndex.Value == 0) ? symmetricSliceIndex2.Value : symmetricSliceIndex.Value);
				if (num == 0)
				{
					Debug.LogWarning($"Unable to determine the symmetric slice index of parts '{partA.Id}' and '{partB.Id}' relative to parts '{sourcePartA.Id}' and '{sourcePartB.Id}'. " + $"Part '{partA.Id}' and part '{partB.Id} both appear to belong to symmetric slice 0");
					return null;
				}
				return num;
			}
		}

		public static int GetSymmetricPartGroupCount(SymmetryMode symmetryMode)
		{
			return symmetryMode switch
			{
				SymmetryMode.Disabled => 1, 
				SymmetryMode.Mirrored => 2, 
				SymmetryMode.Radial2x => 2, 
				SymmetryMode.Radial3x => 3, 
				SymmetryMode.Radial4x => 4, 
				_ => throw new NotSupportedException($"Symmetry mode of '{symmetryMode}' is not currently supported."), 
			};
		}

		public static void GetSymmetricPartGroups(IList<PartData> parts, SymmetryConfig symmetry, IList<SymmetryPartGroup> symmetricPartGroups)
		{
			using (Profile.GetSymmetricPartGroups.Auto())
			{
				if (symmetry.Mode == SymmetryMode.Disabled)
				{
					return;
				}
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					int num = GetSymmetricPartGroupCount(symmetry.Mode) - 1;
					for (int i = 0; i < num; i++)
					{
						float radialAngle = ((symmetry.Mode == SymmetryMode.Mirrored) ? 0f : (360f / (float)(num + 1) * (float)(i + 1)));
						symmetricPartGroups.Add(new SymmetryPartGroup(radialAngle));
					}
					if (parts == null || parts.Count == 0)
					{
						return;
					}
					Assembly assembly = parts[0].PartScript.Aircraft.Aircraft.Assembly;
					foreach (PartData part in parts)
					{
						value.Clear();
						if (part.SymmetryId != 0)
						{
							assembly.GetOtherSymmetricParts(part, value);
							if (value.Count != num)
							{
								Debug.LogError($"Unable to get symmetric part groups. Part '{part.Id}' was expected to have '{num}' symmetric parts but instead had '{value.Count}' symmetric parts");
								ClearPartSymmetricGroups(symmetricPartGroups);
								break;
							}
							if (value.Count == 1)
							{
								symmetricPartGroups[0].Parts.Add(value[0]);
								continue;
							}
							for (int j = 0; j < num; j++)
							{
								SymmetryPartGroup symmetryPartGroup = symmetricPartGroups[j];
								Vector3 radialPosition = GetRadialPosition(part.PartScript.transform.position, symmetryPartGroup.RadialAngle, symmetry.RadialAxis.Axis, symmetry.RadialAxis.Point);
								for (int k = 0; k < value.Count; k++)
								{
									PartData partData = value[k];
									if (Utilities.CompareVector3s(partData.PartScript.transform.position, radialPosition, 0.001f))
									{
										symmetryPartGroup.Parts.Add(partData);
										value.RemoveAt(k);
										break;
									}
								}
							}
							if (value.Count == 0)
							{
								continue;
							}
							Debug.LogError($"Unable to get symmetric part groups. Part '{part.Id}' had '{value.Count}' parts that could not be matched up with their expected symmetric positions");
							ClearPartSymmetricGroups(symmetricPartGroups);
							break;
						}
						Debug.LogError($"Unable to get symmetric part groups. Part '{part.Id}' does not have a symmetry id.");
						ClearPartSymmetricGroups(symmetricPartGroups);
						break;
					}
				}
			}
			static void ClearPartSymmetricGroups(IList<SymmetryPartGroup> list)
			{
				foreach (SymmetryPartGroup item in list)
				{
					item.Dispose();
				}
				list.Clear();
			}
		}

		public static Vector3 GetSymmetricPosition(Vector3 position, int symmetricSliceIndex, SymmetryConfig symmetry)
		{
			using (Profile.GetSymmetricPosition.Auto())
			{
				if (symmetricSliceIndex < 0 || symmetricSliceIndex >= GetSymmetricPartGroupCount(symmetry.Mode))
				{
					throw new IndexOutOfRangeException($"Symmetric slice index '{symmetricSliceIndex}' is out of range for symmetry mode '{symmetry.Mode}'.");
				}
				if (symmetricSliceIndex == 0)
				{
					return position;
				}
				if (symmetry.Mode == SymmetryMode.Disabled)
				{
					return position;
				}
				if (symmetry.Mode == SymmetryMode.Mirrored)
				{
					return GetMirroredPosition(position, symmetry);
				}
				return GetRadialPosition(position, symmetricSliceIndex, symmetry);
			}
		}

		public static void GetSymmetricPositions(Vector3 position, SymmetryConfig symmetry, IList<Vector3> symmetricPositions)
		{
			using (Profile.GetSymmetricPositions.Auto())
			{
				if (symmetry.Mode == SymmetryMode.Disabled)
				{
					return;
				}
				if (symmetry.Mode == SymmetryMode.Mirrored)
				{
					symmetricPositions.Add(GetMirroredPosition(position, symmetry));
					return;
				}
				if (symmetry.Mode == SymmetryMode.Radial2x || symmetry.Mode == SymmetryMode.Radial3x || symmetry.Mode == SymmetryMode.Radial4x)
				{
					int symmetricPartGroupCount = GetSymmetricPartGroupCount(symmetry.Mode);
					float num = 360f / (float)symmetricPartGroupCount;
					(float3, float3) radialAxis = symmetry.RadialAxis;
					Vector3 vector = position - (Vector3)radialAxis.Item2;
					for (int i = 1; i < symmetricPartGroupCount; i++)
					{
						Vector3 item = Quaternion.AngleAxis(num * (float)i, radialAxis.Item1) * vector + (Vector3)radialAxis.Item2;
						symmetricPositions.Add(item);
					}
					return;
				}
				throw new NotSupportedException($"Symmetry mode of '{symmetry.Mode}' is not currently supported.");
			}
		}

		public static int? GetSymmetricSliceIndex(PartData part, PartData sourcePart, SymmetryConfig symmetry)
		{
			using (Profile.GetSymmetricSliceIndex.Auto())
			{
				if (symmetry.Mode == SymmetryMode.Mirrored)
				{
					Vector3 position = part.PartScript.transform.position;
					Vector3 position2 = sourcePart.PartScript.transform.position;
					Vector3 mirroredPosition = GetMirroredPosition(position2, symmetry);
					if (Utilities.CompareVector3s(position, mirroredPosition, 0.001f))
					{
						return 1;
					}
					if (Utilities.CompareVector3s(position, position2, 0.001f))
					{
						return 0;
					}
				}
				else if (symmetry.Mode != SymmetryMode.Disabled)
				{
					int symmetricPartGroupCount = GetSymmetricPartGroupCount(symmetry.Mode);
					float num = 360f / (float)symmetricPartGroupCount;
					float3 item = symmetry.RadialAxis.Axis;
					float3 item2 = symmetry.RadialAxis.Point;
					Vector3 position3 = part.PartScript.transform.position;
					Vector3 position4 = sourcePart.PartScript.transform.position;
					for (int i = 0; i < symmetricPartGroupCount; i++)
					{
						float radialAngle = num * (float)i;
						Vector3 radialPosition = GetRadialPosition(position4, radialAngle, item, item2);
						if (Utilities.CompareVector3s(position3, radialPosition, 0.001f))
						{
							return i;
						}
					}
				}
				return null;
			}
		}

		public static void GetSymmetricTransforms(PartData part, SymmetryConfig symmetry, IList<SymmetryTransform> symmetricTransforms)
		{
			using (Profile.GetSymmetricTransforms.Auto())
			{
				Vector3? mirrorRotationOffset = null;
				if (symmetry.Mode == SymmetryMode.Mirrored)
				{
					mirrorRotationOffset = part.PartType.MirrorRotationOffset;
				}
				Transform transform = part.PartScript.transform;
				GetSymmetricTransforms(new SymmetryTransform(transform.position, transform.rotation), mirrorRotationOffset, symmetry, symmetricTransforms);
			}
		}

		public static void GetSymmetricTransforms(SymmetryTransform transform, SymmetryConfig symmetry, IList<SymmetryTransform> symmetricTransforms)
		{
			using (Profile.GetSymmetricTransforms.Auto())
			{
				GetSymmetricTransforms(transform, null, symmetry, symmetricTransforms);
			}
		}

		public static bool HasOverlappingSymmetricParts(IReadOnlyList<PartScript> parts)
		{
			using (Profile.HasOverlappingSymmetricParts.Auto())
			{
				if (parts == null || parts.Count == 0)
				{
					return false;
				}
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					Assembly assembly = parts[0].Aircraft.Aircraft.Assembly;
					for (int i = 0; i < parts.Count; i++)
					{
						PartScript partScript = parts[i];
						value.Clear();
						if (IsOverlappingSymmetricParts(partScript.Part, assembly, value))
						{
							return true;
						}
					}
					return false;
				}
			}
		}

		public static bool IsConnectedToCockpit(List<PartScript> parts, bool ignoreSourcePartCockpits)
		{
			using (Profile.IsConnectedToCockpit.Auto())
			{
				Queue<PartData> value;
				using (QueuePool<PartData>.Get(out value))
				{
					HashSet<int> value2;
					using (CollectionPool<HashSet<int>, int>.Get(out value2))
					{
						HashSet<int> value3;
						using (CollectionPool<HashSet<int>, int>.Get(out value3))
						{
							foreach (PartScript part in parts)
							{
								if (part.Part.IsCockpit)
								{
									if (!ignoreSourcePartCockpits)
									{
										return true;
									}
									value3.Add(part.Part.Id);
								}
								if (value2.Add(part.Part.Id))
								{
									value.Enqueue(part.Part);
								}
							}
							while (value.Count > 0)
							{
								PartData partData = value.Dequeue();
								if (partData.IsCockpit && !value3.Contains(partData.Id))
								{
									return true;
								}
								foreach (PartConnection partConnection in partData.PartConnections)
								{
									PartData otherPart = partConnection.GetOtherPart(partData);
									if (otherPart != null && value2.Add(otherPart.Id))
									{
										value.Enqueue(otherPart);
									}
								}
							}
							return false;
						}
					}
				}
			}
		}

		public static bool IsOverlappingSymmetricParts(PartData part)
		{
			using (Profile.IsOverlappingSymmetricParts.Auto())
			{
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					Assembly assembly = part.PartScript.Aircraft.Aircraft.Assembly;
					return IsOverlappingSymmetricParts(part, assembly, value);
				}
			}
		}

		public static bool IsSymmetricAttachPoint(AttachPointData attachPoint, AttachPointData attachPointOther, int symmetricSliceIndex, SymmetryConfig symmetry)
		{
			using (Profile.IsSymmetricAttachPoint.Auto())
			{
				if (attachPoint.MirrorId >= 0 && attachPoint.MirrorId == attachPointOther.Id && symmetry.Mode == SymmetryMode.Mirrored)
				{
					return true;
				}
				if (attachPoint.JointType == attachPointOther.JointType && attachPoint.Surface == attachPointOther.Surface && attachPoint.SeekType == attachPointOther.SeekType && attachPoint.ReceiveType == attachPointOther.ReceiveType)
				{
					Vector3 position = attachPoint.AttachPointScript.transform.position;
					Vector3 position2 = attachPointOther.AttachPointScript.transform.position;
					Vector3 symmetricPosition = GetSymmetricPosition(position, symmetricSliceIndex, symmetry);
					if (Utilities.CompareVector3s(position2, symmetricPosition, 0.001f))
					{
						return true;
					}
				}
				return false;
			}
		}

		public static bool IsSymmetricPartsValid(PartData part, List<PartData> symmetricParts, SymmetryConfig symmetry)
		{
			using (Profile.IsSymmetricPartsValid.Auto())
			{
				if (part.SymmetryDisabled)
				{
					Debug.LogError($"Part with id '{part.Id}' has a symmetry id of '{part.SymmetryId}' while the part has symmetry disabled.");
					return false;
				}
				foreach (PartData symmetricPart in symmetricParts)
				{
					if (part.SymmetryId != symmetricPart.SymmetryId)
					{
						Debug.LogError($"Part with id '{part.Id}' has a symmetry id of '{part.SymmetryId}' that does not match " + $"the symmetric part with id '{symmetricPart.Id}' and a symmetry id of '{symmetricPart.SymmetryId}'.");
						return false;
					}
					if (symmetricPart.SymmetryDisabled)
					{
						Debug.LogError($"Part with id '{symmetricPart.Id}' has a symmetry id of '{symmetricPart.SymmetryId}' while the part has symmetry disabled.");
						return false;
					}
					if (part.PartType != symmetricPart.PartType)
					{
						Debug.LogError($"Part with id '{part.Id}' and symmetry id '{part.SymmetryId}' has a part type of '{part.PartType}' that does not match " + $"the symmetricPart part with id '{symmetricPart.Id}' and a part type of '{symmetricPart.PartType}'.");
						return false;
					}
				}
				List<Vector3> value;
				using (CollectionPool<List<Vector3>, Vector3>.Get(out value))
				{
					GetSymmetricPositions(part.PartScript.transform.position, symmetry, value);
					if (symmetricParts.Count != value.Count)
					{
						return false;
					}
					foreach (PartData symmetricPart2 in symmetricParts)
					{
						Vector3 position = symmetricPart2.PartScript.transform.position;
						for (int i = 0; i < value.Count; i++)
						{
							if (Utilities.CompareVector3s(position, value[i], 0.001f))
							{
								value.RemoveAt(i);
								break;
							}
						}
					}
					if (value.Count > 0)
					{
						return false;
					}
					return true;
				}
			}
		}

		public static void MoveConnectedParts(PartData part, AttachPointData ap0, AttachPointData ap1, Vector3 previousPosition0, Vector3? previousPosition1, bool ignoreSymmetricParts = false)
		{
			if (!previousPosition1.HasValue)
			{
				ap1 = null;
			}
			Vector3 vector = ((ap0.PartConnections.Count == 1) ? (ap0.AttachPointScript.transform.position - previousPosition0) : Vector3.zero);
			Vector3 vector2 = (((ap1?.PartConnections.Count ?? 0) == 1) ? (ap1.AttachPointScript.transform.position - previousPosition1.Value) : Vector3.zero);
			SymmetryConfig symmetryConfig = Designer.Instance.Symmetry;
			if (symmetryConfig.Mode == SymmetryMode.Disabled)
			{
				symmetryConfig = symmetryConfig.Clone(SymmetryMode.Mirrored);
			}
			bool flag = false;
			if (symmetryConfig.Mode == SymmetryMode.Mirrored)
			{
				flag = Utilities.CompareFloats(Vector3.Dot(vector, symmetryConfig.MirrorPlane.Normal), 0f) && Utilities.CompareFloats(Vector3.Dot(vector2, symmetryConfig.MirrorPlane.Normal), 0f);
			}
			else
			{
				Debug.LogError("Radial symmetry not yet supported");
			}
			if (flag)
			{
				if (!Utilities.CompareVector3s(vector, Vector3.zero))
				{
					RepositionParts(part, ap0.PartConnections[0], vector, vector, ignoreSymmetricParts);
				}
				if (!Utilities.CompareVector3s(vector2, Vector3.zero))
				{
					RepositionParts(part, ap1.PartConnections[0], vector2, vector2, ignoreSymmetricParts);
				}
				return;
			}
			AsymmetricRepositionPrepassData asymmetricRepositionPrepassData = ((!Utilities.CompareVector3s(vector, Vector3.zero)) ? AsymmetricRepositionPrepass(part, ap0.PartConnections[0], symmetryConfig) : new AsymmetricRepositionPrepassData(isAllowed: true, null));
			AsymmetricRepositionPrepassData asymmetricRepositionPrepassData2 = ((!Utilities.CompareVector3s(vector2, Vector3.zero)) ? AsymmetricRepositionPrepass(part, ap1.PartConnections[0], symmetryConfig) : new AsymmetricRepositionPrepassData(isAllowed: true, null));
			if (asymmetricRepositionPrepassData.IsSupported && asymmetricRepositionPrepassData2.IsSupported)
			{
				if ((ap0?.PartConnections.Count ?? 0) == 1 && !Utilities.CompareVector3s(vector, Vector3.zero))
				{
					Vector3 symmetricPartsDelta = Vector3.Reflect(vector, symmetryConfig.MirrorPlane.Normal);
					RepositionParts(part, ap0.PartConnections[0], vector, symmetricPartsDelta, ignoreSymmetricParts);
				}
				if ((ap1?.PartConnections.Count ?? 0) == 1 && !Utilities.CompareVector3s(vector2, Vector3.zero))
				{
					Vector3 symmetricPartsDelta2 = Vector3.Reflect(vector2, symmetryConfig.MirrorPlane.Normal);
					RepositionParts(part, ap1.PartConnections[0], vector2, symmetricPartsDelta2, ignoreSymmetricParts);
				}
				return;
			}
			if (asymmetricRepositionPrepassData.IsSupported)
			{
				part.PartScript.transform.position -= vector2;
				vector -= vector2;
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					part.PartScript.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(part, value);
					foreach (PartData item in value)
					{
						item.PartScript.transform.position -= Vector3.Reflect(vector2, symmetryConfig.MirrorPlane.Normal);
					}
					if ((ap0?.PartConnections.Count ?? 0) == 1 && !Utilities.CompareVector3s(vector, Vector3.zero))
					{
						Vector3 symmetricPartsDelta3 = Vector3.Reflect(vector, symmetryConfig.MirrorPlane.Normal);
						RepositionParts(part, ap0.PartConnections[0], vector, symmetricPartsDelta3, ignoreSymmetricParts);
					}
					return;
				}
			}
			if (!asymmetricRepositionPrepassData2.IsSupported)
			{
				return;
			}
			part.PartScript.transform.position -= vector;
			vector2 -= vector;
			List<PartData> value2;
			using (CollectionPool<List<PartData>, PartData>.Get(out value2))
			{
				part.PartScript.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(part, value2);
				foreach (PartData item2 in value2)
				{
					item2.PartScript.transform.position -= Vector3.Reflect(vector, symmetryConfig.MirrorPlane.Normal);
				}
				if ((ap1?.PartConnections.Count ?? 0) == 1 && !Utilities.CompareVector3s(vector2, Vector3.zero))
				{
					Vector3 symmetricPartsDelta4 = Vector3.Reflect(vector2, symmetryConfig.MirrorPlane.Normal);
					RepositionParts(part, ap1.PartConnections[0], vector2, symmetricPartsDelta4, ignoreSymmetricParts);
				}
			}
		}

		public static bool PartsSpanSymmetricOrigin(List<PartScript> parts, bool symmetricPartsOnly, SymmetryConfig symmetry)
		{
			using (Profile.PartsSpanSymmetricOrigin.Auto())
			{
				if (symmetry.Mode == SymmetryMode.Disabled)
				{
					return false;
				}
				bool flag = symmetry.Mode == SymmetryMode.Mirrored;
				float3 float5 = (flag ? ((0f - symmetry.MirrorPlane.Distance) * symmetry.MirrorPlane.Normal) : symmetry.RadialAxis.Point);
				float3? float6 = (flag ? new float3?(symmetry.MirrorPlane.Normal) : ((float3?)null));
				float3 item = symmetry.RadialAxis.Axis;
				float? num = null;
				foreach (PartScript part in parts)
				{
					if (symmetricPartsOnly && part.Part.SymmetryId == 0)
					{
						continue;
					}
					float3 float7 = part.transform.position;
					float3 float8 = (flag ? (float7 - float5) : GetVectorPerpendicularToRadialAxis(item, float5, float7));
					if (!float6.HasValue)
					{
						if (Utilities.CompareVector3s(float8, Vector3.zero, 0.001f))
						{
							if (part.Part.SymmetryId == 0 || IsOverlappingSymmetricParts(part.Part))
							{
								return true;
							}
							continue;
						}
						float6 = math.normalize(float8);
					}
					float num2 = math.dot(float8, float6.Value);
					if (Utilities.CompareFloats(num2, 0f, 0.001f))
					{
						if (part.Part.SymmetryId == 0 || IsOverlappingSymmetricParts(part.Part))
						{
							return true;
						}
						continue;
					}
					float num3 = math.sign(num2);
					if (!num.HasValue)
					{
						num = num3;
					}
					else if (num.Value != num3)
					{
						return true;
					}
				}
				return false;
			}
			static float3 GetVectorPerpendicularToRadialAxis(float3 axis, float3 axisOrigin, float3 position)
			{
				float num4 = Vector3.Dot(position - axisOrigin, axis);
				float3 float9 = axisOrigin + num4 * axis;
				return position - float9;
			}
		}

		public static void RepositionParts(PartData rootPart, PartConnection rootPartConnection, Vector3 delta, Vector3 symmetricPartsDelta, bool ignoreSymmetricParts, HashSet<uint> symmetryIdsToIgnore = null)
		{
			using (Profile.RepositionParts.Auto())
			{
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					if (rootPart == null)
					{
						throw new ArgumentNullException("rootPart");
					}
					if (rootPartConnection == null)
					{
						throw new ArgumentNullException("rootPartConnection");
					}
					Assembly assembly = rootPart.PartScript.Aircraft.Aircraft.Assembly;
					if (value == null)
					{
						value = new List<PartData>();
					}
					value.Clear();
					if (symmetryIdsToIgnore == null)
					{
						symmetryIdsToIgnore = new HashSet<uint>(0);
					}
					Queue<PartData> value2;
					using (QueuePool<PartData>.Get(out value2))
					{
						Queue<PartData> value3;
						using (QueuePool<PartData>.Get(out value3))
						{
							HashSet<int> value4;
							using (CollectionPool<HashSet<int>, int>.Get(out value4))
							{
								PartData otherPart = rootPartConnection.GetOtherPart(rootPart);
								if (otherPart == null)
								{
									return;
								}
								value4.Add(otherPart.Id);
								value2.Enqueue(otherPart);
								if (rootPart.SymmetryId == 0)
								{
									value4.Add(rootPart.Id);
								}
								else
								{
									AttachPointData attachPointData = null;
									if (rootPartConnection.AttachPointsA.Count > 0 && rootPartConnection.AttachPointsB.Count > 0)
									{
										PartData obj = rootPartConnection.AttachPointsA[0]?.AttachPointScript.PartScript.Part;
										PartData partData = rootPartConnection.AttachPointsB[0]?.AttachPointScript.PartScript.Part;
										attachPointData = ((obj == rootPart) ? rootPartConnection.AttachPointsA[0] : ((partData == rootPart) ? rootPartConnection.AttachPointsB[0] : null));
									}
									foreach (PartData symmetricPart in assembly.GetSymmetricParts(rootPart))
									{
										value4.Add(symmetricPart.Id);
										if (symmetricPart == rootPart || attachPointData == null || symmetricPart.AttachPoints.Count <= attachPointData.Id)
										{
											continue;
										}
										foreach (PartConnection partConnection in symmetricPart.AttachPoints[attachPointData.Id].PartConnections)
										{
											PartData otherPart2 = partConnection.GetOtherPart(symmetricPart);
											if (otherPart2.SymmetryId == 0 && value4.Add(otherPart2.Id))
											{
												value3.Enqueue(otherPart2);
											}
										}
									}
								}
								while (value2.Count > 0)
								{
									PartData partData2 = value2.Dequeue();
									value.Add(partData2);
									partData2.PartScript.transform.position += delta;
									if (partData2.SymmetryId != 0 && !symmetryIdsToIgnore.Contains(partData2.SymmetryId))
									{
										foreach (PartData symmetricPart2 in assembly.GetSymmetricParts(partData2))
										{
											if (symmetricPart2 != partData2 && value4.Add(symmetricPart2.Id))
											{
												value3.Enqueue(symmetricPart2);
											}
										}
									}
									foreach (PartConnection partConnection2 in partData2.PartConnections)
									{
										PartData otherPart3 = partConnection2.GetOtherPart(partData2);
										if (value4.Add(otherPart3.Id))
										{
											value2.Enqueue(otherPart3);
										}
									}
								}
								if (!ignoreSymmetricParts)
								{
									while (value3.Count > 0)
									{
										PartData partData3 = value3.Dequeue();
										value.Add(partData3);
										partData3.PartScript.transform.position += symmetricPartsDelta;
										foreach (PartConnection partConnection3 in partData3.PartConnections)
										{
											PartData otherPart4 = partConnection3.GetOtherPart(partData3);
											if ((otherPart4.SymmetryId == 0 || symmetryIdsToIgnore.Contains(partData3.SymmetryId)) && value4.Add(otherPart4.Id))
											{
												value3.Enqueue(otherPart4);
											}
										}
									}
								}
								PartData part = rootPart.PartScript.Aircraft.MainCockpit.Part;
								value.Add(rootPart);
								foreach (PartData item in value)
								{
									if (item == part)
									{
										Designer.Instance.UpdatePaintOrigin(delta);
									}
									IReadOnlyList<ICraftDecal> decals = item.Decals;
									for (int i = 0; i < decals.Count; i++)
									{
										decals[i].SetDirty();
									}
								}
							}
						}
					}
				}
			}
		}

		public static TogglePartSymmetryReport TogglePartSymmetryDisabledState(Designer designer, PartScript partScript, bool connectedParts, bool cloneUnlinkedOrToggleAndDelete, SymmetryConfig symmetry)
		{
			using (Profile.TogglePartSymmetryDisabledState.Auto())
			{
				bool flag = !partScript.Part.SymmetryDisabled;
				if (partScript.GetModifier<ControlSurfacePartScript>() != null)
				{
					foreach (PartConnection partConnection in partScript.Part.PartConnections)
					{
						PartData otherPart = partConnection.GetOtherPart(partScript.Part);
						if (otherPart.GetModifier<JWingData>() != null)
						{
							partScript = otherPart.PartScript;
							break;
						}
					}
				}
				PartSelection partSelection = PartSelection.CreatePartSelection(partScript, preserveConnections: true, null, null, !connectedParts, showAttachPoints: false);
				TogglePartSymmetryReport togglePartSymmetryReport = new TogglePartSymmetryReport(symmetry.Mode, flag, cloneUnlinkedOrToggleAndDelete, partScript.Part, partSelection.Parts.Count);
				try
				{
					Assembly assembly = partScript.Aircraft.Aircraft.Assembly;
					if (flag)
					{
						if (!IsConnectedToCockpit(partSelection.Parts, ignoreSourcePartCockpits: false))
						{
							List<PartData> value;
							using (CollectionPool<List<PartData>, PartData>.Get(out value))
							{
								GetAllSymmetricAndConnectedParts(partSelection.Parts, value);
								if (!value.Any((PartData x) => x.IsCockpit))
								{
									foreach (PartData item in value)
									{
										designer.DeletePart(item.PartScript);
										togglePartSymmetryReport.DeletedParts.Add(item);
									}
								}
							}
						}
						foreach (PartScript part in partSelection.Parts)
						{
							if (part.Part.SymmetryId == 0)
							{
								continue;
							}
							IReadOnlyList<PartData> symmetricParts = assembly.GetSymmetricParts(part.Part.SymmetryId);
							if (symmetricParts.Count > 0)
							{
								togglePartSymmetryReport.UnlinkedParts.Add(symmetricParts.ToList());
							}
							assembly.UnlinkSymmetricParts(part.Part.SymmetryId, disableSymmetry: true);
							if (!cloneUnlinkedOrToggleAndDelete)
							{
								continue;
							}
							foreach (PartData item2 in symmetricParts)
							{
								if (item2 != part.Part)
								{
									designer.DeletePart(item2.PartScript);
									togglePartSymmetryReport.DeletedParts.Add(item2);
								}
							}
						}
					}
					foreach (PartScript part2 in partSelection.Parts)
					{
						part2.Part.SymmetryDisabled = flag;
					}
					if (!flag)
					{
						bool flag2 = symmetry.Mode == SymmetryMode.Disabled;
						SymmetryConfig symmetry2 = (flag2 ? symmetry.Clone(SymmetryMode.Mirrored) : symmetry);
						List<PartScript> value2;
						using (CollectionPool<List<PartScript>, PartScript>.Get(out value2))
						{
							foreach (PartScript part3 in partSelection.Parts)
							{
								if (!part3.Part.TryGetModifier<JWingData>(out var result))
								{
									continue;
								}
								List<PartData> value3;
								using (CollectionPool<List<PartData>, PartData>.Get(out value3))
								{
									FindUnlinkedSymmetricParts(result.Part, includeSelf: false, ignoreSymmetryDisabled: true, allowSamePosition: false, null, symmetry2, value3);
									foreach (PartData item3 in value3)
									{
										if (partSelection.Parts.Contains(item3.PartScript))
										{
											continue;
										}
										foreach (ControlSurfacePartData item4 in item3.GetModifier<JWingData>()?.ControlSurfacesInformational ?? new List<ControlSurfacePartData>(0))
										{
											if (!partSelection.Parts.Contains(item4.Part.PartScript))
											{
												value2.Add(item4.Part.PartScript);
											}
										}
									}
								}
							}
							foreach (PartScript item5 in value2)
							{
								designer.DeletePart(item5);
								togglePartSymmetryReport.DeletedParts.Add(item5.Part);
							}
							List<PartData> value4;
							using (CollectionPool<List<PartData>, PartData>.Get(out value4))
							{
								foreach (PartScript part4 in partSelection.Parts)
								{
									if (part4.Part.SymmetryId == 0)
									{
										value4.Clear();
										value4.Add(part4.Part);
										AutoLinkSymmetricParts(value4, null, ignoreSymmetryDisabled: true, symmetry2);
										IReadOnlyList<PartData> symmetricParts2 = assembly.GetSymmetricParts(part4.Part.SymmetryId);
										if (symmetricParts2.Count > 0)
										{
											togglePartSymmetryReport.LinkedParts.Add(symmetricParts2.ToList());
										}
									}
								}
								List<PartData> value5;
								using (CollectionPool<List<PartData>, PartData>.Get(out value5))
								{
									foreach (PartScript part5 in partSelection.Parts)
									{
										if (part5.Part.SymmetryId == 0)
										{
											value4.Clear();
											CreateSymmetricParts(part5.Part, allowOverlappingPositions: false, symmetry2, value4);
											if (value4.Count > 0)
											{
												value5.Add(part5.Part);
												togglePartSymmetryReport.CreatedParts.Add(value4.ToList());
											}
										}
									}
									foreach (PartData item6 in value5)
									{
										foreach (PartConnection partConnection2 in item6.PartConnections)
										{
											int num = Mathf.Min(partConnection2.AttachPointsA.Count, partConnection2.AttachPointsB.Count);
											for (int num2 = 0; num2 < num; num2++)
											{
												ConnectSymmetricParts(partConnection2.AttachPointsA[num2].AttachPointScript, partConnection2.AttachPointsB[num2].AttachPointScript, symmetry2, null, togglePartSymmetryReport.ConnectionFailures);
											}
										}
									}
									if (flag2 || cloneUnlinkedOrToggleAndDelete)
									{
										foreach (PartScript part6 in partSelection.Parts)
										{
											if (part6.Part.SymmetryId != 0)
											{
												assembly.UnlinkSymmetricParts(part6.Part.SymmetryId, disableSymmetry: true);
											}
											else
											{
												part6.Part.SymmetryDisabled = true;
											}
										}
									}
								}
							}
						}
					}
				}
				finally
				{
					partSelection.Deselect();
				}
				return togglePartSymmetryReport;
			}
		}

		private static bool CheckIfPartConnectionExists(PartData partA, PartData partB, AttachPointData attachPointA, AttachPointData attachPointB)
		{
			bool result = false;
			foreach (PartConnection partConnection in partA.PartConnections)
			{
				if ((partConnection.PartA != partA || partConnection.PartB != partB) && (partConnection.PartB != partA || partConnection.PartA != partB))
				{
					continue;
				}
				for (int i = 0; i < partConnection.AttachPointsA.Count; i++)
				{
					AttachPointData attachPointData = partConnection.AttachPointsA[i];
					AttachPointData attachPointData2 = partConnection.AttachPointsB[i];
					if ((attachPointA == attachPointData && attachPointB == attachPointData2) || (attachPointA == attachPointData2 && attachPointB == attachPointData))
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		private static int DeleteInvalidSymmetricPart(Designer designer, PartData part, bool raiseAircraftStructureChanged)
		{
			using (Profile.DeleteInvalidSymmetricPart.Auto())
			{
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					value.Add(part);
					PartSelection partSelection = PartSelection.CreateSymmetricPartSelection(value, Vector3.zero, Quaternion.identity, selectSinglePart: false, preserveConnections: false, showAttachPoints: false);
					partSelection.Deselect();
					int count = partSelection.Parts.Count;
					foreach (PartScript part2 in partSelection.Parts)
					{
						designer.DeletePart(part2);
					}
					if (raiseAircraftStructureChanged)
					{
						designer.OnAircraftStructureChanged();
					}
					return count;
				}
			}
		}

		private static void GetSymmetricTransforms(SymmetryTransform transform, Vector3? mirrorRotationOffset, SymmetryConfig symmetry, IList<SymmetryTransform> symmetricTransforms)
		{
			using (Profile.GetSymmetricTransforms.Auto())
			{
				if (symmetry.Mode == SymmetryMode.Disabled)
				{
					return;
				}
				if (symmetry.Mode == SymmetryMode.Mirrored)
				{
					Unity.Mathematics.Geometry.Plane mirrorPlane = symmetry.MirrorPlane;
					float num = math.dot(mirrorPlane.Normal, transform.Position) + mirrorPlane.Distance;
					Vector3 position = transform.Position - 2f * num * (Vector3)mirrorPlane.Normal;
					Quaternion rotation = transform.Rotation.Mirror(mirrorPlane.Normal);
					if (mirrorRotationOffset.HasValue && mirrorRotationOffset.Value != Vector3.zero)
					{
						rotation *= Quaternion.Euler(-mirrorRotationOffset.Value);
					}
					symmetricTransforms.Add(new SymmetryTransform(position, rotation));
					return;
				}
				if (symmetry.Mode == SymmetryMode.Radial2x || symmetry.Mode == SymmetryMode.Radial3x || symmetry.Mode == SymmetryMode.Radial4x)
				{
					int num2 = symmetry.Mode switch
					{
						SymmetryMode.Radial2x => 2, 
						SymmetryMode.Radial3x => 3, 
						SymmetryMode.Radial4x => 4, 
						_ => throw new InvalidOperationException($"Invalid radial symmetry mode: {symmetry.Mode}"), 
					};
					float num3 = 360f / (float)num2;
					(float3, float3) radialAxis = symmetry.RadialAxis;
					Vector3 vector = transform.Position - (Vector3)radialAxis.Item2;
					for (int i = 1; i < num2; i++)
					{
						Quaternion obj = Quaternion.AngleAxis(num3 * (float)i, radialAxis.Item1);
						Vector3 position2 = obj * vector + (Vector3)radialAxis.Item2;
						Quaternion rotation2 = obj * transform.Rotation;
						symmetricTransforms.Add(new SymmetryTransform(position2, rotation2));
					}
					return;
				}
				throw new NotSupportedException($"Symmetry mode of '{symmetry.Mode}' is not currently supported.");
			}
		}

		private static bool IsOverlappingSymmetricParts(PartData part, Assembly assembly, IList<PartData> tempList)
		{
			using (Profile.IsOverlappingSymmetricParts.Auto())
			{
				Vector3 position = part.PartScript.transform.position;
				assembly.GetOtherSymmetricParts(part, tempList);
				for (int i = 0; i < tempList.Count; i++)
				{
					PartData partData = tempList[i];
					Vector3 position2 = partData.PartScript.transform.position;
					if (!Utilities.CompareVector3s(position, position2, 0.001f))
					{
						continue;
					}
					if (part.PartType.HasAttachPointAtPartOrigin)
					{
						if (part.TryGetModifier<ControlSurfacePartData>(out var result) && partData.TryGetModifier<ControlSurfacePartData>(out var result2))
						{
							JWingData firstConnectedWing = result.GetFirstConnectedWing();
							JWingData firstConnectedWing2 = result2.GetFirstConnectedWing();
							if (firstConnectedWing != null && firstConnectedWing2 != null && firstConnectedWing != firstConnectedWing2)
							{
								return false;
							}
						}
						List<AttachPointData> attachPoints = part.AttachPoints;
						List<AttachPointData> attachPoints2 = partData.AttachPoints;
						if (attachPoints.Count != attachPoints2.Count)
						{
							return true;
						}
						for (int j = 0; j < attachPoints.Count; j++)
						{
							AttachPointScript attachPointScript = attachPoints[j].AttachPointScript;
							AttachPointScript attachPointScript2 = attachPoints2[j].AttachPointScript;
							if (Utilities.CompareVector3s(attachPointScript.transform.position, attachPointScript2.transform.position, 0.001f))
							{
								if (Utilities.CompareVector3s(attachPointScript.WorldNormal, attachPointScript2.WorldNormal, 0.001f))
								{
									return true;
								}
								return false;
							}
						}
					}
					return true;
				}
				return false;
			}
		}
	}
}
