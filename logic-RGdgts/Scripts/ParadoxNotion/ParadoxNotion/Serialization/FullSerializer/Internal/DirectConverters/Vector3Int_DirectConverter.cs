using System;
using System.Collections.Generic;
using UnityEngine;

namespace ParadoxNotion.Serialization.FullSerializer.Internal.DirectConverters
{
	public class Vector3Int_DirectConverter : fsDirectConverter<Vector3Int>
	{
		protected override fsResult DoSerialize(Vector3Int model, Dictionary<string, fsData> serialized)
		{
			return default(fsResult);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Vector3Int model)
		{
			return default(fsResult);
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return null;
		}
	}
}
