using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(SpawnPoint))]
	public class CustomerSpawn : AgentSpawn<Customer>, IGive<Customer>
	{
		[SerializeField]
		[ShowIf(EConditionOperator.And, new string[] { "IsSpawningAllowed", "IsHuman" })]
		protected bool _startDead;

		[SerializeField]
		[ShowIf(EConditionOperator.And, new string[] { "IsSpawningAllowed", "IsHuman" })]
		private bool _canDetectCrimes = true;

		[SerializeField]
		private CustomerParameters _customerParameters;

		protected override Color GizmoColor
		{
			get
			{
				if (!IsSpawningAllowed())
				{
					return Color.red;
				}
				if (!IsHuman())
				{
					return new Color(0.5f, 0f, 1f);
				}
				return Color.blue;
			}
		}

		private bool IsHuman()
		{
			if ((bool)_customerParameters)
			{
				return !_customerParameters.IsVampire;
			}
			return false;
		}

		protected override bool IsSpawningAllowed()
		{
			return _customerParameters;
		}

		protected override Customer SpawnAgent()
		{
			if (!_customerParameters)
			{
				return null;
			}
			Customer customer;
			if (!_spawnSpecificGender)
			{
				customer = SpawnSpecific();
			}
			else
			{
				CharacterData characterData = _customerParameters.CharacterData;
				characterData.Gender = ((_gender == EGender.Man) ? CTS.EGender.Male : CTS.EGender.Female);
				customer = SpawnSpecific(characterData);
			}
			if (customer == null)
			{
				return null;
			}
			customer.SpawnPoint = CTSSingleton<CustomerSpawner>.Instance.GetClosestSpawnPoint(base.transform.position);
			customer.transform.SetPositionAndRotation(base.transform);
			customer.RoomObject.TryFindCurrentRoom();
			customer.GroupData.CanEnterBar = true;
			if (customer.RoomObject.CurrentRoom != CustomerSpawner.EntranceRoom)
			{
				customer.SetEnterBarTag();
				customer.Selection.Selectable = true;
				if (customer.IsVampire && !_autoSpawn)
				{
					customer.SetVisualActive(value: false);
					customer.ActionPlayer.InsertAction(new AgentActionVampireSpawn(customer.transform.position), AgentActionPlayer.EInsertType.CancelAction, EActionPriority.Forced);
				}
				else
				{
					customer.UpdateLighting(0f);
				}
			}
			customer.AutonomousActions.Paused = _startPaused;
			if (_startDead)
			{
				customer.Health.ForceDeath();
			}
			if (!_canDetectCrimes)
			{
				customer.CrimeWitness.enabled = false;
			}
			if ((bool)customer.RoomObject.CurrentRoom && customer.RoomObject.CurrentRoom.RoomIndex != 0)
			{
				CustomerManager.AddCustomer(customer);
			}
			return customer;
		}

		private Customer SpawnSpecific(CharacterData? characterData = null)
		{
			if (_customerParameters == null)
			{
				return null;
			}
			SpawnPoint component = GetComponent<SpawnPoint>();
			Customer[] array = new Customer[1] { Pooler.Pull(CTSSingleton<CustomerSpawner>.Instance.CurrentCustomerPrefab) };
			CustomerGroups.GetOrCreateGroup().SetMembers(array);
			array[0].Spawn(_customerParameters, component, null, characterData);
			int field = CTSSingleton<CustomerSpawner>.Instance.GetField<int>("_customersSpawned");
			CTSSingleton<CustomerSpawner>.Instance.SetField("_customersSpawned", field + 1);
			return array[0];
		}

		Customer IGive<Customer>.Get()
		{
			return GetSpawned();
		}
	}
}
