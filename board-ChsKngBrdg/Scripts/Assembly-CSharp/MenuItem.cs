using System;
using UnityEngine;

[Serializable]
public abstract class MenuItem : MonoBehaviour
{
	public abstract void OnClick();
}
