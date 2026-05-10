using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class AddressablesManager : MonoBehaviour
{
	[Serializable]
	public struct AddressableMapping
	{
		public string key;

		public AssetReference assetReference;
	}

	[Header("UI Elements")]
	[SerializeField]
	private Button m_loadAddressable;

	[SerializeField]
	private Button m_releaseAddressable;

	[SerializeField]
	private TMP_Dropdown m_selectDLC;

	[Header("Addressable Mappings")]
	[SerializeField]
	private List<AddressableMapping> m_addressableMappings;

	private Dictionary<string, GameObject> m_instantiatedObjects;

	private AssetReference m_selectedAssetReference;

	private void Start()
	{
	}

	private void OnDropdownValueChanged(int index)
	{
	}

	private void LoadAddressable()
	{
	}

	private void ReleaseAddressable()
	{
	}

	private void ReleaseAllAddressables()
	{
	}

	private void OnDestroy()
	{
	}
}
