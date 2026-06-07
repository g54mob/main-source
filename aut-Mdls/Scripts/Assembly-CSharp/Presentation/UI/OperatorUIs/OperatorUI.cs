using Data.FactoryFloor.Behaviours;
using Presentation.FactoryFloor;
using UnityEngine;

namespace Presentation.UI.OperatorUIs
{
	public class OperatorUI<T> : MonoBehaviour where T : FactoryObjectBehaviour
	{
		protected T _behaviour;

		public bool IsOpen => base.gameObject.activeSelf;

		public virtual void OpenWindow(T behaviour, FactoryObjectView objectView)
		{
			_behaviour = behaviour;
			base.gameObject.SetActive(value: true);
		}

		public virtual void CloseWindow()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
