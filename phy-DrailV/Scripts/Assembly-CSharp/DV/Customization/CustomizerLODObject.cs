using System.Runtime.CompilerServices;
using UnityEngine;

namespace DV.Customization
{
	public class CustomizerLODObject : MonoBehaviour
	{
		public Customization.CustomizerBase Base { get; private set; }

		public bool IsOnTrainCar
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Base.Custom is TrainCarCustomization;
			}
		}

		protected internal virtual void OnPowerStateChanged(bool newValue)
		{
		}

		internal virtual void SetBase(Customization.CustomizerBase associatedBase)
		{
			Base = associatedBase;
		}
	}
	public class CustomizerLODObject<T> : CustomizerLODObject where T : Customization.CustomizerBase
	{
		private T castedBase;

		public new T Base => castedBase;

		internal override void SetBase(Customization.CustomizerBase associatedBase)
		{
			base.SetBase(associatedBase);
			castedBase = associatedBase as T;
			if (castedBase == null)
			{
				Debug.LogError("A customizer LOD object requires base type '" + typeof(T).Name + "', but '" + associatedBase.GetType().Name + "' was provided!");
			}
		}
	}
}
