using I2.Loc;
using UnityEngine;

public abstract class AchievementBase : ScriptableObject, IPanelContext
{
	[SerializeField]
	private AchievementId _id;

	[SerializeField]
	private LocalizedString _name;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private Sprite _iconLocked;

	public PlayerProfile PlayerProfile { get; private set; }

	public AchievementId Id => _id;

	public AchievementProgress Progress { get; protected set; }

	public virtual bool ItIsAchieved { get; protected set; }

	public LocalizedString Name => _name;

	public LocalizedString Description => _description;

	public Sprite Icon => _icon;

	protected virtual AchievementId DefaultId => AchievementId.None;

	public PanelID PanelID => PanelID.Achievement;

	public void Initialize(PlayerProfile player)
	{
		PlayerProfile = player;
		ItIsAchieved = PlayerProfile.IsAchievementUnlocked(this);
		if (!ItIsAchieved)
		{
			Initialize();
		}
	}

	protected abstract void Initialize();

	public abstract void Uninitialize();

	public virtual void UnlockAchievement(PlayerProfile playerProfile)
	{
	}

	protected bool UnlockAchievement()
	{
		if (ItIsAchieved || !UnlockAchievementSpecific())
		{
			return false;
		}
		PlayerProfile.UnlockAchievement(this);
		ItIsAchieved = true;
		return true;
	}

	protected virtual bool UnlockAchievementSpecific()
	{
		return true;
	}
}
