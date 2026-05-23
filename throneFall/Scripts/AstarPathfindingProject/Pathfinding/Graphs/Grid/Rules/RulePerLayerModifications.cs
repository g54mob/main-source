using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Rules
{
	[Preserve]
	public class RulePerLayerModifications : GridGraphRule
	{
		public struct PerLayerRule
		{
			public int layer;

			public RuleAction action;

			public int tag;
		}

		public enum RuleAction
		{
			SetTag = 0,
			MakeUnwalkable = 1
		}

		public PerLayerRule[] layerRules = new PerLayerRule[0];

		private const int SetTagBit = 1073741824;

		public override void Register(GridGraphRules rules)
		{
			int[] layerToTag = new int[32];
			bool[] layerToUnwalkable = new bool[32];
			for (int i = 0; i < layerRules.Length; i++)
			{
				PerLayerRule perLayerRule = layerRules[i];
				if (perLayerRule.action == RuleAction.SetTag)
				{
					layerToTag[perLayerRule.layer] = 0x40000000 | perLayerRule.tag;
				}
				else
				{
					layerToUnwalkable[perLayerRule.layer] = true;
				}
			}
			rules.AddMainThreadPass(Pass.BeforeConnections, delegate(GridGraphRules.Context context)
			{
				if (!context.data.heightHits.IsCreated)
				{
					Debug.LogError("RulePerLayerModifications requires height testing to be enabled on the grid graph", context.graph.active);
				}
				else
				{
					NativeArray<RaycastHit> heightHits = context.data.heightHits;
					NativeArray<bool> walkable = context.data.nodes.walkable;
					NativeArray<int> tags = context.data.nodes.tags;
					Slice3D slice3D = new Slice3D(context.data.nodes.bounds, context.data.heightHitsBounds);
					int3 size = slice3D.slice.size;
					for (int j = 0; j < size.y; j++)
					{
						for (int k = 0; k < size.z; k++)
						{
							int num = j * size.x * size.z + k * size.x;
							for (int l = 0; l < size.x; l++)
							{
								int index = num + l;
								int index2 = slice3D.InnerCoordinateToOuterIndex(l, j, k);
								Collider collider = heightHits[index].collider;
								if (collider != null)
								{
									int layer = collider.gameObject.layer;
									if (layerToUnwalkable[layer])
									{
										walkable[index2] = false;
									}
									int num2 = layerToTag[layer];
									if ((num2 & 0x40000000) != 0)
									{
										tags[index2] = num2 & 0xFF;
									}
								}
							}
						}
					}
				}
			});
		}
	}
}
