using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class FurnitureShopMenuButton : InterfaceButton
	{
		[SerializeField]
		private UIFurnitureList _UIFurnitureList;

		public static FurnitureShopMenuButton Instance { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			Instance = this;
		}

		private void Start()
		{
			_UIFurnitureList.GetComponent<CanvasGroupController>().CanvasShowning += MonoSingleton<FurnitureShop>.Instance.SetFurnitureShopOpen;
		}

		private void OnDestroy()
		{
			if (MonoSingleton<FurnitureShop>.InstanceExists())
			{
				_UIFurnitureList.GetComponent<CanvasGroupController>().CanvasShowning -= MonoSingleton<FurnitureShop>.Instance.SetFurnitureShopOpen;
			}
			Instance = null;
		}
	}
}
