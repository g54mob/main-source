using CTS.BBT;
using CTS.Core.Pooling;
using UnityEngine;

namespace CTS
{
	public class SaveOrderPlates : SaveStaticGameObjectSaverSet<OrderPlate>
	{
		[SerializeField]
		private OrderPlate _prefab;

		public override bool CanObjectBeSaved(OrderPlate obj)
		{
			return obj.Drinks.Count > 0;
		}

		protected override OrderPlate InstantiateSingle(string saveKey, ES3Settings settings)
		{
			return Pooler.Pull(_prefab);
		}

		protected override void LoadIntoSingle(string saveKey, OrderPlate obj, ES3Settings settings)
		{
			base.LoadIntoSingle(saveKey, obj, settings);
			obj.gameObject.SetActive(value: true);
		}
	}
}
