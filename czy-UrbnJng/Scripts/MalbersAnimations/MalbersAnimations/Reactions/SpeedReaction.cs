using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/Speeds", 0)]
	public class SpeedReaction : MReaction
	{
		public enum Speed_Reaction
		{
			Activate = 0,
			Increase = 1,
			Decrease = 2,
			LockCurrentSpeed = 3,
			LockSpeed = 4,
			TopSpeed = 5,
			AnimationSpeed = 6,
			GlobalAnimatorSpeed = 7,
			SetRandomSpeed = 8,
			Sprint = 9
		}

		public Speed_Reaction type;

		[Hide("type", new int[] { 0, 4, 5, 6, 8 })]
		[Tooltip("Speed Set on the Animal to make the changes (E.g. 'Ground' 'Fly')")]
		public string SpeedSet = "Ground";

		[Hide("type", new int[] { 0, 4, 3, 5, 6 })]
		[Tooltip("Index of the Speed Set on the Animal to make the changes (E.g. 'Walk-1' 'Trot-2', 'Run-3')")]
		public int Index = 1;

		[Hide("type", new int[] { 4, 3, 9 })]
		public bool Value = true;

		[Hide("type", new int[] { 6 })]
		public float animatorSpeed = 1f;

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			switch (type)
			{
			case Speed_Reaction.LockCurrentSpeed:
				mAnimal.Speed_Lock(Value);
				break;
			case Speed_Reaction.LockSpeed:
				mAnimal.Speed_Lock(SpeedSet, Value, Index);
				break;
			case Speed_Reaction.Increase:
				mAnimal.SpeedUp();
				break;
			case Speed_Reaction.Decrease:
				mAnimal.SpeedDown();
				break;
			case Speed_Reaction.Activate:
				mAnimal.SpeedSet_Set_Active(SpeedSet, Index);
				break;
			case Speed_Reaction.TopSpeed:
				mAnimal.Speed_SetTopIndex(SpeedSet, Index);
				break;
			case Speed_Reaction.AnimationSpeed:
				mAnimal.SpeedSet_Get(SpeedSet)[Index - 1].animator.Value = animatorSpeed;
				break;
			case Speed_Reaction.GlobalAnimatorSpeed:
				mAnimal.AnimatorSpeed = animatorSpeed;
				break;
			case Speed_Reaction.SetRandomSpeed:
			{
				MSpeedSet mSpeedSet = mAnimal.SpeedSet_Get(SpeedSet);
				if (mSpeedSet != null)
				{
					mAnimal.SpeedSet_Set_Active(SpeedSet, UnityEngine.Random.Range(1, (int)mSpeedSet.TopIndex + 1));
				}
				break;
			}
			case Speed_Reaction.Sprint:
				mAnimal.Sprint = Value;
				break;
			}
			return true;
		}
	}
}
