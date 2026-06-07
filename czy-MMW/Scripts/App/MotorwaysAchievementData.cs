using Motorways;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Motorways/Achievements/Achievement Data", order = 1)]
public class MotorwaysAchievementData : AchievementData
{
	[HideIf("ShouldHideCityField")]
	[EnumSearch(typeof(MapDefinition.CityNames), false, isString = true)]
	public string cityName;

	[HideIf("ShouldHideCityField")]
	[Dropdown("_getChallengeIndexValues")]
	public int challengeIndex = -1;

	public int intValue;

	public AchievementType type;

	public AchievementScale scale;

	[HideIf("ShouldHideCityField")]
	public MotorwaysAchievementDefinition.AchievementGameMode gameMode = MotorwaysAchievementDefinition.AchievementGameMode.Everything;

	[ShowIf("ShouldShowUpgradeTypeField")]
	public UpgradeType upgradeType;

	[StringEnumSearch(typeof(StringId))]
	[Header("Description ID")]
	public string DescriptionId = StringId.None.ToString();

	private DropdownList<int> _getChallengeIndexValues = new DropdownList<int>
	{
		{ "No Challenge", -1 },
		{ "Any Challenge", -2 },
		{ "Challenge 0", 0 },
		{ "Challenge 1", 1 },
		{ "Challenge 2", 2 },
		{ "Challenge 3", 3 },
		{ "Challenge 4", 4 }
	};

	private bool ShouldShowUpgradeTypeField()
	{
		if (type != AchievementType.UpgradesUsed && type != AchievementType.UpgradeLength)
		{
			return type == AchievementType.DeletedUpgrades;
		}
		return true;
	}

	private bool ShouldHideCityField()
	{
		return scale == AchievementScale.Lifetime;
	}
}
