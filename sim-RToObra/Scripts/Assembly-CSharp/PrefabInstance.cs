using UnityEngine;

[ExecuteInEditMode]
public class PrefabInstance : MonoBehaviour
{
	public GameObject prefab;

	public RuntimeAnimatorController anim;

	public bool addAnimEventHandler = true;

	[Multiline]
	public string propertyValues;
}
