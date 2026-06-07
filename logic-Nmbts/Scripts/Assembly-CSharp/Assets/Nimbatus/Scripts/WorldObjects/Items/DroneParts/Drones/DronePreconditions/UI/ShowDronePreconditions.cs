using System.Collections.Generic;
using Assets.Nimbatus.GUI.DroneSelection.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions.UI
{
	public class ShowDronePreconditions : SerializedMonoBehaviour
	{
		public NGUIText.Alignment Alignment;

		public bool CheckContiniously;

		public DronePreconditionUI Prefab;

		public UIGrid Grid;

		private DroneData _item;

		public UILabel Title;

		public void Init(DroneData drone)
		{
			if (DroneSelectionManager.HideLaunchButton && GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial == null)
			{
				Title.text = "";
				base.gameObject.SetActive(false);
			}
			else
			{
				_item = drone;
				Fillup();
			}
		}

		public void Start()
		{
			Fillup();
		}

		public void Fillup()
		{
			Grid.transform.DestroyAllChildren();
			List<DronePrecondition> preconditions = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions();
			Title.text = "";
			if (preconditions != null)
			{
				foreach (DronePrecondition item in preconditions)
				{
					DronePreconditionUI dronePreconditionUI = Object.Instantiate(Prefab);
					dronePreconditionUI.transform.position = Grid.transform.position;
					dronePreconditionUI.transform.parent = Grid.transform;
					dronePreconditionUI.transform.localScale = Prefab.transform.localScale;
					dronePreconditionUI.Init(item, _item, CheckContiniously, Alignment);
				}
				if (preconditions.Count > 0)
				{
					Title.text = LocalizationManager.GetTermTranslation("DroneHangar/Requirements");
				}
			}
			Grid.repositionNow = true;
		}
	}
}
