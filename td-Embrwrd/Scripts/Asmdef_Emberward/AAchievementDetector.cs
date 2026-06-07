using System.Collections.Generic;
using UnityEngine;

public abstract class AAchievementDetector : MonoBehaviour
{
	public void FullGameDetectStart()
	{
	}

	protected virtual void FullGameDetectStartProc()
	{
	}

	public void FullGameDetectStop()
	{
	}

	protected virtual void FullGameDetectStopProc()
	{
	}

	public void IngameDetectStart()
	{
	}

	protected abstract void IngameDetectStartProc();

	public void IngameDetectStop()
	{
	}

	protected abstract void IngameDetectStopProc();

	protected void UnlockAchievement(eAchievementType type)
	{
	}

	protected void SetAchievementProgress(eAchievementType type, int progress)
	{
	}

	public List<eAchievementType> GetQualifiedForUnlockAchievements()
	{
		return null;
	}

	protected virtual List<eAchievementType> GetQualifiedForUnlockAchievementsProc()
	{
		return null;
	}

	public void InstantCheck()
	{
	}

	protected virtual void InstantCheckProc()
	{
	}
}
