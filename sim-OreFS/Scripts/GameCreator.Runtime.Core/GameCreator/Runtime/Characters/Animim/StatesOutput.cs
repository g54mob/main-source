using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Playables;

namespace GameCreator.Runtime.Characters.Animim
{
	public class StatesOutput : TAnimimOutput
	{
		[NonSerialized]
		private readonly SortedList<int, List<StatePlayableBehaviour>> m_Layers;

		internal override float RootMotion
		{
			get
			{
				float num = 0f;
				foreach (KeyValuePair<int, List<StatePlayableBehaviour>> layer in m_Layers)
				{
					foreach (StatePlayableBehaviour item in layer.Value)
					{
						num = Math.Max(num, item.RootMotion);
					}
				}
				return num;
			}
		}

		public StatesOutput(AnimimGraph animimGraph)
			: base(animimGraph)
		{
			m_Layers = new SortedList<int, List<StatePlayableBehaviour>>();
		}

		public StatesOutput()
			: base(null)
		{
			m_Layers = new SortedList<int, List<StatePlayableBehaviour>>();
		}

		public bool IsAvailable(int layer)
		{
			if (!m_Layers.ContainsKey(layer))
			{
				return true;
			}
			if (m_Layers.TryGetValue(layer, out var value))
			{
				return value.Count == 0;
			}
			return true;
		}

		public async Task SetState(StateData stateData, int layer, BlendMode blendMode, ConfigState config)
		{
			switch (stateData.Type)
			{
			case StateData.StateType.AnimationClip:
				await SetState(stateData.GetAnimationClip(m_AnimimGraph.Character.Args), stateData.AvatarMask, layer, blendMode, config);
				break;
			case StateData.StateType.RuntimeController:
				await SetState(stateData.RuntimeController, stateData.AvatarMask, layer, blendMode, config);
				break;
			case StateData.StateType.State:
				await SetState(stateData.State, layer, blendMode, config);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public Task SetState(AnimationClip animationClip, AvatarMask avatarMask, int layer, BlendMode blendMode, ConfigState config)
		{
			StatePlayableBehaviour template = new StatePlayableBehaviour(animationClip, avatarMask, layer, blendMode, m_AnimimGraph, config);
			ScriptPlayable<StatePlayableBehaviour> statePlayable = ScriptPlayable<StatePlayableBehaviour>.Create(m_AnimimGraph.Graph, template, 1);
			SetPlayable(ref statePlayable, layer, config);
			RunStateChange();
			return TAnimimOutput.TASK_COMPLETE;
		}

		public Task SetState(RuntimeAnimatorController rtc, AvatarMask avatarMask, int layer, BlendMode blendMode, ConfigState config)
		{
			StatePlayableBehaviour template = new StatePlayableBehaviour(rtc, avatarMask, layer, blendMode, m_AnimimGraph, config);
			ScriptPlayable<StatePlayableBehaviour> statePlayable = ScriptPlayable<StatePlayableBehaviour>.Create(m_AnimimGraph.Graph, template, 1);
			SetPlayable(ref statePlayable, layer, config);
			RunStateChange();
			return TAnimimOutput.TASK_COMPLETE;
		}

		public async Task SetState(State state, int layer, BlendMode blendMode, ConfigState config)
		{
			StatePlayableBehaviour template = new StatePlayableBehaviour(state, layer, blendMode, m_AnimimGraph, config);
			ScriptPlayable<StatePlayableBehaviour> statePlayable = ScriptPlayable<StatePlayableBehaviour>.Create(m_AnimimGraph.Graph, template, 1);
			StatePlayableBehaviour behavior = SetPlayable(ref statePlayable, layer, config);
			RunStateChange();
			while (!behavior.IsComplete && !ApplicationManager.IsExiting)
			{
				await Task.Yield();
			}
		}

		public void Stop(int layer, float delay, float transitionOut)
		{
			StopPlayable(layer, delay, transitionOut);
			RunStateChange();
		}

		public void ChangeWeight(int layer, float weight, float transition)
		{
			if (m_Layers.TryGetValue(layer, out var value))
			{
				int count = value.Count;
				if (count != 0)
				{
					value[count - 1].ChangeWeight(weight, transition);
				}
			}
		}

		private StatePlayableBehaviour SetPlayable(ref ScriptPlayable<StatePlayableBehaviour> statePlayable, int layer, ConfigState config)
		{
			StopPlayable(layer, config.DelayIn + config.TransitionIn, 0.01f);
			int num = -1;
			using (IEnumerator<KeyValuePair<int, List<StatePlayableBehaviour>>> enumerator = m_Layers.GetEnumerator())
			{
				while (enumerator.MoveNext() && enumerator.Current.Key <= layer)
				{
					num++;
				}
			}
			Playable playable;
			Playable sourcePlayable;
			if (m_Layers.Count == 0)
			{
				playable = base.ScriptPlayable;
				sourcePlayable = base.ScriptPlayable.GetInput(0);
				base.ScriptPlayable.DisconnectInput(0);
			}
			else if (num < 0)
			{
				int key = m_Layers.Keys[0];
				int index = m_Layers[key].Count - 1;
				StatePlayableBehaviour statePlayableBehaviour = m_Layers[key][index];
				playable = statePlayableBehaviour.mixerPlayable;
				sourcePlayable = statePlayableBehaviour.mixerPlayable.GetInput(0);
				statePlayableBehaviour.mixerPlayable.DisconnectInput(0);
			}
			else
			{
				int key2 = m_Layers.Keys[num];
				int index2 = m_Layers[key2].Count - 1;
				StatePlayableBehaviour statePlayableBehaviour2 = m_Layers[key2][index2];
				playable = statePlayableBehaviour2.scriptPlayable.GetOutput(0);
				sourcePlayable = statePlayableBehaviour2.scriptPlayable;
				statePlayableBehaviour2.scriptPlayable.GetOutput(0).DisconnectInput(0);
			}
			statePlayable.ConnectInput(0, sourcePlayable, 0);
			statePlayable.SetInputWeight(0, 1f);
			playable.ConnectInput(0, statePlayable, 0);
			playable.SetInputWeight(0, 1f);
			StatePlayableBehaviour behaviour = statePlayable.GetBehaviour();
			if (!m_Layers.ContainsKey(layer))
			{
				m_Layers.Add(layer, new List<StatePlayableBehaviour>());
			}
			m_Layers[layer].Add(behaviour);
			behaviour.Create(this);
			return behaviour;
		}

		private void StopPlayable(int layer, float delay, float transitionOut)
		{
			if (!m_Layers.TryGetValue(layer, out var value))
			{
				return;
			}
			foreach (StatePlayableBehaviour item in value)
			{
				item.Stop(delay, transitionOut);
			}
		}

		private void RunStateChange()
		{
			Args args = new Args(m_AnimimGraph.Character);
			foreach (KeyValuePair<int, List<StatePlayableBehaviour>> layer in m_Layers)
			{
				int num = layer.Value.Count - 1;
				if (num >= 0)
				{
					StatePlayableBehaviour statePlayableBehaviour = layer.Value[num];
					if (!statePlayableBehaviour.IsExiting && !(statePlayableBehaviour.State == null))
					{
						statePlayableBehaviour.State.RunChange(args);
					}
				}
			}
		}

		internal override void OnDeleteChild(TAnimimPlayableBehaviour playableBehaviour)
		{
			if (playableBehaviour is StatePlayableBehaviour { Layer: var layer } statePlayableBehaviour && m_Layers.TryGetValue(layer, out var value))
			{
				value.Remove(statePlayableBehaviour);
				if (value.Count == 0)
				{
					m_Layers.Remove(layer);
				}
			}
		}
	}
}
