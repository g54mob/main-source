using System.Collections.Generic;
using UnityEngine;

public class MissionContainer : MonoBehaviour
{
	private List<ITutorial> m_Tutorials;

	private ITutorial m_CurrentTutorial;

	public void BeginTutorial<T>() where T : ITutorial
	{
	}

	public void AddTutorial(ITutorial tutorial)
	{
	}

	public bool IsTutorialCompleted<T>() where T : ITutorial
	{
		return false;
	}
}
