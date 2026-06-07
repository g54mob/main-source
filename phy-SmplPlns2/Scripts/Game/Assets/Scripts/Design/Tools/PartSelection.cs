using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class PartSelection
	{
		public class PartLimb
		{
			public PartScript BasePart { get; }

			public List<PartConnection> BoundaryConnections { get; private set; } = new List<PartConnection>();

			public List<PartScript> Parts { get; private set; } = new List<PartScript>();

			public PartLimb(PartScript basePart)
			{
				BasePart = basePart;
			}
		}

		private PartCollisionDetector _collisionDetector;

		private bool _showAttachPoints;

		public ICollection<AttachPointScript> AllAttachPoints { get; set; }

		public ICollection<AttachPointScript> AvailableAttachPoints { get; set; }

		public int ConnectionMask { get; }

		public bool IsSeekExclusivelyPowertrain
		{
			get
			{
				int num = 176;
				if (ConnectionMask != 0)
				{
					return (ConnectionMask & ~num) == 0;
				}
				return false;
			}
		}

		public Transform ContainerParent { get; set; }

		public PartCollisionDetector PartCollisionDetector => _collisionDetector;

		public List<PartScript> Parts { get; set; }

		public bool PartsColliding { get; set; }

		public PartSelection(ICollection<PartScript> partScripts, Vector3 containerPosition, Quaternion containerRotation, bool showAttachPoints = true)
		{
			Transform transform = new GameObject("MovingParts").transform;
			transform.SetPositionAndRotation(containerPosition, containerRotation);
			transform.localScale = new Vector3(1f, 1f, 1f);
			_collisionDetector = new PartCollisionDetector();
			AllAttachPoints = new List<AttachPointScript>();
			AvailableAttachPoints = new List<AttachPointScript>();
			Parts = new List<PartScript>();
			foreach (PartScript partScript in partScripts)
			{
				Parts.Add(partScript);
				partScript.transform.parent = transform;
				_collisionDetector.AddPartSelection(partScript);
				foreach (AttachPointData attachPoint in partScript.Part.AttachPoints)
				{
					AllAttachPoints.Add(attachPoint.AttachPointScript);
					if (attachPoint.IsAvailable)
					{
						AvailableAttachPoints.Add(attachPoint.AttachPointScript);
					}
				}
			}
			_showAttachPoints = showAttachPoints;
			if (_showAttachPoints)
			{
				foreach (AttachPointScript availableAttachPoint in AvailableAttachPoints)
				{
					if (availableAttachPoint.AttachPoint.DisplayWhenDragged && availableAttachPoint.AttachPoint.IsAvailable && availableAttachPoint.AttachPoint.SeekType != AttachPointConnectionType.None)
					{
						availableAttachPoint.ShowGizmo(show: true);
					}
				}
			}
			foreach (AttachPointScript allAttachPoint in AllAttachPoints)
			{
				ConnectionMask |= (int)allAttachPoint.AttachPoint.SeekType;
			}
			ContainerParent = transform;
			PartsColliding = false;
		}

		public static PartSelection CreatePartSelection(PartScript basePart, bool preserveConnections, Quaternion? containerRotation = null, Vector3? containerPosition = null, bool selectSinglePart = false, bool showAttachPoints = true)
		{
			ICollection<PartScript> collection = null;
			if (selectSinglePart)
			{
				collection = new List<PartScript>();
				List<PartConnection> list = new List<PartConnection>();
				if (basePart.Part.GroupId.HasValue)
				{
					WeldedPartGroup weldedPartGroup = new WeldedPartGroup(basePart.Part);
					list.AddRange(weldedPartGroup.BoundaryConnections);
					foreach (PartData part in weldedPartGroup.Parts)
					{
						collection.Add(part.PartScript);
					}
				}
				else
				{
					collection.Add(basePart);
					list.AddRange(basePart.Part.PartConnections);
				}
				if (basePart.Part.GetModifier<JWingData>() != null)
				{
					foreach (PartConnection partConnection in basePart.Part.PartConnections)
					{
						PartData otherPart = partConnection.GetOtherPart(basePart.Part);
						if (otherPart.GetModifier<ControlSurfacePartData>() != null && !collection.Contains(otherPart.PartScript))
						{
							collection.Add(otherPart.PartScript);
							list.Remove(partConnection);
						}
					}
				}
				if (!preserveConnections)
				{
					foreach (PartConnection item in list)
					{
						item.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: true, raiseConnectionChangedEvents: true);
					}
				}
			}
			else
			{
				collection = FindPartsToMove(basePart, preserveConnections).Parts;
			}
			Quaternion containerRotation2 = ((!containerRotation.HasValue) ? basePart.transform.rotation : containerRotation.Value);
			Vector3 containerPosition2 = ((!containerPosition.HasValue) ? basePart.transform.position : containerPosition.Value);
			return new PartSelection(collection, containerPosition2, containerRotation2, showAttachPoints);
		}

		public static PartSelection CreateSymmetricPartSelection(IList<PartData> symmetricParts, Vector3 containerPosition, Quaternion containerRotation, bool selectSinglePart, bool preserveConnections, bool showAttachPoints)
		{
			if (symmetricParts == null || symmetricParts.Count == 0)
			{
				return new PartSelection(Array.Empty<PartScript>(), containerPosition, containerRotation, showAttachPoints: false);
			}
			List<PartScript> value;
			if (selectSinglePart)
			{
				using (CollectionPool<List<PartScript>, PartScript>.Get(out value))
				{
					foreach (PartData symmetricPart in symmetricParts)
					{
						value.Add(symmetricPart.PartScript);
					}
					List<PartConnection> value2;
					using (CollectionPool<List<PartConnection>, PartConnection>.Get(out value2))
					{
						if (symmetricParts[0].GetModifier<JWingData>() != null)
						{
							foreach (PartConnection partConnection2 in symmetricParts[0].PartConnections)
							{
								PartData otherPart = partConnection2.GetOtherPart(symmetricParts[0]);
								if (otherPart.GetModifier<ControlSurfacePartData>() != null)
								{
									if (!value.Contains(otherPart.PartScript))
									{
										value.Add(otherPart.PartScript);
									}
									value2.Add(partConnection2);
								}
							}
						}
						if (!preserveConnections)
						{
							List<PartConnection> value3;
							using (CollectionPool<List<PartConnection>, PartConnection>.Get(out value3))
							{
								foreach (PartData symmetricPart2 in symmetricParts)
								{
									foreach (PartConnection partConnection3 in symmetricPart2.PartConnections)
									{
										if (!value2.Contains(partConnection3))
										{
											value3.Add(partConnection3);
										}
									}
								}
								foreach (PartConnection item in value3)
								{
									item.DestroyConnection(isSymmetryOperation: true, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
								}
							}
						}
						return new PartSelection(value, containerPosition, containerRotation, showAttachPoints);
					}
				}
			}
			Queue<PartData> value4;
			using (QueuePool<PartData>.Get(out value4))
			{
				HashSet<int> value5;
				using (CollectionPool<HashSet<int>, int>.Get(out value5))
				{
					List<PartScript> value6;
					using (CollectionPool<List<PartScript>, PartScript>.Get(out value6))
					{
						List<PartData> value7;
						using (CollectionPool<List<PartData>, PartData>.Get(out value7))
						{
							HashSet<int> value8;
							using (CollectionPool<HashSet<int>, int>.Get(out value8))
							{
								HashSet<PartConnection> value9;
								using (CollectionPool<HashSet<PartConnection>, PartConnection>.Get(out value9))
								{
									foreach (PartData symmetricPart3 in symmetricParts)
									{
										value8.Add(symmetricPart3.Id);
									}
									value4.EnqueueRange(symmetricParts);
									value5.AddRange(value8);
									while (value4.Count > 0)
									{
										PartData partData = value4.Dequeue();
										if ((partData.SymmetryId == 0 && !partData.IsCockpit) || value8.Contains(partData.Id))
										{
											value6.Add(partData.PartScript);
											foreach (PartConnection partConnection4 in partData.PartConnections)
											{
												PartData otherPart2 = partConnection4.GetOtherPart(partData);
												if (value5.Add(otherPart2.Id))
												{
													value4.Enqueue(otherPart2);
												}
											}
										}
										else
										{
											value7.Add(partData);
										}
									}
									if (value7.Count == 0)
									{
										return new PartSelection(value6, containerPosition, containerRotation, showAttachPoints: false);
									}
									value4.Clear();
									value5.Clear();
									value4.EnqueueRange(value7);
									value5.AddRange(value8);
									while (value4.Count > 0)
									{
										PartData partData2 = value4.Dequeue();
										List<PartConnection> partConnections = partData2.PartConnections;
										for (int num = partConnections.Count - 1; num >= 0; num--)
										{
											PartConnection partConnection = partConnections[num];
											PartData otherPart3 = partConnection.GetOtherPart(partData2);
											if (value8.Contains(otherPart3.Id))
											{
												if (preserveConnections)
												{
													value9.Add(partConnection);
												}
												else
												{
													partConnection.DestroyConnection(isSymmetryOperation: true, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
												}
											}
											else if (value5.Add(otherPart3.Id))
											{
												value4.Enqueue(otherPart3);
											}
										}
									}
									value4.Clear();
									value5.Clear();
									value6.Clear();
									value4.EnqueueRange(symmetricParts);
									value5.AddRange(value8);
									while (value4.Count > 0)
									{
										PartData partData3 = value4.Dequeue();
										value6.Add(partData3.PartScript);
										foreach (PartConnection partConnection5 in partData3.PartConnections)
										{
											if (value9.Count <= 0 || !value9.Contains(partConnection5))
											{
												PartData otherPart4 = partConnection5.GetOtherPart(partData3);
												if (value5.Add(otherPart4.Id))
												{
													value4.Enqueue(otherPart4);
												}
											}
										}
									}
									return new PartSelection(value6, containerPosition, containerRotation, showAttachPoints: false);
								}
							}
						}
					}
				}
			}
		}

		public static PartLimb FindPartLimb(PartScript basePart, bool onlyIncludeGroupedParts = false)
		{
			if (basePart.Part.GroupId.HasValue)
			{
				return FindPartLimbFromWeldedPartGroup(new WeldedPartGroup(basePart.Part), onlyIncludeGroupedParts);
			}
			PartLimb partLimb = new PartLimb(basePart);
			Queue<PartData> value;
			using (QueuePool<PartData>.Get(out value))
			{
				HashSet<int> value2;
				using (CollectionPool<HashSet<int>, int>.Get(out value2))
				{
					List<PartConnection> value3;
					using (CollectionPool<List<PartConnection>, PartConnection>.Get(out value3))
					{
						foreach (PartConnection partConnection in basePart.Part.PartConnections)
						{
							PartData otherPart = partConnection.GetOtherPart(basePart.Part);
							if (basePart.Part.SymmetryId != 0 && basePart.Part.SymmetryId == otherPart.SymmetryId)
							{
								partLimb.BoundaryConnections.Add(partConnection);
								continue;
							}
							value.Clear();
							value2.Clear();
							value3.Clear();
							value2.Add(basePart.Part.Id);
							value2.Add(otherPart.Id);
							value.Enqueue(otherPart);
							while (value.Count > 0)
							{
								PartData partData = value.Dequeue();
								if (partData.IsCockpit)
								{
									value3.Clear();
									value3.Add(partConnection);
									break;
								}
								foreach (PartConnection partConnection2 in partData.PartConnections)
								{
									PartData otherPart2 = partConnection2.GetOtherPart(partData);
									if (value2.Add(otherPart2.Id))
									{
										if (partData.SymmetryId != 0 && partData.SymmetryId == otherPart2.SymmetryId)
										{
											value3.Add(partConnection2);
										}
										else
										{
											value.Enqueue(otherPart2);
										}
									}
								}
							}
							partLimb.BoundaryConnections.AddRange(value3);
						}
						foreach (PartData part in new PartGraph(basePart.Part, partLimb.BoundaryConnections).Parts)
						{
							partLimb.Parts.Add(part.PartScript);
						}
						return partLimb;
					}
				}
			}
		}

		public static PartLimb FindPartLimbFromWeldedPartGroup(WeldedPartGroup group, bool onlyIncludeGroupedParts)
		{
			PartLimb partLimb = new PartLimb(group.BasePart.PartScript);
			PartLookup partLookup = new PartLookup();
			foreach (PartData boundaryPart in group.BoundaryParts)
			{
				PartGraph partGraph = new PartGraph(boundaryPart, group.BoundaryConnections);
				if (partGraph.HasCockpit)
				{
					foreach (PartConnection partConnection in boundaryPart.PartConnections)
					{
						PartData otherPart = partConnection.GetOtherPart(boundaryPart);
						Guid? groupId = otherPart.GroupId;
						Guid groupId2 = group.GroupId;
						if (groupId.HasValue && (!groupId.HasValue || groupId.GetValueOrDefault() == groupId2) && group.Parts.Contains(otherPart))
						{
							partLimb.BoundaryConnections.Add(partConnection);
						}
					}
				}
				else
				{
					if (onlyIncludeGroupedParts)
					{
						continue;
					}
					foreach (PartData part in partGraph.Parts)
					{
						partLookup.AddPart(part);
					}
				}
			}
			foreach (PartData part2 in group.Parts)
			{
				partLookup.AddPart(part2);
			}
			foreach (PartData part3 in partLookup.Parts)
			{
				partLimb.Parts.Add(part3.PartScript);
			}
			return partLimb;
		}

		public void Deselect()
		{
			if (_showAttachPoints)
			{
				foreach (AttachPointScript availableAttachPoint in AvailableAttachPoints)
				{
					if (availableAttachPoint.AttachPoint.DisplayWhenDragged)
					{
						availableAttachPoint.ShowGizmo(show: false);
					}
				}
			}
			for (int num = ContainerParent.childCount - 1; num >= 0; num--)
			{
				Transform child = ContainerParent.GetChild(num);
				child.parent = Designer.Instance.Aircraft.Children;
				if (child.TryGetComponent<PartScript>(out var component))
				{
					IReadOnlyList<ICraftDecal> decals = component.Part.Decals;
					for (int i = 0; i < decals.Count; i++)
					{
						decals[i].SetDirty();
					}
					component.IsDragging = false;
				}
			}
			ContainerParent.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(ContainerParent.gameObject);
		}

		public bool DetectCollisions()
		{
			return _collisionDetector.DetectCollisions(updateMaterials: false);
		}

		public bool IsWingAndControlSurfaces()
		{
			JWingScript jWingScript = Parts.FirstOrDefault()?.GetModifier<JWingScript>();
			if (jWingScript != null)
			{
				for (int i = 1; i < Parts.Count; i++)
				{
					ControlSurfacePartScript modifier = Parts[i].GetModifier<ControlSurfacePartScript>();
					if (modifier == null || modifier.ConnectedWing != jWingScript)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		private static PartLimb FindPartsToMove(PartScript selectedPart, bool preserveConnections)
		{
			PartLimb partLimb = FindPartLimb(selectedPart);
			if (!preserveConnections)
			{
				foreach (PartConnection boundaryConnection in partLimb.BoundaryConnections)
				{
					boundaryConnection.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: true, raiseConnectionChangedEvents: true);
				}
			}
			return partLimb;
		}
	}
}
