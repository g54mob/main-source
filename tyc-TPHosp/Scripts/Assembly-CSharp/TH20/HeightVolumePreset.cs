using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Height Volume Preset", order = 1024)]
	public class HeightVolumePreset : ScriptableObjectWithID
	{
		public AnimationCurve HeightVolumeCurve = AnimationCurve.Linear(0f, 100f, 1f, 0f);
	}
}
