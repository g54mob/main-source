using System;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	public class BBObjectParameter : BBParameter<object>, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string _type;

		private Type type { get; set; }

		public override Type varType => null;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public BBObjectParameter()
		{
		}

		public BBObjectParameter(Type t)
		{
		}

		public BBObjectParameter(BBParameter source)
		{
		}

		public void SetType(Type t)
		{
		}
	}
}
