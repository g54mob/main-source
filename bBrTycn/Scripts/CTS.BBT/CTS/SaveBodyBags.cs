using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core.Pooling;
using UnityEngine;

namespace CTS
{
	public class SaveBodyBags : SaveStaticGameObjectSaverSet<BodyBag>
	{
		[SerializeField]
		private BodyBag _prefab;

		public static HashSet<Customer> LinkedCustomers { get; } = new HashSet<Customer>();

		public override bool CanObjectBeSaved(BodyBag obj)
		{
			if (!obj.Initialized)
			{
				return false;
			}
			return base.CanObjectBeSaved(obj);
		}

		public override void LoadInit(ES3Settings settings)
		{
			LinkedCustomers.Clear();
			base.LoadInit(settings);
		}

		protected override BodyBag InstantiateSingle(string saveKey, ES3Settings settings)
		{
			return Pooler.Pull(_prefab);
		}

		protected override void LoadIntoSingle(string saveKey, BodyBag obj, ES3Settings settings)
		{
			base.LoadIntoSingle(saveKey, obj, settings);
			obj.gameObject.SetActive(value: true);
		}

		protected override void OnAllLoaded()
		{
			base.OnAllLoaded();
			foreach (var loadedObject in base.loadedObjects)
			{
				BodyBag item = loadedObject.Item2;
				item.CreateBodyBagCleaningChore(item.CurrentChoreType != EDeathChore.BodyBagSewer);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			base.LoadPost(settings);
			foreach (Customer linkedCustomer in LinkedCustomers)
			{
				linkedCustomer.ClearObject();
			}
			LinkedCustomers.Clear();
		}
	}
}
