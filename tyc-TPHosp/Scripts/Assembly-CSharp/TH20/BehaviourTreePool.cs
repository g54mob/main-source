using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class BehaviourTreePool : MustCallDestroy
	{
		private class Pool
		{
			public List<ExternalBehavior> Free = new List<ExternalBehavior>();

			public List<ExternalBehavior> Used = new List<ExternalBehavior>();
		}

		private Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();

		private const int MaxTickedPerFrame = 10;

		private int _lastProcessed;

		private List<Behavior> _tick = new List<Behavior>();

		private GUIStyle _debugGUIStyle;

		public override void Destroy()
		{
			foreach (KeyValuePair<string, Pool> pool in _pools)
			{
				pool.Value.Free.ClearAndDestroy();
				pool.Value.Used.ClearAndDestroy();
			}
			base.Destroy();
		}

		public void Set(CharacterBehaviorTree behaviorTree, ExternalBehavior externalBehavior)
		{
			if (!(behaviorTree == null))
			{
				if (DebugVars.UseBehaviourTreePool.Value)
				{
					BehaviorManager.instance.DisableBehavior(behaviorTree);
					Return(behaviorTree.ExternalBehavior);
					behaviorTree.ExternalBehavior = ((externalBehavior == null) ? null : Get(externalBehavior));
					AddOrRemoveFromTickList(behaviorTree, externalBehavior);
				}
				else
				{
					AddOrRemoveFromTickList(behaviorTree, externalBehavior);
					behaviorTree.ExternalBehavior = externalBehavior;
				}
			}
		}

		private void AddOrRemoveFromTickList(CharacterBehaviorTree behaviorTree, ExternalBehavior externalBehavior)
		{
			if (externalBehavior == null)
			{
				int num = _tick.IndexOf(behaviorTree);
				if (num != -1)
				{
					_tick.RemoveAt(num);
					if (num <= _lastProcessed && _lastProcessed != 0)
					{
						_lastProcessed--;
					}
				}
			}
			else
			{
				_tick.AddUnique(behaviorTree);
			}
		}

		private ExternalBehavior Get(ExternalBehavior externalBehavior)
		{
			string name = externalBehavior.name;
			if (!_pools.TryGetValue(name, out var value))
			{
				value = new Pool();
				_pools.Add(name, value);
			}
			ExternalBehavior externalBehavior2;
			if (value.Free.Count != 0)
			{
				externalBehavior2 = value.Free.Pop();
				value.Used.Add(externalBehavior2);
			}
			else
			{
				externalBehavior2 = Object.Instantiate(externalBehavior);
				externalBehavior2.name = externalBehavior2.name.Replace("(Clone)", "");
				externalBehavior2.Init();
				value.Used.Add(externalBehavior2);
			}
			return externalBehavior2;
		}

		private void Return(ExternalBehavior externalBehavior)
		{
			if (externalBehavior != null)
			{
				string name = externalBehavior.name;
				if (_pools.TryGetValue(name, out var value) && value.Used.Contains(externalBehavior))
				{
					value.Free.Add(externalBehavior);
					value.Used.Remove(externalBehavior);
				}
			}
		}

		public void DebugGUI()
		{
			if (!DebugVars.ShowBehaviourTreePool.Value)
			{
				return;
			}
			string empty = string.Empty;
			if (_debugGUIStyle == null)
			{
				_debugGUIStyle = new GUIStyle(GUI.skin.box)
				{
					alignment = TextAnchor.UpperLeft,
					font = Font.CreateDynamicFontFromOSFont("Courier New", 12),
					fontStyle = FontStyle.Bold
				};
			}
			empty += "Behaviour Tree Pool\n";
			empty += $"\nNum Ticking: {_tick.Count}\n";
			foreach (KeyValuePair<string, Pool> pool in _pools)
			{
				empty += $"\n{pool.Key,64} Used: {pool.Value.Used.Count,3} Free: {pool.Value.Free.Count,3}";
			}
			Vector2 vector = _debugGUIStyle.CalcSize(new GUIContent(empty));
			GUI.Box(new Rect(0f, 0f, vector.x, vector.y), empty, _debugGUIStyle);
		}

		public void Tick()
		{
			if (DebugVars.EnableBehaviourTreeTickSlicing.Value)
			{
				int num = _lastProcessed;
				int i = 0;
				int num2 = Mathf.Min(10, _tick.Count);
				if (num >= _tick.Count)
				{
					num = 0;
				}
				for (; i < num2; i++)
				{
					BehaviorManager.instance.Tick(_tick[num]);
					num++;
					if (num >= _tick.Count)
					{
						num = 0;
					}
				}
				_lastProcessed = num;
			}
			else
			{
				for (int num3 = _tick.Count - 1; num3 >= 0; num3--)
				{
					BehaviorManager.instance.Tick(_tick[num3]);
				}
			}
		}
	}
}
