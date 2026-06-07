using Assets.Source.Player;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T7FuelRodHatch : MonoBehaviour
	{
		[SerializeField]
		private T7FuelRodItem _itemPrefab;

		private ActiveWorldFrame _frame;

		private void Start()
		{
			_frame = GetComponentInParent<ActiveWorldFrame>();
		}

		public void SpawnItem()
		{
			if (GamePlayer.Current.GetInventoryCount("uranium") == 0L)
			{
				_frame.ShowNeedItem(new WorldAnchor(WorldAnchorType.Custom, 0), "uranium", 1);
				return;
			}
			UISounds.CraftStep();
			Object.Instantiate(_itemPrefab, base.transform.position, Quaternion.Euler(0f, 0f, SeededRandom.Global.RandomRange(0, 360)), _frame.transform);
		}
	}
}
