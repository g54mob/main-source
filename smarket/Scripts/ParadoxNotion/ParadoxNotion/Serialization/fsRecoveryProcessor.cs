using System;
using ParadoxNotion.Serialization.FullSerializer;

namespace ParadoxNotion.Serialization
{
	public class fsRecoveryProcessor<TCanProcess, TMissing> : fsObjectProcessor
	{
		private const string FIELD_NAME_TYPE = "_missingType";

		private const string FIELD_NAME_STATE = "_recoveryState";

		public override bool CanProcess(Type type)
		{
			return false;
		}

		public override void OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}
	}
}
