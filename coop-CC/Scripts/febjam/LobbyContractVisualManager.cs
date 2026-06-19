using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class LobbyContractVisualManager : EntityBehaviourBase
{
	private static readonly int Locked = Shader.PropertyToID("_locked");

	private static readonly int UV1Offset = Shader.PropertyToID("_uv1Offset");

	public int selectedContractIndex;

	private float _currentOffset;

	public float speed = 1f;

	private List<ContractObject> _contracts = new List<ContractObject>();

	public GameObject orderVisualStack;

	public Transform contractVisualGroup;

	public float offset = 5f;

	public MeshRenderer[] conveyorRenderers;

	public void SetUp()
	{
		foreach (Transform item in contractVisualGroup)
		{
			Object.Destroy(item.gameObject);
		}
		_contracts.Clear();
		GameManager.GetAllContracts(_contracts);
		for (int i = 0; i < _contracts.Count; i++)
		{
			ContractObject contractObject = _contracts[i];
			LobbyOrderVisualStack component = Object.Instantiate(orderVisualStack, contractVisualGroup).GetComponent<LobbyOrderVisualStack>();
			int num = ((contractObject.type == ContractType.Random) ? contractObject.randomBoxCount : contractObject.orders.Length);
			for (int j = 0; j < component.tape.Length; j++)
			{
				component.tape[j].gameObject.SetActive(j < num - 1);
			}
			if (contractObject.isDemoLocked)
			{
				for (int k = 0; k < contractObject.demoVisualPrefabs.Length; k++)
				{
					GameObject gameObject = ((contractObject.type != ContractType.Random) ? Object.Instantiate(contractObject.demoVisualPrefabs[k], component.slots[k]) : Object.Instantiate(contractObject.randomBoxVisualPrefab, component.slots[k]));
					gameObject.transform.localPosition = Vector3.zero;
					Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
					for (int l = 0; l < componentsInChildren.Length; l++)
					{
						componentsInChildren[l].SetPropertyBlockFloat(Locked, 1f);
					}
				}
			}
			else
			{
				for (int m = 0; m < num; m++)
				{
					GameObject gameObject2 = ((contractObject.type != ContractType.Random) ? Object.Instantiate(contractObject.orders[m].orderVisualPrefab, component.slots[m]) : Object.Instantiate(contractObject.randomBoxVisualPrefab, component.slots[m]));
					gameObject2.transform.localPosition = Vector3.zero;
					if (NetworkAggroManagerBase<LobbyManager>.instance.hostTotalBells < contractObject.bellsRequired)
					{
						Renderer[] componentsInChildren = gameObject2.GetComponentsInChildren<Renderer>();
						for (int l = 0; l < componentsInChildren.Length; l++)
						{
							componentsInChildren[l].SetPropertyBlockFloat(Locked, 1f);
						}
					}
				}
			}
			component.transform.localPosition = new Vector3((float)i * (0f - offset), 0f, 0f);
		}
	}

	protected override void OnUpdatePresentation()
	{
		float b = (float)selectedContractIndex * (0f - offset);
		_currentOffset = Mathf.Lerp(_currentOffset, b, speed * Time.deltaTime);
		contractVisualGroup.localPosition = new Vector3(0f - _currentOffset, 0f, 0f);
		selectedContractIndex = NetworkAggroManagerBase<LobbyManager>.instance.GetContractIndex();
		MeshRenderer[] array = conveyorRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetPropertyBlockFloat(UV1Offset, _currentOffset);
		}
	}
}
