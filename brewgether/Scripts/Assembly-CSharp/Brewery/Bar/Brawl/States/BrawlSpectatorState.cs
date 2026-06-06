using UnityEngine;

namespace Brewery.Bar.Brawl.States
{
	public class BrawlSpectatorState : IBrawlState
	{
		private readonly BrawlStateContext ctx;

		private float stateTime;

		private float timeout;

		private float nextJoinCheck;

		private Vector3 watchPosition;

		private const float JoinCheckInterval = 3f;

		public BrawlState StateType => default(BrawlState);

		public BrawlSpectatorState(BrawlStateContext context)
		{
		}

		public void OnEnter()
		{
		}

		public void OnExit()
		{
		}

		public IBrawlStateResult Tick(float deltaTime)
		{
			return null;
		}

		public BrawlState? TryGetNextState(IBrawlStateResult result)
		{
			return null;
		}

		private void FacePosition(Vector3 position)
		{
		}

		private bool TryJoinBrawl()
		{
			return false;
		}
	}
}
