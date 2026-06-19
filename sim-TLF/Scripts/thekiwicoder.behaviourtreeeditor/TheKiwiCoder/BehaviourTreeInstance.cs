using System;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

namespace TheKiwiCoder
{
	[AddComponentMenu("TheKiwiCoder/BehaviourTreeInstance")]
	public class BehaviourTreeInstance : MonoBehaviour
	{
		public enum TickMode
		{
			None = 0,
			FixedUpdate = 1,
			Update = 2,
			LateUpdate = 3
		}

		public enum StartMode
		{
			None = 0,
			OnEnable = 1,
			OnAwake = 2,
			OnStart = 3
		}

		[Tooltip("BehaviourTree asset to instantiate during Awake")]
		public BehaviourTree behaviourTree;

		[Tooltip("When to update this behaviour tree in the frame")]
		public TickMode tickMode = TickMode.Update;

		[Tooltip("When to start this behaviour tree")]
		public StartMode startMode = StartMode.OnStart;

		[Tooltip("Run behaviour tree validation at startup (Can be disabled for release)")]
		public bool validate = true;

		[Tooltip("Override / set blackboard key values for this behaviour tree instance")]
		public List<BlackboardKeyValuePair> blackboardOverrides = new List<BlackboardKeyValuePair>();

		private BehaviourTree runtimeTree;

		private Context context;

		private static readonly ProfilerMarker profileUpdate = new ProfilerMarker("BehaviourTreeInstance.Update");

		private Node.State treeState;

		public BehaviourTree RuntimeTree
		{
			get
			{
				if (runtimeTree != null)
				{
					return runtimeTree;
				}
				return behaviourTree;
			}
		}

		private void OnEnable()
		{
			if (startMode == StartMode.OnEnable)
			{
				StartBehaviour(behaviourTree);
			}
		}

		private void Awake()
		{
			if (startMode == StartMode.OnAwake)
			{
				StartBehaviour(behaviourTree);
			}
		}

		private void Start()
		{
			if (startMode == StartMode.OnStart)
			{
				StartBehaviour(behaviourTree);
			}
		}

		private void ApplyBlackboardOverrides()
		{
			foreach (BlackboardKeyValuePair blackboardOverride in blackboardOverrides)
			{
				BlackboardKey blackboardKey = runtimeTree.blackboard.Find(blackboardOverride.key.name);
				BlackboardKey value = blackboardOverride.value;
				if (blackboardKey != null && value != null)
				{
					blackboardKey.CopyFrom(value);
				}
			}
		}

		private void InternalUpdate(float tickDelta)
		{
			if ((bool)runtimeTree)
			{
				context.tickResults.Clear();
				treeState = runtimeTree.Tick(tickDelta);
			}
		}

		private void FixedUpdate()
		{
			if (tickMode == TickMode.FixedUpdate)
			{
				InternalUpdate(Time.fixedDeltaTime);
			}
		}

		private void Update()
		{
			if (tickMode == TickMode.Update)
			{
				InternalUpdate(Time.deltaTime);
			}
		}

		private void LateUpdate()
		{
			if (tickMode == TickMode.LateUpdate)
			{
				InternalUpdate(Time.deltaTime);
			}
		}

		public void ManualTick(float tickDelta)
		{
			if (tickMode != TickMode.None)
			{
				Debug.LogWarning($"Manually ticking the behaviour tree while in {tickMode} will cause duplicate updates");
			}
			InternalUpdate(tickDelta);
		}

		public void StartBehaviour(BehaviourTree tree)
		{
			if (ValidateTree(tree))
			{
				InstantiateTree(tree);
			}
			else
			{
				runtimeTree = null;
			}
		}

		public void InstantiateTree(BehaviourTree tree)
		{
			context = CreateBehaviourTreeContext();
			runtimeTree = tree.Clone();
			runtimeTree.Bind(context);
			ApplyBlackboardOverrides();
		}

		private Context CreateBehaviourTreeContext()
		{
			return Context.CreateFromGameObject(base.gameObject);
		}

		private bool ValidateTree(BehaviourTree tree)
		{
			if (!tree)
			{
				Debug.LogWarning("No BehaviourTree assigned to " + base.name + ", assign a behaviour tree in the inspector");
				return false;
			}
			bool flag = true;
			if (validate)
			{
				flag = !IsRecursive(tree, out var cycle);
				if (!flag)
				{
					Debug.LogError("Failed to create recursive behaviour tree. Found cycle at: " + cycle);
				}
			}
			return flag;
		}

		private bool IsRecursive(BehaviourTree tree, out string cycle)
		{
			List<string> treeStack = new List<string>();
			HashSet<BehaviourTree> referencedTrees = new HashSet<BehaviourTree>();
			bool cycleFound = false;
			string cyclePath = "";
			Action<Node> traverse = null;
			traverse = delegate(Node node)
			{
				if (!cycleFound && node is SubTree subTree && subTree.treeAsset != null)
				{
					treeStack.Add(subTree.treeAsset.name);
					if (referencedTrees.Contains(subTree.treeAsset))
					{
						int num = 0;
						foreach (string item in treeStack)
						{
							num++;
							if (num == treeStack.Count)
							{
								cyclePath += item;
							}
							else
							{
								cyclePath = cyclePath + item + " -> ";
							}
						}
						cycleFound = true;
					}
					else
					{
						referencedTrees.Add(subTree.treeAsset);
						BehaviourTree.Traverse(subTree.treeAsset.rootNode, traverse);
						referencedTrees.Remove(subTree.treeAsset);
					}
					treeStack.RemoveAt(treeStack.Count - 1);
				}
			};
			treeStack.Add(tree.name);
			referencedTrees.Add(tree);
			BehaviourTree.Traverse(tree.rootNode, traverse);
			referencedTrees.Remove(tree);
			treeStack.RemoveAt(treeStack.Count - 1);
			cycle = cyclePath;
			return cycleFound;
		}

		private void OnDrawGizmosSelected()
		{
			if (!Application.isPlaying || !runtimeTree)
			{
				return;
			}
			BehaviourTree.Traverse(runtimeTree.rootNode, delegate(Node n)
			{
				if (n.drawGizmos)
				{
					n.OnDrawGizmos();
				}
			});
		}

		public BlackboardKey<T> FindBlackboardKey<T>(string keyName)
		{
			if ((bool)runtimeTree)
			{
				return runtimeTree.blackboard.Find<T>(keyName);
			}
			return null;
		}

		public void SetBlackboardValue<T>(string keyName, T value)
		{
			if ((bool)runtimeTree)
			{
				runtimeTree.blackboard.SetValue(keyName, value);
			}
		}

		public T GetBlackboardValue<T>(string keyName)
		{
			if ((bool)runtimeTree)
			{
				return runtimeTree.blackboard.GetValue<T>(keyName);
			}
			return default(T);
		}
	}
}
