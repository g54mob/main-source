using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Manager
{
	[Serializable]
	public class PathRenderManager : MonoSingleton<PathRenderManager>
	{
		private const float UpdateFrequency = 0.8569f;

		private static readonly Vector3 Offset = new Vector3(0f, 0.05f, 0f);

		[SerializeField]
		private int maxSimulteniousPathRender = 1;

		[SerializeField]
		private GameObject lineRenderPrefab;

		private Dictionary<PathfinderAgentDriver, LineRenderer> pathLines = new Dictionary<PathfinderAgentDriver, LineRenderer>();

		private float updateDeltaAccumulator;

		public void RenderDriverPath(PathfinderAgentDriver driver)
		{
			if (!driver.IsMoving || driver.CurrentPath?.NodePath == null)
			{
				HideDriverPath(driver);
			}
			else if (driver.CurrentNodeIndex <= 2)
			{
				HideDriverPath(driver);
			}
			else
			{
				if (pathLines.ContainsKey(driver))
				{
					return;
				}
				LineRenderer componentInChildren = UnityEngine.Object.Instantiate(lineRenderPrefab, Vector3.zero, Quaternion.identity).GetComponentInChildren<LineRenderer>();
				pathLines.Add(driver, componentInChildren);
				driver.OnStartTraversingPathEvent += OnAgentStartTraversingPath;
				List<MapNode> nodePath = driver.CurrentPath.NodePath;
				int count = nodePath.Count;
				componentInChildren.positionCount = driver.CurrentNodeIndex + 2;
				for (int i = 0; i <= driver.CurrentNodeIndex + 1 && i < count; i++)
				{
					if (nodePath[i] != null)
					{
						componentInChildren.SetPosition(i, nodePath[i].WorldPosition + Offset);
					}
				}
			}
		}

		public void HideDriverPath(PathfinderAgentDriver driver)
		{
			if (driver != null && pathLines.TryGetValue(driver, out var value))
			{
				UnityEngine.Object.Destroy(value.transform.parent.gameObject);
				pathLines.Remove(driver);
				driver.OnStartTraversingPathEvent -= OnAgentStartTraversingPath;
			}
		}

		private void OnAgentStartTraversingPath(PathfinderAgentDriver driver)
		{
			HideDriverPath(driver);
			RenderDriverPath(driver);
		}

		private void RefreshPath(PathfinderAgentDriver driver)
		{
			if (pathLines.TryGetValue(driver, out var value) && driver.CurrentNodeIndex > 1 && driver.CurrentPath != null)
			{
				value.positionCount = driver.CurrentNodeIndex + 1;
			}
		}

		private void Update()
		{
			if (Time.deltaTime <= 0f)
			{
				return;
			}
			updateDeltaAccumulator += Time.deltaTime;
			if (updateDeltaAccumulator <= 0.8569f)
			{
				return;
			}
			updateDeltaAccumulator = 0f;
			bool flag = false;
			foreach (PathfinderAgentDriver key in pathLines.Keys)
			{
				if (key.CurrentNodeIndex <= 1 || key.CurrentPath == null)
				{
					flag = true;
				}
				RefreshPath(key);
			}
			if (!flag)
			{
				return;
			}
			foreach (PathfinderAgentDriver item in (from item in pathLines
				select item.Key into item
				where item.CurrentNodeIndex <= 1 || item.CurrentPath == null
				select item).ToList())
			{
				HideDriverPath(item);
			}
		}
	}
}
