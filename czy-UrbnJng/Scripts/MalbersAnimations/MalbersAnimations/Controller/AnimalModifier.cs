using System;
using MalbersAnimations.Utilities;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public struct AnimalModifier
	{
		[Flag]
		public modifier modify;

		public bool RootMotion;

		public bool Sprint;

		public bool Gravity;

		public bool Grounded;

		public bool OrientToGround;

		public bool CustomRotation;

		public bool FreeMovement;

		public bool AdditivePosition;

		public bool AdditiveRotation;

		public bool Persistent;

		public bool IgnoreLowerStates;

		public bool LockMovement;

		public bool LockInput;

		public void Modify(MAnimal animal)
		{
			if (modify != 0 && !(animal == null))
			{
				if (Modify(modifier.IgnoreLowerStates))
				{
					animal.ActiveState.IgnoreLowerStates = IgnoreLowerStates;
				}
				if (Modify(modifier.AdditivePositionSpeed))
				{
					animal.UseAdditivePos = AdditivePosition;
				}
				if (Modify(modifier.AdditiveRotationSpeed))
				{
					animal.UseAdditiveRot = AdditiveRotation;
				}
				if (Modify(modifier.RootMotion))
				{
					animal.RootMotion = RootMotion;
				}
				if (Modify(modifier.Gravity))
				{
					animal.UseGravity = Gravity;
				}
				if (Modify(modifier.Sprint))
				{
					animal.UseSprintState = Sprint;
				}
				if (Modify(modifier.Grounded))
				{
					animal.Grounded = Grounded;
				}
				if (Modify(modifier.OrientToGround))
				{
					animal.UseOrientToGround = OrientToGround;
				}
				if (Modify(modifier.CustomRotation))
				{
					animal.UseCustomRotation = CustomRotation;
				}
				if (Modify(modifier.Persistent))
				{
					animal.ActiveState.IsPersistent = Persistent;
				}
				if (Modify(modifier.LockInput))
				{
					animal.LockInput = LockInput;
				}
				if (Modify(modifier.LockMovement))
				{
					animal.LockMovement = LockMovement;
				}
				if (Modify(modifier.FreeMovement))
				{
					animal.FreeMovement = FreeMovement;
				}
			}
		}

		private readonly bool Modify(modifier modifier)
		{
			return (modify & modifier) == modifier;
		}
	}
}
