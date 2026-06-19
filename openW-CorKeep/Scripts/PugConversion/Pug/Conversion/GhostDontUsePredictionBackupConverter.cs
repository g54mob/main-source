using Unity.NetCode;
using UnityEngine;

namespace Pug.Conversion
{
	public class GhostDontUsePredictionBackupConverter : Converter
	{
		public override void Convert(GameObject authoring)
		{
			if (TryGetActiveComponent<GhostAuthoringComponent>(authoring, out var component) && component.DontUsePredictionBackup)
			{
				EnsureHasComponent<DontUsePredictionBackup>();
			}
		}
	}
}
