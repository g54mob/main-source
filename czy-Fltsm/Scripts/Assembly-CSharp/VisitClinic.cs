using System.Collections;
using PajamaLlama.Fltsm;
using UnityEngine;

public class VisitClinic : TaskBase
{
	[SerializeField]
	private Activity _queueActivity = Activity.Sitting;

	[SerializeField]
	private Activity _consultActivity;

	public override TaskType Type => TaskType.VisitClinic;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Pollution pollution = agent.Vitals.Pollution;
		Disease disease = pollution.CurrentDisease;
		if (!TryReturnAvailableClinic(out var clinic))
		{
			yield break;
		}
		clinic.TakeAppointment(agent);
		yield return MoveAgentCoroutine(clinic.Obstalce);
		while (clinic.IsBusy())
		{
			agent.UpdateActivity(_queueActivity);
			yield return null;
		}
		if (clinic.Enter(agent))
		{
			agent.UpdateActivity(_consultActivity);
			while (!clinic.IsDiagnosed(agent))
			{
				yield return null;
			}
			pollution.CurrentDiseaseDiagnosed = true;
			Item medicine = ((0 < project.GeneralItems.Count) ? project.GeneralItems[0] : agent.Community.Inventory.ReturnItem(disease.Medication, SubInventoryType.Storage));
			if (medicine != null)
			{
				agent.UpdateActivity(disease.MedicationActivity);
				yield return new WaitForSeconds(disease.MedicationDuration);
				medicine.Inventory.TakeItem(medicine);
				medicine.Inventory = null;
				new AgentItemPropertiesEvent(GameEventType.AgentMedicated, _agent, medicine.Properties).Dispatch();
				project.RemoveAllGeneralItems();
				disease.FinishDisease(agent);
				pollution.Decrease(pollution.Level);
			}
		}
	}

	private void TakeMedication(Item medicine)
	{
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		if (TryReturnAvailableClinic(out var _))
		{
			return ProjectBlocker.None;
		}
		return ProjectBlocker.NoClinicAvailable;
	}

	protected override void OnGUI()
	{
		Header("Visit a Clinic", 2, Color.green);
		EditorGUI_PropertyField("_queueActivity");
		EditorGUI_PropertyField("_consultActivity");
		EditorGUI_HelpBox("Wait at a clinic to get a disease diagnosed.");
	}

	private bool TryReturnAvailableClinic(out Clinic clinic)
	{
		foreach (Buildable buildable in Community.PlayerCommunity.Buildables)
		{
			if (buildable.TryReturnBuildableExtendable<Clinic>(out clinic) && (bool)clinic.Doctor)
			{
				return true;
			}
		}
		clinic = null;
		return false;
	}
}
