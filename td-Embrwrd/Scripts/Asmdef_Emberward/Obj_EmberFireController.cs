using System;
using UnityEngine;

public class Obj_EmberFireController : MonoBehaviour
{
	[Serializable]
	public class EmberTypeToGameobjectDic : SerializableDictionary<eEmberType, Obj_EmberFire>
	{
	}

	[Header("火焰種類對應的GameObject")]
	[SerializeField]
	private EmberTypeToGameobjectDic dic_EmberTypeToGameobject;

	private Obj_EmberFire curEmberFire;

	private void Start()
	{
	}

	private void SwitchEmber(eEmberType type)
	{
	}

	public void SetEmberAttributes(float rate)
	{
	}
}
