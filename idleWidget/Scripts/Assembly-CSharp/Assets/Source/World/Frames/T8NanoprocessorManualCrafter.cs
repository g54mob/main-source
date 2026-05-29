namespace Assets.Source.World.Frames
{
	public class T8NanoprocessorManualCrafter : ManualCrafter
	{
		private bool _consumedMaterials;

		public new T8Nanoprocessor Parent => base.Parent as T8Nanoprocessor;

		public T8NanoprocessorManualCrafter(T8Nanoprocessor parent, WorldAnchor slot)
			: base(parent, slot)
		{
		}

		public override bool InitStartCrafting()
		{
			if (_consumedMaterials)
			{
				return true;
			}
			return base.InitStartCrafting();
		}

		public override void Start()
		{
			base.Start();
			if (base.Active)
			{
				_consumedMaterials = true;
			}
		}

		protected override bool DoCraftingResult()
		{
			bool num = base.DoCraftingResult();
			if (num)
			{
				_consumedMaterials = false;
			}
			return num;
		}

		public void Reset()
		{
			base.Active = false;
			base.TimeAccumulated = 0f;
		}
	}
}
