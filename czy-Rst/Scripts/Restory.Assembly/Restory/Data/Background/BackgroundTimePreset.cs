using Restory.Gameplay.TimeSystems;
using UnityEngine;

namespace Restory.Data.Background
{
	[CreateAssetMenu(menuName = "Restory/Background/BackgroundTimePreset", fileName = "BackgroundTimePreset")]
	public class BackgroundTimePreset : ScriptableObject
	{
		[SerializeField]
		private TimeOfDay timeOfDay;

		[SerializeField]
		private Color color = Color.white;

		[SerializeField]
		[Range(0f, 1f)]
		private float intensity = 1f;

		public TimeOfDay TimeOfDay => timeOfDay;

		public Color Color => color;

		public float Intensity => intensity;
	}
}
