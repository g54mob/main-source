using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_RawImageMap : MonoBehaviour
{
	[Serializable]
	public class WorldToMaterialDic : SerializableDictionary<eWorldType, Material>
	{
	}

	[SerializeField]
	private RawImage image_Map;

	[SerializeField]
	private WorldToMaterialDic dic_WorldToMaterial;

	[SerializeField]
	private WorldToMaterialDic dic_WorldToMaterial_static;

	private eWorldType curWorldType;

	private bool doUseStaticMaterial;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameSettingChanged()
	{
	}

	private void Start()
	{
	}

	private void SwapBackground(eWorldType worldType, bool isStatic)
	{
	}
}
