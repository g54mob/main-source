using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public class TMPCharacterModifiers
	{
		[Flags]
		public enum ModifierFlags
		{
			PositionDelta = 2,
			Rotations = 4,
			Scale = 8
		}

		[SerializeField]
		private Vector3 positionDelta = Vector3.zero;

		[SerializeField]
		private Matrix4x4 scaleDelta = Matrix4x4.Scale(Vector3.one);

		[SerializeField]
		private List<Rotation> rotations = new List<Rotation>();

		[SerializeField]
		private ModifierFlags modifier;

		private ReadOnlyCollection<Rotation> rotationsReadOnly;

		public ModifierFlags Modifier => modifier;

		public Vector3 PositionDelta
		{
			get
			{
				return positionDelta;
			}
			set
			{
				positionDelta = value;
				modifier |= ModifierFlags.PositionDelta;
			}
		}

		public Matrix4x4 ScaleDelta
		{
			get
			{
				return scaleDelta;
			}
			set
			{
				scaleDelta = value;
				modifier |= ModifierFlags.Scale;
			}
		}

		public ReadOnlyCollection<Rotation> Rotations
		{
			get
			{
				if (rotationsReadOnly == null)
				{
					rotationsReadOnly = new ReadOnlyCollection<Rotation>(rotations);
				}
				return rotationsReadOnly;
			}
		}

		public void InsertRotation(int index, Rotation rotation)
		{
			rotations.Insert(index, rotation);
			modifier |= ModifierFlags.Rotations;
		}

		public void AddRotation(Rotation rotation)
		{
			if (rotations.Count > 100)
			{
				throw new Exception("Cannot add more than 100 rotations.");
			}
			rotations.Add(rotation);
			modifier |= ModifierFlags.Rotations;
		}

		public void RemoveRotation(int index)
		{
			rotations.RemoveAt(index);
			if (rotations.Count == 0)
			{
				ClearRotations();
			}
		}

		public TMPCharacterModifiers()
		{
		}

		public TMPCharacterModifiers(TMPCharacterModifiers original)
		{
			positionDelta = original.positionDelta;
			scaleDelta = original.scaleDelta;
			rotations = new List<Rotation>(original.rotations);
			modifier = original.Modifier;
		}

		public void Combine(TMPCharacterModifiers other)
		{
			if (other.Modifier.HasFlag(ModifierFlags.PositionDelta))
			{
				positionDelta += other.positionDelta;
			}
			if (other.Modifier.HasFlag(ModifierFlags.Scale))
			{
				scaleDelta *= other.ScaleDelta;
			}
			if (other.Modifier.HasFlag(ModifierFlags.Rotations))
			{
				for (int i = 0; i < other.rotations.Count; i++)
				{
					rotations.Add(other.rotations[i]);
				}
			}
			modifier |= other.Modifier;
		}

		public void CopyFrom(TMPCharacterModifiers other)
		{
			ClearModifiers();
			positionDelta = other.positionDelta;
			scaleDelta = other.ScaleDelta;
			for (int i = 0; i < other.rotations.Count; i++)
			{
				rotations.Add(other.rotations[i]);
			}
			modifier = other.Modifier;
		}

		public void ClearModifiers()
		{
			if (modifier.HasFlag(ModifierFlags.PositionDelta))
			{
				ClearPositionDelta();
			}
			if (modifier.HasFlag(ModifierFlags.Rotations))
			{
				ClearRotations();
			}
			if (modifier.HasFlag(ModifierFlags.Scale))
			{
				ClearScale();
			}
		}

		public void ClearModifiers(ModifierFlags flags)
		{
			ModifierFlags modifierFlags = modifier & flags;
			if (modifierFlags.HasFlag(ModifierFlags.PositionDelta))
			{
				ClearPositionDelta();
			}
			if (modifierFlags.HasFlag(ModifierFlags.Rotations))
			{
				ClearRotations();
			}
			if (modifierFlags.HasFlag(ModifierFlags.Scale))
			{
				ClearScale();
			}
		}

		private void ClearRotations()
		{
			modifier &= ~ModifierFlags.Rotations;
			rotations.Clear();
		}

		private void ClearPositionDelta()
		{
			modifier &= ~ModifierFlags.PositionDelta;
			positionDelta = Vector3.zero;
		}

		private void ClearScale()
		{
			modifier &= ~ModifierFlags.Scale;
			scaleDelta = Matrix4x4.identity;
		}
	}
}
