using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design.Symmetry;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartConnection
	{
		public List<AttachPointData> AttachPointsA { get; private set; }

		public List<AttachPointData> AttachPointsB { get; private set; }

		public bool EnableCollision
		{
			get
			{
				if (!PartA.PartType.CollideConnected)
				{
					return PartB.PartType.CollideConnected;
				}
				return true;
			}
		}

		public bool IsDestroyed { get; private set; }

		public bool IsPhysicsJoint { get; set; }

		public PartData PartA { get; private set; }

		public PartData PartB { get; private set; }

		public PartConnection(PartData partA, PartData partB)
		{
			if (partA == partB)
			{
				throw new Exception("PartConnection: PartA and PartB cannot be the same part.");
			}
			PartA = partA;
			PartB = partB;
			PartA.PartConnections.Add(this);
			PartB.PartConnections.Add(this);
			AttachPointsA = new List<AttachPointData>();
			AttachPointsB = new List<AttachPointData>();
		}

		public void AddAttachPointA(AttachPointData attachPoint)
		{
			attachPoint.PartConnections.Add(this);
			if (attachPoint.RequiresPhysicsJoint)
			{
				IsPhysicsJoint = true;
			}
			AttachPointsA.Add(attachPoint);
		}

		public void AddAttachPointB(AttachPointData attachPoint)
		{
			attachPoint.PartConnections.Add(this);
			if (attachPoint.RequiresPhysicsJoint)
			{
				IsPhysicsJoint = true;
			}
			AttachPointsB.Add(attachPoint);
		}

		public int DestroyConnection(bool isSymmetryOperation, bool destroySymmetricConnections, bool raiseConnectionChangedEvents)
		{
			int num = 0;
			if (destroySymmetricConnections)
			{
				List<PartConnection> value;
				using (CollectionPool<List<PartConnection>, PartConnection>.Get(out value))
				{
					FindExistingSymmetricConnections(value);
					foreach (PartConnection item in value)
					{
						num += item.DestroyConnection(isSymmetryOperation, destroySymmetricConnections: false, raiseConnectionChangedEvents);
					}
				}
			}
			PartA.PartConnections.Remove(this);
			PartB.PartConnections.Remove(this);
			foreach (AttachPointData item2 in AttachPointsA)
			{
				item2.RemoveConnection(this);
			}
			foreach (AttachPointData item3 in AttachPointsB)
			{
				item3.RemoveConnection(this);
			}
			AttachPointsA.Clear();
			AttachPointsB.Clear();
			IsDestroyed = true;
			if (raiseConnectionChangedEvents)
			{
				RaiseConnectionChangedEvents(isSymmetryOperation);
			}
			return ++num;
		}

		public void FindExistingSymmetricConnections(List<PartConnection> symmetricConnections)
		{
			Assembly assembly = PartA.PartScript.Aircraft.Aircraft.Assembly;
			List<PartData> symmetricParts;
			using (assembly.GetOtherSymmetricParts(PartA, out symmetricParts))
			{
				List<PartData> symmetricParts2;
				using (assembly.GetOtherSymmetricParts(PartB, out symmetricParts2))
				{
					if (symmetricParts.Count == 0)
					{
						if (symmetricParts2.Count != 0)
						{
							GetConnectionsToPart(PartA, symmetricParts2, symmetricConnections);
						}
						return;
					}
					if (symmetricParts2.Count == 0)
					{
						GetConnectionsToPart(PartB, symmetricParts, symmetricConnections);
						return;
					}
					foreach (PartData item in symmetricParts)
					{
						foreach (PartConnection partConnection in item.PartConnections)
						{
							PartData otherPart = partConnection.GetOtherPart(item);
							if (symmetricParts2.Contains(otherPart))
							{
								symmetricConnections.Add(partConnection);
							}
						}
					}
				}
			}
			static void GetConnectionsToPart(PartData targetPart, List<PartData> sourceParts, List<PartConnection> connectionsToPart)
			{
				foreach (PartData sourcePart in sourceParts)
				{
					foreach (PartConnection partConnection2 in sourcePart.PartConnections)
					{
						if (partConnection2.GetOtherPart(sourcePart) == targetPart)
						{
							connectionsToPart.Add(partConnection2);
						}
					}
				}
			}
		}

		public XElement GenerateXml()
		{
			string text = string.Empty;
			foreach (AttachPointData item in AttachPointsA)
			{
				text = text + item.Id + ",";
			}
			string text2 = string.Empty;
			foreach (AttachPointData item2 in AttachPointsB)
			{
				text2 = text2 + item2.Id + ",";
			}
			text = text.TrimEnd(',');
			text2 = text2.TrimEnd(',');
			return new XElement("Connection", new XAttribute("partA", PartA.Id), new XAttribute("partB", PartB.Id), new XAttribute("attachPointsA", text), new XAttribute("attachPointsB", text2));
		}

		public AttachPointData GetOtherAttachPoint(AttachPointData ap)
		{
			if (AttachPointsA.Count == 1 && AttachPointsB.Count == 1)
			{
				if (ap == AttachPointsA[0])
				{
					return AttachPointsB[0];
				}
				if (ap == AttachPointsB[0])
				{
					return AttachPointsA[0];
				}
			}
			return null;
		}

		public PartData GetOtherPart(PartData part)
		{
			if (PartA != part)
			{
				return PartA;
			}
			return PartB;
		}

		public void RaiseConnectionChangedEvents(bool isSymmetryOperation)
		{
			if (PartA != null)
			{
				PartA.PartScript.OnPartConnectionChanged(this, isSymmetryOperation);
			}
			if (PartB != null)
			{
				PartB.PartScript.OnPartConnectionChanged(this, isSymmetryOperation);
			}
		}

		public void RebuildSymmetricConnections(SymmetryConfig symmetry)
		{
			if (PartA.SymmetryId == 0 || PartB.SymmetryId == 0)
			{
				return;
			}
			List<(PartData, PartData)> value;
			using (CollectionPool<List<(PartData, PartData)>, (PartData, PartData)>.Get(out value))
			{
				SymmetryUtility.GetSymmetricPairs(PartA, PartB, allowUnlinkedSymmetricParts: false, symmetry, value);
				foreach (var item3 in value)
				{
					PartData item = item3.Item1;
					PartData item2 = item3.Item2;
					bool flag = true;
					int? symmetricPairSliceIndex = SymmetryUtility.GetSymmetricPairSliceIndex(item, item2, PartA, PartB, symmetry);
					if (!symmetricPairSliceIndex.HasValue)
					{
						Debug.LogError($"Unable to rebuild symmetric connections for part id '{PartA.Id}' to part id '{PartB.Id}'. " + $"An error occurred determining the symmetric slice to which part '{item.Id}' and part '{item2.Id}' belong");
						continue;
					}
					foreach (PartConnection partConnection in item.PartConnections)
					{
						if (partConnection.GetOtherPart(item) != item2)
						{
							continue;
						}
						bool flag2 = partConnection.PartA != item;
						bool flag3 = true;
						if (AttachPointsA.Count != partConnection.AttachPointsA.Count || AttachPointsB.Count != partConnection.AttachPointsB.Count)
						{
							flag3 = false;
						}
						else
						{
							for (int i = 0; i < AttachPointsA.Count; i++)
							{
								AttachPointData attachPoint = AttachPointsA[i];
								AttachPointData attachPoint2 = AttachPointsB[i];
								AttachPointData attachPointOther = (flag2 ? partConnection.AttachPointsB[i] : partConnection.AttachPointsA[i]);
								AttachPointData attachPointOther2 = (flag2 ? partConnection.AttachPointsA[i] : partConnection.AttachPointsB[i]);
								if (!SymmetryUtility.IsSymmetricAttachPoint(attachPoint, attachPointOther, symmetricPairSliceIndex.Value, symmetry) || !SymmetryUtility.IsSymmetricAttachPoint(attachPoint2, attachPointOther2, symmetricPairSliceIndex.Value, symmetry))
								{
									flag3 = false;
									break;
								}
							}
						}
						if (!flag3)
						{
							partConnection.DestroyConnection(isSymmetryOperation: true, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
							flag = true;
						}
						else
						{
							flag = false;
						}
						break;
					}
					if (!flag)
					{
						continue;
					}
					for (int j = 0; j < AttachPointsA.Count; j++)
					{
						AttachPointData attachPoint3 = AttachPointsA[j];
						AttachPointData attachPoint4 = AttachPointsB[j];
						AttachPointData attachPointData = SymmetryUtility.FindSymmetricAttachPoint(attachPoint3, item, symmetricPairSliceIndex.Value, symmetry);
						AttachPointData attachPointData2 = SymmetryUtility.FindSymmetricAttachPoint(attachPoint4, item2, symmetricPairSliceIndex.Value, symmetry);
						if (attachPointData == null || attachPointData2 == null)
						{
							Debug.LogError($"Unable to find symmetric attach points for connection between parts '{item.Id}' and '{item2.Id}'.");
						}
						else
						{
							item.PartScript.ConnectToPart(attachPointData.AttachPointScript, attachPointData2.AttachPointScript, isSymmetryOperation: true);
						}
					}
				}
			}
		}
	}
}
