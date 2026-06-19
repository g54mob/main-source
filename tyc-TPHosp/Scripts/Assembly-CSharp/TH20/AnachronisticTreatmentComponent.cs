using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AnachronisticTreatmentComponent : EntityTickComponent
	{
		private IllnessEraType _eraType;

		public IllnessEraType EraType => _eraType;

		public bool Cured { get; private set; }

		public bool ReceivedDiagnosis { get; private set; }

		public bool SentHome { get; private set; }

		public void Setup(IllnessEraType eraType)
		{
			_eraType = eraType;
			RegisterEvents();
		}

		public override void Tick()
		{
			base.Tick();
		}

		public override void LateTick()
		{
			base.LateTick();
		}

		public bool GetAnachronisticPatient(ref Patient retAnachronisticPatient)
		{
			retAnachronisticPatient = GetOwner() as Patient;
			return retAnachronisticPatient != null;
		}

		public bool GetAnachronisticPatientAndManager(ref Patient retAnachronisticPatient, ref AnachronisticManager retAnachronisticManager)
		{
			bool result = false;
			retAnachronisticPatient = GetOwner() as Patient;
			if (retAnachronisticPatient != null)
			{
				retAnachronisticManager = retAnachronisticPatient.Level.CharacterManager.GetAnachronisticManager();
				if (retAnachronisticManager != null)
				{
					result = true;
				}
			}
			return result;
		}

		public bool IsSentHome()
		{
			if (SentHome)
			{
				return true;
			}
			Patient retAnachronisticPatient = null;
			if (GetAnachronisticPatient(ref retAnachronisticPatient) && ((retAnachronisticPatient.GoingToRoom != null) ? retAnachronisticPatient.GoingToRoom.Definition._type : retAnachronisticPatient.WaitingForRoom) == RoomDefinition.Type.TimeTunnel)
			{
				return true;
			}
			return false;
		}

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

		private void RegisterEvents()
		{
			Patient retAnachronisticPatient = null;
			if (GetAnachronisticPatient(ref retAnachronisticPatient))
			{
				CharacterEvents characterEvents = retAnachronisticPatient.Level.CharacterEvents;
				characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				CharacterEvents characterEvents2 = retAnachronisticPatient.Level.CharacterEvents;
				characterEvents2.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents2.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
				CharacterEvents characterEvents3 = retAnachronisticPatient.Level.CharacterEvents;
				characterEvents3.OnPatientSendHomeRequested = (Action<Patient>)Delegate.Combine(characterEvents3.OnPatientSendHomeRequested, new Action<Patient>(OnPatientSentHome));
				CharacterEvents characterEvents4 = retAnachronisticPatient.Level.CharacterEvents;
				characterEvents4.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents4.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			}
		}

		private void UnRegisterEvents()
		{
			Patient retAnachronisticPatient = null;
			if (GetAnachronisticPatient(ref retAnachronisticPatient))
			{
				CharacterEvents characterEvents = retAnachronisticPatient.Level.CharacterEvents;
				characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
				CharacterEvents characterEvents2 = retAnachronisticPatient.Level.CharacterEvents;
				characterEvents2.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Remove(characterEvents2.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
				CharacterEvents characterEvents3 = retAnachronisticPatient.Level.CharacterEvents;
				characterEvents3.OnPatientSendHomeRequested = (Action<Patient>)Delegate.Remove(characterEvents3.OnPatientSendHomeRequested, new Action<Patient>(OnPatientSentHome));
				CharacterEvents characterEvents4 = retAnachronisticPatient.Level.CharacterEvents;
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
