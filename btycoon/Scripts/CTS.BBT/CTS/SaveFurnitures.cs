using System;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SaveFurnitures : SaveStaticGameObjectSaverSet<Furniture>
	{
		public override void LoadPost(ES3Settings settings)
		{
			base.LoadPost(settings);
			if (CTSSingleton<LevelParameters>.TryGetInstance(out var outInstance))
			{
				outInstance.Furnitures.ClearNullFurnitures();
			}
		}

		public override bool CanObjectBeSaved(Furniture obj)
		{
			if (!obj.Controller.IsPlaced)
			{
				return false;
			}
			if ((bool)obj.Controller.CurrentSlot && !obj.Controller.CurrentSlot.FurnitureController.IsPlaced)
			{
				return false;
			}
			return base.CanObjectBeSaved(obj);
		}

		protected override void SaveSingle(string saveKey, Furniture obj, ES3Settings settings)
		{
			try
			{
				SaveContainer.SaveReference(saveKey + "prefab", obj.Parameters, settings);
				base.SaveSingle(saveKey, obj, settings);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected override Furniture InstantiateSingle(string saveKey, ES3Settings settings)
		{
			FurnitureSO furnitureSO = SaveContainer.LoadReference<FurnitureSO>(saveKey + "prefab", settings);
			if (furnitureSO == null)
			{
				return null;
			}
			return CTSFactory.Instantiate(furnitureSO.Prefab, MonoSingleton<ParentFurnitures>.Instance.transform, instantiateInWorldSpace: false, false);
		}

		protected override void LoadIntoSingle(string saveKey, Furniture obj, ES3Settings settings)
		{
			try
			{
				base.LoadIntoSingle(saveKey, obj, settings);
				obj.gameObject.SetActive(value: true);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected override void OnAllLoaded()
		{
			base.OnAllLoaded();
			if (CTSSingleton<BarFurnitures>.TryGetInstance(out var outInstance))
			{
				foreach (var loadedObject in base.loadedObjects)
				{
					Furniture item = loadedObject.Item2;
					outInstance.AddFurniture(item);
				}
			}
			CTSSingleton<BarStyleInfluence>.Instance.ReLoad();
		}
	}
}
