using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class TryToSpawn : NimbatusAction
	{
		public int Count;

		public bool SpawnImmediately;

		private Spawner _spawner;

		protected override void OnInit()
		{
			_spawner = Behaviour.GetCoreBehaviour<Spawner>();
		}

		public override void Execute()
		{
			if (_spawner != null)
			{
				if (!SpawnImmediately)
				{
					_spawner.TryToSpawn(Count);
				}
				else
				{
					_spawner.TryToSpawnImmediate(Count);
				}
			}
		}
	}
}
