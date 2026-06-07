using FishNet.Object;
using ScheduleOne.Employees;
using ScheduleOne.Interaction;
using UnityEngine;

namespace ScheduleOne.ObjectScripts
{
	public class Bed : NetworkBehaviour
	{
		public const int MIN_SLEEP_TIME = 1800;

		[SerializeField]
		[Header("References")]
		protected InteractableObject intObj;

		public EmployeeHome EmployeeStationThing;

		public MeshRenderer BlanketMesh;

		[Header("Materials")]
		public Material DefaultBlanket;

		public Material BotanistBlanket;

		public Material ChemistBlanket;

		public Material PackagerBlanket;

		public Material CleanerBlanket;

		private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EBedAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EBedAssembly_002DCSharp_002Edll_Excuted;

		public Employee AssignedEmployee => null;

		public virtual void Awake()
		{
		}

		public void Hovered()
		{
		}

		public void Interacted()
		{
		}

		private bool CanSleep(out string noSleepReason)
		{
			noSleepReason = null;
			return false;
		}

		public void UpdateMaterial()
		{
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void Awake_UserLogic_ScheduleOne_002EObjectScripts_002EBed_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
