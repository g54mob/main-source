using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PatientTimePortalComponent : EntityTickComponent
	{
		public bool Cured { get; private set; }

		public bool ReceivedDiagnosis { get; private set; }

		public bool SentHome { get; private set; }

		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RegisterEvents();
		}

		public override void Destroy()
		{
			UnRegisterEvents();
			base.Destroy();
		}

		private bool GetPatient(ref Patient patient)
		{
			patient = GetOwner() as Patient;
			return patient != null;
		}

		private void RegisterEvents()
		{
			Patient patient = null;
			if (GetPatient(ref patient))
			{
				CharacterEvents characterEvents = patient.Level.CharacterEvents;
				characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				CharacterEvents characterEvents2 = patient.Level.CharacterEvents;
				characterEvents2.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents2.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
				CharacterEvents characterEvents3 = patient.Level.CharacterEvents;
				characterEvents3.OnPatientSendHomeRequested = (Action<Patient>)Delegate.Combine(characterEvents3.OnPatientSendHomeRequested, new Action<Patient>(OnPatientSentHome));
				CharacterEvents characterEvents4 = patient.Level.CharacterEvents;
				characterEvents4.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents4.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}
		}

		private void UnRegisterEvents()
		{
			Patient patient = null;
			if (GetPatient(ref patient))
			{
				CharacterEvents characterEvents = patient.Level.CharacterEvents;
				characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				CharacterEvents characterEvents2 = patient.Level.CharacterEvents;
				characterEvents2.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Remove(characterEvents2.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
				CharacterEvents characterEvents3 = patient.Level.CharacterEvents;
				characterEvents3.OnPatientSendHomeRequested = (Action<Patient>)Delegate.Remove(characterEvents3.OnPatientSendHomeRequested, new Action<Patient>(OnPatientSentHome));
				CharacterEvents characterEvents4 = patient.Level.CharacterEvents;
				characterEvents4.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents4.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}
		}

		private void OnPatientCured(Patient patient, List<Staff> staff)
		{
			if (GetOwner() == patient)
			{
				Cured = true;
			}
		}

		private void OnPatientReceivedDiagnosis(Patient patient, Staff staff, Room room, float increment)
		{
			if (GetOwner() == patient)
			{
				ReceivedDiagnosis = true;
			}
		}

		private void OnPatientSentHome(Patient patient)
		{
			if (GetOwner() == patient)
			{
				SentHome = true;
			}
		}
	}
}
