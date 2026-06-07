using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12WidgetBucket : MonoBehaviour
	{
		[SerializeField]
		private T12WidgetEntrance _entrance;

		private ActiveWorldFrame _parent;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			T7FuelRodItem component = collision.GetComponent<T7FuelRodItem>();
			if ((bool)component && component.Contained.Identifier.EndsWith("widget"))
			{
				UISounds.CraftStep();
				_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			}
			else
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T12WidgetAmalgamationWarning");
				_entrance.Delay(2f);
			}
			Object.Destroy(collision.gameObject);
		}
	}
}
