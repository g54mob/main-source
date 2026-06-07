using Factory;

public class SetLanguageAction : PlayerAction
{
	private enum CycleLanguageDirection
	{
		Forward = 0,
		Backward = 1
	}

	[Dependency]
	protected IActivePlayer _player;

	[Dependency]
	private LocaleDatabase _locales;

	private LocaleDatabase.LocaleId _localeId = LocaleDatabase.LocaleId.en_US;

	public override void OnActionBegin(float timestamp)
	{
		base.OnActionBegin(timestamp);
		_player.LocaleId = _localeId;
	}

	public override void Tick(float frameTime)
	{
		OnActionComplete();
	}

	private void CycleLocaleId(CycleLanguageDirection direction)
	{
		Locale currentLocale = _locales.CurrentLocale;
		int index = _locales.GetIndex(currentLocale);
		int num = ((direction == CycleLanguageDirection.Forward) ? (index + 1) : (index - 1));
		if (num >= _locales.LocaleCount)
		{
			num = 0;
		}
		if (num < 0)
		{
			num = _locales.LocaleCount - 1;
		}
		_localeId = _locales.GetLocale(num).Id;
	}

	public static SetLanguageAction CreateCycleForwardSetLanguageAction(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		SetLanguageAction setLanguageAction = scope.Get<SetLanguageAction>();
		setLanguageAction.CycleLocaleId(CycleLanguageDirection.Forward);
		setLanguageAction.InitializeAction(owningGroup, timestamp);
		setLanguageAction.OnActionBegin(timestamp);
		return setLanguageAction;
	}

	public static SetLanguageAction CreateCycleBackwardSetLanguageAction(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		SetLanguageAction setLanguageAction = scope.Get<SetLanguageAction>();
		setLanguageAction.CycleLocaleId(CycleLanguageDirection.Backward);
		setLanguageAction.InitializeAction(owningGroup, timestamp);
		setLanguageAction.OnActionBegin(timestamp);
		return setLanguageAction;
	}

	public override void Reset()
	{
		base.Reset();
		_localeId = LocaleDatabase.LocaleId.en_US;
	}
}
