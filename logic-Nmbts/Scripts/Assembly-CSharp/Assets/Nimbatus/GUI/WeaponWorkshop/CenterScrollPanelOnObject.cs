using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop
{
	public class CenterScrollPanelOnObject : MonoBehaviour
	{
		public Transform Center;

		public UIPanel Panel;

		public void OnClick()
		{
			UIScrollView component = Panel.GetComponent<UIScrollView>();
			Vector3 pos = -Panel.cachedTransform.InverseTransformPoint(Center.position);
			if (!component.canMoveHorizontally)
			{
				pos.x = Panel.cachedTransform.localPosition.x;
			}
			if (!component.canMoveVertically)
			{
				pos.y = Panel.cachedTransform.localPosition.y;
			}
			SpringPanel.Begin(Panel.cachedGameObject, pos, 6f);
		}
	}
}
