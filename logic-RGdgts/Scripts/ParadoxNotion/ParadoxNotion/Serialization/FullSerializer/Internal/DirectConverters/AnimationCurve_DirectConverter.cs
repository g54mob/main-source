using System;
using System.Collections.Generic;
using UnityEngine;

namespace ParadoxNotion.Serialization.FullSerializer.Internal.DirectConverters
{
	public class AnimationCurve_DirectConverter : fsDirectConverter<AnimationCurve>
	{
		protected override fsResult DoSerialize(AnimationCurve model, Dictionary<string, fsData> serialized)
		{
			return default(fsResult);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref AnimationCurve model)
		{
			return default(fsResult);
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return null;
		}
	}
}
