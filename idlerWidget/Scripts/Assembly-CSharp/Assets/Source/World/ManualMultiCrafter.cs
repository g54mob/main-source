namespace Assets.Source.World
{
	public class ManualMultiCrafter : ManualCrafter
	{
		private int _multiCount;

		private float _baseTickTimer;

		private float _tickTimer;

		private int _ticksRemaining;

		public ManualMultiCrafter(CraftingFrame parent, WorldAnchor slot, int multiCount)
			: base(parent, slot)
		{
			_multiCount = multiCount;
		}

		public override void Start()
		{
			base.Start();
			if (base.Active)
			{
				_baseTickTimer = base.TimeRequired / (float)_multiCount;
				_tickTimer = 0f;
				_ticksRemaining = _multiCount - 1;
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
					_tickTimer = 0f;
					_ticksRemaining--;
					base.Active = false;
					DoCraftingResult();
					InitStartCrafting();
					base.Active = true;
				}
			}
		}
	}
}
