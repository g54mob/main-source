using UnityEngine;

public abstract class AAchievementStore : MonoBehaviour
{
	public abstract void Init();

	public abstract bool UnlockAchievement(AchievementController.Type type);

	public abstract void ClearAll();
}
