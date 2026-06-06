using System;
using System.Collections;
using MalbersAnimations.Controller;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/Add Force to Animal", 0)]
	public class ForceReaction : MReaction
	{
		public enum DirectionType
		{
			Local = 0,
			World = 1,
			TargetPush = 2,
			TargetPull = 3
		}

		[Tooltip("Direction mode to be applied the force on the Animal. World, or Local")]
		public DirectionType Mode;

		[Tooltip("Use a Target when the Mode is set to FromTarget or To Target")]
		[Hide("Mode", false, new int[] { 3, 2 })]
		public TransformReference m_Value;

		[Hide("Mode", true, new int[] { 3, 2 })]
		[Tooltip("Relative Direction of the Force to apply")]
		public Vector3Reference Direction = new Vector3Reference(Vector3.forward);

		[Tooltip("Time to Apply the force")]
		public FloatReference time = new FloatReference(1f);

		[Tooltip("Amount of force to apply")]
		public FloatReference force = new FloatReference(10f);

		[Tooltip("Aceleration to apply to the force")]
		public FloatReference Aceleration = new FloatReference(2f);

		[Tooltip("Drag to Decrease the Force after the Force time has pass")]
		public FloatReference ExitDrag = new FloatReference(2f);

		[Tooltip("Set if the Animal is grounded when adding a force")]
		public BoolReference ResetGravity = new BoolReference(value: false);

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			if (mAnimal.enabled && mAnimal.gameObject.activeInHierarchy)
			{
				mAnimal.StartCoroutine(IForceC(mAnimal));
				return true;
			}
			return false;
		}

		private IEnumerator IForceC(MAnimal animal)
		{
			Vector3 direction = Mode switch
			{
				DirectionType.Local => animal.transform.InverseTransformDirection(Direction), 
				DirectionType.World => Direction, 
				DirectionType.TargetPush => animal.transform.position - m_Value.position, 
				DirectionType.TargetPull => m_Value.position - animal.transform.position, 
				_ => Direction, 
			};
			direction.Normalize();
			animal.Force_Add(direction, force, Aceleration, ResetGravity);
			yield return new WaitForSeconds(time);
			animal.Force_Remove(ExitDrag);
		}
	}
}
