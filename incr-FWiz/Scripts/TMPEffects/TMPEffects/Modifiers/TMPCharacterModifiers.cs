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
		private Vector3 positionDelta;

		[SerializeField]
		private Matrix4x4 scaleDelta;

		[SerializeField]
		private List<Rotation> rotations;

		[SerializeField]
		private ModifierFlags modifier;

		private ReadOnlyCollection<Rotation> rotationsReadOnly;

		public ModifierFlags Modifier => default(ModifierFlags);

		public Vector3 PositionDelta
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Matrix4x4 ScaleDelta
		{
			get
			{
				return default(Matrix4x4);
			}
			set
			{
			}
		}

		public ReadOnlyCollection<Rotation> Rotations => null;

		public void InsertRotation(int index, Rotation rotation)
		{
		}

		public void AddRotation(Rotation rotation)
		{
		}

		public void RemoveRotation(int index)
		{
		}

		public TMPCharacterModifiers()
		{
		}

		public TMPCharacterModifiers(TMPCharacterModifiers original)
		{
		}

		public void Combine(TMPCharacterModifiers other)
		{
		}

		public void CopyFrom(TMPCharacterModifiers other)
		{
		}

		public void ClearModifiers()
		{
		}

		public void ClearModifiers(ModifierFlags flags)
		{
		}

		private void ClearRotations()
		{
		}

		private void ClearPositionDelta()
		{
		}

		private void ClearScale()
		{
		}
	}
}
