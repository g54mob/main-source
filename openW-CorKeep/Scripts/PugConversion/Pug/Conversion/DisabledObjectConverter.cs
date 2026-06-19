using Unity.Entities;
using UnityEngine;

namespace Pug.Conversion
{
	public class DisabledObjectConverter : Converter
	{
		public override void Convert(GameObject authoring)
		{
			if (!authoring.activeSelf)
			{
				EnsureHasComponent<Disabled>();
			}
		}
	}
}
