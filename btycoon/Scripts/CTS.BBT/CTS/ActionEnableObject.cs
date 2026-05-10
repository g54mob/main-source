using UnityEngine;

namespace CTS
{
	public class ActionEnableObject : InstantAction
	{
		[SerializeField]
		private Object _obj;

		[SerializeField]
		private bool _setActive = true;

		protected override bool PlayAction(ActionSequence sequence)
		{
			if (_obj is GameObject gameObject)
			{
				gameObject.SetActive(_setActive);
			}
			else if (_obj is MonoBehaviour monoBehaviour)
			{
				monoBehaviour.enabled = _setActive;
			}
			return true;
		}
	}
}
