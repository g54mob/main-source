using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardDeveloperPromise : IRewardMetagame
	{
		[SerializeField]
		private string _promiseText;

		public string PromiseText => _promiseText;

		public override void Apply(Metagame metagame)
		{
		}

		public override string Description(Objective objective)
		{
			return _promiseText;
		}

		public static RewardDeveloperPromise Create(string developerPromiseText)
		{
			return new RewardDeveloperPromise
			{
				_promiseText = developerPromiseText
			};
		}
	}
}
