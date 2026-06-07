using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TNRD
{
	[Serializable]
	public class SerializableInterface<TInterface> : ISerializableInterface where TInterface : class
	{
		[HideInInspector]
		[SerializeField]
		private ReferenceMode mode;

		[HideInInspector]
		[SerializeField]
		private UnityEngine.Object unityReference;

		[SerializeReference]
		[UsedImplicitly]
		private object rawReference;

		public TInterface Value
		{
			get
			{
				return mode switch
				{
					ReferenceMode.Raw => rawReference as TInterface, 
					ReferenceMode.Unity => unityReference as TInterface, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			set
			{
				if (value is UnityEngine.Object obj)
				{
					rawReference = null;
					unityReference = obj;
					mode = ReferenceMode.Unity;
				}
				else
				{
					unityReference = null;
					rawReference = value;
					mode = ReferenceMode.Raw;
				}
			}
		}

		public SerializableInterface()
		{
		}

		public SerializableInterface(TInterface value)
		{
			Value = value;
		}

		object ISerializableInterface.GetRawReference()
		{
			return rawReference;
		}

		public bool TryGetObject(out UnityEngine.Object unityObject)
		{
			unityObject = null;
			if (mode != ReferenceMode.Unity)
			{
				return false;
			}
			unityObject = unityReference;
			return true;
		}
	}
}
