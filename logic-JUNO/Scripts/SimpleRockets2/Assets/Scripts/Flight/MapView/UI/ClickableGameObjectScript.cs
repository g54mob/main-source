using UnityEngine;

namespace Assets.Scripts.Flight.MapView.UI
{
	public class ClickableGameObjectScript : MonoBehaviour
	{
		[SerializeField]
		private bool _selectable = true;

		public bool Selectable
		{
			get
			{
				return _selectable;
			}
			set
			{
				_selectable = value;
			}
		}
	}
}
