using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/AudioClip List", order = 2000)]
	public class AudioClipListVar : ScriptableList<AudioClip>
	{
		[MinMaxRange(-3f, 3f)]
		public RangedFloat pitch = new RangedFloat(1f, 1f);

		[MinMaxRange(0f, 1f)]
		public RangedFloat volume = new RangedFloat(1f, 1f);

		[Range(0f, 1f)]
		public float SpatialBlend = 1f;

		public bool PlayRandom = true;

		private int CurrentIndex;

		public void Play(AudioSource source)
		{
			AudioClip clip = (PlayRandom ? Item_GetRandom() : Item_Get(CurrentIndex));
			CurrentIndex++;
			source.clip = clip;
			source.pitch = pitch.RandomValue;
			source.volume = volume.RandomValue;
			source.spatialBlend = SpatialBlend;
			source.Play();
		}

		public void Play()
		{
			AudioSource audioSource = new GameObject
			{
				name = "Audio [" + base.name + "]"
			}.AddComponent<AudioSource>();
			audioSource.spatialBlend = 1f;
			AudioClip clip = Item_GetRandom();
			audioSource.clip = clip;
			audioSource.pitch = pitch.RandomValue;
			audioSource.volume = volume.RandomValue;
			audioSource.spatialBlend = SpatialBlend;
			audioSource.Play();
		}

		private void Reset()
		{
			Description = "Store a Collection of AudioClip";
		}
	}
}
