using System;
using System.Collections.Generic;
using CTS.AI;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.BBT
{
	[Serializable]
	public class ContextActorData
	{
		[SerializeField]
		public SerializableDictionary<EInteractionKey, MoveTarget[]> InteractionTargets = new SerializableDictionary<EInteractionKey, MoveTarget[]>();

		private readonly List<WorkerChore> _associatedChores = new List<WorkerChore>();

		private static NavMeshPath _dummyPath;

		private static readonly SortedList<float, MoveTarget> _tempList = new SortedList<float, MoveTarget>();

		public ListEnumerator<WorkerChore> AssociatedChores => new ListEnumerator<WorkerChore>(_associatedChores);

		public int ChoresCount => _associatedChores.Count;

		public bool HasInteractionTarget(EInteractionKey p_key)
		{
			return InteractionTargets.ContainsKey(p_key);
		}

		public bool TryGetInteractionTarget(EInteractionKey p_key, Vector3 p_position, out MoveTarget p_target)
		{
			p_target = null;
			if (!InteractionTargets.ContainsKey(p_key))
			{
				Debug.LogError($"Context actor doesn't have any interaction point called {p_key}");
				return false;
			}
			switch (InteractionTargets[p_key].Length)
			{
			case 0:
				p_target = null;
				break;
			case 1:
				p_target = InteractionTargets[p_key][0];
				break;
			default:
				p_target = InteractionTargets[p_key].GetNearest(p_position.ToHorizontal2D(), MoveTarget.Available);
				break;
			}
			return p_target;
		}

		public bool TryGetAvailableInteractionTarget(EInteractionKey p_key, Vector3 p_position, out MoveTarget outTarget)
		{
			outTarget = null;
			if (!InteractionTargets.ContainsKey(p_key))
			{
				Debug.LogError($"Context actor doesn't have any interaction point called {p_key}");
				return false;
			}
			if (_dummyPath == null)
			{
				_dummyPath = new NavMeshPath();
			}
			NavMeshHit hit;
			PathLocker component;
			switch (InteractionTargets[p_key].Length)
			{
			case 0:
				outTarget = null;
				break;
			case 1:
				outTarget = InteractionTargets[p_key][0];
				if (!NavMesh.SamplePosition(p_position, out hit, 1f, AgentsMover.AllAreas))
				{
					return false;
				}
				NavMesh.CalculatePath(hit.position, outTarget.Position, AgentsMover.AllAreas, _dummyPath);
				if (_dummyPath.status != NavMeshPathStatus.PathComplete && outTarget.TryGetComponent<PathLocker>(out component))
				{
					component.SetUnpathable();
					return false;
				}
				break;
			default:
			{
				_tempList.Clear();
				MoveTarget[] array = InteractionTargets[p_key];
				foreach (MoveTarget moveTarget in array)
				{
					float key = Vector3.SqrMagnitude(moveTarget.Position - p_position);
					_tempList.TryAdd(key, moveTarget);
				}
				if (!NavMesh.SamplePosition(p_position, out hit, 1f, AgentsMover.AllAreas))
				{
					return false;
				}
				foreach (MoveTarget value in _tempList.Values)
				{
					NavMesh.CalculatePath(hit.position, value.Position, AgentsMover.AllAreas, _dummyPath);
					if (_dummyPath.status == NavMeshPathStatus.PathComplete)
					{
						outTarget = value;
						break;
					}
					if (value.TryGetComponent<PathLocker>(out component))
					{
						component.SetUnpathable();
					}
				}
				break;
			}
			}
			return outTarget;
		}

		public MoveTarget GetInteractionTarget(EInteractionKey key, Vector3 pos)
		{
			if (!InteractionTargets.ContainsKey(key))
			{
				Debug.LogError($"Context actor doesn't have any interaction point called {key}");
				return null;
			}
			return InteractionTargets[key].Length switch
			{
				0 => null, 
				1 => InteractionTargets[key][0], 
				_ => InteractionTargets[key].GetNearest(pos.ToHorizontal2D()), 
			};
		}

		public bool AreInteractionTargetsAvailable(EInteractionKey key, Agent agent)
		{
			if (!InteractionTargets.ContainsKey(key))
			{
				return false;
			}
			MoveTarget[] array = InteractionTargets[key];
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].IsAvailable(agent))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryGetChore<TChore>(out TChore outChore)
		{
			foreach (WorkerChore associatedChore in _associatedChores)
			{
				if (associatedChore is TChore val)
				{
					outChore = val;
					return true;
				}
			}
			outChore = default(TChore);
			return false;
		}

		public bool TryGetChore<TChore>(out TChore outChore, Func<TChore, bool> filter) where TChore : WorkerChore
		{
			foreach (WorkerChore associatedChore in _associatedChores)
			{
				if (associatedChore is TChore val && filter(val))
				{
					outChore = val;
					return true;
				}
			}
			outChore = null;
			return false;
		}

		public bool TryGetChore<TChore, TArg>(out TChore outChore, Func<TChore, TArg, bool> filter, TArg arg) where TChore : WorkerChore
		{
			foreach (WorkerChore associatedChore in _associatedChores)
			{
				if (associatedChore is TChore val && filter(val, arg))
				{
					outChore = val;
					return true;
				}
			}
			outChore = null;
			return false;
		}

		public void AddChore(WorkerChore p_chore)
		{
			Remove(p_chore);
			_associatedChores.Add(p_chore);
		}

		public void Remove(WorkerChore p_chore)
		{
			_associatedChores.Remove(p_chore);
		}

		public void ClearAssociatedChores()
		{
			while (ChoresCount > 0)
			{
				_associatedChores[0].DestroyChore();
			}
		}
	}
}
