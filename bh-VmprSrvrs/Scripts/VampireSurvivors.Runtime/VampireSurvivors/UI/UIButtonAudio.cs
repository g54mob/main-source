using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class UIButtonAudio : MonoBehaviour
	{
		[FormerlySerializedAs("Sound")]
		public SfxType _Sound;

		private Button _button;

		private void Start()
		{
		}

		private void Play()
		{
		}
	}
}
