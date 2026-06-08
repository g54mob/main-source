using UnityEngine;

namespace Kitchen
{
	public class SnapToCorner : MonoBehaviour
	{
		public Vector2 ScreenSpacePosition;

		private void Update()
		{
			if (!(Session.GameCreator == null) && !(Session.GameCreator.UICamera == null))
			{
				base.transform.localPosition = ViewHelpers.ScaleToBounds(ViewHelpers.GetOrthoCameraBounds(Session.GameCreator.UICamera), ScreenSpacePosition);
			}
		}
	}
}
