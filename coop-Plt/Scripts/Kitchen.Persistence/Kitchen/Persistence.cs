using System.IO;
using System.Threading.Tasks;
using Platforms;
using Platforms.BackCompatibility;
using UnityEngine;

namespace Kitchen
{
	public static class Persistence
	{
		private const int MultiSaveCount = 5;

		public static ProfileSaveSystem Profile;

		public static PackProgressionSaveSystem Progress;

		public static FullWorldSaveSystem FullWorld;

		public static SaveStorage<Nothing> PreferencesFile;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		private static void InitOnLoad()
		{
			Platform current = Platform.Current;
			SaveStorage<Nothing> save_storage = new SaveStorage<Nothing>(current, "Profile");
			SaveStorage<ProgressInfo> save_storage2 = new SaveStorage<ProgressInfo>(current, "Progress");
			SaveStorage<Nothing>[] array = new SaveStorage<Nothing>[5];
			for (int i = 0; i < array.Length; i++)
			{
				string directory = Path.Combine("Full", (i + 1).ToString());
				array[i] = new SaveStorage<Nothing>(current, directory);
			}
			Profile = new ProfileSaveSystem(save_storage);
			Progress = new PackProgressionSaveSystem(save_storage2);
			FullWorld = new FullWorldSaveSystem(array, Progress);
			PostLoadingInstructionManager.RegisterPostLoadingTasks(InstructionGroup.Dependent, (ImportFileSystemInMemorySave.ConvertOldData, "Convert FSIM"));
			PostLoadingInstructionManager.RegisterPostLoadingTasks(InstructionGroup.LoadFiles, (Profile.Initialise, "Profile Persistence"), (Progress.Initialise, "Progress Persistence"), (FullWorld.Initialise, "FullWorld Persistence"));
			if (PlatformSettings.UseFileForPreferences)
			{
				PreferencesFile = new SaveStorage<Nothing>(current, "Preferences");
				PostLoadingInstructionManager.RegisterPostLoadingTasks(InstructionGroup.LoadFiles, (async delegate
				{
					await PreferencesFile.Initialise();
				}, "Preferences"));
			}
		}

		public static async Task PostInit()
		{
			await ImportFileSystemInMemorySave.ConvertOldData();
			await Task.WhenAll(Profile.Initialise(), Progress.Initialise(), FullWorld.Initialise());
		}
	}
}
