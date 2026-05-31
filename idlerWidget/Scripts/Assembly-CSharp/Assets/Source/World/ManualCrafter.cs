namespace Assets.Source.World
{
	public class ManualCrafter : AutoCrafter
	{
		public bool Active { get; protected set; }

		public ManualCrafter(CraftingFrame parent, WorldAnchor slot)
			: base(parent, slot)
		{
		}

		public virtual void Start()
		{
			if (InitStartCrafting())
			{
				base.TimeRequired = base.Parent.GetCraftingTime(handCraft: true);
				base.TimeAccumulated = 0f;
				Active = true;
				_activeCooldown = base.Parent.ActiveFrame?.TriggerCooldown(Slot, base.TimeRequired);
				base.Parent.ActiveFrame?.TriggerGizmoStart(Slot);
			}
		}

		public override bool InitStartCrafting()
		{
			if (Active)
			{
				return false;
			}
			return base.InitStartCrafting();
		}

		public override void ActiveUpdate(float delta)
		{
			if (Active)
			{
				base.TimeAccumulated += delta;
				if (base.TimeAccumulated >= base.TimeRequired)
				{
					DoCraftingResult();
					Active = false;
					base.Parent.ActiveFrame?.EnableButton(Slot);
					base.Parent.ActiveFrame?.TriggerGizmoStop(Slot);
				}
			}
		}

		public override void SetupActiveFrame(ActiveWorldFrame frame)
		{
			if (Active)
			{
				base.SetupActiveFrame(frame);
				frame.TriggerGizmoStart(Slot);
			}
		}
	}
}
