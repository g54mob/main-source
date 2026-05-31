using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(-1)]
	public class Outlines : MonoSingleton<Outlines>
	{
		[field: SerializeField]
		public SerializableDictionary<EOutline, OutlineData> Data { get; private set; } = new SerializableDictionary<EOutline, OutlineData>();

		public void Remove(Renderer rend)
		{
			foreach (OutlineData value in Data.Values)
			{
				value.Remove(rend);
			}
		}

		public void Remove(IEnumerable<Renderer> p_renderers)
		{
			foreach (OutlineData value in Data.Values)
			{
				value.Remove(p_renderers);
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
