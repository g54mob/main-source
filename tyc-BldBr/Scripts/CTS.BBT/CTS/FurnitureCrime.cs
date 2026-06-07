using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class FurnitureCrime : Crime
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		protected Furniture _furniture;

		protected override void OnAwake()
		{
			_furniture.Controller.PlacementChanged += OnPlacementChanged;
			OnPlacementChanged(_furniture.Controller.IsPlaced);
		}

		protected virtual void OnDestroy()
		{
			_furniture.Controller.PlacementChanged -= OnPlacementChanged;
		}

		protected virtual void OnPlacementChanged(bool placed)
		{
			base.gameObject.SetActive(placed);
		}
	}
}
