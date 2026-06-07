using System;
using UnityEngine;

[Serializable]
public class ChildBehaviourCache<T> : ChildObjectCache<T> where T : MonoBehaviour
{
	protected override void SetActive(T instance, bool active)
	{
		instance.gameObject.SetActive(active);
	}
}
