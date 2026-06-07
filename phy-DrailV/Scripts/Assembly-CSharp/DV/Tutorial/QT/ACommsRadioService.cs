using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public abstract class ACommsRadioService<T> : ATutorialService where T : class, ICommsRadioMode
	{
		public CommsRadioController CommsRadio { get; private set; }

		public T Mode { get; private set; }

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			CommsRadio = null;
			Mode = null;
			GameObject[] itemsArray = SingletonBehaviour<Inventory>.Instance.GetItemsArray();
			foreach (GameObject gameObject in itemsArray)
			{
				if (gameObject != null)
				{
					CommsRadioController commsRadioController = (CommsRadio = gameObject.GetComponent<CommsRadioController>());
					if ((bool)commsRadioController)
					{
						break;
					}
				}
			}
			if ((bool)CommsRadio)
			{
				Mode = CommsRadio.GetComponentInChildren<T>();
			}
		}
	}
}
