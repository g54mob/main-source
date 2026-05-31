using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class ShaderVariable
	{
		public string Name;

		private int? _id;

		public int ID
		{
			get
			{
				if (!_id.HasValue)
				{
					_id = Shader.PropertyToID(Name);
				}
				return _id.Value;
			}
		}

		public static implicit operator int(ShaderVariable variable)
		{
			return variable.ID;
		}
	}
}
