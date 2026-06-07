using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ScaleToDiameter : MonoBehaviour
	{
		public void Start()
		{
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial != null)
			{
				if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.ShowRadius)
				{
					base.transform.localScale = new Vector3(GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.DroneRadius / 10f, GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.DroneRadius / 10f, 1f);
				}
				else
				{
					base.gameObject.SetActive(false);
				}
				return;
			}
			DroneSize droneSize = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions().OfType<DroneSize>().FirstOrDefault();
			if (droneSize != null)
			{
				base.transform.localScale = new Vector3(droneSize.MaxDiameter / 10f, droneSize.MaxDiameter / 10f, 1f);
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
