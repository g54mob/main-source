using UnityEngine;

namespace TH20
{
	public class RandomLookAtCameraPOI : LookAtPOI
	{
		private float _timer;

		public RandomLookAtCameraPOI(LookAtPOISourceComponent source)
			: base(source, 20f, 100f)
		{
		}

		public void Update(float deltaTime)
		{
			_timer -= deltaTime;
			if (_timer < 0f)
			{
				float charactersLookAtPlayerMinTime = GameAlgorithms.Config.CharactersLookAtPlayerMinTime;
				float charactersLookAtPlayerMaxTime = GameAlgorithms.Config.CharactersLookAtPlayerMaxTime;
				_timer = RandomUtils.GlobalRandomInstance.NextFloat(charactersLookAtPlayerMinTime, charactersLookAtPlayerMaxTime);
			}
		}

		public override float GetInterest(Vector3 from)
		{
			if (!(_timer > GameAlgorithms.Config.CharactersLookAtPlayerDuration))
			{
				return base.GetInterest(from);
			}
			return 0f;
		}
	}
}
