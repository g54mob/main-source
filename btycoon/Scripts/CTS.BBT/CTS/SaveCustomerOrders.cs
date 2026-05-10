using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Pooling;
using UnityEngine;

namespace CTS
{
	public class SaveCustomerOrders : SaveStaticGameObjectSaverSet<Drink>
	{
		[SerializeField]
		private Drink _drinkPrefab;

		public override bool CanObjectBeSaved(Drink obj)
		{
			return !(obj.CurrentHolder is Worker);
		}

		public override void LoadInit(ES3Settings settings)
		{
			StaticObjectSet<GroupOrder>.Clear();
			base.LoadInit(settings);
		}

		protected override Drink InstantiateSingle(string saveKey, ES3Settings settings)
		{
			return Pooler.Pull(_drinkPrefab);
		}

		protected override void LoadIntoSingle(string saveKey, Drink obj, ES3Settings settings)
		{
			base.LoadIntoSingle(saveKey, obj, settings);
			obj.gameObject.SetActive(value: true);
		}

		protected override void OnAllLoaded()
		{
			base.OnAllLoaded();
			foreach (var loadedObject in base.loadedObjects)
			{
				loadedObject.Item2.UpdateMeshes();
			}
			foreach (GroupOrder item in StaticObjectSet<GroupOrder>.List)
			{
				item.RecalculateStatus();
				switch (item.Status)
				{
				case CustomerOrder.EStatus.WaitingToOrder:
					item.CreateOrderChore();
					break;
				case CustomerOrder.EStatus.Ordered:
					item.CreatePreparationChores();
					break;
				case CustomerOrder.EStatus.Prepared:
					item.CreateDeliveryChores();
					break;
				default:
					throw new ArgumentOutOfRangeException();
				case CustomerOrder.EStatus.Delivered:
					break;
				}
			}
			StaticObjectSet<GroupOrder>.Clear();
		}
	}
}
