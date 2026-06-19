using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Patient")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PatientSpawn : LevelAction
	{
		[SerializeField]
		private SharedInstance_TH20TH20_IllnessDefinition _illness;

		[SerializeField]
		private SharedInstance_TH20TH20_ArrivalMethodDefinition _arrivalMethod;

		public override TaskStatus OnUpdate()
		{
			CharacterManager characterManager = base.Owner.Level.CharacterManager;
			IllnessDefinition illnessDefinition = (_illness.NotNull() ? _illness.Instance : characterManager.RandomIllness());
			ArrivalMethodDefinition arrivalMethod = (_arrivalMethod.NotNull() ? _arrivalMethod.Instance : null);
			characterManager.SpawnPatient(illnessDefinition, arrivalMethod, null);
			return TaskStatus.Success;
		}
	}
}
