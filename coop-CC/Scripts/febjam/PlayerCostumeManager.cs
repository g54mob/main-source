using System;
using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;

public class PlayerCostumeManager : EntityBehaviourBase
{
	public enum ExpressionClip
	{
		Idle = 0,
		Crashout = 1,
		Bonk = 2
	}

	public enum PartType
	{
		CostumeFace = 0,
		CostumeHead = 1,
		CostumeBody = 2
	}

	[Serializable]
	public class Costume
	{
		public string name = "";

		public CostumeObject costumeObject;

		public Expression[] expressions;
	}

	[Serializable]
	public class Expression
	{
		public ExpressionClip expressionClip;

		public Part[] parts;
	}

	[Serializable]
	public class Part
	{
		public PartType partType;

		public GameObject[] frameObjects;
	}

	public Costume[] costumes;

	public int currentCostumeID;

	public int currentUnlockedCostumeIndex;

	public ExpressionClip currentExpression;

	public float frameSpeed = 1f;

	public float animationTime;

	private List<GameObject> currentlyActiveFrames = new List<GameObject>();

	public int[] unlockedCostumeIndicies;

	public PlayerCostumeManagerNetwork playerCostumeManagerNetwork;

	protected override void OnUpdatePresentation()
	{
		if (playerCostumeManagerNetwork != null)
		{
			currentCostumeID = playerCostumeManagerNetwork.currentCostumeID;
		}
		UpdateCostume();
	}

	public int GetIndexFromCostumeObject(CostumeObject costumeObject)
	{
		for (int i = 0; i < costumes.Length; i++)
		{
			if (costumes[i].costumeObject == costumeObject)
			{
				return i;
			}
		}
		return -1;
	}

	protected override void OnEntityCreated()
	{
		if (!GameUtil.isReady)
		{
			if (SaveManager.data.TryGetCurrentCostume(out var costume))
			{
				currentCostumeID = GetIndexFromCostumeObject(costume);
			}
			else
			{
				currentCostumeID = 0;
			}
		}
		ResetAllCostumes();
		UpdateCostume();
	}

	public void SetUpUnlockedIndicies()
	{
		CostumeObject[] unlockedCostumes = SaveManager.data.GetUnlockedCostumes();
		unlockedCostumeIndicies = new int[unlockedCostumes.Length];
		for (int i = 0; i < unlockedCostumes.Length; i++)
		{
			for (int j = 0; j < costumes.Length; j++)
			{
				if (costumes[j].costumeObject == unlockedCostumes[i])
				{
					unlockedCostumeIndicies[i] = j;
				}
			}
		}
	}

	private void ResetAllCostumesButton()
	{
		ResetAllCostumes();
	}

	public void ResetAllCostumes()
	{
		Costume[] array = costumes;
		foreach (Costume costume in array)
		{
			Expression[] expressions = costume.expressions;
			for (int j = 0; j < expressions.Length; j++)
			{
				Part[] parts = expressions[j].parts;
				for (int k = 0; k < parts.Length; k++)
				{
					GameObject[] frameObjects = parts[k].frameObjects;
					foreach (GameObject obj in frameObjects)
					{
						if (obj == null)
						{
							Debug.LogError(costume.name + " has no frame object");
						}
						obj.SetActive(value: false);
					}
				}
			}
		}
	}

	public void UpdateCostume()
	{
		_ = currentlyActiveFrames.Count;
		foreach (GameObject currentlyActiveFrame in currentlyActiveFrames)
		{
			currentlyActiveFrame.SetActive(value: false);
		}
		currentlyActiveFrames.Clear();
		int num = 0;
		animationTime += Time.deltaTime;
		num = Mathf.FloorToInt(frameSpeed * animationTime);
		Costume costume = costumes[currentCostumeID];
		int num2 = 0;
		for (int i = 0; i < costume.expressions.Length; i++)
		{
			if (costume.expressions[i].expressionClip == currentExpression)
			{
				num2 = i;
				break;
			}
		}
		Part[] parts = costume.expressions[num2].parts;
		foreach (Part part in parts)
		{
			int num3 = num % part.frameObjects.Length;
			part.frameObjects[num3].SetActive(value: true);
			currentlyActiveFrames.Add(part.frameObjects[num3]);
		}
	}

	public Costume GetCurrentCostume()
	{
		return costumes[currentCostumeID];
	}
}
