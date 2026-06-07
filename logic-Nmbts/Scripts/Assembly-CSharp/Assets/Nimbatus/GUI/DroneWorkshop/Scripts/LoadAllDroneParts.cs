using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class LoadAllDroneParts : MonoBehaviour
	{
		public EDronePartType SelectedDronePartType;

		public bool ShowTemplates;

		public UIGrid ItemGrid;

		public GameObject ItemPrefab;

		public GameObject TemplateItemPrefab;

		public UIScrollView ItemPanel;

		public void Start()
		{
			ShowTemplates = false;
			FillUp();
		}

		public void FillUp()
		{
			if (!ShowTemplates)
			{
				FillupItems.FillUp(ItemPanel, ItemGrid, ItemPrefab, true, Check);
			}
			else
			{
				FillupItems.FillUpTemplates(ItemPanel, ItemGrid, TemplateItemPrefab);
			}
			ItemPanel.ResetPosition();
		}

		private bool Check(DronePart part)
		{
			if (SelectedDronePartType == EDronePartType.None)
			{
				return !ShowTemplates;
			}
			return part.DronePartType == SelectedDronePartType;
		}
	}
}
