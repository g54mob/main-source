using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common.Audio;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class AudioManager : Singleton<AudioManager>, IGameSave
	{
		protected override bool SurviveSceneLoads => true;

		public Volume Volume { get; private set; } = new Volume();

		public SoundEffect SoundEffect { get; private set; }

		public Ambient Ambient { get; private set; }

		public Music Music { get; private set; }

		public Speech Speech { get; private set; }

		public UserInterface UserInterface { get; private set; }

		public string SaveID => "volumes";

		public bool IsShared => true;

		public Type SaveType => typeof(Volume);

		public LoadMode LoadMode => LoadMode.Greedy;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void OnSubsystemsInit()
		{
			Singleton<AudioManager>.Instance.WakeUp();
		}

		protected override void OnCreate()
		{
			base.OnCreate();
			Transform transform = CreateParent("Sound Effects");
			Transform transform2 = CreateParent("Ambient");
			Transform transform3 = CreateParent("Music");
			Transform transform4 = CreateParent("Speech");
			Transform transform5 = CreateParent("User Interface");
			SoundEffect = new SoundEffect(transform.transform);
			Ambient = new Ambient(transform2.transform);
			Music = new Music(transform3.transform);
			Speech = new Speech(transform4.transform);
			UserInterface = new UserInterface(transform5.transform);
			SaveLoadManager.Subscribe(this);
		}

		private void Update()
		{
			Volume.Update();
			SoundEffect.Update();
			Ambient.Update();
			Music.Update();
			Speech.Update();
			UserInterface.Update();
		}

		private async Task StopAll(float duration)
		{
			await Task.WhenAll(SoundEffect.StopAll(duration), Ambient.StopAll(duration), Music.StopAll(duration), Speech.StopAll(duration), UserInterface.StopAll(duration));
		}

		private Transform CreateParent(string id)
		{
			GameObject obj = new GameObject(id);
			obj.transform.SetParent(base.transform);
			return obj.transform;
		}

		public object GetSaveData(bool includeNonSavable)
		{
			return Volume;
		}

		public Task OnLoad(object value)
		{
			StopAll(0.5f);
			Volume = (value as Volume) ?? new Volume();
			return Task.FromResult(result: true);
		}
	}
}
