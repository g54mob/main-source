using UnityEngine;

namespace Controllers
{
	public interface IMouseUIElement
	{
		void OnMouseUIDown();

		void OnMouseUIUp(Vector3 position);

		void OnMouseUIRollOver();

		void OnMouseUIRollOut();

		bool IntersectsPoint(Vector3 world_point);
	}
}
