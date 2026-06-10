using System;
using NSMedieval.Enums;
using UnityEngine;

[Serializable]
public class LockStateData
{
	[SerializeField]
	private LockState lockState;

	[SerializeField]
	private string textKey;

	[SerializeField]
	private string infoTextKey;

	[SerializeField]
	private bool isScaringPredators;

	[SerializeField]
	private bool defaultLockState;

	public LockState LockState => lockState;

	public string TextKey => textKey;

	public string InfoTextKey => infoTextKey;

	public bool IsScaringPredators => isScaringPredators;

	public bool DefaultLockState => defaultLockState;
}
