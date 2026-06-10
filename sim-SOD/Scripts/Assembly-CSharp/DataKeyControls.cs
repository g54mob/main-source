using System;
using UnityEngine;

public class DataKeyControls : MonoBehaviour
{
	[Serializable]
	public class DataKeySettings
	{
		public Evidence.DataKey key;

		[Tooltip("Is this a unique identifier?")]
		public bool uniqueKey;

		public bool countTowardsProfile;
	}

	private static DataKeyControls _instance;

	public static DataKeyControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
