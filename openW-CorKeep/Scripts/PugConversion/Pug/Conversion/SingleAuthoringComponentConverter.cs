using System;
using UnityEngine;

namespace Pug.Conversion
{
	public abstract class SingleAuthoringComponentConverter<T> : Converter where T : MonoBehaviour
	{
		public sealed override Type RequireComponentTypeToRun => typeof(T);

		public sealed override void Convert(GameObject authoring)
		{
			T component = authoring.GetComponent<T>();
			Convert(component);
		}

		protected abstract void Convert(T authoring);
	}
}
