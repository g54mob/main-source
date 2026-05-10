using UnityEngine;

namespace CTS
{
	public class MapDetectionMouse : MonoBehaviour
	{
		[SerializeField]
		private MapSelection _parentMapScript;

		private void OnMouseEnter()
		{
			if (!(_parentMapScript == null) && _parentMapScript.CanBeSelected() && !_parentMapScript.ManagerScript.SomethingIsSelected && !_parentMapScript.IsSelected())
			{
				_parentMapScript.Selection();
			}
		}

		private void OnMouseExit()
		{
			if (!(_parentMapScript == null) && _parentMapScript.CanBeSelected() && !_parentMapScript.ManagerScript.SomethingIsSelected && !_parentMapScript.IsSelected())
			{
				_parentMapScript.Deselection();
			}
		}

		private void OnMouseDown()
		{
			if (!(_parentMapScript == null) && _parentMapScript.CanBeSelected() && !_parentMapScript.ManagerScript.SomethingIsSelected && !_parentMapScript.IsSelected())
			{
				_parentMapScript.UserClick();
			}
		}
	}
}
