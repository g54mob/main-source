using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "PlayerUpgrade_default", menuName = "Tower Factory/PlayerUpgrade")]
public class PlayerUpgrade : ScriptableObject
{
	[SerializeField]
	private string id = "ASSING_AN_ID";

	[SerializeField]
	private string[] oldIds;

	[SerializeField]
	private LocalizedString displayName;

	[SerializeField]
	private LocalizedString description;

	[SerializeField]
	private Sprite icon;

	[SerializeField]
	private int cost;

	[SerializeField]
	private bool unlockedByDefault;

	[SerializeField]
	private PlayerUpgrade[] upgradesToLock;

	[SerializeField]
	private GameplayEffectData[] grantedGameplayEffects;

	public string Id => id;

	public string[] OldIds => oldIds;

	public string DisplayName => displayName.GetLocalizedString();

	public string Description => description.GetLocalizedString();

	public Sprite Icon => icon;

	public int Cost => cost;

	public bool UnlockedByDefault => unlockedByDefault;

	public PlayerUpgrade[] UpgradesToLock => upgradesToLock;

	public GameplayEffectData[] GrantedGameplayEffects => grantedGameplayEffects;

	private void SetNameAsID()
	{
		id = base.name;
	}
}
