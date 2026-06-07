using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions.UI
{
	public class HideIfNoPreconditions : SerializedMonoBehaviour
	{
		public void Start()
		{
			List<DronePrecondition> preconditions = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions();
			if (preconditions == null || preconditions.Count < 1)
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
