using System;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;

namespace NodeCanvas.Framework.Internal
{
	public class fsBBParameterProcessor : fsRecoveryProcessor<BBParameter, MissingBBParameterType>
	{
		public override void OnBeforeDeserializeAfterInstanceCreation(Type storageType, object instance, ref fsData data)
		{
		}
	}
}
