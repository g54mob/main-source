using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Animal Controller/Simple Respawner")]
	public class SimpleRespawner : MonoBehaviour
	{
		public MAnimal animal;

		public StateID DeathID;

		public StateID RespawnState;

		public float RespawnTime = 4f;

		private void OnEnable()
		{
			if (!(animal == null))
			{
				if (animal.gameObject.IsPrefab())
				{
					animal = Object.Instantiate(animal);
				}
				animal.TeleportRot(base.transform);
				animal.OnStateChange.AddListener(OnCharacterDead);
			}
		}

		private void OnDisable()
		{
			animal?.OnStateChange.AddListener(OnCharacterDead);
		}

		public virtual void SetAnimal(MAnimal animal)
		{
			this.animal = animal;
		}

		public virtual void SetAnimal(GameObject animal)
		{
			this.animal = animal.FindComponent<MAnimal>();
		}

		public virtual void SetAnimal(Behaviour animal)
		{
			this.animal = animal.FindComponent<MAnimal>();
		}

		public virtual void OnCharacterDead(int state)
		{
			if (DeathID.ID != state)
			{
				return;
			}
			this.Delay_Action(RespawnTime, delegate
			{
				animal.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
				animal.InputSource?.Enable(val: true);
				animal.enabled = true;
				animal.OverrideStartState = RespawnState;
				animal.ResetController();
				IRestart[] components = animal.GetComponents<IRestart>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].Restart();
				}
			});
		}

		private void Reset()
		{
			DeathID = MTools.GetInstance<StateID>("Death");
			RespawnState = MTools.GetInstance<StateID>("Idle");
		}
	}
}
