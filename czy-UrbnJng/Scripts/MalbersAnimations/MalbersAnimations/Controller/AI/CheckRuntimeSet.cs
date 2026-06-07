using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	public class CheckRuntimeSet : MAIDecision
	{
		[RequiredField]
		public RuntimeGameObjects Set;

		[Tooltip("Check options of the Set")]
		public CheckSetSize CheckSize = CheckSetSize.Equal;

		[Tooltip("Size of the Current Set")]
		[Hide("CheckSize", true, new int[] { 0 })]
		public int Size;

		public override string DisplayName => "Runtime Set/Check Runtime Set";

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			return CheckSize switch
			{
				CheckSetSize.Empty => Set.IsEmpty, 
				CheckSetSize.Equal => Set.Count == Size, 
				CheckSetSize.Greater => Set.Count > Size, 
				CheckSetSize.Less => Set.Count < Size, 
				_ => false, 
			};
		}

		private void Reset()
		{
			Description = "Check if a Runtime Set is Empty or has a Size equal, greater or less than a given value";
		}
	}
}
