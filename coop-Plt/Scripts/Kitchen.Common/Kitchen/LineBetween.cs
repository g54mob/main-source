using Shapes;
using UnityEngine;

namespace Kitchen
{
	public class LineBetween : MonoBehaviour, IViewModifier
	{
		public Line Line;

		public Transform Target1;

		public Transform Target2;

		private void Update()
		{
			Transform parent = Line.transform.parent;
			Line.Start = parent.InverseTransformPoint(Target1.position);
			Line.End = parent.InverseTransformPoint(Target2.position);
		}

		public void UpdateState(ApplianceView.ViewData view_data)
		{
			base.gameObject.SetActive(value: true);
		}
	}
}
