namespace Assets.Source.World.Frames
{
	public class T2SandManualCrafter : ManualCrafter
	{
		private float _baseTickTimer;

		private float _tickTimer;

		private int _ticksRemaining;

		public T2SandManualCrafter(CraftingFrame parent, WorldAnchor slot)
			: base(parent, slot)
		{
		}

		public override void Start()
		{
			base.Start();
			if (base.Active)
			{
				_baseTickTimer = base.TimeRequired / 10f;
				_tickTimer = 0f;
				_ticksRemaining = 9;
			}
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			if (base.Active && _ticksRemaining > 0)
			{
				_tickTimer += delta;
				if (_tickTimer >= _baseTickTimer)
				{
					DoCraftingResult();
					_tickTimer = 0f;
					_ticksRemaining--;
				}
			}
		}
	}
}
