using System;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	[fsAutoInstance(false)]
	public sealed class TaskAgentParameter : BBParameter<UnityEngine.Object>
	{
		[SerializeField]
		private Type _type;

		public override Type varType => null;

		public new UnityEngine.Object value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override object GetValueBoxed()
		{
			return null;
		}

		public override void SetValueBoxed(object newValue)
		{
		}

		public void SetType(Type newType)
		{
		}
	}
}
