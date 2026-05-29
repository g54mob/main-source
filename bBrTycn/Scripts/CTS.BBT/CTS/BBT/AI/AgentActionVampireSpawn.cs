using System;
using System.Collections;
using System.Collections.Generic;
using CTS.AI;
using CTS.Core;
using CTS.Core.Pooling;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace CTS.BBT.AI
{
	public class AgentActionVampireSpawn : AgentAction<Agent>
	{
		private Vector3 _fallbackPosition;

		private Vector3? _spawnPos;

		private static readonly Resource<MonoTimer> SpawnVFXPrefab = new Resource<MonoTimer>("Prefabs/VFX/Pfb_VFX_VampireSpawn");

		private MonoTimer _spawnedVFX;

		private List<NavigationArea> _navigationAreas;

		public static event Action<Agent> VampireSpawning;

		public AgentActionVampireSpawn(Vector3 fallbackPosition, List<NavigationArea> areas)
		{
			_fallbackPosition = fallbackPosition;
			_navigationAreas = areas;
			_spawnPos = null;
		}

		public AgentActionVampireSpawn(Vector3 specificPosition)
		{
			_spawnPos = specificPosition;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public static bool RoomExists(NavigationArea area)
		{
			foreach (BuildingRoomContainer roomManager in MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers)
			{
				foreach (KeyValuePair<int, RoomBuilding> generatedRoom in roomManager.GeneratedRooms)
				{
					generatedRoom.Deconstruct(out var _, out var value);
					if (value.NavArea == area)
					{
						return true;
					}
				}
			}
			return false;
		}

		public override IEnumerator ActionRoutine()
		{
			yield return Coroutines.WaitForSeconds(UnityEngine.Random.Range(0.2f, 1f));
			if (_spawnPos.HasValue && NavMesh.SamplePosition(_spawnPos.Value, out var hit, 1.5f, AgentsMover.AllAreas))
			{
				_spawnPos = hit.position;
			}
			int passCount = 0;
			while (true)
			{
				Vector3? spawnPos = _spawnPos;
				if (!spawnPos.HasValue && passCount < 20)
				{
					yield return null;
					foreach (NavigationArea navigationArea in _navigationAreas)
					{
						foreach (BuildingRoomContainer roomManager in MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers)
						{
							foreach (var (_, roomBuilding2) in roomManager.GeneratedRooms)
							{
								if (!(roomBuilding2.NavArea != navigationArea))
								{
									int index = UnityEngine.Random.Range(0, roomBuilding2.FloorTiles.Count);
									if (NavMesh.SamplePosition(roomBuilding2.FloorTiles[index].transform.position, out var hit2, 0.75f, -1))
									{
										_spawnPos = hit2.position;
										goto end_IL_0242;
									}
								}
							}
						}
						yield return null;
					}
					passCount++;
					continue;
				}
				spawnPos = _spawnPos;
				if (!spawnPos.HasValue)
				{
					_spawnPos = _fallbackPosition;
				}
				break;
				continue;
				end_IL_0242:
				break;
			}
			base.ActionAgent.SetEnterBarTag();
			base.ActionAgent.transform.position = _spawnPos.Value;
			if ((bool)_spawnedVFX)
			{
				_spawnedVFX.OnComplete -= PushVFX;
			}
			_spawnedVFX = Pooler.Pull(SpawnVFXPrefab.Value);
			_spawnedVFX.OnComplete += PushVFX;
			_spawnedVFX.transform.position = _spawnPos.Value;
			if (_spawnedVFX.TryGetComponent<RoomObject>(out var component))
			{
				component.SetParent(base.ActionAgent.RoomObject);
			}
			if (_spawnedVFX.TryGetComponent<VFXBehavior>(out var component2))
			{
				foreach (AgentVisualUpdater item in component2.Updaters<AgentVisualUpdater>())
				{
					item.SetAgent(base.ActionAgent);
				}
			}
			_spawnedVFX.Play();
			yield return Coroutines.WaitForSeconds(0.6f);
			AgentActionVampireSpawn.VampireSpawning?.Invoke(base.ActionAgent);
			yield return Coroutines.WaitForSeconds(0.4f);
			LocalKeyword keyword = AgentVisual.Keyword("EMISSIVE_MASK_ON");
			base.ActionAgent.Material.SetKeyword(in keyword, value: true);
			base.ActionAgent.SetVisualActive(value: true);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.VampireSpawn);
			base.ActionAgent.UpdateLighting(0f);
			base.ActionAgent.Material.SetKeyword(in keyword, value: false);
			base.ActionAgent.Selection.Selectable = true;
			if (base.ActionAgent is Customer p_customer)
			{
				CustomerManager.AddCustomer(p_customer);
			}
			if (base.ActionAgent.TryGetComponent<SituationnalBarks>(out var component3))
			{
				component3.EnterBar();
			}
		}

		private void PushVFX()
		{
			if ((bool)_spawnedVFX)
			{
				_spawnedVFX.OnComplete -= PushVFX;
				Pooler.Push(_spawnedVFX);
			}
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
