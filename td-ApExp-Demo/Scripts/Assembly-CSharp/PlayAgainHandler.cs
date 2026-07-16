using System;
using UnityEngine;

public class PlayAgainHandler : MonoBehaviour
{
	public static PlayAgainHandler Instance;

	[NonSerialized]
	public bool playAgain;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
	}
}
