using UnityEngine;

namespace Simulator
{
	public class ObjectActivator : MonoBehaviour
	{
		public GameObject CurrentGameObject { get; protected set; }

		public IActivable CurrentActivable { get; protected set; }

		public virtual void Activate(GameObject go)
		{
			DeactivateCurrent();
			CurrentGameObject = go;
			CurrentGameObject.SetActive(value: true);
		}

		public virtual void Activate(IActivable activable)
		{
			DeactivateCurrent();
			CurrentActivable = activable;
			CurrentActivable.SetActive(active: true);
		}

		public virtual void DeactivateCurrent()
		{
			if (CurrentGameObject != null)
			{
				CurrentGameObject.SetActive(value: false);
				CurrentGameObject = null;
			}
			if (CurrentActivable != null)
			{
				CurrentActivable.SetActive(active: false);
				CurrentActivable = null;
			}
		}
	}
}
