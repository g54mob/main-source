using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ChangeSpawningBehaviour : NimbatusAction
	{
		public bool ChangeMaxActive;

		[ShowIf("ChangeMaxActive", true)]
		public int MaxActive;

		private Spawner _spawnerBehaviour;

		protected override void OnInit()
		{
			_spawnerBehaviour = Behaviour.GetCoreBehaviour<Spawner>();
		}

		public override void Execute()
		{
			if (_spawnerBehaviour != null && ChangeMaxActive)
			{
				_spawnerBehaviour.SetMaxActive(MaxActive);
			}
		}
	}
}
