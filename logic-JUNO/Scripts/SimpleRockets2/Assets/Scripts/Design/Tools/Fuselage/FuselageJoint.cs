using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tools.Fuselage
{
	public class FuselageJoint
	{
		public class FuselageInfo
		{
			public bool AnchorConnected { get; internal set; }

			public Transform AnchorPoint { get; set; }

			public AttachPoint AttachPoint
			{
				get
				{
					if (Fuselage.MarkerTop == TargetPoint)
					{
						return Fuselage.AttachPointTop;
					}
					return Fuselage.AttachPointBottom;
				}
			}

			public int CornerIndexOffset { get; set; }

			public bool Flipped { get; internal set; }

			public bool FlipScaleXY { get; internal set; }

			public FuselageScript Fuselage { get; set; }

			public bool IncompatibleRotation { get; internal set; }

			public bool InvertCornerIndexOrder { get; internal set; }

			public Transform TargetPoint { get; set; }

			public Vector2 UndoFrontScale { get; set; }

			public Vector3 UndoOffset { get; set; }

			public Vector3 UndoPosition { get; set; }

			public Vector2 UndoRearScale { get; set; }

			public PartConnection GetLoadPartConnection()
			{
				if (AttachPoint != null)
				{
					foreach (AttachPoint attachPoint in Fuselage.PartScript.Data.AttachPoints)
					{
						if (attachPoint.Tag == AttachPoint.Tag && attachPoint.ConnectionType == AttachPointConnectionType.Normal && attachPoint.PartConnections.Count == 1)
						{
							return attachPoint.PartConnections[0];
						}
					}
				}
				return null;
			}
		}

		public Vector3 AnchorPosition { get; private set; }

		public List<FuselageInfo> Fuselages { get; private set; }

		public PartConnection PartConnection { get; private set; }

		public Vector2 Scale { get; private set; }

		public Transform Transform { get; set; }

		public FuselageJoint()
		{
			Fuselages = new List<FuselageInfo>();
		}

		public void AdaptSecondFuselage(bool updateOppositeSide)
		{
			if (Fuselages.Count != 2)
			{
				return;
			}
			FuselageInfo fuselageInfo = Fuselages[1];
			FuselageData data = fuselageInfo.Fuselage.Data;
			Vector3 deformations = data.Deformations;
			deformations.x = Fuselages[0].Fuselage.Data.Deformations.x;
			deformations.z = Fuselages[0].Fuselage.Data.Deformations.z;
			data.Deformations = deformations;
			float[] cornerRadiuses = GetCornerRadiuses();
			float[] clampAmounts = GetClampAmounts();
			for (int i = 0; i < 4; i++)
			{
				int cornerIndex = GetCornerIndex(fuselageInfo, i, fuselageInfo.Flipped);
				data.CornerRadiuses[cornerIndex] = cornerRadiuses[i];
				data.ClampDistances[cornerIndex] = clampAmounts[i] * (float)((!(fuselageInfo.InvertCornerIndexOrder ^ (fuselageInfo.CornerIndexOffset % 2 == 1))) ? 1 : (-1));
				if (!fuselageInfo.AnchorConnected)
				{
					cornerIndex = GetCornerIndex(fuselageInfo, i, !fuselageInfo.Flipped);
					data.CornerRadiuses[cornerIndex] = cornerRadiuses[i];
					data.ClampDistances[cornerIndex] = clampAmounts[i] * (float)((!(fuselageInfo.InvertCornerIndexOrder ^ (fuselageInfo.CornerIndexOffset % 2 == 1))) ? 1 : (-1));
				}
			}
			Vector2 scale = Scale;
			if (fuselageInfo.FlipScaleXY)
			{
				scale.x = Scale.y;
				scale.y = Scale.x;
			}
			if (!fuselageInfo.AnchorConnected && updateOppositeSide && data.BottomScale == data.TopScale)
			{
				if (data.ToolAutoAdaptBottom)
				{
					data.BottomScale = scale;
				}
				if (data.ToolAutoAdaptTop)
				{
					data.TopScale = scale;
				}
			}
			else if (fuselageInfo.Flipped)
			{
				if (data.ToolAutoAdaptBottom)
				{
					data.BottomScale = scale;
				}
			}
			else if (data.ToolAutoAdaptTop)
			{
				data.TopScale = scale;
			}
		}

		public void AddFuselage(FuselageScript fuselageScript, Transform fuselageMarker)
		{
			bool anchorConnected = false;
			Transform anchorPoint;
			if (fuselageMarker == fuselageScript.MarkerTop)
			{
				anchorPoint = fuselageScript.MarkerBottom;
				if (fuselageScript.AttachPointBottom != null)
				{
					anchorConnected = fuselageScript.AttachPointBottom.NumPartConnections > 0;
				}
			}
			else
			{
				anchorPoint = fuselageScript.MarkerTop;
				if (fuselageScript.AttachPointTop != null)
				{
					anchorConnected = fuselageScript.AttachPointTop.NumPartConnections > 0;
				}
			}
			AddFuselage(fuselageScript, fuselageMarker, anchorPoint, anchorConnected);
		}

		public FuselageScript AddOtherFuselageToJoint(FuselageScript fuselageScript, AttachPoint attachPoint)
		{
			if (attachPoint != null && attachPoint.PartConnections.Count == 1)
			{
				PartConnection partConnection = attachPoint.PartConnections[0];
				FuselageScript modifier = partConnection.GetOtherPart(fuselageScript.PartScript.Data).PartScript.GetModifier<FuselageScript>();
				if (modifier != null && modifier.Data.AutoResize)
				{
					foreach (PartConnection.Attachment attachment in partConnection.Attachments)
					{
						AttachPoint otherAttachPoint = attachment.GetOtherAttachPoint(attachPoint);
						if (otherAttachPoint == modifier.AttachPointTop)
						{
							AddFuselage(modifier, modifier.MarkerTop);
							return modifier;
						}
						if (otherAttachPoint == modifier.AttachPointBottom)
						{
							AddFuselage(modifier, modifier.MarkerBottom);
							return modifier;
						}
					}
				}
			}
			return null;
		}

		public bool ContainsFuselage(FuselageScript fuselage)
		{
			foreach (FuselageInfo fuselage2 in Fuselages)
			{
				if (fuselage2.Fuselage == fuselage)
				{
					return true;
				}
			}
			return false;
		}

		public float[] GetClampAmounts()
		{
			float[] array = new float[4];
			FuselageInfo fuselageInfo = Fuselages[0];
			for (int i = 0; i < 4; i++)
			{
				int cornerIndex = GetCornerIndex(fuselageInfo, i, fuselageInfo.Flipped);
				array[i] = fuselageInfo.Fuselage.Data.ClampDistances[cornerIndex];
			}
			return array;
		}

		public float[] GetCornerRadiuses()
		{
			float[] array = new float[4];
			FuselageInfo fuselageInfo = Fuselages[0];
			for (int i = 0; i < 4; i++)
			{
				int cornerIndex = GetCornerIndex(fuselageInfo, i, fuselageInfo.Flipped);
				array[i] = fuselageInfo.Fuselage.Data.CornerRadiuses[cornerIndex];
			}
			return array;
		}

		public void SetClampAmounts(float[] clampAmounts)
		{
			foreach (FuselageInfo fuselage in Fuselages)
			{
				for (int i = 0; i < 4; i++)
				{
					int cornerIndex = GetCornerIndex(fuselage, i, fuselage.Flipped);
					fuselage.Fuselage.Data.ClampDistances[cornerIndex] = clampAmounts[i] * (float)((!(fuselage.InvertCornerIndexOrder ^ (fuselage.CornerIndexOffset % 2 == 1))) ? 1 : (-1));
				}
				fuselage.Fuselage.UpdateMeshes(updateNormalSmoothing: true);
				Symmetry.SynchronizePartModifiers(fuselage.Fuselage.PartScript);
			}
		}

		public void SetCornerRadiuses(float[] cornerRadiuses)
		{
			foreach (FuselageInfo fuselage in Fuselages)
			{
				for (int i = 0; i < 4; i++)
				{
					int cornerIndex = GetCornerIndex(fuselage, i, fuselage.Flipped);
					fuselage.Fuselage.Data.CornerRadiuses[cornerIndex] = cornerRadiuses[i];
				}
				fuselage.Fuselage.UpdateMeshes(updateNormalSmoothing: true);
				Symmetry.SynchronizePartModifiers(fuselage.Fuselage.PartScript);
			}
		}

		public void SetDimensions(Vector3 position, Vector2 size, bool undoInvalidChanges)
		{
			SetSize(size);
			SetPosition(position, undoInvalidChanges);
		}

		public bool SetFuselagePosition(FuselageInfo fuselage, Vector3 position)
		{
			Vector3 vector = fuselage.Fuselage.transform.InverseTransformPoint(position);
			Vector3 vector2 = fuselage.Fuselage.transform.InverseTransformPoint(fuselage.AnchorPoint.position);
			Vector3 offset = (vector - vector2) * (fuselage.Flipped ? (-0.5f) : 0.5f);
			bool result = fuselage.Fuselage.TryUpdateOffset(offset);
			Vector3 vector3 = fuselage.Fuselage.Data.Offset;
			if (fuselage.Flipped)
			{
				vector3 = -vector3;
			}
			fuselage.Fuselage.transform.position = fuselage.Fuselage.transform.TransformPoint(vector2 + vector3);
			return result;
		}

		public void SetPosition(Vector3 position, bool undoInvalidChanges)
		{
			foreach (FuselageInfo fuselage in Fuselages)
			{
				fuselage.UndoRearScale = fuselage.Fuselage.Data.BottomScale;
				fuselage.UndoFrontScale = fuselage.Fuselage.Data.TopScale;
				fuselage.UndoPosition = fuselage.Fuselage.transform.position;
				fuselage.UndoOffset = fuselage.Fuselage.Data.Offset;
			}
			bool flag = false;
			foreach (FuselageInfo fuselage2 in Fuselages)
			{
				if (SetFuselagePosition(fuselage2, position))
				{
					fuselage2.Fuselage.UpdateMeshes(updateNormalSmoothing: true);
					continue;
				}
				flag = true;
				break;
			}
			if (!(flag && undoInvalidChanges))
			{
				return;
			}
			foreach (FuselageInfo fuselage3 in Fuselages)
			{
				fuselage3.Fuselage.Data.BottomScale = fuselage3.UndoRearScale;
				fuselage3.Fuselage.Data.TopScale = fuselage3.UndoFrontScale;
				fuselage3.Fuselage.Data.Offset = fuselage3.UndoOffset;
				fuselage3.Fuselage.PartScript.Transform.position = fuselage3.UndoPosition;
				fuselage3.Fuselage.UpdateMeshes(updateNormalSmoothing: true);
			}
		}

		public void SetSize(Vector2 size)
		{
			Scale = size;
			Vector2 size2 = size;
			foreach (FuselageInfo fuselage in Fuselages)
			{
				Vector2 scale = size;
				if (fuselage.FlipScaleXY)
				{
					scale.x = size.y;
					scale.y = size.x;
				}
				Vector2 vector = fuselage.Fuselage.TryUpdateScale(scale, !fuselage.Flipped);
				if (size2.magnitude < vector.magnitude)
				{
					size2 = vector;
				}
			}
			if (size2.magnitude > size.magnitude)
			{
				SetSize(size2);
			}
		}

		public void UpdateAttachedParts(bool checkForBrokenConnections, bool updateSymmetry)
		{
			List<IPartScript> list = new List<IPartScript>();
			foreach (FuselageInfo fuselage in Fuselages)
			{
				foreach (AttachPointScript attachPointScript2 in fuselage.Fuselage.PartScript.AttachPointScripts)
				{
					if (attachPointScript2.transform != fuselage.TargetPoint)
					{
						if (!checkForBrokenConnections)
						{
							continue;
						}
						int num = 0;
						while (num < attachPointScript2.AttachPoint.PartConnections.Count)
						{
							PartConnection partConnection = attachPointScript2.AttachPoint.PartConnections[num];
							bool flag = false;
							foreach (PartConnection.Attachment attachment in partConnection.Attachments)
							{
								AttachPoint otherAttachPoint = attachment.GetOtherAttachPoint(attachPointScript2.AttachPoint);
								if (otherAttachPoint != null)
								{
									flag = CheckIfAttachPointsStillConnected(attachPointScript2.AttachPoint, otherAttachPoint);
								}
							}
							if (!flag)
							{
								Debug.Log("Broke Connection");
								partConnection.DestroyConnection();
								Symmetry.RemovePartConnection(fuselage.Fuselage.PartScript, partConnection);
							}
							else
							{
								num++;
							}
						}
					}
					else
					{
						if (Fuselages.Count != 1 || attachPointScript2.AttachPoint.PartConnections.Count != 1)
						{
							continue;
						}
						PartConnection partConnection2 = attachPointScript2.AttachPoint.PartConnections[0];
						if (partConnection2.Attachments.Count <= 0)
						{
							continue;
						}
						AttachPointScript attachPointScript = partConnection2.Attachments[0].GetOtherAttachPoint(attachPointScript2.AttachPoint).AttachPointScript;
						Vector3 vector = attachPointScript2.transform.position - attachPointScript.transform.position;
						foreach (PartData part in new PartGraph(attachPointScript.PartScript.Data, fuselage.Fuselage.PartScript.Data).Parts)
						{
							part.PartScript.Transform.position += vector;
							list.Add(part.PartScript);
						}
					}
				}
			}
			if (!updateSymmetry)
			{
				return;
			}
			foreach (FuselageInfo fuselage2 in Fuselages)
			{
				list.Add(fuselage2.Fuselage.PartScript);
			}
			Symmetry.UpdatePartPositions(list);
		}

		public void UpdateMeshes()
		{
			foreach (FuselageInfo fuselage in Fuselages)
			{
				fuselage.Fuselage.UpdateMeshes(updateNormalSmoothing: true);
			}
		}

		private static bool CheckIfAttachPointsStillConnected(AttachPoint ap1, AttachPoint ap2)
		{
			GameObject gameObject;
			GameObject gameObject2;
			if (ap1.IsSurfaceAttachPoint)
			{
				gameObject = ap1.AttachPointScript.gameObject;
				gameObject2 = ap2.AttachPointScript.gameObject;
			}
			else
			{
				gameObject = ap2.AttachPointScript.gameObject;
				gameObject2 = ap1.AttachPointScript.gameObject;
			}
			int layer = gameObject.layer;
			gameObject.layer = 2;
			float radius = 0.0625f;
			bool result = Physics.CheckSphere(gameObject2.transform.position, radius, 4);
			gameObject.layer = layer;
			return result;
		}

		private static int GetCornerIndex(FuselageInfo fuselageInfo, int globalCornerIndex, bool flipped)
		{
			int num = globalCornerIndex;
			num = ((!fuselageInfo.InvertCornerIndexOrder) ? (num - fuselageInfo.CornerIndexOffset) : (3 - (num - fuselageInfo.CornerIndexOffset)));
			if (num >= 4)
			{
				num -= 4;
			}
			else if (num < 0)
			{
				num += 4;
			}
			if (flipped)
			{
				num += 4;
			}
			return num;
		}

		private void AddFuselage(FuselageScript fuselage, Transform targetPoint, Transform anchorPoint, bool anchorConnected)
		{
			FuselageInfo fuselageInfo = new FuselageInfo();
			fuselageInfo.Fuselage = fuselage;
			fuselageInfo.TargetPoint = targetPoint;
			fuselageInfo.AnchorPoint = anchorPoint;
			fuselageInfo.AnchorConnected = anchorConnected;
			Vector3 vector = fuselage.transform.InverseTransformPoint(targetPoint.position);
			Vector3 vector2 = fuselage.transform.InverseTransformPoint(anchorPoint.position);
			if ((vector - vector2).y < 0f)
			{
				fuselageInfo.Flipped = true;
			}
			if (Transform == null)
			{
				Transform = targetPoint;
				AnchorPosition = anchorPoint.position;
				Scale = (fuselageInfo.Flipped ? fuselage.Data.BottomScale : fuselage.Data.TopScale);
			}
			if (Fuselages.Count == 1)
			{
				if (Fuselages[0].Flipped == fuselageInfo.Flipped)
				{
					fuselageInfo.InvertCornerIndexOrder = true;
				}
				Vector3 vector3 = Fuselages[0].Fuselage.transform.InverseTransformDirection(fuselage.transform.forward);
				if (fuselageInfo.InvertCornerIndexOrder)
				{
					if (Utilities.CompareFloats(vector3.z, 1f, 0.2f))
					{
						fuselageInfo.CornerIndexOffset = 2;
					}
					else if (Utilities.CompareFloats(vector3.z, -1f, 0.2f))
					{
						fuselageInfo.CornerIndexOffset = 0;
					}
					else if (Utilities.CompareFloats(vector3.x, 1f, 0.2f))
					{
						fuselageInfo.CornerIndexOffset = 3;
						fuselageInfo.FlipScaleXY = true;
					}
					else if (Utilities.CompareFloats(vector3.x, -1f, 0.2f))
					{
						fuselageInfo.CornerIndexOffset = 1;
						fuselageInfo.FlipScaleXY = true;
					}
					else
					{
						fuselageInfo.IncompatibleRotation = true;
					}
				}
				else if (Utilities.CompareFloats(vector3.z, 1f, 0.2f))
				{
					fuselageInfo.CornerIndexOffset = 0;
				}
				else if (Utilities.CompareFloats(vector3.z, -1f, 0.2f))
				{
					fuselageInfo.CornerIndexOffset = 2;
				}
				else if (Utilities.CompareFloats(vector3.x, 1f, 0.2f))
				{
					fuselageInfo.CornerIndexOffset = 1;
					fuselageInfo.FlipScaleXY = true;
				}
				else if (Utilities.CompareFloats(vector3.x, -1f, 0.2f))
				{
					fuselageInfo.CornerIndexOffset = 3;
					fuselageInfo.FlipScaleXY = true;
				}
				else
				{
					fuselageInfo.IncompatibleRotation = true;
				}
			}
			Fuselages.Add(fuselageInfo);
		}
	}
}
