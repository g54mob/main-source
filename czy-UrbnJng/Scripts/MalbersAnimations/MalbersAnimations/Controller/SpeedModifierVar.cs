using UnityEngine;

namespace MalbersAnimations.Controller
{
	[CreateAssetMenu(menuName = "Malbers Animations/Modifier/Speeds/New Speed Modifier")]
	public class SpeedModifierVar : ScriptableObject
	{
		public string SpeedSet;

		public MSpeed NewSpeed;

		public virtual void ModifySpeed(MAnimal animal)
		{
			foreach (State state in animal.states)
			{
				state.SpeedSets.Find((MSpeedSet x) => x.name == SpeedSet)?.SwapSpeed(NewSpeed);
			}
		}

		public virtual void ModifySpeed(GameObject go)
		{
			MAnimal mAnimal = go.FindComponent<MAnimal>();
			if ((bool)mAnimal)
			{
				ModifySpeed(mAnimal);
			}
		}

		public virtual void ModifySpeed(Component go)
		{
			MAnimal mAnimal = go.FindComponent<MAnimal>();
			if ((bool)mAnimal)
			{
				ModifySpeed(mAnimal);
			}
		}

		public virtual void AddSpeed(MAnimal animal)
		{
			foreach (MAnimal.StateCache item in animal.states_C)
			{
				item.state.SpeedSets.Find((MSpeedSet x) => x.name == SpeedSet)?.AddSpeed(NewSpeed);
			}
		}

		public virtual void AddSpeed(GameObject go)
		{
			MAnimal mAnimal = go.FindComponent<MAnimal>();
			if ((bool)mAnimal)
			{
				AddSpeed(mAnimal);
			}
		}

		public virtual void AddSpeed(Component go)
		{
			MAnimal mAnimal = go.FindComponent<MAnimal>();
			if ((bool)mAnimal)
			{
				AddSpeed(mAnimal);
			}
		}
	}
}
