namespace TH20
{
	public class MetagameStateCollaborativePlayer : MetagameState
	{
		private CollaborativeResearchMenu _collaborativePortfolioMenu;

		private readonly bool _createMenuOnEnter;

		public MetagameStateCollaborativePlayer(bool createMenuOnEnter, MetagameMap map)
			: base(map)
		{
			_createMenuOnEnter = createMenuOnEnter;
		}

		public override void Enter()
		{
			if (_createMenuOnEnter)
			{
				CreateMenu();
			}
		}

		public override void Resume(State resumingFrom)
		{
			CreateMenu();
		}

		public override void Update()
		{
			if (_collaborativePortfolioMenu.IsClosed())
			{
				_collaborativePortfolioMenu = null;
				PopState();
			}
		}

		private void CreateMenu()
		{
			_collaborativePortfolioMenu = MetagameMap.HUD.FindMenu<CollaborativeResearchMenu>();
			if (_collaborativePortfolioMenu == null)
			{
				_collaborativePortfolioMenu = MetagameMap.HUD.CreateMenu<CollaborativeResearchMenu>();
				_collaborativePortfolioMenu.Initialise(Metagame.App);
			}
		}
	}
}
