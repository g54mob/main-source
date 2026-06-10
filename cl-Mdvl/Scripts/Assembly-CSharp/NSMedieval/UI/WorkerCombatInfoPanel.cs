using System.Collections.Generic;
using NSEipix.View.UI;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace NSMedieval.UI
{
	public class WorkerCombatInfoPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private LayoutGroupView workerSkillGroup;

		[SerializeField]
		private LayoutGroupItemView buttonTemplate;

		private List<FillBarLayoutItemView> elements = new List<FillBarLayoutItemView>();

		protected override void SetupTabPanel()
		{
			InitalizeWorkerSkills();
		}

		protected override void UpdateTabPanel()
		{
			InitalizeWorkerSkills();
		}

		private void InitalizeWorkerSkills()
		{
			elements.Clear();
			foreach (Transform item in workerSkillGroup.gameObject.transform)
			{
				Object.Destroy(item.gameObject);
			}
			List<string> infos = new List<string>();
			base.Humanoid.GetAgentView<WorkerView>().AddEffectors(ref infos);
			for (int i = 0; i < 11 + infos.Count; i++)
			{
				elements.Add(CreateListEmenet());
			}
			base.Humanoid.GetEquipment().Find((EquipmentInstance item) => item.Blueprint.ItemType == ItemType.Armor && (item.Blueprint.EquipmentSlots & EquipmentSlotType.LeftHand) != 0);
			for (int num = 0; num < infos.Count; num++)
			{
				elements[num].GetComponent<TextMeshProUGUI>().text = infos[num];
			}
			elements[infos.Count].GetComponent<TextMeshProUGUI>().text = "----------";
			elements[infos.Count + 1].GetComponent<TextMeshProUGUI>().text = "Is wounded: " + base.Humanoid.IsWounded;
			elements[infos.Count + 2].GetComponent<TextMeshProUGUI>().text = "Ready for wound treatment: " + base.Humanoid.CanReceiveWoundTreatment;
		}

		private FillBarLayoutItemView CreateListEmenet()
		{
			FillBarLayoutItemView obj = Object.Instantiate(workerSkillGroup.Prefab, Vector3.zero, Quaternion.identity, workerSkillGroup.gameObject.transform) as FillBarLayoutItemView;
			obj.GetComponent<TextMeshProUGUI>().text = string.Empty;
			return obj;
		}

		private void CreateButton(string text, UnityAction onClick)
		{
			LayoutGroupItemView layoutGroupItemView = Object.Instantiate(buttonTemplate, Vector3.zero, Quaternion.identity, workerSkillGroup.gameObject.transform);
			layoutGroupItemView.GetComponentInChildren<SoundButton>().onClick.AddListener(onClick);
			layoutGroupItemView.GetComponentInChildren<TextMeshProUGUI>().text = text;
		}
	}
}
