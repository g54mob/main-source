using System.Collections;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions.UI
{
	public class DronePreconditionUI : SerializedMonoBehaviour
	{
		public UILabel Label;

		private DronePrecondition _precondition;

		private DroneData _item;

		private bool _checkContinuously;

		public void Start()
		{
			StartCoroutine(CheckPrecondition());
		}

		public void Init(DronePrecondition precondition, DroneData item, bool checkContinuously, NGUIText.Alignment alignment)
		{
			_item = item;
			_precondition = precondition;
			_checkContinuously = checkContinuously;
			Label.alignment = alignment;
		}

		private IEnumerator CheckPrecondition()
		{
			while (true)
			{
				if (_precondition != null)
				{
					bool status;
					if (_item == null && DronePartManager.Instance != null && DronePartManager.Instance.ActiveDrone != null)
					{
						Label.text = _precondition.GetStatus(DronePartManager.Instance.ActiveDrone, out status);
					}
					else if (_item != null)
					{
						Label.text = _precondition.GetStatus(_item, out status);
					}
					else
					{
						Label.text = "";
					}
				}
				if (_checkContinuously)
				{
					yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
					continue;
				}
				break;
			}
		}
	}
}
