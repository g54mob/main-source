using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowNumberOfDroneParts : MonoBehaviour
	{
		private UILabel _label;

		public void Awake()
		{
			_label = GetComponent<UILabel>();
		}

		public void Update()
		{
			_label.text = DronePartManager.Instance.ActiveNumberOfDroneParts.ToString();
		}
	}
}
