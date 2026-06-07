using System.Collections.Generic;
using UnityEngine;

public class EmitterSecondaryEditor : MonoBehaviour
{
	public GameObject secondaryRowPrefab;

	public GameObject rowContainer;

	public EmitterSecondaryEditorRowAddOrEdit rowEditor;

	public InspectorInt initialDelay;

	private Emitter emitter;

	private List<Emitter.SecondaryEnemyRow> localList;

	public void SetEmitter(Emitter emitter)
	{
	}

	public void RefreshRows()
	{
	}

	public List<Emitter.SecondaryEnemyRow> GetLocalList()
	{
		return null;
	}

	public void OnAdd()
	{
	}

	public void OnEdit(EmitterSecondaryRowEditor re)
	{
	}

	public void AddRow(Emitter.SecondaryEnemyRow row)
	{
	}

	public void RemoveRow(Emitter.SecondaryEnemyRow row)
	{
	}

	public void MoveUp(Emitter.SecondaryEnemyRow row)
	{
	}

	public void MoveDown(Emitter.SecondaryEnemyRow row)
	{
	}

	public void Apply()
	{
	}

	public void Cancel()
	{
	}

	private void MoveSecondaryRow(int index, bool up)
	{
	}

	private List<Emitter.SecondaryEnemyRow> CopyList(List<Emitter.SecondaryEnemyRow> from)
	{
		return null;
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
