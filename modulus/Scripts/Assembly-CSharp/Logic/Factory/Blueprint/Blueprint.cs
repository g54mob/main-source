using System.Collections.Generic;
using System.Linq;
using SaveData.FactoryFloor;
using UnityEngine;
using Utils;

namespace Logic.Factory.Blueprint
{
	public class Blueprint
	{
		public Vector3Int Position { get; private set; }

		public int Rotation { get; private set; }

		public Vector3Int Bounds { get; private set; }

		public Vector3 MiddleOffset { get; private set; }

		public List<Vector3Int> CranePositions { get; private set; } = new List<Vector3Int>();

		public List<BlueprintElement> Elements { get; private set; } = new List<BlueprintElement>();

		public Blueprint(Vector3Int position, int rotation, List<BlueprintElement> blueprintElements)
		{
			Position = position;
			Rotation = rotation;
			Elements = blueprintElements;
			CalculateBounds();
		}

		public Blueprint(Vector3Int position, int rotation, List<BlueprintElement> blueprintElements, List<Vector3Int> cranePositions)
		{
			Position = position;
			Rotation = rotation;
			Elements = blueprintElements;
			CranePositions = cranePositions;
			CalculateBounds();
		}

		private void CalculateBounds()
		{
			Vector3 vector = new Vector3Int(int.MaxValue, int.MaxValue, int.MaxValue);
			Vector3 vector2 = -new Vector3Int(int.MinValue, int.MinValue, int.MinValue);
			foreach (BlueprintElement element in Elements)
			{
				foreach (Vector3Int relativePosition in element.RelativePositions)
				{
					vector = Vector3.Min(relativePosition, vector);
					vector2 = Vector3.Max(relativePosition, vector2);
				}
			}
			Vector3 vector3 = Position + vector + (vector2 - vector) * 0.5f;
			MiddleOffset = -(vector3 - Position);
			vector2 += (Vector3)Vector3Int.one;
			Bounds = new Vector3Int(Mathf.RoundToInt(vector2.x - vector.x), Mathf.RoundToInt(vector2.y - vector.y), Mathf.RoundToInt(vector2.z - vector.z));
		}

		public void Rotate(int degrees)
		{
			Rotation += degrees;
			Rotation = ClampAngle(Rotation);
			foreach (BlueprintElement element in Elements)
			{
				for (int i = 0; i < element.RelativePositions.Count; i++)
				{
					Vector3Int point = element.RelativePositions[i];
					element.RelativePositions[i] = GridUtils.RotatePoint(point, degrees);
				}
				if (element.IsSoftLinked)
				{
					element.SoftLinkedToRelativePositions = GridUtils.RotatePoints(element.SoftLinkedToRelativePositions, degrees);
				}
				if (element.IsHardLinked)
				{
					element.HardLinkedToRelativePositions = GridUtils.RotatePoints(element.HardLinkedToRelativePositions, degrees);
				}
			}
			CalculateBounds();
		}

		public void SetRotation(int degrees)
		{
			Rotation = degrees;
		}

		public void SetPosition(Vector3Int position)
		{
			Position = position;
		}

		public void Mirror()
		{
			if (Elements.Count == 1)
			{
				MirrorSingleObject();
			}
			else
			{
				MirrorSelection();
			}
		}

		private void MirrorSelection()
		{
			foreach (BlueprintElement element in Elements)
			{
				MirrorRelativePositions(element);
				MirrorSoftLinkedRelativePositions(element);
				MirrorHardLinkedRelativePositions(element);
				int num = element.Rotation % 360;
				if (num == 90 || num == 270)
				{
					element.Rotation = (element.Rotation + 180) % 360;
				}
				if (element.ObjectData.CanBeMirrored)
				{
					element.Mirrored = !element.Mirrored;
				}
			}
			CalculateBounds();
		}

		private void MirrorSingleObject()
		{
			BlueprintElement blueprintElement = Elements[0];
			if (blueprintElement.ObjectData.CanBeMirrored)
			{
				MirrorRelativePositions(blueprintElement, singleObject: true);
				MirrorSoftLinkedRelativePositions(blueprintElement, singleObject: true);
				MirrorHardLinkedRelativePositions(blueprintElement, singleObject: true);
				blueprintElement.Mirrored = !blueprintElement.Mirrored;
				CalculateBounds();
			}
		}

		private void MirrorHardLinkedRelativePositions(BlueprintElement element, bool singleObject = false)
		{
			if (!element.IsHardLinked)
			{
				return;
			}
			for (int i = 0; i < element.HardLinkedToRelativePositions.Count; i++)
			{
				int num = (singleObject ? (Rotation + element.Rotation) : Rotation);
				if (num % 360 == 90 || num % 360 == 270)
				{
					element.HardLinkedToRelativePositions[i] = new Vector3Int(element.HardLinkedToRelativePositions[i].x, element.HardLinkedToRelativePositions[i].y, -element.HardLinkedToRelativePositions[i].z);
				}
				else
				{
					element.HardLinkedToRelativePositions[i] = new Vector3Int(-element.HardLinkedToRelativePositions[i].x, element.HardLinkedToRelativePositions[i].y, element.HardLinkedToRelativePositions[i].z);
				}
			}
			CalculateBounds();
		}

		private void MirrorSoftLinkedRelativePositions(BlueprintElement element, bool singleObject = false)
		{
			if (!element.IsSoftLinked)
			{
				return;
			}
			for (int i = 0; i < element.SoftLinkedToRelativePositions.Count; i++)
			{
				int num = (singleObject ? (Rotation + element.Rotation) : Rotation);
				if (num % 360 == 90 || num % 360 == 270)
				{
					element.SoftLinkedToRelativePositions[i] = new Vector3Int(element.SoftLinkedToRelativePositions[i].x, element.SoftLinkedToRelativePositions[i].y, -element.SoftLinkedToRelativePositions[i].z);
				}
				else
				{
					element.SoftLinkedToRelativePositions[i] = new Vector3Int(-element.SoftLinkedToRelativePositions[i].x, element.SoftLinkedToRelativePositions[i].y, element.SoftLinkedToRelativePositions[i].z);
				}
			}
			CalculateBounds();
		}

		private void MirrorRelativePositions(BlueprintElement element, bool singleObject = false)
		{
			for (int i = 0; i < element.RelativePositions.Count; i++)
			{
				int num = (singleObject ? (Rotation + element.Rotation) : Rotation);
				if (num % 360 == 90 || num % 360 == 270)
				{
					element.RelativePositions[i] = new Vector3Int(element.RelativePositions[i].x, element.RelativePositions[i].y, -element.RelativePositions[i].z);
				}
				else
				{
					element.RelativePositions[i] = new Vector3Int(-element.RelativePositions[i].x, element.RelativePositions[i].y, element.RelativePositions[i].z);
				}
			}
			CalculateBounds();
		}

		public int ClampAngle(int angle)
		{
			angle %= 360;
			if (angle < 0)
			{
				angle += 360;
			}
			return angle;
		}

		public Blueprint GetCopy()
		{
			return new Blueprint(Position, Rotation, GetCopyOfElements());
		}

		private List<BlueprintElement> GetCopyOfElements()
		{
			List<BlueprintElement> list = new List<BlueprintElement>(Elements.Count);
			foreach (BlueprintElement element in Elements)
			{
				list.Add(new BlueprintElement(GetCopyOfRelativePositions(element.RelativePositions), element.ObjectData, element.Rotation, element.Mirrored, element.IsSoftLinked, element.IsHardLinked, element.SoftLinkedToRelativePositions, element.HardLinkedToRelativePositions, GetCopyOfConfigurations(element.Configurations), element.CreatedId));
			}
			return list;
		}

		private List<BehaviourConfigurationDto> GetCopyOfConfigurations(List<BehaviourConfigurationDto> configurations)
		{
			if (configurations == null)
			{
				return null;
			}
			List<BehaviourConfigurationDto> list = new List<BehaviourConfigurationDto>();
			foreach (BehaviourConfigurationDto configuration in configurations)
			{
				list.Add(configuration.CopyOf());
			}
			return list;
		}

		private List<Vector3Int> GetCopyOfRelativePositions(List<Vector3Int> elementRelativePositions)
		{
			return elementRelativePositions.Select((Vector3Int x) => x).ToList();
		}

		public void SetElements(List<BlueprintElement> elements)
		{
			Elements = elements;
		}
	}
}
